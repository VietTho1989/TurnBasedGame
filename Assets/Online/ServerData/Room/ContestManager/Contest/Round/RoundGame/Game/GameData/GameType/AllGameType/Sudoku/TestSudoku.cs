using System.Threading;

namespace Sudoku
{
    public class TestSudoku
    {

        class Work
        {

            public Work()
            {

            }

            public void DoWork()
            {
                SudokuDancingLink.main();
                // Samurai.main();
                // Hexadoku.main();
                // Dodeka.main();

                {
                    /*int[,] board = {
						{1, 2, 3, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
						{0, 0, 0, 0, 0, 0, 0, 0, 0},
					};
					SudokuGenerator generator = new SudokuGenerator(board, SudokuGenerator.PARAM_DO_NOT_TRANSFORM);*/
                    /*SudokuGenerator generator = new SudokuGenerator (SudokuGenerator.PARAM_GEN_RND_BOARD);
					// setGeneratorOptions
					{
						 generator.enableRndSeedOnFilledCells ();
						// generator.disableRndSeedOnFilledCells();
					}
					int[,] generated = generator.generate();
					if (generator.getGeneratorState () == SudokuGenerator.GENERATOR_GEN_FINISHED) {
						SudokuDancingLink.report (generated);
						// solve
						{
							SudokuDancingLink sudoku = new SudokuDancingLink();
							sudoku.solve (generated);
						}
					} else {
						Debug.LogError (">>> !!! Error while generating random puzzle !!! <<<");
						Debug.LogError (generator.getMessages ());
					}*/
                }
            }
        }


        public static void startTestMatch(int matchCount)
        {
            for (int i = 0; i < matchCount; i++)
            {
                Work w = new Work();
                {
                    // startThread
                    ThreadStart threadDelegate = new ThreadStart(w.DoWork);
                    Thread newThread = new Thread(threadDelegate, 1048576);
                    newThread.Start();
                }
            }
        }

    }
}
/*

4 9 7 6 8 3 5 2 1 . . . 5 1 8 3 4 2 6 7 9 
8 5 6 1 2 4 3 9 7 . . . 9 4 6 8 7 5 2 1 3 
1 3 2 5 9 7 6 4 8 . . . 3 7 2 6 9 1 5 8 4 
6 2 4 3 1 5 8 7 9 . . . 8 3 4 2 1 6 9 5 7 
3 7 5 9 4 8 1 6 2 . . . 2 9 7 4 5 3 8 6 1 
9 8 1 2 7 6 4 5 3 . . . 6 5 1 7 8 9 3 4 2 
7 1 3 4 6 9 2 8 5 9 4 1 7 6 3 5 2 4 1 9 8 
2 6 8 7 5 1 9 3 4 2 6 7 1 8 5 9 3 7 4 2 6 
5 4 9 8 3 2 7 1 6 8 5 3 4 2 9 1 6 8 7 3 5 
. . . . . . 8 7 2 1 3 5 6 9 4 . . . . . . 
. . . . . . 4 9 3 7 8 6 2 5 1 . . . . . . 
. . . . . . 5 6 1 4 2 9 8 3 7 . . . . . . 
6 9 7 1 2 5 3 4 8 5 1 2 9 7 6 2 1 8 5 3 4 
1 3 5 7 8 4 6 2 9 3 7 4 5 1 8 6 3 4 7 9 2 
8 2 4 3 9 6 1 5 7 6 9 8 3 4 2 9 5 7 1 6 8 
2 7 1 8 4 3 9 6 5 . . . 1 5 4 3 2 9 6 8 7 
3 5 8 9 6 2 7 1 4 . . . 6 9 3 7 8 5 4 2 1 
9 4 6 5 1 7 8 3 2 . . . 8 2 7 4 6 1 9 5 3 
7 8 3 4 5 1 2 9 6 . . . 7 3 5 1 9 2 8 4 6 
5 1 2 6 7 9 4 8 3 . . . 2 8 1 5 4 6 3 7 9 
4 6 9 2 3 8 5 7 1 . . . 4 6 9 8 7 3 2 1 5 
-----------------------------------------

 * */