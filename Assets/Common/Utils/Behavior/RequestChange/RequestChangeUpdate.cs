using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class RequestChangeUpdate<K> : UpdateBehavior<RequestChangeUpdate<K>.UpdateData>
{

	#region UpdateData

	public class UpdateData : Data
	{
		public VP<K> origin;

		public VP<K> current;

		public VP<bool> canRequestChange;
		
		public VP<ChangeState> changeState;

		public VP<Server.State.Type> serverState;

		#region Interface

		public delegate void Request(RequestChangeUpdate<K>.UpdateData update, K newK);

		public VP<Request> request;

		#endregion

		public VP<float> waitTime;

		#region Constructor

		public enum Property
		{
			origin,
			current,
			canRequestChange,
			changeState,
			serverState,
			request,
			waitTime
		}

		public UpdateData() : base()
		{
			this.origin = new VP<K>(this, (byte)Property.origin, default(K));
			this.current = new VP<K>(this, (byte)Property.current, default(K));
			this.canRequestChange = new VP<bool>(this, (byte)Property.canRequestChange, false);
			this.changeState = new VP<ChangeState>(this, (byte)Property.changeState, ChangeState.None);
			this.serverState = new VP<Server.State.Type>(this, (byte)Property.serverState, Server.State.Type.Connect);
			this.request = new VP<Request>(this, (byte)Property.request, null);
			this.waitTime = new VP<float>(this, (byte)Property.waitTime, 0.5f);
		}

		#endregion
	}

	#endregion

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// Process
				if (this.data.canRequestChange.v) {
					// process
					if (!object.Equals(this.data.origin.v, this.data.current.v)) {
						switch (this.data.changeState.v) {
						case Data.ChangeState.None:
							{
								destroyRoutine (waitToResend);
								this.data.changeState.v = Data.ChangeState.Request;
							}
							break;
						case Data.ChangeState.Request:
							{
								destroyRoutine (waitToResend);
								// Request change
								if (this.data.request.v != null) {
									if (this.data.serverState.v == Server.State.Type.Connect) {
										this.data.request.v (this.data, this.data.current.v);
										this.data.changeState.v = Data.ChangeState.Requesting;
									} else {
										Debug.LogError ("server not connect, so not request immediately");
									}
								} else {
									Debug.LogError ("request null: " + this);
								}
							}
							break;
						case Data.ChangeState.Requesting:
							{
								if (this.data.serverState.v == Server.State.Type.Connect) {
									/*if (Routine.IsNull (waitToResend)) {
										waitToResend = CoroutineManager.StartCoroutine (TaskWaitToResend (), this.gameObject);
									} else {
										// Debug.LogError ("Why routine != null: " + this);
									}*/
									startRoutine (ref this.waitToResend, TaskWaitToResend ());
								} else {
									Debug.LogError ("server not connect, so stop requesting");
									this.data.changeState.v = Data.ChangeState.Request;
								}
							}
							break;
						default:
							Debug.LogError ("unknown state: " + this.data.changeState.v + "; " + this);
							break;
						}
					} else {
						this.data.changeState.v = Data.ChangeState.None;
						destroyRoutine (waitToResend);
					}
				} else {
					{
						this.data.changeState.v = Data.ChangeState.None;
						destroyRoutine (waitToResend);
					}
					// set to origin
					this.data.current.v = this.data.origin.v;
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

	#region Task wait to resend

	private Routine waitToResend;

	public IEnumerator TaskWaitToResend()
	{
		if (this.data != null) {
			yield return new Wait (this.data.waitTime.v);
			this.data.changeState.v = Data.ChangeState.Request;
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (waitToResend);
		}
		return ret;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is UpdateData) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UpdateData) {
			UpdateData updateData = data as UpdateData;
			this.setDataNull (updateData);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UpdateData) {
			switch ((UpdateData.Property)wrapProperty.n) {
			case UpdateData.Property.origin:
				{
					dirty = true;
					if (this.data != null) {
						if (this.data.changeState.v == Data.ChangeState.None) {
							this.data.current.v = (K)wrapProperty.getValue ();
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				break;
			case UpdateData.Property.current:
				dirty = true;
				break;
			case UpdateData.Property.canRequestChange:
				dirty = true;
				break;
			case UpdateData.Property.changeState:
				dirty = true;
				break;
			case UpdateData.Property.serverState:
				dirty = true;
				break;
			case UpdateData.Property.request:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: ");
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}