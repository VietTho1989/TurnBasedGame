using UnityEngine;
using System.Collections;

namespace Gomoku
{
	public class GomokuAI : Computer.AI
	{

		#region Property

		#region SearchDepth

		public VP<int> searchDepth;// = 8;

		public void requestChangeSearchDepth(uint userId, int newSearchDepth){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeSearchDepth (userId, newSearchDepth);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is GomokuAIIdentity) {
							GomokuAIIdentity gomokuAIIdentity = dataIdentity as GomokuAIIdentity;
							gomokuAIIdentity.requestChangeSearchDepth (userId, newSearchDepth);
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

		public void changeSearchDepth(uint userId, int newSearchDepth){
			if (isCanRequest (userId)) {
				this.searchDepth.v = newSearchDepth;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}
			
		#endregion

		#region timeLimit

		public VP<int> timeLimit;// = 10000;

		public void requestChangeTimeLimit(uint userId, int newTimeLimit){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeTimeLimit (userId, newTimeLimit);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is GomokuAIIdentity) {
							GomokuAIIdentity gomokuAIIdentity = dataIdentity as GomokuAIIdentity;
							gomokuAIIdentity.requestChangeTimeLimit (userId, newTimeLimit);
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

		public void changeTimeLimit(uint userId, int newTimeLimit){
			if (isCanRequest (userId)) {
				this.timeLimit.v = newTimeLimit;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region level

		/** 0 -> 20*/
		public VP<int> level;// = 12;

		public void requestChangeLevel(uint userId, int newLevel){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeLevel (userId, newLevel);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is GomokuAIIdentity) {
							GomokuAIIdentity gomokuAIIdentity = dataIdentity as GomokuAIIdentity;
							gomokuAIIdentity.requestChangeLevel (userId, newLevel);
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

		public void changeLevel(uint userId, int newLevel){
			if (isCanRequest (userId)) {
				this.level.v = newLevel;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#endregion

		#region Constructor

		public enum Property
		{
			searchDepth,
			timeLimit,
			level
		}

		public GomokuAI() : base()
		{
			this.searchDepth = new VP<int> (this, (byte)Property.searchDepth, 8);
			this.timeLimit = new VP<int> (this, (byte)Property.timeLimit, 10000);
			this.level = new VP<int> (this, (byte)Property.level, 12);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Gomoku;
		}
	}
}