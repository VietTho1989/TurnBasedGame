using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalChatUpdate : UpdateBehavior<GlobalChat>
{

	#region update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is GlobalChat) {
			GlobalChat globalChat = data as GlobalChat;
			// Child
			{
				globalChat.general.allAddCallBack (this);
				globalChat.shortQuestion.allAddCallBack (this);
				globalChat.suggestion.allAddCallBack (this);
				globalChat.bugReport.allAddCallBack (this);
				globalChat.offTopic.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is ChatRoom) {
			ChatRoom chatRoom = data as ChatRoom;
			// Update
			{
				UpdateUtils.makeUpdate<ChatRoomUpdate, ChatRoom> (chatRoom, this.transform);
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is GlobalChat) {
			GlobalChat globalChat = data as GlobalChat;
			// Child
			{
				globalChat.general.allRemoveCallBack (this);
				globalChat.shortQuestion.allRemoveCallBack (this);
				globalChat.suggestion.allRemoveCallBack (this);
				globalChat.bugReport.allRemoveCallBack (this);
				globalChat.offTopic.allRemoveCallBack (this);
			}
			this.setDataNull (globalChat);
			return;
		}
		// Child
		if (data is ChatRoom) {
			ChatRoom chatRoom = data as ChatRoom;
			// Update
			{
				chatRoom.removeCallBackAndDestroy (typeof(ChatRoomUpdate));
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is GlobalChat) {
			switch ((GlobalChat.Property)wrapProperty.n) {
			case GlobalChat.Property.general:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GlobalChat.Property.shortQuestion:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GlobalChat.Property.suggestion:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GlobalChat.Property.bugReport:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GlobalChat.Property.offTopic:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is ChatRoom) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}