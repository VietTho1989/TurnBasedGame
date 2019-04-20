using UnityEngine;
using System;
using System.Text;
using System.Collections;

namespace EnglishDraught
{
    public class Common
    {

        public const int MAX_GAMEMOVES = 2048;

        public const byte WHITE = 2;
        public const byte BLACK = 1; // Black == Red

        public const byte BPIECE = 1;
        public const byte WPIECE = 2;
        public const byte KING = 4;
        public const byte BKING = 5;
        public const byte WKING = 6;

        #region print

        // Convert between 32 square board and internal 44 square board
        public static System.Int32[] BoardLocTo32 = { 0, 0, 0, 0, 0, 0, 1, 2, 3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 0, 12, 13, 14, 15, 16, 17, 18, 19, 0, 20, 21, 22, 23, 24, 25, 26, 27, 0, 28, 29, 30, 31 };
        public static System.Int32[] BoardLoc32 = { 5, 6, 7, 8, 10, 11, 12, 13, 14, 15, 16, 17, 19, 20, 21, 22, 23, 24, 25, 26, 28, 29, 30, 31, 32, 33, 34, 35, 37, 38, 39, 40 };

        // Flip square horizontally because the internal board is flipped.
        public static System.Int64 FlipX(System.Int32 x)
        {
            System.Int32 y = x & 3;
            x ^= y;
            x += 3 - y;
            return x;
        }

        public static void convertSquareToXY(long square, out int x, out int y)
        {
            y = (int)((square - 1) / 4);
            x = (int)(7 - (((square - 1) % 4) * 2 + (y % 2 == 0 ? 1 : 0)));
            y = 7 - y;
        }

        public static int getIndexFromXY(int x, int y)
        {
            /* indexes to be updated
         #            37  38  39  40
         #          32  33  34  35
         #            28  29  30  31
         #          23  24  25  26
         #            19  20  21  22
         #          14  15  16  17
         #            10  11  12  13
         #           5   6   7   8
         */
            /* indexes to be updated
			#            32  31  30  29
			#          28  27  26  25
			#            24  23  22  21
			#          20  19  18  17
			#            16  15  14  13
			#           12  11  10  9
			#            8  7  6  5
			#           4   3   2   1
			*/
            /* indexes to be updated
			#            28  29  30  31
			#          24  25  26  27
			#            20  21  22  23
			#          16  17  18  19
			#            12  13  14  15
			#          08  09  10  11
			#            04  05  06  07
			#          00  01  02  03
			*/
            return x / 2 + 4 * (7 - y);
        }

        public static bool isPiece(byte piece)
        {
            return (piece == BPIECE) || (piece == BKING) || (piece == WPIECE) || (piece == WKING);
        }

