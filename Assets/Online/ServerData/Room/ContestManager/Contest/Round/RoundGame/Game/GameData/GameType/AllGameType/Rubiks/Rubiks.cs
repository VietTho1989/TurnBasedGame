using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class Rubiks : GameType
    {

        public LP<byte> faces;

        public const int MinDimension = 3;
        public const int MaxDimension = 100;
        public VP<int> dimension;

        #region lastMove

        public VP<int> lastMoveId;

        public VP<int> lastMoveIndex;

        #endregion

        public VP<bool> canFinish;

        #region Constructor

        public enum Property
        {
            faces,
            dimension,
            lastMoveId,
            lastMoveIndex,
            canFinish
        }

        public Rubiks() : base()
        {
            this.faces = new LP<byte>(this, (byte)Property.faces);
            this.dimension = new VP<int>(this, (byte)Property.dimension, 3);
            this.lastMoveId = new VP<int>(this, (byte)Property.lastMoveId, 0);
            this.lastMoveIndex = new VP<int>(this, (byte)Property.lastMoveIndex, 0);
            this.canFinish = new VP<bool>(this, (byte)Property.canFinish, true);
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // board
                if (ret)
                {
                    if (this.faces.vs.Count == 0)
                    {
                        Debug.LogError("Don't have piece");
                        ret = false;
                    }
                }
                // st
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        // TODO Can hoan thien
                        /*if (dataIdentity is ShogiIdentity)
                        {
                            ShogiIdentity shogiIdentity = dataIdentity as ShogiIdentity;
                            if (shogiIdentity.startState != this.startState.vs.Count || shogiIdentity.st != this.st.vs.Count)
                            {
                                Debug.LogError("st not load full");
                                ret = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("why not chessIdentity");
                        }*/
                    }
                }
            }
            return ret;
        }

        #endregion

        #region implement interface

        public override Type getType()
        {
            return GameType.Type.Rubiks;
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
                        // TODO Can hoan thien
                        default:
                            Debug.LogError("unknown game type: " + gameMove.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    switch (gameMove.getType())
                    {
                        // TODO Can hoan thien
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
                // TODO Can hoan thien
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
                // TODO Can hoan thien
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
                    // TODO Can hoan thien
                    /*// find ai
                    ShogiAI ai = (computerAI != null && computerAI is ShogiAI) ? (ShogiAI)computerAI : new ShogiAI();
                    // search
                    uint move = Core.unityLetComputerThink(this, Core.CanCorrect, ai.depth.v, ai.skillLevel.v,
                        ai.mr.v, ai.duration.v, ai.useBook.v);
                    // Debug.LogError ("find shogi move: " + move + "; " + Core.unityMoveToString (move) + "; " + byteArray.Length);
                    if (move != 0)
                    {
                        ShogiMove shogiMove = new ShogiMove();
                        {
                            shogiMove.move.v = move;
                        }
                        ret = shogiMove;
                    }
                    else
                    {
                        Debug.LogError("why cannot find move: " + this);
                    }*/
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
                // TODO Can hoan thien
                {

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
                int isGameFinish = 0;// TODO Can hoan hoan thien Core.unityIsGameFinish(this, Core.CanCorrect);
                switch (isGameFinish)
                {
                    case 0:
                        {
                            result.isGameFinish = false;
                        }
                        break;
                    case 1:
                        // win
                        {
                            // Debug.LogError ("black: PlayerIndex 0 win: \n" + Core.unityPositionToString (Shogi.convertToBytes (this), Core.CanCorrect));
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 1));
                        }
                        break;
                    case 2:
                        // lose
                        {
                            // Debug.LogError ("white: PlayerIndex 1 win: \n" + Core.unityPositionToString (Shogi.convertToBytes (this), Core.CanCorrect));
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
                            if (turn.turn.v >= 1000000)
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
                }
            }
            // return
            return result;
        }

        #endregion

        #region Convert

        public static Cube convertToCube(Rubiks rubiks)
        {
            int dimension = Mathf.Clamp(rubiks.dimension.v, MinDimension, MaxDimension);
            Cube cube = new Cube(dimension);
            {
                for (int i = 0; i < cube.faces.Count; i++)
                {
                    int face = 0;
                    {
                        if (i >= 0 && i < rubiks.faces.vs.Count)
                        {
                            face = rubiks.faces.vs[i];
                        }
                    }
                    cube.faces[i] = face;
                }
            }
            return cube;
        }

        public static Rubiks parseCube(Cube cube)
        {
            Rubiks rubiks = new Rubiks();
            {
                rubiks.dimension.v = cube.dimension;
                for (int i = 0; i < cube.faces.Count; i++)
                {
                    int face = cube.faces[i];
                    rubiks.faces.add((byte)face);
                }
            }
            return rubiks;
        }

        #endregion

    }
}