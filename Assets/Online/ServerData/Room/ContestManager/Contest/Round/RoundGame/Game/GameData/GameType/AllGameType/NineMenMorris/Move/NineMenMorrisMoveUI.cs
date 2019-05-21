using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class NineMenMorrisMoveUI : UIBehavior<NineMenMorrisMoveUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<NineMenMorrisMove>> nineMenMorrisMove;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                nineMenMorrisMove,
                isHint
            }

            public UIData() : base()
            {
                this.nineMenMorrisMove = new VP<ReferenceData<NineMenMorrisMove>>(this, (byte)Property.nineMenMorrisMove, new ReferenceData<NineMenMorrisMove>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.NineMenMorrisMove;
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
        public Image lineRendererRemove;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    NineMenMorrisMove nineMenMorrisMove = this.data.nineMenMorrisMove.v.data;
                    if (nineMenMorrisMove != null)
                    {
                        Debug.LogError(nineMenMorrisMove.print());
                        if (lineRendererFrom != null && lineRendererDest != null && lineRendererRemove != null)
                        {
                            float rectSize = 0.3f;
                            switch (nineMenMorrisMove.action.v)
                            {
                                case Common.NMMAction.Place:
                                    {
                                        // from
                                        lineRendererFrom.enabled = true;
                                        {
                                            Vector2[] points = new Vector2[5];
                                            {
                                                Vector3 localPos = Common.convertPositionToLocal(nineMenMorrisMove.moved.v);
                                                points[0] = new Vector2(localPos.x + rectSize, localPos.y + rectSize);
                                                points[1] = new Vector2(localPos.x - rectSize, localPos.y + rectSize);
                                                points[2] = new Vector2(localPos.x - rectSize, localPos.y - rectSize);
                                                points[3] = new Vector2(localPos.x + rectSize, localPos.y - rectSize);
                                                points[4] = new Vector2(localPos.x + rectSize, localPos.y + rectSize);
                                            }
                                            lineRendererFrom.Points = points;
                                        }
                                        // dest
                                        lineRendererDest.enabled = false;
                                    }
                                    break;
                                case Common.NMMAction.Mv_Down:
                                case Common.NMMAction.Mv_Up:
                                case Common.NMMAction.Mv_Right:
                                case Common.NMMAction.Mv_Left:
                                    {
                                        // from
                                        lineRendererFrom.enabled = true;
                                        {
                                            Vector2[] points = new Vector2[2];
                                            {
                                                points[0] = Common.convertPositionToLocal(nineMenMorrisMove.moved.v);
                                                points[1] = Common.convertPositionToLocal(nineMenMorrisMove.moved_to.v);
                                            }
                                            lineRendererFrom.Points = points;
                                        }
                                        // dest
                                        lineRendererDest.enabled = false;
                                    }
                                    break;
                                case Common.NMMAction.Fly:
                                    {
                                        // from
                                        lineRendererFrom.enabled = true;
                                        {
                                            Vector2[] points = new Vector2[5];
                                            {
                                                Vector3 localPos = Common.convertPositionToLocal(nineMenMorrisMove.moved.v);
                                                points[0] = new Vector2(localPos.x + rectSize, localPos.y + rectSize);
                                                points[1] = new Vector2(localPos.x - rectSize, localPos.y + rectSize);
                                                points[2] = new Vector2(localPos.x - rectSize, localPos.y - rectSize);
                                                points[3] = new Vector2(localPos.x + rectSize, localPos.y - rectSize);
                                                points[4] = new Vector2(localPos.x + rectSize, localPos.y + rectSize);
                                            }
                                            lineRendererFrom.Points = points;
                                        }
                                        // dest
                                        lineRendererDest.enabled = true;
                                        {
                                            Vector2[] points = new Vector2[5];
                                            {
                                                Vector3 localPos = Common.convertPositionToLocal(nineMenMorrisMove.moved_to.v);
                                                points[0] = new Vector2(localPos.x + rectSize, localPos.y + rectSize);
                                                points[1] = new Vector2(localPos.x - rectSize, localPos.y + rectSize);
                                                points[2] = new Vector2(localPos.x - rectSize, localPos.y - rectSize);
                                                points[3] = new Vector2(localPos.x + rectSize, localPos.y - rectSize);
                                                points[4] = new Vector2(localPos.x + rectSize, localPos.y + rectSize);
                                            }
                                            lineRendererDest.Points = points;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown action: " + nineMenMorrisMove.action.v);
                                    break;
                            }
                            // removed
                            {
                                bool isRemoved = false;
                                {
                                    if (nineMenMorrisMove.removed.v >= 0 && nineMenMorrisMove.removed.v < Common.BOARD_SPOT)
                                    {
                                        isRemoved = true;
                                    }
                                }
                                if (isRemoved)
                                {
                                    lineRendererRemove.enabled = true;
                                    /*{
										Vector2[] points = new Vector2[5];
										{
											Vector3 localPos = Common.convertPositionToLocal (nineMenMorrisMove.removed.v);
											points [0] = new Vector2 (localPos.x + rectSize, localPos.y + rectSize);
											points [1] = new Vector2 (localPos.x - rectSize, localPos.y + rectSize);
											points [2] = new Vector2 (localPos.x - rectSize, localPos.y - rectSize);
											points [3] = new Vector2 (localPos.x + rectSize, localPos.y - rectSize);
											points [4] = new Vector2 (localPos.x + rectSize, localPos.y + rectSize);
										}
										lineRendererRemove.Points = points;
									}*/
                                    lineRendererRemove.transform.localPosition = Common.convertPositionToLocal(nineMenMorrisMove.removed.v);
                                }
                                else
                                {
                                    lineRendererRemove.enabled = false;
                                }
                            }
                            // color
                            if (!this.data.isHint.v)
                            {
                                lineRendererFrom.color = new Color(0, 0, 1, 1);
                                lineRendererDest.color = new Color(0, 0, 1, 1);
                                lineRendererRemove.color = new Color(1, 0, 0, 1);
                            }
                            else
                            {
                                lineRendererFrom.color = new Color(0, 0, 1, 0.5f);
                                lineRendererDest.color = new Color(0, 0, 1, 0.5f);
                                lineRendererRemove.color = new Color(1, 0, 0, 0.5f);
                            }
                        }
                        else
                        {
                            Debug.LogError("lineRenderer null");
                        }
                    }
                    else
                    {
                        Debug.LogError("nineMenMorrisMove null");
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.nineMenMorrisMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is NineMenMorrisMove)
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
                    uiData.nineMenMorrisMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is NineMenMorrisMove)
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
                    case UIData.Property.nineMenMorrisMove:
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
            if (wrapProperty.p is NineMenMorrisMove)
            {
                switch ((NineMenMorrisMove.Property)wrapProperty.n)
                {
                    case NineMenMorrisMove.Property.moved:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.moved_to:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.action:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.mill:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.removed:
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