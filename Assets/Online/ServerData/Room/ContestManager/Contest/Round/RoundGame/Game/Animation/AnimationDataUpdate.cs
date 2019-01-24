using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationDataUpdate : UpdateBehavior<AnimationData>
{

	#region update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

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
		if (data is AnimationData) {
			AnimationData animationData = data as AnimationData;
			// Child
			{
				animationData.moveAnimations.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is MoveAnimation) {
			MoveAnimation moveAnimation = data as MoveAnimation;
			// Update
			{
				UpdateUtils.makeUpdate<MoveAnimationUpdate, MoveAnimation> (moveAnimation, this.transform);
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is AnimationData) {
			AnimationData animationData = data as AnimationData;
			// Child
			{
				animationData.moveAnimations.allRemoveCallBack (this);
			}
			this.setDataNull (animationData);
			return;
		}
		// Child
		if (data is MoveAnimation) {
			MoveAnimation moveAnimation = data as MoveAnimation;
			// Update
			{
				moveAnimation.removeCallBackAndDestroy (typeof(MoveAnimationUpdate));
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is AnimationData) {
			switch ((AnimationData.Property)wrapProperty.n) {
			case AnimationData.Property.moveAnimations:
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
		if (wrapProperty.p is MoveAnimation) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}