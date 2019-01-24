using UnityEngine;
using System.Collections;

public abstract class MoveAnimation : Data
{

	public abstract GameMove.Type getType();

	public abstract float getDuration();

	public abstract void initDuration();

	public abstract void updateAfterProcessGameMove (GameType gameType);

	public abstract bool isLoadFullData ();

	public abstract GameMove makeGameMove();

	#region interpolator

	public static float getAccelerateDecelerateInterpolation(float input) {
		if (input < 0) {
			input = 0;
		} else {
			// Debug.LogError ("input<0");
		}
		if (input > 1) {
			input = 1;
		} else {
			// Debug.LogError ("input>1");
		}
		// return (float) (Mathf.Cos((input + 1) * Mathf.PI) / 2.0f) + 0.5f;
		return input;
	}

	public static float getLinearInterpolation(float input) {
		if (input < 0) {
			input = 0;
		}
		if (input > 1) {
			input = 1;
		}
		return input;
	}

	#endregion

	public static float GetDistanceMoveDuration(float distance)
	{
		if (distance > 0) {
			return (0.8f + 0.1f * distance) * AnimationManager.DefaultDuration;
		} else {
			return 0;
		}
	}

}