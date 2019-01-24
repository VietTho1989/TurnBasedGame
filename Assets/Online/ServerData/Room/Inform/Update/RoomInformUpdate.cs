using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomInformUpdate : UpdateBehavior<RoomInform>
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
		if (data is RoomInform) {
			RoomInform roomInform = data as RoomInform;
			// Update
			{
				UpdateUtils.makeUpdate<RoomInformUserCountUpdate, RoomInform> (roomInform, this.transform);
				UpdateUtils.makeUpdate<RoomInformGameTypeUpdate, RoomInform> (roomInform, this.transform);
			}
			// Child
			{
				roomInform.creator.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is Human) {
			Human human = data as Human;
			// Update
			{
				UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RoomInform) {
			RoomInform roomInform = data as RoomInform;
			// Update
			{
				roomInform.removeCallBackAndDestroy (typeof(RoomInformUserCountUpdate));
				roomInform.removeCallBackAndDestroy (typeof(RoomInformGameTypeUpdate));
			}
			// Child
			{
				roomInform.creator.allRemoveCallBack (this);
			}
			this.setDataNull (roomInform);
			return;
		}
		// Child
		if (data is Human) {
			Human human = data as Human;
			// Update
			{
				human.removeCallBackAndDestroy (typeof(HumanUpdate));
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
		if (wrapProperty.p is RoomInform) {
			switch ((RoomInform.Property)wrapProperty.n) {
			case RoomInform.Property.creator:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case RoomInform.Property.userCount:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is Human) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}