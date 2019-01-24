using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class RoomContainer : Data
{

	public enum Type
	{
		Global,
		Limit
	}

	public abstract Type getType();

	public abstract List<GameType.Type> getGameTypes ();

}