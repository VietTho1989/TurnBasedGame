using UnityEngine;
using System.Collections;

namespace Weiqi
{
	public class WeiqiAI : Computer.AI
	{

		#region Property

		#region canResign

		public VP<bool> canResign;

		public void requestChangeCanResign(uint userId, bool newCanResign){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeCanResign (userId, newCanResign);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is WeiqiAIIdentity) {
							WeiqiAIIdentity weiqiAIIdentity = dataIdentity as WeiqiAIIdentity;
							weiqiAIIdentity.requestChangeCanResign (userId, newCanResign);
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

		public void changeCanResign(uint userId, bool newCanResign){
			if (isCanRequest (userId)) {
				this.canResign.v = newCanResign;
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
						if (dataIdentity is WeiqiAIIdentity) {
							WeiqiAIIdentity weiqiAIIdentity = dataIdentity as WeiqiAIIdentity;
							weiqiAIIdentity.requestChangeUseBook (userId, newUseBook);
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

		#region time

		public VP<int> time;

		public void requestChangeTime(uint userId, int newTime){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeTime (userId, newTime);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is WeiqiAIIdentity) {
							WeiqiAIIdentity weiqiAIIdentity = dataIdentity as WeiqiAIIdentity;
							weiqiAIIdentity.requestChangeTime (userId, newTime);
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

		public void changeTime(uint userId, int newTime){
			if (isCanRequest (userId)) {
				this.time.v = newTime;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region games

		public VP<int> games;

		public void requestChangeGames(uint userId, int newGames){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeGames (userId, newGames);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is WeiqiAIIdentity) {
							WeiqiAIIdentity weiqiAIIdentity = dataIdentity as WeiqiAIIdentity;
							weiqiAIIdentity.requestChangeGames (userId, newGames);
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

		public void changeGames(uint userId, int newGames){
			if (isCanRequest (userId)) {
				this.games.v = newGames;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region engine

		public VP<int> engine;

		public void requestChangeEngine(uint userId, int newEngine){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeEngine (userId, newEngine);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is WeiqiAIIdentity) {
							WeiqiAIIdentity weiqiAIIdentity = dataIdentity as WeiqiAIIdentity;
							weiqiAIIdentity.requestChangeEngine (userId, newEngine);
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

		public void changeEngine(uint userId, int newEngine){
			if (isCanRequest (userId)) {
				this.engine.v = newEngine;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#endregion

		#region Constructor

		public enum Property
		{
			canResign,
			useBook,
			time,
			games,
			engine
		}

		public WeiqiAI() : base()
		{
			this.canResign = new VP<bool> (this, (byte)Property.canResign, true);
			this.useBook = new VP<bool> (this, (byte)Property.useBook, false);
			// this.useBook = new VP<bool> (this, (byte)Property.useBook, true);
			this.time = new VP<int> (this, (byte)Property.time, 3000);
			this.games = new VP<int> (this, (byte)Property.games, -1);
			this.engine = new VP<int> (this, (byte)Property.engine, (int)Common.engine_id.E_UCT);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Weiqi;
		}
	}
}