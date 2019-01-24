using UnityEngine;
using System.Collections;
using System.Text;
using Rule;

namespace CoTuongUp
{

	public class Common 
	{	

		static Common()
		{

		}

		#region Convert

		public static Convert convert = new Convert();

		public class Convert : Board.ConvertPieceToString
		{
			public string convert(byte piece)
			{
				return Common.getStrPiece (piece);
			}

			public string convertSide(byte side)
			{
				switch (side) {
				case 0:
					return "0";
				case 1:
					return "1";
				case 2:
					return "2";
				default:
					Debug.LogError ("unknown side: " + side);
					return "0";
				}
			}

			public string convertX (int x)
			{
				if (x < 0) {
					return " ' ";
				}
				return " " + (char)(x + 'A') + " ";
			}

			public string convertY(int y)
			{
				return "" + y;
			}
		}


		#endregion

		public class Side
		{
			public const byte None = 0;
			public const byte Red = 1;
			public const byte Black = 2;
		}

		public class PieceType
		{
			public const byte None = 0;
			public const byte King = 1;
			public const byte Advisor = 2;
			public const byte Bishop = 3;
			public const byte Rook = 4;
			public const byte Cannon = 5;
			public const byte Knight = 6;
			public const byte Pawn = 7;

			public static string getStrPieceType(byte pieceType)
			{
				switch (pieceType) {
				case None:
					return "None";
				case King:
					return "King";
				case Advisor:
					return "Advisor";
				case Bishop:
					return "Bishop";
				case Rook:
					return "Rook";
				case Cannon:
					return "Cannon";
				case Knight:
					return "Knight";
				case Pawn:
					return "Pawn";
				default:
					return "unknown";
				}
			}
		}

		public class Visibility
		{
			public const byte Show = 0;
			public const byte Hide = 1;

			public static bool isHide(byte piece)
			{
				return (piece & 0x08) != 0;
			}

			public static byte flip(byte piece)
			{
				return unchecked((byte)(piece & 0xF7));
			}

			public static byte hide(byte piece)
			{
				if (piece == Common.x) {
					return Common.x;
				} else {
					return piece |= ((byte)1) << 3;
				}
			}

		}

		#region Piece

		/** None*/
		public const int x = 0;

		/** RedGeneral*/
		public const byte K = (Side.Red << 4) + (Visibility.Show << 3) + 1;
		/** RedAdvisor*/
		public const byte A = (Side.Red << 4) + (Visibility.Show << 3) + 2;
		/** RedElephant*/
		public const byte B = (Side.Red << 4) + (Visibility.Show << 3) + 3;
		/** RedChariot*/
		public const byte R = (Side.Red << 4) + (Visibility.Show << 3) + 4;
		/** RedCannon*/
		public const byte C = (Side.Red << 4) + (Visibility.Show << 3) + 5;
		/** RedHorse*/
		public const byte N = (Side.Red << 4) + (Visibility.Show << 3) + 6;
		/** RedPawn*/
		public const byte P = (Side.Red << 4) + (Visibility.Show << 3) + 7;

		/** HideRedGeneral*/
		public const byte HK = (Side.Red << 4) + (Visibility.Hide << 3) + 1;
		/** HideRedAdvisor*/
		public const byte HA = (Side.Red << 4) + (Visibility.Hide << 3) + 2;
		/** HideRedElephant*/
		public const byte HB = (Side.Red << 4) + (Visibility.Hide << 3) + 3;
		/** HideRedChariot*/
		public const byte HR = (Side.Red << 4) + (Visibility.Hide << 3) + 4;
		/** HideRedCannon*/
		public const byte HC = (Side.Red << 4) + (Visibility.Hide << 3) + 5;
		/** HideRedHorse*/
		public const byte HN = (Side.Red << 4) + (Visibility.Hide << 3) + 6;
		/** HideRedPawn*/
		public const byte HP = (Side.Red << 4) + (Visibility.Hide << 3) + 7;

		/** BlackGeneral*/
		public const byte k = (Side.Black << 4) + (Visibility.Show << 3) + 1;
		/** BlackAdvisor*/
		public const byte a = (Side.Black << 4) + (Visibility.Show << 3) + 2;
		/** BlackElephant*/
		public const byte b = (Side.Black << 4) + (Visibility.Show << 3) + 3;
		/** BlackChariot*/
		public const byte r = (Side.Black << 4) + (Visibility.Show << 3) + 4;
		/** BlackCannon*/
		public const byte c = (Side.Black << 4) + (Visibility.Show << 3) + 5;
		/** BlackHorse*/
		public const byte n = (Side.Black << 4) + (Visibility.Show << 3) + 6;
		/** BlackPawn*/
		public const byte p = (Side.Black << 4) + (Visibility.Show << 3) + 7;

		/** HideBlackGeneral*/
		public const byte hk = (Side.Black << 4) + (Visibility.Hide << 3) + 1;
		/** HideBlackAdvisor*/
		public const byte ha = (Side.Black << 4) + (Visibility.Hide << 3) + 2;
		/** HideBlackElephant*/
		public const byte hb = (Side.Black << 4) + (Visibility.Hide << 3) + 3;
		/** HideBlackChariot*/
		public const byte hr = (Side.Black << 4) + (Visibility.Hide << 3) + 4;
		/** HideBlackCannon*/
		public const byte hc = (Side.Black << 4) + (Visibility.Hide << 3) + 5;
		/** HideBlackHorse*/
		public const byte hn = (Side.Black << 4) + (Visibility.Hide << 3) + 6;
		/** HideBlackPawn*/
		public const byte hp = (Side.Black << 4) + (Visibility.Hide << 3) + 7;

