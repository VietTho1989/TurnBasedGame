using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiAI : Computer.AI
	{

		#region Property

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
						if (dataIdentity is XiangqiAIIdentity) {
							XiangqiAIIdentity xiangqiAIIdentity = dataIdentity as XiangqiAIIdentity;
							xiangqiAIIdentity.requestChangeDepth (userId, newDepth);
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

		#region thinkTime

		public VP<int> thinkTime;

		public void requestChangeThinkTime(uint userId, int newThinkTime){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeThinkTime (userId, newThinkTime);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is XiangqiAIIdentity) {
							XiangqiAIIdentity xiangqiAIIdentity = dataIdentity as XiangqiAIIdentity;
							xiangqiAIIdentity.requestChangeThinkTime (userId, newThinkTime);
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

		public void changeThinkTime(uint userId, int newThinkTime){
			if (isCanRequest (userId)) {
				this.thinkTime.v = newThinkTime;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region useBook

		public VP<bool> useBook;

		public void requestChangeUseBook(uint userId, bool newUseBook){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeUseBook (userId, newUseBook);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is XiangqiAIIdentity) {
							XiangqiAIIdentity xiangqiAIIdentity = dataIdentity as XiangqiAIIdentity;
							xiangqiAIIdentity.requestChangeUseBook (userId, newUseBook);
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

		public void changeUseBook(uint userId, bool newUseBook){
			if (isCanRequest (userId)) {
				this.useBook.v = newUseBook;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		public VP<int> pickBestMove;

		public void requestChangePickBestMove(uint userId, int newPickBestMove){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changePickBestMove (userId, newPickBestMove);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is XiangqiAIIdentity) {
							XiangqiAIIdentity xiangqiAIIdentity = dataIdentity as XiangqiAIIdentity;
							xiangqiAIIdentity.requestChangePickBestMove (userId, newPickBestMove);
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
			depth,
			thinkTime,
			useBook,
			pickBestMove
		}

		public XiangqiAI() : base()
		{
			this.depth = new VP<int> (this, (byte)Property.depth, 10);
			this.thinkTime = new VP<int> (this, (byte)Property.thinkTime, 5000);
			this.useBook = new VP<bool> (this, (byte)Property.useBook, true);
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 90);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Xiangqi;
		}
	}
}