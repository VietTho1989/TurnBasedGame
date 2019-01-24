/*
 * @(#)SudokuSolver.cs        1.1.1    2016-04-18
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
using org.mariuszgromada.math.janetsudoku.utils;
using System;
using System.Collections.Generic;

// [assembly: CLSCompliant(true)]
namespace org.mariuszgromada.math.janetsudoku {
	/**
	 * Sudoku board, with predefined Sudoku examples and possibility to load
	 * external examples from arrays or files. Class implements
	 * loading methods as well as Sudoku solving methods.
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
	 * @version        1.1.1
	 */
	// [CLSCompliant(true)]
	public class SudokuSolver {
		/**
		 * Sudoku solving not initiated.
		 */
		public const int SOLVING_STATE_NOT_STARTED = 1;
		/**
		 * Sudoku solving started.
		 */
		public const int SOLVING_STATE_STARTED = 2;
		/**
		 * Sudoku solving finished and successful.
		 */
		public const int SOLVING_STATE_SOLVED = 3;
		/**
		 * Solution does not exist.
		 * @see #checkIfUniqueSolution()
		 */
		public const int SOLUTION_NOT_EXISTS = -1;
		/**
		 * Solution exists and is unique.
		 * @see #checkIfUniqueSolution()
		 */
		public const int SOLUTION_UNIQUE = 1;
		/**
		 * Solution exists and is non-unique.
		 * @see #checkIfUniqueSolution()
		 */
		public const int SOLUTION_NON_UNIQUE = 2;
		/**
		 * Message type normal.
		 */
		private const int MSG_INFO = 1;
		/**
		 * Message type error.
		 */
		private const int MSG_ERROR = -1;
		/**
		 * Sudoku board size.
		 */
		private const int BOARD_SIZE = SudokuBoard.BOARD_SIZE;
		/**
		 * Number of cells on the Sudoku board.
		 */
		private const int BOARD_CELLS_NUMBER = SudokuBoard.BOARD_CELLS_NUMBER;
		/**
		 * Sudoku board was successfully loaded.
		 */
		private const int BOARD_STATE_EMPTY = SudokuBoard.BOARD_STATE_EMPTY;
		/**
		 * Sudoku board was successfully loaded.
		 */
		private const int BOARD_STATE_LOADED = SudokuBoard.BOARD_STATE_LOADED;
		/**
		 * Sudoku board is ready to start solving process.
		 */
		private const int BOARD_STATE_READY = SudokuBoard.BOARD_STATE_READY;
		/**
		 * Sudoku board is ready to start solving process.
		 */
		private const int BOARD_STATE_ERROR = SudokuBoard.BOARD_STATE_ERROR;
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
		 * Cell is not pointing to any cells on the board.
		 */
		private const int INDEX_NULL = BoardCell.INDEX_NULL;
		/**
		 * Sudoku board used while solving process.
		 */
		internal int[,] sudokuBoard = new int[BOARD_SIZE, BOARD_SIZE];
		/**
		 * Sudoku solution.
		 */
		internal int[,] solvedBoard = null;
		/**
		 * Board backup for general internal purposes.
		 */
		private int[,] boardBackup = new int[BOARD_SIZE, BOARD_SIZE];
		/**
		 * Path to the sudoku solution.
		 */
		private Stack<BoardCell> solutionPath;
		/**
		 * All solutions list
		 */
		private List<SudokuBoard> solutionsList;
		/**
		 * Solving status indicator.
		 */
		private int boardState;
		/**
		 * Solving status indicator.
		 */
		private int solvingState;
		/**
		 * Solving time in seconds.
		 */
		private double computingTime;
		/**
		 * Step back counter showing how many different
		 * routes were evaluated while solving.
		 */
		private int closedPathsCounter;
		/**
		 * Total evaluated paths counter while finding all solutions.
		 */
		private int totalPathsCounter;
		/**
		 * If yes then empty cells with the same number of
		 * still free digits will be randomized.
		 */
		private bool randomizeEmptyCells;
		/**
		 * If yes then still free digits for a given empty cell
		 * will be randomized.
		 */
		private bool randomizeFreeDigits;
		/**
		 * Empty cells on the Sudoku board
		 */
		private EmptyCell[] emptyCells = new EmptyCell[BOARD_CELLS_NUMBER];
		/**
		 * Pointers to the empty cells.
		 */
		private EmptyCell[, ] emptyCellsPointer = new EmptyCell[BOARD_SIZE, BOARD_SIZE];
		/**
		 * Number of empty cells on the Sudoku board.
		 */
		private int emptyCellsNumber;
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
		private int solutionNumber;
		/*
		 * =====================================================
		 *                  Constructors
		 * =====================================================
		 */
		/**
		 * Default constructor - only board initialization.
		 */
		public SudokuSolver() {
			clearPuzzels();
			randomizeEmptyCells = true;
			randomizeFreeDigits = true;
			findEmptyCells();
		}
		/**
		 * Constructor - based on the Sudoku predefined example number.
		 * @param exampleNumber  number of Sudoku example to load between 1
		 * and {@link SudokuPuzzles#NUMBER_OF_PUZZLE_EXAMPLES}
		 */
		public SudokuSolver(int exampleNumber) {
			clearPuzzels();
			randomizeEmptyCells = true;
			randomizeFreeDigits = true;
			loadBoard(exampleNumber);
		}
		/**
		 * Constructor - based on file path to the Sudoku definition.
		 * @param filePath     Path to the sudoku definition.
		 */
		public SudokuSolver(String filePath) {
			clearPuzzels();
			randomizeEmptyCells = true;
			randomizeFreeDigits = true;
			loadBoard(filePath);
		}
		/**
		 * Constructor - based on file path to the Sudoku definition.
		 * @param boardDefinition     Board definition (as array of strings,
		 *                            each array entry as separate row).
		 */
		public SudokuSolver(String[] boardDefinition) {
			clearPuzzels();
			randomizeEmptyCells = true;
			randomizeFreeDigits = true;
			loadBoard(sudokuBoard);
		}
		/**
		 * Constructor - based on file path to the Sudoku definition.
		 * @param boardDefinition     Board definition (as list of strings,
		 *                            each list entry as separate row).
		 */
		public SudokuSolver(List<String> boardDefinition) {
			clearPuzzels();
			randomizeEmptyCells = true;
			randomizeFreeDigits = true;
			loadBoard(boardDefinition);
		}
		/**
		 * Constructor - based on array representing Sudoku board.
		 * @param sudokuBoard    9x9 array representing Sudoku board/
		 */
		public SudokuSolver(int[,] sudokuBoard) {
			clearPuzzels();
			randomizeEmptyCells = true;
			randomizeFreeDigits = true;
			loadBoard(sudokuBoard);
		}
		/*
		 * =====================================================
		 *                  Loading methods
		 * =====================================================
		 */
		/**
		 * Loads Sudoku example given by the parameter exampleNumber.
		 *
		 * @param exampleNumber  Number of predefined Sudoku example.
		 * @return {@link ErrorCodes#SUDOKUSOLVER_LOADBOARD_LOADING_FAILED} or
		 *         {@link SudokuBoard#BOARD_STATE_LOADED}.
		 */
		public int loadBoard(int exampleNumber) {
			if ((exampleNumber < 0) || (exampleNumber > SudokuStore.NUMBER_OF_PUZZLE_EXAMPLES)) {
				addMessage("(loadBoard) Loading failed - example number should be between 0 and " + (SudokuStore.NUMBER_OF_PUZZLE_EXAMPLES-1), MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			if (boardState != BOARD_STATE_EMPTY)
				clearPuzzels();
			int[,] loadedBoard = SudokuStore.getPuzzleExample(exampleNumber);
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					sudokuBoard[i, j] = loadedBoard[i, j];
			boardState = BOARD_STATE_LOADED;
			addMessage("(loadBoard) Sudoku example board " + exampleNumber + " loaded", MSG_INFO);
			return findEmptyCells();
		}
		/**
		 * Loads Sudoku from file.
		 *
		 * @param filePath File path that contains board definition.
		 * @return {@link ErrorCodes#SUDOKUSOLVER_LOADBOARD_LOADING_FAILED} or
		 *         {@link SudokuBoard#BOARD_STATE_LOADED}.
		 */
		public int loadBoard(String filePath) {
			int[,] loadedBoard = SudokuStore.loadBoard(filePath);
			if (loadedBoard == null) {
				addMessage("(loadBoard) Loading from file failed: " + filePath, MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			if (boardState != BOARD_STATE_EMPTY)
				clearPuzzels();
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					sudokuBoard[i, j] = loadedBoard[i, j];
			boardState = BOARD_STATE_LOADED;
			addMessage("(loadBoard) Sudoku loaded, file: " + filePath, MSG_INFO);
			return findEmptyCells();
		}
		/**
		 * Loads Sudoku from array of strings.
		 *
		 * @param boardDefinition  Board definition as array of strings
		 *                        (each array entry as separate row).
		 * @return {@link ErrorCodes#SUDOKUSOLVER_LOADBOARD_LOADING_FAILED} or
		 *         {@link SudokuBoard#BOARD_STATE_LOADED}.
		 */
		public int loadBoard(String[] boardDefinition) {
			int[,] loadedBoard = SudokuStore.loadBoard(boardDefinition);
			if (loadedBoard == null) {
				addMessage("(loadBoard) Loading from array of strings failed.", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			if (boardState != BOARD_STATE_EMPTY)
				clearPuzzels();
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					sudokuBoard[i, j] = loadedBoard[i, j];
			boardState = BOARD_STATE_LOADED;
			addMessage("(loadBoard) Sudoku loaded from array of strings. ", MSG_INFO);
			return findEmptyCells();
		}
		/**
		 * Loads Sudoku from array of strings.
		 *
		 * @param boardDefinition  Board definition as list of strings
		 *                        (each list entry as separate row).
		 * @return {@link ErrorCodes#SUDOKUSOLVER_LOADBOARD_LOADING_FAILED} or
		 *         {@link SudokuBoard#BOARD_STATE_LOADED}.
		 */
		public int loadBoard(List<String> boardDefinition) {
			int[,] loadedBoard = SudokuStore.loadBoard(boardDefinition);
			if (loadedBoard == null) {
				addMessage("(loadBoard) Loading from list of strings failed.", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			if (boardState != BOARD_STATE_EMPTY)
				clearPuzzels();
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					sudokuBoard[i, j] = loadedBoard[i, j];
			boardState = BOARD_STATE_LOADED;
			addMessage("(loadBoard) Sudoku loaded from list of strings. ", MSG_INFO);
			return findEmptyCells();
		}
		/**
		 * Loads Sudoku from array.
		 *
		 * @param sudokuBoard Array representing Sudoku puzzles.
		 * @return {@link ErrorCodes#SUDOKUSOLVER_LOADBOARD_LOADING_FAILED} or
		 *         {@link SudokuBoard#BOARD_STATE_LOADED}.
		 */
		public int loadBoard(int[,] sudokuBoard) {
			if (sudokuBoard == null) {
				addMessage("(loadBoard) Loading from array failed - null array!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			if (sudokuBoard.GetLength(0) != BOARD_SIZE) {
				addMessage("(loadBoard) Loading from array failed - incorrect number of rows! " + sudokuBoard.GetLength(0), MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			if (sudokuBoard.GetLength(1) != BOARD_SIZE) {
				addMessage("(loadBoard) Loading from array failed - incorrect number of columns! " + sudokuBoard.GetLength(1), MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
			}
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++) {
					int d = sudokuBoard[i, j];
					if ( !( ((d >= 1) && (d <= 9)) || (d == CELL_EMPTY) ) )  {
						addMessage("(loadBoard) Loading from array failed - incorrect digit: " + d, MSG_ERROR);
						return ErrorCodes.SUDOKUSOLVER_LOADBOARD_LOADING_FAILED;
					}
				}
			if (boardState != BOARD_STATE_EMPTY)
				clearPuzzels();
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					this.sudokuBoard[i, j] = sudokuBoard[i, j];
			boardState = BOARD_STATE_LOADED;
			addMessage("(loadBoard) Sudoku loaded from array!", MSG_INFO);
			return findEmptyCells();
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
		 * Saves solved board to the text file.
		 *
		 * @param filePath       Path to the file.
		 * @return               True if saving was successful, otherwise false.
		 *
		 * @see SudokuStore#saveBoard(int[,], String)
		 * @see SudokuStore#boardToString(int[,])
		 */
		public bool saveSolvedBoard(String filePath) {
			bool savingStatus = SudokuStore.saveBoard(solvedBoard, filePath);
			if (savingStatus == true)
				addMessage("(saveSolvedBoard) Saving successful, file: " + filePath, MSG_INFO);
			else
				addMessage("(saveSolvedBoard) Saving failed, file: " + filePath, MSG_ERROR);
			return savingStatus;
		}
		/**
		 * Saves solved board to the text file.
		 *
		 * @param filePath       Path to the file.
		 * @param headComment    Comment to be added at the head.
		 * @return               True if saving was successful, otherwise false.
		 *
		 * @see SudokuStore#saveBoard(int[,], String, String)
		 * @see SudokuStore#boardToString(int[,], String)
		 */
		public bool saveSolvedBoard(String filePath, String headComment) {
			bool savingStatus = SudokuStore.saveBoard(solvedBoard, filePath, headComment);
			if (savingStatus == true)
				addMessage("(saveSolvedBoard) Saving successful, file: " + filePath, MSG_INFO);
			else
				addMessage("(saveSolvedBoard) Saving failed, file: " + filePath, MSG_ERROR);
			return savingStatus;
		}
		/**
		 * Saves solved board to the text file.
		 *
		 * @param filePath       Path to the file.
		 * @param headComment    Comment to be added at the head.
		 * @param tailComment    Comment to be added at the tail.
		 * @return               True if saving was successful, otherwise false.
		 *
		 * @see SudokuStore#saveBoard(int[,], String, String, String)
		 * @see SudokuStore#boardToString(int[,], String, String)
		 */
		public bool saveSolvedBoard(String filePath, String headComment, String tailComment) {
			bool savingStatus = SudokuStore.saveBoard(solvedBoard, filePath, headComment, tailComment);
			if (savingStatus == true)
				addMessage("(saveSolvedBoard) Saving successful, file: " + filePath, MSG_INFO);
			else
				addMessage("(saveSolvedBoard) Saving failed, file: " + filePath, MSG_ERROR);
			return savingStatus;
		}
		/**
		 * Manually set cell value.
		 *
		 * @param rowIndex   Cell row index between 0 and 8.
		 * @param colIndex   Cell column index between 0 and 8.
		 * @param digit      Cell digit between 1 and 9, or EMPTY_CELL.
		 * @return           Number of empty cells that left if cell definition correct,
		 *                   {@link ErrorCodes#SUDOKUSOLVER_SETCELL_INCORRECT_DEFINITION} otherwise.
		 */
		public int setCell(int rowIndex, int colIndex, int digit) {
			if ( (rowIndex < 0) || (rowIndex >= BOARD_SIZE) ) {
				addMessage("(setCell) Incorrect row index - is: " + rowIndex + ", should be between 0 and " + BOARD_SIZE + ".", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_SETCELL_INCORRECT_DEFINITION;
			}
			if ( (colIndex < 0) || (colIndex >= BOARD_SIZE) ) {
				addMessage("(setCell) Incorrect colmn index - is: " + colIndex + ", should be between 0 and " + BOARD_SIZE + ".", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_SETCELL_INCORRECT_DEFINITION;
			}
			if ( ( (digit < 1) || (digit > 9) ) && (digit != CELL_EMPTY) ){
				addMessage("(setCell) Incorrect digit definition - is: " + digit + ", should be between 1 and 9, or " + CELL_EMPTY + " for empty cell", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_SETCELL_INCORRECT_DEFINITION;
			}
			sudokuBoard[rowIndex, colIndex] = digit;
			return findEmptyCells();
		}
		/**
		 * Returns cell digit from current Sudoku board.
		 * @param rowIndex    Cell row index between 0 and 8.
		 * @param colIndex    Cell column index between 0 and 8.
		 * @return            Cell digit between 1 and 9, if cell empty
		 *                    then {@link BoardCell#EMPTY}.
		 *                    If indexes are out of range then error
		 *                    {@link ErrorCodes#SUDOKUSOLVER_GETCELLDIGIT_INCORRECT_INDEX}
		 *                    is returned.
		 */
		public int getCellDigit(int rowIndex, int colIndex) {
			if ( (rowIndex < 0) || (rowIndex >= BOARD_SIZE) ) {
				addMessage("(getCellDigit) Incorrect row index - is: " + rowIndex + ", should be between 0 and " + BOARD_SIZE + ".", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_GETCELLDIGIT_INCORRECT_INDEX;
			}
			if ( (colIndex < 0) || (colIndex >= BOARD_SIZE) ) {
				addMessage("(getCellDigit) Incorrect colmn index - is: " + colIndex + ", should be between 0 and " + BOARD_SIZE + ".", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_GETCELLDIGIT_INCORRECT_INDEX;
			}
			return sudokuBoard[rowIndex, colIndex];
		}
		/*
		 * =====================================================
		 *                  Solving methods
		 * =====================================================
		 */
		/**
		 * Method starts solving procedure.
		 * @return if board state is {@link SudokuBoard#BOARD_STATE_EMPTY} then {@link ErrorCodes#SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_ERROR} then {@link ErrorCodes#SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_LOADED} then {@link ErrorCodes#SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_READY} then returns solving status:
		 *              {@link SudokuSolver#SOLVING_STATE_SOLVED},
		 *              {@link ErrorCodes#SUDOKUSOLVER_SOLVE_SOLVING_FAILED}.
		 *
		 */
		public int solve() {
			switch(boardState) {
			case BOARD_STATE_EMPTY:
				addMessage("(solve) Nothing to solve - the board is empty!", MSG_ERROR);
				solvingState = SOLVING_STATE_NOT_STARTED;
				return ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED;
			case BOARD_STATE_ERROR:
				addMessage("(solve) Can not start solving process - the board contains an error!", MSG_ERROR);
				solvingState = SOLVING_STATE_NOT_STARTED;
				return ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED;
			case BOARD_STATE_LOADED:
				addMessage("(solve) Can not start solving process - the board is not ready!", MSG_ERROR);
				solvingState = SOLVING_STATE_NOT_STARTED;
				return ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED;
			case BOARD_STATE_READY:
				addMessage("(solve) Starting solving process!", MSG_INFO);
				if (randomizeEmptyCells == true)
					addMessage("(solve) >>> Will randomize empty cells if number of still free digits is the same.", MSG_INFO);
				if (randomizeFreeDigits == true)
					addMessage("(solve) >>> Will randomize still free digits for a given empty cell.", MSG_INFO);
				solvingState = SOLVING_STATE_STARTED;
				solutionPath = new Stack<BoardCell>();
				backupCurrentBoard();
				long solvingStartTime = DateTimeX.currentTimeMillis();
				closedPathsCounter = 0;
				solve(0);
				long solvingEndTime = DateTimeX.currentTimeMillis();
				computingTime = (solvingEndTime - solvingStartTime) / 1000.0;
				if (solvingState != SOLVING_STATE_SOLVED) {
					solvingState = ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_FAILED;
					boardState = BOARD_STATE_ERROR;
					addMessage("(solve) Error while solving - no solutions found - setting board state as 'error' !!", MSG_ERROR);
				} else {
					addMessage("(solve) Sudoku solved !!! Cells solved: " + emptyCellsNumber + " ... Closed routes: " + closedPathsCounter + " ... solving time: " + computingTime + " s.", MSG_INFO);
					emptyCellsNumber = 0;
				}
				restoreBoardFromBackup();
				return solvingState;
			}
			addMessage("(solve) Can not start solving process - do not know why :-(. Please report bug!", MSG_ERROR);
			solvingState = SOLVING_STATE_NOT_STARTED;
			return ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED;
		}
		/**
		 * Recursive process of Sudoku solving.
		 * @param level     Level of recursive step.
		 */
		private void solve(int level) {
			/**
			 * Close route if solving process stopped
			 */
			if (solvingState != SOLVING_STATE_STARTED)
				return;
			/**
			 * Check if solved
			 */
			if (level == emptyCellsNumber) {
				solvingState = SOLVING_STATE_SOLVED;
				solvedBoard = getBoardCopy();
				return;
			}
			/**
			 * If still other cells are empty, perform recursive steps.
			 */
			EmptyCell emptyCell = emptyCells[level];
			int digitsStillFreeNumber = emptyCell.digitsStillFreeNumber;
			if (digitsStillFreeNumber > 0) {
				int digitNum = 0;
				for (int digitIndex = 1; digitIndex <= 9; digitIndex++) {
					int digit = digitIndex;
					if (randomizeFreeDigits == true)
						digit = emptyCell.digitsRandomSeed[digitIndex].digit;
					if (emptyCell.digitsStillFree[digit] == DIGIT_STILL_FREE) {
						digitNum++;
						sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = digit;
						if (level + 1 < emptyCellsNumber - 1)
							sortEmptyCells(level+1, emptyCellsNumber-1);
						solutionPath.Push( new BoardCell(emptyCell.rowIndex, emptyCell.colIndex, digit) );
						updateDigitsStillFree(emptyCell);
						solve(level + 1);
						if (solvingState == SOLVING_STATE_STARTED) {
							solutionPath.Pop();
							if (digitNum == digitsStillFreeNumber) {
								sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = CELL_EMPTY;
								updateDigitsStillFree(emptyCell);
								if (level < emptyCellsNumber - 1)
									sortEmptyCells(level, emptyCellsNumber-1);
								closedPathsCounter++;
							}
						} else
							return;
					}
				}
			} else {
				sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = CELL_EMPTY;
				updateDigitsStillFree(emptyCell);
			}
		}
		/**
		 * Method searching all solutions procedure.
		 *
		 * @return if board state is {@link SudokuBoard#BOARD_STATE_EMPTY} then {@link ErrorCodes#SUDOKUSOLVER_FINDALLSOLUTIONS_SEARCHING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_ERROR} then {@link ErrorCodes#SUDOKUSOLVER_FINDALLSOLUTIONS_SEARCHING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_LOADED} then {@link ErrorCodes#SUDOKUSOLVER_FINDALLSOLUTIONS_SEARCHING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_READY} then returns number of all solutions found.
		 */
		public int findAllSolutions() {
			switch(boardState) {
			case BOARD_STATE_EMPTY:
				addMessage("(findAllSolutions) Nothing to solve - the board is empty!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_FINDALLSOLUTIONS_SEARCHING_NOT_STARTED;
			case BOARD_STATE_ERROR:
				addMessage("(findAllSolutions) Can not start solving process - the board contains an error!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_FINDALLSOLUTIONS_SEARCHING_NOT_STARTED;
			case BOARD_STATE_LOADED:
				addMessage("(findAllSolutions) Can not start solving process - the board is not ready!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_FINDALLSOLUTIONS_SEARCHING_NOT_STARTED;
			case BOARD_STATE_READY:
				addMessage("(findAllSolutions) Starting solving process!", MSG_INFO);
				if (randomizeEmptyCells == true)
					addMessage("(findAllSolutions) >>> Will randomize empty cells if number of still free digits is the same.", MSG_INFO);
				if (randomizeFreeDigits == true)
					addMessage("(findAllSolutions) >>> Will randomize still free digits for a given empty cell.", MSG_INFO);
				solutionsList = new List<SudokuBoard>();
				backupCurrentBoard();
				long solvingStartTime = DateTimeX.currentTimeMillis();
				totalPathsCounter = 0;
				findAllSolutions(0);
				long solvingEndTime = DateTimeX.currentTimeMillis();
				computingTime = (solvingEndTime - solvingStartTime) / 1000.0;
				restoreBoardFromBackup();
				return solutionsList.Count;
			}
			addMessage("(findAllSolutions) Can not start solving process - do not know why :-(", MSG_ERROR);
			return ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_NOT_STARTED;
		}
		/**
		 * Recursive process of searching all possible solutions.
		 * @param level     Level of recursive step.
		 */
		private void findAllSolutions(int level) {
			/*
			 * Enter level.
			 * Check if solved.
			 */
			if (level == emptyCellsNumber) {
				SudokuBoard solution = new SudokuBoard();
				solution.board = getBoardCopy();
				solution.pathNumber = totalPathsCounter;
				solutionsList.Add(solution);
				return;
			}
			/*
			 * If still other cells are empty, perform recursive steps.
			 */
			EmptyCell emptyCell = emptyCells[level];
			int digitsStillFreeNumber = emptyCell.digitsStillFreeNumber;
			if (digitsStillFreeNumber > 0) {
				int digitNum = 0;
				for (int digitIndex = 1; digitIndex <= 9; digitIndex++) {
					int digit = digitIndex;
					if (randomizeFreeDigits == true)
						digit = emptyCell.digitsRandomSeed[digitIndex].digit;
					if (emptyCell.digitsStillFree[digit] == DIGIT_STILL_FREE) {
						digitNum++;
						sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = digit;
						if (level + 1 < emptyCellsNumber - 1)
							sortEmptyCells(level+1, emptyCellsNumber-1);
						updateDigitsStillFree(emptyCell);
						findAllSolutions(level + 1);
						if (digitNum == digitsStillFreeNumber) {
							sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = CELL_EMPTY;
							updateDigitsStillFree(emptyCell);
							if (level < emptyCellsNumber - 1)
								sortEmptyCells(level, emptyCellsNumber-1);
							totalPathsCounter++;
						}
					}
				}
			} else {
				sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = CELL_EMPTY;
				updateDigitsStillFree(emptyCell);
			}
		}
		/**
		 * Method searching all solutions procedure.
		 *
		 * @return if board state is {@link SudokuBoard#BOARD_STATE_EMPTY} then {@link ErrorCodes#SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_ERROR} then {@link ErrorCodes#SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_LOADED} then {@link ErrorCodes#SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED},
		 *         if board state is {@link SudokuBoard#BOARD_STATE_READY} then returns number of all solutions found.
		 */
		public int checkIfUniqueSolution() {
			switch(boardState) {
			case BOARD_STATE_EMPTY:
				addMessage("(checkIfUniqueSolution) Nothing to solve - the board is empty!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED;
			case BOARD_STATE_ERROR:
				addMessage("(checkIfUniqueSolution) Can not start solving process - the board contains an error!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED;
			case BOARD_STATE_LOADED:
				addMessage("(checkIfUniqueSolution) Can not start solving process - the board is not ready!", MSG_ERROR);
				return ErrorCodes.SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED;
			case BOARD_STATE_READY:
				addMessage("(checkIfUniqueSolution) Starting solving process!", MSG_INFO);
				if (randomizeEmptyCells == true)
					addMessage("(checkIfUniqueSolution) >>> Will randomize empty cells if number of still free digits is the same.", MSG_INFO);
				if (randomizeFreeDigits == true)
					addMessage("(checkIfUniqueSolution) >>> Will randomize still free digits for a given empty cell.", MSG_INFO);
				solutionNumber = 0;
				backupCurrentBoard();
				long solvingStartTime = DateTimeX.currentTimeMillis();
				totalPathsCounter = 0;
				checkIfUniqueSolution(0);
				long solvingEndTime = DateTimeX.currentTimeMillis();
				computingTime = (solvingEndTime - solvingStartTime) / 1000.0;
				restoreBoardFromBackup();
				if (solutionNumber == 1)
					return SOLUTION_UNIQUE;
				else if (solutionNumber == 2)
					return SOLUTION_NON_UNIQUE;
				else
					return SOLUTION_NOT_EXISTS;
			}
			addMessage("(checkIfUniqueSolution) Can not start solving process - do not know why :-(", MSG_ERROR);
			return ErrorCodes.SUDOKUSOLVER_CHECKIFUNIQUESOLUTION_CHECKING_NOT_STARTED;
		}
		/**
		 * Recursive process of checking unique solution.
		 * @param level     Level of recursive step.
		 */
		private void checkIfUniqueSolution(int level) {
			if (solutionNumber > 1) return;
			/*
			 * Enter level.
			 * Check if solved.
			 */
			if (level == emptyCellsNumber) {
				solutionNumber++;
				return;
			}
			/*
			 * If still other cells are empty, perform recursive steps.
			 */
			EmptyCell emptyCell = emptyCells[level];
			int digitsStillFreeNumber = emptyCell.digitsStillFreeNumber;
			if (digitsStillFreeNumber > 0) {
				int digitNum = 0;
				for (int digitIndex = 1; digitIndex <= 9; digitIndex++) {
					int digit = digitIndex;
					if (randomizeFreeDigits == true)
						digit = emptyCell.digitsRandomSeed[digitIndex].digit;
					if (emptyCell.digitsStillFree[digit] == DIGIT_STILL_FREE) {
						digitNum++;
						sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = digit;
						if (level + 1 < emptyCellsNumber - 1)
							sortEmptyCells(level+1, emptyCellsNumber-1);
						updateDigitsStillFree(emptyCell);
						checkIfUniqueSolution(level + 1);
						if (digitNum == digitsStillFreeNumber) {
							sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = CELL_EMPTY;
							updateDigitsStillFree(emptyCell);
							if (level < emptyCellsNumber - 1)
								sortEmptyCells(level, emptyCellsNumber-1);
							totalPathsCounter++;
						}
					}
				}
			} else {
				sudokuBoard[emptyCell.rowIndex, emptyCell.colIndex] = CELL_EMPTY;
				updateDigitsStillFree(emptyCell);
			}
		}
		/*
		 * =====================================================
		 *               Board related methods
		 * =====================================================
		 */
		/**
		 * Perform current board backup
		 */
		private void backupCurrentBoard() {
			boardBackup = getBoardCopy();
		}
		/**
		 * Restore board state from backup
		 */
		private void restoreBoardFromBackup() {
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					sudokuBoard[i, j] = boardBackup[i, j];
			findEmptyCells();
		}
		/**
		 * To clear the Sudoku board.
		 */
		public void clearPuzzels() {
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++) {
					sudokuBoard[i, j] = CELL_EMPTY;
					emptyCellsPointer[i, j] = null;
				}
			for (int i = 0; i < BOARD_CELLS_NUMBER; i++)
				emptyCells[i] = new EmptyCell();
			emptyCellsNumber = 0;
			solvingState = SOLVING_STATE_NOT_STARTED;
			boardState = BOARD_STATE_EMPTY;
			solvedBoard = null;
			solutionPath = null;
			computingTime = 0;
			closedPathsCounter = 0;
			addMessage("(clearPuzzels) Clearing sudoku board - board is empty.", MSG_INFO);
		}
		/**
		 * Reset empty cells
		 */
		private void clearEmptyCells() {
			for (int i = 0; i < BOARD_CELLS_NUMBER; i++) {
				emptyCells[i].rowIndex = INDEX_NULL;
				emptyCells[i].colIndex = INDEX_NULL;
				emptyCells[i].digitsStillFreeNumber = -1;
			}
		}
		/**
		 * Search and initialize list of empty cells.
		 * @return    {@link SudokuBoard#BOARD_STATE_EMPTY}
		 *            {@link SudokuBoard#BOARD_STATE_READY}
		 *            {@link SudokuBoard#BOARD_STATE_ERROR}.
		 */
		private int findEmptyCells() {
			clearEmptyCells();
			int emptyCellIndex = 0;
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++)
					if (sudokuBoard[i, j] == CELL_EMPTY) {
						emptyCells[emptyCellIndex].rowIndex = i;
						emptyCells[emptyCellIndex].colIndex = j;
						emptyCellsPointer[i, j] = emptyCells[emptyCellIndex];
						findDigitsStillFree(emptyCells[emptyCellIndex]);
						if (emptyCells[emptyCellIndex].digitsStillFreeNumber == 0) {
							addMessage("Cell empty, but no still free digit to fill in - cell: " + i + ", " + j, MSG_ERROR);
							return BOARD_STATE_ERROR;
						}
						emptyCellIndex++;
					}
			emptyCellsNumber = emptyCellIndex;
			addMessage("(findEmptyCells) Empty cells evaluated - number of cells to solve: " + emptyCellsNumber, MSG_INFO);
			if (boardState == BOARD_STATE_EMPTY) {
				addMessage("(findEmptyCells) Empty board - please fill some values.", MSG_INFO);
			} else if (emptyCellsNumber > 0) {
				sortEmptyCells(0, emptyCellsNumber - 1);
				boardState = BOARD_STATE_READY;
			} else {
				if (SudokuStore.checkSolvedBoard(sudokuBoard) == true) {
					addMessage("(findEmptyCells) Puzzle already solved. Marking as solved, but no path leading to the solution.", MSG_INFO);
					boardState = BOARD_STATE_READY;
					solvingState = SOLVING_STATE_SOLVED;
					solvedBoard = SudokuStore.boardCopy(sudokuBoard);
				} else {
					addMessage("(findEmptyCells) No cells to solve + board error.", MSG_ERROR);
					boardState = BOARD_STATE_ERROR;
					return BOARD_STATE_ERROR;
				}
			}

			if (SudokuStore.checkPuzzle(sudokuBoard) != true) {
				addMessage("(findEmptyCells) Board contains an abvious error - duplicated digits.", MSG_ERROR);
				boardState = BOARD_STATE_ERROR;
				return BOARD_STATE_ERROR;
			}

			return BOARD_STATE_READY;
		}
		/**
		 * Find digits that still can be used in a given empty cell.
		 * @param emptyCell Empty cell to search still free digits for.
		 */
		private void findDigitsStillFree(EmptyCell emptyCell) {
			emptyCell.setAllDigitsStillFree();
			for (int j = 0; j < BOARD_SIZE; j++) {
				int boardDigit = sudokuBoard[emptyCell.rowIndex, j];
				if (boardDigit != CELL_EMPTY)
					emptyCell.digitsStillFree[boardDigit] = DIGIT_IN_USE;
			}
			for (int i = 0; i < BOARD_SIZE; i++) {
				int boardDigit = sudokuBoard[i, emptyCell.colIndex];
				if (boardDigit != CELL_EMPTY)
					emptyCell.digitsStillFree[boardDigit] = DIGIT_IN_USE;
			}
			SubSquare sub = SubSquare.getSubSqare(emptyCell);
			/*
			 * Mark digits used in a sub-square.
			 */
			for (int i = sub.rowMin; i < sub.rowMax; i++)
				for (int j = sub.colMin; j < sub.colMax; j++) {
					int boardDigit = sudokuBoard[i, j];
					if (boardDigit != CELL_EMPTY)
						emptyCell.digitsStillFree[boardDigit] = DIGIT_IN_USE;
				}
			/*
			 * Find number of still free digits to use.
			 */
			emptyCell.digitsStillFreeNumber = 0;
			for (int digit = 1; digit < 10; digit++)
				if (emptyCell.digitsStillFree[digit] == DIGIT_STILL_FREE)
					emptyCell.digitsStillFreeNumber++;
		}
		/**
		 * Find digits that still can be used in a given empty cell.
		 * @param emptyCell Empty cell to search still free digits for.
		 */
		private void updateDigitsStillFree(EmptyCell emptyCell) {
			for (int j = 0; j < BOARD_SIZE; j++)
				if (sudokuBoard[emptyCell.rowIndex, j] == CELL_EMPTY)
					findDigitsStillFree(emptyCellsPointer[emptyCell.rowIndex, j]);
			for (int i = 0; i < BOARD_SIZE; i++)
				if (sudokuBoard[i, emptyCell.colIndex] == CELL_EMPTY)
					findDigitsStillFree(emptyCellsPointer[i, emptyCell.colIndex]);
			SubSquare sub = SubSquare.getSubSqare(emptyCell);
			for (int i = sub.rowMin; i < sub.rowMax; i++)
				for (int j = sub.colMin; j < sub.colMax; j++)
					if (sudokuBoard[i, j] == CELL_EMPTY)
						findDigitsStillFree(emptyCellsPointer[i, j]);
			/*
			 * Mark digits used in a sub-sqre
			 */
			for (int i = sub.rowMin; i < sub.rowMax; i++)
				for (int j = sub.colMin; j < sub.colMax; j++) {
					int boardDigit = sudokuBoard[i, j];
					if (boardDigit != CELL_EMPTY)
						emptyCell.digitsStillFree[boardDigit] = DIGIT_IN_USE;
				}
			/*
			 * Find number of still free digits to use.
			 */
			emptyCell.digitsStillFreeNumber = 0;
			for (int digit = 1; digit < 10; digit++)
				if (emptyCell.digitsStillFree[digit] == DIGIT_STILL_FREE)
					emptyCell.digitsStillFreeNumber++;
		}
		/**
		 * Sorting empty cells list by ascending number of
		 * still free digits left that can be used in a context
		 * of a given empty cell.
		 *
		 * @param l    Starting left index.
		 * @param r    Starting right index.
		 */
		private void sortEmptyCells(int l, int r) {
			int i = l;
			int j = r;
			EmptyCell x;
			EmptyCell w;
			x = emptyCells[(l+r)/2];
			do {
				if (randomizeEmptyCells == true) {
					/*
					 * Adding randomization
					 */
					while ( emptyCells[i].orderPlusRndSeed() < x.orderPlusRndSeed() )
						i++;
					while ( emptyCells[j].orderPlusRndSeed() > x.orderPlusRndSeed() )
						j--;
				} else {
					/*
					 * No randomization
					 */
					while ( emptyCells[i].order() < x.order() )
						i++;
					while ( emptyCells[j].order() > x.order() )
						j--;
				}
				if (i<=j)
				{
					w = emptyCells[i];
					emptyCells[i] = emptyCells[j];
					emptyCells[j] = w;
					i++;
					j--;
				}
			} while (i <= j);
			if (l < j)
				sortEmptyCells(l,j);
			if (i < r)
				sortEmptyCells(i,r);
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
		 * Return current Sudou board state.
		 * @return  {@link SudokuBoard#BOARD_STATE_READY} or
		 *          {@link SudokuBoard#BOARD_STATE_EMPTY} or
		 *          {@link SudokuBoard#BOARD_STATE_ERROR}.
		 */
		public int getBoardState() {
			return boardState;
		}
		/**
		 * Method for copy current board content
		 * @return  Current copy of Sudoku board
		 */
		public int[,] getBoardCopy() {
			return SudokuStore.boardCopy(sudokuBoard);
		}
		/**
		 * Return current solving status.
		 * @return  {@link SudokuSolver#SOLVING_STATE_NOT_STARTED} or
		 *          {@link ErrorCodes#SUDOKUSOLVER_SOLVE_SOLVING_FAILED} or
		 *          {@link SudokuSolver#SOLVING_STATE_SOLVED}.
		 */
		public int getSolvingState() {
			return solvingState;
		}
		/**
		 * Gets array representing Sudoku board.
		 * @return Array representing Sudoku board.
		 */
		public int[,] getBoard() {
			return sudokuBoard;
		}
		/**
		 * Gets array representing solved Sudoku board.
		 * @return Array representing solved Sudoku board.
		 */
		public int[,] getSolvedBoard() {
			return solvedBoard;
		}
		/**
		 * Gets all solutions list evaluated by the findAllSolutions() method
		 * @return  List of all found solutions
		 * @see SudokuSolver#findAllSolutions()
		 */
		public List<SudokuBoard> getAllSolutionsList() {
			return solutionsList;
		}
		/**
		 * Gets array representing evaluated empty cells.
		 * meaning number of still free digits possible.
		 * @return Array representing evaluated empty cells.
		 */
		public int[,] getEmptyCells() {
			int[,] emptyCells = new int[BOARD_SIZE, BOARD_SIZE];
			if (boardState == BOARD_STATE_EMPTY) {
				for (int i = 0; i < BOARD_SIZE; i++)
					for (int j = 0; i < BOARD_SIZE; i++)
						emptyCells[i, j] = 9;
				return emptyCells;
			}
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; i < BOARD_SIZE; i++) {
					if (sudokuBoard[i, j] == CELL_EMPTY)
						emptyCells[i, j] = emptyCellsPointer[i, j].digitsStillFreeNumber;
					else
						emptyCells[i, j] = 0;
				}
			return emptyCells;
		}
		/**
		 * Get all current board cells.
		 * @return  Array of current board cells.
		 */
		public BoardCell[] getAllBoardCells() {
			BoardCell[] boardCells = new BoardCell[BOARD_CELLS_NUMBER];
			int cellIndex = 0;
			for (int i = 0; i < BOARD_SIZE; i++)
				for (int j = 0; j < BOARD_SIZE; j++) {
					boardCells[cellIndex] = new BoardCell(i, j, sudokuBoard[i, j]);
					cellIndex++;
				}
			return boardCells;
		}
		/**
		 * Return solution board cells keeping the solution
		 * path order. If error was encountered while solving
		 * path to the solution will be incomplete, but will show
		 * where solving process was aborted.
		 *
		 * @return Array of board cells that lead to the solution (keeping
		 *         the path order).
		 */
		public BoardCell[] getSolutionBoardCells() {
			if (solutionPath == null) return null;
			if (solutionPath.Count == 0) return null;
			return ArrayX.toArray(solutionPath);
		}
		/**
		 * Return solving time in seconds..
		 * @return  Solvnig time in seconds.
		 */
		public double getComputingTime() {
			return computingTime;
		}
		/**
		 * Number of routes that were assessed, but lead to nothing
		 * and required step back. The higher number to more computation was
		 * performed while solving.
		 * @return Number of closed routes while solving.
		 */
		public int getClosedRoutesNumber() {
			return closedPathsCounter;
		}
		/**
		 * By default random seed on empty cells is enabled. This parameter
		 * affects solving process only. Random seed on
		 * empty cells causes randomization on empty cells
		 * within empty cells with the same number of still free digits.
		 * Enabling extends ability to find different solutions, if exists.
		 */
		public void enableRndSeedOnEmptyCells() {
			randomizeEmptyCells = true;
		}
		/**
		 * By default random seed on empty cells is enabled. This parameter
		 * affects solving process only. Random seed on
		 * empty cells causes randomization on empty cells
		 * within empty cells with the same number of still free digits.
		 * Disabling limits ability to find different solutions, if exists.
		 */
		public void disableRndSeedOnEmptyCells() {
			randomizeEmptyCells = false;
		}
		/**
		 * By default random seed on free digits is enabled. This parameter
		 * affects solving process only. Random seed on
		 * free digits causes randomization on accessing free digits
		 * for a given empty cells. Each free digits is a starting point
		 * for a new recursive sub-path potentially leading to solution.
		 * Enabling extends ability to find different solutions, if exists.
		 */
		public void enableRndSeedOnFreeDigits() {
			randomizeFreeDigits = true;
		}
		/**
		 * By default random seed on free digits is enabled. This parameter
		 * affects solving process only. Random seed on
		 * free digits causes randomization on accessing free digits
		 * for a given empty cells. Each free digits is a starting point
		 * for a new recursive sub-path potentially leading to solution.
		 * Disabling limits ability to find different solutions, if exists.
		 */
		public void disableRndSeedOnFreeDigits() {
			randomizeFreeDigits = false;
		}
		/**
		 * Returns board state summary.
		 * @return Board state summary as string.
		 */
		private String boardStateToString() {
			String boardStateStr = "Board: ";
			switch(boardState) {
			case BOARD_STATE_EMPTY:
				boardStateStr = boardStateStr + "empty";
				break;
			case BOARD_STATE_ERROR:
				boardStateStr = boardStateStr + "error";
				break;
			case BOARD_STATE_LOADED:
				boardStateStr = boardStateStr + "loaded";
				break;
			case BOARD_STATE_READY:
				boardStateStr = boardStateStr + "ready";
				break;
			}
			boardStateStr = boardStateStr + SudokuStore.NEW_LINE_SEPARATOR + "Initial empty cells: " + emptyCellsNumber;
			boardStateStr = boardStateStr + SudokuStore.NEW_LINE_SEPARATOR + "Solving : ";
			switch(solvingState) {
			case SOLVING_STATE_NOT_STARTED:
				boardStateStr = boardStateStr + "not started";
				break;
			case SOLVING_STATE_STARTED:
				boardStateStr = boardStateStr + "started";
				break;
			case SOLVING_STATE_SOLVED:
				boardStateStr = boardStateStr + "solved";
				break;
			case ErrorCodes.SUDOKUSOLVER_SOLVE_SOLVING_FAILED:
				boardStateStr = boardStateStr + "failed";
				break;
			}
			return boardStateStr;
		}
		/**
		 * Returns string board and empty cells representation.
		 * @return Board and empty cells representation.
		 */
		public String boardAndEmptyCellsToString() {
			return SudokuStore.boardAndEmptyCellsToString(sudokuBoard, getEmptyCells()) + boardStateToString() + SudokuStore.NEW_LINE_SEPARATOR;
		}
		/**
		 * Returns string board (only) representation.
		 * @return Board (only) representation.
		 */
		public String boardToString() {
			return SudokuStore.boardToString(sudokuBoard) + boardStateToString() + SudokuStore.NEW_LINE_SEPARATOR;
		}
		/**
		 * Returns string empty cells (only) representation.
		 * @return Empty cells (only) representation.
		 */
		public String emptyCellsToString() {
			return SudokuStore.emptyCellsToString( getEmptyCells() ) + boardStateToString() + SudokuStore.NEW_LINE_SEPARATOR;
		}
		/**
		 * Return string representation of cells that lead to
		 * the solution, keeping the sequence.
		 * @return  String representation of entries that lead to the solution.
		 */
		public String solutionPathToString() {
			return SudokuStore.solutionPathToString( getSolutionBoardCells() );
		}
	}
}