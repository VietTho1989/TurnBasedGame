using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSetting : Data
{

	public VP<float> scale;

	public VP<bool> fastForward;

	public VP<int> maxWaitAnimationCount;// >=1

	#region Constructor

	public enum Property
	{
		scale,
		fastForward,
		maxWaitAnimationCount
	}

	public AnimationSetting() : base()
	{
		this.scale = new VP<float> (this, (byte)Property.scale, 1);
		this.fastForward = new VP<bool> (this, (byte)Property.fastForward, false);
		this.maxWaitAnimationCount = new VP<int> (this, (byte)Property.maxWaitAnimationCount, 10);
	}

	#endregion

}