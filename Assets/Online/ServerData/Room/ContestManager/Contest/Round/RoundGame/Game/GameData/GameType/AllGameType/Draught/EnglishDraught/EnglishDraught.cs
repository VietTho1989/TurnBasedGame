using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using EnglishDraught.NoneRule;

namespace EnglishDraught
{
    public class EnglishDraught : GameType
    {

        public const string StartFen = "B:W24,23,22,21,28,27,26,25,32,31,30,29:B4,3,2,1,8,7,6,5,12,11,10,9.";

        #region Sqs

        /** char Sqs[48]*/
        public LP<byte> Sqs;

        public static bool IsCorrectSquare(int square)
        {
            int x = square % 8;
            int y = square / 8;
            return (x + y) % 2 == 1;
        }

        public static byte getPiece(List<byte> Sqs, int square)
        {
            byte ret = 0;
            {
                int x = square % 8;
                int y = square / 8;
                if ((x + y) % 2 == 1)
                {
                    int index = Common.getIndexFromXY(x, y);
                    if (index >= 0 && index < 32)
                    {
                        if (index >= 0 && index < Common.BoardLoc32.Length)
                        {
                            int boardLoc32Index = Common.BoardLoc32[index];
                            if (boardLoc32Index >= 0 && boardLoc32Index < Sqs.Count)
                            {
                                ret = Sqs[boardLoc32Index];
                            }
                        }
                        else
                        {
                            Debug.LogError("index error: " + index);
                        }
                    }
                }
            }
            return ret;
        }

        public void setPieceOn(int square, byte piece)
        {
            int x = square % 8;
            int y = square / 8;
            if ((x + y) % 2 == 1)
            {
                int index = Common.getIndexFromXY(x, y);
                if (index >= 0 && index < 32)
                {
                    if (index >= 0 && index < Common.BoardLoc32.Length)
                    {
                        int boardLoc32Index = Common.BoardLoc32[index];
                        if (boardLoc32Index >= 0 && boardLoc32Index < this.Sqs.vs.Count)
                        {
                            this.Sqs.set(boardLoc32Index, piece);
                        }
                    }
                    else
                    {
                        Debug.LogError("index error: " + index);
                    }
                }
            }
        }

        #endregion

        /** SCheckerBoard C*/
        public VP<SCheckerBoard> C;

        /** int16_t nPSq*/
        public VP<System.Int16> nPSq;
        /** int16_t eval*/
        public VP<System.Int16> eval;

        /** char nWhite*/
        public VP<byte> nWhite;
        /** char nBlack*/
        public VP<byte> nBlack;

        /** char SideToMove: Black go first*/
        public VP<byte> SideToMove;
        /** char extra*/
        public VP<byte> extra;
        /** u_int64_t HashKey*/
        public VP<System.UInt64> HashKey;

        /** uint32_t ply = 0*/
        public VP<System.UInt32> ply;
        /** int64_t RepNum[MAX_GAMEMOVES]*/
        public LP<System.Int64> RepNum;
        /** uint32_t maxPly = 100*/
        public VP<System.UInt32> maxPly;
        /** uint32_t turn = 0*/
        public VP<System.UInt32> turn;

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            Sqs,
            C,
            nPSq,
            eval,
            nWhite,
            nBlack,
            SideToMove,
            extra,
            HashKey,
            ply,
            RepNum,
            maxPly,
            turn,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static EnglishDraught()
        {
            AllowNames.Add((byte)Property.Sqs);
            AllowNames.Add((byte)Property.C);
            AllowNames.Add((byte)Property.nPSq);
            AllowNames.Add((byte)Property.eval);
            AllowNames.Add((byte)Property.nWhite);
            AllowNames.Add((byte)Property.nBlack);
            AllowNames.Add((byte)Property.SideToMove);
            AllowNames.Add((byte)Property.extra);
            AllowNames.Add((byte)Property.HashKey);
            AllowNames.Add((byte)Property.ply);
            AllowNames.Add((byte)Property.RepNum);
            AllowNames.Add((byte)Property.maxPly);
            AllowNames.Add((byte)Property.turn);
            AllowNames.Add((byte)Property.isCustom);
        }

