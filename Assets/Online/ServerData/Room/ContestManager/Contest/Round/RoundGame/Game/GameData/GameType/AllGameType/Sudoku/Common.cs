using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class Common
	{

		public static Vector2 GetLocalPos(int x, int y)
		{
			return new Vector2 (x - 4.0f, 4.0f - y);
		}

		public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
		{
			x = Mathf.RoundToInt (localPosition.x + 4.0f);
			y = Mathf.RoundToInt (4.0f - localPosition.y);
		}

	}
}