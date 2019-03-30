using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using InternationalDraught.NoneRule;

namespace InternationalDraught
{
    public class InternationalDraught : GameType
    {

        public const string StartFen = "W:W31-50:B1-20";

        public override Type getType()
        {
            return Type.InternationalDraught;
        }

        #region Property

        #region node

        /** Node* node = NULL;*/
        public LP<Node> node;

        public Pos getCurrentPos()
        {
            if (this.node.vs.Count > 0)
            {
                Node node = this.node.vs[this.node.vs.Count - 1];
                return node.p_pos.v;
            }
            else
            {
                Debug.LogError("why node count = 0: " + this);
                return null;
            }
        }

        public int getPieceSide(int square)
        {
            if (this.node.vs.Count > 0)
            {
                Node node = this.node.vs[this.node.vs.Count - 1];
                Pos pos = node.p_pos.v;
                if (pos != null)
                {
                    return pos.piece_side(square);
                }
                else
                {
                    Debug.LogError("pos null: " + this);
                }
            }
            Debug.LogError("error, cannot get pieceSide: " + this);
            return (int)Common.Piece_Side.Empty;
        }

        #endregion

        /** struct var::Var var;*/
        public VP<Var> var;
        /** uint64 lastMove = 0;*/
        public VP<System.UInt64> lastMove;
        /** int ply = 50;*/
        public VP<int> ply;

        // CaptureSquares
        /** int captureSize = 0;*/
        public VP<int> captureSize;
        /** Square captureSquares[20];*/
        public LP<int> captureSquares;

        #endregion

        public VP<bool> isCustom;

        #region Constructor

        public enum Property
        {
            node,
            var,
            lastMove,
            ply,

            captureSize,
            captureSquares,

            isCustom
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static InternationalDraught()
        {
            AllowNames.Add((byte)Property.node);
            AllowNames.Add((byte)Property.var);
            AllowNames.Add((byte)Property.lastMove);
            AllowNames.Add((byte)Property.ply);
            AllowNames.Add((byte)Property.captureSize);
            AllowNames.Add((byte)Property.captureSquares);
            AllowNames.Add((byte)Property.isCustom);
        }

