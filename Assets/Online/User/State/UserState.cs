using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserState : Data
{

	public enum State
	{
		Online,
		Disconnect,
		Offline
	}

	public VP<State> state;// Offline

	public VP<bool> hide;// false: khong hien online cho nguoi khac biet

	public VP<long> time;//==0

	public enum Property
	{
		state,
		hide,
		time
	}

	public UserState() : base()
	{
		state = new VP<State>(this, (byte)Property.state, State.Offline);
		hide = new VP<bool>(this, (byte)Property.hide, false);
		time = new VP<long>(this, (byte)Property.time, 0);
	}

}