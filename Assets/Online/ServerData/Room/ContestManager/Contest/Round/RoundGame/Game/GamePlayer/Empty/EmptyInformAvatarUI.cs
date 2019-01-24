using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmptyInformAvatarUI : UIBehavior<EmptyInformAvatarUI.UIData>
{

	#region UIData

	public class UIData : InformAvatarUI.UIData.Sub
	{

		public VP<ReferenceData<EmptyInform>> emptyInform;

		#region Constructor

		public enum Property
		{
			emptyInform
		}

		public UIData() : base()
		{
			this.emptyInform = new VP<ReferenceData<EmptyInform>>(this, (byte)Property.emptyInform, new ReferenceData<EmptyInform>(null));
		}

		#endregion

		public override GamePlayer.Inform.Type getType ()
		{
			return GamePlayer.Inform.Type.None;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				EmptyInform emptyInform = this.data.emptyInform.v.data;
				if (emptyInform != null) {

				} else {
					// Debug.LogError ("emptyInform null: " + this);
				}
			} else {
				// Debug.LogError ("data null: " + this);
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
				uiData.emptyInform.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is EmptyInform) {
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
				uiData.emptyInform.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is EmptyInform) {
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
			case UIData.Property.emptyInform:
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
		if (wrapProperty.p is EmptyInform) {
			switch ((EmptyInform.Property)wrapProperty.n) {
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