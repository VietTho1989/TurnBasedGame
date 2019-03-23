using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestManagerUI : UIBehavior<ContestManagerUI.UIData>
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

            #region Constructor

            public enum Property
            {
                contestManager,
                sub,
                btns
            }

            public UIData() : base()
            {
                this.contestManager = new VP<ReferenceData<ContestManager>>(this, (byte)Property.contestManager, new ReferenceData<ContestManager>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
                this.btns = new VP<ContestManagerBtnUI.UIData>(this, (byte)Property.btns, new ContestManagerBtnUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                // Debug.LogError ("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
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
                ContestManagerBtnUI.UIData btns = this.btns.v;
                if (btns != null)
                {
                    ContestManagerBtnChatUI.UIData btnChatUIData = btns.btnChat.v;
                    if (btnChatUIData != null)
                    {
                        btnChatUIData.visibility.v = ContestManagerBtnChatUI.UIData.Visibility.Hide;
                    }
                    else
                    {
                        Debug.LogError("btnChatUIData null");
                    }
                }
                else
                {
                    Debug.LogError("btns null");
                }
            }

        }

        #endregion

        #region txt, rect

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
        }

        #endregion

        #region Refresh

        private const float PortraitChatHeight = 60;
        private const float LandscapeChatWidth = 160;

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
                                            UIRectTransform fullScreenRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);
                                            UIRectTransform.Set(sub, fullScreenRect);
                                        }
                                        break;
                                    case ContestManager.State.Type.Play:
                                        {
                                            // find
                                            bool isHaveChatFull = false;
                                            {
                                                ContestManagerBtnUI.UIData btns = this.data.btns.v;
                                                if (btns != null)
                                                {
                                                    ContestManagerBtnChatUI.UIData btnChat = btns.btnChat.v;
                                                    if (btnChat != null)
                                                    {
                                                        if (btnChat.visibility.v == ContestManagerBtnChatUI.UIData.Visibility.Show
                                                            && btnChat.style.v == ContestManagerBtnChatUI.UIData.Style.Full)
                                                        {
                                                            isHaveChatFull = true;
                                                        }
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
                                            if (!isHaveChatFull)
                                            {
                                                UIRectTransform fullScreenRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);
                                                UIRectTransform.Set(sub, fullScreenRect);
                                            }
                                            else
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
                                                // process
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.contestManager.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                    uiData.btns.allAddCallBack(this);
                }
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
                    uiData.contestManager.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                    uiData.btns.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}