using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Perspective : Data
{

	public VP<int> playerView;

	#region Sub

	public abstract class Sub : Data
	{

		public enum Type
		{
			Auto,
			Force
		}

		public abstract Type getType();

	}

	public VP<Sub> sub;

	#endregion

	#region Constructor

	public enum Property
	{
		playerView,
		sub
	}

	public Perspective() : base()
	{
		this.playerView = new VP<int> (this, (byte)Property.playerView, 0);
		this.sub = new VP<Sub> (this, (byte)Property.sub, new PerspectiveAuto());
	}

	#endregion

}

