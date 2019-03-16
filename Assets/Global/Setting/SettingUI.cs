using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SettingUI : UIBehavior<SettingUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<EditData<Setting>> editSetting;

        public VP<UIRectTransform.ShowType> showType;

        #region language

        public VP<RequestChangeEnumUI.UIData> language;

        public void makeRequestChangeLanguage(RequestChangeUpdate<int>.UpdateData update, int newLanguage)
        {
            // Find
            Setting setting = null;
            {
                EditData<Setting> editSetting = this.editSetting.v;
                if (editSetting != null)
                {
                    setting = editSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
            }
            // Process
            if (setting != null)
            {
                setting.language.v = Language.GetSupportType(newLanguage);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region style

        public VP<RequestChangeEnumUI.UIData> style;

        public void makeRequestChangeStyle(RequestChangeUpdate<int>.UpdateData update, int newStyle)
        {
            // Find
            Setting setting = null;
            {
                EditData<Setting> editSetting = this.editSetting.v;
                if (editSetting != null)
                {
                    setting = editSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
            }
            // Process
            if (setting != null)
            {
                setting.style.v = (Setting.Style)newStyle;
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region showLastMove

        public VP<RequestChangeBoolUI.UIData> showLastMove;

        public void makeRequestChangeShowLastMove(RequestChangeUpdate<bool>.UpdateData update, bool newShowLastMove)
        {
            // Find
            Setting setting = null;
            {
                EditData<Setting> editSetting = this.editSetting.v;
                if (editSetting != null)
                {
                    setting = editSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
            }
            // Process
            if (setting != null)
            {
                setting.showLastMove.v = newShowLastMove;
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region viewUrlImage

        public VP<RequestChangeBoolUI.UIData> viewUrlImage;

        public void makeRequestChangeViewUrlImage(RequestChangeUpdate<bool>.UpdateData update, bool newViewUrlImage)
        {
            // Find
            Setting setting = null;
            {
                EditData<Setting> editSetting = this.editSetting.v;
                if (editSetting != null)
                {
                    setting = editSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
            }
            // Process
            if (setting != null)
            {
                setting.viewUrlImage.v = newViewUrlImage;
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        public VP<AnimationSettingUI.UIData> animationSetting;

        #region maxThinkCount

        public VP<RequestChangeIntUI.UIData> maxThinkCount;

        public void makeRequestChangeMaxThinkCount(RequestChangeUpdate<int>.UpdateData update, int newMaxThinkCount)
        {
            // Find
            Setting setting = null;
            {
                EditData<Setting> editSetting = this.editSetting.v;
                if (editSetting != null)
                {
                    setting = editSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
            }
            // Process
            if (setting != null)
            {
                setting.maxThinkCount.v = Mathf.Clamp(newMaxThinkCount, AIController.MIN_THINK_COUNT, AIController.MAX_THINK_COUNT);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region defaultChosenGameType

        public VP<RequestChangeEnumUI.UIData> defaultChosenGameType;

        public void makeRequestChangeDefaultChosenGameType(RequestChangeUpdate<int>.UpdateData update, int newDefaultChosenGameType)
        {
            // Find
            Setting setting = null;
            {
                EditData<Setting> editSetting = this.editSetting.v;
                if (editSetting != null)
                {
                    setting = editSetting.show.v.data;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
            }
            // Process
            if (setting != null)
            {
                // Find
                DefaultChosenGame.Type defaultChosenGameType = (DefaultChosenGame.Type)newDefaultChosenGameType;
                setting.changeDefaultChosenGameType(defaultChosenGameType);
            }
            else
            {
                Debug.LogError("gameFactory null: " + this);
            }
        }

        public VP<DefaultChosenGame.UIData> defaultChosenGameUIData;

        #endregion

        #region Constructor

        public enum Property
        {
            editSetting,
            showType,
            language,
            style,
            showLastMove,
            viewUrlImage,
            animationSetting,
            maxThinkCount,
            defaultChosenGameType,
            defaultChosenGameUIData
        }

        public UIData() : base()
        {
            this.editSetting = new VP<EditData<Setting>>(this, (byte)Property.editSetting, new EditData<Setting>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            // language
            {
                this.language = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.language, new RequestChangeEnumUI.UIData());
                this.language.v.updateData.v.request.v = makeRequestChangeLanguage;
                // options
                {
                    foreach (Language.Type type in Language.SupportTypes)
                    {
                        string strType = "" + type;
                        {
                            string txtType = "";
                            if (Language.dict.TryGetValue(type, out txtType))
                            {
                                strType += " " + txtType;
                            }
                            else
                            {
                                Debug.LogError("why don't have type: " + type + "; " + this);
                            }
                        }
                        this.language.v.options.add(strType);
                    }
                }
            }
            // style
            {
                this.style = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.style, new RequestChangeEnumUI.UIData());
                this.style.v.updateData.v.request.v = makeRequestChangeStyle;
                // options
                {
                    foreach (Setting.Style style in System.Enum.GetValues(typeof(Setting.Style)))
                    {
                        this.style.v.options.add("" + style);
                    }
                }
            }
            // showLastMove
            {
                this.showLastMove = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.showLastMove, new RequestChangeBoolUI.UIData());
                this.showLastMove.v.updateData.v.request.v = makeRequestChangeShowLastMove;
            }
            // viewUrlImage
            {
                this.viewUrlImage = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.viewUrlImage, new RequestChangeBoolUI.UIData());
                this.viewUrlImage.v.updateData.v.request.v = makeRequestChangeViewUrlImage;
            }
            this.animationSetting = new VP<AnimationSettingUI.UIData>(this, (byte)Property.animationSetting, new AnimationSettingUI.UIData());
            // maxThinkCount
            {
                this.maxThinkCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxThinkCount, new RequestChangeIntUI.UIData());
                // have limit
                {
                    IntLimit.Have have = new IntLimit.Have();
                    {
                        have.uid = this.maxThinkCount.v.limit.makeId();
                        have.min.v = AIController.MIN_THINK_COUNT;
                        have.max.v = AIController.MAX_THINK_COUNT;
                    }
                    this.maxThinkCount.v.limit.v = have;
                }
                // event
                this.maxThinkCount.v.updateData.v.request.v = makeRequestChangeMaxThinkCount;
            }
            // defaultChosenGameType
            {
                // gameType
                {
                    this.defaultChosenGameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.defaultChosenGameType, new RequestChangeEnumUI.UIData());
                    // event
                    this.defaultChosenGameType.v.updateData.v.request.v = makeRequestChangeDefaultChosenGameType;
                    {
                        foreach (DefaultChosenGame.Type type in System.Enum.GetValues(typeof(DefaultChosenGame.Type)))
                        {
                            this.defaultChosenGameType.v.options.add(type.ToString());
                        }
                    }
                }
                this.defaultChosenGameUIData = new VP<DefaultChosenGame.UIData>(this, (byte)Property.defaultChosenGameUIData, null);
            }
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text lbLanguage;
    private static readonly TxtLanguage txtLanguage = new TxtLanguage();

    public Text lbStyle;
    private static readonly TxtLanguage txtStyle = new TxtLanguage();

    public Text lbShowLastMove;
    private static readonly TxtLanguage txtShowLastMove = new TxtLanguage();

    public Text lbViewUrlImage;
    private static readonly TxtLanguage txtViewUrlImage = new TxtLanguage();

    public Text lbMaxThinkCount;
    private static readonly TxtLanguage txtMaxThinkCount = new TxtLanguage();

    public Text lbDefaultChosenGameType;
    private static readonly TxtLanguage txtDefaultChosenGameType = new TxtLanguage();
    private static readonly TxtLanguage txtDefaultChosenGameLast = new TxtLanguage();
    private static readonly TxtLanguage txtDefaultChosenGameAlways = new TxtLanguage();

    static SettingUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thiết Lập");
            txtLanguage.add(Language.Type.vi, "Ngôn Ngữ");
            txtStyle.add(Language.Type.vi, "Kiểu");
            txtShowLastMove.add(Language.Type.vi, "Hiện nước đi ");
            txtViewUrlImage.add(Language.Type.vi, "Xem ảnh url");
            txtMaxThinkCount.add(Language.Type.vi, "Số luồng nghĩ tối đa");

            txtDefaultChosenGameType.add(Language.Type.vi, "Game mặc định");
            txtDefaultChosenGameLast.add(Language.Type.vi, "Chọn Trước");
            txtDefaultChosenGameAlways.add(Language.Type.vi, "Luôn Chọn");
        }
        // rect
        {

        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public Image bgAnimationSetting;
    public Image bgDefaultChosenGame;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<Setting> editSetting = this.data.editSetting.v;
                if (editSetting != null)
                {
                    editSetting.update();
                    // get show
                    Setting show = editSetting.show.v.data;
                    Setting compare = editSetting.compare.v.data;
                    if (show != null)
                    {
                        // different
                        if (lbTitle != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editSetting.compareOtherType.v.data != null)
                                {
                                    if (editSetting.compareOtherType.v.data.GetType() != show.GetType())
                                    {
                                        isDifferent = true;
                                    }
                                }
                            }
                            lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                        }
                        else
                        {
                            Debug.LogError("lbSetting null: " + this);
                        }
                        // request
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            /*{
								Server server = show.findDataInParent<Server> ();
								if (server != null) {
									if (server.state.v != null) {
										serverState = server.state.v.getType ();
									} else {
										Debug.LogError ("server state null: " + this);
									}
								} else {
									Debug.LogError ("server null: " + this);
								}
							}*/
                            // set origin
                            {
                                // language
                                {
                                    RequestChangeEnumUI.UIData language = this.data.language.v;
                                    if (language != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = language.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = Language.GetSupportIndex(show.language.v);
                                            updateData.canRequestChange.v = editSetting.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                language.showDifferent.v = true;
                                                language.compare.v = Language.GetSupportIndex(compare.language.v);
                                            }
                                            else
                                            {
                                                language.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // style
                                {
                                    RequestChangeEnumUI.UIData style = this.data.style.v;
                                    if (style != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = style.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = (int)show.style.v;
                                            updateData.canRequestChange.v = editSetting.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                style.showDifferent.v = true;
                                                style.compare.v = (int)(compare.style.v);
                                            }
                                            else
                                            {
                                                style.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // showLastMove
                                {
                                    RequestChangeBoolUI.UIData showLastMove = this.data.showLastMove.v;
                                    if (showLastMove != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = showLastMove.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.showLastMove.v;
                                            updateData.canRequestChange.v = editSetting.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                showLastMove.showDifferent.v = true;
                                                showLastMove.compare.v = compare.showLastMove.v;
                                            }
                                            else
                                            {
                                                showLastMove.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // viewUrlImage
                                {
                                    RequestChangeBoolUI.UIData viewUrlImage = this.data.viewUrlImage.v;
                                    if (viewUrlImage != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = viewUrlImage.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.viewUrlImage.v;
                                            updateData.canRequestChange.v = editSetting.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                viewUrlImage.showDifferent.v = true;
                                                viewUrlImage.compare.v = compare.viewUrlImage.v;
                                            }
                                            else
                                            {
                                                viewUrlImage.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // animationSetting
                                {
                                    AnimationSettingUI.UIData animationSetting = this.data.animationSetting.v;
                                    if (animationSetting != null)
                                    {
                                        EditData<AnimationSetting> editAnimationSetting = animationSetting.editAnimationSetting.v;
                                        if (editAnimationSetting != null)
                                        {
                                            // origin
                                            {
                                                AnimationSetting originAnimationSetting = null;
                                                {
                                                    Setting originSetting = editSetting.origin.v.data;
                                                    if (originSetting != null)
                                                    {
                                                        originAnimationSetting = originSetting.animationSetting.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("originSetting null: " + this);
                                                    }
                                                }
                                                editAnimationSetting.origin.v = new ReferenceData<AnimationSetting>(originAnimationSetting);
                                            }
                                            // show
                                            {
                                                AnimationSetting showAnimationSetting = null;
                                                {
                                                    Setting showSetting = editSetting.show.v.data;
                                                    if (showSetting != null)
                                                    {
                                                        showAnimationSetting = showSetting.animationSetting.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("showSetting null: " + this);
                                                    }
                                                }
                                                editAnimationSetting.show.v = new ReferenceData<AnimationSetting>(showAnimationSetting);
                                            }
                                            // compare
                                            {
                                                AnimationSetting compareAnimationSetting = null;
                                                {
                                                    Setting compareSetting = editSetting.compare.v.data;
                                                    if (compareSetting != null)
                                                    {
                                                        compareAnimationSetting = compareSetting.animationSetting.v;
                                                    }
                                                    else
                                                    {
                                                        // Debug.LogError("compareSetting null: " + this);
                                                    }
                                                }
                                                editAnimationSetting.compare.v = new ReferenceData<AnimationSetting>(compareAnimationSetting);
                                            }
                                            // compare other type
                                            {
                                                AnimationSetting compareOtherTypeAnimationSetting = null;
                                                {
                                                    Setting compareOtherTypeSetting = (Setting)editSetting.compareOtherType.v.data;
                                                    if (compareOtherTypeSetting != null)
                                                    {
                                                        compareOtherTypeAnimationSetting = compareOtherTypeSetting.animationSetting.v;
                                                    }
                                                }
                                                editAnimationSetting.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeAnimationSetting);
                                            }
                                            // canEdit
                                            editAnimationSetting.canEdit.v = editSetting.canEdit.v;
                                            // editType
                                            editAnimationSetting.editType.v = editSetting.editType.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("editAnimationSetting null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("animationSetting null: " + this);
                                    }
                                }
                                // maxThinkCount
                                {
                                    RequestChangeIntUI.UIData maxThinkCount = this.data.maxThinkCount.v;
                                    if (maxThinkCount != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = maxThinkCount.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.maxThinkCount.v;
                                            updateData.canRequestChange.v = editSetting.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                maxThinkCount.showDifferent.v = true;
                                                maxThinkCount.compare.v = compare.maxThinkCount.v;
                                            }
                                            else
                                            {
                                                maxThinkCount.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }

                                // defaultChosenGameType
                                {
                                    RequestChangeEnumUI.UIData defaultChosenGameType = this.data.defaultChosenGameType.v;
                                    if (defaultChosenGameType != null)
                                    {
                                        // options
                                        {
                                            List<string> options = new List<string>();
                                            {
                                                options.Add(txtDefaultChosenGameLast.get("Last Chosen"));
                                                options.Add(txtDefaultChosenGameAlways.get("Always Choose"));
                                            }
                                            defaultChosenGameType.options.copyList(options);
                                        }
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = defaultChosenGameType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = (int)show.defaultChosenGame.v.getType();
                                            updateData.canRequestChange.v = editSetting.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                defaultChosenGameType.showDifferent.v = true;
                                                defaultChosenGameType.compare.v = (int)compare.defaultChosenGame.v.getType();
                                            }
                                            else
                                            {
                                                defaultChosenGameType.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // defaultChosenGameType
                                {
                                    DefaultChosenGame defaultChosenGame = show.defaultChosenGame.v;
                                    if (defaultChosenGame != null)
                                    {
                                        // find origin 
                                        DefaultChosenGame originDefaultChosenGame = null;
                                        {
                                            Setting originSetting = editSetting.origin.v.data;
                                            if (originSetting != null)
                                            {
                                                originDefaultChosenGame = originSetting.defaultChosenGame.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("origin null: " + this);
                                            }
                                        }
                                        // find compare
                                        DefaultChosenGame compareDefaultChosenGame = null;
                                        {
                                            if (compare != null)
                                            {
                                                compareDefaultChosenGame = compare.defaultChosenGame.v;
                                            }
                                            else
                                            {
                                                // Debug.LogError ("compare null: " + this);
                                            }
                                        }
                                        switch (defaultChosenGame.getType())
                                        {
                                            case DefaultChosenGame.Type.Last:
                                                {
                                                    DefaultChosenGameLast defaultChosenGameLast = defaultChosenGame as DefaultChosenGameLast;
                                                    // UIData
                                                    DefaultChosenGameLastUI.UIData defaultChosenGameLastUIData = this.data.defaultChosenGameUIData.newOrOld<DefaultChosenGameLastUI.UIData>();
                                                    {
                                                        EditData<DefaultChosenGameLast> editDefaultChosenGameLast = defaultChosenGameLastUIData.editDefaultChosenGameLast.v;
                                                        if (editDefaultChosenGameLast != null)
                                                        {
                                                            // origin
                                                            editDefaultChosenGameLast.origin.v = new ReferenceData<DefaultChosenGameLast>((DefaultChosenGameLast)originDefaultChosenGame);
                                                            // show
                                                            editDefaultChosenGameLast.show.v = new ReferenceData<DefaultChosenGameLast>(defaultChosenGameLast);
                                                            // compare
                                                            editDefaultChosenGameLast.compare.v = new ReferenceData<DefaultChosenGameLast>((DefaultChosenGameLast)compareDefaultChosenGame);
                                                            // compareOtherType
                                                            editDefaultChosenGameLast.compareOtherType.v = new ReferenceData<Data>(compareDefaultChosenGame);
                                                            // canEdit
                                                            editDefaultChosenGameLast.canEdit.v = editSetting.canEdit.v;
                                                            // editType
                                                            editDefaultChosenGameLast.editType.v = editSetting.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultGameDataFactory null: " + this);
                                                        }
                                                        defaultChosenGameLastUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                    }
                                                    this.data.defaultChosenGameUIData.v = defaultChosenGameLastUIData;
                                                }
                                                break;
                                            case DefaultChosenGame.Type.Always:
                                                {
                                                    DefaultChosenGameAlways defaultChosenGameAlways = defaultChosenGame as DefaultChosenGameAlways;
                                                    // UIData
                                                    DefaultChosenGameAlwaysUI.UIData defaultChosenGameAlwaysUIData = this.data.defaultChosenGameUIData.newOrOld<DefaultChosenGameAlwaysUI.UIData>();
                                                    {
                                                        EditData<DefaultChosenGameAlways> editDefaultChosenGameAlways = defaultChosenGameAlwaysUIData.editDefaultChosenGameAlways.v;
                                                        if (editDefaultChosenGameAlways != null)
                                                        {
                                                            // origin
                                                            editDefaultChosenGameAlways.origin.v = new ReferenceData<DefaultChosenGameAlways>((DefaultChosenGameAlways)originDefaultChosenGame);
                                                            // show
                                                            editDefaultChosenGameAlways.show.v = new ReferenceData<DefaultChosenGameAlways>(defaultChosenGameAlways);
                                                            // compare
                                                            editDefaultChosenGameAlways.compare.v = new ReferenceData<DefaultChosenGameAlways>((DefaultChosenGameAlways)compareDefaultChosenGame);
                                                            // compareOtherType
                                                            editDefaultChosenGameAlways.compareOtherType.v = new ReferenceData<Data>(compareDefaultChosenGame);
                                                            // canEdit
                                                            editDefaultChosenGameAlways.canEdit.v = editSetting.canEdit.v;
                                                            // editType
                                                            editDefaultChosenGameAlways.editType.v = editSetting.editType.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("editDefaultChosenGameAlways null: " + this);
                                                        }
                                                        defaultChosenGameAlwaysUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                    }
                                                    this.data.defaultChosenGameUIData.v = defaultChosenGameAlwaysUIData;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + defaultChosenGame.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("show null: " + this);
                                    }
                                }
                            }
                        }
                        // reset
                        if (needReset)
                        {
                            needReset = false;
                            // language
                            {
                                RequestChangeEnumUI.UIData language = this.data.language.v;
                                if (language != null)
                                {
                                    // update
                                    RequestChangeUpdate<int>.UpdateData updateData = language.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = Language.GetSupportIndex(show.language.v);
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRule null: " + this);
                                }
                            }
                            // style
                            {
                                RequestChangeEnumUI.UIData style = this.data.style.v;
                                if (style != null)
                                {
                                    // update
                                    RequestChangeUpdate<int>.UpdateData updateData = style.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = (int)show.style.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRule null: " + this);
                                }
                            }
                            // showLastMove
                            {
                                RequestChangeBoolUI.UIData showLastMove = this.data.showLastMove.v;
                                if (showLastMove != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = showLastMove.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.showLastMove.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRule null: " + this);
                                }
                            }
                            // viewUrlImage
                            {
                                RequestChangeBoolUI.UIData viewUrlImage = this.data.viewUrlImage.v;
                                if (viewUrlImage != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = viewUrlImage.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.viewUrlImage.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRule null: " + this);
                                }
                            }
                            // maxThinkCount
                            {
                                RequestChangeIntUI.UIData maxThinkCount = this.data.maxThinkCount.v;
                                if (maxThinkCount != null)
                                {
                                    // update
                                    RequestChangeUpdate<int>.UpdateData updateData = maxThinkCount.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = show.maxThinkCount.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRule null: " + this);
                                }
                            }

                            // defaultChosenGameType
                            {
                                RequestChangeEnumUI.UIData defaultChosenGameType = this.data.defaultChosenGameType.v;
                                if (defaultChosenGameType != null)
                                {
                                    // update
                                    RequestChangeUpdate<int>.UpdateData updateData = defaultChosenGameType.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = (int)show.defaultChosenGame.v.getType();
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("useRule null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError("show null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
                // UISize
                {
                    float deltaY = UIConstants.HeaderHeight;
                    // header
                    {
                        if (this.data.showType.v == UIRectTransform.ShowType.HeadLess)
                        {
                            deltaY = 0;
                            if (lbTitle != null)
                            {
                                lbTitle.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                        else
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                    }
                    // language
                    {
                        if (this.data.language.v != null)
                        {
                            if (lbLanguage != null)
                            {
                                lbLanguage.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbLanguage.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbLanguage null");
                            }
                            UIRectTransform.SetPosY(this.data.language.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbLanguage != null)
                            {
                                lbLanguage.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbLanguage null");
                            }
                        }
                    }
                    // style
                    {
                        if (this.data.style.v != null)
                        {
                            if (lbStyle != null)
                            {
                                lbStyle.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbStyle.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbStyle null");
                            }
                            UIRectTransform.SetPosY(this.data.style.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbStyle != null)
                            {
                                lbStyle.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbStyle null");
                            }
                        }
                    }
                    // showLastMove
                    {
                        if (this.data.showLastMove.v != null)
                        {
                            if (lbShowLastMove != null)
                            {
                                lbShowLastMove.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbShowLastMove.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbShowLastMove null");
                            }
                            UIRectTransform.SetPosY(this.data.showLastMove.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbShowLastMove != null)
                            {
                                lbShowLastMove.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbShowLastMove null");
                            }
                        }
                    }
                    // viewUrlImage
                    {
                        if (this.data.viewUrlImage.v != null)
                        {
                            if (lbViewUrlImage != null)
                            {
                                lbViewUrlImage.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbViewUrlImage.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbViewUrlImage null");
                            }
                            UIRectTransform.SetPosY(this.data.viewUrlImage.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbViewUrlImage != null)
                            {
                                lbViewUrlImage.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbViewUrlImage null");
                            }
                        }
                    }
                    // animationSetting
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // UI
                        {
                            float height = UIRectTransform.SetPosY(this.data.animationSetting.v, deltaY);
                            bgHeight += height;
                            deltaY += height;
                        }
                        // bg
                        if (bgAnimationSetting != null)
                        {
                            UIRectTransform.SetPosY(bgAnimationSetting.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgAnimationSetting.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgAnimationSetting null");
                        }
                    }
                    // maxThinkCount
                    {
                        if (this.data.maxThinkCount.v != null)
                        {
                            if (lbMaxThinkCount != null)
                            {
                                lbMaxThinkCount.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbMaxThinkCount.rectTransform, deltaY);
                            }
                            else
                            {
                                Debug.LogError("lbMaxThinkCount null");
                            }
                            UIRectTransform.SetPosY(this.data.maxThinkCount.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                            deltaY += UIConstants.ItemHeight;
                        }
                        else
                        {
                            if (lbMaxThinkCount != null)
                            {
                                lbMaxThinkCount.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbMaxThinkCount null");
                            }
                        }
                    }
                    // defaultChosenGame
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // type
                        {
                            if (this.data.defaultChosenGameType.v != null)
                            {
                                if (lbDefaultChosenGameType != null)
                                {
                                    lbDefaultChosenGameType.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbDefaultChosenGameType.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbDefaultChosenGameType null");
                                }
                                UIRectTransform.SetPosY(this.data.defaultChosenGameType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                bgHeight += UIConstants.ItemHeight;
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbDefaultChosenGameType != null)
                                {
                                    lbDefaultChosenGameType.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbDefaultChosenGameType null");
                                }
                            }
                        }
                        // UI
                        {
                            float height = UIRectTransform.SetPosY(this.data.defaultChosenGameUIData.v, deltaY);
                            bgHeight += height;
                            deltaY += height;
                        }
                        // bg
                        if (bgDefaultChosenGame != null)
                        {
                            UIRectTransform.SetPosY(bgDefaultChosenGame.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgDefaultChosenGame.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgDefaultChosenGame null");
                        }
                    }
                    // set
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Setting");
                    }
                    else
                    {
                        Debug.LogError("lbSetting null: " + this);
                    }
                    if (lbLanguage != null)
                    {
                        lbLanguage.text = txtLanguage.get("Language");
                    }
                    else
                    {
                        Debug.LogError("tvLanguage null: " + this);
                    }
                    if (lbStyle != null)
                    {
                        lbStyle.text = txtStyle.get("Style");
                    }
                    else
                    {
                        Debug.LogError("tvStyle null: " + this);
                    }
                    if (lbShowLastMove != null)
                    {
                        lbShowLastMove.text = txtShowLastMove.get("Show Last Move");
                    }
                    else
                    {
                        Debug.LogError("tvShowLastMove null: " + this);
                    }
                    if (lbViewUrlImage != null)
                    {
                        lbViewUrlImage.text = txtViewUrlImage.get("View Url Image");
                    }
                    else
                    {
                        Debug.LogError("tvViewUrlImage null: " + this);
                    }
                    if (lbMaxThinkCount != null)
                    {
                        lbMaxThinkCount.text = txtMaxThinkCount.get("Max Think Count");
                    }
                    else
                    {
                        Debug.LogError("tvMaxThinkCount null: " + this);
                    }
                    if (lbDefaultChosenGameType != null)
                    {
                        lbDefaultChosenGameType.text = txtDefaultChosenGameType.get("Default game");
                    }
                    else
                    {
                        Debug.LogError("lbDefaultChosenGameType null");
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

    public RequestChangeEnumUI requestEnumPrefab;
    public RequestChangeBoolUI requestBoolPrefab;
    public AnimationSettingUI animationSettingPrefab;
    public RequestChangeIntUI requestIntPrefab;

    private static readonly UIRectTransform languageRect = new UIRectTransform(UIConstants.RequestEnumRect);
    private static readonly UIRectTransform styleRect = new UIRectTransform(UIConstants.RequestEnumRect);
    private static readonly UIRectTransform showLastMoveRect = new UIRectTransform(UIConstants.RequestBoolRect);
    private static readonly UIRectTransform viewUrlImageRect = new UIRectTransform(UIConstants.RequestBoolRect);
    private static readonly UIRectTransform maxThinkCountRect = new UIRectTransform(UIConstants.RequestRect);
    private static readonly UIRectTransform defaultChosenGameTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

    public DefaultChosenGameLastUI defaultChosenGameLastPrefab;
    public DefaultChosenGameAlwaysUI defaultChosenGameAlwaysPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            {
                Setting.get().addCallBack(this);
            }
            // Child
            {
                uiData.editSetting.allAddCallBack(this);
                uiData.language.allAddCallBack(this);
                uiData.style.allAddCallBack(this);
                uiData.showLastMove.allAddCallBack(this);
                uiData.viewUrlImage.allAddCallBack(this);
                uiData.animationSetting.allAddCallBack(this);
                uiData.maxThinkCount.allAddCallBack(this);
                uiData.defaultChosenGameType.allAddCallBack(this);
                uiData.defaultChosenGameUIData.allAddCallBack(this);
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
            // editSetting
            {
                if (data is EditData<Setting>)
                {
                    EditData<Setting> editSetting = data as EditData<Setting>;
                    // Child
                    {
                        editSetting.show.allAddCallBack(this);
                        editSetting.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Setting)
                {
                    needReset = true;
                    dirty = true;
                    return;
                }
            }
            // language, style
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
                            case UIData.Property.language:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, languageRect);
                                break;
                            case UIData.Property.style:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, styleRect);
                                break;
                            case UIData.Property.defaultChosenGameType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, defaultChosenGameTypeRect);
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
            // showLastMove, viewUrlImage
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.showLastMove:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, showLastMoveRect);
                                break;
                            case UIData.Property.viewUrlImage:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, viewUrlImageRect);
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
            // animationSettingUIData
            if (data is AnimationSettingUI.UIData)
            {
                AnimationSettingUI.UIData animationSettingUIData = data as AnimationSettingUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(animationSettingUIData, animationSettingPrefab, this.transform);
                }
                // Child
                {
                    TransformData.AddCallBack(animationSettingUIData, this);
                }
                dirty = true;
                return;
            }
            // maxThinkCount
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.maxThinkCount:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, maxThinkCountRect);
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
            // defaultChosenGameUIData
            if (data is DefaultChosenGame.UIData)
            {
                DefaultChosenGame.UIData defaultChosenGameUIData = data as DefaultChosenGame.UIData;
                // UI
                {
                    switch (defaultChosenGameUIData.getType())
                    {
                        case DefaultChosenGame.Type.Last:
                            {
                                DefaultChosenGameLastUI.UIData defaultChosenGameLastUIData = defaultChosenGameUIData as DefaultChosenGameLastUI.UIData;
                                UIUtils.Instantiate(defaultChosenGameLastUIData, defaultChosenGameLastPrefab, this.transform);
                            }
                            break;
                        case DefaultChosenGame.Type.Always:
                            {
                                DefaultChosenGameAlwaysUI.UIData defaultChosenGameAlwaysUIData = defaultChosenGameUIData as DefaultChosenGameAlwaysUI.UIData;
                                UIUtils.Instantiate(defaultChosenGameAlwaysUIData, defaultChosenGameAlwaysPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + defaultChosenGameUIData.getType());
                            break;
                    }
                }
                // Child
                {
                    TransformData.AddCallBack(defaultChosenGameUIData, this);
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
            {
                Setting.get().removeCallBack(this);
            }
            // Child
            {
                uiData.editSetting.allRemoveCallBack(this);
                uiData.language.allRemoveCallBack(this);
                uiData.style.allRemoveCallBack(this);
                uiData.showLastMove.allRemoveCallBack(this);
                uiData.viewUrlImage.allRemoveCallBack(this);
                uiData.animationSetting.allRemoveCallBack(this);
                uiData.maxThinkCount.allRemoveCallBack(this);
                uiData.defaultChosenGameType.allRemoveCallBack(this);
                uiData.defaultChosenGameUIData.allRemoveCallBack(this);
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
            // editSetting
            {
                if (data is EditData<Setting>)
                {
                    EditData<Setting> editSetting = data as EditData<Setting>;
                    // Child
                    {
                        editSetting.show.allRemoveCallBack(this);
                        editSetting.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Setting)
                {
                    return;
                }
            }
            // language, style
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            // showLastMove, viewUrlImage
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                }
                return;
            }
            // animationSettingUIData
            if (data is AnimationSettingUI.UIData)
            {
                AnimationSettingUI.UIData animationSettingUIData = data as AnimationSettingUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(animationSettingUIData, this);
                }
                // UI
                {
                    animationSettingUIData.removeCallBackAndDestroy(typeof(AnimationSettingUI));
                }
                return;
            }
            // maxThinkCount
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                }
                return;
            }
            // defaultChosenGameUIData
            if (data is DefaultChosenGame.UIData)
            {
                DefaultChosenGame.UIData defaultChosenGameUIData = data as DefaultChosenGame.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(defaultChosenGameUIData, this);
                }
                // UI
                {
                    switch (defaultChosenGameUIData.getType())
                    {
                        case DefaultChosenGame.Type.Last:
                            {
                                DefaultChosenGameLastUI.UIData defaultChosenGameLastUIData = defaultChosenGameUIData as DefaultChosenGameLastUI.UIData;
                                defaultChosenGameLastUIData.removeCallBackAndDestroy(typeof(DefaultChosenGameLastUI));
                            }
                            break;
                        case DefaultChosenGame.Type.Always:
                            {
                                DefaultChosenGameAlwaysUI.UIData defaultChosenGameAlwaysUIData = defaultChosenGameUIData as DefaultChosenGameAlwaysUI.UIData;
                                defaultChosenGameAlwaysUIData.removeCallBackAndDestroy(typeof(DefaultChosenGameAlwaysUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + defaultChosenGameUIData.getType());
                            break;
                    }
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
                case UIData.Property.editSetting:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showType:
                    dirty = true;
                    break;
                case UIData.Property.language:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.style:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showLastMove:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.viewUrlImage:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.animationSetting:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.maxThinkCount:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.defaultChosenGameType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.defaultChosenGameUIData:
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
        // Child
        {
            // editSetting
            {
                if (wrapProperty.p is EditData<Setting>)
                {
                    switch ((EditData<Setting>.Property)wrapProperty.n)
                    {
                        case EditData<Setting>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<Setting>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Setting>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Setting>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<Setting>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<Setting>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Setting)
                {
                    switch ((Setting.Property)wrapProperty.n)
                    {
                        case Setting.Property.language:
                            dirty = true;
                            break;
                        case Setting.Property.style:
                            dirty = true;
                            break;
                        case Setting.Property.showLastMove:
                            dirty = true;
                            break;
                        case Setting.Property.viewUrlImage:
                            dirty = true;
                            break;
                        case Setting.Property.animationSetting:
                            dirty = true;
                            break;
                        case Setting.Property.maxThinkCount:
                            dirty = true;
                            break;
                        case Setting.Property.defaultChosenGame:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // language, style
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            // showLastMove, viewUrlImage
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
            // animationSettingUIData
            if (wrapProperty.p is AnimationSettingUI.UIData)
            {
                return;
            }
            // maxThinkCount
            if (wrapProperty.p is RequestChangeIntUI.UIData)
            {
                return;
            }
            // defaultChosenGameUIData
            if (wrapProperty.p is DefaultChosenGame.UIData)
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