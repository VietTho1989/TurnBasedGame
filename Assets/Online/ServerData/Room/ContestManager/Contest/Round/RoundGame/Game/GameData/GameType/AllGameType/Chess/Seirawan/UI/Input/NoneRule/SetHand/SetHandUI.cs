using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
    public class SetHandUI : UIBehavior<SetHandUI.UIData>
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            public VP<SetHandAdapter.UIData> setHandAdapter;

            #region Constructor

            public enum Property
            {
                setHandAdapter
            }

            public UIData() : base()
            {
                this.setHandAdapter = new VP<SetHandAdapter.UIData>(this, (byte)Property.setHandAdapter, new SetHandAdapter.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.SetHand;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            SetHandUI setHandUI = this.findCallBack<SetHandUI>();
                            if (setHandUI != null)
                            {
                                setHandUI.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("setHandUI null: " + this);
                            }
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            SetHandUI setHandUI = this.findCallBack<SetHandUI>();
                            if (setHandUI != null)
                            {
                                isProcess = setHandUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("setHandUI null: " + this);
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

        #endregion

        #region Refresh

        public RectTransform contentContainer;

        public Button btnBack;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
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
                        {
                            UIRectTransform.SetPosY(this.data.setHandAdapter.v, deltaY + 10);
                            deltaY += ClickPosTxt.setPieceChoosePieceAdapterHeight + 10;
                        }
                        // height
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight(contentContainer, deltaY);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = ClickPosTxt.txtSetHandTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
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

        private GameDataBoardCheckPerspectiveChange<UIData> checkPerspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

        public SetHandAdapter setHandAdapterPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    checkPerspectiveChange.addCallBack(this);
                    checkPerspectiveChange.setData(uiData);
                }
                // Child
                {
                    uiData.setHandAdapter.allAddCallBack(this);
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
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            if (data is SetHandAdapter.UIData)
            {
                SetHandAdapter.UIData setHandAdapterUIData = data as SetHandAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(setHandAdapterUIData, setHandAdapterPrefab, contentContainer, ClickPosTxt.setHandChoosePieceAdapterRect);
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
                // CheckChange
                {
                    checkPerspectiveChange.removeCallBack(this);
                    checkPerspectiveChange.setData(null);
                }
                // Child
                {
                    uiData.setHandAdapter.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                return;
            }
            // Child
            if (data is SetHandAdapter.UIData)
            {
                SetHandAdapter.UIData setHandAdapterUIData = data as SetHandAdapter.UIData;
                // UI
                {
                    setHandAdapterUIData.removeCallBackAndDestroy(typeof(SetHandAdapter));
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
                    case UIData.Property.setHandAdapter:
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
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            if (wrapProperty.p is SetHandAdapter.UIData)
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
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData();
                    {
                        clickNoneUIData.uid = noneRuleInputUIData.sub.makeId();
                    }
                    noneRuleInputUIData.sub.v = clickNoneUIData;
                }
                else
                {
                    Debug.LogError("noneRuleInputUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}