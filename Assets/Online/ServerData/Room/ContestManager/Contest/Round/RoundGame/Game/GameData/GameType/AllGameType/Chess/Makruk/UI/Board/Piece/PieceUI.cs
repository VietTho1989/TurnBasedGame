﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
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
                this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.NO_PIECE);
                this.position = new VP<int>(this, (byte)Property.position, 0);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Makruk ? 32 : 0;
        }

        #region Refresh

        public Image image;

        public static Vector2 ConvertPositionToLocalPosition(int position)
        {
            float x = position % 8;
            float y = position / 8;
            return new Vector2(x + 0.5f - 8 / 2f, y + 0.5f - 8 / 2f);
        }

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.position.v >= 0 && this.data.position.v < 64)
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
                                        // find sprite
                                        Setting.Style style = Setting.get().style.v;
                                        Sprite sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v); ;
                                        {
                                            // sprite
                                            if (moveAnimation != null)
                                            {
                                                switch (moveAnimation.getType())
                                                {
                                                    case GameMove.Type.MakrukMove:
                                                        {
                                                            MakrukMoveAnimation makrukMoveAnimation = moveAnimation as MakrukMoveAnimation;
                                                            MakrukMove.Move move = new MakrukMove.Move(makrukMoveAnimation.move.v);
                                                            switch (move.type)
                                                            {
                                                                case Common.MoveType.NORMAL:
                                                                    sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v);
                                                                    break;
                                                                case Common.MoveType.PROMOTION:
                                                                    {
                                                                        if ((int)move.ori == this.data.position.v)
                                                                        {
                                                                            float distanceDuration = MoveAnimation.GetDistanceMoveDuration(Common.GetDistance(move.ori, move.dest));
                                                                            if (time <= distanceDuration)
                                                                            {
                                                                                sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v);
                                                                            }
                                                                            else
                                                                            {
                                                                                bool showPromotion = true;
                                                                                {
                                                                                    float promotionTime = time - distanceDuration;
                                                                                    int flipFlop = Mathf.CeilToInt(promotionTime / (MakrukMoveAnimation.PromotionDuration * AnimationManager.DefaultDuration / 4));
                                                                                    showPromotion = (flipFlop % 2 == 0);
                                                                                }
                                                                                sprite = MakrukSpriteContainer.get().getSprite(style, showPromotion ? Common.make_piece(Common.color_of(this.data.piece.v), move.promotion) : this.data.piece.v);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v);
                                                                        }
                                                                    }
                                                                    break;
                                                                default:
                                                                    Debug.LogError("unknown moveType: " + move.GetType() + "; " + this);
                                                                    sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v);
                                                                    break;
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown moveAnimationType: " + moveAnimation.getType() + "; " + this);
                                                        sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                // Debug.LogError ("moveAnimation null: " + this);
                                                sprite = MakrukSpriteContainer.get().getSprite(style, this.data.piece.v);
                                            }
                                        }
                                        // set
                                        image.sprite = sprite;
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
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.MakrukMove:
                                            {
                                                MakrukMoveAnimation makrukMoveAnimation = moveAnimation as MakrukMoveAnimation;
                                                MakrukMove.Move move = new MakrukMove.Move(makrukMoveAnimation.move.v);
                                                switch (move.type)
                                                {
                                                    case Common.MoveType.NORMAL:
                                                        {
                                                            if ((int)move.ori == this.data.position.v)
                                                            {
                                                                this.transform.SetAsLastSibling();
                                                                Vector2 from = ConvertPositionToLocalPosition((int)move.ori);
                                                                Vector2 dest = ConvertPositionToLocalPosition((int)move.dest);
                                                                // set 
                                                                if (duration > 0)
                                                                {
                                                                    this.transform.localPosition = Vector2.Lerp(from, dest, MoveAnimation.getAccelerateDecelerateInterpolation(time / duration));
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("why duration < 0: " + duration + "; " + this);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.transform.localPosition = ConvertPositionToLocalPosition(this.data.position.v);
                                                            }
                                                        }
                                                        break;
                                                    case Common.MoveType.PROMOTION:
                                                        {
                                                            if ((int)move.ori == this.data.position.v)
                                                            {
                                                                this.transform.SetAsLastSibling();
                                                                Vector2 from = ConvertPositionToLocalPosition((int)move.ori);
                                                                Vector2 dest = ConvertPositionToLocalPosition((int)move.dest);
                                                                // set 
                                                                if (duration > 0)
                                                                {
                                                                    this.transform.localPosition = Vector2.Lerp(from, dest, MoveAnimation.getAccelerateDecelerateInterpolation(time / (duration - MakrukMoveAnimation.PromotionDuration * AnimationManager.DefaultDuration)));
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("why duration < 0: " + duration + "; " + this);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                this.transform.localPosition = ConvertPositionToLocalPosition(this.data.position.v);
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown move type: " + move.type + "; " + this);
                                                        this.transform.localPosition = ConvertPositionToLocalPosition(this.data.position.v);
                                                        break;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                            this.transform.localPosition = ConvertPositionToLocalPosition(this.data.position.v);
                                            break;
                                    }
                                }
                                else
                                {
                                    this.transform.localPosition = ConvertPositionToLocalPosition(this.data.position.v);
                                }
                            }
                            // Scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                this.transform.localScale = (playerView == 0 ? new Vector3(1f, 1f, 1f) : new Vector3(1f, -1f, 1f));
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
            // CheckChange
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
            // CheckChange
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
            // CheckChange
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