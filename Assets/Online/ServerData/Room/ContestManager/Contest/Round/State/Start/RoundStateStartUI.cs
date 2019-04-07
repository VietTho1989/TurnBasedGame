using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RoundStateStartUI : UIHaveTransformDataBehavior<RoundStateStartUI.UIData>
    {

        #region UIData

        public class UIData : RoundState.UIData
        {

            public VP<ReferenceData<RoundStateStart>> roundStateStart;

            #region Constructor

            public enum Property
            {
                roundStateStart
            }

            public UIData() : base()
            {
                this.roundStateStart = new VP<ReferenceData<RoundStateStart>>(this, (byte)Property.roundStateStart, new ReferenceData<RoundStateStart>(null));
            }

            #endregion

            public override RoundState.Type getType()
            {
                return RoundState.Type.Start;
            }

        }

        #endregion

        #region txt

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("Starting");

        static RoundStateStartUI()
        {
            txtMessage.add(Language.Type.vi, "Đang Bắt Đầu");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundStateStart roundStateStart = this.data.roundStateStart.v.data;
                    if (roundStateStart != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("roundStateStart null: " + this);
                    }
                    // txt
                    {
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get();
                        }
                        else
                        {
                            Debug.LogError("tvMessage null: " + this);
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
                    uiData.roundStateStart.allAddCallBack(this);
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
            if (data is RoundStateStart)
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
                    uiData.roundStateStart.allRemoveCallBack(this);
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
            if (data is RoundStateStart)
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
                    case UIData.Property.roundStateStart:
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
            if (wrapProperty.p is RoundStateStart)
            {
                switch ((RoundStateStart.Property)wrapProperty.n)
                {
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