using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomUserListUI : UIBehavior<RoomUserListUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ContestManagerStatePlay>> play;

        public VP<RoomUserAdapter.UIData> roomUserAdapter;

        public VP<RoomUserInformUI.UIData> userInformUIData;

        #region Constructor

        public enum Property
        {
            play,
            roomUserAdapter,
            userInformUIData
        }

        public UIData() : base()
        {
            this.play = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.play, new ReferenceData<ContestManagerStatePlay>(null));
            // roomUserAdapter
            {
                this.roomUserAdapter = new VP<RoomUserAdapter.UIData>(this, (byte)Property.roomUserAdapter, new RoomUserAdapter.UIData());
                this.roomUserAdapter.v.type.v = RoomUserAdapter.UIData.Type.Play;
            }
            this.userInformUIData = new VP<RoomUserInformUI.UIData>(this, (byte)Property.userInformUIData, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // userInformUIData
                if (!isProcess)
                {
                    RoomUserInformUI.UIData userInformUIData = this.userInformUIData.v;
                    if (userInformUIData != null)
                    {
                        isProcess = userInformUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("userInformUIData null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        RoomUserListUI roomUserListUI = this.findCallBack<RoomUserListUI>();
                        if (roomUserListUI != null)
                        {
                            roomUserListUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("roomUserListUI null");
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Room User List");

    static RoomUserListUI()
    {
        txtTitle.add(Language.Type.vi, "Danh Sách Người Trong Phòng");
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
                ContestManagerStatePlay play = this.data.play.v.data;
                if (play != null)
                {
                    // roomUserAdapter
                    {
                        RoomUserAdapter.UIData roomUserAdapterUIData = this.data.roomUserAdapter.v;
                        if (roomUserAdapterUIData != null)
                        {
                            // find
                            Room room = play.findDataInParent<Room>();
                            // set
                            roomUserAdapterUIData.room.v = new ReferenceData<Room>(room);
                        }
                        else
                        {
                            Debug.LogError("roomUserAdapterUIData null");
                        }
                    }
                    // siblingIndex
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.transform.SetSiblingIndex(0);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (btnBack != null)
                        {
                            btnBack.transform.SetSiblingIndex(1);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                        UIRectTransform.SetSiblingIndex(this.data.roomUserAdapter.v, 2);
                        UIRectTransform.SetSiblingIndex(this.data.userInformUIData.v, 3);
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        float deltaY = 0;
                        // header
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            deltaY += buttonSize;
                        }
                        // adapter
                        deltaY += UIRectTransform.SetPosY(this.data.roomUserAdapter.v, deltaY);
                        // set
                        {
                            UIRectTransform rect = UIRectTransform.CreateCenterRect(400, deltaY, 0, 30);
                            rect.set((RectTransform)this.transform);
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
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("play null");
                }
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

    public RoomUserAdapter roomUserAdapterPrefab;
    private static readonly UIRectTransform roomUserAdapterRect = UIRectTransform.CreateTopBottomRect(370);

    public RoomUserInformUI roomUserInformPrefab;
    private static readonly UIRectTransform roomUserInformRect = UIConstants.FullParent;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.roomUserAdapter.allAddCallBack(this);
                uiData.userInformUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is RoomUserAdapter.UIData)
            {
                RoomUserAdapter.UIData roomUserAdapterUIData = data as RoomUserAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(roomUserAdapterUIData, roomUserAdapterPrefab, this.transform, roomUserAdapterRect);
                }
                dirty = true;
                return;
            }
            if(data is RoomUserInformUI.UIData)
            {
                RoomUserInformUI.UIData roomUserInformUIData = data as RoomUserInformUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(roomUserInformUIData, roomUserInformPrefab, this.transform, roomUserInformRect);
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
                uiData.roomUserAdapter.allRemoveCallBack(this);
                uiData.userInformUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        {
            if (data is RoomUserAdapter.UIData)
            {
                RoomUserAdapter.UIData roomUserAdapterUIData = data as RoomUserAdapter.UIData;
                // UI
                {
                    roomUserAdapterUIData.removeCallBackAndDestroy(typeof(RoomUserAdapter));
                }
                return;
            }
            if (data is RoomUserInformUI.UIData)
            {
                RoomUserInformUI.UIData roomUserInformUIData = data as RoomUserInformUI.UIData;
                // UI
                {
                    roomUserInformUIData.removeCallBackAndDestroy(typeof(RoomUserInformUI));
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
                case UIData.Property.play:
                    dirty = true;
                    break;
                case UIData.Property.roomUserAdapter:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.userInformUIData:
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
        if(wrapProperty.p is Setting)
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
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is RoomUserAdapter.UIData)
            {
                return;
            }
            if (wrapProperty.p is RoomUserInformUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            ContestManagerStatePlayUI.UIData contestManagerStatePlayUIData = this.data.findDataInParent<ContestManagerStatePlayUI.UIData>();
            if (contestManagerStatePlayUIData != null)
            {
                contestManagerStatePlayUIData.roomUserListUIData.v = null;
            }
            else
            {
                Debug.LogError("contestManagerStatePlayUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}