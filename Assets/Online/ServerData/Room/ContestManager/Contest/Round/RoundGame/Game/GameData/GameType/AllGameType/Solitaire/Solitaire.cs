using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class Solitaire : GameType
    {

        /** Pile piles[13]*/
        public LP<Pile> piles;
        /** Card cards[52]*/
        public LP<Card> cards;

        /** int32_t movesAvailableCount*/
        public VP<int> movesAvailableCount;
        /** Move movesAvailable[32]*/
        public LP<SolitaireMove> movesAvailable;

        /** int32_t drawCount*/
        public VP<int> drawCount;
        /** int32_t roundCount*/
        public VP<int> roundCount;
        /** int32_t foundationCount*/
        public VP<int> foundationCount;

        public VP<SolvedMoves> solvedMoves;
        private SolvedMoves clientSolvedMoves = new SolvedMoves();

        #region Constructor

        public enum Property
        {
            piles,
            cards,
            movesAvailableCount,
            movesAvailable,
            drawCount,
            roundCount,
            foundationCount,
            solvedMoves
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static Solitaire()
        {
            AllowNames.Add((byte)Property.piles);
            AllowNames.Add((byte)Property.cards);
            AllowNames.Add((byte)Property.movesAvailableCount);
            AllowNames.Add((byte)Property.movesAvailable);
            AllowNames.Add((byte)Property.drawCount);
            AllowNames.Add((byte)Property.roundCount);
            AllowNames.Add((byte)Property.foundationCount);
        }

        public Solitaire() : base()
        {
            this.piles = new LP<Pile>(this, (byte)Property.piles);
            this.cards = new LP<Card>(this, (byte)Property.cards);
            {
                this.movesAvailableCount = new VP<int>(this, (byte)Property.movesAvailableCount, 0);
                this.movesAvailable = new LP<SolitaireMove>(this, (byte)Property.movesAvailable);
            }
            this.drawCount = new VP<int>(this, (byte)Property.drawCount, 1);
            this.roundCount = new VP<int>(this, (byte)Property.roundCount, 0);
            this.foundationCount = new VP<int>(this, (byte)Property.foundationCount, 0);
            this.solvedMoves = new VP<SolvedMoves>(this, (byte)Property.solvedMoves, new SolvedMoves());
        }

        public bool isLoadFull()
        {
            bool ret = true;
            {
                // check solitaire
                if (ret)
                {
                    if (this.piles.vs.Count != 13 || this.cards.vs.Count != 52 || this.movesAvailable.vs.Count != this.movesAvailableCount.v)
                    {
                        Debug.LogError("solitaire error");
                        ret = false;
                    }
                }
                // check pile
                if (ret)
                {
                    for (int i = 0; i < this.piles.vs.Count; i++)
                    {
                        Pile pile = this.piles.vs[i];
                        if (pile.downSize.v != pile.down.vs.Count || pile.upSize.v != pile.up.vs.Count)
                        {
                            Debug.LogError("pile error: " + pile + ", " + pile.down.vs.Count + ", " + pile.up.vs.Count);
                            ret = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        #endregion

        public bool isHaveDrawMove()
        {
            bool ret = false;
            {
                foreach (SolitaireMove solitaireMove in this.movesAvailable.vs)
                {
                    Debug.LogError("moveAvailable: " + solitaireMove.print());
                }
                // get stock pile
                Pile stockPile = null;
                {
                    int pileIndex = (int)Pile.Piles.STOCK;
                    if (pileIndex >= 0 && pileIndex < this.piles.vs.Count)
                    {
                        stockPile = this.piles.vs[pileIndex];
                    }
                }
                // get waste pile
                Pile wastePile = null;
                {
                    int pileIndex = (int)Pile.Piles.WASTE;
                    if (pileIndex >= 0 && pileIndex < this.piles.vs.Count)
                    {
                        wastePile = this.piles.vs[pileIndex];
                    }
                }
                // process
                if (stockPile != null && wastePile != null)
                {
                    if (stockPile.size.v > 0 || wastePile.size.v > 0)
                    {
                        ret = true;
                    }
                    else
                    {
                        Debug.LogError("don't have any card in stock, waste");
                    }
                }
                else
                {
                    Debug.LogError("stockPile, wastePile null");
                }
            }
            return ret;
        }

        #region implement gameType

        public override Type getType()
        {
            return Type.Solitaire;
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
            // TODO Can hoan thien
            return true;
        }

        #region processGameMove

        public override void processGameMove(GameMove gameMove)
        {
            if (gameMove != null)
            {
                switch (gameMove.getType())
                {
                    case GameMove.Type.SolitaireMove:
                        {
                            SolitaireMove solitaireMove = gameMove as SolitaireMove;
                            // update board
                            {
                                Solitaire newSolitaire = Core.unityDoMove(this, Core.CanCorrect, solitaireMove);
                                DataUtils.copyData(this, newSolitaire, AllowNames);
                            }
                            // update solved
                            this.solvedMoves.v.processMove(solitaireMove);
                            this.clientSolvedMoves.processMove(solitaireMove);
                        }
                        break;
                    case GameMove.Type.SolitaireReset:
                        {
                            // update board
                            {
                                Solitaire newSolitaire = Core.unityReset(this, Core.CanCorrect);
                                DataUtils.copyData(this, newSolitaire, AllowNames);
                            }
                            // update solved
                            this.solvedMoves.v.moveIndex.v = -1;
                            this.clientSolvedMoves.moveIndex.v = -1;
                        }
                        break;
                    default:
                        Debug.LogError("unknown gameMove: " + gameMove + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("gameMove null: " + this);
            }
        }

        #endregion

        public override int getStackSize()
        {
            return 0;
        }

        public override GameMove getAIMove(Computer.AI ai, bool isFindHint)
        {
            Debug.LogError("solitaire: getAIMove: " + ai);
            GameMove ret = new NonMove();
            {
                if (!isFindHint)
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
                            useNormalMove = true;
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
                                        Debug.LogError("why don't have data: " + this.piles.vs.Count + ", " + this.cards.vs.Count + ", " + this.movesAvailable.vs.Count);
                                        return new NonMove();
                                    }
                                }
                            }
                        }
                        // search
                        if (this.solvedMoves.v.solved.v.result.v != SolitaireSolved.SolveResult.NotSolved)
                        {
                            Debug.LogError("already have server solved moves");
                            ret = this.solvedMoves.v.getSolvedMove();
                        }
                        else
                        {
                            if (this.clientSolvedMoves.solved.v.result.v != SolitaireSolved.SolveResult.NotSolved)
                            {
                                Debug.LogError("already have client solved moves");
                                ret = this.clientSolvedMoves.solved.v;
                            }
                            else
                            {
                                // get ai
                                SolitaireAI solitaireAI = (ai != null && ai is SolitaireAI) ? (SolitaireAI)ai : new SolitaireAI();
                                // search
                                SolitaireSolved solitaireSolved = Core.unityLetComputerThink(this, Core.CanCorrect, solitaireAI.multiThreaded.v, solitaireAI.maxClosedCount.v, solitaireAI.fastMode.v);
                                // client
                                {
                                    {
                                        // solved
                                        {
                                            SolitaireSolved clientSolved = DataUtils.cloneData(solitaireSolved) as SolitaireSolved;
                                            {
                                                clientSolved.uid = clientSolvedMoves.solved.makeId();
                                            }
                                            clientSolvedMoves.solved.v = clientSolved;
                                        }
                                        // moveIndex
                                        clientSolvedMoves.moveIndex.v = -1;
                                    }
                                }
                                // return
                                ret = solitaireSolved;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("why not use normal move");
                    }
                }
                else
                {
                    Debug.LogError("find hint, TODO Can hoan thien");
                }
            }
            return ret;
        }

        public override Result isGameFinish()
        {
            Result result = Result.makeDefault();
            // find too many turn?
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
            // process
            if (GameData.IsUseRule(this))
            {
                int isGameFinish = 0;
                {
                    if (isTooManyTurn)
                    {
                        isGameFinish = 2;
                    }
                    else
                    {
                        isGameFinish = Core.unityIsGameFinish(this, Core.CanCorrect);
                        if (isGameFinish == 0)
                        {
                            // check computer cannot finish?
                            Debug.LogError("TODO Can hoan thien");
                        }
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
                        // win
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 1));// white
                        }
                        break;
                    case 2:
                        // lose
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
            else
            {
                if (isTooManyTurn)
                {
                    // draw
                    result.isGameFinish = true;
                    // score
                    result.scores.Add(new GameType.Score(0, 0.5f));
                }
            }
            // return
            return result;
        }

        #endregion

        #region solvedMove

        public override bool isHaveSolvedMove()
        {
            if (this.solvedMoves.v.solved.v.result.v != SolitaireSolved.SolveResult.NotSolved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override GameMove getSolvedMove()
        {
            if (this.solvedMoves.v.solved.v.result.v != SolitaireSolved.SolveResult.NotSolved)
            {
                GameMove solvedMove = this.solvedMoves.v.getSolvedMove();
                {
                    if (solvedMove is SolitaireMove)
                    {
                        SolitaireMove solitaireMove = solvedMove as SolitaireMove;
                        Debug.LogError(string.Format("getSolvedMove: {0}",
                            Core.unityPrintMove(this, Core.CanCorrect, solitaireMove)));
                        Debug.LogError(string.Format("From: {0}, To: {1}, Count: {2}, Extra: {3}",
                            (int)solitaireMove.From.v, (int)solitaireMove.To.v, (int)solitaireMove.Count.v, (int)solitaireMove.Extra.v));
                    }
                }
                return solvedMove;
            }
            else
            {
                return getAIMove(null, false);
            }
        }

        public override GameMove preprocessGameMove(GameMove gameMove)
        {
            if (gameMove is SolitaireSolved)
            {
                SolitaireSolved solitaireSolved = gameMove as SolitaireSolved;
                // solvedMoves set
                SolvedMoves solvedMoves = this.solvedMoves.v;
                {
                    // solved
                    {
                        SolitaireSolved solved = DataUtils.cloneData(solitaireSolved) as SolitaireSolved;
                        {
                            solved.uid = solvedMoves.solved.makeId();
                        }
                        solvedMoves.solved.v = solved;
                    }
                    // moveIndex
                    if (solvedMoves.moveIndex.v == -1)
                    {
                        return solvedMoves.getSolvedMove();
                    }
                    else
                    {
                        return new SolitaireReset();
                    }
                }
            }
            else
            {
                return gameMove;
            }
        }

        #endregion

        #region Convert

        public static byte[] convertToBytes(Solitaire solitaire)
        {
            byte[] byteArray;
            using (MemoryStream memStream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(memStream))
                {
                    // write
                    {
                        /** Pile piles[13]*/
                        for (int i = 0; i < 13; i++)
                        {
                            // get value
                            Pile pile = null;
                            {
                                if (i < solitaire.piles.vs.Count)
                                {
                                    pile = solitaire.piles.vs[i];
                                }
                                else
                                {
                                    Debug.LogError("index error: " + pile);
                                    pile = new Pile();
                                }
                            }
                            writer.Write(Pile.convertToBytes(pile));
                        }
                        /** Card cards[52]*/
                        for (int i = 0; i < 52; i++)
                        {
                            // get value
                            Card card = null;
                            {
                                if (i < solitaire.cards.vs.Count)
                                {
                                    card = solitaire.cards.vs[i];
                                }
                                else
                                {
                                    Debug.LogError("index error: " + card);
                                    card = new Card();
                                }
                            }
                            writer.Write(Card.convertToBytes(card));
                        }

                        /** int32_t movesAvailableCount*/
                        writer.Write(solitaire.movesAvailableCount.v);
                        /** Move movesAvailable[32]*/
                        if (solitaire.movesAvailableCount.v >= 0 && solitaire.movesAvailableCount.v <= 32)
                        {
                            for (int i = 0; i < solitaire.movesAvailableCount.v; i++)
                            {
                                // get value
                                SolitaireMove move = null;
                                {
                                    if (i < solitaire.movesAvailable.vs.Count)
                                    {
                                        move = solitaire.movesAvailable.vs[i];
                                    }
                                    else
                                    {
                                        Debug.LogError("index error: " + move);
                                        move = new SolitaireMove();
                                    }
                                }
                                writer.Write(SolitaireMove.convertToBytes(move));
                            }
                        }
                        else
                        {
                            Debug.LogError("solitaire movesAvailableCount error: " + solitaire.movesAvailableCount.v);
                        }

                        /** int32_t drawCount*/
                        writer.Write(solitaire.drawCount.v);
                        /** int32_t roundCount*/
                        writer.Write(solitaire.roundCount.v);
                        /** int32_t foundationCount*/
                        writer.Write(solitaire.foundationCount.v);
                    }
                    // to byteArray
                    byteArray = memStream.ToArray();
                }
            }
            return byteArray;
        }

        public static int parse(Solitaire solitaire, byte[] byteArray, int start)
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
                            /** Pile piles[13]*/
                            solitaire.piles.clear();
                            // get list
                            List<Pile> piles = new List<Pile>();
                            {
                                for (int i = 0; i < 13; i++)
                                {
                                    Pile pile = new Pile();
                                    int pileByteLength = Pile.parse(pile, byteArray, count);
                                    if (pileByteLength > 0)
                                    {
                                        piles.Add(pile);
                                        count += pileByteLength;
                                    }
                                    else
                                    {
                                        Debug.LogError("cannot parse");
                                        break;
                                    }
                                }
                            }
                            // add
                            foreach (Pile pile in piles)
                            {
                                pile.uid = solitaire.piles.makeId();
                                solitaire.piles.add(pile);
                            }
                        }
                        break;
                    case 1:
                        {
                            /** Card cards[52]*/
                            solitaire.cards.clear();
                            // get list
                            List<Card> cards = new List<Card>();
                            {
                                for (int i = 0; i < 52; i++)
                                {
                                    Card card = new Card();
                                    int cardByteLength = Card.parse(card, byteArray, count);
                                    if (cardByteLength > 0)
                                    {
                                        cards.Add(card);
                                        count += cardByteLength;
                                    }
                                    else
                                    {
                                        Debug.LogError("cannot parse");
                                        break;
                                    }
                                }
                            }
                            // add
                            foreach (Card card in cards)
                            {
                                card.uid = solitaire.cards.makeId();
                                solitaire.cards.add(card);
                            }
                        }
                        break;

                    case 2:
                        {
                            /** int32_t movesAvailableCount*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                solitaire.movesAvailableCount.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: movesAvailableCount: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 3:
                        {
                            /** Move movesAvailable[32]*/
                            solitaire.movesAvailable.clear();
                            // get list
                            List<SolitaireMove> moves = new List<SolitaireMove>();
                            {
                                if (solitaire.movesAvailableCount.v >= 0 && solitaire.movesAvailableCount.v <= 32)
                                {
                                    for (int i = 0; i < solitaire.movesAvailableCount.v; i++)
                                    {
                                        SolitaireMove move = new SolitaireMove();
                                        int moveByteLength = SolitaireMove.parse(move, byteArray, count);
                                        if (moveByteLength > 0)
                                        {
                                            moves.Add(move);
                                            count += moveByteLength;
                                        }
                                        else
                                        {
                                            Debug.LogError("cannot parse");
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("solitaire movesAvailableCount error: " + solitaire.movesAvailableCount.v);
                                }
                            }
                            // add
                            foreach (SolitaireMove move in moves)
                            {
                                move.uid = solitaire.movesAvailable.makeId();
                                solitaire.movesAvailable.add(move);
                            }
                        }
                        break;

                    case 4:
                        {
                            /** int32_t drawCount*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                solitaire.drawCount.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: drawCount: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 5:
                        {
                            /** int32_t roundCount*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                solitaire.roundCount.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: roundCount: " + count + "; " + byteArray.Length);
                                isParseCorrect = false;
                            }
                        }
                        break;
                    case 6:
                        {
                            /** int32_t foundationCount*/
                            int size = sizeof(int);
                            if (count + size <= byteArray.Length)
                            {
                                solitaire.foundationCount.v = BitConverter.ToInt32(byteArray, count);
                                count += size;
                            }
                            else
                            {
                                Debug.LogError("array not enough length: foundationCount: " + count + "; " + byteArray.Length);
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

    }
}