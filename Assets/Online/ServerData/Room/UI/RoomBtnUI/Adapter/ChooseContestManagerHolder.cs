using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ChooseContestManagerHolder : SriaHolderBehavior<ChooseContestManagerHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<ContestManager>> contestManager;

            #region state

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

            public void updateView(ChooseContestManagerAdapter.UIData myParams)
            {
                // Find
                ContestManager contestManager = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.contestManagers.Count)
                    {
                        contestManager = myParams.contestManagers[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.contestManager.v = new ReferenceData<ContestManager>(contestManager);
            }

        }

        #endregion

        #region txt

        public Text tvShow;
        private static readonly TxtLanguage txtShow = new TxtLanguage("Show");

        static ChooseContestManagerHolder()
        {
            txtShow.add(Language.Type.vi, "Hiện");
            // rect
            {
                // stateUIRect
                {
                    // anchoredPosition: (-14.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (30.0, -50.0); offsetMax: (-58.0, 0.0); sizeDelta: (-88.0, 50.0);
                    stateUIRect.anchoredPosition = new Vector3(-14.0f, 0.0f, 0.0f);
                    stateUIRect.anchorMin = new Vector2(0.0f, 1.0f);
                    stateUIRect.anchorMax = new Vector2(1.0f, 1.0f);
                    stateUIRect.pivot = new Vector2(0.5f, 1.0f);
                    stateUIRect.offsetMin = new Vector2(30.0f, -50.0f);
                    stateUIRect.offsetMax = new Vector2(-58.0f, 0.0f);
                    stateUIRect.sizeDelta = new Vector2(-88.0f, 50.0f);
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
                    ContestManager contestManager = this.data.contestManager.v.data;
                    if (contestManager != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (contestManager.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
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
                                            ContestManagerStateLobby contestManagerStateLobby = state as ContestManagerStateLobby;
                                            // UIData
                                            ChooseContestManagerStateLobbyUI.UIData chooseContestManagerStateLobbyUIData = this.data.stateUI.newOrOld<ChooseContestManagerStateLobbyUI.UIData>();
                                            {
                                                chooseContestManagerStateLobbyUIData.contestManagerStateLobby.v = new ReferenceData<ContestManagerStateLobby>(contestManagerStateLobby);
                                            }
                                            this.data.stateUI.v = chooseContestManagerStateLobbyUIData;
                                        }
                                        break;
                                    case ContestManager.State.Type.Play:
                                        {
                                            ContestManagerStatePlay contestManagerStatePlay = state as ContestManagerStatePlay;
                                            // UIData
                                            ChooseContestManagerStatePlayUI.UIData chooseContestManagerStatePlayUIData = this.data.stateUI.newOrOld<ChooseContestManagerStatePlayUI.UIData>();
                                            {
                                                chooseContestManagerStatePlayUIData.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay>(contestManagerStatePlay);
                                            }
                                            this.data.stateUI.v = chooseContestManagerStatePlayUIData;
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
                        // UI
                        {
                            float deltaY = 0;
                            // stateUI
                            deltaY += UIRectTransform.SetPosY(this.data.stateUI.v, deltaY);
                            // set
                            this.setHolderSize(Mathf.Max(40, deltaY));
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                bool isAlreadyShow = false;
                                {
                                    RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                                    if (roomUIData != null)
                                    {
                                        ContestManagerUI.UIData contestManagerUIData = roomUIData.contestManagerUIData.v;
                                        if (contestManagerUIData != null)
                                        {
                                            if (contestManagerUIData.contestManager.v.data == contestManager)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("contestManagerUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("roomUIData null");
                                    }
                                }
                                btnShow.interactable = !isAlreadyShow;
                            }
                            else
                            {
                                Debug.LogError("btnShow null");
                            }
                        }
                        // txt
                        {
                            if (tvShow != null)
                            {
                                tvShow.text = txtShow.get();
                            }
                            else
                            {
                                Debug.LogError("tvShow null: " + this);
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
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        public ChooseContestManagerStateLobbyUI lobbyPrefab;
        public ChooseContestManagerStatePlayUI playPrefab;
        private static readonly UIRectTransform stateUIRect = new UIRectTransform();

        private RoomUI.UIData roomUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.roomUIData);
                }
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
            // Parent
            {
                if(data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Child
                    {
                        roomUIData.contestManagerUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is ContestManagerUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is ContestManager)
                {
                    dirty = true;
                    return;
                }
                // stateUI
                {
                    if (data is UIData.StateUI)
                    {
                        UIData.StateUI stateUI = data as UIData.StateUI;
                        // UI
                        {
                            switch (stateUI.getType())
                            {
                                case ContestManager.State.Type.Lobby:
                                    {
                                        ChooseContestManagerStateLobbyUI.UIData chooseContestManagerStateLobbyUIData = stateUI as ChooseContestManagerStateLobbyUI.UIData;
                                        UIUtils.Instantiate(chooseContestManagerStateLobbyUIData, lobbyPrefab, this.transform, stateUIRect);
                                    }
                                    break;
                                case ContestManager.State.Type.Play:
                                    {
                                        ChooseContestManagerStatePlayUI.UIData chooseContestManagerStatePlayUIData = stateUI as ChooseContestManagerStatePlayUI.UIData;
                                        UIUtils.Instantiate(chooseContestManagerStatePlayUIData, playPrefab, this.transform, stateUIRect);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + stateUI.getType() + "; " + this);
                                    break;
                            }
                        }
                        // Child
                        {
                            TransformData.AddCallBack(stateUI, this);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.roomUIData);
                }
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
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Child
                    {
                        roomUIData.contestManagerUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ContestManagerUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                if (data is ContestManager)
                {
                    return;
                }
                // stateUI
                {
                    if (data is UIData.StateUI)
                    {
                        UIData.StateUI stateUI = data as UIData.StateUI;
                        // Child
                        {
                            TransformData.RemoveCallBack(stateUI, this);
                        }
                        // UI
                        {
                            switch (stateUI.getType())
                            {
                                case ContestManager.State.Type.Lobby:
                                    {
                                        ChooseContestManagerStateLobbyUI.UIData chooseContestManagerStateLobbyUIData = stateUI as ChooseContestManagerStateLobbyUI.UIData;
                                        chooseContestManagerStateLobbyUIData.removeCallBackAndDestroy(typeof(ChooseContestManagerStateLobbyUI));
                                    }
                                    break;
                                case ContestManager.State.Type.Play:
                                    {
                                        ChooseContestManagerStatePlayUI.UIData chooseContestManagerStatePlayUIData = stateUI as ChooseContestManagerStatePlayUI.UIData;
                                        chooseContestManagerStatePlayUIData.removeCallBackAndDestroy(typeof(ChooseContestManagerStatePlayUI));
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + stateUI.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    if(data is TransformData)
                    {
                        return;
                    }
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
                        Debug.LogError("Don't process: " + data + "; " + this);
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
                if (wrapProperty.p is RoomUI.UIData)
                {
                    switch ((RoomUI.UIData.Property)wrapProperty.n)
                    {
                        case RoomUI.UIData.Property.room:
                            break;
                        case RoomUI.UIData.Property.roomBtnUIData:
                            break;
                        case RoomUI.UIData.Property.contestManagerUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoomUI.UIData.Property.requestNewContestManagerUIData:
                            break;
                        case RoomUI.UIData.Property.chooseContestManagerUIData:
                            break;
                        case RoomUI.UIData.Property.roomUserInformUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is ContestManagerUI.UIData)
                {
                    switch ((ContestManagerUI.UIData.Property)wrapProperty.n)
                    {
                        case ContestManagerUI.UIData.Property.contestManager:
                            dirty = true;
                            break;
                        case ContestManagerUI.UIData.Property.sub:
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
                // stateUI
                {
                    if (wrapProperty.p is UIData.StateUI)
                    {
                        return;
                    }
                    // Child
                    if(wrapProperty.p is TransformData)
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                ContestManager contestManager = this.data.contestManager.v.data;
                if (contestManager != null)
                {
                    RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                    if (roomUIData != null)
                    {
                        ContestManagerUI.UIData contestManagerUIData = roomUIData.contestManagerUIData.v;
                        if (contestManagerUIData != null)
                        {
                            contestManagerUIData.contestManager.v = new ReferenceData<ContestManager>(contestManager);
                        }
                        else
                        {
                            Debug.LogError("contestManagerUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("roomUIData null: " + this);
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
}