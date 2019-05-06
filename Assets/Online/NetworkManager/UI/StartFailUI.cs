using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StartFailUI : UIBehavior<StartFailUI.UIData>
{

    #region UIData

    public class UIData : ManagerUI.UIData.Sub
    {

        public VP<ReferenceData<Server>> server;

        #region Constructor

        public enum Property
        {
            server
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
        }

        #endregion

        public override Type getType()
        {
            return Type.Fail;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        StartFailUI startFailUI = this.findCallBack<StartFailUI>();
                        if (startFailUI != null)
                        {
                            startFailUI.onClickBtnReturn();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("startFailUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        StartFailUI startFailUI = this.findCallBack<StartFailUI>();
                        if (startFailUI != null)
                        {
                            isProcess = startFailUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("startFailUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            return MainUI.UIData.AllowShowBanner.ForceShow;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Start Server Fail");

    public Text tvReturn;
    private static readonly TxtLanguage txtReturn = new TxtLanguage("Return");

    static StartFailUI()
    {
        txtTitle.add(Language.Type.vi, "Khởi động server thất bại");
        txtReturn.add(Language.Type.vi, "Quay lại");
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
                // lbTitle
                if (lbTitle != null)
                {
                    lbTitle.text = txtTitle.get();
                }
                else
                {
                    Debug.LogError("lbTitle null: " + this);
                }
                // tvReturn
                if (tvReturn != null)
                {
                    tvReturn.text = txtReturn.get();
                }
                else
                {
                    Debug.LogError("tvReturn null: " + this);
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
                uiData.server.allAddCallBack(this);
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
        if (data is Server)
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
                uiData.server.allRemoveCallBack(this);
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
        if (data is Server)
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
                case UIData.Property.server:
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
        if (wrapProperty.p is Server)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {

        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnReturn()
    {
        Debug.LogError("onClickBtnReturn: " + this);
        if (this.data != null)
        {
            ServerManager.UIData.OnClick onClick = this.data.findDataInParent<ServerManager.UIData.OnClick>();
            if (onClick != null)
            {
                onClick.onClickReturn();
            }
            else
            {
                Debug.LogError("onClick null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}