/*
 * @(#)SudokuGenerator.cs        1.0.0    2016-03-19
 *
 * You may use this software under the condition of "Simplified BSD License"
 *
 * Copyright 2016 MARIUSZ GROMADA. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 *
 *    1. Redistributions of source code must retain the above copyright notice, this list of
 *       conditions and the following disclaimer.
 *
 *    2. Redistributions in binary form must reproduce the above copyright notice, this list
 *       of conditions and the following disclaimer in the documentation and/or other materials
 *       provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY MARIUSZ GROMADA ``AS IS'' AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of MARIUSZ GROMADA.
 *
 * If you have any questions/bugs feel free to contact:
 *
 *     Mariusz Gromada
 *     mariuszgromada.org@gmail.com
 *     http://janetsudoku.mariuszgromada.org
 *     http://mathparser.org
 *     http://mathspace.pl
 *     http://github.com/mariuszgromada/Janet-Sudoku
 *     http://janetsudoku.codeplex.com
 *     http://sourceforge.net/projects/janetsudoku
 *     http://bitbucket.org/mariuszgromada/janet-sudoku
 *     http://github.com/mariuszgromada/MathParser.org-mXparser
 *
 *
 *                              Asked if he believes in one God, a mathematician answered:
 *                              "Yes, up to isomorphism."
 */
using UnityEngine;
using org.mariuszgromada.math.janetsudoku.utils;
using System;
using System.Collections.Generic;

