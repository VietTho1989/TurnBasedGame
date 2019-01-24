using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class KhetAI : Computer.AI
	{

		#region infinite

		public VP<bool> infinite;

		public void requestChangeInfinite(uint userId, bool newInfinite){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeInfinite (userId, newInfinite);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is KhetAIIdentity) {
							KhetAIIdentity khetAIIdentity = dataIdentity as KhetAIIdentity;
							khetAIIdentity.requestChangeInfinite (userId, newInfinite);
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

		public void changeInfinite(uint userId, bool newInfinite){
			if (isCanRequest (userId)) {
				this.infinite.v = newInfinite;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region moveTime

		public VP<int> moveTime;

		public void requestChangeMoveTime(uint userId, int newMoveTime){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMoveTime (userId, newMoveTime);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is KhetAIIdentity) {
							KhetAIIdentity khetAIIdentity = dataIdentity as KhetAIIdentity;
							khetAIIdentity.requestChangeMoveTime (userId, newMoveTime);
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

		public void changeMoveTime(uint userId, int newMoveTime){
			if (isCanRequest (userId)) {
				this.moveTime.v = newMoveTime;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region depth

		public VP<int> depth;

		public void requestChangeDepth(uint userId, int newDepth){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeDepth (userId, newDepth);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is KhetAIIdentity) {
							KhetAIIdentity khetAIIdentity = dataIdentity as KhetAIIdentity;
							khetAIIdentity.requestChangeDepth (userId, newDepth);
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

		#region pickBestMove

		public VP<int> pickBestMove;

		public void requestChangePickBestMove(uint userId, int newPickBestMove){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changePickBestMove (userId, newPickBestMove);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is KhetAIIdentity) {
							KhetAIIdentity khetAIIdentity = dataIdentity as KhetAIIdentity;
							khetAIIdentity.requestChangePickBestMove (userId, newPickBestMove);
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
			infinite,
			moveTime,
			depth,
			pickBestMove
		}

		public KhetAI() : base()
		{
			this.infinite = new VP<bool> (this, (byte)Property.infinite, false);
			this.moveTime = new VP<int> (this, (byte)Property.moveTime, 10000);
			this.depth = new VP<int> (this, (byte)Property.depth, 0);
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 90);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Khet;
		}

	}
}