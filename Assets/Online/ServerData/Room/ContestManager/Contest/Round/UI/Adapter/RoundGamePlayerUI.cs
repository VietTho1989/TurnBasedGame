using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;

namespace GameManager.Match
{
    public class RoundGamePlayerUI : UIBehavior<RoundGamePlayerUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<GamePlayer>> gamePlayer;

            public VP<InformAvatarUI.UIData> avatar;

            public VP<ResultUI.UIData> result;

            #region Constructor

            public enum Property
            {
                gamePlayer,
                avatar,
                result
            }

            public UIData() : base()
            {
                this.gamePlayer = new VP<ReferenceData<GamePlayer>>(this, (byte)Property.gamePlayer, new ReferenceData<GamePlayer>(null));
                this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
                this.result = new VP<ResultUI.UIData>(this, (byte)Property.result, new ResultUI.UIData());
            }

            #endregion

        }

        #endregion

        #region txt, rect

        static RoundGamePlayerUI()
        {
            // rect
            {
                // informAvatarRect
                {
                    // anchoredPosition: (5.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.0, 0.5); pivot: (0.0, 0.5);
                    // offsetMin: (5.0, -15.0); offsetMax: (35.0, 15.0); sizeDelta: (30.0, 30.0);
                    informAvatarRect.anchoredPosition = new Vector3(5.0f, 0.0f);
                    informAvatarRect.anchorMin = new Vector2(0.0f, 0.5f);
                    informAvatarRect.anchorMax = new Vector2(0.0f, 0.5f);
                    informAvatarRect.pivot = new Vector2(0.0f, 0.5f);
                    informAvatarRect.offsetMin = new Vector2(5.0f, -15.0f);
                    informAvatarRect.offsetMax = new Vector2(35.0f, 15.0f);
                    informAvatarRect.sizeDelta = new Vector2(30.0f, 30.0f);
                }
                // resultRect
                {
                    // anchoredPosition: (17.5, -20.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (40.0, -36.0); offsetMax: (-5.0, -20.0); sizeDelta: (-45.0, 16.0);
                    resultRect.anchoredPosition = new Vector3(17.5f, -20.0f);
                    resultRect.anchorMin = new Vector2(0.0f, 1.0f);
                    resultRect.anchorMax = new Vector2(1.0f, 1.0f);
                    resultRect.pivot = new Vector2(0.5f, 1.0f);
                    resultRect.offsetMin = new Vector2(40.0f, -36.0f);
                    resultRect.offsetMax = new Vector2(-5.0f, -20.0f);
                    resultRect.sizeDelta = new Vector2(-45.0f, 16.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvName;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    GamePlayer gamePlayer = this.data.gamePlayer.v.data;
                    if (gamePlayer != null)
                    {
                        // avatar
                        {
                            InformAvatarUI.UIData avatar = this.data.avatar.v;
                            if (avatar != null)
                            {
                                avatar.inform.v = new ReferenceData<GamePlayer.Inform>(gamePlayer.inform.v);
                            }
                            else
                            {
                                Debug.LogError("avatar null: " + this);
                            }
                        }
                        // tvName
                        if (tvName != null)
                        {
                            tvName.text = gamePlayer.inform.v.getPlayerName();
                        }
                        else
                        {
                            Debug.LogError("tvName null: " + this);
                        }
                        // result
                        {
                            ResultUI.UIData resultUIData = this.data.result.v;
                            if (resultUIData != null)
                            {
                                // find
                                GameState.Result result = null;
                                {
                                    Game game = gamePlayer.findDataInParent<Game>();
                                    if (game != null)
                                    {
                                        if (game.state.v is GameState.End)
                                        {
                                            GameState.End end = game.state.v as GameState.End;
                                            // get
                                            result = end.findResult(gamePlayer.playerIndex.v);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("game null: " + this);
                                    }
                                }
                                // set
                                resultUIData.result.v = new ReferenceData<Result>(result);
                            }
                            else
                            {
                                Debug.LogError("resultUIData null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("gamePlayer null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public InformAvatarUI informAvatarPrefab;
        private static readonly UIRectTransform informAvatarRect = new UIRectTransform();

        public ResultUI resultPrefab;
        private static readonly UIRectTransform resultRect = new UIRectTransform();

        private Game game = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.gamePlayer.allAddCallBack(this);
                    uiData.avatar.allAddCallBack(this);
                    uiData.result.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                // GamePlayer
                {
                    if (data is GamePlayer)
                    {
                        GamePlayer gamePlayer = data as GamePlayer;
                        // Parent
                        {
                            DataUtils.addParentCallBack(gamePlayer, this, ref this.game);
                        }
                        // Child
                        {
                            gamePlayer.inform.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is Game)
                        {
                            Game game = data as Game;
                            // Child
                            {
                                game.state.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        {
                            if (data is GameState.State)
                            {
                                GameState.State state = data as GameState.State;
                                // Child
                                {
                                    if (state is GameState.End)
                                    {
                                        GameState.End end = state as GameState.End;
                                        end.results.allAddCallBack(this);
                                    }
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            if (data is GameState.Result)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
                    // Child
                    {
                        if (data is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = data as GamePlayer.Inform;
                            // Child
                            {
                                switch (inform.getType())
                                {
                                    case GamePlayer.Inform.Type.None:
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        break;
                                    case GamePlayer.Inform.Type.Human:
                                        {
                                            Human human = inform as Human;
                                            human.account.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType() + "; " + this);
                                        break;
                                }
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is Account)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (data is InformAvatarUI.UIData)
                {
                    InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(informAvatarUIData, informAvatarPrefab, this.transform, informAvatarRect);
                    }
                    dirty = true;
                    return;
                }
                if(data is ResultUI.UIData)
                {
                    ResultUI.UIData resultUIData = data as ResultUI.UIData;
                    // Child
                    {
                        UIUtils.Instantiate(resultUIData, resultPrefab, this.transform, resultRect);
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
                // Child
                {
                    uiData.gamePlayer.allRemoveCallBack(this);
                    uiData.avatar.allRemoveCallBack(this);
                    uiData.result.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                // GamePlayer
                {
                    if (data is GamePlayer)
                    {
                        GamePlayer gamePlayer = data as GamePlayer;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(gamePlayer, this, ref this.game);
                        }
                        // Child
                        {
                            gamePlayer.inform.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is Game)
                        {
                            Game game = data as Game;
                            // Child
                            {
                                game.state.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        {
                            if (data is GameState.State)
                            {
                                GameState.State state = data as GameState.State;
                                // Child
                                {
                                    if (state is GameState.End)
                                    {
                                        GameState.End end = state as GameState.End;
                                        end.results.allRemoveCallBack(this);
                                    }
                                }
                                return;
                            }
                            // Child
                            if (data is GameState.Result)
                            {
                                return;
                            }
                        }
                    }
                    // Child
                    {
                        if (data is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = data as GamePlayer.Inform;
                            // Child
                            {
                                switch (inform.getType())
                                {
                                    case GamePlayer.Inform.Type.None:
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        break;
                                    case GamePlayer.Inform.Type.Human:
                                        {
                                            Human human = inform as Human;
                                            human.account.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (data is Account)
                        {
                            return;
                        }
                    }
                }
                if (data is InformAvatarUI.UIData)
                {
                    InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
                    // UI
                    {
                        informAvatarUIData.removeCallBackAndDestroy(typeof(InformAvatarUI));
                    }
                    return;
                }
                if (data is ResultUI.UIData)
                {
                    ResultUI.UIData resultUIData = data as ResultUI.UIData;
                    // Child
                    {
                        resultUIData.removeCallBackAndDestroy(typeof(ResultUI));
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
                    case UIData.Property.gamePlayer:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.avatar:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.result:
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
                // GamePlayer
                {
                    if (wrapProperty.p is GamePlayer)
                    {
                        switch ((GamePlayer.Property)wrapProperty.n)
                        {
                            case GamePlayer.Property.playerIndex:
                                dirty = true;
                                break;
                            case GamePlayer.Property.inform:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GamePlayer.Property.state:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is Game)
                        {
                            switch ((Game.Property)wrapProperty.n)
                            {
                                case Game.Property.gamePlayers:
                                    break;
                                case Game.Property.requestDraw:
                                    break;
                                case Game.Property.state:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
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
                        // Child
                        {
                            if (wrapProperty.p is GameState.State)
                            {
                                if (wrapProperty.p is GameState.End)
                                {
                                    switch ((GameState.End.Property)wrapProperty.n)
                                    {
                                        case GameState.End.Property.results:
                                            {
                                                ValueChangeUtils.replaceCallBack(this, syncs);
                                                dirty = true;
                                            }
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                return;
                            }
                            // Child
                            if (wrapProperty.p is GameState.Result)
                            {
                                switch ((GameState.Result.Property)wrapProperty.n)
                                {
                                    case GameState.Result.Property.playerIndex:
                                        dirty = true;
                                        break;
                                    case GameState.Result.Property.score:
                                        dirty = true;
                                        break;
                                    case GameState.Result.Property.reason:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                        }
                    }
                    // Child
                    {
                        if (wrapProperty.p is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
                            // Child
                            {
                                switch (inform.getType())
                                {
                                    case GamePlayer.Inform.Type.None:
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        {
                                            switch ((Computer.Property)wrapProperty.n)
                                            {
                                                case Computer.Property.computerName:
                                                    dirty = true;
                                                    break;
                                                case Computer.Property.avatarUrl:
                                                    break;
                                                case Computer.Property.ai:
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    case GamePlayer.Inform.Type.Human:
                                        {
                                            switch ((Human.Property)wrapProperty.n)
                                            {
                                                case Human.Property.playerId:
                                                    break;
                                                case Human.Property.account:
                                                    {
                                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                                        dirty = true;
                                                    }
                                                    break;
                                                case Human.Property.state:
                                                    break;
                                                case Human.Property.email:
                                                    break;
                                                case Human.Property.phoneNumber:
                                                    break;
                                                case Human.Property.status:
                                                    break;
                                                case Human.Property.birthday:
                                                    break;
                                                case Human.Property.sex:
                                                    break;
                                                case Human.Property.connection:
                                                    break;
                                                case Human.Property.ban:
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType() + "; " + this);
                                        break;
                                }
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is Account)
                        {
                            Account.OnUpdateSyncAccount(wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is InformAvatarUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ResultUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}