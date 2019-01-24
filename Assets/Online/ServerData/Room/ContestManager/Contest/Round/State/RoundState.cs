using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class RoundState : Data
	{

		public enum Type
		{
			Load,
			Start,
			Play,
			End
		}

		public abstract Type getType();

		public abstract class UIData : Data
		{

			public abstract Type getType();

		}

	}
}