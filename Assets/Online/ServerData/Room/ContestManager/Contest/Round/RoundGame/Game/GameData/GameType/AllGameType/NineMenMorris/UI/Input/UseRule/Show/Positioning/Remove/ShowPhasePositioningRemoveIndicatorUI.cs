using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
	public class ShowPhasePositioningRemoveIndicatorUI : UIBehavior<ShowPhasePositioningRemoveIndicatorUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<int> position;

			#region Constructor

			public enum Property
			{
				position
			}

			public UIData() : base()
			{
				this.position = new VP<int>(this, (byte)Property.position, 0);
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
					this.transform.localPosition = Common.convertPositionToLocal (this.data.position.v);
				} else {
					Debug.LogError ("data null");
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
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.position:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}