using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class BanNormalUI : UIBehavior<BanNormalUI.UIData>
{

	#region UIData

	public class UIData : BanUI.UIData.Sub
	{

		public VP<ReferenceData<BanNormal>> banNormal;

		#region State

		public enum State
		{
			None,
			Request,
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			banNormal,
			state
		}

		public UIData() : base()
		{
			this.banNormal = new VP<ReferenceData<BanNormal>>(this, (byte)Property.banNormal, new ReferenceData<BanNormal>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public override Ban.Type getType ()
		{
			return Ban.Type.Normal;
		}

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	private User profileUser = null;
	private User toBanUser = null;

	public Button btnBan;
	public Text txtRequestState;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				BanNormal banNormal = this.data.banNormal.v.data;
				if (banNormal != null) {
					// Check to add callBack
					{
						// profileUser
						{
							User profileUser = Server.GetProfileUser (banNormal);
							if (this.profileUser != profileUser) {
								// remove old
								if (this.profileUser != null) {
									this.profileUser.removeCallBack (this);
								}
								// set new
								this.profileUser = profileUser;
								if (this.profileUser != null) {
									this.profileUser.addCallBack (this);
								}
							} else {
								Debug.LogError ("the same: " + this);
							}
						}
						// toBanUser
						{
							User toBanUser = banNormal.findDataInParent<User>();
							if (this.toBanUser != toBanUser) {
								// remove old
								if (this.toBanUser != null) {
									this.toBanUser.removeCallBack (this);
								}
								// set new
								this.toBanUser = toBanUser;
								if (this.toBanUser != null) {
									this.toBanUser.addCallBack (this);
								}
							} else {
								Debug.LogError ("the same: " + this);
							}
						}
					}
					// Check can ban
					bool canBan = banNormal.isCanBanOrUnBan(Server.getProfileUserId(banNormal));
					// Task
					{
						if (canBan) {
							switch (this.data.state.v) {
							case UIData.State.None:
								{
									destroyRoutine (wait);
								}
								break;
							case UIData.State.Request:
								{
									destroyRoutine (wait);
									// request
									if (Server.IsServerOnline (banNormal)) {
										banNormal.requestBan (Server.getProfileUserId (banNormal));
										this.data.state.v = UIData.State.Wait;
									} else {
										Debug.LogError ("server not online: " + this);
									}
								}
								break;
							case UIData.State.Wait:
								{
									if (Server.IsServerOnline (banNormal)) {
										if (Routine.IsNull (wait)) {
											wait = CoroutineManager.StartCoroutine (TaskWait (), this.gameObject);
										} else {
											Debug.LogError ("Why routine != null: " + this);
										}
									} else {
										this.data.state.v = UIData.State.None;
									}
								}
								break;
							default:
								Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
								break;
							}
						} else {
							this.data.state.v = UIData.State.None;
						}
					}
					// btnBan
					{
						if (btnBan != null) {
							if (canBan) {
								btnBan.interactable = (this.data.state.v == UIData.State.None);
							} else {
								btnBan.interactable = false;
							}
						} else {
							Debug.LogError ("btnBan null: " + this);
						}
					}
					// txtRequestState
					{
						if (txtRequestState != null) {
							if (canBan) {
								switch (this.data.state.v) {
								case UIData.State.None:
									txtRequestState.text = "Ban";
									break;
								case UIData.State.Request:
								case UIData.State.Wait:
									txtRequestState.text = "Requesting to ban";
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								txtRequestState.text = "Cannot Ban";
							}
						} else {
							Debug.LogError ("txtRequestState null: " + this);
						}
					}
				} else {
					Debug.LogError ("banNormal null: " + this);
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

	public override void OnDestroy()
	{
		base.OnDestroy ();
		if (this.profileUser != null) {
			this.profileUser.removeCallBack (this);
			this.profileUser = null;
		} else {
			Debug.LogError ("profileUser null: " + this);
		}
		if (this.toBanUser != null) {
			this.toBanUser.removeCallBack (this);
			this.toBanUser = null;
		} else {
			Debug.LogError ("toBanUser null: " + this);
		}
	}

	#endregion

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			this.data.state.v = UIData.State.None;
			Toast.showMessage ("request unfriend error");
			Debug.LogError ("request unfriend error: " + this);
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.banNormal.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// BanNormal
			{
				if (data is BanNormal) {
					BanNormal banNormal = data as BanNormal;
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
						DataUtils.addParentCallBack (banNormal, this, ref this.server);
					}
					dirty = true;
					return;
				}
				// Parent
				{
					if (data is Server) {
						dirty = true;
						return;
					}
				}
				if (data is User) {
					dirty = true;
					return;
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
				uiData.banNormal.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// BanNormal
			{
				if (data is BanNormal) {
					BanNormal banNormal = data as BanNormal;
					// Parent
					{
						DataUtils.removeParentCallBack (banNormal, this, ref this.server);
					}
					return;
				}
				// Parent
				{
					if (data is Server) {
						return;
					}
				}
				if (data is User) {
					return;
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
			case UIData.Property.banNormal:
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
			// BanNormal
			{
				if (wrapProperty.p is BanNormal) {
					switch ((BanNormal.Property)wrapProperty.n) {
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				{
					if (wrapProperty.p is Server) {
						Server.State.OnUpdateSyncStateChange (wrapProperty, this);
						return;
					}
				}
				if (wrapProperty.p is User) {
					switch ((User.Property)wrapProperty.n) {
					case User.Property.human:
						dirty = true;
						break;
					case User.Property.role:
						dirty = true;
						break;
					case User.Property.ipAddress:
						break;
					case User.Property.registerTime:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBan()
	{
		if (this.data != null) {
			if (this.data.state.v == UIData.State.None) {
				this.data.state.v = UIData.State.Request;
			} else {
				Debug.LogError ("you are requesting: " + this.data.state.v + "; " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}