using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
    public class Rule
    {

        #region getAllLegalMoves

        public static void changeMoveSide(ref Rules.Move move)
        {
            move.from.y = unchecked((byte)(9 - move.from.y));
            move.dest.y = unchecked((byte)(9 - move.dest.y));
        }

        private static Rules getRule(Board board, int x, int y)
        {
            byte pieceType = Common.PieceType.None;
            if (Common.Visibility.isHide(board.board[x, y]))
            {
                pieceType = Common.getPieceType(Common.DefaultBoard[x + y * 9]);
            }
            else
            {
                pieceType = Common.getPieceType(board.board[x, y]);
            }
            switch (pieceType)
            {
                case Common.PieceType.King:
                    return RuleList.KingRule;
                case Common.PieceType.Advisor:
                    return RuleList.AdvisorRule;
                case Common.PieceType.Bishop:
                    return RuleList.BishopRule;
                case Common.PieceType.Rook:
                    return RuleList.RookRule;
                case Common.PieceType.Cannon:
                    return RuleList.CannonRule;
                case Common.PieceType.Knight:
                    return RuleList.KnightRule;
                case Common.PieceType.Pawn:
                    {
                        byte pieceSide = Common.getPieceSide(board.board[x, y]);
                        switch (pieceSide)
                        {
                            case Common.Side.Red:
                                return y >= 5 ? RuleList.PawnRule : RuleList.PromotedPawnRule;
                            case Common.Side.Black:
                            default:
                                return y < 5 ? RuleList.PawnRule : RuleList.PromotedPawnRule;
                        }
                    }
                default:
                    Debug.LogError("unknown pieceType: " + pieceType + ", " + x + "; " + y);
                    return null;
            }
        }

        public static bool isCheckingOpponent(CoTuongUp coTuongUp, byte side)
        {
            if (side == Common.Side.None)
            {
                Debug.LogError("why side none");
                return false;
            }
            Board board = getBoard(coTuongUp);
            rotateBoard(board, side);
            // Find general position
            bool haveGeneral = false;
            Rules.Coord generalCoord = new Rules.Coord();
            bool haveEnemyGeneral = false;
            Rules.Coord enemyGeneralCoord = new Rules.Coord();
            {

                for (byte x = 3; x <= 5; x++)
                {
                    for (byte y = 0; y <= 2; y++)
                    {
                        if (board.board[x, y] == Common.k)
                        {
                            haveGeneral = true;
                            generalCoord.x = x;
                            generalCoord.y = y;
                        }
                    }
                    for (byte y = 7; y <= 9; y++)
                    {
                        if (board.board[x, y] == Common.K)
                        {
                            haveEnemyGeneral = true;
                            enemyGeneralCoord.x = x;
                            enemyGeneralCoord.y = y;
                        }
                    }
                }
            }
            // have any move check
            if (haveGeneral && haveEnemyGeneral)
            {
                bool haveCheckMove = false;
                // normal move
                if (!haveCheckMove)
                {
                    for (byte x = 0; x < 9; x++)
                        for (byte y = 0; y < 10; y++)
                        {
                            if (board.side[x, y] == Common.Side.Red)
                            {
                                Rules rules = getRule(board, x, y);
                                if (rules != null)
                                {
                                    Rules.Coord pieceCoord = new Rules.Coord();
                                    {
                                        pieceCoord.x = x;
                                        pieceCoord.y = y;
                                    }
                                    List<Rules.Coord> legalCoords = rules.getLegalCoords(board, pieceCoord);
                                    for (int i = 0; i < legalCoords.Count; i++)
                                    {
                                        Rules.Coord legalCoord = legalCoords[i];
                                        if (legalCoord.x == generalCoord.x && legalCoord.y == generalCoord.y)
                                        {
                                            haveCheckMove = true;
                                            break;
                                        }
                                    }
                                    if (haveCheckMove)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("rule null");
                                }
                            }
                        }
                }
                // general vs general
                /*if (!haveCheckMove)
                {
                    if (generalCoord.x == enemyGeneralCoord.x)
                    {
                        // find have obstacle
                        bool haveObstacle = false;
                        {
                            for (int i = generalCoord.y + 1; i < enemyGeneralCoord.y; i++)
                            {
                                if (board.board[generalCoord.x, i] != Common.x)
                                {
                                    haveObstacle = true;
                                    break;
                                }
                            }
                        }
                        // process
                        if (!haveObstacle)
                        {
                            Debug.LogError("Don't have obstacle");
                            haveCheckMove = true;
                        }
                    }
                }*/
                return haveCheckMove;
            }
            else
            {
                Debug.LogError("why cannot find general");
                return false;
            }
        }

        public static List<Rules.Move> getAllLegalMoves(CoTuongUp coUp, bool needClone)
        {
            List<Rules.Move> ret = new List<Rules.Move>();
            {
                CoTuongUp coTuongUp = needClone ? (CoTuongUp)DataUtils.cloneData(coUp) : coUp;
                if (coTuongUp.nodes.vs.Count > 0)
                {
                    Node node = coTuongUp.nodes.vs[coTuongUp.nodes.vs.Count - 1];
                    // Get flipMove
                    if (coTuongUp.allowOnlyFlip.v)
                    {
                        // check you are being checked or not?
                        bool areYouBeingChecked = false;
                        {
                            areYouBeingChecked = Rule.isCheckingOpponent(coTuongUp, Common.changeSide(coTuongUp.side.v));
                        }
                        if (!areYouBeingChecked)
                        {
                            for (byte x = 0; x < 9; x++)
                                for (byte y = 0; y < 10; y++)
                                {
                                    byte piece = node.getPieceByCoord(Common.makeCoord(x, y));
                                    if (Common.Visibility.isHide(piece))
                                    {
                                        if (Common.getPieceSide(piece) == coTuongUp.side.v)
                                        {
                                            Rules.Move move = new Rules.Move();
                                            {
                                                // from
                                                {
                                                    Rules.Coord from = new Rules.Coord();
                                                    {
                                                        from.x = x;
                                                        from.y = y;
                                                    }
                                                    move.from = from;
                                                }
                                                // dest
                                                {
                                                    Rules.Coord dest = new Rules.Coord();
                                                    {
                                                        dest.x = x;
                                                        dest.y = y;
                                                    }
                                                    move.dest = dest;
                                                }
                                            }
                                            ret.Add(move);
                                        }
                                    }
                                }
                        }
                        else
                        {
                            // Debug.LogError ("you are being checked, so cannot flip");
                        }
                    }
                    // Normal Moves
                    {
                        List<Rules.Move> normalMoves = new List<Rules.Move>();
                        // Find normalMoves
                        {
                            Board board = Rule.getBoard(coTuongUp);
                            rotateBoard(board, coTuongUp.side.v);
                            for (byte x = 0; x < 9; x++)
                                for (byte y = 0; y < 10; y++)
                                {
                                    if (board.side[x, y] == Common.Side.Red)
                                    {
                                        Rules rules = getRule(board, x, y);
                                        if (rules != null)
                                        {
                                            Rules.Coord pieceCoord = new Rules.Coord();
                                            {
                                                pieceCoord.x = x;
                                                pieceCoord.y = y;
                                            }
                                            List<Rules.Coord> legalCoords = rules.getLegalCoords(board, pieceCoord);
                                            for (int i = 0; i < legalCoords.Count; i++)
                                            {
                                                Rules.Coord legalCoord = legalCoords[i];
                                                Rules.Move move = new Rules.Move();
                                                {
                                                    move.from = pieceCoord;
                                                    move.dest = legalCoord;
                                                }
                                                normalMoves.Add(move);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("rule null");
                                        }
                                    }
                                }
                            // Change Move Side
                            if (coTuongUp.side.v == Common.Side.Black)
                            {
                                for (int i = 0; i < normalMoves.Count; i++)
                                {
                                    normalMoves[i].from.y = unchecked((byte)(9 - normalMoves[i].from.y));
                                    normalMoves[i].dest.y = unchecked((byte)(9 - normalMoves[i].dest.y));
                                }
                            }
                        }
                        // after normalMoves, will check?
                        for (int i = 0; i < normalMoves.Count; i++)
                        {
                            Rules.Move move = normalMoves[i];
                            // check this is legalMove
                            bool isLegalMove = true;
                            {
                                coTuongUp.doMove(move, true);
                                if (isCheckingOpponent(coTuongUp, coTuongUp.side.v))
                                {
                                    // Debug.LogError ("opponent is checking: " + coTuongUp + "; " + move);
                                    isLegalMove = false;
                                }
                                coTuongUp.undoMove();
                            }
                            // Add
                            if (isLegalMove)
                            {
                                ret.Add(move);
                            }
                            else
                            {
                                // Debug.LogError ("not legal move: " + move);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("why don't have any node: " + coTuongUp);
                }
            }
            return ret;
        }

        #endregion

        public static Board getBoard(Node node)
        {
            Board board = new Board();
            {
                board.board = new byte[9, 10];
                board.side = new byte[9, 10];
                for (byte x = 0; x < 9; x++)
                    for (byte y = 0; y < 10; y++)
                    {
                        byte piece = node.getPieceByCoord(Common.makeCoord(x, y));
                        board.board[x, y] = piece;
                        board.side[x, y] = Common.getPieceSide(piece);
                    }
            }
            return board;
        }

        public static Board getBoard(CoTuongUp coTuongUp)
        {
            if (coTuongUp.nodes.vs.Count > 0)
            {
                Node node = coTuongUp.nodes.vs[coTuongUp.nodes.vs.Count - 1];
                return getBoard(node);
            }
            else
            {
                Debug.LogError("why don't have node: " + coTuongUp);
                Board board = new Board();
                {
                    board.board = new byte[9, 10];
                    board.side = new byte[9, 10];
                }
                return board;
            }
        }

        public static void rotateBoard(Board board, byte side)
        {
            if (side == Common.Side.Black)
            {
                if (board.board.GetLength(0) == 9 && board.board.GetLength(1) == 10
                    && board.side.GetLength(0) == 9 && board.board.GetLength(1) == 10)
                {
                    for (byte x = 0; x < 9; x++)
                        for (byte y = 0; y < 5; y++)
                        {
                            // board
                            {
                                byte temp = board.board[x, y];
                                board.board[x, y] = Common.changePieceSide(board.board[x, 9 - y]);
                                board.board[x, 9 - y] = Common.changePieceSide(temp);
                            }
                            // side
                            {
                                byte temp = board.side[x, y];
                                board.side[x, y] = Common.changeSide(board.side[x, 9 - y]);
                                board.side[x, 9 - y] = Common.changeSide(temp);
                            }
                        }
                }
                else
                {
                    Debug.LogError("boardSize error: " + board);
                }
            }
            else
            {
                // Debug.Log ("Don't need rotate");
            }
        }
    }
}