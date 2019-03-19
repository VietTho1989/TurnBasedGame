using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class BtnRoundUI : UIBehavior<BtnRoundUI.UIData>
    {

        #region UIData

        public class UIData : RoomBtnUI.UIData.Sub
        {

            public VP<ReferenceData<RoundUI.UIData>> roundUIData;

            #region Constructor

            public enum Property
            {
                roundUIData
            }

            public UIData() : base()
            {
                this.roundUIData = new VP<ReferenceData<RoundUI.UIData>>(this, (byte)Property.roundUIData, new ReferenceData<RoundUI.UIData>(null));
            }

            #endregion

            public override Type getType()
            {
                return Type.Round;
            }

        }

        #endregion

        #region Refresh

        public Text tvRound;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundUI.UIData roundUIData = this.data.roundUIData.v.data;
                    if (roundUIData != null)
                    {
                        // tvRound
                        {
                            if (tvRound != null)
                            {
                                // Find
                                int gameIndex = 0;
                                int gameCount = 1;
                                {
                                    // gameIndex
                                    {
                                        RoundGameUI.UIData roundGameUIData = roundUIData.roundGameUIData.v;
                                        if (roundGameUIData != null)
                                        {
                                            RoundGame roundGame = roundGameUIData.roundGame.v.data;
                                            if (roundGame != null)
                                            {
                                                gameIndex = roundGame.index.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("roundGame null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("roundGameUIData null: " + this);
                                        }
                                    }
                                    // gameCount
                                    {
                                        Round round = roundUIData.round.v.data;
                                        if (round != null)
                                        {
                                            gameCount = round.roundGames.vs.Count;
                                        }
                                        else
                                        {
                                            Debug.LogError("round null: " + this);
                                        }
                                    }
                                }
                                // Process
                                tvRound.text = "Game " + (gameIndex + 1) + "/" + gameCount;
                            }
                            else
                            {
                                Debug.LogError("tvRound null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundUIData null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.roundUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is RoundUI.UIData)
                {
                    RoundUI.UIData roundUIData = data as RoundUI.UIData;
                    // Child
                    {
                        roundUIData.round.allAddCallBack(this);
                        roundUIData.roundGameUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Round)
                    {
                        dirty = true;
                        return;
                    }
                    // roundGameUIData
                    {
                        if (data is RoundGameUI.UIData)
                        {
                            RoundGameUI.UIData roundGameUIData = data as RoundGameUI.UIData;
                            // Child
                            {
                                roundGameUIData.roundGame.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is RoundGame)
                        {
                            dirty = true;
                            return;
                        }
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
                // Child
                {
                    uiData.roundUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is RoundUI.UIData)
                {
                    RoundUI.UIData roundUIData = data as RoundUI.UIData;
                    // Child
                    {
                        roundUIData.round.allRemoveCallBack(this);
                        roundUIData.roundGameUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Round)
                    {
                        return;
                    }
                    // roundGameUIData
                    {
                        if (data is RoundGameUI.UIData)
                        {
                            RoundGameUI.UIData roundGameUIData = data as RoundGameUI.UIData;
                            // Child
                            {
                                roundGameUIData.roundGame.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is RoundGame)
                        {
                            return;
                        }
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
                    case UIData.Property.roundUIData:
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
                if (wrapProperty.p is RoundUI.UIData)
                {
                    switch ((RoundUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundUI.UIData.Property.round:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
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
                        return;
                    }
                    // roundGameUIData
                    {
                        if (wrapProperty.p is RoundGameUI.UIData)
                        {
                            switch ((RoundGameUI.UIData.Property)wrapProperty.n)
                            {
                                case RoundGameUI.UIData.Property.roundGame:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case RoundGameUI.UIData.Property.gameUIData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnRound()
        {
            if (this.data != null)
            {
                RoundUI.UIData roundUIData = this.data.roundUIData.v.data;
                if (roundUIData != null)
                {
                    ChooseRoundGameUI.UIData chooseRoundGameUIData = roundUIData.chooseRoundGameUIData.newOrOld<ChooseRoundGameUI.UIData>();
                    {

                    }
                    roundUIData.chooseRoundGameUIData.v = chooseRoundGameUIData;
                }
                else
                {
                    Debug.LogError("roundUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}