using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HaveDatabaseServerFailUI : UIBehavior<HaveDatabaseServerFailUI.UIData>
{

    #region UIData

    public class UIData : HaveDatabaseServerUI.UIData.Sub
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

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
                Debug.LogError("TODO Can hoan thien");
            }
            return isProcess;
        }

        public static void changeToFail(Data data)
        {
            if (data != null)
            {
                HaveDatabaseServerUI.UIData haveDatabaseServerUIData = data.findDataInParent<HaveDatabaseServerUI.UIData>();
                if (haveDatabaseServerUIData != null)
                {
                    HaveDatabaseServerFailUI.UIData failUIData = haveDatabaseServerUIData.sub.newOrOld<HaveDatabaseServerFailUI.UIData>();
                    {

                    }
                    haveDatabaseServerUIData.sub.v = failUIData;
                }
                else
                {
                    Debug.LogError("haveDatabaseServerUIData null: " + data);
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
            }
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            return MainUI.UIData.AllowShowBanner.ForceShow;
        }

    }

    #endregion

    #region txt

    public Text lbMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Load database fail");

    static HaveDatabaseServerFailUI()
    {
        txtMessage.add(Language.Type.vi, "Tải cơ sở dữ liệu thất bại");
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
                // txt
                {
                    if (lbMessage != null)
                    {
                        lbMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("lbMessage null");
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
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
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
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}