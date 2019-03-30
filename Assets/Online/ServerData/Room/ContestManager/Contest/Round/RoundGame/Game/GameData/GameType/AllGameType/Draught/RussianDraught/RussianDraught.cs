using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using RussianDraught.NoneRule;

namespace RussianDraught
{
    public class RussianDraught : GameType
    {

        public const string StartFen = "bbbbbbbbbbbb........wwwwwwwwwwwww";

        #region board

        /** int32_t Board[46];*/
        public LP<int> Board;

        public int getPiece(int square)
        {
            int[,] b = new int[8, 8];
            {
                List<int> Board = this.Board.vs;
                b[0, 0] = Board[5];
                b[2, 0] = Board[6];
                b[4, 0] = Board[7];
                b[6, 0] = Board[8];
                b[1, 1] = Board[10];
                b[3, 1] = Board[11];
                b[5, 1] = Board[12];
                b[7, 1] = Board[13];
                b[0, 2] = Board[14];
                b[2, 2] = Board[15];
                b[4, 2] = Board[16];
                b[6, 2] = Board[17];
                b[1, 3] = Board[19];
                b[3, 3] = Board[20];
                b[5, 3] = Board[21];
                b[7, 3] = Board[22];
                b[0, 4] = Board[23];
                b[2, 4] = Board[24];
                b[4, 4] = Board[25];
                b[6, 4] = Board[26];
                b[1, 5] = Board[28];
                b[3, 5] = Board[29];
                b[5, 5] = Board[30];
                b[7, 5] = Board[31];
                b[0, 6] = Board[32];
                b[2, 6] = Board[33];
                b[4, 6] = Board[34];
                b[6, 6] = Board[35];
                b[1, 7] = Board[37];
                b[3, 7] = Board[38];
                b[5, 7] = Board[39];
                b[7, 7] = Board[40];
            }
            if (square >= 0 && square < 64)
            {
                return b[square % 8, square / 8];
            }
            else
            {
                Debug.LogError("square error: " + square + "; " + this);
                return Common.FREE;
            }
        }

        public void setPieceOn(int square, int piece)
        {
            // find index
            int index = square;
            {
                int[,] b = new int[8, 8];
                {
                    b[0, 0] = 5;
                    b[2, 0] = 6;
                    b[4, 0] = 7;
                    b[6, 0] = 8;
                    b[1, 1] = 10;
                    b[3, 1] = 11;
                    b[5, 1] = 12;
                    b[7, 1] = 13;
                    b[0, 2] = 14;
                    b[2, 2] = 15;
                    b[4, 2] = 16;
                    b[6, 2] = 17;
                    b[1, 3] = 19;
                    b[3, 3] = 20;
                    b[5, 3] = 21;
                    b[7, 3] = 22;
                    b[0, 4] = 23;
                    b[2, 4] = 24;
                    b[4, 4] = 25;
                    b[6, 4] = 26;
                    b[1, 5] = 28;
                    b[3, 5] = 29;
                    b[5, 5] = 30;
                    b[7, 5] = 31;
                    b[0, 6] = 32;
                    b[2, 6] = 33;
                    b[4, 6] = 34;
                    b[6, 6] = 35;
                    b[1, 7] = 37;
                    b[3, 7] = 38;
                    b[5, 7] = 39;
                    b[7, 7] = 40;
                }
                // get
                if (square >= 0 && square < 64)
                {
                    index = b[square % 8, square / 8];
                }
                else
                {
                    Debug.LogError("square error: " + square + "; " + this);
                    index = 0;
                }
            }
            // set
            if (index >= 0 && index < this.Board.vs.Count)
            {
                this.Board.set(index, piece);
            }
            else
            {
                Debug.LogError("index error: " + index);
            }
        }

        #endregion

        /** uint32_t num_wpieces = 0;*/
        public VP<uint> num_wpieces;
        /** uint32_t num_bpieces = 0;*/
        public VP<uint> num_bpieces;

        /** int32_t Color = WHITE;*/
        public VP<int> Color;

        /** int32_t g_root_mb = 0;*/
        public VP<int> g_root_mb;

        /** int32_t realdepth = 0;*/
        public VP<int> realdepth;

