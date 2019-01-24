using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Topic : Data
{

	public enum Type
	{
		General,
		ShortQuestion,
		Bug,
		Suggestion,
		Off,
		User,
		Friend,
		Guild,
		Room,
		Game
	}

	public abstract Type getType();

	public abstract bool isCanSendNormalMessage (uint userId);

}