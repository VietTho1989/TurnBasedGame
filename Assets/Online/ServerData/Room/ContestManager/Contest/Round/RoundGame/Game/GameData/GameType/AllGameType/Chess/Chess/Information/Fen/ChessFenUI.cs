using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public class ChessFenUI : UIBehavior<ChessFenUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Chess>> chess;

            #region Constructor

            public enum Property
            {
                chess
            }

            public UIData() : base()
            {
                this.chess = new VP<ReferenceData<Chess>>(this, (byte)Property.chess, new ReferenceData<Chess>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        public Text tvFen;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Chess chess = this.data.chess.v.data;
                    if (chess != null)
                    {
                        // tvFen
                        if (tvFen != null)
                        {
                            tvFen.text = Core.unityPositionToFen(chess, Core.CanCorrect);
                        }
                        else
                        {
                            Debug.LogError("tvFen null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("chess null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.chess.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                data.addCallBackAllChildren(this);
                dirty = true;
                return;
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.chess.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                data.removeCallBackAllChildren(this);
                return;
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
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
                    case UIData.Property.chess:
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
            // Child
            {
                if (Generic.IsAddCallBackInterface<T>())
                {
                    ValueChangeUtils.replaceCallBack(this, syncs);
                }
                dirty = true;
                return;
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}