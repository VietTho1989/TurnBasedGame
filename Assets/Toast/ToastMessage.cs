using UnityEngine;
using System.Collections;

public class ToastMessage : Data
{
	public VP<int> toastIndex;

	public VP<string> message;

	public VP<float> time;

	public const float DefaultDuration = 2.5f;
	public VP<float> duration;

	#region Constructor

	public enum Property
	{
		toastIndex,
		message,
		time,
		duration
	}

	public ToastMessage() : base()
	{
		this.toastIndex = new VP<int>(this, (byte)Property.toastIndex, 0);
		this.message = new VP<string> (this, (byte)Property.message, "");
		this.time = new VP<float> (this, (byte)Property.time, 0);
		this.duration = new VP<float> (this, (byte)Property.duration, DefaultDuration);
	}

	#endregion

}