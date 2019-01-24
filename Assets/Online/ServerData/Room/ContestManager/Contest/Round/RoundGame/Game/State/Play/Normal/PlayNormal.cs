using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayNormal : Play.Sub
	{

		#region Constructor

		public enum Property
		{

		}

		public PlayNormal() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Normal;
		}

		#region request pause

		public void requestPause(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.pause (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is PlayNormalIdentity) {
							PlayNormalIdentity playNormalIdentity = dataIdentity as PlayNormalIdentity;
							playNormalIdentity.requestPause (userId);
						} else {
							Debug.LogError ("Why not correct identity: " + this);
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request");
			}
		}

		public void pause(uint userId){
			if (Play.IsCanChange (this, userId)) {
				Play play = this.findDataInParent<Play>();
				if (play != null) {
					PlayPause playPause = new PlayPause ();
					{
						playPause.uid = play.sub.makeId ();
						// human
						{
							playPause.human.v.playerId.v = userId;
						}
					}
					play.sub.v = playPause;
				} else {
					Debug.LogError ("play null: " + this);
				}
			} else {
				Debug.LogError ("Cannot change: " + userId);
			}
		}

		#endregion

	}
}