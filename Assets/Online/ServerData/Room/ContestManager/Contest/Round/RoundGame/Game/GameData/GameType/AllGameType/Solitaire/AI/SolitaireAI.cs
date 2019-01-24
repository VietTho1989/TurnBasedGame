using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireAI : Computer.AI
	{

		#region multiThreaded

		public VP<int> multiThreaded;

		public void requestChangeMultiThreaded(uint userId, int newMultiThreaded){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMultiThreaded (userId, newMultiThreaded);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SolitaireAIIdentity) {
							SolitaireAIIdentity solitaireAIIdentity = dataIdentity as SolitaireAIIdentity;
							solitaireAIIdentity.requestChangeMultiThreaded (userId, newMultiThreaded);
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

		public void changeMultiThreaded(uint userId, int newMultiThreaded){
			if (isCanRequest (userId)) {
				this.multiThreaded.v = newMultiThreaded;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region maxClosedCount

		public VP<int> maxClosedCount;

		public void requestChangeMaxClosedCount(uint userId, int newMaxClosedCount){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxClosedCount (userId, newMaxClosedCount);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SolitaireAIIdentity) {
							SolitaireAIIdentity solitaireAIIdentity = dataIdentity as SolitaireAIIdentity;
							solitaireAIIdentity.requestChangeMaxClosedCount (userId, newMaxClosedCount);
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

		public void changeMaxClosedCount(uint userId, int newMaxClosedCount){
			if (isCanRequest (userId)) {
				this.maxClosedCount.v = newMaxClosedCount;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region fastMode

		public VP<bool> fastMode;

		public void requestChangeFastMode(uint userId, bool newFastMode){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeFastMode (userId, newFastMode);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SolitaireAIIdentity) {
							SolitaireAIIdentity solitaireAIIdentity = dataIdentity as SolitaireAIIdentity;
							solitaireAIIdentity.requestChangeFastMode (userId, newFastMode);
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

		public void changeFastMode(uint userId, bool newFastMode){
			if (isCanRequest (userId)) {
				this.fastMode.v = newFastMode;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			multiThreaded,
			maxClosedCount,
			fastMode
		}

		public SolitaireAI() : base()
		{
			this.multiThreaded = new VP<int> (this, (byte)Property.multiThreaded, 0);
			this.maxClosedCount = new VP<int> (this, (byte)Property.maxClosedCount, 0);
			this.fastMode = new VP<bool> (this, (byte)Property.fastMode, true);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Solitaire;
		}

	}
}