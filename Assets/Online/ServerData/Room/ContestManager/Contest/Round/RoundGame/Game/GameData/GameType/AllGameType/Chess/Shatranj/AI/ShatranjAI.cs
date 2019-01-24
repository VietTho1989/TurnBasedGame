using UnityEngine;
using System.Collections;

namespace Shatranj
{
	public class ShatranjAI : Computer.AI
	{
		#region Property

		#region depth

		public VP<int> depth;// = 15;

		public void requestChangeDepth(uint userId, int newDepth){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeDepth (userId, newDepth);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ShatranjAIIdentity) {
							ShatranjAIIdentity shatranjAIIdentity = dataIdentity as ShatranjAIIdentity;
							shatranjAIIdentity.requestChangeDepth (userId, newDepth);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeDepth(uint userId, int newDepth){
			if (isCanRequest (userId)) {
				this.depth.v = newDepth;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region skillLevel

		public VP<int> skillLevel;// = 19;

		public void requestChangeSkillLevel(uint userId, int newSkillLevel){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeSkillLevel (userId, newSkillLevel);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ShatranjAIIdentity) {
							ShatranjAIIdentity shatranjAIIdentity = dataIdentity as ShatranjAIIdentity;
							shatranjAIIdentity.requestChangeSkillLevel (userId, newSkillLevel);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeSkillLevel(uint userId, int newSkillLevel){
			if (isCanRequest (userId)) {
				this.skillLevel.v = newSkillLevel;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region duration

		public VP<long> duration;// = 10000;

		public void requestChangeDuration(uint userId, long newDuration){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeDuration (userId, newDuration);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ShatranjAIIdentity) {
							ShatranjAIIdentity shatranjAIIdentity = dataIdentity as ShatranjAIIdentity;
							shatranjAIIdentity.requestChangeDuration (userId, newDuration);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeDuration(uint userId, long newDuration){
			if (isCanRequest (userId)) {
				this.duration.v = newDuration;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#endregion

		#region Constructor

		public enum Property
		{
			depth,
			skillLevel,
			duration
		}

		public ShatranjAI() : base()
		{
			this.depth = new VP<int> (this, (byte)Property.depth, 15);
			this.skillLevel = new VP<int> (this, (byte)Property.skillLevel, 19);
			this.duration = new VP<long> (this, (byte)Property.duration, 5000);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Shatranj;
		}
	}
}