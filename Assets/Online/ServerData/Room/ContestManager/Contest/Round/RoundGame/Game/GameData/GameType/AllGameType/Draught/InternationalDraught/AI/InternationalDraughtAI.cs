using UnityEngine;
using System.Collections;

namespace InternationalDraught
{
	public class InternationalDraughtAI : Computer.AI
	{

		#region Property

		#region bMove

		/** Cai nay co le ko can set, suy nghi sau*/
		public VP<bool> bMove;

		public void requestChangeBMove(uint userId, bool newBMove){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeBMove (userId, newBMove);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangeBMove (userId, newBMove);
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

		public void changeBMove(uint userId, bool newBMove){
			if (isCanRequest (userId)) {
				this.bMove.v = newBMove;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region book

		public VP<bool> book;

		public void requestChangeBook(uint userId, bool newBook){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeBook (userId, newBook);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangeBook (userId, newBook);
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

		public void changeBook(uint userId, bool newBook){
			if (isCanRequest (userId)) {
				this.book.v = newBook;
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
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangeDepth (userId, newDepth);
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

		#region time

		/** time in miliseconds*/
		public VP<float> time;

		public void requestChangeTime(uint userId, float newTime){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeTime (userId, newTime);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangeTime (userId, newTime);
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

		public void changeTime(uint userId, float newTime){
			if (isCanRequest (userId)) {
				this.time.v = newTime;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region input

		/** Cai nay co le ko can set, suy nghi sau*/
		public VP<bool> input;

		public void requestChangeInput(uint userId, bool newInput){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeInput (userId, newInput);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangeInput (userId, newInput);
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

		public void changeInput(uint userId, bool newInput){
			if (isCanRequest (userId)) {
				this.input.v = newInput;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region useEndGameDatabase

		public VP<bool> useEndGameDatabase;

		public void requestChangeUseEndGameDatabase(uint userId, bool newUseEndGameDatabase){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeUseEndGameDatabase (userId, newUseEndGameDatabase);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangeUseEndGameDatabase (userId, newUseEndGameDatabase);
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

		public void changeUseEndGameDatabase(uint userId, bool newUseEndGameDatabase){
			if (isCanRequest (userId)) {
				this.useEndGameDatabase.v = newUseEndGameDatabase;
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
						if (dataIdentity is InternationalDraughtAIIdentity) {
							InternationalDraughtAIIdentity internationalDraughtAIIdentity = dataIdentity as InternationalDraughtAIIdentity;
							internationalDraughtAIIdentity.requestChangePickBestMove (userId, newPickBestMove);
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

		#endregion

		#region Constructor

		public enum Property
		{
			bMove,
			book,
			depth,
			time,
			input,
			useEndGameDatabase,
			pickBestMove
		}

		public InternationalDraughtAI() : base()
		{
			this.bMove = new VP<bool> (this, (byte)Property.bMove, true);
			this.book = new VP<bool> (this, (byte)Property.book, true);
			this.depth = new VP<int> (this, (byte)Property.depth, 15);
			this.time = new VP<float> (this, (byte)Property.time, 50000);
			this.input = new VP<bool> (this, (byte)Property.input, true);
			this.useEndGameDatabase = new VP<bool> (this, (byte)Property.useEndGameDatabase, true);
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 95);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.InternationalDraught;
		}

	}
}