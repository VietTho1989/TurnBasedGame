using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationProgress : Data
{

	public VP<float> time;

	public VP<float> duration;

	public VP<ReferenceData<MoveAnimation>> moveAnimation;

	public bool isReverse = false;

	#region Constructor

	public enum Property
	{
		time,
		duration,
		moveAnimation
	}

	public AnimationProgress() : base()
	{
		this.time = new VP<float> (this, (byte)Property.time, 0);
		this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		this.moveAnimation = new VP<ReferenceData<MoveAnimation>> (this, (byte)Property.moveAnimation, new ReferenceData<MoveAnimation> (null));
	}

	#endregion

}