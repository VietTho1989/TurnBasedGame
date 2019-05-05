﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LanMenuUI : UIBehavior<LanMenuUI.UIData>
{

    #region UIData

    public class UIData : LanUI.UIData.Sub
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

        }

        #endregion

        public override LanUI.UIData.Sub.Type getType()
        {
            return LanUI.UIData.Sub.Type.Menu;
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
                        LanMenuUI lanMenuUI = this.findCallBack<LanMenuUI>();
                        if (lanMenuUI != null)
                        {
                            lanMenuUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("lanMenuUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        LanMenuUI lanMenuUI = this.findCallBack<LanMenuUI>();
                        if (lanMenuUI != null)
                        {
                            isProcess = lanMenuUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("lanMenuUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("LAN");

    public Text tvHost;
    private static readonly TxtLanguage txtHost = new TxtLanguage("Host");

    public Text tvClient;
    private static readonly TxtLanguage txtClient = new TxtLanguage("Client");

    static LanMenuUI()
    {
        txtTitle.add(Language.Type.vi, "Chơi Mạng Lan");
        txtHost.add(Language.Type.vi, "Tạo Mạng Chủ");
        txtClient.add(Language.Type.vi, "Tạo Mạng Khách");
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // UI
                {
                    UIRectTransform.SetButtonTopLeftTransform(btnBack);
                    UIRectTransform.SetTitleTransform(lbTitle);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get();
                        Setting.get().setTitleTextSize(lbTitle);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (tvHost != null)
                    {
                        tvHost.text = txtHost.get();
                    }
                    else
                    {
                        Debug.LogError("tvHost null: " + this);
                    }
                    if (tvClient != null)
                    {
                        tvClient.text = txtClient.get();
                    }
                    else
                    {
                        Debug.LogError("tvClient null: " + this);
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
        if (data is LanMenuUI.UIData)
        {
            // Setting
            {
                Setting.get().addCallBack(this);
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is LanMenuUI.UIData)
        {
            LanMenuUI.UIData uiData = data as LanMenuUI.UIData;
            // Setting
            {
                Setting.get().removeCallBack(this);
            }
            // Child
            {

            }
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        // Debug.LogError ("onClickBtnBack");
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                if (mainUIData.sub.v.getType() != MainUI.UIData.Sub.Type.Home)
                {
                    mainUIData.sub.v = new HomeUI.UIData();
                }
                else
                {
                    Debug.LogError("Why already home");
                }
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnHost()
    {
        // Debug.LogError ("onClickBtnHost");
        if (this.data != null)
        {
            LanUI.UIData lanUIData = this.data.findDataInParent<LanUI.UIData>();
            if (lanUIData != null)
            {
                if (lanUIData.sub.v.getType() != LanUI.UIData.Sub.Type.Host)
                {
                    lanUIData.sub.v = new LanHostUI.UIData();
                }
                else
                {
                    Debug.LogError("Why already host");
                }
            }
            else
            {
                Debug.LogError("lanUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnClient()
    {
        // Debug.LogError ("onClickBtnClient");
        if (this.data != null)
        {
            LanUI.UIData lanUIData = this.data.findDataInParent<LanUI.UIData>();
            if (lanUIData != null)
            {
                if (lanUIData.sub.v.getType() != LanUI.UIData.Sub.Type.Client)
                {
                    lanUIData.sub.v = new LanClientUI.UIData();
                }
                else
                {
                    Debug.LogError("Why already client");
                }
            }
            else
            {
                Debug.LogError("lanUIData null");
            }
        }
        else
        {
            Debug.LogError("uiData null");
        }
    }

}