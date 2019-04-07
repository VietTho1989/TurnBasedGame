using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public class LoadUI : UIBehavior<LoadUI.UIData>
    {

        #region UIData

        public class UIData : StateUI.UIData.Sub
        {

            public VP<ReferenceData<Load>> load;

            public VP<BtnRequestNewUI.UIData> btnRequestNew;

            #region Constructor

            public enum Property
            {
                load,
                btnRequestNew
            }

            public UIData() : base()
            {
                this.load = new VP<ReferenceData<Load>>(this, (byte)Property.load, new ReferenceData<Load>(null));
                this.btnRequestNew = new VP<BtnRequestNewUI.UIData>(this, (byte)Property.btnRequestNew, new BtnRequestNewUI.UIData());
            }

            #endregion

            public override State.Type getType()
            {
                return State.Type.Load;
            }

        }

        #endregion

        #region txt, rect

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("Loading");

        static LoadUI()
        {
            // txt
            txtMessage.add(Language.Type.vi, "Đang Tải");
            // rect
            btnRequestNewRect.setPosY(-7.5f);
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
                    Load load = this.data.load.v.data;
                    if (load != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("load null: " + this);
                    }
                    // txt
                    {
                        if (tvMessage != null)
                        {
                            tvMessage.text = txtMessage.get();
                        }
                        else
                        {
                            Debug.LogError("tvMessage null: " + this);
                        }
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

        public BtnRequestNewUI btnRequestNewPrefab;
        private static readonly UIRectTransform btnRequestNewRect = UIRectTransform.CreateCenterRect(120, 30);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.load.allAddCallBack(this);
                    uiData.btnRequestNew.allAddCallBack(this);
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
                if (data is Load)
                {
                    dirty = true;
                    return;
                }
                if (data is BtnRequestNewUI.UIData)
                {
                    BtnRequestNewUI.UIData btnRequestNewUIData = data as BtnRequestNewUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnRequestNewUIData, btnRequestNewPrefab, this.transform, btnRequestNewRect);
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
                    uiData.load.allRemoveCallBack(this);
                    uiData.btnRequestNew.allRemoveCallBack(this);
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
                if (data is Load)
                {
                    return;
                }
                if (data is BtnRequestNewUI.UIData)
                {
                    BtnRequestNewUI.UIData btnRequestNewUIData = data as BtnRequestNewUI.UIData;
                    // UI
                    {
                        btnRequestNewUIData.removeCallBackAndDestroy(typeof(BtnRequestNewUI));
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
                    case UIData.Property.load:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnRequestNew:
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
            {
                if (wrapProperty.p is Load)
                {
                    switch ((Load.Property)wrapProperty.n)
                    {
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is BtnRequestNewUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}