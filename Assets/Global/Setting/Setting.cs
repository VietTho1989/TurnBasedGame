﻿using UnityEngine;
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

    public VP<bool> showLastMove;

	public VP<bool> viewUrlImage;

	public VP<AnimationSetting> animationSetting;

	#endregion

	public VP<int> maxThinkCount;

	#region Constructor

	public enum Property
	{
		language,
        style,
        showLastMove,
		viewUrlImage,
		animationSetting,
		maxThinkCount
	}

	public Setting() : base()
	{
		this.language = new VP<Language.Type> (this, (byte)Property.language, Language.Type.en);
        this.style = new VP<Style>(this, (byte)Property.style, Style.Normal);
        this.showLastMove = new VP<bool> (this, (byte)Property.showLastMove, true);
		this.viewUrlImage = new VP<bool> (this, (byte)Property.viewUrlImage, true);
		this.animationSetting = new VP<AnimationSetting> (this, (byte)Property.animationSetting, new AnimationSetting ());
		this.maxThinkCount = new VP<int> (this, (byte)Property.maxThinkCount, 12);
	}

	#endregion

}