using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
	public class ShowPhasePlayingUI : UIBehavior<ShowPhasePlayingUI.UIData>
	{

		#region UIData

		public class UIData : ShowUI.UIData.Sub
		{

			#region Sub

			public abstract class Sub : Data
			{

				public enum Type
				{
					ClickFrom,
					ClickDest,
					ClickRemove
				}

				public abstract Type getType();

				public abstract bool processEvent(Event e);

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				sub
			}

			public UIData() : base()
			{
				this.sub = new VP<Sub>(this, (byte)Property.sub, new ShowPhasePlayingFromUI.UIData());
			}

			#endregion

			public override Type getType ()
			{
				return Type.Playing;
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

		public ShowPhasePlayingFromUI fromPrefab;
		public ShowPhasePlayingDestUI destPrefab;
		public ShowPhasePlayingRemoveUI removePrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.ClickFrom:
						{
							ShowPhasePlayingFromUI.UIData fromUIData = sub as ShowPhasePlayingFromUI.UIData;
							UIUtils.Instantiate (fromUIData, fromPrefab, this.transform);
						}
						break;
					case UIData.Sub.Type.ClickDest:
						{
							ShowPhasePlayingDestUI.UIData destUIData = sub as ShowPhasePlayingDestUI.UIData;
							UIUtils.Instantiate (destUIData, destPrefab, this.transform);
						}
						break;
					case UIData.Sub.Type.ClickRemove:
						{
							ShowPhasePlayingRemoveUI.UIData removeUIData = sub as ShowPhasePlayingRemoveUI.UIData;
							UIUtils.Instantiate (removeUIData, removePrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType ());
						break;
					}
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
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.ClickFrom:
						{
							ShowPhasePlayingFromUI.UIData fromUIData = sub as ShowPhasePlayingFromUI.UIData;
							fromUIData.removeCallBackAndDestroy (typeof(ShowPhasePlayingFromUI));
						}
						break;
					case UIData.Sub.Type.ClickDest:
						{
							ShowPhasePlayingDestUI.UIData destUIData = sub as ShowPhasePlayingDestUI.UIData;
							destUIData.removeCallBackAndDestroy (typeof(ShowPhasePlayingDestUI));
						}
						break;
					case UIData.Sub.Type.ClickRemove:
						{
							ShowPhasePlayingRemoveUI.UIData removeUIData = sub as ShowPhasePlayingRemoveUI.UIData;
							removeUIData.removeCallBackAndDestroy (typeof(ShowPhasePlayingRemoveUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType ());
						break;
					}
				}
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
				case UIData.Property.sub:
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
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}


		#endregion

	}
}