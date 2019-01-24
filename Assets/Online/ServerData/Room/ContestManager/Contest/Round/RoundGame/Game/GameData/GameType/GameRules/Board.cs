using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Rule
{
	public class Board
	{

		public byte[,] board;

		public byte[,] side;

		#region Print

		public interface ConvertPieceToString
		{
			string convert(byte piece);

			string convertSide(byte side);

			string convertX(int x);

			string convertY(int y);
		}

		public string convertToString (ConvertPieceToString convert, List<Rules.Coord> legalCoords = null)
		{
			StringBuilder builder = new StringBuilder ();
			{
				// Board
				builder.AppendLine ("Board: ");
				{
					// Header
					{
						for (int i = -1; i < board.GetLength (0); i++) {
							builder.Append (convert == null ? " " + i : " " + convert.convertX (i));
						}
						builder.AppendLine ();
					}
					// Content
					for (byte y = 0; y < board.GetLength (1); y++) {
						builder.Append (string.Format ("{0} ", convert == null
							? (board.GetLength (1) - y - 1).ToString ("D3") 
							: convert.convertY (board.GetLength (1) - y - 1)));
						for (byte x = 0; x < board.GetLength (0); x++) {
							builder.Append (string.Format ("{0} ", convert == null ? board [x, y].ToString ("D3") : convert.convert (board [x, y])));
						}
						builder.AppendLine ();
					}
				}
				// Side
				builder.AppendLine ("Side: ");
				{
					// Header
					{
						for (int i = -1; i < board.GetLength (0); i++) {
							builder.Append (convert == null ? "" + i : " " + convert.convertX (i));
						}
						builder.AppendLine ();
					}
					// Content
					for (byte y = 0; y < side.GetLength (1); y++) {
						builder.Append (string.Format ("{0} ", convert == null
							? (board.GetLength (1) - y - 1).ToString ("D3") 
							: convert.convertY (board.GetLength (1) - y - 1)));
						for (byte x = 0; x < side.GetLength (0); x++) {
							builder.Append (string.Format ("{0} ", convert == null ? side [x, y].ToString ("D3") : convert.convertSide (side [x, y])));
						}
						builder.AppendLine ();
					}
				}
				// Legals
				if (legalCoords != null) {
					// Header
					{
						for (int i = -1; i < board.GetLength (0); i++) {
							builder.Append (convert == null ? " " + i : " " + convert.convertX (i));
						}
						builder.AppendLine ();
					}
					// Content
					for (byte y = 0; y < board.GetLength (1); y++) {
						builder.Append (string.Format ("{0} ", convert == null
							? (board.GetLength (1) - y - 1).ToString ("D3") 
							: convert.convertY (board.GetLength (1) - y - 1)));
						for (byte x = 0; x < board.GetLength (0); x++) {
							bool isLegalCoord = false;
							{
								for (int i = 0; i < legalCoords.Count; i++) {
									Rules.Coord legalCoord = legalCoords [i];
									if (legalCoord.x == x && legalCoord.y == y) {
										isLegalCoord = true;
										break;
									}
								}
							}
							if (isLegalCoord) {
								builder.Append (" +  ");
							} else {
								builder.Append (string.Format ("{0} ", convert == null ? board [x, y].ToString ("D3") : convert.convert (board [x, y])));
							}
						}
						builder.AppendLine ();
					}
				}
			}
			return builder.ToString ();
		}

		#endregion

	}
}