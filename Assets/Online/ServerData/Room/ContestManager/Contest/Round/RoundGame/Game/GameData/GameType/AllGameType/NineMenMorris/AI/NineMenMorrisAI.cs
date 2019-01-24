using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NineMenMorrisAI : Computer.AI
	{

		#region maxNormal

		public VP<int> MaxNormal;

		public void requestChangeMaxNormal(uint userId, int newMaxNormal){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxNormal (userId, newMaxNormal);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NineMenMorrisAIIdentity) {
							NineMenMorrisAIIdentity nineMenMorrisAIIdentity = dataIdentity as NineMenMorrisAIIdentity;
							nineMenMorrisAIIdentity.requestChangeMaxNormal (userId, newMaxNormal);
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

		public void changeMaxNormal(uint userId, int newMaxNormal){
			if (isCanRequest (userId)) {
				this.MaxNormal.v = newMaxNormal;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region maxPositioning

		public VP<int> MaxPositioning;

		public void requestChangeMaxPositioning(uint userId, int newMaxPositioning){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxPositioning (userId, newMaxPositioning);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NineMenMorrisAIIdentity) {
							NineMenMorrisAIIdentity nineMenMorrisAIIdentity = dataIdentity as NineMenMorrisAIIdentity;
							nineMenMorrisAIIdentity.requestChangeMaxPositioning (userId, newMaxPositioning);
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

		public void changeMaxPositioning(uint userId, int newMaxPositioning){
			if (isCanRequest (userId)) {
				this.MaxPositioning.v = newMaxPositioning;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region maxBlackAndWhite3

		public VP<int> MaxBlackAndWhite3;

		public void requestChangeMaxBlackAndWhite3(uint userId, int newMaxBlackAndWhite3){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxBlackAndWhite3 (userId, newMaxBlackAndWhite3);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NineMenMorrisAIIdentity) {
							NineMenMorrisAIIdentity nineMenMorrisAIIdentity = dataIdentity as NineMenMorrisAIIdentity;
							nineMenMorrisAIIdentity.requestChangeMaxBlackAndWhite3 (userId, newMaxBlackAndWhite3);
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

		public void changeMaxBlackAndWhite3(uint userId, int newMaxBlackAndWhite3){
			if (isCanRequest (userId)) {
				this.MaxBlackAndWhite3.v = newMaxBlackAndWhite3;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region maxBlackOrWhite3

		public VP<int> MaxBlackOrWhite3;

		public void requestChangeMaxBlackOrWhite3(uint userId, int newMaxBlackOrWhite3){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxBlackOrWhite3 (userId, newMaxBlackOrWhite3);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NineMenMorrisAIIdentity) {
							NineMenMorrisAIIdentity nineMenMorrisAIIdentity = dataIdentity as NineMenMorrisAIIdentity;
							nineMenMorrisAIIdentity.requestChangeMaxBlackOrWhite3 (userId, newMaxBlackOrWhite3);
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

		public void changeMaxBlackOrWhite3(uint userId, int newMaxBlackOrWhite3){
			if (isCanRequest (userId)) {
				this.MaxBlackOrWhite3.v = newMaxBlackOrWhite3;
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
						if (dataIdentity is NineMenMorrisAIIdentity) {
							NineMenMorrisAIIdentity nineMenMorrisAIIdentity = dataIdentity as NineMenMorrisAIIdentity;
							nineMenMorrisAIIdentity.requestChangePickBestMove (userId, newPickBestMove);
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
			MaxNormal,
			MaxPositioning,
			MaxBlackAndWhite3,
			MaxBlackOrWhite3,
			pickBestMove
		}

		public NineMenMorrisAI() : base()
		{
			this.MaxNormal = new VP<int> (this, (byte)Property.MaxNormal, 3);
			this.MaxPositioning = new VP<int> (this, (byte)Property.MaxPositioning, 3);
			this.MaxBlackAndWhite3 = new VP<int> (this, (byte)Property.MaxBlackAndWhite3, 3);
			this.MaxBlackOrWhite3 = new VP<int> (this, (byte)Property.MaxBlackOrWhite3, 3);
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 90);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.NineMenMorris;
		}

	}
}