using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateUI : UIBehavior<GamePlayerStateUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<GamePlayer.State>> state;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract GamePlayer.State.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        public VP<InformAvatarUI.UIData> avatar;

        #region Constructor

        public enum Property
        {
            state,
            sub,
            avatar
        }

        public UIData() : base()
        {
            this.state = new VP<ReferenceData<GamePlayer.State>>(this, (byte)Property.state, new ReferenceData<GamePlayer.State>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
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
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        GamePlayerStateUI gamePlayerStateUI = this.findCallBack<GamePlayerStateUI>();
                        if (gamePlayerStateUI != null)
                        {
                            gamePlayerStateUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("gamePlayerStateUI null");
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text tvPlayer;
    private static readonly TxtLanguage txtPlayer = new TxtLanguage();

    static GamePlayerStateUI()
    {
        txtTitle.add(Language.Type.vi, "Đầu Hàng");
        txtPlayer.add(Language.Type.vi, "Người chơi");
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
                GamePlayer.State state = this.data.state.v.data;
                if (state != null)
                {
                    // lbTitle
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Surrender");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    // tvPlayer
                    if (tvPlayer != null)
                    {
                        int playerIndex = 0;
                        {
                            GamePlayer gamePlayer = state.findDataInParent<GamePlayer>();
                            if (gamePlayer != null)
                            {
                                playerIndex = gamePlayer.playerIndex.v;
                            }
                            else
                            {
                                Debug.LogError("gamePlayer null");
                            }
                        }
                        tvPlayer.text = txtPlayer.get("Player") + ": " + playerIndex;
                    }
                    else
                    {
                        Debug.LogError("tvPlayer null");
                    }
                    // tvName
                    if (tvName != null)
                    {
                        string name = "";
                        {
                            GamePlayer gamePlayer = state.findDataInParent<GamePlayer>();
                            if (gamePlayer != null)
                            {
                                name = gamePlayer.inform.v.getPlayerName();
                            }
                            else
                            {
                                Debug.LogError("gamePlayer null");
                            }
                        }
                        tvName.text = name;
                    }
                    else
                    {
                        Debug.LogError("tvName null");
                    }
                    // avatar
                    {
                        InformAvatarUI.UIData avatar = this.data.avatar.v;
                        if (avatar != null)
                        {
                            GamePlayer.Inform inform = null;
                            {
                                GamePlayer gamePlayer = state.findDataInParent<GamePlayer>();
                                if (gamePlayer != null)
                                {
                                    inform = gamePlayer.inform.v;
                                }
                                else
                                {
                                    Debug.LogError("gamePlayer null");
                                }
                            }
                            avatar.inform.v = new ReferenceData<GamePlayer.Inform>(inform);
                        }
                        else
                        {
                            Debug.LogError("avatar null: " + this);
                        }
                    }
                    // sub
                    {
                        switch (state.getType())
                        {
                            case GamePlayer.State.Type.Normal:
                                {
                                    GamePlayerStateNormal gamePlayerStateNormal = state as GamePlayerStateNormal;
                                    // UIData
                                    GamePlayerStateNormalUI.UIData normalUIData = this.data.sub.newOrOld<GamePlayerStateNormalUI.UIData>();
                                    {
                                        normalUIData.normal.v = new ReferenceData<GamePlayerStateNormal>(gamePlayerStateNormal);
                                    }
                                    this.data.sub.v = normalUIData;
                                }
                                break;
                            case GamePlayer.State.Type.Surrender:
                                {
                                    GamePlayerStateSurrender gamePlayerStateSurrender = state as GamePlayerStateSurrender;
                                    // UIData
                                    GamePlayerStateSurrenderUI.UIData surrenderUIData = this.data.sub.newOrOld<GamePlayerStateSurrenderUI.UIData>();
                                    {
                                        surrenderUIData.surrender.v = new ReferenceData<GamePlayerStateSurrender>(gamePlayerStateSurrender);
                                    }
                                    this.data.sub.v = surrenderUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType());
                                break;
                        }
                    }
                }
                else
                {
                    Debug.LogError("state null: " + this);
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

    public GamePlayerStateNormalUI normalPrefab;
    public GamePlayerStateSurrenderUI surrenderPrefab;

    public InformAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    private GamePlayer gamePlayer = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.state.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
                uiData.avatar.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            // state
            {
                if(data is GamePlayer.State)
                {
                    GamePlayer.State state = data as GamePlayer.State;
                    // Parent
                    {
                        DataUtils.addParentCallBack(state, this, ref this.gamePlayer);
                    }
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if(data is GamePlayer)
                    {
                        GamePlayer gamePlayer = data as GamePlayer;
                        // child
                        {
                            gamePlayer.inform.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = data as GamePlayer.Inform;
                            // Child
                            {
                                if (inform is Human)
                                {
                                    Human human = inform as Human;
                                    human.account.allAddCallBack(this);
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
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GamePlayer.State.Type.Normal:
                            {
                                GamePlayerStateNormalUI.UIData normalUIData = sub as GamePlayerStateNormalUI.UIData;
                                UIUtils.Instantiate(normalUIData, normalPrefab, this.transform);
                            }
                            break;
                        case GamePlayer.State.Type.Surrender:
                            {
                                GamePlayerStateSurrenderUI.UIData surrenderUIData = sub as GamePlayerStateSurrenderUI.UIData;
                                UIUtils.Instantiate(surrenderUIData, surrenderPrefab, this.transform);
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
            if(data is InformAvatarUI.UIData)
            {
                InformAvatarUI.UIData avatarUIData = data as InformAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(avatarUIData, avatarPrefab, this.transform, avatarRect);
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
                uiData.state.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
                uiData.avatar.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            // state
            {
                if (data is GamePlayer.State)
                {
                    GamePlayer.State state = data as GamePlayer.State;
                    // Parent
                    {
                        DataUtils.removeParentCallBack(state, this, ref this.gamePlayer);
                    }
                    return;
                }
                // Parent
                {
                    if (data is GamePlayer)
                    {
                        GamePlayer gamePlayer = data as GamePlayer;
                        // child
                        {
                            gamePlayer.inform.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = data as GamePlayer.Inform;
                            // Child
                            {
                                if (inform is Human)
                                {
                                    Human human = inform as Human;
                                    human.account.allRemoveCallBack(this);
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
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case GamePlayer.State.Type.Normal:
                            {
                                GamePlayerStateNormalUI.UIData normalUIData = sub as GamePlayerStateNormalUI.UIData;
                                normalUIData.removeCallBackAndDestroy(typeof(GamePlayerStateNormalUI));
                            }
                            break;
                        case GamePlayer.State.Type.Surrender:
                            {
                                GamePlayerStateSurrenderUI.UIData surrenderUIData = sub as GamePlayerStateSurrenderUI.UIData;
                                surrenderUIData.removeCallBackAndDestroy(typeof(GamePlayerStateSurrenderUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
            if (data is InformAvatarUI.UIData)
            {
                InformAvatarUI.UIData avatarUIData = data as InformAvatarUI.UIData;
                // UI
                {
                    avatarUIData.removeCallBackAndDestroy(typeof(InformAvatarUI));
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
                case UIData.Property.state:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
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
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // state
            {
                if (wrapProperty.p is GamePlayer.State)
                {
                    return;
                }
                // Parent
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
                    // Child
                    {
                        if (wrapProperty.p is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
                            switch (inform.getType())
                            {
                                case GamePlayer.Inform.Type.None:
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
                                case GamePlayer.Inform.Type.Computer:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + inform.getType());
                                    break;
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
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            if(wrapProperty.p is InformAvatarUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            GamePlayerStateBtnUI.UIData stateBtnUIData = this.data.findDataInParent<GamePlayerStateBtnUI.UIData>();
            if (stateBtnUIData != null)
            {
                stateBtnUIData.stateUIData.v = null;
            }
            else
            {
                Debug.LogError("stateBtnUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}