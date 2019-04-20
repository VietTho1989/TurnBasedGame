using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Xiangqi.NoneRule;

namespace Xiangqi
{
    public class Xiangqi : GameType
    {

        const int MAX_MOVE_NUM = 1024;
        const int REP_HASH_MASK = 4095;

        public const string StartFen = "rnbakabnr/9/1c5c1/p1p1p1p1p/9/9/P1P1P1P1P/1C5C1/9/RNBAKABNR w";

        #region Property

        /** int sdPlayer;*/
        public VP<int> sdPlayer;

        #region piece

        /** uint8_t ucpcSquares[256];*/
        public LP<byte> ucpcSquares;

        public static Common.Piece Convert(byte bytePiece)
        {
            char piece = (char)(Common.PIECE_BYTE(Common.PIECE_TYPE(bytePiece)) + (bytePiece < 32 ? 0 : 'a' - 'A'));
            switch (piece)
            {
                case 'K':
                    return Common.Piece.RedGeneral;
                case 'A':
                    return Common.Piece.RedAdvisor;
                case 'B':
                    return Common.Piece.RedElephant;
                case 'N':
                    return Common.Piece.RedHorse;
                case 'R':
                    return Common.Piece.RedChariot;
                case 'C':
                    return Common.Piece.RedCannon;
                case 'P':
                    return Common.Piece.RedPawn;

                case 'k':
                    return Common.Piece.BlackGeneral;
                case 'a':
                    return Common.Piece.BlackAdvisor;
                case 'b':
                    return Common.Piece.BlackElephant;
                case 'n':
                    return Common.Piece.BlackHorse;
                case 'r':
                    return Common.Piece.BlackChariot;
                case 'c':
                    return Common.Piece.BlackCannon;
                case 'p':
                    return Common.Piece.BlackPawn;
                default:
                    return Common.Piece.None;
            }
        }

        public Common.Piece piece_on(int x, int y)
        {
            Common.Piece piece = Common.Piece.None;
            {
                int coord = Common.COORD_XY(x + 3, (9 - y) + 3);
                if (coord >= 0 && coord < this.ucpcSquares.vs.Count)
                {
                    piece = Convert(this.ucpcSquares.vs[coord]);
                }
                else
                {
                    Debug.LogError("coord error: " + x + "; " + y + "; " + coord);
                }
            }
            return piece;
        }

        public static byte Convert(Common.Piece piece)
        {
            switch (piece)
            {
                case Common.Piece.RedGeneral:
                    return 16;
                case Common.Piece.RedAdvisor:
                    return 17;
                case Common.Piece.RedElephant:
                    return 19;
                case Common.Piece.RedHorse:
                    return 21;
                case Common.Piece.RedChariot:
                    return 23;
                case Common.Piece.RedCannon:
                    return 25;
                case Common.Piece.RedPawn:
                    return 27;

                case Common.Piece.BlackGeneral:
                    return 32;
                case Common.Piece.BlackAdvisor:
                    return 33;
                case Common.Piece.BlackElephant:
                    return 35;
                case Common.Piece.BlackHorse:
                    return 37;
                case Common.Piece.BlackChariot:
                    return 39;
                case Common.Piece.BlackCannon:
                    return 41;
                case Common.Piece.BlackPawn:
                    return 43;
                case Common.Piece.None:
                    return 0;
                default:
                    return 0;
            }
        }

        public void setPieceOn(int x, int y, Common.Piece piece)
        {
            int coord = Common.COORD_XY(x + 3, (9 - y) + 3);
            if (coord >= 0 && coord < this.ucpcSquares.vs.Count)
            {
                this.ucpcSquares.set(coord, Convert(piece));
            }
            else
            {
                Debug.LogError("coord error: " + x + "; " + y + "; " + coord);
            }
        }

        #endregion

        /** uint8_t ucsqPieces[48];*/
        public LP<byte> ucsqPieces;

        /** ZobristStruct zobr;*/
        public VP<ZobristStruct> zobr;

