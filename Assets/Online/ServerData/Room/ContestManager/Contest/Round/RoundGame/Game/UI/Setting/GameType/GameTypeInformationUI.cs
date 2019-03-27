using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTypeInformationUI : UIHaveTransformDataBehavior<GameTypeInformationUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GameType>> gameType;

        #region sub

        public abstract class Sub : Data
        {

            public abstract GameType.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            gameType,
            sub
        }

        public UIData() : base()
        {
            this.gameType = new VP<ReferenceData<GameType>>(this, (byte)Property.gameType, new ReferenceData<GameType>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
            }
            return isProcess;
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
                GameType gameType = this.data.gameType.v.data;
                if (gameType != null)
                {
                    // sub
                    {
                        switch (gameType.getType())
                        {
                            case GameType.Type.CHESS:
                                {
                                    Chess.Chess chess = gameType as Chess.Chess;
                                    // make UI
                                    Chess.ChessInformationUI.UIData chessInformationUIData = this.data.sub.newOrOld<Chess.ChessInformationUI.UIData>();
                                    {
                                        chessInformationUIData.chess.v = new ReferenceData<Chess.Chess>(chess);
                                        chessInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = chessInformationUIData;
                                }
                                break;
                            case GameType.Type.FairyChess:
                                {
                                    FairyChess.FairyChess fairyChess = gameType as FairyChess.FairyChess;
                                    // make UI
                                    FairyChess.FairyChessInformationUI.UIData fairyChessInformationUIData = this.data.sub.newOrOld<FairyChess.FairyChessInformationUI.UIData>();
                                    {
                                        fairyChessInformationUIData.fairyChess.v = new ReferenceData<FairyChess.FairyChess>(fairyChess);
                                        fairyChessInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = fairyChessInformationUIData;
                                }
                                break;
                            case GameType.Type.Makruk:
                                {
                                    Makruk.Makruk makruk = gameType as Makruk.Makruk;
                                    // make UI
                                    Makruk.MakrukInformationUI.UIData makrukInformationUIData = this.data.sub.newOrOld<Makruk.MakrukInformationUI.UIData>();
                                    {
                                        makrukInformationUIData.makruk.v = new ReferenceData<Makruk.Makruk>(makruk);
                                        makrukInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = makrukInformationUIData;
                                }
                                break;
                            case GameType.Type.Seirawan:
                                {
                                    Seirawan.Seirawan seirawan = gameType as Seirawan.Seirawan;
                                    // make UI
                                    Seirawan.SeirawanInformationUI.UIData seirawanInformationUIData = this.data.sub.newOrOld<Seirawan.SeirawanInformationUI.UIData>();
                                    {
                                        seirawanInformationUIData.seirawan.v = new ReferenceData<Seirawan.Seirawan>(seirawan);
                                        seirawanInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = seirawanInformationUIData;
                                }
                                break;
                            case GameType.Type.Shatranj:
                                {
                                    Shatranj.Shatranj shatranj = gameType as Shatranj.Shatranj;
                                    // make UI
                                    Shatranj.ShatranjInformationUI.UIData shatranjInformationUIData = this.data.sub.newOrOld<Shatranj.ShatranjInformationUI.UIData>();
                                    {
                                        shatranjInformationUIData.shatranj.v = new ReferenceData<Shatranj.Shatranj>(shatranj);
                                        shatranjInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = shatranjInformationUIData;
                                }
                                break;

                            case GameType.Type.Banqi:
                                {
                                    Banqi.Banqi banqi = gameType as Banqi.Banqi;
                                    // make UI
                                    Banqi.BanqiInformationUI.UIData banqiInformationUIData = this.data.sub.newOrOld<Banqi.BanqiInformationUI.UIData>();
                                    {
                                        banqiInformationUIData.banqi.v = new ReferenceData<Banqi.Banqi>(banqi);
                                        banqiInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = banqiInformationUIData;
                                }
                                break;
                            case GameType.Type.CO_TUONG_UP:
                                {
                                    CoTuongUp.CoTuongUp coTuongUp = gameType as CoTuongUp.CoTuongUp;
                                    // make UI
                                    CoTuongUp.CoTuongUpInformationUI.UIData coTuongUpInformationUIData = this.data.sub.newOrOld<CoTuongUp.CoTuongUpInformationUI.UIData>();
                                    {
                                        coTuongUpInformationUIData.coTuongUp.v = new ReferenceData<CoTuongUp.CoTuongUp>(coTuongUp);
                                        coTuongUpInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = coTuongUpInformationUIData;
                                }
                                break;
                            case GameType.Type.Janggi:
                                {
                                    Janggi.Janggi janggi = gameType as Janggi.Janggi;
                                    // make UI
                                    Janggi.JanggiInformationUI.UIData janggiInformationUIData = this.data.sub.newOrOld<Janggi.JanggiInformationUI.UIData>();
                                    {
                                        janggiInformationUIData.janggi.v = new ReferenceData<Janggi.Janggi>(janggi);
                                        janggiInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = janggiInformationUIData;
                                }
                                break;
                            case GameType.Type.Xiangqi:
                                {
                                    Xiangqi.Xiangqi xiangqi = gameType as Xiangqi.Xiangqi;
                                    // make UI
                                    Xiangqi.XiangqiInformationUI.UIData xiangqiInformationUIData = this.data.sub.newOrOld<Xiangqi.XiangqiInformationUI.UIData>();
                                    {
                                        xiangqiInformationUIData.xiangqi.v = new ReferenceData<Xiangqi.Xiangqi>(xiangqi);
                                        xiangqiInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = xiangqiInformationUIData;
                                }
                                break;

                            case GameType.Type.ChineseCheckers:
                                {
                                    ChineseCheckers.ChineseCheckers chineseCheckers = gameType as ChineseCheckers.ChineseCheckers;
                                    // make UI
                                    ChineseCheckers.ChineseCheckersInformationUI.UIData chineseCheckersInformationUIData = this.data.sub.newOrOld<ChineseCheckers.ChineseCheckersInformationUI.UIData>();
                                    {
                                        chineseCheckersInformationUIData.chineseCheckers.v = new ReferenceData<ChineseCheckers.ChineseCheckers>(chineseCheckers);
                                        chineseCheckersInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = chineseCheckersInformationUIData;
                                }
                                break;
                            case GameType.Type.EnglishDraught:
                                {
                                    EnglishDraught.EnglishDraught englishDraught = gameType as EnglishDraught.EnglishDraught;
                                    // make UI
                                    EnglishDraught.EnglishDraughtInformationUI.UIData englishDraughtInformationUIData = this.data.sub.newOrOld<EnglishDraught.EnglishDraughtInformationUI.UIData>();
                                    {
                                        englishDraughtInformationUIData.englishDraught.v = new ReferenceData<EnglishDraught.EnglishDraught>(englishDraught);
                                        englishDraughtInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = englishDraughtInformationUIData;
                                }
                                break;
                            case GameType.Type.InternationalDraught:
                                {
                                    InternationalDraught.InternationalDraught internationalDraught = gameType as InternationalDraught.InternationalDraught;
                                    // make UI
                                    InternationalDraught.InternationalDraughtInformationUI.UIData internationalDraughtInformationUIData = this.data.sub.newOrOld<InternationalDraught.InternationalDraughtInformationUI.UIData>();
                                    {
                                        internationalDraughtInformationUIData.internationalDraught.v = new ReferenceData<InternationalDraught.InternationalDraught>(internationalDraught);
                                        internationalDraughtInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = internationalDraughtInformationUIData;
                                }
                                break;
                            case GameType.Type.RussianDraught:
                                {
                                    RussianDraught.RussianDraught russianDraught = gameType as RussianDraught.RussianDraught;
                                    // make UI
                                    RussianDraught.RussianDraughtInformationUI.UIData russianDraughtInformationUIData = this.data.sub.newOrOld<RussianDraught.RussianDraughtInformationUI.UIData>();
                                    {
                                        russianDraughtInformationUIData.russianDraught.v = new ReferenceData<RussianDraught.RussianDraught>(russianDraught);
                                        russianDraughtInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = russianDraughtInformationUIData;
                                }
                                break;

                            case GameType.Type.Gomoku:
                                {
                                    Gomoku.Gomoku gomoku = gameType as Gomoku.Gomoku;
                                    // make UI
                                    Gomoku.GomokuInformationUI.UIData gomokuInformationUIData = this.data.sub.newOrOld<Gomoku.GomokuInformationUI.UIData>();
                                    {
                                        gomokuInformationUIData.gomoku.v = new ReferenceData<Gomoku.Gomoku>(gomoku);
                                        gomokuInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = gomokuInformationUIData;
                                }
                                break;
                            case GameType.Type.Hex:
                                {
                                    HEX.Hex hex = gameType as HEX.Hex;
                                    // make UI
                                    HEX.HexInformationUI.UIData hexInformationUIData = this.data.sub.newOrOld<HEX.HexInformationUI.UIData>();
                                    {
                                        hexInformationUIData.hex.v = new ReferenceData<HEX.Hex>(hex);
                                        hexInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = hexInformationUIData;
                                }
                                break;
                            case GameType.Type.Khet:
                                {
                                    Khet.Khet khet = gameType as Khet.Khet;
                                    // make UI
                                    Khet.KhetInformationUI.UIData khetInformationUIData = this.data.sub.newOrOld<Khet.KhetInformationUI.UIData>();
                                    {
                                        khetInformationUIData.khet.v = new ReferenceData<Khet.Khet>(khet);
                                        khetInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = khetInformationUIData;
                                }
                                break;
                            case GameType.Type.MineSweeper:
                                {
                                    MineSweeper.MineSweeper mineSweeper = gameType as MineSweeper.MineSweeper;
                                    // make UI
                                    MineSweeper.MineSweeperInformationUI.UIData mineSweeperInformationUIData = this.data.sub.newOrOld<MineSweeper.MineSweeperInformationUI.UIData>();
                                    {
                                        mineSweeperInformationUIData.mineSweeper.v = new ReferenceData<MineSweeper.MineSweeper>(mineSweeper);
                                        mineSweeperInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = mineSweeperInformationUIData;
                                }
                                break;
                            case GameType.Type.NineMenMorris:
                                {
                                    NineMenMorris.NineMenMorris nineMenMorris = gameType as NineMenMorris.NineMenMorris;
                                    // make UI
                                    NineMenMorris.NineMenMorrisInformationUI.UIData nineMenMorrisInformationUIData = this.data.sub.newOrOld<NineMenMorris.NineMenMorrisInformationUI.UIData>();
                                    {
                                        nineMenMorrisInformationUIData.nineMenMorris.v = new ReferenceData<NineMenMorris.NineMenMorris>(nineMenMorris);
                                        nineMenMorrisInformationUIData.showType.v = UIRectTransform.ShowType.Normal;
                                    }
                                    this.data.sub.v = nineMenMorrisInformationUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + gameType.getType());
                                break;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // sub
                        {
                            float height = UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                            deltaY += height;
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                }
                else
                {
                    Debug.LogError("gameType null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public Chess.ChessInformationUI chessInformationPrefab;
    public FairyChess.FairyChessInformationUI fairyChessInformationPrefab;
    public Makruk.MakrukInformationUI makrukInformationPrefab;
    public Seirawan.SeirawanInformationUI seirawanInformationPrefab;
    public Shatranj.ShatranjInformationUI shatranjInformationPrefab;

    public Banqi.BanqiInformationUI banqiInformationPrefab;
    public CoTuongUp.CoTuongUpInformationUI coTuongUpInformationPrefab;
    public Janggi.JanggiInformationUI janggiInformationPrefab;
    public Xiangqi.XiangqiInformationUI xiangqiInformationPrefab;

    public ChineseCheckers.ChineseCheckersInformationUI chineseCheckersInformationPrefab;
    public EnglishDraught.EnglishDraughtInformationUI englishDraughtInformationPrefab;
    public InternationalDraught.InternationalDraughtInformationUI internationalDraughtInformationPrefab;
    public RussianDraught.RussianDraughtInformationUI russianDraughtInformationPrefab;

    public Gomoku.GomokuInformationUI gomokuInformationPrefab;
    public HEX.HexInformationUI hexInformationPrefab;
    public Khet.KhetInformationUI khetInformationPrefab;
    public MineSweeper.MineSweeperInformationUI mineSweeperInformationPrefab;
    public NineMenMorris.NineMenMorrisInformationUI nineMenMorrisInformationPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.ChessInformationUI.UIData chessInformationUIData = sub as Chess.ChessInformationUI.UIData;
                                UIUtils.Instantiate(chessInformationUIData, chessInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.FairyChessInformationUI.UIData fairyChessInformationUIData = sub as FairyChess.FairyChessInformationUI.UIData;
                                UIUtils.Instantiate(fairyChessInformationUIData, fairyChessInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Makruk:
                            {
                                Makruk.MakrukInformationUI.UIData makrukInformationUIData = sub as Makruk.MakrukInformationUI.UIData;
                                UIUtils.Instantiate(makrukInformationUIData, makrukInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Seirawan:
                            {
                                Seirawan.SeirawanInformationUI.UIData seirawanInformationUIData = sub as Seirawan.SeirawanInformationUI.UIData;
                                UIUtils.Instantiate(seirawanInformationUIData, seirawanInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Shatranj:
                            {
                                Shatranj.ShatranjInformationUI.UIData shatranjInformationUIData = sub as Shatranj.ShatranjInformationUI.UIData;
                                UIUtils.Instantiate(shatranjInformationUIData, shatranjInformationPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.Banqi:
                            {
                                Banqi.BanqiInformationUI.UIData banqiInformationUIData = sub as Banqi.BanqiInformationUI.UIData;
                                UIUtils.Instantiate(banqiInformationUIData, banqiInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.CO_TUONG_UP:
                            {
                                CoTuongUp.CoTuongUpInformationUI.UIData coTuongUpInformationUIData = sub as CoTuongUp.CoTuongUpInformationUI.UIData;
                                UIUtils.Instantiate(coTuongUpInformationUIData, coTuongUpInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Janggi:
                            {
                                Janggi.JanggiInformationUI.UIData janggiInformationUIData = sub as Janggi.JanggiInformationUI.UIData;
                                UIUtils.Instantiate(janggiInformationUIData, janggiInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Xiangqi:
                            {
                                Xiangqi.XiangqiInformationUI.UIData xiangqiInformationUIData = sub as Xiangqi.XiangqiInformationUI.UIData;
                                UIUtils.Instantiate(xiangqiInformationUIData, xiangqiInformationPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.ChineseCheckers:
                            {
                                ChineseCheckers.ChineseCheckersInformationUI.UIData chineseCheckersInformationUIData = sub as ChineseCheckers.ChineseCheckersInformationUI.UIData;
                                UIUtils.Instantiate(chineseCheckersInformationUIData, chineseCheckersInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                EnglishDraught.EnglishDraughtInformationUI.UIData englishDraughtInformationUIData = sub as EnglishDraught.EnglishDraughtInformationUI.UIData;
                                UIUtils.Instantiate(englishDraughtInformationUIData, englishDraughtInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.InternationalDraught:
                            {
                                InternationalDraught.InternationalDraughtInformationUI.UIData internationalDraughtInformationUIData = sub as InternationalDraught.InternationalDraughtInformationUI.UIData;
                                UIUtils.Instantiate(internationalDraughtInformationUIData, internationalDraughtInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                RussianDraught.RussianDraughtInformationUI.UIData russianDraughtInformationUIData = sub as RussianDraught.RussianDraughtInformationUI.UIData;
                                UIUtils.Instantiate(russianDraughtInformationUIData, russianDraughtInformationPrefab, this.transform);
                            }
                            break;

                        case GameType.Type.Gomoku:
                            {
                                Gomoku.GomokuInformationUI.UIData gomokuInformationUIData = sub as Gomoku.GomokuInformationUI.UIData;
                                UIUtils.Instantiate(gomokuInformationUIData, gomokuInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Hex:
                            {
                                HEX.HexInformationUI.UIData hexInformationUIData = sub as HEX.HexInformationUI.UIData;
                                UIUtils.Instantiate(hexInformationUIData, hexInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.Khet:
                            {
                                Khet.KhetInformationUI.UIData khetInformationUIData = sub as Khet.KhetInformationUI.UIData;
                                UIUtils.Instantiate(khetInformationUIData, khetInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.MineSweeper:
                            {
                                MineSweeper.MineSweeperInformationUI.UIData mineSweeperInformationUIData = sub as MineSweeper.MineSweeperInformationUI.UIData;
                                UIUtils.Instantiate(mineSweeperInformationUIData, mineSweeperInformationPrefab, this.transform);
                            }
                            break;
                        case GameType.Type.NineMenMorris:
                            {
                                NineMenMorris.NineMenMorrisInformationUI.UIData nineMenMorrisInformationUIData = sub as NineMenMorris.NineMenMorrisInformationUI.UIData;
                                UIUtils.Instantiate(nineMenMorrisInformationUIData, nineMenMorrisInformationPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                // Child
                {
                    TransformData.AddCallBack(sub, this);
                }
                dirty = true;
                return;
            }
            // Child
            if(data is TransformData)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // Child
                {
                    TransformData.RemoveCallBack(sub, this);
                }
                // UI
                {
                    switch (sub.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.ChessInformationUI.UIData chessInformationUIData = sub as Chess.ChessInformationUI.UIData;
                                chessInformationUIData.removeCallBackAndDestroy(typeof(Chess.ChessInformationUI));
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.FairyChessInformationUI.UIData fairyChessInformationUIData = sub as FairyChess.FairyChessInformationUI.UIData;
                                fairyChessInformationUIData.removeCallBackAndDestroy(typeof(FairyChess.FairyChessInformationUI));
                            }
                            break;
                        case GameType.Type.Makruk:
                            {
                                Makruk.MakrukInformationUI.UIData makrukInformationUIData = sub as Makruk.MakrukInformationUI.UIData;
                                makrukInformationUIData.removeCallBackAndDestroy(typeof(Makruk.MakrukInformationUI));
                            }
                            break;
                        case GameType.Type.Seirawan:
                            {
                                Seirawan.SeirawanInformationUI.UIData seirawanInformationUIData = sub as Seirawan.SeirawanInformationUI.UIData;
                                seirawanInformationUIData.removeCallBackAndDestroy(typeof(Seirawan.SeirawanInformationUI));
                            }
                            break;
                        case GameType.Type.Shatranj:
                            {
                                Shatranj.ShatranjInformationUI.UIData shatranjInformationUIData = sub as Shatranj.ShatranjInformationUI.UIData;
                                shatranjInformationUIData.removeCallBackAndDestroy(typeof(Shatranj.ShatranjInformationUI));
                            }
                            break;

                        case GameType.Type.Banqi:
                            {
                                Banqi.BanqiInformationUI.UIData banqiInformationUIData = sub as Banqi.BanqiInformationUI.UIData;
                                banqiInformationUIData.removeCallBackAndDestroy(typeof(Banqi.BanqiInformationUI));
                            }
                            break;
                        case GameType.Type.CO_TUONG_UP:
                            {
                                CoTuongUp.CoTuongUpInformationUI.UIData coTuongUpInformationUIData = sub as CoTuongUp.CoTuongUpInformationUI.UIData;
                                coTuongUpInformationUIData.removeCallBackAndDestroy(typeof(CoTuongUp.CoTuongUpInformationUI));
                            }
                            break;
                        case GameType.Type.Janggi:
                            {
                                Janggi.JanggiInformationUI.UIData janggiInformationUIData = sub as Janggi.JanggiInformationUI.UIData;
                                janggiInformationUIData.removeCallBackAndDestroy(typeof(Janggi.JanggiInformationUI));
                            }
                            break;
                        case GameType.Type.Xiangqi:
                            {
                                Xiangqi.XiangqiInformationUI.UIData xiangqiInformationUIData = sub as Xiangqi.XiangqiInformationUI.UIData;
                                xiangqiInformationUIData.removeCallBackAndDestroy(typeof(Xiangqi.XiangqiInformationUI));
                            }
                            break;

                        case GameType.Type.ChineseCheckers:
                            {
                                ChineseCheckers.ChineseCheckersInformationUI.UIData chineseCheckersInformationUIData = sub as ChineseCheckers.ChineseCheckersInformationUI.UIData;
                                chineseCheckersInformationUIData.removeCallBackAndDestroy(typeof(ChineseCheckers.ChineseCheckersInformationUI));
                            }
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                EnglishDraught.EnglishDraughtInformationUI.UIData englishDraughtInformationUIData = sub as EnglishDraught.EnglishDraughtInformationUI.UIData;
                                englishDraughtInformationUIData.removeCallBackAndDestroy(typeof(EnglishDraught.EnglishDraughtInformationUI));
                            }
                            break;
                        case GameType.Type.InternationalDraught:
                            {
                                InternationalDraught.InternationalDraughtInformationUI.UIData internationalDraughtInformationUIData = sub as InternationalDraught.InternationalDraughtInformationUI.UIData;
                                internationalDraughtInformationUIData.removeCallBackAndDestroy(typeof(InternationalDraught.InternationalDraughtInformationUI));
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                RussianDraught.RussianDraughtInformationUI.UIData russianDraughtInformationUIData = sub as RussianDraught.RussianDraughtInformationUI.UIData;
                                russianDraughtInformationUIData.removeCallBackAndDestroy(typeof(RussianDraught.RussianDraughtInformationUI));
                            }
                            break;

                        case GameType.Type.Gomoku:
                            {
                                Gomoku.GomokuInformationUI.UIData gomokuInformationUIData = sub as Gomoku.GomokuInformationUI.UIData;
                                gomokuInformationUIData.removeCallBackAndDestroy(typeof(Gomoku.GomokuInformationUI));
                            }
                            break;
                        case GameType.Type.Hex:
                            {
                                HEX.HexInformationUI.UIData hexInformationUIData = sub as HEX.HexInformationUI.UIData;
                                hexInformationUIData.removeCallBackAndDestroy(typeof(HEX.HexInformationUI));
                            }
                            break;
                        case GameType.Type.Khet:
                            {
                                Khet.KhetInformationUI.UIData khetInformationUIData = sub as Khet.KhetInformationUI.UIData;
                                khetInformationUIData.removeCallBackAndDestroy(typeof(Khet.KhetInformationUI));
                            }
                            break;
                        case GameType.Type.MineSweeper:
                            {
                                MineSweeper.MineSweeperInformationUI.UIData mineSweeperInformationUIData = sub as MineSweeper.MineSweeperInformationUI.UIData;
                                mineSweeperInformationUIData.removeCallBackAndDestroy(typeof(MineSweeper.MineSweeperInformationUI));
                            }
                            break;
                        case GameType.Type.NineMenMorris:
                            {
                                NineMenMorris.NineMenMorrisInformationUI.UIData nineMenMorrisInformationUIData = sub as NineMenMorris.NineMenMorrisInformationUI.UIData;
                                nineMenMorrisInformationUIData.removeCallBackAndDestroy(typeof(NineMenMorris.NineMenMorrisInformationUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType());
                            break;
                    }
                }
                return;
            }
            // Child
            if (data is TransformData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.gameType:
                    dirty = true;
                    break;
                case UIData.Property.sub:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            // Child
            if (wrapProperty.p is TransformData)
            {
                switch ((TransformData.Property)wrapProperty.n)
                {
                    case TransformData.Property.anchoredPosition:
                        break;
                    case TransformData.Property.anchorMin:
                        break;
                    case TransformData.Property.anchorMax:
                        break;
                    case TransformData.Property.pivot:
                        break;
                    case TransformData.Property.offsetMin:
                        break;
                    case TransformData.Property.offsetMax:
                        break;
                    case TransformData.Property.sizeDelta:
                        break;
                    case TransformData.Property.rotation:
                        break;
                    case TransformData.Property.scale:
                        break;
                    case TransformData.Property.size:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}