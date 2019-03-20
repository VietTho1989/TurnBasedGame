using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InformGameMessageUI : UIBehavior<InformGameMessageUI.UIData>
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
                    // position
                    {
                        // find
                        RectTransform boardTransform = null;
                        float boardLeft = 0;
                        float boardRight = 0;
                        float boardTop = 0;
                        float boardBottom = 0;
                        GameDataBoardUI.UIData.Screen screen = GameDataBoardUI.UIData.Screen.Portrait;
                        {
                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                            if (gameDataUIData != null)
                            {
                                GameDataBoardUI.UIData gameDataBoardUIData = gameDataUIData.board.v;
                                if (gameDataBoardUIData != null)
                                {
                                    // boardTransform
                                    {
                                        GameDataBoardUI gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                                        if (gameDataBoardUI != null)
                                        {
                                            boardTransform = (RectTransform)gameDataBoardUI.transform;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataBoardUI null");
                                        }
                                        screen = gameDataBoardUIData.screen.v;
                                    }
                                    // margin
                                    {
                                        boardLeft = gameDataBoardUIData.left.v;
                                        boardRight = gameDataBoardUIData.right.v;
                                        boardTop = gameDataBoardUIData.top.v;
                                        boardBottom = gameDataBoardUIData.bottom.v;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameDataBoardUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("gameDataUIData null");
                            }
                        }
                        float bottomHeight = 0;
                        {
                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                            if (gameDataUIData != null)
                            {
                                bottomHeight = gameDataUIData.bottomHeight.v;
                            }
                            else
                            {
                                Debug.LogError("gameDataUIData null");
                            }
                        }
                        // process
                        if (boardTransform != null)
                        {
                            // find
                            float left = boardTransform.rect.xMin;
                            float right = boardTransform.rect.xMax;
                            float top = boardTransform.rect.yMin;
                            float bottom = boardTransform.rect.yMax;
                            {
                                UIRectTransform.GetMargin(boardTransform, out left, out right, out top, out bottom);
                                left -= boardLeft;
                                right += boardRight;
                                top -= boardTop;
                                bottom += boardBottom;
                            }
                            Debug.LogError("boardTransform: " + left + ", " + right + ", " + top + ", " + bottom);
                            // process
                            RectTransform chatRoomTransform = (RectTransform)this.transform;
                            if (chatRoomTransform != null)
                            {
                                // find dimension
                                float chatRoomWidth = 0;
                                float chatRoomHeight = 0;
                                float chatRoomX = 0;
                                float chatRoomY = 0;
                                {
                                    // get gameDataUI dimension
                                    float gameDataWidth = 480;
                                    float gameDataHeight = 640;
                                    {
                                        GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                                        if (gameDataUIData != null)
                                        {
                                            GameDataUI gameDataUI = gameDataUIData.findCallBack<GameDataUI>();
                                            if (gameDataUI != null)
                                            {
                                                RectTransform gameDataRectTransform = gameDataUI.transform as RectTransform;
                                                if (gameDataRectTransform != null)
                                                {
                                                    gameDataWidth = gameDataRectTransform.rect.width;
                                                    gameDataHeight = gameDataRectTransform.rect.height;
                                                }
                                                else
                                                {
                                                    Debug.LogError("gameDataRectTransform null");
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("gameDataUI");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUIData null");
                                        }
                                    }
                                    // process
                                    {
                                        float boardWidth = right - left;
                                        float boardHeight = bottom - top;
                                        Debug.LogError("gameData: " + gameDataWidth + ", " + gameDataHeight + ", " + boardWidth + ", " + boardHeight);
                                        switch (screen)
                                        {
                                            case GameDataBoardUI.UIData.Screen.Portrait:
                                                {
                                                    // width
                                                    {
                                                        float leftBoardWidth = GameDataBoardUI.Margin;
                                                        chatRoomWidth = gameDataWidth - leftBoardWidth - GameDataBoardUI.Margin - GamePlayerUI.Width - GameDataBoardUI.Margin - GameDataBoardUI.Margin;
                                                        chatRoomX = gameDataWidth / 2 - GameDataBoardUI.Margin - chatRoomWidth / 2;
                                                    }
                                                    // height
                                                    {
                                                        chatRoomHeight = gameDataHeight - boardHeight - bottomHeight - (2 * GameDataBoardUI.Margin + GamePlayerUI.Height) - 2 * GameDataBoardUI.Margin;
                                                        chatRoomY = -(gameDataHeight / 2 - bottomHeight - GameDataBoardUI.Margin - chatRoomHeight / 2);
                                                    }
                                                }
                                                break;
                                            case GameDataBoardUI.UIData.Screen.LandScape:
                                                {
                                                    // width
                                                    {
                                                        chatRoomWidth = gameDataWidth / 2 - boardWidth / 2 - 2 * GameDataBoardUI.Margin;
                                                        chatRoomX = gameDataWidth / 2 - GameDataBoardUI.Margin - chatRoomWidth / 2;
                                                    }
                                                    // height
                                                    {
                                                        float topBoardWidth = GameDataBoardUI.Margin;
                                                        chatRoomHeight = gameDataHeight - bottomHeight - topBoardWidth - GamePlayerUI.Height - GameDataBoardUI.Margin - GameDataBoardUI.Margin - GameDataBoardUI.Margin;
                                                        chatRoomY = -gameDataHeight / 2 + bottomHeight + GameDataBoardUI.Margin + chatRoomHeight / 2;
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown screen");
                                                break;
                                        }
                                    }
                                }
                                // set
                                {
                                    Debug.LogError("informGameMessage transform: " + chatRoomWidth + ", " + chatRoomHeight + ", " + chatRoomX + ", " + chatRoomY);
                                    UIRectTransform rectTransform = UIRectTransform.CreateCenterRect(chatRoomWidth, chatRoomHeight, chatRoomX, chatRoomY);
                                    rectTransform.set(chatRoomTransform);
                                }
                            }
                            else
                            {
                                Debug.LogError("chatRoomTransform null");
                            }
                        }
                        else
                        {
                            Debug.LogError("boardTransform null");
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

    private GameDataUI.UIData gameDataUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.gameDataUIData);
            }
            // Child
            {
                uiData.chatRoom.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if(data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // Child
                {
                    gameDataUIData.board.allAddCallBack(this);
                    TransformData.AddCallBack(gameDataUIData, this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if(data is GameDataBoardUI.UIData)
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(gameDataBoardUIData, this);
                    }
                    dirty = true;
                    return;
                }
                if (data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            if(data is ChatRoom)
            {
                ChatRoom chatRoom = data as ChatRoom;
                // Child
                {
                    chatRoom.messages.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is ChatMessage)
            {
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.gameDataUIData);
            }
            // Child
            {
                uiData.chatRoom.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Parent
        {
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // Child
                {
                    gameDataUIData.board.allRemoveCallBack(this);
                    TransformData.RemoveCallBack(gameDataUIData, this);
                }
                return;
            }
            // Child
            {
                if (data is GameDataBoardUI.UIData)
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(gameDataBoardUIData, this);
                    }
                    return;
                }
                if (data is TransformData)
                {
                    return;
                }
            }
        }
        // Child
        {
            if (data is ChatRoom)
            {
                ChatRoom chatRoom = data as ChatRoom;
                // Child
                {
                    chatRoom.messages.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            if (data is ChatMessage)
            {
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
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is GameDataUI.UIData)
            {
                switch ((GameDataUI.UIData.Property)wrapProperty.n)
                {
                    case GameDataUI.UIData.Property.gameData:
                        break;
                    case GameDataUI.UIData.Property.board:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case GameDataUI.UIData.Property.allowLastMove:
                        break;
                    case GameDataUI.UIData.Property.hintUI:
                        break;
                    case GameDataUI.UIData.Property.allowInput:
                        break;
                    case GameDataUI.UIData.Property.requestChangeUseRule:
                        break;
                    case GameDataUI.UIData.Property.perspectiveUIData:
                        break;
                    case GameDataUI.UIData.Property.gamePlayerList:
                        break;
                    case GameDataUI.UIData.Property.informGameMessage:
                        break;
                    case GameDataUI.UIData.Property.gameActionsUI:
                        break;
                    case GameDataUI.UIData.Property.bottomHeight:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is GameDataBoardUI.UIData)
                {
                    switch ((GameDataBoardUI.UIData.Property)wrapProperty.n)
                    {
                        case GameDataBoardUI.UIData.Property.gameData:
                            break;
                        case GameDataBoardUI.UIData.Property.animationManager:
                            break;
                        case GameDataBoardUI.UIData.Property.sub:
                            break;
                        case GameDataBoardUI.UIData.Property.heightWidth:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.left:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.right:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.top:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.bottom:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.screen:
                            dirty = true;
                            break;
                        case GameDataBoardUI.UIData.Property.perspective:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (wrapProperty.p is ChatRoom)
                {
                    switch ((ChatRoom.Property)wrapProperty.n)
                    {
                        case ChatRoom.Property.topic:
                            break;
                        case ChatRoom.Property.isEnable:
                            break;
                        case ChatRoom.Property.players:
                            break;
                        case ChatRoom.Property.messages:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ChatRoom.Property.chatViewers:
                            break;
                        case ChatRoom.Property.typing:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is ChatMessage)
                {
                    dirty = true;
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}