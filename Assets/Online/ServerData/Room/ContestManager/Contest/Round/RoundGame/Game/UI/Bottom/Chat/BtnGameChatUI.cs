using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnGameChatUI : UIBehavior<BtnGameChatUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatRoom>> chatRoom;

        #region Constructor

        public enum Property
        {
            chatRoom
        }

        public UIData() : base()
        {
            this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
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
                        BtnGameChatUI btnGameChatUI = this.findCallBack<BtnGameChatUI>();
                        if (btnGameChatUI != null)
                        {
                            isProcess = btnGameChatUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnGameChatUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Messages");

    static BtnGameChatUI()
    {
        txtTitle.add(Language.Type.vi, "Thông Báo");
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
                ChatRoom chatRoom = this.data.chatRoom.v.data;
                if (chatRoom != null)
                {
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
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

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
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
            Setting.get().addCallBack(this);
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
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
                case UIData.Property.chatRoom:
                    dirty = true;
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
                    case KeyCode.C:
                        {
                            if (btnGameChat != null && btnGameChat.gameObject.activeInHierarchy && btnGameChat.interactable)
                            {
                                this.onClickBtnGameChat();
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

    public Button btnGameChat;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnGameChat()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                GameChatRoomUI.UIData gameChatRoomUIData = gameUIData.gameChatRoom.newOrOld<GameChatRoomUI.UIData>();
                {

                }
                gameUIData.gameChatRoom.v = gameChatRoomUIData;
                // showAnimationUI
                {
                    ShowAnimationUI.UIData showAnimationUIData = gameChatRoomUIData.showAnimation.v;
                    if (showAnimationUIData != null)
                    {
                        showAnimationUIData.show();
                    }
                    else
                    {
                        Debug.LogError("showAnimationUIData null");
                    }
                }
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

}