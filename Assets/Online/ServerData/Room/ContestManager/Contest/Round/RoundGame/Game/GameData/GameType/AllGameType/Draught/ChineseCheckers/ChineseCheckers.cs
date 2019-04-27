using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class ChineseCheckers : GameType
    {

        public const string INITIAL_POSITION =
        "1"+
        "11"+
        "111"+
        "1111"+
        "0000000000000"+
        "000000000000"+
        "00000000000"+
        "0000000000"+
        "000000000"+
        "0000000000"+
        "00000000000"+
        "000000000000"+
        "0000000000000"+
        "2222"+
        "222"+
        "22"+
        "2"+
        " "+
        "x";

        /** std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;*/
        public LP<byte> _squares;

        /** Pebble _turn;*/
        public VP<byte> _turn;

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            _squares,
            _turn,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static ChineseCheckers()
        {
            AllowNames.Add((byte)Property._squares);
            AllowNames.Add((byte)Property._turn);
            AllowNames.Add((byte)Property.isCustom);
        }

        public ChineseCheckers() : base()
        {
            this._squares = new LP<byte>(this, (byte)Property._squares);
            this._turn = new VP<byte>(this, (byte)Property._turn, 1);   
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // board
                if (ret)
                {
                    if (this._squares.vs.Count == 0)
                    {
                        Debug.LogError("_square count = 0");
                        ret = false;
                    }
                }
            }
            return ret;
        }

        #endregion

        #region Convert

        public static byte[] convertToBytes(ChineseCheckers chineseCheckers, bool needCheckCustom = true)
        {
            // custom
            /*if (nineMenMorris.isCustom.v && needCheckCustom) {
                string strFen = Core.unityPositionToFen (russianDraught, Core.CanCorrect);
                Debug.LogError ("russianDraught custom fen: " + strFen);
                RussianDraught newRussianDraught = Core.unityMakePositionByFen (strFen);
                return convertToBytes (newRussianDraught);
            }*/
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    /** std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;*/
                    for(int y=0; y < Common.Y_SIZE; y++)
                        for(int x=0; x < Common.X_SIZE; x++)
                        {
                            byte value = 0;
                            {
                                int index = y * Common.X_SIZE + x;
                                if(index>=0 && index < chineseCheckers._squares.vs.Count)
                                {
                                    value = chineseCheckers._squares.vs[index];
                                }
                                else
                                {
                                    Debug.LogError("index error");
                                }
                            }
                            writer.Write(value);
                        }
                    /** Pebble _turn;*/
                    writer.Write(chineseCheckers._turn.v);

                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            // Debug.LogError ("convert NineMenMorris: " + byteArray.Length);
            return byteArray;
        }

        public static int parse(ChineseCheckers chineseCheckers, byte[] byteArray, int start)
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
                            /** std::array<std::array<Pebble, X_SIZE>, Y_SIZE> _squares;*/
                            chineseCheckers._squares.clear();
                            int size = sizeof(byte);
                            for (int i = 0; i < Common.X_SIZE * Common.Y_SIZE; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    chineseCheckers._squares.add(byteArray[count]);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: _squares: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                    break;
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            /** Pebble _turn;*/
                            int size = sizeof(byte);
                            if (count + size <= byteArray.Length)
                            {
                                chineseCheckers._turn.v = byteArray[count];
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: _turn: " + count + "; " + byteArray.Length);
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
                Debug.LogError("parse chineseCheckers fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.ChineseCheckers;
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
            switch ((Common.Pebble)this._turn.v)
            {
                case Common.Pebble.P1:
                    return 0;
                case Common.Pebble.P2:
                    return 1;
                default:
                    Debug.LogError("unknown turn: " + this._turn.v);
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
                        case GameMove.Type.ChineseCheckersMove:
                            {
                                ChineseCheckersMove move = gameMove as ChineseCheckersMove;
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
            // TODO Can hoan thien
        }

        public override void processGameMove(GameMove gameMove)
        {
            switch (gameMove.getType())
            {
                case GameMove.Type.ChineseCheckersMove:
                    {
                        // get information
                        ChineseCheckersMove move = gameMove as ChineseCheckersMove;
                        ChineseCheckers newChineseCheckers = Core.unityDoMove(this, Core.CanCorrect, move);
                        if (newChineseCheckers != null)
                        {
                            DataUtils.copyData(this, newChineseCheckers, AllowNames);
                        }
                        else
                        {
                            Debug.LogError("newChineseCheckers null: " + this);
                        }
                    }
                    break;
                default:
                    Debug.LogError("unknown gameMove: " + gameMove + "; " + this);
                    this.processCustomGameMove(gameMove);
                    break;
            }
        }

        #endregion

        #region getAIMove

        public override int getStackSize()
        {
            return 0;
        }

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
                    // get AI
                    ChineseCheckersAI ai = (computerAI != null && computerAI is ChineseCheckersAI) ? (ChineseCheckersAI)computerAI : new ChineseCheckersAI();
                    // search
                    ChineseCheckersMove move = Core.unityLetComputerThink(this, true, (int)ai.type.v, ai.depth.v, ai.time.v, ai.node.v, ai.pickBestMove.v);
                    if (move != null)
                    {
                        ret = move;
                    }
                    else
                    {
                        Debug.LogError("move null: " + this);
                        List<ChineseCheckersMove> legalMoves = Core.unityGetLegalMoves(this, true);
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
            Debug.LogError("chineseCheckers get ai move: " + ret);
            return ret;
        }

        public GameMove getCustomMove()
        {
            return null;
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
                        if (turn.turn.v >= 2000)
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

        #endregion

    }
}
