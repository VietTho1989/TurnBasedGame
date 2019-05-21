using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj.NoneRule
{
    public class ShatranjCustomMoveUI : UIBehavior<ShatranjCustomMoveUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<ShatranjCustomMove>> shatranjCustomMove;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                shatranjCustomMove,
                isHint
            }

            public UIData() : base()
            {
                this.shatranjCustomMove = new VP<ReferenceData<ShatranjCustomMove>>(this, (byte)Property.shatranjCustomMove, new ReferenceData<ShatranjCustomMove>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.ShatranjCustomMove;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Shatranj ? 1 : 0;
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
                    ShatranjCustomMove shatranjCustomMove = this.data.shatranjCustomMove.v.data;
                    if (shatranjCustomMove != null)
                    {
                        // from
                        if (lineRendererFrom != null)
                        {
                            // point
                            {
                                Vector2[] points = new Vector2[5];
                                {
                                    Vector3 localPos = Common.convertXYToLocalPosition(shatranjCustomMove.fromX.v, shatranjCustomMove.fromY.v);
                                    points[0] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                    points[1] = new Vector2(localPos.x - 0.5f, localPos.y + 0.5f);
                                    points[2] = new Vector2(localPos.x - 0.5f, localPos.y - 0.5f);
                                    points[3] = new Vector2(localPos.x + 0.5f, localPos.y - 0.5f);
                                    points[4] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                }
                                lineRendererFrom.Points = points;
                            }
                            // color
                            {
                                if (this.data.isHint.v)
                                {
                                    lineRendererFrom.color = new Color(1, 0, 0, 0.5f);
                                }
                                else
                                {
                                    lineRendererFrom.color = new Color(1, 0, 0, 1f);
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
                                    Vector3 localPos = Common.convertXYToLocalPosition(shatranjCustomMove.destX.v, shatranjCustomMove.destY.v);
                                    points[0] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                    points[1] = new Vector2(localPos.x - 0.5f, localPos.y + 0.5f);
                                    points[2] = new Vector2(localPos.x - 0.5f, localPos.y - 0.5f);
                                    points[3] = new Vector2(localPos.x + 0.5f, localPos.y - 0.5f);
                                    points[4] = new Vector2(localPos.x + 0.5f, localPos.y + 0.5f);
                                }
                                lineRendererDest.Points = points;
                            }
                            // color
                            {
                                if (this.data.isHint.v)
                                {
                                    lineRendererDest.color = new Color(0, 1, 0, 0.5f);
                                }
                                else
                                {
                                    lineRendererDest.color = new Color(0, 1, 0, 1f);
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
                        // Debug.LogError ("shatranjCustomMove null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.shatranjCustomMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is ShatranjCustomMove)
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
                    uiData.shatranjCustomMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is ShatranjCustomMove)
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
                    case UIData.Property.shatranjCustomMove:
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
            if (wrapProperty.p is ShatranjCustomMove)
            {
                switch ((ShatranjCustomMove.Property)wrapProperty.n)
                {
                    case ShatranjCustomMove.Property.fromX:
                        dirty = true;
                        break;
                    case ShatranjCustomMove.Property.fromY:
                        dirty = true;
                        break;
                    case ShatranjCustomMove.Property.destX:
                        dirty = true;
                        break;
                    case ShatranjCustomMove.Property.destY:
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