using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class ActionNoneUI : UIBehavior<ActionNoneUI.UIData>
	{

		#region UIData

		public class UIData : Action.UIData
		{

			public VP<ReferenceData<ActionNone>> actionNone;

			#region Constructor

			public enum Property
			{
				actionNone
			}

			public UIData() : base()
			{
				this.actionNone = new VP<ReferenceData<ActionNone>>(this, (byte)Property.actionNone, new ReferenceData<ActionNone>(null));
			}

			#endregion

			public override Action.Type getType ()
			{
				return Action.Type.None;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ActionNone actionNone = this.data.actionNone.v.data;
					if (actionNone != null) {

					} else {
						Debug.LogError ("actionNone null: " + this);
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