using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewChatMessageNumberUI : UIBehavior<NewChatMessageNumberUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<ChatRoom>> chatRoom;

		public VP<RequestChangeStringUI.UIData> newCount;

		#region Constructor

		public enum Property
		{
			chatRoom,
			newCount
		}

		public UIData() : base()
		{
			this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
			// newCount
			{
				this.newCount = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.newCount, new RequestChangeStringUI.UIData());
				this.newCount.v.updateData.v.canRequestChange.v = false;
			}
		}

		#endregion

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatRoom chatRoom = this.data.chatRoom.v.data;
				if (chatRoom != null) {
					// newCount
					{
						RequestChangeStringUI.UIData name = this.data.newCount.v;
						if (name != null) {
							RequestChangeStringUpdate.UpdateData updateData = name.updateData.v;
							if (updateData != null) {
								// find newCount
								int newCount = 0;
								{
									// TODO Can hoan thien: tam de tam nhu vay da
									newCount = chatRoom.messages.vs.Count;
								}
								if (newCount > 0) {
									updateData.origin.v = "" + newCount;
								} else {
									updateData.origin.v = "";
								}
							} else {
								Debug.LogError ("updateData null: " + this);
							}
						} else {
							Debug.LogError ("name null: " + this);
						}
					}
				} else {
					Debug.LogError ("chatRoom null: " + this);
				}
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

	public RequestChangeStringUI requestStringPrefab;
	public Transform newCountContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.chatRoom.allAddCallBack (this);
				uiData.newCount.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is ChatRoom) {
				dirty = true;
				return;
			}
			// newCount
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.newCount:
							UIUtils.Instantiate (requestChange, requestStringPrefab, newCountContainer);
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("wrapProperty null: " + this);
					}
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.chatRoom.allRemoveCallBack (this);
				uiData.newCount.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is ChatRoom) {
				return;
			}
			// newCount
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.chatRoom:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.newCount:
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
		{
			if (wrapProperty.p is ChatRoom) {
				switch ((ChatRoom.Property)wrapProperty.n) {
				case ChatRoom.Property.topic:
					break;
				case ChatRoom.Property.isEnable:
					break;
				case ChatRoom.Property.players:
					break;
				case ChatRoom.Property.messages:
					dirty = true;
					break;
				case ChatRoom.Property.typing:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// newCount
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}