using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;
using GameState;

namespace GameManager.Match
{
    public class ChooseRoundGameHolder : SriaHolderBehavior<ChooseRoundGameHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<RoundGame>> roundGame;

            public LP<RoundGamePlayerUI.UIData> roundGamePlayers;

            #region State

            public abstract class StateUI : Data
            {

                public abstract GameState.State.Type getType();

            }

            public VP<StateUI> stateUI;

            #endregion

            #region Constructor

            public enum Property
            {
                roundGame,
                roundGamePlayers,
                stateUI
            }

            public UIData() : base()
            {
                this.roundGame = new VP<ReferenceData<RoundGame>>(this, (byte)Property.roundGame, new ReferenceData<RoundGame>(null));
                this.roundGamePlayers = new LP<RoundGamePlayerUI.UIData>(this, (byte)Property.roundGamePlayers);
                this.stateUI = new VP<StateUI>(this, (byte)Property.stateUI, null);
            }

            #endregion

            public void updateView(ChooseRoundGameAdapter.UIData myParams)
            {
                // Find
                RoundGame roundGame = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.roundGames.Count)
                    {
                        roundGame = myParams.roundGames[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.roundGame.v = new ReferenceData<RoundGame>(roundGame);
            }

        }

        #endregion

        #region txt

        public Text tvShow;
        public static readonly TxtLanguage txtShow = new TxtLanguage();

