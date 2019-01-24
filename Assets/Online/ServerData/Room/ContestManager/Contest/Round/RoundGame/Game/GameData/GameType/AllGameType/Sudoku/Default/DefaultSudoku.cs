using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using org.mariuszgromada.math.janetsudoku;

namespace Sudoku
{
	public class DefaultSudoku : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultSudoku() : base()
		{

		}

		#endregion

		public override GameType.Type getType()
		{
			return GameType.Type.Sudoku;
		}

		public override GameType makeDefaultGameType()
		{
			Sudoku sudoku = new Sudoku ();
			{
				// board
				{
					SudokuGenerator generator = new SudokuGenerator (SudokuGenerator.PARAM_GEN_RND_BOARD);
					// setGeneratorOptions
					{
						generator.enableRndSeedOnFilledCells ();
					}
					// generate
					int[,] generated = generator.generate();
					if (generator.getGeneratorState () == SudokuGenerator.GENERATOR_GEN_FINISHED) {
						SudokuDancingLink.report (generated);
						if (generated != null) {
							if (generated.GetLength (0) == 9 && generated.GetLength (1) == 9) {
								for (int y = 0; y < 9; y++)
									for (int x = 0; x < 9; x++) {
										sudoku.board.add ((byte)generated [x, y]);
									}
							} else {
								Debug.LogError ("generated length error");
							}
						} else {
							Debug.LogError ("why generated null");
						}
					}
				}
				// userSolve
				// aiSolve
			}
			return sudoku;
		}

	}
}