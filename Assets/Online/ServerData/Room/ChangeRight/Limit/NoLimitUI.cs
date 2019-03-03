using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
    public class NoLimitUI : UIBehavior<NoLimitUI.UIData>, HaveTransformData
    {

        #region UIData

        public class UIData : Limit.UIData
        {

            public VP<EditData<NoLimit>> editNoLimit;

            #region Constructor

            public enum Property
            {
                editNoLimit
            }

            public UIData() : base()
            {
                this.editNoLimit = new VP<EditData<NoLimit>>(this, (byte)Property.editNoLimit, new EditData<NoLimit>());
            }

            #endregion

            public override Limit.Type getType()
            {
                return Limit.Type.NoLimit;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        static NoLimitUI()
        {
            txtTitle.add(Language.Type.vi, "Không giới hạn");
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<NoLimit> editNoLimit = this.data.editNoLimit.v;
                    if (editNoLimit != null)
                    {
                        editNoLimit.update();
                        // get show
                        NoLimit show = editNoLimit.show.v.data;
                        NoLimit compare = editNoLimit.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editNoLimit.compareOtherType.v.data != null)
                                    {
                                        if (editNoLimit.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = Server.State.Type.Connect;
                                {
                                    Server server = show.findDataInParent<Server>();
                                    if (server != null)
                                    {
                                        if (server.state.v != null)
                                        {
                                            serverState = server.state.v.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("server state null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("server null: " + this + "; " + serverState + "; " + compare);
                                    }
                                }
                                // set origin
                                {

                                }
                                // reset
                                if (needReset)
                                {
                                    needReset = false;
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editNoLimit null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("No Limit");
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
            updateTransformData();
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
                // Global
                Global.get().addCallBack(this);
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editNoLimit.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Global
            if (data is Global)
            {
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
                // editNoLimit
                {
                    if (data is EditData<NoLimit>)
                    {
                        EditData<NoLimit> editNoLimit = data as EditData<NoLimit>;
                        // Child
                        {
                            editNoLimit.show.allAddCallBack(this);
                            editNoLimit.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is NoLimit)
                        {
                            NoLimit noLimit = data as NoLimit;
                            // Parent
                            {
                                DataUtils.addParentCallBack(noLimit, this, ref this.server);
                            }
                            needReset = true;
                            dirty = true;
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
                // Global
                Global.get().removeCallBack(this);
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editNoLimit.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Global
            if (data is Global)
            {
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // editNoLimit
                {
                    if (data is EditData<NoLimit>)
                    {
                        EditData<NoLimit> editNoLimit = data as EditData<NoLimit>;
                        // Child
                        {
                            editNoLimit.show.allRemoveCallBack(this);
                            editNoLimit.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is NoLimit)
                        {
                            NoLimit noLimit = data as NoLimit;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(noLimit, this, ref this.server);
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
                    case UIData.Property.editNoLimit:
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
            // Global
            if (wrapProperty.p is Global)
            {
                Global.OnValueTransformChange(wrapProperty, this);
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
                // editNoLimit
                {
                    if (wrapProperty.p is EditData<NoLimit>)
                    {
                        switch ((EditData<NoLimit>.Property)wrapProperty.n)
                        {
                            case EditData<NoLimit>.Property.origin:
                                break;
                            case EditData<NoLimit>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<NoLimit>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<NoLimit>.Property.compareOtherType:
                                break;
                            case EditData<NoLimit>.Property.canEdit:
                                break;
                            case EditData<NoLimit>.Property.editType:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is NoLimit)
                        {
                            switch ((NoLimit.Property)wrapProperty.n)
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