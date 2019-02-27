using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameChatRoomUI : UIBehavior<GameChatRoomUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatRoom>> chatRoom;

        public VP<ChatRoomUI.UIData> chatRoomUIData;

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            GameChatRoomUI gameChatRoomUI = this.findCallBack<GameChatRoomUI>();
            if (gameChatRoomUI != null)
            {
                gameChatRoomUI.back();
            }
            else
            {
                Debug.LogError("gameChatRoomUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            chatRoom,
            chatRoomUIData,
            showAnimation
        }

        public UIData() : base()
        {
            this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
            // chatRoomUIData
            {
                this.chatRoomUIData = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoomUIData, new ChatRoomUI.UIData());
                this.chatRoomUIData.v.needHeader.v = false;
            }
            // showAnimation
            {
                this.showAnimation = new VP<ShowAnimationUI.UIData>(this, (byte)Property.showAnimation, new ShowAnimationUI.UIData());
                this.showAnimation.v.onHide.v = OnHide;
            }
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // chatRoomUIData
                if (!isProcess)
                {
                    ChatRoomUI.UIData chatRoomUIData = this.chatRoomUIData.v;
                    if (chatRoomUIData != null)
                    {
                        isProcess = chatRoomUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("chatRoomUIData null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        GameChatRoomUI gameChatRoomUI = this.findCallBack<GameChatRoomUI>();
                        if (gameChatRoomUI != null)
                        {
                            gameChatRoomUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("gameChatRoomUI null");
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    static GameChatRoomUI()
    {
        txtTitle.add(Language.Type.vi, "Thông Báo");
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
                ChatRoom chatRoom = this.data.chatRoom.v.data;
                if (chatRoom != null)
                {
                    // chatRoomUIData
                    {
                        ChatRoomUI.UIData chatRoomUIData = this.data.chatRoomUIData.v;
                        if (chatRoomUIData != null)
                        {
                            chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom>(chatRoom);
                        }
                        else
                        {
                            Debug.LogError("chatRoomUIData null");
                        }
                    }
                    // UI Sibling Index
                    {
                        UIRectTransform.SetSiblingIndex(this.data.chatRoomUIData.v, 0);
                        if (btnBack != null)
                        {
                            btnBack.transform.SetSiblingIndex(1);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Game Messages");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("chatRoom null");
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

    public ChatRoomUI chatRoomPrefab;
    private static readonly UIRectTransform chatRoomRect = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight, 0);

    public ShowAnimationUI showAnimationUI;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.chatRoom.allAddCallBack(this);
                uiData.chatRoomUIData.allAddCallBack(this);
                uiData.showAnimation.allAddCallBack(this);
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
            if(data is ChatRoom)
            {
                dirty = true;
                return;
            }
            if (data is ChatRoomUI.UIData)
            {
                ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(chatRoomUIData, chatRoomPrefab, this.transform, chatRoomRect);
                }
                dirty = true;
                return;
            }
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setData(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
                    }
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
                uiData.chatRoom.allRemoveCallBack(this);
                uiData.chatRoomUIData.allRemoveCallBack(this);
                uiData.showAnimation.allRemoveCallBack(this);
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
            if(data is ChatRoom)
            {
                return;
            }
            if (data is ChatRoomUI.UIData)
            {
                ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
                // UI
                {
                    chatRoomUIData.removeCallBackAndDestroy(typeof(ChatRoomUI));
                }
                return;
            }
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setDataNull(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
                    }
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
                case UIData.Property.chatRoom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chatRoomUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showAnimation:
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
        {
            if(wrapProperty.p is ChatRoom)
            {
                return;
            }
            if (wrapProperty.p is ChatRoomUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ShowAnimationUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region back

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            if (showAnimationUI != null)
            {
                ShowAnimationUI.UIData showAnimationUIData = this.data.showAnimation.v;
                if (showAnimationUIData != null)
                {
                    showAnimationUIData.hide();
                }
                else
                {
                    Debug.LogError("showAnimationUIData null");
                }
            }
            else
            {
                Debug.LogError("showAnimationUI null");
                back();
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    private void back()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                gameUIData.gameChatRoom.v = null;
            }
            else
            {
                Debug.LogError("gameUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #endregion

}