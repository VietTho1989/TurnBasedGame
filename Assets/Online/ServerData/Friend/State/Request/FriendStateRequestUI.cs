using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class FriendStateRequestUI : UIBehavior<FriendStateRequestUI.UIData>
{

	#region UIData

	public class UIData : FriendStateUI.UIData.Sub
	{

		public VP<ReferenceData<FriendStateRequest>> friendStateRequest;

		#region State

		public enum State
		{
			None,
			RequestAccept,
			RequestRefuse,
			RequestCancel,
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			friendStateRequest,
			state
		}

		public UIData() : base()
		{
			this.friendStateRequest = new VP<ReferenceData<FriendStateRequest>>(this, (byte)Property.friendStateRequest, new ReferenceData<FriendStateRequest>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override Friend.State.Type getType ()
		{
			return Friend.State.Type.Request;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	public GameObject requestingIndicator;

	public Button btnAccept;
	public Button btnRefuse;
	public Button btnCancel;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				FriendStateRequest friendStateRequest = this.data.friendStateRequest.v.data;
				if (friendStateRequest != null) {
					// btnAccept, btnRefuse
					{
						if (btnAccept != null && btnRefuse!=null) {
							if (friendStateRequest.isCanAnswer (Server.getProfileUserId (friendStateRequest))) {
								btnAccept.gameObject.SetActive (true);
								btnRefuse.gameObject.SetActive (true);
								// enable?
								switch (this.data.state.v) {
								case UIData.State.None:
									{
										btnAccept.enabled = true;
										btnRefuse.enabled = true;
									}
									break;
								case UIData.State.RequestAccept:
								case UIData.State.RequestCancel:
								case UIData.State.RequestRefuse:
								case UIData.State.Wait:
									{
										btnAccept.enabled = false;
										btnRefuse.enabled = false;
									}
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								btnAccept.gameObject.SetActive (false);
								btnRefuse.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("btnAccept, btnRefuse null: " + this);
						}
					}
					// btnCancel
					{
						if (btnCancel != null) {
							if (friendStateRequest.isCanCancel (Server.getProfileUserId (friendStateRequest))) {
								btnCancel.gameObject.SetActive (true);
								// enable?
								switch (this.data.state.v) {
								case UIData.State.None:
									{
										btnCancel.enabled = true;
									}
									break;
								case UIData.State.RequestAccept:
								case UIData.State.RequestCancel:
								case UIData.State.RequestRefuse:
								case UIData.State.Wait:
									{
										btnCancel.enabled = false;
									}
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								btnCancel.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("btnCancel null: " + this);
						}
					}
					// requestingIndicator
					{
						if (requestingIndicator != null) {
							switch (this.data.state.v) {
							case UIData.State.None:
								requestingIndicator.SetActive (false);
								break;
							case UIData.State.RequestAccept:
							case UIData.State.RequestRefuse:
							case UIData.State.RequestCancel:
							case UIData.State.Wait:
								requestingIndicator.SetActive (true);
								break;
							default:
								Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("requestingIndicator null: " + this);
						}
					}
					// Task
					{
						switch (this.data.state.v) {
						case UIData.State.None:
							{
								destroyRoutine (wait);
							}
							break;
						case UIData.State.RequestAccept:
							{
								destroyRoutine (wait);
								// request
								if (Server.IsServerOnline (friendStateRequest)) {
									friendStateRequest.requestAccept (Server.getProfileUserId (friendStateRequest));
									this.data.state.v = UIData.State.Wait;
								} else {
									Debug.LogError ("server not online: " + this);
								}
							}
							break;
						case UIData.State.RequestRefuse:
							{
								destroyRoutine (wait);
								// request
								if (Server.IsServerOnline (friendStateRequest)) {
									friendStateRequest.requestRefuse (Server.getProfileUserId (friendStateRequest));
									this.data.state.v = UIData.State.Wait;
								} else {
									Debug.LogError ("server not online: " + this);
								}
							}
							break;
						case UIData.State.RequestCancel:
							{
								destroyRoutine (wait);
								// request
								if (Server.IsServerOnline (friendStateRequest)) {
									friendStateRequest.requestCancel (Server.getProfileUserId (friendStateRequest));
									this.data.state.v = UIData.State.Wait;
								} else {
									Debug.LogError ("server not online: " + this);
								}
							}
							break;
						case UIData.State.Wait:
							{
								if (Server.IsServerOnline (friendStateRequest)) {
									startRoutine (ref this.wait, TaskWait ());
								} else {
									this.data.state.v = UIData.State.None;
								}
							}
							break;
						default:
							Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
							break;
						}
					}
				} else {
					Debug.LogError ("friendStateRequest null: " + this);
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

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			if (this.data != null) {
				this.data.state.v = UIData.State.None;
			} else {
				Debug.LogError ("data null: " + this);
			}
			Toast.showMessage ("request error");
			Debug.LogError ("request error: " + this);
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (wait);
		}
		return ret;
	}

	#endregion

	#region implement callBacks

	private Server server = null;
	private Friend friend = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.friendStateRequest.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is FriendStateRequest) {
				FriendStateRequest friendStateRequest = data as FriendStateRequest;
				// Reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				// Parent
				{
					DataUtils.addParentCallBack (friendStateRequest, this, ref this.server);
					DataUtils.addParentCallBack (friendStateRequest, this, ref this.friend);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// Server
				if (data is Server) {
					dirty = true;
					return;
				}
				// Friend
				{
					if (data is Friend) {
						Friend friend = data as Friend;
						// Child
						{
							friend.user1.allAddCallBack (this);
							friend.user2.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if(data is Human){
						dirty = true;
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.friendStateRequest.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is FriendStateRequest) {
				FriendStateRequest friendStateRequest = data as FriendStateRequest;
				// Parent
				{
					DataUtils.removeParentCallBack (friendStateRequest, this, ref this.server);
					DataUtils.removeParentCallBack (friendStateRequest, this, ref this.friend);
				}
				return;
			}
			// Parent
			{
				// Server
				if (data is Server) {
					return;
				}
				// Friend
				{
					if (data is Friend) {
						Friend friend = data as Friend;
						// Child
						{
							friend.user1.allRemoveCallBack (this);
							friend.user2.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if(data is Human){
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.friendStateRequest:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is FriendStateRequest) {
				switch ((FriendStateRequest.Property)wrapProperty.n) {
				case FriendStateRequest.Property.accepts:
					{
						dirty = true;
						if (this.data != null) {
							this.data.reset ();
						}
					}
					break;
				case FriendStateRequest.Property.refuses:
					{
						dirty = true;
						if (this.data != null) {
							this.data.reset ();
						}
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// Server
				if (wrapProperty.p is Server) {
					Server.State.OnUpdateSyncStateChange (wrapProperty, this);
					return;
				}
				// Friend
				{
					if (wrapProperty.p is Friend) {
						switch ((Friend.Property)wrapProperty.n) {
						case Friend.Property.state:
							break;
						case Friend.Property.user1:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case Friend.Property.user2:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case Friend.Property.time:
							break;
						case Friend.Property.chatRoom:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if(wrapProperty.p is Human){
						Human.onUpdateSyncPlayerIdChange (wrapProperty, this);
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnAccept()
	{
		if (this.data != null) {
			if (this.data.state.v == UIData.State.None) {
				this.data.state.v = UIData.State.RequestAccept;
			} else {
				Debug.LogError ("you are requesting: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnRefuse()
	{
		if (this.data != null) {
			if (this.data.state.v == UIData.State.None) {
				this.data.state.v = UIData.State.RequestRefuse;
			} else {
				Debug.LogError ("you are requesting: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnCancel()
	{
		if (this.data != null) {
			if (this.data.state.v == UIData.State.None) {
				this.data.state.v = UIData.State.RequestCancel;
			} else {
				Debug.LogError ("you are requesting: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}