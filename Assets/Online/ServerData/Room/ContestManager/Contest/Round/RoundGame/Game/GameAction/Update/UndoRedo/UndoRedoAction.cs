using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UndoRedo;

public class UndoRedoAction : GameAction
{

	#region State

	public abstract class State : Data
	{

		public enum Type
		{
			Start,
			Process,
			Resolved
		}

		public abstract Type getType();

	}
	public VP<State> state;

	#endregion

	public VP<RequestInform> requestInform;

	#region Constructor

	public enum Property
	{
		state,
		requestInform
	}

	public UndoRedoAction() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, null);
		this.requestInform = new VP<RequestInform> (this, (byte)Property.requestInform, new RequestLastYourTurn ());
	}

	#endregion

	public override Type getType ()
	{
		return Type.UndoRedo;
	}
}