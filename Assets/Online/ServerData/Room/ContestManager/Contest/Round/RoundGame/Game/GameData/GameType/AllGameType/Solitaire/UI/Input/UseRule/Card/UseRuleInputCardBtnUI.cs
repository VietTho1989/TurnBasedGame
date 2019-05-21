using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class UseRuleInputCardBtnUI : UIBehavior<UseRuleInputCardBtnUI.UIData>
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
                            UseRuleInputCardBtnUI useRuleInputCardBtnUI = this.findCallBack<UseRuleInputCardBtnUI>();
                            if (useRuleInputCardBtnUI != null)
                            {
                                isProcess = useRuleInputCardBtnUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("useRuleInputCardBtnUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Solitaire ? 1 : 0;
        }

        #region txt

        public Text tvBack;
        private static readonly TxtLanguage txtBack = new TxtLanguage("Back");

        static UseRuleInputCardBtnUI()
        {
            txtBack.add(Language.Type.vi, "Quay Lại");
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
                        if (tvBack != null)
                        {
                            tvBack.text = txtBack.get();
                        }
                        else
                        {
                            Debug.LogError("tvBack null");
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
                UIData uiData = data as UIData;
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
                UIUtils.SetButtonOnClick(btnBack, onClickBtnBack);
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
                        case KeyCode.Backspace:
                        case KeyCode.Escape:
                            {
                                if (btnBack != null && btnBack.gameObject.activeInHierarchy && btnBack.interactable)
                                {
                                    this.onClickBtnBack();
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

        public Button btnBack;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                UseRuleInputCardUI.UIData useRuleInputCardUIData = this.data.findDataInParent<UseRuleInputCardUI.UIData>();
                if (useRuleInputCardUIData != null)
                {
                    UseRuleInputCardUI useRuleInputCardUI = useRuleInputCardUIData.findCallBack<UseRuleInputCardUI>();
                    if (useRuleInputCardUI != null)
                    {
                        useRuleInputCardUI.onClickBtnBack();
                    }
                    else
                    {
                        Debug.LogError("useRuleInputCardUI null");
                    }
                }
                else
                {
                    Debug.LogError("useRuleInputCardUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}