using UnityEngine;
using System.Collections;
using System.Text;

namespace Reversi
{
    public class Common
    {

        public static string printMove(sbyte move)
        {
            return string.Format("{0}{1}", (char)('a' + (move & 7)), (move >> 3) + 1);
        }

        #region print position

        public static readonly System.UInt64[] MOVEMASK = {
            0x0000000000000001, 0x0000000000000002, 0x0000000000000004, 0x0000000000000008,
            0x0000000000000010, 0x0000000000000020, 0x0000000000000040, 0x0000000000000080,
            0x0000000000000100, 0x0000000000000200, 0x0000000000000400, 0x0000000000000800,
            0x0000000000001000, 0x0000000000002000, 0x0000000000004000, 0x0000000000008000,
            0x0000000000010000, 0x0000000000020000, 0x0000000000040000, 0x0000000000080000,
            0x0000000000100000, 0x0000000000200000, 0x0000000000400000, 0x0000000000800000,
            0x0000000001000000, 0x0000000002000000, 0x0000000004000000, 0x0000000008000000,
            0x0000000010000000, 0x0000000020000000, 0x0000000040000000, 0x0000000080000000,
            0x0000000100000000, 0x0000000200000000, 0x0000000400000000, 0x0000000800000000,
            0x0000001000000000, 0x0000002000000000, 0x0000004000000000, 0x0000008000000000,
            0x0000010000000000, 0x0000020000000000, 0x0000040000000000, 0x0000080000000000,
            0x0000100000000000, 0x0000200000000000, 0x0000400000000000, 0x0000800000000000,
            0x0001000000000000, 0x0002000000000000, 0x0004000000000000, 0x0008000000000000,
            0x0010000000000000, 0x0020000000000000, 0x0040000000000000, 0x0080000000000000,
            0x0100000000000000, 0x0200000000000000, 0x0400000000000000, 0x0800000000000000,
            0x1000000000000000, 0x2000000000000000, 0x4000000000000000, 0x8000000000000000
        };

        public static System.UInt64 getLegal(System.UInt64 white, System.UInt64 black, int side)
        {
            System.UInt64 result = 0;
            // set self, opp
            System.UInt64 self = white;// pieces[side];
            System.UInt64 opp = black;// pieces[side^1];
            {
                if (side == Reversi.WHITE)
                {
                    self = white;
                    opp = black;
                }
                else
                {
                    self = black;
                    opp = white;
                }
            }

            System.UInt64 other = opp & 0x00FFFFFFFFFFFF00;
            // north and south
            System.UInt64 templ = other & (self << 8);
            System.UInt64 tempr = other & (self >> 8);
            templ |= other & (templ << 8);
            tempr |= other & (tempr >> 8);
            System.UInt64 maskl = other & (other << 8);
            System.UInt64 maskr = other & (other >> 8);
            templ |= maskl & (templ << 16);
            tempr |= maskr & (tempr >> 16);
            templ |= maskl & (templ << 16);
            tempr |= maskr & (tempr >> 16);
            result |= (templ << 8) | (tempr >> 8);

            other = opp & 0x7E7E7E7E7E7E7E7E;
            // east and west
            templ = other & (self << 1);
            tempr = other & (self >> 1);
            templ |= other & (templ << 1);
            tempr |= other & (tempr >> 1);
            maskl = other & (other << 1);
            maskr = other & (other >> 1);
            templ |= maskl & (templ << 2);
            tempr |= maskr & (tempr >> 2);
            templ |= maskl & (templ << 2);
            tempr |= maskr & (tempr >> 2);
            result |= (templ << 1) | (tempr >> 1);

            // ne and sw
            templ = other & (self << 7);
            tempr = other & (self >> 7);
            templ |= other & (templ << 7);
            tempr |= other & (tempr >> 7);
            maskl = other & (other << 7);
            maskr = other & (other >> 7);
            templ |= maskl & (templ << 14);
            tempr |= maskr & (tempr >> 14);
            templ |= maskl & (templ << 14);
            tempr |= maskr & (tempr >> 14);
            result |= (templ << 7) | (tempr >> 7);

            // nw and se
            templ = other & (self << 9);
            tempr = other & (self >> 9);
            templ |= other & (templ << 9);
            tempr |= other & (tempr >> 9);
            maskl = other & (other << 9);
            maskr = other & (other >> 9);
            templ |= maskl & (templ << 18);
            tempr |= maskr & (tempr >> 18);
            templ |= maskl & (templ << 18);
            tempr |= maskr & (tempr >> 18);
            result |= (templ << 9) | (tempr >> 9);

            return result & ~(white | black);
        }

