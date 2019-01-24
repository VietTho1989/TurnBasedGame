using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public abstract class State : Data
	{

		public enum Type
		{
			Load,
			Start,
			Play,
			End
		}

		public abstract Type getType();

	}
}