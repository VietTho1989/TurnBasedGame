using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.UseRule
{
    public class BtnChosenMoveHolder : SriaHolderBehavior<BtnChosenMoveHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<ShogiMove>> shogiMove;

            public VP<OnClick> onClick;

            #region Constructor

            public enum Property
            {
                shogiMove,
                onClick
            }

            public UIData() : base()
            {
                this.shogiMove = new VP<ReferenceData<ShogiMove>>(this, (byte)Property.shogiMove, new ReferenceData<ShogiMove>(null));
                this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
            }

            #endregion

            public void updateView(BtnChosenMoveAdapter.UIData myParams)
            {
                // Find
                ShogiMove shogiMove = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.shogiMoves.Count)
                    {
                        shogiMove = myParams.shogiMoves[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.shogiMove.v = new ReferenceData<ShogiMove>(shogiMove);
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnChosenMoveHolder btnChosenMoveHolder = this.findCallBack<BtnChosenMoveHolder>();
                            if (btnChosenMoveHolder != null)
                            {
                                isProcess = btnChosenMoveHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnChosenMoveHolder null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        public interface OnClick
        {
            void onClickMove(ShogiMove shogiMove);
        }

        #endregion

        #region Refresh

        public Image imgPiece;

        public Text tvMoveType;
        public Text tvMove;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ShogiMove shogiMove = this.data.shogiMove.v.data;
                    if (shogiMove != null)
                    {
                        // imgPromotion
                        {
                            if (imgPiece != null)
                            {
                                // find piece
                                Common.Piece piece = Common.Piece.Empty;
                                {
                                    Common.PieceType pieceType = shogiMove.pieceTypeTo();
                                    // Find playerIndex
                                    int playerIndex = 0;
                                    {
                                        ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData>();
                                        if (shogiGameDataUIData != null)
                                        {
                                            GameData gameData = shogiGameDataUIData.gameData.v.data;
                                            if (gameData != null)
                                            {
                                                Turn turn = gameData.turn.v;
                                                if (turn != null)
                                                {
                                                    playerIndex = turn.playerIndex.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("turn null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("gameData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("shogiGameDataUIData null: " + this);
                                        }
                                    }
                                    // Process
                                    switch (playerIndex)
                                    {
                                        case 0:
                                            {
                                                switch (pieceType)
                                                {
                                                    case Common.PieceType.Pawn:
                                                        piece = Common.Piece.BPawn;
                                                        break;
                                                    case Common.PieceType.Lance:
                                                        piece = Common.Piece.BLance;
                                                        break;
                                                    case Common.PieceType.Knight:
                                                        piece = Common.Piece.BKnight;
                                                        break;
                                                    case Common.PieceType.Silver:
                                                        piece = Common.Piece.BSilver;
                                                        break;
                                                    case Common.PieceType.Bishop:
                                                        piece = Common.Piece.BBishop;
                                                        break;
                                                    case Common.PieceType.Rook:
                                                        piece = Common.Piece.BRook;
                                                        break;
                                                    case Common.PieceType.Gold:
                                                        piece = Common.Piece.BGold;
                                                        break;
                                                    case Common.PieceType.King:
                                                        piece = Common.Piece.BKing;
                                                        break;
                                                    case Common.PieceType.ProPawn:
                                                        piece = Common.Piece.BProPawn;
                                                        break;
                                                    case Common.PieceType.ProLance:
                                                        piece = Common.Piece.BProLance;
                                                        break;
                                                    case Common.PieceType.ProKnight:
                                                        piece = Common.Piece.BProKnight;
                                                        break;
                                                    case Common.PieceType.ProSilver:
                                                        piece = Common.Piece.BProSilver;
                                                        break;
                                                    case Common.PieceType.Horse:
                                                        piece = Common.Piece.BHorse;
                                                        break;
                                                    case Common.PieceType.Dragon:
                                                        piece = Common.Piece.BDragon;
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown pieceType: " + pieceType + "; " + this);
                                                        break;
                                                }
                                            }
                                            break;
                                        case 1:
                                            {
                                                switch (pieceType)
                                                {
                                                    case Common.PieceType.Pawn:
                                                        piece = Common.Piece.WPawn;
                                                        break;
                                                    case Common.PieceType.Lance:
                                                        piece = Common.Piece.WLance;
                                                        break;
                                                    case Common.PieceType.Knight:
                                                        piece = Common.Piece.WKnight;
                                                        break;
                                                    case Common.PieceType.Silver:
                                                        piece = Common.Piece.WSilver;
                                                        break;
                                                    case Common.PieceType.Bishop:
                                                        piece = Common.Piece.WBishop;
                                                        break;
                                                    case Common.PieceType.Rook:
                                                        piece = Common.Piece.WRook;
                                                        break;
                                                    case Common.PieceType.Gold:
                                                        piece = Common.Piece.WGold;
                                                        break;
                                                    case Common.PieceType.King:
                                                        piece = Common.Piece.WKing;
                                                        break;
                                                    case Common.PieceType.ProPawn:
                                                        piece = Common.Piece.WProPawn;
                                                        break;
                                                    case Common.PieceType.ProLance:
                                                        piece = Common.Piece.WProLance;
                                                        break;
                                                    case Common.PieceType.ProKnight:
                                                        piece = Common.Piece.WProKnight;
                                                        break;
                                                    case Common.PieceType.ProSilver:
                                                        piece = Common.Piece.WProSilver;
                                                        break;
                                                    case Common.PieceType.Horse:
                                                        piece = Common.Piece.WHorse;
                                                        break;
                                                    case Common.PieceType.Dragon:
                                                        piece = Common.Piece.WDragon;
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown pieceType: " + pieceType + "; " + this);
                                                        break;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown playerIndex: " + playerIndex + "; " + this);
                                            break;
                                    }
                                }
                                // set
                                {
                                    Setting.Style style = Setting.get().style.v;
                                    imgPiece.sprite = ShogiSpriteContainer.get().getSprite(style, piece);
                                }
                            }
                            else
                            {
                                Debug.LogError("imgPromotion null: " + this);
                            }
                        }
                        // tvMoveType
                        {
                            if (tvMoveType != null)
                            {
                                if (shogiMove.isDrop())
                                {
                                    tvMoveType.text = "Drop";
                                }
                                else if (shogiMove.isPromotion() != 0)
                                {
                                    tvMoveType.text = "Promotion";
                                }
                                else
                                {
                                    tvMoveType.text = "Normal";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvMoveType null: " + this);
                            }
                        }
                        // tvMove
                        if (tvMove != null)
                        {
                            tvMove.text = Common.printMove(shogiMove.move.v);
                        }
                        else
                        {
                            Debug.LogError("tvMove null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("shogiMove null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        private ShogiGameDataUI.UIData shogiGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.shogiGameDataUIData);
                }
                // Child
                {
                    uiData.shogiMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is ShogiGameDataUI.UIData)
                {
                    ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
                    // Child
                    {
                        shogiGameDataUIData.gameData.allAddCallBack(this);
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
                            gameData.turn.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    if (data is Turn)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (data is ShogiMove)
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.shogiGameDataUIData);
                }
                // Child
                {
                    uiData.shogiMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is ShogiGameDataUI.UIData)
                {
                    ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
                    // Child
                    {
                        shogiGameDataUIData.gameData.allRemoveCallBack(this);
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
                            gameData.turn.allRemoveCallBack(this);
                        }
                        return;
                    }
                    if (data is Turn)
                    {
                        return;
                    }
                }
            }
            // Child
            if (data is ShogiMove)
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
                    case UIData.Property.shogiMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.onClick:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        break;
                    case Setting.Property.style:
                        dirty = true;
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
                if (wrapProperty.p is ShogiGameDataUI.UIData)
                {
                    switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case ShogiGameDataUI.UIData.Property.gameData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ShogiGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case ShogiGameDataUI.UIData.Property.board:
                            break;
                        case ShogiGameDataUI.UIData.Property.lastMove:
                            break;
                        case ShogiGameDataUI.UIData.Property.showHint:
                            break;
                        case ShogiGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // GameData
                {
                    if (wrapProperty.p is GameData)
                    {
                        switch ((GameData.Property)wrapProperty.n)
                        {
                            case GameData.Property.gameType:
                                break;
                            case GameData.Property.useRule:
                                break;
                            case GameData.Property.turn:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
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
                    if (wrapProperty.p is Turn)
                    {
                        switch ((Turn.Property)wrapProperty.n)
                        {
                            case Turn.Property.turn:
                                break;
                            case Turn.Property.playerIndex:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is ShogiMove)
                {
                    switch ((ShogiMove.Property)wrapProperty.n)
                    {
                        case ShogiMove.Property.move:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnMove, onClickMove);
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
                        case KeyCode.M:
                            {
                                if (btnMove != null && btnMove.gameObject.activeInHierarchy && btnMove.interactable)
                                {
                                    this.onClickMove();
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

        public Button btnMove;

        [UnityEngine.Scripting.Preserve]
        public void onClickMove()
        {
            if (this.data != null)
            {
                ShogiMove shogiMove = this.data.shogiMove.v.data;
                if (shogiMove != null)
                {
                    if (this.data.onClick.v != null)
                    {
                        this.data.onClick.v.onClickMove(shogiMove);
                    }
                    else
                    {
                        Debug.LogError("onClick null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("shogiMove null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}