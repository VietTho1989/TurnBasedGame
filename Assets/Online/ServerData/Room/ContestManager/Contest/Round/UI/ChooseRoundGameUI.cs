﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ChooseRoundGameUI : UIBehavior<ChooseRoundGameUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Round>> round;

            public VP<ChooseRoundGameAdapter.UIData> chooseRoundGameAdapter;

            #region Constructor

            public enum Property
            {
                round,
                chooseRoundGameAdapter
            }

            public UIData() : base()
            {
                this.round = new VP<ReferenceData<Round>>(this, (byte)Property.round, new ReferenceData<Round>(null));
                this.chooseRoundGameAdapter = new VP<ChooseRoundGameAdapter.UIData>(this, (byte)Property.chooseRoundGameAdapter, new ChooseRoundGameAdapter.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ChooseRoundGameUI chooseRoundGameUI = this.findCallBack<ChooseRoundGameUI>();
                            if (chooseRoundGameUI != null)
                            {
                                chooseRoundGameUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("chooseRoundGameUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChooseRoundGameUI chooseRoundGameUI = this.findCallBack<ChooseRoundGameUI>();
                            if (chooseRoundGameUI != null)
                            {
                                isProcess = chooseRoundGameUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundGameUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Game In Set");

        static ChooseRoundGameUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn Game Trong Hiệp");
        }

        #endregion

        #region Refresh

        public Button btnBack;

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
                        // chooseRoundGameAdapter
                        {
                            ChooseRoundGameAdapter.UIData chooseRoundGameAdapter = this.data.chooseRoundGameAdapter.v;
                            if (chooseRoundGameAdapter != null)
                            {
                                chooseRoundGameAdapter.round.v = new ReferenceData<Round>(round);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundGameAdapter null: " + this);
                            }
                        }
                        // UI
                        {
                            float buttonSize = Setting.get().getButtonSize();
                            float deltaY = 0;
                            // header
                            {
                                UIRectTransform.SetTitleTransform(lbTitle);
                                UIRectTransform.SetButtonTopLeftTransform(btnBack);
                                deltaY += buttonSize;
                            }
                            // adapter
                            deltaY += UIRectTransform.SetPosY(this.data.chooseRoundGameAdapter.v, deltaY);
                            // set
                            {
                                UIRectTransform rect = UIRectTransform.CreateCenterRect(400, deltaY, 0, 30);
                                rect.set((RectTransform)this.transform);
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
                                Debug.LogError("lbTitle null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("round null: " + this);
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

        public ChooseRoundGameAdapter chooseRoundGameAdapterPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // UI
                {
                    uiData.round.allAddCallBack(this);
                    uiData.chooseRoundGameAdapter.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
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
                if (data is ChooseRoundGameAdapter.UIData)
                {
                    ChooseRoundGameAdapter.UIData chooseRoundAdapterUIData = data as ChooseRoundGameAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundAdapterUIData, chooseRoundGameAdapterPrefab, this.transform);
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
                // UI
                {
                    uiData.round.allRemoveCallBack(this);
                    uiData.chooseRoundGameAdapter.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // Child
            {
                if (data is Round)
                {
                    return;
                }
                if (data is ChooseRoundGameAdapter.UIData)
                {
                    ChooseRoundGameAdapter.UIData chooseRoundAdapterUIData = data as ChooseRoundGameAdapter.UIData;
                    // UI
                    {
                        chooseRoundAdapterUIData.removeCallBackAndDestroy(typeof(ChooseRoundGameAdapter));
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
                    case UIData.Property.chooseRoundGameAdapter:
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
            if(wrapProperty.p is Setting)
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
                    case Setting.Property.confirmQuit:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    case Setting.Property.defaultChosenGame:
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
                    return;
                }
                if (wrapProperty.p is ChooseRoundGameAdapter.UIData)
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
                RoundUI.UIData roundUIData = this.data.findDataInParent<RoundUI.UIData>();
                if (roundUIData != null)
                {
                    roundUIData.chooseRoundGameUIData.v = null;
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