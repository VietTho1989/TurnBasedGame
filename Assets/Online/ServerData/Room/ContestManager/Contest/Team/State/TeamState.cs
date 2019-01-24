using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class TeamState : Data
	{

		public enum Type
		{
			Normal,
			Surrender
		}

		public abstract Type getType();

	}
}