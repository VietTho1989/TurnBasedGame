using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ShogiMove>> legalMove;

            #region Constructor

            public enum Property
            {
                legalMove
            }

            public UIData() : base()
            {
                this.legalMove = new VP<ReferenceData<ShogiMove>>(this, (byte)Property.legalMove, new ReferenceData<ShogiMove>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        public GameObject contentContainer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // contentContainer
                    if (contentContainer != null)
                    {
                        if (this.data.legalMove.v.data != null)
                        {
                            contentContainer.SetActive(true);
                        }
                        else
                        {
                            contentContainer.SetActive(false);
                        }
                    }
                    else
                    {
                        Debug.LogError("contentContainer null: " + this);
                    }
                    // Update
                    {
                        ShogiMove legalMove = this.data.legalMove.v.data;
                        if (legalMove != null)
                        {
                            // position
                            this.transform.localPosition = Common.convertSquareToLocalPosition(legalMove.to());
                        }
                        else
                        {
                            Debug.LogError("legalMove null: " + this);
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
                // Child
                {
                    uiData.legalMove.allAddCallBack(this);
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
            // Child
            if (data is ShogiMove)
            {
                // ShogiMove shogiMove = data as ShogiMove;
                {

                }
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
                // Child
                {
                    uiData.legalMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Child
            if (data is ShogiMove)
            {
                // ShogiMove shogiMove = data as ShogiMove;
                {

                }
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
                    case UIData.Property.legalMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
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
            // Child
            if (wrapProperty.p is ShogiMove)
            {
                switch ((ShogiMove.Property)wrapProperty.n)
                {
                    case ShogiMove.Property.move:
                        dirty = true;
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