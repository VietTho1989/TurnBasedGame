using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class DefaultSolitaire : DefaultGameType
	{

		#region drawCount

		public VP<int> drawCount;

		public void requestChangeDrawCount(uint userId, int newDrawCount){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeDrawCount (userId, newDrawCount);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is DefaultSolitaireIdentity) {
							DefaultSolitaireIdentity defaultSolitaireIdentity = dataIdentity as DefaultSolitaireIdentity;
							defaultSolitaireIdentity.requestChangeDrawCount (userId, newDrawCount);
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

		public void changeDrawCount(uint userId, int newDrawCount){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.drawCount.v = newDrawCount;
			} else {
				Debug.LogError ("cannot change config: " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			drawCount
		}

		public DefaultSolitaire() : base()
		{
			this.drawCount = new VP<int> (this, (byte)Property.drawCount, 1);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Solitaire;
		}

		public override GameType makeDefaultGameType ()
		{
			Solitaire solitaire = Core.unityMakeDefaultPosition (this.drawCount.v);
			Debug.LogError ("make default solitaire: " + solitaire.drawCount.v + "; " + this.drawCount.v);
			return solitaire;
		}

	}
}