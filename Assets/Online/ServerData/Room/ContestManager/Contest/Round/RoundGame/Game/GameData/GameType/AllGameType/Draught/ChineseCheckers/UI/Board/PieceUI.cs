using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class PieceUI : UIBehavior<PieceUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> x;

            public VP<int> y;

            public VP<Common.Pebble> pebble;

            public VP<bool> blindFold;

            #region Constructor

            public enum Property
            {
                x,
                y,
                pebble,
                blindFold
            }

            public UIData() : base()
            {
                this.x = new VP<int>(this, (byte)Property.x, 0);
                this.y = new VP<int>(this, (byte)Property.y, 0);
                this.pebble = new VP<Common.Pebble>(this, (byte)Property.pebble, Common.Pebble.INVALID);
                this.blindFold = new VP<bool>(this, (byte)Property.blindFold, false);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.ChineseCheckers ? 20 : 0;
        }

        #region Refresh

        public Image imgPiece;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if(this.data.x.v>=0 && this.data.x.v<Common.X_SIZE && this.data.y.v>=0 && this.data.y.v < Common.Y_SIZE)
                    {
                        if (this.data.pebble.v != Common.Pebble.INVALID)
                        {
                            if (imgPiece != null)
                            {
                                imgPiece.enabled = true;
                            }
                            else
                            {
                                Debug.LogError("imgPiece null");
                            }
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
                                // position
                                {
                                    Vector2 localPosition = Common.ConvertXYToLocalPosition(this.data.x.v, this.data.y.v);
                                    {

                                    }
                                    this.transform.localPosition = localPosition;
                                }
                                // sprite
                                {
                                    if (imgPiece != null)
                                    {
                                        if (!this.data.blindFold.v)
                                        {
                                            Sprite sprite = ChineseCheckersSpriteContainer.get().getSprite(this.data.pebble.v);
                                            {

                                            }
                                            imgPiece.sprite = sprite;
                                        }
                                        else
                                        {
                                            Sprite sprite = ChineseCheckersSpriteContainer.get().getSprite(Common.Pebble.NO_PEBBLE);
                                            {

                                            }
                                            imgPiece.sprite = sprite;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("imgPiece null");
                                    }
                                }
                                // scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    this.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("invalid pebble");
                            if (imgPiece != null)
                            {
                                imgPiece.enabled = false;
                            }
                            else
                            {
                                Debug.LogError("imgPiece null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("outside board");
                        if (imgPiece != null)
                        {
                            imgPiece.enabled = false;
                        }
                        else
                        {
                            Debug.LogError("imgPiece null");
                        }
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
                    case UIData.Property.x:
                        dirty = true;
                        break;
                    case UIData.Property.y:
                        dirty = true;
                        break;
                    case UIData.Property.pebble:
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