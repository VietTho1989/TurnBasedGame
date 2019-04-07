using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoomStateEndUI : UIBehavior<RoomStateEndUI.UIData>
{

    #region UIData

    public class UIData : RoomStateUI.UIData.Sub
    {

        public VP<ReferenceData<RoomStateEnd>> roomStateEnd;

        #region Constructor

        public enum Property
        {
            roomStateEnd
        }

        public UIData() : base()
        {
            this.roomStateEnd = new VP<ReferenceData<RoomStateEnd>>(this, (byte)Property.roomStateEnd, new ReferenceData<RoomStateEnd>(null));
        }

        #endregion

        public override Room.State.Type getType()
        {
            return Room.State.Type.End;
        }

    }

    #endregion

    #region txt

    public Text lbMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Room Already End");

    static RoomStateEndUI()
    {
        txtMessage.add(Language.Type.vi, "Phòng đã kết thúc");
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
                RoomStateEnd roomStateEnd = this.data.roomStateEnd.v.data;
                if (roomStateEnd != null)
                {

                }
                else
                {
                    Debug.LogError("roomStateEnd null: " + this);
                }
                // txt
                {
                    if (lbMessage != null)
                    {
                        lbMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("lbMessage null: " + this);
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
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.roomStateEnd.allAddCallBack(this);
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
        if (data is RoomStateEnd)
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
                uiData.roomStateEnd.allRemoveCallBack(this);
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
        if (data is RoomStateEnd)
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
                case UIData.Property.roomStateEnd:
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
        if (wrapProperty.p is RoomStateEnd)
        {
            switch ((RoomStateEnd.Property)wrapProperty.n)
            {
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