using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match
{
    public class ChooseRoundGameAdapter : SRIA<ChooseRoundGameAdapter.UIData, ChooseRoundGameHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<Round>> round;

            public LP<ChooseRoundGameHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                round,
                holders
            }

            public UIData() : base()
            {
                this.round = new VP<ReferenceData<Round>>(this, (byte)Property.round, new ReferenceData<Round>(null));
                this.holders = new LP<ChooseRoundGameHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<RoundGame> roundGames = new List<RoundGame>();

            public void reset()
            {
                this.roundGames.Clear();
            }

        }

        #endregion

        #region Adapter

        public ChooseRoundGameHolder holderPrefab;

        protected override ChooseRoundGameHolder.UIData CreateViewsHolder(int itemIndex)
        {
            ChooseRoundGameHolder.UIData uiData = new ChooseRoundGameHolder.UIData();
            {
                // add
                {
                    uiData.uid = this.data.holders.makeId();
                    this.data.holders.add(uiData);
                }
                // MakeUI
                if (holderPrefab != null)
                {
                    uiData.Init(holderPrefab.gameObject, itemIndex);
                }
                else
                {
                    Debug.LogError("holderPrefab null: " + this);
                }
            }
            return uiData;
        }

        protected override void UpdateViewsHolder(ChooseRoundGameHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region txt

        public Text tvNoRoundGames;
        private static readonly TxtLanguage txtNoRoundGames = new TxtLanguage("Don't have any games");

        static ChooseRoundGameAdapter()
        {
            txtNoRoundGames.add(Language.Type.vi, "Không có game nào cả");
        }

        #endregion

        #region Refresh

        public GameObject noRoundGames;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        Round round = this.data.round.v.data;
                        if (round != null)
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
                                List<RoundGame> roundGames = new List<RoundGame>();
                                // get
                                {
                                    roundGames.AddRange(round.roundGames.vs);
                                }
                                // Make list
                                {
                                    int min = Mathf.Min(roundGames.Count, _Params.roundGames.Count);
                                    // Update
                                    {
                                        for (int i = 0; i < min; i++)
                                        {
                                            if (roundGames[i] != _Params.roundGames[i])
                                            {
                                                // change param
                                                _Params.roundGames[i] = roundGames[i];
                                                // Update holder
                                                foreach (ChooseRoundGameHolder.UIData holder in this.data.holders.vs)
                                                {
                                                    if (holder.ItemIndex == i)
                                                    {
                                                        holder.roundGame.v = new ReferenceData<RoundGame>(roundGames[i]);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    // Add or Remove
                                    {
                                        if (roundGames.Count > min)
                                        {
                                            // Add
                                            int insertCount = roundGames.Count - min;
                                            List<RoundGame> addItems = roundGames.GetRange(min, insertCount);
                                            _Params.roundGames.AddRange(addItems);
                                            InsertItems(min, insertCount, false, false);
                                        }
                                        else
                                        {
                                            // Remove
                                            int deleteCount = _Params.roundGames.Count - min;
                                            if (deleteCount > 0)
                                            {
                                                RemoveItems(min, deleteCount, false, false);
                                                _Params.roundGames.RemoveRange(min, deleteCount);
                                            }
                                        }
                                    }
                                }
                                // NoRoundGames
                                {
                                    if (noRoundGames != null)
                                    {
                                        bool haveAny = false;
                                        {
                                            foreach (ChooseRoundGameHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.roundGame.v.data != null)
                                                {
                                                    ChooseRoundGameHolder holderUI = holder.findCallBack<ChooseRoundGameHolder>();
                                                    if (holderUI != null)
                                                    {
                                                        if (holderUI.gameObject.activeSelf)
                                                        {
                                                            haveAny = true;
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("holderUI null: " + this);
                                                    }
                                                }
                                            }
                                        }
                                        noRoundGames.SetActive(!haveAny);
                                    }
                                    else
                                    {
                                        Debug.LogError("noRoundGames null: " + this);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                        // txt
                        {
                            if (tvNoRoundGames != null)
                            {
                                tvNoRoundGames.text = txtNoRoundGames.get();
                            }
                            else
                            {
                                Debug.LogError("tvNoRoundGames null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not initalized: " + this);
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
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.round.allAddCallBack(this);
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
            if (data is Round)
            {
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                dirty = true;
                return;
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
                    uiData.round.allRemoveCallBack(this);
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
            if (data is Round)
            {
                return;
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
                    case UIData.Property.holders:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}