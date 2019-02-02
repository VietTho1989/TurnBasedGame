using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataBoardUI : UIBehavior<GameDataBoardUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		
		public VP<ReferenceData<GameData>> gameData;

		#region AnimationManager

		public VP<AnimationManager> animationManager;

		#endregion

		#region Sub

		public abstract class Sub : Data
		{
			
			public abstract GameType.Type getType ();

			public abstract bool processEvent(Event e);

		}

		public VP<Sub> sub;

		#endregion

		#region Perspective

		public VP<Perspective> perspective;

		public VP<PerspectiveUI.UIData> perspectiveUIData;

		public static int getPlayerView(Data data)
		{
			UIData uiData = data.findDataInParent<UIData> ();
			if (uiData != null) {
				Perspective perspective = uiData.perspective.v;
				if (perspective != null) {
					return perspective.playerView.v;
				} else {
					Debug.LogError ("perspective null: " + data);
				}
			} else {
				Debug.LogError ("uiData null: " + data);
			}
			return 0;
		}

		#endregion

		public VP<UpdateTransform.UpdateData> updateTransform;

		#region Constructor

		public enum Property
		{
			gameData,
			animationManager,
			sub,
			perspective,
			perspectiveUIData,
			updateTransform
		}

		public UIData() : base()
		{
			this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
			this.animationManager = new VP<AnimationManager>(this, (byte)Property.animationManager, new AnimationManager());
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			this.perspective = new VP<Perspective>(this, (byte)Property.perspective, new Perspective());
			this.perspectiveUIData = new VP<PerspectiveUI.UIData>(this, (byte)Property.perspectiveUIData, new PerspectiveUI.UIData());
			this.updateTransform = new VP<UpdateTransform.UpdateData>(this, (byte)Property.updateTransform, new UpdateTransform.UpdateData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// sub
				if (!isProcess) {
					Sub sub = this.sub.v;
					if (sub != null) {
						isProcess = sub.processEvent (e);
					} else {
						Debug.LogError ("sub null: " + this);
					}
				}
			}
			return isProcess;
		}

		public void reset()
		{
			if (this.animationManager.v != null) {
				this.animationManager.v.reset ();
			} else {
				Debug.LogError ("animationManager null: " + this);
			}
		}

		public static MoveAnimation getCurrentMoveAnimation(Data data)
		{
			GameDataBoardUI.UIData gameDataBoardUIData = data.findDataInParent<GameDataBoardUI.UIData> ();
			if (gameDataBoardUIData != null) {
				AnimationManager animationManager = gameDataBoardUIData.animationManager.v;
				if (animationManager != null) {
					if (animationManager.animationProgresses.vs.Count > 0) {
						AnimationProgress animationProgres = animationManager.animationProgresses.vs [0];
						return animationProgres.moveAnimation.v.data;
					} else {
						
					}
				} else {
					Debug.LogError ("animationManager null: " + data);
				}
			} else {
				Debug.LogError ("gameDataBoardUIData null: " + data);
			}
			return null;
		}

		public static void getCurrentMoveAnimationInfo(Data data, out MoveAnimation moveAnimation, out float time, out float duration)
		{
			// init
			moveAnimation = null;
			time = 0;
			duration = 0;
			// Find
			GameDataBoardUI.UIData gameDataBoardUIData = data.findDataInParent<GameDataBoardUI.UIData> ();
			if (gameDataBoardUIData != null) {
				AnimationManager animationManager = gameDataBoardUIData.animationManager.v;
				if (animationManager != null) {
					if (animationManager.animationProgresses.vs.Count > 0) {
						AnimationProgress animationProgress = animationManager.animationProgresses.vs [0];
						// get info
						moveAnimation = animationProgress.moveAnimation.v.data;
						time = animationProgress.time.v;
						duration = animationProgress.duration.v;
						if (duration == 0) {
							Debug.LogError ("why duration = 0");
							// duration = 100 * AnimationManager.DefaultDuration;
							duration = 0.1f;
						}
						// reverse?
						{
							// find
							bool isReverse = animationProgress.isReverse;
							{
								/*Record.ViewRecordUI.UIData viewRecordUIData = data.findDataInParent<Record.ViewRecordUI.UIData> ();
								if (viewRecordUIData != null) {
									Record.ViewRecordControllerUI.UIData controller = viewRecordUIData.controller.v;
									if (controller != null) {
										if (controller.speed.v < 0) {
											isReverse = true;
										}
									} else {
										Debug.LogError ("controller null: " + data);
									}
								} else {
									Debug.LogError ("viewRecordUIData null: " + data);
								}*/
							}
							// process
							if (isReverse) {
								time = duration - time;
							}
						}
					}
					// correct time
					if (duration > 0) {
						time = Mathf.Clamp (time, 0, duration);
					} else {
						// Debug.LogError ("duration < 0: " + this);
					}
				} else {
					Debug.LogError ("animationManager null: " + data);
				}
			} else {
				Debug.LogError ("gameDataBoardUIData null: " + data);
			}
		}

		public static bool isOnAnimation(Data data)
		{
			GameDataBoardUI.UIData gameDataBoardUIData = data.findDataInParent<GameDataBoardUI.UIData> ();
			if (gameDataBoardUIData != null) {
				AnimationManager animationManager = gameDataBoardUIData.animationManager.v;
				if (animationManager != null) {
					return animationManager.isOnAnimation ();
				} else {
					Debug.LogError ("animationManager null: " + data);
				}
			} else {
				Debug.LogError ("gameDataBoardUIData null: " + data);
			}
			return false;
		}

	}

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GameData gameData = this.data.gameData.v.data;
                if (gameData != null)
                {
                    // check is load full
                    bool isLoadFull = true;
                    {
                        GameType gameType = gameData.gameType.v;
                        if (gameType != null)
                        {
                            if (gameType is Xiangqi.Xiangqi)
                            {
                                Xiangqi.Xiangqi xiangqi = gameType as Xiangqi.Xiangqi;
                                if (xiangqi.ucpcSquares.vs.Count == 0)
                                {
                                    Debug.LogError("xiangqi ucpcSquares count = 0");
                                    isLoadFull = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("gameType null");
                        }
                    }
                    // process
                    if (isLoadFull)
                    {
                        // Choose sub
                        {
                            if (gameData.gameType.v != null)
                            {
                                switch (gameData.gameType.v.getType())
                                {
                                    case GameType.Type.CHESS:
                                        {
                                            // UIData
                                            Chess.ChessGameDataUI.UIData chessGameDataUIData = this.data.sub.newOrOld<Chess.ChessGameDataUI.UIData>();
                                            {
                                                chessGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = chessGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Shatranj:
                                        {
                                            // UIData
                                            Shatranj.ShatranjGameDataUI.UIData shatranjGameDataUIData = this.data.sub.newOrOld<Shatranj.ShatranjGameDataUI.UIData>();
                                            {
                                                shatranjGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = shatranjGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Makruk:
                                        {
                                            // UIData
                                            Makruk.MakrukGameDataUI.UIData makrukGameDataUIData = this.data.sub.newOrOld<Makruk.MakrukGameDataUI.UIData>();
                                            {
                                                makrukGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = makrukGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Seirawan:
                                        {
                                            // UIData
                                            Seirawan.SeirawanGameDataUI.UIData seirawanGameDataUIData = this.data.sub.newOrOld<Seirawan.SeirawanGameDataUI.UIData>();
                                            {
                                                seirawanGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = seirawanGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.FairyChess:
                                        {
                                            // UIData
                                            FairyChess.FairyChessGameDataUI.UIData fairyChessGameDataUIData = this.data.sub.newOrOld<FairyChess.FairyChessGameDataUI.UIData>();
                                            {
                                                fairyChessGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = fairyChessGameDataUIData;
                                        }
                                        break;

                                    case GameType.Type.Xiangqi:
                                        {
                                            // UIData
                                            Xiangqi.XiangqiGameDataUI.UIData xiangqiGameDataUIData = this.data.sub.newOrOld<Xiangqi.XiangqiGameDataUI.UIData>();
                                            {
                                                xiangqiGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = xiangqiGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.CO_TUONG_UP:
                                        {
                                            // UIData
                                            CoTuongUp.CoTuongUpGameDataUI.UIData coTuongUpGameDataUIData = this.data.sub.newOrOld<CoTuongUp.CoTuongUpGameDataUI.UIData>();
                                            {
                                                coTuongUpGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = coTuongUpGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Janggi:
                                        {
                                            // UIData
                                            Janggi.JanggiGameDataUI.UIData janggiGameDataUIData = this.data.sub.newOrOld<Janggi.JanggiGameDataUI.UIData>();
                                            {
                                                janggiGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = janggiGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Banqi:
                                        {
                                            // UIData
                                            Banqi.BanqiGameDataUI.UIData banqiGameDataUIData = this.data.sub.newOrOld<Banqi.BanqiGameDataUI.UIData>();
                                            {
                                                banqiGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = banqiGameDataUIData;
                                        }
                                        break;

                                    case GameType.Type.Weiqi:
                                        {
                                            // UIData
                                            Weiqi.WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.sub.newOrOld<Weiqi.WeiqiGameDataUI.UIData>();
                                            {
                                                weiqiGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = weiqiGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.SHOGI:
                                        {
                                            // UIData
                                            Shogi.ShogiGameDataUI.UIData shogiGameDataUIData = this.data.sub.newOrOld<Shogi.ShogiGameDataUI.UIData>();
                                            {
                                                shogiGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = shogiGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.ROCK_SCISSOR_PAPER:
                                        {
                                            Debug.LogError("Can hoan thien: " + this);
                                        }
                                        break;
                                    case GameType.Type.Reversi:
                                        {
                                            // UIData
                                            Reversi.ReversiGameDataUI.UIData reversiGameDataUIData = this.data.sub.newOrOld<Reversi.ReversiGameDataUI.UIData>();
                                            {
                                                reversiGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = reversiGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Gomoku:
                                        {
                                            // UIData
                                            Gomoku.GomokuGameDataUI.UIData gomokuGameDataUIData = this.data.sub.newOrOld<Gomoku.GomokuGameDataUI.UIData>();
                                            {
                                                gomokuGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = gomokuGameDataUIData;
                                        }
                                        break;

                                    case GameType.Type.InternationalDraught:
                                        {
                                            // UIData
                                            InternationalDraught.InternationalDraughtGameDataUI.UIData internationalDraughtGameDataUIData = this.data.sub.newOrOld<InternationalDraught.InternationalDraughtGameDataUI.UIData>();
                                            {
                                                internationalDraughtGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = internationalDraughtGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.EnglishDraught:
                                        {
                                            // UIData
                                            EnglishDraught.EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = this.data.sub.newOrOld<EnglishDraught.EnglishDraughtGameDataUI.UIData>();
                                            {
                                                englishDraughtGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = englishDraughtGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.RussianDraught:
                                        {
                                            // UIData
                                            RussianDraught.RussianDraughtGameDataUI.UIData russianDraughtGameDataUIData = this.data.sub.newOrOld<RussianDraught.RussianDraughtGameDataUI.UIData>();
                                            {
                                                russianDraughtGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = russianDraughtGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.ChineseCheckers:
                                        {
                                            // UIData
                                            ChineseCheckers.ChineseCheckersGameDataUI.UIData chineseCheckersGameDataUIData = this.data.sub.newOrOld<ChineseCheckers.ChineseCheckersGameDataUI.UIData>();
                                            {
                                                chineseCheckersGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = chineseCheckersGameDataUIData;
                                        }
                                        break;

                                    case GameType.Type.MineSweeper:
                                        {
                                            // UIData
                                            MineSweeper.MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.sub.newOrOld<MineSweeper.MineSweeperGameDataUI.UIData>();
                                            {
                                                mineSweeperGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = mineSweeperGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Hex:
                                        {
                                            // UIData
                                            HEX.HexGameDataUI.UIData hexGameDataUIData = this.data.sub.newOrOld<HEX.HexGameDataUI.UIData>();
                                            {
                                                hexGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = hexGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Solitaire:
                                        {
                                            // UIData
                                            Solitaire.SolitaireGameDataUI.UIData solitaireGameDataUIData = this.data.sub.newOrOld<Solitaire.SolitaireGameDataUI.UIData>();
                                            {
                                                solitaireGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = solitaireGameDataUIData;
                                        }
                                        break;

                                    case GameType.Type.Sudoku:
                                        {
                                            // UIData
                                            Sudoku.SudokuGameDataUI.UIData sudokuGameDataUIData = this.data.sub.newOrOld<Sudoku.SudokuGameDataUI.UIData>();
                                            {
                                                sudokuGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = sudokuGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.Khet:
                                        {
                                            // UIData
                                            Khet.KhetGameDataUI.UIData khetGameDataUIData = this.data.sub.newOrOld<Khet.KhetGameDataUI.UIData>();
                                            {
                                                khetGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = khetGameDataUIData;
                                        }
                                        break;
                                    case GameType.Type.NineMenMorris:
                                        {
                                            // UIData
                                            NineMenMorris.NineMenMorrisGameDataUI.UIData nineMenMorrisGameDataUIData = this.data.sub.newOrOld<NineMenMorris.NineMenMorrisGameDataUI.UIData>();
                                            {
                                                nineMenMorrisGameDataUIData.gameData.v = new ReferenceData<GameData>(gameData);
                                            }
                                            this.data.sub.v = nineMenMorrisGameDataUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown gameType: " + gameData.gameType.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("why gameType null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("not load full");
                        dirty = true;
                    }
                }
                else
                {
                    Debug.LogError("gameData nul: " + this);
                }
                // Perspective
                {
                    if (this.data.perspectiveUIData.v != null)
                    {
                        this.data.perspectiveUIData.v.perspective.v = new ReferenceData<Perspective>(this.data.perspective.v);
                    }
                    else
                    {
                        // Debug.LogError ("perspectiveUIData null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public PerspectiveUI perspectiveUIPrefab;

	public Chess.ChessGameDataUI chessPrefab;
	public Shatranj.ShatranjGameDataUI shatranjPrefab;
	public Makruk.MakrukGameDataUI makrukPrefab;
	public Seirawan.SeirawanGameDataUI seirawanPrefab;
	public FairyChess.FairyChessGameDataUI fairyChessPrefab;

	public Xiangqi.XiangqiGameDataUI xiangqiPrefab;
	public CoTuongUp.CoTuongUpGameDataUI coTuongUpPrefab;
	public Janggi.JanggiGameDataUI janggiPrefab;
	public Banqi.BanqiGameDataUI banqiPrefab;

	public Weiqi.WeiqiGameDataUI weiqiPrefab;
	public Reversi.ReversiGameDataUI reversiPrefab;
	public Shogi.ShogiGameDataUI shogiPrefab;
	public Gomoku.GomokuGameDataUI gomokuPrefab;

	public InternationalDraught.InternationalDraughtGameDataUI internationalDraughtPrefab;
	public EnglishDraught.EnglishDraughtGameDataUI englishDraughtPrefab;
	public RussianDraught.RussianDraughtGameDataUI russianDraughtPrefab;
    public ChineseCheckers.ChineseCheckersGameDataUI chineseCheckersPrefab;

    public MineSweeper.MineSweeperGameDataUI mineSweeperPrefab;
	public HEX.HexGameDataUI hexPrefab;
	public Solitaire.SolitaireGameDataUI solitairePrefab;
	public Sudoku.SudokuGameDataUI sudokuPrefab;
	public Khet.KhetGameDataUI khetPrefab;
	public NineMenMorris.NineMenMorrisGameDataUI nineMenMorrisPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.animationManager.allAddCallBack (this);
				uiData.updateTransform.allAddCallBack (this);
				// Perspective
				{
					uiData.perspective.allAddCallBack (this);
					uiData.perspectiveUIData.allAddCallBack (this);
				}
				uiData.gameData.allAddCallBack(this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is UpdateTransform.UpdateData) {
				UpdateTransform.UpdateData updateTransformData = data as UpdateTransform.UpdateData;
				// Update
				{
					UpdateUtils.makeComponentUpdate<UpdateTransform, UpdateTransform.UpdateData> (updateTransformData, this.transform);
				}
				dirty = true;
				return;
			}
			// Perspective
			{
				if (data is Perspective) {
					Perspective perspective = data as Perspective;
					{
						UpdateUtils.makeUpdate<PerspectiveUpdate, Perspective> (perspective, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is PerspectiveUI.UIData) {
					PerspectiveUI.UIData perspectiveUIData = data as PerspectiveUI.UIData;
					// UI
					{
						UIUtils.Instantiate (perspectiveUIData, perspectiveUIPrefab, this.transform);
					}
					dirty = true;
					return;
				}
			}
			// Sub
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.ChessGameDataUI.UIData subUIData = sub as Chess.ChessGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, chessPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Shatranj:
                            {
                                Shatranj.ShatranjGameDataUI.UIData subUIData = sub as Shatranj.ShatranjGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, shatranjPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Makruk:
                            {
                                Makruk.MakrukGameDataUI.UIData subUIData = sub as Makruk.MakrukGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, makrukPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Seirawan:
                            {
                                Seirawan.SeirawanGameDataUI.UIData subUIData = sub as Seirawan.SeirawanGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, seirawanPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.FairyChessGameDataUI.UIData subUIData = sub as FairyChess.FairyChessGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, fairyChessPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.Xiangqi:
                            {
                                Xiangqi.XiangqiGameDataUI.UIData subUIData = sub as Xiangqi.XiangqiGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, xiangqiPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.CO_TUONG_UP:
                            {
                                CoTuongUp.CoTuongUpGameDataUI.UIData subUIData = sub as CoTuongUp.CoTuongUpGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, coTuongUpPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Janggi:
                            {
                                Janggi.JanggiGameDataUI.UIData subUIData = sub as Janggi.JanggiGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, janggiPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Banqi:
                            {
                                Banqi.BanqiGameDataUI.UIData subUIData = sub as Banqi.BanqiGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, banqiPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.Weiqi:
                            {
                                Weiqi.WeiqiGameDataUI.UIData subUIData = sub as Weiqi.WeiqiGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, weiqiPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.ROCK_SCISSOR_PAPER:
                            break;
                        case GameType.Type.Reversi:
                            {
                                Reversi.ReversiGameDataUI.UIData subUIData = sub as Reversi.ReversiGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, reversiPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.SHOGI:
                            {
                                Shogi.ShogiGameDataUI.UIData subUIData = sub as Shogi.ShogiGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, shogiPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Gomoku:
                            {
                                Gomoku.GomokuGameDataUI.UIData subUIData = sub as Gomoku.GomokuGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, gomokuPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.InternationalDraught:
                            {
                                InternationalDraught.InternationalDraughtGameDataUI.UIData subUIData = sub as InternationalDraught.InternationalDraughtGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, internationalDraughtPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                EnglishDraught.EnglishDraughtGameDataUI.UIData subUIData = sub as EnglishDraught.EnglishDraughtGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, englishDraughtPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                RussianDraught.RussianDraughtGameDataUI.UIData subUIData = sub as RussianDraught.RussianDraughtGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, russianDraughtPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.ChineseCheckers:
                            {
                                ChineseCheckers.ChineseCheckersGameDataUI.UIData subUIData = sub as ChineseCheckers.ChineseCheckersGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, chineseCheckersPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.MineSweeper:
                            {
                                MineSweeper.MineSweeperGameDataUI.UIData subUIData = sub as MineSweeper.MineSweeperGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, mineSweeperPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Hex:
                            {
                                HEX.HexGameDataUI.UIData subUIData = sub as HEX.HexGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, hexPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Solitaire:
                            {
                                Solitaire.SolitaireGameDataUI.UIData subUIData = sub as Solitaire.SolitaireGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, solitairePrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Sudoku:
                            {
                                Sudoku.SudokuGameDataUI.UIData subUIData = sub as Sudoku.SudokuGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, sudokuPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Khet:
                            {
                                Khet.KhetGameDataUI.UIData subUIData = sub as Khet.KhetGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, khetPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.NineMenMorris:
                            {
                                NineMenMorris.NineMenMorrisGameDataUI.UIData subUIData = sub as NineMenMorris.NineMenMorrisGameDataUI.UIData;
                                UIUtils.Instantiate(subUIData, nineMenMorrisPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
				dirty = true;
				return;
			}
			// GameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// Child
					{
						gameData.gameType.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is GameType) {
					dirty = true;
					return;
				}
			}
			if (data is AnimationManager) {
				AnimationManager animationManager = data as AnimationManager;
				// Update
				{
					UpdateUtils.makeUpdate<AnimationManagerUpdate, AnimationManager> (animationManager, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			{
				uiData.animationManager.allRemoveCallBack (this);
				uiData.updateTransform.allRemoveCallBack (this);
				// Perspective
				{
					uiData.perspective.allRemoveCallBack (this);
					uiData.perspectiveUIData.allRemoveCallBack (this);
				}
				uiData.gameData.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is UpdateTransform.UpdateData) {
				UpdateTransform.UpdateData updateTransformData = data as UpdateTransform.UpdateData;
				{
					updateTransformData.removeCallBackAndRemoveComponent (typeof(UpdateTransform));
				}
				return;
			}
			// Perspective
			{
				if (data is Perspective) {
					Perspective perspective = data as Perspective;
					{
						perspective.removeCallBackAndDestroy (typeof(PerspectiveUpdate));
					}
					return;
				}
				if (data is PerspectiveUI.UIData) {
					PerspectiveUI.UIData perspectiveUIData = data as PerspectiveUI.UIData;
					{
						perspectiveUIData.removeCallBackAndDestroy (typeof(PerspectiveUI));
					}
					return;
				}
			}
			// Sub
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.ChessGameDataUI.UIData subUIData = sub as Chess.ChessGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Chess.ChessGameDataUI));
                            }
                            break;
                        case GameType.Type.Shatranj:
                            {
                                Shatranj.ShatranjGameDataUI.UIData subUIData = sub as Shatranj.ShatranjGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Shatranj.ShatranjGameDataUI));
                            }
                            break;
                        case GameType.Type.Makruk:
                            {
                                Makruk.MakrukGameDataUI.UIData subUIData = sub as Makruk.MakrukGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Makruk.MakrukGameDataUI));
                            }
                            break;
                        case GameType.Type.Seirawan:
                            {
                                Seirawan.SeirawanGameDataUI.UIData subUIData = sub as Seirawan.SeirawanGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Seirawan.SeirawanGameDataUI));
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.FairyChessGameDataUI.UIData subUIData = sub as FairyChess.FairyChessGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(FairyChess.FairyChessGameDataUI));
                            }
                            break;

                        case GameType.Type.Xiangqi:
                            {
                                Xiangqi.XiangqiGameDataUI.UIData subUIData = sub as Xiangqi.XiangqiGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Xiangqi.XiangqiGameDataUI));
                            }
                            break;
                        case GameType.Type.CO_TUONG_UP:
                            {
                                CoTuongUp.CoTuongUpGameDataUI.UIData subUIData = sub as CoTuongUp.CoTuongUpGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(CoTuongUp.CoTuongUpGameDataUI));
                            }
                            break;
                        case GameType.Type.Janggi:
                            {
                                Janggi.JanggiGameDataUI.UIData subUIData = sub as Janggi.JanggiGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Janggi.JanggiGameDataUI));
                            }
                            break;
                        case GameType.Type.Banqi:
                            {
                                Banqi.BanqiGameDataUI.UIData subUIData = sub as Banqi.BanqiGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Banqi.BanqiGameDataUI));
                            }
                            break;

                        case GameType.Type.Weiqi:
                            {
                                Weiqi.WeiqiGameDataUI.UIData subUIData = sub as Weiqi.WeiqiGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Weiqi.WeiqiGameDataUI));
                            }
                            break;
                        case GameType.Type.ROCK_SCISSOR_PAPER:
                            break;
                        case GameType.Type.Reversi:
                            {
                                Reversi.ReversiGameDataUI.UIData subUIData = sub as Reversi.ReversiGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Reversi.ReversiGameDataUI));
                            }
                            break;
                        case GameType.Type.SHOGI:
                            {
                                Shogi.ShogiGameDataUI.UIData subUIData = sub as Shogi.ShogiGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Shogi.ShogiGameDataUI));
                            }
                            break;
                        case GameType.Type.Gomoku:
                            {
                                Gomoku.GomokuGameDataUI.UIData subUIData = sub as Gomoku.GomokuGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Gomoku.GomokuGameDataUI));
                            }
                            break;

                        case GameType.Type.InternationalDraught:
                            {
                                InternationalDraught.InternationalDraughtGameDataUI.UIData subUIData = sub as InternationalDraught.InternationalDraughtGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(InternationalDraught.InternationalDraughtGameDataUI));
                            }
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                EnglishDraught.EnglishDraughtGameDataUI.UIData subUIData = sub as EnglishDraught.EnglishDraughtGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(EnglishDraught.EnglishDraughtGameDataUI));
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                RussianDraught.RussianDraughtGameDataUI.UIData subUIData = sub as RussianDraught.RussianDraughtGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(RussianDraught.RussianDraughtGameDataUI));
                            }
                            break;
                        case GameType.Type.ChineseCheckers:
                            {
                                ChineseCheckers.ChineseCheckersGameDataUI.UIData subUIData = sub as ChineseCheckers.ChineseCheckersGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(ChineseCheckers.ChineseCheckersGameDataUI));
                            }
                            break;

                        case GameType.Type.MineSweeper:
                            {
                                MineSweeper.MineSweeperGameDataUI.UIData subUIData = sub as MineSweeper.MineSweeperGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(MineSweeper.MineSweeperGameDataUI));
                            }
                            break;
                        case GameType.Type.Hex:
                            {
                                HEX.HexGameDataUI.UIData subUIData = sub as HEX.HexGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(HEX.HexGameDataUI));
                            }
                            break;
                        case GameType.Type.Solitaire:
                            {
                                Solitaire.SolitaireGameDataUI.UIData subUIData = sub as Solitaire.SolitaireGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Solitaire.SolitaireGameDataUI));
                            }
                            break;
                        case GameType.Type.Sudoku:
                            {
                                Sudoku.SudokuGameDataUI.UIData subUIData = sub as Sudoku.SudokuGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Sudoku.SudokuGameDataUI));
                            }
                            break;
                        case GameType.Type.Khet:
                            {
                                Khet.KhetGameDataUI.UIData subUIData = sub as Khet.KhetGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(Khet.KhetGameDataUI));
                            }
                            break;
                        case GameType.Type.NineMenMorris:
                            {
                                NineMenMorris.NineMenMorrisGameDataUI.UIData subUIData = sub as NineMenMorris.NineMenMorrisGameDataUI.UIData;
                                subUIData.removeCallBackAndDestroy(typeof(NineMenMorris.NineMenMorrisGameDataUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
				return;
			}
			// GameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// Child
					{
						gameData.gameType.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is GameType) {
					return;
				}
			}
			if (data is AnimationManager) {
				AnimationManager animationManager = data as AnimationManager;
				// Update
				{
					animationManager.removeCallBackAndDestroy (typeof(AnimationManagerUpdate));
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.gameData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.animationManager:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.updateTransform:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.perspective:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.perspectiveUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.sub:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			// Perspective
			{
				if (wrapProperty.p is Perspective) {
					return;
				}
				if (wrapProperty.p is PerspectiveUI.UIData) {
					return;
				}
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
			if (wrapProperty.p is UpdateTransform.UpdateData) {
				return;
			}
			// GameData
			{
				if (wrapProperty.p is GameData) {
					switch ((GameData.Property)wrapProperty.n) {
					case GameData.Property.gameType:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case GameData.Property.useRule:
						break;
					case GameData.Property.turn:
						break;
					case GameData.Property.timeControl:
						break;
					case GameData.Property.lastMove:
						break;
					case GameData.Property.state:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is GameType) {
					return;
				}
			}
			if (wrapProperty.p is AnimationManager) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}