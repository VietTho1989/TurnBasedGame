using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rights;

public class RequestChangeUseRule : Data
{

	#region State

	public abstract class State : Data
	{

		public enum Type
		{
			None,
			Ask
		}

		public abstract Type getType();

	}

	public VP<State> state;

	#endregion

	#region getWhoCanAsk

	public LP<Human> whoCanAsks;

	public HashSet<uint> getWhoCanAsk()
	{
		HashSet<uint> ret = new HashSet<uint> ();
		{
			// find rights
			ChangeUseRuleRight changeUseRuleRight = null;
			{
				Room room = this.findDataInParent<Room> ();
				if (room != null) {
					ChangeRights changeRights = room.changeRights.v;
					if (changeRights != null) {
						changeUseRuleRight = changeRights.changeUseRuleRight.v;
					} else {
						Debug.LogError ("changeRights null: " + this);
					}
				} else {
					Debug.LogError ("room null: " + this);
				}
			}
			// process
			if (changeUseRuleRight != null) {
				if (changeUseRuleRight.canChange.v) {
					if (changeUseRuleRight.onlyAdmin.v) {
						// add admin
						RoomUser admin = Room.findAdmin (this);
						if (admin != null) {
							ret.Add (admin.inform.v.playerId.v);
						} else {
							Debug.LogError ("admin null: " + this);
							ret.Add (0);
						}
					} else {
						// add players
						{
							Game game = this.findDataInParent<Game> ();
							if (game != null) {
								foreach (GamePlayer gamePlayer in game.gamePlayers.vs) {
									if (gamePlayer.inform.v is Human) {
										Human human = gamePlayer.inform.v as Human;
										ret.Add (human.playerId.v);
									}
								}
							} else {
								Debug.LogError ("game null: " + this);
							}
						}
						// add admin
						if (ret.Count == 0 || changeUseRuleRight.needAdmin.v) {
							RoomUser admin = Room.findAdmin (this);
							if (admin != null) {
								ret.Add (admin.inform.v.playerId.v);
							} else {
								Debug.LogError ("admin null: " + this);
								ret.Add (0);
							}
						}
					}
				}
			} else {
				Debug.LogError ("changeUseRuleRight null: " + this);
                ret.Add(0);
            }
		}
		return ret;
	}

	#endregion

	#region Constructor

	public enum Property
	{
		state,
		whoCanAsks
	}

	public RequestChangeUseRule() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, new RequestChangeUseRuleStateNone ());
		this.whoCanAsks = new LP<Human> (this, (byte)Property.whoCanAsks);
	}

	#endregion

}