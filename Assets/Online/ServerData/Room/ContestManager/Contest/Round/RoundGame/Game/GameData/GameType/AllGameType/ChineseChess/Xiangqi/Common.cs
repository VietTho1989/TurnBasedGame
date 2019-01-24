using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;

namespace Xiangqi
{
	public class Common
	{

		public enum RepStatus
		{
			REP_NONE = 0,
			REP_DRAW = 1,
			REP_LOSS = 3,
			REP_WIN = 5
		}

		public enum Piece
		{
			None = 0,

			RedGeneral = 1,
			RedAdvisor = 2,
			RedElephant = 3,
			RedHorse = 4,
			RedChariot = 5,
			RedCannon = 6,
			RedPawn = 7,

			BlackGeneral = 8,
			BlackAdvisor = 9,
			BlackElephant = 10,
			BlackHorse = 11,
			BlackChariot = 12,
			BlackCannon = 13,
			BlackPawn = 14
		}

		#region Convert Xiangqi to board array

		const int RANK_TOP = 3;
		const int RANK_BOTTOM = 12;
		const int FILE_LEFT = 3;
		const int FILE_CENTER = 7;
		const int FILE_RIGHT = 11;

		public static int[,] getBoardArray(List<byte> ucpcSquares)
		{
			int[,] board = new int[9, 10];
			{
				for (int y = RANK_TOP; y <= RANK_BOTTOM; y ++) {
					for (int x = FILE_LEFT; x <= FILE_RIGHT; x ++) {
						// find pc
						int pc = 0;
						{
							int coordXY = COORD_XY (x, y);
							if (coordXY >= 0 && coordXY < ucpcSquares.Count) {
								pc = ucpcSquares [coordXY];
							} else {
								Debug.LogError ("error, getBoardArray: coordXY error: " + coordXY + "; " + ucpcSquares.Count);
							}
						}
						// process
						if (pc != 0) {
							int piece = 0;
							{
								// find pieceType
								int pieceType = 0;
								{
									if (pieceType >= 0 && pieceType < cnPieceTypes.Length) {
										pieceType = cnPieceTypes [pc];
									} else {
										Debug.LogError ("error, getBoardArray: get piece type error: " + pc);
									}
								}
								// convert pieceType to piece
								if (pieceType >= 0 && pieceType <= 6) {
									if (pc < 32) {
										piece = pieceType + 1;
									} else {
										piece = pieceType + 8;
									}
								} else {
									Debug.LogError ("error, getBoardArray: find piece type error: " + pieceType);
								}
							}
							if (x - 3 >= 0 && x - 3 < 9 && y - 3 >= 0 && y - 3 < 10) {
								board [x - 3, y - 3] = piece;
							} else {
								Debug.LogError ("error, getBoardArray: x, y error: " + x + "; " + y);
							}
							// Debug.LogError ("pc: " + pc + "; " + (Common.Piece)piece);
						} else {
							if (x - 3 >= 0 && x - 3 < 9 && y - 3 >= 0 && y - 3 < 10) {
								board [x - 3, y - 3] = 0;
							} else {
								Debug.LogError ("error, getBoardArray: x, y error: " + x + "; " + y);
							}
						}
					}
				}
			}
			return board;
		}

		public static int COORD_XY(int x, int y) {
			return x + (y << 4);
		}

		static int[] cnPieceTypes = {
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6, 6,
			0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6, 6
		};

		public static int PIECE_TYPE(int pc) {
			if (pc >= 0 && pc < cnPieceTypes.Length) {
				return cnPieceTypes [pc];
			} else {
				Debug.LogError ("PIECE_TYPE: pc error: " + pc);
				return cnPieceTypes [0];
			}
		}

		static string cszPieceBytes = "KABNRCP";

		public static char PIECE_BYTE(int pt) {
			if (pt >= 0 && pt < cszPieceBytes.Length) {
				return cszPieceBytes[pt];
			} else {
				Debug.LogError ("error, PIECE_BYTE: " + pt);
				return cszPieceBytes[0];
			}

		}

		#endregion

		public static bool isInsideBoard(int x, int y)
		{
			if (x >= 0 && x < 9 && y >= 0 && y < 10) {
				return true;
			} else {
				return false;
			}
		}

		#region MoveStruct

		public struct MoveStruct
		{
			public int srcX;
			public int srcY;
			public int destX;
			public int destY;

			public MoveStruct(System.UInt32 move)
			{
				srcX = 0;
				srcY = 0;
				destX = 0;
				destY = 0;
				convert(move);
			}

