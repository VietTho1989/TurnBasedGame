using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
    public class ShowPhasePlayingDestUI : UIBehavior<ShowPhasePlayingDestUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : ShowPhasePlayingUI.UIData.Sub
        {

            public VP<int> from;

            #region keyEvent

            public VP<int> keyX;

            public VP<int> keyY;

            #endregion

            public LP<ShowPhasePlayingLegalMoveUI.UIData> legalMoves;

            #region Constructor

            public enum Property
            {
                from,
                keyX,
                keyY,
                legalMoves
            }

            public UIData() : base()
            {
                this.from = new VP<int>(this, (byte)Property.from, 0);
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
                this.legalMoves = new LP<ShowPhasePlayingLegalMoveUI.UIData>(this, (byte)Property.legalMoves);
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickDest;
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
                                    Common.parsePositionToXY(this.from.v, out lastKeyX, out lastKeyY);
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
                            ivSelect.transform.localPosition = Common.convertPositionToLocal(this.data.from.v);
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
                    // legalMoves
                    {
                        // find oldUI
                        List<ShowPhasePlayingLegalMoveUI.UIData> oldLegalMoveUIDatas = new List<ShowPhasePlayingLegalMoveUI.UIData>();
                        {
                            oldLegalMoveUIDatas.AddRange(this.data.legalMoves.vs);
                        }
                        // Update
                        {
                            // find legalMoves
                            List<NineMenMorrisMove> legalMoves = new List<NineMenMorrisMove>();
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    foreach (NineMenMorrisMove check in showUIData.legalMoves.vs)
                                    {
                                        if (check.moved.v == this.data.from.v)
                                        {
                                            legalMoves.Add(check);
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
                                // find UIData
                                ShowPhasePlayingLegalMoveUI.UIData legalMoveUIData = null;
                                bool needAdd = false;
                                {
                                    // find old
                                    if (oldLegalMoveUIDatas.Count > 0)
                                    {
                                        legalMoveUIData = oldLegalMoveUIDatas[0];
                                    }
                                    // make new
                                    if (legalMoveUIData == null)
                                    {
                                        legalMoveUIData = new ShowPhasePlayingLegalMoveUI.UIData();
                                        {
                                            legalMoveUIData.uid = this.data.legalMoves.makeId();
                                        }
                                        needAdd = true;
                                    }
                                    else
                                    {
                                        oldLegalMoveUIDatas.Remove(legalMoveUIData);
                                    }
                                }
                                // Update
                                {
                                    legalMoveUIData.nineMenMorrisMove.v = new ReferenceData<NineMenMorrisMove>(nineMenMorrisMove);
                                }
                                // Add
                                if (needAdd)
                                {
                                    this.data.legalMoves.add(legalMoveUIData);
                                }
                            }
                        }
                        // remove old
                        foreach (ShowPhasePlayingLegalMoveUI.UIData oldLegalMoveUIData in oldLegalMoveUIDatas)
                        {
                            this.data.legalMoves.remove(oldLegalMoveUIData);
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

        public ShowPhasePlayingLegalMoveUI legalMovePrefab;

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
                    uiData.legalMoves.allAddCallBack(this);
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
            if (data is ShowPhasePlayingLegalMoveUI.UIData)
            {
                ShowPhasePlayingLegalMoveUI.UIData legalMoveUIData = data as ShowPhasePlayingLegalMoveUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(legalMoveUIData, legalMovePrefab, this.transform);
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
                    uiData.legalMoves.allRemoveCallBack(this);
                }
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
            if (data is ShowPhasePlayingLegalMoveUI.UIData)
            {
                ShowPhasePlayingLegalMoveUI.UIData legalMoveUIData = data as ShowPhasePlayingLegalMoveUI.UIData;
                // UI
                {
                    legalMoveUIData.removeCallBackAndDestroy(typeof(ShowPhasePlayingLegalMoveUI));
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
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.from:
                        dirty = true;
                        break;
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
                        dirty = true;
                        break;
                    case UIData.Property.legalMoves:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
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
            if (wrapProperty.p is ShowPhasePlayingLegalMoveUI.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        #region IPointerDownHandler

        private void clickPiece(int x, int y)
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
                            // find legalMoves
                            List<NineMenMorrisMove> legalMoves = new List<NineMenMorrisMove>();
                            {
                                ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData>();
                                if (showUIData != null)
                                {
                                    foreach (NineMenMorrisMove check in showUIData.legalMoves.vs)
                                    {
                                        if (check.moved.v == this.data.from.v && check.moved_to.v == position)
                                        {
                                            legalMoves.Add(check);
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
                                if (this.data.from.v == position)
                                {
                                    // tro ve from
                                    ShowPhasePlayingUI.UIData playUIData = this.data.findDataInParent<ShowPhasePlayingUI.UIData>();
                                    if (playUIData != null)
                                    {
                                        ShowPhasePlayingFromUI.UIData fromUIData = new ShowPhasePlayingFromUI.UIData();
                                        {
                                            fromUIData.uid = playUIData.sub.makeId();
                                        }
                                        playUIData.sub.v = fromUIData;
                                    }
                                    else
                                    {
                                        Debug.LogError("playUIData null");
                                    }
                                }
                            }
                            else
                            {
                                // find only move
                                bool isOnlyMove = false;
                                {
                                    if (legalMoves.Count == 1)
                                    {
                                        if (!(legalMoves[0].removed.v >= 0 && legalMoves[0].removed.v < Common.BOARD_SPOT))
                                        {
                                            isOnlyMove = true;
                                        }
                                    }
                                }
                                // process
                                if (isOnlyMove)
                                {
                                    ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                                    if (clientInput != null)
                                    {
                                        clientInput.makeSend(legalMoves[0]);
                                    }
                                    else
                                    {
                                        Debug.LogError("clientInput null");
                                    }
                                }
                                else
                                {
                                    ShowPhasePlayingUI.UIData playUIData = this.data.findDataInParent<ShowPhasePlayingUI.UIData>();
                                    if (playUIData != null)
                                    {
                                        ShowPhasePlayingRemoveUI.UIData removeUIData = new ShowPhasePlayingRemoveUI.UIData();
                                        {
                                            removeUIData.uid = playUIData.sub.makeId();
                                            removeUIData.from.v = this.data.from.v;
                                            removeUIData.dest.v = position;
                                        }
                                        playUIData.sub.v = removeUIData;
                                    }
                                    else
                                    {
                                        Debug.LogError("playUIData null");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("outside board: " + position);
                        }
                    }
                    else
                    {
                        Debug.LogError("click outside board: " + this);
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
            // Debug.LogError ("OnPointerDown: " + eventData);
            // get x, y
            int x = -1;
            int y = -1;
            {
                Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                Common.convertLocalPositionToXY(localPosition, out x, out y);
                // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
            }
            this.clickPiece(x, y);
        }

        public void onEnterKey()
        {
            if (this.data != null)
            {
                this.clickPiece(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #endregion

    }
}