using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
    public class ReversiLegalUI : UIBehavior<ReversiLegalUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<int> position;

            #region Constructor

            public enum Property
            {
                position
            }

            public UIData() : base()
            {
                this.position = new VP<int>(this, (byte)Property.position, -1);
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Reversi ? 4 : 0;
        }

        #region Refresh

        public UICircle ivLegal;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // position
                    {
                        if (ivLegal != null)
                        {
                            // get position
                            int position = this.data.position.v;
                            // process
                            if (position >= 0 && position < 64)
                            {
                                // enable
                                {
                                    // check isOnAnimation
                                    bool isOnAnimation = false;
                                    {
                                        ReversiGameDataUI.UIData reversiGameDataUIData = this.data.findDataInParent<ReversiGameDataUI.UIData>();
                                        if (reversiGameDataUIData != null)
                                        {
                                            isOnAnimation = reversiGameDataUIData.isOnAnimation.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("reversiGameDataUIData null: " + this);
                                        }
                                    }
                                    // process
                                    if (!isOnAnimation)
                                    {
                                        ivLegal.enabled = true;
                                    }
                                    else
                                    {
                                        ivLegal.enabled = false;
                                    }
                                }
                                // transform
                                {
                                    this.transform.localPosition = Common.convertSquareToLocalPosition(position);
                                }
                            }
                            else
                            {
                                ivLegal.enabled = false;
                            }
                            // scale
                            {
                                int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                ivLegal.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                            }
                        }
                        else
                        {
                            Debug.LogError("why img null: " + this);
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

        private ReversiGameDataUI.UIData reversiGameDataUIData = null;
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
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.reversiGameDataUIData);
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
            // Parent
            if (data is ReversiGameDataUI.UIData)
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.reversiGameDataUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Parent
            if (data is ReversiGameDataUI.UIData)
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
            // Parent
            if (wrapProperty.p is ReversiGameDataUI.UIData)
            {
                switch ((ReversiGameDataUI.UIData.Property)wrapProperty.n)
                {
                    case ReversiGameDataUI.UIData.Property.gameData:
                        break;
                    case ReversiGameDataUI.UIData.Property.board:
                        break;
                    case ReversiGameDataUI.UIData.Property.isOnAnimation:
                        dirty = true;
                        break;
                    case ReversiGameDataUI.UIData.Property.lastMove:
                        break;
                    case ReversiGameDataUI.UIData.Property.showHint:
                        break;
                    case ReversiGameDataUI.UIData.Property.inputUI:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }

        #endregion

    }
}