using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class ContestManagerBtnRoomUserUI : UIBehavior<ContestManagerBtnRoomUserUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

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
                        ContestManagerBtnRoomUserUI contestManagerBtnRoomUserUI = this.findCallBack<ContestManagerBtnRoomUserUI>();
                        if (contestManagerBtnRoomUserUI != null)
                        {
                            isProcess = contestManagerBtnRoomUserUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("contestManagerBtnChatUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

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

            }
            else
            {
                Debug.LogError("data null");
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
        if(data is UIData)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            this.setDataNull(uiData);
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
        if(wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
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

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.R:
                        {
                            if (btnRoomUser != null && btnRoomUser.gameObject.activeInHierarchy && btnRoomUser.interactable)
                            {
                                this.onClickBtnRoomUser();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnRoomUser;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRoomUser()
    {
        if (this.data != null)
        {
            ContestManagerUI.UIData contestManagerUIData = this.data.findDataInParent<ContestManagerUI.UIData>();
            if (contestManagerUIData != null)
            {
                ContestManagerUI.UIData.Sub sub = contestManagerUIData.sub.v;
                if (sub != null)
                {
                    if(sub.getType()== ContestManager.State.Type.Play)
                    {
                        ContestManagerStatePlayUI.UIData contestManagerStatePlayUIData = sub as ContestManagerStatePlayUI.UIData;
                        // make UI
                        if (contestManagerStatePlayUIData.roomUserListUIData.v == null)
                        {
                            RoomUserListUI.UIData roomUserListUIData = new RoomUserListUI.UIData();
                            {
                                roomUserListUIData.uid = contestManagerStatePlayUIData.roomUserListUIData.makeId();
                            }
                            contestManagerStatePlayUIData.roomUserListUIData.v = roomUserListUIData;
                        }
                        else
                        {
                            contestManagerStatePlayUIData.roomUserListUIData.v = null;
                        }
                    }
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            else
            {
                Debug.LogError("contestManagerUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}