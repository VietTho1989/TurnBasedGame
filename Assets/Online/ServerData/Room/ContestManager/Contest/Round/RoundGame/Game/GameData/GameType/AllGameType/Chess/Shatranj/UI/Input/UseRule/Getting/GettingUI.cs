using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj.UseRule
{
	public class GettingUI : UIBehavior<GettingUI.UIData>
	{

		#region UIData

		public class UIData : UseRuleInputUI.UIData.State
		{

			#region Constructor

			public enum Property
			{

			}

			public UIData() : base()
			{

			}

			#endregion

			public override Type getType ()
			{
				return Type.Getting;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{

				}
				return isProcess;
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
				dirty = true;
				return;
			}
			Debug.LogError ("not process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData getting = data as UIData;
				this.setDataNull (getting);
				return;
			}
			Debug.LogError ("not process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
		}

		#endregion

	}
}