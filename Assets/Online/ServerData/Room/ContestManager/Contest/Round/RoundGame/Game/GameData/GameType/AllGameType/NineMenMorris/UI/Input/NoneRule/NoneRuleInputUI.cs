using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NoneRuleInputUI : UIBehavior<NoneRuleInputUI.UIData>
	{

		#region UIData

		public class UIData : InputUI.UIData.Sub
		{

			public VP<ReferenceData<NineMenMorris>> nineMenMorris;

			#region Constructor

			public enum Property
			{
				nineMenMorris
			}

			public UIData() : base()
			{
				this.nineMenMorris = new VP<ReferenceData<NineMenMorris>>(this, (byte)Property.nineMenMorris, new ReferenceData<NineMenMorris>(null));
			}

			#endregion

			public override Type getType ()
			{
				return Type.NoneRule;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// TODO Can hoan thien
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
					NineMenMorris nineMenMorris = this.data.nineMenMorris.v.data;
					if (nineMenMorris != null) {

					} else {
						Debug.LogError ("nineMenMorris null");
					}
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
				// UIData uiData = data as UIData;
				// Child
				{

				}
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
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.nineMenMorris:
					dirty = true;
					break;
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
}