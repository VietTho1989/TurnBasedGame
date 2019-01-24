using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class Common
	{

		public static Vector2 converPosToLocalPosition(int x, int y, BoardUI.UIData boardUIData)
		{
			float localX = x - (boardUIData.x.v + boardUIData.width.v / 2.0f) + 0.5f;
			float localY = -(y - (boardUIData.y.v + boardUIData.height.v / 2.0f)) - 0.5f;
			return new Vector2 (localX, localY);
		}

		public static int convertLocalPositionToPos(Vector2 localPosition, BoardUI.UIData boardUIData)
		{
			// get x, y
			int x = Mathf.RoundToInt(localPosition.x + (boardUIData.x.v + boardUIData.width.v / 2.0f) - 0.5f);
			int y = Mathf.RoundToInt (-localPosition.y + (boardUIData.y.v + boardUIData.height.v / 2.0f) - 0.5f);
			// check outside board
			if (x >= boardUIData.x.v && x <= boardUIData.x.v + boardUIData.width.v
			    && y >= boardUIData.y.v && y <= boardUIData.y.v + boardUIData.height.v) {
				// return
				MineSweeper mineSweeper = boardUIData.mineSweeper.v.data;
				if (mineSweeper != null) {
					return x * mineSweeper.Y.v + y;
				} else {
					Debug.LogError ("mineSweeper null: " + boardUIData);
				}
			} else {
				Debug.LogError ("click outside board: " + boardUIData);
			}
			return -1;
		}

		public static Vector2 converPosToBoundaryLocalPosition(int x, int y, BoardUI.UIData boardUIData)
		{
			float localX = x - (0 + boardUIData.width.v) / 2.0f + 0.5f;
			float localY = -(y - (0 + boardUIData.height.v) / 2.0f) - 0.5f;
			return new Vector2 (localX, localY);
		}

		#region show

		public static void show(Image img, int square, Data data)
		{
			if (img != null && data != null) {
				bool isShow = false;
				{
					// find boardUIData
					BoardUI.UIData boardUIData = null;
					{
						MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data.findDataInParent<MineSweeperGameDataUI.UIData> ();
						if (mineSweeperGameDataUIData != null) {
							boardUIData = mineSweeperGameDataUIData.board.v;
						} else {
							Debug.LogError ("mineSweeperGameDataUIData null: " + data);
						}
					}
					// process
					if (boardUIData != null) {
						MineSweeper mineSweeper = boardUIData.mineSweeper.v.data;
						if (mineSweeper != null) {
							// find x, y
							int x = -1;
							int y = -1;
							{
								if (mineSweeper.Y.v > 0) {
									x = square / mineSweeper.Y.v;
									y = square % mineSweeper.Y.v;
								} else {
									Debug.LogError ("Y error: " + mineSweeper.Y.v);
								}
							}
							// Check inside board
							bool isInsideBoard = false;
							{
								if (square >= 0) {
									if (x >= boardUIData.x.v && x < boardUIData.x.v + boardUIData.width.v
										&& y >= boardUIData.y.v && y < boardUIData.y.v + boardUIData.height.v) {
										isInsideBoard = true;
									}
								} else {
									Debug.LogError ("why square < 0: " + square + "; " + data);
								}
							}
							// Process
							if (isInsideBoard) {
								isShow = true;
								img.transform.localPosition = Common.converPosToLocalPosition (x, y, boardUIData);
							}
						} else {
							Debug.LogError ("mineSweeper null: " + data);
						}
					} else {
						Debug.LogError ("boardUIData null: " + data);
					}
				}
				img.gameObject.SetActive (isShow);
			} else {
				Debug.LogError ("img, data null: " + data);
			}
		}

		#endregion

	}
}