        static ChooseRoundGameHolder()
        {
            // txt
            {
                txtShow.add(Language.Type.vi, "Hiện");
            }
            // rect
            {
                // stateUIRect
                {
                    // anchoredPosition: (-58.0, 0.0); anchorMin: (1.0, 0.0); anchorMax: (1.0, 1.0); pivot: (1.0, 0.5);
                    // offsetMin: (-108.0, 0.0); offsetMax: (-58.0, 0.0); sizeDelta: (50.0, 0.0);
                    stateUIRect.anchoredPosition = new Vector3(-58.0f, 0.0f);
                    stateUIRect.anchorMin = new Vector2(1.0f, 0.0f);
                    stateUIRect.anchorMax = new Vector2(1.0f, 1.0f);
                    stateUIRect.pivot = new Vector2(1.0f, 0.5f);
                    stateUIRect.offsetMin = new Vector2(-108.0f, 0.0f);
                    stateUIRect.offsetMax = new Vector2(-58.0f, 0.0f);
                    stateUIRect.sizeDelta = new Vector2(50.0f, 0.0f);
                }
                // roundGamePlayerRect
                {
                    // anchoredPosition: (-45.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (30.0, -40.0); offsetMax: (-120.0, 0.0); sizeDelta: (-150.0, 40.0);
                    roundGamePlayerRect.anchoredPosition = new Vector3(-45.0f, 0.0f, 0.0f);
                    roundGamePlayerRect.anchorMin = new Vector2(0.0f, 1.0f);
                    roundGamePlayerRect.anchorMax = new Vector2(1.0f, 1.0f);
                    roundGamePlayerRect.pivot = new Vector2(0.5f, 1.0f);
                    roundGamePlayerRect.offsetMin = new Vector2(30.0f, -40.0f);
                    roundGamePlayerRect.offsetMax = new Vector2(-120.0f, 0.0f);
                    roundGamePlayerRect.sizeDelta = new Vector2(-150.0f, 40.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvIndex;

        public Button btnShow;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundGame roundGame = this.data.roundGame.v.data;
                    if (roundGame != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (roundGame.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // state
                        {
                            // Find
                            State state = null;
                            {
                                Game game = roundGame.game.v;
                                if (game != null)
                                {
                                    state = game.state.v;
                                }
                                else
                                {
                                    Debug.LogError("game null: " + this);
                                }
                            }
                            // Process
                            if (state != null)
                            {
                                switch (state.getType())
                                {
                                    case State.Type.Load:
                                        {
                                            Load load = state as Load;
                                            // UIData
                                            RoundGameStateLoadUI.UIData loadUIData = this.data.stateUI.newOrOld<RoundGameStateLoadUI.UIData>();
                                            {
                                                loadUIData.load.v = new ReferenceData<Load>(load);
                                            }
                                            this.data.stateUI.v = loadUIData;
                                        }
                                        break;
                                    case State.Type.Start:
                                        {
                                            Start start = state as Start;
                                            // UIData
                                            RoundGameStateStartUI.UIData startUIData = this.data.stateUI.newOrOld<RoundGameStateStartUI.UIData>();
                                            {
                                                startUIData.start.v = new ReferenceData<Start>(start);
                                            }
                                            this.data.stateUI.v = startUIData;
                                        }
                                        break;
                                    case State.Type.Play:
                                        {
                                            Play play = state as Play;
                                            // UIData
                                            RoundGameStatePlayUI.UIData playUIData = this.data.stateUI.newOrOld<RoundGameStatePlayUI.UIData>();
                                            {
                                                playUIData.play.v = new ReferenceData<Play>(play);
                                            }
                                            this.data.stateUI.v = playUIData;
                                        }
                                        break;
                                    case State.Type.End:
                                        {
                                            End end = state as End;
                                            // UIData
                                            RoundGameStateEndUI.UIData endUIData = this.data.stateUI.newOrOld<RoundGameStateEndUI.UIData>();
                                            {
                                                endUIData.end.v = new ReferenceData<End>(end);
                                            }
                                            this.data.stateUI.v = endUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("state null: " + this);
                            }
                        }
                        // roundGamePlayers
                        {
                            List<RoundGamePlayerUI.UIData> oldRoundGamePlayers = new List<RoundGamePlayerUI.UIData>();
                            // get old
                            {
                                oldRoundGamePlayers.AddRange(this.data.roundGamePlayers.vs);
                            }
                            // Update
                            {
                                Game game = roundGame.game.v;
                                if (game != null)
                                {
                                    // get list
                                    List<GamePlayer> gamePlayers = new List<GamePlayer>();
                                    {
                                        gamePlayers.AddRange(game.gamePlayers.vs);
                                        gamePlayers.Sort(delegate (GamePlayer p1, GamePlayer p2)
                                        {
                                            return p1.playerIndex.v.CompareTo(p2.playerIndex.v);
                                        });
                                    }
                                    foreach (GamePlayer gamePlayer in gamePlayers)
                                    {
                                        // Find UI
                                        RoundGamePlayerUI.UIData roundGamePlayerUIData = null;
                                        {
                                            // Find old
                                            if (oldRoundGamePlayers.Count > 0)
                                            {
                                                roundGamePlayerUIData = oldRoundGamePlayers[0];
                                            }
                                            // Make new
                                            if (roundGamePlayerUIData == null)
                                            {
                                                roundGamePlayerUIData = new RoundGamePlayerUI.UIData();
                                                {
                                                    roundGamePlayerUIData.uid = this.data.roundGamePlayers.makeId();
                                                }
                                                this.data.roundGamePlayers.add(roundGamePlayerUIData);
                                            }
                                            else
                                            {
                                                oldRoundGamePlayers.Remove(roundGamePlayerUIData);
                                            }
                                        }
                                        // Update
                                        {
                                            roundGamePlayerUIData.gamePlayer.v = new ReferenceData<GamePlayer>(gamePlayer);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("game null: " + this);
                                }
                            }
                            // Remove old
                            foreach (RoundGamePlayerUI.UIData oldRoundGamePlayer in oldRoundGamePlayers)
                            {
                                this.data.roundGamePlayers.remove(oldRoundGamePlayer);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // roundGamePlayer
                            {
                                // get list
                                List<RoundGamePlayerUI.UIData> players = new List<RoundGamePlayerUI.UIData>();
                                {
                                    players.AddRange(this.data.roundGamePlayers.vs);
                                }
                                // position
                                foreach(RoundGamePlayerUI.UIData player in players)
                                {
                                    deltaY += UIRectTransform.SetPosY(player, deltaY);
                                }
                            }
                            // set size
                            {
                                ISRIA adapter = null;
                                {
                                    BaseParams baseParams = this.data.findDataInParent<BaseParams>();
                                    if (baseParams != null)
                                    {
                                        // Debug.LogError ("find base params: " + baseParams + "; " + this);
                                        // find adapter in callBack
                                        adapter = baseParams.findCallBack<ISRIA>();
                                    }
                                    else
                                    {
                                        Debug.LogError("baseParams null: " + this);
                                    }
                                }
                                // Process
                                if (adapter != null)
                                {
                                    float holderSize = Mathf.Max(deltaY, 40);
                                    adapter.RequestChangeItemSizeAndUpdateLayout(this.data.ItemIndex, holderSize);
                                }
                                else
                                {
                                    Debug.LogError("adapter null");
                                }
                            }
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                bool isAlreadyShow = false;
                                {
                                    RoundUI.UIData roundUIData = this.data.findDataInParent<RoundUI.UIData>();
                                    if (roundUIData != null)
                                    {
                                        RoundGameUI.UIData roundGameUIData = roundUIData.roundGameUIData.v;
                                        if (roundGameUIData != null)
                                        {
                                            if (roundGame == roundGameUIData.roundGame.v.data)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundGameUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roundUIData null");
                                    }
                                }
                                btnShow.interactable = !isAlreadyShow;
                            }
                            else
                            {
                                Debug.LogError("btnShow null");
                            }
                        }
                        // txtShow
                        {
                            if (tvShow != null)
                            {
                                tvShow.text = txtShow.get("Show");
                            }
                            else
                            {
                                Debug.LogError("tvShow null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundGame null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        public RoundGameStateLoadUI loadPrefab;
        public RoundGameStateStartUI startPrefab;
        public RoundGameStatePlayUI playPrefab;
        public RoundGameStateEndUI endPrefab;
        private static readonly UIRectTransform stateUIRect = new UIRectTransform();

        public RoundGamePlayerUI roundGamePlayerPrefab;
        private static readonly UIRectTransform roundGamePlayerRect = new UIRectTransform();

        private RoundUI.UIData roundUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.roundUIData);
                }
                // Child
                {
                    uiData.roundGame.allAddCallBack(this);
                    uiData.roundGamePlayers.allAddCallBack(this);
                    uiData.stateUI.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if(data is RoundUI.UIData)
                {
                    RoundUI.UIData roundUIData = data as RoundUI.UIData;
                    // Child
                    {
                        roundUIData.roundGameUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is RoundGameUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // RoundGame
                {
                    if (data is RoundGame)
                    {
                        RoundGame roundGame = data as RoundGame;
                        // Child
                        {
                            roundGame.game.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Game)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is RoundGamePlayerUI.UIData)
                {
                    RoundGamePlayerUI.UIData roundGamePlayerUIData = data as RoundGamePlayerUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roundGamePlayerUIData, roundGamePlayerPrefab, this.transform, roundGamePlayerRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.StateUI)
                {
                    UIData.StateUI stateUIData = data as UIData.StateUI;
                    // UI
                    {
                        switch (stateUIData.getType())
                        {
                            case State.Type.Load:
                                {
                                    RoundGameStateLoadUI.UIData loadUIData = stateUIData as RoundGameStateLoadUI.UIData;
                                    UIUtils.Instantiate(loadUIData, loadPrefab, this.transform, stateUIRect);
                                }
                                break;
                            case State.Type.Start:
                                {
                                    RoundGameStateStartUI.UIData startUIData = stateUIData as RoundGameStateStartUI.UIData;
                                    UIUtils.Instantiate(startUIData, startPrefab, this.transform, stateUIRect);
                                }
                                break;
                            case State.Type.Play:
                                {
                                    RoundGameStatePlayUI.UIData playUIData = stateUIData as RoundGameStatePlayUI.UIData;
                                    UIUtils.Instantiate(playUIData, playPrefab, this.transform, stateUIRect);
                                }
                                break;
                            case State.Type.End:
                                {
                                    RoundGameStateEndUI.UIData endUIData = stateUIData as RoundGameStateEndUI.UIData;
                                    UIUtils.Instantiate(endUIData, endPrefab, this.transform, stateUIRect);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + stateUIData.getType() + "; " + this);
                                break;
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.roundUIData);
                }
                // Child
                {
                    uiData.roundGame.allRemoveCallBack(this);
                    uiData.roundGamePlayers.allRemoveCallBack(this);
                    uiData.stateUI.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is RoundUI.UIData)
                {
                    RoundUI.UIData roundUIData = data as RoundUI.UIData;
                    // Child
                    {
                        roundUIData.roundGameUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is RoundGameUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                // RoundGame
                {
                    if (data is RoundGame)
                    {
                        RoundGame roundGame = data as RoundGame;
                        // Child
                        {
                            roundGame.game.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Game)
                    {
                        return;
                    }
                }
                if (data is RoundGamePlayerUI.UIData)
                {
                    RoundGamePlayerUI.UIData roundGamePlayerUIData = data as RoundGamePlayerUI.UIData;
                    // UI
                    {
                        roundGamePlayerUIData.removeCallBackAndDestroy(typeof(RoundGamePlayerUI));
                    }
                    return;
                }
                if (data is UIData.StateUI)
                {
                    UIData.StateUI stateUIData = data as UIData.StateUI;
                    // UI
                    {
                        switch (stateUIData.getType())
                        {
                            case State.Type.Load:
                                {
                                    RoundGameStateLoadUI.UIData loadUIData = stateUIData as RoundGameStateLoadUI.UIData;
                                    loadUIData.removeCallBackAndDestroy(typeof(RoundGameStateLoadUI));
                                }
                                break;
                            case State.Type.Start:
                                {
                                    RoundGameStateStartUI.UIData startUIData = stateUIData as RoundGameStateStartUI.UIData;
                                    startUIData.removeCallBackAndDestroy(typeof(RoundGameStateStartUI));
                                }
                                break;
                            case State.Type.Play:
                                {
                                    RoundGameStatePlayUI.UIData playUIData = stateUIData as RoundGameStatePlayUI.UIData;
                                    playUIData.removeCallBackAndDestroy(typeof(RoundGameStatePlayUI));
                                }
                                break;
                            case State.Type.End:
                                {
                                    RoundGameStateEndUI.UIData endUIData = stateUIData as RoundGameStateEndUI.UIData;
                                    endUIData.removeCallBackAndDestroy(typeof(RoundGameStateEndUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + stateUIData.getType() + "; " + this);
                                break;
                        }
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
                    case UIData.Property.roundGame:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundGamePlayers:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.stateUI:
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
            // Parent
            {
                if (wrapProperty.p is RoundUI.UIData)
                {
                    switch ((RoundUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundUI.UIData.Property.round:
                            break;
                        case RoundUI.UIData.Property.roundGameUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoundUI.UIData.Property.chooseRoundGameUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is RoundGameUI.UIData)
                {
                    switch ((RoundGameUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundGameUI.UIData.Property.roundGame:
                            dirty = true;
                            break;
                        case RoundGameUI.UIData.Property.gameUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            {
                // RoundGame
                {
                    if (wrapProperty.p is RoundGame)
                    {
                        switch ((RoundGame.Property)wrapProperty.n)
                        {
                            case RoundGame.Property.index:
                                dirty = true;
                                break;
                            case RoundGame.Property.playerInTeam:
                                break;
                            case RoundGame.Property.playerInGame:
                                break;
                            case RoundGame.Property.game:
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
                    if (wrapProperty.p is Game)
                    {
                        switch ((Game.Property)wrapProperty.n)
                        {
                            case Game.Property.gamePlayers:
                                dirty = true;
                                break;
                            case Game.Property.requestDraw:
                                break;
                            case Game.Property.state:
                                dirty = true;
                                break;
                            case Game.Property.gameData:
                                break;
                            case Game.Property.history:
                                break;
                            case Game.Property.gameAction:
                                break;
                            case Game.Property.undoRedoRequest:
                                break;
                            case Game.Property.chatRoom:
                                break;
                            case Game.Property.animationData:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is RoundGamePlayerUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is UIData.StateUI)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                RoundGame roundGame = this.data.roundGame.v.data;
                if (roundGame != null)
                {
                    RoundUI.UIData roundUIData = this.data.findDataInParent<RoundUI.UIData>();
                    if (roundUIData != null)
                    {
                        RoundGameUI.UIData roundGameUIData = roundUIData.roundGameUIData.v;
                        if (roundGameUIData != null)
                        {
                            roundGameUIData.roundGame.v = new ReferenceData<RoundGame>(roundGame);
                        }
                        else
                        {
                            Debug.LogError("roundGameUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("roundUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("roundGame null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}