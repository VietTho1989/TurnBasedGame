using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;

namespace GameManager.Match
{
    public class RoomBtnUI : UIBehavior<RoomBtnUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<RoomBtnBackUI.UIData> btnBack;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    Contest,
                    Round,

                    RoundRobinContent,
                    RoundRobin,

                    EliminationContent,
                    EliminationRound,
                    Bracket
                }

                public abstract Type getType();

            }

            public LP<Sub> subs;

            #endregion

            #region Constructor

            public enum Property
            {
                btnBack,
                subs
            }

            public UIData() : base()
            {
                this.btnBack = new VP<RoomBtnBackUI.UIData>(this, (byte)Property.btnBack, new RoomBtnBackUI.UIData());
                this.subs = new LP<Sub>(this, (byte)Property.subs);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // btnBack
                    if (!isProcess)
                    {
                        RoomBtnBackUI.UIData roomBtnBackUIData = this.btnBack.v;
                        if (roomBtnBackUIData != null)
                        {
                            isProcess = roomBtnBackUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roomBtnBackUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public static readonly TxtLanguage txtContestManager = new TxtLanguage("Tournament");

        static RoomBtnUI()
        {
            txtContestManager.add(Language.Type.vi, "Giải đấu");
        }

        #endregion

        #region Refresh

        public Text tvContestManager;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                    if (roomUIData != null)
                    {
                        Room room = roomUIData.room.v.data;
                        if (room != null)
                        {
                            // btnBack
                            {
                                RoomBtnBackUI.UIData roomBtnBackUIData = this.data.btnBack.v;
                                if (roomBtnBackUIData != null)
                                {
                                    roomBtnBackUIData.room.v = new ReferenceData<Room>(room);
                                }
                                else
                                {
                                    Debug.LogError("roomBtnBackUIData null: " + this);
                                }
                            }
                            // tvBtnContestManager
                            {
                                if (tvContestManager != null)
                                {
                                    int contestManagerIndex = 0;
                                    {
                                        ContestManagerUI.UIData contestManagerUIData = roomUIData.contestManagerUIData.v;
                                        if (contestManagerUIData != null)
                                        {
                                            ContestManager contestManager = contestManagerUIData.contestManager.v.data;
                                            if (contestManager != null)
                                            {
                                                contestManagerIndex = contestManager.index.v;
                                            }
                                            else
                                            {
                                                // Debug.LogError ("contestManager null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("contestManagerUIData null: " + this);
                                        }
                                    }
                                    int contestManagerCount = room.contestManagers.vs.Count;
                                    // Set
                                    tvContestManager.text = txtContestManager.get() + ": " + (contestManagerIndex + 1) + "/" + contestManagerCount;
                                }
                                else
                                {
                                    Debug.LogError("tvContestManager null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("room null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("roomUIData null: " + this);
                    }
                    // siblingIndex
                    {
                        // btnBack
                        UIRectTransform.SetSiblingIndex(this.data.btnBack.v, 0);
                    }
                    // UI
                    {
                        // btnBack
                        {
                            // TODO Can hoan thien
                        }
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

        public RoomBtnBackUI btnBackPrefab;

        public BtnContestUI btnContestPrefab;
        public BtnRoundUI btnRoundPrefab;

        public BtnRoundRobinContentUI btnRoundRobinContentPrefab;
        public BtnRoundRobinUI btnRoundRobinPrefab;

        public BtnEliminationContentUI btnEliminationContentPrefab;
        public BtnEliminationRoundUI btnEliminationRoundPrefab;
        public BtnBracketUI btnBracketPrefab;

        public Transform subContainer;

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
                    uiData.btnBack.allAddCallBack(this);
                    uiData.subs.allAddCallBack(this);
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
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Child
                    {
                        roomUIData.room.allAddCallBack(this);
                        roomUIData.contestManagerUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Room)
                    {
                        dirty = true;
                        return;
                    }
                    // contestManagerUIData
                    {
                        if (data is ContestManagerUI.UIData)
                        {
                            ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                            // Child
                            {
                                contestManagerUIData.contestManager.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is ContestManager)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Child
            {
                if (data is RoomBtnBackUI.UIData)
                {
                    RoomBtnBackUI.UIData roomBtnBackUIData = data as RoomBtnBackUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roomBtnBackUIData, btnBackPrefab, subContainer);
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
                            case UIData.Sub.Type.Contest:
                                {
                                    BtnContestUI.UIData btnContestUIData = sub as BtnContestUI.UIData;
                                    UIUtils.Instantiate(btnContestUIData, btnContestPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.Round:
                                {
                                    BtnRoundUI.UIData btnRoundUIData = sub as BtnRoundUI.UIData;
                                    UIUtils.Instantiate(btnRoundUIData, btnRoundPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.RoundRobinContent:
                                {
                                    BtnRoundRobinContentUI.UIData btnRoundRobinContentUIData = sub as BtnRoundRobinContentUI.UIData;
                                    UIUtils.Instantiate(btnRoundRobinContentUIData, btnRoundRobinContentPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.RoundRobin:
                                {
                                    BtnRoundRobinUI.UIData btnRoundRobinUIData = sub as BtnRoundRobinUI.UIData;
                                    UIUtils.Instantiate(btnRoundRobinUIData, btnRoundRobinPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.EliminationContent:
                                {
                                    BtnEliminationContentUI.UIData btnEliminationContentUIData = sub as BtnEliminationContentUI.UIData;
                                    UIUtils.Instantiate(btnEliminationContentUIData, btnEliminationContentPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.EliminationRound:
                                {
                                    BtnEliminationRoundUI.UIData btnEliminationRoundUIData = sub as BtnEliminationRoundUI.UIData;
                                    UIUtils.Instantiate(btnEliminationRoundUIData, btnEliminationRoundPrefab, subContainer);
                                }
                                break;
                            case UIData.Sub.Type.Bracket:
                                {
                                    BtnBracketUI.UIData btnBracketUIData = sub as BtnBracketUI.UIData;
                                    UIUtils.Instantiate(btnBracketUIData, btnBracketPrefab, subContainer);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.roomUIData);
                }
                // Child
                {
                    uiData.btnBack.allRemoveCallBack(this);
                    uiData.subs.allRemoveCallBack(this);
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
                        roomUIData.room.allRemoveCallBack(this);
                        roomUIData.contestManagerUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Room)
                    {
                        return;
                    }
                    // contestManagerUIData
                    {
                        if (data is ContestManagerUI.UIData)
                        {
                            ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                            // Child
                            {
                                contestManagerUIData.contestManager.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is ContestManager)
                        {
                            return;
                        }
                    }
                }
            }
            // Child
            {
                if (data is RoomBtnBackUI.UIData)
                {
                    RoomBtnBackUI.UIData roomBtnBackUIData = data as RoomBtnBackUI.UIData;
                    // UI
                    {
                        roomBtnBackUIData.removeCallBackAndDestroy(typeof(RoomBtnBackUI));
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
                            case UIData.Sub.Type.Contest:
                                {
                                    BtnContestUI.UIData btnContestUIData = sub as BtnContestUI.UIData;
                                    btnContestUIData.removeCallBackAndDestroy(typeof(BtnContestUI));
                                }
                                break;
                            case UIData.Sub.Type.Round:
                                {
                                    BtnRoundUI.UIData btnRoundUIData = sub as BtnRoundUI.UIData;
                                    btnRoundUIData.removeCallBackAndDestroy(typeof(BtnRoundUI));
                                }
                                break;
                            case UIData.Sub.Type.RoundRobinContent:
                                {
                                    BtnRoundRobinContentUI.UIData btnRoundRobinContentUIData = sub as BtnRoundRobinContentUI.UIData;
                                    btnRoundRobinContentUIData.removeCallBackAndDestroy(typeof(BtnRoundRobinContentUI));
                                }
                                break;
                            case UIData.Sub.Type.RoundRobin:
                                {
                                    BtnRoundRobinUI.UIData btnRoundRobinUIData = sub as BtnRoundRobinUI.UIData;
                                    btnRoundRobinUIData.removeCallBackAndDestroy(typeof(BtnRoundRobinUI));
                                }
                                break;
                            case UIData.Sub.Type.EliminationContent:
                                {
                                    BtnEliminationContentUI.UIData btnEliminationContentUIData = sub as BtnEliminationContentUI.UIData;
                                    btnEliminationContentUIData.removeCallBackAndDestroy(typeof(BtnEliminationContentUI));
                                }
                                break;
                            case UIData.Sub.Type.EliminationRound:
                                {
                                    BtnEliminationRoundUI.UIData btnEliminationRoundUIData = sub as BtnEliminationRoundUI.UIData;
                                    btnEliminationRoundUIData.removeCallBackAndDestroy(typeof(BtnEliminationRoundUI));
                                }
                                break;
                            case UIData.Sub.Type.Bracket:
                                {
                                    BtnBracketUI.UIData btnBracketUIData = sub as BtnBracketUI.UIData;
                                    btnBracketUIData.removeCallBackAndDestroy(typeof(BtnBracketUI));
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
                    case UIData.Property.btnBack:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.subs:
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
            // Parent
            {
                if (wrapProperty.p is RoomUI.UIData)
                {
                    switch ((RoomUI.UIData.Property)wrapProperty.n)
                    {
                        case RoomUI.UIData.Property.room:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
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
                {
                    if (wrapProperty.p is Room)
                    {
                        switch ((Room.Property)wrapProperty.n)
                        {
                            case Room.Property.changeRights:
                                break;
                            case Room.Property.name:
                                break;
                            case Room.Property.password:
                                break;
                            case Room.Property.users:
                                break;
                            case Room.Property.state:
                                break;
                            case Room.Property.contestManagers:
                                dirty = true;
                                break;
                            case Room.Property.timeCreated:
                                break;
                            case Room.Property.chatRoom:
                                break;
                            case Room.Property.allowHint:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // contestManagerUIData
                    {
                        if (wrapProperty.p is ContestManagerUI.UIData)
                        {
                            switch ((ContestManagerUI.UIData.Property)wrapProperty.n)
                            {
                                case ContestManagerUI.UIData.Property.contestManager:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case ContestManagerUI.UIData.Property.sub:
                                    break;
                                case ContestManagerUI.UIData.Property.btns:
                                    break;
                                case ContestManagerUI.UIData.Property.roomChat:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is ContestManager)
                        {
                            switch ((ContestManager.Property)wrapProperty.n)
                            {
                                case ContestManager.Property.index:
                                    dirty = true;
                                    break;
                                case ContestManager.Property.state:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is RoomBtnBackUI.UIData)
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

        public void onClickBtnChooseContestManager()
        {
            if (this.data != null)
            {
                RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                if (roomUIData != null)
                {
                    ChooseContestManagerUI.UIData chooseContestManagerUIData = roomUIData.chooseContestManagerUIData.newOrOld<ChooseContestManagerUI.UIData>();
                    {

                    }
                    roomUIData.chooseContestManagerUIData.v = chooseContestManagerUIData;
                }
                else
                {
                    Debug.LogError("roomUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}