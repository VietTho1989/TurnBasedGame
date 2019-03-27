using UnityEngine;
using System.Collections;
using System.Text;

namespace Weiqi
{
    public class Common
    {
        /* Maximum supported board size. (Without the S_OFFBOARD edges.) */
        public const int BOARD_MAX_SIZE = 19;

        public const int BOARD_MAX_COORDS = (19 + 2) * (19 + 2);//(BOARD_MAX_SIZE + 2) * (BOARD_MAX_SIZE + 2);

        public enum stone
        {
            S_NONE,
            S_BLACK,
            S_WHITE,
            S_OFFBOARD,
            S_MAX
        };

        public const int BOARD_MAX_GROUPS = (BOARD_MAX_SIZE * BOARD_MAX_SIZE * 2 / 3);

        /* The ruleset is currently almost never taken into account;
     * the board implementation is basically Chinese rules (handicap
     * stones compensation) w/ suicide (or you can look at it as
     * New Zealand w/o handi stones compensation), while the engine
     * enforces no-suicide, making for real Chinese rules.
     * However, we accept suicide moves by the opponent, so we
     * should work with rules allowing suicide, just not taking
     * full advantage of them. */
        public enum go_ruleset
        {
            RULES_CHINESE, /* default value */
            RULES_AGA,
            RULES_NEW_ZEALAND,
            RULES_JAPANESE,
            RULES_STONES_ONLY, /* do not count eyes */
                               /* http://home.snafu.de/jasiek/siming.html */
                               /* Simplified ING rules - RULES_CHINESE with handicaps
                            * counting as points and pass stones. Also should
                            * allow suicide, but Pachi will never suicide
                            * nevertheless. */
                               /* XXX: I couldn't find the point about pass stones
                               * in the rule text, but it is Robert Jasiek's
                               * interpretation of them... These rules were
                               * used e.g. at the EGC2012 13x13 tournament.
                               * They are not supported by KGS. */
            RULES_SIMING,
        };

        public enum engine_id
        {
            E_RANDOM,
            E_REPLAY,
            E_PATTERNSCAN,
            E_PATTERNPLAY,
            E_MONTECARLO,
            E_UCT,
            E_DISTRIBUTED,
            E_JOSEKI,
            E_DCNN,
            E_MAX
        };

        ///////////////////////////////////////////////////////////////////////////////////
        /// /////////////// Print ////////////////////
        /// ///////////////////////////////////////////////////////////////////////////////

        public static int coord_x(int boardSize, int c)
        {
            if (boardSize > 0 && c >= 0)
            {
                return c % boardSize;
            }
            else
            {
                // Debug.LogError ("error, coord_x: why boardSize<0: " + boardSize + "; " + c);
                return 0;
            }
        }

        public static int coord_y(int boardSize, int c)
        {
            if (boardSize > 0 && c >= 0)
            {
                return c / boardSize;
            }
            else
            {
                Debug.LogError("error, coord_y: why boardSize<0: " + boardSize + c);
                return 0;
            }
        }

        public const int pass = -1;
        public const int resign = -2;

        const string asdf = "abcdefghjklmnopqrstuvwxyz";

        public static string printMove(WeiqiMove move)
        {
            string ret = "";
            // color
            {
                if (move.color.v == (int)stone.S_BLACK)
                {
                    ret = "Black ";
                }
                else
                {
                    ret = "White ";
                }
            }
            // coord
            {
                ret += coordToString(move.coord.v, move.boardSize.v);
            }
            ret += " " + move.coord;
            return ret;
        }

        public static string printMove(WeiqiMove move, int boardSize)
        {
            string ret = "";
            // color
            {
                if (move.color.v == (int)stone.S_BLACK)
                {
                    ret = "Black ";
                }
                else
                {
                    ret = "White ";
                }
            }
            // coord
            {
                ret += coordToString(move.coord.v, boardSize);
            }
            ret += " " + move.coord;
            return ret;
        }

