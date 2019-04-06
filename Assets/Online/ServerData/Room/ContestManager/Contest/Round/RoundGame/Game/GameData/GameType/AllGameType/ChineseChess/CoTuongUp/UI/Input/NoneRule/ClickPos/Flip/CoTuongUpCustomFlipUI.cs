using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
    public class CoTuongUpCustomFlipUI : UIBehavior<CoTuongUpCustomFlipUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<CoTuongUpCustomFlip>> coTuongUpCustomFlip;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                coTuongUpCustomFlip,
                isHint
            }

            public UIData() : base()
            {
                this.coTuongUpCustomFlip = new VP<ReferenceData<CoTuongUpCustomFlip>>(this, (byte)Property.coTuongUpCustomFlip, new ReferenceData<CoTuongUpCustomFlip>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.CoTuongUpCustomFlip;
            }

        }

        #endregion

        #region Refresh

        public UILineRenderer lineRenderer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    CoTuongUpCustomFlip coTuongUpCustomFlip = this.data.coTuongUpCustomFlip.v.data;
                    if (coTuongUpCustomFlip != null)
                    {
                        // lineRenderer
                        if (lineRenderer != null)
                        {
                            Vector2[] points = new Vector2[5];
                            {
                                Vector3 localPos = Common.convertCoordToLocalPosition(coTuongUpCustomFlip.coord.v);
                                points[0] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                points[1] = new Vector2(localPos.x - 0.5f, localPos.y + 0.5f);
                                points[2] = new Vector2(localPos.x - 0.5f, localPos.y - 0.5f);
                                points[3] = new Vector2(localPos.x + 0.5f, localPos.y - 0.5f);
                                points[4] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                            }
                            lineRenderer.Points = points;
                        }
                        else
                        {
                            Debug.LogError("lineRenderer null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("coTuongUpCustomFlip null: " + this);
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
                    uiData.coTuongUpCustomFlip.allAddCallBack(this);
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
            // Child
            if (data is CoTuongUpCustomFlip)
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
                // Child
                {
                    uiData.coTuongUpCustomFlip.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Child
            if (data is CoTuongUpCustomFlip)
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
                    case UIData.Property.coTuongUpCustomFlip:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isHint:
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
            // Child
            if (wrapProperty.p is CoTuongUpCustomFlip)
            {
                switch ((CoTuongUpCustomFlip.Property)wrapProperty.n)
                {
                    case CoTuongUpCustomFlip.Property.coord:
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