using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class BtnShowSwapUI : UIBehavior<BtnShowSwapUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Swap>> swap;

            #region Constructor

            public enum Property
            {
                swap
            }

            public UIData() : base()
            {
                this.swap = new VP<ReferenceData<Swap>>(this, (byte)Property.swap, new ReferenceData<Swap>(null));
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnShowSwapUI btnShowSwapUI = this.findCallBack<BtnShowSwapUI>();
                            if (btnShowSwapUI != null)
                            {
                                isProcess = btnShowSwapUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnShowSwapUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Swap Player");

        static BtnShowSwapUI()
        {
            txtTitle.add(Language.Type.vi, "Đổi Người");
        }

        #endregion

        #region Refresh

        public Text tvRequestCount;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Swap swap = this.data.swap.v.data;
                    if (swap != null)
                    {
                        // tvRequestCount
                        {
                            if (tvRequestCount != null)
                            {
                                if (swap.swapRequests.vs.Count > 0)
                                {
                                    tvRequestCount.text = "" + swap.swapRequests.vs.Count;
                                }
                                else
                                {
                                    tvRequestCount.text = "";
                                }
                            }
                            else
                            {
                                Debug.LogError("tvRequestCount null: " + this);
                            }
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError("swap null: " + this);
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
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.swap.allAddCallBack(this);
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
            if (data is Swap)
            {
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
                    uiData.swap.allRemoveCallBack(this);
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
            if (data is Swap)
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
                    case UIData.Property.swap:
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
            if (wrapProperty.p is Swap)
            {
                switch ((Swap.Property)wrapProperty.n)
                {
                    case Swap.Property.swapRequests:
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

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnShow, onClickBtnShow);
            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.S:
                            {
                                if (btnShow != null && btnShow.gameObject.activeInHierarchy && btnShow.interactable)
                                {
                                    this.onClickBtnShow();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        public Button btnShow;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                Swap swap = this.data.swap.v.data;
                if (swap != null)
                {
                    ContestManagerStatePlayUI.UIData contestManagerStatePlayUIData = this.data.findDataInParent<ContestManagerStatePlayUI.UIData>();
                    if (contestManagerStatePlayUIData != null)
                    {
                        SwapUI.UIData swapUIData = contestManagerStatePlayUIData.swapUIData.newOrOld<SwapUI.UIData>();
                        {

                        }
                        contestManagerStatePlayUIData.swapUIData.v = swapUIData;
                    }
                    else
                    {
                        Debug.LogError("contestManagerStatePlayUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("swap null");
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}