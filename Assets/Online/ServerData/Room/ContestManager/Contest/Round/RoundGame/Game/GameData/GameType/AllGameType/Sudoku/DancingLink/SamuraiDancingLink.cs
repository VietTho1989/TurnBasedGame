using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class SamuraiDancingLink
	{
		public static void main()
		{
			// Create an instance.

			SamuraiDancingLink samurai = new SamuraiDancingLink();

			// Define some puzzles.

			int[,] puzzle1 = {
				{ 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 6, 0, 0 },
				{ 0, 0, 7, 3, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 5 },
				{ 0, 5, 0, 0, 9, 0, 0, 6, 3, 0, 0, 0, 0, 0, 8, 0, 0, 0, 0, 4, 0 },
				{ 0, 8, 0, 0, 7, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 8, 0, 0 },
				{ 0, 0, 6, 2, 0, 0, 8, 0, 0, 0, 0, 0, 7, 0, 0, 0, 9, 0, 5, 0, 0 },
				{ 4, 0, 0, 5, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 7, 0 },
				{ 0, 3, 0, 0, 5, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
				{ 0, 0, 8, 0, 0, 9, 0, 3, 0, 0, 4, 9, 6, 8, 0, 4, 0, 0, 2, 0, 0 },
				{ 0, 0, 9, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 8, 0 },
				{ 0, 0, 0, 0, 0, 0, 9, 0, 0, 6, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 3, 0, 0, 4, 0, 0, 1, 5, 8, 0, 0, 0, 0, 6, 0, 0, 0 },
				{ 0, 0, 0, 9, 0, 0, 0, 2, 0, 3, 0, 0, 0, 9, 0, 0, 0, 4, 0, 0, 6 },
				{ 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 2, 0 },
				{ 0, 0, 0, 3, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0 },
				{ 7, 0, 0, 0, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 7, 0, 0 },
				{ 0, 6, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 3, 5, 6, 0, 0, 0, 0, 8, 0 },
				{ 3, 0, 0, 2, 9, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 2, 6, 0, 0, 0, 1 },
				{ 0, 0, 5, 0, 0, 4, 0, 0, 8, 0, 0, 0, 0, 0, 3, 0, 0, 5, 0, 0, 0 },
				{ 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 9, 0, 0 }
			};
			int[,] puzzle2 = {
				{ 4, 9, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 8, 0, 0, 0, 6, 7, 9 },
				{ 8, 0, 0, 0, 0, 0, 0, 9, 7, 0, 0, 0, 0, 4, 0, 8, 0, 0, 0, 0, 3 },
				{ 1, 0, 0, 0, 0, 0, 6, 0, 8, 0, 0, 0, 0, 0, 2, 0, 9, 0, 0, 0, 4 },
				{ 0, 0, 0, 3, 0, 5, 0, 7, 0, 0, 0, 0, 0, 0, 0, 2, 0, 6, 0, 0, 0 },
				{ 0, 0, 5, 0, 4, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0 },
				{ 0, 8, 0, 2, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 9, 0, 0, 0 },
				{ 7, 0, 3, 0, 0, 0, 0, 0, 5, 0, 0, 0, 7, 0, 0, 0, 2, 0, 1, 0, 0 },
				{ 2, 6, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 1, 0, 0, 0, 0, 7, 0, 2, 0 },
				{ 0, 0, 0, 0, 0, 0, 7, 1, 6, 0, 5, 0, 4, 2, 9, 0, 0, 0, 7, 3, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				{ 0, 9, 7, 0, 0, 0, 3, 4, 8, 0, 1, 0, 9, 7, 6, 0, 0, 0, 0, 0, 0 },
				{ 0, 3, 0, 7, 0, 0, 0, 0, 9, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 9, 2 },
				{ 0, 0, 4, 0, 9, 0, 0, 0, 7, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 0, 8 },
				{ 0, 0, 0, 8, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 9, 0, 8, 0 },
				{ 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 8, 0, 4, 0, 0 },
				{ 0, 0, 0, 5, 0, 7, 0, 0, 0, 0, 0, 0, 0, 2, 0, 4, 0, 1, 0, 0, 0 },
				{ 7, 0, 0, 0, 5, 0, 2, 0, 0, 0, 0, 0, 7, 0, 5, 0, 0, 0, 0, 0, 6 },
				{ 5, 0, 0, 0, 0, 9, 0, 8, 0, 0, 0, 0, 2, 8, 0, 0, 0, 0, 0, 0, 9 },
				{ 4, 6, 9, 0, 0, 0, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 5 }
			};

			// Solve them.

			samurai.solve(puzzle1);
			samurai.solve(puzzle2);
		}

		// Solve a puzzle.

		public void solve(int[,] puzzle)
		{
			// Create a new Dancing Links.

			DancingLinks dl = new DancingLinks(puzzle);

			// Print the puzzle for checking.

			report(puzzle);

			// Solve the puzzle.

			dl.solve(this);
		}

		// Print the solution.

		public void report(int[,] solution)
		{
			StringBuilder builder = new StringBuilder();
			for (int r = 0; r < PUZZLE_SIDE; r++) {
				for (int c = 0; c < PUZZLE_SIDE; c++)
					if (solution [r, c] > 0)
						builder.Append (solution [r, c] + " ");
					else
						builder.Append (". ");

				builder.AppendLine ();
			}
			builder.AppendLine("-----------------------------------------");
			Debug.LogError(builder.ToString());
		}

		///////////////////////////////////////////////////////////////////////////////
		//
		//  Define constants for the dimensions of the puzzle.
		//
		///////////////////////////////////////////////////////////////////////////////

		public const int PUZZLE_SIDE = 21;
		public const int PUZZLE_SIZE = 441;
		public const int SUDOKU_SIDE = 9;
		public const int SUDOKU_SIZE = 81;
		public const int SQUARE_SIDE = 3;
		public const int COLUMN_SIZE = 1692;

		///////////////////////////////////////////////////////////////////////////////
		//
		//   Declare an array which defines which squares are in which puzzle,
		//   including those in two puzzles, and those that aren't in any
		//   puzzle, an array which defines which puzzle row a samurai row is
		//   in, and an array which defines which puzzle column a samurai
		//   column is in.
		//
		///////////////////////////////////////////////////////////////////////////////

		public static readonly int[][] SAMURAI_SQUARE = new int[49][];
		public static readonly int[][] SUDOKU_ROW = new int[5][];
		public static readonly int[][] SUDOKU_COLUMN = new int[5][];

		static SamuraiDancingLink()
		{
			// samurai square
			{
				SAMURAI_SQUARE [0] = new int[]{ 0 };
				SAMURAI_SQUARE [1] = new int[]{ 0 };
				SAMURAI_SQUARE [2] = new int[]{ 0 };  
				SAMURAI_SQUARE [3] = new int[]{ };
				SAMURAI_SQUARE [4] = new int[]{ 1 };
				SAMURAI_SQUARE [5] = new int[]{ 1 };
				SAMURAI_SQUARE [6] = new int[]{ 1 };

				SAMURAI_SQUARE [7] = new int[]{ 0 };
				SAMURAI_SQUARE [8] = new int[]{ 0 };
				SAMURAI_SQUARE [9] = new int[]{ 0 };  
				SAMURAI_SQUARE [10] = new int[]{ };    
				SAMURAI_SQUARE [11] = new int[]{ 1 };
				SAMURAI_SQUARE [12] = new int[]{ 1 };
				SAMURAI_SQUARE [13] = new int[]{ 1 };

				SAMURAI_SQUARE [14] = new int[]{ 0 };
				SAMURAI_SQUARE [15] = new int[]{ 0 };
				SAMURAI_SQUARE [16] = new int[]{ 0, 2 };
				SAMURAI_SQUARE [17] = new int[]{ 2 }; 
				SAMURAI_SQUARE [18] = new int[]{ 1, 2 }; 
				SAMURAI_SQUARE [19] = new int[]{ 1 };
				SAMURAI_SQUARE [20] = new int[]{ 1 };

				SAMURAI_SQUARE [21] = new int[]{ };
				SAMURAI_SQUARE [22] = new int[]{ };
				SAMURAI_SQUARE [23] = new int[]{ 2 };
				SAMURAI_SQUARE [24] = new int[]{ 2 };
				SAMURAI_SQUARE [25] = new int[]{ 2 };
				SAMURAI_SQUARE [26] = new int[]{ };
				SAMURAI_SQUARE [27] = new int[]{ };

				SAMURAI_SQUARE [28] = new int[]{ 3 };
				SAMURAI_SQUARE [29] = new int[]{ 3 };
				SAMURAI_SQUARE [30] = new int[]{ 2, 3 };
				SAMURAI_SQUARE [31] = new int[]{ 2 };
				SAMURAI_SQUARE [32] = new int[]{ 2, 4 };
				SAMURAI_SQUARE [33] = new int[]{ 4 };
				SAMURAI_SQUARE [34] = new int[]{ 4 };

				SAMURAI_SQUARE [35] = new int[]{ 3 };
				SAMURAI_SQUARE [36] = new int[]{ 3 }; 
				SAMURAI_SQUARE [37] = new int[]{ 3 };
				SAMURAI_SQUARE [38] = new int[]{ };
				SAMURAI_SQUARE [39] = new int[]{ 4 };
				SAMURAI_SQUARE [40] = new int[]{ 4 };
				SAMURAI_SQUARE [41] = new int[]{ 4 };

				SAMURAI_SQUARE [42] = new int[]{ 3 };
				SAMURAI_SQUARE [43] = new int[]{ 3 };
				SAMURAI_SQUARE [44] = new int[]{ 3 };
				SAMURAI_SQUARE [45] = new int[]{ };
				SAMURAI_SQUARE [46] = new int[]{ 4 };
				SAMURAI_SQUARE [47] = new int[]{ 4 };
				SAMURAI_SQUARE [48] = new int[]{ 4 };
			}
			// SUDOKU_ROW
			{
				SUDOKU_ROW [0] = new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_ROW [1] = new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_ROW [2] = new int[]{ -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_ROW [3] = new int[]{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_ROW [4] = new int[]{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			}
			// SUDOKU_COLUMN
			{
				SUDOKU_COLUMN [0] = new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_COLUMN [1] = new int[]{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_COLUMN [2] = new int[]{ -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_COLUMN [3] = new int[]{ 0, 1, 2, 3, 4, 5, 6, 7, 8 };
				SUDOKU_COLUMN [4] = new int[]{ -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 };
			}
		}

		///////////////////////////////////////////////////////////////////////////////
		//
		//  Class DancingLinks implements the Dancing Links algorithm adapted
		//  for Samurai Sudoku puzzles.
		//
		///////////////////////////////////////////////////////////////////////////////

		public class DancingLinks
		{
			SamuraiDancingLink samurai;
			bool stop;
			int[] stats;
			int index;
			Column h;
			Node[] o;

			// Create a column head and add 1692 (21 x 21 = 441 slots + 5
			// puzzles x 9 rows x 9 digits = 405 + 5 puzzles x 9 columns x
			// 9 digits = 405 + 49 slots x 9 digits = 441) columns. Empty
			// columns will be removed. 3645 (9 rows x 9 columns x 9
			// digits x 5 puzzles) rows of nodes are added to the
			// columns. Those rows corresponding to slots in one puzzle
			// will have four nodes, those overlapping two puzzles will
			// have six nodes. If a row is part of the puzzle it is
			// removed from the matrix and added to the solution.

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

				// For each samurai (big) row, column and possible digit.

				for (int r = 0; r < PUZZLE_SIDE; r++)
					for (int c = 0; c < PUZZLE_SIDE; c++)
						for (int d = 0; d < SUDOKU_SIDE; d++)
						{
							// Calculate row number for possible
							// move in samurai (big) puzzle.

							int k = 1 + (r * PUZZLE_SIDE * SUDOKU_SIDE) +
								(c * SUDOKU_SIDE) + d;

							// See what samurai (big) square we're in.

							int s = (c / 3) + ((r / 3) * 7);

							// If the slot is in a puzzle create a row of
							// nodes.

							if (SAMURAI_SQUARE[s].Length > 0)
							{
								// Create a node for the slot.

								Node n = new Node(m[(r * PUZZLE_SIDE) + c], k);

								// For each puzzle that this slot is in...

								for (int j = 0; j < SAMURAI_SQUARE[s].Length; j++)
								{
									// Find which puzzle the slot is in.

									int pz = SAMURAI_SQUARE[s][j];

									// Find the puzzle row and column.

									int pr = SUDOKU_ROW[pz][r];
									int pc = SUDOKU_COLUMN[pz][c];

									// Add a node for the puzzle, row and
									// digit.

									n.add(new Node(m[PUZZLE_SIZE +
										(pz * SUDOKU_SIZE) +
										(pr * SUDOKU_SIDE) + d], k));

									// Add a node for the puzzle, column
									// and digit.

									n.add(new Node(m[PUZZLE_SIZE + 405 +
										(pz * SUDOKU_SIZE) +
										(pc * SUDOKU_SIDE) + d], k));
								}

								// Add a node for the samurai (big) square
								// and digit.

								n.add(new Node(m[PUZZLE_SIZE + 405 + 405 +
									(s * SUDOKU_SIDE) + d], k));

								// If this row is in the puzzle, add it to the
								// list.

								if (p[c,r] == (d + 1))
									l[temp++] = n;
							}
						}

				// There will be empty columns corresponding to the unused
				// slots in the samurai (big) puzzle. Remove the empty
				// columns.

				for (Column c = (Column) h.r; c != h; c = (Column) c.r)
					if (c.s == 0)
						c.cover();

				// Create an array for the output.

				o = new Node[PUZZLE_SIZE];

				// Remove the rows in the list and add them to the output.

				for (int j = 0; j < temp; j++)
				{
					l[j].remove();
					o[index++] = l[j];
				}

				// Create an array for the stats.

				stats = new int[PUZZLE_SIZE];
			}

			// Rearrange the output to match the puzzle.

			public void report(int[] o)
			{
				// Create an array for the result.

				int[,] a = new int[PUZZLE_SIDE,PUZZLE_SIDE];

				// Convert the row number back to row, column, digit.

				for (int i = 0; i < o.Length; i++)
				{
					int v = o[i];

					int d = v % SUDOKU_SIDE;
					int c = (v / SUDOKU_SIDE) % PUZZLE_SIDE;
					int r = (v / (PUZZLE_SIDE * SUDOKU_SIDE)) % PUZZLE_SIDE;

					a[c,r] = d + 1;
				}

				// Report the result.

				samurai.report(a);

				// Create an array for the stats

				int[,] s = new int[PUZZLE_SIDE,PUZZLE_SIDE];

				for (int i = 0; i < o.Length; i++)
					s[i / PUZZLE_SIDE,i % PUZZLE_SIDE] = stats[i];

				// Report stats.

				samurai.report(s);
			}

			// Start the search process.

			public void solve(SamuraiDancingLink s)
			{
				samurai = s;
				search(index);
			}

			// This is the procedure search(k) from the Dancing Links
			// algorithm with an added feature to report only one
			// solution.

			public void search(int k)
			{
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
				if (c != null)
					c.add(this);
			}

			// This is the procedure cover(c) from the Dancing Links
			// algorithm.

			public void cover()
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

					for (Node j = i.l; j != i; j = j.l)
					{
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
	}
}