using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInput : WaitInputAction.Sub
{

	public VP<uint> userThink;

	public VP<uint> rethink;

	#region Sub

	public abstract class Sub : Data
	{

		public enum Type
		{
			None,
			Search,
			Solved
		}

		public abstract Type getType();

	}

	/** sub always in client, so don't need identity*/
	public VP<Sub> sub;

	#endregion

	public VP<bool> isGettingSolvedMove;

	#region Constructor

	public enum Property
	{
		userThink,
		reThink,
		sub,
		isGettingSolvedMove
	}

	public WaitAIInput() : base()
	{
		this.userThink = new VP<uint> (this, (byte)Property.userThink, 0);
		this.rethink = new VP<uint> (this, (byte)Property.reThink, 0);
		{
			this.sub = new VP<Sub> (this, (byte)Property.sub, new WaitAIInputNone ());
			// don't create dataIdentity
			this.sub.ni = 0;
		}
		this.isGettingSolvedMove = new VP<bool> (this, (byte)Property.isGettingSolvedMove, false);
	}

	#endregion

	public override Type getType ()
	{
		return Type.AI;
	}


}