using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class ChooseRoundContestUI : UIBehavior<ChooseRoundContestUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RoundRobin>> roundRobin;

            public VP<ChooseRoundContestAdapter.UIData> chooseRoundContestAdapter;

            #region Constructor

            public enum Property
            {
                roundRobin,
                chooseRoundContestAdapter
            }

            public UIData() : base()
            {
                this.roundRobin = new VP<ReferenceData<RoundRobin>>(this, (byte)Property.roundRobin, new ReferenceData<RoundRobin>(null));
                this.chooseRoundContestAdapter = new VP<ChooseRoundContestAdapter.UIData>(this, (byte)Property.chooseRoundContestAdapter, new ChooseRoundContestAdapter.UIData());
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
                            ChooseRoundContestUI chooseRoundContestUI = this.findCallBack<ChooseRoundContestUI>();
                            if (chooseRoundContestUI != null)
                            {
                                chooseRoundContestUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("chooseRoundContestUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChooseRoundContestUI chooseRoundContestUI = this.findCallBack<ChooseRoundContestUI>();
                            if (chooseRoundContestUI != null)
                            {
                                isProcess = chooseRoundContestUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundContestUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Round-robin Match");

        static ChooseRoundContestUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn Trận Đấu Vòng Tròn");
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
                    RoundRobin roundRobin = this.data.roundRobin.v.data;
                    if (roundRobin != null)
                    {
                        // chooseRoundContestAdapter
                        {
                            ChooseRoundContestAdapter.UIData chooseRoundContestAdapter = this.data.chooseRoundContestAdapter.v;
                            if (chooseRoundContestAdapter != null)
                            {
                                chooseRoundContestAdapter.roundRobin.v = new ReferenceData<RoundRobin>(roundRobin);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundContestAdapter null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobin null: " + this);
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
                        deltaY += UIRectTransform.SetPosY(this.data.chooseRoundContestAdapter.v, deltaY);
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

        public ChooseRoundContestAdapter chooseRoundContestAdapterPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.roundRobin.allAddCallBack(this);
                    uiData.chooseRoundContestAdapter.allAddCallBack(this);
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
                if (data is RoundRobin)
                {
                    dirty = true;
                    return;
                }
                if (data is ChooseRoundContestAdapter.UIData)
                {
                    ChooseRoundContestAdapter.UIData chooseRoundContestAdapterUIData = data as ChooseRoundContestAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundContestAdapterUIData, chooseRoundContestAdapterPrefab, this.transform);
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
                    uiData.roundRobin.allRemoveCallBack(this);
                    uiData.chooseRoundContestAdapter.allRemoveCallBack(this);
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
                if (data is RoundRobin)
                {
                    return;
                }
                if (data is ChooseRoundContestAdapter.UIData)
                {
                    ChooseRoundContestAdapter.UIData chooseRoundContestAdapterUIData = data as ChooseRoundContestAdapter.UIData;
                    // UI
                    {
                        chooseRoundContestAdapterUIData.removeCallBackAndDestroy(typeof(ChooseRoundContestAdapter));
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
                    case UIData.Property.roundRobin:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseRoundContestAdapter:
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
                        Debug.LogError("DOn't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is RoundRobin)
                {
                    return;
                }
                if (wrapProperty.p is ChooseRoundContestAdapter.UIData)
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
                RoundRobinUI.UIData roundRobinUIData = this.data.findDataInParent<RoundRobinUI.UIData>();
                if (roundRobinUIData != null)
                {
                    roundRobinUIData.chooseRoundContestUIData.v = null;
                }
                else
                {
                    Debug.LogError("roundRobinUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}