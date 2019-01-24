using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class SudokuAI : Computer.AI
	{

		#region Constructor

		public enum Property
		{

		}

		public SudokuAI() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Sudoku;
		}

	}
}