        public InternationalDraught() : base()
        {
            /** Node* node = NULL;*/
            this.node = new LP<Node>(this, (byte)Property.node);
            /** struct var::Var var;*/
            this.var = new VP<Var>(this, (byte)Property.var, new Var());
            /** uint64 lastMove = 0;*/
            this.lastMove = new VP<ulong>(this, (byte)Property.lastMove, 0);
            /** int ply = 50;*/
            this.ply = new VP<int>(this, (byte)Property.ply, 50);

            // CaptureSquares
            /** int captureSize = 0;*/
            this.captureSize = new VP<int>(this, (byte)Property.captureSize, 0);
            /** Square captureSquares[20];*/
            this.captureSquares = new LP<int>(this, (byte)Property.captureSquares);

            this.isCustom = new VP<bool>(this, (byte)Property.isCustom, false);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // node
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is InternationalDraughtIdentity)
                        {
                            InternationalDraughtIdentity internationalDraughtIdentity = dataIdentity as InternationalDraughtIdentity;
                            if (internationalDraughtIdentity.node != this.node.vs.Count)
                            {
                                Debug.LogError("node count error");
                                ret = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("why not internationalDraughtIdentity");
                        }
                    }
                }
                // check each node
                if (ret)
                {
                    for (int i = 0; i < this.node.vs.Count; i++)
                    {
                        Node node = this.node.vs[i];
                        Pos pos = node.p_pos.v;
                        if (pos != null)
                        {
                            if (pos.p_piece.vs.Count == 0)
                            {
                                Debug.LogError("pos don't have piece: " + pos);
                                ret = false;
                                break;
                            }
                        }
                        else
                        {
                            Debug.LogError("pos null");
                            ret = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        public string getFen()
        {
            if (this.node.vs.Count > 0)
            {
                Node node = this.node.vs[this.node.vs.Count - 1];
                return Core.unityGetFen(node.p_pos.v, Core.CanCorrect);
            }
            return "";
        }

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
            if (this.node.vs.Count > 0)
            {
                Node node = this.node.vs[this.node.vs.Count - 1];
                Pos pos = node.p_pos.v;
                switch (pos.p_turn.v)
                {
                    case (int)Common.Side.White:
                        return 0;
                    case (int)Common.Side.Black:
                        return 1;
                    default:
                        Debug.LogError("error, unknown turn: " + pos.p_turn.v);
                        return 0;
                }
            }
            else
            {
                Debug.LogError("why don't have any node: " + this);
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
                        case GameMove.Type.InternationalDraughtMove:
                            {
                                InternationalDraughtMove move = (InternationalDraughtMove)gameMove;
                                return Core.unityIsLegalMove(this, Core.CanCorrect, move.move.v);
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
                        case GameMove.Type.InternationalDraughtCustomSet:
                            return true;
                        case GameMove.Type.EndTurn:
                            return true;
                        case GameMove.Type.Clear:
                            return true;
                        case GameMove.Type.InternationalDraughtCustomMove:
                            return true;
                        case GameMove.Type.InternationalDraughtCustomFen:
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
                // make tempInternationalDraught
                InternationalDraught tempInternationalDraught = DataUtils.cloneData(this) as InternationalDraught;
                bool needUpdate = true;
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.InternationalDraughtCustomSet:
                            {
                                NoneRule.InternationalDraughtCustomSet internationalDraughtCustomSet = gameMove as NoneRule.InternationalDraughtCustomSet;
                                // set piece
                                {
                                    Pos currentPos = tempInternationalDraught.getCurrentPos();
                                    if (currentPos != null)
                                    {
                                        currentPos.setPieceSide(internationalDraughtCustomSet.square.v, internationalDraughtCustomSet.pieceSide.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("currentPos null: " + this);
                                    }
                                }
                            }
                            break;
                        case GameMove.Type.Clear:
                            {
                                Pos currentPos = tempInternationalDraught.getCurrentPos();
                                if (currentPos != null)
                                {
                                    for (int x = 0; x < 10; x++)
                                        for (int y = 0; y < 10; y++)
                                        {
                                            if (Common.square_is_dark(x, y))
                                            {
                                                int square = Common.square_make(x, y);
                                                currentPos.setPieceSide(square, Common.Piece_Side.Empty);
                                            }
                                        }
                                }
                                else
                                {
                                    Debug.LogError("currentPos null: " + this);
                                }
                            }
                            break;
                        case GameMove.Type.InternationalDraughtCustomMove:
                            {
                                NoneRule.InternationalDraughtCustomMove internationalDraughtCustomMove = gameMove as NoneRule.InternationalDraughtCustomMove;
                                // update
                                {
                                    Pos currentPos = tempInternationalDraught.getCurrentPos();
                                    if (currentPos != null)
                                    {
                                        currentPos.setPieceSide(internationalDraughtCustomMove.destSquare.v, (Common.Piece_Side)currentPos.piece_side(internationalDraughtCustomMove.fromSquare.v));
                                        currentPos.setPieceSide(internationalDraughtCustomMove.fromSquare.v, Common.Piece_Side.Empty);
                                    }
                                    else
                                    {
                                        Debug.LogError("currentPos null: " + this);
                                    }
                                }
                            }
                            break;
                        case GameMove.Type.InternationalDraughtCustomFen:
                            {
                                InternationalDraughtCustomFen internationalDraughtCustomFen = gameMove as InternationalDraughtCustomFen;
                                // Update
                                {
                                    tempInternationalDraught = Core.unityMakeDefaultPosition(tempInternationalDraught.var.v.Variant.v, internationalDraughtCustomFen.fen.v);
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
                    tempInternationalDraught.isCustom.v = true;
                    DataUtils.copyData(this, tempInternationalDraught, AllowNames);
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
                case GameMove.Type.InternationalDraughtMove:
                    {
                        // get information
                        InternationalDraughtMove move = (InternationalDraughtMove)gameMove;
                        InternationalDraught newInternationalDraught = Core.unityDoMove(this, Core.CanCorrect, move.move.v);
                        if (newInternationalDraught != null)
                        {
                            DataUtils.copyData(this, newInternationalDraught, AllowNames);
                        }
                        else
                        {
                            Debug.LogError("newInternationalDraught null: " + this);
                        }
                        // print board
                        // Debug.LogError(Common.printPosition(this));
                    }
                    break;
                case GameMove.Type.EndTurn:
                    {
                        if (this.node.vs.Count > 0)
                        {
                            Node node = this.node.vs[this.node.vs.Count - 1];
                            Pos pos = node.p_pos.v;
                            switch (pos.p_turn.v)
                            {
                                case (int)Common.Side.White:
                                    pos.p_turn.v = (int)Common.Side.Black;
                                    break;
                                case (int)Common.Side.Black:
                                    pos.p_turn.v = (int)Common.Side.White;
                                    break;
                                default:
                                    Debug.LogError("error, unknown turn: " + pos.p_turn.v);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("why don't have any node: " + this);
                        }
                        this.isCustom.v = true;
                    }
                    break;
                case GameMove.Type.InternationalDraughtCustomSet:
                case GameMove.Type.Clear:
                case GameMove.Type.InternationalDraughtCustomMove:
                case GameMove.Type.InternationalDraughtCustomFen:
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
                    InternationalDraughtAI ai = (computerAI != null && computerAI is InternationalDraughtAI) ? (InternationalDraughtAI)computerAI : new InternationalDraughtAI();
                    System.UInt64 move = Core.unityLetComputerThink(this, true, ai.bMove.v, ai.book.v, ai.depth.v,
                        ai.time.v, ai.input.v, ai.useEndGameDatabase.v, ai.pickBestMove.v);
                    // return
                    {
                        InternationalDraughtMove draughtMove = new InternationalDraughtMove();
                        {
                            draughtMove.move.v = move;
                        }
                        ret = draughtMove;
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
                Common.Piece_Side[] allPieceSides = { Common.Piece_Side.Empty, Common.Piece_Side.Black_Man, Common.Piece_Side.Black_King, Common.Piece_Side.White_Man, Common.Piece_Side.White_King };
                // get custom set
                {
                    for (int x = 0; x < 10; x++)
                        for (int y = 0; y < 10; y++)
                        {
                            if (Common.square_is_dark(x, y))
                            {
                                int square = Common.square_make(x, y);
                                Common.Piece_Side alreadySelectPieceSide = (Common.Piece_Side)this.getPieceSide(square);
                                foreach (Common.Piece_Side pieceSide in allPieceSides)
                                {
                                    if (pieceSide != alreadySelectPieceSide)
                                    {
                                        NoneRule.InternationalDraughtCustomSet internationalDraughtCustomSet = new NoneRule.InternationalDraughtCustomSet();
                                        {
                                            internationalDraughtCustomSet.square.v = square;
                                            internationalDraughtCustomSet.pieceSide.v = pieceSide;
                                        }
                                        moves.Add(internationalDraughtCustomSet);
                                    }
                                }
                            }
                        }
                }
                // get custom move
                {
                    for (int x = 0; x < 10; x++)
                        for (int y = 0; y < 10; y++)
                        {
                            if (Common.square_is_dark(x, y))
                            {
                                int square = Common.square_make(x, y);
                                Common.Piece_Side alreadySelectPieceSide = (Common.Piece_Side)this.getPieceSide(square);
                                if (alreadySelectPieceSide != Common.Piece_Side.Empty)
                                {
                                    for (int destX = 0; destX < 10; destX++)
                                        for (int destY = 0; destY < 10; destY++)
                                        {
                                            if (Common.square_is_dark(destX, destY))
                                            {
                                                int destSquare = Common.square_make(destX, destY);
                                                if (destSquare != square)
                                                {
                                                    InternationalDraughtCustomMove internationalDraughtCustomMove = new InternationalDraughtCustomMove();
                                                    {
                                                        internationalDraughtCustomMove.fromSquare.v = square;
                                                        internationalDraughtCustomMove.destSquare.v = destSquare;
                                                    }
                                                    moves.Add(internationalDraughtCustomMove);
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
            // use rule or not
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
                            result.scores.Add(new GameType.Score(0, 1));// white: 0 index
                            result.scores.Add(new GameType.Score(1, 0));// black: 1 index
                        }
                        break;
                    case 2:
                        // black win
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));// white: 0 index
                            result.scores.Add(new GameType.Score(1, 1));// black: 1 index
                        }
                        break;
                    case 3:
                        // draw
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));// white: 0 index
                            result.scores.Add(new GameType.Score(1, 0));// black: 1 index
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

        public static byte[] convertToBytes(InternationalDraught internationalDraught, bool needCheckCustom = true)
        {
            // custom
            if (internationalDraught.isCustom.v && needCheckCustom)
            {
                string strFen = internationalDraught.getFen();
                Debug.LogError("internationalDraught custom fen: " + strFen);
                InternationalDraught newInternationalDraught = Core.unityMakeDefaultPosition(internationalDraught.var.v.Variant.v, strFen);
                return convertToBytes(newInternationalDraught);
            }
            // normal
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // write value
                    {
                        /** Node* node = NULL;*/
                        {
                            writer.Write(internationalDraught.node.vs.Count);
                            for (int i = 0; i < internationalDraught.node.vs.Count; i++)
                            {
                                Node node = internationalDraught.node.vs[i];
                                writer.Write(Node.convertToBytes(node));
                            }
                        }
                        /** struct var::Var var;*/
                        writer.Write(Var.convertToBytes(internationalDraught.var.v));
                        /** uint64 lastMove = 0;*/
                        writer.Write(internationalDraught.lastMove.v);
                        /** int ply = 50;*/
                        writer.Write(internationalDraught.ply.v);

                        // CaptureSquares
                        /** int captureSize = 0;*/
                        writer.Write(internationalDraught.captureSize.v);
                        /** Square captureSquares[20];*/
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                // get value
                                int value = 0;
                                {
                                    if (i < internationalDraught.captureSquares.vs.Count)
                                    {
                                        value = internationalDraught.captureSquares.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("error, index:  captureSquares: " + internationalDraught);
                                    }
                                }
                                // write
                                writer.Write(value);
                            }
                        }
                    }
                    // write to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(InternationalDraught internationalDraught, byte[] byteArray, int start)
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
                        /** Node* node = NULL;*/
                        {
                            // Debug.Log ("parse node: " + count);
                            // reset
                            internationalDraught.node.clear();
                            // find node count
                            int nodeCount = 0;
                            {
                                int size = sizeof(int);
                                if (count + size <= byteArray.Length)
                                {
                                    nodeCount = BitConverter.ToInt32(byteArray, count);
                                    count += size;
                                }
                                else
                                {
                                    Debug.LogError("error, array not enough length: nodeCount: " + count + "; " + byteArray.Length);
                                    isParseCorrect = false;
                                }
                            }
                            if (nodeCount >= 0)
                            {
                                List<Node> nodes = new List<Node>();
                                // get nodes 
                                for (int i = 0; i < nodeCount; i++)
                                {
                                    Node node = new Node();
                                    int nodeByteLength = Node.parse(node, byteArray, count);
                                    if (nodeByteLength > 0)
                                    {
                                        nodes.Add(node);
                                        count += nodeByteLength;
                                        // Debug.Log ("nodeByteLength: " + nodeByteLength);
                                    }
                                    else
                                    {
                                        Debug.LogError("cannot parse");
                                        break;
                                    }
                                }
                                // add to internationalDraught
                                for (int i = 0; i < nodes.Count; i++)
                                {
                                    Node node = nodes[i];
                                    node.uid = internationalDraught.node.makeId();
                                    internationalDraught.node.add(node);
                                }
                            }
                            else
                            {
                                Debug.LogError("error, why nodeCount < 0: " + nodeCount);
                            }
                        }
                        break;
                    case 1:
                        /** struct var::Var var;*/
                        {
                            // Debug.Log ("parse var: " + count);
                            Var var = new Var();
                            // parse
                            {
                                int byteLength = Var.parse(var, byteArray, count);
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
                                var.uid = internationalDraught.var.makeId();
                                internationalDraught.var.v = var;
                            }
                            else
                            {
                                Debug.LogError("parse var error");
                            }
                        }
                        break;
                    case 2:
                        /** uint64 lastMove = 0;*/
                        {
                            // Debug.Log ("parse lastMove: " + count);
                            int size = sizeof(System.UInt64);
                            if (count + size <= byteArray.Length)
                            {
                                internationalDraught.lastMove.v = BitConverter.ToUInt64(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: lastMove: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        /** int ply = 50;*/
                        {
                            // Debug.Log ("parse ply: " + count);
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                internationalDraught.ply.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: ply: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;

                    // CaptureSquares
                    case 4:
                        /** int captureSize = 0;*/
                        {
                            // Debug.Log ("parse captureSize: " + count);
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                internationalDraught.captureSize.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("error, array not enough length: captureSize: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        /** Square captureSquares[20];*/
                        {
                            // Debug.Log ("parse captureSquares: " + count);
                            internationalDraught.captureSquares.clear();
                            int size = sizeof(int);
                            for (int i = 0; i < 20; i++)
                            {
                                if (count + size <= byteArray.Length)
                                {
                                    internationalDraught.captureSquares.add(BitConverter.ToInt32(byteArray, count));
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
                Debug.LogError("parse InternationalDraught fail: " + count + "; " + byteArray.Length + "; " + start);
                return -1;
            }
            else
            {
                // Debug.Log ("parse InternationalDraught success: " + count + "; " + byteArray.Length + "; " + start);
                return (count - start);
            }
        }

        #endregion

    }
}