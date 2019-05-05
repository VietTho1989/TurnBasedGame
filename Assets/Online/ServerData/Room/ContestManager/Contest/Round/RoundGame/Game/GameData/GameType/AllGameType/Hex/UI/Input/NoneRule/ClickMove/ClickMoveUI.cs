using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace HEX.NoneRule
{
    public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<ushort> square;

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
                this.square = new VP<ushort>(this, (byte)Property.square, 0);
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
                        // find boardSize
                        int boardSize = 11;
                        {
                            NoneRuleInputUI.UIData noneRuleInputUIData = this.findDataInParent<NoneRuleInputUI.UIData>();
                            if (noneRuleInputUIData != null)
                            {
                                Hex hex = noneRuleInputUIData.hex.v.data;
                                if (hex != null)
                                {
                                    boardSize = hex.boardSize.v;
                                }
                                else
                                {
                                    Debug.LogError("hex null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("noneRuleInputUIData null: " + this);
                            }
                        }
                        // Process
                        if (boardSize >= Hex.MIN_BOARD_SIZE)
                        {
                            if (this.keyX.v >= 0 && this.keyX.v < boardSize
                                && this.keyY.v >= 0 && this.keyY.v < boardSize)
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
                                if (newKeyX >= 0 && newKeyX < boardSize
                                    && newKeyY >= 0 && newKeyY < boardSize)
                                {
                                    this.keyX.v = newKeyX;
                                    this.keyY.v = newKeyY;
                                }
                            }
                            else
                            {
                                this.keyX.v = this.square.v % boardSize;
                                this.keyY.v = this.square.v / boardSize;
                            }
                        }
                        else
                        {
                            Debug.LogError("boardSize too small: " + boardSize + "; " + this);
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
                    // find hex
                    Hex hex = null;
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            hex = noneRuleInputUIData.hex.v.data;
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
                        }
                    }
                    // Process
                    if (hex != null)
                    {
                        // keySelect
                        {
                            if (keySelect != null)
                            {
                                ushort boardSize = hex.boardSize.v;
                                if (boardSize >= Hex.MIN_BOARD_SIZE)
                                {
                                    if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
                                        && this.data.keyY.v >= 0 && this.data.keyY.v < boardSize)
                                    {
                                        keySelect.SetActive(true);
                                        keySelect.transform.localPosition = Common.GetLocalPosition((ushort)(this.data.keyX.v + boardSize * this.data.keyY.v), this.data);
                                    }
                                    else
                                    {
                                        keySelect.SetActive(false);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("keySelect null: " + this);
                            }
                        }
                        // clickPiece?
                        {
                            // find isClickPiece
                            bool isClickPiece = false;
                            {
                                if (hex.getPiece(this.data.square.v) != (sbyte)Common.Color.Empty)
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
                                ivSelect.transform.localPosition = Common.GetLocalPosition(this.data.square.v, this.data);
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
                        Debug.LogError("hex null: " + this);
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
                        noneRuleInputUIData.hex.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Hex)
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
                        noneRuleInputUIData.hex.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Hex)
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
                        case NoneRuleInputUI.UIData.Property.hex:
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
                if (wrapProperty.p is Hex)
                {
                    switch ((Hex.Property)wrapProperty.n)
                    {
                        case Hex.Property.boardSize:
                            break;
                        case Hex.Property.board:
                            dirty = true;
                            break;
                        case Hex.Property.isSwitch:
                            break;
                        case Hex.Property.isCustom:
                            break;
                        case Hex.Property.playerIndex:
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

        private void clickMove(ushort square)
        {
            if (this.data != null)
            {
                Hex hex = null;
                // Check isActive
                bool isActive = false;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        hex = noneRuleInputUIData.hex.v.data;
                        if (hex != null)
                        {
                            if (Game.IsPlaying(hex))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("hex null: " + this);
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
                    if (square >= 0 && square < hex.boardSize.v * hex.boardSize.v)
                    {
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
                                HexCustomMove hexCustomMove = new HexCustomMove();
                                {
                                    hexCustomMove.from.v = this.data.square.v;
                                    hexCustomMove.dest.v = square;
                                }
                                clientInput.makeSend(hexCustomMove);
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
                // find boardSize
                ushort boardSize = 11;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        Hex hex = noneRuleInputUIData.hex.v.data;
                        if (hex != null)
                        {
                            boardSize = hex.boardSize.v;
                        }
                        else
                        {
                            Debug.LogError("hex null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("noneRuleInputUIData null: " + this);
                    }
                }
                // process
                if (boardSize >= Hex.MIN_BOARD_SIZE)
                {
                    if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
                        && this.data.keyY.v >= 0 && this.data.keyY.v < boardSize)
                    {
                        this.clickMove((ushort)(this.data.keyX.v + boardSize * this.data.keyY.v));
                    }
                    else
                    {
                        Debug.LogError("outside board: " + boardSize + ", " + this.data.keyX.v + ", " + this.data.keyY.v);
                    }
                }
                else
                {
                    Debug.LogError("boardSize too small: " + this);
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
            if (this.data != null)
            {
                System.UInt16 square = System.UInt16.MaxValue;
                {
                    Vector2 localPosition = transform.InverseTransformPoint(eventData.position);
                    // find boardUIData
                    BoardUI.UIData boardUIData = null;
                    {
                        HexGameDataUI.UIData hexGameDataUIData = this.data.findDataInParent<HexGameDataUI.UIData>();
                        if (hexGameDataUIData != null)
                        {
                            boardUIData = hexGameDataUIData.board.v;
                        }
                        else
                        {
                            Debug.LogError("hexGameDataUIData null: " + this);
                        }
                    }
                    // Process
                    if (boardUIData != null)
                    {
                        square = Common.GetIndex(localPosition, boardUIData);
                    }
                    else
                    {
                        Debug.LogError("boardUIData null: " + this);
                    }
                }
                this.clickMove(square);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
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