			public void convert(System.UInt32 move)
			{
				Byte[] bytes = BitConverter.GetBytes (move);
				if (bytes.Length == 4) {
					srcX = bytes[0] - 'a';
					srcY = bytes[1] - '0';
					destX = bytes[2] - 'a';
					destY = bytes[3] - '0';
				} else {
					Debug.LogError ("why bytes !=4");
				}
			}

			public override string ToString ()
			{
				return string.Format ("[{0}, {1}, {2}, {3}]", srcX, srcY, destX, destY);
			}
		}

		#endregion

		#region print

		public static string printMove(System.UInt32 move)
		{
			Byte[] bytes = BitConverter.GetBytes (move);
			if (bytes.Length == 4) {
				char char0 = (char)bytes[0];
				char char1 = (char)bytes[1];
				char char2 = (char)bytes[2];
				char char3 = (char)bytes[3];
				return char0.ToString() + char1.ToString() + char2.ToString() + char3.ToString();
			} else {
				Debug.LogError ("why bytes !=4");
				return "error";
			}
		}

		#region print position

		public static string printPosition(Xiangqi xiangqi)
		{
			StringBuilder strPosition = new StringBuilder ();
			{
				strPosition.Append (string.Format ("turn: {0}\n", xiangqi.nMoveNum.v));
				// lastMove
				int lastMoveSrc = -1;
				int lastMoveDst = -1;
				{
					if(xiangqi.nMoveNum.v>=1){
						System.UInt32 lastMove = xiangqi.getLastMove();
						lastMoveSrc = Xiangqi.Src (lastMove);
						lastMoveDst = Xiangqi.Dst (lastMove);
						strPosition.Append (string.Format ("lastMove: {0} {1}; {2}\n", lastMoveSrc, lastMoveDst, lastMove));
					}else{
						Debug.Log ("don't have last move");
					}
				}
				// write board
				{
					int y, x, pc;
					// write rank:
					strPosition.Append(" `  a  b  c  d  e  f  g  h  i\n");
					for (y = RANK_TOP; y <= RANK_BOTTOM; y ++) {
						strPosition.Append (string.Format (" {0} ", RANK_BOTTOM - y));
						for (x = FILE_LEFT; x <= FILE_RIGHT; x ++) {
							// find coord and pc
							int coordXY = COORD_XY(x, y);
							// get pc
							pc = 0;
							{
								if (coordXY >= 0 && coordXY < xiangqi.ucpcSquares.vs.Count) {
									pc = xiangqi.ucpcSquares.vs [coordXY];
								} else {
									Debug.LogError ("error, coorXY: " + coordXY);
								}
							}
							// print
							if (pc != 0) {
								char piece = (char)(PIECE_BYTE (PIECE_TYPE (pc)) + (pc < 32 ? 0 : 'a' - 'A'));
								if(lastMoveDst!=coordXY){
									strPosition.Append (string.Format(" {0} ", piece));
								}else{
									strPosition.Append (string.Format("[{0}]", piece));
								}
							} else {
								if(lastMoveSrc!=coordXY){
									strPosition.Append (" * ");
								}else{
									strPosition.Append (" - ");
								}
							}
						}
						strPosition.Append ("\n");
					}
				}
			}
			return strPosition.ToString();
		}

		#endregion

		public static string printPositionFen(Xiangqi xiangqi)
		{
			StringBuilder strFen = new StringBuilder ();
			{
				int i, j, k, pc;
				for (i = RANK_TOP; i <= RANK_BOTTOM; i ++) {
					k = 0;
					for (j = FILE_LEFT; j <= FILE_RIGHT; j ++) {
						// find pc
						pc = 0;
						{
							int coordXY = COORD_XY (j, i);
							if (coordXY >= 0 && coordXY < xiangqi.ucpcSquares.vs.Count) {
								pc = xiangqi.ucpcSquares.vs [coordXY];
							}
						}
						if (pc != 0) {
							if (k > 0) {
								strFen.Append ("" + k);
								k = 0;
							}
							strFen.Append ((char)(PIECE_BYTE (PIECE_TYPE (pc)) + (pc < 32 ? 0 : 'a' - 'A')));
						} else {
							k ++;
						}
					}
					if (k > 0) {
						strFen.Append ("" + k);
					}
					strFen.Append ("/");
				}
				strFen.Append (" ");
				strFen.Append (xiangqi.sdPlayer.v == 0 ? "w" : "b");
			}
			return strFen.ToString();
		}

		#endregion

		#region Convert

		private const float deltaX = 0.5f - 9 / 2.0f;
		private const float deltaY = 0.5f - 10 / 2.0f;

		public static Vector2 convertXYToLocalPosition(int x, int y)
		{
			return new Vector2 (x + deltaX, y + deltaY);
		}

		#endregion

	}
}