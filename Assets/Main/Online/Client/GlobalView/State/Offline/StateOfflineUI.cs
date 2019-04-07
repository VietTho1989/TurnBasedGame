using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StateOfflineUI : UIBehavior<StateOfflineUI.UIData>
{

    #region UIData

    public class UIData : GlobalStateUI.UIData.Sub
    {

        public VP<ReferenceData<Server.State.Offline>> offline;

        #region Constructor

        public enum Property
        {
            offline
        }

        public UIData() : base()
        {
            this.offline = new VP<ReferenceData<Server.State.Offline>>(this, (byte)Property.offline, new ReferenceData<Server.State.Offline>(null));
        }

        #endregion

        public override Server.State.Type getType()
        {
            return Server.State.Type.Offline;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text tvOffline;
    public static readonly TxtLanguage txtOffline = new TxtLanguage("Offline");

    static StateOfflineUI()
    {
        txtOffline.add(Language.Type.vi, "Không có mạng");
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
                Server.State.Offline offline = this.data.offline.v.data;
                if (offline != null)
                {
                    // txt
                    {
                        if (tvOffline != null)
                        {
                            tvOffline.text = txtOffline.get();
                        }
                        else
                        {
                            Debug.LogError("tvOffline null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("offline null: " + this);
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
                uiData.offline.allAddCallBack(this);
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
        if (data is Server.State.Offline)
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
                uiData.offline.allRemoveCallBack(this);
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
        if (data is Server.State.Offline)
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
                case UIData.Property.offline:
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
        if (wrapProperty.p is Server.State.Offline)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}