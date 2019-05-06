using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapPlayerUI : UIBehavior<SwapPlayerUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<TeamPlayer>> teamPlayer;

            public VP<InformAvatarUI.UIData> avatar;

            #region Constructor

            public enum Property
            {
                teamPlayer,
                avatar
            }

            public UIData() : base()
            {
                this.teamPlayer = new VP<ReferenceData<TeamPlayer>>(this, (byte)Property.teamPlayer, new ReferenceData<TeamPlayer>(null));
                this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            SwapPlayerUI swapPlayerUI = this.findCallBack<SwapPlayerUI>();
                            if (swapPlayerUI != null)
                            {
                                isProcess = swapPlayerUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("swapPlayerUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        static SwapPlayerUI()
        {
            // rect
            {
                // avatarRect
                {
                    // anchoredPosition: (6.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (0.0, 0.5); pivot: (0.0, 0.5);
                    // offsetMin: (6.0, -18.0); offsetMax: (42.0, 18.0); sizeDelta: (36.0, 36.0);
                    avatarRect.anchoredPosition = new Vector3(6.0f, 0.0f, 0.0f);
                    avatarRect.anchorMin = new Vector2(0.0f, 0.5f);
                    avatarRect.anchorMax = new Vector2(0.0f, 0.5f);
                    avatarRect.pivot = new Vector2(0.0f, 0.5f);
                    avatarRect.offsetMin = new Vector2(6.0f, -18.0f);
                    avatarRect.offsetMax = new Vector2(42.0f, 18.0f);
                    avatarRect.sizeDelta = new Vector2(36.0f, 36.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvPlayerIndex;
        public Text tvPlayerName;
        public Button btnShow;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
                    if (teamPlayer != null)
                    {
                        // tvPlayerIndex
                        {
                            if (tvPlayerIndex != null)
                            {
                                tvPlayerIndex.text = "" + teamPlayer.playerIndex.v;
                            }
                            else
                            {
                                Debug.LogError("tvPlayerIndex null: " + this);
                            }
                        }
                        // tvPlayerName
                        {
                            if (tvPlayerName != null)
                            {
                                tvPlayerName.text = "" + teamPlayer.inform.v.getPlayerName();
                            }
                            else
                            {
                                Debug.LogError("tvPlayerName null: " + this);
                            }
                        }
                        // avatar
                        {
                            InformAvatarUI.UIData avatar = this.data.avatar.v;
                            if (avatar != null)
                            {
                                avatar.inform.v = new ReferenceData<GamePlayer.Inform>(teamPlayer.inform.v);
                            }
                            else
                            {
                                Debug.LogError("avatar null: " + this);
                            }
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                btnShow.transform.SetAsFirstSibling();
                                // check isSelected
                                bool alreadySelected = false;
                                {
                                    SwapUI.UIData swapUIData = this.data.findDataInParent<SwapUI.UIData>();
                                    if (swapUIData != null)
                                    {
                                        SwapPlayerInformUI.UIData swapPlayerInformUIData = swapUIData.swapPlayerInformUIData.v;
                                        if (swapPlayerInformUIData != null)
                                        {
                                            if (swapPlayerInformUIData.teamPlayer.v.data == teamPlayer)
                                            {
                                                alreadySelected = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("swapPlayerInformUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("swapUIData null");
                                    }
                                }
                                // process
                                btnShow.interactable = !alreadySelected;
                            }
                            else
                            {
                                Debug.LogError("btnShow null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("teamPlayer null: " + this);
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

        public InformAvatarUI avatarPrefab;
        private static readonly UIRectTransform avatarRect = new UIRectTransform();

        private SwapUI.UIData swapUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.swapUIData);
                }
                // Child
                {
                    uiData.teamPlayer.allAddCallBack(this);
                    uiData.avatar.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is SwapUI.UIData)
                {
                    SwapUI.UIData swapUIData = data as SwapUI.UIData;
                    // Child
                    {
                        swapUIData.swapPlayerInformUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is SwapPlayerInformUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                // teamPlayer
                {
                    if (data is TeamPlayer)
                    {
                        TeamPlayer teamPlayer = data as TeamPlayer;
                        // Child
                        {
                            teamPlayer.inform.allAddCallBack(this);
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
                    InformAvatarUI.UIData avatar = data as InformAvatarUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(avatar, avatarPrefab, this.transform, avatarRect);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.swapUIData);
                }
                // Child
                {
                    uiData.teamPlayer.allRemoveCallBack(this);
                    uiData.avatar.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is SwapUI.UIData)
                {
                    SwapUI.UIData swapUIData = data as SwapUI.UIData;
                    // Child
                    {
                        swapUIData.swapPlayerInformUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is SwapPlayerInformUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                // teamPlayer
                {
                    if (data is TeamPlayer)
                    {
                        TeamPlayer teamPlayer = data as TeamPlayer;
                        // Child
                        {
                            teamPlayer.inform.allRemoveCallBack(this);
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
                    InformAvatarUI.UIData avatar = data as InformAvatarUI.UIData;
                    // UI
                    {
                        avatar.removeCallBackAndDestroy(typeof(InformAvatarUI));
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
                    case UIData.Property.teamPlayer:
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
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is SwapUI.UIData)
                {
                    switch ((SwapUI.UIData.Property)wrapProperty.n)
                    {
                        case SwapUI.UIData.Property.swap:
                            break;
                        case SwapUI.UIData.Property.swapTeamAdapter:
                            break;
                        case SwapUI.UIData.Property.swapPlayerInformUIData:
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
                if (wrapProperty.p is SwapPlayerInformUI.UIData)
                {
                    switch ((SwapPlayerInformUI.UIData.Property)wrapProperty.n)
                    {
                        case SwapPlayerInformUI.UIData.Property.teamPlayer:
                            dirty = true;
                            break;
                        case SwapPlayerInformUI.UIData.Property.informUI:
                            break;
                        case SwapPlayerInformUI.UIData.Property.sub:
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
                // teamPlayer
                {
                    if (wrapProperty.p is TeamPlayer)
                    {
                        switch ((TeamPlayer.Property)wrapProperty.n)
                        {
                            case TeamPlayer.Property.playerIndex:
                                dirty = true;
                                break;
                            case TeamPlayer.Property.inform:
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.S:
                            {
                                if (btnShow != null && btnShow.gameObject.activeInHierarchy && btnShow.interactable)
                                {
                                    this.onClickBtnShow();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
                if (teamPlayer != null)
                {
                    SwapUI.UIData swapUIData = this.data.findDataInParent<SwapUI.UIData>();
                    if (swapUIData != null)
                    {
                        SwapPlayerInformUI.UIData swapPlayerInformUIData = swapUIData.swapPlayerInformUIData.v;
                        if (swapPlayerInformUIData != null)
                        {
                            swapPlayerInformUIData.teamPlayer.v = new ReferenceData<TeamPlayer>(teamPlayer);
                        }
                        else
                        {
                            Debug.LogError("swapPlayerInformUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("swapUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("teamPlayer null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}