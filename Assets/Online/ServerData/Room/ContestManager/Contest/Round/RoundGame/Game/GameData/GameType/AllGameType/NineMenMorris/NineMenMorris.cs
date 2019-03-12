using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using NineMenMorris.NoneRule;

namespace NineMenMorris
{
    public class NineMenMorris : GameType
    {

        #region board

        /** shared_ptr<Board> board*/
        public LP<int> board;

        public int pieceOn(int square)
        {
            int ret = (int)Common.SpotStatus.SS_Empty;
            {
                if (square >= 0 && square < this.board.vs.Count)
                {
                    ret = this.board.vs[square];
                }
                else
                {
                    Debug.LogError("square error");
                }
            }
            return ret;
        }

        public void setPieceOn(int square, Common.SpotStatus piece)
        {
            if (square >= 0 && square < this.board.vs.Count)
            {
                this.board.set(square, (int)piece);
            }
            else
            {
                Debug.LogError("unknown square: " + square);
            }
        }

        #endregion

        /** int32_t moved = 0*/
        public VP<int> moved;

        /** int32_t moved_to = 0*/
        public VP<int> moved_to;

        /** NMMAction action = Place*/
        public VP<Common.NMMAction> action;

        /** bool mill = false*/
        public VP<bool> mill;

        /** bool terminal = false*/
        public VP<bool> terminal;

        /** int32_t removed = 0*/
        public VP<int> removed;

        /** float utility = 0*/
        public VP<float> utility;

        /** int32_t turn = 0*/
        public VP<int> turn;

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            board,
            moved,
            moved_to,
            action,
            mill,
            terminal,
            removed,
            utility,
            turn,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static NineMenMorris()
        {
            AllowNames.Add((byte)Property.board);
            AllowNames.Add((byte)Property.moved);
            AllowNames.Add((byte)Property.moved_to);
            AllowNames.Add((byte)Property.action);
            AllowNames.Add((byte)Property.mill);
            AllowNames.Add((byte)Property.terminal);
            AllowNames.Add((byte)Property.removed);
            AllowNames.Add((byte)Property.utility);
            AllowNames.Add((byte)Property.turn);
            AllowNames.Add((byte)Property.isCustom);
        }

