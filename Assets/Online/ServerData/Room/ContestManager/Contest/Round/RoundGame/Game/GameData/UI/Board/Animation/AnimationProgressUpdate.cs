using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationProgressUpdate : UpdateBehavior<AnimationProgress>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				MoveAnimation moveAnimation = this.data.moveAnimation.v.data;
				if (moveAnimation != null) {
					this.data.duration.v = moveAnimation.getDuration ();
				} else {
					Debug.LogError ("moveAnimation null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is AnimationProgress) {
			AnimationProgress animationProgress = data as AnimationProgress;
			// Child
			{
				animationProgress.moveAnimation.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is MoveAnimation) {
				MoveAnimation moveAnimation = data as MoveAnimation;
				// Child
				{
					moveAnimation.addCallBackAllChildren (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				data.addCallBackAllChildren (this);
				dirty = true;
				return;
			}
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is AnimationProgress) {
			AnimationProgress animationProgress = data as AnimationProgress;
			// Child
			{
				animationProgress.moveAnimation.allRemoveCallBack (this);
			}
			this.setDataNull (animationProgress);
			return;
		}
		// Child
		{
			if (data is MoveAnimation) {
				MoveAnimation moveAnimation = data as MoveAnimation;
				// Child
				{
					moveAnimation.removeCallBackAllChildren (this);
				}
				return;
			}
			// Child
			{
				data.removeCallBackAllChildren (this);
				return;
			}
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is AnimationProgress) {
			switch ((AnimationProgress.Property)wrapProperty.n) {
			case AnimationProgress.Property.time:
				break;
			case AnimationProgress.Property.duration:
				break;
			case AnimationProgress.Property.moveAnimation:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is MoveAnimation) {
				if (Generic.IsAddCallBackInterface<T>()) {
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (Generic.IsAddCallBackInterface<T>()) {
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				dirty = true;
				return;
			}
		}
		// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}