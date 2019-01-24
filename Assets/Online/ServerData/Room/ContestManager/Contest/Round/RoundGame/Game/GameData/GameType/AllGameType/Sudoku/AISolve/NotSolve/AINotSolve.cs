using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class AINotSolve : AISolve
	{

		#region Constructor

		public enum Property
		{

		}

		public AINotSolve() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.NotSolve;
		}

		public override GameMove getAIMove ()
		{
			return null;
		}

	}
}