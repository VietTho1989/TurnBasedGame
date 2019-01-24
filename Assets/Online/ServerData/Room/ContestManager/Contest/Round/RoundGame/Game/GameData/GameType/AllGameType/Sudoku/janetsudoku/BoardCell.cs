/*
 * @(#)BoardCell.cs        1.0.0    2016-03-19
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
	 * Data type for board entry, containing row and column indexes and digit.
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
	public class BoardCell {
		/**
		 * Empty cell.
		 */
		public const int EMPTY = EmptyCell.CELL_ID;
		/**
		 * Cell is not pointing to any cells on the board.
		 */
		public const int INDEX_NULL = -1;
		/**
		 * Row index of board entry.
		 */
		public int rowIndex;
		/**
		 * Column index of board entry.
		 */
		public int colIndex;
		/**
		 * Entry digit.
		 */
		public int digit;
		/**
		 * Random seed.
		 */
		internal double randomSeed;
		/**
		 * Digits still free number.
		 */
		internal int digitsStillFreeNumber;
		/**
		 * Default constructor - uninitialized entry.
		 */
		/**
		 * Marker if analyzed digit 0...9 is still not used.
		 */
		internal const int DIGIT_STILL_FREE = 1;
		/**
		 * Digit 0...9 can not be used in that place.
		 */
		internal const int DIGIT_IN_USE = 2;
		/**
		 * Cell is not pointing to any cells on the board.
		 */
		public BoardCell() {
			rowIndex = INDEX_NULL;
			colIndex = INDEX_NULL;
			digit = EMPTY;
			randomSeed = SudokuStore.nextRandom();
			digitsStillFreeNumber = -1;
		}
		/**
		 * Constructor - initialized entry.
		 * @param rowIndex   Row index.
		 * @param colIndex   Column index.
		 * @param digit    Entry digit.
		 */
		public BoardCell(int rowIndex, int colIndex, int digit) {
			this.rowIndex = rowIndex;
			this.colIndex = colIndex;
			this.digit = digit;
			randomSeed = SudokuStore.nextRandom();
			digitsStillFreeNumber = -1;
		}
		/**
		 * Package level method
		 * @return
		 */
		internal int order() {
			return digitsStillFreeNumber;
		}
		/**
		 * Package level method
		 * @return
		 */
		internal double orderPlusRndSeed() {
			return digitsStillFreeNumber + randomSeed;
		}
	}
}