using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
    public class ShowPhasePositioningRemoveUI : UIBehavior<ShowPhasePositioningRemoveUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : ShowPhasePositioningUI.UIData.Sub
        {

            public VP<int> position;

            #region keyEvent

            public VP<int> keyX;

            public VP<int> keyY;

            #endregion

            public LP<ShowPhasePositioningRemoveIndicatorUI.UIData> indicators;

            #region Constructor

            public enum Property
            {
                position,
                keyX,
                keyY,
                indicators
            }

            public UIData() : base()
            {
                this.position = new VP<int>(this, (byte)Property.position, 0);
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
                this.indicators = new LP<ShowPhasePositioningRemoveIndicatorUI.UIData>(this, (byte)Property.indicators);
            }

            #endregion

            public override Type getType()
            {
                return Type.Remove;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (!isProcess)
                    {
                        if (InputEvent.isEnter(e))
                        {
                            // enter
                            ShowPhasePositioningRemoveUI showPhasePositioningRemoveUI = this.findCallBack<ShowPhasePositioningRemoveUI>();
                            if (showPhasePositioningRemoveUI != null)
                            {
                                showPhasePositioningRemoveUI.onEnterKey();
                            }
                            else
                            {
                                Debug.LogError("showPhasePositioningRemoveUI null: " + this);
                            }
                            isProcess = true;
                        }
                        else if (InputEvent.isArrow(e))
                        {
                            if (this.keyX.v >= 0 && this.keyX.v <= 6
                                && this.keyY.v >= 0 && this.keyY.v <= 6)
                            {
                                // find new key position
                                int newKeyX = this.keyX.v;
                                int newKeyY = this.keyY.v;
                                {
                                    switch (e.keyCode)
                                    {
                                        case KeyCode.LeftArrow:
                                            newKeyX--;
                                            break;
                                        case KeyCode.RightArrow:
                                            newKeyX++;
                                            break;
                                        case KeyCode.UpArrow:
                                            newKeyY++;
                                            break;
                                        case KeyCode.DownArrow:
                                            newKeyY--;
                                            break;
                                        default:
                                            Debug.LogError("unknown keyCode: " + e.keyCode);
                                            break;
                                    }
                                }
                                // set
                                if (newKeyX >= 0 && newKeyX <= 6
                                    && newKeyY >= 0 && newKeyY <= 6)
                                {
                                    this.keyX.v = newKeyX;
                                    this.keyY.v = newKeyY;
                                }
                            }
                            else
                            {
                                // bring to lastMove
                                int lastKeyX = 3;
                                int lastKeyY = 3;
                                {
                                    Common.parsePositionToXY(this.position.v, out lastKeyX, out lastKeyY);
                                }
                                // set
                                this.keyX.v = lastKeyX;
                                this.keyY.v = lastKeyY;
                            }
                            isProcess = true;
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.NineMenMorris ? 1 : 0;
        }

        #region Refresh

        public GameObject ivSelect;

        public GameObject keySelect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (this.data.keyX.v >= 0 && this.data.keyX.v <= 6
                                && this.data.keyY.v >= 0 && this.data.keyY.v <= 6)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = new Vector2(this.data.keyX.v - 3, this.data.keyY.v - 3);
                            }
                            else
                            {
                                keySelect.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("keySelect null: " + this);
                        }
                    }
                    // imgSelect
                    {
                        if (ivSelect != null)
                        {
                            ivSelect.transform.localPosition = Common.convertPositionToLocal(this.data.position.v);
                            // TODO co the co rotate
                            {
                                // TODO Can hoan thien
                            }
                        }
                        else
                        {
                            Debug.LogError("imgSelect null: " + this);
                        }
                    }
                    // indicators
                    {
                        // get old
                        List<ShowPhasePositioningRemoveIndicatorUI.UIData> oldIndicators = new List<ShowPhasePositioningRemoveIndicatorUI.UIData>();
                        {
                            oldIndicators.AddRange(this.data.indicators.vs);
                        }
                        // Update
                        {
                            // find legalMove
                            List<NineMenMorrisMove> legalMoves = new List<NineMenMorrisMove>();
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    foreach (NineMenMorrisMove nineMenMorrisMove in showUIData.legalMoves.vs)
                                    {
                                        if (nineMenMorrisMove.action.v == Common.NMMAction.Place)
                                        {
                                            if (nineMenMorrisMove.moved.v == this.data.position.v)
                                            {
                                                legalMoves.Add(nineMenMorrisMove);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("showUIData null");
                                }
                            }
                            // Update
                            foreach (NineMenMorrisMove nineMenMorrisMove in legalMoves)
                            {
                                // Get UI
                                ShowPhasePositioningRemoveIndicatorUI.UIData indicatorUIData = null;
                                bool needAdd = false;
                                {
                                    // find old
                                    if (oldIndicators.Count > 0)
                                    {
                                        indicatorUIData = oldIndicators[0];
                                    }
                                    // make new
                                    if (indicatorUIData == null)
                                    {
                                        indicatorUIData = new ShowPhasePositioningRemoveIndicatorUI.UIData();
                                        {
                                            indicatorUIData.uid = this.data.indicators.makeId();
                                        }
                                        needAdd = true;
                                    }
                                    else
                                    {
                                        oldIndicators.Remove(indicatorUIData);
                                    }
                                }
                                // Update
                                {
                                    indicatorUIData.position.v = nineMenMorrisMove.removed.v;
                                }
                                // Add
                                if (needAdd)
                                {
                                    this.data.indicators.add(indicatorUIData);
                                }
                            }
                        }
                        // remove old
                        foreach (ShowPhasePositioningRemoveIndicatorUI.UIData oldIndicator in oldIndicators)
                        {
                            this.data.indicators.remove(oldIndicator);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return false;
        }

        #endregion

        #region implement callBacks

        public ShowPhasePositioningRemoveIndicatorUI indicatorPrefab;

        private ShowUI.UIData showUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.showUIData);
                }
                // Child
                {
                    uiData.indicators.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is ShowUI.UIData)
                {
                    ShowUI.UIData showUIData = data as ShowUI.UIData;
                    // Child
                    {
                        showUIData.legalMoves.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is NineMenMorrisMove)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            if (data is ShowPhasePositioningRemoveIndicatorUI.UIData)
            {
                ShowPhasePositioningRemoveIndicatorUI.UIData indicatorUIData = data as ShowPhasePositioningRemoveIndicatorUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(indicatorUIData, indicatorPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.showUIData);
                }
                // Child
                {
                    uiData.indicators.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is ShowUI.UIData)
                {
                    ShowUI.UIData showUIData = data as ShowUI.UIData;
                    // Child
                    {
                        showUIData.legalMoves.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is NineMenMorrisMove)
                {
                    return;
                }
            }
            // Child
            if (data is ShowPhasePositioningRemoveIndicatorUI.UIData)
            {
                ShowPhasePositioningRemoveIndicatorUI.UIData indicatorUIData = data as ShowPhasePositioningRemoveIndicatorUI.UIData;
                // UI
                {
                    indicatorUIData.removeCallBackAndDestroy(typeof(ShowPhasePositioningRemoveIndicatorUI));
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.position:
                    dirty = true;
                    break;
                case UIData.Property.keyX:
                    dirty = true;
                    break;
                case UIData.Property.keyY:
                    dirty = true;
                    break;
                case UIData.Property.indicators:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
                    break;
            }
            // Parent
            {
                if (wrapProperty.p is ShowUI.UIData)
                {
                    switch ((ShowUI.UIData.Property)wrapProperty.n)
                    {
                        case ShowUI.UIData.Property.legalMoves:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ShowUI.UIData.Property.sub:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is NineMenMorrisMove)
                {
                    switch ((NineMenMorrisMove.Property)wrapProperty.n)
                    {
                        case NineMenMorrisMove.Property.moved:
                            dirty = true;
                            break;
                        case NineMenMorrisMove.Property.moved_to:
                            dirty = true;
                            break;
                        case NineMenMorrisMove.Property.action:
                            dirty = true;
                            break;
                        case NineMenMorrisMove.Property.mill:
                            dirty = true;
                            break;
                        case NineMenMorrisMove.Property.removed:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            if (wrapProperty.p is ShowPhasePositioningRemoveIndicatorUI.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        private void clickRemove(int x, int y)
        {
            if (this.data != null)
            {
                NineMenMorris nineMenMorris = null;
                // Check isActive
                bool isActive = false;
                {
                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                    if (useRuleInputUIData != null)
                    {
                        nineMenMorris = useRuleInputUIData.nineMenMorris.v.data;
                        if (nineMenMorris != null)
                        {
                            if (Game.IsPlaying(nineMenMorris))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("nineMenMorris null: " + this);
                            return;
                        }
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUIData null: " + this);
                    }
                }
                if (isActive)
                {
                    if (x >= 0 && x <= 6 && y >= 0 && y <= 6)
                    {
                        int position = Common.ConvertXYToPosition(x, y);
                        if (position >= 0 && position < Common.BOARD_SPOT)
                        {
                            // find legalMove
                            List<NineMenMorrisMove> legalMoves = new List<NineMenMorrisMove>();
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    foreach (NineMenMorrisMove nineMenMorrisMove in showUIData.legalMoves.vs)
                                    {
                                        if (nineMenMorrisMove.action.v == Common.NMMAction.Place)
                                        {
                                            if (nineMenMorrisMove.moved.v == this.data.position.v && nineMenMorrisMove.removed.v == position)
                                            {
                                                legalMoves.Add(nineMenMorrisMove);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("showUIData null");
                                }
                            }
                            // process
                            if (legalMoves.Count == 0)
                            {
                                if (position == this.data.position.v)
                                {
                                    // tro ve place
                                    ShowPhasePositioningUI.UIData positioningUIData = this.data.findDataInParent<ShowPhasePositioningUI.UIData>();
                                    if (positioningUIData != null)
                                    {
                                        ShowPhasePositioningPlaceUI.UIData placeUIData = new ShowPhasePositioningPlaceUI.UIData();
                                        {
                                            placeUIData.uid = positioningUIData.sub.makeId();
                                        }
                                        positioningUIData.sub.v = placeUIData;
                                    }
                                    else
                                    {
                                        Debug.LogError("positioningUIData null");
                                    }
                                }
                            }
                            else if (legalMoves.Count == 1)
                            {
                                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                                if (clientInput != null)
                                {
                                    clientInput.makeSend(legalMoves[0]);
                                }
                                else
                                {
                                    Debug.LogError("clientInput null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("why have too many legalMoves");
                            }
                        }
                        else
                        {
                            Debug.LogError("position error");
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board");
                    }
                }
                else
                {
                    Debug.LogError("not active: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Debug.LogError ("OnPointerDown: " + eventData + "; " + this);
            int x = -1;
            int y = -1;
            {
                Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                Common.convertLocalPositionToXY(localPosition, out x, out y);
                // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
            }
            this.clickRemove(x, y);
        }

        public void onEnterKey()
        {
            if (this.data != null)
            {
                this.clickRemove(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}