using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<Common.Piece> piece;

            public VP<int> position;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                piece,
                position,
                blindFold
            }

            public UIData() : base()
            {
                this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.Empty);
                this.position = new VP<int>(this, (byte)Property.position, 0);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.SHOGI ? 20 : 0;
        }

        public Image image;

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.position.v >= 0 && this.data.position.v < 90)
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
                            // Image
                            {
                                if (image != null)
                                {
                                    if (!this.data.blindFold.v)
                                    {
                                        image.enabled = true;
                                        // find correct sprite
                                        // set
                                        {
                                            // Find style
                                            Setting.Style style = Setting.get().style.v;
                                            // Process
                                            {
                                                // Find piece
                                                Common.Piece piece = this.data.piece.v;
                                                {
                                                    if (moveAnimation != null)
                                                    {
                                                        switch (moveAnimation.getType())
                                                        {
                                                            case GameMove.Type.ShogiMove:
                                                                {
                                                                    ShogiMoveAnimation shogiMoveAnimation = moveAnimation as ShogiMoveAnimation;
                                                                    // Get Inform
                                                                    ShogiMove shogiMove = new ShogiMove();
                                                                    {
                                                                        shogiMove.move.v = shogiMoveAnimation.move.v;
                                                                    }
                                                                    if (shogiMove.from() == (Common.Square)this.data.position.v)
                                                                    {
                                                                        if (shogiMove.isPromotion() != 0)
                                                                        {
                                                                            bool showPromotion = false;
                                                                            {
                                                                                float promotionDuration = ShogiMoveAnimation.PromotionDuration * AnimationManager.DefaultDuration;
                                                                                float distanceDuration = duration - promotionDuration;
                                                                                float promotionTime = time - distanceDuration;
                                                                                if (promotionTime > 0)
                                                                                {
                                                                                    int flipFlop = Mathf.CeilToInt(promotionTime / (promotionDuration / 4));
                                                                                    showPromotion = (flipFlop % 2 == 0);
                                                                                }
                                                                            }
                                                                            if (showPromotion)
                                                                            {
                                                                                piece = Common.getPromotion(this.data.piece.v);
                                                                            }
                                                                        }
                                                                        // this.transform.SetAsLastSibling ();
                                                                    }
                                                                }
                                                                break;
                                                            default:
                                                                Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                                                break;
                                                        }
                                                    }
                                                }
                                                image.sprite = ShogiSpriteContainer.get().getSprite(style, piece);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        image.enabled = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("image null: " + this);
                                }
                            }
                            // Position
                            {
                                Vector3 localPosition = Common.convertSquareToLocalPosition((Common.Square)this.data.position.v);
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.ShogiMove:
                                            {
                                                ShogiMoveAnimation shogiMoveAnimation = moveAnimation as ShogiMoveAnimation;
                                                // Get Inform
                                                ShogiMove shogiMove = new ShogiMove();
                                                {
                                                    shogiMove.move.v = shogiMoveAnimation.move.v;
                                                }
                                                if (!shogiMove.isDrop())
                                                {
                                                    Common.Square from = shogiMove.from();
                                                    Common.Square dest = shogiMove.to();
                                                    if (from != dest)
                                                    {
                                                        if ((int)from == this.data.position.v)
                                                        {
                                                            // get moveDuration
                                                            float moveDuration = duration;
                                                            {
                                                                if (shogiMove.isPromotion() != 0)
                                                                {
                                                                    moveDuration = duration - ShogiMoveAnimation.PromotionDuration * AnimationManager.DefaultDuration;
                                                                }
                                                            }
                                                            if (moveDuration > 0)
                                                            {
                                                                Vector3 fromPos = Common.convertSquareToLocalPosition(from);
                                                                Vector3 destPos = Common.convertSquareToLocalPosition(dest);
                                                                localPosition = Vector3.Lerp(fromPos, destPos, time / moveDuration);
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("error, moveDuration < 0");
                                                            }
                                                            this.transform.SetAsLastSibling();
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + moveAnimation + "; " + this);
                                            break;
                                    }
                                }
                                this.transform.localPosition = localPosition;
                            }
                            // Scale
                            {
                                // int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
                                float localScale = 1;
                                {
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.ShogiMove:
                                                {
                                                    ShogiMoveAnimation shogiMoveAnimation = moveAnimation as ShogiMoveAnimation;
                                                    // Find inform
                                                    ShogiMove shogiMove = new ShogiMove();
                                                    {
                                                        shogiMove.move.v = shogiMoveAnimation.move.v;
                                                    }
                                                    // Process
                                                    if (shogiMove.isDrop())
                                                    {
                                                        if (shogiMove.to() == (Common.Square)this.data.position.v)
                                                        {
                                                            if (duration > 0)
                                                            {
                                                                localScale = MoveAnimation.getAccelerateDecelerateInterpolation(time / duration);
                                                                // Debug.LogError ("localScale: " + localScale);
                                                            }
                                                            // this.transform.SetAsLastSibling ();
                                                        }
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                                break;
                                        }
                                    }
                                }
                                // this.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
                                this.transform.localScale = new Vector3(localScale, localScale, localScale);
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
                        Debug.LogError("outside board: " + this);
                        // Image
                        if (image != null)
                        {
                            image.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("image null: " + this);
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                    // Image
                    if (image != null)
                    {
                        image.enabled = false;
                    }
                    else
                    {
                        Debug.LogError("image null: " + this);
                    }
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
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
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
                // Setting
                Setting.get().removeCallBack(this);
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
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
                    case UIData.Property.piece:
                        dirty = true;
                        break;
                    case UIData.Property.position:
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