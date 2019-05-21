using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Janggi.NoneRule
{
    public class JanggiCustomSetUI : UIBehavior<JanggiCustomSetUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<JanggiCustomSet>> janggiCustomSet;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                janggiCustomSet,
                isHint
            }

            public UIData() : base()
            {
                this.janggiCustomSet = new VP<ReferenceData<JanggiCustomSet>>(this, (byte)Property.janggiCustomSet, new ReferenceData<JanggiCustomSet>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.JanggiCustomSet;
            }
        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Janggi ? 1 : 0;
        }

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
                    JanggiCustomSet janggiCustomSet = this.data.janggiCustomSet.v.data;
                    if (janggiCustomSet != null)
                    {
                        // lineRenderer
                        if (lineRenderer != null)
                        {
                            Vector2[] points = new Vector2[5];
                            {
                                Vector3 localPos = Common.convertXYToLocalPosition(janggiCustomSet.x.v, janggiCustomSet.y.v);
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
                        // imgHint
                        if (imgHint != null)
                        {
                            if (this.data.isHint.v)
                            {
                                // sprite
                                imgHint.sprite = JanggiSpriteContainer.get().getSprite((uint)janggiCustomSet.piece.v, Setting.get().style.v);
                                // position
                                {
                                    imgHint.transform.localPosition = Common.convertXYToLocalPosition(janggiCustomSet.x.v, janggiCustomSet.y.v);
                                }
                                // scale
                                {
                                    int playerView = GameDataBoardUI.UIData.getPlayerView(this.data);
                                    imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3(1, 1, 1) : new Vector3(1, -1, 1));
                                }
                            }
                            else
                            {
                                imgHint.sprite = JanggiSpriteContainer.get().getSprite((uint)StoneHelper.Stones.Empty, Setting.get().style.v);
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("janggiCustomSet null: " + this);
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
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    perspectiveChange.addCallBack(this);
                    perspectiveChange.setData(uiData);
                }
                // Child
                {
                    uiData.janggiCustomSet.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
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
            if (data is JanggiCustomSet)
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
                // Setting
                Setting.get().removeCallBack(this);
                // CheckChange
                {
                    perspectiveChange.removeCallBack(this);
                    perspectiveChange.setData(null);
                }
                // Child
                {
                    uiData.janggiCustomSet.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Child
            if (data is JanggiCustomSet)
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
                    case UIData.Property.janggiCustomSet:
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
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        break;
                    case Setting.Property.style:
                        dirty = true;
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
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
            if (wrapProperty.p is JanggiCustomSet)
            {
                switch ((JanggiCustomSet.Property)wrapProperty.n)
                {
                    case JanggiCustomSet.Property.x:
                        dirty = true;
                        break;
                    case JanggiCustomSet.Property.y:
                        dirty = true;
                        break;
                    case JanggiCustomSet.Property.piece:
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