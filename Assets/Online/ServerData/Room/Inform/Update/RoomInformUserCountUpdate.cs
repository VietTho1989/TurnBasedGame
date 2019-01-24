using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomInformUserCountUpdate : UpdateBehavior<RoomInform>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// userCount
				{
					uint userCount = 0;
					{
						Room room = this.data.findDataInParent<Room> ();
						if (room != null) {
							foreach (RoomUser roomUser in room.users.vs) {
								if (roomUser.isInsideRoom ()) {
									userCount++;
								}
							}
						} else {
							Debug.LogError ("room null: " + this);
						}
					}
					this.data.userCount.v = userCount;
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

	private RoomCheckChangeAdminChange<RoomInform> roomCheckAdminChange = new RoomCheckChangeAdminChange<RoomInform> ();

	public override void onAddCallBack<T> (T data)
	{
		if (data is RoomInform) {
			RoomInform roomInform = data as RoomInform;
			// CheckChange
			{
				roomCheckAdminChange.addCallBack (this);
				roomCheckAdminChange.setData (roomInform);
			}
			dirty = true;
			return;
		}
		// CheckChange
		if (data is RoomCheckChangeAdminChange<RoomInform>) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RoomInform) {
			RoomInform roomInform = data as RoomInform;
			// CheckChange
			{
				roomCheckAdminChange.removeCallBack (this);
				roomCheckAdminChange.setData (null);
			}
			this.setDataNull (roomInform);
			return;
		}
		// CheckChange
		if (data is RoomCheckChangeAdminChange<RoomInform>) {
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
				break;
			case RoomInform.Property.userCount:
				break;
			case RoomInform.Property.isHavePassword:
				break;
			case RoomInform.Property.contestStateType:
				break;
			case RoomInform.Property.gameType:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// CheckChange
		if (wrapProperty.p is RoomCheckChangeAdminChange<RoomInform>) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}