using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.NoneRule
{
    public class NineMenMorrisCustomMoveUI : UIBehavior<NineMenMorrisCustomMoveUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<NineMenMorrisCustomMove>> nineMenMorrisCustomMove;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                nineMenMorrisCustomMove,
                isHint
            }

            public UIData() : base()
            {
                this.nineMenMorrisCustomMove = new VP<ReferenceData<NineMenMorrisCustomMove>>(this, (byte)Property.nineMenMorrisCustomMove, new ReferenceData<NineMenMorrisCustomMove>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.NineMenMorrisCustomMove;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.NineMenMorris ? 1 : 0;
        }

        #region Refresh

        public UILineRenderer lineRendererFrom;
        public UILineRenderer lineRendererDest;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    NineMenMorrisCustomMove nineMenMorrisCustomMove = this.data.nineMenMorrisCustomMove.v.data;
                    if (nineMenMorrisCustomMove != null)
                    {
                        float radius = 0.25f;
                        // from
                        if (lineRendererFrom != null)
                        {
                            // point
                            {
                                Vector2[] points = new Vector2[5];
                                {
                                    Vector3 localPos = new Vector2(nineMenMorrisCustomMove.fromX.v - 3, nineMenMorrisCustomMove.fromY.v - 3);
                                    points[0] = new Vector2(localPos.x + radius, localPos.y + radius);
                                    points[1] = new Vector2(localPos.x - radius, localPos.y + radius);
                                    points[2] = new Vector2(localPos.x - radius, localPos.y - radius);
                                    points[3] = new Vector2(localPos.x + radius, localPos.y - radius);
                                    points[4] = new Vector2(localPos.x + radius, localPos.y + radius);
                                }
                                lineRendererFrom.Points = points;
                            }
                            // color
                            {
                                if (this.data.isHint.v)
                                {
                                    lineRendererFrom.color = new Color(0, 0, 1, 0.5f);
                                }
                                else
                                {
                                    lineRendererFrom.color = new Color(0, 0, 1, 1f);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("lineRendererFrom null: " + this);
                        }
                        // dest
                        if (lineRendererDest != null)
                        {
                            // point
                            {
                                Vector2[] points = new Vector2[5];
                                {
                                    Vector3 localPos = new Vector2(nineMenMorrisCustomMove.destX.v - 3, nineMenMorrisCustomMove.destY.v - 3);
                                    points[0] = new Vector2(localPos.x + radius, localPos.y + radius);
                                    points[1] = new Vector2(localPos.x - radius, localPos.y + radius);
                                    points[2] = new Vector2(localPos.x - radius, localPos.y - radius);
                                    points[3] = new Vector2(localPos.x + radius, localPos.y - radius);
                                    points[4] = new Vector2(localPos.x + radius, localPos.y + radius);
                                }
                                lineRendererDest.Points = points;
                            }
                            // color
                            {
                                if (this.data.isHint.v)
                                {
                                    lineRendererDest.color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 0.5f);
                                }
                                else
                                {
                                    lineRendererDest.color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 1f);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("lineRendererDest null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("nineMenMorrisCustomMove null: " + this);
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
                    uiData.nineMenMorrisCustomMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is NineMenMorrisCustomMove)
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
                    uiData.nineMenMorrisCustomMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is NineMenMorrisCustomMove)
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
                    case UIData.Property.nineMenMorrisCustomMove:
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
            if (wrapProperty.p is NineMenMorrisCustomMove)
            {
                switch ((NineMenMorrisCustomMove.Property)wrapProperty.n)
                {
                    case NineMenMorrisCustomMove.Property.fromX:
                        dirty = true;
                        break;
                    case NineMenMorrisCustomMove.Property.fromY:
                        dirty = true;
                        break;
                    case NineMenMorrisCustomMove.Property.destX:
                        dirty = true;
                        break;
                    case NineMenMorrisCustomMove.Property.destY:
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