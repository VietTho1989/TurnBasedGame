using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;
using GameManager.ContestManager;
using GameManager.Match.Elimination;

public class BtnNewEliminationRoundUI : UIBehavior<BtnNewEliminationRoundUI.UIData>
{

    #region UIData

    public class UIData : BtnRequestNewUI.UIData.Sub
    {

        public VP<ReferenceData<RequestNewEliminationRound>> requestNewEliminationRound;

        #region Constructor

        public enum Property
        {
            requestNewEliminationRound
        }

        public UIData() : base()
        {
            this.requestNewEliminationRound = new VP<ReferenceData<RequestNewEliminationRound>>(this, (byte)Property.requestNewEliminationRound, new ReferenceData<RequestNewEliminationRound>(null));
        }

        #endregion

        public override Type getType()
        {
            return Type.EliminationRound;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        BtnNewEliminationRoundUI btnNewEliminationRoundUI = this.findCallBack<BtnNewEliminationRoundUI>();
                        if (btnNewEliminationRoundUI != null)
                        {
                            isProcess = btnNewEliminationRoundUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnNewContestManagerUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text tvNewEliminationRound;
    private static readonly TxtLanguage txtNewEliminationRound = new TxtLanguage("New Elimination Round");

    static BtnNewEliminationRoundUI()
    {
        // txt
        {
            txtNewEliminationRound.add(Language.Type.vi, "Vòng Đấu Mới");
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
                RequestNewEliminationRound requestNewEliminationRound = this.data.requestNewEliminationRound.v.data;
                if (requestNewEliminationRound != null)
                {
                    // txt
                    {
                        if (tvNewEliminationRound != null)
                        {
                            tvNewEliminationRound.text = txtNewEliminationRound.get();
                        }
                        else
                        {
                            Debug.LogError("tvNewEliminationRound null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestNewEliminationRound null");
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
                uiData.requestNewEliminationRound.allAddCallBack(this);
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
        if (data is RequestNewEliminationRound)
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
                uiData.requestNewEliminationRound.allRemoveCallBack(this);
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
        if (data is RequestNewEliminationRound)
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
                case UIData.Property.requestNewEliminationRound:
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
        if (wrapProperty.p is RequestNewEliminationRound)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.Q:
                        {
                            if (btnRequest != null && btnRequest.gameObject.activeInHierarchy && btnRequest.interactable)
                            {
                                this.onClickBtnRequest();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnRequest;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRequest()
    {
        if (this.data != null)
        {
            EliminationContentUI.UIData eliminationContentUIData = this.data.findDataInParent<EliminationContentUI.UIData>();
            if (eliminationContentUIData != null)
            {
                RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = eliminationContentUIData.requestNewEliminationRoundUIData.v;
                if (requestNewEliminationRoundUIData != null)
                {
                    RequestNewEliminationRoundUI.UIData.Sub sub = requestNewEliminationRoundUIData.sub.v;
                    if (sub != null)
                    {
                        switch (sub.getType())
                        {
                            case RequestNewEliminationRound.State.Type.None:
                                break;
                            case RequestNewEliminationRound.State.Type.Ask:
                                {
                                    RequestNewEliminationRoundStateAskUI.UIData askUIData = sub as RequestNewEliminationRoundStateAskUI.UIData;
                                    askUIData.visibility.v = RequestNewEliminationRoundStateAskUI.UIData.Visibility.Show;
                                }
                                break;
                            case RequestNewEliminationRound.State.Type.Accept:
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
                    Debug.LogError("requestNewEliminationRoundUIData null");
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