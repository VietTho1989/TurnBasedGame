using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllLimitRoomContainers : Data
{

	public LP<LimitRoomContainer> limitRoomContainers;

	#region Constructor

	public enum Property
	{
		limitRoomContainers
	}

	public AllLimitRoomContainers() : base()
	{
		this.limitRoomContainers = new LP<LimitRoomContainer> (this, (byte)Property.limitRoomContainers);
	}

	#endregion

}