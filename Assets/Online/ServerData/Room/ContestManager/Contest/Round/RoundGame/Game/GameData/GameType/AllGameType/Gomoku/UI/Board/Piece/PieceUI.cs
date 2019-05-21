using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> coord;

            public VP<Common.Type> type;

            public VP<int> lastMoveIndex;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                coord,
                type,
                lastMoveIndex,
                isWinCoord,
                blindFold
            }

            public UIData() : base()
            {
                this.coord = new VP<int>(this, (byte)Property.coord, -1);
                this.type = new VP<Common.Type>(this, (byte)Property.type, Common.Type.None);
                this.lastMoveIndex = new VP<int>(this, (byte)Property.lastMoveIndex, -1);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Gomoku ? 1 : 0;
        }

        #region Refresh

        public Image imgStone;

        private static readonly Color BlackColor = Color.white;
        private static readonly Color WhiteColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
        public Text tvLastMoveIndex;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // check load full
                    bool isLoadFull = true;
                    {
                        // animation
                        if (isLoadFull)
                        {
                            isLoadFull = AnimationManager.IsLoadFull(this.data);
                        }
                    }
                    // process
                    if (isLoadFull)
                    {
                        // Find MoveAnimation
                        MoveAnimation moveAnimation = null;
                        float time = 0;
                        float duration = 0;
                        {
                            GameDataBoardUI.UIData.getCurrentMoveAnimationInfo(this.data, out moveAnimation, out time, out duration);
                        }
                        // Get BoardSize
                        int boardSize = 19;
                        {
                            BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData>();
                            if (boardUIData != null)
                            {
                                boardSize = boardUIData.boardSize.v;
                            }
                            else
                            {
                                Debug.LogError("boardUI null: " + this);
                            }
                        }
                        // position
                        {
                            // Debug.Log ("pieceUI: boardSize: " + boardSize);
                            // Set Position
                            if (boardSize > 0)
                            {
                                int x = this.data.coord.v % boardSize;
                                int y = this.data.coord.v / boardSize;
                                this.transform.localPosition = new Vector3(x + 0.5f - boardSize / 2.0f, y + 0.5f - boardSize / 2.0f, 0);
                            }
                            else
                            {
                                Debug.LogError("error, why boardSize <=0: " + boardSize);
                            }
                        }
                        // imgStone
                        {
                            if (imgStone != null)
                            {
                                if (!this.data.blindFold.v)
                                {
                                    imgStone.enabled = true;
                                    imgStone.sprite = GomokuSpriteContainer.get().getSprite(this.data.type.v);
                                }
                                else
                                {
                                    imgStone.enabled = false;
                                }
                            }
                            else
                            {
                                Debug.LogError("imgStone null: " + this);
                            }
                        }
                        // lastMoveIndex
                        {
                            if (tvLastMoveIndex != null)
                            {
                                if (!this.data.blindFold.v)
                                {
                                    if (this.data.lastMoveIndex.v >= 0 && moveAnimation == null)
                                    {
                                        tvLastMoveIndex.text = "" + (this.data.lastMoveIndex.v + 1);
                                        // color
                                        switch (this.data.type.v)
                                        {
                                            case Common.Type.Black:
                                                tvLastMoveIndex.color = BlackColor;
                                                break;
                                            case Common.Type.White:
                                                tvLastMoveIndex.color = WhiteColor;
                                                break;
                                            case Common.Type.None:
                                                tvLastMoveIndex.color = WhiteColor;
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + this.data.type.v);
                                                tvLastMoveIndex.color = BlackColor;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        tvLastMoveIndex.text = "";
                                    }
                                }
                                else
                                {
                                    tvLastMoveIndex.text = "";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvLastMoveIndex null: " + this);
                            }
                        }
                        // Scale
                        {
                            int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                            // localScale
                            float localScale = 1;
                            {
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.GomokuMove:
                                            {
                                                GomokuMoveAnimation gomokuMoveAnimation = moveAnimation as GomokuMoveAnimation;
                                                if (gomokuMoveAnimation.move.v == this.data.coord.v)
                                                {
                                                    if (duration > 0)
                                                    {
                                                        localScale = MoveAnimation.getAccelerateDecelerateInterpolation(time / duration);
                                                        // Debug.LogError ("localScale: " + localScale);
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("why duration < 0");
                                                        localScale = 0;
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                            this.transform.localScale = (playerView == 0 ? new Vector3(localScale, localScale, 1) : new Vector3(localScale, -localScale, 1));
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
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public BoardUI.UIData boardUIData = null;
        private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

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
                // parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.boardUIData);
                }
                dirty = true;
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            if (data is BoardUI.UIData)
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.boardUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Parent
            if (data is BoardUI.UIData)
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
                    case UIData.Property.coord:
                        dirty = true;
                        break;
                    case UIData.Property.type:
                        dirty = true;
                        break;
                    case UIData.Property.lastMoveIndex:
                        dirty = true;
                        break;
                    case UIData.Property.isWinCoord:
                        dirty = true;
                        break;
                    case UIData.Property.blindFold:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Check Change
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Parent
            if (wrapProperty.p is BoardUI.UIData)
            {
                switch ((BoardUI.UIData.Property)wrapProperty.n)
                {
                    case BoardUI.UIData.Property.gomoku:
                        break;
                    case BoardUI.UIData.Property.boardSize:
                        dirty = true;
                        break;
                    case BoardUI.UIData.Property.background:
                        break;
                    case BoardUI.UIData.Property.pieces:
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

    }
}