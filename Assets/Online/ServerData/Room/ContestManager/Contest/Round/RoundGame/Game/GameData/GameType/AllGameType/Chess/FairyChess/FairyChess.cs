using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FairyChess.NoneRule;

namespace FairyChess
{
    public class FairyChess : GameType
    {

        /**Piece board[SQUARE_NB];*/
        public LP<int> board;

        /** Piece unpromotedBoard[SQUARE_NB];*/
        public LP<int> unpromotedBoard;

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

        public VP<int> variantType;

        /**StateInfo* st;*/
        public LP<StateInfo> st;

        /**bool chess960;*/
        public VP<bool> chess960;

        #region hand

        /** int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];*/
        public LP<int> pieceCountInHand;

        public int getPieceCountInHand(Common.PieceType pieceType, Common.Color color)
        {
            int pieceCount = 0;
            {
                int index = (int)pieceType + (int)color * (int)Common.PieceType.PIECE_TYPE_NB;
                if (index >= 0 && index < this.pieceCountInHand.vs.Count)
                {
                    pieceCount = this.pieceCountInHand.vs[index];
                }
                else
                {
                    Debug.LogError("index error: " + index + "; " + this);
                }
            }
            return pieceCount;
        }

        public void setPieceCountInHand(Common.PieceType pieceType, Common.Color color, int pieceCount)
        {
            int index = (int)pieceType + (int)color * (int)Common.PieceType.PIECE_TYPE_NB;
            if (index >= 0 && index < this.pieceCountInHand.vs.Count)
            {
                this.pieceCountInHand.set(index, pieceCount);
            }
            else
            {
                Debug.LogError("index error: " + index + "; " + this);
            }
        }

        #endregion

        /** Bitboard promotedPieces;*/
        public VP<ulong> promotedPieces;

        public int rule50_count()
        {
            if (st.getValueCount() > 0)
            {
                StateInfo last = this.st.vs[st.getValueCount() - 1];
                return last.rule50.v;
            }
            return 0;
        }

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            board,
            unpromotedBoard,
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
            variantType,
            st,
            chess960,
            pieceCountInHand,
            promotedPieces,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static FairyChess()
        {
            AllowNames.Add((byte)Property.board);
            AllowNames.Add((byte)Property.unpromotedBoard);
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
            AllowNames.Add((byte)Property.variantType);
            AllowNames.Add((byte)Property.st);
            AllowNames.Add((byte)Property.chess960);
            AllowNames.Add((byte)Property.pieceCountInHand);
            AllowNames.Add((byte)Property.promotedPieces);
            AllowNames.Add((byte)Property.isCustom);
        }

