using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class BtnBackWardUI : UIBehavior<BtnBackWardUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<DirectoryHistory>> directoryHistory;

            #region Constructor

            public enum Property
            {
                directoryHistory
            }

            public UIData() : base()
            {
                this.directoryHistory = new VP<ReferenceData<DirectoryHistory>>(this, (byte)Property.directoryHistory, new ReferenceData<DirectoryHistory>(null));
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnBackWardUI btnBackWardUI = this.findCallBack<BtnBackWardUI>();
                            if (btnBackWardUI != null)
                            {
                                isProcess = btnBackWardUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnBackWardUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        public Button btnBackWard;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    DirectoryHistory directoryHistory = this.data.directoryHistory.v.data;
                    if (directoryHistory != null)
                    {
                        if (btnBackWard != null)
                        {
                            if (directoryHistory.position.v < 0)
                            {
                                btnBackWard.interactable = false;
                            }
                            else
                            {
                                btnBackWard.interactable = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("btnBackWard, tvBackWard null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("directoryHistory null: " + this);
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
                // Child
                {
                    uiData.directoryHistory.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is DirectoryHistory)
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
                // Child
                {
                    uiData.directoryHistory.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is DirectoryHistory)
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
                    case UIData.Property.directoryHistory:
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
            if (wrapProperty.p is DirectoryHistory)
            {
                switch ((DirectoryHistory.Property)wrapProperty.n)
                {
                    case DirectoryHistory.Property.isActive:
                        break;
                    case DirectoryHistory.Property.history:
                        dirty = true;
                        break;
                    case DirectoryHistory.Property.position:
                        dirty = true;
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
        public void onClickBtnBackWard()
        {
            if (this.data != null)
            {
                DirectoryHistory directoryHistory = this.data.directoryHistory.v.data;
                if (directoryHistory != null)
                {
                    directoryHistory.processUndoRedo(DirectoryHistory.Operation.Undo);
                }
                else
                {
                    Debug.LogError("directoryHistory null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}