        /** U64 RepNum[MAXDEPTH];*/
        public LP<System.UInt64> RepNum;

        /** U64 HASH_KEY = 0;*/
        public VP<System.UInt64> HASH_KEY;

        /** uint32_t p_list[3][16];*/
        public LP<uint> p_list;

        /** uint32_t indices[41];*/
        public LP<uint> indices;

        /** int32_t g_pieces[11];*/
        public LP<int> g_pieces;

        /** bool Reversible[MAXDEPTH+1];*/
        public LP<bool> Reversible;

        /** uint32_t c_num[MAXDEPTH+1][16];*/
        public LP<uint> c_num;

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            Board,
            num_wpieces,
            num_bpieces,
            Color,
            g_root_mb,
            realdepth,
            RepNum,
            HASH_KEY,
            p_list,
            indices,
            g_pieces,
            Reversible,
            c_num,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static RussianDraught()
        {
            AllowNames.Add((byte)Property.Board);
            AllowNames.Add((byte)Property.num_wpieces);
            AllowNames.Add((byte)Property.num_bpieces);
            AllowNames.Add((byte)Property.Color);
            AllowNames.Add((byte)Property.g_root_mb);
            AllowNames.Add((byte)Property.realdepth);
            AllowNames.Add((byte)Property.RepNum);
            AllowNames.Add((byte)Property.HASH_KEY);
            AllowNames.Add((byte)Property.p_list);
            AllowNames.Add((byte)Property.indices);
            AllowNames.Add((byte)Property.g_pieces);
            AllowNames.Add((byte)Property.Reversible);
            AllowNames.Add((byte)Property.c_num);
            AllowNames.Add((byte)Property.isCustom);
        }

        public RussianDraught() : base()
        {
            this.Board = new LP<int>(this, (byte)Property.Board);
            this.num_wpieces = new VP<uint>(this, (byte)Property.num_wpieces, 0);
            this.num_bpieces = new VP<uint>(this, (byte)Property.num_bpieces, 0);
            this.Color = new VP<int>(this, (byte)Property.Color, Common.WHITE);
            this.g_root_mb = new VP<int>(this, (byte)Property.g_root_mb, 0);
            this.realdepth = new VP<int>(this, (byte)Property.realdepth, 0);
            this.RepNum = new LP<ulong>(this, (byte)Property.RepNum);
            this.HASH_KEY = new VP<ulong>(this, (byte)Property.HASH_KEY, 0);
            this.p_list = new LP<uint>(this, (byte)Property.p_list);
            this.indices = new LP<uint>(this, (byte)Property.indices);
            this.g_pieces = new LP<int>(this, (byte)Property.g_pieces);
            this.Reversible = new LP<bool>(this, (byte)Property.Reversible);
            this.c_num = new LP<uint>(this, (byte)Property.c_num);
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // board
                if (ret)
                {
                    if (this.Board.vs.Count == 0)
                    {
                        Debug.LogError("board don't have piece");
                        ret = false;
                    }
                }
            }
            return ret;
        }

        #endregion

