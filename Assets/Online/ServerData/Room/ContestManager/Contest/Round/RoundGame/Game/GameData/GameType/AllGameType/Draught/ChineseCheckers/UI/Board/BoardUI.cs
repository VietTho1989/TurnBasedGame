using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class BoardUI : UIBehavior<BoardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {
            
            public VP<ReferenceData<ChineseCheckers>> chineseCheckers;

            public LP<PieceUI.UIData> pieces;

            #region Constructor

            public enum Property
            {
                chineseCheckers,
                pieces
            }

            public UIData() : base()
            {
                this.chineseCheckers = new VP<ReferenceData<ChineseCheckers>>(this, (byte)Property.chineseCheckers, new ReferenceData<ChineseCheckers>(null));
                this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ChineseCheckers chineseCheckers = this.data.chineseCheckers.v.data;
                    if (chineseCheckers != null)
                    {
                        // check load full
                        bool isLoadFull = true;
                        {
                            // chineseCheckers
                            if (isLoadFull)
                            {
                                if (!chineseCheckers.isLoadFull())
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
                            // get old
                            List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData>();
                            {
                                oldPieces.AddRange(this.data.pieces.vs);
                            }
                            // Find squares
                            List<byte> squares = chineseCheckers._squares.vs;
                            {
                                MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation(this.data);
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.ChineseCheckersMove:
                                            {
                                                // TODO Can hoan thien
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
                            // update board
                            for (int y = 0; y < Common.Y_SIZE; y++)
                            {
                                for (int x = 0; x < Common.X_SIZE; x++)
                                {
                                    int index = x + Common.X_SIZE * y;
                                    // get piece
                                    Common.Pebble piece = Common.Pebble.INVALID;
                                    {
                                        if(index>=0 && index < squares.Count)
                                        {
                                            piece = (Common.Pebble)squares[index];
                                        }
                                        else
                                        {
                                            Debug.LogError("index error: " + index);
                                        }
                                    }
                                    // process
                                    if (piece!=Common.Pebble.INVALID)
                                    {
                                        bool needAdd = false;
                                        // Find PieceUI
                                        PieceUI.UIData pieceUIData = null;
                                        {
                                            // Find old
                                            foreach (PieceUI.UIData check in oldPieces)
                                            {
                                                if (check.x.v==x && check.y.v==y)
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
                                                oldPieces.Remove(pieceUIData);
                                            }
                                        }
                                        // Update Property
                                        {
                                            pieceUIData.x.v = x;
                                            pieceUIData.y.v = y;
                                            pieceUIData.pebble.v = piece;
                                        }
                                        // add
                                        if (needAdd)
                                        {
                                            this.data.pieces.add(pieceUIData);
                                        }
                                    }
                                }
                            }
                            // remove unused piece
                            foreach (PieceUI.UIData oldPiece in oldPieces)
                            {
                                this.data.pieces.remove(oldPiece);
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
                        Debug.LogError("chineseCheckers null");
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
                    uiData.chineseCheckers.allAddCallBack(this);
                    uiData.pieces.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // checkChange
            if (data is AnimationManagerCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            {
                if (data is ChineseCheckers)
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
                    uiData.chineseCheckers.allRemoveCallBack(this);
                    uiData.pieces.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            if (data is AnimationManagerCheckChange<UIData>)
            {
                return;
            }
            // Child
            {
                if (data is ChineseCheckers)
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
                    case UIData.Property.chineseCheckers:
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
                if (wrapProperty.p is ChineseCheckers)
                {
                    switch ((ChineseCheckers.Property)wrapProperty.n)
                    {
                        case ChineseCheckers.Property._squares:
                            dirty = true;
                            break;
                        case ChineseCheckers.Property._turn:
                            break;
                        case ChineseCheckers.Property.isCustom:
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