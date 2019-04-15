﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DefaultChosenGameAlwaysUI : UIHaveTransformDataBehavior<DefaultChosenGameAlwaysUI.UIData>
{

    #region UIData

    public class UIData : DefaultChosenGame.UIData
    {

        public VP<EditData<DefaultChosenGameAlways>> editDefaultChosenGameAlways;

        public VP<UIRectTransform.ShowType> showType;

        #region gameType

        public VP<RequestChangeEnumUI.UIData> gameType;

        public void makeRequestChangeGameType(RequestChangeUpdate<int>.UpdateData update, int newGameType)
        {
            // Find
            DefaultChosenGameAlways defaultChosenGameAlways = null;
            {
                EditData<DefaultChosenGameAlways> editDefaultChosenGameAlways = this.editDefaultChosenGameAlways.v;
                if (editDefaultChosenGameAlways != null)
                {
                    defaultChosenGameAlways = editDefaultChosenGameAlways.show.v.data;
                }
                else
                {
                    Debug.LogError("editDefaultChosenGameAlways null: " + this);
                }
            }
            // Process
            if (defaultChosenGameAlways != null)
            {
                // Find gameTypeType
                GameType.Type gameTypeType = GameType.Type.CHESS;
                {
                    if (newGameType >= 0 && newGameType < GameType.EnableTypes.Length)
                    {
                        gameTypeType = GameType.EnableTypes[newGameType];
                    }
                }
                defaultChosenGameAlways.gameType.v = gameTypeType;
            }
            else
            {
                Debug.LogError("defaultChosenGameAlways null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editDefaultChosenGameAlways,
            showType,
            gameType
        }

        public UIData() : base()
        {
            this.editDefaultChosenGameAlways = new VP<EditData<DefaultChosenGameAlways>>(this, (byte)Property.editDefaultChosenGameAlways, new EditData<DefaultChosenGameAlways>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            // gameType
            {
                this.gameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.gameType, new RequestChangeEnumUI.UIData());
                // event
                this.gameType.v.updateData.v.request.v = makeRequestChangeGameType;
                {
                    for (int i = 0; i < GameType.EnableTypes.Length; i++)
                    {
                        this.gameType.v.options.add(GameType.EnableTypes[i].ToString());
                    }
                }
            }
        }

        #endregion

        public override DefaultChosenGame.Type getType()
        {
            return DefaultChosenGame.Type.Always;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Game Always Chosen");

    public Text lbGameType;
    private static readonly TxtLanguage txtGameType = new TxtLanguage("Game");

    static DefaultChosenGameAlwaysUI()
    {
        txtTitle.add(Language.Type.vi, "Game Luôn Được Chọn");
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
                EditData<DefaultChosenGameAlways> editDefaultChosenGameAlways = this.data.editDefaultChosenGameAlways.v;
                if (editDefaultChosenGameAlways != null)
                {
                    editDefaultChosenGameAlways.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editDefaultChosenGameAlways);
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            // set origin
                            {
                                // gameType
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.gameType.v, GameType.GetEnableTypeString());
                                    RequestChange.RefreshUI(this.data.gameType.v, editDefaultChosenGameAlways, serverState, needReset, editData => GameType.getEnableIndex(editData.gameType.v));
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
                    Debug.LogError("editDefaultChosenGameAlways null: " + this);
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

    public RequestChangeEnumUI requestEnumPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editDefaultChosenGameAlways.allAddCallBack(this);
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
            // editDefaultChosenGameAlways
            {
                if (data is EditData<DefaultChosenGameAlways>)
                {
                    EditData<DefaultChosenGameAlways> editDefaultChosenGameAlways = data as EditData<DefaultChosenGameAlways>;
                    // Child
                    {
                        editDefaultChosenGameAlways.show.allAddCallBack(this);
                        editDefaultChosenGameAlways.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is DefaultChosenGameAlways)
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
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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
                uiData.editDefaultChosenGameAlways.allRemoveCallBack(this);
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
            // editDefaultChosenGameAlways
            {
                if (data is EditData<DefaultChosenGameAlways>)
                {
                    EditData<DefaultChosenGameAlways> editDefaultChosenGameAlways = data as EditData<DefaultChosenGameAlways>;
                    // Child
                    {
                        editDefaultChosenGameAlways.show.allRemoveCallBack(this);
                        editDefaultChosenGameAlways.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is DefaultChosenGameAlways)
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
                case UIData.Property.editDefaultChosenGameAlways:
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
            // editDefaultChosenGameAlways
            {
                if (wrapProperty.p is EditData<DefaultChosenGameAlways>)
                {
                    switch ((EditData<DefaultChosenGameAlways>.Property)wrapProperty.n)
                    {
                        case EditData<DefaultChosenGameAlways>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<DefaultChosenGameAlways>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChosenGameAlways>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<DefaultChosenGameAlways>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<DefaultChosenGameAlways>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<DefaultChosenGameAlways>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is DefaultChosenGameAlways)
                {
                    switch ((DefaultChosenGameAlways.Property)wrapProperty.n)
                    {
                        case DefaultChosenGameAlways.Property.gameType:
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