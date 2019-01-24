using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateUI : UIBehavior<RoomStateUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Room.State>> roomState;

		#region Sub

		public abstract class Sub : Data
		{

			public abstract Room.State.Type getType();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			roomState,
			sub
		}

		public UIData() : base()
		{
			this.roomState = new VP<ReferenceData<Room.State>>(this, (byte)Property.roomState, new ReferenceData<Room.State>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
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
				Room.State roomState = this.data.roomState.v.data;
				if (roomState != null) {
					switch (roomState.getType ()) {
					case Room.State.Type.Normal:
						{
							RoomStateNormal normal = roomState as RoomStateNormal;
							// UIData
							{
								RoomStateNormalUI.UIData normalUIData = this.data.sub.newOrOld<RoomStateNormalUI.UIData> ();
								{
									normalUIData.roomStateNormal.v = new ReferenceData<RoomStateNormal> (normal);
								}
								this.data.sub.v = normalUIData;
							}
						}
						break;
					case Room.State.Type.End:
						{
							RoomStateEnd end = roomState as RoomStateEnd;
							// UIData
							{
								RoomStateEndUI.UIData endUIData = this.data.sub.newOrOld<RoomStateEndUI.UIData> ();
								{
									endUIData.roomStateEnd.v = new ReferenceData<RoomStateEnd> (end);
								}
								this.data.sub.v = endUIData;
							}
						}
						break;
					default:
						Debug.LogError ("unknown state: " + roomState.getType () + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("roomState null: " + this);
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

	public RoomStateNormalUI normalPrefab;
	public RoomStateEndUI endPrefab;
	public Transform subContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.roomState.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Room.State) {
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Room.State.Type.Normal:
						{
							RoomStateNormalUI.UIData normalUIData = sub as RoomStateNormalUI.UIData;
							UIUtils.Instantiate (normalUIData, normalPrefab, subContainer);
						}
						break;
					case Room.State.Type.End:
						{
							RoomStateEndUI.UIData endUIData = sub as RoomStateEndUI.UIData;
							UIUtils.Instantiate (endUIData, endPrefab, subContainer);
						}
						break;
					default:
						Debug.LogError ("unknown sub: " + sub.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.roomState.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Room.State) {
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case Room.State.Type.Normal:
						{
							RoomStateNormalUI.UIData normalUIData = sub as RoomStateNormalUI.UIData;
							normalUIData.removeCallBackAndDestroy (typeof(RoomStateNormalUI));
						}
						break;
					case Room.State.Type.End:
						{
							RoomStateEndUI.UIData endUIData = sub as RoomStateEndUI.UIData;
							endUIData.removeCallBackAndDestroy (typeof(RoomStateEndUI));
						}
						break;
					default:
						Debug.LogError ("unknown sub: " + sub.getType () + "; " + this);
						break;
					}
				}
				return;
			}
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
			case UIData.Property.roomState:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
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
		{
			if (wrapProperty.p is Room.State) {
				return;
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}