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