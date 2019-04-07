using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContestManagerBtnChatUI : UIBehavior<ContestManagerBtnChatUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region visibility

        public enum Visibility
        {
            Show,
            Hide
        }

        private static readonly TxtLanguage txtShow = new TxtLanguage("Show");
        private static readonly TxtLanguage txtHide = new TxtLanguage("Hide");

        public static List<string> GetStrVisibility()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtShow.get());
                ret.Add(txtHide.get());
            }
            return ret;
        }

        public VP<Visibility> visibility;

        #endregion

        #region style

        public enum Style
        {
            Overlay,
            Full,
            Push
        }

        private static readonly TxtLanguage txtOverlay = new TxtLanguage("Overlay");
        private static readonly TxtLanguage txtFull = new TxtLanguage("By Side");
        private static readonly TxtLanguage txtPush = new TxtLanguage("Push");

        public static List<string> GetStrStyles()
        {
            List<string> ret = new List<string>();
            {
                ret.Add(txtOverlay.get());
                ret.Add(txtFull.get());
                ret.Add(txtPush.get());
            }
            return ret;
        }

        static UIData()
        {
            // visibility
            {
                txtShow.add(Language.Type.vi, "Hiện");
                txtHide.add(Language.Type.vi, "Ẩn");
            }
            // style
            {
                txtOverlay.add(Language.Type.vi, "Đặt Lên");
                txtFull.add(Language.Type.vi, "Ngay Cạnh");
                txtPush.add(Language.Type.vi, "Đẩy");
            }
        }

        public VP<Style> style;

        #endregion

        public VP<ChatRoomNewMessageCountUI.UIData> newMessageCountUIData;

        #region Constructor

        public enum Property
        {
            visibility,
            style,
            newMessageCountUIData
        }

        public UIData() : base()
        {
            this.visibility = new VP<Visibility>(this, (byte)Property.visibility, Setting.get().defaultChatRoomStyle.v.getVisibility());
            this.style = new VP<Style>(this, (byte)Property.style, Setting.get().defaultChatRoomStyle.v.getStyle());
            this.newMessageCountUIData = new VP<ChatRoomNewMessageCountUI.UIData>(this, (byte)Property.newMessageCountUIData, new ChatRoomNewMessageCountUI.UIData());
            // Debug.LogWarning("btnChat constructor: " + this.visibility.v + ", " + this.style.v);
        }

        #endregion

    }

    #endregion

    static ContestManagerBtnChatUI()
    {
        // rect
        {
            // newMessageCountRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-15.0, -15.0); offsetMax: (0.0, 0.0); sizeDelta: (15.0, 15.0);
                newMessageCountRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                newMessageCountRect.anchorMin = new Vector2(1.0f, 1.0f);
                newMessageCountRect.anchorMax = new Vector2(1.0f, 1.0f);
                newMessageCountRect.pivot = new Vector2(1.0f, 1.0f);
                newMessageCountRect.offsetMin = new Vector2(-15.0f, -15.0f);
                newMessageCountRect.offsetMax = new Vector2(0.0f, 0.0f);
                newMessageCountRect.sizeDelta = new Vector2(15.0f, 15.0f);
            }
        }
    }

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // newMessageCountUIData
                {
                    ChatRoomNewMessageCountUI.UIData newMessageCountUIData = this.data.newMessageCountUIData.v;
                    if (newMessageCountUIData != null)
                    {
                        // find
                        ChatRoom chatRoom = null;
                        {
                            RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                            if (roomUIData != null)
                            {
                                Room room = roomUIData.room.v.data;
                                if (room != null)
                                {
                                    chatRoom = room.chatRoom.v;
                                }
                                else
                                {
                                    Debug.LogError("room null");
                                }
                            }
                            else
                            {
                                Debug.LogError("roomUIData null");
                            }
                        }
                        // set
                        newMessageCountUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                    }
                    else
                    {
                        Debug.LogError("newMessageCountUIData null");
                    }
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

    public ChatRoomNewMessageCountUI newMessageCountPrefab;
    private static readonly UIRectTransform newMessageCountRect = new UIRectTransform();

    private RoomUI.UIData roomUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.roomUIData);
            }
            // Child
            {
                uiData.newMessageCountUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if(data is RoomUI.UIData)
            {
                RoomUI.UIData roomUIData = data as RoomUI.UIData;
                // Child
                {
                    roomUIData.room.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is Room)
            {
                dirty = true;
                return;
            }
        }
        // Child
        if(data is ChatRoomNewMessageCountUI.UIData)
        {
            ChatRoomNewMessageCountUI.UIData newMessageCountUIData = data as ChatRoomNewMessageCountUI.UIData;
            // UI
            {
                UIUtils.Instantiate(newMessageCountUIData, newMessageCountPrefab, this.transform, newMessageCountRect);
            }
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.roomUIData);
            }
            // Child
            {
                uiData.newMessageCountUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
        }
        // Parent
        {
            if (data is RoomUI.UIData)
            {
                RoomUI.UIData roomUIData = data as RoomUI.UIData;
                // Child
                {
                    roomUIData.room.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is Room)
            {
                return;
            }
        }
        // Child
        if (data is ChatRoomNewMessageCountUI.UIData)
        {
            ChatRoomNewMessageCountUI.UIData newMessageCountUIData = data as ChatRoomNewMessageCountUI.UIData;
            // UI
            {
                newMessageCountUIData.removeCallBackAndDestroy(typeof(ChatRoomNewMessageCountUI));
            }
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
                case UIData.Property.visibility:
                    dirty = true;
                    break;
                case UIData.Property.style:
                    dirty = true;
                    break;
                case UIData.Property.newMessageCountUIData:
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
        // Parent
        {
            if (wrapProperty.p is RoomUI.UIData)
            {
                switch ((RoomUI.UIData.Property)wrapProperty.n)
                {
                    case RoomUI.UIData.Property.room:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case RoomUI.UIData.Property.roomBtnUIData:
                        break;
                    case RoomUI.UIData.Property.contestManagerUIData:
                        break;
                    case RoomUI.UIData.Property.requestNewContestManagerUIData:
                        break;
                    case RoomUI.UIData.Property.chooseContestManagerUIData:
                        break;
                    case RoomUI.UIData.Property.roomUserInformUI:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is Room)
            {
                switch ((Room.Property)wrapProperty.n)
                {
                    case Room.Property.roomInform:
                        break;
                    case Room.Property.changeRights:
                        break;
                    case Room.Property.name:
                        break;
                    case Room.Property.password:
                        break;
                    case Room.Property.users:
                        break;
                    case Room.Property.state:
                        break;
                    case Room.Property.requestNewContestManager:
                        break;
                    case Room.Property.contestManagers:
                        break;
                    case Room.Property.timeCreated:
                        break;
                    case Room.Property.chatRoom:
                        dirty = true;
                        break;
                    case Room.Property.allowHint:
                        break;
                    case Room.Property.allowLoadHistory:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        // Child
        if (wrapProperty.p is ChatRoomNewMessageCountUI.UIData)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnChat()
    {
        if (this.data != null)
        {
            switch (this.data.visibility.v)
            {
                case UIData.Visibility.Show:
                    this.data.visibility.v = UIData.Visibility.Hide;
                    break;
                case UIData.Visibility.Hide:
                    this.data.visibility.v = UIData.Visibility.Show;
                    break;
                default:
                    Debug.LogError("unknown visibility: " + this.data.visibility.v);
                    break;
            }
            Setting.get().defaultChatRoomStyle.v.setLastVisibility(this.data.visibility.v);
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}