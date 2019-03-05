using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace LoginState
{
    public class StateSuccessUI : UIHaveTransformDataBehavior<StateSuccessUI.UIData>
    {

        #region UIData

        public class UIData : NoneUI.UIData.Sub
        {

            public VP<ReferenceData<StateSuccess>> stateSuccess;

            #region Constructor

            public enum Property
            {
                stateSuccess
            }

            public UIData() : base()
            {
                this.stateSuccess = new VP<ReferenceData<StateSuccess>>(this, (byte)Property.stateSuccess, new ReferenceData<StateSuccess>(null));
            }

            #endregion

            public override None.State.Type getType()
            {
                return None.State.Type.Success;
            }

        }

        #endregion

        #region txt

        public Text tvSuccess;
        public static readonly TxtLanguage txtSuccess = new TxtLanguage();

        static StateSuccessUI()
        {
            txtSuccess.add(Language.Type.vi, "Đăng nhập thành công");
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
                    StateSuccess stateSuccess = this.data.stateSuccess.v.data;
                    if (stateSuccess != null)
                    {
                        if (tvSuccess != null)
                        {
                            tvSuccess.text = txtSuccess.get("Login success");
                        }
                        else
                        {
                            Debug.LogError("tvSuccess null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("stateSuccess null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
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
                    uiData.stateSuccess.allAddCallBack(this);
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
            if (data is StateSuccess)
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
                    uiData.stateSuccess.allRemoveCallBack(this);
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
            if (data is StateSuccess)
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
                    case UIData.Property.stateSuccess:
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
            if (wrapProperty.p is StateSuccess)
            {
                switch ((StateSuccess.Property)wrapProperty.n)
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

    }
}