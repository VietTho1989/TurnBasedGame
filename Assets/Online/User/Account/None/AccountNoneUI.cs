using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountNoneUI : UIHaveTransformDataBehavior<AccountNoneUI.UIData>
{

    #region UIData

    public class UIData : AccountUI.UIData.Sub
    {

        public VP<EditData<AccountNone>> editAccountNone;

        public VP<UIRectTransform.ShowType> showType;

        #region Constructor

        public enum Property
        {
            editAccountNone,
            showType
        }

        public UIData() : base()
        {
            this.editAccountNone = new VP<EditData<AccountNone>>(this, (byte)Property.editAccountNone, new EditData<AccountNone>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
        }

        #endregion

        public override Account.Type getType()
        {
            return Account.Type.NONE;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static TxtLanguage txtTitle = new TxtLanguage("Unknown Account");

    static AccountNoneUI()
    {
        txtTitle.add(Language.Type.vi, "Tài Khoản Ẩn Danh");
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
                EditData<AccountNone> editAccountNone = this.data.editAccountNone.v;
                if (editAccountNone != null)
                {
                    editAccountNone.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editAccountNone);
                        // request
                        {
                            // get server state
                            // Server.State.Type serverState = RequestChange.GetServerState(editAccountNone);
                            // set origin
                            {

                            }
                            needReset = false;
                        }
                    }
                }
                else
                {
                    Debug.LogError("editAccountNone null: " + this);
                }
                // UI
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
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
                uiData.editAccountNone.allAddCallBack(this);
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
            // editAccountNone
            {
                if (data is EditData<AccountNone>)
                {
                    EditData<AccountNone> editAccountNone = data as EditData<AccountNone>;
                    // Child
                    {
                        editAccountNone.show.allAddCallBack(this);
                        editAccountNone.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is AccountNone)
                    {
                        AccountNone accountNone = data as AccountNone;
                        // Parent
                        {
                            DataUtils.addParentCallBack(accountNone, this, ref this.server);
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
                uiData.editAccountNone.allRemoveCallBack(this);
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
            // editAccountNone
            {
                if (data is EditData<AccountNone>)
                {
                    EditData<AccountNone> editAccountNone = data as EditData<AccountNone>;
                    // Child
                    {
                        editAccountNone.show.allRemoveCallBack(this);
                        editAccountNone.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is AccountNone)
                    {
                        AccountNone accountNone = data as AccountNone;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(accountNone, this, ref this.server);
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
                case UIData.Property.editAccountNone:
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
            // editAccountNone
            {
                if (wrapProperty.p is EditData<AccountNone>)
                {
                    switch ((EditData<AccountNone>.Property)wrapProperty.n)
                    {
                        case EditData<AccountNone>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<AccountNone>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountNone>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<AccountNone>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<AccountNone>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<AccountNone>.Property.editType:
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
                    if (wrapProperty.p is AccountNone)
                    {
                        switch ((AccountNone.Property)wrapProperty.n)
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