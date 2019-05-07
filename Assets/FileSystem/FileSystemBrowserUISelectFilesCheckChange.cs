using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class FileSystemBrowserUISelectFilesCheckChange<K> : Data, ValueChangeCallBack where K : Data
    {

        public VP<int> change;

        private void notifyChange()
        {
            this.change.v = this.change.v + 1;
        }

        #region Constructor

        public enum Property
        {
            change
        }

        public FileSystemBrowserUISelectFilesCheckChange() : base()
        {
            this.change = new VP<int>(this, (byte)Property.change, 0);
        }

        #endregion

        public K data;

        public void setData(K newData)
        {
            if (this.data != newData)
            {
                // remove old
                {
                    DataUtils.removeParentCallBack(this.data, this, ref this.fileSystemBrowserUIData);
                }
                // set new 
                {
                    this.data = newData;
                    DataUtils.addParentCallBack(this.data, this, ref this.fileSystemBrowserUIData);
                }
            }
            else
            {
                Debug.LogError("the same: " + this + ", " + data + ", " + newData);
            }
        }

        #region implement callBacks

        private FileSystemBrowserUI.UIData fileSystemBrowserUIData = null;

        public void onAddCallBack<T>(T data) where T : Data
        {
            if (data is FileSystemBrowserUI.UIData)
            {
                FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                // Child
                {
                    fileSystemBrowserUIData.fileSystemBrowser.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            // Child
            {
                if(data is FileSystemBrowser)
                {
                    FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
                    // Child
                    {
                        fileSystemBrowser.action.allAddCallBack(this);
                    }
                    this.notifyChange();
                    return;
                }
                // Child
                if(data is Action)
                {
                    this.notifyChange();
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
        {
            if (data is FileSystemBrowserUI.UIData)
            {
                FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
                // Child
                {
                    fileSystemBrowserUIData.fileSystemBrowser.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is FileSystemBrowser)
                {
                    FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
                    // Child
                    {
                        fileSystemBrowser.action.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Action)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is FileSystemBrowserUI.UIData)
            {
                switch ((FileSystemBrowserUI.UIData.Property)wrapProperty.n)
                {
                    case FileSystemBrowserUI.UIData.Property.fileSystemBrowser:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case FileSystemBrowserUI.UIData.Property.showUIData:
                        break;
                    case FileSystemBrowserUI.UIData.Property.btnDelete:
                        break;
                    case FileSystemBrowserUI.UIData.Property.btnCopy:
                        break;
                    case FileSystemBrowserUI.UIData.Property.btnCut:
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
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                this.notifyChange();
                            }
                            break;
                        case FileSystemBrowser.Property.show:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Action)
                {
                    Action action = wrapProperty.p as Action;
                    switch (action.getType())
                    {
                        case Action.Type.None:
                            {
                                switch ((ActionNone.Property)wrapProperty.n)
                                {
                                    case ActionNone.Property.state:
                                        break;
                                    case ActionNone.Property.selectFiles:
                                        this.notifyChange();
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case Action.Type.Edit:
                            break;
                        default:
                            Debug.LogError("unknown type: " + action.getType());
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        #endregion

    }
}