        public FairyChess() : base()
        {
            this.board = new LP<int>(this, (byte)Property.board);
            this.unpromotedBoard = new LP<int>(this, (byte)Property.unpromotedBoard);
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
            this.variantType = new VP<int>(this, (byte)Property.variantType, (int)Common.VariantType.antichess);
            this.st = new LP<StateInfo>(this, (byte)Property.st);
            this.chess960 = new VP<bool>(this, (byte)Property.chess960, false);
            this.pieceCountInHand = new LP<int>(this, (byte)Property.pieceCountInHand);
            this.promotedPieces = new VP<ulong>(this, (byte)Property.promotedPieces, 0);
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
                        if (dataIdentity is FairyChessIdentity)
                        {
                            FairyChessIdentity fairyChessIdentity = dataIdentity as FairyChessIdentity;
                            if (fairyChessIdentity.st != this.st.vs.Count)
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

        public override int getTeamCount()
        {
            return 2;
        }

        public override int getPerspectiveCount()
        {
            return 2;
        }

        public override Type getType()
        {
            return Type.FairyChess;
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
                        case GameMove.Type.FairyChessMove:
                            {
                                FairyChessMove fairyChessMove = (FairyChessMove)gameMove;
                                return Core.unityIsLegalMove(this, Core.CanCorrect, fairyChessMove.move.v);
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
                        case GameMove.Type.FairyChessCustomSet:
                        case GameMove.Type.FairyChessCustomMove:
                        case GameMove.Type.FairyChessCustomHand:
                        case GameMove.Type.Clear:
                        case GameMove.Type.EndTurn:
                        case GameMove.Type.FairyChessCustomFen:
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
                // make tempFairyChess
                FairyChess tempFairyChess = DataUtils.cloneData(this) as FairyChess;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.FairyChessCustomSet:
                            {
                                NoneRule.FairyChessCustomSet fairyChessCustomSet = gameMove as NoneRule.FairyChessCustomSet;
                                // set piece
                                {
                                    Common.Square square = Common.make_square((Common.File)fairyChessCustomSet.x.v, (Common.Rank)fairyChessCustomSet.y.v);
                                    tempFairyChess.setPieceOn(square, Common.make_piece(fairyChessCustomSet.color.v, fairyChessCustomSet.pieceType.v));
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                for (int i = 0; i < tempFairyChess.board.vs.Count; i++)
                                {
                                    tempFairyChess.board.vs[i] = (int)Common.Piece.NO_PIECE;
                                }
                            }
                            break;
                        case GameMove.Type.FairyChessCustomMove:
                            {
                                NoneRule.FairyChessCustomMove fairyChessCustomMove = gameMove as NoneRule.FairyChessCustomMove;
                                // update
                                {
                                    Common.Square fromSquare = Common.make_square((Common.File)fairyChessCustomMove.fromX.v, (Common.Rank)fairyChessCustomMove.fromY.v);
                                    Common.Square destSquare = Common.make_square((Common.File)fairyChessCustomMove.destX.v, (Common.Rank)fairyChessCustomMove.destY.v);
                                    tempFairyChess.setPieceOn(destSquare, tempFairyChess.piece_on(fromSquare));
                                    tempFairyChess.setPieceOn(fromSquare, Common.Piece.NO_PIECE);
                                }
                            }
                            break;
                        case GameMove.Type.FairyChessCustomHand:
                            {
                                FairyChessCustomHand fairyChessCustomHand = gameMove as FairyChessCustomHand;
                                // Debug.LogError ("fairyChessCustomHand: " + fairyChessCustomHand.print ());
                                // update
                                {
                                    tempFairyChess.setPieceCountInHand(fairyChessCustomHand.pieceType.v, fairyChessCustomHand.color.v, fairyChessCustomHand.pieceCount.v);
                                }
                            }
                            break;
                        case GameMove.Type.FairyChessCustomFen:
                            {
                                FairyChessCustomFen fairyChessCustomFen = gameMove as FairyChessCustomFen;
                                // Update
                                {
                                    tempFairyChess = Core.unityMakePositionByFen((Common.VariantType)tempFairyChess.variantType.v, fairyChessCustomFen.fen.v, tempFairyChess.chess960.v);
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
                    tempFairyChess.isCustom.v = true;
                    DataUtils.copyData(this, tempFairyChess, AllowNames);
                }
            }
            else
            {
                Debug.LogError("gameMove null: " + this);
            }
        }

        public override void processGameMove(GameMove gameMove)
        {
            switch (gameMove.getType())
            {
                case GameMove.Type.FairyChessMove:
                    {
                        // get information
                        FairyChessMove fairyChessMove = (FairyChessMove)gameMove;
                        // make request to native
                        FairyChess newFairyChess = Core.unityDoMove(this, Core.CanCorrect, fairyChessMove.move.v);
                        // Copy to current chess
                        DataUtils.copyData(this, newFairyChess, AllowNames);
                    }
                    break;
                case GameMove.Type.EndTurn:
                    {
                        if (this.sideToMove.v == (int)Common.Color.BLACK)
                        {
                            this.sideToMove.v = (int)Common.Color.WHITE;
                        }
                        else
                        {
                            this.sideToMove.v = (int)Common.Color.BLACK;
                        }
                        this.isCustom.v = true;
                    }
                    break;
                case GameMove.Type.FairyChessCustomMove:
                case GameMove.Type.FairyChessCustomSet:
                case GameMove.Type.FairyChessCustomHand:
                case GameMove.Type.Clear:
                case GameMove.Type.FairyChessCustomFen:
                    this.processCustomGameMove(gameMove);
                    break;
                default:
                    Debug.LogError("unknown gameMove: " + gameMove + "; " + this);
                    this.processCustomGameMove(gameMove);
                    break;
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
                // process
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
                    FairyChessAI fairyChessAI = (ai != null && ai is FairyChessAI) ? (FairyChessAI)ai : new FairyChessAI();
                    // search
                    int move = Core.unityLetComputerThink(this, Core.CanCorrect, fairyChessAI.depth.v,
                                   fairyChessAI.skillLevel.v, fairyChessAI.duration.v);
                    // make move
                    if (move != 0)
                    {
                        FairyChessMove fairyChessMove = new FairyChessMove();
                        {
                            fairyChessMove.move.v = move;
                        }
                        ret = fairyChessMove;
                    }
                    else
                    {
                        Debug.LogError("Don't find any move");
                    }
                }
                else
                {
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
                Common.Color[] colors = { Common.Color.WHITE, Common.Color.BLACK };
                // get inHand
                {
                    // find variant
                    Variant variant = null;
                    if (VariantMap.variants.TryGetValue((Common.VariantType)this.variantType.v, out variant))
                    {
                        foreach (Common.Color color in colors)
                        {
                            foreach (Common.PieceType pieceType in variant.pieceTypes)
                            {
                                int currentPieceCount = this.getPieceCountInHand(pieceType, color);
                                for (int pieceCount = 0; pieceCount < 8; pieceCount++)
                                {
                                    if (currentPieceCount != pieceCount)
                                    {
                                        FairyChessCustomHand fairyChessCustomHand = new FairyChessCustomHand();
                                        {
                                            fairyChessCustomHand.color.v = color;
                                            fairyChessCustomHand.pieceType.v = pieceType;
                                            fairyChessCustomHand.pieceCount.v = pieceCount;
                                        }
                                        moves.Add(fairyChessCustomHand);
                                    }
                                }
                            }
                        }
                    }
                }
                // get custom set
                {
                    foreach (Common.Color color in colors)
                    {
                        for (int x = 0; x < 8; x++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                Common.Square square = Common.make_square((Common.File)x, (Common.Rank)y);
                                // get current
                                Common.Piece currentPiece = this.piece_on(square);
                                if (currentPiece != Common.Piece.NO_PIECE && currentPiece != Common.Piece.PIECE_NB)
                                {
                                    Common.Color currentColor = Common.color_of(currentPiece);
                                    Common.PieceType currentPieceType = Common.type_of(currentPiece);
                                    foreach (Common.PieceType pieceType in System.Enum.GetValues(typeof(Common.PieceType)))
                                    {
                                        if (color != currentColor || pieceType != currentPieceType)
                                        {
                                            NoneRule.FairyChessCustomSet fairyChessCustomSet = new NoneRule.FairyChessCustomSet();
                                            {
                                                fairyChessCustomSet.x.v = x;
                                                fairyChessCustomSet.y.v = y;
                                                fairyChessCustomSet.color.v = color;
                                                fairyChessCustomSet.pieceType.v = pieceType;
                                            }
                                            moves.Add(fairyChessCustomSet);
                                        }
                                    }
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
                                            FairyChessCustomMove fairyChessCustomMove = new FairyChessCustomMove();
                                            {
                                                fairyChessCustomMove.fromX.v = x;
                                                fairyChessCustomMove.fromY.v = y;
                                                fairyChessCustomMove.destX.v = destX;
                                                fairyChessCustomMove.destY.v = destY;
                                            }
                                            moves.Add(fairyChessCustomMove);
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

        public static byte[] convertToBytes(FairyChess fairyChess, bool needCheckCustom = true)
        {
            // custom
            if (fairyChess.isCustom.v && needCheckCustom)
            {
                string strFen = Core.unityGetPositionFen(fairyChess, Core.CanCorrect);
                // Debug.LogError ("fairyChess custom fen: " + strFen);
                FairyChess newFairyChess = Core.unityMakePositionByFen((Common.VariantType)fairyChess.variantType.v, strFen, fairyChess.chess960.v);
                return convertToBytes(newFairyChess);
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
                            if (i < fairyChess.board.vs.Count)
                            {
                                value = fairyChess.board.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
                            }
                        }
                        writer.Write(value);
                    }
                    /** Piece unpromotedBoard[SQUARE_NB];*/
                    for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < fairyChess.unpromotedBoard.vs.Count)
                            {
                                value = fairyChess.unpromotedBoard.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.byTypeBB.vs.Count)
                            {
                                value = fairyChess.byTypeBB.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.byColorBB.vs.Count)
                            {
                                value = fairyChess.byColorBB.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.pieceCount.vs.Count)
                            {
                                value = fairyChess.pieceCount.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.pieceList.vs.Count)
                            {
                                value = fairyChess.pieceList.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.index.vs.Count)
                            {
                                value = fairyChess.index.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.castlingRightsMask.vs.Count)
                            {
                                value = fairyChess.castlingRightsMask.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.castlingRookSquare.vs.Count)
                            {
                                value = fairyChess.castlingRookSquare.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
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
                            if (i < fairyChess.castlingPath.vs.Count)
                            {
                                value = fairyChess.castlingPath.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
                            }
                        }
                        writer.Write(value);
                    }
                    /**int gamePly; public VP<int> gamePly;*/
                    writer.Write(fairyChess.gamePly.v);
                    /**Color sideToMove; public VP<int> sideToMove;*/
                    writer.Write(fairyChess.sideToMove.v);
                    // variantType
                    writer.Write(fairyChess.variantType.v);
                    /**StateInfo* st; public LP<StateInfo> st;*/
                    {
                        writer.Write(fairyChess.st.getValueCount());
                        for (int i = 0; i < fairyChess.st.getValueCount(); i++)
                        {
                            StateInfo st = fairyChess.st.vs[i];
                            writer.Write(StateInfo.convertToBytes(st));
                        }
                    }
                    /**bool chess960; public VP<bool> chess960;*/
                    writer.Write(fairyChess.chess960.v);
                    /** int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];*/
                    for (int i = 0; i < (int)Common.Color.COLOR_NB * (int)Common.PieceType.PIECE_TYPE_NB; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < fairyChess.pieceCountInHand.vs.Count)
                            {
                                value = fairyChess.pieceCountInHand.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + fairyChess);
                            }
                        }
                        writer.Write(value);
                    }
                    /** Bitboard promotedPieces;*/
                    writer.Write(fairyChess.promotedPieces.v);
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(FairyChess fairyChess, byte[] byteArray, int start)
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
                            fairyChess.board.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.board.add(BitConverter.ToInt32(byteArray, count));
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
                            /** Piece unpromotedBoard[SQUARE_NB];*/
                            fairyChess.unpromotedBoard.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.unpromotedBoard.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: unpromotedBoard: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 2:
                        {
                            /**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
                            fairyChess.byTypeBB.clear();
                            int size = sizeof(ulong);
                            for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.byTypeBB.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            /**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
                            fairyChess.byColorBB.clear();
                            int size = sizeof(ulong);
                            for (int i = 0; i < (int)Common.Color.COLOR_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.byColorBB.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            /**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
                            fairyChess.pieceCount.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.pieceCount.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            /**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
                            fairyChess.pieceList.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Piece.PIECE_NB * 16; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.pieceList.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 6:
                        {
                            /**int index[SQUARE_NB]; public LP<int> index;*/
                            fairyChess.index.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.index.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 7:
                        {
                            /**int castlingRightsMask[SQUARE_NB]; public LP<int> castlingRightsMask;*/
                            fairyChess.castlingRightsMask.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.castlingRightsMask.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 8:
                        {
                            /**Square castlingRookSquare[CASTLING_RIGHT_NB]; public LP<int> castlingRookSquare;*/
                            fairyChess.castlingRookSquare.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.castlingRookSquare.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 9:
                        {
                            /**Bitboard castlingPath[CASTLING_RIGHT_NB]; public LP<ulong> castlingPath;*/
                            fairyChess.castlingPath.clear();
                            int size = sizeof(ulong);
                            for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.castlingPath.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 10:
                        {
                            /**int gamePly; public VP<int> gamePly;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                fairyChess.gamePly.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: key: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 11:
                        {
                            /**Color sideToMove; public VP<int> sideToMove;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                fairyChess.sideToMove.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: sideToMove: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 12:
                        {
                            // variantType
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                fairyChess.variantType.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: variantType: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 13:
                        {
                            /**StateInfo* st; public LP<StateInfo> st;*/
                            fairyChess.st.clear();
                            int stateInfoNumber = 0;
                            {
                                if (count + sizeof(int) <= byteArray.Length)
                                {
                                    stateInfoNumber = BitConverter.ToInt32(byteArray, count);
                                    count += sizeof(int);
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: key: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                }
                            }
                            // parse
                            {
                                // Debug.LogError ("parse position stateInfo: " + stateInfoNumber);
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
                                        st.uid = fairyChess.st.makeId();
                                    }
                                    fairyChess.st.add(st);
                                }
                            }
                            // Debug.LogError ("Parse NativeCore: st count: " + stateInfoNumber + "; " + chess.st.vs.Count);
                        }
                        break;
                    case 14:
                        {
                            /**bool chess960; public VP<bool> chess960;*/
                            int size = sizeof(bool);
                            if (count + size <= byteArray.Length)
                            {
                                fairyChess.chess960.v = BitConverter.ToBoolean(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: chess960: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 15:
                        {
                            /** int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];*/
                            fairyChess.pieceCountInHand.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < (int)Common.Color.COLOR_NB * (int)Common.PieceType.PIECE_TYPE_NB; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    fairyChess.pieceCountInHand.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: pieceCountInHand: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 16:
                        {
                            /** Bitboard promotedPieces;*/
                            int size = sizeof(ulong);
                            if (count + size <= byteArray.Length)
                            {
                                fairyChess.promotedPieces.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: promotedPieces: " + count + "; " + byteArray.Length);
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
                Debug.LogError("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

    }
}