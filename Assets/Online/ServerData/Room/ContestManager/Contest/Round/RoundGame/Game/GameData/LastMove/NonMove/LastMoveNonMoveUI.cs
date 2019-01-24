using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LastMoveNonMoveUI : UIBehavior<LastMoveNonMoveUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<NonMove>> nonMove;

		/*public override GameMove.Type getType ()
		{
			return GameMove.Type.None;
		}*/

		#region Constructor

		public enum Property
		{
			nonMove
		}

		public UIData() : base()
		{
			this.nonMove = new VP<ReferenceData<NonMove>>(this, (byte)Property.nonMove, new ReferenceData<NonMove>(null));
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
			{
				uiData.nonMove.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		if (data is NonMove) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			{
				uiData.nonMove.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		if (data is NonMove) {
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
			case UIData.Property.nonMove:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}