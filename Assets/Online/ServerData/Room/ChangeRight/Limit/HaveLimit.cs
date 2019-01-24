using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
	public class HaveLimit : Limit
	{

		#region limit

		public VP<int> limit;

		public void requestChangeLimit(uint userId, int newLimit){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeLimit (userId, newLimit);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is HaveLimitIdentity) {
							HaveLimitIdentity haveLimitIdentity = dataIdentity as HaveLimitIdentity;
							haveLimitIdentity.requestChangeLimit (userId, newLimit);
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

		public void changeLimit(uint userId, int newLimit){
			if (Room.IsCanEditSetting (this, userId)) {
				this.limit.v = newLimit;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			limit
		}

		public HaveLimit() : base()
		{
			this.limit = new VP<int> (this, (byte)Property.limit, 3);
		}

		#endregion

		public override Type getType ()
		{
			return Type.HaveLimit;
		}

		public override bool isOverLimit (int number)
		{
			return number >= this.limit.v;
		}

	}
}