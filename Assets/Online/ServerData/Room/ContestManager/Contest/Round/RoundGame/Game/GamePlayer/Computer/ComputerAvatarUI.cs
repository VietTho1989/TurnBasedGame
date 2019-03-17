using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ComputerAvatarUI : UIBehavior<ComputerAvatarUI.UIData>
{

    #region UIData

    public class UIData : InformAvatarUI.UIData.Sub
    {

        public VP<ReferenceData<Computer>> computer;

        #region Constructor

        public enum Property
        {
            computer
        }

        public UIData() : base()
        {
            this.computer = new VP<ReferenceData<Computer>>(this, (byte)Property.computer, new ReferenceData<Computer>(null));
        }

        #endregion

        public override GamePlayer.Inform.Type getType()
        {
            return GamePlayer.Inform.Type.Computer;
        }

    }

    #endregion

    #region Refresh

    public UrlImage ivAvatar;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Computer computer = this.data.computer.v.data;
                if (computer != null)
                {
                    // Avatar
                    if (ivAvatar != null)
                    {
                        ivAvatar.setUrl(computer.avatarUrl.v, "loading", "computer");
                    }
                    else
                    {
                        Debug.LogError("ivAvatar null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("computer null: " + this);
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
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
                uiData.computer.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is Computer)
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
                uiData.computer.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is Computer)
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
                case UIData.Property.computer:
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
        if (wrapProperty.p is Computer)
        {
            switch ((Computer.Property)wrapProperty.n)
            {
                case Computer.Property.computerName:
                    break;
                case Computer.Property.avatarUrl:
                    dirty = true;
                    break;
                case Computer.Property.ai:
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