        public NineMenMorris() : base()
        {
            this.board = new LP<int>(this, (byte)Property.board);
            this.moved = new VP<int>(this, (byte)Property.moved, -1);
            this.moved_to = new VP<int>(this, (byte)Property.moved_to, -1);
            this.action = new VP<Common.NMMAction>(this, (byte)Property.action, Common.NMMAction.Place);
            this.mill = new VP<bool>(this, (byte)Property.mill, false);
            this.terminal = new VP<bool>(this, (byte)Property.terminal, false);
            this.removed = new VP<int>(this, (byte)Property.removed, -1);
            this.utility = new VP<float>(this, (byte)Property.utility, 0);
            this.turn = new VP<int>(this, (byte)Property.turn, 0);
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
                        Debug.LogError("board count = 0");
                        ret = false;
                    }
                }
            }
            return ret;
        }

        #endregion

        #region Convert

        public static byte[] convertToBytes(NineMenMorris nineMenMorris, bool needCheckCustom = true)
        {
            // custom
            if (nineMenMorris.isCustom.v && needCheckCustom)
            {
                bool haveAnyPiece = false;
                {
                    for (int i = 0; i < nineMenMorris.board.vs.Count; i++)
                    {
                        if (nineMenMorris.board.vs[i] != (int)Common.SpotStatus.SS_Empty)
                        {
                            haveAnyPiece = true;
                            break;
                        }
                    }
                }
                if (haveAnyPiece)
                {
                    return convertToBytes(nineMenMorris, false);
                }
                else
                {
                    return convertToBytes(Core.unityMakeDefaultPosition(), false);
                }
            }
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    /** shared_ptr<Board> board*/
                    for (int i = 0; i < Common.BOARD_SPOT; i++)
                    {
                        // get value
                        int value = 0;
                        {
                            if (i < nineMenMorris.board.vs.Count)
                            {
                                value = nineMenMorris.board.vs[i];
                            }
                            else
                            {
                                Debug.LogError("index error: " + nineMenMorris);
                            }
                        }
                        writer.Write(value);
                    }
                    /** int32_t moved = 0*/
                    writer.Write(nineMenMorris.moved.v);
                    /** int32_t moved_to = 0*/
                    writer.Write(nineMenMorris.moved_to.v);
                    /** NMMAction action = Place*/
                    writer.Write((int)nineMenMorris.action.v);
                    /** bool mill = false*/
                    writer.Write(nineMenMorris.mill.v);
                    /** bool terminal = false*/
                    writer.Write(nineMenMorris.terminal.v);
                    /** int32_t removed = 0*/
                    writer.Write(nineMenMorris.removed.v);
                    /** float utility = 0*/
                    writer.Write(nineMenMorris.utility.v);
                    /** int32_t turn = 0*/
                    writer.Write(nineMenMorris.turn.v);

                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            // Debug.LogError ("convert NineMenMorris: " + byteArray.Length);
            return byteArray;
        }

        public static int parse(NineMenMorris nineMenMorris, byte[] byteArray, int start)
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
                            /** shared_ptr<Board> board*/
                            nineMenMorris.board.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < Common.BOARD_SPOT; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    nineMenMorris.board.add(BitConverter.ToInt32(byteArray, count));
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
                            /** int32_t moved = 0*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.moved.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: moved: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 2:
                        {
                            /** int32_t moved_to = 0*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.moved_to.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: moved_to: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        {
                            /** NMMAction action = Place*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.action.v = (Common.NMMAction)BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: action: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 4:
                        {
                            /** bool mill = false*/
                            int size = sizeof(bool);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.mill.v = BitConverter.ToBoolean(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: mill: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        {
                            /** bool terminal = false*/
                            int size = sizeof(bool);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.terminal.v = BitConverter.ToBoolean(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: terminal: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 6:
                        {
                            /** int32_t removed = 0*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.removed.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: removed: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 7:
                        {
                            /** float utility = 0*/
                            int size = sizeof(float);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.utility.v = BitConverter.ToSingle(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: utility: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 8:
                        {
                            /** int32_t turn = 0*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                nineMenMorris.turn.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: turn: " + count + "; " + byteArray.Length);
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
                Debug.LogError("parse nineMenMorris fail: " + count + "; " + byteArray.Length + "; " + start);
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
            return Type.NineMenMorris;
        }

        public override int getTeamCount()
        {
            return 2;
        }

        public override int getPerspectiveCount()
        {
            return 1;
        }

        public override int getPlayerIndex()
        {
            if (this.turn.v % 2 == 0)
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
                        case GameMove.Type.NineMenMorrisMove:
                            {
                                NineMenMorrisMove move = gameMove as NineMenMorrisMove;
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
            if (gameMove != null)
            {
                // make tempNineMenMorris
                NineMenMorris tempNineMenMorris = DataUtils.cloneData(this) as NineMenMorris;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.NineMenMorrisCustomSet:
                            {
                                NineMenMorrisCustomSet nineMenMorrisCustomSet = gameMove as NineMenMorrisCustomSet;
                                // set piece
                                {
                                    int square = Common.ConvertXYToPosition(nineMenMorrisCustomSet.x.v, nineMenMorrisCustomSet.y.v);
                                    tempNineMenMorris.setPieceOn(square, nineMenMorrisCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                for (int i = 0; i < tempNineMenMorris.board.vs.Count; i++)
                                {
                                    tempNineMenMorris.board.vs[i] = (int)Common.SpotStatus.SS_Empty;
                                }
                            }
                            break;
                        case GameMove.Type.NineMenMorrisCustomMove:
                            {
                                NineMenMorrisCustomMove nineMenMorrisCustomMove = gameMove as NineMenMorrisCustomMove;
                                // update
                                {
                                    int fromSquare = Common.ConvertXYToPosition(nineMenMorrisCustomMove.fromX.v, nineMenMorrisCustomMove.fromY.v);
                                    int destSquare = Common.ConvertXYToPosition(nineMenMorrisCustomMove.destX.v, nineMenMorrisCustomMove.destY.v);
                                    tempNineMenMorris.setPieceOn(destSquare, (Common.SpotStatus)tempNineMenMorris.pieceOn(fromSquare));
                                    tempNineMenMorris.setPieceOn(fromSquare, Common.SpotStatus.SS_Empty);
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
                    /*tempNineMenMorris.moved.v = -1;
                    tempNineMenMorris.moved_to.v = -1;
                    tempNineMenMorris.action.v = Common.NMMAction.Place;
                    tempNineMenMorris.mill.v = false;
                    tempNineMenMorris.terminal.v = false;
                    tempNineMenMorris.removed.v = -1;
                    tempNineMenMorris.utility.v = 0;
                    tempNineMenMorris.turn.v = 0;*/
                    tempNineMenMorris.isCustom.v = true;
                    DataUtils.copyData(this, tempNineMenMorris, AllowNames);
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
                case GameMove.Type.NineMenMorrisMove:
                    {
                        // get information
                        NineMenMorrisMove move = gameMove as NineMenMorrisMove;
                        NineMenMorris newNineMenMorris = Core.unityDoMove(this, Core.CanCorrect, move);
                        if (newNineMenMorris != null)
                        {
                            DataUtils.copyData(this, newNineMenMorris, AllowNames);
                        }
                        else
                        {
                            Debug.LogError("newNineMenMorris null: " + this);
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
                        if (gameData != null)
                        {
                            Turn turn = gameData.turn.v;
                            if (turn != null)
                            {
                                if (turn.turn.v % 4 == 0 || turn.turn.v % 4 == 2)
                                {
                                    useNormalMove = false;
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
                    NineMenMorrisAI ai = (computerAI != null && computerAI is NineMenMorrisAI) ? (NineMenMorrisAI)computerAI : new NineMenMorrisAI();
                    // search
                    NineMenMorrisMove move = Core.unityLetComputerThink(this, true, ai.MaxNormal.v, ai.MaxPositioning.v, ai.MaxBlackAndWhite3.v, ai.MaxBlackOrWhite3.v, ai.pickBestMove.v);
                    if (move != null)
                    {
                        ret = move;
                    }
                    else
                    {
                        Debug.LogError("move null: " + this);
                        List<NineMenMorrisMove> legalMoves = Core.unityGetLegalMoves(this, true);
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
            Debug.LogError("nineMenMorris get ai move: " + ret);
            return ret;
        }

        public GameMove getCustomMove()
        {
            // find moves
            List<GameMove> moves = new List<GameMove>();
            {
                // get custom set
                {
                    for (int i = 0; i < Common.BOARD_SPOT; i++)
                    {
                        Common.SpotStatus alreadySelectPiece = (Common.SpotStatus)this.pieceOn(i);
                        foreach (Common.SpotStatus piece in System.Enum.GetValues(typeof(Common.SpotStatus)))
                        {
                            if (piece != alreadySelectPiece)
                            {
                                NineMenMorrisCustomSet nineMenMorrisCustomSet = new NineMenMorrisCustomSet();
                                {
                                    int x = 0;
                                    int y = 0;
                                    Common.parsePositionToXY(i, out x, out y);
                                    nineMenMorrisCustomSet.x.v = x;
                                    nineMenMorrisCustomSet.y.v = y;
                                    nineMenMorrisCustomSet.piece.v = piece;
                                }
                                moves.Add(nineMenMorrisCustomSet);
                            }
                        }
                    }
                }
                // get custom move
                {
                    for (int i = 0; i < Common.BOARD_SPOT; i++)
                    {
                        Common.SpotStatus piece = (Common.SpotStatus)this.pieceOn(i);
                        if (piece != Common.SpotStatus.SS_Empty)
                        {
                            for (int destI = 0; destI < Common.BOARD_SPOT; destI++)
                            {
                                if (destI != i)
                                {
                                    NineMenMorrisCustomMove nineMenMorrisCustomMove = new NineMenMorrisCustomMove();
                                    {
                                        // from
                                        {
                                            int x = 0;
                                            int y = 0;
                                            Common.parsePositionToXY(i, out x, out y);
                                            nineMenMorrisCustomMove.fromX.v = x;
                                            nineMenMorrisCustomMove.fromY.v = y;
                                        }
                                        // dest
                                        {
                                            int destX = 0;
                                            int destY = 0;
                                            Common.parsePositionToXY(destI, out destX, out destY);
                                            nineMenMorrisCustomMove.destX.v = destX;
                                            nineMenMorrisCustomMove.destY.v = destY;
                                        }
                                    }
                                    moves.Add(nineMenMorrisCustomMove);
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
                        if (turn.turn.v >= 10000)
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