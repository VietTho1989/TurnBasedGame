/*
 * @(#)SudokuBoard.cs        1.0.0    2016-03-19
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
using System;

namespace org.mariuszgromada.math.janetsudoku {
	/**
	 * Data type used while returning all solutions list
	 *
	 * @see SudokuSolver
	 * @see SudokuSolver#findAllSolutions()
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
	public class SudokuBoard {
		/**
		 * Sudoku board size.
		 */
		public const int BOARD_SIZE = 9;
		/**
		 * Sudoku board sub-square size.
		 */
		public const int BOARD_SUB_SQURE_SIZE = 3;
		/**
		 * Number of 9x3 column segments or 3x9 row segments.
		 */
		public const int BOARD_SEGMENTS_NUMBER = 3;
		/**
		 * We will use array indexes from 1.,.n, instead 0...n-1
		 */
		internal const int BOARD_MAX_INDEX = BOARD_SIZE + 1;
		/**
		 * Number of cells on the Sudoku board.
		 */
		internal const int BOARD_CELLS_NUMBER = BOARD_SIZE * BOARD_SIZE;
		/**
		 * Sudoku board was successfully loaded.
		 */
		public const int BOARD_STATE_EMPTY = 1;
		/**
		 * Sudoku board was successfully loaded.
		 */
		public const int BOARD_STATE_LOADED = 2;
		/**
		 * Sudoku board is ready to start solving process.
		 */
		public const int BOARD_STATE_READY = 3;
		/**
		 * Sudoku board is ready to start solving process.
		 */
		public const int BOARD_STATE_ERROR = ErrorCodes.SUDOKUSOLVER_BOARD_ERROR;
		/**
		 * Path number gives the information on how many routes
		 * were verified until solutions was found.
		 */
		public int pathNumber;
		/**
		 * Sudoku board array.
		 */
		public int[,] board;
		/**
		 * Default constructor.
		 */
		public SudokuBoard() {
			board = new int[BOARD_SIZE, BOARD_SIZE];
			pathNumber = -1;
		}
	}
}