using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public abstract class AISolve : Data
	{

		public enum Type
		{
			NotSolve,
			HaveSove
		}

		public abstract Type getType ();

		public abstract GameMove getAIMove();

	}
}