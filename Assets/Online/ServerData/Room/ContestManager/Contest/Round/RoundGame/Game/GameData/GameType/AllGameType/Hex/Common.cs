using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class Common
	{

		public enum Color
		{
			Empty = 2,
			Red = 0,
			Blue = 1,
		}

		public static Vector2 GetLocalPosition(ushort square, Data data)
		{
			Vector2 localPos = Vector2.zero;
			if (data != null) {
				// find boardUIData
				BoardUI.UIData boardUIData = null;
				{
					HexGameDataUI.UIData hexGameDataUIData = data.findDataInParent<HexGameDataUI.UIData> ();
					if (hexGameDataUIData != null) {
						boardUIData = hexGameDataUIData.board.v;
					} else {
						Debug.LogError ("hexGameDataUIData null: " + data);
					}
				}
				// Process
				if (boardUIData != null) {
					if (boardUIData.boardSize.v >= Hex.MIN_BOARD_SIZE && boardUIData.boardSize.v <= Hex.MAX_BOARD_SIZE) {
						System.UInt16 x = 0;
						System.UInt16 y = 0;
						{
							if (boardUIData.boardSize.v > 0) {
								x = (System.UInt16)(square % boardUIData.boardSize.v);
								y = (System.UInt16)(square / boardUIData.boardSize.v);
							} else {
								Debug.LogError ("why board size too small: " + data);
							}
						}
						// check inside board or not
						bool isInsideBoard = false;
						{
							if (x >= 0 && x < boardUIData.boardSize.v && y >= 0 && y < boardUIData.boardSize.v) {
								isInsideBoard = true;
							}
						}
						// Process
						if (isInsideBoard) {
							localPos = Common.GetLocalPosition (x, y, boardUIData);
						}
					}
				}
			} else {
				Debug.LogError ("data null: " + data);
			}
			return localPos;
		}

		public static Vector2 GetLocalPosition(System.UInt16 x, System.UInt16 y, BoardUI.UIData boardUIData)
		{
			// 5, 5, 11 -> (0, 0)
			if (boardUIData != null) {
				if (boardUIData.boardSize.v >= Hex.MIN_BOARD_SIZE && boardUIData.boardSize.v <= Hex.MAX_BOARD_SIZE) {
					float localX = x + 0.5f * y - boardUIData.boardSize.v * (1 + 0.5f) / 2.0f + 0.75f;
					float localY = (boardUIData.boardSize.v - 1 - y) - boardUIData.boardSize.v / 2.0f + 0.5f;
					return new Vector2 (localX, localY);
				} else {
					Debug.LogError ("boardSize error: " + boardUIData.boardSize.v);
				}
			} else {
				Debug.LogError ("boardUIData null");
			}
			return Vector2.zero;
		}

		public static System.UInt16 GetIndex(Vector2 localPosition, BoardUI.UIData boardUIData)
		{
			if (boardUIData != null) {
				if (boardUIData.boardSize.v >= Hex.MIN_BOARD_SIZE && boardUIData.boardSize.v <= Hex.MAX_BOARD_SIZE) {
					System.UInt16 y = (ushort)Mathf.RoundToInt ((boardUIData.boardSize.v - 1) - boardUIData.boardSize.v / 2.0f + 0.5f - localPosition.y);
					System.UInt16 x = (ushort)Mathf.RoundToInt (localPosition.x - 0.5f * y + boardUIData.boardSize.v * (1 + 0.5f) / 2.0f - 0.75f);
					if (x >= 0 && x < boardUIData.boardSize.v && y >= 0 && y < boardUIData.boardSize.v) {
						return (System.UInt16)(boardUIData.boardSize.v * y + x);
					} else {
						Debug.LogError ("click outside board: " + x + "; " + y);
					}
				} else {
					Debug.LogError ("boardSize error: " + boardUIData.boardSize.v);
				}
			} else {
				Debug.LogError ("boardUIData null");
			}
			return System.UInt16.MaxValue;
		}

	}
}