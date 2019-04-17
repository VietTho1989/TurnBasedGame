using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> square;

            public VP<int> pieceSide;

            public VP<bool> isLastCapture;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                square,
                pieceSide,
                isLastCapture,
                blindFold
            }

            public UIData() : base()
            {
                this.square = new VP<int>(this, (byte)Property.square, 0);
                this.pieceSide = new VP<int>(this, (byte)Property.pieceSide, (int)Common.Piece_Side.Empty);
                this.isLastCapture = new VP<bool>(this, (byte)Property.isLastCapture, false);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Image imgPieceSide;
        public Image imgLastCapture;

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
                                        case GameMove.Type.InternationalDraughtMove:
                                            {
                                                InternationalDraughtMoveAnimation internationalDraughtMoveAnimation = moveAnimation as InternationalDraughtMoveAnimation;
                                                System.UInt64 internationalDraughtMove = internationalDraughtMoveAnimation.move.v;
                                                {
                                                    if (InternationalDraughtMove.from(internationalDraughtMove) == this.data.square.v)
                                                    {
                                                        List<int> squareList = Core.unityGetMoveSquareList(internationalDraughtMove);
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
                                                                    float stepDuration = InternationalDraughtMoveAnimation.getMoveDurationByDistance(Mathf.Abs(Common.square_file(square) - Common.square_file(nextSquare))) * AnimationManager.DefaultDuration;
                                                                    stepEnd = stepBegin + stepDuration;
                                                                    // get stepDuration
                                                                    if (time >= stepBegin && time <= stepEnd + InternationalDraughtMoveAnimation.StayDuration * AnimationManager.DefaultDuration)
                                                                    {
                                                                        from = Common.convertSquareToLocalPosition(square);
                                                                        dest = Common.convertSquareToLocalPosition(nextSquare);
                                                                        break;
                                                                    }
                                                                    stepBegin = stepEnd + InternationalDraughtMoveAnimation.StayDuration * AnimationManager.DefaultDuration;
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
                            if (imgPieceSide != null)
                            {
                                // sprite
                                if (!this.data.blindFold.v)
                                {
                                    imgPieceSide.enabled = true;
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.InternationalDraughtMove:
                                                {
                                                    InternationalDraughtMoveAnimation internationalDraughtMoveAnimation = moveAnimation as InternationalDraughtMoveAnimation;
                                                    // check dead or not
                                                    bool isDead = false;
                                                    {
                                                        System.UInt64 internationalDraughtMove = internationalDraughtMoveAnimation.move.v;
                                                        {
                                                            List<int> squareList = Core.unityGetMoveSquareList(internationalDraughtMove);
                                                            if (squareList.Count >= 2)
                                                            {
                                                                int yourSquareX = Common.square_file(this.data.square.v);
                                                                int yourSquareY = Common.square_rank(this.data.square.v);
                                                                for (int i = 0; i < squareList.Count - 1; i++)
                                                                {
                                                                    int square = squareList[i];
                                                                    int nextSquare = squareList[i + 1];
                                                                    if (square != this.data.square.v && nextSquare != this.data.square.v)
                                                                    {
                                                                        // get x, y
                                                                        int squareX = Common.square_file(square);
                                                                        int squareY = Common.square_rank(square);
                                                                        int nextSquareX = Common.square_file(nextSquare);
                                                                        int nextSquareY = Common.square_rank(nextSquare);
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
                                                            else
                                                            {
                                                                Debug.LogError("error, squareList too small: " + this);
                                                            }
                                                        }
                                                    }
                                                    // Process
                                                    if (isDead)
                                                    {
                                                        imgPieceSide.sprite = InternationalDraughtSpriteContainer.get().getDeadSprite(this.data.pieceSide.v);
                                                    }
                                                    else
                                                    {
                                                        imgPieceSide.sprite = InternationalDraughtSpriteContainer.get().getSprite(this.data.pieceSide.v);
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                                imgPieceSide.sprite = InternationalDraughtSpriteContainer.get().getSprite(this.data.pieceSide.v);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        imgPieceSide.sprite = InternationalDraughtSpriteContainer.get().getSprite(this.data.pieceSide.v);
                                    }
                                    // Scale
                                    {
                                        int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                        imgPieceSide.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                    }
                                }
                                else
                                {
                                    imgPieceSide.enabled = false;
                                }
                            }
                            else
                            {
                                Debug.LogError("imgPieceSide null: " + this);
                            }
                        }
                        // isLastCapture
                        {
                            if (imgLastCapture != null)
                            {
                                // enable
                                if (this.data.isLastCapture.v && moveAnimation == null)
                                {
                                    // imgLastCapture.enabled = true;
                                    imgLastCapture.enabled = false;
                                }
                                else
                                {
                                    imgLastCapture.enabled = false;
                                }
                                // Scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    imgLastCapture.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                }
                            }
                            else
                            {
                                // Debug.LogError("imgLastCapture null: " + this);
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError("not load full");
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
                    case UIData.Property.pieceSide:
                        dirty = true;
                        break;
                    case UIData.Property.isLastCapture:
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