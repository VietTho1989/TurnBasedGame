using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class DefaultEnglishDraught : DefaultGameType
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
						if (dataIdentity is DefaultEnglishDraughtIdentity) {
							DefaultEnglishDraughtIdentity defaultEnglishDraughtIdentity = dataIdentity as DefaultEnglishDraughtIdentity;
							defaultEnglishDraughtIdentity.requestChangeThreeMoveRandom (userId, newThreeMoveRandom);
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
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.threeMoveRandom.v = newThreeMoveRandom;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion
		
		#region maxPly

		public VP<int> maxPly;

		public void requestChangeMaxPly(uint userId, int newMaxPly){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxPly (userId, newMaxPly);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultEnglishDraughtIdentity) {
							DefaultEnglishDraughtIdentity defaultEnglishDraughtIdentity = dataIdentity as DefaultEnglishDraughtIdentity;
							defaultEnglishDraughtIdentity.requestChangeMaxPly (userId, newMaxPly);
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

		public void changeMaxPly(uint userId, int newMaxPly){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.maxPly.v = newMaxPly;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			threeMoveRandom,
			maxPly
		}

		public DefaultEnglishDraught() : base()
		{
			this.threeMoveRandom = new VP<bool> (this, (byte)Property.threeMoveRandom, false);
			this.maxPly = new VP<int> (this, (byte)Property.maxPly, 100);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.EnglishDraught;
		}

		public override GameType makeDefaultGameType ()
		{
			EnglishDraught englishDraught = Core.unityMakeDefaultPosition (EnglishDraught.StartFen, this.maxPly.v);
			// threeMoveRandom
			{
				if (this.threeMoveRandom.v) {
					for (int i = 0; i < 3; i++) {
						List<EnglishDraughtMove> moves = Core.unityGetLegalMoves (englishDraught, Core.CanCorrect);
						if (moves.Count > 0) {
							int randomIdex = Random.Range (0, moves.Count);
							if (randomIdex >= 0 && randomIdex < moves.Count) {
								EnglishDraughtMove move = moves [randomIdex];
								englishDraught = Core.unityDoMove (englishDraught, Core.CanCorrect, move);
							} else {
								Debug.LogError ("randomIndex error: " + randomIdex + "; " + moves.Count + "; " + this);
							}
						} else {
							Debug.LogError ("why moves count = 0: " + this);
						}
					}
				}
			}
			return englishDraught;
		}

	}
}