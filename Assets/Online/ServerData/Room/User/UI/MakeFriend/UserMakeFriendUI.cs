using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class UserMakeFriendUI : UIBehavior<UserMakeFriendUI.UIData>, FriendHashMap.Delegate
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Human>> human;

		#region State

		public enum State
		{
			None,
			Request,
			Wait
		}

		public VP<State> state;

		#endregion

		public VP<FriendStateUI.UIData> friendStateUIData;

		#region Constructor

		public enum Property
		{
			human,
			state,
			friendStateUIData
		}

		public UIData() : base()
		{
			this.human = new VP<ReferenceData<Human>>(this, (byte)Property.human, new ReferenceData<Human>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
			this.friendStateUIData = new VP<FriendStateUI.UIData>(this, (byte)Property.friendStateUIData, new FriendStateUI.UIData());
		}

		#endregion

	}

	#endregion

	#region Refresh

	public GameObject yourInform;

	public Button btnMakeFriend;
	public Text tvMakeFriend;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Human human = this.data.human.v.data;
				if (human != null) {
					uint profileId = Server.getProfileUserId (human);
					if (profileId != human.playerId.v) {
						// yourInform
						{
							if (yourInform != null) {
								yourInform.SetActive (false);
							} else {
								Debug.LogError ("yourInform null: " + this);
							}
						}
						// Find Friend
						Friend friend = null;
						{
							// get friendWorld
							FriendWorld friendWorld = null;
							{
								Server server = human.findDataInParent<Server> ();
								if (server != null) {
									friendWorld = server.friendWorld.v;
								} else {
									Debug.LogError ("server null: " + this);
								}
							}
							// Process
							if (friendWorld != null) {
								friend = friendWorld.findFriend (profileId, human.playerId.v);
							} else {
								Debug.LogError ("friendWorld null: " + this);
							}
						}
						// Process
						if (friend == null) {
							// friendStateUIContainer
							{
								if (friendStateContainer != null) {
									friendStateContainer.gameObject.SetActive (false);
								} else {
									Debug.LogError ("friendStateUIContainer null: " + this);
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
								case UIData.State.Request:
									{
										destroyRoutine (wait);
										if (Server.IsServerOnline (human)) {
											// Find User
											User user = Server.GetProfileUser (human);
											// Process
											if (user != null) {
												user.requestMakeFriendRequest (human.playerId.v);
											} else {
												Debug.LogError ("user null: " + this);
											}
											this.data.state.v = UIData.State.Wait;
										} else {
											Debug.LogError ("server not online: " + this);
										}
									}
									break;
								case UIData.State.Wait:
									{
										if (Server.IsServerOnline (human)) {
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
							// UI
							{
								if (btnMakeFriend != null && tvMakeFriend != null) {
									switch (this.data.state.v) {
									case UIData.State.None:
										{
											btnMakeFriend.interactable = true;
											tvMakeFriend.text = "Make Friend";
										}
										break;
									case UIData.State.Request:
										{
											btnMakeFriend.interactable = true;
											tvMakeFriend.text = "Cancel Make Friend?";
										}
										break;
									case UIData.State.Wait:
										{
											btnMakeFriend.interactable = false;
											tvMakeFriend.text = "Making Friend...";
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("btnMakeFriend, tvMakeFriend null: " + this);
								}
							}
						} else {
							// friendStateUIContainer
							{
								if (friendStateContainer != null) {
									friendStateContainer.gameObject.SetActive (true);
								} else {
									Debug.LogError ("friendStateUIContainer null: " + this);
								}
							}
							// Task
							{
								this.data.state.v = UIData.State.None;
								destroyRoutine (wait);
							}
							// friendStateUIData
							{
								FriendStateUI.UIData friendStateUIData = this.data.friendStateUIData.v;
								if (friendStateUIData != null) {
									friendStateUIData.friend.v = new ReferenceData<Friend> (friend);
								}
							}
						}
					} else {
						// yourInform
						{
							if (yourInform != null) {
								yourInform.SetActive (true);
							} else {
								Debug.LogError ("yourInform null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("human null: " + this);
				}
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

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			// Chuyen sang state none
			{
				if (this.data != null) {
					this.data.state.v = UIData.State.None;
				} else {
					Debug.LogError ("data null: " + this);
				}
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

	public FriendStateUI friendStatePrefab;
	public Transform friendStateContainer;

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.human.allAddCallBack (this);
				uiData.friendStateUIData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// Human
			{
				if (data is Human) {
					Human human = data as Human;
					// Parent
					{
						DataUtils.addParentCallBack (human, this, ref this.server);
					}
					dirty = true;
					return;
				}
				// Parent
				{
					if (data is Server) {
						Server server = data as Server;
						// Child
						{
							server.friendWorld.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is FriendWorld) {
						FriendWorld friendWorld = data as FriendWorld;
						// Child
						{
							friendWorld.friendHashMap.delegates.Add (this);
						}
						dirty = true;
						return;
					}
				}
			}
			if (data is FriendStateUI.UIData) {
				FriendStateUI.UIData friendStateUIData = data as FriendStateUI.UIData;
				// UI
				{
					UIUtils.Instantiate (friendStateUIData, friendStatePrefab, friendStateContainer);
				}
				dirty = true;
				return;
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
				uiData.human.allRemoveCallBack (this);
				uiData.friendStateUIData.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Human) {
				Human human = data as Human;
				// Parent
				{
					DataUtils.removeParentCallBack (human, this, ref this.server);
				}
				return;
			}
			// Parent
			{
				if (data is Server) {
					Server server = data as Server;
					// Child
					{
						server.friendWorld.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is FriendWorld) {
					FriendWorld friendWorld = data as FriendWorld;
					// Child
					{
						friendWorld.friendHashMap.delegates.Remove (this);
					}
					return;
				}
			}
			if (data is FriendStateUI.UIData) {
				FriendStateUI.UIData friendStateUIData = data as FriendStateUI.UIData;
				// UI
				{
					friendStateUIData.removeCallBackAndDestroy (typeof(FriendStateUI));
				}
				return;
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
			case UIData.Property.human:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.friendStateUIData:
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
			// Human
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						dirty = true;
						break;
					case Human.Property.account:
						break;
					case Human.Property.state:
						break;
					case Human.Property.email:
						break;
					case Human.Property.phoneNumber:
						break;
					case Human.Property.status:
						break;
					case Human.Property.birthday:
						break;
					case Human.Property.sex:
						break;
					case Human.Property.connection:
						break;
					case Human.Property.ban:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				{
					if (wrapProperty.p is Server) {
						switch ((Server.Property)wrapProperty.n) {
						case Server.Property.serverConfig:
							break;
						case Server.Property.startState:
							break;
						case Server.Property.type:
							break;
						case Server.Property.profile:
							break;
						case Server.Property.state:
							dirty = true;
							break;
						case Server.Property.users:
							break;
						case Server.Property.disconnectTime:
							break;
						case Server.Property.globalChat:
							break;
						case Server.Property.friendWorld:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case Server.Property.guilds:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is FriendWorld) {
						return;
					}
				}
			}
			if (wrapProperty.p is FriendStateUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnMakeFriend()
	{
		if (this.data != null) {
			switch (this.data.state.v) {
			case UIData.State.None:
				this.data.state.v = UIData.State.Request;
				break;
			case UIData.State.Request:
				this.data.state.v = UIData.State.None;
				break;
			case UIData.State.Wait:
				Debug.LogError ("You are requesting: " + this);
				break;
			default:
				Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
				break;
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#region FriendHashMap

	public void onFriendListChange (uint userId)
	{
		if (this.data != null) {
			Human human = this.data.human.v.data;
			if (human != null) {
				if (human.playerId.v == userId) {
					dirty = true;
				}
			} else {
				Debug.LogError ("human null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#endregion

}