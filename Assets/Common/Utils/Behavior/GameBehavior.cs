using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public abstract class GameBehavior<K> : MonoBehaviour, ValueChangeCallBack where K : Data
{

	public K data;

	public virtual void setData(K newData)
	{
		// before
		this.onBeforeSetData (newData);
		// set
		if (this.data != newData) {
			// remove old
			if (this.data != null) {
				this.data.removeCallBack (this);
			}
			// set new 
			{
				this.data = newData as K;
				if (this.data != null) {
					this.data.addCallBack (this);
				}
			}
		} else {
			// Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
		// after
		if (this.data != null) {
			this.onAfterSetData ();
		}
	}

	public virtual void onBeforeSetData(K newData)
	{

	}

	public virtual void onAfterSetData()
	{

	}

	public void setDataNull(Data removeData){
		if (this.data == removeData) {
			this.data = null;
		} else {
			Debug.LogError ("not correct removeData: " + removeData);
		}
	}

	#region implement callBacks

	public abstract void onAddCallBack<T> (T data) where T:Data;

	public abstract void onRemoveCallBack<T> (T data, bool isHide) where T:Data;

	public abstract void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs);

	#endregion

	#region Coroutine

	public virtual List<Routine> getRoutineList()
	{
		return null;
	}

	public virtual bool isPauseWhenDisable()
	{
		return true;
	}

	public virtual void OnEnable()
	{
		if (isPauseWhenDisable ()) {
			List<Routine> routines = getRoutineList ();
			if (routines != null) {
				for (int i = 0; i < routines.Count; i++) {
					Routine routine = routines [i];
					if (!Routine.IsNull (routine)) {
						if (routine.IsPaused ()) {
							routine.Resume ();
						} else {
							// Debug.Log ("Why routine not pause");
						}
					} else {
						// Debug.Log ("routine null");
					}
				}
			}
		} else {
			// Debug.LogError ("not pause when disable: " + this);
		}
	}

	public virtual void OnDisable() {
		if (isPauseWhenDisable ()) {
			List<Routine> routines = getRoutineList ();
			if (routines != null) {
				for (int i = 0; i < routines.Count; i++) {
					Routine routine = routines [i];
					if (!Routine.IsNull (routine)) {
						if (!routine.IsPaused ()) {
							routine.Pause ();
						} else {
							Debug.Log ("Why routine not pause");
						}
					} else {
						// Debug.Log ("routine null");
					}
				}
			}
		} else {
			// Debug.LogError ("not pause when disable: " + this);
		}
	}

	public virtual void OnDestroy() {
		List<Routine> routines = getRoutineList();
		if (routines != null) {
			for (int i = 0; i < routines.Count; i++) {
				Routine routine = routines [i];
				destroyRoutine (routine);
			}
		}
	}

	public void destroyRoutine(Routine routine)
	{
		if (!Routine.IsNull (routine)) {
			CoroutineManager.StopCoroutine (routine);
		} else {
			// Debug.Log ("Why routine null: " + this);
		}
	}

	public void startRoutine(ref Routine routine, IEnumerator task)
	{
		if (Routine.IsNull (routine)) {
			routine = CoroutineManager.StartCoroutine (task, this.gameObject);
		} else {
			Debug.LogError ("Why routine != null: " + this);
		}
	}

	#endregion

}