        public static string printPosition(EnglishDraught englishDraught, EnglishDraughtMove lastMove)
        {
            StringBuilder builder = new StringBuilder();
            {
                // turn
                {
                    switch (englishDraught.SideToMove.v)
                    {
                        case BLACK:
                            builder.Append(string.Format("Turn: {0}, Black\n", englishDraught.turn.v));
                            break;
                        case WHITE:
                            builder.Append(string.Format("Turn: {0}, White\n", englishDraught.turn.v));
                            break;
                        default:
                            Debug.LogError("error, unknown turn");
                            break;
                    }
                }
                // Board
                {
                    System.Int32 from = -1;
                    System.Int32 dest = -1;
                    if (lastMove.SrcDst.v != 0)
                    {
                        from = (System.Int32)FlipX(BoardLocTo32[lastMove.SrcDst.v & 63]) + 1;
                        dest = (System.Int32)FlipX(BoardLocTo32[(lastMove.SrcDst.v >> 6) & 63]) + 1;
                    }
                    // print top
                    builder.Append("\n    A  B  C  D  E  F  G  H  I\n");
                    // print piece
                    for (int y = 0; y < 8; y++)
                    {
                        builder.Append((8 - y).ToString("D2"));
                        for (int x = 0; x < 8; x++)
                        {
                            if ((x + y) % 2 == 1)
                            {
                                int index = getIndexFromXY(x, y);
                                if (index >= 0 && index < 32)
                                {
                                    char t = ' ';
                                    {
                                        if (from >= 0 && dest >= 0)
                                        {
                                            if (((from - 1) / 4) * 4 + (3 - (from - 1) % 4) == index)
                                            {
                                                t = '-';
                                            }
                                            else if (((dest - 1) / 4) * 4 + (3 - (dest - 1) % 4) == index)
                                            {
                                                t = '+';
                                            }
                                        }
                                        else
                                        {
                                            // printf("don't have last move\n");
                                        }
                                    }
                                    byte piece = 0;
                                    {
                                        if (index >= 0 && index < BoardLoc32.Length)
                                        {
                                            int boardLoc32Index = BoardLoc32[index];
                                            if (boardLoc32Index >= 0 && boardLoc32Index < englishDraught.Sqs.vs.Count)
                                            {
                                                piece = englishDraught.Sqs.vs[boardLoc32Index];
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("index error: " + index);
                                        }
                                    }
                                    switch (piece)
                                    {
                                        case BPIECE:
                                            builder.Append(string.Format("{0}m{1}", t, t));
                                            break;
                                        case BKING:
                                            builder.Append(string.Format("{0}k{1}", t, t));
                                            break;
                                        case WPIECE:
                                            builder.Append(string.Format("{0}M{1}", t, t));
                                            break;
                                        case WKING:
                                            builder.Append(string.Format("{0}K{1}", t, t));
                                            break;
                                        default:
                                            builder.Append(string.Format("{0}.{1}", t, t));
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError(string.Format("error, index error: {0}\n", index));
                                }
                            }
                            else
                            {
                                builder.Append("   ");
                            }
                        }
                        builder.Append(string.Format("{0}\n", (8 - y).ToString("D2")));
                    }
                    // print bottom
                    builder.Append("    A  B  C  D  E  F  G  H  I\n");
                }
                // Fen
                builder.Append(string.Format("Fen: {0}\n", Core.unityGetFen(englishDraught, Core.CanCorrect)));
                // GamePly
                builder.Append(string.Format("Ply: {0}\n", englishDraught.ply.v));
                // HashKey
                builder.Append(string.Format("HashKey: {0}\n", englishDraught.HashKey.v));
            }
            return builder.ToString();
        }

        public static string printMove(EnglishDraughtMove englishDraughtMove)
        {
            char cCap = ((englishDraughtMove.SrcDst.v >> 12) != 0) ? 'x' : '-';
            string cPath = "";
            {
                // 32-23, 25-18
                if (cCap == 'x')
                {
                    for (int i = 0; i < englishDraughtMove.cPath.vs.Count; i++)
                    {
                        if (englishDraughtMove.cPath.vs[i] != 0)
                        {
                            cPath += "x" + (FlipX(BoardLocTo32[englishDraughtMove.cPath.vs[i]]) + 1);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return string.Format("{0}{1}{2}{3}", FlipX(BoardLocTo32[englishDraughtMove.SrcDst.v & 63]) + 1, cCap, FlipX(BoardLocTo32[(englishDraughtMove.SrcDst.v >> 6) & 63]) + 1, cPath);
        }

        #endregion

        #region Convert

        public static int convertLocalPositionToSquare(Vector3 localPosition)
        {
            int x = Mathf.RoundToInt(localPosition.x - (0.5f - 4f));
            int y = 7 - Mathf.RoundToInt(localPosition.y - (0.5f - 4f));
            if (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                int square = x + 8 * y;
                return square;
            }
            else
            {
                return -1;
            }
        }

        public static Vector2 convertSquareToLocalPosition(int square)
        {
            float x = square % 8;
            float y = square / 8;
            return new Vector2(x + 0.5f - 4, (7 - y) + 0.5f - 4);
        }

        #endregion

    }
}