using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.Swap;

namespace Rights
{
    public class ChangeRightsUI : UIHaveTransformDataBehavior<ChangeRightsUI.UIData>
    {

        #region UIData

        public class UIData : Data, EditDataUI.UIData<ChangeRights>
        {

            public VP<EditData<ChangeRights>> editChangeRights;

            public VP<UndoRedoRightUI.UIData> undoRedoRight;

            public VP<ChangeGamePlayerRightUI.UIData> changeGamePlayerRight;

            public VP<ChangeUseRuleRightUI.UIData> changeUseRuleRight;

            #region Constructor

            public enum Property
            {
                editChangeRights,
                undoRedoRight,
                changeGamePlayerRight,
                changeUseRuleRight
            }

            public UIData() : base()
            {
                this.editChangeRights = new VP<EditData<ChangeRights>>(this, (byte)Property.editChangeRights, new EditData<ChangeRights>());
                this.undoRedoRight = new VP<UndoRedoRightUI.UIData>(this, (byte)Property.undoRedoRight, new UndoRedoRightUI.UIData());
                this.changeGamePlayerRight = new VP<ChangeGamePlayerRightUI.UIData>(this, (byte)Property.changeGamePlayerRight, new ChangeGamePlayerRightUI.UIData());
                this.changeUseRuleRight = new VP<ChangeUseRuleRightUI.UIData>(this, (byte)Property.changeUseRuleRight, new ChangeUseRuleRightUI.UIData());
            }

            #endregion

            #region implement base

