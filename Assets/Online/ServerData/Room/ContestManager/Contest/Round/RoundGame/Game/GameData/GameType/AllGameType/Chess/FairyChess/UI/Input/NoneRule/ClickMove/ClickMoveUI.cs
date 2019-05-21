using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace FairyChess.NoneRule
{
    public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<int> x;

            public VP<int> y;

            #region keyEvent

            public VP<int> keyX;

            public VP<int> keyY;

            #endregion

            #region Constructor

            public enum Property
            {
                x,
                y,
                keyX,
                keyY
            }

            public UIData() : base()
            {
                this.x = new VP<int>(this, (byte)Property.x, 0);
                this.y = new VP<int>(this, (byte)Property.y, 0);
                // keyEvent
                {
                    this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
                    this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
                }
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
                            if (newKeyX >= 0 && newKeyX < 8
                                && newKeyY >= 0 && newKeyY < 8)
                            {
                                this.keyX.v = newKeyX;
                                this.keyY.v = newKeyY;
                            }
                        }
                        else
                        {
                            this.keyX.v = this.x.v;
                            this.keyY.v = this.y.v;
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

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.FairyChess ? 1 : 0;
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
                            if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
                                && this.data.keyY.v >= 0 && this.data.keyY.v < 8)
                            {
                                keySelect.SetActive(true);
                                keySelect.transform.localPosition = Common.convertXYToLocalPosition(this.data.keyX.v, this.data.keyY.v);
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
                    // find fairyChess
                    FairyChess fairyChess = null;
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                        if (noneRuleInputUIData != null)
                        {
                            fairyChess = noneRuleInputUIData.fairyChess.v.data;
                        }
                        else
                        {
                            Debug.LogError("noneRuleInputUIData null: " + this);
                        }
                    }
                    // Process
                    if (fairyChess != null)
                    {
                        // clickPiece?
                        {
                            // find isClickPiece
                            bool isClickPiece = false;
                            {
                                Common.Square square = Common.make_square((Common.File)this.data.x.v, (Common.Rank)this.data.y.v);
                                Common.Piece piece = fairyChess.piece_on(square);
                                if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.PIECE_NB)
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
                                ivSelect.transform.localPosition = Common.convertXYToLocalPosition(this.data.x.v, this.data.y.v);
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
                        Debug.LogError("fairyChess null: " + this);
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
                        noneRuleInputUIData.fairyChess.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is FairyChess)
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
                        noneRuleInputUIData.fairyChess.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is FairyChess)
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
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
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
                        case NoneRuleInputUI.UIData.Property.fairyChess:
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
                if (wrapProperty.p is FairyChess)
                {
                    switch ((FairyChess.Property)wrapProperty.n)
                    {
                        case FairyChess.Property.board:
                            dirty = true;
                            break;
                        case FairyChess.Property.unpromotedBoard:
                            break;
                        case FairyChess.Property.byTypeBB:
                            break;
                        case FairyChess.Property.byColorBB:
                            break;
                        case FairyChess.Property.pieceCount:
                            break;
                        case FairyChess.Property.pieceList:
                            break;
                        case FairyChess.Property.index:
                            break;
                        case FairyChess.Property.castlingRightsMask:
                            break;
                        case FairyChess.Property.castlingRookSquare:
                            break;
                        case FairyChess.Property.castlingPath:
                            break;
                        case FairyChess.Property.gamePly:
                            break;
                        case FairyChess.Property.sideToMove:
                            break;
                        case FairyChess.Property.variantType:
                            break;
                        case FairyChess.Property.st:
                            break;
                        case FairyChess.Property.chess960:
                            break;
                        case FairyChess.Property.pieceCountInHand:
                            break;
                        case FairyChess.Property.promotedPieces:
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
                FairyChess fairyChess = null;
                // Check isActive
                bool isActive = false;
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                    if (noneRuleInputUIData != null)
                    {
                        fairyChess = noneRuleInputUIData.fairyChess.v.data;
                        if (fairyChess != null)
                        {
                            if (Game.IsPlaying(fairyChess))
                            {
                                isActive = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("fairyChess null: " + this);
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
                        if (this.data.x.v == x && this.data.y.v == y)
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
                                FairyChessCustomMove fairyChessCustomMove = new FairyChessCustomMove();
                                {
                                    fairyChessCustomMove.fromX.v = this.data.x.v;
                                    fairyChessCustomMove.fromY.v = this.data.y.v;
                                    fairyChessCustomMove.destX.v = x;
                                    fairyChessCustomMove.destY.v = y;
                                }
                                clientInput.makeSend(fairyChessCustomMove);
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
            // get x, y
            int x = -1;
            int y = -1;
            {
                Vector3 localPosition = transform.InverseTransformPoint(eventData.position);
                Common.convertLocalPositionToXY(localPosition, out x, out y);
                // Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
            }
            this.clickMove(x, y);
        }

        #region back

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {

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
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

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