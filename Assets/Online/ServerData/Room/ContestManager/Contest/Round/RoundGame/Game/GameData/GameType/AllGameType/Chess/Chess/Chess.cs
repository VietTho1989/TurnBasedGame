using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Chess.NoneRule;

namespace Chess
{
    public class Chess : GameType
    {

        public const string DefaultFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        /**Piece board[SQUARE_NB];*/
        public LP<int> board;

        /**Bitboard byTypeBB[PIECE_TYPE_NB];*/
        public LP<ulong> byTypeBB;

        /**Bitboard byColorBB[COLOR_NB];*/
        public LP<ulong> byColorBB;

        /**int pieceCount[PIECE_NB];*/
        public LP<int> pieceCount;

        /**Square pieceList[PIECE_NB][16];*/
        public LP<int> pieceList;

        /**int index[SQUARE_NB];*/
        public LP<int> index;

        /**int castlingRightsMask[SQUARE_NB];*/
        public LP<int> castlingRightsMask;

        /**Square castlingRookSquare[CASTLING_RIGHT_NB];*/
        public LP<int> castlingRookSquare;

        /**Bitboard castlingPath[CASTLING_RIGHT_NB];*/
        public LP<ulong> castlingPath;

        /**int gamePly;*/
        public VP<int> gamePly;

        /**Color sideToMove;*/
        public VP<int> sideToMove;

        /**StateInfo* st;*/
        public LP<StateInfo> st;

        public int rule50_count()
        {
            if (st.getValueCount() > 0)
            {
                StateInfo last = this.st.vs[st.getValueCount() - 1];
                return last.rule50.v;
            }
            return 0;
        }

        /**bool chess960;*/
        public VP<bool> chess960;

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            board,
            byTypeBB,
            byColorBB,
            pieceCount,
            pieceList,
            index,
            castlingRightsMask,
            castlingRookSquare,
            castlingPath,
            gamePly,
            sideToMove,
            st,
            chess960,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static Chess()
        {
            AllowNames.Add((byte)Property.board);
            AllowNames.Add((byte)Property.byTypeBB);
            AllowNames.Add((byte)Property.byColorBB);
            AllowNames.Add((byte)Property.pieceCount);
            AllowNames.Add((byte)Property.pieceList);
            AllowNames.Add((byte)Property.index);
            AllowNames.Add((byte)Property.castlingRightsMask);
            AllowNames.Add((byte)Property.castlingRookSquare);
            AllowNames.Add((byte)Property.castlingPath);
            AllowNames.Add((byte)Property.gamePly);
            AllowNames.Add((byte)Property.sideToMove);
            AllowNames.Add((byte)Property.st);
            AllowNames.Add((byte)Property.chess960);
            AllowNames.Add((byte)Property.isCustom);
        }

