using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class BtnNewRoundUI : UIBehavior<BtnNewRoundUI.UIData>
{

    #region UIData

    public class UIData : BtnRequestNewUI.UIData.Sub
    {

        public VP<ReferenceData<RequestNewRound>> requestNewRound;

        #region Constructor

        public enum Property
        {
            requestNewRound
        }

        public UIData() : base()
        {
            this.requestNewRound = new VP<ReferenceData<RequestNewRound>>(this, (byte)Property.requestNewRound, new ReferenceData<RequestNewRound>(null));
        }

        #endregion

        public override Type getType()
        {
            return Type.Round;
        }

    }

    #endregion

    #region txt

    public Text tvNewRound;
    private static readonly TxtLanguage txtNewRound = new TxtLanguage("New Game");

    static BtnNewRoundUI()
    {
        // txt
        {
            txtNewRound.add(Language.Type.vi, "Game Mới");
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
                RequestNewRound requestNewRound = this.data.requestNewRound.v.data;
                if (requestNewRound != null)
                {
                    // txt
                    {
                        if (tvNewRound != null)
                        {
                            tvNewRound.text = txtNewRound.get();
                        }
                        else
                        {
                            Debug.LogError("tvNewRound null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestNewRound null");
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
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestNewRound.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        if(data is RequestNewRound)
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
                uiData.requestNewRound.allRemoveCallBack(this);
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
        if (data is RequestNewRound)
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
                case UIData.Property.requestNewRound:
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
        if (wrapProperty.p is RequestNewRound)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRequest()
    {
        if (this.data != null)
        {
            ContestUI.UIData contestUIData = this.data.findDataInParent<ContestUI.UIData>();
            if (contestUIData != null)
            {
                RequestNewRoundUI.UIData requestNewRoundUIData = contestUIData.requestNewRoundUIData.v;
                if (requestNewRoundUIData != null)
                {
                    RequestNewRoundUI.UIData.Sub sub = requestNewRoundUIData.sub.v;
                    if (sub != null)
                    {
                        switch (sub.getType())
                        {
                            case RequestNewRound.State.Type.None:
                                break;
                            case RequestNewRound.State.Type.Ask:
                                {
                                    RequestNewRoundStateAskUI.UIData askUIData = sub as RequestNewRoundStateAskUI.UIData;
                                    askUIData.visibility.v = RequestNewRoundStateAskUI.UIData.Visibility.Show;
                                }
                                break;
                            case RequestNewRound.State.Type.Accept:
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
                    Debug.LogError("requestNewRoundUIData null");
                }
            }
            else
            {
                Debug.LogError("contestUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}