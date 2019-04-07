using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;
using GameManager.ContestManager;
using GameManager.Match.RoundRobin;

public class BtnNewRoundRobinUI : UIBehavior<BtnNewRoundRobinUI.UIData>
{

    #region UIData

    public class UIData : BtnRequestNewUI.UIData.Sub
    {

        public VP<ReferenceData<RequestNewRoundRobin>> requestNewRoundRobin;

        #region Constructor

        public enum Property
        {
            requestNewRoundRobin
        }

        public UIData() : base()
        {
            this.requestNewRoundRobin = new VP<ReferenceData<RequestNewRoundRobin>>(this, (byte)Property.requestNewRoundRobin, new ReferenceData<RequestNewRoundRobin>(null));
        }

        #endregion

        public override Type getType()
        {
            return Type.RoundRobin;
        }

    }

    #endregion

    #region txt

    public Text tvNewRoundRobin;
    private static readonly TxtLanguage txtNewRoundRobin = new TxtLanguage("New Round-robin Round");

    static BtnNewRoundRobinUI()
    {
        // txt
        {
            txtNewRoundRobin.add(Language.Type.vi, "Vòng Đấu Vòng Tròn Mới");
        }
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
                RequestNewRoundRobin requestNewRoundRobin = this.data.requestNewRoundRobin.v.data;
                if (requestNewRoundRobin != null)
                {
                    // txt
                    {
                        if (tvNewRoundRobin != null)
                        {
                            tvNewRoundRobin.text = txtNewRoundRobin.get();
                        }
                        else
                        {
                            Debug.LogError("tvNewRoundRobinRound null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestNewRoundRobinRound null");
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
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestNewRoundRobin.allAddCallBack(this);
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
        if (data is RequestNewRoundRobin)
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
                uiData.requestNewRoundRobin.allRemoveCallBack(this);
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
        if (data is RequestNewRoundRobin)
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
                case UIData.Property.requestNewRoundRobin:
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
                case Setting.Property.style:
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
        if (wrapProperty.p is RequestNewRoundRobin)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnRequest()
    {
        if (this.data != null)
        {
            RoundRobinContentUI.UIData roundRobinContentUIData = this.data.findDataInParent<RoundRobinContentUI.UIData>();
            if (roundRobinContentUIData != null)
            {
                RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = roundRobinContentUIData.requestNewRoundRobinUIData.v;
                if (requestNewRoundRobinUIData != null)
                {
                    RequestNewRoundRobinUI.UIData.Sub sub = requestNewRoundRobinUIData.sub.v;
                    if (sub != null)
                    {
                        switch (sub.getType())
                        {
                            case RequestNewRoundRobin.State.Type.None:
                                break;
                            case RequestNewRoundRobin.State.Type.Ask:
                                {
                                    RequestNewRoundRobinStateAskUI.UIData askUIData = sub as RequestNewRoundRobinStateAskUI.UIData;
                                    askUIData.visibility.v = RequestNewRoundRobinStateAskUI.UIData.Visibility.Show;
                                }
                                break;
                            case RequestNewRoundRobin.State.Type.Accept:
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType());
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
                else
                {
                    Debug.LogError("requestNewRoundRobinUIData null");
                }
            }
            else
            {
                Debug.LogError("roomUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}