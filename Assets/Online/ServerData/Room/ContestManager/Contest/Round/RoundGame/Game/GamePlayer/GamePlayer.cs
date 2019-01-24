using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Danh sach player va vi tri trong 1 duel: co le se ko thay doi khi da set
 * */
public class GamePlayer : Data
{
	public VP<int> playerIndex;

	#region Infor

	public abstract class Inform : Data
	{
		public enum Type
		{
			None,
			Human,
			Computer
		}

		public abstract Type getType ();

		public virtual string getPlayerName ()
		{
			return "Information";
		}

		public static GamePlayer.Inform parse(Type type, string strInform){
			switch (type) {
			case Type.None:
				{
					EmptyInform emptyInform = (EmptyInform)StringSerializationAPI.Deserialize (typeof(EmptyInform), strInform);
					return emptyInform;
				}
			case Type.Human:
				{
					Human human = (Human)StringSerializationAPI.Deserialize (typeof(Human), strInform);
					return human;
				}
			case Type.Computer:
				{
					Computer computer = (Computer)StringSerializationAPI.Deserialize (typeof(Computer), strInform);
					return computer;
				}
			default:
				// Debug.LogError ("unknown type: " + type);
				break;
			}
			return null;
		}

		public bool isCorrectHuman(uint userId)
		{
			if (this.getType () == Type.Human) {
				Human human = this as Human;
				if (human.playerId.v == userId) {
					return true;
				} else {
					// Other human
				}
			}
			return false;
		}
	}

	public VP<Inform> inform;

	public Computer.AI getAI()
	{
		if (inform.v is Computer) {
			Computer computer = inform.v as Computer;
			return computer.ai.v;
		} else {
			Debug.LogError ("Why not computer: "+this);
		}
		return null;
	}

	#endregion

	#region State

	public abstract class State : Data
	{
		public enum Type
		{
			Normal,
			Surrender
		}

		public abstract Type getType ();

	}

	public VP<State> state;

	#endregion

	#region Constructor

	public enum Property
	{
		playerIndex,
		inform,
		state
	}

	public GamePlayer() : base()
	{
		this.playerIndex = new VP<int>(this, (byte)Property.playerIndex, -1);
		this.inform = new VP<Inform> (this, (byte)Property.inform, new EmptyInform ());
		this.state = new VP<State> (this, (byte)Property.state, new GamePlayerStateNormal());
	}

	#endregion

	public static GamePlayer findYourGamePlayer(Data data){
		Game game = data.findDataInParent<Game> ();
		if (game != null) {
			Server server = data.findDataInParent<Server> ();
			if (server != null) {
				for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
					GamePlayer gamePlayer = game.gamePlayers.vs [i];
					if (gamePlayer.inform.v is Human) {
						Human human = gamePlayer.inform.v as Human;
						if (human.playerId.v == server.profileId.v) {
							return gamePlayer;
						}
					}
				}
			} else {
				// Debug.LogError ("server null");
				for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
					GamePlayer gamePlayer = game.gamePlayers.vs [i];
					if (gamePlayer.inform.v is Human) {
						return gamePlayer;
					}
				}
			}
		} else {
			// Debug.LogError ("Cannot find duel");
		}
		return null;
	}
}