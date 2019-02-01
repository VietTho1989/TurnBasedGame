using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DefaultGameDataFactoryUI : UIBehavior<DefaultGameDataFactoryUI.UIData>
{

    #region UIData

    public class UIData : GameFactoryUI.UIData.GameDataFactoryUIData
    {

        public VP<EditData<DefaultGameDataFactory>> editDefaultGameDataFactory;

        #region gameType

        public VP<RequestChangeEnumUI.UIData> gameType;

        public void makeRequestChangeGameType(RequestChangeUpdate<int>.UpdateData update, int newGameType)
        {
            // Find
            DefaultGameDataFactory defaultGameDataFactory = null;
            {
                EditData<DefaultGameDataFactory> editDefaultGameDataFactory = this.editDefaultGameDataFactory.v;
                if (editDefaultGameDataFactory != null)
                {
                    defaultGameDataFactory = editDefaultGameDataFactory.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultGameDataFactory null: " + this);
                }
            }
            // Process
            if (defaultGameDataFactory != null)
            {
                // Find gameTypeType
                GameType.Type gameTypeType = GameType.Type.Xiangqi;
                {
                    if (newGameType >= 0 && newGameType < GameType.EnableTypes.Length)
                    {
                        gameTypeType = GameType.EnableTypes[newGameType];
                    }
                }
                defaultGameDataFactory.requestChangeGameType(Server.getProfileUserId(defaultGameDataFactory), gameTypeType);
            }
            else
            {
                Debug.LogError("defaultGameDataFactory null: " + this);
            }
        }

        #endregion

        public VP<DefaultGameTypeUI> defaultGameTypeUI;

        #region useRule

        public VP<RequestChangeBoolUI.UIData> useRule;

        public void makeRequestChangeUseRule(RequestChangeUpdate<bool>.UpdateData update, bool newUseRule)
        {
            // Find
            DefaultGameDataFactory defaultGameDataFactory = null;
            {
                EditData<DefaultGameDataFactory> editDefaultGameDataFactory = this.editDefaultGameDataFactory.v;
                if (editDefaultGameDataFactory != null)
                {
                    defaultGameDataFactory = editDefaultGameDataFactory.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultGameDataFactory null: " + this);
                }
            }
            // Process
            if (defaultGameDataFactory != null)
            {
                defaultGameDataFactory.requestChangeUseRule(Server.getProfileUserId(defaultGameDataFactory), newUseRule);
            }
            else
            {
                Debug.LogError("defaultGameDataFactory null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editDefaultGameDataFactory,
            gameType,
            defaultGameTypeUI,
            useRule
        }

        public UIData() : base()
        {
            this.editDefaultGameDataFactory = new VP<EditData<DefaultGameDataFactory>>(this, (byte)Property.editDefaultGameDataFactory, new EditData<DefaultGameDataFactory>());
            // gameType
            {
                this.gameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.gameType, new RequestChangeEnumUI.UIData());
                // event
                this.gameType.v.updateData.v.request.v = makeRequestChangeGameType;
                {
                    for (int i = 0; i < GameType.EnableTypes.Length; i++)
                    {
                        this.gameType.v.options.add(GameType.EnableTypes[i].ToString());
                    }
                }
            }
            this.defaultGameTypeUI = new VP<DefaultGameTypeUI>(this, (byte)Property.defaultGameTypeUI, null);
            // useRule
            {
                this.useRule = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useRule, new RequestChangeBoolUI.UIData());
                // event
                this.useRule.v.updateData.v.request.v = makeRequestChangeUseRule;
            }
        }

        #endregion

        public override GameDataFactory.Type getType()
        {
            return GameDataFactory.Type.Default;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

    }

    #endregion

    #region Refresh

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text lbGameType;
    public static readonly TxtLanguage txtGameType = new TxtLanguage();

    public Text lbUseRule;
    public static readonly TxtLanguage txtUseRule = new TxtLanguage();

    static DefaultGameDataFactoryUI()
    {
        txtTitle.add(Language.Type.vi, "Cách Tạo Dữ Liệu Game Mặc Định");
        txtGameType.add(Language.Type.vi, "Loại game");
        txtUseRule.add(Language.Type.vi, "Dùng luật");
    }

    #endregion

    private bool needReset = true;
    public GameObject differentIndicator;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<DefaultGameDataFactory> editDefaultGameDataFactory = this.data.editDefaultGameDataFactory.v;
                if (editDefaultGameDataFactory != null)
                {
                    editDefaultGameDataFactory.update();
                    // get show
                    DefaultGameDataFactory show = editDefaultGameDataFactory.show.v.data;
                    DefaultGameDataFactory compare = editDefaultGameDataFactory.compare.v.data;
                    if (show != null)
                    {
                        // differentIndicator
                        if (differentIndicator != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editDefaultGameDataFactory.compareOtherType.v.data != null)
                                {
                                    if (editDefaultGameDataFactory.compareOtherType.v.data.GetType() != show.GetType())
                                    {
                                        isDifferent = true;
                                    }
                                }
                            }
                            differentIndicator.SetActive(isDifferent);
                        }
                        else
                        {
                            Debug.LogError("differentIndicator null: " + this);
                        }
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            {
                                Server server = show.findDataInParent<Server>();
                                if (server != null)
                                {
                                    if (server.state.v != null)
                                    {
                                        serverState = server.state.v.getType();
                                    }
                                    else
                                    {
                                        Debug.LogError("server state null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("server null: " + this);
                                }
                            }
                            // set origin
                            {
                                // gameType
                                {
                                    RequestChangeEnumUI.UIData gameType = this.data.gameType.v;
                                    if (gameType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = gameType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = GameType.getEnableIndex(show.getGameTypeType());
                                            updateData.canRequestChange.v = editDefaultGameDataFactory.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                gameType.showDifferent.v = true;
                                                gameType.compare.v = GameType.getEnableIndex(compare.getGameTypeType());
                                            }
                                            else
                                            {
                                                gameType.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameType null: " + this);
                                    }
                                }
                                // defaultGameTypeUI
                                {
                                    DefaultGameType defaultGameType = show.defaultGameType.v;
                                    if (defaultGameType != null)
                                    {
                                        // find origin 
                                        DefaultGameType originDefaultGameType = null;
                                        {
                                            if (editDefaultGameDataFactory.origin.v.data != null)
                                            {
                                                originDefaultGameType = editDefaultGameDataFactory.origin.v.data.defaultGameType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("origin null: " + this);
                                            }
                                        }
                                        // find compare
                                        DefaultGameType compareDefaultGameType = null;
                                        {
                                            if (compare != null)
                                            {
                                                compareDefaultGameType = compare.defaultGameType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("compare null: " + this);
                                            }
                                        }
                                        // process
                                        switch (defaultGameType.getType())
                                        {
                                            case GameType.Type.CHESS:
                                                {
                                                    Chess.DefaultChess defaultChess = defaultGameType as Chess.DefaultChess;
                                                    // UIData
                                                    Chess.DefaultChessUI.UIData defaultChessUIData = this.data.defaultGameTypeUI.newOrOld<Chess.DefaultChessUI.UIData>();
                                                    {
                                                        EditData<Chess.DefaultChess> editDefaultChess = defaultChessUIData.editDefaultChess.v;
                                                        if (editDefaultChess != null)
                                                        {
                                                            // origin
                                                            editDefaultChess.origin.v = new ReferenceData<Chess.DefaultChess>((Chess.DefaultChess)originDefaultGameType);
                                                            // show
                                                            editDefaultChess.show.v = new ReferenceData<Chess.DefaultChess>(defaultChess);
                                                            // compare
                                                            editDefaultChess.compare.v = new ReferenceData<Chess.DefaultChess>((Chess.DefaultChess)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultChess.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultChess.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultChess null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultChessUIData;
                                                }
                                                break;
                                            case GameType.Type.Shatranj:
                                                {
                                                    Shatranj.DefaultShatranj defaultShatranj = defaultGameType as Shatranj.DefaultShatranj;
                                                    // UIData
                                                    Shatranj.DefaultShatranjUI.UIData defaultShatranjUIData = this.data.defaultGameTypeUI.newOrOld<Shatranj.DefaultShatranjUI.UIData>();
                                                    {
                                                        EditData<Shatranj.DefaultShatranj> editDefaultShatranj = defaultShatranjUIData.editDefaultShatranj.v;
                                                        if (editDefaultShatranj != null)
                                                        {
                                                            // origin
                                                            editDefaultShatranj.origin.v = new ReferenceData<Shatranj.DefaultShatranj>((Shatranj.DefaultShatranj)originDefaultGameType);
                                                            // show
                                                            editDefaultShatranj.show.v = new ReferenceData<Shatranj.DefaultShatranj>(defaultShatranj);
                                                            // compare
                                                            editDefaultShatranj.compare.v = new ReferenceData<Shatranj.DefaultShatranj>((Shatranj.DefaultShatranj)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultShatranj.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultShatranj.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultShatranj null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultShatranjUIData;
                                                }
                                                break;
                                            case GameType.Type.Makruk:
                                                {
                                                    Makruk.DefaultMakruk defaultMakruk = defaultGameType as Makruk.DefaultMakruk;
                                                    // UIData
                                                    Makruk.DefaultMakrukUI.UIData defaultMakrukUIData = this.data.defaultGameTypeUI.newOrOld<Makruk.DefaultMakrukUI.UIData>();
                                                    {
                                                        EditData<Makruk.DefaultMakruk> editDefaultMakruk = defaultMakrukUIData.editDefaultMakruk.v;
                                                        if (editDefaultMakruk != null)
                                                        {
                                                            // origin
                                                            editDefaultMakruk.origin.v = new ReferenceData<Makruk.DefaultMakruk>((Makruk.DefaultMakruk)originDefaultGameType);
                                                            // show
                                                            editDefaultMakruk.show.v = new ReferenceData<Makruk.DefaultMakruk>(defaultMakruk);
                                                            // compare
                                                            editDefaultMakruk.compare.v = new ReferenceData<Makruk.DefaultMakruk>((Makruk.DefaultMakruk)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultMakruk.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultMakruk.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultMakruk null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultMakrukUIData;
                                                }
                                                break;
                                            case GameType.Type.Seirawan:
                                                {
                                                    Seirawan.DefaultSeirawan defaultSeirawan = defaultGameType as Seirawan.DefaultSeirawan;
                                                    // UIData
                                                    Seirawan.DefaultSeirawanUI.UIData defaultSeirawanUIData = this.data.defaultGameTypeUI.newOrOld<Seirawan.DefaultSeirawanUI.UIData>();
                                                    {
                                                        EditData<Seirawan.DefaultSeirawan> editDefaultSeirawan = defaultSeirawanUIData.editDefaultSeirawan.v;
                                                        if (editDefaultSeirawan != null)
                                                        {
                                                            // origin
                                                            editDefaultSeirawan.origin.v = new ReferenceData<Seirawan.DefaultSeirawan>((Seirawan.DefaultSeirawan)originDefaultGameType);
                                                            // show
                                                            editDefaultSeirawan.show.v = new ReferenceData<Seirawan.DefaultSeirawan>(defaultSeirawan);
                                                            // compare
                                                            editDefaultSeirawan.compare.v = new ReferenceData<Seirawan.DefaultSeirawan>((Seirawan.DefaultSeirawan)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultSeirawan.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultSeirawan.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultSeirawan null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultSeirawanUIData;
                                                }
                                                break;
                                            case GameType.Type.FairyChess:
                                                {
                                                    FairyChess.DefaultFairyChess defaultFairyChess = defaultGameType as FairyChess.DefaultFairyChess;
                                                    // UIData
                                                    FairyChess.DefaultFairyChessUI.UIData defaultFairyChessUIData = this.data.defaultGameTypeUI.newOrOld<FairyChess.DefaultFairyChessUI.UIData>();
                                                    {
                                                        EditData<FairyChess.DefaultFairyChess> editDefaultFairyChess = defaultFairyChessUIData.editDefaultFairyChess.v;
                                                        if (editDefaultFairyChess != null)
                                                        {
                                                            // origin
                                                            editDefaultFairyChess.origin.v = new ReferenceData<FairyChess.DefaultFairyChess>((FairyChess.DefaultFairyChess)originDefaultGameType);
                                                            // show
                                                            editDefaultFairyChess.show.v = new ReferenceData<FairyChess.DefaultFairyChess>(defaultFairyChess);
                                                            // compare
                                                            editDefaultFairyChess.compare.v = new ReferenceData<FairyChess.DefaultFairyChess>((FairyChess.DefaultFairyChess)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultFairyChess.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultFairyChess.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultFairyChess null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultFairyChessUIData;
                                                }
                                                break;

                                            case GameType.Type.Xiangqi:
                                                {
                                                    Xiangqi.DefaultXiangqi defaultXiangqi = defaultGameType as Xiangqi.DefaultXiangqi;
                                                    // UIData
                                                    Xiangqi.DefaultXiangqiUI.UIData defaultXiangqiUIData = this.data.defaultGameTypeUI.newOrOld<Xiangqi.DefaultXiangqiUI.UIData>();
                                                    {
                                                        EditData<Xiangqi.DefaultXiangqi> editDefaultXiangqi = defaultXiangqiUIData.editDefaultXiangqi.v;
                                                        if (editDefaultXiangqi != null)
                                                        {
                                                            // origin
                                                            editDefaultXiangqi.origin.v = new ReferenceData<Xiangqi.DefaultXiangqi>((Xiangqi.DefaultXiangqi)originDefaultGameType);
                                                            // show
                                                            editDefaultXiangqi.show.v = new ReferenceData<Xiangqi.DefaultXiangqi>(defaultXiangqi);
                                                            // compare
                                                            editDefaultXiangqi.compare.v = new ReferenceData<Xiangqi.DefaultXiangqi>((Xiangqi.DefaultXiangqi)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultXiangqi.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultXiangqi.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultXiangqi null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultXiangqiUIData;
                                                }
                                                break;
                                            case GameType.Type.CO_TUONG_UP:
                                                {
                                                    CoTuongUp.DefaultCoTuongUp defaultCoTuongUp = defaultGameType as CoTuongUp.DefaultCoTuongUp;
                                                    // UIData
                                                    CoTuongUp.DefaultCoTuongUpUI.UIData defaultCoTuongUpUIData = this.data.defaultGameTypeUI.newOrOld<CoTuongUp.DefaultCoTuongUpUI.UIData>();
                                                    {
                                                        EditData<CoTuongUp.DefaultCoTuongUp> editDefaultCoTuongUp = defaultCoTuongUpUIData.editDefaultCoTuongUp.v;
                                                        if (editDefaultCoTuongUp != null)
                                                        {
                                                            // origin
                                                            editDefaultCoTuongUp.origin.v = new ReferenceData<CoTuongUp.DefaultCoTuongUp>((CoTuongUp.DefaultCoTuongUp)originDefaultGameType);
                                                            // show
                                                            editDefaultCoTuongUp.show.v = new ReferenceData<CoTuongUp.DefaultCoTuongUp>(defaultCoTuongUp);
                                                            // compare
                                                            editDefaultCoTuongUp.compare.v = new ReferenceData<CoTuongUp.DefaultCoTuongUp>((CoTuongUp.DefaultCoTuongUp)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultCoTuongUp.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultCoTuongUp.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultCoTuongUp null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultCoTuongUpUIData;
                                                }
                                                break;
                                            case GameType.Type.Janggi:
                                                {
                                                    Janggi.DefaultJanggi defaultJanggi = defaultGameType as Janggi.DefaultJanggi;
                                                    // UIData
                                                    Janggi.DefaultJanggiUI.UIData defaultJanggiUIData = this.data.defaultGameTypeUI.newOrOld<Janggi.DefaultJanggiUI.UIData>();
                                                    {
                                                        EditData<Janggi.DefaultJanggi> editDefaultJanggi = defaultJanggiUIData.editDefaultJanggi.v;
                                                        if (editDefaultJanggi != null)
                                                        {
                                                            // origin
                                                            editDefaultJanggi.origin.v = new ReferenceData<Janggi.DefaultJanggi>((Janggi.DefaultJanggi)originDefaultGameType);
                                                            // show
                                                            editDefaultJanggi.show.v = new ReferenceData<Janggi.DefaultJanggi>(defaultJanggi);
                                                            // compare
                                                            editDefaultJanggi.compare.v = new ReferenceData<Janggi.DefaultJanggi>((Janggi.DefaultJanggi)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultJanggi.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultJanggi.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultJanggi null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultJanggiUIData;
                                                }
                                                break;
                                            case GameType.Type.Banqi:
                                                {
                                                    Banqi.DefaultBanqi defaultBanqi = defaultGameType as Banqi.DefaultBanqi;
                                                    // UIData
                                                    Banqi.DefaultBanqiUI.UIData defaultBanqiUIData = this.data.defaultGameTypeUI.newOrOld<Banqi.DefaultBanqiUI.UIData>();
                                                    {
                                                        EditData<Banqi.DefaultBanqi> editDefaultBanqi = defaultBanqiUIData.editDefaultBanqi.v;
                                                        if (editDefaultBanqi != null)
                                                        {
                                                            // origin
                                                            editDefaultBanqi.origin.v = new ReferenceData<Banqi.DefaultBanqi>((Banqi.DefaultBanqi)originDefaultGameType);
                                                            // show
                                                            editDefaultBanqi.show.v = new ReferenceData<Banqi.DefaultBanqi>(defaultBanqi);
                                                            // compare
                                                            editDefaultBanqi.compare.v = new ReferenceData<Banqi.DefaultBanqi>((Banqi.DefaultBanqi)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultBanqi.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultBanqi.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultBanqi null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultBanqiUIData;
                                                }
                                                break;

                                            case GameType.Type.Weiqi:
                                                {
                                                    Weiqi.DefaultWeiqi defaultWeiqi = defaultGameType as Weiqi.DefaultWeiqi;
                                                    // UIData
                                                    Weiqi.DefaultWeiqiUI.UIData defaultWeiqiUIData = this.data.defaultGameTypeUI.newOrOld<Weiqi.DefaultWeiqiUI.UIData>();
                                                    {
                                                        EditData<Weiqi.DefaultWeiqi> editDefaultWeiqi = defaultWeiqiUIData.editDefaultWeiqi.v;
                                                        if (editDefaultWeiqi != null)
                                                        {
                                                            // origin
                                                            editDefaultWeiqi.origin.v = new ReferenceData<Weiqi.DefaultWeiqi>((Weiqi.DefaultWeiqi)originDefaultGameType);
                                                            // show
                                                            editDefaultWeiqi.show.v = new ReferenceData<Weiqi.DefaultWeiqi>(defaultWeiqi);
                                                            // compare
                                                            editDefaultWeiqi.compare.v = new ReferenceData<Weiqi.DefaultWeiqi>((Weiqi.DefaultWeiqi)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultWeiqi.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultWeiqi.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultWeiqi null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultWeiqiUIData;
                                                }
                                                break;
                                            case GameType.Type.SHOGI:
                                                {
                                                    Shogi.DefaultShogi defaultShogi = defaultGameType as Shogi.DefaultShogi;
                                                    // UIData
                                                    Shogi.DefaultShogiUI.UIData defaultShogiUIData = this.data.defaultGameTypeUI.newOrOld<Shogi.DefaultShogiUI.UIData>();
                                                    {
                                                        EditData<Shogi.DefaultShogi> editDefaultShogi = defaultShogiUIData.editDefaultShogi.v;
                                                        if (editDefaultShogi != null)
                                                        {
                                                            // origin
                                                            editDefaultShogi.origin.v = new ReferenceData<Shogi.DefaultShogi>((Shogi.DefaultShogi)originDefaultGameType);
                                                            // show
                                                            editDefaultShogi.show.v = new ReferenceData<Shogi.DefaultShogi>(defaultShogi);
                                                            // compare
                                                            editDefaultShogi.compare.v = new ReferenceData<Shogi.DefaultShogi>((Shogi.DefaultShogi)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultShogi.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultShogi.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultShogi null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultShogiUIData;
                                                }
                                                break;
                                            case GameType.Type.Reversi:
                                                {
                                                    Reversi.DefaultReversi defaultReversi = defaultGameType as Reversi.DefaultReversi;
                                                    // UIData
                                                    Reversi.DefaultReversiUI.UIData defaultReversiUIData = this.data.defaultGameTypeUI.newOrOld<Reversi.DefaultReversiUI.UIData>();
                                                    {
                                                        EditData<Reversi.DefaultReversi> editDefaultReversi = defaultReversiUIData.editDefaultReversi.v;
                                                        if (editDefaultReversi != null)
                                                        {
                                                            // origin
                                                            editDefaultReversi.origin.v = new ReferenceData<Reversi.DefaultReversi>((Reversi.DefaultReversi)originDefaultGameType);
                                                            // show
                                                            editDefaultReversi.show.v = new ReferenceData<Reversi.DefaultReversi>(defaultReversi);
                                                            // compare
                                                            editDefaultReversi.compare.v = new ReferenceData<Reversi.DefaultReversi>((Reversi.DefaultReversi)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultReversi.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultReversi.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultReversi null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultReversiUIData;
                                                }
                                                break;
                                            case GameType.Type.Gomoku:
                                                {
                                                    Gomoku.DefaultGomoku defaultGomoku = defaultGameType as Gomoku.DefaultGomoku;
                                                    // UIData
                                                    Gomoku.DefaultGomokuUI.UIData defaultGomokuUIData = this.data.defaultGameTypeUI.newOrOld<Gomoku.DefaultGomokuUI.UIData>();
                                                    {
                                                        EditData<Gomoku.DefaultGomoku> editDefaultGomoku = defaultGomokuUIData.editDefaultGomoku.v;
                                                        if (editDefaultGomoku != null)
                                                        {
                                                            // origin
                                                            editDefaultGomoku.origin.v = new ReferenceData<Gomoku.DefaultGomoku>((Gomoku.DefaultGomoku)originDefaultGameType);
                                                            // show
                                                            editDefaultGomoku.show.v = new ReferenceData<Gomoku.DefaultGomoku>(defaultGomoku);
                                                            // compare
                                                            editDefaultGomoku.compare.v = new ReferenceData<Gomoku.DefaultGomoku>((Gomoku.DefaultGomoku)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultGomoku.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultGomoku.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultGomoku null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultGomokuUIData;
                                                }
                                                break;
                                            case GameType.Type.InternationalDraught:
                                                {
                                                    InternationalDraught.DefaultInternationalDraught defaultInternationalDraught = defaultGameType as InternationalDraught.DefaultInternationalDraught;
                                                    // UIData
                                                    InternationalDraught.DefaultInternationalDraughtUI.UIData defaultInternationalDraughtUIData = this.data.defaultGameTypeUI.newOrOld<InternationalDraught.DefaultInternationalDraughtUI.UIData>();
                                                    {
                                                        EditData<InternationalDraught.DefaultInternationalDraught> editDefaultInternationalDraught = defaultInternationalDraughtUIData.editDefaultInternationalDraught.v;
                                                        if (editDefaultInternationalDraught != null)
                                                        {
                                                            // origin
                                                            editDefaultInternationalDraught.origin.v = new ReferenceData<InternationalDraught.DefaultInternationalDraught>((InternationalDraught.DefaultInternationalDraught)originDefaultGameType);
                                                            // show
                                                            editDefaultInternationalDraught.show.v = new ReferenceData<InternationalDraught.DefaultInternationalDraught>(defaultInternationalDraught);
                                                            // compare
                                                            editDefaultInternationalDraught.compare.v = new ReferenceData<InternationalDraught.DefaultInternationalDraught>((InternationalDraught.DefaultInternationalDraught)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultInternationalDraught.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultInternationalDraught.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultInternationalDraught null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultInternationalDraughtUIData;
                                                }
                                                break;
                                            case GameType.Type.EnglishDraught:
                                                {
                                                    EnglishDraught.DefaultEnglishDraught defaultEnglishDraught = defaultGameType as EnglishDraught.DefaultEnglishDraught;
                                                    // UIData
                                                    EnglishDraught.DefaultEnglishDraughtUI.UIData defaultEnglishDraughtUIData = this.data.defaultGameTypeUI.newOrOld<EnglishDraught.DefaultEnglishDraughtUI.UIData>();
                                                    {
                                                        EditData<EnglishDraught.DefaultEnglishDraught> editDefaultEnglishDraught = defaultEnglishDraughtUIData.editDefaultEnglishDraught.v;
                                                        if (editDefaultEnglishDraught != null)
                                                        {
                                                            // origin
                                                            editDefaultEnglishDraught.origin.v = new ReferenceData<EnglishDraught.DefaultEnglishDraught>((EnglishDraught.DefaultEnglishDraught)originDefaultGameType);
                                                            // show
                                                            editDefaultEnglishDraught.show.v = new ReferenceData<EnglishDraught.DefaultEnglishDraught>(defaultEnglishDraught);
                                                            // compare
                                                            editDefaultEnglishDraught.compare.v = new ReferenceData<EnglishDraught.DefaultEnglishDraught>((EnglishDraught.DefaultEnglishDraught)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultEnglishDraught.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultEnglishDraught.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultEnglishDraught null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultEnglishDraughtUIData;
                                                }
                                                break;
                                            case GameType.Type.RussianDraught:
                                                {
                                                    RussianDraught.DefaultRussianDraught defaultRussianDraught = defaultGameType as RussianDraught.DefaultRussianDraught;
                                                    // UIData
                                                    RussianDraught.DefaultRussianDraughtUI.UIData defaultRussianDraughtUIData = this.data.defaultGameTypeUI.newOrOld<RussianDraught.DefaultRussianDraughtUI.UIData>();
                                                    {
                                                        EditData<RussianDraught.DefaultRussianDraught> editDefaultRussianDraught = defaultRussianDraughtUIData.editDefaultRussianDraught.v;
                                                        if (editDefaultRussianDraught != null)
                                                        {
                                                            // origin
                                                            editDefaultRussianDraught.origin.v = new ReferenceData<RussianDraught.DefaultRussianDraught>((RussianDraught.DefaultRussianDraught)originDefaultGameType);
                                                            // show
                                                            editDefaultRussianDraught.show.v = new ReferenceData<RussianDraught.DefaultRussianDraught>(defaultRussianDraught);
                                                            // compare
                                                            editDefaultRussianDraught.compare.v = new ReferenceData<RussianDraught.DefaultRussianDraught>((RussianDraught.DefaultRussianDraught)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultRussianDraught.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultRussianDraught.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultRussianDraught null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultRussianDraughtUIData;
                                                }
                                                break;
                                            case GameType.Type.ChineseCheckers:
                                                {
                                                    ChineseCheckers.DefaultChineseCheckers defaultChineseCheckers = defaultGameType as ChineseCheckers.DefaultChineseCheckers;
                                                    // UIData
                                                    ChineseCheckers.DefaultChineseCheckersUI.UIData defaultChineseCheckersUIData = this.data.defaultGameTypeUI.newOrOld<ChineseCheckers.DefaultChineseCheckersUI.UIData>();
                                                    {
                                                        EditData<ChineseCheckers.DefaultChineseCheckers> editDefaultChineseCheckers = defaultChineseCheckersUIData.editDefaultChineseCheckers.v;
                                                        if (editDefaultChineseCheckers != null)
                                                        {
                                                            // origin
                                                            editDefaultChineseCheckers.origin.v = new ReferenceData<ChineseCheckers.DefaultChineseCheckers>((ChineseCheckers.DefaultChineseCheckers)originDefaultGameType);
                                                            // show
                                                            editDefaultChineseCheckers.show.v = new ReferenceData<ChineseCheckers.DefaultChineseCheckers>(defaultChineseCheckers);
                                                            // compare
                                                            editDefaultChineseCheckers.compare.v = new ReferenceData<ChineseCheckers.DefaultChineseCheckers>((ChineseCheckers.DefaultChineseCheckers)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultChineseCheckers.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultChineseCheckers.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultChineseCheckers null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultChineseCheckersUIData;
                                                }
                                                break;

                                            case GameType.Type.MineSweeper:
                                                {
                                                    MineSweeper.DefaultMineSweeper defaultMineSweeper = defaultGameType as MineSweeper.DefaultMineSweeper;
                                                    // UIData
                                                    MineSweeper.DefaultMineSweeperUI.UIData defaultMineSweeperUIData = this.data.defaultGameTypeUI.newOrOld<MineSweeper.DefaultMineSweeperUI.UIData>();
                                                    {
                                                        EditData<MineSweeper.DefaultMineSweeper> editDefaultMineSweeper = defaultMineSweeperUIData.editDefaultMineSweeper.v;
                                                        if (editDefaultMineSweeper != null)
                                                        {
                                                            // origin
                                                            editDefaultMineSweeper.origin.v = new ReferenceData<MineSweeper.DefaultMineSweeper>((MineSweeper.DefaultMineSweeper)originDefaultGameType);
                                                            // show
                                                            editDefaultMineSweeper.show.v = new ReferenceData<MineSweeper.DefaultMineSweeper>(defaultMineSweeper);
                                                            // compare
                                                            editDefaultMineSweeper.compare.v = new ReferenceData<MineSweeper.DefaultMineSweeper>((MineSweeper.DefaultMineSweeper)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultMineSweeper.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultMineSweeper.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultMineSweeper null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultMineSweeperUIData;
                                                }
                                                break;
                                            case GameType.Type.Hex:
                                                {
                                                    HEX.DefaultHex defaultHex = defaultGameType as HEX.DefaultHex;
                                                    // UIData
                                                    HEX.DefaultHexUI.UIData defaultHexUIData = this.data.defaultGameTypeUI.newOrOld<HEX.DefaultHexUI.UIData>();
                                                    {
                                                        EditData<HEX.DefaultHex> editDefaultHex = defaultHexUIData.editDefaultHex.v;
                                                        if (editDefaultHex != null)
                                                        {
                                                            // origin
                                                            editDefaultHex.origin.v = new ReferenceData<HEX.DefaultHex>((HEX.DefaultHex)originDefaultGameType);
                                                            // show
                                                            editDefaultHex.show.v = new ReferenceData<HEX.DefaultHex>(defaultHex);
                                                            // compare
                                                            editDefaultHex.compare.v = new ReferenceData<HEX.DefaultHex>((HEX.DefaultHex)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultHex.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultHex.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultHex null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultHexUIData;
                                                }
                                                break;
                                            case GameType.Type.Solitaire:
                                                {
                                                    Solitaire.DefaultSolitaire defaultSolitaire = defaultGameType as Solitaire.DefaultSolitaire;
                                                    // UIData
                                                    Solitaire.DefaultSolitaireUI.UIData defaultSolitaireUIData = this.data.defaultGameTypeUI.newOrOld<Solitaire.DefaultSolitaireUI.UIData>();
                                                    {
                                                        EditData<Solitaire.DefaultSolitaire> editDefaultSolitaire = defaultSolitaireUIData.editDefaultSolitaire.v;
                                                        if (editDefaultSolitaire != null)
                                                        {
                                                            // origin
                                                            editDefaultSolitaire.origin.v = new ReferenceData<Solitaire.DefaultSolitaire>((Solitaire.DefaultSolitaire)originDefaultGameType);
                                                            // show
                                                            editDefaultSolitaire.show.v = new ReferenceData<Solitaire.DefaultSolitaire>(defaultSolitaire);
                                                            // compare
                                                            editDefaultSolitaire.compare.v = new ReferenceData<Solitaire.DefaultSolitaire>((Solitaire.DefaultSolitaire)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultSolitaire.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultSolitaire.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultSolitaire null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultSolitaireUIData;
                                                }
                                                break;
                                            case GameType.Type.Sudoku:
                                                {
                                                    Sudoku.DefaultSudoku defaultSudoku = defaultGameType as Sudoku.DefaultSudoku;
                                                    // UIData
                                                    Sudoku.DefaultSudokuUI.UIData defaultSudokuUIData = this.data.defaultGameTypeUI.newOrOld<Sudoku.DefaultSudokuUI.UIData>();
                                                    {
                                                        EditData<Sudoku.DefaultSudoku> editDefaultSudoku = defaultSudokuUIData.editDefaultSudoku.v;
                                                        if (editDefaultSudoku != null)
                                                        {
                                                            // origin
                                                            editDefaultSudoku.origin.v = new ReferenceData<Sudoku.DefaultSudoku>((Sudoku.DefaultSudoku)originDefaultGameType);
                                                            // show
                                                            editDefaultSudoku.show.v = new ReferenceData<Sudoku.DefaultSudoku>(defaultSudoku);
                                                            // compare
                                                            editDefaultSudoku.compare.v = new ReferenceData<Sudoku.DefaultSudoku>((Sudoku.DefaultSudoku)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultSudoku.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultSudoku.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultSudoku null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultSudokuUIData;
                                                }
                                                break;
                                            case GameType.Type.Khet:
                                                {
                                                    Khet.DefaultKhet defaultKhet = defaultGameType as Khet.DefaultKhet;
                                                    // UIData
                                                    Khet.DefaultKhetUI.UIData defaultKhetUIData = this.data.defaultGameTypeUI.newOrOld<Khet.DefaultKhetUI.UIData>();
                                                    {
                                                        EditData<Khet.DefaultKhet> editDefaultKhet = defaultKhetUIData.editDefaultKhet.v;
                                                        if (editDefaultKhet != null)
                                                        {
                                                            // origin
                                                            editDefaultKhet.origin.v = new ReferenceData<Khet.DefaultKhet>((Khet.DefaultKhet)originDefaultGameType);
                                                            // show
                                                            editDefaultKhet.show.v = new ReferenceData<Khet.DefaultKhet>(defaultKhet);
                                                            // compare
                                                            editDefaultKhet.compare.v = new ReferenceData<Khet.DefaultKhet>((Khet.DefaultKhet)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultKhet.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultKhet.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultKhet null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultKhetUIData;
                                                }
                                                break;
                                            case GameType.Type.NineMenMorris:
                                                {
                                                    NineMenMorris.DefaultNineMenMorris defaultNineMenMorris = defaultGameType as NineMenMorris.DefaultNineMenMorris;
                                                    // UIData
                                                    NineMenMorris.DefaultNineMenMorrisUI.UIData defaultNineMenMorrisUIData = this.data.defaultGameTypeUI.newOrOld<NineMenMorris.DefaultNineMenMorrisUI.UIData>();
                                                    {
                                                        EditData<NineMenMorris.DefaultNineMenMorris> editDefaultNineMenMorris = defaultNineMenMorrisUIData.editDefaultNineMenMorris.v;
                                                        if (editDefaultNineMenMorris != null)
                                                        {
                                                            // origin
                                                            editDefaultNineMenMorris.origin.v = new ReferenceData<NineMenMorris.DefaultNineMenMorris>((NineMenMorris.DefaultNineMenMorris)originDefaultGameType);
                                                            // show
                                                            editDefaultNineMenMorris.show.v = new ReferenceData<NineMenMorris.DefaultNineMenMorris>(defaultNineMenMorris);
                                                            // compare
                                                            editDefaultNineMenMorris.compare.v = new ReferenceData<NineMenMorris.DefaultNineMenMorris>((NineMenMorris.DefaultNineMenMorris)compareDefaultGameType);
                                                            // canEdit
                                                            editDefaultNineMenMorris.canEdit.v = editDefaultGameDataFactory.canEdit.v;
                                                            // editType
                                                            editDefaultNineMenMorris.editType.v = editDefaultGameDataFactory.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultNineMenMorris null: " + this);
                                                        }
                                                    }
                                                    this.data.defaultGameTypeUI.v = defaultNineMenMorrisUIData;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + defaultGameType + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("defaultGameType null: " + this);
                                    }
                                }
                                // useRule
                                {
                                    RequestChangeBoolUI.UIData useRule = this.data.useRule.v;
                                    if (useRule != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = useRule.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.useRule.v;
                                            updateData.canRequestChange.v = editDefaultGameDataFactory.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                useRule.showDifferent.v = true;
                                                useRule.compare.v = compare.useRule.v;
                                            }
                                            else
                                            {
                                                useRule.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // gameType
                                {
                                    RequestChangeEnumUI.UIData gameType = this.data.gameType.v;
                                    if (gameType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = gameType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = GameType.getEnableIndex(show.getGameTypeType());
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameType null: " + this);
                                    }
                                }
                                // useRule
                                {
                                    RequestChangeBoolUI.UIData useRule = this.data.useRule.v;
                                    if (useRule != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = useRule.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.useRule.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("show null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("editDefaultGameDataFactory null: " + this);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Default Game Data Factory");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbGameType != null)
                    {
                        lbGameType.text = txtGameType.get("Game type");
                    }
                    else
                    {
                        Debug.LogError("lbGameType null: " + this);
                    }
                    if (lbUseRule != null)
                    {
                        lbUseRule.text = txtUseRule.get("Use rule");
                    }
                    else
                    {
                        Debug.LogError("lbUseRule null: " + this);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public Transform defaultGameTypeUIContainer;

    public Chess.DefaultChessUI defaultChessUIPrefab;
    public Shatranj.DefaultShatranjUI defaultShatranjUIPrefab;
    public Makruk.DefaultMakrukUI defaultMakrukUIPrefab;
    public Seirawan.DefaultSeirawanUI defaultSeirawanUIPrefab;
    public FairyChess.DefaultFairyChessUI defaultFairyChessUIPrefab;

    public Xiangqi.DefaultXiangqiUI defaultXiangqiUIPrefab;
    public CoTuongUp.DefaultCoTuongUpUI defaultCoTuongUpUIPrefab;
    public Janggi.DefaultJanggiUI defaultJanggiUIPrefab;
    public Banqi.DefaultBanqiUI defaultBanqiUIPrefab;

    public Gomoku.DefaultGomokuUI defaultGomokuUIPrefab;

    public Reversi.DefaultReversiUI defaultReversiUIPrefab;
    public Shogi.DefaultShogiUI defaultShogiUIPrefab;
    public Weiqi.DefaultWeiqiUI defaultWeiqiUIPrefab;

    public InternationalDraught.DefaultInternationalDraughtUI defaultInternationalDraughtUIPrefab;
    public EnglishDraught.DefaultEnglishDraughtUI defaultEnglishDraughtUIPrefab;
    public RussianDraught.DefaultRussianDraughtUI defaultRussianDraughtUIPrefab;
    public ChineseCheckers.DefaultChineseCheckersUI defaultChineseCheckersUIPrefab;

    public MineSweeper.DefaultMineSweeperUI defaultMineSweeperUIPrefab;
    public HEX.DefaultHexUI defaultHexUIPrefab;
    public Solitaire.DefaultSolitaireUI defaultSolitaireUIPrefab;
    public Sudoku.DefaultSudokuUI defaultSudokuUIPrefab;
    public Khet.DefaultKhetUI defaultKhetUIPrefab;
    public NineMenMorris.DefaultNineMenMorrisUI defaultNineMenMorrisUIPrefab;

    public RequestChangeBoolUI requestBoolPrefab;
    public RequestChangeEnumUI requestEnumPrefab;

    public Transform gameTypeContainer;
    public Transform useRuleContainer;

    private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editDefaultGameDataFactory.allAddCallBack(this);
                uiData.gameType.allAddCallBack(this);
                uiData.defaultGameTypeUI.allAddCallBack(this);
                uiData.useRule.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            // editDefaultGameDataFactory
            {
                if (data is EditData<DefaultGameDataFactory>)
                {
                    EditData<DefaultGameDataFactory> editDefaultGameDataFactory = data as EditData<DefaultGameDataFactory>;
                    // Child
                    {
                        editDefaultGameDataFactory.show.allAddCallBack(this);
                        editDefaultGameDataFactory.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is DefaultGameDataFactory)
                    {
                        DefaultGameDataFactory defaultGameDataFactory = data as DefaultGameDataFactory;
                        // Parent
                        {
                            DataUtils.addParentCallBack(defaultGameDataFactory, this, ref this.server);
                        }
                        needReset = true;
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is Server)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.gameType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, gameTypeContainer);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            if (data is DefaultGameTypeUI)
            {
                DefaultGameTypeUI defaultGameTypeUIData = data as DefaultGameTypeUI;
                {
                    switch (defaultGameTypeUIData.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.DefaultChessUI.UIData defaultChessUIData = defaultGameTypeUIData as Chess.DefaultChessUI.UIData;
                                UIUtils.Instantiate(defaultChessUIData, defaultChessUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Shatranj:
                            {
                                Shatranj.DefaultShatranjUI.UIData defaultShatranjUIData = defaultGameTypeUIData as Shatranj.DefaultShatranjUI.UIData;
                                UIUtils.Instantiate(defaultShatranjUIData, defaultShatranjUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Makruk:
                            {
                                Makruk.DefaultMakrukUI.UIData defaultMakrukUIData = defaultGameTypeUIData as Makruk.DefaultMakrukUI.UIData;
                                UIUtils.Instantiate(defaultMakrukUIData, defaultMakrukUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Seirawan:
                            {
                                Seirawan.DefaultSeirawanUI.UIData defaultSeirawanUIData = defaultGameTypeUIData as Seirawan.DefaultSeirawanUI.UIData;
                                UIUtils.Instantiate(defaultSeirawanUIData, defaultSeirawanUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.DefaultFairyChessUI.UIData defaultFairyChessUIData = defaultGameTypeUIData as FairyChess.DefaultFairyChessUI.UIData;
                                UIUtils.Instantiate(defaultFairyChessUIData, defaultFairyChessUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;

                        case GameType.Type.Xiangqi:
                            {
                                Xiangqi.DefaultXiangqiUI.UIData defaultXiangqiUIData = defaultGameTypeUIData as Xiangqi.DefaultXiangqiUI.UIData;
                                UIUtils.Instantiate(defaultXiangqiUIData, defaultXiangqiUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.CO_TUONG_UP:
                            {
                                CoTuongUp.DefaultCoTuongUpUI.UIData defaultCoTuongUpUIData = defaultGameTypeUIData as CoTuongUp.DefaultCoTuongUpUI.UIData;
                                UIUtils.Instantiate(defaultCoTuongUpUIData, defaultCoTuongUpUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Janggi:
                            {
                                Janggi.DefaultJanggiUI.UIData defaultJanggiUIData = defaultGameTypeUIData as Janggi.DefaultJanggiUI.UIData;
                                UIUtils.Instantiate(defaultJanggiUIData, defaultJanggiUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Banqi:
                            {
                                Banqi.DefaultBanqiUI.UIData defaultBanqiUIData = defaultGameTypeUIData as Banqi.DefaultBanqiUI.UIData;
                                UIUtils.Instantiate(defaultBanqiUIData, defaultBanqiUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;

                        case GameType.Type.Weiqi:
                            {
                                Weiqi.DefaultWeiqiUI.UIData defaultWeiqiUIData = defaultGameTypeUIData as Weiqi.DefaultWeiqiUI.UIData;
                                UIUtils.Instantiate(defaultWeiqiUIData, defaultWeiqiUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.SHOGI:
                            {
                                Shogi.DefaultShogiUI.UIData defaultShogiUIData = defaultGameTypeUIData as Shogi.DefaultShogiUI.UIData;
                                UIUtils.Instantiate(defaultShogiUIData, defaultShogiUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Reversi:
                            {
                                Reversi.DefaultReversiUI.UIData defaultReversiUIData = defaultGameTypeUIData as Reversi.DefaultReversiUI.UIData;
                                UIUtils.Instantiate(defaultReversiUIData, defaultReversiUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Gomoku:
                            {
                                Gomoku.DefaultGomokuUI.UIData defaultGomokuUIData = defaultGameTypeUIData as Gomoku.DefaultGomokuUI.UIData;
                                UIUtils.Instantiate(defaultGomokuUIData, defaultGomokuUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;

                        case GameType.Type.InternationalDraught:
                            {
                                InternationalDraught.DefaultInternationalDraughtUI.UIData defaultInternationalDraughtUIData = defaultGameTypeUIData as InternationalDraught.DefaultInternationalDraughtUI.UIData;
                                UIUtils.Instantiate(defaultInternationalDraughtUIData, defaultInternationalDraughtUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                EnglishDraught.DefaultEnglishDraughtUI.UIData defaultEnglishDraughtUIData = defaultGameTypeUIData as EnglishDraught.DefaultEnglishDraughtUI.UIData;
                                UIUtils.Instantiate(defaultEnglishDraughtUIData, defaultEnglishDraughtUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                RussianDraught.DefaultRussianDraughtUI.UIData defaultRussianDraughtUIData = defaultGameTypeUIData as RussianDraught.DefaultRussianDraughtUI.UIData;
                                UIUtils.Instantiate(defaultRussianDraughtUIData, defaultRussianDraughtUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.ChineseCheckers:
                            {
                                ChineseCheckers.DefaultChineseCheckersUI.UIData defaultChineseCheckersUIData = defaultGameTypeUIData as ChineseCheckers.DefaultChineseCheckersUI.UIData;
                                UIUtils.Instantiate(defaultChineseCheckersUIData, defaultChineseCheckersUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;

                        case GameType.Type.MineSweeper:
                            {
                                MineSweeper.DefaultMineSweeperUI.UIData defaultMineSweeperUIData = defaultGameTypeUIData as MineSweeper.DefaultMineSweeperUI.UIData;
                                UIUtils.Instantiate(defaultMineSweeperUIData, defaultMineSweeperUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Hex:
                            {
                                HEX.DefaultHexUI.UIData defaultHexUIData = defaultGameTypeUIData as HEX.DefaultHexUI.UIData;
                                UIUtils.Instantiate(defaultHexUIData, defaultHexUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Solitaire:
                            {
                                Solitaire.DefaultSolitaireUI.UIData defaultSolitaireUIData = defaultGameTypeUIData as Solitaire.DefaultSolitaireUI.UIData;
                                UIUtils.Instantiate(defaultSolitaireUIData, defaultSolitaireUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Sudoku:
                            {
                                Sudoku.DefaultSudokuUI.UIData defaultSudokuUIData = defaultGameTypeUIData as Sudoku.DefaultSudokuUI.UIData;
                                UIUtils.Instantiate(defaultSudokuUIData, defaultSudokuUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.Khet:
                            {
                                Khet.DefaultKhetUI.UIData defaultKhetUIData = defaultGameTypeUIData as Khet.DefaultKhetUI.UIData;
                                UIUtils.Instantiate(defaultKhetUIData, defaultKhetUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        case GameType.Type.NineMenMorris:
                            {
                                NineMenMorris.DefaultNineMenMorrisUI.UIData defaultNineMenMorrisUIData = defaultGameTypeUIData as NineMenMorris.DefaultNineMenMorrisUI.UIData;
                                UIUtils.Instantiate(defaultNineMenMorrisUIData, defaultNineMenMorrisUIPrefab, defaultGameTypeUIContainer);
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + defaultGameTypeUIData + "; " + this);
                            break;
                    }
                }
                dirty = true;
                return;
            }
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.useRule:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, useRuleContainer);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
                }
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
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.editDefaultGameDataFactory.allRemoveCallBack(this);
                uiData.gameType.allRemoveCallBack(this);
                uiData.defaultGameTypeUI.allRemoveCallBack(this);
                uiData.useRule.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        {
            // editDefaultGameDataFactory
            {
                if (data is EditData<DefaultGameDataFactory>)
                {
                    EditData<DefaultGameDataFactory> editDefaultGameDataFactory = data as EditData<DefaultGameDataFactory>;
                    // Child
                    {
                        editDefaultGameDataFactory.show.allRemoveCallBack(this);
                        editDefaultGameDataFactory.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is DefaultGameDataFactory)
                    {
                        DefaultGameDataFactory defaultGameDataFactory = data as DefaultGameDataFactory;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(defaultGameDataFactory, this, ref this.server);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is Server)
                        {
                            return;
                        }
                    }
                }
            }
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            if (data is DefaultGameTypeUI)
            {
                DefaultGameTypeUI defaultGameTypeUIData = data as DefaultGameTypeUI;
                {
                    switch (defaultGameTypeUIData.getType())
                    {
                        case GameType.Type.CHESS:
                            {
                                Chess.DefaultChessUI.UIData defaultChessUIData = defaultGameTypeUIData as Chess.DefaultChessUI.UIData;
                                defaultChessUIData.removeCallBackAndDestroy(typeof(Chess.DefaultChessUI));
                            }
                            break;
                        case GameType.Type.Shatranj:
                            {
                                Shatranj.DefaultShatranjUI.UIData defaultShatranjUIData = defaultGameTypeUIData as Shatranj.DefaultShatranjUI.UIData;
                                defaultShatranjUIData.removeCallBackAndDestroy(typeof(Shatranj.DefaultShatranjUI));
                            }
                            break;
                        case GameType.Type.Makruk:
                            {
                                Makruk.DefaultMakrukUI.UIData defaultMakrukUIData = defaultGameTypeUIData as Makruk.DefaultMakrukUI.UIData;
                                defaultMakrukUIData.removeCallBackAndDestroy(typeof(Makruk.DefaultMakrukUI));
                            }
                            break;
                        case GameType.Type.Seirawan:
                            {
                                Seirawan.DefaultSeirawanUI.UIData defaultSeirawanUIData = defaultGameTypeUIData as Seirawan.DefaultSeirawanUI.UIData;
                                defaultSeirawanUIData.removeCallBackAndDestroy(typeof(Seirawan.DefaultSeirawanUI));
                            }
                            break;
                        case GameType.Type.FairyChess:
                            {
                                FairyChess.DefaultFairyChessUI.UIData defaultFairyChessUIData = defaultGameTypeUIData as FairyChess.DefaultFairyChessUI.UIData;
                                defaultFairyChessUIData.removeCallBackAndDestroy(typeof(FairyChess.DefaultFairyChessUI));
                            }
                            break;

                        case GameType.Type.Xiangqi:
                            {
                                Xiangqi.DefaultXiangqiUI.UIData defaultXiangqiUIData = defaultGameTypeUIData as Xiangqi.DefaultXiangqiUI.UIData;
                                defaultXiangqiUIData.removeCallBackAndDestroy(typeof(Xiangqi.DefaultXiangqiUI));
                            }
                            break;
                        case GameType.Type.CO_TUONG_UP:
                            {
                                CoTuongUp.DefaultCoTuongUpUI.UIData defaultCoTuongUpUIData = defaultGameTypeUIData as CoTuongUp.DefaultCoTuongUpUI.UIData;
                                defaultCoTuongUpUIData.removeCallBackAndDestroy(typeof(CoTuongUp.DefaultCoTuongUpUI));
                            }
                            break;
                        case GameType.Type.Janggi:
                            {
                                Janggi.DefaultJanggiUI.UIData defaultJanggiUIData = defaultGameTypeUIData as Janggi.DefaultJanggiUI.UIData;
                                defaultJanggiUIData.removeCallBackAndDestroy(typeof(Janggi.DefaultJanggiUI));
                            }
                            break;
                        case GameType.Type.Banqi:
                            {
                                Banqi.DefaultBanqiUI.UIData defaultBanqiUIData = defaultGameTypeUIData as Banqi.DefaultBanqiUI.UIData;
                                defaultBanqiUIData.removeCallBackAndDestroy(typeof(Banqi.DefaultBanqiUI));
                            }
                            break;

                        case GameType.Type.Weiqi:
                            {
                                Weiqi.DefaultWeiqiUI.UIData defaultWeiqiUIData = defaultGameTypeUIData as Weiqi.DefaultWeiqiUI.UIData;
                                defaultWeiqiUIData.removeCallBackAndDestroy(typeof(Weiqi.DefaultWeiqiUI));
                            }
                            break;
                        case GameType.Type.SHOGI:
                            {
                                Shogi.DefaultShogiUI.UIData defaultShogiUIData = defaultGameTypeUIData as Shogi.DefaultShogiUI.UIData;
                                defaultShogiUIData.removeCallBackAndDestroy(typeof(Shogi.DefaultShogiUI));
                            }
                            break;
                        case GameType.Type.Reversi:
                            {
                                Reversi.DefaultReversiUI.UIData defaultReversiUIData = defaultGameTypeUIData as Reversi.DefaultReversiUI.UIData;
                                defaultReversiUIData.removeCallBackAndDestroy(typeof(Reversi.DefaultReversiUI));
                            }
                            break;

                        case GameType.Type.Gomoku:
                            {
                                Gomoku.DefaultGomokuUI.UIData defaultGomokuUIData = defaultGameTypeUIData as Gomoku.DefaultGomokuUI.UIData;
                                defaultGomokuUIData.removeCallBackAndDestroy(typeof(Gomoku.DefaultGomokuUI));
                            }
                            break;

                        case GameType.Type.InternationalDraught:
                            {
                                InternationalDraught.DefaultInternationalDraughtUI.UIData defaultInternationalDraughtUIData = defaultGameTypeUIData as InternationalDraught.DefaultInternationalDraughtUI.UIData;
                                defaultInternationalDraughtUIData.removeCallBackAndDestroy(typeof(InternationalDraught.DefaultInternationalDraughtUI));
                            }
                            break;
                        case GameType.Type.EnglishDraught:
                            {
                                EnglishDraught.DefaultEnglishDraughtUI.UIData defaultEnglishDraughtUIData = defaultGameTypeUIData as EnglishDraught.DefaultEnglishDraughtUI.UIData;
                                defaultEnglishDraughtUIData.removeCallBackAndDestroy(typeof(EnglishDraught.DefaultEnglishDraughtUI));
                            }
                            break;
                        case GameType.Type.RussianDraught:
                            {
                                RussianDraught.DefaultRussianDraughtUI.UIData defaultRussianDraughtUIData = defaultGameTypeUIData as RussianDraught.DefaultRussianDraughtUI.UIData;
                                defaultRussianDraughtUIData.removeCallBackAndDestroy(typeof(RussianDraught.DefaultRussianDraughtUI));
                            }
                            break;
                        case GameType.Type.ChineseCheckers:
                            {
                                ChineseCheckers.DefaultChineseCheckersUI.UIData defaultChineseCheckersUIData = defaultGameTypeUIData as ChineseCheckers.DefaultChineseCheckersUI.UIData;
                                defaultChineseCheckersUIData.removeCallBackAndDestroy(typeof(ChineseCheckers.DefaultChineseCheckersUI));
                            }
                            break;

                        case GameType.Type.MineSweeper:
                            {
                                MineSweeper.DefaultMineSweeperUI.UIData defaultMineSweeperUIData = defaultGameTypeUIData as MineSweeper.DefaultMineSweeperUI.UIData;
                                defaultMineSweeperUIData.removeCallBackAndDestroy(typeof(MineSweeper.DefaultMineSweeperUI));
                            }
                            break;
                        case GameType.Type.Hex:
                            {
                                HEX.DefaultHexUI.UIData defaultHexUIData = defaultGameTypeUIData as HEX.DefaultHexUI.UIData;
                                defaultHexUIData.removeCallBackAndDestroy(typeof(HEX.DefaultHexUI));
                            }
                            break;
                        case GameType.Type.Solitaire:
                            {
                                Solitaire.DefaultSolitaireUI.UIData defaultSolitaireUIData = defaultGameTypeUIData as Solitaire.DefaultSolitaireUI.UIData;
                                defaultSolitaireUIData.removeCallBackAndDestroy(typeof(Solitaire.DefaultSolitaireUI));
                            }
                            break;
                        case GameType.Type.Sudoku:
                            {
                                Sudoku.DefaultSudokuUI.UIData defaultSudokuUIData = defaultGameTypeUIData as Sudoku.DefaultSudokuUI.UIData;
                                defaultSudokuUIData.removeCallBackAndDestroy(typeof(Sudoku.DefaultSudokuUI));
                            }
                            break;
                        case GameType.Type.Khet:
                            {
                                Khet.DefaultKhetUI.UIData defaultKhetUIData = defaultGameTypeUIData as Khet.DefaultKhetUI.UIData;
                                defaultKhetUIData.removeCallBackAndDestroy(typeof(Khet.DefaultKhetUI));
                            }
                            break;
                        case GameType.Type.NineMenMorris:
                            {
                                NineMenMorris.DefaultNineMenMorrisUI.UIData defaultNineMenMorrisUIData = defaultGameTypeUIData as NineMenMorris.DefaultNineMenMorrisUI.UIData;
                                defaultNineMenMorrisUIData.removeCallBackAndDestroy(typeof(NineMenMorris.DefaultNineMenMorrisUI));
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + defaultGameTypeUIData + "; " + this);
                            break;
                    }
                }
                return;
            }
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                }
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
                case UIData.Property.editDefaultGameDataFactory:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.defaultGameTypeUI:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.useRule:
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
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // editDefaultGameDataFactory
            {
                if (wrapProperty.p is EditData<DefaultGameDataFactory>)
                {
                    switch ((EditData<DefaultGameDataFactory>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultGameDataFactory>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultGameDataFactory>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultGameDataFactory>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultGameDataFactory>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultGameDataFactory>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultGameDataFactory>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is DefaultGameDataFactory)
                    {
                        switch ((DefaultGameDataFactory.Property)wrapProperty.n)
                        {
                            case DefaultGameDataFactory.Property.defaultGameType:
                                dirty = true;
                                break;
                            case DefaultGameDataFactory.Property.useRule:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                    }
                }
            }
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is DefaultGameTypeUI)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}