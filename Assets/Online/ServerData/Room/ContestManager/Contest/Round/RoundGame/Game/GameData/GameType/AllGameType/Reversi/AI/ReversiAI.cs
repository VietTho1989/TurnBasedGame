using UnityEngine;
using System.Collections;

namespace Reversi
{
	public class ReversiAI : Computer.AI
	{

		#region Property

		#region sort

		public VP<int> sort;

		public void requestChangeSort(uint userId, int newSort){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeSort (userId, newSort);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangeSort (userId, newSort);
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

		public void changeSort(uint userId, int newSort){
			if (isCanRequest (userId)) {
				this.sort.v = newSort;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region min

		public VP<int> min;

		public void requestChangeMin(uint userId, int newMin){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMin (userId, newMin);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangeMin (userId, newMin);
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

		public void changeMin(uint userId, int newMin){
			if (isCanRequest (userId)) {
				this.min.v = newMin;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region max

		public VP<int> max;

		public void requestChangeMax(uint userId, int newMax){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMax (userId, newMax);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangeMax (userId, newMax);
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

		public void changeMax(uint userId, int newMax){
			if (isCanRequest (userId)) {
				this.max.v = newMax;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region end

		public VP<int> end;

		public void requestChangeEnd(uint userId, int newEnd){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeEnd (userId, newEnd);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangeEnd (userId, newEnd);
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

		public void changeEnd(uint userId, int newEnd){
			if (isCanRequest (userId)) {
				this.end.v = newEnd;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region msLeft

		public VP<int> msLeft;

		public void requestChangeMsLeft(uint userId, int newMsLeft){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMsLeft (userId, newMsLeft);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangeMsLeft (userId, newMsLeft);
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

		public void changeMsLeft(uint userId, int newMsLeft){
			if (isCanRequest (userId)) {
				this.msLeft.v = newMsLeft;
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
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangeUseBook (userId, newUseBook);
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

		#region percent

		public VP<int> percent;

		public void requestChangePercent(uint userId, int newPercent){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changePercent (userId, newPercent);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ReversiAIIdentity) {
							ReversiAIIdentity reversiAIIdentity = dataIdentity as ReversiAIIdentity;
							reversiAIIdentity.requestChangePercent (userId, newPercent);
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

		public void changePercent(uint userId, int newPercent){
			if (isCanRequest (userId)) {
				this.percent.v = newPercent;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#endregion

		#region Constructor

		public enum Property
		{
			sort,
			min,
			max,
			end,
			msLeft,
			useBook,
			percent
		}

		public ReversiAI() : base()
		{
			this.sort = new VP<int> (this, (byte)Property.sort, 4);
			this.min = new VP<int> (this, (byte)Property.min, 10);
			this.max = new VP<int> (this, (byte)Property.max, 15);
			this.end = new VP<int> (this, (byte)Property.end, 22);
			this.msLeft = new VP<int> (this, (byte)Property.msLeft, 20 * 10000);
			this.useBook = new VP<bool> (this, (byte)Property.useBook, false);
			this.percent = new VP<int> (this, (byte)Property.percent, 95);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Reversi;
		}
	}
}