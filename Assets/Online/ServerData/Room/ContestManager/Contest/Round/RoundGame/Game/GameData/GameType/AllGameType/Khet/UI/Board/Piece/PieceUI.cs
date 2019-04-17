using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> position;

            public VP<Common.Piece> piece;

            public VP<Common.Player> owner;

            public VP<Common.Orientation> orientation;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                position,
                piece,
                owner,
                orientation,
                blindFold
            }

            public UIData() : base()
            {
                this.position = new VP<int>(this, (byte)Property.position, 0);
                this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.None);
                this.owner = new VP<Common.Player>(this, (byte)Property.owner, Common.Player.Silver);
                this.orientation = new VP<Common.Orientation>(this, (byte)Property.orientation, Common.Orientation.Up);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Image image;

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
                        // image
                        {
                            if (image != null)
                            {
                                // sprite
                                if(!this.data.blindFold.v)
                                {
                                    image.enabled = true;
                                    // find sprite
                                    Sprite sprite = KhetSpriteContainer.get().GetSprite(this.data.owner.v, this.data.piece.v, this.data.orientation.v);
                                    {
                                        // TODO Animation?
                                    }
                                    // set
                                    image.sprite = sprite;
                                }
                                else
                                {
                                    image.enabled = false;
                                }
                                // scale
                                {
                                    float localScale = 1;
                                    {
                                        if (moveAnimation != null)
                                        {
                                            switch (moveAnimation.getType())
                                            {
                                                case GameMove.Type.KhetMove:
                                                    {
                                                        KhetMoveAnimation khetMoveAnimation = moveAnimation as KhetMoveAnimation;
                                                        if (khetMoveAnimation.isKill.v)
                                                        {
                                                            // check is kill piece
                                                            bool isKillPiece = false;
                                                            {
                                                                int start = KhetMove.GetStart(khetMoveAnimation.move.v);
                                                                int end = KhetMove.GetEnd(khetMoveAnimation.move.v);
                                                                if (khetMoveAnimation.laserTargetIndex.v != start && khetMoveAnimation.laserTargetIndex.v != end)
                                                                {
                                                                    if (this.data.position.v == khetMoveAnimation.laserTargetIndex.v)
                                                                    {
                                                                        isKillPiece = true;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (khetMoveAnimation.laserTargetIndex.v == start)
                                                                    {
                                                                        if (this.data.position.v == end)
                                                                        {
                                                                            isKillPiece = true;
                                                                        }
                                                                    }
                                                                    else if (khetMoveAnimation.laserTargetIndex.v == end)
                                                                    {
                                                                        if (this.data.position.v == start)
                                                                        {
                                                                            isKillPiece = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            // process
                                                            if (isKillPiece)
                                                            {
                                                                if (time >= khetMoveAnimation.moveTime.v + khetMoveAnimation.rotateTime.v)
                                                                {
                                                                    if (khetMoveAnimation.laserTime.v > 0)
                                                                    {
                                                                        float killTime = time - (khetMoveAnimation.moveTime.v + khetMoveAnimation.rotateTime.v);
                                                                        localScale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation(killTime / khetMoveAnimation.laserTime.v);
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("why laserTime <= 0: " + khetMoveAnimation.laserTime.v);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown moveAnimation: " + moveAnimation);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("moveAnimation null");
                                        }
                                    }
                                    image.transform.localScale = new Vector3(localScale, localScale, 1);
                                }
                            }
                            else
                            {
                                Debug.LogError("image null");
                            }
                        }
                        // position
                        {
                            Vector2 localPosition = Common.getLocalPosition(this.data.position.v);
                            {
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.KhetMove:
                                            {
                                                KhetMoveAnimation khetMoveAnimation = moveAnimation as KhetMoveAnimation;
                                                if (khetMoveAnimation.moveTime.v > 0)
                                                {
                                                    int start = KhetMove.GetStart(khetMoveAnimation.move.v);
                                                    int end = KhetMove.GetEnd(khetMoveAnimation.move.v);
                                                    if (this.data.position.v == start)
                                                    {
                                                        this.transform.SetAsLastSibling();
                                                        localPosition = Vector2.Lerp(Common.getLocalPosition(start), Common.getLocalPosition(end), MoveAnimation.getAccelerateDecelerateInterpolation(time / khetMoveAnimation.moveTime.v));
                                                    }
                                                    else if (this.data.position.v == end)
                                                    {
                                                        localPosition = Vector2.Lerp(Common.getLocalPosition(end), Common.getLocalPosition(start), MoveAnimation.getAccelerateDecelerateInterpolation(time / khetMoveAnimation.moveTime.v));
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation);
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
                        // rotation
                        {
                            float angle = 0;
                            {
                                if (moveAnimation != null)
                                {
                                    switch (moveAnimation.getType())
                                    {
                                        case GameMove.Type.KhetMove:
                                            {
                                                KhetMoveAnimation khetMoveAnimation = moveAnimation as KhetMoveAnimation;
                                                if (khetMoveAnimation.rotateTime.v > 0)
                                                {
                                                    int start = KhetMove.GetStart(khetMoveAnimation.move.v);
                                                    if (this.data.position.v == start)
                                                    {
                                                        int rotation = KhetMove.GetRotation(khetMoveAnimation.move.v);
                                                        angle = 90 * Mathf.Lerp(0, 1, time / khetMoveAnimation.rotateTime.v) * (rotation > 0 ? -1 : 1);
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown moveAnimation: " + moveAnimation);
                                            break;
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("moveAnimation null");
                                }
                            }
                            this.transform.localEulerAngles = new Vector3(0, 0, angle);
                        }
                        // Scale
                        /*{
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							this.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
						}*/
                    }
                    else
                    {
                        Debug.LogError("not load full");
                        dirty = true;
                    }
                }
                else
                {
                    // Debug.LogError ("data null");
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
                    // perspective
                    {
                        perspectiveChange.addCallBack(this);
                        perspectiveChange.setData(uiData);
                    }
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
                    // perspective
                    {
                        perspectiveChange.removeCallBack(this);
                        perspectiveChange.setData(null);
                    }
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
                    case UIData.Property.owner:
                        dirty = true;
                        break;
                    case UIData.Property.orientation:
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