        public static string printPosition(Reversi pos)
        {
            StringBuilder result = new StringBuilder();
            {
                // last move
                sbyte lastMove = -1;
                System.UInt64 change = 0;
                {
                    if (pos.nMoveNum.v >= 1 && pos.nMoveNum.v <= 64)
                    {
                        // lastMove
                        {
                            if (pos.nMoveNum.v - 1 >= 0 && pos.nMoveNum.v - 1 < pos.moves.vs.Count)
                            {
                                lastMove = pos.moves.vs[pos.nMoveNum.v - 1];
                            }
                            else
                            {
                                Debug.LogError("error, nMoveNum, moves error: " + pos);
                            }
                        }
                        // change
                        {
                            if (pos.nMoveNum.v - 1 >= 0 && pos.nMoveNum.v - 1 < pos.changes.vs.Count)
                            {
                                change = pos.changes.vs[pos.nMoveNum.v - 1];
                            }
                            else
                            {
                                Debug.LogError("error, nMoveNum, changes error: " + pos);
                            }
                        }
                    }
                }
                // board
                {
                    System.UInt64 taken = pos.white.v | pos.black.v;
                    // legal
                    System.UInt64 legal = getLegal(pos.white.v, pos.black.v, pos.side.v);
                    result.Append(" `  a  b  c  d  e  f  g  h\n");
                    for (int y = 0; y < 8; y++)
                    {
                        result.Append(string.Format(" {0} ", y + 1));
                        for (int x = 0; x < 8; x++)
                        {
                            int i = 8 * y + x;
                            // piece in position
                            if ((taken & MOVEMASK[i]) != 0)
                            {
                                // check is last
                                bool isLast = false;
                                bool isLastMove = false;
                                {
                                    if (i == lastMove)
                                    {
                                        isLast = true;
                                        isLastMove = true;
                                    }
                                    if ((change & MOVEMASK[i]) != 0)
                                    {
                                        isLast = true;
                                    }
                                }
                                if ((pos.black.v & MOVEMASK[i]) != 0)
                                {
                                    if (!isLastMove)
                                    {
                                        result.Append(isLast ? " B " : " b ");
                                    }
                                    else
                                    {
                                        result.Append(isLast ? "[B]" : " b ");
                                    }
                                }
                                else
                                {
                                    if (!isLastMove)
                                    {
                                        result.Append(isLast ? " W " : " w ");
                                    }
                                    else
                                    {
                                        result.Append(isLast ? "[W]" : " w ");
                                    }
                                }
                            }
                            else
                            {
                                if ((legal & MOVEMASK[i]) != 0)
                                {
                                    result.Append(" + ");
                                }
                                else
                                {
                                    result.Append(" - ");
                                }
                            }
                        }
                        result.Append("\n");
                    }
                }
                result.Append("\n");
                // count
                {
                    int whiteCount = countSetBits(pos.white.v);
                    int blackCount = countSetBits(pos.black.v);
                    result.Append(string.Format("white count: {0}, black count: {1}\n", whiteCount, blackCount));
                }
            }
            return result.ToString();
        }

        #endregion

        #region count

        public static int countSetBits(System.UInt64 i)
        {
            i = i - ((i >> 1) & 0x5555555555555555);
            i = (i & 0x3333333333333333) + ((i >> 2) & 0x3333333333333333);
            i = (((i + (i >> 4)) & 0x0F0F0F0F0F0F0F0F) *
                0x0101010101010101) >> 56;
            return (int)i;
        }

        #endregion

        public static Vector2 convertSquareToLocalPosition(int position)
        {
            if (position >= 0 && position < 64)
            {
                int x = position % 8;
                int y = 7 - position / 8;// vi chieu cua toa do la tu duoi len tren nen phai them so 7 vao
                return new Vector2(x + 0.5f - 8 / 2.0f, y + 0.5f - 8 / 2.0f);
            }
            else
            {
                return Vector2.zero;
            }
        }

    }
}