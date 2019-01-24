using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class MoveAnimationUpdate : UpdateBehavior<MoveAnimation>
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
		return false;
	}

	#endregion

	#region Task

	private Routine clientTimeRoutine;

	void Awake() {
		if (Routine.IsNull (clientTimeRoutine)) {
			clientTimeRoutine = CoroutineManager.StartCoroutine (updateClientTime (), this.gameObject);
		} else {
			Debug.LogError ("Why routine != null");
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (clientTimeRoutine);
		}
		return ret;
	}

	public IEnumerator updateClientTime()
	{
		yield return new Wait (30f);
		if (this.data != null) {
			AnimationData animationData = this.data.findDataInParent<AnimationData> ();
			if (animationData != null) {
				animationData.moveAnimations.remove (this.data);
			} else {
				Debug.LogError ("animationData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is MoveAnimation) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is MoveAnimation) {
			MoveAnimation moveAnimation = data as MoveAnimation;
			{

			}
			this.setDataNull (moveAnimation);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is MoveAnimation) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}