using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class RoundFactory : Data
	{

		public enum Type
		{
			Normal
		}

		public abstract Type getType();

		public abstract int getPlayerCountPerGame();

		public abstract Round makeRound();

		public abstract float getMaxAbleScore();

		public abstract float getMinAbleScore ();

		public abstract GameType.Type getGameTypeType();

	}
}