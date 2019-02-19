using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomHolder : SriaHolderBehavior<RoomHolder.UIData>
{

	#region UIData

	public class UIData : BaseItemViewsHolder
	{
		
		public VP<ReferenceData<Room>> room;

		#region Constructor

		public enum Property
		{
			room
		}

		public UIData() : base()
		{
			this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
		}

		#endregion

		public void updateView(RoomAdapter.UIData myParams)
		{
			// Find
			Room room = null;
			{
				if (ItemIndex >= 0 && ItemIndex < myParams.rooms.Count) {
					room = myParams.rooms [ItemIndex];
				} else {
					Debug.LogError ("ItemIdex error: " + this);
				}
			}
			// Update
			this.room.v = new ReferenceData<Room> (room);
		}

	}

	#endregion

	#region Refresh

	public Text tvId;

	public Text tvName;

	public Text tvPlayers;

	public Text tvState;

	public Text tvTime;

	public Text tvGameType;
	public Text tvContestManagerState;

    public Image imgPassword;

	#region txt

	public Text tvCanJoinRoom;
	private static readonly TxtLanguage txtCannotJoinRoom = new TxtLanguage();
    private static readonly TxtLanguage txtCanJoinRoom = new TxtLanguage();

	private static readonly TxtLanguage txtId = new TxtLanguage ();
	private static readonly TxtLanguage txtName = new TxtLanguage();
	private static readonly TxtLanguage txtAdmin = new TxtLanguage ();
	private static readonly TxtLanguage txtUserCount = new TxtLanguage();

	private static readonly TxtLanguage txtStateNormal = new TxtLanguage();
	private static readonly TxtLanguage txtStateFreeze = new TxtLanguage ();
	private static readonly TxtLanguage txtStateEnd = new TxtLanguage();

	private static readonly TxtLanguage txtCreated = new TxtLanguage ();
	private static readonly TxtLanguage txtGameType = new TxtLanguage();

	private static readonly TxtLanguage txtState = new TxtLanguage();

	static RoomHolder()
	{
		txtCannotJoinRoom.add (Language.Type.vi, "Không Thể Vào");
        txtCanJoinRoom.add(Language.Type.vi, "Có Thể Vào");

		txtId.add (Language.Type.vi, "Id");
		txtName.add (Language.Type.vi, "Tên");
		txtAdmin.add (Language.Type.vi, "Admin");
		txtUserCount.add (Language.Type.vi, "Số người dùng");
		txtStateNormal.add (Language.Type.vi, "Bình thường");
		txtStateFreeze.add (Language.Type.vi, "Đóng băng");
		txtStateEnd.add (Language.Type.vi, "Kết thúc");
		txtCreated.add (Language.Type.vi, "Tạo ra");
		txtGameType.add (Language.Type.vi, "Trò");
		txtState.add (Language.Type.vi, "Trạng thái");
	}

    #endregion

    public static readonly Color CanJoinColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
    public static readonly Color CannotJoinColor = Color.red;

    public override void refresh ()
	{
		base.refresh ();
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Room room = this.data.room.v.data;
				if (room != null) {
                    GameType.Type gameType = GameType.Type.CHESS;
                    {
                        RoomInform roomInform = room.roomInform.v;
                        if (roomInform != null)
                        {
                            gameType = roomInform.gameType.v;
                        }
                        else
                        {
                            Debug.LogError("roomInform null: " + this);
                        }
                    }
                    // cannot join
                    {
						if (tvCanJoinRoom != null) {
                            if(room.isCanJoinRoom(Server.getProfileUserId(room)) != Room.JoinRoomState.Can)
                            {
                                tvCanJoinRoom.text = txtCannotJoinRoom.get("Cannot Join");
                                tvCanJoinRoom.color = CannotJoinColor;
                            }
                            else
                            {
                                tvCanJoinRoom.text = txtCanJoinRoom.get("Can Join");
                                tvCanJoinRoom.color = CanJoinColor;
                            }
						} else {
							Debug.LogError ("tvCannotJoinRoom null: " + this);
						}
					}
					// tvId
					{
						if (tvId != null) {
							tvId.text = txtId.get ("Id") + ": " + room.uid;
						} else {
							Debug.LogError ("tvId null: " + this);
						}
					}
					// name
					{
						if (tvName != null) {
                            if (string.IsNullOrEmpty(room.name.v))
                            {
                                tvName.text = GameType.GetStrGameType(gameType);
                            }
                            else
                            {
                                tvName.text = room.name.v;
                            }
						} else {
							Debug.LogError ("tvName null: " + this);
						}
					}
					// players
					{
						if (tvPlayers != null) {
							// find
							string strCreator = "";
							uint userCount = 0;
							// set
							{
								RoomInform roomInform = room.roomInform.v;
								if (roomInform != null) {
									// creator
									{
										Human creator = roomInform.creator.v;
										if (creator != null) {
											strCreator = creator.getPlayerName ();
										} else {
											Debug.LogError ("creator null: " + this);
										}
									}
									userCount = roomInform.userCount.v;
								} else {
									Debug.LogError ("roomInform null: " + this);
								}
							}
							tvPlayers.text = txtAdmin.get ("Admin") + ": " + strCreator
							+ "; " + txtUserCount.get ("user count") + ": " + userCount;
						} else {
							Debug.LogError ("tvPlayers null: " + this);
						}
					}
					// state
					{
						if (tvState != null) {
							Room.State state = room.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case Room.State.Type.Normal:
									{
										RoomStateNormal normal = state as RoomStateNormal;
										// state
										{
											RoomStateNormal.State normalState = normal.state.v;
											if (normalState != null) {
												switch (normalState.getType ()) {
												case RoomStateNormal.State.Type.Normal:
													tvState.text = txtStateNormal.get ("Normal");
													break;
												case RoomStateNormal.State.Type.Freeze:
													tvState.text = txtStateFreeze.get ("Freeze");
													break;
												default:
													Debug.LogError ("unkown type: " + normalState.getType () + "; " + this);
													break;
												}
											} else {
												Debug.LogError ("normalState null: " + this);
											}
										}
									}
									break;
								case Room.State.Type.End:
									{
										tvState.text = txtStateEnd.get ("End");
									}
									break;
								default:
									Debug.LogError ("unknown type: " + state.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("state null: " + this);
							}
						} else {
							Debug.LogError ("tvState null: " + this);
						}
					}
					// time
					{
						if (tvTime != null) {
                            tvTime.text = txtCreated.get("created") + ": " + Global.getStrTime(room.timeCreated.v);
						} else {
							Debug.LogError ("tvTime null: " + this);
						}
					}
					// tvGameType
					{
						if (tvGameType != null) {
                            // tvGameType.text = txtGameType.get ("GameType") + ": " + gameType;
                            tvGameType.text = GameType.GetStrGameType(gameType);
                        } else {
							Debug.LogError ("tvGameType null: " + this);
						}
					}
					// tvContestManagerState
					{
						if (tvContestManagerState != null) {
							ContestManager.State.Type contestManagerState = ContestManager.State.Type.Lobby;
							{
								RoomInform roomInform = room.roomInform.v;
								if (roomInform != null) {
									contestManagerState = roomInform.contestStateType.v;
								} else {
									Debug.LogError ("roomInform null: " + this);
								}
							}
							tvContestManagerState.text = txtState.get("State")+": " + contestManagerState;
						} else {
							Debug.LogError ("tvContestManagerState null: " + this);
						}
					}
					// imgPassword
					{
						if (imgPassword != null) {
							bool isHavePassword = false;
							{
								RoomInform roomInform = room.roomInform.v;
								if (roomInform != null) {
									isHavePassword = roomInform.isHavePassword.v;
								} else {
									Debug.LogError ("roomInform null: " + this);
								}
							}
                            imgPassword.gameObject.SetActive(isHavePassword);
						} else {
							Debug.LogError ("tvHavePassword null: " + this);
						}
					}
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement callback

	private RoomCheckChangeAdminChange<Room> roomCheckAdminChange = new RoomCheckChangeAdminChange<Room>();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.room.allAddCallBack (this);
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
			if (data is Room) {
				Room room = data as Room;
				// CheckChange
				{
					roomCheckAdminChange.addCallBack (this);
					roomCheckAdminChange.setData (room);
				}
				// Child
				{
					room.roomInform.allAddCallBack (this);
					room.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is RoomCheckChangeAdminChange<Room>) {
				dirty = true;
				return;
			}
			// Child
			{
				// roomInform
				{
					if (data is RoomInform) {
						RoomInform roomInform = data as RoomInform;
						// Child
						{
							roomInform.creator.allAddCallBack (this);
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
				// state
				{
					if (data is Room.State) {
						Room.State state = data as Room.State;
						// Child
						{
							switch (state.getType ()) {
							case Room.State.Type.Normal:
								{
									RoomStateNormal roomStateNormal = state as RoomStateNormal;
									roomStateNormal.state.allAddCallBack (this);
								}
								break;
							case Room.State.Type.End:
								{
									// RoomStateEnd roomStateEnd = state as RoomStateEnd;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + state.getType () + "; " + this);
								break;
							}
						}
						dirty = true;
						return;
					}
					// Child
					if (data is RoomStateNormal.State) {
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
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.room.allRemoveCallBack (this);
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
			if (data is Room) {
				Room room = data as Room;
				// CheckChange
				{
					roomCheckAdminChange.removeCallBack (this);
					roomCheckAdminChange.setData (null);
				}
				// Child
				{
					room.roomInform.allRemoveCallBack (this);
					room.state.allRemoveCallBack (this);
				}
				return;
			}
			// CheckChange
			if (data is RoomCheckChangeAdminChange<Room>) {
				return;
			}
			// Child
			{
				// roomInform
				{
					if (data is RoomInform) {
						RoomInform roomInform = data as RoomInform;
						// Child
						{
							roomInform.creator.allRemoveCallBack (this);
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
				// state
				{
					if (data is Room.State) {
						Room.State state = data as Room.State;
						// Child
						{
							switch (state.getType ()) {
							case Room.State.Type.Normal:
								{
									RoomStateNormal roomStateNormal = state as RoomStateNormal;
									roomStateNormal.state.allRemoveCallBack (this);
								}
								break;
							case Room.State.Type.End:
								{
									// RoomStateEnd roomStateEnd = state as RoomStateEnd;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + state.getType () + "; " + this);
								break;
							}
						}
						return;
					}
					// Child
					if (data is RoomStateNormal.State) {
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
			case UIData.Property.room:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
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
			if (wrapProperty.p is Room) {
				switch ((Room.Property)wrapProperty.n) {
				case Room.Property.roomInform:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Room.Property.changeRights:
					break;
				case Room.Property.name:
					dirty = true;
					break;
				case Room.Property.password:
					break;
				case Room.Property.users:
					break;
				case Room.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Room.Property.requestNewContestManager:
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
			// CheckChange
			if (wrapProperty.p is RoomCheckChangeAdminChange<Room>) {
				dirty = true;
				return;
			}
			// Child
			{
				// roomInform
				{
					if (wrapProperty.p is RoomInform) {
						switch ((RoomInform.Property)wrapProperty.n) {
						case RoomInform.Property.creator:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case RoomInform.Property.userCount:
							dirty = true;
							break;
						case RoomInform.Property.isHavePassword:
							dirty = true;
							break;
						case RoomInform.Property.contestStateType:
							dirty = true;
							break;
						case RoomInform.Property.gameType:
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
							case Human.Property.ban:
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
				// state
				{
					if (wrapProperty.p is Room.State) {
						Room.State state = wrapProperty.p as Room.State;
						// Child
						{
							switch (state.getType ()) {
							case Room.State.Type.Normal:
								{
									switch ((RoomStateNormal.Property)wrapProperty.n) {
									case RoomStateNormal.Property.state:
										{
											ValueChangeUtils.replaceCallBack (this, syncs);
											dirty = true;
										}
										break;
									default:
										Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
										break;
									}
								}
								break;
							case Room.State.Type.End:
								{
									// RoomStateEnd roomStateEnd = state as RoomStateEnd;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + state.getType () + "; " + this);
								break;
							}
						}
						return;
					}
					// Child
					if (wrapProperty.p is RoomStateNormal.State) {
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	#region Click Button

	public void OnClickCell()
	{
		if (this.data != null) {
			Room room = this.data.room.v.data;
			if (room != null) {
				RoomListUI.UIData roomListUIData = this.data.findDataInParent<RoomListUI.UIData> ();
				if (roomListUIData != null) {
					JoinRoomUI.UIData joinRoomUIData = roomListUIData.sub.newOrOld<JoinRoomUI.UIData> ();
					{
						joinRoomUIData.room.v = new ReferenceData<Room> (room);
					}
					roomListUIData.sub.v = joinRoomUIData;
				} else {
					Debug.LogError ("roomListUIData null: " + this);
				}
			} else {
				Debug.LogError ("room null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#endregion
}