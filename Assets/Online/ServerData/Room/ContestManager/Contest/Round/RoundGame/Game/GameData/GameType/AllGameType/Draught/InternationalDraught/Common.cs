using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace InternationalDraught
{
	public class Common
	{

		public enum Variant_Type 
		{ 
			Normal,
			Killer, 
			BT 
		};

		public const int Line_Size = 10;
		public const int Dense_Size = Line_Size * Line_Size / 2;
		public const int Square_Size = 63;
		public const int Dir_Size = 4;
		public const int Side_Size = 2;
		public const int Piece_Size = 2;
		public const int Piece_Side_Size = 4; // excludes Empty #

		public const int Move_Index_Size = (1 << 12);

		public const int Stage_Size = 300;

		public enum Side 
		{ 
			White, 
			Black 
		};
		public enum Piece 
		{ 
			Man, 
			King 
		};

		public enum Piece_Side
		{
			White_Man,
			Black_Man,
			White_King,
			Black_King,
			Empty
		};

		public static int[] Square_Sparse = new int[Dense_Size];
		public static int[] Square_Dense = new int[Square_Size];

		public static int[] Square_File = new int[Square_Size];
		public static int[] Square_Rank = new int[Square_Size];

		public static int square_file(int sq) {
			if (sq >= 0 && sq < Square_File.Length) {
				return Square_File [sq];
			} else {
				// Debug.LogError ("unknown sq: " + sq);
				return 0;
			}
		}

		public static int square_rank(int sq) {
			if (sq >= 0 && sq < Square_Rank.Length) {
				return Square_Rank [sq];
			} else {
				// Debug.LogError ("unknown sq: " + sq);
				return 0;
			}
		}

		static Common() 
		{
			// square numbering
			int dense = 0;
			int sparse = 0;
			for (int rk = 0; rk < Line_Size; rk++) {
				for (int fl = 0; fl < Line_Size + 3; fl++) { // 3 ghost files
					{
						// assert(dense < Dense_Size);
						if(dense>=Dense_Size){
							Debug.LogError("error, assert(dense < Dense_Size)");
							dense = Dense_Size - 1;
						}
					}
					{
						// assert(sparse < Square_Size);
						if(sparse>=Square_Size){
							Debug.LogError("error, assert(sparse < Square_Size)");
							sparse = Square_Size - 1;
						}
					}
					if (square_is_light(fl, rk)) { // invalid square

					} else if (square_is_ok(fl, rk)) { // board square
						Square_Sparse[dense] = sparse;
						Square_Dense[sparse] = dense;

						Square_File[sparse] = fl;
						Square_Rank[sparse] = rk;

						{
							// assert(square_make(fl, rk) == sparse);
							if(square_make(fl, rk) != sparse){
								Debug.LogError("error, assert(square_make(fl, rk) == sparse)\n");
								sparse = square_make(fl, rk);
							}
						}

						dense++;
						sparse++;

						if (dense >= Dense_Size) break; // all squares have been covered

					} else { // ghost square

						Square_Dense[sparse] = -1;

						Square_File[sparse] = -1;
						Square_Rank[sparse] = -1;

						sparse++;
					}
				}
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////
		//////////////////////////// Print ////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////////////

		public static bool square_is_dark(int fl, int rk) {
			return (fl + rk) % 2 != 0;
		}

		public static bool square_is_light(int fl, int rk) {
			return !square_is_dark(fl, rk);
		}

		public static bool square_is_ok(int fl, int rk) {
			return (fl >= 0 && fl < Line_Size) && (rk >= 0 && rk < Line_Size) && square_is_dark(fl, rk);
		}

		public static int square_sparse(int dense) {
			{
				// assert(dense >= 0 && dense < Dense_Size);
				if(!(dense >= 0 && dense < Dense_Size)){
					Debug.LogError("error, assert(dense >= 0 && dense < Dense_Size)");
					dense = 0;
				}
			}
			return Square_Sparse[dense];
		}

		public static int square_make(int fl, int rk) {
			{
				// assert(square_is_ok(fl, rk));
				if(!(square_is_ok(fl, rk))){
					Debug.LogError ("error, assert(square_is_ok(fl, rk))");
				}
			}
			int dense = (rk * Line_Size + fl) / 2;
			return square_sparse(dense);
		}

		#region Print Position

		public static string printPosition(InternationalDraught internationalDraught)
		{
			StringBuilder builder = new StringBuilder ();
			{
				if (internationalDraught.node.vs.Count > 0) {
					Node node = internationalDraught.node.vs [internationalDraught.node.vs.Count - 1];
					Pos pos = node.p_pos.v;
					// Variant
					{
						switch (internationalDraught.var.v.Variant.v) {
						case (int)Common.Variant_Type.Normal:
							builder.Append ("Variant: Normal\n");
							break;
						case (int)Common.Variant_Type.Killer:
							builder.Append ("Variant: Killer\n");
							break;
						case (int)Common.Variant_Type.BT:
							builder.Append ("Variant: BT\n");
							break;
						default:
							Debug.LogError("error, unknown variantType: "+ internationalDraught.var.v.Variant.v);
							break;
						}
					}
					// turn
					{
						switch (pos.p_turn.v) {
						case (int)Side.White:
							builder.Append ("Turn: White\n");
							break;
						case (int)Side.Black:
							builder.Append ("Turn: Black\n");
							break;
						default:
							Debug.LogError ("error, unknown turn: " + pos.p_turn.v);
							break;
						}
					}
					// GamePly
					{
						builder.Append("Ply: " + node.p_ply.v);
						{
							for (int i = 0; i < internationalDraught.node.vs.Count; i++) {
								Node n = internationalDraught.node.vs[i];
								builder.Append (", " + n.p_ply.v);
							}
						}
						builder.AppendLine ();
					}
					// lastMove
					int from = -1;
					int dest = -1;
					{
						if (internationalDraught.lastMove.v > 0) {
							System.UInt64 mv = internationalDraught.lastMove.v;
							from = InternationalDraughtMove.from (mv);
							dest = InternationalDraughtMove.to (mv);
							// Debug.Log ("lastMove: " + from + "; " + dest + "; " + internationalDraught.lastMove.v);
						} else {
							Debug.Log ("don't have last move");
						}
					}
					// board
					{
						// print top
						builder.Append("\n    A  B  C  D  E  F  G  H  I  J\n");
						// print piece
						for (int y = 0; y < Line_Size; y++) {// Square.Rank_Size
							builder.Append (string.Format("{0} ", (Line_Size-y).ToString("D2")));
							for (int x = 0; x < Line_Size; x++) {// Square.File_Size
								if(square_is_dark(x, y)){
									int sq = square_make(x, y);
									// check is last move
									char cLastMove = ' ';
									{
										if(sq==from){
											cLastMove = '(';
										}else if(sq==dest){
											cLastMove = ')';
										}else{
											cLastMove = ' ';
										}
									}
									// Check capture square
									char lastCaptureSquare = ' ';
									{
										bool isLastCaptureSquare = false;
										{
											if (internationalDraught.captureSize.v >= 0 && internationalDraught.captureSize.v <= 20) {
												for (int i = 0; i < internationalDraught.captureSize.v; i++) {
													if (i >= 0 && i < internationalDraught.captureSquares.vs.Count) {
														if (internationalDraught.captureSquares.vs [i] == sq) {
															isLastCaptureSquare = true;
															break;
														}
													} else {
														Debug.LogError ("internationalDraught captureSquares error: " + i);
													}
												}
											} else {
												Debug.LogError ("error, captureSize wrong: " + internationalDraught.captureSize.v);
											}
										}
										if(isLastCaptureSquare){
											lastCaptureSquare = '-';
										}
									}
									// print piece
									// Debug.Log("pos piece_side: "+pos.piece_side(sq)+"; "+sq);
									switch (pos.piece_side(sq)) {
									case (int)Common.Piece_Side.White_Man:
										builder.Append (string.Format("{0}M{1}", lastCaptureSquare, cLastMove));
										break;
									case (int)Common.Piece_Side.Black_Man:
										builder.Append (string.Format("{0}m{1}", lastCaptureSquare, cLastMove));
										break;
									case (int)Common.Piece_Side.White_King:
										builder.Append (string.Format("{0}K{1}", lastCaptureSquare, cLastMove));
										break;
									case (int)Common.Piece_Side.Black_King:
										builder.Append (string.Format("{0}k{1}", lastCaptureSquare, cLastMove));
										break;
									case (int)Common.Piece_Side.Empty:
										builder.Append (string.Format("{0}.{1}", lastCaptureSquare, cLastMove));
										break;
									default:
										Debug.LogError("error, unknown piece_side");
										break;
									}
								}else{
									builder.Append ("   ");
								}
							}
							builder.Append (string.Format(" {0}\n", (Line_Size-y).ToString("D2")));
						}
						// print bottom
						builder.Append ("    A  B  C  D  E  F  G  H  I  J\n");
					}
					// fen
					builder.Append(string.Format("\nFen: {0}\n", Core.unityGetFen(pos, Core.CanCorrect)));
				} else {
					Debug.LogError ("error, why don't have node");
				}
			}
			return builder.ToString ();
		}

		#endregion

		static int square_to_std(int sq) {
			if (sq >= 0 && sq < Square_Dense.Length) {
				int std = Square_Dense[sq] + 1;
				{
					// assert(std >= 1 && std <= Dense_Size);
					if(!(std >= 1 && std <= Dense_Size)){
						Debug.LogError("error, assert(std >= 1 && std <= Dense_Size)");
						std = 1;
					}
				}
				return std;
			} else {
				Debug.LogError ("sq error: " + sq);
				return 0;
			}
		}

		public static string square_to_string(int sq) {
			return "" + square_to_std (sq);
		}

		public static string printMove(System.UInt64 move)
		{
			System.UInt64 caps = InternationalDraughtMove.captured (move);

			string s = "";
			{
				List<int> squares = Core.unityGetMoveSquareList (move);
				if (squares.Count == 2) {
					s += square_to_string (squares [0]);
					s += (caps != 0) ? "x" : "-";
					s += square_to_string (squares [1]);
				} else if (squares.Count >= 3) {
					// from
					s += square_to_string (squares [0]);
					for (int i = 1; i < squares.Count; i++) {
						s += "x" + square_to_string (squares [i]);
					}
				}
			}
			return s;
		}

		public static string printSquareList(List<int> squares)
		{
			StringBuilder ret = new StringBuilder ();
			{
				for (int i = 0; i < squares.Count; i++) {
					ret.Append (Common.square_to_string (squares [i]));
					if (i != squares.Count - 1) {
						ret.Append (", ");
					}
				}
			}
			return ret.ToString ();
		}

		#region Convert

		public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
		{
			x = Mathf.RoundToInt (localPosition.x - (0.5f - 5f));
			y = 9 - Mathf.RoundToInt (localPosition.y - (0.5f - 5f));
		}

		public static Vector2 convertSquareToLocalPosition(int square)
		{
			float x = Common.square_file (square);
			float y = Common.square_rank (square);
			return new Vector2 (x + 0.5f - 5, (9 - y) + 0.5f - 5);
		}

		#endregion

	}
}