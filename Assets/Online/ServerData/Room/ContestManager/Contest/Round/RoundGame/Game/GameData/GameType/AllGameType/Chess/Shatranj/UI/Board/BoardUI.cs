using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Shatranj>> shatranj;

            public LP<PieceUI.UIData> pieces;

            #region Constructor

            public enum Property
            {
                shatranj,
                pieces
            }

            public UIData() : base()
            {
                this.shatranj = new VP<ReferenceData<Shatranj>>(this, (byte)Property.shatranj, new ReferenceData<Shatranj>(null));
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
            }

            #endregion

        }

        #endregion

        #region refresh

        public Sprite NormalBg;
        public Sprite WesternBg;
        public Image bg;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Shatranj shatranj = this.data.shatranj.v.data;
                    if (shatranj != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // chess
                            if (isLoadFull)
                            {
                                if (shatranj.board.vs.Count == 0)
                                {
                                    Debug.LogError("board not load");
                                    isLoadFull = false;
                                }
                            }
                            // animation
                            if (isLoadFull)
                            {
                                isLoadFull = AnimationManager.IsLoadFull(this.data);
                            }
                        }
                        // process
                        if (isLoadFull)
                        {
                            // Normal board
                            {
                                // get olds
                                List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData>();
                                {
                                    oldPieceUIs.AddRange(this.data.pieces.vs);
                                }
                                // Find board
                                List<int> board = shatranj.board.vs;
                                {
                                    MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.ShatranjMove:
                                                {
                                                    ShatranjMoveAnimation shatranjMoveAnimation = moveAnimation as ShatranjMoveAnimation;
                                                    board = shatranjMoveAnimation.board.vs;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + moveAnimation.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("moveAnimation null: " + this);
                                    }
                                }
                                // Make pieceUI
                                {
                                    for (int index = 0; index < board.Count; index++)
                                    {
                                        int pieceIndex = board[index];
                                        if (pieceIndex >= 0 && pieceIndex <= (int)Common.Piece.PIECE_NB)
                                        {
                                            Common.Piece piece = (Common.Piece)pieceIndex;
                                            if (piece != Common.Piece.NO_PIECE)
                                            {
                                                bool needAdd = false;
                                                // Find pieceUI
                                                PieceUI.UIData pieceUIData = null;
                                                {
                                                    // Find old
                                                    foreach (PieceUI.UIData check in oldPieceUIs)
                                                    {
                                                        if (check.position.v == index)
                                                        {
                                                            pieceUIData = check;
                                                            break;
                                                        }
                                                    }
                                                    // Make new
                                                    if (pieceUIData == null)
                                                    {
                                                        pieceUIData = new PieceUI.UIData();
                                                        {
                                                            pieceUIData.uid = this.data.pieces.makeId();
                                                        }
                                                        needAdd = true;
                                                    }
                                                    else
                                                    {
                                                        oldPieceUIs.Remove(pieceUIData);
                                                    }
                                                }
                                                // Update Property
                                                {
                                                    // piece
                                                    pieceUIData.piece.v = piece;
                                                    // position
                                                    pieceUIData.position.v = index;
                                                }
                                                // Add
                                                if (needAdd)
                                                {
                                                    this.data.pieces.add(pieceUIData);
                                                }
                                            }
                                            else
                                            {
                                                // Debug.Log ("pieceIndex wrong: " + piece + "; " + this);
                                            }
                                        }
                                    }
                                }
                                // Remove oldPieceUIs not reuse
                                foreach (PieceUI.UIData oldPieceUI in oldPieceUIs)
                                {
                                    this.data.pieces.remove(oldPieceUI);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("not load full");
                            dirty = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("shatranj null: " + this);
                    }
                    // background
                    {
                        if (bg != null)
                        {
                            switch (Setting.get().style.v)
                            {
                                case Setting.Style.Western:
                                    {
                                        UIRectTransform.CreateCenterRect(8.0f, 8.0f).set(bg.rectTransform);
                                        bg.sprite = WesternBg;
                                    }
                                    break;
                                case Setting.Style.Normal:
                                default:
                                    {
                                        UIRectTransform.CreateCenterRect(8.8f, 8.8f).set(bg.rectTransform);
                                        bg.sprite = NormalBg;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("bg null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("why data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public PieceUI piecePrefab;
        private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    animationManagerCheckChange.needTimeChange = false;
                    animationManagerCheckChange.addCallBack(this);
                    animationManagerCheckChange.setData(uiData);
                }
                // Update
                {
                    UpdateUtils.makeUpdate<AnimationSetDirtyUpdate, UIData>(uiData, this.transform);
                }
                // Child
                {
                    uiData.shatranj.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
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
            // checkChange
            {
                if (data is AnimationManagerCheckChange<UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is Shatranj)
                {
                    dirty = true;
                    return;
                }
                if (data is PieceUI.UIData)
                {
                    PieceUI.UIData pieceUIData = data as PieceUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(pieceUIData, piecePrefab, this.transform);
                    }
                    // dirty = true;
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
                // Setting
                Setting.get().removeCallBack(this);
                // CheckChange
                {
                    animationManagerCheckChange.removeCallBack(this);
                    animationManagerCheckChange.setData(null);
                }
                // Update
                {
                    uiData.removeCallBackAndDestroy(typeof(AnimationSetDirtyUpdate));
                }
                // Child
                {
                    uiData.shatranj.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // checkChange
            {
                if (data is AnimationManagerCheckChange<UIData>)
                {
                    return;
                }
            }
            // Child
            {
                if (data is Shatranj)
                {
                    return;
                }
                if (data is PieceUI.UIData)
                {
                    PieceUI.UIData pieceUIData = data as PieceUI.UIData;
                    // UI
                    {
                        pieceUIData.removeCallBackAndDestroy(typeof(PieceUI));
                    }
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
                    case UIData.Property.shatranj:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.pieces:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            // dirty = true;
                        }
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
            // Check Change
            {
                if (wrapProperty.p is AnimationManagerCheckChange<UIData>)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (wrapProperty.p is Shatranj)
                {
                    switch ((Shatranj.Property)wrapProperty.n)
                    {
                        case Shatranj.Property.board:
                            dirty = true;
                            break;
                        case Shatranj.Property.byTypeBB:
                            break;
                        case Shatranj.Property.byColorBB:
                            break;
                        case Shatranj.Property.pieceCount:
                            break;
                        case Shatranj.Property.pieceList:
                            break;
                        case Shatranj.Property.index:
                            break;
                        case Shatranj.Property.gamePly:
                            break;
                        case Shatranj.Property.sideToMove:
                            break;
                        case Shatranj.Property.st:
                            break;
                        case Shatranj.Property.chess960:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is PieceUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}