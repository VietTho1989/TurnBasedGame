using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmptyInformUI : UIBehavior<EmptyInformUI.UIData>
{

	#region UIData

	public class UIData : InformUI
	{

		public VP<EditData<EmptyInform>> editEmptyInform;

		#region Constructor

		public enum Property
		{
			editEmptyInform
		}

		public UIData() : base()
		{
			this.editEmptyInform = new VP<EditData<EmptyInform>>(this, (byte)Property.editEmptyInform, new EditData<EmptyInform>());
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
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}