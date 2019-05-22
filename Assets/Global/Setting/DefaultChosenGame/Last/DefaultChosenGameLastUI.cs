using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DefaultChosenGameLastUI : UIHaveTransformDataBehavior<DefaultChosenGameLastUI.UIData>
{

    #region UIData

    public class UIData : DefaultChosenGame.UIData
    {

        public VP<EditData<DefaultChosenGameLast>> editDefaultChosenGameLast;

        public VP<UIRectTransform.ShowType> showType;

        #region gameType

        public VP<RequestChangeEnumUI.UIData> gameType;

        public void makeRequestChangeGameType(RequestChangeUpdate<int>.UpdateData update, int newGameType)
        {
            // Find
            DefaultChosenGameLast defaultChosenGameLast = null;
            {
                EditData<DefaultChosenGameLast> editDefaultChosenGameLast = this.editDefaultChosenGameLast.v;
                if (editDefaultChosenGameLast != null)
                {
                    defaultChosenGameLast = editDefaultChosenGameLast.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultChosenGameLast null: " + this);
                }
            }
            // Process
            if (defaultChosenGameLast != null)
            {
                GameType.Type gameTypeType = GameType.GetEnableGameTypeByIndex(this.editDefaultChosenGameLast.v.origin.v.data, newGameType);
                defaultChosenGameLast.gameType.v = gameTypeType;
            }
            else
            {
                Debug.LogError("defaultChosenGameLast null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editDefaultChosenGameLast,
            showType,
            gameType
        }

        public UIData() : base()
        {
            this.editDefaultChosenGameLast = new VP<EditData<DefaultChosenGameLast>>(this, (byte)Property.editDefaultChosenGameLast, new EditData<DefaultChosenGameLast>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            // gameType
            {
                this.gameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.gameType, new RequestChangeEnumUI.UIData());
                // event
                this.gameType.v.updateData.v.request.v = makeRequestChangeGameType;
            }
        }

        #endregion

        public override DefaultChosenGame.Type getType()
        {
            return DefaultChosenGame.Type.Last;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Game Chosen Last");

    public Text lbGameType;
    private static readonly TxtLanguage txtGameType = new TxtLanguage("Game");

    static DefaultChosenGameLastUI()
    {
        txtTitle.add(Language.Type.vi, "Game Được Chọn Trước");
        txtGameType.add(Language.Type.vi, "Game");
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
                EditData<DefaultChosenGameLast> editDefaultChosenGameLast = this.data.editDefaultChosenGameLast.v;
                if (editDefaultChosenGameLast != null)
                {
                    editDefaultChosenGameLast.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editDefaultChosenGameLast);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            // set origin
                            {
                                // gameType
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.gameType.v, GameType.GetEnableTypeString(editDefaultChosenGameLast.origin.v.data));
                                    RequestChange.RefreshUI(this.data.gameType.v, editDefaultChosenGameLast, serverState, needReset, editData => GameType.getEnableIndex(editData.gameType.v, editDefaultChosenGameLast.origin.v.data));
                                }
                            }
                            needReset = false;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // gameType
                        UIUtils.SetLabelContentPosition(lbGameType, this.data.gameType.v, ref deltaY);
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
                        if (lbGameType != null)
                        {
                            lbGameType.text = txtGameType.get();
                            Setting.get().setLabelTextSize(lbGameType);
                        }
                        else
                        {
                            Debug.LogError("lbGameType null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("editDefaultChosenGameLast null: " + this);
                }
            }
            else
            {
                // Debug.LogError("data null");
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
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editDefaultChosenGameLast.allAddCallBack(this);
                uiData.gameType.allAddCallBack(this);
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
            // editDefaultChosenGameLast
            {
                if (data is EditData<DefaultChosenGameLast>)
                {
                    EditData<DefaultChosenGameLast> editDefaultChosenGameLast = data as EditData<DefaultChosenGameLast>;
                    // Child
                    {
                        editDefaultChosenGameLast.show.allAddCallBack(this);
                        editDefaultChosenGameLast.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is DefaultChosenGameLast)
                {
                    needReset = true;
                    dirty = true;
                    return;
                }
            }
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.gameType:
                                UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
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
                uiData.editDefaultChosenGameLast.allRemoveCallBack(this);
                uiData.gameType.allRemoveCallBack(this);
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
            // editDefaultChosenGameLast
            {
                if (data is EditData<DefaultChosenGameLast>)
                {
                    EditData<DefaultChosenGameLast> editDefaultChosenGameLast = data as EditData<DefaultChosenGameLast>;
                    // Child
                    {
                        editDefaultChosenGameLast.show.allRemoveCallBack(this);
                        editDefaultChosenGameLast.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is DefaultChosenGameLast)
                {
                    return;
                }
            }
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
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
                case UIData.Property.editDefaultChosenGameLast:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showType:
                    dirty = true;
                    break;
                case UIData.Property.gameType:
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
                case Setting.Property.itemSize:
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
                case Setting.Property.defaultChosenGame:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // editDefaultChosenGameLast
            {
                if (wrapProperty.p is EditData<DefaultChosenGameLast>)
                {
                    switch ((EditData<DefaultChosenGameLast>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultChosenGameLast>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultChosenGameLast>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChosenGameLast>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChosenGameLast>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultChosenGameLast>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultChosenGameLast>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is DefaultChosenGameLast)
                {
                    switch ((DefaultChosenGameLast.Property)wrapProperty.n)
                    {
                        case DefaultChosenGameLast.Property.gameType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}