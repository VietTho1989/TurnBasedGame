using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateNormalUI : UIBehavior<RoomStateNormalUI.UIData>
{

	#region UIData

	public class UIData : RoomStateUI.UIData.Sub
	{

		public VP<ReferenceData<RoomStateNormal>> roomStateNormal;

		#region Sub

		public abstract class Sub : Data
		{

			public abstract RoomStateNormal.State.Type getType();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			roomStateNormal,
			sub
		}

		public UIData() : base()
		{
			this.roomStateNormal = new VP<ReferenceData<RoomStateNormal>>(this, (byte)Property.roomStateNormal, new ReferenceData<RoomStateNormal>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

		public override Room.State.Type getType ()
		{
			return Room.State.Type.Normal;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RoomStateNormal roomStateNormal = this.data.roomStateNormal.v.data;
				if (roomStateNormal != null) {
					RoomStateNormal.State state = roomStateNormal.state.v;
					if (state != null) {
						switch (state.getType ()) {
						case RoomStateNormal.State.Type.Normal:
							{
								RoomStateNormalNormal normal = state as RoomStateNormalNormal;
								// UIData
								{
									RoomStateNormalNormalUI.UIData normalUIData = this.data.sub.newOrOld<RoomStateNormalNormalUI.UIData> ();
									{
										normalUIData.normal.v = new ReferenceData<RoomStateNormalNormal> (normal);
									}
									this.data.sub.v = normalUIData;
								}
							}
							break;
						case RoomStateNormal.State.Type.Freeze:
							{
								RoomStateNormalFreeze freeze = state as RoomStateNormalFreeze;
								// UIData
								{
									RoomStateNormalFreezeUI.UIData freezeUIData = this.data.sub.newOrOld<RoomStateNormalFreezeUI.UIData> ();
									{
										freezeUIData.freeze.v = new ReferenceData<RoomStateNormalFreeze> (freeze);
									}
									this.data.sub.v = freezeUIData;
								}
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("state null: " + this);
					}
				} else {
					Debug.LogError ("roomStateNormal null: " + this);
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

	public RoomStateNormalNormalUI normalPrefab;
	public RoomStateNormalFreezeUI freezePrefab;
	public Transform subContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.roomStateNormal.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is RoomStateNormal) {
				dirty = true;
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case RoomStateNormal.State.Type.Normal:
						{
							RoomStateNormalNormalUI.UIData normalUIData = sub as RoomStateNormalNormalUI.UIData;
							UIUtils.Instantiate (normalUIData, normalPrefab, subContainer);
						}
						break;
					case RoomStateNormal.State.Type.Freeze:
						{
							RoomStateNormalFreezeUI.UIData freezeUIData = sub as RoomStateNormalFreezeUI.UIData;
							UIUtils.Instantiate (freezeUIData, freezePrefab, subContainer);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
				uiData.roomStateNormal.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is RoomStateNormal) {
				return;
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case RoomStateNormal.State.Type.Normal:
						{
							RoomStateNormalNormalUI.UIData normalUIData = sub as RoomStateNormalNormalUI.UIData;
							normalUIData.removeCallBackAndDestroy (typeof(RoomStateNormalNormalUI));
						}
						break;
					case RoomStateNormal.State.Type.Freeze:
						{
							RoomStateNormalFreezeUI.UIData freezeUIData = sub as RoomStateNormalFreezeUI.UIData;
							freezeUIData.removeCallBackAndDestroy (typeof(RoomStateNormalFreezeUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
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
			case UIData.Property.roomStateNormal:
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
			if (wrapProperty.p is RoomStateNormal) {
				switch ((RoomStateNormal.Property)wrapProperty.n) {
				case RoomStateNormal.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
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