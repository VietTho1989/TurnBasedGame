using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class ChooseBracketUI : UIBehavior<ChooseBracketUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<EliminationRound>> eliminationRound;

            public VP<ChooseBracketAdapter.UIData> chooseBracketAdapter;

            #region Constructor

            public enum Property
            {
                eliminationRound,
                chooseBracketAdapter
            }

            public UIData() : base()
            {
                this.eliminationRound = new VP<ReferenceData<EliminationRound>>(this, (byte)Property.eliminationRound, new ReferenceData<EliminationRound>(null));
                this.chooseBracketAdapter = new VP<ChooseBracketAdapter.UIData>(this, (byte)Property.chooseBracketAdapter, new ChooseBracketAdapter.UIData());
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
                            ChooseBracketUI chooseBracketUI = this.findCallBack<ChooseBracketUI>();
                            if (chooseBracketUI != null)
                            {
                                chooseBracketUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("chooseBracketUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChooseBracketUI chooseBracketUI = this.findCallBack<ChooseBracketUI>();
                            if (chooseBracketUI != null)
                            {
                                isProcess = chooseBracketUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseBracketUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Bracket");

        static ChooseBracketUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn Nhánh");
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
                    EliminationRound eliminationRound = this.data.eliminationRound.v.data;
                    if (eliminationRound != null)
                    {
                        // chooseBracketAdapter
                        {
                            ChooseBracketAdapter.UIData chooseBracketAdapter = this.data.chooseBracketAdapter.v;
                            if (chooseBracketAdapter != null)
                            {
                                chooseBracketAdapter.eliminationRound.v = new ReferenceData<EliminationRound>(eliminationRound);
                            }
                            else
                            {
                                Debug.LogError("chooseBracketAdapter null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("eliminationRound null: " + this);
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
                        deltaY += UIRectTransform.SetPosY(this.data.chooseBracketAdapter.v, deltaY);
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
                            Debug.LogError("lbTitle null: " + this);
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

        public ChooseBracketAdapter chooseBracketAdapterPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.eliminationRound.allAddCallBack(this);
                    uiData.chooseBracketAdapter.allAddCallBack(this);
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
                if (data is EliminationRound)
                {
                    dirty = true;
                    return;
                }
                if (data is ChooseBracketAdapter.UIData)
                {
                    ChooseBracketAdapter.UIData chooseBracketAdapterUIData = data as ChooseBracketAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseBracketAdapterUIData, chooseBracketAdapterPrefab, this.transform);
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
                    uiData.eliminationRound.allRemoveCallBack(this);
                    uiData.chooseBracketAdapter.allRemoveCallBack(this);
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
                if (data is EliminationRound)
                {
                    return;
                }
                if (data is ChooseBracketAdapter.UIData)
                {
                    ChooseBracketAdapter.UIData chooseBracketAdapterUIData = data as ChooseBracketAdapter.UIData;
                    // UI
                    {
                        chooseBracketAdapterUIData.removeCallBackAndDestroy(typeof(ChooseBracketAdapter));
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
                    case UIData.Property.eliminationRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseBracketAdapter:
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is EliminationRound)
                {
                    return;
                }
                if (wrapProperty.p is ChooseBracketAdapter.UIData)
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
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                EliminationRoundUI.UIData eliminationRoundUIData = this.data.findDataInParent<EliminationRoundUI.UIData>();
                if (eliminationRoundUIData != null)
                {
                    eliminationRoundUIData.chooseBracketUIData.v = null;
                }
                else
                {
                    Debug.LogError("eliminationRoundUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}