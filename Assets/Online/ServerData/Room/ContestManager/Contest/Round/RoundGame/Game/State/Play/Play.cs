using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class Play : State
	{

		#region Sub

		public abstract class Sub : Data
		{

			public enum Type
			{
				Normal,
				Pause,
				UnPause
			}

			public abstract Type getType();

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			sub
		}

		public Play() : base()
		{
			this.sub = new VP<Sub> (this, (byte)Property.sub, new PlayNormal ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

		#region can change

		public List<uint> getWhoCanChange()
		{
			List<uint> ret = new List<uint> ();
			{
				// find gamePlayers
				{
					Game game = this.findDataInParent<Game> ();
					if (game != null) {
						for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
							GamePlayer gamePlayer = game.gamePlayers.vs [i];
							if (gamePlayer.inform.v != null && gamePlayer.inform.v is Human) {
								Human human = gamePlayer.inform.v as Human;
								if (!ret.Contains (human.playerId.v)) {
									ret.Add (human.playerId.v);
								}
							}
						}
					} else {
						Debug.LogError ("game null: " + this);
					}
				}
				// Add admin
				{
					RoomUser admin = Room.findAdmin (this);
					if (admin != null) {
						Human human = admin.inform.v;
						if (human != null) {
							if (!ret.Contains (human.playerId.v)) {
								ret.Add (human.playerId.v);
							}
						} else {
							Debug.LogError ("human null: " + this);
						}
					} else {
						Debug.LogError ("admin null: " + this);
					}
				}
			}
			return ret;
		}

		public static bool IsCanChange(Data data, uint userId)
		{
			bool ret = false;
			{
				if (data != null) {
					Play play = data.findDataInParent<Play> ();
					if (play != null) {
						if (play.getWhoCanChange ().Contains (userId)) {
							ret = true;
						}
					} else {
						Debug.LogError ("play null: " + data);
					}
				} else {
					Debug.LogError ("data null: " + data);
				}
			}
			return ret;
		}

		#endregion

	}

}