using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestManagerUI : UIHaveTransformDataBehavior<ContestManagerUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ContestManager>> contestManager;

            #region Sub

            public abstract class Sub : Data
            {

                public abstract ContestManager.State.Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            public VP<ContestManagerBtnUI.UIData> btns;

            public VP<RoomChatUI.UIData> roomChat;

            #region Constructor

            public enum Property
            {
                contestManager,
                sub,
                btns,
                roomChat
            }

            public UIData() : base()
            {
                this.contestManager = new VP<ReferenceData<ContestManager>>(this, (byte)Property.contestManager, new ReferenceData<ContestManager>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
                this.btns = new VP<ContestManagerBtnUI.UIData>(this, (byte)Property.btns, new ContestManagerBtnUI.UIData());
                this.roomChat = new VP<RoomChatUI.UIData>(this, (byte)Property.roomChat, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                // Debug.LogError ("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    // roomChat
                    if (!isProcess)
                    {
                        RoomChatUI.UIData roomChat = this.roomChat.v;
                        if (roomChat != null)
                        {
                            isProcess = roomChat.processEvent(e);
                        }
                        else
                        {
                            // Debug.LogError("roomChat null");
                        }
                    }
                    // sub
                    if (!isProcess)
                    {
                        Sub sub = this.sub.v;
                        if (sub != null)
                        {
                            isProcess = sub.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("sub null: " + this);
                        }
                    }
                }
                return isProcess;
            }

            public void reset()
            {

            }

        }

        #endregion

        #region txt, rect

        private const float PortraitChatHeight = 180;
        private const float LandscapeChatWidth = 240;

        private static readonly UIRectTransform roomChatPortraitRect = new UIRectTransform();
        private static readonly UIRectTransform roomChatLandscapeRect = new UIRectTransform();

        static ContestManagerUI()
        {
            // btnRect
            {
                // anchoredPosition: (0.0, 30.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                // offsetMin: (-90.0, 0.0); offsetMax: (0.0, 30.0); sizeDelta: (90.0, 30.0);
                btnRect.anchoredPosition = new Vector3(0.0f, 30.0f, 0.0f);
                btnRect.anchorMin = new Vector2(1.0f, 1.0f);
                btnRect.anchorMax = new Vector2(1.0f, 1.0f);
                btnRect.pivot = new Vector2(1.0f, 1.0f);
                btnRect.offsetMin = new Vector2(-90.0f, 0.0f);
                btnRect.offsetMax = new Vector2(0.0f, 30.0f);
                btnRect.sizeDelta = new Vector2(90.0f, 30.0f);
            }
            // roomChat
            {
                // portrait
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 0.0); pivot: (0.5, 0.0);
                    // offsetMin: (0.0, 0.0); offsetMax: (0.0, 120.0); sizeDelta: (0.0, 120.0);
                    roomChatPortraitRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    roomChatPortraitRect.anchorMin = new Vector2(0.0f, 0.0f);
                    roomChatPortraitRect.anchorMax = new Vector2(1.0f, 0.0f);
                    roomChatPortraitRect.pivot = new Vector2(0.5f, 0.0f);
                    roomChatPortraitRect.offsetMin = new Vector2(0.0f, 0.0f);
                    roomChatPortraitRect.offsetMax = new Vector2(0.0f, PortraitChatHeight);
                    roomChatPortraitRect.sizeDelta = new Vector2(0.0f, PortraitChatHeight);
                }
                // landscape
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 0.0); anchorMax: (1.0, 1.0); pivot: (1.0, 0.5);
                    // offsetMin: (-160.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (160.0, 0.0);
                    roomChatLandscapeRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    roomChatLandscapeRect.anchorMin = new Vector2(1.0f, 0.0f);
                    roomChatLandscapeRect.anchorMax = new Vector2(1.0f, 1.0f);
                    roomChatLandscapeRect.pivot = new Vector2(1.0f, 0.5f);
                    roomChatLandscapeRect.offsetMin = new Vector2(-LandscapeChatWidth, 0.0f);
                    roomChatLandscapeRect.offsetMax = new Vector2(0.0f, 0.0f);
                    roomChatLandscapeRect.sizeDelta = new Vector2(LandscapeChatWidth, 0.0f);
                }
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
                    ContestManager contestManager = this.data.contestManager.v.data;
                    if (contestManager != null)
                    {
                        // sub
                        {
                            ContestManager.State state = contestManager.state.v;
                            if (state != null)
                            {
                                switch (state.getType())
                                {
                                    case ContestManager.State.Type.Lobby:
                                        {
                                            ContestManagerStateLobby lobby = state as ContestManagerStateLobby;
                                            // UIData
                                            ContestManagerStateLobbyUI.UIData lobbyUIData = this.data.sub.newOrOld<ContestManagerStateLobbyUI.UIData>();
                                            {
                                                lobbyUIData.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby>(lobby);
                                            }
                                            this.data.sub.v = lobbyUIData;
                                        }
                                        break;
                                    case ContestManager.State.Type.Play:
                                        {
                                            ContestManagerStatePlay play = state as ContestManagerStatePlay;
                                            // UIData
                                            ContestManagerStatePlayUI.UIData playUIData = this.data.sub.newOrOld<ContestManagerStatePlayUI.UIData>();
                                            {
                                                playUIData.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay>(play);
                                            }
                                            this.data.sub.v = playUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("state null: " + this);
                            }
                        }
                        // UI
                        {
                            UIData.Sub sub = this.data.sub.v;
                            if (sub != null)
                            {
                                switch (sub.getType())
                                {
                                    case ContestManager.State.Type.Lobby:
                                        {
                                            // sub
                                            UIRectTransform fullScreenRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);
                                            UIRectTransform.Set(sub, fullScreenRect);
                                            // chat
                                            this.data.roomChat.v = null;
                                        }
                                        break;
                                    case ContestManager.State.Type.Play:
                                        {
                                            // find
                                            bool isPortrait = true;
                                            {
                                                RectTransform rectTransform = (RectTransform)this.transform;
                                                if (rectTransform != null)
                                                {
                                                    if (rectTransform.rect.height >= rectTransform.rect.width)
                                                    {
                                                        isPortrait = true;
                                                    }
                                                    else
                                                    {
                                                        isPortrait = false;
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("rectTransform null");
                                                }
                                            }
                                            // sub
                                            {
                                                // find
                                                ContestManagerBtnChatUI.UIData.Visibility visibility = ContestManagerBtnChatUI.UIData.Visibility.Hide;
                                                ContestManagerBtnChatUI.UIData.Style style = ContestManagerBtnChatUI.UIData.Style.Overlay;
                                                {
                                                    ContestManagerBtnUI.UIData btns = this.data.btns.v;
                                                    if (btns != null)
                                                    {
                                                        ContestManagerBtnChatUI.UIData btnChat = btns.btnChat.v;
                                                        if (btnChat != null)
                                                        {
                                                            visibility = btnChat.visibility.v;
                                                            style = btnChat.style.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("btnChat null");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("btns null");
                                                    }
                                                }
                                                // process
                                                {
                                                    switch (visibility)
                                                    {
                                                        case ContestManagerBtnChatUI.UIData.Visibility.Hide:
                                                            {
                                                                UIRectTransform fullScreenRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);
                                                                UIRectTransform.Set(sub, fullScreenRect);
                                                            }
                                                            break;
                                                        case ContestManagerBtnChatUI.UIData.Visibility.Show:
                                                            {
                                                                switch (style)
                                                                {
                                                                    case ContestManagerBtnChatUI.UIData.Style.Overlay:
                                                                        {
                                                                            UIRectTransform fullScreenRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);
                                                                            UIRectTransform.Set(sub, fullScreenRect);
                                                                        }
                                                                        break;
                                                                    case ContestManagerBtnChatUI.UIData.Style.Full:
                                                                        {
                                                                            if (isPortrait)
                                                                            {
                                                                                UIRectTransform subHaveChatRect = UIRectTransform.CreateFullRect(0, 0, 0, PortraitChatHeight);
                                                                                UIRectTransform.Set(sub, subHaveChatRect);
                                                                            }
                                                                            else
                                                                            {
                                                                                UIRectTransform subHaveChatRect = UIRectTransform.CreateFullRect(0, LandscapeChatWidth, 0, 0);
                                                                                UIRectTransform.Set(sub, subHaveChatRect);
                                                                            }
                                                                        }
                                                                        break;
                                                                    case ContestManagerBtnChatUI.UIData.Style.Push:
                                                                        {
                                                                            if (isPortrait)
                                                                            {
                                                                                UIRectTransform subHaveChatRect = UIRectTransform.CreateFullRect(0, 0, 0, PortraitChatHeight);
                                                                                UIRectTransform.Set(sub, subHaveChatRect);
                                                                            }
                                                                            else
                                                                            {
                                                                                UIRectTransform subHaveChatRect = UIRectTransform.CreateFullRect(-LandscapeChatWidth, LandscapeChatWidth, 0, 0);
                                                                                UIRectTransform.Set(sub, subHaveChatRect);
                                                                            }
                                                                        }
                                                                        break;
                                                                    default:
                                                                        Debug.LogError("unknown style: " + style);
                                                                        break;
                                                                }
                                                            }
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown visibility: " + visibility);
                                                            break;
                                                    }
                                                }
                                            }
                                            // chat
                                            {
                                                // find
                                                ContestManagerBtnChatUI.UIData.Visibility visibility = ContestManagerBtnChatUI.UIData.Visibility.Hide;
                                                ContestManagerBtnChatUI.UIData.Style style = ContestManagerBtnChatUI.UIData.Style.Overlay;
                                                {
                                                    ContestManagerBtnUI.UIData btns = this.data.btns.v;
                                                    if (btns != null)
                                                    {
                                                        ContestManagerBtnChatUI.UIData btnChat = btns.btnChat.v;
                                                        if (btnChat != null)
                                                        {
                                                            visibility = btnChat.visibility.v;
                                                            style = btnChat.style.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("btnChat null");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("btns null");
                                                    }
                                                }
                                                // process
                                                switch (visibility)
                                                {
                                                    case ContestManagerBtnChatUI.UIData.Visibility.Hide:
                                                        this.data.roomChat.v = null;
                                                        break;
                                                    case ContestManagerBtnChatUI.UIData.Visibility.Show:
                                                        {
                                                            // make UI
                                                            {
                                                                RoomChatUI.UIData roomChatUIData = this.data.roomChat.newOrOld<RoomChatUI.UIData>();
                                                                {

                                                                }
                                                                this.data.roomChat.v = roomChatUIData;
                                                            }
                                                            // UI Transform
                                                            {
                                                                if (isPortrait)
                                                                {
                                                                    UIRectTransform.Set(this.data.roomChat.v, roomChatPortraitRect);
                                                                }
                                                                else
                                                                {
                                                                    UIRectTransform.Set(this.data.roomChat.v, roomChatLandscapeRect);
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown visiblity: " + visibility);
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + sub.getType());
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("sub null");
                            }
                        }
                        // siblingIndex
                        {
                            UIRectTransform.SetSiblingIndex(this.data.btns.v, 0);
                            UIRectTransform.SetSiblingIndex(this.data.sub.v, 1);
                            UIRectTransform.SetSiblingIndex(this.data.roomChat.v, 2);
                        }
                        // UI
                        {
                            float buttonSize = Setting.get().buttonSize.v;
                            // btn
                            {
                                {
                                    btnRect.anchoredPosition = new Vector3(0.0f, buttonSize, 0.0f);
                                    btnRect.offsetMin = new Vector2(-3 * buttonSize, 0.0f);
                                    btnRect.offsetMax = new Vector2(0.0f, buttonSize);
                                    btnRect.sizeDelta = new Vector2(3 * buttonSize, buttonSize);
                                }
                                UIRectTransform.Set(this.data.btns.v, btnRect);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManager null");
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

        public ContestManagerStateLobbyUI lobbyPrefab;
        public ContestManagerStatePlayUI playPrefab;
        private static readonly UIRectTransform subRect = UIConstants.FullParent;

        public ContestManagerBtnUI btnPrefab;
        private static readonly UIRectTransform btnRect = new UIRectTransform();

        public RoomChatUI roomChatPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.contestManager.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                    uiData.btns.allAddCallBack(this);
                    uiData.roomChat.allAddCallBack(this);
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
                if (data is ContestManager)
                {
                    // reset
                    {
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null");
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // reset
                    {
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null");
                        }
                    }
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                {
                                    ContestManagerStateLobbyUI.UIData lobbyUIData = sub as ContestManagerStateLobbyUI.UIData;
                                    UIUtils.Instantiate(lobbyUIData, lobbyPrefab, this.transform, subRect);
                                }
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    ContestManagerStatePlayUI.UIData playUIData = sub as ContestManagerStatePlayUI.UIData;
                                    UIUtils.Instantiate(playUIData, playPrefab, this.transform, subRect);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
                // btn
                {
                    if (data is ContestManagerBtnUI.UIData)
                    {
                        ContestManagerBtnUI.UIData btnUIData = data as ContestManagerBtnUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(btnUIData, btnPrefab, this.transform, btnRect);
                        }
                        // Child
                        {
                            btnUIData.btnChat.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is ContestManagerBtnChatUI.UIData)
                    {
                        dirty = true;
                        return;
                    }
                }
                if(data is RoomChatUI.UIData)
                {
                    RoomChatUI.UIData roomChatUIData = data as RoomChatUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roomChatUIData, roomChatPrefab, this.transform);
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
                    uiData.contestManager.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                    uiData.btns.allRemoveCallBack(this);
                    uiData.roomChat.allRemoveCallBack(this);
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
                if (data is ContestManager)
                {
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                {
                                    ContestManagerStateLobbyUI.UIData lobbyUIData = sub as ContestManagerStateLobbyUI.UIData;
                                    lobbyUIData.removeCallBackAndDestroy(typeof(ContestManagerStateLobbyUI));
                                }
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    ContestManagerStatePlayUI.UIData playUIData = sub as ContestManagerStatePlayUI.UIData;
                                    playUIData.removeCallBackAndDestroy(typeof(ContestManagerStatePlayUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // btn
                {
                    if (data is ContestManagerBtnUI.UIData)
                    {
                        ContestManagerBtnUI.UIData btnUIData = data as ContestManagerBtnUI.UIData;
                        // UI
                        {
                            btnUIData.removeCallBackAndDestroy(typeof(ContestManagerBtnUI));
                        }
                        // Child
                        {
                            btnUIData.btnChat.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is ContestManagerBtnChatUI.UIData)
                    {
                        return;
                    }
                }
                if (data is RoomChatUI.UIData)
                {
                    RoomChatUI.UIData roomChatUIData = data as RoomChatUI.UIData;
                    // UI
                    {
                        roomChatUIData.removeCallBackAndDestroy(typeof(RoomChatUI));
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
                    case UIData.Property.contestManager:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.sub:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btns:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roomChat:
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
                if (wrapProperty.p is ContestManager)
                {
                    switch ((ContestManager.Property)wrapProperty.n)
                    {
                        case ContestManager.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
                // btn
                {
                    if (wrapProperty.p is ContestManagerBtnUI.UIData)
                    {
                        switch ((ContestManagerBtnUI.UIData.Property)wrapProperty.n)
                        {
                            case ContestManagerBtnUI.UIData.Property.btnChat:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case ContestManagerBtnUI.UIData.Property.btnRoomUser:
                                break;
                            case ContestManagerBtnUI.UIData.Property.btnSetting:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is ContestManagerBtnChatUI.UIData)
                    {
                        switch ((ContestManagerBtnChatUI.UIData.Property)wrapProperty.n)
                        {
                            case ContestManagerBtnChatUI.UIData.Property.visibility:
                                dirty = true;
                                break;
                            case ContestManagerBtnChatUI.UIData.Property.style:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is RoomChatUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}