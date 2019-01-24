using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomManager : Data
{

	public VP<GlobalRoomContainer> globalRoomContainer;

	public VP<AllLimitRoomContainers> allLimitRoomContainers;

	#region Constructor

	public enum Property
	{
		globalRoomContainer,
		allLimitRoomContainers
	}

	public RoomManager() : base()
	{
		this.globalRoomContainer = new VP<GlobalRoomContainer> (this, (byte)Property.globalRoomContainer, new GlobalRoomContainer ());
		this.allLimitRoomContainers = new VP<AllLimitRoomContainers> (this, (byte)Property.allLimitRoomContainers, new AllLimitRoomContainers ());
	}

	#endregion

}