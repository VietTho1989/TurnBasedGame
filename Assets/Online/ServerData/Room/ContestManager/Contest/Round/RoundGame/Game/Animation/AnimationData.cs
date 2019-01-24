using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationData : Data
{

	public LP<MoveAnimation> moveAnimations;

	#region Constructor

	public enum Property
	{
		moveAnimations
	}

	public AnimationData() : base()
	{
		this.moveAnimations = new LP<MoveAnimation> (this, (byte)Property.moveAnimations);
	}

	#endregion

}