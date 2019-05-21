using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public class StartNormalUI : UIBehavior<StartNormalUI.UIData>
    {

        #region UIData

        public class UIData : StartUI.UIData.Sub
        {

            public VP<ReferenceData<StartNormal>> startNormal;

            #region Constructor

            public enum Property
            {
                startNormal
            }

            public UIData() : base()
            {
                this.startNormal = new VP<ReferenceData<StartNormal>>(this, (byte)Property.startNormal, new ReferenceData<StartNormal>(null));
            }

            #endregion

            public override Start.Sub.Type getType()
            {
                return Start.Sub.Type.Normal;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return 1;
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Start");

        static StartNormalUI()
        {
            txtTitle.add(Language.Type.vi, "Bắt Đầu");
        }

        #endregion

        #region Refresh

        public Text tvTime;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    StartNormal startNormal = this.data.startNormal.v.data;
                    if (startNormal != null)
                    {
                        // tvTime
                        if (tvTime != null)
                        {
                            if (startNormal.duration.v > 0)
                            {
                                tvTime.text = Mathf.Min(startNormal.time.v, startNormal.duration.v) + "/" + startNormal.duration.v;
                            }
                            else
                            {
                                tvTime.text = Mathf.Min(startNormal.time.v, startNormal.duration.v) + "/" + startNormal.duration.v;
                            }
                        }
                        else
                        {
                            Debug.LogError("tvTime null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("startNormal null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
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
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.startNormal.allAddCallBack(this);
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
            // Child
            if (data is StartNormal)
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
                // Child
                {
                    uiData.startNormal.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            if (data is StartNormal)
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
                    case UIData.Property.startNormal:
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
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
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
            // Child
            if (wrapProperty.p is StartNormal)
            {
                switch ((StartNormal.Property)wrapProperty.n)
                {
                    case StartNormal.Property.time:
                        dirty = true;
                        break;
                    case StartNormal.Property.duration:
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