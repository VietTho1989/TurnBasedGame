using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;
using GameManager.ContestManager;

public class BtnNewContestManagerUI : UIBehavior<BtnNewContestManagerUI.UIData>
{

    #region UIData

    public class UIData : BtnRequestNewUI.UIData.Sub
    {

        public VP<ReferenceData<RequestNewContestManager>> requestNewContestManager;

        #region Constructor

        public enum Property
        {
            requestNewContestManager
        }

        public UIData() : base()
        {
            this.requestNewContestManager = new VP<ReferenceData<RequestNewContestManager>>(this, (byte)Property.requestNewContestManager, new ReferenceData<RequestNewContestManager>(null));
        }

        #endregion

        public override Type getType()
        {
            return Type.ContestManager;
        }

    }

    #endregion

    #region txt

    public Text tvNewContestManager;
    private static readonly TxtLanguage txtNewContestManager = new TxtLanguage("New Tournament");

    static BtnNewContestManagerUI()
    {
        // txt
        {
            txtNewContestManager.add(Language.Type.vi, "Giải Mới");
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
                RequestNewContestManager requestNewContestManager = this.data.requestNewContestManager.v.data;
                if (requestNewContestManager != null)
                {
                    // txt
                    {
                        if (tvNewContestManager != null)
                        {
                            tvNewContestManager.text = txtNewContestManager.get();
                        }
                        else
                        {
                            Debug.LogError("tvNewContestManager null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestNewContestManager null");
                }
            }
            else
            {
                // Debug.LogError("data null");
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
                uiData.requestNewContestManager.allAddCallBack(this);
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
        if (data is RequestNewContestManager)
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
                uiData.requestNewContestManager.allRemoveCallBack(this);
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
        if (data is RequestNewContestManager)
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
                case UIData.Property.requestNewContestManager:
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
        if (wrapProperty.p is RequestNewContestManager)
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
            RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
            if (roomUIData != null)
            {
                RequestNewContestManagerUI.UIData requestNewContestManagerUIData = roomUIData.requestNewContestManagerUIData.v;
                if (requestNewContestManagerUIData != null)
                {
                    RequestNewContestManagerUI.UIData.Sub sub = requestNewContestManagerUIData.sub.v;
                    if (sub != null)
                    {
                        switch (sub.getType())
                        {
                            case RequestNewContestManager.State.Type.None:
                                break;
                            case RequestNewContestManager.State.Type.Ask:
                                {
                                    RequestNewContestManagerStateAskUI.UIData askUIData = sub as RequestNewContestManagerStateAskUI.UIData;
                                    askUIData.visibility.v = RequestNewContestManagerStateAskUI.UIData.Visibility.Show;
                                }
                                break;
                            case RequestNewContestManager.State.Type.Accept:
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
                    Debug.LogError("requestNewContestManagerUIData null");
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