        /** uint32_t dwBitPiece;*/
        public VP<System.UInt32> dwBitPiece;

        /** uint16_t wBitRanks[16];*/
        public LP<System.UInt16> wBitRanks;

        /** uint16_t wBitFiles[16];*/
        public LP<System.UInt16> wBitFiles;

        /** int vlWhite;*/
        public VP<int> vlWhite;

        /** int vlBlack;*/
        public VP<int> vlBlack;

        /** int nMoveNum;*/
        public VP<int> nMoveNum;

        /** int nDistance;*/
        public VP<int> nDistance;

        /** RollbackStruct rbsList[MAX_MOVE_NUM];*/
        public LP<RollbackStruct> rbsList;

        //uint8_t ucRepHash[REP_HASH_MASK + 1];
        public LP<uint> ucRepHash;

        #endregion

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            sdPlayer,
            ucpcSquares,
            ucsqPieces,
            zobr,
            dwBitPiece,
            wBitRanks,
            wBitFiles,
            vlWhite,
            vlBlack,
            nMoveNum,
            nDistance,
            rbsList,
            ucRepHash,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static Xiangqi()
        {
            AllowNames.Add((byte)Property.sdPlayer);
            AllowNames.Add((byte)Property.ucpcSquares);
            AllowNames.Add((byte)Property.ucsqPieces);
            AllowNames.Add((byte)Property.zobr);
            AllowNames.Add((byte)Property.dwBitPiece);
            AllowNames.Add((byte)Property.wBitRanks);
            AllowNames.Add((byte)Property.wBitFiles);
            AllowNames.Add((byte)Property.vlWhite);
            AllowNames.Add((byte)Property.vlBlack);
            AllowNames.Add((byte)Property.nMoveNum);
            AllowNames.Add((byte)Property.nDistance);
            AllowNames.Add((byte)Property.rbsList);
            AllowNames.Add((byte)Property.ucRepHash);
            AllowNames.Add((byte)Property.isCustom);
        }

