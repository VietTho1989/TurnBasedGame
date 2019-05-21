using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> piece;

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
                this.piece = new VP<int>(this, (byte)Property.piece, 0);
                this.position = new VP<int>(this, (byte)Property.position, 0);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Xiangqi ? 32 : 0;
        }

        #region Refresh

        public Image image;

        private const float deltaX = 0.5f - 9 / 2.0f;
        private const float deltaY = 0.5f - 10 / 2.0f;

        private static Vector2 convertPosToLocalPosition(int position)
        {
            float x = position % 9;
            float y = 9 - position / 9;
            return new Vector2(x + deltaX, y + deltaY);
        }

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (this.data.position.v >= 0)
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
                                        // position
                                        {
                                            Vector2 localPos = convertPosToLocalPosition(this.data.position.v);
                                            {
                                                if (moveAnimation != null)
                                                {
                                                    switch (moveAnimation.getType())
                                                    {
                                                        case GameMove.Type.XiangqiMove:
                                                            {
                                                                XiangqiMoveAnimation xiangqiMoveAnimation = moveAnimation as XiangqiMoveAnimation;
                                                                Common.MoveStruct moveStruct = new Common.MoveStruct(xiangqiMoveAnimation.move.v);
                                                                // 9*y+x
                                                                // int x = this.data.position.v % 9;
                                                                // int y = 9 - this.data.position.v / 9;

                                                                int from = 9 * (9 - moveStruct.srcY) + moveStruct.srcX;
                                                                int dest = 9 * (9 - moveStruct.destY) + moveStruct.destX;
                                                                if (this.data.position.v == from)
                                                                {
                                                                    this.transform.SetAsLastSibling();
                                                                    Vector2 fromPos = convertPosToLocalPosition(from);
                                                                    Vector2 destPos = convertPosToLocalPosition(dest);
                                                                    // set 
                                                                    if (duration > 0)
                                                                    {
                                                                        localPos = Vector2.Lerp(fromPos, destPos, MoveAnimation.getAccelerateDecelerateInterpolation(time / duration));
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("why duration < 0");
                                                                    }
                                                                }
                                                            }
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown moveAnimation: " + moveAnimation + "; " + this);
                                                            break;
                                                    }
                                                    // Debug.LogError ("have moveAnimation: " + this.data.uid);
                                                }
                                                else
                                                {
                                                    // Debug.LogError ("Don't have moveAnimation: " + this.data.uid);
                                                }
                                            }
                                            this.transform.localPosition = localPos;
                                            // Debug.LogError ("pieceUI position: " + this.transform.localPosition + "; " + this.data.position.v
                                            //  + "; " + this.data.animationPos + "; " + this.data.uid+"; "+this.data.piece.v);
                                        }
                                        // sprite
                                        image.sprite = XiangqiSpriteContainer.get().getSprite(this.data.piece.v, Setting.get().style.v);
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
                            // Scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                this.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
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
                        if (image != null)
                        {
                            image.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("image null: " + this);
                        }
                    }
                    // Debug.LogError ("pieceUI position: " + this.transform.localPosition);
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
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