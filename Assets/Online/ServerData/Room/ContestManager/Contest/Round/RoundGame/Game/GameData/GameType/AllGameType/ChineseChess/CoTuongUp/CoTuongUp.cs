using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Rule;
using CoTuongUp.NoneRule;

namespace CoTuongUp
{
    public class CoTuongUp : GameType
    {

        ///////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// Property ////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        public VP<bool> allowViewCapture;

        public VP<bool> allowWatcherViewHidden;

        public VP<bool> allowOnlyFlip;

        public VP<uint> plyDraw;

        public VP<int> turn;

        #region Side

        public VP<byte> side;

        public void changeSide()
        {
            switch (this.side.v)
            {
                case Common.Side.Red:
                    this.side.v = Common.Side.Black;
                    break;
                case Common.Side.Black:
                    this.side.v = Common.Side.Red;
                    break;
                default:
                    Debug.LogError("unknown side: " + this.side.v);
                    this.side.v = Common.Side.Red;
                    break;
            }
        }

        #endregion

        public LP<Node> nodes;

        public byte getPieceByCoord(byte coord)
        {
            if (this.nodes.vs.Count > 0)
            {
                Node currentNode = this.nodes.vs[this.nodes.vs.Count - 1];
                return currentNode.getPieceByCoord(coord);
            }
            else
            {
                Debug.LogError("why don't have any node: " + this);
                return 0;
            }
        }

        public void setPieceByCoord(byte coord, byte piece)
        {
            if (this.nodes.vs.Count > 0)
            {
                Node currentNode = this.nodes.vs[this.nodes.vs.Count - 1];
                currentNode.setPieceByCoord(coord, piece);
            }
            else
            {
                Debug.LogError("why don't have any node: " + this);
            }
        }

        public VP<bool> isCustom;

