using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRoundHaveLimitInformUI : UIHaveTransformDataBehavior<RequestNewRoundHaveLimitInformUI.UIData>
    {

        #region UIData

        public class UIData : RequestNewRoundInformUI.UIData.LimitUI
        {

            public VP<ReferenceData<RequestNewRoundHaveLimit>> haveLimit;

            #region Constructor

            public enum Property
            {
                haveLimit
            }

            public UIData() : base()
            {
                this.haveLimit = new VP<ReferenceData<RequestNewRoundHaveLimit>>(this, (byte)Property.haveLimit, new ReferenceData<RequestNewRoundHaveLimit>(null));
            }

            #endregion

            public override RequestNewRound.Limit.Type getType()
            {
                return RequestNewRound.Limit.Type.HaveLimit;
            }

        }

        #endregion

        #region Refresh

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public static readonly TxtLanguage txtMaxRound = new TxtLanguage();
        public static readonly TxtLanguage txtEnoughScoreStop = new TxtLanguage();

        static RequestNewRoundHaveLimitInformUI()
        {
            txtTitle.add(Language.Type.vi, "Yêu Cầu Set Mới: Có Giới Hạn");
            txtMaxRound.add(Language.Type.vi, "Số set tối đa");
            txtEnoughScoreStop.add(Language.Type.vi, "Đủ điểm thì dừng");
        }

        #endregion

        public Text tvInform;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RequestNewRoundHaveLimit haveLimit = this.data.haveLimit.v.data;
                    if (haveLimit != null)
                    {
                        // tvInform
                        {
                            if (tvInform != null)
                            {
                                tvInform.text = txtMaxRound.get("Max round") + ": " + haveLimit.maxRound.v + "; " + txtEnoughScoreStop.get("enough score stop") + ": " + haveLimit.enoughScoreStop.v;
                            }
                            else
                            {
                                Debug.LogError("tvInform null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("haveLimit null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Request New Set: Have Limit");
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
                    uiData.haveLimit.allAddCallBack(this);
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
            if (data is RequestNewRoundHaveLimit)
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
                    uiData.haveLimit.allRemoveCallBack(this);
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
            if (data is RequestNewRoundHaveLimit)
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
                    case UIData.Property.haveLimit:
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
            if (wrapProperty.p is RequestNewRoundHaveLimit)
            {
                switch ((RequestNewRoundHaveLimit.Property)wrapProperty.n)
                {
                    case RequestNewRoundHaveLimit.Property.maxRound:
                        dirty = true;
                        break;
                    case RequestNewRoundHaveLimit.Property.enoughScoreStop:
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