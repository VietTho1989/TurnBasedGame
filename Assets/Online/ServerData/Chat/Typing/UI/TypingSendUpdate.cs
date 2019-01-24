using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedCoroutines;

public class TypingSendUpdate : UpdateBehavior<TypingSendUpdate.TypingSendData>
{

	#region Update

	public void onValueChange(string newValue)
	{
		// Debug.LogError ("onValueChange: " + newValue);
		if (this.data != null) {
			if (!string.IsNullOrEmpty (newValue)) {
				if (this.data.state.v == TypingSendData.State.Normal) {
					this.data.state.v = TypingSendData.State.Send;
				}
			} else {
				if (this.data.state.v == TypingSendData.State.Send) {
					this.data.state.v = TypingSendData.State.Normal;
				}
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	#region Coroutine Wait Send

	private Routine waitToSend;

	public IEnumerator TaskWaitToSend()
	{
		yield return new Wait(1);
		// Send
		if (this.data.typing.v.data != null) {
			Typing typing = this.data.typing.v.data;
			uint userId = Server.getProfileUserId (typing);
			if (typing.isCanTyping (userId)) {
				// Send
				typing.requestSendTyping(userId);
				// Change state
				this.data.state.v = TypingSendData.State.Sending;
			} else {
				this.data.state.v = TypingSendData.State.UnableSend;
			}
		} else {
			Debug.LogError ("typing null");
			this.data.state.v = TypingSendData.State.UnableSend;
		}
	}

	private Routine waitSend;

	public IEnumerator TaskWaitSend()
	{
		float waitTime = 1f;
		{
			if (this.data != null && this.data.typing.v.data != null) {
				Typing typing = this.data.typing.v.data;
				waitTime = typing.nextReceiveTime.v;
			} else {
				Debug.LogError ("data, typing null");
			}
			if (waitTime < 0) {
				waitTime = 1;
				Debug.LogError ("Why wait time < 0: " + waitTime);
			}
		}
		yield return new Wait(waitTime);
		// Change state
		if (this.data != null && this.data.typing.v.data != null) {
			Typing typing = this.data.typing.v.data;
			uint userId = Server.getProfileUserId (typing);
			if (typing.isCanTyping (userId)) {
				this.data.state.v = TypingSendData.State.Normal;
			} else {
				this.data.state.v = TypingSendData.State.UnableSend;
			}
		} else {
			Debug.LogError ("data, typing null");
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (waitToSend);
			ret.Add (waitSend);
		}
		return ret;
	}

	#endregion

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case TypingSendData.State.Normal:
					{
						destroyRoutine (waitToSend);
						destroyRoutine (waitSend);
						// Check change to unable
						if (this.data.typing.v.data != null) {
							Typing typing = this.data.typing.v.data;
							uint userId = Server.getProfileUserId (typing);
							if (!typing.isCanTyping (userId)) {
								this.data.state.v = TypingSendData.State.UnableSend;
							}
						} else {
							Debug.LogError ("typing null");
						}
					}
					break;
				case TypingSendData.State.Send:
					{
						destroyRoutine (waitSend);
						// Check can send
						if (this.data.typing.v.data != null) {
							Typing typing = this.data.typing.v.data;
							uint userId = Server.getProfileUserId (typing);
							if (typing.isCanTyping (userId)) {
								// Start task wait to send
								if (Routine.IsNull (waitToSend)) {
									waitToSend = CoroutineManager.StartCoroutine (TaskWaitToSend (), this.gameObject);
								} else {
									Debug.LogError ("Why routine!=null");
								}
							} else {
								this.data.state.v = TypingSendData.State.UnableSend;
							}
						} else {
							Debug.LogError ("typing null");
							this.data.state.v = TypingSendData.State.UnableSend;
						}
					}
					break;
				case TypingSendData.State.Sending:
					{
						destroyRoutine (waitToSend);
						if (Routine.IsNull (waitSend)) {
							waitSend = CoroutineManager.StartCoroutine (TaskWaitSend (), this.gameObject);
						} else {
							// Debug.LogError ("Why routine!=null");
						}
					}
					break;
				case TypingSendData.State.UnableSend:
					{
						destroyRoutine (waitToSend);
						destroyRoutine (waitSend);
						// Check change to enable
						if (this.data.typing.v.data != null) {
							Typing typing = this.data.typing.v.data;
							uint userId = Server.getProfileUserId (typing);
							if (typing.isCanTyping (userId)) {
								this.data.state.v = TypingSendData.State.Normal;
							}
						} else {
							// Debug.LogError ("typing null");
						}
					}
					break;
				default:
					Debug.LogError ("unknown state: " + this.data.state.v);
					break;
				}
			} else {
				Debug.Log ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is TypingSendData) {
			TypingSendData typingSendData = data as TypingSendData;
			// Child
			{
				typingSendData.typing.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		if (data is Typing) {
			Typing typing = data as Typing;
			{
				typing.typingPlayers.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		if (data is TypingPlayer) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is TypingSendData) {
			TypingSendData typingSendData = data as TypingSendData;
			// Child
			{
				typingSendData.typing.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (typingSendData);
			return;
		}
		if (data is Typing) {
			Typing typing = data as Typing;
			{
				typing.typingPlayers.allRemoveCallBack (this);
			}
			return;
		}
		if (data is TypingPlayer) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is TypingSendData) {
			switch ((TypingSendData.Property)wrapProperty.n) {
			case TypingSendData.Property.typing:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case TypingSendData.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is Typing) {
			switch ((Typing.Property)wrapProperty.n) {
			case Typing.Property.isEnable:
				dirty = true;
				break;
			case Typing.Property.nextReceiveTime:
				dirty = true;
				break;
			case Typing.Property.stopDuration:
				dirty = true;
				break;
			case Typing.Property.typingPlayers:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is TypingPlayer) {
			switch ((TypingPlayer.Property)wrapProperty.n) {
			case TypingPlayer.Property.playerId:
				dirty = true;
				break;
			case TypingPlayer.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region TypingSendData

	public class TypingSendData : Data
	{

		public VP<ReferenceData<Typing>> typing;

		public enum State
		{
			Normal,
			Send,
			Sending,
			UnableSend
		}
		public VP<State> state;

		#region Constructor

		public enum Property
		{
			typing,
			state
		}

		public TypingSendData() : base()
		{
			this.typing = new VP<ReferenceData<Typing>>(this, (byte)Property.typing, new ReferenceData<Typing>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.UnableSend);
		}

		#endregion

	}

	#endregion
}