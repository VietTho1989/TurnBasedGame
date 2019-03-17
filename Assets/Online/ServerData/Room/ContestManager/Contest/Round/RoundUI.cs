using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RoundUI : UIBehavior<RoundUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Round>> round;

            public VP<RoundGameUI.UIData> roundGameUIData;

            public VP<ChooseRoundGameUI.UIData> chooseRoundGameUIData;

            #region Constructor

            public enum Property
            {
                round,
                roundGameUIData,
                chooseRoundGameUIData
            }

            public UIData() : base()
            {
                this.round = new VP<ReferenceData<Round>>(this, (byte)Property.round, new ReferenceData<Round>(null));
                this.roundGameUIData = new VP<RoundGameUI.UIData>(this, (byte)Property.roundGameUIData, new RoundGameUI.UIData());
                this.chooseRoundGameUIData = new VP<ChooseRoundGameUI.UIData>(this, (byte)Property.chooseRoundGameUIData, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // chooseRoundGameUIData
                    if (!isProcess)
                    {
                        ChooseRoundGameUI.UIData chooseRoundGameUIData = this.chooseRoundGameUIData.v;
                        if (chooseRoundGameUIData != null)
                        {
                            isProcess = chooseRoundGameUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chooseRoundGameUIData null: " + this);
                        }
                    }
                    // roundGameUIData
                    if (!isProcess)
                    {
                        RoundGameUI.UIData roundGameUIData = this.roundGameUIData.v;
                        if (roundGameUIData != null)
                        {
                            isProcess = roundGameUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roundGameUIData null: " + this);
                        }
                    }
                }
                return isProcess;
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
                    Round round = this.data.round.v.data;
                    if (round != null)
                    {
                        // roundGameUIData
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(round, out dataIdentity))
                                    {
                                        if (dataIdentity is RoundIdentity)
                                        {
                                            RoundIdentity roundIdentity = dataIdentity as RoundIdentity;
                                            if (roundIdentity.roundGames != round.roundGames.vs.Count)
                                            {
                                                Debug.LogError("roundGames count error");
                                                isLoadFull = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not roundIdentity");
                                        }
                                    }
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                RoundGameUI.UIData roundGameUIData = this.data.roundGameUIData.v;
                                if (roundGameUIData != null)
                                {
                                    if (roundGameUIData.roundGame.v.data == null
                                        || !round.roundGames.vs.Contains(roundGameUIData.roundGame.v.data))
                                    {
                                        // get roundGame
                                        if (round.roundGames.vs.Count > 0)
                                        {
                                            // find roundGame
                                            RoundGame roundGame = round.roundGames.vs[0];
                                            {
                                                // find first round game have you
                                                uint yourProfileId = Server.getProfileUserId(round);
                                                foreach (RoundGame check in round.roundGames.vs)
                                                {
                                                    Game game = check.game.v;
                                                    if (game != null)
                                                    {
                                                        if (game.findYourGamePlayer(yourProfileId) != null)
                                                        {
                                                            roundGame = check;
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("game null: " + this);
                                                    }
                                                }
                                            }
                                            roundGameUIData.roundGame.v = new ReferenceData<RoundGame>(roundGame);
                                        }
                                        else
                                        {
                                            Debug.LogError("roundGames count = 0: " + this);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("roundGameUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        // chooseRoundGameUIData
                        {
                            ChooseRoundGameUI.UIData chooseRoundGameUIData = this.data.chooseRoundGameUIData.v;
                            if (chooseRoundGameUIData != null)
                            {
                                chooseRoundGameUIData.round.v = new ReferenceData<Round>(round);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundGameUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError ("round null: " + this);
                    }
                    // siblingIndex
                    {
                        UIRectTransform.SetSiblingIndex(this.data.roundGameUIData.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.chooseRoundGameUIData.v, 1);
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

        public RoundGameUI roundGamePrefab;
        private static readonly UIRectTransform roundGameRect = UIConstants.FullParent;

        public ChooseRoundGameUI chooseRoundGamePrefab;
        private static readonly UIRectTransform chooseRoundGameRect = UIRectTransform.CreateCenterRect(400, 400);

        private RoomUI.UIData roomUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.roomUIData);
                }
                // Child
                {
                    uiData.round.allAddCallBack(this);
                    uiData.roundGameUIData.allAddCallBack(this);
                    uiData.chooseRoundGameUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Add BtnRoundUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            BtnRoundUI.UIData btnRoundUIData = new BtnRoundUI.UIData();
                            {
                                btnRoundUIData.uid = roomBtnUIData.subs.makeId();
                                btnRoundUIData.roundUIData.v = new ReferenceData<UIData>(this.data);
                            }
                            roomBtnUIData.subs.add(btnRoundUIData);
                        }
                        else
                        {
                            Debug.LogError("roomBtnUIData null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is Round)
                {
                    dirty = true;
                    return;
                }
                if (data is RoundGameUI.UIData)
                {
                    RoundGameUI.UIData roundGameUIData = data as RoundGameUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roundGameUIData, roundGamePrefab, this.transform, roundGameRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChooseRoundGameUI.UIData)
                {
                    ChooseRoundGameUI.UIData chooseRoundGameUIData = data as ChooseRoundGameUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundGameUIData, chooseRoundGamePrefab, this.transform, chooseRoundGameRect);
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.roomUIData);
                }
                // Child
                {
                    uiData.round.allRemoveCallBack(this);
                    uiData.roundGameUIData.allRemoveCallBack(this);
                    uiData.chooseRoundGameUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Remove BtnRoundUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs)
                            {
                                if (sub is BtnRoundUI.UIData)
                                {
                                    BtnRoundUI.UIData btnRoundUIData = sub as BtnRoundUI.UIData;
                                    if (btnRoundUIData.roundUIData.v.data == this.data)
                                    {
                                        roomBtnUIData.subs.remove(sub);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("roomBtnUIData null: " + this);
                        }
                    }
                    return;
                }
            }
            // Child
            {
                if (data is Round)
                {
                    return;
                }
                if (data is RoundGameUI.UIData)
                {
                    RoundGameUI.UIData roundGameUIData = data as RoundGameUI.UIData;
                    // UI
                    {
                        roundGameUIData.removeCallBackAndDestroy(typeof(RoundGameUI));
                    }
                    return;
                }
                if (data is ChooseRoundGameUI.UIData)
                {
                    ChooseRoundGameUI.UIData chooseRoundGameUIData = data as ChooseRoundGameUI.UIData;
                    // UI
                    {
                        chooseRoundGameUIData.removeCallBackAndDestroy(typeof(ChooseRoundGameUI));
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
                    case UIData.Property.round:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundGameUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseRoundGameUIData:
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
            if (wrapProperty.p is RoomUI.UIData)
            {
                return;
            }
            // Child
            {
                if (wrapProperty.p is Round)
                {
                    switch ((Round.Property)wrapProperty.n)
                    {
                        case Round.Property.state:
                            break;
                        case Round.Property.index:
                            break;
                        case Round.Property.roundGames:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }

                    dirty = true;
                    return;
                }
                if (wrapProperty.p is RoundGameUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ChooseRoundGameUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}