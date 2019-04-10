using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class InformGameMessageUI : UIBehavior<InformGameMessageUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ChatRoom>> chatRoom;

        public LP<ChatMessageHolder.UIData> chatMessageUIDatas;

        #region state

        public enum State
        {
            None,
            Request,
            Wait
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            chatRoom,
            chatMessageUIDatas,
            state
        }

        public UIData() : base()
        {
            this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
            this.chatMessageUIDatas = new LP<ChatMessageHolder.UIData>(this, (byte)Property.chatMessageUIDatas);
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public void reset()
        {
            this.state.v = State.None;
        }

    }

    #endregion

    #region txt, rect

    private static readonly TxtLanguage txtLoadError = new TxtLanguage("Load game messages error");

    static InformGameMessageUI()
    {
        // txt
        txtLoadError.add(Language.Type.vi, "Tải thông báo lỗi");
        // rect
        {
            // chatMessageRect.anchoredPosition = new Vector3(0, 0, 0);
            chatMessageRect.anchorMin = new Vector2(0.0f, 1.0f);
            chatMessageRect.anchorMax = new Vector2(1.0f, 1.0f);
            chatMessageRect.pivot = new Vector2(0.5f, 1.0f);
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
                        float rightWidth = 0;
                        float bottomHeight = 0;
                        {
                            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
                            if (gameDataUIData != null)
                            {
                                rightWidth = gameDataUIData.rightWidth.v;
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
                            // Debug.LogError("boardTransform: " + left + ", " + right + ", " + top + ", " + bottom);
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
                                        // Debug.LogError("gameData: " + gameDataWidth + ", " + gameDataHeight + ", " + boardWidth + ", " + boardHeight + ", " + right + ", " + left + ", " + top + ", " + bottom);
                                        switch (screen)
                                        {
                                            case GameDataBoardUI.UIData.Screen.Portrait:
                                                {
                                                    // width
                                                    {
                                                        chatRoomWidth = gameDataWidth - GameDataBoardUI.Margin - GameDataBoardUI.Margin - GamePlayerUI.Width - GameDataBoardUI.Margin - rightWidth;
                                                        chatRoomX = -gameDataWidth / 2 + GameDataBoardUI.Margin + GamePlayerUI.Width + GameDataBoardUI.Margin + chatRoomWidth / 2;
                                                    }
                                                    // height
                                                    {
                                                        chatRoomHeight = gameDataHeight / 2 - bottom - GameDataBoardUI.Margin - GameDataBoardUI.Margin;
                                                        chatRoomY = -(gameDataHeight / 2 - bottomHeight - GameDataBoardUI.Margin - chatRoomHeight / 2);
                                                    }
                                                }
                                                break;
                                            case GameDataBoardUI.UIData.Screen.LandScape:
                                                {
                                                    // width
                                                    {
                                                        chatRoomWidth = gameDataWidth / 2 - boardWidth / 2 - rightWidth / 2 - 2 * GameDataBoardUI.Margin;
                                                        chatRoomX = right + GameDataBoardUI.Margin + chatRoomWidth / 2;
                                                    }
                                                    // height
                                                    {
                                                        chatRoomHeight = boardHeight - GamePlayerUI.Height - GameDataBoardUI.Margin + (gameDataHeight / 2 - bottom - GameDataBoardUI.Margin);
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
                                    // Debug.LogError("informGameMessage transform: " + chatRoomWidth + ", " + chatRoomHeight + ", " + chatRoomX + ", " + chatRoomY);
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
                    // chatMessages
                    {
                        // get chatMessage: tin gan day nhat xep dau
                        List<ChatMessage> chatMessages = new List<ChatMessage>();
                        {
                            long currentTime = Global.getRealTimeInMiliSeconds();
                            long maxDeltaTime = 1 * 60 * 1000;
                            int maxCount = 20;
                            int count = 0;
                            for (int i = chatRoom.messages.vs.Count - 1; i >= 0; i--)
                            {
                                ChatMessage chatMessage = chatRoom.messages.vs[i];
                                if (currentTime - chatMessage.clientTime <= maxDeltaTime
                                    && Mathf.Abs(chatMessage.time.v - chatMessage.clientTime) <= maxDeltaTime)
                                {
                                    chatMessages.Add(chatMessage);
                                    count++;
                                    if (count >= maxCount)
                                    {
                                        // Debug.LogError("maxCount");
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            // Debug.LogError("chatMessage count: " + chatMessages.Count + ", " + chatRoom.messages.vs.Count);
                        }
                        // make UI
                        {
                            // get old
                            List<ChatMessageHolder.UIData> oldMessages = new List<ChatMessageHolder.UIData>();
                            {
                                oldMessages.AddRange(this.data.chatMessageUIDatas.vs);
                            }
                            // update
                            foreach (ChatMessage chatMessage in chatMessages)
                            {
                                // find UI
                                ChatMessageHolder.UIData chatMessageUIData = null;
                                bool needAdd = false;
                                {
                                    // find old
                                    if (oldMessages.Count > 0)
                                    {
                                        chatMessageUIData = oldMessages[0];
                                    }
                                    // make new
                                    if (chatMessageUIData == null)
                                    {
                                        chatMessageUIData = new ChatMessageHolder.UIData();
                                        {
                                            chatMessageUIData.uid = this.data.chatMessageUIDatas.makeId();
                                        }
                                        needAdd = true;
                                    }
                                    else
                                    {
                                        oldMessages.Remove(chatMessageUIData);
                                    }
                                }
                                // update
                                {
                                    chatMessageUIData.chatMessage.v = new ReferenceData<ChatMessage>(chatMessage);
                                }
                                // add
                                if (needAdd)
                                {
                                    this.data.chatMessageUIDatas.add(chatMessageUIData);
                                }
                            }
                            // remove old
                            foreach (ChatMessageHolder.UIData oldMessage in oldMessages)
                            {
                                this.data.chatMessageUIDatas.remove(oldMessage);
                            }
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // chatMessages
                        {
                            for (int i = 0; i < this.data.chatMessageUIDatas.vs.Count; i++)
                            {
                                ChatMessageHolder.UIData chatMessageUIData = this.data.chatMessageUIDatas.vs[i];
                                deltaY += UIRectTransform.SetPosY(chatMessageUIData, deltaY);
                            }
                        }
                        // Debug.LogError("deltaY: " + deltaY);
                    }
                    // autoLoad
                    {
                        // find can load more
                        uint profileId = Server.getProfileUserId(chatRoom);
                        bool needLoad = false;
                        {
                            Server server = chatRoom.findDataInParent<Server>();
                            if (server != null && server.type.v == Server.Type.Client)
                            {
                                ChatViewer chatViewer = chatRoom.chatViewers.getInList(profileId);
                                if (chatViewer != null)
                                {
                                    if (chatViewer.isActive.v)
                                    {
                                        needLoad = false;
                                    }
                                    else
                                    {
                                        needLoad = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("chatViewer null: " + this);
                                    needLoad = true;
                                }
                            }
                        }
                        if (needLoad)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        destroyRoutine(waitLoad);
                                        this.data.state.v = UIData.State.Request;
                                    }
                                    break;
                                case UIData.State.Request:
                                    {
                                        destroyRoutine(waitLoad);
                                        if (Server.IsServerOnline(chatRoom))
                                        {
                                            Debug.LogError("informGameMessageUI: load more");
                                            chatRoom.requestLoadMore(profileId, ChatRoom.LoadMorePerRequest);
                                            this.data.state.v = UIData.State.Wait;
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online");
                                        }
                                    }
                                    break;
                                case UIData.State.Wait:
                                    {
                                        if (Server.IsServerOnline(chatRoom))
                                        {
                                            startRoutine(ref this.waitLoad, TaskWaitLoad());
                                        }
                                        else
                                        {
                                            destroyRoutine(waitLoad);
                                            this.data.state.v = UIData.State.None;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            this.data.state.v = UIData.State.None;
                            destroyRoutine(waitLoad);
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
        return false;
    }

    #endregion

    #region Task wait

    private Routine waitLoad;

    public IEnumerator TaskWaitLoad()
    {
        if (this.data != null)
        {
            yield return new Wait(Global.WaitSendTime);
            this.data.state.v = UIData.State.None;
            Toast.showMessage(txtLoadError.get());
            Debug.LogError("request error: " + this);
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    #endregion

    #region Task

    private Routine timeRoutine;

    public override void Awake()
    {
        base.Awake();
        startRoutine(ref this.timeRoutine, updateTime());
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(timeRoutine);
            ret.Add(waitLoad);
        }
        return ret;
    }

    public IEnumerator updateTime()
    {
        while (true)
        {
            yield return new Wait(5f);
            if (this.data != null)
            {
                dirty = true;
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    #endregion

    #region implement callBacks

    private GameDataUI.UIData gameDataUIData = null;

    public ChatMessageHolder chatMessagePrefab;
    private static readonly UIRectTransform chatMessageRect = new UIRectTransform();

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
                uiData.chatMessageUIDatas.allAddCallBack(this);
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
            // chatRoom
            {
                if (data is ChatRoom)
                {
                    ChatRoom chatRoom = data as ChatRoom;
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
                    // Child
                    {
                        chatRoom.chatViewers.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is ChatViewer)
                {
                    dirty = true;
                    return;
                }
            }
            if(data is ChatMessageHolder.UIData)
            {
                ChatMessageHolder.UIData chatMessageUIData = data as ChatMessageHolder.UIData;
                // Child
                {
                    UIUtils.Instantiate(chatMessageUIData, chatMessagePrefab, this.transform, chatMessageRect);
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.gameDataUIData);
            }
            // Child
            {
                uiData.chatRoom.allRemoveCallBack(this);
                uiData.chatMessageUIDatas.allRemoveCallBack(this);
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
            // chatRoom
            {
                if (data is ChatRoom)
                {
                    ChatRoom chatRoom = data as ChatRoom;
                    // Child
                    {
                        chatRoom.chatViewers.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ChatViewer)
                {
                    return;
                }
            }
            if (data is ChatMessageHolder.UIData)
            {
                ChatMessageHolder.UIData chatMessageUIData = data as ChatMessageHolder.UIData;
                // Child
                {
                    chatMessageUIData.removeCallBackAndDestroy(typeof(ChatMessageHolder));
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
                case UIData.Property.chatMessageUIDatas:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
                    dirty = true;
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
                    case GameDataUI.UIData.Property.type:
                        dirty = true;
                        break;
                    case GameDataUI.UIData.Property.rightWidth:
                        dirty = true;
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
                // chatRoom
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
                                dirty = true;
                                break;
                            case ChatRoom.Property.editMax:
                                break;
                            case ChatRoom.Property.maxId:
                                break;
                            case ChatRoom.Property.chatViewers:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
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
                    if (wrapProperty.p is ChatViewer)
                    {
                        switch ((ChatViewer.Property)wrapProperty.n)
                        {
                            case ChatViewer.Property.userId:
                                dirty = true;
                                break;
                            case ChatViewer.Property.minViewId:
                                break;
                            case ChatViewer.Property.subViews:
                                break;
                            case ChatViewer.Property.connection:
                                break;
                            case ChatViewer.Property.isActive:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is ChatMessageHolder.UIData)
                {
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}