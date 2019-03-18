using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestManagerInformUI : UIBehavior<ContestManagerInformUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ContestManager>> contestManager;

            #region stateUI

            public abstract class StateUI : Data
            {

                public abstract ContestManager.State.Type getType();

            }

            public VP<StateUI> stateUI;

            #endregion

            #region Constructor

            public enum Property
            {
                contestManager,
                stateUI
            }

            public UIData() : base()
            {
                this.contestManager = new VP<ReferenceData<ContestManager>>(this, (byte)Property.contestManager, new ReferenceData<ContestManager>(null));
                this.stateUI = new VP<StateUI>(this, (byte)Property.stateUI, null);
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        static ContestManagerInformUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Giải Đấu");
            }
            // rect
            {
                // stateUIRect
                {
                    // anchoredPosition: (0.0, -90.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (0.0, -150.0); offsetMax: (0.0, -90.0); sizeDelta: (0.0, 60.0);
                    stateUIRect.anchoredPosition = new Vector3(0.0f, -30.0f, 0.0f);
                    stateUIRect.anchorMin = new Vector2(0.0f, 1.0f);
                    stateUIRect.anchorMax = new Vector2(1.0f, 1.0f);
                    stateUIRect.pivot = new Vector2(0.5f, 1.0f);
                    stateUIRect.offsetMin = new Vector2(0.0f, -90.0f);
                    stateUIRect.offsetMax = new Vector2(0.0f, -30.0f);
                    stateUIRect.sizeDelta = new Vector2(0.0f, 60.0f);
                }
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
                    ContestManager contestManager = this.data.contestManager.v.data;
                    if (contestManager != null)
                    {
                        // title
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Tournament") + " " + (contestManager.index.v + 1);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        // stateUI
                        {
                            ContestManager.State state = contestManager.state.v;
                            if (state != null)
                            {
                                switch (state.getType())
                                {
                                    case ContestManager.State.Type.Lobby:
                                        {
                                            ContestManagerStateLobby lobby = state as ContestManagerStateLobby;
                                            // UIData
                                            ContestManagerStateLobbyInformUI.UIData lobbyInformUIData = this.data.stateUI.newOrOld<ContestManagerStateLobbyInformUI.UIData>();
                                            {
                                                lobbyInformUIData.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby>(lobby);
                                            }
                                            this.data.stateUI.v = lobbyInformUIData;
                                        }
                                        break;
                                    case ContestManager.State.Type.Play:
                                        {
                                            ContestManagerStatePlay play = state as ContestManagerStatePlay;
                                            // UIData
                                            ContestManagerStatePlayInformUI.UIData playInformUIData = this.data.stateUI.newOrOld<ContestManagerStatePlayInformUI.UIData>();
                                            {
                                                playInformUIData.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay>(play);
                                            }
                                            this.data.stateUI.v = playInformUIData;
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
                    }
                    else
                    {
                        Debug.LogError("contestManager null: " + this);
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

        public ContestManagerStateLobbyInformUI lobbyPrefab;
        public ContestManagerStatePlayInformUI playPrefab;
        private static readonly UIRectTransform stateUIRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.contestManager.allAddCallBack(this);
                    uiData.stateUI.allAddCallBack(this);
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
                if (data is ContestManager)
                {
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
                            case ContestManager.State.Type.Lobby:
                                {
                                    ContestManagerStateLobbyInformUI.UIData lobbyUIData = stateUIData as ContestManagerStateLobbyInformUI.UIData;
                                    UIUtils.Instantiate(lobbyUIData, lobbyPrefab, this.transform, stateUIRect);
                                }
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    ContestManagerStatePlayInformUI.UIData playUIData = stateUIData as ContestManagerStatePlayInformUI.UIData;
                                    UIUtils.Instantiate(playUIData, playPrefab, this.transform, stateUIRect);
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
                // Child
                {
                    uiData.contestManager.allRemoveCallBack(this);
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
            // Child
            {
                if (data is ContestManager)
                {
                    return;
                }
                if (data is UIData.StateUI)
                {
                    UIData.StateUI stateUIData = data as UIData.StateUI;
                    // UI
                    {
                        switch (stateUIData.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                {
                                    ContestManagerStateLobbyInformUI.UIData lobbyUIData = stateUIData as ContestManagerStateLobbyInformUI.UIData;
                                    lobbyUIData.removeCallBackAndDestroy(typeof(ContestManagerStateLobbyInformUI));
                                }
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    ContestManagerStatePlayInformUI.UIData playUIData = stateUIData as ContestManagerStatePlayInformUI.UIData;
                                    playUIData.removeCallBackAndDestroy(typeof(ContestManagerStatePlayInformUI));
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
                    case UIData.Property.contestManager:
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
            // Child
            {
                if (wrapProperty.p is ContestManager)
                {
                    switch ((ContestManager.Property)wrapProperty.n)
                    {
                        case ContestManager.Property.index:
                            dirty = true;
                            break;
                        case ContestManager.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
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

    }
}