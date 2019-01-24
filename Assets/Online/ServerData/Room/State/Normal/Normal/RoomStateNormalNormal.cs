using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateNormalNormal : RoomStateNormal.State
{

	#region Constructor

	public enum Property
	{

	}

	public RoomStateNormalNormal() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Normal;
	}

	#region freeze

	public bool isCanFreeze(uint userId)
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

	public void requestFreeze(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.freeze (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is RoomStateNormalNormalIdentity) {
						RoomStateNormalNormalIdentity roomStateNormalNormalIdentity = dataIdentity as RoomStateNormalNormalIdentity;
						roomStateNormalNormalIdentity.requestFreeze(userId);
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

	public void freeze(uint userId)
	{
		if (isCanFreeze (userId)) {
			RoomStateNormal roomStateNormal = this.findDataInParent<RoomStateNormal> ();
			if (roomStateNormal != null) {
				RoomStateNormalFreeze freeze = new RoomStateNormalFreeze ();
				{
					freeze.uid = roomStateNormal.state.makeId ();
				}
				roomStateNormal.state.v = freeze;
			} else {
				Debug.LogError ("roomStateNormal null: " + this);
			}
		} else {
			Debug.LogError ("cannot freeze: " + userId + "; " + this);
		}
	}

	#endregion

}