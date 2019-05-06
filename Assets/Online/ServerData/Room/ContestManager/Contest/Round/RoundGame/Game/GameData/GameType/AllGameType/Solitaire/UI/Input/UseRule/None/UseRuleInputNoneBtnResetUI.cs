using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class UseRuleInputNoneBtnResetUI : UIBehavior<UseRuleInputNoneBtnResetUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

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
                            UseRuleInputNoneBtnResetUI useRuleInputNoneBtnResetUI = this.findCallBack<UseRuleInputNoneBtnResetUI>();
                            if (useRuleInputNoneBtnResetUI != null)
                            {
                                isProcess = useRuleInputNoneBtnResetUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("useRuleInputNoneBtnResetUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvReset;
        private static readonly TxtLanguage txtReset = new TxtLanguage("Reset");

        static UseRuleInputNoneBtnResetUI()
        {
            txtReset.add(Language.Type.vi, "Đặt Lại");
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
                    // txt
                    {
                        if (tvReset != null)
                        {
                            tvReset.text = txtReset.get();
                        }
                        else
                        {
                            Debug.LogError("tvReset null");
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                // Setting
                Setting.get().addCallBack(this);
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
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
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
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
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
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
                UIUtils.SetButtonOnClick(btnReset, onClickBtnReset);
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
                        case KeyCode.R:
                            {
                                if (btnReset != null && btnReset.gameObject.activeInHierarchy && btnReset.interactable)
                                {
                                    this.onClickBtnReset();
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

        public Button btnReset;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnReset()
        {
            if (this.data != null)
            {
                UseRuleInputNoneUI.UIData useRuleInputNoneUIData = this.data.findDataInParent<UseRuleInputNoneUI.UIData>();
                if (useRuleInputNoneUIData != null)
                {
                    UseRuleInputNoneUI useRuleInputNoneUI = useRuleInputNoneUIData.findCallBack<UseRuleInputNoneUI>();
                    if (useRuleInputNoneUI != null)
                    {
                        useRuleInputNoneUI.onClickBtnReset();
                    }
                    else
                    {
                        Debug.LogError("useRuleInputNoneUI null");
                    }
                }
                else
                {
                    Debug.LogError("useRuleInputNoneUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}