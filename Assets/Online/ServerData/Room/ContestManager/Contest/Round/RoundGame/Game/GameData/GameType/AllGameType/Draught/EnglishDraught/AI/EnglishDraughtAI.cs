using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class EnglishDraughtAI : Computer.AI
	{

		#region threeMoveRandom

		public VP<bool> threeMoveRandom;

		public void requestChangeThreeMoveRandom(uint userId, bool newThreeMoveRandom){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeThreeMoveRandom (userId, newThreeMoveRandom);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is EnglishDraughtAIIdentity) {
							EnglishDraughtAIIdentity englishDraughtAIIdentity = dataIdentity as EnglishDraughtAIIdentity;
							englishDraughtAIIdentity.requestChangeThreeMoveRandom (userId, newThreeMoveRandom);
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

		public void changeThreeMoveRandom(uint userId, bool newThreeMoveRandom){
			if (isCanRequest (userId)) {
				this.threeMoveRandom.v = newThreeMoveRandom;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region fMaxSeconds

		public VP<float> fMaxSeconds;

		public void requestChangeFMaxSeconds(uint userId, float newFMaxSeconds){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeFMaxSeconds (userId, newFMaxSeconds);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is EnglishDraughtAIIdentity) {
							EnglishDraughtAIIdentity englishDraughtAIIdentity = dataIdentity as EnglishDraughtAIIdentity;
							englishDraughtAIIdentity.requestChangeFMaxSeconds (userId, newFMaxSeconds);
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

		public void changeFMaxSeconds(uint userId, float newFMaxSeconds){
			if (isCanRequest (userId)) {
				this.fMaxSeconds.v = newFMaxSeconds;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region g_MaxDepth

		public VP<System.Int32> g_MaxDepth;

		public void requestChangeGMaxDepth(uint userId, int newGMaxDepth){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeGMaxDepth (userId, newGMaxDepth);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is EnglishDraughtAIIdentity) {
							EnglishDraughtAIIdentity englishDraughtAIIdentity = dataIdentity as EnglishDraughtAIIdentity;
							englishDraughtAIIdentity.requestChangeGMaxDepth (userId, newGMaxDepth);
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

		public void changeGMaxDepth(uint userId, int newGMaxDepth){
			if (isCanRequest (userId)) {
				this.g_MaxDepth.v = newGMaxDepth;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region pickBestMove

		public VP<System.Int32> pickBestMove;

		public void requestChangePickBestMove(uint userId, int newPickBestMove){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changePickBestMove (userId, newPickBestMove);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is EnglishDraughtAIIdentity) {
							EnglishDraughtAIIdentity englishDraughtAIIdentity = dataIdentity as EnglishDraughtAIIdentity;
							englishDraughtAIIdentity.requestChangePickBestMove (userId, newPickBestMove);
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

		public void changePickBestMove(uint userId, int newPickBestMove){
			if (isCanRequest (userId)) {
				this.pickBestMove.v = newPickBestMove;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			threeMoveRandom,
			fMaxSeconds,
			g_MaxDepth,
			pickBestMove
		}

		public EnglishDraughtAI() : base()
		{
			this.threeMoveRandom = new VP<bool> (this, (byte)Property.threeMoveRandom, true);
			this.fMaxSeconds = new VP<float> (this, (byte)Property.fMaxSeconds, 5.0f);
			this.g_MaxDepth = new VP<int> (this, (byte)Property.g_MaxDepth, 15);
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 95);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.EnglishDraught;
		}

	}
}