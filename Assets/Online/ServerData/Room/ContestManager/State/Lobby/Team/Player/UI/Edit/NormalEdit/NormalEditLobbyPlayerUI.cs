using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class NormalEditLobbyPlayerUI : UIBehavior<NormalEditLobbyPlayerUI.UIData>
    {

        #region UIData

        public class UIData : EditLobbyPlayerUI.UIData.Sub
        {

            public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

            public VP<NormalEditLobbyPlayerBtnSetUI.UIData> btnSet;

            public VP<NormalEditLobbyPlayerBtnEmptyUI.UIData> btnEmpty;

            #region Constructor

            public enum Property
            {
                lobbyPlayer,
                btnSet,
                btnEmpty
            }

            public UIData() : base()
            {
                this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
                this.btnSet = new VP<NormalEditLobbyPlayerBtnSetUI.UIData>(this, (byte)Property.btnSet, new NormalEditLobbyPlayerBtnSetUI.UIData());
                this.btnEmpty = new VP<NormalEditLobbyPlayerBtnEmptyUI.UIData>(this, (byte)Property.btnEmpty, new NormalEditLobbyPlayerBtnEmptyUI.UIData());
            }

            #endregion

            public override RoomUser.Role getType()
            {
                return RoomUser.Role.NORMAL;
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

        #region txt, rect

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Normal Edit Lobby Player");

        public Text tvCannotEdit;
        private static readonly TxtLanguage txtCannotEdit = new TxtLanguage("Don't have rights to edit");

        static NormalEditLobbyPlayerUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Chỉnh sửa người chơi");
                txtCannotEdit.add(Language.Type.vi, "Không có quyền chỉnh sửa");
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
                    LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
                    if (lobbyPlayer != null)
                    {
                        // btnSet
                        {
                            NormalEditLobbyPlayerBtnSetUI.UIData btnSet = this.data.btnSet.v;
                            if (btnSet != null)
                            {
                                btnSet.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
                            }
                            else
                            {
                                Debug.LogError("btnSet null: " + this);
                            }
                        }
                        // btnEmpty
                        {
                            NormalEditLobbyPlayerBtnEmptyUI.UIData btnEmpty = this.data.btnEmpty.v;
                            if (btnEmpty != null)
                            {
                                btnEmpty.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
                            }
                            else
                            {
                                Debug.LogError("btnEmpty null: " + this);
                            }
                        }
                        // tvCannotEdit
                        {
                            if (tvCannotEdit != null)
                            {
                                // find
                                bool canEdit = false;
                                {
                                    // canSet
                                    bool canSet = true;
                                    {
                                        NormalEditLobbyPlayerBtnSetUI.UIData btnSet = this.data.btnSet.v;
                                        if (btnSet != null)
                                        {
                                            canSet = btnSet.canSet.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("btnSet null: " + this);
                                        }
                                    }
                                    // canEmpty
                                    bool canEmpty = true;
                                    {
                                        NormalEditLobbyPlayerBtnEmptyUI.UIData btnEmpty = this.data.btnEmpty.v;
                                        if (btnEmpty != null)
                                        {
                                            canEmpty = btnEmpty.canEmpty.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("btnEmpty null: " + this);
                                        }
                                    }
                                    // canEdit
                                    if (canSet || canEmpty)
                                    {
                                        canEdit = true;
                                    }
                                    else
                                    {
                                        canEdit = false;
                                    }
                                }
                                tvCannotEdit.gameObject.SetActive(!canEdit);
                            }
                            else
                            {
                                Debug.LogError("tvCannotEdit null");
                            }
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
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
                        Debug.LogError("lobbyPlayer null: " + this);
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

        public NormalEditLobbyPlayerBtnSetUI btnSetPrefab;
        private static readonly UIRectTransform btnSetRect = UIRectTransform.CreateCenterRect(120, 24);

        public NormalEditLobbyPlayerBtnEmptyUI btnEmptyPrefab;
        private static readonly UIRectTransform btnEmptyRect = UIRectTransform.CreateCenterRect(120, 24);

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
                    uiData.btnSet.allAddCallBack(this);
                    uiData.btnEmpty.allAddCallBack(this);
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
                if (data is LobbyPlayer)
                {
                    dirty = true;
                    return;
                }
                if (data is NormalEditLobbyPlayerBtnSetUI.UIData)
                {
                    NormalEditLobbyPlayerBtnSetUI.UIData btnSet = data as NormalEditLobbyPlayerBtnSetUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnSet, btnSetPrefab, this.transform, btnSetRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is NormalEditLobbyPlayerBtnEmptyUI.UIData)
                {
                    NormalEditLobbyPlayerBtnEmptyUI.UIData btnEmpty = data as NormalEditLobbyPlayerBtnEmptyUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnEmpty, btnEmptyPrefab, this.transform, btnEmptyRect);
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
                    uiData.btnSet.allRemoveCallBack(this);
                    uiData.btnEmpty.allRemoveCallBack(this);
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
                if (data is LobbyPlayer)
                {
                    return;
                }
                if (data is NormalEditLobbyPlayerBtnSetUI.UIData)
                {
                    NormalEditLobbyPlayerBtnSetUI.UIData btnSet = data as NormalEditLobbyPlayerBtnSetUI.UIData;
                    // UI
                    {
                        btnSet.removeCallBackAndDestroy(typeof(NormalEditLobbyPlayerBtnSetUI));
                    }
                    return;
                }
                if (data is NormalEditLobbyPlayerBtnEmptyUI.UIData)
                {
                    NormalEditLobbyPlayerBtnEmptyUI.UIData btnEmpty = data as NormalEditLobbyPlayerBtnEmptyUI.UIData;
                    // UI
                    {
                        btnEmpty.removeCallBackAndDestroy(typeof(NormalEditLobbyPlayerBtnEmptyUI));
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
                    case UIData.Property.btnSet:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnEmpty:
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
                if (wrapProperty.p is LobbyPlayer)
                {
                    return;
                }
                if (wrapProperty.p is NormalEditLobbyPlayerBtnSetUI.UIData)
                {
                    switch ((NormalEditLobbyPlayerBtnSetUI.UIData.Property)wrapProperty.n)
                    {
                        case NormalEditLobbyPlayerBtnSetUI.UIData.Property.lobbyPlayer:
                            break;
                        case NormalEditLobbyPlayerBtnSetUI.UIData.Property.state:
                            break;
                        case NormalEditLobbyPlayerBtnSetUI.UIData.Property.canSet:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is NormalEditLobbyPlayerBtnEmptyUI.UIData)
                {
                    switch ((NormalEditLobbyPlayerBtnEmptyUI.UIData.Property)wrapProperty.n)
                    {
                        case NormalEditLobbyPlayerBtnEmptyUI.UIData.Property.lobbyPlayer:
                            break;
                        case NormalEditLobbyPlayerBtnEmptyUI.UIData.Property.state:
                            break;
                        case NormalEditLobbyPlayerBtnEmptyUI.UIData.Property.canEmpty:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}