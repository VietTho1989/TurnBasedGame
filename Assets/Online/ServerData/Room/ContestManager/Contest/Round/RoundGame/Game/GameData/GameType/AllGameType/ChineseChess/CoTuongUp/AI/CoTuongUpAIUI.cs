using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
    public class CoTuongUpAIUI : UIHaveTransformDataBehavior<CoTuongUpAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<CoTuongUpAI>> editCoTuongUpAI;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                editCoTuongUpAI,
                showType
            }

            public UIData() : base()
            {
                this.editCoTuongUpAI = new VP<EditData<CoTuongUpAI>>(this, (byte)Property.editCoTuongUpAI, new EditData<CoTuongUpAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.CO_TUONG_UP;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Hidden Chinese Chess AI");

        static CoTuongUpAIUI()
        {
            txtTitle.add(Language.Type.vi, "Cờ Úp AI");
        }

        #endregion

        #region Refresh

        protected bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<CoTuongUpAI> editCoTuongUpAI = this.data.editCoTuongUpAI.v;
                    if (editCoTuongUpAI != null)
                    {
                        editCoTuongUpAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editCoTuongUpAI);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editCoTuongUpAI);
                                // set origin
                                {

                                }
                                needReset = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editCoTuongUpAI null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // Set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editCoTuongUpAI.allAddCallBack(this);
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
                // editCoTuongUpAI
                {
                    if (data is EditData<CoTuongUpAI>)
                    {
                        EditData<CoTuongUpAI> editCoTuongUpAI = data as EditData<CoTuongUpAI>;
                        // Child
                        {
                            editCoTuongUpAI.show.allAddCallBack(this);
                            editCoTuongUpAI.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is CoTuongUpAI)
                        {
                            CoTuongUpAI coTuongUpAI = data as CoTuongUpAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(coTuongUpAI, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
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
                    uiData.editCoTuongUpAI.allRemoveCallBack(this);
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
                // editCoTuongUpAI
                {
                    if (data is EditData<CoTuongUpAI>)
                    {
                        EditData<CoTuongUpAI> editCoTuongUpAI = data as EditData<CoTuongUpAI>;
                        // Child
                        {
                            editCoTuongUpAI.show.allRemoveCallBack(this);
                            editCoTuongUpAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is CoTuongUpAI)
                        {
                            CoTuongUpAI coTuongUpAI = data as CoTuongUpAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(coTuongUpAI, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                return;
                            }
                        }
                    }
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
                    case UIData.Property.editCoTuongUpAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
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
            // Child
            {
                // editCoTuongUpAI
                {
                    if (wrapProperty.p is EditData<CoTuongUpAI>)
                    {
                        switch ((EditData<CoTuongUpAI>.Property)wrapProperty.n)
                        {
                            case EditData<CoTuongUpAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<CoTuongUpAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<CoTuongUpAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<CoTuongUpAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<CoTuongUpAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<CoTuongUpAI>.Property.editType:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is CoTuongUpAI)
                        {
                            switch ((CoTuongUpAI.Property)wrapProperty.n)
                            {
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
                        {
                            if (wrapProperty.p is Server)
                            {
                                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                                return;
                            }
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}