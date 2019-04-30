using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace LoginState
{
	public class CheckTimeOutUpdate : UpdateBehavior<Log>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.time.v >= this.data.timeOut.v) {
						Login login = this.data.findDataInParent<Login> ();
						if (login != null) {
							None none = new None ();
							{
								none.uid = login.state.makeId ();
								// state
								{
									StateFail stateFail = new StateFail ();
									{
										stateFail.uid = none.state.makeId ();
										stateFail.reason.v = StateFail.Reason.TimeOut;
									}
									none.state.v = stateFail;
								}
							}
							login.state.v = none;
						} else {
							Debug.LogError ("login null: " + this);
						}
					}
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

		private Routine updateTimeRoutine;

		void Awake() {
			if (Routine.IsNull (updateTimeRoutine)) {
				updateTimeRoutine = CoroutineManager.StartCoroutine (updateTime (), this.gameObject);
			} else {
				Debug.LogError ("Why routine != null");
			}
		}

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (updateTimeRoutine);
			}
			return ret;
		}

		public IEnumerator updateTime()
		{
			while (true) {
				yield return new Wait (1f);
				if (this.data != null) {
					this.data.time.v = this.data.time.v + 1;
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is Log) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Log) {
				Log log = data as Log;
				{

				}
				this.setDataNull (log);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is Log) {
				switch ((Log.Property)wrapProperty.n) {
				case Log.Property.connectState:
					break;
				case Log.Property.step:
					break;
				case Log.Property.time:
					dirty = true;
					break;
				case Log.Property.timeOut:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}