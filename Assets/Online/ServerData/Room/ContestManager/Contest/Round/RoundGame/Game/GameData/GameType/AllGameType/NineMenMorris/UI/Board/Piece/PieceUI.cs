using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> position;

            public VP<Common.SpotStatus> piece;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                position,
                piece,
                blindFold
            }

            public UIData() : base()
            {
                this.position = new VP<int>(this, (byte)Property.position, 0);
                this.piece = new VP<Common.SpotStatus>(this, (byte)Property.piece, Common.SpotStatus.SS_Empty);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Image image;

        public GameObject removeAnimationIndicator;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.position.v >= 0 && this.data.position.v < Common.BOARD_SPOT)
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
                            // image
                            {
                                if (image != null)
                                {
                                    // sprite
                                    if (!this.data.blindFold.v)
                                    {
                                        image.enabled = true;
                                        Sprite sprite = NineMenMorrisSpriteContainer.get().getSprite(this.data.piece.v);
                                        {
                                            // Co le ko can
                                        }
                                        image.sprite = sprite;
                                    }
                                    else
                                    {
                                        image.enabled = false;
                                    }
                                    // scale
                                    {
                                        float scale = 1;
                                        {
                                            if (moveAnimation != null)
                                            {
                                                switch (moveAnimation.getType())
                                                {
                                                    case GameMove.Type.NineMenMorrisMove:
                                                        {
                                                            NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = moveAnimation as NineMenMorrisMoveAnimation;
                                                            if (this.data.position.v == nineMenMorrisMoveAnimation.moved.v)
                                                            {
                                                                // positioning
                                                                if (nineMenMorrisMoveAnimation.positioningDuration.v > 0)
                                                                {
                                                                    scale = Mathf.Lerp(0, 1, time / nineMenMorrisMoveAnimation.positioningDuration.v);
                                                                }
                                                            }
                                                            else if (this.data.position.v == nineMenMorrisMoveAnimation.removed.v)
                                                            {
                                                                // mill
                                                                if (nineMenMorrisMoveAnimation.removedDuration.v > 0)
                                                                {
                                                                    if (time >= nineMenMorrisMoveAnimation.positioningDuration.v + nineMenMorrisMoveAnimation.moveDuration.v)
                                                                    {
                                                                        float removeTime = time - (nineMenMorrisMoveAnimation.positioningDuration.v + nineMenMorrisMoveAnimation.moveDuration.v);
                                                                        scale = 1 - Mathf.Lerp(0, 1, removeTime / nineMenMorrisMoveAnimation.removedDuration.v);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + moveAnimation.getType());
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                // Debug.LogError ("moveAnimation null");
                                            }
                                        }
                                        image.transform.localScale = new Vector2(scale, scale);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("image null");
                                }
                            }
                            // Position
                            {
                                Vector2 localPosition = Common.convertPositionToLocal(this.data.position.v);
                                {
                                    if (moveAnimation != null)
                                    {
                                        switch (moveAnimation.getType())
                                        {
                                            case GameMove.Type.NineMenMorrisMove:
                                                {
                                                    NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = moveAnimation as NineMenMorrisMoveAnimation;
                                                    if (nineMenMorrisMoveAnimation.moveDuration.v > 0)
                                                    {
                                                        if (this.data.position.v == nineMenMorrisMoveAnimation.moved.v)
                                                        {
                                                            this.transform.SetAsLastSibling();
                                                            Vector2 from = Common.convertPositionToLocal(nineMenMorrisMoveAnimation.moved.v);
                                                            Vector2 dest = Common.convertPositionToLocal(nineMenMorrisMoveAnimation.moved_to.v);
                                                            localPosition = Vector2.Lerp(from, dest, MoveAnimation.getAccelerateDecelerateInterpolation(time / nineMenMorrisMoveAnimation.moveDuration.v));
                                                        }
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown animtion: " + moveAnimation);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("moveAnimation null");
                                    }
                                }
                                this.transform.localPosition = localPosition;
                            }
                            // removeAnimationIndicator
                            {
                                if (removeAnimationIndicator != null)
                                {
                                    bool isOnAnimation = false;
                                    {
                                        if (moveAnimation != null)
                                        {
                                            switch (moveAnimation.getType())
                                            {
                                                case GameMove.Type.NineMenMorrisMove:
                                                    {
                                                        NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = moveAnimation as NineMenMorrisMoveAnimation;
                                                        if (this.data.position.v == nineMenMorrisMoveAnimation.removed.v)
                                                        {
                                                            // mill
                                                            if (nineMenMorrisMoveAnimation.removedDuration.v > 0)
                                                            {
                                                                if (time >= nineMenMorrisMoveAnimation.positioningDuration.v + nineMenMorrisMoveAnimation.moveDuration.v)
                                                                {
                                                                    isOnAnimation = true;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + moveAnimation.getType());
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("moveAnimation null");
                                        }
                                    }
                                    removeAnimationIndicator.SetActive(isOnAnimation);
                                }
                                else
                                {
                                    Debug.LogError("removeAnimationIndicator null");
                                }
                            }
                            // Scale
                            {
                                float scale = 1;
                                {

                                }
                                // Debug.LogError("scale: " + scale);
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                this.transform.localScale = (playerView == 0 ? new Vector3(scale, scale, 1f) : new Vector3(scale, -scale, 1f));
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
                        Debug.LogError("outside board: " + this.data.position.v);
                    }
                }
                else
                {
                    Debug.LogError("PieceUI: why data null");
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
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                this.setDataNull(uiData);
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
                    case UIData.Property.position:
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