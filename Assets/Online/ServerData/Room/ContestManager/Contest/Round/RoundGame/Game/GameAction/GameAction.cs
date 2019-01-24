using UnityEngine;
using System.Collections;

public abstract class GameAction : Data
{
	public enum Type
	{
		ProcessMove,
		StartTurn,
		EndTurn,
		Non,
		UndoRedo,
		WaitInput
	}

	public abstract Type getType ();


}