        public static string coordToString(int coord, int boardSize)
        {
            if (coord == pass)
            {
                return "pass";
            }
            else if (coord == resign)
            {
                return "resign";
            }
            else
            {
                // find coord
                int coordX = coord_x(boardSize, coord);
                int coordY = coord_y(boardSize, coord);
                // process
                {
                    if (coordX - 1 >= 0 && coordX - 1 < asdf.Length)
                    {
                        return char.ToUpper(asdf[coordX - 1]) + "" + coordY + " (" + coordX + ", " + coordY + ")";
                    }
                    else
                    {
                        // Debug.LogError ("coordX error: " + coordX);
                        return "error";
                    }
                }
            }
        }

        #region print position

        private static int board_atxy(Board board, int x, int y)
        {
            int i = x + board.size.v * y;
            if (i >= 0 && i < board.b.vs.Count)
            {
                return board.b.vs[i];
            }
            else
            {
                Debug.LogError("error, board_atxy: " + i + ", " + board.b.vs.Count);
                return (int)Common.stone.S_NONE;
            }
        }

        private static char stone2char(int s)
        {
            string str = ".XO#";
            if (s >= 0 && s < str.Length)
            {
                return str[s];
            }
            else
            {
                Debug.LogError("error, stone2char: " + s + ", " + str.Length);
                return str[0];
            }
        }

        private static string board_print_top(Board board)
        {
            StringBuilder ret = new StringBuilder();
            {
                {
                    string asdf = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
                    ret.Append("     ");
                    for (int x = 1; x < board.size.v - 1; x++)
                    {
                        ret.Append(" " + asdf[x - 1]);
                    }
                    ret.Append(" ");
                }
                ret.Append("\n");
                {
                    ret.Append("    +-");
                    for (int x = 1; x < board.size.v - 1; x++)
                    {
                        ret.Append("--");
                    }
                    ret.Append("+");
                }
                ret.Append("\n");
            }
            return ret.ToString();
        }

        private static string board_print_row(Board board, int y)
        {
            StringBuilder ret = new StringBuilder();
            {
                ret.Append(string.Format(" {0} | ", y.ToString("D2")));
                for (int x = 1; x < board.size.v - 1; x++)
                {
                    // check is last move
                    int lastMoveIndex = 0;
                    {
                        // lastMove
                        if (lastMoveIndex == 0)
                        {
                            if (board.last_move.v.coord.v >= 0)
                            {
                                int coordX = coord_x(board.size.v, board.last_move.v.coord.v);
                                int coordY = coord_y(board.size.v, board.last_move.v.coord.v);
                                if (coordX == x && coordY == y)
                                {
                                    lastMoveIndex = 1;
                                }
                            }
                        }
                        // lastMove2
                        if (lastMoveIndex == 0)
                        {
                            if (board.last_move2.v.coord.v >= 0)
                            {
                                int coordX = coord_x(board.size.v, board.last_move2.v.coord.v);
                                int coordY = coord_y(board.size.v, board.last_move2.v.coord.v);
                                if (coordX == x && coordY == y)
                                {
                                    lastMoveIndex = 2;
                                }
                            }
                        }
                        // lastMove3
                        if (lastMoveIndex == 0)
                        {
                            if (board.last_move3.v.coord.v >= 0)
                            {
                                int coordX = coord_x(board.size.v, board.last_move3.v.coord.v);
                                int coordY = coord_y(board.size.v, board.last_move3.v.coord.v);
                                if (coordX == x && coordY == y)
                                {
                                    lastMoveIndex = 3;
                                }
                            }
                        }
                        // lastMove4
                        if (lastMoveIndex == 0)
                        {
                            if (board.last_move4.v.coord.v >= 0)
                            {
                                int coordX = coord_x(board.size.v, board.last_move4.v.coord.v);
                                int coordY = coord_y(board.size.v, board.last_move4.v.coord.v);
                                if (coordX == x && coordY == y)
                                {
                                    lastMoveIndex = 4;
                                }
                            }
                        }
                    }
                    switch (lastMoveIndex)
                    {
                        case 0:
                            {
                                ret.Append(stone2char(board_atxy(board, x, y)) + " ");
                            }
                            break;
                        case 1:
                            {
                                // Debug.LogError ("test:  " + board_atxy (board, x, y));
                                ret.Append(char.ToLower(stone2char(board_atxy(board, x, y))) + "1");
                            }
                            break;
                        case 2:
                            {
                                ret.Append(char.ToLower(stone2char(board_atxy(board, x, y))) + "2");
                            }
                            break;
                        case 3:
                            {
                                ret.Append(char.ToLower(stone2char(board_atxy(board, x, y))) + "3");
                            }
                            break;
                        case 4:
                            {
                                ret.Append(char.ToLower(stone2char(board_atxy(board, x, y))) + "4");
                            }
                            break;
                        default:
                            {
                                Debug.LogError("error, unknown lastMoveIndex: " + lastMoveIndex);
                                ret.Append(stone2char(board_atxy(board, x, y)) + " ");
                            }
                            break;
                    }
                }
                ret.Append("|\n");
            }
            return ret.ToString();
        }

