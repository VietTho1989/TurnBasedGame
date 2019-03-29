using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
    public class CreateByFenUI : UIBehavior<CreateByFenUI.UIData>
    {

        #region UIData

        public class UIData : NoneRuleInputUI.UIData.Sub
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

            }

            #endregion

            public override Type getType()
            {
                return Type.CreateByFen;
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
                            CreateByFenUI createByFenUI = this.findCallBack<CreateByFenUI>();
                            if (createByFenUI != null)
                            {
                                createByFenUI.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("createByFenUI null");
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt, rect

        public Text lbTitle;

        public InputField edtFen;

        public Text tvFenPlaceHolder;

        public Text tvCreate;

        #endregion

        #region Refresh

        private bool firstInit = false;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // firstInit
                    if (firstInit)
                    {
                        firstInit = false;
                        // find current fen
                        string currentFen = "";
                        {
                            NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                            if (noneRuleInputUIData != null)
                            {
                                Seirawan seirawan = noneRuleInputUIData.seirawan.v.data;
                                if (seirawan != null)
                                {
                                    currentFen = Core.unityGetPositionFen(seirawan, Core.CanCorrect);
                                }
                                else
                                {
                                    Debug.LogError("seirawan null");
                                }
                            }
                            else
                            {
                                Debug.LogError("noneRuleInputUIData null");
                            }
                        }
                        // set
                        if (edtFen != null)
                        {
                            edtFen.text = currentFen;
                        }
                        else
                        {
                            Debug.LogError("edtFen null");
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = ClickPosTxt.txtCreateByFenTitle.get(ClickPosTxt.DefaultCreateByFenTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        if (tvFenPlaceHolder != null)
                        {
                            tvFenPlaceHolder.text = ClickPosTxt.txtCreateByFenPlaceHolder.get(ClickPosTxt.DefaultCreateByFenPlaceHolder);
                        }
                        else
                        {
                            Debug.LogError("tvFenPlaceHolder null");
                        }
                        if (tvCreate != null)
                        {
                            tvCreate.text = ClickPosTxt.txtCreateByFenCreate.get(ClickPosTxt.DefaultCreateByFenCreate);
                        }
                        else
                        {
                            Debug.LogError("tvCreate null");
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
            if(data is UIData)
            {
                // Setting
                Setting.get().addCallBack(this);
                firstInit = true;
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
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
                switch ((UIData.Property)wrapProperty.n)
                {
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
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
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

        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                if (noneRuleInputUIData != null)
                {
                    ClickNoneUI.UIData clickNoneUIData = noneRuleInputUIData.sub.newOrOld<ClickNoneUI.UIData>();
                    {

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

        public void onClickBtnPaste()
        {
            if (this.data != null)
            {
                if (edtFen != null)
                {
                    edtFen.text = UniClipboard.GetText();
                }
                else
                {
                    Debug.LogError("edtFen null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

        public void onClickBtnCreate()
        {
            if (this.data != null)
            {
                // find fen
                string strFen = "";
                {
                    if (edtFen != null)
                    {
                        strFen = edtFen.text;
                    }
                    else
                    {
                        Debug.LogError("edtFen null");
                    }
                }
                // process
                if (!string.IsNullOrEmpty(strFen))
                {
                    if (strFen.Length <= 100)
                    {
                        // Find ClientInput
                        ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                        // Process
                        if (clientInput != null)
                        {
                            SeirawanCustomFen seirawanCustomFen = new SeirawanCustomFen();
                            {
                                seirawanCustomFen.fen.v = strFen;
                            }
                            clientInput.makeSend(seirawanCustomFen);
                        }
                        else
                        {
                            Debug.LogError("clientInput null: " + this);
                        }
                    }
                    else
                    {
                        Toast.showMessage("Fen too long");
                    }
                }
                else
                {
                    Toast.showMessage("Fen null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}