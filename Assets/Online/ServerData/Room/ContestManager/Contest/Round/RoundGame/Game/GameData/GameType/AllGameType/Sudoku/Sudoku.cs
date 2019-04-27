using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
    public class Sudoku : GameType
    {

        public LP<byte> board;

        public LP<byte> userSolve;

        public VP<AISolve> aiSolve;

        #region Constructor

        public enum Property
        {
            board,
            userSolve,
            aiSolve
        }

        public static readonly List<byte> AllowNames = new List<byte>();

        static Sudoku()
        {
            AllowNames.Add((byte)Property.board);
            AllowNames.Add((byte)Property.userSolve);
        }

        public Sudoku() : base()
        {
            this.board = new LP<byte>(this, (byte)Property.board);
            this.userSolve = new LP<byte>(this, (byte)Property.userSolve);
            {
                this.aiSolve = new VP<AISolve>(this, (byte)Property.aiSolve, new AINotSolve());
                this.aiSolve.nh = 0;
            }
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
                        Debug.LogError("board empty");
                        ret = false;
                    }
                }
            }
            return ret;
        }

        #endregion

        public override Type getType()
        {
            return Type.Sudoku;
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
                        case GameMove.Type.SudokuMove:
                            {
                                SudokuMove sudokuMove = gameMove as SudokuMove;
                                // check
                                bool isLegal = false;
                                {
                                    if (sudokuMove.x.v >= 0 && sudokuMove.x.v < 9 && sudokuMove.y.v >= 0 && sudokuMove.y.v < 9)
                                    {
                                        int index = 9 * sudokuMove.y.v + sudokuMove.x.v;
                                        if (index >= 0 && index < this.board.vs.Count)
                                        {
                                            if (this.board.vs[index] == 0)
                                            {
                                                isLegal = true;
                                            }
                                            else
                                            {
                                                Debug.LogError("why not legal: not 0");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("outside board: " + index);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("outside board: " + sudokuMove.x.v + ", " + sudokuMove.y.v);
                                    }
                                }
                                return isLegal;
                            }
                        case GameMove.Type.SudokuSolve:
                            return true;
                        default:
                            Debug.LogError("unknown game type: " + gameMove.getType() + "; " + this);
                            break;
                    }
                }
                else
                {
                    switch (gameMove.getType())
                    {
                        case GameMove.Type.SudokuCustomMove:
                            return true;
                        case GameMove.Type.SudokuSolve:
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

        public override void processGameMove(GameMove gameMove)
        {
            if (gameMove != null)
            {
                switch (gameMove.getType())
                {
                    case GameMove.Type.SudokuMove:
                        {
                            SudokuMove sudokuMove = gameMove as SudokuMove;
                            // init user solve
                            if (this.userSolve.vs.Count != 81)
                            {
                                // clear
                                if (this.userSolve.vs.Count > 0)
                                {
                                    this.userSolve.clear();
                                }
                                // add
                                {
                                    List<byte> bytes = new List<byte>();
                                    {
                                        for (int i = 0; i < 81; i++)
                                        {
                                            bytes.Add(0);
                                        }
                                    }
                                    this.userSolve.add(bytes);
                                }
                            }
                            // change userSolve
                            {
                                if (sudokuMove.x.v >= 0 && sudokuMove.x.v < 9 && sudokuMove.y.v >= 0 && sudokuMove.y.v < 9)
                                {
                                    int index = 9 * sudokuMove.y.v + sudokuMove.x.v;
                                    this.userSolve.set(index, sudokuMove.value.v);
                                }
                            }
                        }
                        break;
                    case GameMove.Type.SudokuSolve:
                        {
                            Debug.LogError("why sudoku solve");
                        }
                        break;
                    case GameMove.Type.SudokuCustomMove:
                        {
                            SudokuCustomMove sudokuCustomMove = gameMove as SudokuCustomMove;
                            if (sudokuCustomMove.x.v >= 0 && sudokuCustomMove.x.v < 9 && sudokuCustomMove.y.v >= 0 && sudokuCustomMove.y.v < 9)
                            {
                                int index = 9 * sudokuCustomMove.y.v + sudokuCustomMove.x.v;
                                this.board.set(index, sudokuCustomMove.value.v);
                            }
                            else
                            {
                                Debug.LogError("outside board");
                            }
                            // reset ai solve
                            {
                                AINotSolve aiNoteSolve = this.aiSolve.newOrOld<AINotSolve>();
                                {

                                }
                                this.aiSolve.v = aiNoteSolve;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown gameMove: " + gameMove.getType());
                        break;
                }
            }
            else
            {
                Debug.LogError("gameMove null");
            }
        }

        public override int getStackSize()
        {
            return 0;
        }

        public override GameMove getAIMove(Computer.AI ai, bool isFindHint)
        {
            Debug.LogError("sudoku getAIMove");
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
                    GameMove aiSolveMove = this.aiSolve.v.getAIMove();
                    if (aiSolveMove == null)
                    {
                        // make board
                        int[,] board = new int[9, 9];
                        {
                            for (int x = 0; x < 9; x++)
                                for (int y = 0; y < 9; y++)
                                {
                                    int index = 9 * y + x;
                                    // find value
                                    int value = 0;
                                    {
                                        if (index >= 0 && index < this.board.vs.Count)
                                        {
                                            value = this.board.vs[index];
                                        }
                                        else
                                        {
                                            Debug.LogError("index error: " + index + ", " + this.board.vs.Count);
                                        }
                                    }
                                    board[x, y] = value;
                                }
                        }
                        SudokuDancingLink.report(board);
                        // solve
                        SudokuDancingLink sudokuDancingLink = new SudokuDancingLink();
                        {
                            sudokuDancingLink.solve(board);
                        }
                        // return result
                        SudokuSolve sudokuSolve = new SudokuSolve();
                        {
                            foreach (int[,] solveBoard in sudokuDancingLink.results)
                            {
                                SudokuDancingLink.report(solveBoard);
                                if (solveBoard.GetLength(0) == 9 && solveBoard.GetLength(1) == 9)
                                {
                                    for (int y = 0; y < 9; y++)
                                        for (int x = 0; x < 9; x++)
                                        {
                                            sudokuSolve.board.add((byte)solveBoard[x, y]);
                                        }
                                }
                                else
                                {
                                    Debug.LogError("solveBoard length error: " + solveBoard.GetLength(0) + ", " + solveBoard.GetLength(1));
                                }
                            }
                        }
                        ret = sudokuSolve;
                    }
                    else
                    {
                        Debug.LogError("aiSolveMove not null");
                        ret = aiSolveMove;
                    }
                }
                else
                {

                }
            }
            return ret;
        }

        public override Result isGameFinish()
        {
            Result result = Result.makeDefault();
            // process
            if (GameData.IsUseRule(this))
            {
                int isGameFinish = 0;
                {
                    // make board
                    int[,] board = new int[9, 9];
                    {
                        for (int y = 0; y < 9; y++)
                            for (int x = 0; x < 9; x++)
                            {
                                int index = 9 * y + x;
                                // find value
                                int value = 0;
                                {
                                    if (index >= 0 && index < this.board.vs.Count)
                                    {
                                        value = this.board.vs[index];
                                        if (value == 0)
                                        {
                                            // get user solve
                                            if (index >= 0 && index < this.userSolve.vs.Count)
                                            {
                                                value = this.userSolve.vs[index];
                                            }
                                            else
                                            {
                                                // Debug.LogError ("index error: " + index + ", " + this.userSolve.vs.Count);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("index error: " + index + ", " + this.board.vs.Count);
                                    }
                                }
                                board[x, y] = value;
                            }
                    }
                    // check
                    if (Sudoku.IsSudokuBoard(board, 9))
                    {
                        isGameFinish = 1;
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
                            result.scores.Add(new GameType.Score(0, 1));
                        }
                        break;
                    case 2:
                        // lose
                        {
                            result.isGameFinish = true;
                            // score
                            result.scores.Add(new GameType.Score(0, 0));
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
                    result.scores.Add(new GameType.Score(0, 0f));
                }
            }
            // return
            return result;
        }

        #region solvedMove

        public override bool isHaveSolvedMove()
        {
            if (this.aiSolve.v.getType() == AISolve.Type.HaveSove)
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
            return this.aiSolve.v.getAIMove();
        }

        public override GameMove preprocessGameMove(GameMove gameMove)
        {
            if (gameMove is SudokuSolve)
            {
                SudokuSolve sudokuSolve = gameMove as SudokuSolve;
                // find haveSolve
                {
                    AIHaveSolve aiHaveSolve = this.aiSolve.newOrOld<AIHaveSolve>();
                    {
                        aiHaveSolve.board.add(sudokuSolve.board.vs);
                        aiHaveSolve.order.add(sudokuSolve.order.vs);
                    }
                    this.aiSolve.v = aiHaveSolve;
                }
                return this.aiSolve.v.getAIMove();
            }
            else
            {
                return gameMove;
            }
        }

        #endregion

        public static bool IsSudokuBoard(int[,] board, int boardSize)
        {
            if (board != null)
            {
                if (boardSize > 0)
                {
                    if (board.GetLength(0) == boardSize && board.GetLength(1) == boardSize)
                    {
                        for (int i = 0; i < boardSize; i++)
                        {
                            // x
                            {
                                List<int> from1toBoardSize = new List<int>();
                                {
                                    for (int x = 1; x <= boardSize; x++)
                                    {
                                        from1toBoardSize.Add(x);
                                    }
                                }
                                // check
                                for (int x = 0; x < boardSize; x++)
                                {
                                    if (board[i, x] >= 1 && board[i, x] <= boardSize)
                                    {
                                        if (from1toBoardSize.Contains(board[i, x]))
                                        {
                                            from1toBoardSize.Remove(board[i, x]);
                                        }
                                        else
                                        {
                                            Debug.LogError("already contain x: " + i + ", " + x + ", " + board[i, x]);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("not finish board x: " + i + ", " + x + ", " + board[i, x]);
                                        return false;
                                    }
                                }
                            }
                            // y
                            {
                                List<int> from1toBoardSize = new List<int>();
                                {
                                    for (int y = 1; y <= boardSize; y++)
                                    {
                                        from1toBoardSize.Add(y);
                                    }
                                }
                                // check
                                for (int y = 0; y < boardSize; y++)
                                {
                                    if (board[y, i] >= 1 && board[y, i] <= boardSize)
                                    {
                                        if (from1toBoardSize.Contains(board[y, i]))
                                        {
                                            from1toBoardSize.Remove(board[y, i]);
                                        }
                                        else
                                        {
                                            Debug.LogError("already contain y: " + y + ", " + i + ", " + board[y, i]);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("not finish board x: " + y + ", " + i + ", " + board[y, i]);
                                        return false;
                                    }
                                }
                            }
                        }
                        return true;
                    }
                    else
                    {
                        Debug.LogError("not correct board");
                        return false;
                    }
                }
                else
                {
                    Debug.LogError("boardSize error: " + boardSize);
                    return false;
                }
            }
            else
            {
                Debug.LogError("board null");
                return false;
            }
        }

    }
}