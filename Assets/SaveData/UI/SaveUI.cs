using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

public class SaveUI : UIBehavior<SaveUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Data>> needSaveData;

        public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

        public VP<BtnSaveDataUI.UIData> btnSaveData;

        #region Constructor

        public enum Property
        {
            needSaveData,
            fileSystemBrowser,
            btnSaveData
        }

        public UIData() : base()
        {
            this.needSaveData = new VP<ReferenceData<Data>>(this, (byte)Property.needSaveData, new ReferenceData<Data>(null));
            {
                this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
                this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
            }
            this.btnSaveData = new VP<BtnSaveDataUI.UIData>(this, (byte)Property.btnSaveData, new BtnSaveDataUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // btnSaveData
                if (!isProcess)
                {
                    BtnSaveDataUI.UIData btnSaveData = this.btnSaveData.v;
                    if (btnSaveData != null)
                    {
                        isProcess = btnSaveData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("btnSaveData null: " + this);
                    }
                }
                // fileSystemBrowser
                if (!isProcess)
                {
                    FileSystemBrowserUI.UIData fileSystemBrowser = this.fileSystemBrowser.v;
                    if (fileSystemBrowser != null)
                    {
                        isProcess = fileSystemBrowser.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("fileSystemBrowser null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        SaveUI saveUI = this.findCallBack<SaveUI>();
                        if (saveUI != null)
                        {
                            saveUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("saveUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        SaveUI saveUI = this.findCallBack<SaveUI>();
                        if (saveUI != null)
                        {
                            isProcess = saveUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("saveUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Save Data");

    public Text tvPlaceHolder;
    private static readonly TxtLanguage txtPlaceHolder = new TxtLanguage("Enter file name");

    static SaveUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Lưu Trữ Dữ Liệu");
            txtPlaceHolder.add(Language.Type.vi, "Đặt tên file");
        }
        // rect
        {
            // btnSaveDataRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-120.0, -30.0); offsetMax: (0.0, 0.0); sizeDelta: (120.0, 30.0);
                btnSaveDataRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                btnSaveDataRect.anchorMin = new Vector2(1.0f, 1.0f);
                btnSaveDataRect.anchorMax = new Vector2(1.0f, 1.0f);
                btnSaveDataRect.pivot = new Vector2(1.0f, 1.0f);
                btnSaveDataRect.offsetMin = new Vector2(-120.0f, -30.0f);
                btnSaveDataRect.offsetMax = new Vector2(0.0f, 0.0f);
                btnSaveDataRect.sizeDelta = new Vector2(120.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public InputField edtName;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Data needSaveData = this.data.needSaveData.v.data;
                if (needSaveData != null)
                {
                    // siblingIndex
                    {
                        int startIndex = 3;
                        UIRectTransform.SetSiblingIndex(this.data.fileSystemBrowser.v, startIndex + 1);
                        UIRectTransform.SetSiblingIndex(this.data.btnSaveData.v, startIndex + 2);
                        if (confirmSaveContainer != null)
                        {
                            confirmSaveContainer.SetSiblingIndex(startIndex + 3);
                        }
                        else
                        {
                            Debug.LogError("confirmSaveContainer null");
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            // btnSaveData
                            {
                                {
                                    btnSaveDataRect.offsetMin.y = -buttonSize;
                                    btnSaveDataRect.sizeDelta.y = buttonSize;
                                }
                                UIRectTransform.Set(this.data.btnSaveData.v, btnSaveDataRect);
                            }
                        }
                        // edtName
                        if (edtName != null)
                        {
                            UIRectTransform.SetPosY((RectTransform)edtName.transform, buttonSize + 10);
                        }
                        else
                        {
                            Debug.LogError("edtName null");
                        }
                        // fileSystemBrowser
                        {
                            UIRectTransform.Set(this.data.fileSystemBrowser.v, CreateFileSystemBrowserRect());
                        }
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
                        if (tvPlaceHolder != null)
                        {
                            tvPlaceHolder.text = txtPlaceHolder.get();
                            Setting.get().setContentTextSize(tvPlaceHolder);
                        }
                        else
                        {
                            Debug.LogError("tvPlaceHolder null: " + this);
                        }
                        if (edtName != null)
                        {
                            if (edtName.textComponent != null)
                            {
                                Setting.get().setContentTextSize(edtName.textComponent);
                            }
                            else
                            {
                                Debug.LogError("textComponent null");
                            }
                        }
                        else
                        {
                            Debug.LogError("edtName null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("needSaveData null: " + this);
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

    public FileSystemBrowserUI fileSystemBrowserPrefab;
    private static UIRectTransform CreateFileSystemBrowserRect()
    {
        return UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize() + 50, 0);
    }

    public BtnSaveDataUI btnSaveDataPrefab;
    private static readonly UIRectTransform btnSaveDataRect = new UIRectTransform();

    public Transform confirmSaveContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.fileSystemBrowser.allAddCallBack(this);
                uiData.btnSaveData.allAddCallBack(this);
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
        {
            if (data is FileSystemBrowserUI.UIData)
            {
                FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(fileSystemBrowserUIData, fileSystemBrowserPrefab, this.transform, CreateFileSystemBrowserRect());
                }
                dirty = true;
                return;
            }
            if (data is BtnSaveDataUI.UIData)
            {
                BtnSaveDataUI.UIData btnSaveDataUIData = data as BtnSaveDataUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnSaveDataUIData, btnSaveDataPrefab, this.transform, btnSaveDataRect);
                }
                dirty = true;
                return;
            }
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
                uiData.fileSystemBrowser.allRemoveCallBack(this);
                uiData.btnSaveData.allRemoveCallBack(this);
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
        {
            if (data is FileSystemBrowserUI.UIData)
            {
                FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                // UI
                {
                    fileSystemBrowserUIData.removeCallBackAndDestroy(typeof(FileSystemBrowserUI));
                }
                return;
            }
            if (data is BtnSaveDataUI.UIData)
            {
                BtnSaveDataUI.UIData btnSaveDataUIData = data as BtnSaveDataUI.UIData;
                // UI
                {
                    btnSaveDataUIData.removeCallBackAndDestroy(typeof(BtnSaveDataUI));
                }
                return;
            }
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
                case UIData.Property.needSaveData:
                    dirty = true;
                    break;
                case UIData.Property.fileSystemBrowser:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnSaveData:
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
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
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
        {
            if (wrapProperty.p is FileSystemBrowserUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is BtnSaveDataUI.UIData)
            {
                return;
            }
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
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            // gameUI
            {
                if (this.data.getDataParent() is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = this.data.getDataParent() as GameUI.UIData;
                    gameUIData.saveUIData.v = null;
                }
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}