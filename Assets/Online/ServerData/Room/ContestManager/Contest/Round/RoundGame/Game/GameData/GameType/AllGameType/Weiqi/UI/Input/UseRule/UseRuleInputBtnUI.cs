using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class UseRuleInputBtnUI : UIBehavior<UseRuleInputBtnUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
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
                            UseRuleInputBtnUI useRuleInputBtnUI = this.findCallBack<UseRuleInputBtnUI>();
                            if (useRuleInputBtnUI != null)
                            {
                                isProcess = useRuleInputBtnUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("useRuleInputBtnUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

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
            if(data is UIData)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                this.setDataNull(uiData);
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
            if(wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
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
                UIUtils.SetButtonOnClick(btnPass, onClickBtnPass);
                UIUtils.SetButtonOnClick(btnResign, onClickBtnResign);
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
                        case KeyCode.P:
                            {
                                if (btnPass != null && btnPass.gameObject.activeInHierarchy && btnPass.interactable)
                                {
                                    this.onClickBtnPass();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        case KeyCode.R:
                            {
                                if (btnResign != null && btnResign.gameObject.activeInHierarchy && btnResign.interactable)
                                {
                                    this.onClickBtnResign();
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

        public Button btnPass;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnPass()
        {
            if (this.data != null)
            {
                UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                if (useRuleInputUIData != null)
                {
                    UseRuleInputUI useRuleInputUI = useRuleInputUIData.findCallBack<UseRuleInputUI>();
                    if (useRuleInputUI != null)
                    {
                        useRuleInputUI.onClickBtnPassOrResign(Common.pass);
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUI null");
                    }
                }
                else
                {
                    Debug.LogError("useRuleInputUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        public Button btnResign;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnResign()
        {
            if (this.data != null)
            {
                UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                if (useRuleInputUIData != null)
                {
                    UseRuleInputUI useRuleInputUI = useRuleInputUIData.findCallBack<UseRuleInputUI>();
                    if (useRuleInputUI != null)
                    {
                        useRuleInputUI.onClickBtnPassOrResign(Common.resign);
                    }
                    else
                    {
                        Debug.LogError("useRuleInputUI null");
                    }
                }
                else
                {
                    Debug.LogError("useRuleInputUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}