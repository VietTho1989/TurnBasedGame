using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class UseRuleInputDrTypeUI : UIBehavior<UseRuleInputDrTypeUI.UIData>
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

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.MineSweeper ? 1 : 0;
        }

        #region drType

        public Dropdown drType;

        public override void Awake()
        {
            base.Awake();
            if (drType != null)
            {
                drType.onValueChanged.AddListener(delegate (int newValue)
                {
                    if (this.data != null)
                    {
                        UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                        if (useRuleInputUIData != null)
                        {
                            useRuleInputUIData.type.v = (MineSweeperMove.MoveType)newValue;
                        }
                        else
                        {
                            Debug.LogError("useRuleInputUIData null");
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                });
            }
            else
            {
                Debug.LogError("drShow null: " + this);
            }
        }

        private static readonly TxtLanguage txtNormal = new TxtLanguage("Normal");
        private static readonly TxtLanguage txtFlag = new TxtLanguage("Flag");

        static UseRuleInputDrTypeUI()
        {
            txtNormal.add(Language.Type.vi, "Thường");
            txtFlag.add(Language.Type.vi, "Cờ");
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
                    // drType
                    {
                        if (drType != null)
                        {
                            // options
                            {
                                string[] options = {
                                        txtNormal.get (),
                                        txtFlag.get (),
                                    };
                                UIUtils.RefreshDropDownOptions(drType, options);
                            }
                            // set value
                            {
                                MineSweeperMove.MoveType type = MineSweeperMove.MoveType.Normal;
                                {
                                    UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData>();
                                    if (useRuleInputUIData != null)
                                    {
                                        type = useRuleInputUIData.type.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("useRuleInputUIData null");
                                    }
                                }
                                drType.value = (int)type;
                            }
                            drType.RefreshShownValue();
                        }
                        else
                        {
                            Debug.LogError("drType null");
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

        private UseRuleInputUI.UIData useRuleInputUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.useRuleInputUIData);
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
            // Parent
            if(data is UseRuleInputUI.UIData)
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.useRuleInputUIData);
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
            if (data is UseRuleInputUI.UIData)
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
            if (wrapProperty.p is UseRuleInputUI.UIData)
            {
                switch ((UseRuleInputUI.UIData.Property)wrapProperty.n)
                {
                    case UseRuleInputUI.UIData.Property.mineSweeper:
                        break;
                    case UseRuleInputUI.UIData.Property.keyX:
                        break;
                    case UseRuleInputUI.UIData.Property.keyY:
                        break;
                    case UseRuleInputUI.UIData.Property.type:
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

    }
}