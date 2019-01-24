using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class ChangeGamePlayerRight : Data
	{

		#region canChange

		public VP<bool> canChange;

		public void requestChangeCanChange(uint userId, bool newCanChange)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeCanChange (userId, newCanChange);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ChangeGamePlayerRightIdentity) {
							ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = dataIdentity as ChangeGamePlayerRightIdentity;
							changeGamePlayerRightIdentity.requestChangeCanChange(userId, newCanChange);
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

		public void changeCanChange(uint userId, bool newCanChange)
		{
			if (Room.IsCanEditSetting (this, userId)) {
				this.canChange.v = newCanChange;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region canChangePlayerLeft

		public VP<bool> canChangePlayerLeft;

		public void requestChangeCanChangePlayerLeft(uint userId, bool newCanChangePlayerLeft)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeCanChangePlayerLeft (userId, newCanChangePlayerLeft);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ChangeGamePlayerRightIdentity) {
							ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = dataIdentity as ChangeGamePlayerRightIdentity;
							changeGamePlayerRightIdentity.requestChangeCanChangePlayerLeft(userId, newCanChangePlayerLeft);	
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

		public void changeCanChangePlayerLeft(uint userId, bool newCanChangePlayerLeft)
		{
			if (Room.IsCanEditSetting (this, userId)) {
				this.canChangePlayerLeft.v = newCanChangePlayerLeft;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}


		#endregion

		#region needAdminAccept

		public VP<bool> needAdminAccept;

		public void requestChangeNeedAdminAccept(uint userId, bool newNeedAdminAccept)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeNeedAdminAccept (userId, newNeedAdminAccept);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ChangeGamePlayerRightIdentity) {
							ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = dataIdentity as ChangeGamePlayerRightIdentity;
							changeGamePlayerRightIdentity.requestChangeNeedAdminAccept(userId, newNeedAdminAccept);		
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

		public void changeNeedAdminAccept(uint userId, bool newNeedAdminAccept)
		{
			if (Room.IsCanEditSetting (this, userId)) {
				this.needAdminAccept.v = newNeedAdminAccept;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region onlyAdminNeed

		public VP<bool> onlyAdminNeed;

		public void requestChangeOnlyAdminNeed(uint userId, bool newOnlyAdminNeed)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeOnlyAdminNeed (userId, newOnlyAdminNeed);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ChangeGamePlayerRightIdentity) {
							ChangeGamePlayerRightIdentity changeGamePlayerRightIdentity = dataIdentity as ChangeGamePlayerRightIdentity;
							changeGamePlayerRightIdentity.requestChangeOnlyAdminNeed(userId, newOnlyAdminNeed);		
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

		public void changeOnlyAdminNeed(uint userId, bool newOnlyAdminNeed)
		{
			if (Room.IsCanEditSetting (this, userId)) {
				this.onlyAdminNeed.v = newOnlyAdminNeed;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			canChange,
			canChangePlayerLeft,
			needAdminAccept,
			onlyAdminNeed
		}

		public ChangeGamePlayerRight() : base()
		{
			this.canChange = new VP<bool> (this, (byte)Property.canChange, true);
			this.canChangePlayerLeft = new VP<bool> (this, (byte)Property.canChangePlayerLeft, true);
			this.needAdminAccept = new VP<bool> (this, (byte)Property.needAdminAccept, true);
			this.onlyAdminNeed = new VP<bool> (this, (byte)Property.onlyAdminNeed, false);
		}

		#endregion

	}
}