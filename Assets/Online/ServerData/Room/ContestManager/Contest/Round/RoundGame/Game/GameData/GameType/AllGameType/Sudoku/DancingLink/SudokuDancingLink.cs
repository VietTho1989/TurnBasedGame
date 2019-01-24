using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class SudokuDancingLink
	{

		public static void main()
		{
			// Create an instance.

			SudokuDancingLink sudoku = new SudokuDancingLink();

			// Define some puzzles.

			int[,] puzzle1 =
			{{0, 0, 0, 0, 0, 0, 0, 0, 0},
				{0, 0, 4, 9, 0, 7, 1, 0, 0},
				{0, 7, 8, 5, 0, 1, 6, 4, 0},
				{9, 0, 0, 4, 0, 8, 0, 0, 3},
				{0, 0, 0, 0, 0, 0, 0, 0, 0},
				{5, 0, 0, 6, 0, 9, 0, 0, 7},
				{0, 3, 9, 1, 0, 4, 5, 2, 0},
				{0, 0, 1, 7, 0, 5, 3, 0, 0},
				{0, 0, 0, 0, 0, 0, 0, 0, 0}};

			int[,] puzzle2 =
			{{0, 0, 0, 9, 0, 0, 8, 5, 0},
				{0, 0, 3, 0, 0, 8, 0, 0, 0},
				{0, 2, 0, 0, 0, 4, 1, 3, 0},
				{0, 0, 0, 0, 5, 9, 0, 7, 0},
				{7, 0, 0, 0, 0, 0, 0, 0, 6},
				{0, 4, 0, 2, 7, 0, 0, 0, 0},
				{0, 5, 2, 8, 0, 0, 0, 6, 0},
				{0, 0, 0, 1, 0, 0, 2, 0, 0},
				{0, 9, 4, 0, 0, 2, 0, 0, 0}};

			int[,] puzzle3 =
			{{0, 0, 3, 0, 0, 8, 0, 0, 6},
				{0, 0, 0, 4, 6, 0, 0, 0, 0},
				{0, 0, 0, 1, 0, 0, 5, 9, 0},
				{0, 9, 8, 0, 0, 0, 6, 4, 0},
				{0, 0, 0, 0, 7, 0, 0, 0, 0},
				{0, 1, 7, 0, 0, 0, 9, 5, 0},
				{0, 2, 4, 0, 0, 1, 0, 0, 0},
				{0, 0, 0, 0, 4, 6, 0, 0, 0},
				{6, 0, 0, 5, 0, 0, 8, 0, 0}};

			int[,] puzzle4 =
			{{6, 0, 0, 9, 0, 0, 2, 0, 4},
				{0, 0, 8, 0, 1, 0, 0, 6, 0},
				{0, 0, 0, 6, 0, 0, 5, 0, 0},
				{0, 3, 0, 0, 0, 0, 0, 4, 5},
				{0, 0, 6, 0, 0, 0, 9, 0, 0},
				{4, 8, 0, 0, 0, 0, 0, 3, 0},
				{0, 0, 1, 0, 0, 5, 0, 0, 0},
				{0, 7, 0, 0, 2, 0, 1, 0, 0},
				{8, 0, 2, 0, 0, 7, 0, 0, 9}};

			// Solve them.

			sudoku.solve(puzzle1);
			sudoku.solve(puzzle2);
			sudoku.solve(puzzle3);
			sudoku.solve(puzzle4);
		}

		public List<int[,]> results = new List<int[,]>();

		// Solve a puzzle.
		public void solve(int[,] puzzle)
		{
			Debug.LogError ("solve puzzle");
			// Create a new Dancing Links.
			DancingLinks dl = new DancingLinks(puzzle);
			// Solve the puzzle.
			dl.solve(this);
		}

		// Print the solution.

		public static void report(int[,] solution)
		{
			StringBuilder builder = new StringBuilder ();
			for (int y = 0; y < PUZZLE_SIDE; y++)
			{
				for (int x = 0; x < PUZZLE_SIDE; x++)
					builder.Append (solution [x, y] + " ");
				builder.AppendLine ();
			}
			builder.AppendLine ("-----------------");
			Debug.LogError ("" + builder.ToString ());
		}

		///////////////////////////////////////////////////////////////////////////////
		//
		//  Define constants for the dimensions of the puzzle.
		//
		///////////////////////////////////////////////////////////////////////////////

		public const int PUZZLE_SIDE = 9;
		public const int SQUARE_SIDE = 3;
		public const int PUZZLE_SIZE = 81;
		public const int COLUMN_SIZE = 324;

		///////////////////////////////////////////////////////////////////////////////
		//
		//  Class Node has four links: left, right, up, down, which reference
		//  adjacent nodes, a link which references the column and a row
		//  number.
		//
		///////////////////////////////////////////////////////////////////////////////

		public class Node
		{
			public Node l;
			public Node r;
			public Node u;
			public Node d;
			public Column c;
			public int n;

			// Create a self referencing node.

			public Node(Column c, int n)
			{
				this.l = this;
				this.r = this;

				this.u = this;
				this.d = this;

				// Column and row number.

				this.c = c;
				this.n = n;

				// If the column isn't null, add this node to it.

				if (c != null)
					c.add(this);
			}

			// Remove a row of nodes.

			public void remove()
			{
				Node n = this;

				// Cover this node's column and move on to the next right.

				do
				{
					n.c.cover();
					n = n.r;
				}

				// While we haven't got back to this node.

				while (n != this);
			}

			// Add a node to the left of this node.

			public virtual void add(Node n)
			{
				n.l = this.l;
				n.r = this;

				this.l.r = n;
				this.l = n;
			}

			public virtual void cover()
			{

			}

		}

		///////////////////////////////////////////////////////////////////////////////
		//
		//  Class Column inherits the links from the Node class and has a column size.
		//
		///////////////////////////////////////////////////////////////////////////////

		public class Column : Node
		{
			public int s;

			// Create a self referencing column using the Node constructor.

			public Column(Column c, int n) : base(null, n)
			{
				// If the column isn't null add this one to it.
				if (c != null)
					c.add(this);
			}

			// This is the procedure cover(c) from the Dancing Links
			// algorithm.

			public override void cover()
			{
				// Cover this column.

				r.l = l;
				l.r = r;

				// For all the rows in this column going down...

				for (Node i = d; i != this; i = i.d)

					// For all the nodes in this row except this one,
					// going right...

					for (Node j = i.r; j != i; j = j.r)
					{
						// Cover this row.

						j.u.d = j.d;
						j.d.u = j.u;

						// Adjust the column size.

						j.c.s--;
					}
			}

			// This is the procedure uncover(c) from the Dancing Links
			// algorithm.

			public void uncover()
			{
				// For all the rows in this column going up...
				for (Node i = u; i != this; i = i.u)
					// For all the nodes in this row except this one,
					// going left...
					for (Node j = i.l; j != i; j = j.l) {
						// Uncover this row.
						j.u.d = j;
						j.d.u = j;
						// Adjust the column size.
						j.c.s++;
					}
				// Uncover this column.
				r.l = this;
				l.r = this;
			}

			// Add a column to the left of this column.
			public void add(Column c)
			{
				c.l = this.l;
				c.r = this;

				this.l.r = c;
				this.l = c;
			}

			// Add a node to the end of this column.
			public override void add(Node n)
			{
				n.u = this.u;
				n.d = this;

				this.u.d = n;
				this.u = n;

				// Increment the column size.

				s++;
			}
		}

		///////////////////////////////////////////////////////////////////////////////
		//
		//  Class DancingLinks implements the Dancing Links algorithm adapted
		//  for Sudoku puzzles.
		//
		///////////////////////////////////////////////////////////////////////////////
		public class DancingLinks
		{
			public SudokuDancingLink sudoku;
			public bool stop;
			public int[] stats;
			public int index;
			public Column h;
			public Node[] o;

			// Create a column head and add 324 (81 x 4) columns. 729 (9 x
			// 9 x 9) rows of four nodes are added to the columns. If a
			// row is part of the puzzle it is removed from the matrix and
			// added to the solution.

			public DancingLinks(int[,] p)
			{
				// Column row head.

				h = new Column(null, 0);
				Column[] m = new Column[COLUMN_SIZE];

				// Create the row of columns.

				for (int i = 0; i < COLUMN_SIZE; i++)
					m[i] = new Column(h, 0);

				// List of rows that are part of the solution.

				Node[] l = new Node[PUZZLE_SIZE];
				int temp = 0;

				// For each row, column and possible digit.

				for (int r = 0; r < PUZZLE_SIDE; r++)
					for (int c = 0; c < PUZZLE_SIDE; c++)
						for (int d = 0; d < PUZZLE_SIDE; d++) {
							// Calculate row number.
							int k = 1 + (r * PUZZLE_SIZE) + (c * PUZZLE_SIDE) + d;

							// Create the row of nodes.
							Node n = new Node(m[(r * PUZZLE_SIDE) + c], k);
							n.add(new Node(m[(PUZZLE_SIZE * 1) +
								(r * PUZZLE_SIDE) + d], k));
							n.add(new Node(m[(PUZZLE_SIZE * 2) +
								(c * PUZZLE_SIDE) + d], k));
							n.add(new Node(m[(PUZZLE_SIZE * 3) +
								((((r / SQUARE_SIDE) * SQUARE_SIDE) +
									(c / SQUARE_SIDE)) * PUZZLE_SIDE) +
								d], k));

							// If this row is in the puzzle, add it to the
							// list.

							if (p[c,r] == (d + 1))
								l[temp++] = n;
						}

				// Create an array for the output.
				o = new Node[PUZZLE_SIZE];

				// Remove the rows in the list and add them to the output.
				for (int j = 0; j < temp; j++) {
					l[j].remove();
					o[index++] = l[j];
				}

				// Create an array for the stats.

				stats = new int[PUZZLE_SIZE];
			}

			#region report result

			// Rearrange the output to match the puzzle.
			public void report(int[] o)
			{
				// Create an array for the result.

				int[,] a = new int[PUZZLE_SIDE,PUZZLE_SIDE];

				// Convert the row number back to row, column, digit.

				for (int i = 0; i < PUZZLE_SIZE; i++) {
					int v = o[i];

					int d = v % PUZZLE_SIDE;
					int c = (v / PUZZLE_SIDE) % PUZZLE_SIDE;
					int r = (v / PUZZLE_SIZE) % PUZZLE_SIDE;

					a[c, r] = d + 1;
				}

				// Report the result.
				SudokuDancingLink.report(a);
				sudoku.results.Add (a);

				// Create an array for the stats.

				int[,] s = new int[PUZZLE_SIDE, PUZZLE_SIDE];

				for (int i = 0; i < PUZZLE_SIZE; i++)
					s[i / PUZZLE_SIDE,i % PUZZLE_SIDE] = stats[i];

				// Report stats.

				SudokuDancingLink.report(s);
			}

			#endregion

			// Start the search process.

			public void solve(SudokuDancingLink s)
			{
				sudoku = s;
				sudoku.results.Clear ();
				search(index);
			}

			// This is the procedure search(k) from the Dancing Links
			// algorithm with an added feature to report only one
			// solution.

			public void search(int k)
			{
				// Debug.LogError ("search: k: " + k);
				// If a result has already been found, return.
				if (stop)
					return;

				// If there are no more columns, report the result.

				if (h.r == h)
				{
					int[] a = new int[k];

					// Extract the row numbers.

					for (int i = 0; i < k; i++)
						a[i] = o[i].n - 1;

					// Report the result and set the stop flag.

					report(a);
					stop = true;
				}

				// Else find the shortest column and cover it.

				else
				{
					Column c = null;
					int s = int.MaxValue;

					// Increment stats;

					stats[k]++;

					// Find the shortest column.

					for (Column j = (Column) h.r; j != h; j = (Column) j.r)
						if (s > j.s)
						{
							c = j;
							s = j.s;
						}

					// Cover it.

					c.cover();

					// For each row in the column...

					for (Node r = c.d; r != c; r = r.d)
					{
						// Skip this if a result has been found.

						if (stop)
							break;

						// Save the row in the output array.

						o[k] = r;

						// For each node in this row, cover it's column.

						for (Node j = r.r; j != r; j = j.r)
							j.c.cover();

						// Recurse with k + 1.

						search(k + 1);

						// For each node in this row, uncover it's column.

						for (Node j = r.l; j != r; j = j.l)
							j.c.uncover();
					}

					// Uncover the column.

					c.uncover();
				}
			}
		}

	}
}