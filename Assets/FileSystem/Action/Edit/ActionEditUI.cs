using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionEditUI : UIBehavior<ActionEditUI.UIData>
	{

		#region UIData

		public class UIData : Action.UIData
		{

			public VP<ReferenceData<ActionEdit>> actionEdit;

			#region Constructor

			public enum Property
			{
				actionEdit
			}

			public UIData() : base()
			{
				this.actionEdit = new VP<ReferenceData<ActionEdit>>(this, (byte)Property.actionEdit, new ReferenceData<ActionEdit>(null));
			}

			#endregion

			public override Action.Type getType ()
			{
				return Action.Type.Edit;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ActionEdit actionEdit = this.data.actionEdit.v.data;
					if (actionEdit != null) {

					} else {
						Debug.LogError ("actionEdit null: " + this);
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
}