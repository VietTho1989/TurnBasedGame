using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class CalculateScoreSumUI : UIHaveTransformDataBehavior<CalculateScoreSumUI.UIData>
    {

        #region UIData

        public class UIData : CalculateScore.UIData
        {

            public VP<EditData<CalculateScoreSum>> editCalculateScoreSum;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                editCalculateScoreSum,
                showType
            }

            public UIData() : base()
            {
                this.editCalculateScoreSum = new VP<EditData<CalculateScoreSum>>(this, (byte)Property.editCalculateScoreSum, new EditData<CalculateScoreSum>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override CalculateScore.Type getType()
            {
                return CalculateScore.Type.Sum;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Calculate score by sum");

        static CalculateScoreSumUI()
        {
            txtTitle.add(Language.Type.vi, "Tính điểm theo tổng");
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
                    EditData<CalculateScoreSum> editCalculateScoreSum = this.data.editCalculateScoreSum.v;
                    if (editCalculateScoreSum != null)
                    {
                        editCalculateScoreSum.update();
                        // get show
                        CalculateScoreSum show = editCalculateScoreSum.show.v.data;
                        CalculateScoreSum compare = editCalculateScoreSum.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editCalculateScoreSum.compareOtherType.v.data != null)
                                    {
                                        if (editCalculateScoreSum.compareOtherType.v.data.GetType() != show.GetType())
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
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            {
                                switch (this.data.showType.v)
                                {
                                    case UIRectTransform.ShowType.Normal:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(true);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                            deltaY += UIConstants.HeaderHeight;
                                        }
                                        break;
                                    case UIRectTransform.ShowType.HeadLess:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(false);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown showType: " + this.data.showType.v);
                                        break;
                                }
                            }
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editNoLimit null: " + this);
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
                    uiData.editCalculateScoreSum.allAddCallBack(this);
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
                // editCalculateScoreSum
                {
                    if (data is EditData<CalculateScoreSum>)
                    {
                        EditData<CalculateScoreSum> editCalculateScoreSum = data as EditData<CalculateScoreSum>;
                        // Child
                        {
                            editCalculateScoreSum.show.allAddCallBack(this);
                            editCalculateScoreSum.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is CalculateScoreSum)
                        {
                            CalculateScoreSum calculateScoreSum = data as CalculateScoreSum;
                            // Parent
                            {
                                DataUtils.addParentCallBack(calculateScoreSum, this, ref this.server);
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
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editCalculateScoreSum.allRemoveCallBack(this);
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
                // editCalculateScoreSum
                {
                    if (data is EditData<CalculateScoreSum>)
                    {
                        EditData<CalculateScoreSum> editCalculateScoreSum = data as EditData<CalculateScoreSum>;
                        // Child
                        {
                            editCalculateScoreSum.show.allRemoveCallBack(this);
                            editCalculateScoreSum.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is CalculateScoreSum)
                        {
                            CalculateScoreSum calculateScoreSum = data as CalculateScoreSum;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(calculateScoreSum, this, ref this.server);
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
                    case UIData.Property.editCalculateScoreSum:
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
                // editCalculateScoreSum
                {
                    if (wrapProperty.p is EditData<CalculateScoreSum>)
                    {
                        switch ((EditData<CalculateScoreSum>.Property)wrapProperty.n)
                        {
                            case EditData<CalculateScoreSum>.Property.origin:
                                break;
                            case EditData<CalculateScoreSum>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<CalculateScoreSum>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<CalculateScoreSum>.Property.compareOtherType:
                                break;
                            case EditData<CalculateScoreSum>.Property.canEdit:
                                break;
                            case EditData<CalculateScoreSum>.Property.editType:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is CalculateScoreSum)
                        {
                            switch ((CalculateScoreSum.Property)wrapProperty.n)
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