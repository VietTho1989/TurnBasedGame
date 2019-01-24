using UnityEngine;
using System.Collections;

public class RemoveTypingPlayerUpdate : UpdateBehavior<ChatRoom>
{
	#region Update

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
		if (data is ChatRoom) {
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is ChatRoom) {
			ChatRoom chatRoom = data as ChatRoom;
			{

			}
			this.setDataNull (chatRoom);
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, System.Collections.Generic.List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is ChatRoom) {
			switch ((ChatRoom.Property)wrapProperty.n) {
			case ChatRoom.Property.players:
				break;
			case ChatRoom.Property.messages:
				{
					if (typeof(T)==typeof(ChatMessage) || typeof(T).IsSubclassOf (typeof(ChatMessage))) {
						for (int syncCount = 0; syncCount < syncs.Count; syncCount++) {
							Sync<T> sync = syncs [syncCount];
							if (sync is SyncAdd<T>) {
								SyncAdd<T> syncAdd = (SyncAdd<T>)sync;
								for (int i = 0; i < syncAdd.values.Count; i++) {
									ChatMessage chatMessage = (ChatMessage)(object)syncAdd.values [i];
									// set
									if (chatMessage.content.v is ChatNormalContent) {
										ChatNormalContent chatNormalContent = chatMessage.content.v as ChatNormalContent;
										ChatRoom chatRoom = chatMessage.findDataInParent<ChatRoom> ();
										if (chatRoom != null) {
											Typing typing = chatRoom.typing.v;
											typing.removePlayer (chatNormalContent.owner.v);
										} else {
											Debug.LogError ("chatRoom null: " + this);
										}
									}
								}
							}
						}
					} else {
						Debug.LogError ("Why T is not ChatMessage: " + this);
					}
				}
				break;
			case ChatRoom.Property.typing:
				break;
			case ChatRoom.Property.isEnable:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion
}