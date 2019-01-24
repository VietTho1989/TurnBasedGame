using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class WaitInputServerTimeUpdate : UpdateBehavior<WaitInputAction>
{

	#region Update

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

	private Routine serverTimeRoutine;

	void Awake() {
		if (Routine.IsNull (serverTimeRoutine)) {
			serverTimeRoutine = CoroutineManager.StartCoroutine (updateServerTime (), this.gameObject);
		} else {
			Debug.LogError ("Why routine != null");
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (serverTimeRoutine);
		}
		return ret;
	}

	public IEnumerator updateServerTime()
	{
		while (true) {
			yield return new Wait (1f);
			if (this.data != null) {
				if (Game.IsPlaying (this.data)) {
					this.data.serverTime.v = this.data.serverTime.v + 1;
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is WaitInputAction) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is WaitInputAction) {
			WaitInputAction waitInputAction = data as WaitInputAction;
			{

			}
			this.setDataNull (waitInputAction);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is WaitInputAction) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}