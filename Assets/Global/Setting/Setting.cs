using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Setting : Data
{

	#region Get

	private static Setting instance;

	static Setting()
	{
		instance = new Setting ();
	}

	public static Setting get()
	{
		return instance;
	}

	#endregion

	#region Property

	public VP<Language.Type> language;

    #region style

    public enum Style
    {
        Normal,
        Western
    }

    public VP<Style> style;

    #endregion

    #region text size

    #region contentTextSize

    public const int DefaultContentTextSize = 14;
    public const int MaxContentTextSize = 25;
    public const int MinContentTextSize = 6;

    public VP<int> contentTextSize;

    public void setContentTextSize(Text content)
    {
        if (content != null)
        {
            content.fontSize = Mathf.Clamp(this.contentTextSize.v, MinContentTextSize, MaxContentTextSize);
        }
        else
        {
            Debug.LogError("content null");
        }
    }

    #endregion

    #region titleTextSize

    public const int DefaultTitleTextSize = 16;
    public const int MaxTitleTextSize = 28;
    public const int MinTitleTextSize = 6;

    public VP<int> titleTextSize;

    public void setTitleTextSize(Text title)
    {
        if (title != null)
        {
            title.fontSize = Mathf.Clamp(this.titleTextSize.v, MinTitleTextSize, MaxTitleTextSize);
        }
        else
        {
            Debug.LogError("title null");
        }
    }

    #endregion

    #region labelTextSize

    public const int DefaultLabelTextSize = 14;
    public const int MaxLabelTextSize = 25;
    public const int MinLabelTextSize = 6;

    public VP<int> labelTextSize;

    public void setLabelTextSize(Text label)
    {
        if (label != null)
        {
            label.fontSize = Mathf.Clamp(this.labelTextSize.v, MinLabelTextSize, MaxLabelTextSize);
        }
        else
        {
            Debug.LogError("label null");
        }
    }

    #endregion

    #region buttonSize

    public const float DefaultButtonSize = UIConstants.HeaderHeight;
    public const float MinButtonSize = 20;
    public const float MaxButtonSize = 60;

    public VP<float> buttonSize;

    public float getButtonSize()
    {
        return Mathf.Clamp(this.buttonSize.v, MinButtonSize, MaxButtonSize);
    }

    #endregion

    #endregion

    public VP<bool> confirmQuit;

    public VP<bool> showLastMove;

	public VP<bool> viewUrlImage;

	public VP<AnimationSetting> animationSetting;

    #endregion

#if UNITY_ANDROID

    public const int DefaultMaxThinkCount = 1;

#else

    public const int DefaultMaxThinkCount = 12;

#endif

    public VP<int> maxThinkCount;

    #region defaultChosenGame

    public VP<DefaultChosenGame> defaultChosenGame;

    public void changeDefaultChosenGameType(DefaultChosenGame.Type newType)
    {
        if (this.defaultChosenGame.v.getType() != newType)
        {
            GameType.Type oldGameType = this.defaultChosenGame.v.getGame();
            // make new
            switch (newType)
            {
                case DefaultChosenGame.Type.Last:
                    {
                        DefaultChosenGameLast defaultChosenGameLast = new DefaultChosenGameLast();
                        {
                            defaultChosenGameLast.uid = this.defaultChosenGame.makeId();
                            defaultChosenGameLast.gameType.v = oldGameType;
                        }
                        this.defaultChosenGame.v = defaultChosenGameLast;
                    }
                    break;
                case DefaultChosenGame.Type.Always:
                    {
                        DefaultChosenGameAlways defaultChosenGameAlways = new DefaultChosenGameAlways();
                        {
                            defaultChosenGameAlways.uid = this.defaultChosenGame.makeId();
                            defaultChosenGameAlways.gameType.v = oldGameType;
                        }
                        this.defaultChosenGame.v = defaultChosenGameAlways;
                    }
                    break;
                default:
                    Debug.LogError("unknown type: " + newType);
                    break;
            }
        }
        else
        {
            Debug.LogError("the same type: " + newType);
        }
    }

    #endregion

    #region defaultRoomName

    public VP<DefaultRoomName> defaultRoomName;

    public void changeDefaultRoomNameType(DefaultRoomName.Type newType)
    {
        if (this.defaultRoomName.v.getType() != newType)
        {
            string oldRoomName = this.defaultRoomName.v.getRoomName();
            // make new
            switch (newType)
            {
                case DefaultRoomName.Type.Last:
                    {
                        DefaultRoomNameLast defaultRoomNameLast = new DefaultRoomNameLast();
                        {
                            defaultRoomNameLast.uid = this.defaultRoomName.makeId();
                            defaultRoomNameLast.roomName.v = oldRoomName;
                        }
                        this.defaultRoomName.v = defaultRoomNameLast;
                    }
                    break;
                case DefaultRoomName.Type.Always:
                    {
                        DefaultRoomNameAlways defaultRoomNameAlways = new DefaultRoomNameAlways();
                        {
                            defaultRoomNameAlways.uid = this.defaultRoomName.makeId();
                            defaultRoomNameAlways.roomName.v = oldRoomName;
                        }
                        this.defaultRoomName.v = defaultRoomNameAlways;
                    }
                    break;
                default:
                    Debug.LogError("unknown type: " + newType);
                    break;
            }
        }
        else
        {
            Debug.LogError("the same type: " + newType);
        }
    }

    #endregion

    #region defaultChatRoomStyle

    public VP<DefaultChatRoomStyle> defaultChatRoomStyle;

    public void changeDefaultChatRoomStyle(DefaultChatRoomStyle.Type newType)
    {
        if (this.defaultChatRoomStyle.v.getType() != newType)
        {
            ContestManagerBtnChatUI.UIData.Visibility oldVisibility = this.defaultChatRoomStyle.v.getVisibility();
            ContestManagerBtnChatUI.UIData.Style oldStyle = this.defaultChatRoomStyle.v.getStyle();
            // make new
            switch (newType)
            {
                case DefaultChatRoomStyle.Type.Last:
                    {
                        DefaultChatRoomStyleLast defaultChatRoomStyleLast = new DefaultChatRoomStyleLast();
                        {
                            defaultChatRoomStyleLast.uid = this.defaultChatRoomStyle.makeId();
                            defaultChatRoomStyleLast.visibility.v = oldVisibility;
                            defaultChatRoomStyleLast.style.v = oldStyle;
                        }
                        this.defaultChatRoomStyle.v = defaultChatRoomStyleLast;
                    }
                    break;
                case DefaultChatRoomStyle.Type.Always:
                    {
                        DefaultChatRoomStyleAlways defaultChatRoomStyleAlways = new DefaultChatRoomStyleAlways();
                        {
                            defaultChatRoomStyleAlways.uid = this.defaultChatRoomStyle.makeId();
                            defaultChatRoomStyleAlways.visibility.v = oldVisibility;
                            defaultChatRoomStyleAlways.style.v = oldStyle;
                        }
                        this.defaultChatRoomStyle.v = defaultChatRoomStyleAlways;
                    }
                    break;
                default:
                    Debug.LogError("unknown type: " + newType);
                    break;
            }
        }
        else
        {
            Debug.LogError("the same type: " + newType);
        }
    }

    #endregion

    #region Constructor

    public enum Property
	{
		language,
        style,

        contentTextSize,
        titleTextSize,
        labelTextSize,
        buttonSize,

        confirmQuit,
        showLastMove,
		viewUrlImage,
		animationSetting,
		maxThinkCount,
        defaultChosenGame,
        defaultRoomName,
        defaultChatRoomStyle
    }

	public Setting() : base()
	{
		this.language = new VP<Language.Type> (this, (byte)Property.language, Language.Type.en);
        this.style = new VP<Style>(this, (byte)Property.style, Style.Normal);
        // textSize
        {
            this.contentTextSize = new VP<int>(this, (byte)Property.contentTextSize, DefaultContentTextSize);
            this.titleTextSize = new VP<int>(this, (byte)Property.titleTextSize, DefaultTitleTextSize);
            this.labelTextSize = new VP<int>(this, (byte)Property.labelTextSize, DefaultLabelTextSize);
            this.buttonSize = new VP<float>(this, (byte)Property.buttonSize, DefaultButtonSize);
        }
        this.confirmQuit = new VP<bool>(this, (byte)Property.confirmQuit, true);
        this.showLastMove = new VP<bool> (this, (byte)Property.showLastMove, true);
		this.viewUrlImage = new VP<bool> (this, (byte)Property.viewUrlImage, true);
		this.animationSetting = new VP<AnimationSetting> (this, (byte)Property.animationSetting, new AnimationSetting ());
		this.maxThinkCount = new VP<int> (this, (byte)Property.maxThinkCount, DefaultMaxThinkCount);
        this.defaultChosenGame = new VP<DefaultChosenGame>(this, (byte)Property.defaultChosenGame, new DefaultChosenGameLast());
        this.defaultRoomName = new VP<DefaultRoomName>(this, (byte)Property.defaultRoomName, new DefaultRoomNameLast());
        this.defaultChatRoomStyle = new VP<DefaultChatRoomStyle>(this, (byte)Property.defaultChatRoomStyle, new DefaultChatRoomStyleLast());
    }

	#endregion

}