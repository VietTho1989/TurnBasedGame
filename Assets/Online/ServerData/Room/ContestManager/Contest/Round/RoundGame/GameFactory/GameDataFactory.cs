using UnityEngine;
using System.Collections;

public abstract class GameDataFactory : Data
{
	public enum Type
	{
		Default,
		Posture
	}
	public abstract Type getType ();

	public abstract void initGameData (GameData gameData);

	public abstract GameType.Type getGameTypeType();

}

