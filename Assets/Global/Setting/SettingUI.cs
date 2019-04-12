using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SettingUI : UIHaveTransformDataBehavior<SettingUI.UIData>
{

    #region UIData

    public class UIData : Data, EditDataUI.UIData<Setting>
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

        #region confirmQuit

        public VP<RequestChangeBoolUI.UIData> confirmQuit;

        public void makeRequestChangeConfirmQuit(RequestChangeUpdate<bool>.UpdateData update, bool newConfirmQuit)
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
                setting.confirmQuit.v = newConfirmQuit;
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

        #region defaultChosenGame

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

        #region defaultRoomName

        public VP<RequestChangeEnumUI.UIData> defaultRoomNameType;

        public void makeRequestChangeDefaultRoomNameType(RequestChangeUpdate<int>.UpdateData update, int newDefaultRoomNameType)
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
                DefaultRoomName.Type defaultRoomNameType = (DefaultRoomName.Type)newDefaultRoomNameType;
                setting.changeDefaultRoomNameType(defaultRoomNameType);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        public VP<DefaultRoomName.UIData> defaultRoomNameUIData;

        #endregion

        #region defaultChatRoomStyle

        public VP<RequestChangeEnumUI.UIData> defaultChatRoomStyleType;

        public void makeRequestChangeDefaultChatRoomStyleType(RequestChangeUpdate<int>.UpdateData update, int newDefaultChatRoomStyleType)
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
                DefaultChatRoomStyle.Type defaultChatRoomStyleType = (DefaultChatRoomStyle.Type)newDefaultChatRoomStyleType;
                setting.changeDefaultChatRoomStyle(defaultChatRoomStyleType);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        public VP<DefaultChatRoomStyle.UIData> defaultChatRoomStyleUIData;

        #endregion

        ///////////////////////////////////////////////////////
        /////////////////// TextSize //////////////////
        ///////////////////////////////////////////////////////

        #region contentTextSize

        public VP<RequestChangeIntUI.UIData> contentTextSize;

        public void makeRequestChangeContentTextSize(RequestChangeUpdate<int>.UpdateData update, int newContentTextSize)
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
                setting.contentTextSize.v = Mathf.Clamp(newContentTextSize, Setting.MinContentTextSize, Setting.MaxContentTextSize);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region titleTextSize

        public VP<RequestChangeIntUI.UIData> titleTextSize;

        public void makeRequestChangeTitleTextSize(RequestChangeUpdate<int>.UpdateData update, int newTitleTextSize)
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
                setting.titleTextSize.v = Mathf.Clamp(newTitleTextSize, Setting.MinTitleTextSize, Setting.MaxTitleTextSize);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region labelTextSize

        public VP<RequestChangeIntUI.UIData> labelTextSize;

        public void makeRequestChangeLabelTextSize(RequestChangeUpdate<int>.UpdateData update, int newLabelTextSize)
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
                setting.labelTextSize.v = Mathf.Clamp(newLabelTextSize, Setting.MinLabelTextSize, Setting.MaxLabelTextSize);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region buttonSize

        public VP<RequestChangeFloatUI.UIData> buttonSize;

        public void makeRequestChangeButtonSize(RequestChangeUpdate<float>.UpdateData update, float newButtonSize)
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
                setting.buttonSize.v = Mathf.Clamp(newButtonSize, Setting.MinButtonSize, Setting.MaxButtonSize);
            }
            else
            {
                Debug.LogError("setting null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editSetting,
            showType,
            language,
            style,
            confirmQuit,
            showLastMove,
            viewUrlImage,
            animationSetting,
            maxThinkCount,

            defaultChosenGameType,
            defaultChosenGameUIData,

            defaultRoomNameType,
            defaultRoomNameUIData,

            defaultChatRoomStyleType,
            defaultChatRoomStyleUIData,

            contentTextSize,
            titleTextSize,
            labelTextSize,
            buttonSize
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
            // confirmQuit
            {
                this.confirmQuit = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.confirmQuit, new RequestChangeBoolUI.UIData());
                this.confirmQuit.v.updateData.v.request.v = makeRequestChangeConfirmQuit;
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
                // type
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
            // defaultRoomNameType
            {
                // type
                {
                    this.defaultRoomNameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.defaultRoomNameType, new RequestChangeEnumUI.UIData());
                    // event
                    this.defaultRoomNameType.v.updateData.v.request.v = makeRequestChangeDefaultRoomNameType;
                    {
                        foreach (DefaultRoomName.Type type in System.Enum.GetValues(typeof(DefaultRoomName.Type)))
                        {
                            this.defaultRoomNameType.v.options.add(type.ToString());
                        }
                    }
                }
                this.defaultRoomNameUIData = new VP<DefaultRoomName.UIData>(this, (byte)Property.defaultRoomNameUIData, null);
            }
            // defaultChatRoomStyle
            {
                // type
                {
                    this.defaultChatRoomStyleType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.defaultChatRoomStyleType, new RequestChangeEnumUI.UIData());
                    // event
                    this.defaultChatRoomStyleType.v.updateData.v.request.v = makeRequestChangeDefaultChatRoomStyleType;
                    {
                        foreach (DefaultChatRoomStyle.Type type in System.Enum.GetValues(typeof(DefaultChatRoomStyle.Type)))
                        {
                            this.defaultChatRoomStyleType.v.options.add(type.ToString());
                        }
                    }
                }
                this.defaultChatRoomStyleUIData = new VP<DefaultChatRoomStyle.UIData>(this, (byte)Property.defaultChatRoomStyleUIData, null);
            }
            // textSize
            {
                // contentTextSize
                {
                    this.contentTextSize = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.contentTextSize, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.contentTextSize.v.limit.makeId();
                            have.min.v = Setting.MinContentTextSize;
                            have.max.v = Setting.MaxContentTextSize;
                        }
                        this.contentTextSize.v.limit.v = have;
                    }
                    this.contentTextSize.v.updateData.v.request.v = makeRequestChangeContentTextSize;
                }
                // titleTextSize
                {
                    this.titleTextSize = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.titleTextSize, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.titleTextSize.v.limit.makeId();
                            have.min.v = Setting.MinTitleTextSize;
                            have.max.v = Setting.MaxTitleTextSize;
                        }
                        this.titleTextSize.v.limit.v = have;
                    }
                    this.titleTextSize.v.updateData.v.request.v = makeRequestChangeTitleTextSize;
                }
                // labelTextSize
                {
                    this.labelTextSize = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.labelTextSize, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.labelTextSize.v.limit.makeId();
                            have.min.v = Setting.MinLabelTextSize;
                            have.max.v = Setting.MaxLabelTextSize;
                        }
                        this.labelTextSize.v.limit.v = have;
                    }
                    this.labelTextSize.v.updateData.v.request.v = makeRequestChangeLabelTextSize;
                }
                // buttonSize
                {
                    this.buttonSize = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.buttonSize, new RequestChangeFloatUI.UIData());
                    // have limit
                    {
                        FloatLimit.Have have = new FloatLimit.Have();
                        {
                            have.uid = this.buttonSize.v.limit.makeId();
                            have.min.v = Setting.MinButtonSize;
                            have.max.v = Setting.MaxButtonSize;
                        }
                        this.buttonSize.v.limit.v = have;
                    }
                    this.buttonSize.v.updateData.v.request.v = makeRequestChangeButtonSize;
                }
            }
        }

        #endregion

        #region implement base

        public EditData<Setting> getEditData()
        {
            return this.editSetting.v;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Setting");

    public Text lbLanguage;
    private static readonly TxtLanguage txtLanguage = new TxtLanguage("Language");

    public Text lbStyle;
    private static readonly TxtLanguage txtStyle = new TxtLanguage("Style");

    public Text lbConfirmQuit;
    private static readonly TxtLanguage txtConfirmQuit = new TxtLanguage("Confirm quit");

    public Text lbShowLastMove;
    private static readonly TxtLanguage txtShowLastMove = new TxtLanguage("Show last move");

    public Text lbViewUrlImage;
    private static readonly TxtLanguage txtViewUrlImage = new TxtLanguage("View url image");

    public Text lbMaxThinkCount;
    private static readonly TxtLanguage txtMaxThinkCount = new TxtLanguage("Max think count");

    public Text lbDefaultChosenGameType;
    private static readonly TxtLanguage txtDefaultChosenGameType = new TxtLanguage("Default game");
    private static readonly TxtLanguage txtDefaultChosenGameLast = new TxtLanguage("Last Chosen");
    private static readonly TxtLanguage txtDefaultChosenGameAlways = new TxtLanguage("Always Choose");

    public Text lbDefaultRoomNameType;
    private static readonly TxtLanguage txtDefaultRoomNameType = new TxtLanguage("Default room name");
    private static readonly TxtLanguage txtDefaultRoomNameLast = new TxtLanguage("Last Chosen");
    private static readonly TxtLanguage txtDefaultRoomNameAlways = new TxtLanguage("Always Choose");

    public Text lbDefaultChatRoomStyleType;
    private static readonly TxtLanguage txtDefaultChatRoomStyleType = new TxtLanguage("Default chat room");
    private static readonly TxtLanguage txtDefaultChatRoomStyleLast = new TxtLanguage("Last Chosen");
    private static readonly TxtLanguage txtDefaultChatRoomStyleAlways = new TxtLanguage("Always Choose");

    public Text lbTextSizeTitle;
    private static readonly TxtLanguage txtTextSizeTitle = new TxtLanguage("Text Size");

    public Text lbContentTextSize;
    private static readonly TxtLanguage txtContentTextSize = new TxtLanguage("Content text size");

    public Text lbTitleTextSize;
    private static readonly TxtLanguage txtTitleTextSize = new TxtLanguage("Title text size");

    public Text lbLabelTextSize;
    private static readonly TxtLanguage txtLabelTextSize = new TxtLanguage("Label text size");

    public Text lbButtonSize;
    private static readonly TxtLanguage txtButtonSize = new TxtLanguage("Button size");

    static SettingUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thiết Lập");
            txtLanguage.add(Language.Type.vi, "Ngôn Ngữ");
            txtStyle.add(Language.Type.vi, "Kiểu");
            txtConfirmQuit.add(Language.Type.vi, "Xác nhận thoát");
            txtShowLastMove.add(Language.Type.vi, "Hiện nước đi ");
            txtViewUrlImage.add(Language.Type.vi, "Xem ảnh url");
            txtMaxThinkCount.add(Language.Type.vi, "Số luồng nghĩ tối đa");

            txtDefaultChosenGameType.add(Language.Type.vi, "Game mặc định");
            txtDefaultChosenGameLast.add(Language.Type.vi, "Chọn Trước");
            txtDefaultChosenGameAlways.add(Language.Type.vi, "Luôn Chọn");

            txtDefaultRoomNameType.add(Language.Type.vi, "Tên phòng mặc định");
            txtDefaultRoomNameLast.add(Language.Type.vi, "Chọn Trước");
            txtDefaultRoomNameAlways.add(Language.Type.vi, "Luôn Chọn");

            txtDefaultChatRoomStyleType.add(Language.Type.vi, "Phòng Chat mặc định");
            txtDefaultChatRoomStyleLast.add(Language.Type.vi, "Chọn Trước");
            txtDefaultChatRoomStyleAlways.add(Language.Type.vi, "Luôn Chọn");

            // txt
            {
                txtTextSizeTitle.add(Language.Type.vi, "Kích Thước Chữ");
                txtContentTextSize.add(Language.Type.vi, "Kích thước chữ nội dung");
                txtTitleTextSize.add(Language.Type.vi, "Kích thước chữ tiêu đề");
                txtLabelTextSize.add(Language.Type.vi, "Kích thước chữ nhãn");
                txtButtonSize.add(Language.Type.vi, "Kích thước nút");
            }
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
    public Image bgDefaultRoomName;
    public Image bgDefaultChatRoomStyle;
    public Image bgTextSize;

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
                    // different
                    RequestChange.ShowDifferentTitle(lbTitle, editSetting);
                    // get server state
                    Server.State.Type serverState = Server.State.Type.Connect;
                    // request
                    {
                        RequestChange.RefreshUI(this.data.language.v, editSetting, serverState, needReset, editData => Language.GetSupportIndex(editData.language.v));
                        RequestChange.RefreshUI(this.data.style.v, editSetting, serverState, needReset, editData => (int)editData.style.v);
                        RequestChange.RefreshUI(this.data.confirmQuit.v, editSetting, serverState, needReset, editData => editData.confirmQuit.v);
                        RequestChange.RefreshUI(this.data.showLastMove.v, editSetting, serverState, needReset, editData => editData.showLastMove.v);
                        RequestChange.RefreshUI(this.data.viewUrlImage.v, editSetting, serverState, needReset, editData => editData.viewUrlImage.v);
                        EditDataUI.RefreshChildUI(this.data, this.data.animationSetting.v, editData => editData.animationSetting.v);
                        RequestChange.RefreshUI(this.data.maxThinkCount.v, editSetting, serverState, needReset, setting => setting.maxThinkCount.v);

                        // defaultChosenGameType
                        {
                            // options
                            {
                                List<string> options = new List<string>();
                                {
                                    options.Add(txtDefaultChosenGameLast.get());
                                    options.Add(txtDefaultChosenGameAlways.get());
                                }
                                RequestChangeEnumUI.RefreshOptions(this.data.defaultChosenGameType.v, options);
                            }
                            RequestChange.RefreshUI(this.data.defaultChosenGameType.v, editSetting, serverState, needReset, editData => (int)editData.defaultChosenGame.v.getType());
                        }
                        // defaultChosenGame
                        {
                            Setting show = editSetting.show.v.data;
                            Setting compare = editSetting.compare.v.data;
                            if (show != null)
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
                                                        Debug.LogError("editDefaultChosenGameLast null: " + this);
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
                            }
                            else
                            {
                                Debug.LogError("show null");
                            }
                        }

                        // defaultRoomNameType
                        {
                            // options
                            {
                                List<string> options = new List<string>();
                                {
                                    options.Add(txtDefaultRoomNameLast.get());
                                    options.Add(txtDefaultRoomNameAlways.get());
                                }
                                RequestChangeEnumUI.RefreshOptions(this.data.defaultRoomNameType.v, options);
                            }
                            RequestChange.RefreshUI(this.data.defaultRoomNameType.v, editSetting, serverState, needReset, editData => (int)editData.defaultRoomName.v.getType());
                        }
                        // defaultRoomName
                        {
                            Setting show = editSetting.show.v.data;
                            Setting compare = editSetting.compare.v.data;
                            if (show != null)
                            {
                                DefaultRoomName defaultRoomName = show.defaultRoomName.v;
                                if (defaultRoomName != null)
                                {
                                    // find origin 
                                    DefaultRoomName originDefaultRoomName = null;
                                    {
                                        Setting originSetting = editSetting.origin.v.data;
                                        if (originSetting != null)
                                        {
                                            originDefaultRoomName = originSetting.defaultRoomName.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("origin null: " + this);
                                        }
                                    }
                                    // find compare
                                    DefaultRoomName compareDefaultRoomName = null;
                                    {
                                        if (compare != null)
                                        {
                                            compareDefaultRoomName = compare.defaultRoomName.v;
                                        }
                                        else
                                        {
                                            // Debug.LogError ("compare null: " + this);
                                        }
                                    }
                                    switch (defaultRoomName.getType())
                                    {
                                        case DefaultRoomName.Type.Last:
                                            {
                                                DefaultRoomNameLast defaultRoomNameLast = defaultRoomName as DefaultRoomNameLast;
                                                // UIData
                                                DefaultRoomNameLastUI.UIData defaultRoomNameLastUIData = this.data.defaultRoomNameUIData.newOrOld<DefaultRoomNameLastUI.UIData>();
                                                {
                                                    EditData<DefaultRoomNameLast> editDefaultRoomNameLast = defaultRoomNameLastUIData.editDefaultRoomNameLast.v;
                                                    if (editDefaultRoomNameLast != null)
                                                    {
                                                        // origin
                                                        editDefaultRoomNameLast.origin.v = new ReferenceData<DefaultRoomNameLast>((DefaultRoomNameLast)originDefaultRoomName);
                                                        // show
                                                        editDefaultRoomNameLast.show.v = new ReferenceData<DefaultRoomNameLast>(defaultRoomNameLast);
                                                        // compare
                                                        editDefaultRoomNameLast.compare.v = new ReferenceData<DefaultRoomNameLast>((DefaultRoomNameLast)compareDefaultRoomName);
                                                        // compareOtherType
                                                        editDefaultRoomNameLast.compareOtherType.v = new ReferenceData<Data>(compareDefaultRoomName);
                                                        // canEdit
                                                        editDefaultRoomNameLast.canEdit.v = editSetting.canEdit.v;
                                                        // editType
                                                        editDefaultRoomNameLast.editType.v = editSetting.editType.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("editDefaultRoomNameLast null: " + this);
                                                    }
                                                    defaultRoomNameLastUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                }
                                                this.data.defaultRoomNameUIData.v = defaultRoomNameLastUIData;
                                            }
                                            break;
                                        case DefaultRoomName.Type.Always:
                                            {
                                                DefaultRoomNameAlways defaultRoomNameAlways = defaultRoomName as DefaultRoomNameAlways;
                                                // UIData
                                                DefaultRoomNameAlwaysUI.UIData defaultRoomNameAlwaysUIData = this.data.defaultRoomNameUIData.newOrOld<DefaultRoomNameAlwaysUI.UIData>();
                                                {
                                                    EditData<DefaultRoomNameAlways> editDefaultRoomNameAlways = defaultRoomNameAlwaysUIData.editDefaultRoomNameAlways.v;
                                                    if (editDefaultRoomNameAlways != null)
                                                    {
                                                        // origin
                                                        editDefaultRoomNameAlways.origin.v = new ReferenceData<DefaultRoomNameAlways>((DefaultRoomNameAlways)originDefaultRoomName);
                                                        // show
                                                        editDefaultRoomNameAlways.show.v = new ReferenceData<DefaultRoomNameAlways>(defaultRoomNameAlways);
                                                        // compare
                                                        editDefaultRoomNameAlways.compare.v = new ReferenceData<DefaultRoomNameAlways>((DefaultRoomNameAlways)compareDefaultRoomName);
                                                        // compareOtherType
                                                        editDefaultRoomNameAlways.compareOtherType.v = new ReferenceData<Data>(compareDefaultRoomName);
                                                        // canEdit
                                                        editDefaultRoomNameAlways.canEdit.v = editSetting.canEdit.v;
                                                        // editType
                                                        editDefaultRoomNameAlways.editType.v = editSetting.editType.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("editDefaultRoomNameAlways null: " + this);
                                                    }
                                                    defaultRoomNameAlwaysUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                }
                                                this.data.defaultRoomNameUIData.v = defaultRoomNameAlwaysUIData;
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + defaultRoomName.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("show null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("show null");
                            }
                        }

                        // defaultChatRoomStyleType
                        {
                            // options
                            {
                                List<string> options = new List<string>();
                                {
                                    options.Add(txtDefaultChatRoomStyleLast.get());
                                    options.Add(txtDefaultChatRoomStyleAlways.get());
                                }
                                RequestChangeEnumUI.RefreshOptions(this.data.defaultChatRoomStyleType.v, options);
                            }
                            RequestChange.RefreshUI(this.data.defaultChatRoomStyleType.v, editSetting, serverState, needReset, editData => (int)editData.defaultChatRoomStyle.v.getType());
                        }
                        // defaultChatRoomStyle
                        {
                            Setting show = editSetting.show.v.data;
                            Setting compare = editSetting.compare.v.data;
                            if (show != null)
                            {
                                DefaultChatRoomStyle defaultChatRoomStyle = show.defaultChatRoomStyle.v;
                                if (defaultChatRoomStyle != null)
                                {
                                    // find origin 
                                    DefaultChatRoomStyle originDefaultChatRoomStyle = null;
                                    {
                                        Setting originSetting = editSetting.origin.v.data;
                                        if (originSetting != null)
                                        {
                                            originDefaultChatRoomStyle = originSetting.defaultChatRoomStyle.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("origin null: " + this);
                                        }
                                    }
                                    // find compare
                                    DefaultChatRoomStyle compareDefaultChatRoomStyle = null;
                                    {
                                        if (compare != null)
                                        {
                                            compareDefaultChatRoomStyle = compare.defaultChatRoomStyle.v;
                                        }
                                        else
                                        {
                                            // Debug.LogError ("compare null: " + this);
                                        }
                                    }
                                    switch (defaultChatRoomStyle.getType())
                                    {
                                        case DefaultChatRoomStyle.Type.Last:
                                            {
                                                DefaultChatRoomStyleLast defaultChatRoomStyleLast = defaultChatRoomStyle as DefaultChatRoomStyleLast;
                                                // UIData
                                                DefaultChatRoomStyleLastUI.UIData defaultChatRoomStyleLastUIData = this.data.defaultChatRoomStyleUIData.newOrOld<DefaultChatRoomStyleLastUI.UIData>();
                                                {
                                                    EditData<DefaultChatRoomStyleLast> editDefaultChatRoomStyleLast = defaultChatRoomStyleLastUIData.editDefaultChatRoomStyleLast.v;
                                                    if (editDefaultChatRoomStyleLast != null)
                                                    {
                                                        // origin
                                                        editDefaultChatRoomStyleLast.origin.v = new ReferenceData<DefaultChatRoomStyleLast>((DefaultChatRoomStyleLast)originDefaultChatRoomStyle);
                                                        // show
                                                        editDefaultChatRoomStyleLast.show.v = new ReferenceData<DefaultChatRoomStyleLast>(defaultChatRoomStyleLast);
                                                        // compare
                                                        editDefaultChatRoomStyleLast.compare.v = new ReferenceData<DefaultChatRoomStyleLast>((DefaultChatRoomStyleLast)compareDefaultChatRoomStyle);
                                                        // compareOtherType
                                                        editDefaultChatRoomStyleLast.compareOtherType.v = new ReferenceData<Data>(compareDefaultChatRoomStyle);
                                                        // canEdit
                                                        editDefaultChatRoomStyleLast.canEdit.v = editSetting.canEdit.v;
                                                        // editType
                                                        editDefaultChatRoomStyleLast.editType.v = editSetting.editType.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("editDefaultChatRoomStyleLast null: " + this);
                                                    }
                                                    defaultChatRoomStyleLastUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                }
                                                this.data.defaultChatRoomStyleUIData.v = defaultChatRoomStyleLastUIData;
                                            }
                                            break;
                                        case DefaultChatRoomStyle.Type.Always:
                                            {
                                                DefaultChatRoomStyleAlways defaultChatRoomStyleAlways = defaultChatRoomStyle as DefaultChatRoomStyleAlways;
                                                // UIData
                                                DefaultChatRoomStyleAlwaysUI.UIData defaultChatRoomStyleAlwaysUIData = this.data.defaultChatRoomStyleUIData.newOrOld<DefaultChatRoomStyleAlwaysUI.UIData>();
                                                {
                                                    EditData<DefaultChatRoomStyleAlways> editDefaultChatRoomStyleAlways = defaultChatRoomStyleAlwaysUIData.editDefaultChatRoomStyleAlways.v;
                                                    if (editDefaultChatRoomStyleAlways != null)
                                                    {
                                                        // origin
                                                        editDefaultChatRoomStyleAlways.origin.v = new ReferenceData<DefaultChatRoomStyleAlways>((DefaultChatRoomStyleAlways)originDefaultChatRoomStyle);
                                                        // show
                                                        editDefaultChatRoomStyleAlways.show.v = new ReferenceData<DefaultChatRoomStyleAlways>(defaultChatRoomStyleAlways);
                                                        // compare
                                                        editDefaultChatRoomStyleAlways.compare.v = new ReferenceData<DefaultChatRoomStyleAlways>((DefaultChatRoomStyleAlways)compareDefaultChatRoomStyle);
                                                        // compareOtherType
                                                        editDefaultChatRoomStyleAlways.compareOtherType.v = new ReferenceData<Data>(compareDefaultChatRoomStyle);
                                                        // canEdit
                                                        editDefaultChatRoomStyleAlways.canEdit.v = editSetting.canEdit.v;
                                                        // editType
                                                        editDefaultChatRoomStyleAlways.editType.v = editSetting.editType.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("editDefaultChatRoomStyleAlways null: " + this);
                                                    }
                                                    defaultChatRoomStyleAlwaysUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                }
                                                this.data.defaultChatRoomStyleUIData.v = defaultChatRoomStyleAlwaysUIData;
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + defaultChatRoomStyle.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("show null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("show null");
                            }
                        }

                        // textSize
                        {
                            RequestChange.RefreshUI(this.data.contentTextSize.v, editSetting, serverState, needReset, editData => editData.contentTextSize.v);
                            RequestChange.RefreshUI(this.data.titleTextSize.v, editSetting, serverState, needReset, editData => editData.titleTextSize.v);
                            RequestChange.RefreshUI(this.data.labelTextSize.v, editSetting, serverState, needReset, editData => editData.labelTextSize.v);
                            RequestChange.RefreshUI(this.data.buttonSize.v, editSetting, serverState, needReset, editData => editData.buttonSize.v);
                        }
                    }
                    needReset = false;
                }
                else
                {
                    Debug.LogError("editSetting null: " + this);
                }
                // UISize
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                    // language
                    UIUtils.SetLabelContentPosition(lbLanguage, this.data.language.v, ref deltaY);
                    // style
                    UIUtils.SetLabelContentPosition(lbStyle, this.data.style.v, ref deltaY);
                    // confirmQuit
                    UIUtils.SetLabelContentPosition(lbConfirmQuit, this.data.confirmQuit.v, ref deltaY);
                    // showLastMove
                    UIUtils.SetLabelContentPosition(lbShowLastMove, this.data.showLastMove.v, ref deltaY);
                    // viewUrlImage
                    UIUtils.SetLabelContentPosition(lbViewUrlImage, this.data.viewUrlImage.v, ref deltaY);
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
                    UIUtils.SetLabelContentPosition(lbMaxThinkCount, this.data.maxThinkCount.v, ref deltaY);
                    // defaultChosenGame
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // type
                        UIUtils.SetLabelContentPositionBg(lbDefaultChosenGameType, this.data.defaultChosenGameType.v, ref deltaY, ref bgHeight);
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
                    // defaultRoomName
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // type
                        UIUtils.SetLabelContentPositionBg(lbDefaultRoomNameType, this.data.defaultRoomNameType.v, ref deltaY, ref bgHeight);
                        // UI
                        {
                            float height = UIRectTransform.SetPosY(this.data.defaultRoomNameUIData.v, deltaY);
                            bgHeight += height;
                            deltaY += height;
                        }
                        // bg
                        if (bgDefaultRoomName != null)
                        {
                            UIRectTransform.SetPosY(bgDefaultRoomName.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgDefaultRoomName.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgDefaultRoomName null");
                        }
                    }
                    // defaultChatRoomStyle
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // type
                        UIUtils.SetLabelContentPositionBg(lbDefaultChatRoomStyleType, this.data.defaultChatRoomStyleType.v, ref deltaY, ref bgHeight);
                        // UI
                        {
                            float height = UIRectTransform.SetPosY(this.data.defaultChatRoomStyleUIData.v, deltaY);
                            bgHeight += height;
                            deltaY += height;
                        }
                        // bg
                        if (bgDefaultChatRoomStyle != null)
                        {
                            UIRectTransform.SetPosY(bgDefaultChatRoomStyle.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgDefaultChatRoomStyle.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgDefaultChatRoomStyle null");
                        }
                    }
                    // textSize
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // title
                        {
                            if (lbTextSizeTitle != null)
                            {
                                UIRectTransform.SetPosY(lbTextSizeTitle.rectTransform, deltaY);
                                bgHeight += UIConstants.HeaderHeight;
                                deltaY += UIConstants.HeaderHeight;
                            }
                            else
                            {
                                Debug.LogError("lbTextSizeTitle null");
                            }
                        }
                        // contentTextSize
                        UIUtils.SetLabelContentPositionBg(lbContentTextSize, this.data.contentTextSize.v, ref deltaY, ref bgHeight);
                        // titleTextSize
                        UIUtils.SetLabelContentPositionBg(lbTitleTextSize, this.data.titleTextSize.v, ref deltaY, ref bgHeight);
                        // labelTextSize
                        UIUtils.SetLabelContentPositionBg(lbLabelTextSize, this.data.labelTextSize.v, ref deltaY, ref bgHeight);
                        // buttonSize
                        UIUtils.SetLabelContentPositionBg(lbButtonSize, this.data.buttonSize.v, ref deltaY, ref bgHeight);
                        // bg
                        if (bgTextSize != null)
                        {
                            UIRectTransform.SetPosY(bgTextSize.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgTextSize.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgTextSize null");
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
                        Debug.LogError("lbSetting null: " + this);
                    }
                    if (lbLanguage != null)
                    {
                        lbLanguage.text = txtLanguage.get();
                        Setting.get().setLabelTextSize(lbLanguage);
                    }
                    else
                    {
                        Debug.LogError("tvLanguage null: " + this);
                    }
                    if (lbStyle != null)
                    {
                        lbStyle.text = txtStyle.get();
                        Setting.get().setLabelTextSize(lbStyle);
                    }
                    else
                    {
                        Debug.LogError("tvStyle null: " + this);
                    }
                    if (lbConfirmQuit != null)
                    {
                        lbConfirmQuit.text = txtConfirmQuit.get();
                        Setting.get().setLabelTextSize(lbConfirmQuit);
                    }
                    else
                    {
                        Debug.LogError("lbConfirmQuit null: " + this);
                    }
                    if (lbShowLastMove != null)
                    {
                        lbShowLastMove.text = txtShowLastMove.get();
                        Setting.get().setLabelTextSize(lbShowLastMove);
                    }
                    else
                    {
                        Debug.LogError("tvShowLastMove null: " + this);
                    }
                    if (lbViewUrlImage != null)
                    {
                        lbViewUrlImage.text = txtViewUrlImage.get();
                        Setting.get().setLabelTextSize(lbViewUrlImage);
                    }
                    else
                    {
                        Debug.LogError("tvViewUrlImage null: " + this);
                    }
                    if (lbMaxThinkCount != null)
                    {
                        lbMaxThinkCount.text = txtMaxThinkCount.get();
                        Setting.get().setLabelTextSize(lbMaxThinkCount);
                    }
                    else
                    {
                        Debug.LogError("tvMaxThinkCount null: " + this);
                    }
                    if (lbDefaultChosenGameType != null)
                    {
                        lbDefaultChosenGameType.text = txtDefaultChosenGameType.get();
                        Setting.get().setLabelTextSize(lbDefaultChosenGameType);
                    }
                    else
                    {
                        Debug.LogError("lbDefaultChosenGameType null");
                    }
                    if (lbDefaultRoomNameType != null)
                    {
                        lbDefaultRoomNameType.text = txtDefaultRoomNameType.get();
                        Setting.get().setLabelTextSize(lbDefaultRoomNameType);
                    }
                    else
                    {
                        Debug.LogError("lbDefaultRoomNameType null");
                    }
                    if (lbDefaultChatRoomStyleType != null)
                    {
                        lbDefaultChatRoomStyleType.text = txtDefaultChatRoomStyleType.get();
                        Setting.get().setLabelTextSize(lbDefaultChatRoomStyleType);
                    }
                    else
                    {
                        Debug.LogError("lbDefaultChatRoomStyleType null");
                    }
                    // txtSize
                    {
                        if (lbTextSizeTitle != null)
                        {
                            lbTextSizeTitle.text = txtTextSizeTitle.get();
                            Setting.get().setTitleTextSize(lbTextSizeTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTextSizeTitle null");
                        }
                        if (lbContentTextSize != null)
                        {
                            lbContentTextSize.text = txtContentTextSize.get();
                            Setting.get().setLabelTextSize(lbContentTextSize);
                        }
                        else
                        {
                            Debug.LogError("lbContentTextSize null");
                        }
                        if (lbTitleTextSize != null)
                        {
                            lbTitleTextSize.text = txtTitleTextSize.get();
                            Setting.get().setLabelTextSize(lbTitleTextSize);
                        }
                        else
                        {
                            Debug.LogError("lbTitleTextSize null");
                        }
                        if (lbLabelTextSize != null)
                        {
                            lbLabelTextSize.text = txtLabelTextSize.get();
                            Setting.get().setLabelTextSize(lbLabelTextSize);
                        }
                        else
                        {
                            Debug.LogError("lbLabelTextSize null");
                        }
                        if (lbButtonSize != null)
                        {
                            lbButtonSize.text = txtButtonSize.get();
                            Setting.get().setLabelTextSize(lbButtonSize);
                        }
                        else
                        {
                            Debug.LogError("lbButtonSize null");
                        }
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
    public RequestChangeFloatUI requestFloatPrefab;

    public DefaultChosenGameLastUI defaultChosenGameLastPrefab;
    public DefaultChosenGameAlwaysUI defaultChosenGameAlwaysPrefab;

    public DefaultRoomNameLastUI defaultRoomNameLastPrefab;
    public DefaultRoomNameAlwaysUI defaultRoomNameAlwaysPrefab;

    public DefaultChatRoomStyleLastUI defaultChatRoomStyleLastPrefab;
    public DefaultChatRoomStyleAlwaysUI defaultChatRoomStyleAlwaysPrefab;

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
                uiData.confirmQuit.allAddCallBack(this);
                uiData.showLastMove.allAddCallBack(this);
                uiData.viewUrlImage.allAddCallBack(this);
                uiData.animationSetting.allAddCallBack(this);
                uiData.maxThinkCount.allAddCallBack(this);
                // defaultChosenGame
                {
                    uiData.defaultChosenGameType.allAddCallBack(this);
                    uiData.defaultChosenGameUIData.allAddCallBack(this);
                }
                // defaultRoomName
                {
                    uiData.defaultRoomNameType.allAddCallBack(this);
                    uiData.defaultRoomNameUIData.allAddCallBack(this);
                }
                // defaultChatRoomStyle
                {
                    uiData.defaultChatRoomStyleType.allAddCallBack(this);
                    uiData.defaultChatRoomStyleUIData.allAddCallBack(this);
                }
                uiData.contentTextSize.allAddCallBack(this);
                uiData.titleTextSize.allAddCallBack(this);
                uiData.labelTextSize.allAddCallBack(this);
                uiData.buttonSize.allAddCallBack(this);
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
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.style:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.defaultChosenGameType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.defaultRoomNameType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.defaultChatRoomStyleType:
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
            // confirmQuit, showLastMove, viewUrlImage
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
                            case UIData.Property.confirmQuit:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                break;
                            case UIData.Property.showLastMove:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                break;
                            case UIData.Property.viewUrlImage:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
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
            // maxThinkCount, contentTextSize, titleTextSize, labelTextSize
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
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                break;
                            case UIData.Property.contentTextSize:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                break;
                            case UIData.Property.titleTextSize:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                break;
                            case UIData.Property.labelTextSize:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
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
            // buttonSize
            if (data is RequestChangeFloatUI.UIData)
            {
                RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.buttonSize:
                                UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform, UIConstants.RequestRect);
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
            // defaultRoomNameUIData
            if (data is DefaultRoomName.UIData)
            {
                DefaultRoomName.UIData defaultRoomNameUIData = data as DefaultRoomName.UIData;
                // UI
                {
                    switch (defaultRoomNameUIData.getType())
                    {
                        case DefaultRoomName.Type.Last:
                            {
                                DefaultRoomNameLastUI.UIData defaultRoomNameLastUIData = defaultRoomNameUIData as DefaultRoomNameLastUI.UIData;
                                UIUtils.Instantiate(defaultRoomNameLastUIData, defaultRoomNameLastPrefab, this.transform);
                            }
                            break;
                        case DefaultRoomName.Type.Always:
                            {
                                DefaultRoomNameAlwaysUI.UIData defaultRoomNameAlwaysUIData = defaultRoomNameUIData as DefaultRoomNameAlwaysUI.UIData;
                                UIUtils.Instantiate(defaultRoomNameAlwaysUIData, defaultRoomNameAlwaysPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + defaultRoomNameUIData.getType());
                            break;
                    }
                }
                // Child
                {
                    TransformData.AddCallBack(defaultRoomNameUIData, this);
                }
                dirty = true;
                return;
            }
            // defaultChatRoomStyleUIData
            if (data is DefaultChatRoomStyle.UIData)
            {
                DefaultChatRoomStyle.UIData defaultChatRoomStyleUIData = data as DefaultChatRoomStyle.UIData;
                // UI
                {
                    switch (defaultChatRoomStyleUIData.getType())
                    {
                        case DefaultChatRoomStyle.Type.Last:
                            {
                                DefaultChatRoomStyleLastUI.UIData defaultChatRoomStyleLastUIData = defaultChatRoomStyleUIData as DefaultChatRoomStyleLastUI.UIData;
                                UIUtils.Instantiate(defaultChatRoomStyleLastUIData, defaultChatRoomStyleLastPrefab, this.transform);
                            }
                            break;
                        case DefaultChatRoomStyle.Type.Always:
                            {
                                DefaultChatRoomStyleAlwaysUI.UIData defaultChatRoomStyleAlwaysUIData = defaultChatRoomStyleUIData as DefaultChatRoomStyleAlwaysUI.UIData;
                                UIUtils.Instantiate(defaultChatRoomStyleAlwaysUIData, defaultChatRoomStyleAlwaysPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + defaultChatRoomStyleUIData.getType());
                            break;
                    }
                }
                // Child
                {
                    TransformData.AddCallBack(defaultChatRoomStyleUIData, this);
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
                uiData.confirmQuit.allRemoveCallBack(this);
                uiData.showLastMove.allRemoveCallBack(this);
                uiData.viewUrlImage.allRemoveCallBack(this);
                uiData.animationSetting.allRemoveCallBack(this);
                uiData.maxThinkCount.allRemoveCallBack(this);
                // defaultChosenGame
                {
                    uiData.defaultChosenGameType.allRemoveCallBack(this);
                    uiData.defaultChosenGameUIData.allRemoveCallBack(this);
                }
                // defaultRoomName
                {
                    uiData.defaultRoomNameType.allRemoveCallBack(this);
                    uiData.defaultRoomNameUIData.allRemoveCallBack(this);
                }
                // defaultChatRoomStyle
                {
                    uiData.defaultChatRoomStyleType.allRemoveCallBack(this);
                    uiData.defaultChatRoomStyleUIData.allRemoveCallBack(this);
                }
                uiData.contentTextSize.allRemoveCallBack(this);
                uiData.titleTextSize.allRemoveCallBack(this);
                uiData.labelTextSize.allRemoveCallBack(this);
                uiData.buttonSize.allRemoveCallBack(this);
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
            // confirmQuit, showLastMove, viewUrlImage
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
            // maxThinkCount, contentTextSize, titleTextSize, labelTextSize
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                }
                return;
            }
            // buttonSize
            if (data is RequestChangeFloatUI.UIData)
            {
                RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
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
            // defaultRoomNameUIData
            if (data is DefaultRoomName.UIData)
            {
                DefaultRoomName.UIData defaultRoomNameUIData = data as DefaultRoomName.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(defaultRoomNameUIData, this);
                }
                // UI
                {
                    switch (defaultRoomNameUIData.getType())
                    {
                        case DefaultRoomName.Type.Last:
                            {
                                DefaultRoomNameLastUI.UIData defaultRoomNameLastUIData = defaultRoomNameUIData as DefaultRoomNameLastUI.UIData;
                                defaultRoomNameLastUIData.removeCallBackAndDestroy(typeof(DefaultRoomNameLastUI));
                            }
                            break;
                        case DefaultRoomName.Type.Always:
                            {
                                DefaultRoomNameAlwaysUI.UIData defaultRoomNameAlwaysUIData = defaultRoomNameUIData as DefaultRoomNameAlwaysUI.UIData;
                                defaultRoomNameAlwaysUIData.removeCallBackAndDestroy(typeof(DefaultRoomNameAlwaysUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + defaultRoomNameUIData.getType());
                            break;
                    }
                }
                return;
            }
            // defaultChatRoomStyleUIData
            if (data is DefaultChatRoomStyle.UIData)
            {
                DefaultChatRoomStyle.UIData defaultChatRoomStyleUIData = data as DefaultChatRoomStyle.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(defaultChatRoomStyleUIData, this);
                }
                // UI
                {
                    switch (defaultChatRoomStyleUIData.getType())
                    {
                        case DefaultChatRoomStyle.Type.Last:
                            {
                                DefaultChatRoomStyleLastUI.UIData defaultChatRoomStyleLastUIData = defaultChatRoomStyleUIData as DefaultChatRoomStyleLastUI.UIData;
                                defaultChatRoomStyleLastUIData.removeCallBackAndDestroy(typeof(DefaultChatRoomStyleLastUI));
                            }
                            break;
                        case DefaultChatRoomStyle.Type.Always:
                            {
                                DefaultChatRoomStyleAlwaysUI.UIData defaultChatRoomStyleAlwaysUIData = defaultChatRoomStyleUIData as DefaultChatRoomStyleAlwaysUI.UIData;
                                defaultChatRoomStyleAlwaysUIData.removeCallBackAndDestroy(typeof(DefaultChatRoomStyleAlwaysUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + defaultChatRoomStyleUIData.getType());
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
                case UIData.Property.confirmQuit:
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
                case UIData.Property.defaultRoomNameType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.defaultRoomNameUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.defaultChatRoomStyleType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.defaultChatRoomStyleUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.contentTextSize:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.titleTextSize:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.labelTextSize:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.buttonSize:
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
                        case Setting.Property.confirmQuit:
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
                        case Setting.Property.defaultRoomName:
                            dirty = true;
                            break;
                        case Setting.Property.defaultChatRoomStyle:
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
            // confirmQuit, showLastMove, viewUrlImage
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
            // animationSettingUIData
            if (wrapProperty.p is AnimationSettingUI.UIData)
            {
                return;
            }
            // maxThinkCount, contentTextSize, titleTextSize, labelTextSize
            if (wrapProperty.p is RequestChangeIntUI.UIData)
            {
                return;
            }
            // buttonSize
            if (wrapProperty.p is RequestChangeFloatUI.UIData)
            {
                return;
            }
            // defaultChosenGameUIData
            if (wrapProperty.p is DefaultChosenGame.UIData)
            {
                return;
            }
            // defaultRoomNameUIData
            if (wrapProperty.p is DefaultRoomName.UIData)
            {
                return;
            }
            // defaultChatRoomStyleUIData
            if (wrapProperty.p is DefaultChatRoomStyle.UIData)
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