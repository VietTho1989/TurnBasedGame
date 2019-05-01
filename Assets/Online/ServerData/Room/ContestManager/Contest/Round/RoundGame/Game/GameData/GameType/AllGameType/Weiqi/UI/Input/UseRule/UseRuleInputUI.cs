using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Weiqi
{
    public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : InputUI.UIData.Sub
        {

            public VP<ReferenceData<Weiqi>> weiqi;

            public VP<int> keyX;

            public VP<int> keyY;

            public VP<UseRuleInputBtnUI.UIData> btn;

            #region Constructor

            public enum Property
            {
                weiqi,
                keyX,
                keyY,
                btn
            }

            public UIData() : base()
            {
                this.weiqi = new VP<ReferenceData<Weiqi>>(this, (byte)Property.weiqi, new ReferenceData<Weiqi>(null));
                this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
                this.btn = new VP<UseRuleInputBtnUI.UIData>(this, (byte)Property.btn, new UseRuleInputBtnUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.UseRule;
            }

            public override bool processEvent(Event e)
            {
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
                        int boardSize = 19;
                        {
                            Weiqi weiqi = this.weiqi.v.data;
                            if (weiqi != null)
                            {
                                boardSize = weiqi.b.v.size.v;
                            }
                            else
                            {
                                Debug.LogError("weiqi null: " + this);
                            }
                        }
                        // process
                        if (boardSize >= Weiqi.MinBoardSize)
                        {
                            if (this.keyX.v >= 1 && this.keyX.v < boardSize - 1
                                && this.keyY.v >= 1 && this.keyY.v < boardSize - 1)
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
                                if (newKeyX >= 1 && newKeyX < boardSize - 1
                                    && newKeyY >= 1 && newKeyY < boardSize - 1)
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
                                            case GameMove.Type.WeiqiMove:
                                                {
                                                    WeiqiMove weiqiMove = gameMove as WeiqiMove;
                                                    if (weiqiMove.coord.v > 0)
                                                    {
                                                        lastKeyX = weiqiMove.coord.v % boardSize;
                                                        lastKeyY = weiqiMove.coord.v / boardSize;
                                                    }
                                                }
                                                break;
                                            case GameMove.Type.WeiqiCustomSet:
                                                {
                                                    NoneRule.WeiqiCustomSet weiqiCustomSet = gameMove as NoneRule.WeiqiCustomSet;
                                                    if (weiqiCustomSet.coord.v > 0)
                                                    {
                                                        lastKeyX = weiqiCustomSet.coord.v % boardSize;
                                                        lastKeyY = weiqiCustomSet.coord.v / boardSize;
                                                    }
                                                }
                                                break;
                                            case GameMove.Type.WeiqiCustomMove:
                                                {
                                                    NoneRule.WeiqiCustomMove weiqiCustomMove = gameMove as NoneRule.WeiqiCustomMove;
                                                    if (weiqiCustomMove.dest.v > 0)
                                                    {
                                                        lastKeyX = weiqiCustomMove.dest.v % boardSize;
                                                        lastKeyY = weiqiCustomMove.dest.v / boardSize;
                                                    }
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
                            Debug.LogError("boardSize too small: " + this);
                        }
                        isProcess = true;
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public GameObject keySelect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // Find Weiqi
                    Weiqi weiqi = null;
                    {
                        WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.findDataInParent<WeiqiGameDataUI.UIData>();
                        if (weiqiGameDataUIData != null)
                        {
                            GameData gameData = weiqiGameDataUIData.gameData.v.data;
                            if (gameData != null)
                            {
                                if (gameData.gameType.v != null && gameData.gameType.v is Weiqi)
                                {
                                    weiqi = gameData.gameType.v as Weiqi;
                                }
                                else
                                {
                                    Debug.LogError("weiqi null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("gameData null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("weiqiGameDataUIData null: " + this);
                        }
                    }
                    // get board size
                    int boardSize = weiqi != null ? weiqi.b.v.size.v : 21;
                    {
                        if (boardSize < 5)
                        {
                            Debug.LogError("why boardSize small: " + boardSize + "; " + this);
                            boardSize = 5;
                        }
                    }
                    // keySelect
                    {
                        if (keySelect != null)
                        {
                            if (this.data.keyX.v >= 1 && this.data.keyX.v < boardSize - 1
                                && this.data.keyY.v >= 1 && this.data.keyY.v < boardSize - 1)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertCoordToLocalPosition(boardSize, this.data.keyX.v + boardSize * this.data.keyY.v);
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

        public UseRuleInputBtnUI btnPrefab;

        private WeiqiGameDataUI.UIData weiqiGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.weiqiGameDataUIData);
                }
                // Child
                {
                    uiData.btn.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is WeiqiGameDataUI.UIData)
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
                    // Child
                    {
                        weiqiGameDataUIData.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Child
                        {
                            gameData.gameType.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is GameType)
                        {
                            GameType gameType = data as GameType;
                            // Child
                            {
                                if (gameType is Weiqi)
                                {
                                    Weiqi weiqi = gameType as Weiqi;
                                    // Child
                                    {
                                        weiqi.b.allAddCallBack(this);
                                    }
                                }
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is Board)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Child
            if (data is UseRuleInputBtnUI.UIData)
            {
                UseRuleInputBtnUI.UIData btnUIData = data as UseRuleInputBtnUI.UIData;
                // UI
                {
                    Transform btnContainer = null;
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = btnUIData.findDataInParent<GameDataBoardUI.UIData>();
                        if (gameDataBoardUIData != null)
                        {
                            GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                            if (gameDataBoardUI != null)
                            {
                                btnContainer = gameDataBoardUI.transform;
                            }
                            else
                            {
                                Debug.LogError("gameDataBoardUI null");
                            }
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    UIUtils.Instantiate(btnUIData, btnPrefab, btnContainer);
                    // siblingIndex
                    UIRectTransform.SetSiblingIndex(btnUIData, 0);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.weiqiGameDataUIData);
                }
                // Child
                {
                    uiData.btn.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is WeiqiGameDataUI.UIData)
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
                    // Child
                    {
                        weiqiGameDataUIData.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // GameData
                {
                    if (data is GameData)
                    {
                        GameData gameData = data as GameData;
                        // Child
                        {
                            gameData.gameType.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is GameType)
                        {
                            GameType gameType = data as GameType;
                            // Child
                            {
                                if (gameType is Weiqi)
                                {
                                    Weiqi weiqi = gameType as Weiqi;
                                    // Child
                                    {
                                        weiqi.b.allRemoveCallBack(this);
                                    }
                                }
                            }
                            return;
                        }
                        // Child
                        if (data is Board)
                        {
                            return;
                        }
                    }
                }
            }
            // Child
            if (data is UseRuleInputBtnUI.UIData)
            {
                UseRuleInputBtnUI.UIData btnUIData = data as UseRuleInputBtnUI.UIData;
                // UI
                {
                    btnUIData.removeCallBackAndDestroy(typeof(UseRuleInputBtnUI));
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
                    case UIData.Property.weiqi:
                        dirty = true;
                        break;
                    case UIData.Property.keyX:
                        dirty = true;
                        break;
                    case UIData.Property.keyY:
                        dirty = true;
                        break;
                    case UIData.Property.btn:
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
                if (wrapProperty.p is WeiqiGameDataUI.UIData)
                {
                    switch ((WeiqiGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case WeiqiGameDataUI.UIData.Property.gameData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case WeiqiGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case WeiqiGameDataUI.UIData.Property.board:
                            break;
                        case WeiqiGameDataUI.UIData.Property.information:
                            break;
                        case WeiqiGameDataUI.UIData.Property.lastMove:
                            break;
                        case WeiqiGameDataUI.UIData.Property.showHint:
                            break;
                        case WeiqiGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GameData)
                    {
                        switch ((GameData.Property)wrapProperty.n)
                        {
                            case GameData.Property.gameType:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GameData.Property.useRule:
                                break;
                            case GameData.Property.turn:
                                break;
                            case GameData.Property.timeControl:
                                break;
                            case GameData.Property.lastMove:
                                break;
                            case GameData.Property.state:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is GameType)
                        {
                            if (wrapProperty.p is Weiqi)
                            {
                                switch ((Weiqi.Property)wrapProperty.n)
                                {
                                    case Weiqi.Property.b:
                                        {
                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                            dirty = true;
                                        }
                                        break;
                                    case Weiqi.Property.deadgroup:
                                        break;
                                    case Weiqi.Property.scoreOwnerMap:
                                        break;
                                    case Weiqi.Property.scoreOwnerMapSize:
                                        break;
                                    case Weiqi.Property.scoreBlack:
                                        break;
                                    case Weiqi.Property.scoreWhite:
                                        break;
                                    case Weiqi.Property.dame:
                                        break;
                                    case Weiqi.Property.score:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is Board)
                        {
                            switch ((Board.Property)wrapProperty.n)
                            {
                                case Board.Property.size:
                                    dirty = true;
                                    break;
                                case Board.Property.size2:
                                    break;
                                case Board.Property.bits2:
                                    break;
                                case Board.Property.captures:
                                    break;
                                case Board.Property.komi:
                                    break;
                                case Board.Property.handicap:
                                    break;
                                case Board.Property.rules:
                                    break;

                                case Board.Property.moves:
                                    break;
                                case Board.Property.last_move:
                                    break;
                                case Board.Property.last_move2:
                                    break;
                                case Board.Property.last_move3:
                                    break;
                                case Board.Property.last_move4:
                                    break;
                                case Board.Property.superko_violation:
                                    break;

                                case Board.Property.b:
                                    break;
                                case Board.Property.g:
                                    break;
                                case Board.Property.pp:
                                    break;

                                case Board.Property.pat3:
                                    break;

                                case Board.Property.gi:
                                    break;

                                case Board.Property.c:
                                    break;
                                case Board.Property.clen:
                                    break;

                                case Board.Property.symmetry:
                                    break;

                                case Board.Property.last_ko:
                                    break;
                                case Board.Property.last_ko_age:
                                    break;

                                case Board.Property.ko:
                                    break;

                                case Board.Property.quicked:
                                    break;

                                case Board.Property.history_hash:
                                    break;
                                case Board.Property.hash:
                                    break;
                                case Board.Property.qhash:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            // Child
            if (wrapProperty.p is UseRuleInputBtnUI.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        private void clickMove(int coord)
        {
            if (this.data != null)
            {
                Weiqi weiqi = null;
                // Check isActive
                bool isActive = false;
                {
                    weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        if (Game.IsPlaying(weiqi))
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
                    // get move
                    WeiqiMove move = new WeiqiMove();
                    {
                        // get coord
                        {
                            move.coord.v = coord;
                            // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y + "; " + move);
                        }
                        // get color
                        {
                            switch (weiqi.getPlayerIndex())
                            {
                                case 0:
                                    move.color.v = (int)Common.stone.S_BLACK;
                                    break;
                                case 1:
                                    move.color.v = (int)Common.stone.S_WHITE;
                                    break;
                                default:
                                    Debug.LogError("unknown playerIndex: " + weiqi.getPlayerIndex() + "; " + this);
                                    move.color.v = (int)Common.stone.S_BLACK;
                                    break;
                            }
                        }
                    }
                    // Debug.LogError ("onClickMove: " + Common.printMove (move, boardSize));
                    if (Core.unityIsLegalMove(weiqi, Core.CanCorrect, move))
                    {
                        // Send
                        ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                        if (clientInput != null)
                        {
                            clientInput.makeSend(move);
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
                // get board size
                int boardSize = 19;
                {
                    Weiqi weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        boardSize = weiqi.b.v.size.v;
                    }
                    else
                    {
                        Debug.LogError("weiqi null: " + this);
                    }
                    if (boardSize < 5)
                    {
                        Debug.LogError("why board size so small: " + this);
                        boardSize = 5;
                    }
                }
                // make move
                if (this.data.keyX.v >= 1 && this.data.keyX.v < boardSize - 1
                    && this.data.keyY.v >= 1 && this.data.keyY.v < boardSize - 1)
                {
                    this.clickMove(this.data.keyX.v + boardSize * this.data.keyY.v);
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
                // get board size
                int boardSize = 19;
                {
                    Weiqi weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        boardSize = weiqi.b.v.size.v;
                    }
                    else
                    {
                        Debug.LogError("weiqi null: " + this);
                    }
                    if (boardSize < 5)
                    {
                        Debug.LogError("why board size so small: " + this);
                        boardSize = 5;
                    }
                }
                // get x, y
                Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                int x = Mathf.RoundToInt(localPosition.x + boardSize / 2.0f - 0.5f);
                int y = Mathf.RoundToInt(localPosition.y + boardSize / 2.0f - 0.5f);
                // make move
                this.clickMove(x + boardSize * y);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #region Click Button

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnPass()
        {
            Debug.LogError("onClickBtnPass: " + this);
            this.onClickBtnPassOrResign(Common.pass);
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnResign()
        {
            Debug.LogError("onClickBtnResign: " + this);
            this.onClickBtnPassOrResign(Common.resign);
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnPassOrResign(int passOrResign)
        {
            if (this.data != null)
            {
                Weiqi weiqi = null;
                // Check isActive
                bool isActive = false;
                {
                    weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        if (Game.IsPlaying(weiqi))
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
                    // get move
                    WeiqiMove move = new WeiqiMove();
                    {
                        // coord
                        move.coord.v = passOrResign;
                        // get color
                        {
                            switch (weiqi.getPlayerIndex())
                            {
                                case 0:
                                    move.color.v = (int)Common.stone.S_BLACK;
                                    break;
                                case 1:
                                    move.color.v = (int)Common.stone.S_WHITE;
                                    break;
                                default:
                                    Debug.LogError("unknown playerIndex: " + weiqi.getPlayerIndex() + "; " + this);
                                    move.color.v = (int)Common.stone.S_BLACK;
                                    break;
                            }
                        }
                    }
                    // Debug.LogError ("onClickMove: " + Common.printMove (move, boardSize));
                    if (Core.unityIsLegalMove(weiqi, Core.CanCorrect, move))
                    {
                        // Send
                        ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                        if (clientInput != null)
                        {
                            clientInput.makeSend(move);
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

        #endregion

    }
}