        public Chess() : base()
        {
            this.board = new LP<int>(this, (byte)Property.board);
            this.byTypeBB = new LP<ulong>(this, (byte)Property.byTypeBB);
            this.byColorBB = new LP<ulong>(this, (byte)Property.byColorBB);
            this.pieceCount = new LP<int>(this, (byte)Property.pieceCount);
            this.pieceList = new LP<int>(this, (byte)Property.pieceList);
            this.index = new LP<int>(this, (byte)Property.index);
            this.castlingRightsMask = new LP<int>(this, (byte)Property.castlingRightsMask);
            this.castlingRookSquare = new LP<int>(this, (byte)Property.castlingRookSquare);
            this.castlingPath = new LP<ulong>(this, (byte)Property.castlingPath);
            this.gamePly = new VP<int>(this, (byte)Property.gamePly, 0);
            this.sideToMove = new VP<int>(this, (byte)Property.sideToMove, (int)Common.Color.BLACK);
            this.st = new LP<StateInfo>(this, (byte)Property.st);
            this.chess960 = new VP<bool>(this, (byte)Property.chess960, false);
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // board
                if (ret)
                {
                    if (this.board.vs.Count == 0)
                    {
                        Debug.LogError("Don't have any piece");
                        ret = false;
                    }
                }
                // st
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is ChessIdentity)
                        {
                            ChessIdentity chessIdentity = dataIdentity as ChessIdentity;
                            if (chessIdentity.st != this.st.vs.Count)
                            {
                                Debug.LogError("st count error");
                                ret = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("why not chessIdentity");
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        public override Type getType()
        {
            return Type.CHESS;
        }

        public Common.Piece piece_on(Common.Square s)
        {
            if ((int)s >= 0 && (int)s < this.board.vs.Count)
            {
                return (Common.Piece)this.board.vs[(int)s];
            }
            else
            {
                return Common.Piece.NO_PIECE;
            }
        }

        public void setPieceOn(Common.Square square, Common.Piece piece)
        {
            if ((int)square >= 0 && (int)square < this.board.vs.Count)
            {
                this.board.set((int)square, (int)piece);
            }
            else
            {
                Debug.LogError("outside board: " + this);
            }
        }

        #region Logic

        public override int getTeamCount()
        {
            return 2;
        }

        public override int getPerspectiveCount()
        {
            return 2;
        }

        public override int getPlayerIndex()
        {
            switch (this.sideToMove.v)
            {
                case (int)Common.Color.WHITE:
                    return 0;
                case (int)Common.Color.BLACK:
                    return 1;
                default:
                    Debug.LogError("unknown side to move: " + this.sideToMove.v);
                    return 0;
            }
        }

        public override bool checkLegalMove(InputData inputData)
        {
            GameMove gameMove = inputData.gameMove.v;
            if (gameMove != null)
            {
                if (GameData.IsUseRule(this))
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.ChessMove:
                            {
                                ChessMove chessMove = gameMove as ChessMove;
                                return Core.unityIsLegalMove(this, Core.CanCorrect, chessMove.move.v);
                            }
                        // break;
                        default:
                            Debug.LogError("unknown game type: " + gameMove.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.ChessMove:
                            return true;
                        case GameMove.Type.ChessCustomSet:
                            return true;
                        case GameMove.Type.EndTurn:
                            return true;
                        case GameMove.Type.Clear:
                            return true;
                        case GameMove.Type.ChessCustomMove:
                            return true;
                        default:
                            Debug.LogError("unknown game type: " + gameMove.getType() + "; " + this);
                            return true;
                    }
                }
            }
            else
            {
                Debug.LogError("gameMove null: " + this);
            }
            return false;
        }

        #region processGameMove

        private void processCustomGameMove(GameMove gameMove)
        {
            if (gameMove != null)
            {
                // make tempChess
                Chess tempChess = DataUtils.cloneData(this) as Chess;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.ChessCustomSet:
                            {
                                ChessCustomSet chessCustomSet = gameMove as ChessCustomSet;
                                // set piece
                                {
                                    Common.Square square = Common.make_square((Common.File)chessCustomSet.x.v, (Common.Rank)chessCustomSet.y.v);
                                    tempChess.setPieceOn(square, chessCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                for (int i = 0; i < tempChess.board.vs.Count; i++)
                                {
                                    tempChess.board.vs[i] = (int)Common.Piece.NO_PIECE;
                                }
                            }
                            break;
                        case GameMove.Type.ChessCustomMove:
                            {
                                ChessCustomMove chessCustomMove = gameMove as ChessCustomMove;
                                // update
                                {
                                    Common.Square fromSquare = Common.make_square((Common.File)chessCustomMove.fromX.v, (Common.Rank)chessCustomMove.fromY.v);
                                    Common.Square destSquare = Common.make_square((Common.File)chessCustomMove.destX.v, (Common.Rank)chessCustomMove.destY.v);
                                    tempChess.setPieceOn(destSquare, tempChess.piece_on(fromSquare));
                                    tempChess.setPieceOn(fromSquare, Common.Piece.NO_PIECE);
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + gameMove.getType() + "; " + this);
                            needUpdate = false;
                            break;
                    }
                }
                // Update
                if (needUpdate)
                {
                    tempChess.isCustom.v = true;
                    DataUtils.copyData(this, tempChess, AllowNames);
                }
            }
            else
            {
                Debug.LogError("gameMove null: " + this);
            }
        }

        public override void processGameMove(GameMove gameMove)
        {
            if (gameMove != null)
            {
                switch (gameMove.getType())
                {
                    case GameMove.Type.ChessMove:
                        {
                            // get information
                            ChessMove chessMove = gameMove as ChessMove;
                            // make request to native
                            Chess newChess = Core.unityDoMove(this, Core.CanCorrect, chessMove.move.v);
                            // Copy to current chess
                            DataUtils.copyData(this, newChess, AllowNames);
                        }
                        break;
                    case GameMove.Type.None:
                        break;
                    case GameMove.Type.EndTurn:
                        {
                            if (this.sideToMove.v == (int)Common.Color.WHITE)
                            {
                                this.sideToMove.v = (int)Common.Color.BLACK;
                            }
                            else
                            {
                                this.sideToMove.v = (int)Common.Color.WHITE;
                            }
                            this.isCustom.v = true;
                        }
                        break;
                    case GameMove.Type.ChessCustomSet:
                    case GameMove.Type.Clear:
                    case GameMove.Type.ChessCustomMove:
                        this.processCustomGameMove(gameMove);
                        break;
                    default:
                        Debug.LogError("unknown gameMove: " + gameMove + "; " + this);
                        this.processCustomGameMove(gameMove);
                        break;
                }
            }
            else
            {
                Debug.LogError("gameMove null: " + this);
            }
        }

        #endregion

        #region getAIMove

        public override GameMove getAIMove(Computer.AI ai, bool isFindHint)
        {
            GameMove ret = new NonMove();
            {
                // check is userNormalMove
                bool useNormalMove = true;
                {
                    if (GameData.IsUseRule(this))
                    {
                        useNormalMove = true;
                    }
                    else
                    {
                        useNormalMove = false;
                        /*GameData gameData = this.findDataInParent<GameData>();
						if (gameData != null) {
							Turn turn = gameData.turn.v;
							if (turn != null) {
								if (turn.turn.v % 4 == 0 || turn.turn.v % 4 == 2) {
									useNormalMove = false;
								}
							} else {
								Debug.LogError ("turn null: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}*/
                    }
                }
                // Process
                if (useNormalMove)
                {
                    // sleep until get enough data
                    {
                        int count = 0;
                        while (true)
                        {
                            if (isLoadFull())
                            {
                                break;
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(1000);
                                Debug.LogError("need sleep: " + count);
                                count++;
                                if (count >= 360)
                                {
                                    Debug.LogError("why don't have data");
                                    return new NonMove();
                                }
                            }
                        }
                    }
                    // get ai
                    ChessAI chessAI = (ai != null && ai is ChessAI) ? (ChessAI)ai : new ChessAI();
                    // search
                    int move = Core.unityLetComputerThink(this, Core.CanCorrect, chessAI.depth.v,
                        chessAI.skillLevel.v, chessAI.duration.v);
                    // make move
                    {
                        ChessMove chessMove = new ChessMove();
                        {
                            chessMove.move.v = move;
                        }
                        ret = chessMove;
                    }
                }
                else
                {
                    // Debug.LogError ("not use rule: " + this);
                    GameMove customMove = getCustomMove();
                    if (customMove != null)
                    {
                        ret = customMove;
                    }
                    else
                    {
                        Debug.LogError("customMove null: " + this);
                    }
                }
            }
            return ret;
        }

        public GameMove getCustomMove()
        {
            // find moves
            List<GameMove> moves = new List<GameMove>();
            {
                // get custom set
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            Common.Square square = Common.make_square((Common.File)x, (Common.Rank)y);
                            Common.Piece alreadySelectPiece = this.piece_on(square);
                            foreach (Common.Piece piece in System.Enum.GetValues(typeof(Common.Piece)))
                            {
                                if (piece != alreadySelectPiece && piece != Common.Piece.PIECE_NB)
                                {
                                    ChessCustomSet chessCustomSet = new ChessCustomSet();
                                    {
                                        chessCustomSet.x.v = x;
                                        chessCustomSet.y.v = y;
                                        chessCustomSet.piece.v = piece;
                                    }
                                    moves.Add(chessCustomSet);
                                }
                            }
                        }
                    }
                }
                // get custom move
                {
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            Common.Square square = Common.make_square((Common.File)x, (Common.Rank)y);
                            Common.Piece piece = this.piece_on(square);
                            if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.PIECE_NB)
                            {
                                for (int destX = 0; destX < 8; destX++)
                                {
                                    for (int destY = 0; destY < 8; destY++)
                                    {
                                        if (destX != x || destY != y)
                                        {
                                            ChessCustomMove chessCustomMove = new ChessCustomMove();
                                            {
                                                chessCustomMove.fromX.v = x;
                                                chessCustomMove.fromY.v = y;
                                                chessCustomMove.destX.v = destX;
                                                chessCustomMove.destY.v = destY;
                                            }
                                            moves.Add(chessCustomMove);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // get clear
                {
                    Clear clear = new Clear();
                    {

                    }
                    moves.Add(clear);
                }
                // endTurn
                {
                    EndTurn endTurn = new EndTurn();
                    {

                    }
                    moves.Add(endTurn);
                }
            }
            // choose
            if (moves.Count > 0)
            {
                System.Random random = new System.Random();
                int index = random.Next(0, moves.Count);
                if (index >= 0 && index < moves.Count)
                {
                    return moves[index];
                }
                else
                {
                    Debug.LogError("index error: " + index + "; " + this);
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        #endregion

        public override Result isGameFinish()
        {
            Result result = Result.makeDefault();
            // process
            if (GameData.IsUseRule(this))
            {
                int isGameFinish = Core.unityIsGameFinish(this, Core.CanCorrect);
                switch (isGameFinish)
                {
                    case 0:
                        {
                            result.isGameFinish = false;
                        }
                        break;
                    case 1:
                        // white win
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 1));// white
                            result.scores.Add(new GameType.Score(1, 0));// black
                        }
                        break;
                    case 2:
                        // black win
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));// white
                            result.scores.Add(new GameType.Score(1, 1));// black
                        }
                        break;
                    case 3:
                        // draw
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0.5f));// white
                            result.scores.Add(new GameType.Score(1, 0.5f));// black
                        }
                        break;
                    default:
                        Debug.LogError("unknown result: " + this);
                        break;
                }
            }
            else
            {
                bool isTooManyTurn = false;
                {
                    GameData gameData = this.findDataInParent<GameData>();
                    if (gameData != null)
                    {
                        Turn turn = gameData.turn.v;
                        if (turn != null)
                        {
                            if (turn.turn.v >= 1000)
                            {
                                isTooManyTurn = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("turn null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("gameData null: " + this);
                    }
                }
                if (isTooManyTurn)
                {
                    // draw
                    result.isGameFinish = true;
                    // score
                    result.scores.Add(new GameType.Score(0, 0.5f));// white
                    result.scores.Add(new GameType.Score(1, 0.5f));// black
                }
            }
            // return
            return result;
        }

        #endregion

        #region convert

        public static byte[] convertToBytes(Chess chess, bool needCheckCustom = true)
        {
            // custom
            if (chess.isCustom.v && needCheckCustom)
            {
                string strFen = Core.unityPositionToFen(chess, Core.CanCorrect);
                Debug.LogError("chess custom fen: " + strFen);
                Chess newChess = Core.unityMakePositionByFen(strFen, chess.chess960.v);
                return convertToBytes(newChess);
            }
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    /**Piece board[SQUARE_NB]; public LP<int> board;*/
                    for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < chess.board.vs.Count)
                            {
                                value = chess.board.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
                    for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++)
                    {
                        // get value
                        ulong value = 0;
                        {
                            if (i < chess.byTypeBB.vs.Count)
                            {
                                value = chess.byTypeBB.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
                    for (int i = 0; i < (int)Common.Color.COLOR_NB; i++)
                    {
                        // get value
                        ulong value = 0;
                        {
                            if (i < chess.byColorBB.vs.Count)
                            {
                                value = chess.byColorBB.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
                    for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < chess.pieceCount.vs.Count)
                            {
                                value = chess.pieceCount.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
                    for (int i = 0; i < (int)Common.Piece.PIECE_NB * 16; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < chess.pieceList.vs.Count)
                            {
                                value = chess.pieceList.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**int index[SQUARE_NB]; public LP<int> index;*/
                    for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < chess.index.vs.Count)
                            {
                                value = chess.index.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**int castlingRightsMask[SQUARE_NB]; public LP<int> castlingRightsMask;*/
                    for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < chess.castlingRightsMask.vs.Count)
                            {
                                value = chess.castlingRightsMask.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**Square castlingRookSquare[CASTLING_RIGHT_NB]; public LP<int> castlingRookSquare;*/
                    for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < chess.castlingRookSquare.vs.Count)
                            {
                                value = chess.castlingRookSquare.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**Bitboard castlingPath[CASTLING_RIGHT_NB]; public LP<ulong> castlingPath;*/
                    for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++)
                    {
                        // get value
                        ulong value = 0;
                        {
                            if (i < chess.castlingPath.vs.Count)
                            {
                                value = chess.castlingPath.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + chess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**int gamePly; public VP<int> gamePly;*/
                    writer.Write(chess.gamePly.v);
                    /**Color sideToMove; public VP<int> sideToMove;*/
                    writer.Write(chess.sideToMove.v);
                    /**StateInfo* st; public LP<StateInfo> st;*/
                    {
                        // Debug.LogError ("convertToBytes: NativeCore: st count: " + chess.st.getValueCount ());
                        writer.Write(chess.st.getValueCount());
                        for (int i = 0; i < chess.st.getValueCount(); i++)
                        {
                            StateInfo st = chess.st.vs[i];
                            writer.Write(StateInfo.convertToBytes(st));
                        }
                    }
                    /**bool chess960; public VP<bool> chess960;*/
                    writer.Write(chess.chess960.v);

                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(Chess chess, byte[] byteArray, int start)
        {
            int count = start;
            int index = 0;
            bool isParseCorrect = true;
            while (count < byteArray.Length)
            {
                bool alreadyPassAll = false;
                switch (index)
                {
                    case 0:
                        {
                            /**Piece board[SQUARE_NB]; public LP<int> board;*/
                            chess.board.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.board.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: board: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            /**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
                            chess.byTypeBB.clear();
                            int size = sizeof(ulong);
                            for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.byTypeBB.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: byTypeBB: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            /**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
                            chess.byColorBB.clear();
                            int size = sizeof(ulong);
                            for (int i = 0; i < (int)Common.Color.COLOR_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.byColorBB.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: byColorBB: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            /**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
                            chess.pieceCount.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.pieceCount.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: pieceCount: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            /**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
                            chess.pieceList.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Piece.PIECE_NB * 16; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.pieceList.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: pieceList: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            /**int index[SQUARE_NB]; public LP<int> index;*/
                            chess.index.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.index.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: index: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 6:
                        {
                            /**int castlingRightsMask[SQUARE_NB]; public LP<int> castlingRightsMask;*/
                            chess.castlingRightsMask.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.castlingRightsMask.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: castlingRightsMask: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 7:
                        {
                            /**Square castlingRookSquare[CASTLING_RIGHT_NB]; public LP<int> castlingRookSquare;*/
                            chess.castlingRookSquare.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.castlingRookSquare.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: castlingRookSquare: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 8:
                        {
                            /**Bitboard castlingPath[CASTLING_RIGHT_NB]; public LP<ulong> castlingPath;*/
                            chess.castlingPath.clear();
                            int size = sizeof(ulong);
                            for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chess.castlingPath.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: castlingPath: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 9:
                        {
                            /**int gamePly; public VP<int> gamePly;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                chess.gamePly.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: gamePly: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 10:
                        {
                            /**Color sideToMove; public VP<int> sideToMove;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                chess.sideToMove.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: sideToMove: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 11:
                        {
                            /**StateInfo* st; public LP<StateInfo> st;*/
                            chess.st.clear();
                            int stateInfoNumber = 0;
                            {
                                int size = sizeof(int);
                                if (count + size <= byteArray.Length)
                                {
                                    stateInfoNumber = BitConverter.ToInt32(byteArray, count);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: stateInfoNumber: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                }
                            }
                            // parse
                            {
                                // get list of stateInfo
                                List<StateInfo> sts = new List<StateInfo>();
                                for (int i = 0; i < stateInfoNumber; i++)
                                {
                                    StateInfo st = new StateInfo();
                                    int stateInfoByteLength = StateInfo.parse(st, byteArray, count);
                                    if (stateInfoByteLength > 0)
                                    {
                                        sts.Add(st);
                                        count += stateInfoByteLength;
                                    }
                                    else
                                    {
                                        Debug.LogError("cannot parse");
                                        break;
                                    }
                                }
                                // add to chess data
                                for (int i = 0; i < sts.Count; i++)
                                {
                                    StateInfo st = sts[i];
                                    {
                                        st.uid = chess.st.makeId();
                                    }
                                    chess.st.add(st);
                                }
                            }
                        }
                        break;
                    case 12:
                        {
                            /**bool chess960; public VP<bool> chess960;*/
                            int size = sizeof(bool);
                            if (count + size <= byteArray.Length)
                            {
                                chess.chess960.v = BitConverter.ToBoolean(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: chess960: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    default:
                        // Debug.LogError ("unknown index: " + index);
                        alreadyPassAll = true;
                        break;
                }
                index++;
                if (!isParseCorrect)
                {
                    Debug.LogError("not parse correct");
                    break;
                }
                if (alreadyPassAll)
                {
                    break;
                }
            }
            // return
            if (!isParseCorrect)
            {
                Debug.LogError("parse fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.LogError ("parse success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

    }
}