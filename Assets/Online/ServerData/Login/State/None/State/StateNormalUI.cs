using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
	public class StateNormalUI : UIBehavior<StateNormalUI.UIData>
	{

		#region UIData

		public class UIData : NoneUI.UIData.Sub
		{

			public VP<ReferenceData<StateNormal>> stateNormal;

			#region Constructor

			public enum Property
			{
				stateNormal
			}

			public UIData() : base()
			{
				this.stateNormal = new VP<ReferenceData<StateNormal>>(this, (byte)Property.stateNormal, new ReferenceData<StateNormal>(null));
			}

			#endregion

			public override None.State.Type getType ()
			{
				return None.State.Type.Normal;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					StateNormal stateNormal = this.data.stateNormal.v.data;
					if (stateNormal != null) {

					} else {
						Debug.LogError ("stateNormal null: " + this);
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
					uiData.stateNormal.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is StateNormal) {
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
					uiData.stateNormal.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is StateNormal) {
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
				case UIData.Property.stateNormal:
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
			if (wrapProperty.p is StateNormal) {
				switch ((StateNormal.Property)wrapProperty.n) {
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