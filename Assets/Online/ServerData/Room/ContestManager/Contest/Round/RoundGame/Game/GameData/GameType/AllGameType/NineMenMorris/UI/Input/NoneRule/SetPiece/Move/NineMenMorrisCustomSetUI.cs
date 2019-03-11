using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.NoneRule
{
    public class NineMenMorrisCustomSetUI : UIBehavior<NineMenMorrisCustomSetUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<NineMenMorrisCustomSet>> nineMenMorrisCustomSet;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                nineMenMorrisCustomSet,
                isHint
            }

            public UIData() : base()
            {
                this.nineMenMorrisCustomSet = new VP<ReferenceData<NineMenMorrisCustomSet>>(this, (byte)Property.nineMenMorrisCustomSet, new ReferenceData<NineMenMorrisCustomSet>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.NineMenMorrisCustomSet;
            }

        }

        #endregion

        #region Refresh

        public UILineRenderer lineRenderer;

        public Image imgHint;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    NineMenMorrisCustomSet nineMenMorrisCustomSet = this.data.nineMenMorrisCustomSet.v.data;
                    if (nineMenMorrisCustomSet != null)
                    {
                        // lineRenderer
                        if (lineRenderer != null)
                        {
                            Vector2[] points = new Vector2[5];
                            {
                                float radius = 0.25f;
                                Vector3 localPos = new Vector2(nineMenMorrisCustomSet.x.v - 3, nineMenMorrisCustomSet.y.v - 3);
                                points[0] = new Vector2(localPos.x + radius, localPos.y + radius);
                                points[1] = new Vector2(localPos.x - radius, localPos.y + radius);
                                points[2] = new Vector2(localPos.x - radius, localPos.y - radius);
                                points[3] = new Vector2(localPos.x + radius, localPos.y - radius);
                                points[4] = new Vector2(localPos.x + radius, localPos.y + radius);
                            }
                            lineRenderer.Points = points;
                        }
                        else
                        {
                            Debug.LogError("lineRenderer null: " + this);
                        }
                        // imgHint
                        if (imgHint != null)
                        {
                            if (this.data.isHint.v)
                            {
                                // sprite
                                imgHint.sprite = NineMenMorrisSpriteContainer.get().getSprite(nineMenMorrisCustomSet.piece.v);
                                // position
                                {
                                    imgHint.transform.localPosition = new Vector2(nineMenMorrisCustomSet.x.v - 3, nineMenMorrisCustomSet.y.v - 3);
                                }
                                // scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                }
                            }
                            else
                            {
                                imgHint.sprite = NineMenMorrisSpriteContainer.get().getSprite(Common.SpotStatus.SS_Empty);
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("nineMenMorrisCustomSet null: " + this);
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
                    uiData.nineMenMorrisCustomSet.allAddCallBack(this);
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
            if (data is NineMenMorrisCustomSet)
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
                    uiData.nineMenMorrisCustomSet.allRemoveCallBack(this);
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
            if (data is NineMenMorrisCustomSet)
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
                    case UIData.Property.nineMenMorrisCustomSet:
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
            if (wrapProperty.p is NineMenMorrisCustomSet)
            {
                switch ((NineMenMorrisCustomSet.Property)wrapProperty.n)
                {
                    case NineMenMorrisCustomSet.Property.x:
                        dirty = true;
                        break;
                    case NineMenMorrisCustomSet.Property.y:
                        dirty = true;
                        break;
                    case NineMenMorrisCustomSet.Property.piece:
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