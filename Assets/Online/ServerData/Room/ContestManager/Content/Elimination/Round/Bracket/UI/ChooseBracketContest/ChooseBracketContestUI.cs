using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class ChooseBracketContestUI : UIBehavior<ChooseBracketContestUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Bracket>> bracket;

            public VP<ChooseBracketContestAdapter.UIData> chooseBracketContestAdapter;

            #region Constructor

            public enum Property
            {
                bracket,
                chooseBracketContestAdapter
            }

            public UIData() : base()
            {
                this.bracket = new VP<ReferenceData<Bracket>>(this, (byte)Property.bracket, new ReferenceData<Bracket>(null));
                this.chooseBracketContestAdapter = new VP<ChooseBracketContestAdapter.UIData>(this, (byte)Property.chooseBracketContestAdapter, new ChooseBracketContestAdapter.UIData());
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
                            ChooseBracketContestUI chooseBracketContestUI = this.findCallBack<ChooseBracketContestUI>();
                            if (chooseBracketContestUI != null)
                            {
                                chooseBracketContestUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("chooseBracketContestUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChooseBracketContestUI chooseBracketContestUI = this.findCallBack<ChooseBracketContestUI>();
                            if (chooseBracketContestUI != null)
                            {
                                isProcess = chooseBracketContestUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseBracketContestUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Bracket Match");

        static ChooseBracketContestUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn Trận Đấu Nhánh");
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
                    Bracket bracket = this.data.bracket.v.data;
                    if (bracket != null)
                    {
                        // chooseBracketContestAdapter
                        {
                            ChooseBracketContestAdapter.UIData chooseBracketContestAdapter = this.data.chooseBracketContestAdapter.v;
                            if (chooseBracketContestAdapter != null)
                            {
                                chooseBracketContestAdapter.bracket.v = new ReferenceData<Bracket>(bracket);
                            }
                            else
                            {
                                Debug.LogError("chooseBracketContestAdapter null: " + this);
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
                            deltaY += UIRectTransform.SetPosY(this.data.chooseBracketContestAdapter.v, deltaY);
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
                        // Debug.LogError ("bracket null: " + this);
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

        public ChooseBracketContestAdapter chooseBracketContestAdapterPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.bracket.allAddCallBack(this);
                    uiData.chooseBracketContestAdapter.allAddCallBack(this);
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
                if (data is Bracket)
                {
                    dirty = true;
                    return;
                }
                if (data is ChooseBracketContestAdapter.UIData)
                {
                    ChooseBracketContestAdapter.UIData chooseBracketContestAdapterUIData = data as ChooseBracketContestAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseBracketContestAdapterUIData, chooseBracketContestAdapterPrefab, this.transform);
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
                    uiData.bracket.allRemoveCallBack(this);
                    uiData.chooseBracketContestAdapter.allRemoveCallBack(this);
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
                if (data is Bracket)
                {
                    return;
                }
                if (data is ChooseBracketContestAdapter.UIData)
                {
                    ChooseBracketContestAdapter.UIData chooseBracketContestAdapterUIData = data as ChooseBracketContestAdapter.UIData;
                    // UI
                    {
                        chooseBracketContestAdapterUIData.removeCallBackAndDestroy(typeof(ChooseBracketContestAdapter));
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
                    case UIData.Property.bracket:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseBracketContestAdapter:
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
                if (wrapProperty.p is Bracket)
                {
                    return;
                }
                if (wrapProperty.p is ChooseBracketContestAdapter.UIData)
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
                BracketUI.UIData bracketUIData = this.data.findDataInParent<BracketUI.UIData>();
                if (bracketUIData != null)
                {
                    bracketUIData.chooseBracketContestUIData.v = null;
                }
                else
                {
                    Debug.LogError("bracketUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}