        private static string board_print_bottom(Board board)
        {
            StringBuilder ret = new StringBuilder();
            {
                {
                    ret.Append("    +-");
                    for (int x = 1; x < board.size.v - 1; x++)
                    {
                        ret.Append("--");
                    }
                    ret.Append("+");
                }
                ret.Append("\n");
            }
            return ret.ToString();
        }

        private static string printBoard(Board board)
        {
            StringBuilder ret = new StringBuilder();
            {
                ret.Append(string.Format("Move: {0}  Komi: {1}  Handicap: {2}  Captures B: {3} W: {4}  ", board.moves.v, board.komi.v, board.handicap.v, board.getCaptures((int)stone.S_BLACK), board.getCaptures((int)stone.S_WHITE)));
                ret.Append("\n");
                ret.Append(board_print_top(board));
                for (int y = board.size.v - 2; y >= 1; y--)
                {
                    ret.Append(board_print_row(board, y));
                }
                ret.Append(board_print_bottom(board));
            }
            return ret.ToString();
        }

        private static string printOwnerMap(Weiqi position)
        {
            StringBuilder ret = new StringBuilder();
            {
                int boardSize = position.b.v.size.v;
                // print top
                {
                    {
                        string asdf = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
                        ret.Append("      ");
                        for (int x = 1; x < boardSize - 1; x++)
                        {
                            if (x - 1 >= 0 && x - 1 < asdf.Length)
                            {
                                ret.Append(asdf[x - 1] + " ");
                            }
                            else
                            {
                                ret.Append(asdf[0] + " ");
                            }
                        }
                        ret.Append(" ");
                    }
                    ret.Append("\n");
                    {
                        ret.Append("    +-");
                        for (int x = 1; x < boardSize - 1; x++)
                        {
                            ret.Append("--");
                        }
                        ret.Append("+");
                    }
                    ret.Append("\n");
                }
                // print row
                {
                    // for row
                    for (int y = boardSize - 2; y >= 1; y--)
                    {
                        // print row
                        ret.Append(string.Format(" {0} | ", y.ToString("D2")));
                        for (int x = 1; x < boardSize - 1; x++)
                        {
                            int coord = x + boardSize * y;
                            if (coord >= 0 && coord < position.scoreOwnerMap.vs.Count)
                            {
                                switch (position.scoreOwnerMap.vs[coord])
                                {
                                    case 0:
                                        {
                                            ret.Append(". ");
                                        }
                                        break;
                                    case 1:
                                        {
                                            // black
                                            string str = "";
                                            {
                                                str = "X ";
                                            }
                                            // choose correct char to print
                                            {
                                                stone s = Board.GetBoardStone(position.b.v.b.vs, coord);
                                                // cho trong
                                                if (s == stone.S_NONE)
                                                {
                                                    str = "x ";
                                                }
                                                // quan den
                                                else if (s == stone.S_BLACK)
                                                {
                                                    str = "X ";
                                                }
                                                // quan trang capture
                                                else if (s == stone.S_WHITE)
                                                {
                                                    str = "x)";
                                                }
                                            }
                                            ret.Append(str);
                                        }
                                        break;
                                    case 2:
                                        {
                                            // white
                                            string str = "";
                                            {
                                                str = "X ";
                                            }
                                            // choose correct char to print
                                            {
                                                stone s = Board.GetBoardStone(position.b.v.b.vs, coord);
                                                // cho trong
                                                if (s == stone.S_NONE)
                                                {
                                                    str = "o ";
                                                }
                                                // quan trang
                                                else if (s == stone.S_WHITE)
                                                {
                                                    str = "O ";
                                                }
                                                // quan den capture
                                                else if (s == stone.S_WHITE)
                                                {
                                                    str = "o)";
                                                }
                                            }
                                            ret.Append(str);
                                        }
                                        break;
                                    case 3:
                                        {
                                            // dame
                                            ret.Append(". ");
                                        }
                                        break;
                                    default:
                                        {
                                            //printf("error, don't know score owner map value: %d\n", value);
                                            ret.Append("  ");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("error, coord: " + coord);
                            }
                        }
                        ret.Append("|\n");
                    }
                }
                // print bottom
                {
                    {
                        ret.Append("    +-");
                        for (int x = 1; x < position.b.v.size.v - 1; x++)
                        {
                            ret.Append("--");
                        }
                        ret.Append("+");
                    }
                    ret.Append("\n");
                }
            }
            return ret.ToString();
        }

        #region printDeadGroups

        public static bool groupnext_at(Board b, int c, out int ret)
        {
            if (c >= 0 && c < b.pp.vs.Count)
            {
                ret = b.pp.vs[c];
                return true;
            }
            else
            {
                // Debug.LogError ("groupnext_at: " + c);
                ret = 0;
                return false;
            }
        }

        private static string printDeadGroups(Board b, MoveQueue mq)
        {
            StringBuilder ret = new StringBuilder();
            {
                ret.Append(string.Format("dead groups: {0}\n", mq.moves.v));
                if (mq.moves.v == 0)
                {
                    ret.Append("  none\n");
                }
                else
                {
                    for (int i = 0; i < mq.moves.v; i++)
                    {
                        ret.Append("  ");
                        {
                            int group = mq.getMove(i);
                            // while
                            {
                                // them count vao de phong lap vo tan
                                int count = 0;
                                // iteriate
                                int c = group;
                                int c2 = c;
                                if (groupnext_at(b, c2, out c2))
                                {
                                    do
                                    {
                                        count++;
                                        // print
                                        ret.Append(coordToString(c, b.size.v) + " ");
                                        // next
                                        c = c2;
                                        if (!groupnext_at(b, c2, out c2))
                                        {
                                            Debug.LogError("group error");
                                            break;
                                        }
                                    } while (c != 0 && count < 361);
                                }
                                else
                                {
                                    Debug.LogError("group error");
                                }
                            }

                        }
                        ret.Append("\n");
                    }
                }
            }
            return ret.ToString();
        }

        #endregion

        public static string printPosition(Weiqi pos)
        {
            StringBuilder ret = new StringBuilder();
            {
                // board
                {
                    ret.Append("\n" + printBoard(pos.b.v));
                }
                // print owner map
                {
                    ret.Append("\n");
                    ret.Append(printOwnerMap(pos));
                }
                // dead group
                {
                    ret.Append("\n");
                    ret.Append(printDeadGroups(pos.b.v, pos.deadgroup.v));
                }
                // score
                ret.Append(string.Format("\nblack score: {0}, white score: {1}, dame: {2}, score: {3}", pos.scoreBlack, pos.scoreWhite, pos.dame, pos.score));
            }
            return ret.ToString();
        }

        #endregion

        #region Convert

        public static Vector2 convertCoordToLocalPosition(int boardSize, int coord)
        {
            int x = Common.coord_x(boardSize, coord);
            int y = Common.coord_y(boardSize, coord);
            return new Vector2(x - boardSize / 2.0f + 0.5f, y - boardSize / 2.0f + 0.5f);
        }

        #endregion

    }
}