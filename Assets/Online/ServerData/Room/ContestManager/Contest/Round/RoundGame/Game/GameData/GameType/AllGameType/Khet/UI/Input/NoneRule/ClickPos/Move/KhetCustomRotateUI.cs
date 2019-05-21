using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Khet.NoneRule
{
    public class KhetCustomRotateUI : UIBehavior<KhetCustomRotateUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<KhetCustomRotate>> khetCustomRotate;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                khetCustomRotate,
                isHint
            }

            public UIData() : base()
            {
                this.khetCustomRotate = new VP<ReferenceData<KhetCustomRotate>>(this, (byte)Property.khetCustomRotate, new ReferenceData<KhetCustomRotate>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.KhetCustomRotate;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Khet ? 1 : 0;
        }

        #region Refresh

        public UILineRenderer lineRenderer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    KhetCustomRotate khetCustomRotate = this.data.khetCustomRotate.v.data;
                    if (khetCustomRotate != null)
                    {
                        // from
                        if (lineRenderer != null)
                        {
                            // point
                            {
                                Vector2[] points = new Vector2[4];
                                {
                                    Vector2 location = Common.getLocalPosition(khetCustomRotate.position.v);
                                    if (khetCustomRotate.isAdd.v)
                                    {
                                        points[0] = new Vector2(location.x - 0.5f, location.y + 0.5f);
                                        points[1] = new Vector2(location.x + 0.5f, location.y + 0.5f);
                                        points[2] = new Vector2(location.x + 0.5f, location.y - 0.5f);
                                        points[3] = new Vector2(location.x - 0.5f, location.y - 0.5f);
                                    }
                                    else
                                    {
                                        points[0] = new Vector2(location.x + 0.5f, location.y + 0.5f);
                                        points[1] = new Vector2(location.x - 0.5f, location.y + 0.5f);
                                        points[2] = new Vector2(location.x - 0.5f, location.y - 0.5f);
                                        points[3] = new Vector2(location.x + 0.5f, location.y - 0.5f);
                                    }
                                }
                                lineRenderer.Points = points;
                            }
                            // color
                            {
                                if (this.data.isHint.v)
                                {
                                    lineRenderer.color = new Color(1, 1, 0, 1f);
                                }
                                else
                                {
                                    lineRenderer.color = new Color(1, 1, 0, 0.5f);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("lineRendererFrom null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("khetCustomRotate null: " + this);
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
                    uiData.khetCustomRotate.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is KhetCustomRotate)
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
                // Child
                {
                    uiData.khetCustomRotate.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is KhetCustomRotate)
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
                    case UIData.Property.khetCustomRotate:
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
            // Child
            if (wrapProperty.p is KhetCustomRotate)
            {
                switch ((KhetCustomRotate.Property)wrapProperty.n)
                {
                    case KhetCustomRotate.Property.position:
                        dirty = true;
                        break;
                    case KhetCustomRotate.Property.isAdd:
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