using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

public class JoinRoomUI : UIBehavior<JoinRoomUI.UIData>
{

	#region UIData

	public class UIData : RoomListUI.UIData.Sub
	{

		public VP<ReferenceData<Room>> room;

		public VP<RequestChangeStringUI.UIData> id;

		public VP<RequestChangeStringUI.UIData> name;

		public VP<RequestChangeStringUI.UIData> players;

		public VP<RequestChangeEnumUI.UIData> state;

		public VP<RequestChangeStringUI.UIData> time;

		public VP<RequestChangeStringUI.UIData> password;

		#region State

		public enum State
		{
			None,
			Request,
			Wait
		}

		public VP<State> requestState;

		#endregion

		#region Constructor

		public enum Property
		{
			room,
			id,
			name,
			players,
			state,
			time,
			password,
			requestState
		}

		public UIData() : base()
		{
			this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
			// id
			{
				this.id = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.id, new RequestChangeStringUI.UIData());
				this.id.v.updateData.v.canRequestChange.v = false;
			}
			// name
			{
				this.name = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.name, new RequestChangeStringUI.UIData());
				this.name.v.updateData.v.canRequestChange.v = false;
			}
			// players
			{
				this.players = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.players, new RequestChangeStringUI.UIData());
				this.players.v.updateData.v.canRequestChange.v = false;
			}
			// state
			{
				this.state = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.state, new RequestChangeEnumUI.UIData());
				this.state.v.updateData.v.canRequestChange.v = false;
				// options
				foreach(Room.State.Type type in System.Enum.GetValues(typeof(Room.State.Type))){
					this.state.v.options.add(type.ToString());
				}
			}
			// time
			{
				this.time = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.time, new RequestChangeStringUI.UIData());
				this.time.v.updateData.v.canRequestChange.v = false;
			}
			// password
			{
				this.password = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.password, new RequestChangeStringUI.UIData());
				this.password.v.updateData.v.canRequestChange.v = true;
			}
			this.requestState = new VP<State>(this, (byte)Property.requestState, State.None);
		}

		#endregion

		public override Type getType ()
		{
			return Type.JoinRoom;
		}

		public void reset()
		{
			// password
			{
				this.password.v.updateData.v.origin.v = "";
				this.password.v.updateData.v.current.v = "";
			}
			// request state
			this.requestState.v = State.None;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						JoinRoomUI joinRoomUI = this.findCallBack<JoinRoomUI> ();
						if (joinRoomUI != null) {
							joinRoomUI.onClickBtnCancel ();
						} else {
							Debug.LogError ("joinRoomUI null: " + this);
						}
						isProcess = true;
					}
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();
	public Text tvCannotJoinRoom;
	public static readonly TxtLanguage txtCannotJoinRoom = new TxtLanguage();

	public static readonly TxtLanguage txtId = new TxtLanguage ();
	public static readonly TxtLanguage txtRoomName = new TxtLanguage();
	public static readonly TxtLanguage txtAdmin = new TxtLanguage();
	public static readonly TxtLanguage txtUserCount = new TxtLanguage ();
	public static readonly TxtLanguage txtCreate = new TxtLanguage ();

	public Text tvCancel;
	public static readonly TxtLanguage txtCancel = new TxtLanguage();

	public static readonly TxtLanguage txtJoinRoom = new TxtLanguage();
	public static readonly TxtLanguage txtCancelJoin = new TxtLanguage ();
	public static readonly TxtLanguage txtJoiningRoom = new TxtLanguage();
	public static readonly TxtLanguage txtCannotJoin = new TxtLanguage ();

	static JoinRoomUI()
	{
		txtTitle.add (Language.Type.vi, "Vào Phòng");
		txtCannotJoinRoom.add (Language.Type.vi, "Không thể vào phòng");
		txtId.add (Language.Type.vi, "Id");
		txtRoomName.add(Language.Type.vi, "Tên Phòng");
		txtAdmin.add(Language.Type.vi, "Admin");
		txtUserCount.add(Language.Type.vi, "số người dùng");
		txtCreate.add(Language.Type.vi, "Được tạo");
		txtCancel.add(Language.Type.vi, "Huỷ Bỏ");

		txtJoinRoom.add(Language.Type.vi, "Vào Phòng");
		txtCancelJoin.add(Language.Type.vi, "Huỷ Vào Phòng");
		txtJoiningRoom.add(Language.Type.vi, "Đang vào phòng");
		txtCannotJoin.add (Language.Type.vi, "Không thể vào ");
	}

	#endregion

	public GameObject cannotJoinIndicator;

	public Button btnJoin;
	public Text tvJoin;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Room room = this.data.room.v.data;
				if (room != null) {
					// join
					{
						bool isCanJoin = room.isCanJoinRoom (Server.getProfileUserId (room)) == Room.JoinRoomState.Can;
						// indicator
						if (cannotJoinIndicator != null) {
							cannotJoinIndicator.gameObject.SetActive (!isCanJoin);
						} else {
							Debug.LogError ("cannot joinIndicator null: " + this);
						}
						// Process
						if (isCanJoin) {
							// Task
							{
								switch (this.data.requestState.v) {
								case UIData.State.None:
									{
										destroyRoutine (wait);
									}
									break;
								case UIData.State.Request:
									{
										destroyRoutine (wait);
										// request
										if (Server.IsServerOnline (room)) {
											{
												uint profileId = Server.getProfileUserId (room);
												if (room.isCanJoinRoom (profileId) == Room.JoinRoomState.Can) {
													string password = "";
													{
														if (this.data.password.v != null) {
															password = this.data.password.v.updateData.v.current.v;
														} else {
															Debug.LogError ("password null: " + this);
														}
													}
													room.requestJoinRoom (profileId, password);
												} else {
													Debug.LogError ("Cannot join room: " + this);
												}
											}
											this.data.requestState.v = UIData.State.Wait;
										} else {
											Debug.LogError ("server not online: " + this);
										}
									}
									break;
								case UIData.State.Wait:
									{
										if (Server.IsServerOnline (room)) {
											startRoutine (ref this.wait, TaskWait ());
										} else {
											destroyRoutine (wait);
											this.data.requestState.v = UIData.State.None;
										}
									}
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.requestState.v + "; " + this);
									break;
								}
							}
							// UI
							{
								if (btnJoin != null && tvJoin != null) {
									switch (this.data.requestState.v) {
									case UIData.State.None:
										{
											btnJoin.enabled = true;
											tvJoin.text = txtJoinRoom.get ("Join Room");
										}
										break;
									case UIData.State.Request:
										{
											btnJoin.enabled = true;
											tvJoin.text = txtCancelJoin.get ("Cancel Join");
										}
										break;
									case UIData.State.Wait:
										{
											btnJoin.enabled = false;
											tvJoin.text = txtJoiningRoom.get ("Joining room...");
										}
										break;
									default:
										Debug.LogError ("unknown state: " + this.data.requestState.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("btnJoin, tvJoin null: " + this);
								}
							}
						} else {
							// Task
							{
								this.data.requestState.v = UIData.State.None;
								destroyRoutine (wait);
							}
							// UI
							{
								if (btnJoin != null && tvJoin != null) {
									btnJoin.enabled = false;
									tvJoin.text = txtCannotJoin.get ("Cannot Join");
								} else {
									Debug.LogError ("btnJoin, tvJoin null: " + this);
								}
							}
						}
					}
					// RoomInfo
					{
						// id
						{
							RequestChangeStringUI.UIData id = this.data.id.v;
							if (id != null) {
								RequestChangeStringUpdate.UpdateData updateData = id.updateData.v;
								if (updateData != null) {
									updateData.origin.v = txtId.get ("Id") + ": " + room.uid;
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("id null: " + this);
							}
						}
						// name
						{
							RequestChangeStringUI.UIData name = this.data.name.v;
							if (name != null) {
								RequestChangeStringUpdate.UpdateData updateData = name.updateData.v;
								if (updateData != null) {
									updateData.origin.v = txtRoomName.get ("Name") + ": " + room.name.v;
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("name null: " + this);
							}
						}
						// players
						{
							string strAdmin = "";
							{
								RoomUser admin = room.findAdmin ();
								if (admin != null) {
									Human adminHuman = admin.inform.v;
									if (adminHuman != null) {
										Account account = adminHuman.account.v;
										if (account != null) {
											strAdmin = account.getName ();
										} else {
											Debug.LogError ("account null: " + this);
										}
									} else {
										Debug.LogError ("adminHuman null: " + this);
									}
								} else {
									Debug.LogError ("admin null: " + this);
								}
							}
							int userCount = 0;
							{
								foreach (RoomUser roomUser in room.users.vs) {
									if (roomUser.isInsideRoom ()) {
										userCount++;
									}
								}
							}
							// request
							RequestChangeStringUI.UIData players = this.data.players.v;
							if (players != null) {
								RequestChangeStringUpdate.UpdateData updateData = players.updateData.v;
								if (updateData != null) {
									updateData.origin.v = txtAdmin.get ("Admin") + ": " + strAdmin + "; " + txtUserCount.get ("user count") + ": " + userCount;
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("players null: " + this);
							}
						}
						// state
						{
							RequestChangeEnumUI.UIData state = this.data.state.v;
							if (state != null) {
								RequestChangeIntUpdate.UpdateData updateData = state.updateData.v;
								if (updateData != null) {
									updateData.origin.v = (int)room.state.v.getType ();
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("state null: " + this);
							}
						}
						// time
						{
							RequestChangeStringUI.UIData time = this.data.time.v;
							if (time != null) {
								RequestChangeStringUpdate.UpdateData updateData = time.updateData.v;
								if (updateData != null) {
									updateData.origin.v = txtCreate.get ("Created") + " " + room.timeCreated.v;
								} else {
									Debug.LogError ("updateData null: " + this);
								}
							} else {
								Debug.LogError ("time null: " + this);
							}
						}
					}
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Join Room");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvCannotJoinRoom != null) {
						tvCannotJoinRoom.text = txtCannotJoinRoom.get ("Cannot join room");
					} else {
						Debug.LogError ("tvCannotJoinRoom null: " + this);
					}
					if (tvCancel != null) {
						tvCancel.text = txtCancel.get ("Cancel");
					} else {
						Debug.LogError ("tvCancel null: " + this);
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

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			if (this.data != null) {
				this.data.requestState.v = UIData.State.None;
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

	#region implement callback

	public RequestChangeStringUI requestStringPrefab;
	public RequestChangeEnumUI requestEnumPrefab;

	public Transform idContainer;
	public Transform nameContainer;
	public Transform playersContainer;
	public Transform stateContainer;
	public Transform timeContainer;
	public Transform passwordContainer;

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.room.allAddCallBack (this);
				uiData.id.allAddCallBack (this);
				uiData.name.allAddCallBack (this);
				uiData.players.allAddCallBack (this);
				uiData.state.allAddCallBack (this);
				uiData.time.allAddCallBack (this);
				uiData.password.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		// Child
		{
			// Room
			{
				if (data is Room) {
					Room room = data as Room;
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
						DataUtils.addParentCallBack (room, this, ref this.server);
					}
					// Child
					{
						room.users.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Parent
				if (data is Server) {
					dirty = true;
					return;
				}
				// Child
				{
					if (data is RoomUser) {
						RoomUser roomUser = data as RoomUser;
						// Child
						{
							roomUser.inform.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is Human) {
							Human human = data as Human;
							// Child
							{
								human.account.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						if (data is Account) {
							dirty = true;
							return;
						}
					}
				}
			}
			// id, name, players, time, password
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.id:
							UIUtils.Instantiate (requestChange, requestStringPrefab, idContainer);
							break;
						case UIData.Property.name:
							UIUtils.Instantiate (requestChange, requestStringPrefab, nameContainer);
							break;
						case UIData.Property.players:
							UIUtils.Instantiate (requestChange, requestStringPrefab, playersContainer);
							break;
						case UIData.Property.time:
							UIUtils.Instantiate (requestChange, requestStringPrefab, timeContainer);
							break;
						case UIData.Property.password:
							UIUtils.Instantiate (requestChange, requestStringPrefab, passwordContainer);
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("wrapProperty null: " + this);
					}
				}
				dirty = true;
				return;
			}
			// state
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.state:
							UIUtils.Instantiate (requestChange, requestEnumPrefab, stateContainer);
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("wrapProperty null: " + this);
					}
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
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.room.allRemoveCallBack (this);
				uiData.id.allRemoveCallBack (this);
				uiData.name.allRemoveCallBack (this);
				uiData.players.allRemoveCallBack (this);
				uiData.state.allRemoveCallBack (this);
				uiData.time.allRemoveCallBack (this);
				uiData.password.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Child
		{
			// Room
			{
				if (data is Room) {
					Room room = data as Room;
					// Parent
					{
						DataUtils.removeParentCallBack (room, this, ref this.server);
					}
					// Child
					{
						room.users.allRemoveCallBack (this);
					}
					return;
				}
				// Parent
				if (data is Server) {
					return;
				}
				// Child
				{
					if (data is RoomUser) {
						RoomUser roomUser = data as RoomUser;
						// Child
						{
							roomUser.inform.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is Human) {
							Human human = data as Human;
							// Child
							{
								human.account.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						if (data is Account) {
							return;
						}
					}
				}
			}
			// id, name, players, time
			if (data is RequestChangeStringUI.UIData) {
				RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeStringUI));
				}
				return;
			}
			// state
			if (data is RequestChangeEnumUI.UIData) {
				RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
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
			case UIData.Property.room:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.id:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.name:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.players:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.time:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.password:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.requestState:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Setting
		if (wrapProperty.p is Setting) {
			switch ((Setting.Property)wrapProperty.n) {
			case Setting.Property.language:
				dirty = true;
				break;
			case Setting.Property.showLastMove:
				break;
			case Setting.Property.viewUrlImage:
				break;
			case Setting.Property.animationSetting:
				break;
			case Setting.Property.maxThinkCount:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			// Room
			{
				if (wrapProperty.p is Room) {
					switch ((Room.Property)wrapProperty.n) {
					case Room.Property.changeRights:
						break;
					case Room.Property.name:
						dirty = true;
						break;
					case Room.Property.password:
						break;
					case Room.Property.users:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Room.Property.state:
						dirty = true;
						break;
					case Room.Property.contestManagers:
						break;
					case Room.Property.timeCreated:
						dirty = true;
						break;
					case Room.Property.chatRoom:
						break;
					case Room.Property.allowHint:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				if (wrapProperty.p is Server) {
					Server.State.OnUpdateSyncStateChange (wrapProperty, this);
					return;
				}
				// Child
				{
					if (wrapProperty.p is RoomUser) {
						switch ((RoomUser.Property)wrapProperty.n) {
						case RoomUser.Property.role:
							dirty = true;
							break;
						case RoomUser.Property.inform:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RoomUser.Property.state:
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
						if (wrapProperty.p is Human) {
							switch ((Human.Property)wrapProperty.n) {
							case Human.Property.playerId:
								break;
							case Human.Property.account:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
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
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						if (wrapProperty.p is Account) {
							Account.OnUpdateSyncAccount (wrapProperty, this);
							return;
						}
					}
				}
			}
			// id, name, players, time
			if (wrapProperty.p is RequestChangeStringUI.UIData) {
				return;
			}
			// state
			if (wrapProperty.p is RequestChangeEnumUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnJoin()
	{
		if (this.data != null) {
			if (this.data.requestState.v == UIData.State.None) {
				this.data.requestState.v = UIData.State.Request;
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
			RoomListUI.UIData roomListUIData = this.data.findDataInParent<RoomListUI.UIData> ();
			if (roomListUIData != null) {
				roomListUIData.sub.v = null;
			} else {
				Debug.LogError ("roomListUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}