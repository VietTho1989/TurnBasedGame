using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class ContestManagerContent : Data
	{

		public enum Type
		{
			Single,
			RoundRobin,
			Elimination
		}

		public abstract Type getType();

		public abstract class UIData : Data
		{

			public abstract Type getType();

			public abstract bool processEvent(Event e);

		}

		public abstract ContestManagerContentFactory makeContentFactory();

		public abstract GameType.Type getGameTypeType();

	}
}