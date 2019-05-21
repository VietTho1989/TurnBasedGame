using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Banqi.NoneRule
{
    public class BanqiCustomFlipUI : UIBehavior<BanqiCustomFlipUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<BanqiCustomFlip>> banqiCustomFlip;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                banqiCustomFlip,
                isHint
            }

            public UIData() : base()
            {
                this.banqiCustomFlip = new VP<ReferenceData<BanqiCustomFlip>>(this, (byte)Property.banqiCustomFlip, new ReferenceData<BanqiCustomFlip>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.BanqiCustomFlip;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Banqi ? 1 : 0;
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
                    BanqiCustomFlip banqiCustomFlip = this.data.banqiCustomFlip.v.data;
                    if (banqiCustomFlip != null)
                    {
                        // lineRenderer
                        if (lineRenderer != null)
                        {
                            Vector2[] points = new Vector2[5];
                            {
                                Vector3 localPos = Common.convertPosToLocalPosition(8 * banqiCustomFlip.y.v + banqiCustomFlip.x.v);
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
                        Debug.LogError("banqiCustomFlip null: " + this);
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
                    uiData.banqiCustomFlip.allAddCallBack(this);
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
            if (data is BanqiCustomFlip)
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
                    uiData.banqiCustomFlip.allRemoveCallBack(this);
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
            if (data is BanqiCustomFlip)
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
                    case UIData.Property.banqiCustomFlip:
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
            if (wrapProperty.p is BanqiCustomFlip)
            {
                switch ((BanqiCustomFlip.Property)wrapProperty.n)
                {
                    case BanqiCustomFlip.Property.x:
                        dirty = true;
                        break;
                    case BanqiCustomFlip.Property.y:
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