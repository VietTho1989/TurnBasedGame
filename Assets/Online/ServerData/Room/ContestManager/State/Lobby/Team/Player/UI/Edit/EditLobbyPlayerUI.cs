using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class EditLobbyPlayerUI : UIBehavior<EditLobbyPlayerUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

            public VP<InformAvatarUI.UIData> avatar;

            public VP<LobbyPlayerBtnSetReady.UIData> btnReady;

            #region Sub

            public abstract class Sub : Data
            {

                public abstract RoomUser.Role getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                lobbyPlayer,
                avatar,
                btnReady,
                sub
            }

            public UIData() : base()
            {
                this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
                this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
                this.btnReady = new VP<LobbyPlayerBtnSetReady.UIData>(this, (byte)Property.btnReady, new LobbyPlayerBtnSetReady.UIData());
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
                            Debug.LogError("sub null: " + this);
                        }
                    }
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            EditLobbyPlayerUI editLobbyPlayerUI = this.findCallBack<EditLobbyPlayerUI>();
                            if (editLobbyPlayerUI != null)
                            {
                                editLobbyPlayerUI.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("editLobbyPlayerUI null: " + this);
                            }
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            EditLobbyPlayerUI editLobbyPlayerUI = this.findCallBack<EditLobbyPlayerUI>();
                            if (editLobbyPlayerUI != null)
                            {
                                isProcess = editLobbyPlayerUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("editLobbyPlayerUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Edit Lobby Player");

        public Text tvTeamIndex;
        private static readonly TxtLanguage txtTeamIndex = new TxtLanguage("Team index");

        public Text tvPlayerIndex;
        private static readonly TxtLanguage txtPlayerIndex = new TxtLanguage("Player index");

        public Text tvCannotEdit;
        private static readonly TxtLanguage txtCannotEdit = new TxtLanguage("Cannot Edit");

        static EditLobbyPlayerUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Chỉnh Sửa Người chơi");
                txtTeamIndex.add(Language.Type.vi, "Chỉ số đội");
                txtPlayerIndex.add(Language.Type.vi, "Chỉ số người chơi");
                txtCannotEdit.add(Language.Type.vi, "Không thể chỉnh sửa");
            }
            // rect
            {
                // avatarRect
                {
                    // anchoredPosition: (10.0, -105.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                    // offsetMin: (10.0, -141.0); offsetMax: (46.0, -105.0); sizeDelta: (36.0, 36.0);
                    avatarRect.anchoredPosition = new Vector3(10.0f, -105.0f, 0f);
                    avatarRect.anchorMin = new Vector2(0.0f, 1.0f);
                    avatarRect.anchorMax = new Vector2(0.0f, 1.0f);
                    avatarRect.pivot = new Vector2(0.0f, 1.0f);
                    avatarRect.offsetMin = new Vector2(10.0f, -141.0f);
                    avatarRect.offsetMax = new Vector2(46.0f, -105.0f);
                    avatarRect.sizeDelta = new Vector2(36.0f, 36.0f);
                }
                // btnReadyRect
                {
                    // anchoredPosition: (-5.0, -46.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
                    // offsetMin: (-41.0, -82.0); offsetMax: (-5.0, -46.0); sizeDelta: (36.0, 36.0);
                    btnReadyRect.anchoredPosition = new Vector3(-5.0f, -46.0f, 0.0f);
                    btnReadyRect.anchorMin = new Vector2(1.0f, 1.0f);
                    btnReadyRect.anchorMax = new Vector2(1.0f, 1.0f);
                    btnReadyRect.pivot = new Vector2(1.0f, 1.0f);
                    btnReadyRect.offsetMin = new Vector2(-41.0f, -82.0f);
                    btnReadyRect.offsetMax = new Vector2(-5.0f, -46.0f);
                    btnReadyRect.sizeDelta = new Vector2(36.0f, 36.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvPlayerName;
        public Button btnBack;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
                    if (lobbyPlayer != null)
                    {
                        if (lobbyPlayer.getDataParent() != null)
                        {
                            // tvTeamIndex
                            {
                                if (tvTeamIndex != null)
                                {
                                    int teamIndex = 0;
                                    {
                                        LobbyTeam lobbyTeam = lobbyPlayer.findDataInParent<LobbyTeam>();
                                        if (lobbyTeam != null)
                                        {
                                            teamIndex = lobbyTeam.teamIndex.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("lobbyTeam null: " + this);
                                        }
                                    }
                                    tvTeamIndex.text = txtTeamIndex.get() + ": " + teamIndex;
                                    Setting.get().setContentTextSize(tvTeamIndex);
                                }
                                else
                                {
                                    Debug.LogError("tvTeamIndex null: " + this);
                                }
                            }
                            // tvPlayerIndex
                            {
                                if (tvPlayerIndex != null)
                                {
                                    tvPlayerIndex.text = txtPlayerIndex.get() + ": " + lobbyPlayer.playerIndex.v;
                                    Setting.get().setContentTextSize(tvPlayerIndex);
                                }
                                else
                                {
                                    Debug.LogError("tvPlayerIndex null: " + this);
                                }
                            }
                            // avatar
                            {
                                InformAvatarUI.UIData avatar = this.data.avatar.v;
                                if (avatar != null)
                                {
                                    avatar.inform.v = new ReferenceData<GamePlayer.Inform>(lobbyPlayer.inform.v);
                                }
                                else
                                {
                                    Debug.LogError("avatar null: " + this);
                                }
                            }
                            // tvPlayerName
                            {
                                if (tvPlayerName != null)
                                {
                                    string strName = "";
                                    {
                                        GamePlayer.Inform inform = lobbyPlayer.inform.v;
                                        if (inform != null)
                                        {
                                            strName = inform.getPlayerName();
                                        }
                                        else
                                        {
                                            Debug.LogError("inform null: " + this);
                                        }
                                    }
                                    tvPlayerName.text = string.IsNullOrEmpty(strName) ? "?" : strName;
                                    Setting.get().setContentTextSize(tvPlayerName);
                                }
                                else
                                {
                                    Debug.LogError("tvName null: " + this);
                                }
                            }
                            // btnReady
                            {
                                LobbyPlayerBtnSetReady.UIData btnReady = this.data.btnReady.v;
                                if (btnReady != null)
                                {
                                    btnReady.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
                                }
                                else
                                {
                                    Debug.LogError("btnReady null: " + this);
                                }
                            }
                            // sub
                            {
                                bool canEdit = true;
                                {
                                    ContestManagerStateLobby contestManagerStateLobby = lobbyPlayer.findDataInParent<ContestManagerStateLobby>();
                                    if (contestManagerStateLobby != null)
                                    {
                                        if (!(contestManagerStateLobby.state.v is Lobby.StateNormal))
                                        {
                                            canEdit = false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("contestManagerStateLobby null: " + this);
                                    }
                                }
                                // Process
                                if (canEdit)
                                {
                                    if (Room.isYouAdmin(lobbyPlayer))
                                    {
                                        AdminEditLobbyPlayerUI.UIData adminEditLobbyPlayerUIData = this.data.sub.newOrOld<AdminEditLobbyPlayerUI.UIData>();
                                        {
                                            adminEditLobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
                                        }
                                        this.data.sub.v = adminEditLobbyPlayerUIData;
                                    }
                                    else
                                    {
                                        NormalEditLobbyPlayerUI.UIData normalEditLobbyPlayerUIData = this.data.sub.newOrOld<NormalEditLobbyPlayerUI.UIData>();
                                        {
                                            normalEditLobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
                                        }
                                        this.data.sub.v = normalEditLobbyPlayerUIData;
                                    }
                                    UIRectTransform.SetActive(this.data.sub.v, true);
                                }
                                else
                                {
                                    UIRectTransform.SetActive(this.data.sub.v, false);
                                }
                                // tvCannotEdit
                                if (tvCannotEdit != null)
                                {
                                    tvCannotEdit.gameObject.SetActive(!canEdit);
                                }
                                else
                                {
                                    Debug.LogError("tvCannotEdit null");
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("data parent null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("lobbyPlayer null: " + this);
                    }
                    // siblingIndex
                    {

                    }
                    // UI
                    {
                        float buttonSize = Setting.get().buttonSize.v;
                        float deltaY = 0;
                        // header
                        {
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            UIRectTransform.SetTitleTransform(lbTitle);
                            deltaY += buttonSize;
                        }
                        // tvTeamIndex
                        {
                            if (tvTeamIndex != null)
                            {
                                UIRectTransform.SetPosY(tvTeamIndex.rectTransform, deltaY + 10);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("tvTeamIndex null");
                            }
                        }
                        // tvPlayerIndex
                        {
                            if (tvPlayerIndex != null)
                            {
                                UIRectTransform.SetPosY(tvPlayerIndex.rectTransform, deltaY + 10);
                                deltaY += 40;
                            }
                            else
                            {
                                Debug.LogError("tvPlayerIndex null");
                            }
                        }
                        // playerName
                        {
                            if (tvPlayerName != null)
                            {
                                UIRectTransform.SetPosY(tvPlayerName.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("tvPlayerName null");
                            }
                            UIRectTransform.SetPosY(this.data.avatar.v, deltaY + 5);
                            deltaY += 50;
                        }
                        // subContainer
                        {
                            if (subContainer != null)
                            {
                                UIRectTransform.SetPosY(subContainer, deltaY);
                                deltaY += 250;
                            }
                            else
                            {
                                Debug.LogError("subContainer null");
                            }
                        }
                        // set contentContainer
                        {
                            if (contentContainer != null)
                            {
                                UIRectTransform rect = UIRectTransform.CreateCenterRect(360, deltaY);
                                rect.set(contentContainer);
                            }
                            else
                            {
                                Debug.LogError("contentContainer null");
                            }
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvCannotEdit != null)
                        {
                            tvCannotEdit.text = txtCannotEdit.get();
                        }
                        else
                        {
                            Debug.LogError("tvCannotEdit null");
                        }
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

        public RectTransform contentContainer;

        public InformAvatarUI avatarPrefab;
        private static readonly UIRectTransform avatarRect = new UIRectTransform();

        public LobbyPlayerBtnSetReady btnReadyPrefab;
        private static readonly UIRectTransform btnReadyRect = new UIRectTransform();

        public AdminEditLobbyPlayerUI adminEditPrefab;
        public NormalEditLobbyPlayerUI normalEditPrefab;
        public RectTransform subContainer;

        private RoomCheckChangeAdminChange<LobbyPlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<LobbyPlayer>();

        private LobbyTeam lobbyTeam = null;
        private ContestManagerStateLobby contestManagerStateLobby = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.lobbyPlayer.allAddCallBack(this);
                    uiData.avatar.allAddCallBack(this);
                    uiData.btnReady.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
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
                // LobbyPlayer
                {
                    if (data is LobbyPlayer)
                    {
                        LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                        // CheckChange
                        {
                            roomCheckAdminChange.addCallBack(this);
                            roomCheckAdminChange.setData(lobbyPlayer);
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(lobbyPlayer, this, ref this.lobbyTeam);
                            DataUtils.addParentCallBack(lobbyPlayer, this, ref this.contestManagerStateLobby);
                        }
                        // Child
                        {
                            lobbyPlayer.inform.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<LobbyPlayer>)
                    {
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is LobbyTeam)
                        {
                            dirty = true;
                            return;
                        }
                        if (data is ContestManagerStateLobby)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Child
                    {
                        if(data is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = data as GamePlayer.Inform;
                            // Child
                            {
                                switch (inform.getType())
                                {
                                    case GamePlayer.Inform.Type.None:
                                        break;
                                    case GamePlayer.Inform.Type.Human:
                                        {
                                            Human human = inform as Human;
                                            human.account.allAddCallBack(this);
                                        }
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType());
                                        break;
                                }
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if(data is Account)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (data is InformAvatarUI.UIData)
                {
                    InformAvatarUI.UIData avatar = data as InformAvatarUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(avatar, avatarPrefab, contentContainer, avatarRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is LobbyPlayerBtnSetReady.UIData)
                {
                    LobbyPlayerBtnSetReady.UIData btnReady = data as LobbyPlayerBtnSetReady.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnReady, btnReadyPrefab, contentContainer, btnReadyRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case RoomUser.Role.ADMIN:
                                {
                                    AdminEditLobbyPlayerUI.UIData adminEdit = sub as AdminEditLobbyPlayerUI.UIData;
                                    UIUtils.Instantiate(adminEdit, adminEditPrefab, subContainer);
                                }
                                break;
                            case RoomUser.Role.NORMAL:
                                {
                                    NormalEditLobbyPlayerUI.UIData normalEdit = sub as NormalEditLobbyPlayerUI.UIData;
                                    UIUtils.Instantiate(normalEdit, normalEditPrefab, subContainer);
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
                    uiData.lobbyPlayer.allRemoveCallBack(this);
                    uiData.avatar.allRemoveCallBack(this);
                    uiData.btnReady.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
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
                // LobbyPlayer
                {
                    if (data is LobbyPlayer)
                    {
                        LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                        // CheckChange
                        {
                            roomCheckAdminChange.removeCallBack(this);
                            roomCheckAdminChange.setData(null);
                        }
                        // Parent
                        {
                            DataUtils.removeParentCallBack(lobbyPlayer, this, ref this.lobbyTeam);
                            DataUtils.removeParentCallBack(lobbyPlayer, this, ref this.contestManagerStateLobby);
                        }
                        // Child
                        {
                            lobbyPlayer.inform.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<LobbyPlayer>)
                    {
                        return;
                    }
                    // Parent
                    {
                        if (data is LobbyTeam)
                        {
                            return;
                        }
                        if (data is ContestManagerStateLobby)
                        {
                            return;
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
                                    case GamePlayer.Inform.Type.Human:
                                        {
                                            Human human = inform as Human;
                                            human.account.allRemoveCallBack(this);
                                        }
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType());
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
                    InformAvatarUI.UIData avatar = data as InformAvatarUI.UIData;
                    // UI
                    {
                        avatar.removeCallBackAndDestroy(typeof(InformAvatarUI));
                    }
                    return;
                }
                if (data is LobbyPlayerBtnSetReady.UIData)
                {
                    LobbyPlayerBtnSetReady.UIData btnReady = data as LobbyPlayerBtnSetReady.UIData;
                    // UI
                    {
                        btnReady.removeCallBackAndDestroy(typeof(LobbyPlayerBtnSetReady));
                    }
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case RoomUser.Role.ADMIN:
                                {
                                    AdminEditLobbyPlayerUI.UIData adminEdit = sub as AdminEditLobbyPlayerUI.UIData;
                                    adminEdit.removeCallBackAndDestroy(typeof(AdminEditLobbyPlayerUI));
                                }
                                break;
                            case RoomUser.Role.NORMAL:
                                {
                                    NormalEditLobbyPlayerUI.UIData normalEdit = sub as NormalEditLobbyPlayerUI.UIData;
                                    normalEdit.removeCallBackAndDestroy(typeof(NormalEditLobbyPlayerUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
                    case UIData.Property.lobbyPlayer:
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
                    case UIData.Property.btnReady:
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
                    default:
                        Debug.LogError("Don't prococess: " + wrapProperty + "; " + this);
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
                    case Setting.Property.style:
                        break;
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.buttonSize:
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
                // LobbyPlayer
                {
                    if (wrapProperty.p is LobbyPlayer)
                    {
                        switch ((LobbyPlayer.Property)wrapProperty.n)
                        {
                            case LobbyPlayer.Property.playerIndex:
                                dirty = true;
                                break;
                            case LobbyPlayer.Property.inform:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case LobbyPlayer.Property.isReady:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is RoomCheckChangeAdminChange<LobbyPlayer>)
                    {
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is LobbyTeam)
                        {
                            switch ((LobbyTeam.Property)wrapProperty.n)
                            {
                                case LobbyTeam.Property.teamIndex:
                                    dirty = true;
                                    break;
                                case LobbyTeam.Property.players:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        if (wrapProperty.p is ContestManagerStateLobby)
                        {
                            switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                            {
                                case ContestManagerStateLobby.Property.state:
                                    dirty = true;
                                    break;
                                case ContestManagerStateLobby.Property.teams:
                                    break;
                                case ContestManagerStateLobby.Property.gameType:
                                    break;
                                case ContestManagerStateLobby.Property.randomTeamIndex:
                                    break;
                                case ContestManagerStateLobby.Property.contentFactory:
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
                        if (wrapProperty.p is GamePlayer.Inform)
                        {
                            GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
                            // Child
                            {
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
                                            Human human = inform as Human;
                                            human.account.allAddCallBack(this);
                                        }
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        {
                                            switch ((Computer.Property)wrapProperty.n)
                                            {
                                                case Computer.Property.computerName:
                                                    dirty = true;
                                                    break;
                                                case Computer.Property.avatarUrl:
                                                    dirty = true;
                                                    break;
                                                case Computer.Property.ai:
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType());
                                        break;
                                }
                            }
                            dirty = true;
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
                if (wrapProperty.p is LobbyPlayerBtnSetReady.UIData)
                {
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = this.data.findDataInParent<ContestManagerStateLobbyUI.UIData>();
                if (contestManagerStateLobbyUIData != null)
                {
                    contestManagerStateLobbyUIData.editLobbyPlayer.v = null;
                }
                else
                {
                    Debug.LogError("contestManagerStateLobbyUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}