using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatRoomAdapterAutoSscrollToBottom : UpdateBehavior<ChatRoomAdapter.UIData>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (needScrollToBottom)
                {
                    needScrollToBottom = false;
                    // check need scroll
                    bool isCorrect = false;
                    {
                        if (this.data.holders.vs.Count == 0)
                        {
                            Debug.LogError("Why don't have anything");
                            isCorrect = true;
                        }
                        else
                        {
                            // Check show the next last item
                            bool isShowingTheNextLast = false;
                            {
                                // Find next last item
                                ChatMessage nextLast = null;
                                {
                                    if (this.data.chatRoom.v.data != null)
                                    {
                                        if (this.data.chatRoom.v.data.messages.vs.Count >= 2)
                                        {
                                            nextLast = this.data.chatRoom.v.data.messages.vs[this.data.chatRoom.v.data.messages.vs.Count - 2];
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("Why chatMessages null: " + this);
                                    }
                                }
                                // Check is showing
                                if (nextLast != null)
                                {
                                    foreach (ChatMessageHolder.UIData holder in this.data.holders.vs)
                                    {
                                        if (holder.chatMessage.v.data == nextLast)
                                        {
                                            isShowingTheNextLast = true;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    // Debug.LogError ("why nextLast null: " + this);
                                }
                            }
                            if (isShowingTheNextLast)
                            {
                                isCorrect = true;
                            }
                            else
                            {
                                // Debug.LogError ("not showing the next last item: " + this);
                            }
                        }
                    }
                    if (isCorrect)
                    {
                        scrollToBottom();
                    }
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
        return false;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatRoomAdapter.UIData)
        {
            ChatRoomAdapter.UIData uiData = data as ChatRoomAdapter.UIData;
            {
                uiData.chatRoom.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        if (data is ChatRoom)
        {
            dirty = true;
            needScrollToBottom = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatRoomAdapter.UIData)
        {
            ChatRoomAdapter.UIData uiData = data as ChatRoomAdapter.UIData;
            {
                uiData.chatRoom.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        if (data is ChatRoom)
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
        if (wrapProperty.p is ChatRoomAdapter.UIData)
        {
            switch ((ChatRoomAdapter.UIData.Property)wrapProperty.n)
            {
                case ChatRoomAdapter.UIData.Property.chatRoom:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ChatRoomAdapter.UIData.Property.holders:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
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
                        dirty = true;
                        needScrollToBottom = true;
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    private bool needScrollToBottom = false;

    private void scrollToBottom()
    {
        StartCoroutine(TaskScrollToBottom());
        /*if (this.data != null) {
			ChatRoomAdapter chatRoomAdapter = this.GetComponent<ChatRoomAdapter> ();
			if (chatRoomAdapter != null) {
				int index = -1;
				{
					if (this.data.chatRoom.v.data != null) {
						index = this.data.chatRoom.v.data.messages.vs.Count - 1;
					} else {
						Debug.LogError ("Why chatMessages null: " + this);
					}
				}
				if (index > 0) {
					Debug.LogError ("scrollToBottom");
					chatRoomAdapter.SmoothScrollTo (index, 0.3f, 1, 1f, null, true);
					// chatRoomAdapter.ScrollTo (index, 1f, 1f);
				}
			} else {
				Debug.LogError ("chatRoomAdapter null: " + this);
			}
		} else {
			// Debug.LogError ("data null: " + this);
		}*/
    }

    public IEnumerator TaskScrollToBottom()
    {
        yield return new WaitForSeconds(0.3f);
        if (this.data != null)
        {
            ChatRoomAdapter chatRoomAdapter = this.GetComponent<ChatRoomAdapter>();
            if (chatRoomAdapter != null)
            {
                int index = -1;
                {
                    if (this.data.chatRoom.v.data != null)
                    {
                        index = this.data.chatRoom.v.data.messages.vs.Count - 1;
                    }
                    else
                    {
                        Debug.LogError("Why chatMessages null: " + this);
                    }
                }
                if (index > 0)
                {
                    // Debug.LogError ("scrollToBottom");
                    chatRoomAdapter.SmoothScrollTo(index, 0.3f, 0, 0f, null, true);
                    // chatRoomAdapter.ScrollTo (index, 1f, 1f);
                }
            }
            else
            {
                Debug.LogError("chatRoomAdapter null: " + this);
            }
        }
        else
        {
            // Debug.LogError ("data null: " + this);
        }
    }

}