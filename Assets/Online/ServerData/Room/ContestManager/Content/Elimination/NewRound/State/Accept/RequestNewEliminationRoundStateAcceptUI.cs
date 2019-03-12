using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class RequestNewEliminationRoundStateAcceptUI : UIBehavior<RequestNewEliminationRoundStateAcceptUI.UIData>
    {

        #region UIData

        public class UIData : RequestNewEliminationRoundUI.UIData.Sub
        {

            public VP<ReferenceData<RequestNewEliminationRoundStateAccept>> requestNewEliminationRoundStateAccept;

            #region Constructor

            public enum Property
            {
                requestNewEliminationRoundStateAccept
            }

            public UIData() : base()
            {
                this.requestNewEliminationRoundStateAccept = new VP<ReferenceData<RequestNewEliminationRoundStateAccept>>(this, (byte)Property.requestNewEliminationRoundStateAccept, new ReferenceData<RequestNewEliminationRoundStateAccept>(null));
            }

            #endregion

            public override RequestNewEliminationRound.State.Type getType()
            {
                return RequestNewEliminationRound.State.Type.Accept;
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

        #region Refresh

        #region txt

        public Text tvMessage;
        public static readonly TxtLanguage txtMessage = new TxtLanguage();

        static RequestNewEliminationRoundStateAcceptUI()
        {
            txtMessage.add(Language.Type.vi, "Yêu Cầu Vòng Loại Mới Chấp Nhận");
        }

        #endregion

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RequestNewEliminationRoundStateAccept requestNewEliminationRoundStateAccept = this.data.requestNewEliminationRoundStateAccept.v.data;
                    if (requestNewEliminationRoundStateAccept != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("requestNewEliminationRoundStateAccept null: " + this);
                    }
                    // txt
                    {
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get("Request New Elimination Round Accepted");
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
                    uiData.requestNewEliminationRoundStateAccept.allAddCallBack(this);
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
            if (data is RequestNewEliminationRoundStateAccept)
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
                    uiData.requestNewEliminationRoundStateAccept.allRemoveCallBack(this);
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
            if (data is RequestNewEliminationRoundStateAccept)
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
                    case UIData.Property.requestNewEliminationRoundStateAccept:
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
            if (wrapProperty.p is RequestNewEliminationRoundStateAccept)
            {
                switch ((RequestNewEliminationRoundStateAccept.Property)wrapProperty.n)
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