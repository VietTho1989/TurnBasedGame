using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

namespace GameManager.ContestManager
{
    public class RequestNewContestManagerStateAcceptUI : UIBehavior<RequestNewContestManagerStateAcceptUI.UIData>
    {

        #region UIData

        public class UIData : RequestNewContestManagerUI.UIData.Sub
        {

            public VP<ReferenceData<RequestNewContestManagerStateAccept>> requestNewContestManagerStateAccept;

            #region Constructor

            public enum Property
            {
                requestNewContestManagerStateAccept
            }

            public UIData() : base()
            {
                this.requestNewContestManagerStateAccept = new VP<ReferenceData<RequestNewContestManagerStateAccept>>(this, (byte)Property.requestNewContestManagerStateAccept, new ReferenceData<RequestNewContestManagerStateAccept>(null));
            }

            #endregion

            public override RequestNewContestManager.State.Type getType()
            {
                return RequestNewContestManager.State.Type.Accept;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("Request New Tournament Accepted");

        static RequestNewContestManagerStateAcceptUI()
        {
            txtMessage.add(Language.Type.vi, "Yêu Cầu Giải Mới Chấp Nhận");
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
                    RequestNewContestManagerStateAccept requestNewContestManagerStateAccept = this.data.requestNewContestManagerStateAccept.v.data;
                    if (requestNewContestManagerStateAccept != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("requestNewContestManagerStateAccept null: " + this);
                    }
                    // txt
                    {
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get();
                        }
                        else
                        {
                            Debug.LogError("lbMessage null: " + this);
                        }
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
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.requestNewContestManagerStateAccept.allAddCallBack(this);
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
            if (data is RequestNewContestManagerStateAccept)
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
                    uiData.requestNewContestManagerStateAccept.allRemoveCallBack(this);
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
            if (data is RequestNewContestManagerStateAccept)
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
                    case UIData.Property.requestNewContestManagerStateAccept:
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
            if (wrapProperty.p is RequestNewContestManagerStateAccept)
            {
                switch ((RequestNewContestManagerStateAccept.Property)wrapProperty.n)
                {
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}