            public EditData<ChangeRights> getEditData()
            {
                return this.editChangeRights.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage("Change Rights");

        static ChangeRightsUI()
        {
            txtTitle.add(Language.Type.vi, "Quyền Thay Đổi");
        }

        #endregion

        #region Refresh

        protected bool needReset = true;

        public Image bgUndoRedoRight;
        public Image bgChangeGamePlayerRight;
        public Image bgChangeUseRuleRight;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<ChangeRights> editChangeRights = this.data.editChangeRights.v;
                    if (editChangeRights != null)
                    {
                        editChangeRights.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editChangeRights);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editChangeRights);
                                // set origin
                                {
                                    EditDataUI.RefreshChildUI(this.data, this.data.undoRedoRight.v, editData => editData.undoRedoRight.v);
                                    EditDataUI.RefreshChildUI(this.data, this.data.changeGamePlayerRight.v, editData => editData.changeGamePlayerRight.v);
                                    EditDataUI.RefreshChildUI(this.data, this.data.changeUseRuleRight.v, editData => editData.changeUseRuleRight.v);
                                }
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editChangeRights null: " + this);
                    }
                    // UISize
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                        // undoRedoRight
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.undoRedoRight.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgUndoRedoRight != null)
                            {
                                UIRectTransform.SetPosY(bgUndoRedoRight.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgUndoRedoRight.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgUndoRedoRight null");
                            }
                        }
                        // changeGamePlayerRight
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.changeGamePlayerRight.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgChangeGamePlayerRight != null)
                            {
                                UIRectTransform.SetPosY(bgChangeGamePlayerRight.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgChangeGamePlayerRight.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgChangeGamePlayerRight null");
                            }
                        }
                        // changeUseRuleRight
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.changeUseRuleRight.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgChangeUseRuleRight != null)
                            {
                                UIRectTransform.SetPosY(bgChangeUseRuleRight.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgChangeUseRuleRight.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgChangeUseRuleRight null");
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
                    // Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public UndoRedoRightUI undoRedoRightPrefab;
        public ChangeGamePlayerRightUI changeGamePlayerRightPrefab;
        public ChangeUseRuleRightUI changeUseRuleRightPrefab;

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
                    uiData.editChangeRights.allAddCallBack(this);
                    uiData.undoRedoRight.allAddCallBack(this);
                    uiData.changeGamePlayerRight.allAddCallBack(this);
                    uiData.changeUseRuleRight.allAddCallBack(this);
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
                // editChangeRights
                {
                    if (data is EditData<ChangeRights>)
                    {
                        EditData<ChangeRights> editChangeRights = data as EditData<ChangeRights>;
                        // Child
                        {
                            editChangeRights.show.allAddCallBack(this);
                            editChangeRights.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeRights)
                        {
                            ChangeRights changeRights = data as ChangeRights;
                            // Parent
                            {
                                DataUtils.addParentCallBack(changeRights, this, ref this.server);
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
                if (data is UndoRedoRightUI.UIData)
                {
                    UndoRedoRightUI.UIData undoRedoRightUIData = data as UndoRedoRightUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(undoRedoRightUIData, undoRedoRightPrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(undoRedoRightUIData, this);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChangeGamePlayerRightUI.UIData)
                {
                    ChangeGamePlayerRightUI.UIData changeGamePlayerRightUIData = data as ChangeGamePlayerRightUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(changeGamePlayerRightUIData, changeGamePlayerRightPrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(changeGamePlayerRightUIData, this);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChangeUseRuleRightUI.UIData)
                {
                    ChangeUseRuleRightUI.UIData changeUseRuleRightUIData = data as ChangeUseRuleRightUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(changeUseRuleRightUIData, changeUseRuleRightPrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(changeUseRuleRightUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is TransformData)
                {
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
                    uiData.editChangeRights.allRemoveCallBack(this);
                    uiData.undoRedoRight.allRemoveCallBack(this);
                    uiData.changeGamePlayerRight.allRemoveCallBack(this);
                    uiData.changeUseRuleRight.allRemoveCallBack(this);
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
                // editChangeRights
                {
                    if (data is EditData<ChangeRights>)
                    {
                        EditData<ChangeRights> editChangeRights = data as EditData<ChangeRights>;
                        // Child
                        {
                            editChangeRights.show.allRemoveCallBack(this);
                            editChangeRights.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeRights)
                        {
                            ChangeRights changeRights = data as ChangeRights;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(changeRights, this, ref this.server);
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
                if (data is UndoRedoRightUI.UIData)
                {
                    UndoRedoRightUI.UIData undoRedoRightUIData = data as UndoRedoRightUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(undoRedoRightUIData, this);
                    }
                    // UI
                    {
                        undoRedoRightUIData.removeCallBackAndDestroy(typeof(UndoRedoRightUI));
                    }
                    return;
                }
                if (data is ChangeGamePlayerRightUI.UIData)
                {
                    ChangeGamePlayerRightUI.UIData changeGamePlayerRightUIData = data as ChangeGamePlayerRightUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(changeGamePlayerRightUIData, this);
                    }
                    // UI
                    {
                        changeGamePlayerRightUIData.removeCallBackAndDestroy(typeof(ChangeGamePlayerRightUI));
                    }
                    return;
                }
                if (data is ChangeUseRuleRightUI.UIData)
                {
                    ChangeUseRuleRightUI.UIData changeUseRuleRightUIData = data as ChangeUseRuleRightUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(changeUseRuleRightUIData, this);
                    }
                    // UI
                    {
                        changeUseRuleRightUIData.removeCallBackAndDestroy(typeof(ChangeUseRuleRightUI));
                    }
                    return;
                }
                // Child
                if (data is TransformData)
                {
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
                    case UIData.Property.editChangeRights:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.undoRedoRight:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.changeGamePlayerRight:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.changeUseRuleRight:
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
                // editChangeRights
                {
                    if (wrapProperty.p is EditData<ChangeRights>)
                    {
                        switch ((EditData<ChangeRights>.Property)wrapProperty.n)
                        {
                            case EditData<ChangeRights>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ChangeRights>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChangeRights>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChangeRights>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ChangeRights>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ChangeRights>.Property.editType:
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
                        if (wrapProperty.p is ChangeRights)
                        {
                            switch ((ChangeRights.Property)wrapProperty.n)
                            {
                                case ChangeRights.Property.undoRedoRight:
                                    dirty = true;
                                    break;
                                case ChangeRights.Property.changeGamePlayerRight:
                                    dirty = true;
                                    break;
                                case ChangeRights.Property.changeUseRuleRight:
                                    dirty = true;
                                    break;
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
                if (wrapProperty.p is UndoRedoRightUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ChangeGamePlayerRightUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ChangeUseRuleRightUI.UIData)
                {
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.anchoredPosition:
                            break;
                        case TransformData.Property.anchorMin:
                            break;
                        case TransformData.Property.anchorMax:
                            break;
                        case TransformData.Property.pivot:
                            break;
                        case TransformData.Property.offsetMin:
                            break;
                        case TransformData.Property.offsetMax:
                            break;
                        case TransformData.Property.sizeDelta:
                            break;
                        case TransformData.Property.rotation:
                            break;
                        case TransformData.Property.scale:
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}