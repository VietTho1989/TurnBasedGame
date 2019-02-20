using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NewChatMessageNumberUI : UIBehavior<NewChatMessageNumberUI.UIData>
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

    public Text tvNewCount;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatRoom chatRoom = this.data.chatRoom.v.data;
				if (chatRoom != null) {
                    if (tvNewCount != null)
                    {
                        // find newCount
                        int newCount = 0;
                        {
                            // TODO Can hoan thien: tam de tam nhu vay da
                            newCount = chatRoom.messages.vs.Count;
                        }
                        if (newCount > 0)
                        {
                            tvNewCount.text = "" + newCount;
                        }
                        else
                        {
                            tvNewCount.text = "";
                        }
                    }
                    else
                    {
                        Debug.LogError("tvNewCount null");
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.chatRoom.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
        // Child
        if (data is ChatRoom)
        {
            dirty = true;
            return;
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
			}
			this.setDataNull (uiData);
			return;
		}
        // Child
        if (data is ChatRoom)
        {
            return;
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
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
        // Child
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
        Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}