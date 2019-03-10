using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using MineSweeper.NoneRule;

namespace MineSweeper
{
    public class MineSweeper : GameType
    {

        public const int MAX_DIMENSION_SIZE = 100;
        public const int MIN_DIMENSION_SIZE = 5;

        public VP<int> Y;

        public VP<int> X;

        public VP<int> K;

        public LP<MineSweeperSub> sub;

        #region bombs

        public sbyte getBomb(int square)
        {
            sbyte ret = (sbyte)-1;
            {
                // find sub
                MineSweeperSub sub = null;
                {
                    int subIndex = square / MineSweeperSub.MaxCount;
                    if (subIndex >= 0 && subIndex < this.sub.vs.Count)
                    {
                        sub = this.sub.vs[subIndex];
                    }
                    else
                    {
                        Debug.LogError("subIndex error");
                    }
                }
                // get
                if (sub != null)
                {
                    int bombIndex = square % MineSweeperSub.MaxCount;
                    if (bombIndex >= 0 && bombIndex < sub.bombs.vs.Count)
                    {
                        ret = sub.bombs.vs[bombIndex];
                    }
                    else
                    {
                        Debug.LogError("bombIndex error");
                    }
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

        public void setBomb(int square, sbyte bomb)
        {
            // find sub
            MineSweeperSub sub = null;
            {
                int subIndex = square / MineSweeperSub.MaxCount;
                if (subIndex >= 0 && subIndex < this.sub.vs.Count)
                {
                    sub = this.sub.vs[subIndex];
                }
                else
                {
                    Debug.LogError("subIndex error");
                }
            }
            // get
            if (sub != null)
            {
                int bombIndex = square % MineSweeperSub.MaxCount;
                if (bombIndex >= 0 && bombIndex < sub.bombs.vs.Count)
                {
                    sub.bombs.set(bombIndex, bomb);
                }
                else
                {
                    Debug.LogError("bombIndex error");
                }
            }
            else
            {
                Debug.LogError("sub null");
            }
        }

        #endregion

        public VP<bool> booom;

        #region board

        public sbyte getPiece(int square)
        {
            sbyte ret = (sbyte)-1;
            {
                // find sub
                MineSweeperSub sub = null;
                {
                    int subIndex = square / MineSweeperSub.MaxCount;
                    if (subIndex >= 0 && subIndex < this.sub.vs.Count)
                    {
                        sub = this.sub.vs[subIndex];
                    }
                    else
                    {
                        Debug.LogError("subIndex error");
                    }
                }
                // get
                if (sub != null)
                {
                    int pieceIndex = square % MineSweeperSub.MaxCount;
                    if (pieceIndex >= 0 && pieceIndex < sub.board.vs.Count)
                    {
                        ret = sub.board.vs[pieceIndex];
                    }
                    else
                    {
                        Debug.LogError("bombIndex error");
                    }
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

        public void setPiece(int square, sbyte piece)
        {
            // find sub
            MineSweeperSub sub = null;
            {
                int subIndex = square / MineSweeperSub.MaxCount;
                if (subIndex >= 0 && subIndex < this.sub.vs.Count)
                {
                    sub = this.sub.vs[subIndex];
                }
                else
                {
                    Debug.LogError("subIndex error");
                }
            }
            // get
            if (sub != null)
            {
                int pieceIndex = square % MineSweeperSub.MaxCount;
                if (pieceIndex >= 0 && pieceIndex < sub.board.vs.Count)
                {
                    sub.board.set(pieceIndex, piece);
                }
                else
                {
                    Debug.LogError("pieceIndex error");
                }
            }
            else
            {
                Debug.LogError("sub null");
            }
        }

        #endregion

        public VP<int> minesFound;

        public VP<bool> init;

        public LP<Neb> neb;

        public VP<bool> allowWatchBoomb;

        public VP<bool> isCustom;

        public LP<MineSweeperFlags> myFlags;

        #region Constructor

        public enum Property
        {
            Y,
            X,
            K,
            sub,
            booom,
            minesFound,
            init,
            neb,
            allowWatchBoomb,
            isCustom,
            myFlags
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static MineSweeper()
        {
            AllowNames.Add((byte)Property.Y);
            AllowNames.Add((byte)Property.X);
            AllowNames.Add((byte)Property.K);
            AllowNames.Add((byte)Property.sub);
            AllowNames.Add((byte)Property.booom);
            AllowNames.Add((byte)Property.minesFound);
            AllowNames.Add((byte)Property.init);
            AllowNames.Add((byte)Property.neb);
            AllowNames.Add((byte)Property.isCustom);
        }

        public MineSweeper() : base()
        {
            this.Y = new VP<int>(this, (byte)Property.Y, 10);
            this.X = new VP<int>(this, (byte)Property.X, 10);
            this.K = new VP<int>(this, (byte)Property.K, 10);
            this.sub = new LP<MineSweeperSub>(this, (byte)Property.sub);
            this.booom = new VP<bool>(this, (byte)Property.booom, false);
            this.minesFound = new VP<int>(this, (byte)Property.minesFound, 0);
            this.init = new VP<bool>(this, (byte)Property.init, false);
            this.neb = new LP<Neb>(this, (byte)Property.neb);
            this.allowWatchBoomb = new VP<bool>(this, (byte)Property.allowWatchBoomb, true);
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
            this.myFlags = new LP<MineSweeperFlags>(this, (byte)Property.myFlags);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // board, neb, flags
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is MineSweeperIdentity)
                        {
                            MineSweeperIdentity mineSweeperIdentity = dataIdentity as MineSweeperIdentity;
                            if (mineSweeperIdentity.neb != this.neb.vs.Count
                                || mineSweeperIdentity.sub != this.sub.vs.Count
                                || mineSweeperIdentity.myFlags != this.myFlags.vs.Count)
                            {
                                Debug.LogError("neb count error");
                                ret = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("why not nebIdentity");
                        }
                    }
                }
                // each neb
                if (ret)
                {
                    for (int i = 0; i < this.neb.vs.Count; i++)
                    {
                        Neb neb = this.neb.vs[i];
                        if (!neb.isLoadFull())
                        {
                            ret = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        #region Convert

        public static byte[] convertToBytes(MineSweeper mineSweeper, bool needCheckCustom = true)
        {
            // custom
            /*if (chess.isCustom.v && needCheckCustom) {
				string strFen = Core.unityPositionToFen (chess, Core.CanCorrect);
				Debug.LogError ("chess custom fen: " + strFen);
				Chess newChess = Core.unityMakePositionByFen (strFen, chess.chess960.v);
				return convertToBytes (newChess);
			}*/
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // get information
                    List<sbyte> bombs = new List<sbyte>();
                    List<sbyte> flags = new List<sbyte>();
                    List<sbyte> board = new List<sbyte>();
                    {
                        foreach (MineSweeperSub sub in mineSweeper.sub.vs)
                        {
                            bombs.AddRange(sub.bombs.vs);
                            flags.AddRange(sub.flags.vs);
                            board.AddRange(sub.board.vs);
                        }
                    }
                    // write value
                    {
                        // public VP<int> N
                        writer.Write(mineSweeper.Y.v);
                        // public VP<int> M
                        writer.Write(mineSweeper.X.v);
                        // public VP<int> K
                        writer.Write(mineSweeper.K.v);
                        // public LP<sbyte> bombs
                        for (int y = 0; y < mineSweeper.Y.v; y++)
                            for (int x = 0; x < mineSweeper.X.v; x++)
                            {
                                sbyte value = 0;
                                {
                                    int index = y * mineSweeper.X.v + x;
                                    if (index >= 0 && index < bombs.Count)
                                    {
                                        value = bombs[index];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error: " + index + "; " + mineSweeper);
                                    }
                                }
                                writer.Write(value);
                            }
                        // public VP<bool> booom
                        writer.Write(mineSweeper.booom.v);
                        // public LP<sbyte> flags
                        for (int y = 0; y < mineSweeper.Y.v; y++)
                            for (int x = 0; x < mineSweeper.X.v; x++)
                            {
                                sbyte value = 0;
                                {
                                    int index = y * mineSweeper.X.v + x;
                                    if (index >= 0 && index < flags.Count)
                                    {
                                        value = flags[index];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error: " + index + "; " + mineSweeper);
                                    }
                                }
                                writer.Write(value);
                            }
                        // public LP<sbyte> board
                        for (int y = 0; y < mineSweeper.Y.v; y++)
                            for (int x = 0; x < mineSweeper.X.v; x++)
                            {
                                sbyte value = 0;
                                {
                                    int index = y * mineSweeper.X.v + x;
                                    if (index >= 0 && index < board.Count)
                                    {
                                        value = board[index];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error: " + index + "; " + mineSweeper);
                                    }
                                }
                                writer.Write(value);
                            }
                        // public VP<int> minesFound
                        writer.Write(mineSweeper.minesFound.v);
                        // public VP<bool> init
                        writer.Write(mineSweeper.init.v);
                        // public LP<Neb> neb
                        {
                            writer.Write(mineSweeper.neb.vs.Count);
                            for (int i = 0; i < mineSweeper.neb.vs.Count; i++)
                            {
                                Neb neb = mineSweeper.neb.vs[i];
                                writer.Write(Neb.convertToBytes(neb));
                            }
                        }
                    }
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(MineSweeper mineSweeper, byte[] byteArray, int start)
        {
            int count = start;
            int index = 0;
            bool isParseCorrect = true;
            // init sub
            {
                mineSweeper.sub.clear();
            }
            while (count < byteArray.Length)
            {
                bool alreadyPassAll = false;
                switch (index)
                {
                    case 0:
                        {
                            // public VP<int> N
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                mineSweeper.Y.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: N: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 1:
                        {
                            // public VP<int> M
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                mineSweeper.X.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: M: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 2:
                        {
                            // public VP<int> K
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                mineSweeper.K.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: K: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        {
                            // public LP<sbyte> bombs
                            if (mineSweeper.Y.v >= MIN_DIMENSION_SIZE && mineSweeper.Y.v <= MAX_DIMENSION_SIZE
                                && mineSweeper.X.v >= MIN_DIMENSION_SIZE && mineSweeper.X.v <= MAX_DIMENSION_SIZE)
                            {
                                int size = sizeof(sbyte);
                                for (int i = 0; i < mineSweeper.Y.v * mineSweeper.X.v; i++)
                                {
                                    if (count + size <= byteArray.Length)
                                    {
                                        // find sub
                                        MineSweeperSub mineSweeperSub = null;
                                        {
                                            // find old
                                            {
                                                int mineSweeperSubIndex = i / MineSweeperSub.MaxCount;
                                                if (mineSweeperSubIndex >= 0 && mineSweeperSubIndex < mineSweeper.sub.vs.Count)
                                                {
                                                    mineSweeperSub = mineSweeper.sub.vs[mineSweeperSubIndex];
                                                }
                                            }
                                            // make new
                                            if (mineSweeperSub == null)
                                            {
                                                mineSweeperSub = new MineSweeperSub();
                                                {
                                                    mineSweeperSub.uid = mineSweeper.sub.makeId();
                                                }
                                                mineSweeper.sub.add(mineSweeperSub);
                                            }
                                        }
                                        // add
                                        mineSweeperSub.bombs.add((sbyte)byteArray[count]);
                                        count += size;
                                    }
                                    else
                                    {
                                        Debug.LogError("array not enough length: bombs: " + count + "; " + byteArray.Length);
                                        isParseCorrect = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("dimension error: " + mineSweeper.Y.v + "; " + mineSweeper.X.v);
                            }
                        }
                        break;
                    case 4:
                        {
                            // public VP<bool> booom
                            int size = sizeof(bool);
                            if (count + size <= byteArray.Length)
                            {
                                mineSweeper.booom.v = BitConverter.ToBoolean(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: boom: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        {
                            // public LP<sbyte> flags
                            if (mineSweeper.Y.v >= MIN_DIMENSION_SIZE && mineSweeper.Y.v <= MAX_DIMENSION_SIZE
                                && mineSweeper.X.v >= MIN_DIMENSION_SIZE && mineSweeper.X.v <= MAX_DIMENSION_SIZE)
                            {
                                int size = sizeof(sbyte);
                                for (int i = 0; i < mineSweeper.Y.v * mineSweeper.X.v; i++)
                                {
                                    if (count + size <= byteArray.Length)
                                    {
                                        // find sub
                                        MineSweeperSub mineSweeperSub = null;
                                        {
                                            // find old
                                            {
                                                int mineSweeperSubIndex = i / MineSweeperSub.MaxCount;
                                                if (mineSweeperSubIndex >= 0 && mineSweeperSubIndex < mineSweeper.sub.vs.Count)
                                                {
                                                    mineSweeperSub = mineSweeper.sub.vs[mineSweeperSubIndex];
                                                }
                                            }
                                            // make new
                                            if (mineSweeperSub == null)
                                            {
                                                mineSweeperSub = new MineSweeperSub();
                                                {
                                                    mineSweeperSub.uid = mineSweeper.sub.makeId();
                                                }
                                                mineSweeper.sub.add(mineSweeperSub);
                                            }
                                        }
                                        // add
                                        mineSweeperSub.flags.add((sbyte)byteArray[count]);
                                        count += size;
                                    }
                                    else
                                    {
                                        Debug.LogError("array not enough length: flags: " + count + "; " + byteArray.Length);
                                        isParseCorrect = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("dimension error: " + mineSweeper.Y.v + "; " + mineSweeper.X.v);
                            }
                        }
                        break;
                    case 6:
                        {
                            // public LP<sbyte> board
                            if (mineSweeper.Y.v >= MIN_DIMENSION_SIZE && mineSweeper.Y.v <= MAX_DIMENSION_SIZE
                                && mineSweeper.X.v >= MIN_DIMENSION_SIZE && mineSweeper.X.v <= MAX_DIMENSION_SIZE)
                            {
                                int size = sizeof(sbyte);
                                for (int i = 0; i < mineSweeper.Y.v * mineSweeper.X.v; i++)
                                {
                                    if (count + size <= byteArray.Length)
                                    {
                                        // find sub
                                        MineSweeperSub mineSweeperSub = null;
                                        {
                                            // find old
                                            {
                                                int mineSweeperSubIndex = i / MineSweeperSub.MaxCount;
                                                if (mineSweeperSubIndex >= 0 && mineSweeperSubIndex < mineSweeper.sub.vs.Count)
                                                {
                                                    mineSweeperSub = mineSweeper.sub.vs[mineSweeperSubIndex];
                                                }
                                            }
                                            // make new
                                            if (mineSweeperSub == null)
                                            {
                                                mineSweeperSub = new MineSweeperSub();
                                                {
                                                    mineSweeperSub.uid = mineSweeper.sub.makeId();
                                                }
                                                mineSweeper.sub.add(mineSweeperSub);
                                            }
                                        }
                                        // add
                                        mineSweeperSub.board.add((sbyte)byteArray[count]);
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
                            else
                            {
                                Debug.LogError("dimension error: " + mineSweeper.Y.v + "; " + mineSweeper.X.v);
                            }
                        }
                        break;
                    case 7:
                        {
                            // public VP<int> minesFound
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                mineSweeper.minesFound.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: minesFound: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 8:
                        {
                            // public VP<bool> init
                            int size = sizeof(bool);
                            if (count + size <= byteArray.Length)
                            {
                                mineSweeper.init.v = BitConverter.ToBoolean(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: init: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 9:
                        {
                            // public LP<Neb> neb
                            mineSweeper.neb.clear();
                            int nebCount = 0;
                            {
                                int size = sizeof(int);
                                if (count + size <= byteArray.Length)
                                {
                                    nebCount = BitConverter.ToInt32(byteArray, count);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("array not enough length: nebCount: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                }
                            }
                            // parse
                            {
                                // get list
                                List<Neb> nebs = new List<Neb>();
                                for (int i = 0; i < nebCount; i++)
                                {
                                    Neb neb = new Neb();
                                    int nebByteLength = Neb.parse(neb, byteArray, count);
                                    if (nebByteLength > 0)
                                    {
                                        nebs.Add(neb);
                                        count += nebByteLength;
                                    }
                                    else
                                    {
                                        Debug.LogError("cannot parse");
                                        break;
                                    }
                                }
                                // add
                                for (int i = 0; i < nebs.Count; i++)
                                {
                                    Neb neb = nebs[i];
                                    {
                                        neb.uid = mineSweeper.neb.makeId();
                                    }
                                    mineSweeper.neb.add(neb);
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

        #region implement callBacks

        public override Type getType()
        {
            return Type.MineSweeper;
        }

        public override int getTeamCount()
        {
            return 1;
        }

        public override int getPerspectiveCount()
        {
            return 1;
        }

        public override int getPlayerIndex()
        {
            return 0;
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
                        case GameMove.Type.MineSweeperMove:
                            {
                                MineSweeperMove mineSweeperMove = gameMove as MineSweeperMove;
                                return Core.unityIsLegalMove(this, Core.CanCorrect, mineSweeperMove.move.v);
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
                        case GameMove.Type.MineSweeperMove:
                            return true;
                        case GameMove.Type.MineSweeperCustomSet:
                            return true;
                        case GameMove.Type.EndTurn:
                            return true;
                        case GameMove.Type.Clear:
                            return true;
                        case GameMove.Type.MineSweeperCustomMove:
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
                // make tempMineSweeper
                MineSweeper tempMineSweeper = DataUtils.cloneData(this) as MineSweeper;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.MineSweeperCustomSet:
                            {
                                MineSweeperCustomSet mineSweeperCustomSet = gameMove as MineSweeperCustomSet;
                                // set piece
                                {
                                    tempMineSweeper.setPiece(mineSweeperCustomSet.square.v, mineSweeperCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                foreach (MineSweeperSub sub in tempMineSweeper.sub.vs)
                                {
                                    for (int i = 0; i < sub.board.vs.Count; i++)
                                    {
                                        sub.board.vs[i] = -1;
                                    }
                                }
                            }
                            break;
                        case GameMove.Type.MineSweeperCustomMove:
                            {
                                MineSweeperCustomMove mineSweeperCustomMove = gameMove as MineSweeperCustomMove;
                                // update
                                {
                                    tempMineSweeper.setPiece(mineSweeperCustomMove.dest.v, tempMineSweeper.getPiece(mineSweeperCustomMove.from.v));
                                    tempMineSweeper.setPiece(mineSweeperCustomMove.from.v, -1);
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
                    tempMineSweeper.init.v = true;
                    tempMineSweeper.isCustom.v = true;
                    DataUtils.copyData(this, tempMineSweeper, AllowNames);
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
                case GameMove.Type.MineSweeperMove:
                    {
                        MineSweeperMove mineSweeperMove = gameMove as MineSweeperMove;
                        switch (mineSweeperMove.type.v)
                        {
                            case MineSweeperMove.MoveType.Normal:
                                {
                                    // make request to native
                                    MineSweeper newMineSweeper = Core.unityDoMove(this, Core.CanCorrect, mineSweeperMove.move.v);
                                    // Copy to current chess
                                    DataUtils.copyData(this, newMineSweeper, AllowNames);
                                }
                                break;
                            case MineSweeperMove.MoveType.Flag:
                                {
                                    ushort move = (ushort)mineSweeperMove.move.v;
                                    // find
                                    bool alreadyContain = false;
                                    {
                                        foreach (MineSweeperFlags mineSweeperFlags in this.myFlags.vs)
                                        {
                                            if (mineSweeperFlags.myFlags.vs.Contains(move))
                                            {
                                                Debug.LogError("already contain: " + move + ", " + mineSweeperFlags);
                                                mineSweeperFlags.myFlags.remove(move);
                                                alreadyContain = true;
                                                break;
                                            }
                                        }
                                    }
                                    // process
                                    if (!alreadyContain)
                                    {
                                        // find myFlags
                                        MineSweeperFlags myFlags = null;
                                        {
                                            foreach(MineSweeperFlags mineSweeperFlags in this.myFlags.vs)
                                            {
                                                if (mineSweeperFlags.myFlags.vs.Count < MineSweeperFlags.MaxCount)
                                                {
                                                    myFlags = mineSweeperFlags;
                                                    break;
                                                }
                                            }
                                        }
                                        // make new
                                        if (myFlags == null)
                                        {
                                            myFlags = new MineSweeperFlags();
                                            {
                                                myFlags.uid = this.myFlags.makeId();
                                            }
                                            this.myFlags.add(myFlags);
                                        }
                                        // add
                                        myFlags.myFlags.add(move);
                                        // remove not contain anything
                                        {
                                            for (int i = this.myFlags.vs.Count - 1; i >= 0; i--)
                                            {
                                                MineSweeperFlags check = this.myFlags.vs[i];
                                                if (check.myFlags.vs.Count == 0)
                                                {
                                                    Debug.LogError("Don't have any flags, so remove: " + check);
                                                    this.myFlags.removeAt(i);
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + mineSweeperMove.type.v);
                                break;
                        }
                    }
                    break;
                case GameMove.Type.None:
                    break;
                case GameMove.Type.EndTurn:
                    break;
                case GameMove.Type.MineSweeperCustomSet:
                case GameMove.Type.Clear:
                case GameMove.Type.MineSweeperCustomMove:
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
                        // TODO Test useNormalMove = false;
                        /*GameData gameData = this.findDataInParent<GameData>();
						if (gameData != null) {
							Turn turn = gameData.turn.v;
							if (turn != null) {
								if (turn.turn.v % 4 == 1 || turn.turn.v % 4 == 3) {
									useNormalMove = false;
								}
							} else {
								Debug.LogError ("turn null: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}*/
                        useNormalMove = true;
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
                    MineSweeperAI mineSweeperAI = (ai != null && ai is MineSweeperAI) ? (MineSweeperAI)ai : new MineSweeperAI();
                    // search
                    int move = Core.unityLetComputerThink(this, Core.CanCorrect, (int)mineSweeperAI.firstMoveType.v);
                    // make move
                    {
                        MineSweeperMove mineSweeperMove = new MineSweeperMove();
                        {
                            mineSweeperMove.move.v = move;
                        }
                        ret = mineSweeperMove;
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
                List<sbyte> board = new List<sbyte>();
                {
                    foreach (MineSweeperSub sub in this.sub.vs)
                    {
                        board.AddRange(sub.board.vs);
                    }
                }
                // get custom set
                {
                    for (int square = 0; square < board.Count; square++)
                    {
                        MineSweeperCustomSet mineSweeperCustomSet = new MineSweeperCustomSet();
                        {
                            mineSweeperCustomSet.square.v = square;
                            mineSweeperCustomSet.piece.v = (board[square] != -1) ? (sbyte)-1 : (sbyte)1;
                        }
                        moves.Add(mineSweeperCustomSet);
                    }
                }
                // get custom move
                {
                    for (int square = 0; square < board.Count; square++)
                    {
                        if (board[square] != -1)
                        {
                            for (int destSquare = 0; destSquare < board.Count; destSquare++)
                            {
                                if (destSquare != square)
                                {
                                    MineSweeperCustomMove mineSweeperCustomMove = new MineSweeperCustomMove();
                                    {
                                        mineSweeperCustomMove.from.v = square;
                                        mineSweeperCustomMove.dest.v = destSquare;
                                    }
                                    moves.Add(mineSweeperCustomMove);
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
            // if (GameData.IsUseRule (this)) 
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
                        // you win
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 1));// white
                        }
                        break;
                    case 2:
                        // you lose
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));// white
                        }
                        break;
                    default:
                        Debug.LogError("unknown result: " + this);
                        break;
                }
            }
            // return
            return result;
        }

        #endregion

    }
}