using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildTopic : Topic
{

	#region Constructor

	public enum Property
	{

	}

	public GuildTopic() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Guild;
	}

	public override bool isCanSendNormalMessage (uint userId)
	{
		return true;
	}

}