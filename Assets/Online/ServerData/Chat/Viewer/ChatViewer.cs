using UnityEngine;
using Mirror;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class ChatViewer : Data
{

    public VP<uint> userId;

    public VP<uint> minViewId;

    public LP<ChatSubView> subViews;

    public VP<NetworkConnection> connection;

    public VP<bool> isActive;

    #region Constructor

    public enum Property
    {
        userId,
        minViewId,
        subViews,
        connection,
        isActive
    }

    public ChatViewer() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.minViewId = new VP<uint>(this, (byte)Property.minViewId, 0);
        this.subViews = new LP<ChatSubView>(this, (byte)Property.subViews);
        this.connection = new VP<NetworkConnection>(this, (byte)Property.connection, null);
        this.isActive = new VP<bool>(this, (byte)Property.isActive, true);
    }

    #endregion

    public static byte[] GetChatViewerByteArray()
    {
        byte[] byteArray = null;
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    ChatViewerIdentity[] chatViewerIdentities = Object.FindObjectsOfType<ChatViewerIdentity>();
                    writer.Write(chatViewerIdentities.Length);
                    foreach (ChatViewerIdentity chatViewerIdentity in chatViewerIdentities)
                    {
                        ChatViewer chatViewer = chatViewerIdentity.netData.clientData;
                        if (chatViewer != null)
                        {
                            // check is showing UI
                            bool isShowing = false;
                            {
                                ChatRoom chatRoom = chatViewer.findDataInParent<ChatRoom>();
                                if (chatRoom != null)
                                {
                                    // write chatRoom netId
                                    {
                                        DataIdentity chatRoomIdentity = null;
                                        if (DataIdentity.clientMap.TryGetValue(chatRoom, out chatRoomIdentity))
                                        {
                                            writer.Write(chatRoomIdentity.netId);
                                        }
                                    }
                                    if (chatRoom.findCallBack<ChatRoomUI>() != null)
                                    {
                                        isShowing = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("chatRoom null");
                                }
                            }
                            // process
                            writer.Write(isShowing ? chatViewer.minViewId.v : uint.MaxValue);
                        }
                        else
                        {
                            Debug.LogError("chatViewer null");
                        }
                    }
                    // convert
                    byteArray = memStream.ToArray();
                }
            }
        }
        return byteArray;
    }

    public static void UpdateChatViewer(uint userId, byte[] chatViewerByteArray)
    {
        MemoryStream mem = new MemoryStream(chatViewerByteArray);
        using (BinaryReader reader = new BinaryReader(mem))
        {
            try
            {
                int chatViewerCount = reader.ReadInt32();
                for (int i = 0; i < chatViewerCount; i++)
                {
                    uint netId = reader.ReadUInt32();
                    uint minViewId = reader.ReadUInt32();
                    // find identity
                    ChatRoomIdentity chatRoomIdentity = ClientConnectIdentity.GetDataIdentity<ChatRoomIdentity>(netId);
                    if (chatRoomIdentity != null)
                    {
                        ChatRoom chatRoom = chatRoomIdentity.netData.serverData;
                        if (chatRoom != null)
                        {
                            // check show
                            bool show = false;
                            {
                                if (minViewId < uint.MaxValue)
                                {
                                    // find largestChatMessageId
                                    uint largestChatMessageId = 0;
                                    uint minChatMessageId = 0;
                                    {
                                        if (chatRoom.messages.vs.Count > 0)
                                        {
                                            ChatMessage lastMessage = chatRoom.messages.vs[chatRoom.messages.vs.Count - 1];
                                            largestChatMessageId = lastMessage.uid;
                                            if (largestChatMessageId > 50)
                                            {
                                                minChatMessageId = largestChatMessageId - 50;
                                            }
                                        }
                                    }
                                    // check
                                    if (minViewId <= largestChatMessageId + 10 && minViewId >= minChatMessageId)
                                    {
                                        Debug.LogError("show: " + minViewId + ", " + largestChatMessageId);
                                        show = true;
                                    }
                                    else
                                    {
                                        Debug.LogError("not show: " + minViewId + ", " + largestChatMessageId);
                                    }
                                }
                            }
                            // process
                            if (show)
                            {
                                // show with minViewId
                                // find chatView
                                ChatViewer chatViewer = chatRoom.findChatViewer(userId);
                                {
                                    if (chatViewer == null)
                                    {
                                        chatViewer = new ChatViewer();
                                        {
                                            chatViewer.uid = chatRoom.chatViewers.makeId();
                                            chatViewer.userId.v = userId;
                                            chatViewer.isActive.v = true;
                                        }
                                        chatRoom.chatViewers.add(chatViewer);
                                    }
                                }
                                // Update
                                {
                                    chatViewer.minViewId.v = minViewId;
                                }
                            }
                            else
                            {
                                // remove chatViewer
                                ChatViewer chatViewer = chatRoom.findChatViewer(userId);
                                if (chatViewer != null)
                                {
                                    // chatRoom.chatViewers.remove(chatViewer);
                                    chatViewer.isActive.v = false;
                                }
                                else
                                {
                                    Debug.LogError("chatViewer null: " + chatRoom);
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
                        Debug.LogError("identity null");
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

}