		public static byte changePieceSide(byte piece)
		{
			if (piece == 0) {
				return 0;
			} else {
				// 01 -> 10
				// change bit 4, 5
				return unchecked((byte)(piece ^ 0x30));
			}
		}

		public static byte changeSide(byte side)
		{
			switch (side) {
			case 0:
				return 0;
			case 1:
				return 2;
			case 2:
				return 1;
			default:
				Debug.LogError ("unknown side: " + side);
				return 0;
			}
		}

		public static string getStrPiece(byte piece)
		{
			switch (piece) {
			case x:
				return " * ";

			case K:
				return " K ";
			case A:
				return " A ";
			case B:
				return " B ";
			case R:
				return " R ";
			case C:
				return " C ";
			case N:
				return " N ";
			case P:
				return " P ";

			case HK:
				return "_K_";
			case HA:
				return "_A_";
			case HB:
				return "_B_";
			case HR:
				return "_R_";
			case HC:
				return "_C_";
			case HN:
				return "_N_";
			case HP:
				return "_P_";

			case k:
				return " k ";
			case a:
				return " a ";
			case b:
				return " b ";
			case r:
				return " r ";
			case c:
				return " c ";
			case n:
				return " n ";
			case p:
				return " p ";

			case hk:
				return "_k_";
			case ha:
				return "_a_";
			case hb:
				return "_b_";
			case hr:
				return "_r_";
			case hc:
				return "_c_";
			case hn:
				return "_n_";
			case hp:
				return "_p_";
			default:
				Debug.LogError ("unknown piece: " + piece);
				return "___";
			}
		}

		public static byte getPieceSide(byte piece)
		{
			return unchecked((byte)(piece >> 4));
		}

		public static string getStrSide(byte side)
		{
			switch (side) {
			case Side.None:
				return "None";
			case Side.Red:
				return "Red";
			case Side.Black:
				return "Black";
			default:
				Debug.LogError ("unknown side: " + side);
				return "Unknown";
			}
		}

		public static byte getPieceType(byte piece)
		{
			return unchecked((byte)(piece & 7)); 
		}

		/** x tu trai qua phai, y tu duoi len*/
		public static readonly byte[] DefaultBoard = {
			r,  n,  b,  a,  k,  a,  b,  n,  r, 
			x,  x,  x,  x,  x,  x,  x,  x,  x,
			x,  c,  x,  x,  x,  x,  x,  c,  x, 
			p,  x,  p,  x,  p,  x,  p,  x,  p,
			x,  x,  x,  x,  x,  x,  x,  x,  x,
			x,  x,  x,  x,  x,  x,  x,  x,  x,
			P,  x,  P,  x,  P,  x,  P,  x,  P,
			x,  C,  x,  x,  x,  x,  x,  C,  x, 
			x,  x,  x,  x,  x,  x,  x,  x,  x,
			R,  N,  B,  A,  K,  A,  B,  N,  R
		};

		#endregion

		#region Print

		/*
		`  a  b  c  d  e  f  g  h  i
		9  r  n  b  a  k  a  b  n  r 
		8  *  *  *  *  *  *  *  *  * 
		7  *  c  *  *  *  *  *  c  * 
		6  p  *  p  *  p  *  p  *  p 
		5  *  *  *  *  *  *  *  *  * 
		4  *  *  *  *  *  *  *  *  * 
		3  P  *  P  *  P  *  P  *  P 
		2  *  C  *  *  *  *  *  C  * 
		1  *  *  *  *  *  *  *  *  * 
		0  R  N  B  A  K  A  B  N  R 
		*/

		public static byte makeCoord(byte x, byte y)
		{
			return unchecked((byte)(x + 9 * y));
		}

		public static void parseCoord(byte coord, out byte x, out byte y)
		{
			x = unchecked((byte)(coord % 9));
			y = unchecked((byte)(coord / 9));
		}

		public static void getLocalPosition(byte coord, out byte x, out byte y)
		{
			x = unchecked((byte)(coord % 9));
			y = unchecked((byte)(9 - coord / 9));
		}

		public static string printPosition(CoTuongUp coTuongUp)
		{
			StringBuilder builder = new StringBuilder ();
			{
				builder.AppendLine ("Turn: " + coTuongUp.turn.v);
				builder.AppendLine ("Side: " + Common.getStrSide (coTuongUp.side.v));
				// Print Board
				if (coTuongUp.nodes.vs.Count > 0) {
					Node node = coTuongUp.nodes.vs [coTuongUp.nodes.vs.Count - 1];
					builder.AppendLine (" `  a  b  c  d  e  f  g  h  i");
					for (byte y = 0; y < 10; y++) {
						builder.Append (string.Format (" {0} ", 9 - y));
						for (byte x = 0; x < 9; x++) {
							byte coord = makeCoord (x, y);
							string strPiece = Common.getStrPiece (node.getPieceByCoord (coord));
							builder.Append (strPiece);
						}
						builder.AppendLine ();
					}
				} else {
					Debug.LogError ("Why don't have node: " + coTuongUp);
				}
			}
			return builder.ToString ();
		}

		#endregion

		public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
		{
			x = Mathf.RoundToInt (localPosition.x - (0.5f - 9/2f));
			y = 9 - Mathf.RoundToInt (localPosition.y - (0.5f - 10/2f));
		}

		public static Vector3 convertCoordToLocalPosition(byte coord)
		{
			Vector3 localPosition = new Vector3 ();
			{
				// get x, y
				byte x = 0;
				byte y = 0;
				Common.parseCoord (coord, out x, out y);
				// set localPosition
				localPosition = new Vector3 ();
				localPosition.x = x + 0.5f - 9 / 2f;
				localPosition.y = (9 - y) + 0.5f - 10 / 2f;
				localPosition.z = 0;
			}
			return localPosition;
		}

	}

}