using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet.UseRule
{
    public class ClickDestBtnRotateUI : UIBehavior<ClickDestBtnRotateUI.UIData>
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

        }

        #endregion

        #region txt

        public Text tvRotateAdd;
        private static readonly TxtLanguage txtRotateAdd = new TxtLanguage("Rotate Add");

        public Text tvRotateSub;
        private static readonly TxtLanguage txtRotateSub = new TxtLanguage("Rotate Sub");

        static ClickDestBtnRotateUI()
        {
            txtRotateAdd.add(Language.Type.vi, "Xoay Tiến");
            txtRotateSub.add(Language.Type.vi, "Xoay Lùi");
        }

        #endregion

        #region Refresh

        public Button btnRotateAdd;
        public Button btnRotateSub;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // btn
                    if (btnRotateAdd != null && btnRotateSub != null)
                    {
                        ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData>();
                        if (clickDestUIData != null)
                        {
                            btnRotateAdd.interactable = clickDestUIData.canRotateAdd.v;
                            btnRotateSub.interactable = clickDestUIData.canRotateSub.v;
                        }
                        else
                        {
                            Debug.LogError("clickDestUIData null");
                        }
                    }
                    else
                    {
                        Debug.LogError("btnRotate null");
                    }
                    // txt
                    {
                        if (tvRotateAdd != null)
                        {
                            tvRotateAdd.text = txtRotateAdd.get();
                        }
                        else
                        {
                            Debug.LogError("tvRotateAdd null");
                        }
                        if (tvRotateSub != null)
                        {
                            tvRotateSub.text = txtRotateSub.get();
                        }
                        else
                        {
                            Debug.LogError("tvRotateSub null");
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

        private ClickDestUI.UIData clickDestUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.clickDestUIData);
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
            // Parent
            if (data is ClickDestUI.UIData)
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.clickDestUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            if (data is ClickDestUI.UIData)
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
            // Parent
            if (wrapProperty.p is ClickDestUI.UIData)
            {
                switch ((ClickDestUI.UIData.Property)wrapProperty.n)
                {
                    case ClickDestUI.UIData.Property.piecePosition:
                        break;
                    case ClickDestUI.UIData.Property.legalMoves:
                        break;
                    case ClickDestUI.UIData.Property.keyX:
                        break;
                    case ClickDestUI.UIData.Property.keyY:
                        break;
                    case ClickDestUI.UIData.Property.canRotateAdd:
                        dirty = true;
                        break;
                    case ClickDestUI.UIData.Property.canRotateSub:
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

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnRotateAdd()
        {
            if (this.data != null)
            {
                ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData>();
                if (clickDestUIData != null)
                {
                    ClickDestUI clickDestUI = clickDestUIData.findCallBack<ClickDestUI>();
                    if (clickDestUI != null)
                    {
                        clickDestUI.onClickRotateAdd();
                    }
                    else
                    {
                        Debug.LogError("clickDestUI null");
                    }
                }
                else
                {
                    Debug.LogError("clickDestUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnRotateSub()
        {
            if (this.data != null)
            {
                ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData>();
                if (clickDestUIData != null)
                {
                    ClickDestUI clickDestUI = clickDestUIData.findCallBack<ClickDestUI>();
                    if (clickDestUI != null)
                    {
                        clickDestUI.onClickRotateSub();
                    }
                    else
                    {
                        Debug.LogError("clickDestUI null");
                    }
                }
                else
                {
                    Debug.LogError("clickDestUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}