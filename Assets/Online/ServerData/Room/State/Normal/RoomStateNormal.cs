using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomStateNormal : Room.State
{

	#region Sub

	public abstract class State : Data
	{
		
		public enum Type
		{
			Normal,
			Freeze
		}

		public abstract Type getType ();

	}

	public VP<State> state;

	#endregion

	#region Constructor

	public enum Property
	{
		state
	}

	public RoomStateNormal() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, new RoomStateNormalNormal ());
	}

	#endregion

	public override Type getType ()
	{
		return Type.Normal;
	}

}