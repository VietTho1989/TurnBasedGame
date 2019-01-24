using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataStateFinish : GameData.State
{

	#region playerResult

	public LP<PlayerResult> playerResults;

	public PlayerResult getPlayerResult(int playerIndex){
		for (int i = 0; i < playerResults.vs.Count; i++) {
			PlayerResult playerResult = playerResults.vs [i];
			if (playerResult.playerIndex.v == playerIndex) {
				return playerResult;
			}
		}
		return null;
	}

	#endregion

	#region Constructor

	public enum Property
	{
		playerResults
	}

	public GameDataStateFinish() : base()
	{
		this.playerResults = new LP<PlayerResult> (this, (byte)Property.playerResults);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Finish;
	}

}