        public override Type getType()
        {
            return Type.RussianDraught;
        }

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
            if (this.Color.v == Common.WHITE)
            {
                return 0;
            }
            else
            {
                return 1;
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
                        case GameMove.Type.RussianDraughtMove:
                            {
                                RussianDraughtMove move = gameMove as RussianDraughtMove;
                                return Core.unityIsLegalMove(this, Core.CanCorrect, move);
                            }
                        // break;
                        default:
                            Debug.LogError("unknown game move type: " + gameMove.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.RussianDraughtCustomSet:
                            return true;
                        case GameMove.Type.EndTurn:
                            return true;
                        case GameMove.Type.Clear:
                            return true;
                        case GameMove.Type.RussianDraughtCustomMove:
                            return true;
                        case GameMove.Type.RussianDraughtCustomFen:
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
                // make tempRussianDraught
                RussianDraught tempRussianDraught = DataUtils.cloneData(this) as RussianDraught;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.RussianDraughtCustomSet:
                            {
                                NoneRule.RussianDraughtCustomSet russianDraughtCustomSet = gameMove as NoneRule.RussianDraughtCustomSet;
                                // set piece
                                {
                                    tempRussianDraught.setPieceOn(russianDraughtCustomSet.square.v, russianDraughtCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                for (int i = 0; i < tempRussianDraught.Board.vs.Count; i++)
                                {
                                    tempRussianDraught.Board.set(i, Common.FREE);
                                }
                            }
                            break;
                        case GameMove.Type.RussianDraughtCustomMove:
                            {
                                NoneRule.RussianDraughtCustomMove russianDraughtCustomMove = gameMove as NoneRule.RussianDraughtCustomMove;
                                // update
                                {
                                    tempRussianDraught.setPieceOn(russianDraughtCustomMove.destSquare.v, tempRussianDraught.getPiece(russianDraughtCustomMove.fromSquare.v));
                                    tempRussianDraught.setPieceOn(russianDraughtCustomMove.fromSquare.v, Common.FREE);
                                }
                            }
                            break;
                        case GameMove.Type.RussianDraughtCustomFen:
                            {
                                RussianDraughtCustomFen russianDraughtCustomFen = gameMove as RussianDraughtCustomFen;
                                // Update
                                {
                                    tempRussianDraught = Core.unityMakePositionByFen(russianDraughtCustomFen.fen.v);
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
                    tempRussianDraught.isCustom.v = true;
                    DataUtils.copyData(this, tempRussianDraught, AllowNames);
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
                case GameMove.Type.RussianDraughtMove:
                    {
                        // get information
                        RussianDraughtMove move = gameMove as RussianDraughtMove;
                        RussianDraught newRussianDraught = Core.unityDoMove(this, Core.CanCorrect, move);
                        if (newRussianDraught != null)
                        {
                            DataUtils.copyData(this, newRussianDraught, AllowNames);
                        }
                        else
                        {
                            Debug.LogError("newRussianDraught null: " + this);
                        }
                    }
                    break;
                case GameMove.Type.EndTurn:
                    {
                        if (this.Color.v == Common.WHITE)
                        {
                            this.Color.v = Common.BLACK;
                        }
                        else
                        {
                            this.Color.v = Common.WHITE;
                        }
                        this.isCustom.v = true;
                    }
                    break;
                case GameMove.Type.RussianDraughtCustomSet:
                case GameMove.Type.Clear:
                case GameMove.Type.RussianDraughtCustomMove:
                case GameMove.Type.RussianDraughtCustomFen:
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

        public override GameMove getAIMove(Computer.AI computerAI, bool isFindHint)
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
                    RussianDraughtAI ai = (computerAI != null && computerAI is RussianDraughtAI) ? (RussianDraughtAI)computerAI : new RussianDraughtAI();
                    RussianDraughtMove move = Core.unityLetComputerThink(this, true, ai.timeLimit.v, ai.pickBestMove.v);
                    if (move != null)
                    {
                        ret = move;
                    }
                    else
                    {
                        Debug.LogError("move null: " + this);
                        List<RussianDraughtMove> legalMoves = Core.unityGetLegalMoves(this, true);
                        if (legalMoves.Count > 0)
                        {
                            ret = legalMoves[0];
                        }
                        else
                        {
                            Debug.LogError("why don't have any legalMoves");
                        }
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
            // Debug.LogError ("russianDraught get ai move: " + ret);
            return ret;
        }

        public GameMove getCustomMove()
        {
            // find moves
            List<GameMove> moves = new List<GameMove>();
            {
                int[] allPieces = { Common.FREE, Common.WHT_MAN, Common.BLK_MAN, Common.WHT_KNG, Common.BLK_KNG };
                // get custom set
                {
                    for (int square = 0; square < 64; square++)
                    {
                        if (Common.isDarkSquare(square))
                        {
                            int alreadySelectPiece = this.getPiece(square);
                            foreach (int piece in allPieces)
                            {
                                if (piece != alreadySelectPiece)
                                {
                                    NoneRule.RussianDraughtCustomSet russianDraughtCustomSet = new NoneRule.RussianDraughtCustomSet();
                                    {
                                        russianDraughtCustomSet.square.v = square;
                                        russianDraughtCustomSet.piece.v = piece;
                                    }
                                    moves.Add(russianDraughtCustomSet);
                                }
                            }
                        }
                    }
                }
                // get custom move
                {
                    for (int square = 0; square < 64; square++)
                    {
                        int alreadySelectPiece = this.getPiece(square);
                        if (Common.isRealPiece(alreadySelectPiece))
                        {
                            for (int destSquare = 0; destSquare < 64; destSquare++)
                            {
                                if (Common.isDarkSquare(destSquare))
                                {
                                    if (destSquare != square)
                                    {
                                        RussianDraughtCustomMove russianDraughtCustomMove = new RussianDraughtCustomMove();
                                        {
                                            russianDraughtCustomMove.fromSquare.v = square;
                                            russianDraughtCustomMove.destSquare.v = destSquare;
                                        }
                                        moves.Add(russianDraughtCustomMove);
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
            bool isTooManyTurn = false;
            {
                GameData gameData = this.findDataInParent<GameData>();
                if (gameData != null)
                {
                    Turn turn = gameData.turn.v;
                    if (turn != null)
                    {
                        if (turn.turn.v >= 3000)
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
            else
            {
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
                            // black win
                            {
                                result.isGameFinish = true;
                                // score
                                result.scores.Add(new GameType.Score(0, 1));// black: 0 index
                                result.scores.Add(new GameType.Score(1, 0));// white: 1 index
                            }
                            break;
                        case 2:
                            // white win
                            {
                                result.isGameFinish = true;
                                // score
                                result.scores.Add(new GameType.Score(0, 0));// black: 0 index
                                result.scores.Add(new GameType.Score(1, 1));// white: 1 index
                            }
                            break;
                        case 3:
                            // draw
                            {
                                result.isGameFinish = true;
                                // score
                                result.scores.Add(new GameType.Score(0, 0));// black: 0 index
                                result.scores.Add(new GameType.Score(1, 0));// white: 1 index
                            }
                            break;
                        default:
                            Debug.LogError("unknown result: " + this);
                            break;
                    }
                }
                else
                {

                }
            }
            return result;
        }

        #region Convert

        public static byte[] convertToBytes(RussianDraught russianDraught, bool needCheckCustom = true)
        {
            // custom
            if (russianDraught.isCustom.v && needCheckCustom)
            {
                string strFen = Core.unityPositionToFen(russianDraught, Core.CanCorrect);
                Debug.LogError("russianDraught custom fen: " + strFen);
                RussianDraught newRussianDraught = Core.unityMakePositionByFen(strFen);
                return convertToBytes(newRussianDraught);
            }
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    /** int32_t Board[46];*/
                    for (int i = 0; i < 46; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < russianDraught.Board.vs.Count)
                            {
                                value = russianDraught.Board.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }
                    /** uint32_t num_wpieces = 0;*/
                    writer.Write(russianDraught.num_wpieces.v);
                    /** uint32_t num_bpieces = 0;*/
                    writer.Write(russianDraught.num_bpieces.v);
                    /** int32_t Color = WHITE;*/
                    writer.Write(russianDraught.Color.v);
                    /** int32_t g_root_mb = 0;*/
                    writer.Write(russianDraught.g_root_mb.v);
                    /** int32_t realdepth = 0;*/
                    writer.Write(russianDraught.realdepth.v);
                    /** U64 RepNum[MAXDEPTH];*/
                    for (int i = 0; i < Common.MAXDEPTH; i++)
                    {
                        // get value
                        System.UInt64 value = 0;
                        {
                            if (i < russianDraught.RepNum.vs.Count)
                            {
                                value = russianDraught.RepNum.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }
                    /** U64 HASH_KEY = 0;*/
                    writer.Write(russianDraught.HASH_KEY.v);
                    /** uint32_t p_list[3][16];*/
                    for (int i = 0; i < 3 * 16; i++)
                    {
                        // get value
                        System.UInt32 value = 0;
                        {
                            if (i < russianDraught.p_list.vs.Count)
                            {
                                value = russianDraught.p_list.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }
                    /** uint32_t indices[41];*/
                    for (int i = 0; i < 41; i++)
                    {
                        // get value
                        System.UInt32 value = 0;
                        {
                            if (i < russianDraught.indices.vs.Count)
                            {
                                value = russianDraught.indices.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }
                    /** int32_t g_pieces[11];*/
                    for (int i = 0; i < 11; i++)
                    {
                        // get value
                        System.Int32 value = 0;
                        {
                            if (i < russianDraught.g_pieces.vs.Count)
                            {
                                value = russianDraught.g_pieces.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }
                    /** bool Reversible[MAXDEPTH+1];*/
                    for (int i = 0; i < Common.MAXDEPTH + 1; i++)
                    {
                        // get value
                        bool value = false;
                        {
                            if (i < russianDraught.Reversible.vs.Count)
                            {
                                value = russianDraught.Reversible.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }
                    /** uint32_t c_num[MAXDEPTH+1][16];*/
                    for (int i = 0; i < (Common.MAXDEPTH + 1) * 16; i++)
                    {
                        // get value
                        System.UInt32 value = 0;
                        {
                            if (i < russianDraught.c_num.vs.Count)
                            {
                                value = russianDraught.c_num.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + russianDraught);
                            }
                        }
                        writer.Write(value);
                    }

                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            // Debug.LogError ("convert RussianDraught: " + byteArray.Length);
            return byteArray;
        }

        public static int parse(RussianDraught russianDraught, byte[] byteArray, int start)
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
                            /** int32_t Board[46];*/
                            russianDraught.Board.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < 46; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.Board.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: Board: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            /** uint32_t num_wpieces = 0;*/
                            int size = sizeof(uint);
                            if (count + size <= byteArray.Length)
                            {
                                russianDraught.num_wpieces.v = BitConverter.ToUInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: num_wpieces: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 2:
                        {
                            /** uint32_t num_bpieces = 0;*/
                            int size = sizeof(uint);
                            if (count + size <= byteArray.Length)
                            {
                                russianDraught.num_bpieces.v = BitConverter.ToUInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: num_bpieces: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        {
                            /** int32_t Color = WHITE;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                russianDraught.Color.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: Color: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 4:
                        {
                            /** int32_t g_root_mb = 0;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                russianDraught.g_root_mb.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: g_root_mb: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        {
                            /** int32_t realdepth = 0;*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                russianDraught.realdepth.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: realdepth: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 6:
                        {
                            /** U64 RepNum[MAXDEPTH];*/
                            russianDraught.RepNum.clear();
                            int size = sizeof(System.UInt64);
                            for (int i = 0; i < Common.MAXDEPTH; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.RepNum.add(BitConverter.ToUInt64(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: RepNum: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 7:
                        {
                            /** U64 HASH_KEY = 0;*/
                            int size = sizeof(System.UInt64);
                            if (count + size <= byteArray.Length)
                            {
                                russianDraught.HASH_KEY.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: HASH_KEY: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 8:
                        {
                            /** uint32_t p_list[3][16];*/
                            russianDraught.p_list.clear();
                            int size = sizeof(System.UInt32);
                            for (int i = 0; i < 3 * 16; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.p_list.add(BitConverter.ToUInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: p_list: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 9:
                        {
                            /** uint32_t indices[41];*/
                            russianDraught.indices.clear();
                            int size = sizeof(System.UInt32);
                            for (int i = 0; i < 41; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.indices.add(BitConverter.ToUInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: indices: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 10:
                        {
                            /** int32_t g_pieces[11];*/
                            russianDraught.g_pieces.clear();
                            int size = sizeof(System.Int32);
                            for (int i = 0; i < 11; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.g_pieces.add(BitConverter.ToInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: g_pieces: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 11:
                        {
                            /** bool Reversible[MAXDEPTH+1];*/
                            russianDraught.Reversible.clear();
                            int size = sizeof(bool);
                            for (int i = 0; i < Common.MAXDEPTH + 1; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.Reversible.add(BitConverter.ToBoolean(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: p_list: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 12:
                        {
                            /** uint32_t c_num[MAXDEPTH+1][16];*/
                            russianDraught.c_num.clear();
                            int size = sizeof(System.UInt32);
                            for (int i = 0; i < (Common.MAXDEPTH + 1) * 16; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    russianDraught.c_num.add(BitConverter.ToUInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: c_num: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
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
                Debug.LogError("parse russianDraught fail: " + count + "; " + byteArray.Length + "; " + start);
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