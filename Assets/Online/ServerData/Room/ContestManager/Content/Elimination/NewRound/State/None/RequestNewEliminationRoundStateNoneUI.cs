using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundStateNoneUI : UIBehavior<RequestNewEliminationRoundStateNoneUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewEliminationRoundUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewEliminationRoundStateNone>> requestNewEliminationRoundStateNone;

			#region Constructor

			public enum Property
			{
				requestNewEliminationRoundStateNone
			}

			public UIData() : base()
			{
				this.requestNewEliminationRoundStateNone = new VP<ReferenceData<RequestNewEliminationRoundStateNone>>(this, (byte)Property.requestNewEliminationRoundStateNone, new ReferenceData<RequestNewEliminationRoundStateNone>(null));
			}

			#endregion

			public override RequestNewEliminationRound.State.Type getType ()
			{
				return RequestNewEliminationRound.State.Type.None;
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
					RequestNewEliminationRoundStateNone requestNewEliminationRoundStateNone = this.data.requestNewEliminationRoundStateNone.v.data;
					if (requestNewEliminationRoundStateNone != null) {

					} else {
						Debug.LogError ("requestNewEliminationRoundStateNone null: " + this);
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
					uiData.requestNewEliminationRoundStateNone.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewEliminationRoundStateNone) {
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
					uiData.requestNewEliminationRoundStateNone.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RequestNewEliminationRoundStateNone) {
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
				case UIData.Property.requestNewEliminationRoundStateNone:
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
			if (wrapProperty.p is RequestNewEliminationRoundStateNone) {
				switch ((RequestNewEliminationRoundStateNone.Property)wrapProperty.n) {
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