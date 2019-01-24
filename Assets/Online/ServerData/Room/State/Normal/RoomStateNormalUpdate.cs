using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateNormalUpdate : UpdateBehavior<RoomStateNormal>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

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
		if (data is RoomStateNormal) {
			RoomStateNormal roomStateNormal = data as RoomStateNormal;
			// Child
			{
				roomStateNormal.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is RoomStateNormal.State) {
			RoomStateNormal.State state = data as RoomStateNormal.State;
			// Update
			{
				switch (state.getType ()) {
				case RoomStateNormal.State.Type.Normal:
					{
						RoomStateNormalNormal roomStateNormalNormal = state as RoomStateNormalNormal;
						UpdateUtils.makeUpdate<RoomStateNormalNormalUpdate, RoomStateNormalNormal> (roomStateNormalNormal, this.transform);
					}
					break;
				case RoomStateNormal.State.Type.Freeze:
					{
						RoomStateNormalFreeze roomStateNormalFreeze = state as RoomStateNormalFreeze;
						UpdateUtils.makeUpdate<RoomStateNormalFreezeUpdate, RoomStateNormalFreeze> (roomStateNormalFreeze, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
		if (data is RoomStateNormal) {
			RoomStateNormal roomStateNormal = data as RoomStateNormal;
			// Child
			{
				roomStateNormal.state.allRemoveCallBack (this);
			}
			this.setDataNull (roomStateNormal);
			return;
		}
		// Child
		if (data is RoomStateNormal.State) {
			RoomStateNormal.State state = data as RoomStateNormal.State;
			// Update
			{
				switch (state.getType ()) {
				case RoomStateNormal.State.Type.Normal:
					{
						RoomStateNormalNormal roomStateNormalNormal = state as RoomStateNormalNormal;
						roomStateNormalNormal.removeCallBackAndDestroy (typeof(RoomStateNormalNormalUpdate));
					}
					break;
				case RoomStateNormal.State.Type.Freeze:
					{
						RoomStateNormalFreeze roomStateNormalFreeze = state as RoomStateNormalFreeze;
						roomStateNormalFreeze.removeCallBackAndDestroy (typeof(RoomStateNormalFreezeUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
		if (wrapProperty.p is RoomStateNormal) {
			switch ((RoomStateNormal.Property)wrapProperty.n) {
			case RoomStateNormal.Property.state:
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
		if (wrapProperty.p is RoomStateNormal.State) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}