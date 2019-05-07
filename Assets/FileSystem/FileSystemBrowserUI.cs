using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class FileSystemBrowserUI : UIBehavior<FileSystemBrowserUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<FileSystemBrowser>> fileSystemBrowser;

            public VP<Show.UIData> showUIData;

            #region button

            public VP<BtnDeleteUI.UIData> btnDelete;

            public VP<BtnCopyUI.UIData> btnCopy;

            public VP<BtnCutUI.UIData> btnCut;

            #endregion

            #region Constructor

            public enum Property
            {
                fileSystemBrowser,
                showUIData,

                btnDelete,
                btnCopy,
                btnCut
            }

            public UIData() : base()
            {
                this.fileSystemBrowser = new VP<ReferenceData<FileSystemBrowser>>(this, (byte)Property.fileSystemBrowser, new ReferenceData<FileSystemBrowser>(null));
                this.showUIData = new VP<Show.UIData>(this, (byte)Property.showUIData, null);
                // btn
                {
                    this.btnDelete = new VP<BtnDeleteUI.UIData>(this, (byte)Property.btnDelete, new BtnDeleteUI.UIData());
                    this.btnCopy = new VP<BtnCopyUI.UIData>(this, (byte)Property.btnCopy, new BtnCopyUI.UIData());
                    this.btnCut = new VP<BtnCutUI.UIData>(this, (byte)Property.btnCut, new BtnCutUI.UIData());
                }
            }

            #endregion

            public List<FileSystemInfo> getSelectedFiles()
            {
                List<FileSystemInfo> ret = new List<FileSystemInfo>();
                {
                    FileSystemBrowser fileSystemBrowser = this.fileSystemBrowser.v.data;
                    if (fileSystemBrowser != null)
                    {
                        Action action = fileSystemBrowser.action.v;
                        switch (action.getType())
                        {
                            case Action.Type.None:
                                {
                                    ActionNone actionNone = action as ActionNone;
                                    ret.AddRange(actionNone.selectFiles.vs);
                                }
                                break;
                            case Action.Type.Edit:
                                break;
                            default:
                                Debug.LogError("unknown type: " + action.getType());
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("fileSystemBrowser null");
                    }
                }
                return ret;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // btnDelete
                    if (!isProcess)
                    {
                        BtnDeleteUI.UIData btnDelete = this.btnDelete.v;
                        if (btnDelete != null)
                        {
                            isProcess = btnDelete.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("btnDelete null: " + this);
                        }
                    }
                    // btnCopy
                    if (!isProcess)
                    {
                        BtnCopyUI.UIData btnCopy = this.btnCopy.v;
                        if (btnCopy != null)
                        {
                            isProcess = btnCopy.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("btnCopy null: " + this);
                        }
                    }
                    // btnCut
                    if (!isProcess)
                    {
                        BtnCutUI.UIData btnCut = this.btnCut.v;
                        if (btnCut != null)
                        {
                            isProcess = btnCut.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("btnCut null: " + this);
                        }
                    }
                    // showUIData
                    if (!isProcess)
                    {
                        Show.UIData showUIData = this.showUIData.v;
                        if (showUIData != null)
                        {
                            isProcess = showUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("showUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public Transform btnActionScrollView;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FileSystemBrowser fileSystemBrowser = this.data.fileSystemBrowser.v.data;
                    if (fileSystemBrowser != null)
                    {
                        // show
                        {
                            Show show = fileSystemBrowser.show.v;
                            if (show != null)
                            {
                                switch (show.getType())
                                {
                                    case Show.Type.Single:
                                        {
                                            SingleShow singleShow = show as SingleShow;
                                            // Find
                                            SingleShowUI.UIData singleShowUIData = this.data.showUIData.newOrOld<SingleShowUI.UIData>();
                                            {
                                                singleShowUIData.singleShow.v = new ReferenceData<SingleShow>(singleShow);
                                            }
                                            this.data.showUIData.v = singleShowUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + show.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("show null: " + this);
                            }
                        }
                        // btn
                        {
                            // btnDelete
                            {
                                BtnDeleteUI.UIData btnDeleteUIData = this.data.btnDelete.v;
                                if (btnDeleteUIData != null)
                                {
                                    btnDeleteUIData.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(fileSystemBrowser);
                                }
                                else
                                {
                                    Debug.LogError("btnDeleteUIData null: " + this);
                                }
                            }
                            // btnCopy
                            {
                                BtnCopyUI.UIData btnCopyUIData = this.data.btnCopy.v;
                                if (btnCopyUIData != null)
                                {
                                    btnCopyUIData.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(fileSystemBrowser);
                                }
                                else
                                {
                                    Debug.LogError("btnCopyUIData null: " + this);
                                }
                            }
                            // btnCut
                            {
                                BtnCutUI.UIData btnCutUIData = this.data.btnCut.v;
                                if (btnCutUIData != null)
                                {
                                    btnCutUIData.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(fileSystemBrowser);
                                }
                                else
                                {
                                    Debug.LogError("btnCutUIData null: " + this);
                                }
                            }
                        }
                        // siblingIndex
                        {
                            if (btnActionScrollView != null)
                            {
                                btnActionScrollView.SetSiblingIndex(0);
                            }
                            else
                            {
                                Debug.LogError("btnActionScrollView null");
                            }
                            UIRectTransform.SetSiblingIndex(this.data.showUIData.v, 1);
                            if (btnDeleteConfirmContainer != null)
                            {
                                btnDeleteConfirmContainer.SetSiblingIndex(2);
                            }
                            else
                            {
                                Debug.LogError("btnDeleteConfirmContainer null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("fileSystemBrowser null: " + this);
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

        private static UIRectTransform CreateBtnRect(int index)
        {
            UIRectTransform uiRectTransform = new UIRectTransform();
            {
                float width = 80.0f;
                uiRectTransform.anchoredPosition = new Vector3(width * index, 0.0f, 0.0f);
                uiRectTransform.anchorMin = new Vector2(0.0f, 0.0f);
                uiRectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                uiRectTransform.pivot = new Vector2(0.0f, 0.5f);
                uiRectTransform.offsetMin = new Vector2(width * index, 0.0f);
                uiRectTransform.offsetMax = new Vector2(width * index + width, 0.0f);
                uiRectTransform.sizeDelta = new Vector2(width, 0.0f);
            }
            return uiRectTransform;
        }

        public SingleShowUI singleShowPrefab;
        private static readonly UIRectTransform showUIRect = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight, 0);

        public BtnDeleteUI btnDeletePrefab;
        public BtnCopyUI btnCopyPrefab;
        public BtnCutUI btnCutPrefab;
        public Transform btnActionContainer;

        public Transform btnDeleteConfirmContainer;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.fileSystemBrowser.allAddCallBack(this);
                    uiData.showUIData.allAddCallBack(this);
                    // btn
                    {
                        uiData.btnDelete.allAddCallBack(this);
                        uiData.btnCopy.allAddCallBack(this);
                        uiData.btnCut.allAddCallBack(this);
                    }
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is FileSystemBrowser)
                {
                    FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
                    // Update
                    {
                        UpdateUtils.makeUpdate<FileSystemBrowserUpdate, FileSystemBrowser>(fileSystemBrowser, this.transform);
                    }
                    dirty = true;
                    return;
                }
                if (data is Show.UIData)
                {
                    Show.UIData showUIData = data as Show.UIData;
                    // UI
                    {
                        switch (showUIData.getType())
                        {
                            case Show.Type.Single:
                                {
                                    SingleShowUI.UIData singleShowUIData = showUIData as SingleShowUI.UIData;
                                    UIUtils.Instantiate(singleShowUIData, singleShowPrefab, this.transform, showUIRect);
                                }
                                break;
                            default:
                                Debug.LogError("showUIData null: " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
                // btn
                {
                    if (data is BtnDeleteUI.UIData)
                    {
                        BtnDeleteUI.UIData btnDeleteUIData = data as BtnDeleteUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(btnDeleteUIData, btnDeletePrefab, btnActionContainer, CreateBtnRect(0));
                        }
                        dirty = true;
                        return;
                    }
                    if (data is BtnCopyUI.UIData)
                    {
                        BtnCopyUI.UIData btnCopyUIData = data as BtnCopyUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(btnCopyUIData, btnCopyPrefab, btnActionContainer, CreateBtnRect(1));
                        }
                        dirty = true;
                        return;
                    }
                    if (data is BtnCutUI.UIData)
                    {
                        BtnCutUI.UIData btnCutUIData = data as BtnCutUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(btnCutUIData, btnCutPrefab, btnActionContainer, CreateBtnRect(2));
                        }
                        dirty = true;
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.fileSystemBrowser.allRemoveCallBack(this);
                    uiData.showUIData.allRemoveCallBack(this);
                    // btn
                    {
                        uiData.btnDelete.allRemoveCallBack(this);
                        uiData.btnCopy.allRemoveCallBack(this);
                        uiData.btnCut.allRemoveCallBack(this);
                    }
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is FileSystemBrowser)
                {
                    FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
                    // Update
                    {
                        fileSystemBrowser.removeCallBackAndDestroy(typeof(FileSystemBrowserUpdate));
                    }
                    return;
                }
                if (data is Show.UIData)
                {
                    Show.UIData showUIData = data as Show.UIData;
                    // UI
                    {
                        switch (showUIData.getType())
                        {
                            case Show.Type.Single:
                                {
                                    SingleShowUI.UIData singleShowUIData = showUIData as SingleShowUI.UIData;
                                    singleShowUIData.removeCallBackAndDestroy(typeof(SingleShowUI));
                                }
                                break;
                            default:
                                Debug.LogError("showUIData null: " + this);
                                break;
                        }
                    }
                    return;
                }
                // btn
                {
                    if (data is BtnDeleteUI.UIData)
                    {
                        BtnDeleteUI.UIData btnDeleteUIData = data as BtnDeleteUI.UIData;
                        // UI
                        {
                            btnDeleteUIData.removeCallBackAndDestroy(typeof(BtnDeleteUI));
                        }
                        return;
                    }
                    if (data is BtnCopyUI.UIData)
                    {
                        BtnCopyUI.UIData btnCopyUIData = data as BtnCopyUI.UIData;
                        // UI
                        {
                            btnCopyUIData.removeCallBackAndDestroy(typeof(BtnCopyUI));
                        }
                        return;
                    }
                    if (data is BtnCutUI.UIData)
                    {
                        BtnCutUI.UIData btnCutUIData = data as BtnCutUI.UIData;
                        // UI
                        {
                            btnCutUIData.removeCallBackAndDestroy(typeof(BtnCutUI));
                        }
                        return;
                    }
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
                    case UIData.Property.fileSystemBrowser:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnDelete:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnCopy:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnCut:
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
            // Child
            {
                if (wrapProperty.p is FileSystemBrowser)
                {
                    switch ((FileSystemBrowser.Property)wrapProperty.n)
                    {
                        case FileSystemBrowser.Property.action:
                            dirty = true;
                            break;
                        case FileSystemBrowser.Property.show:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is Show.UIData)
                {
                    return;
                }
                // btn
                {
                    if (wrapProperty.p is BtnDeleteUI.UIData)
                    {
                        return;
                    }
                    if (wrapProperty.p is BtnCopyUI.UIData)
                    {
                        return;
                    }
                    if (wrapProperty.p is BtnCutUI.UIData)
                    {
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}