        public Xiangqi() : base()
        {
            this.sdPlayer = new VP<int>(this, (byte)Property.sdPlayer, 0);
            this.ucpcSquares = new LP<byte>(this, (byte)Property.ucpcSquares);
            this.ucsqPieces = new LP<byte>(this, (byte)Property.ucsqPieces);
            this.zobr = new VP<ZobristStruct>(this, (byte)Property.zobr, new ZobristStruct());
            this.dwBitPiece = new VP<uint>(this, (byte)Property.dwBitPiece, 0);
            this.wBitRanks = new LP<ushort>(this, (byte)Property.wBitRanks);
            this.wBitFiles = new LP<ushort>(this, (byte)Property.wBitFiles);
            this.vlWhite = new VP<int>(this, (byte)Property.vlWhite, 0);
            this.vlBlack = new VP<int>(this, (byte)Property.vlBlack, 0);
            this.nMoveNum = new VP<int>(this, (byte)Property.nMoveNum, 0);
            this.nDistance = new VP<int>(this, (byte)Property.nDistance, 0);
            this.rbsList = new LP<RollbackStruct>(this, (byte)Property.rbsList);
            this.ucRepHash = new LP<uint>(this, (byte)Property.ucRepHash);
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // rollBackStruct
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is XiangqiIdentity)
                        {
                            XiangqiIdentity xiangqiIdentity = dataIdentity as XiangqiIdentity;
                            if (xiangqiIdentity.rbsList != this.rbsList.vs.Count)
                            {
                                ret = false;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        public System.UInt32 getLastMove()
        {
            if (this.rbsList.vs.Count > 0)
            {
                return this.rbsList.vs[this.rbsList.vs.Count - 1].mvs.v;
            }
            else
            {
                Debug.LogError("error, don't have last move");
                return 0;
            }
        }

        public static int Src(System.UInt32 dwmv)
        {
            byte[] bytes = BitConverter.GetBytes(dwmv);
            if (bytes.Length == 4)
            {
                return bytes[0];
            }
            else
            {
                Debug.LogError("error, bytes length error");
                return 0;
            }
        }

        public static int Dst(System.UInt32 dwmv)
        {
            byte[] bytes = BitConverter.GetBytes(dwmv);
            if (bytes.Length == 4)
            {
                return bytes[1];
            }
            else
            {
                Debug.LogError("error, bytes length error");
                return 0;
            }
        }

        public override Type getType()
        {
            return Type.Xiangqi;
        }

        public override int getTeamCount()
        {
            return 2;
        }

        public override int getPerspectiveCount()
        {
            return 2;
        }

        #region implement method

        public override int getPlayerIndex()
        {
            return this.sdPlayer.v == 0 ? 0 : 1;
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
                        case GameMove.Type.XiangqiMove:
                            {
                                XiangqiMove xiangqiMove = (XiangqiMove)gameMove;
                                return Core.unityIsLegalMove(this, Core.CanCorrect, xiangqiMove.move.v);
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
                        case GameMove.Type.XiangqiCustomSet:
                        case GameMove.Type.XiangqiCustomMove:
                        case GameMove.Type.Clear:
                        case GameMove.Type.EndTurn:
                        case GameMove.Type.XiangqiCustomFen:
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
                // make tempXiangqi
                Xiangqi tempXiangqi = DataUtils.cloneData(this) as Xiangqi;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.XiangqiCustomSet:
                            {
                                NoneRule.XiangqiCustomSet xiangqiCustomSet = gameMove as NoneRule.XiangqiCustomSet;
                                // set piece
                                {
                                    Debug.LogError("xiangqiCustomSet: " + xiangqiCustomSet.x.v + "; " + xiangqiCustomSet.y.v + "; " + xiangqiCustomSet.piece.v);
                                    tempXiangqi.setPieceOn(xiangqiCustomSet.x.v, xiangqiCustomSet.y.v, xiangqiCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                for (int x = 0; x < 9; x++)
                                {
                                    for (int y = 0; y < 10; y++)
                                    {
                                        tempXiangqi.setPieceOn(x, y, Common.Piece.None);
                                    }
                                }
                            }
                            break;
                        case GameMove.Type.XiangqiCustomMove:
                            {
                                NoneRule.XiangqiCustomMove xiangqiCustomMove = gameMove as NoneRule.XiangqiCustomMove;
                                // update
                                {
                                    tempXiangqi.setPieceOn(xiangqiCustomMove.destX.v, xiangqiCustomMove.destY.v, tempXiangqi.piece_on(xiangqiCustomMove.fromX.v, xiangqiCustomMove.fromY.v));
                                    tempXiangqi.setPieceOn(xiangqiCustomMove.fromX.v, xiangqiCustomMove.fromY.v, Common.Piece.None);
                                }
                            }
                            break;
                        case GameMove.Type.XiangqiCustomFen:
                            {
                                XiangqiCustomFen xiangqiCustomFen = gameMove as XiangqiCustomFen;
                                // Update
                                {
                                    tempXiangqi = Core.unityMakePositionByFen(xiangqiCustomFen.fen.v);
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
                {
                    if (needUpdate)
                    {
                        tempXiangqi.isCustom.v = true;
                        DataUtils.copyData(this, tempXiangqi, AllowNames);

                    }
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
                case GameMove.Type.XiangqiMove:
                    {
                        // get information
                        XiangqiMove xiangqiMove = (XiangqiMove)gameMove;
                        // make request to native
                        Xiangqi newXiangqi = Core.unityDoMove(this, Core.CanCorrect, xiangqiMove.move.v);
                        // update
                        DataUtils.copyData(this, newXiangqi, AllowNames);
                    }
                    break;
                case GameMove.Type.EndTurn:
                    {
                        if (this.sdPlayer.v == 0)
                        {
                            this.sdPlayer.v = 1;
                        }
                        else
                        {
                            this.sdPlayer.v = 0;
                        }
                        this.isCustom.v = true;
                    }
                    break;
                case GameMove.Type.XiangqiCustomSet:
                case GameMove.Type.Clear:
                case GameMove.Type.XiangqiCustomMove:
                case GameMove.Type.XiangqiCustomFen:
                    {
                        this.processCustomGameMove(gameMove);
                    }
                    break;
                default:
                    Debug.LogError("typicalProcessGameMove: unknown gameMove: " + gameMove + "; " + this);
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
                // find
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
                    XiangqiAI ai = (computerAI != null && computerAI is XiangqiAI) ? (XiangqiAI)computerAI : new XiangqiAI();
                    uint move = Core.unityLetComputerThink(this, true, ai.depth.v, ai.thinkTime.v, ai.useBook.v,
                                    ai.pickBestMove.v);
                    // Debug.Log ("find xiangqi move: " + move + "; " + Common.printMove (move) + "; " + ai.depth.v + "; " + ai.thinkTime.v);
                    if (move != 0)
                    {
                        XiangqiMove xiangqiMove = new XiangqiMove();
                        {
                            // Debug.LogError("xiangqiMove: " + Common.printMove(move));
                            xiangqiMove.move.v = move;
                        }
                        ret = xiangqiMove;
                    }
                    else
                    {
                        Debug.LogError("why cannot find move: " + this);
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
                // get custom set
                {
                    for (int x = 0; x < 9; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            Common.Piece alreadySelectPiece = this.piece_on(x, y);
                            foreach (Common.Piece piece in System.Enum.GetValues(typeof(Common.Piece)))
                            {
                                if (piece != alreadySelectPiece)
                                {
                                    NoneRule.XiangqiCustomSet xiangqiCustomSet = new NoneRule.XiangqiCustomSet();
                                    {
                                        xiangqiCustomSet.x.v = x;
                                        xiangqiCustomSet.y.v = y;
                                        xiangqiCustomSet.piece.v = piece;
                                    }
                                    moves.Add(xiangqiCustomSet);
                                    moves.Add(xiangqiCustomSet);
                                }
                            }
                        }
                    }
                }
                // get custom move
                {
                    for (int x = 0; x < 9; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            Common.Piece piece = this.piece_on(x, y);
                            if (piece != Common.Piece.None)
                            {
                                for (int destX = 0; destX < 9; destX++)
                                {
                                    for (int destY = 0; destY < 10; destY++)
                                    {
                                        if (destX != x || destY != y)
                                        {
                                            XiangqiCustomMove xiangqiCustomMove = new XiangqiCustomMove();
                                            {
                                                xiangqiCustomMove.fromX.v = x;
                                                xiangqiCustomMove.fromY.v = y;
                                                xiangqiCustomMove.destX.v = destX;
                                                xiangqiCustomMove.destY.v = destY;
                                            }
                                            moves.Add(xiangqiCustomMove);
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
                        // red win
                        {
                            Debug.Log("black: PlayerIndex 0 win: \n" + Common.printPosition(this));
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 1));// red
                            result.scores.Add(new GameType.Score(1, 0));// black
                        }
                        break;
                    case 2:
                        // black win
                        {
                            Debug.Log("white: PlayerIndex 1 win: \n" + Common.printPosition(this));
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));// red
                            result.scores.Add(new GameType.Score(1, 1));// black
                        }
                        break;
                    case 3:
                        // draw
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));// red
                            result.scores.Add(new GameType.Score(1, 0));// black
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
                    result.scores.Add(new GameType.Score(0, 0));// white
                    result.scores.Add(new GameType.Score(1, 0));// black
                }
            }
            // return
            return result;
        }

        #endregion

        #region convert

        public static byte[] convertToBytes(Xiangqi xiangqi)
        {
            // custom
            if (xiangqi.isCustom.v)
            {
                string strFen = Common.printPositionFen(xiangqi);
                Xiangqi newXiangqi = Core.unityMakePositionByFen(strFen);
                return convertToBytes(newXiangqi);
            }
            // not custom
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // write value
                    {
                        /** int sdPlayer;*/
                        writer.Write(xiangqi.sdPlayer.v);
                        /** uint8_t ucpcSquares[256];*/
                        {
                            for (int i = 0; i < 256; i++)
                            {
                                // get value
                                byte value = 0;
                                {
                                    if (i < xiangqi.ucpcSquares.vs.Count)
                                    {
                                        value = xiangqi.ucpcSquares.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error:  ucpcSquares: " + xiangqi);
                                    }
                                }
                                // write
                                writer.Write(value);
                            }
                        }
                        /** uint8_t ucsqPieces[48];*/
                        {
                            for (int i = 0; i < 48; i++)
                            {
                                // get value
                                byte value = 0;
                                {
                                    if (i < xiangqi.ucsqPieces.vs.Count)
                                    {
                                        value = xiangqi.ucsqPieces.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error:  ucsqPieces: " + xiangqi);
                                    }
                                }
                                // write
                                writer.Write(value);
                            }
                        }
                        /** ZobristStruct zobr;*/
                        writer.Write(ZobristStruct.convertToBytes(xiangqi.zobr.v));
                        /** uint32_t dwBitPiece;*/
                        writer.Write(xiangqi.dwBitPiece.v);
                        /** uint16_t wBitRanks[16];*/
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                // get value
                                System.UInt16 value = 0;
                                {
                                    if (i < xiangqi.wBitRanks.vs.Count)
                                    {
                                        value = xiangqi.wBitRanks.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error:  wBitRanks: " + xiangqi);
                                    }
                                }
                                // write
                                writer.Write(value);
                            }
                        }
                        /** uint16_t wBitFiles[16];*/
                        {
                            for (int i = 0; i < 16; i++)
                            {
                                // get value
                                System.UInt16 value = 0;
                                {
                                    if (i < xiangqi.wBitFiles.vs.Count)
                                    {
                                        value = xiangqi.wBitFiles.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error:  wBitFiles: " + xiangqi);
                                    }
                                }
                                // write
                                writer.Write(value);
                            }
                        }
                        /** int vlWhite;*/
                        writer.Write(xiangqi.vlWhite.v);
                        /** int vlBlack;*/
                        writer.Write(xiangqi.vlBlack.v);
                        /** int nMoveNum;*/
                        writer.Write(xiangqi.nMoveNum.v);
                        /** int nDistance;*/
                        writer.Write(xiangqi.nDistance.v);
                        /** RollbackStruct rbsList[MAX_MOVE_NUM];*/
                        {
                            int nMoveNum = Math.Min(xiangqi.nMoveNum.v, MAX_MOVE_NUM);
                            for (int i = 0; i < nMoveNum; i++)
                            {
                                // get value
                                RollbackStruct value;
                                {
                                    if (i < xiangqi.rbsList.vs.Count)
                                    {
                                        value = xiangqi.rbsList.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error:  rbsList: " + xiangqi);
                                        value = new RollbackStruct();
                                    }
                                }
                                // write
                                writer.Write(RollbackStruct.convertToBytes(value));
                            }
                        }

                        /** uint8_t ucRepHash[REP_HASH_MASK + 1];*/
                        {
                            // write uint
                            for (int i = 0; i < xiangqi.ucRepHash.vs.Count; i++)
                            {
                                if (i < (REP_HASH_MASK + 1) / 4)
                                {
                                    // get value
                                    uint value = xiangqi.ucRepHash.vs[i];
                                    // write
                                    writer.Write(value);
                                }
                                else
                                {
                                    Debug.LogError("error, why i>=REP_HASH_MASK + 1");
                                    break;
                                }
                            }
                        }
                    }
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(Xiangqi xiangqi, byte[] byteArray, int start)
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
                        /** int sdPlayer;*/
                        {
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                xiangqi.sdPlayer.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: sdPlayer: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 1:
                        /** uint8_t ucpcSquares[256];*/
                        {
                            xiangqi.ucpcSquares.clear();
                            int size = sizeof(byte);
                            for (int i = 0; i < 256; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    xiangqi.ucpcSquares.add(byteArray[count]);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: ucpcSquares: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 2:
                        /** uint8_t ucsqPieces[48];*/
                        {
                            xiangqi.ucsqPieces.clear();
                            int size = sizeof(byte);
                            for (int i = 0; i < 48; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    xiangqi.ucsqPieces.add(byteArray[count]);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: ucsqPieces: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3:
                        /** ZobristStruct zobr;*/
                        {
                            // ChangedLists cl;
                            ZobristStruct zobr = xiangqi.zobr.v;
                            // parse
                            {
                                int byteLength = ZobristStruct.parse(zobr, byteArray, count);
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
                                // Debug.LogError ("parse correct: zobr: " + xiangqi);
                            }
                            else
                            {
                                Debug.LogError("parse ChangedLists error");
                            }
                        }
                        break;
                    case 4:
                        /** uint32_t dwBitPiece;*/
                        {
                            int size = sizeof(System.UInt32);
                            if (count + size <= byteArray.Length)
                            {
                                xiangqi.dwBitPiece.v = BitConverter.ToUInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: dwBitPiece: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        /** uint16_t wBitRanks[16];*/
                        {
                            xiangqi.wBitRanks.clear();
                            int size = sizeof(System.UInt16);
                            for (int i = 0; i < 16; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    xiangqi.wBitRanks.add(BitConverter.ToUInt16(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: wBitRanks: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 6:
                        /** uint16_t wBitFiles[16];*/
                        {
                            xiangqi.wBitFiles.clear();
                            int size = sizeof(System.UInt16);
                            for (int i = 0; i < 16; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    xiangqi.wBitFiles.add(BitConverter.ToUInt16(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: wBitFiles: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 7:
                        /** int vlWhite;*/
                        {
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                xiangqi.vlWhite.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: vlWhite: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 8:
                        /** int vlBlack;*/
                        {
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                xiangqi.vlBlack.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: vlBlack: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 9:
                        /** int nMoveNum;*/
                        {
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                xiangqi.nMoveNum.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: nMoveNum: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 10:
                        /** int nDistance;*/
                        {
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                xiangqi.nDistance.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: nDistance: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 11:
                        /** RollbackStruct rbsList[MAX_MOVE_NUM];*/
                        {
                            // get list of stateInfo
                            List<RollbackStruct> rbsList = new List<RollbackStruct>();
                            for (int i = 0; i < xiangqi.nMoveNum.v; i++)
                            {
                                RollbackStruct rbs = new RollbackStruct();
                                int rbsByteLength = RollbackStruct.parse(rbs, byteArray, count);
                                if (rbsByteLength > 0)
                                {
                                    // add to chess
                                    rbsList.Add(rbs);
                                    // increase pointer
                                    count += rbsByteLength;
                                }
                                else
                                {
                                    Debug.LogError("cannot parse");
                                    break;
                                }
                            }
                            // add to chess data
                            for (int i = 0; i < rbsList.Count; i++)
                            {
                                RollbackStruct rbs = rbsList[i];
                                {
                                    rbs.uid = xiangqi.rbsList.makeId();
                                }
                                xiangqi.rbsList.add(rbs);
                            }
                        }
                        break;
                    case 12:
                        /** uint8_t ucRepHash[REP_HASH_MASK + 1];*/
                        {
                            xiangqi.ucRepHash.clear();
                            // parse
                            int size = sizeof(System.UInt32);
                            for (int i = 0; i < (REP_HASH_MASK + 1) / 4; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    xiangqi.ucRepHash.add(BitConverter.ToUInt32(byteArray, count));
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: ucRepHash: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
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
                Debug.LogError("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.Log("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

    }
}
// TODO Time
/*{
var watch = System.Diagnostics.Stopwatch.StartNew();
// TODO lam viec gi do de dem thoi gian
watch.Stop ();
var elapsedMs = watch.ElapsedMilliseconds;
}*/