        ///////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// Constructor ////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        public enum Property
        {
            allowViewCapture,
            allowWatcherViewHidden,
            allowOnlyFlip,
            turn,
            side,
            nodes,
            plyDraw,
            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static CoTuongUp()
        {
            AllowNames.Add((byte)Property.allowViewCapture);
            AllowNames.Add((byte)Property.allowWatcherViewHidden);
            AllowNames.Add((byte)Property.allowOnlyFlip);
            AllowNames.Add((byte)Property.turn);
            AllowNames.Add((byte)Property.side);
            AllowNames.Add((byte)Property.nodes);
            AllowNames.Add((byte)Property.plyDraw);
            AllowNames.Add((byte)Property.isCustom);
        }

        public CoTuongUp() : base()
        {
            this.allowViewCapture = new VP<bool>(this, (byte)Property.allowViewCapture, true);
            this.allowWatcherViewHidden = new VP<bool>(this, (byte)Property.allowWatcherViewHidden, true);
            this.allowOnlyFlip = new VP<bool>(this, (byte)Property.allowOnlyFlip, true);
            this.turn = new VP<int>(this, (byte)Property.turn, 0);
            this.side = new VP<byte>(this, (byte)Property.side, Common.Side.Red);
            this.nodes = new LP<Node>(this, (byte)Property.nodes);
            this.plyDraw = new VP<uint>(this, (byte)Property.plyDraw, 100);
            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // nodes
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is CoTuongUpIdentity)
                        {
                            CoTuongUpIdentity coTuongUpIdentity = dataIdentity as CoTuongUpIdentity;
                            if (coTuongUpIdentity.nodes != this.nodes.vs.Count)
                            {
                                ret = false;
                            }
                        }
                    }
                }
            }
            return ret;
        }

        ///////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// action ////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        public void doMove(Rules.Move move, bool keepOldNode)
        {
            this.turn.v = this.turn.v + 1;
            this.side.v = Common.changeSide(this.side.v);
            // Make new node
            {
                if (this.nodes.vs.Count > 0)
                {
                    Node currentNode = this.nodes.vs[this.nodes.vs.Count - 1];
                    // Check increase ply
                    bool isPly = true;
                    {
                        byte movePiece = currentNode.getPieceByCoord(Common.makeCoord(move.from.x, move.from.y));
                        if (Common.Visibility.isHide(movePiece))
                        {
                            isPly = false;
                        }
                        else
                        {
                            if (movePiece == Common.P || movePiece == Common.p)
                            {
                                if (move.from.y != move.dest.y)
                                {
                                    isPly = false;
                                }
                            }
                        }
                    }
                    // New node
                    Node newNode = new Node();
                    {
                        newNode.uid = this.nodes.makeId();
                        // ply 
                        newNode.ply.v = isPly ? currentNode.ply.v + 1 : 0;
                        // piece
                        {
                            newNode.pieces.add(currentNode.pieces.vs);
                            // set dest
                            {
                                byte dest = Common.makeCoord(move.dest.x, move.dest.y);
                                byte piece = currentNode.getPieceByCoord(Common.makeCoord(move.from.x, move.from.y));
                                newNode.setPieceByCoord(dest, Common.Visibility.flip(piece));
                            }
                            // set from
                            if (move.from.x != move.dest.x || move.from.y != move.dest.y)
                            {
                                byte from = Common.makeCoord(move.from.x, move.from.y);
                                newNode.setPieceByCoord(from, 0);
                            }
                            else
                            {
                                // Debug.Log ("flip move");
                            }
                        }
                        // captures
                        {
                            newNode.captures.vs.AddRange(currentNode.captures.vs);
                            if (move.from.x != move.dest.x || move.from.y != move.dest.y)
                            {
                                byte dest = Common.makeCoord(move.dest.x, move.dest.y);
                                byte capture = currentNode.getPieceByCoord(dest);
                                if (capture != 0)
                                {
                                    // Debug.LogError ("add capture: " + capture + "; " + this);
                                    newNode.captures.add(capture);
                                }
                            }
                            else
                            {
                                // Debug.Log ("flip move");
                            }
                        }
                    }
                    // remove old nodes and add new node
                    {
                        if (!isPly && !keepOldNode)
                        {
                            this.nodes.clear();
                        }
                        this.nodes.add(newNode);
                    }
                }
                else
                {
                    Debug.LogError("why don't have current node: " + this);
                }
            }
            // TODO con thieu captures
            {
                // Debug.LogError ("Con thieu captures");
            }
            this.isCustom.v = false;
        }

        public void undoMove()
        {
            if (this.nodes.vs.Count >= 2)
            {
                this.turn.v = this.turn.v - 1;
                this.side.v = Common.changeSide(this.side.v);
                this.nodes.removeAt(this.nodes.vs.Count - 1);
            }
            else
            {
                Debug.LogError("why don't have old nodes");
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////// implements ////////////////////
        ///////////////////////////////////////////////////////////////////////////////////

        public override Type getType()
        {
            return Type.CO_TUONG_UP;
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
            switch (this.side.v)
            {
                case Common.Side.Red:
                    return 0;
                case Common.Side.Black:
                    return 1;
                default:
                    Debug.LogError("unknown side: " + this.side.v + "; " + this);
                    return 0;
            }
        }

        public bool isLegalMove(int mv)
        {
            Rules.Move move = CoTuongUpMove.getMove(mv);
            // Get all legal moves
            List<Rules.Move> allLegalMoves = Rule.getAllLegalMoves(this, true);
            for (int i = 0; i < allLegalMoves.Count; i++)
            {
                Rules.Move legalMove = allLegalMoves[i];
                if (legalMove.equals(move))
                {
                    return true;
                }
            }
            return false;
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
                        case GameMove.Type.CoTuongUpMove:
                            {
                                // Get move
                                CoTuongUpMove coTuongUpMove = (CoTuongUpMove)gameMove;
                                return isLegalMove(coTuongUpMove.move.v);
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
                        case GameMove.Type.CoTuongUpMove:
                            return true;
                        case GameMove.Type.CoTuongUpCustomSet:
                            return true;
                        case GameMove.Type.EndTurn:
                            return true;
                        case GameMove.Type.Clear:
                            return true;
                        case GameMove.Type.CoTuongUpCustomMove:
                            return true;
                        case GameMove.Type.CoTuongUpCustomFlip:
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
                // make tempCoTuongUp
                CoTuongUp tempCoTuongUp = DataUtils.cloneData(this) as CoTuongUp;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.CoTuongUpCustomSet:
                            {
                                CoTuongUpCustomSet coTuongUpCustomSet = gameMove as CoTuongUpCustomSet;
                                // set piece
                                {
                                    tempCoTuongUp.setPieceByCoord(coTuongUpCustomSet.coord.v, coTuongUpCustomSet.piece.v);
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                if (tempCoTuongUp.nodes.vs.Count > 0)
                                {
                                    Node node = tempCoTuongUp.nodes.vs[tempCoTuongUp.nodes.vs.Count - 1];
                                    for (int i = 0; i < node.pieces.vs.Count; i++)
                                    {
                                        node.pieces.vs[i] = Common.x;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("why don't have any node: " + this);
                                }
                            }
                            break;
                        case GameMove.Type.CoTuongUpCustomMove:
                            {
                                CoTuongUpCustomMove coTuongUpCustomMove = gameMove as CoTuongUpCustomMove;
                                // update
                                {
                                    tempCoTuongUp.setPieceByCoord(coTuongUpCustomMove.dest.v, tempCoTuongUp.getPieceByCoord(coTuongUpCustomMove.from.v));
                                    tempCoTuongUp.setPieceByCoord(coTuongUpCustomMove.from.v, Common.x);
                                }
                            }
                            break;
                        case GameMove.Type.CoTuongUpCustomFlip:
                            {
                                CoTuongUpCustomFlip coTuongUpCustomFlip = gameMove as CoTuongUpCustomFlip;
                                {
                                    byte piece = tempCoTuongUp.getPieceByCoord(coTuongUpCustomFlip.coord.v);
                                    tempCoTuongUp.setPieceByCoord(coTuongUpCustomFlip.coord.v, Common.Visibility.flip(piece));
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
                    // nodes
                    {
                        for (int i = tempCoTuongUp.nodes.vs.Count - 2; i >= 0; i--)
                        {
                            tempCoTuongUp.nodes.removeAt(i);
                        }
                        if (tempCoTuongUp.nodes.vs.Count > 0)
                        {
                            Node node = tempCoTuongUp.nodes.vs[tempCoTuongUp.nodes.vs.Count - 1];
                            node.ply.v = 0;
                        }
                    }
                    tempCoTuongUp.isCustom.v = true;
                    DataUtils.copyData(this, tempCoTuongUp, AllowNames);
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
                case GameMove.Type.CoTuongUpMove:
                    {
                        CoTuongUpMove coTuongUpMove = gameMove as CoTuongUpMove;
                        this.doMove(CoTuongUpMove.getMove(coTuongUpMove.move.v), false);
                    }
                    break;
                case GameMove.Type.EndTurn:
                case GameMove.Type.CoTuongUpCustomSet:
                case GameMove.Type.Clear:
                case GameMove.Type.CoTuongUpCustomMove:
                case GameMove.Type.CoTuongUpCustomFlip:
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
                    // Get all legal moves
                    List<Rules.Move> allLegalMoves = Rule.getAllLegalMoves(this, true);
                    // Choose random
                    if (allLegalMoves.Count > 0)
                    {
                        System.Random random = new System.Random();
                        int index = random.Next(0, allLegalMoves.Count);
                        if (index >= 0 && index < allLegalMoves.Count)
                        {
                            ret = CoTuongUpMove.makeMove(allLegalMoves[index]);
                        }
                        else
                        {
                            Debug.LogError("index error: " + index + "; " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("why don't have any legalMoves");
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
                    byte[] CanChoosePieces = {
                        Common.x,

                        Common.K,
                        Common.A,
                        Common.B,
                        Common.R,
                        Common.C,
                        Common.N,
                        Common.P,
                        Common.HK,
                        Common.HA,
                        Common.HB,
                        Common.HR,
                        Common.HC,
                        Common.HN,
                        Common.HP,

                        Common.k,
                        Common.a,
                        Common.b,
                        Common.r,
                        Common.c,
                        Common.n,
                        Common.p,
                        Common.hk,
                        Common.ha,
                        Common.hb,
                        Common.hr,
                        Common.hc,
                        Common.hn,
                        Common.hp
                    };
                    for (byte coord = 0; coord < 90; coord++)
                    {
                        byte alreadySelectPiece = this.getPieceByCoord(coord);
                        foreach (byte piece in CanChoosePieces)
                        {
                            if (piece != alreadySelectPiece)
                            {
                                CoTuongUpCustomSet coTuongUpCustomSet = new CoTuongUpCustomSet();
                                {
                                    coTuongUpCustomSet.coord.v = coord;
                                    coTuongUpCustomSet.piece.v = piece;
                                }
                                moves.Add(coTuongUpCustomSet);
                            }
                        }
                    }
                }
                // flip
                {
                    for (byte coord = 0; coord < 90; coord++)
                    {
                        byte alreadySelectPiece = this.getPieceByCoord(coord);
                        if (Common.Visibility.isHide(alreadySelectPiece))
                        {
                            CoTuongUpCustomFlip coTuongUpCustomFlip = new CoTuongUpCustomFlip();
                            {
                                coTuongUpCustomFlip.coord.v = coord;
                            }
                            moves.Add(coTuongUpCustomFlip);
                        }
                    }
                }
                // get custom move
                {
                    for (byte coord = 0; coord < 90; coord++)
                    {
                        byte piece = this.getPieceByCoord(coord);
                        if (piece != Common.x)
                        {
                            for (byte destCoord = 0; destCoord < 90; destCoord++)
                            {
                                if (destCoord != coord)
                                {
                                    CoTuongUpCustomMove coTuongUpCustomMove = new CoTuongUpCustomMove();
                                    {
                                        coTuongUpCustomMove.from.v = coord;
                                        coTuongUpCustomMove.dest.v = destCoord;
                                    }
                                    moves.Add(coTuongUpCustomMove);
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
                int isGameFinish = 0;
                {
                    if (this.nodes.vs.Count > 0)
                    {
                        Node currentNode = this.nodes.vs[this.nodes.vs.Count - 1];
                        if (currentNode.ply.v >= this.plyDraw.v)
                        {
                            // draw
                            isGameFinish = 3;
                        }
                        else
                        {
                            CoTuongUp check = (CoTuongUp)DataUtils.cloneData(this);
                            // get red legalMoves
                            check.side.v = Common.Side.Red;
                            List<Rules.Move> allRedLegalMoves = Rule.getAllLegalMoves(check, false);
                            // get black legalMoves
                            check.side.v = Common.Side.Black;
                            List<Rules.Move> allBlackLegalMoves = Rule.getAllLegalMoves(check, false);
                            // process
                            if (allRedLegalMoves.Count == 0)
                            {
                                isGameFinish = 1;
                            }
                            else if (allBlackLegalMoves.Count == 0)
                            {
                                isGameFinish = 2;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("why don't have node: " + this);
                    }
                }
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

    }
}