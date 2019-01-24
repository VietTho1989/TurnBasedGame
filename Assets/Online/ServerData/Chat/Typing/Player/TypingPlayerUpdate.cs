using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class TypingPlayerUpdate : UpdateBehavior<TypingPlayer>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case TypingPlayer.State.Start:
					{
						// Destroy old
						{
							destroyRoutine (waitNextReceive);
							destroyRoutine (endTyping);
						}
						// Change state
						this.data.state.v = TypingPlayer.State.Normal;
						{
							if (Routine.IsNull (waitNextReceive)) {
								waitNextReceive = CoroutineManager.StartCoroutine (TaskWaitNextReceive(), this.gameObject);
							} else {
								Debug.LogError ("Why routine!=null");
							}
						}
					}
					break;
				case TypingPlayer.State.Normal:
					{
						destroyRoutine (endTyping);
					}
					break;
				case TypingPlayer.State.NextReceive:
					{
						destroyRoutine (waitNextReceive);
						{
							if (Routine.IsNull (endTyping)) {
								endTyping = CoroutineManager.StartCoroutine (TaskEndTyping(), this.gameObject);
							} else {
								Debug.LogError ("Why routine!=null");
							}
						}
					}
					break;
				default:
					Debug.LogError ("unknown state: " + this.data.state.v);
					break;
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#region Coroutine Next Receive

	private Routine waitNextReceive;

	public IEnumerator TaskWaitNextReceive()
	{
		float waitTime = 1f;
		{
			if (this.data != null) {
				Typing typing = this.data.findDataInParent<Typing> ();
				if (typing != null) {
					waitTime = typing.nextReceiveTime.v;
				} else {
					Debug.LogError ("typing null");
				}
			} else {
				Debug.LogError ("data null");
			}
			if (waitTime < 0) {
				Debug.LogError ("Why waitTime < 0: " + waitTime);
			}
		}
		yield return new Wait(waitTime);
		// Change state
		if (this.data != null) {
			this.data.state.v = TypingPlayer.State.NextReceive;
		} else {
			Debug.LogError ("data null");
		}
	}

	#endregion

	#region Coroutine End Typing

	private Routine endTyping;

	public IEnumerator TaskEndTyping()
	{
		float waitTime = 1f;
		{
			if (this.data != null) {
				Typing typing = this.data.findDataInParent<Typing> ();
				if (typing != null) {
					waitTime = typing.stopDuration.v;
				} else {
					Debug.LogError ("typing null");
				}
			} else {
				Debug.LogError ("data null");
			}
			if (waitTime < 0) {
				Debug.LogError ("Why wait time < 0: " + waitTime);
			}
		}
		yield return new Wait(waitTime);
		// Change state
		if (this.data != null) {
			// Remove
			Typing typing = this.data.findDataInParent<Typing>();
			if (typing != null) {
				typing.typingPlayers.remove (this.data);
			} else {
				Debug.LogError ("typing null");
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	#endregion

	#region LifeCycle

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (waitNextReceive);
			ret.Add (endTyping);
		}
		return ret;
	}

	#endregion

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is TypingPlayer) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is TypingPlayer) {
			TypingPlayer typingPlayer = data as TypingPlayer;
			// set data null
			this.setDataNull (typingPlayer);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is TypingPlayer) {
			switch ((TypingPlayer.Property)wrapProperty.n) {
			case TypingPlayer.Property.playerId:
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

}