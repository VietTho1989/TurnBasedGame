using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class Common
	{

		public static Vector2 convertPosToLocalPosition(int pos)
		{
			if (pos >= 0 && pos < 32) {
				int x = pos % 8;
				int y = pos / 8;
				return new Vector2 (x + 0.5f - 8 / 2.0f, y + 0.5f - 4 / 2.0f);
			} else {
				Debug.LogError ("pos error: " + pos);
				return Vector2.zero;
			}
		}

		public static void convertLocalPostionToPos(Vector3 localPosition, out int x, out int y)
		{
			x = Mathf.RoundToInt (localPosition.x - (0.5f - 8 / 2.0f));
			y = Mathf.RoundToInt (localPosition.y - (0.5f - 4 / 2.0f));
		}

	}
}