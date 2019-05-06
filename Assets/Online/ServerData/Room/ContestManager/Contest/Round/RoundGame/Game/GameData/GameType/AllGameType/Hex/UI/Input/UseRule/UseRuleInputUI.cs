using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace HEX
{
    public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : InputUI.UIData.Sub
        {

            public VP<ReferenceData<Hex>> hex;

            public VP<int> keyX;

            public VP<int> keyY;

            #region Constructor

            public enum Property
            {
                hex,
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.hex = new VP<ReferenceData<Hex>>(this, (byte)Property.hex, new ReferenceData<Hex>(null));
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
            }

            #endregion

            public override Type getType()
            {
                return Type.UseRule;
            }

            public override bool processEvent(Event e)
            {
                // Debug.LogError ("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    if (InputEvent.isEnter(e))
                    {
                        // enter
                        UseRuleInputUI useRuleInputUI = this.findCallBack<UseRuleInputUI>();
                        if (useRuleInputUI != null)
                        {
                            useRuleInputUI.onEnterKey();
                        }
                        else
                        {
                            Debug.LogError("useRuleInputUI null: " + this);
                        }
                        isProcess = true;
                    }
                    else if (InputEvent.isArrow(e))
                    {
                        // find boardSize
                        int boardSize = 11;
                        {
                            Hex hex = this.hex.v.data;
                            if (hex != null)
                            {
                                boardSize = hex.boardSize.v;
                            }
                            else
                            {
                                Debug.LogError("hex null: " + this);
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
                                // bring to lastMove
                                int lastKeyX = boardSize / 2;
                                int lastKeyY = boardSize / 2;
                                {
                                    // find gameMove
                                    GameMove gameMove = null;
                                    {
                                        // Find gameData
                                        GameData gameData = null;
                                        {
                                            GameDataUI.UIData gameDataUIData = this.findDataInParent<GameDataUI.UIData>();
                                            if (gameDataUIData != null)
                                            {
                                                gameData = gameDataUIData.gameData.v.data;
                                            }
                                            else
                                            {
                                                Debug.LogError("gameDataUIData null: ");
                                            }
                                        }
                                        // Process
                                        if (gameData != null)
                                        {
                                            LastMove lastMove = gameData.lastMove.v;
                                            if (lastMove != null)
                                            {
                                                gameMove = lastMove.gameMove.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("lastMove null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("gameData null: " + data);
                                        }
                                    }
                                    // process
                                    if (gameMove != null)
                                    {
                                        switch (gameMove.getType())
                                        {
                                            case GameMove.Type.HexMove:
                                                {
                                                    HexMove hexMove = gameMove as HexMove;
                                                    lastKeyX = hexMove.move.v % boardSize;
                                                    lastKeyY = hexMove.move.v / boardSize;
                                                }
                                                break;
                                            case GameMove.Type.HexCustomSet:
                                                {
                                                    NoneRule.HexCustomSet hexCustomSet = gameMove as NoneRule.HexCustomSet;
                                                    lastKeyX = hexCustomSet.square.v % boardSize;
                                                    lastKeyY = hexCustomSet.square.v / boardSize;
                                                }
                                                break;
                                            case GameMove.Type.HexCustomMove:
                                                {
                                                    NoneRule.HexCustomMove hexCustomMove = gameMove as NoneRule.HexCustomMove;
                                                    lastKeyX = hexCustomMove.dest.v % boardSize;
                                                    lastKeyY = hexCustomMove.dest.v / boardSize;
                                                }
                                                break;
                                            case GameMove.Type.None:
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + gameMove.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameMove null: " + this);
                                    }
                                }
                                // set
                                this.keyX.v = lastKeyX;
                                this.keyY.v = lastKeyY;
                            }
                        }
                        else
                        {
                            Debug.LogError("boardSize too small: " + boardSize + "; " + this);
                        }
                        isProcess = true;
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            UseRuleInputUI useRuleInputUI = this.findCallBack<UseRuleInputUI>();
                            if (useRuleInputUI != null)
                            {
                                isProcess = useRuleInputUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("useRuleInputUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtSwitchSide = new TxtLanguage("Switch Side");

        static UseRuleInputUI()
        {
            txtSwitchSide.add(Language.Type.vi, "Đổi Bên");
        }

        #endregion

        #region Refresh

        public Button btnSwitchSide;
        public Text tvSwitchSide;

        public RectTransform rectTransform;

        public GameObject keySelect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Hex hex = this.data.hex.v.data;
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
                        // switchSideContainer
                        if (btnSwitchSide != null)
                        {
                            // Find BoardUIData
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
                                System.UInt16 boardSize = boardUIData.boardSize.v;
                                // check boardSize
                                if (boardSize >= Hex.MIN_BOARD_SIZE && boardSize <= Hex.MAX_BOARD_SIZE)
                                {
                                    // set width, heigth
                                    if (rectTransform != null)
                                    {
                                        rectTransform.sizeDelta = new Vector2(boardSize + boardSize * 0.5f, boardSize);
                                    }
                                    else
                                    {
                                        Debug.LogError("rectTransform null: " + this);
                                    }
                                    // switchSide Container
                                    if (btnSwitchSide != null)
                                    {
                                        if (hex.rounds() == 1 && hex.getPlayerIndex() == 1)
                                        {
                                            btnSwitchSide.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            btnSwitchSide.gameObject.SetActive(false);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("switchSideContainer null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("boardSize error: " + boardUIData.boardSize.v + "; " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("boardUIData null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("passContainer null: " + this);
                        }
                        // txt
                        {
                            if (tvSwitchSide != null)
                            {
                                tvSwitchSide.text = txtSwitchSide.get();
                            }
                            else
                            {
                                Debug.LogError("tvSwitchSide null");
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

        private HexGameDataUI.UIData hexGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.hexGameDataUIData);
                }
                // Child
                {
                    uiData.hex.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is HexGameDataUI.UIData)
                {
                    HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
                    // Child
                    {
                        hexGameDataUIData.board.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is BoardUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            if (data is Hex)
            {
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
                // Setting
                Setting.get().removeCallBack(this);
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.hexGameDataUIData);
                }
                // Child
                {
                    uiData.hex.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is HexGameDataUI.UIData)
                {
                    HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
                    // Child
                    {
                        hexGameDataUIData.board.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is BoardUI.UIData)
                {
                    return;
                }
            }
            // Child
            if (data is Hex)
            {
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
                    case UIData.Property.hex:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
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
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is HexGameDataUI.UIData)
                {
                    switch ((HexGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case HexGameDataUI.UIData.Property.gameData:
                            break;
                        case HexGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case HexGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case HexGameDataUI.UIData.Property.board:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case HexGameDataUI.UIData.Property.lastMove:
                            break;
                        case HexGameDataUI.UIData.Property.showHint:
                            break;
                        case HexGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is BoardUI.UIData)
                {
                    switch ((BoardUI.UIData.Property)wrapProperty.n)
                    {
                        case BoardUI.UIData.Property.hex:
                            break;
                        case BoardUI.UIData.Property.boardSize:
                            dirty = true;
                            break;
                        case BoardUI.UIData.Property.pieces:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        private void clickMove(ushort move)
        {
            if (this.data != null)
            {
                Hex hex = null;
                // Check isActive
                bool isActive = false;
                {
                    hex = this.data.hex.v.data;
                    if (hex != null)
                    {
                        if (Game.IsPlaying(hex))
                        {
                            isActive = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("weiqi null: " + this);
                        return;
                    }
                }
                if (isActive)
                {
                    if (Core.unityIsLegalMove(hex, Core.CanCorrect, move))
                    {
                        // Send
                        ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                        if (clientInput != null)
                        {
                            HexMove hexMove = new HexMove();
                            {
                                hexMove.move.v = move;
                            }
                            clientInput.makeSend(hexMove);
                        }
                        else
                        {
                            Debug.LogError("clientInput null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("not legal move: " + move + "; " + this);
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
                    Hex hex = this.data.hex.v.data;
                    if (hex != null)
                    {
                        boardSize = hex.boardSize.v;
                    }
                    else
                    {
                        Debug.LogError("hex null: " + this);
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
            if (this.data != null)
            {
                // find move
                System.UInt16 move = System.UInt16.MaxValue;
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
                        move = Common.GetIndex(localPosition, boardUIData);
                    }
                    else
                    {
                        Debug.LogError("boardUIData null: " + this);
                    }
                }
                // Debug.LogError ("onClickMove: " + Common.printMove (move, boardSize));
                this.clickMove(move);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #region Click Button

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnSwitchSide, onClickBtnSwitchSide);
            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.S:
                            {
                                if (btnSwitchSide != null && btnSwitchSide.gameObject.activeInHierarchy && btnSwitchSide.interactable)
                                {
                                    this.onClickBtnSwitchSide();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnSwitchSide()
        {
            if (this.data != null)
            {
                Hex hex = null;
                // Check isActive
                bool isActive = false;
                {
                    hex = this.data.hex.v.data;
                    if (hex != null)
                    {
                        if (Game.IsPlaying(hex))
                        {
                            isActive = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("weiqi null: " + this);
                        return;
                    }
                }
                if (isActive)
                {
                    // Send
                    ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                    if (clientInput != null)
                    {
                        clientInput.makeSend(new HexSwitch());
                    }
                    else
                    {
                        Debug.LogError("clientInput null: " + this);
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

        #endregion

    }
}