namespace org.mariuszgromada.math.janetsudoku {
	/**
	 * Sudoku generator.
	 *
	 * @author         <b>Mariusz Gromada</b><br>
	 *                 <a href="mailto:mariuszgromada.org@gmail.com">mariuszgromada.org@gmail.com</a><br>
	 *                 <a href="http://janetsudoku.mariuszgromada.org" target="_blank">Janet Sudoku - project web page</a><br>
	 *                 <a href="http://mathspace.pl" target="_blank">MathSpace.pl</a><br>
	 *                 <a href="http://mathparser.org" target="_blank">MathParser.org - mXparser project page</a><br>
	 *                 <a href="http://github.com/mariuszgromada/Janet-Sudoku" target="_blank">Janet Sudoku on GitHub</a><br>
	 *                 <a href="http://janetsudoku.codeplex.com" target="_blank">Janet Sudoku on CodePlex</a><br>
	 *                 <a href="http://sourceforge.net/projects/janetsudoku" target="_blank">Janet Sudoku on SourceForge</a><br>
	 *                 <a href="http://bitbucket.org/mariuszgromada/janet-sudoku" target="_blank">Janet Sudoku on BitBucket</a><br>
	 *                 <a href="http://github.com/mariuszgromada/MathParser.org-mXparser" target="_blank">mXparser-MathParser.org on GitHub</a><br>
	 *
	 * @version        1.0.0
	 */
	// [CLSCompliant(true)]
	public class SudokuGenerator {
		/**
		 * Indicator if generation should
		 * start from randomly generated board.
		 */
		public const char PARAM_GEN_RND_BOARD = '1';
		/**
		 * Indicator showing that initial board should be solved
		 * before generation process will be started.
		 */
		public const char PARAM_DO_NOT_SOLVE = '2';
		/**
		 * Indicator showing that initial board should not be
		 * randomly transformed before generation process will be started.
		 */
		public const char PARAM_DO_NOT_TRANSFORM = '3';
		/**
		 * Indicator if generation should
		 * start from randomly generated board.
		 */
		private bool generateRandomBoard;
		/**
		 * Indicator showing that initial board should not be
		 * randomly transformed before generation process will be started.
		 */
		private bool transformBeforeGeneration;
		/**
		 * Indicator showing that initial board should be solved
		 * before generation process will be started.
		 */
		private bool solveBeforeGeneration;
		/**
		 * Board size derived form SudokuBoard class.
		 */
		private const int BOARD_SIZE = SudokuBoard.BOARD_SIZE;
		/**
		 * Board cells number derived form SudokuBoard class.
		 */
		private const int BOARD_CELLS_NUMBER = SudokuBoard.BOARD_CELLS_NUMBER;
		/**
		 * Empty cell identifier.
		 */
		private const int CELL_EMPTY = BoardCell.EMPTY;
		/**
		 * Marker if analyzed digit 0...9 is still not used.
		 */
		private const int DIGIT_STILL_FREE = BoardCell.DIGIT_STILL_FREE;
		/**
		 * Digit 0...9 can not be used in that place.
		 */
		private const int DIGIT_IN_USE = BoardCell.DIGIT_IN_USE;
		/**
		 * If yes then filled cells with the same impact will be randomized.
		 */
		private bool randomizeFilledCells;
		/**
		 * Initial board that will be a basis for
		 * the generation process
		 */
		private int[,] sudokuBoard;
		/**
		 * Board cells array
		 */
		private BoardCell[] boardCells;
		/**
		 * Message type normal.
		 */
		private const int MSG_INFO = 1;
		/**
		 * Message type error.
		 */
		private const int MSG_ERROR = -1;
		/**
		 * Message from the solver.
		 */
		private String messages = "";
		/**
		 * Last message.
		 */
		private String lastMessage = "";
		/**
		 * Last error message.
		 */
		private String lastErrorMessage = "";
		/**
		 * Solving time in seconds.
		 */
		private double computingTime;
		/**
		 * Generator state.
		 *
		 * @see #GENERATOR_INIT_STARTED
		 * @see #GENERATOR_INIT_FINISHED
		 * @see #GENERATOR_INIT_FAILED
		 * @see #GENERATOR_GEN_NOT_STARTED
		 * @see #GENERATOR_GEN_STARTED
		 * @see #GENERATOR_GEN_STARTED
		 * @see #GENERATOR_GEN_FAILED
		 */
		private int generatorState;
		/**
		 * Generator init started
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_INIT_STARTED = 1;
		/**
		 * Generator init finished.
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_INIT_FINISHED = 2;
		/**
		 * Generator init failed.
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_INIT_FAILED = -1;
		/**
		 * Generation process not started.
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_GEN_NOT_STARTED = -2;
		/**
		 * Generation process started.
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_GEN_STARTED = 3;
		/**
		 * Generation process finished.
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_GEN_FINISHED = 4;
		/**
		 * Generation process failed.
		 * @see #getGeneratorState()
		 */
		public const int GENERATOR_GEN_FAILED = -3;
		/**
		 * Internal variables init for constructor.
		 */
		private void initInternalVars() {
			generatorState = GENERATOR_INIT_STARTED;
			randomizeFilledCells = true;
			computingTime = 0;
		}
		/**
		 * Set parameters provided by the user.
		 *
		 * @param parameters  parameters list
		 * @see #PARAM_GEN_RND_BOARD
		 * @see #PARAM_DO_NOT_SOLVE
		 */
		private void setParameters(params char[] parameters) {
			generateRandomBoard = false;
			solveBeforeGeneration = true;
			transformBeforeGeneration = true;
			if (parameters != null) {
				if (parameters.Length > 0) {
					foreach (char p in parameters) {
						switch (p) {
						case PARAM_GEN_RND_BOARD:
							generateRandomBoard = true;
							break;
						case PARAM_DO_NOT_SOLVE:
							solveBeforeGeneration = false;
							break;
						case PARAM_DO_NOT_TRANSFORM:
							transformBeforeGeneration = false;
							break;
						}
					}
				}
			}
		}
		/**
		 * Board initialization method.
		 * @param initBoard        Initial board.
		 * @param info             The string to pass to the msg builder.
		 */
		private void boardInit(int[,] initBoard, String info) {
			Debug.LogError ("boardInit: " + initBoard + "; " + info);
			SudokuSolver puzzle;
			if ((initBoard == null) && (generateRandomBoard == true)) {
				puzzle = new SudokuSolver(SudokuPuzzles.PUZZLE_EMPTY);
				puzzle.solve();
				if (puzzle.getSolvingState() == SudokuSolver.SOLVING_STATE_SOLVED) {
					sudokuBoard = puzzle.solvedBoard;
					Debug.LogError("(SudokuGenerator) Generator initialized using random board (" + info + ").");
					generatorState = GENERATOR_INIT_FINISHED;
					return;
				} else {
					Debug.LogError("(SudokuGenerator) Generator initialization using random board (" + info + ") failed. Board with error?");
					addMessage(puzzle.getLastErrorMessage(), MSG_ERROR);
					generatorState = GENERATOR_INIT_FAILED;
					return;
				}
			}
			if (SudokuStore.checkPuzzle(initBoard) == false) {
				generatorState = GENERATOR_INIT_FAILED;
				Debug.LogError("(SudokuGenerator) Generator initialization (" + info + ") failed. Board with error?");
				return;
			}
			if (solveBeforeGeneration == true) {
				puzzle = new SudokuSolver(initBoard);
				puzzle.solve();
				if (puzzle.getSolvingState() == SudokuSolver.SOLVING_STATE_SOLVED) {
					sudokuBoard = puzzle.solvedBoard;
					Debug.LogError("(SudokuGenerator) Generator initialized usign provided board + finding solution (" + info + ").");
					generatorState = GENERATOR_INIT_FINISHED;
					return;
				} else {
					Debug.LogError("(SudokuGenerator) Generator initialization usign provided board + finding solution (" + info + ") failed. Board with error?");
					addMessage(puzzle.getLastErrorMessage(), MSG_ERROR);
					generatorState = GENERATOR_INIT_FAILED;
					return;
				}
			}
			int[,] board = initBoard;
			puzzle = new SudokuSolver(board);
			if (puzzle.checkIfUniqueSolution() == SudokuSolver.SOLUTION_UNIQUE) {
				sudokuBoard = board;
				Debug.LogError("(SudokuGenerator) Generator initialized usign provided board (" + info + ").");
				generatorState = GENERATOR_INIT_FINISHED;
				return;
			} else {
				Debug.LogError("(SudokuGenerator) Generator initialization usign provided board (" + info + ") failed. Solution not exists or is non unique.");
				Debug.LogError(puzzle.getLastErrorMessage());
				generatorState = GENERATOR_INIT_FAILED;
				return;
			}
		}
		/**
		 * Default constructor based on random Sudoku puzzle example.
		 *
		 * @param parameters      Optional parameters.
		 *
		 * @see #PARAM_DO_NOT_SOLVE
		 * @see #PARAM_DO_NOT_TRANSFORM
		 * @see #PARAM_GEN_RND_BOARD
		 */
		public SudokuGenerator(params char[] parameters) {
			setParameters(parameters);
			initInternalVars();
			if (generateRandomBoard == true) {
				boardInit(null, "random board");
			} else {
				int example = SudokuStore.randomIndex(SudokuPuzzles.NUMBER_OF_PUZZLE_EXAMPLES);
				int[,] board = SudokuStore.boardCopy(SudokuStore.getPuzzleExample(example));
				if (transformBeforeGeneration == true)
					boardInit(SudokuStore.seqOfRandomBoardTransf(board), "transformed example: " + example);
				else
					boardInit(board, "example: " + example);
			}
		}
		/**
		 * Default constructor based on puzzle example.
		 *
		 * @param example         Example number between 0 and {@link SudokuPuzzles#NUMBER_OF_PUZZLE_EXAMPLES}.
		 * @param parameters      Optional parameters.
		 *
		 * @see #PARAM_DO_NOT_SOLVE
		 * @see #PARAM_DO_NOT_TRANSFORM
		 * @see #PARAM_GEN_RND_BOARD
		 */
		public SudokuGenerator(int example, params char[] parameters) {
			setParameters(parameters);
			initInternalVars();
			if ((example >= 0) && (example < SudokuPuzzles.NUMBER_OF_PUZZLE_EXAMPLES)) {
				int[,] board = SudokuStore.boardCopy(SudokuStore.getPuzzleExample(example));
				if (transformBeforeGeneration == true)
					boardInit(SudokuStore.seqOfRandomBoardTransf(board), "transformed example: " + example);
				else
					boardInit(board, "example: " + example);
			} else {
				generatorState = GENERATOR_INIT_FAILED;
				Debug.LogError ("(SudokuGenerator) Generator not initialized incorrect example number: " + example + " - should be between 1 and " + SudokuPuzzles.NUMBER_OF_PUZZLE_EXAMPLES + ".");
			}
		}
		/**
		 * Default constructor based on provided initial board.
		 *
		 * @param initialBoard    Array with the board definition.
		 * @param parameters      Optional parameters
		 *
		 * @see #PARAM_DO_NOT_SOLVE
		 * @see #PARAM_DO_NOT_TRANSFORM
		 * @see #PARAM_GEN_RND_BOARD
		 */
		public SudokuGenerator(int[,] initialBoard, params char[] parameters) {
			setParameters(parameters);
			initInternalVars();
			if (initialBoard == null) {
				generatorState = GENERATOR_INIT_FAILED;
				Debug.LogError("(SudokuGenerator) Generator not initialized - null initial board.");
			} else if (initialBoard.GetLength(0) != BOARD_SIZE) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - incorrect number of rows in initial board, is: " + initialBoard.GetLength(0) + ",  expected: " + BOARD_SIZE + ".", MSG_ERROR);
			} else if (initialBoard.GetLength(1) != BOARD_SIZE) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - incorrect number of columns in initial board, is: " + initialBoard.GetLength(1) + ", expected: " + BOARD_SIZE + ".", MSG_ERROR);
			} else if (SudokuStore.checkPuzzle(initialBoard) == false) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - initial board contains an error.", MSG_ERROR);
			} else {
				int[,] board = SudokuStore.boardCopy(initialBoard);
				if (transformBeforeGeneration == true)
					boardInit(SudokuStore.seqOfRandomBoardTransf(board), "transformed board provided by the user");
				else
					boardInit(board, "board provided by the user");
			}
		}
		/**
		 * Constructor based on the sudoku board
		 * provided in text file.
		 *
		 * @param boardFilePath   Path to the board definition.
		 * @param parameters      Optional parameters
		 *
		 * @see #PARAM_DO_NOT_SOLVE
		 * @see #PARAM_DO_NOT_TRANSFORM
		 * @see #PARAM_GEN_RND_BOARD
		 */
		public SudokuGenerator(String boardFilePath, params char[] parameters) {
			setParameters(parameters);
			initInternalVars();
			if (boardFilePath == null) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - null board file path.", MSG_ERROR);
			} else if (boardFilePath.Length == 0) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - blank board file path.", MSG_ERROR);
			} else {
				int[,] board = SudokuStore.loadBoard(boardFilePath);
				if (transformBeforeGeneration == true)
					boardInit(SudokuStore.seqOfRandomBoardTransf(board), "transformed board provided by the user");
				else
					boardInit(board, "board provided by the user");
			}
		}
		/**
		 * Constructor based on the sudoku board
		 * provided array of strings.
		 *
		 * @param boardDefinition  Board definition as array of strings
		 *                        (each array entry as separate row).
		 * @param parameters        Optional parameters
		 *
		 * @see #PARAM_DO_NOT_SOLVE
		 * @see #PARAM_DO_NOT_TRANSFORM
		 * @see #PARAM_GEN_RND_BOARD
		 */
		public SudokuGenerator(String[] boardDefinition, params char[] parameters) {
			setParameters(parameters);
			initInternalVars();
			if (boardDefinition == null) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - null board definition.", MSG_ERROR);
			} else if (boardDefinition.Length == 0) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - blank board definition.", MSG_ERROR);
			} else {
				int[,] board = SudokuStore.loadBoard(boardDefinition);
				if (transformBeforeGeneration == true)
					boardInit(SudokuStore.seqOfRandomBoardTransf(board), "transformed board provided by the user");
				else
					boardInit(board, "board provided by the user");
			}
		}
		/**
		 * Constructor based on the sudoku board
		 * provided list of strings.
		 *
		 * @param boardDefinition  Board definition as list of strings
		 *                         (each list entry as separate row).
		 * @param parameters       Optional parameters
		 *
		 * @see #PARAM_DO_NOT_SOLVE
		 * @see #PARAM_DO_NOT_TRANSFORM
		 * @see #PARAM_GEN_RND_BOARD
		 */
		public SudokuGenerator(List<String> boardDefinition, params char[] parameters) {
			setParameters(parameters);
			initInternalVars();
			if (boardDefinition == null) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - null board definition.", MSG_ERROR);
			} else if (boardDefinition.Count == 0) {
				generatorState = GENERATOR_INIT_FAILED;
				addMessage("(SudokuGenerator) Generator not initialized - blank board definition.", MSG_ERROR);
			} else {
				int[,] board = SudokuStore.loadBoard(boardDefinition);
				if (transformBeforeGeneration == true)
					boardInit(SudokuStore.seqOfRandomBoardTransf(board), "transformed board provided by the user");
				else
					boardInit(board, "board provided by the user");
			}
		}
		/**
		 * Sudoku puzzle generator.
		 *
		 * @return   Sudoku puzzle if process finished correctly, otherwise null.
		 */
		public int[,] generate() {
			if (generatorState != GENERATOR_INIT_FINISHED) {
				generatorState = GENERATOR_GEN_NOT_STARTED;
				addMessage("(SudokuGenerator) Generation process not started due to incorrect initialization.", MSG_ERROR);
				return null;
			}
			long solvingStartTime = DateTimeX.currentTimeMillis();
			generatorState = GENERATOR_GEN_STARTED;
			addMessage("(SudokuGenerator) Generation process started.", MSG_INFO);
			if (randomizeFilledCells == true)
				addMessage("(SudokuGenerator) >>> Will randomize filled cells within cells with the same impact.", MSG_INFO);
			boardCells = new BoardCell[BOARD_CELLS_NUMBER];
			int cellIndex = 0;
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++) {
					int d = sudokuBoard[i, j];
					if (d != CELL_EMPTY) {
						boardCells[cellIndex] = new BoardCell(i, j, d);
						cellIndex++;
					}
				}
			int filledCells = cellIndex;
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++) {
					int d = sudokuBoard[i, j];
					if (d == CELL_EMPTY) {
						boardCells[cellIndex] = new BoardCell(i, j, d);
						cellIndex++;
					}
				}
			updateDigitsStillFreeCounts();
			sortBoardCells(0, filledCells - 1);
			do {
				int r = 0;
				int i = boardCells[r].rowIndex;
				int j = boardCells[r].colIndex;
				int d = sudokuBoard[i, j];
				sudokuBoard[i, j] = CELL_EMPTY;
				SudokuSolver s = new SudokuSolver(sudokuBoard);
				if (s.checkIfUniqueSolution() != SudokuSolver.SOLUTION_UNIQUE)
					sudokuBoard[i, j] = d;
				int lastIndex = filledCells - 1;
				if (r < lastIndex) {
					BoardCell b1 = boardCells[r];
					BoardCell b2 = boardCells[lastIndex];
					boardCells[lastIndex] = b1;
					boardCells[r] = b2;
				}
				filledCells--;
				updateDigitsStillFreeCounts();
				if (filledCells > 0) sortBoardCells(0, filledCells - 1);
			} while (filledCells > 0);
			long solvingEndTime = DateTimeX.currentTimeMillis();
			computingTime = (solvingEndTime - solvingStartTime) / 1000.0;
			generatorState = GENERATOR_GEN_FINISHED;
			addMessage("(SudokuGenerator) Generation process finished, computing time: " + computingTime + " s.", MSG_INFO);
			return sudokuBoard;
		}
		/**
		 * Saves board to the text file.
		 *
		 * @param filePath       Path to the file.
		 * @return               True if saving was successful, otherwise false.
		 *
		 * @see SudokuStore#saveBoard(int[,], String)
		 * @see SudokuStore#boardToString(int[,])
		 */
		public bool saveBoard(String filePath) {
			bool savingStatus = SudokuStore.saveBoard(sudokuBoard, filePath);
			if (savingStatus == true)
				addMessage("(saveBoard) Saving successful, file: " + filePath, MSG_INFO);
			else
				addMessage("(saveBoard) Saving failed, file: " + filePath, MSG_ERROR);
			return savingStatus;
		}
		/**
		 * Saves board to the text file.
		 *
		 * @param filePath       Path to the file.
		 * @param headComment    Comment to be added at the head.
		 * @return               True if saving was successful, otherwise false.
		 *
		 * @see SudokuStore#saveBoard(int[,], String, String)
		 * @see SudokuStore#boardToString(int[,], String)
		 */
		public bool saveBoard(String filePath, String headComment) {
			bool savingStatus = SudokuStore.saveBoard(sudokuBoard, filePath, headComment);
			if (savingStatus == true)
				addMessage("(saveBoard) Saving successful, file: " + filePath, MSG_INFO);
			else
				addMessage("(saveBoard) Saving failed, file: " + filePath, MSG_ERROR);
			return savingStatus;
		}
		/**
		 * Saves board to the text file.
		 *
		 * @param filePath       Path to the file.
		 * @param headComment    Comment to be added at the head.
		 * @param tailComment    Comment to be added at the tail.
		 * @return               True if saving was successful, otherwise false.
		 *
		 * @see SudokuStore#saveBoard(int[,], String, String, String)
		 * @see SudokuStore#boardToString(int[,], String, String)
		 */
		public bool saveBoard(String filePath, String headComment, String tailComment) {
			bool savingStatus = SudokuStore.saveBoard(sudokuBoard, filePath, headComment, tailComment);
			if (savingStatus == true)
				addMessage("(saveBoard) Saving successful, file: " + filePath, MSG_INFO);
			else
				addMessage("(saveBoard) Saving failed, file: " + filePath, MSG_ERROR);
			return savingStatus;
		}
		/**
		 * Updating digits still free for a specific cell
		 * while generating process.
		 */
		private void updateDigitsStillFreeCounts() {
			for (int i = 0; i < BOARD_CELLS_NUMBER; i++)
				countDigitsStillFree(boardCells[i]);
		}
		/**
		 * Counts number of digits still free
		 * for a specific cell.
		 *
		 * @param boardCell
		 */
		private void countDigitsStillFree(BoardCell boardCell) {
			int[] digitsStillFree = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			int emptyCellsNumber = 0;
			for (int j = 0; j < BOARD_SIZE; j++) {
				int boardDigit = sudokuBoard[boardCell.rowIndex, j];
				if (boardDigit != CELL_EMPTY)
					digitsStillFree[boardDigit] = DIGIT_IN_USE;
				else if (j != boardCell.colIndex)
					emptyCellsNumber++;
			}
			for (int i = 0; i < BOARD_SIZE; i++) {
				int boardDigit = sudokuBoard[i, boardCell.colIndex];
				if (boardDigit != CELL_EMPTY)
					digitsStillFree[boardDigit] = DIGIT_IN_USE;
				else if (i != boardCell.rowIndex)
					emptyCellsNumber++;
			}
			SubSquare sub = SubSquare.getSubSqare(boardCell);
			/*
			 * Mark digits used in a sub-square.
			 */
			for (int i = sub.rowMin; i < sub.rowMax; i++)
				for (int j = sub.colMin; j < sub.colMax; j++) {
					int boardDigit = sudokuBoard[i, j];
					if (boardDigit != CELL_EMPTY)
						digitsStillFree[boardDigit] = DIGIT_IN_USE;
					else if ((i != boardCell.rowIndex) && (j != boardCell.colIndex))
						emptyCellsNumber++;
				}
			/*
			 * Find number of still free digits to use.
			 */
			digitsStillFree[boardCell.digit] = 0;
			boardCell.digitsStillFreeNumber = emptyCellsNumber;
			for (int digit = 1; digit < 10; digit++)
				if (digitsStillFree[digit] == DIGIT_STILL_FREE)
					boardCell.digitsStillFreeNumber++;
		}
		/**
		 * Sorting board cells
		 * @param l  First index
		 * @param r  Last index
		 */
		private void sortBoardCells(int l, int r) {
			int i = l;
			int j = r;
			BoardCell x;
			BoardCell w;
			x = boardCells[(l + r) / 2];
			do {
				if (randomizeFilledCells == true) {
					/*
					 * Adding randomization
					 */
					while (boardCells[i].orderPlusRndSeed() < x.orderPlusRndSeed())
						i++;
					while (boardCells[j].orderPlusRndSeed() > x.orderPlusRndSeed())
						j--;
				} else {
					/*
					 * No randomization
					 */
					while (boardCells[i].order() < x.order())
						i++;
					while (boardCells[j].order() > x.order())
						j--;
				}
				if (i <= j) {
					w = boardCells[i];
					boardCells[i] = boardCells[j];
					boardCells[j] = w;
					i++;
					j--;
				}
			} while (i <= j);
			if (l < j)
				sortBoardCells(l, j);
			if (i < r)
				sortBoardCells(i, r);
		}
		/**
		 * By default random seed on filled cells is enabled. This parameter
		 * affects generating process only. Random seed on
		 * filled cells causes randomization on filled cells
		 * within the same impact.
		 */
		public void enableRndSeedOnFilledCells() {
			randomizeFilledCells = true;
		}
		/**
		 * By default random seed on filled cells is enabled. This parameter
		 * affects generating process only. Lack of random seed on
		 * filled cells causes no randomization on filled cells
		 * within the same impact.
		 */
		public void disableRndSeedOnFilledCells() {
			randomizeFilledCells = false;
		}
		/**
		 * Message builder.
		 * @param msg Message.
		 */
		private void addMessage(String msg, int msgType) {
			String vdt = "[" + SudokuStore.JANET_SUDOKU_NAME + "-v." + SudokuStore.JANET_SUDOKU_VERSION + ", " + DateTimeX.getCurrDateTimeStr() + "]";
			String mt = "(msg)";
			if (msgType == MSG_ERROR) {
				mt = "(error)";
				lastErrorMessage = msg;
			}
			messages = messages + SudokuStore.NEW_LINE_SEPARATOR + vdt + mt + " " + msg;
			lastMessage = msg;
			Debug.LogError (msg);
		}
		/**
		 * Returns list of recorded messages.
		 * @return List of recorded messages.
		 */
		public String getMessages() {
			return messages;
		}
		/**
		 * Clears list of recorded messages.
		 */
		public void clearMessages() {
			messages = "";
		}
		/**
		 * Gets last recorded message.
		 * @return Last recorded message.
		 */
		public String getLastMessage() {
			return lastMessage;
		}
		/**
		 * Gets last recorded error message.
		 * @return Last recorded message.
		 */
		public String getLastErrorMessage() {
			return lastErrorMessage;
		}
		/**
		 * Return solving time in seconds..
		 * @return  Solving time in seconds.
		 */
		public double getComputingTime() {
			return computingTime;
		}
		/**
		 * Return current state of the generator
		 * @return  {@link #GENERATOR_INIT_STARTED} or
		 *          {@link #GENERATOR_INIT_FINISHED} or
		 *          {@link #GENERATOR_INIT_FAILED} or
		 *          {@link #GENERATOR_GEN_NOT_STARTED} or
		 *          {@link #GENERATOR_GEN_STARTED} or
		 *          {@link #GENERATOR_GEN_FINISHED} or
		 *          {@link #GENERATOR_GEN_FAILED}.
		 */
		public int getGeneratorState() {
			return generatorState;
		}
	}
}