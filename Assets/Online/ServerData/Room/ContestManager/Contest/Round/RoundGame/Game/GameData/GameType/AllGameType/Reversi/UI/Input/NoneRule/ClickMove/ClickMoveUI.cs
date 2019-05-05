using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Reversi.NoneRule
{
    public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<sbyte> square;

            public VP<int> keyX;

            public VP<int> keyY;

            #region Constructor

            public enum Property
            {
                square,
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.square = new VP<sbyte>(this, (byte)Property.square, 0);
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickMove;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI>();
                        if (clickMoveUI != null)
                        {
                            clickMoveUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("clickMoveUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        if (this.keyX.v >= 0 && this.keyX.v < 8
                            && this.keyY.v >= 0 && this.keyY.v < 8)
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
                                        newKeyY--;
                                        break;
                                    case KeyCode.DownArrow:
                                        newKeyY++;
                                        break;
                                    default:
                                        Debug.LogError("unknown keyCode: " + e.keyCode);
                                        break;
                                }
                            }
                            // set
                            if (newKeyX >= 0 && newKeyX < 8
                                && newKeyY >= 0 && newKeyY < 8)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            this.keyX.v = this.square.v % 8;
                            this.keyY.v = this.square.v / 8;
                        }
                        isProcess = true;
                    }
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI>();
                            if (clickMoveUI != null)
                            {
                                clickMoveUI.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("clickMoveUI null");
                            }
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI>();
                            if (clickMoveUI != null)
                            {
                                isProcess = clickMoveUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("clickMoveUI null: " + this);
                            }
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
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 8)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertSquareToLocalPosition(this.data.keyX.v + 8 * this.data.keyY.v);
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
                    // find reversi
                    Reversi reversi = null;
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            reversi = noneRuleInputUIData.reversi.v.data;
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
                        }
                    }
                    // Process
                    if (reversi != null)
                    {
                        // clickPiece?
                        {
                            // find isClickPiece
                            bool isClickPiece = false;
                            {
                                if (reversi.getPiece(this.data.square.v) != Reversi.NONE)
                                {
                                    isClickPiece = true;
                                }
                            }
                            // Process
                            if (!isClickPiece)
                            {
                                // change to none
                                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                                if (noneRuleInputUIData != null)
                                {
                                    ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                                    {
                                        clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                                    }
                                    noneRuleInputUIData.sub.v = clickNoneUIData;
                                }
                                else
                                {
                                    Debug.LogError("noneRuleInputUIData null: " + this);
                                }
                            }
                        }
                        // imgSelect
                        {
                            if (ivSelect != null)
                            {
                                // position
                                ivSelect.transform.localPosition = Common.convertSquareToLocalPosition(this.data.square.v);
                                // Scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    ivSelect.transform.localScale = (playerView == 0 ? new Vector3(1f, 1f, 1f) : new Vector3(1f, -1f, 1f));
                                }
                            }
                            else
                            {
                                Debug.LogError("imgSelect null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("reversi null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return false;
        }

        #endregion

        #region implement callBacks

        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();
        private NoneRuleInputUI.UIData noneRuleInputUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.reversi.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Reversi)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Parent
            {
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.reversi.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Reversi)
                {
                    return;
                }
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
                    case UIData.Property.square:
                        dirty = true;
                        break;
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is NoneRuleInputUI.UIData)
                {
                    switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case NoneRuleInputUI.UIData.Property.reversi:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case NoneRuleInputUI.UIData.Property.sub:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Reversi)
                {
                    switch ((Reversi.Property)wrapProperty.n)
                    {
                        case Reversi.Property.side:
                            break;
                        case Reversi.Property.white:
                            dirty = true;
                            break;
                        case Reversi.Property.black:
                            dirty = true;
                            break;
                        case Reversi.Property.nMoveNum:
                            break;
                        case Reversi.Property.moves:
                            break;
                        case Reversi.Property.changes:
                            break;
                        case Reversi.Property.oldSides:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        private void clickMove(int x, int y)
        {
            if (this.data != null)
            {
                Reversi reversi = null;
                // Check isActive
                bool isActive = false;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        reversi = noneRuleInputUIData.reversi.v.data;
                        if (reversi != null)
                        {
                            if (Game.IsPlaying(reversi))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("reversi null: " + this);
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
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        sbyte square = (sbyte)(x + 8 * y);
                        if (this.data.square.v == square)
                        {
                            NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                            if (noneRuleInputUIData != null)
                            {
                                ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                                {
                                    clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                                }
                                noneRuleInputUIData.sub.v = clickNoneUIData;
                            }
                            else
                            {
                                Debug.LogError("noneRuleInputUIData null: " + this);
                            }
                        }
                        else
                        {
                            // send move
                            ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                            if (clientInput != null)
                            {
                                ReversiCustomMove reversiCustomMove = new ReversiCustomMove();
                                {
                                    reversiCustomMove.from.v = this.data.square.v;
                                    reversiCustomMove.dest.v = square;
                                }
                                clientInput.makeSend(reversiCustomMove);
                            }
                            else
                            {
                                Debug.LogError("clientInput null: " + this);
                            }
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

        public void onEnterKey()
        {
            if (this.data != null)
            {
                this.clickMove(this.data.keyX.v, this.data.keyY.v);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Debug.LogError ("OnPointerDown: " + eventData);
            // get square
            Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
            int x = Mathf.RoundToInt(localPosition.x + 3.5f);
            int y = 7 - Mathf.RoundToInt(localPosition.y + 3.5f);
            // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
            this.clickMove(x, y);
        }

        #region back

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                    {
                        clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                    }
                    noneRuleInputUIData.sub.v = clickNoneUIData;
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        #endregion

    }
}