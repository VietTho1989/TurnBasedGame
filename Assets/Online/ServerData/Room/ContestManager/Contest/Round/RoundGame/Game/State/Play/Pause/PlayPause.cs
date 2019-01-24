using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayPause : Play.Sub
	{

		public VP<Human> human;

		#region Constructor

		public enum Property
		{
			human
		}

		public PlayPause() : base()
		{
			this.human = new VP<Human> (this, (byte)Property.human, new Human ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Pause;
		}

		#region request unPause

		public void requestUnPause(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.unPause (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is PlayPauseIdentity) {
							PlayPauseIdentity playPauseIdentity = dataIdentity as PlayPauseIdentity;
							playPauseIdentity.requestUnPause (userId);
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

		public void unPause(uint userId){
			if (Play.IsCanChange (this, userId)) {
				Play play = this.findDataInParent<Play>();
				if (play != null) {
					// Chuyen sang unPause
					PlayUnPause playUnPause = new PlayUnPause ();
					{
						playUnPause.uid = play.sub.makeId ();
						// human
						{
							Human human = new Human ();
							{
								human.playerId.v = userId;
							}
							playUnPause.human.v = human;
						}
						// time
						playUnPause.time.v = 0;
						// duration
						playUnPause.duration.v = 3f;
					}
					play.sub.v = playUnPause;
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