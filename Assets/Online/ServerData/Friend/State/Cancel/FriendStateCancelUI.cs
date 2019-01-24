using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateCancelUI : UIBehavior<FriendStateCancelUI.UIData>
{

	#region UIData

	public class UIData : FriendStateUI.UIData.Sub
	{

		public VP<ReferenceData<FriendStateCancel>> friendStateCancel;

		#region Constructor

		public enum Property
		{
			friendStateCancel
		}

		public UIData() : base()
		{
			this.friendStateCancel = new VP<ReferenceData<FriendStateCancel>>(this, (byte)Property.friendStateCancel, new ReferenceData<FriendStateCancel>(null));
		}

		#endregion

		public override Friend.State.Type getType ()
		{
			return Friend.State.Type.Cancel;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				FriendStateCancel friendStateCancel = this.data.friendStateCancel.v.data;
				if (friendStateCancel != null) {

				} else {
					Debug.LogError ("friendStateCancel null: " + this);
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
				uiData.friendStateCancel.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is FriendStateCancel) {
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
				uiData.friendStateCancel.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is FriendStateCancel) {
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
			case UIData.Property.friendStateCancel:
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
		if (wrapProperty.p is FriendStateCancel) {
			switch ((FriendStateCancel.Property)wrapProperty.n) {
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}