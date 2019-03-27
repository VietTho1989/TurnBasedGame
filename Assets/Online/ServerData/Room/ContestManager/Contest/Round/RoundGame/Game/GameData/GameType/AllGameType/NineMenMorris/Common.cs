using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class Common
    {

        public enum GamePhase
        {
            Positioning,
            Playing
        };

        public enum NMMAction
        {
            Place,
            Mv_Down,
            Mv_Up,
            Mv_Right,
            Mv_Left,
            Fly
        };

        public const int BOARD_SPOT = 24;

        public enum SpotStatus
        {
            SS_Empty,
            SS_Black,
            SS_White
        };

        public static readonly int[] Pos2Coord = {
            0, 0,// 0
			0, 3,// 1
			0, 6,// 2 
			1, 1,// 3 
			1, 3,// 4
			1, 5,// 5
			2, 2,// 6
			2, 3,// 7 
			2, 4,// 8
			3, 0,// 9
			3, 1,// 10
			3, 2,// 11
			3, 4,// 12
			3, 5,// 13
			3, 6,// 14
			4, 2,// 15
			4, 3,// 16
			4, 4,// 17
			5, 1,// 18
			5, 3,// 19 
			5, 5,// 20
			6, 0,// 21
			6, 3,// 22
			6, 6 // 23
		};

        public static Vector2 convertPositionToLocal(int position)
        {
            Vector2 ret = Vector2.zero;
            {
                if (position >= 0 && position < BOARD_SPOT)
                {
                    // find x, y
                    int x = Pos2Coord[2 * position + 1];
                    int y = Pos2Coord[2 * position];
                    // set
                    ret.x = x - 6 / 2f;
                    ret.y = y - 6 / 2f;
                }
                else
                {
                    Debug.LogError("position error: " + position);
                }
            }
            return ret;
        }

        public static void convertLocalPositionToXY(Vector3 localPosition, out int x, out int y)
        {
            x = Mathf.RoundToInt(localPosition.x + 3);
            y = Mathf.RoundToInt(localPosition.y + 3);
        }

        public static void parsePositionToXY(int position, out int x, out int y)
        {
            x = 3;
            y = 3;
            if (position >= 0 && position < BOARD_SPOT)
            {
                x = Pos2Coord[2 * position + 1];
                y = Pos2Coord[2 * position];
            }
            else
            {
                Debug.LogError("position error: " + position);
            }
        }

        public static int ConvertXYToPosition(int x, int y)
        {
            int ret = -1;
            {
                for (int i = 0; i < BOARD_SPOT; i++)
                {
                    if (Pos2Coord[2 * i + 1] == x && Pos2Coord[2 * i] == y)
                    {
                        ret = i;
                        break;
                    }
                }
            }
            return ret;
        }

    }
}