        public EnglishDraught() : base()
        {
            this.Sqs = new LP<byte>(this, (byte)Property.Sqs);
            this.C = new VP<SCheckerBoard>(this, (byte)Property.C, new SCheckerBoard());
            this.nPSq = new VP<short>(this, (byte)Property.nPSq, 0);
            this.eval = new VP<short>(this, (byte)Property.eval, 0);
            this.nWhite = new VP<byte>(this, (byte)Property.nWhite, 0);
            this.nBlack = new VP<byte>(this, (byte)Property.nBlack, 0);
            this.SideToMove = new VP<byte>(this, (byte)Property.SideToMove, 0);
            this.extra = new VP<byte>(this, (byte)Property.extra, 0);
            this.HashKey = new VP<ulong>(this, (byte)Property.HashKey, 0);
            this.ply = new VP<uint>(this, (byte)Property.ply, 0);
            this.RepNum = new LP<long>(this, (byte)Property.RepNum);
            this.maxPly = new VP<uint>(this, (byte)Property.maxPly, 0);
            this.turn = new VP<uint>(this, (byte)Property.turn, 0);
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public override Type getType()
        {
            return Type.EnglishDraught;
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // board
                if (ret)
                {
                    if (this.Sqs.vs.Count == 0)
                    {
                        Debug.LogError("error, Sqs count = 0");
                        ret = false;
                    }
                }
            }
            return ret;
        }

        #endregion

