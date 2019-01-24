using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestDraw : Data
{

	#region State

	public abstract class State : Data
	{
		public enum Type
		{
			None,
			Ask,
			Accept,
			Cancel
		}

		public abstract Type getType();
	}
	public VP<State> state;

	#endregion

	public VP<long> time;

	#region Constructor

	public enum Property
	{
		state,
		time
	}

	public RequestDraw() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, new RequestDrawStateNone ());
		this.time = new VP<long> (this, (byte)Property.time, Constants.UNKNOWN_TIME);
	}

	#endregion

	public List<uint> getWhoCanAnswer()
	{
		List<uint> ret = new List<uint> ();
		{
			// GamePlayer
			{
				Game game = this.findDataInParent<Game> ();
				if (game != null) {
					for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
						GamePlayer gamePlayer = game.gamePlayers.vs [i];
						if (gamePlayer.inform.v is Human) {
							Human human = gamePlayer.inform.v as Human;
							if (!ret.Contains (human.playerId.v)) {
								ret.Add (human.playerId.v);
							} else {
								Debug.LogError ("already contain: " + human.playerId.v);
							}
						}
					}
				} else {
					Debug.LogError ("duel null");
				}
			}
			// Admin
			{
				if (ret.Count == 0) {
					// need admin
					Room room = this.findDataInParent<Room>();
					if (room != null) {
						RoomUser admin = room.findAdmin ();
						if (admin != null) {
							ret.Add (admin.inform.v.playerId.v);
						} else {
							Debug.LogError ("admin null");
						}
					} else {
						Debug.LogError ("room null");
					}
				}
			}
		}
		return ret;
	}

}