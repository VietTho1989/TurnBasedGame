using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateNormalFreeze : RoomStateNormal.State
{

	#region Constructor

	public enum Property
	{

	}

	public RoomStateNormalFreeze() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Freeze;
	}

	#region unfreeze

	public bool isCanUnFreeze(uint userId)
	{
		bool ret = false;
		{
			RoomUser admin = Room.findAdmin (this);
			if (admin != null) {
				Human human = admin.inform.v;
				if (human != null) {
					if (human.playerId.v == userId) {
						return true;
					}
				} else {
					Debug.LogError ("human null: " + this);
				}
			} else {
				Debug.LogError ("admin null: " + this);
			}
		}
		return ret;
	}

	public void requestUnFreeze(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.unFreeze (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is RoomStateNormalFreezeIdentity) {
						RoomStateNormalFreezeIdentity roomStateNormalFreezeIdentity = dataIdentity as RoomStateNormalFreezeIdentity;
						roomStateNormalFreezeIdentity.requestUnFreeze(userId);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void unFreeze(uint userId)
	{
		if (isCanUnFreeze (userId)) {
			RoomStateNormal roomStateNormal = this.findDataInParent<RoomStateNormal> ();
			if (roomStateNormal != null) {
				RoomStateNormalNormal normal = new RoomStateNormalNormal ();
				{
					normal.uid = roomStateNormal.state.makeId ();
				}
				roomStateNormal.state.v = normal;
			} else {
				Debug.LogError ("roomStateNormal null: " + this);
			}
		} else {
			Debug.LogError ("cannot freeze: " + userId + "; " + this);
		}
	}

	#endregion

}