        #region implement gameType

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
            if (this.SideToMove.v == Common.BLACK)
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
                        case GameMove.Type.EnglishDraughtMove:
                            {
                                EnglishDraughtMove move = gameMove as EnglishDraughtMove;
                                // Debug.LogError ("checkLegalMove: " + move);
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
                        case GameMove.Type.EnglishDraughtCustomSet:
                            return true;
                        case GameMove.Type.EndTurn:
                            return true;
                        case GameMove.Type.Clear:
                            return true;
                        case GameMove.Type.EnglishDraughtCustomMove:
                            return true;
                        case GameMove.Type.EnglishDraughtCustomFen:
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
                // make tempEnglishDraught
                EnglishDraught tempEnglishDraught = DataUtils.cloneData(this) as EnglishDraught;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.EnglishDraughtCustomSet:
                            {
                                NoneRule.EnglishDraughtCustomSet englishDraughtCustomSet = gameMove as NoneRule.EnglishDraughtCustomSet;
                                // set piece
                                {
                                    tempEnglishDraught.setPieceOn(englishDraughtCustomSet.square.v, englishDraughtCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                for (int i = 0; i < tempEnglishDraught.Sqs.vs.Count; i++)
                                {
                                    tempEnglishDraught.Sqs.vs[i] = 0;
                                }
                            }
                            break;
                        case GameMove.Type.EnglishDraughtCustomMove:
                            {
                                NoneRule.EnglishDraughtCustomMove englishDraughtCustomMove = gameMove as NoneRule.EnglishDraughtCustomMove;
                                // update
                                {
                                    tempEnglishDraught.setPieceOn(englishDraughtCustomMove.destSquare.v, EnglishDraught.getPiece(tempEnglishDraught.Sqs.vs, englishDraughtCustomMove.fromSquare.v));
                                    tempEnglishDraught.setPieceOn(englishDraughtCustomMove.fromSquare.v, 0);
                                }
                            }
                            break;
                        case GameMove.Type.EnglishDraughtCustomFen:
                            {
                                EnglishDraughtCustomFen englishDraughtCustomFen = gameMove as EnglishDraughtCustomFen;
                                // Update
                                {
                                    tempEnglishDraught = Core.unityMakeDefaultPosition(englishDraughtCustomFen.fen.v, (int)tempEnglishDraught.maxPly.v);
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
                    tempEnglishDraught.isCustom.v = true;
                    DataUtils.copyData(this, tempEnglishDraught, AllowNames);
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
                case GameMove.Type.EnglishDraughtMove:
                    {
                        // get information
                        EnglishDraughtMove move = gameMove as EnglishDraughtMove;
                        EnglishDraught newEnglishDraught = Core.unityDoMove(this, Core.CanCorrect, move);
                        if (newEnglishDraught != null)
                        {
                            DataUtils.copyData(this, newEnglishDraught, AllowNames);
                        }
                        else
                        {
                            Debug.LogError("newEnglishDraught null: " + this);
                        }
                    }
                    break;
                case GameMove.Type.EndTurn:
                    {
                        if (this.SideToMove.v == Common.BLACK)
                        {
                            this.SideToMove.v = Common.WHITE;
                        }
                        else
                        {
                            this.SideToMove.v = Common.BLACK;
                        }
                        this.isCustom.v = true;
                    }
                    break;
                case GameMove.Type.EnglishDraughtCustomSet:
                case GameMove.Type.Clear:
                case GameMove.Type.EnglishDraughtCustomMove:
                case GameMove.Type.EnglishDraughtCustomFen:
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
                    EnglishDraughtAI ai = (computerAI != null && computerAI is EnglishDraughtAI) ? (EnglishDraughtAI)computerAI : new EnglishDraughtAI();
                    EnglishDraughtMove move = Core.unityLetComputerThink(this, true, ai.threeMoveRandom.v, ai.fMaxSeconds.v, ai.g_MaxDepth.v, ai.pickBestMove.v);
                    // Debug.LogError ("find ai move: " + Common.printMove (move) + "; " + this);
                    // return
                    ret = move;
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
                byte[] allPieceTypes = { 0, Common.BPIECE, Common.BKING, Common.WPIECE, Common.WKING };
                // get custom set
                {
                    for (int square = 0; square < 64; square++)
                    {
                        if (IsCorrectSquare(square))
                        {
                            byte alreadySelectPiece = EnglishDraught.getPiece(this.Sqs.vs, square);
                            foreach (byte piece in allPieceTypes)
                            {
                                if (piece != alreadySelectPiece)
                                {
                                    NoneRule.EnglishDraughtCustomSet englishDraughtCustomSet = new NoneRule.EnglishDraughtCustomSet();
                                    {
                                        englishDraughtCustomSet.square.v = square;
                                        englishDraughtCustomSet.piece.v = piece;
                                    }
                                    moves.Add(englishDraughtCustomSet);
                                }
                            }
                        }
                    }
                }
                // get custom move
                {
                    for (int square = 0; square < 64; square++)
                    {
                        if (IsCorrectSquare(square))
                        {
                            byte piece = EnglishDraught.getPiece(this.Sqs.vs, square);
                            if (piece != 0)
                            {
                                for (int destSquare = 0; destSquare < 64; destSquare++)
                                {
                                    if (IsCorrectSquare(destSquare))
                                    {
                                        if (destSquare != square)
                                        {
                                            EnglishDraughtCustomMove englishDraughtCustomMove = new EnglishDraughtCustomMove();
                                            {
                                                englishDraughtCustomMove.fromSquare.v = square;
                                                englishDraughtCustomMove.destSquare.v = destSquare;
                                            }
                                            moves.Add(englishDraughtCustomMove);
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
            return result;
        }

        #endregion

        #region Convert

        public static byte[] convertToBytes(EnglishDraught englishDraught, bool needCheckCustom = true)
        {
            // custom
            if (englishDraught.isCustom.v && needCheckCustom)
            {
                string strFen = Core.unityGetFen(englishDraught, Core.CanCorrect);
                Debug.LogError("englishDraught custom fen: " + strFen);
                EnglishDraught newEnglishDraught = Core.unityMakeDefaultPosition(strFen, (int)englishDraught.maxPly.v);
                return convertToBytes(newEnglishDraught);
            }
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // write value
                    {
                        /** char Sqs[48]*/
                        {
                            for (int i = 0; i < 48; i++)
                            {
                                // get value
                                byte value = 0;
                                {
                                    if (i < englishDraught.Sqs.vs.Count)
                                    {
                                        value = englishDraught.Sqs.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("error, index:  Sqs: " + englishDraught);
                                    }
                                }
                                // write
                                writer.Write(value);
                            }
                        }
                        /** SCheckerBoard C*/
                        writer.Write(SCheckerBoard.convertToBytes(englishDraught.C.v));
                        /** int16_t nPSq*/
                        writer.Write(englishDraught.nPSq.v);
                        /** int16_t eval*/
                        writer.Write(englishDraught.eval.v);
                        /** char nWhite*/
                        writer.Write(englishDraught.nWhite.v);
                        /** char nBlack*/
                        writer.Write(englishDraught.nBlack.v);
                        /** char SideToMove*/
                        writer.Write(englishDraught.SideToMove.v);
                        /** char extra*/
                        writer.Write(englishDraught.extra.v);
                        /** u_int64_t HashKey*/
                        writer.Write(englishDraught.HashKey.v);
                        /** uint32_t ply = 0*/
                        writer.Write(englishDraught.ply.v);
                        /** int64_t RepNum[MAX_GAMEMOVES]*/
                        {
                            uint ply = englishDraught.ply.v;
                            if (ply >= 0 && ply < Common.MAX_GAMEMOVES)
                            {
                                for (int i = 0; i < ply; i++)
                                {
                                    // get value
                                    System.Int64 value = 0;
                                    {
                                        if (i < englishDraught.RepNum.vs.Count)
                                        {
                                            value = englishDraught.RepNum.vs[i];
                                        }
                                        else
                                        {
                                            Debug.LogError("error, index:  RepNum: " + englishDraught);
                                        }
                                    }
                                    // write
                                    writer.Write(value);
                                }
                            }
                            else
                            {
                                Debug.LogError("ply error: " + ply);
                            }
                        }
                        /** uint32_t maxPly = 100*/
                        writer.Write(englishDraught.maxPly.v);
                        /** uint32_t turn = 0*/
                        writer.Write(englishDraught.turn.v);
                    }
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(EnglishDraught englishDraught, byte[] byteArray, int start)
        {
            // TODO co the LittleEdian va BigEndian khac nhau se co loi
            int count = start;
            int index = 0;
            bool isParseCorrect = true;
            while (count < byteArray.Length)
            {
                bool alreadyPassAll = false;
                switch (index)
                {
                    case 0:
                        /** char Sqs[48]*/
                        {
                            englishDraught.Sqs.clear();
                            int size = 1;
                            for (int i = 0; i < 48; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    englishDraught.Sqs.add(byteArray[count]);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: captureSquares: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 1:
                        /** SCheckerBoard C*/
                        {
                            SCheckerBoard C = new SCheckerBoard();
                            // parse
                            {
                                int byteLength = SCheckerBoard.parse(C, byteArray, count);
                                if (byteLength > 0)
                                {
                                    // increase pointer index
                                    count += byteLength;
                                }
                                else
                                {
                                    Debug.LogError("cannot parse");
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                            // add to data
                            if (isParseCorrect)
                            {
                                C.uid = englishDraught.C.makeId();
                                englishDraught.C.v = C;
                            }
                            else
                            {
                                Debug.LogError("parse C error");
                            }
                        }
                        break;
                    case 2:
                        /** int16_t nPSq*/
                        {
                            int size = sizeof(System.Int16);
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.nPSq.v = BitConverter.ToInt16(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: nPSq: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        /** int16_t eval*/
                        {
                            int size = sizeof(System.Int16);
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.eval.v = BitConverter.ToInt16(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: eval: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 4:
                        /** char nWhite*/
                        {
                            int size = 1;
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.nWhite.v = byteArray[count];
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: nWhite: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        /** char nBlack*/
                        {
                            int size = 1;
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.nBlack.v = byteArray[count];
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: nBlack: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 6:
                        /** char SideToMove*/
                        {
                            int size = 1;
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.SideToMove.v = byteArray[count];
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: SideToMove: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 7:
                        /** char extra*/
                        {
                            int size = 1;
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.extra.v = byteArray[count];
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: extra: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 8:
                        /** u_int64_t HashKey*/
                        {
                            int size = sizeof(System.UInt64);
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.HashKey.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: HashKey: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 9:
                        /** uint32_t ply = 0*/
                        {
                            int size = sizeof(System.UInt32);
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.ply.v = BitConverter.ToUInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: ply: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 10:
                        /** int64_t RepNum[MAX_GAMEMOVES]*/
                        {
                            englishDraught.RepNum.clear();
                            if (englishDraught.ply.v >= 0 && englishDraught.ply.v < Common.MAX_GAMEMOVES)
                            {
                                int size = sizeof(System.UInt64);
                                for (int i = 0; i < englishDraught.ply.v; i++)
                                {
                                    if (count + size <= byteArray.Length)
                                    {
                                        englishDraught.RepNum.add(BitConverter.ToInt64(byteArray, count));
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
                        }
                        break;
                    case 11:
                        /** uint32_t maxPly = 100*/
                        {
                            int size = sizeof(System.UInt32);
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.maxPly.v = BitConverter.ToUInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: maxPly: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 12:
                        /** uint32_t turn = 0*/
                        {
                            int size = sizeof(System.UInt32);
                            if (count + size <= byteArray.Length)
                            {
                                englishDraught.turn.v = BitConverter.ToUInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: turn: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    default:
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
                Debug.LogError("parse node fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.Log ("parse node success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

    }
}