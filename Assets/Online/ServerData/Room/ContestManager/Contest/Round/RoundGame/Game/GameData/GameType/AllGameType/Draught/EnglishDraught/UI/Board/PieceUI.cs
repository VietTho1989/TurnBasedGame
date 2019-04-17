using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> square;

            public VP<byte> piece;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                square,
                piece,
                blindFold
            }

            public UIData() : base()
            {
                this.square = new VP<int>(this, (byte)Property.square, 0);
                this.piece = new VP<byte>(this, (byte)Property.piece, Common.WPIECE);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Image imgPiece;

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
                        // Position
                        {
                            Vector2 localPosition = Common.convertSquareToLocalPosition(this.data.square.v);
                            {
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.EnglishDraughtMove:
                                            {
                                                EnglishDraughtMoveAnimation englishDraughtMoveAnimation = moveAnimation as EnglishDraughtMoveAnimation;
                                                EnglishDraughtMove englishDraughtMove = englishDraughtMoveAnimation.move.v;
                                                if (englishDraughtMove != null)
                                                {
                                                    if (englishDraughtMove.from() == this.data.square.v)
                                                    {
                                                        List<int> squareList = englishDraughtMove.getMoveSquareList();
                                                        if (squareList.Count >= 2)
                                                        {
                                                            this.transform.SetAsLastSibling();
                                                            // Find from, dest, time and duration
                                                            Vector2 from = new Vector2(0, 0);
                                                            Vector2 dest = new Vector2(0, 0);
                                                            float stepBegin = 0;
                                                            float stepEnd = 0;
                                                            {
                                                                for (int i = 0; i < squareList.Count - 1; i++)
                                                                {
                                                                    int square = squareList[i];
                                                                    int nextSquare = squareList[i + 1];
                                                                    // get stepTime
                                                                    float stepDuration = EnglishDraughtMoveAnimation.getMoveDurationByDistance(Mathf.Abs(square % 8 - nextSquare % 8)) * AnimationManager.DefaultDuration;
                                                                    stepEnd = stepBegin + stepDuration;
                                                                    // get stepDuration
                                                                    if (time >= stepBegin && time <= stepEnd + EnglishDraughtMoveAnimation.StayDuration * AnimationManager.DefaultDuration)
                                                                    {
                                                                        from = Common.convertSquareToLocalPosition(square);
                                                                        dest = Common.convertSquareToLocalPosition(nextSquare);
                                                                        break;
                                                                    }
                                                                    stepBegin = stepEnd + EnglishDraughtMoveAnimation.StayDuration * AnimationManager.DefaultDuration;
                                                                }
                                                            }
                                                            // set 
                                                            if (stepEnd > stepBegin)
                                                            {
                                                                // Debug.LogError ("stepTime: " + stepBegin + "; " + stepEnd);
                                                                localPosition = Vector2.Lerp(from, dest, MoveAnimation.getAccelerateDecelerateInterpolation((time - stepBegin) / (stepEnd - stepBegin)));
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("why stepDuration < 0: " + stepBegin + "; " + stepEnd + "; " + this);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("why squareList count < 2: " + squareList.Count + "; " + this);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("englishDraughtMove null: " + this);
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknownMoveAnimation: " + moveAnimation + "; " + this);
                                            break;
                                    }
                                }
                            }
                            this.transform.localPosition = localPosition;
                        }
                        // PieceSide
                        {
                            if (imgPiece != null)
                            {
                                // sprite
                                if (!this.data.blindFold.v)
                                {
                                    imgPiece.enabled = true;
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.EnglishDraughtMove:
                                                {
                                                    EnglishDraughtMoveAnimation englishDraughtMoveAnimation = moveAnimation as EnglishDraughtMoveAnimation;
                                                    // check dead or not
                                                    bool isDead = false;
                                                    {
                                                        EnglishDraughtMove englishDraughtMove = englishDraughtMoveAnimation.move.v;
                                                        if (englishDraughtMove != null)
                                                        {
                                                            List<int> squareList = englishDraughtMove.getMoveSquareList();
                                                            if (squareList.Count >= 2)
                                                            {
                                                                int yourSquareX = this.data.square.v % 8;
                                                                int yourSquareY = this.data.square.v / 8;
                                                                for (int i = 0; i < squareList.Count - 1; i++)
                                                                {
                                                                    int square = squareList[i];
                                                                    int nextSquare = squareList[i + 1];
                                                                    if (square != this.data.square.v && nextSquare != this.data.square.v)
                                                                    {
                                                                        // get x, y
                                                                        int squareX = square % 8;
                                                                        int squareY = square / 8;
                                                                        int nextSquareX = nextSquare % 8;
                                                                        int nextSquareY = nextSquare / 8;
                                                                        // check
                                                                        if ((Mathf.Abs(yourSquareX - squareX) == Mathf.Abs(yourSquareY - squareY))
                                                                            && (Mathf.Abs(yourSquareX - nextSquareX) == Mathf.Abs(yourSquareY - nextSquareY)))
                                                                        {
                                                                            if ((yourSquareX - squareX) * (yourSquareX - nextSquareX) < 0 && (yourSquareY - squareY) * (yourSquareY - nextSquareY) < 0)
                                                                            {
                                                                                isDead = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("englishDraughtMove null: " + this);
                                                        }
                                                    }
                                                    // Process
                                                    if (isDead)
                                                    {
                                                        imgPiece.sprite = EnglishDraughtSpriteContainer.get().getDeadSprite(this.data.piece.v);
                                                    }
                                                    else
                                                    {
                                                        imgPiece.sprite = EnglishDraughtSpriteContainer.get().getSprite(this.data.piece.v);
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                                imgPiece.sprite = EnglishDraughtSpriteContainer.get().getSprite(this.data.piece.v);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        imgPiece.sprite = EnglishDraughtSpriteContainer.get().getSprite(this.data.piece.v);
                                    }
                                }
                                else
                                {
                                    imgPiece.enabled = false;
                                }
                                // Scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    imgPiece.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                }
                            }
                            else
                            {
                                Debug.LogError("imgPieceSide null: " + this);
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
                dirty = true;
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
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
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
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
                    case UIData.Property.square:
                        dirty = true;
                        break;
                    case UIData.Property.piece:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}