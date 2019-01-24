using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class ContestState : Data
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