using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Posture
{
    public class ChoosePostureUI : UIBehavior<ChoosePostureUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<GameType.Type> gameType;

            public VP<ChoosePostureAdapter.UIData> adapter;

            #region State

            public enum State
            {
                None,
                Load,
                Loading,
                Show
            }

            public VP<State> state;

            #endregion

            public LP<PostureGameData> gameDatas;

            #region Constructor

            public enum Property
            {
                gameType,
                adapter,
                state,
                gameDatas
            }

            public UIData() : base()
            {
                this.gameType = new VP<GameType.Type>(this, (byte)Property.gameType, GameType.Type.Xiangqi);
                this.adapter = new VP<ChoosePostureAdapter.UIData>(this, (byte)Property.adapter, new ChoosePostureAdapter.UIData());
                this.state = new VP<State>(this, (byte)Property.state, State.None);
                this.gameDatas = new LP<PostureGameData>(this, (byte)Property.gameDatas);
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
                            ChoosePostureUI choosePostureUI = this.findCallBack<ChoosePostureUI>();
                            if (choosePostureUI != null)
                            {
                                if (choosePostureUI.gameObject.activeInHierarchy)
                                {
                                    isProcess = true;
                                    choosePostureUI.onClickBtnBack();
                                }
                            }
                            else
                            {
                                Debug.LogError("choosePostureUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Posture");

        public Text tvRefresh;
        private static readonly TxtLanguage txtRefresh = new TxtLanguage("Refresh");

        private static readonly TxtLanguage txtNone = new TxtLanguage("None");
        private static readonly TxtLanguage txtLoading = new TxtLanguage("Loading");
        private static readonly TxtLanguage txtShow = new TxtLanguage("Show");

        static ChoosePostureUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn Thế Cờ");
            txtRefresh.add(Language.Type.vi, "Làm Mới");

            txtNone.add(Language.Type.vi, "Không có gì");
            txtLoading.add(Language.Type.vi, "Đang tải");
            txtShow.add(Language.Type.vi, "Hiện");
        }

        #endregion

        #region Refresh

        public Button btnBack;
        public Button btnRefresh;

        public Text tvState;
        public Image bgState;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // State
                    {
                        if (tvState != null && bgState != null)
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        tvState.text = txtNone.get();
                                        bgState.gameObject.SetActive(false);
                                    }
                                    break;
                                case UIData.State.Load:
                                    {
                                        tvState.text = txtLoading.get();
                                        bgState.gameObject.SetActive(true);
                                    }
                                    break;
                                case UIData.State.Loading:
                                    {
                                        tvState.text = txtLoading.get();
                                        bgState.gameObject.SetActive(true);
                                    }
                                    break;
                                case UIData.State.Show:
                                    {
                                        tvState.text = txtShow.get();
                                        bgState.gameObject.SetActive(false);
                                    }
                                    break;
                                default:
                                    Debug.LogError("Unknown state: " + this.data.state.v);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("tvState, bgState null");
                        }
                    }
                    // Adapter
                    {
                        if (this.data.adapter.v != null)
                        {
                            this.data.adapter.v.loadPostureData.v = new ReferenceData<UIData>(this.data);
                        }
                        else
                        {
                            Debug.LogError("adapter null: " + this);
                        }
                    }
                    // siblingIndex
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.transform.SetSiblingIndex(0);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (btnBack != null)
                        {
                            btnBack.transform.SetSiblingIndex(1);
                        }
                        else
                        {
                            Debug.LogError("btnBack null");
                        }
                        if (btnRefresh != null)
                        {
                            btnRefresh.transform.SetSiblingIndex(2);
                        }
                        else
                        {
                            Debug.LogError("btnRefresh null");
                        }
                        UIRectTransform.SetSiblingIndex(this.data.adapter.v, 3);
                        if (bgState != null)
                        {
                            bgState.transform.SetSiblingIndex(4);
                        }
                        else
                        {
                            Debug.LogError("bgState null");
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().getButtonSize();
                        // header
                        {
                            UIRectTransform.SetButtonTopLeftTransform(btnBack);
                            UIRectTransform.SetTitleTransform(lbTitle);
                            UIRectTransform.SetButtonTopRightTransformWidthHeight(btnRefresh, 80, buttonSize);
                        }
                        // adapter
                        UIRectTransform.Set(this.data.adapter.v, CreateAdapterRect());
                        // bgState
                        {
                            if (bgState != null)
                            {
                                CreateAdapterRect().set(bgState.rectTransform);
                            }
                            else
                            {
                                Debug.LogError("bgState null");
                            }
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
                        if (tvRefresh != null)
                        {
                            tvRefresh.text = txtRefresh.get();
                        }
                        else
                        {
                            Debug.LogError("tvRefresh null: " + this);
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

        public ChoosePostureAdapter adapterPrefab;
        private static UIRectTransform CreateAdapterRect()
        {
            return UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize(), 0);
        }

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Update
                {
                    UpdateUtils.makeUpdate<ChoosePostureUpdate, UIData>(uiData, this.transform);
                }
                // Child
                {
                    uiData.adapter.allAddCallBack(this);
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
            if (data is ChoosePostureAdapter.UIData)
            {
                ChoosePostureAdapter.UIData adapter = data as ChoosePostureAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(adapter, adapterPrefab, this.transform, CreateAdapterRect());
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
                // Update
                {
                    uiData.removeCallBackAndDestroy(typeof(ChoosePostureUpdate));
                }
                // Child
                {
                    uiData.adapter.allRemoveCallBack(this);
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
            if (data is ChoosePostureAdapter.UIData)
            {
                ChoosePostureAdapter.UIData adapter = data as ChoosePostureAdapter.UIData;
                // UI
                {
                    adapter.removeCallBackAndDestroy(typeof(ChoosePostureAdapter));
                }
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
                    case UIData.Property.gameType:
                        break;
                    case UIData.Property.adapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.state:
                        dirty = true;
                        break;
                    case UIData.Property.gameDatas:
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
            // Child
            if (wrapProperty.p is ChoosePostureAdapter.UIData)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.findDataInParent<EditPostureGameDataUI.UIData>();
                if (editPostureGameDataUIData != null)
                {
                    UIRectTransform.SetActive(editPostureGameDataUIData.choosePostureUIData.v, false);
                }
                else
                {
                    Debug.LogError("editPostureGameDataUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}