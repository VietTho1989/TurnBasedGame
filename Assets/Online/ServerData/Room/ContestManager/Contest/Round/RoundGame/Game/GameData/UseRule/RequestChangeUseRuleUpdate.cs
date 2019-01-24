using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleUpdate : UpdateBehavior<RequestChangeUseRule>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				HashSet<uint> whoCanAsks = this.data.getWhoCanAsk();
				// update human
				{
					// get old
					List<Human> oldHumans = new List<Human> ();
					{
						oldHumans.AddRange (this.data.whoCanAsks.vs);
					}
					// Update
					{
						foreach (uint userId in whoCanAsks) {
							// find Human
							Human human = null;
							{
								// find old
								if (oldHumans.Count > 0) {
									human = oldHumans [0];
								}
								// make new
								if (human == null) {
									human = new Human ();
									{
										human.uid = this.data.whoCanAsks.makeId ();
									}
									this.data.whoCanAsks.add (human);
								} else {
									oldHumans.Remove (human);
								}
							}
							// Update
							{
								human.playerId.v = userId;
							}
						}
					}
					// Remove old
					foreach (Human oldHuman in oldHumans) {
						this.data.whoCanAsks.remove (oldHuman);
					}
				}
				// state
				{
					if (whoCanAsks.Count == 0) {
						// nobody can ask
						RequestChangeUseRuleStateNone none = this.data.state.newOrOld<RequestChangeUseRuleStateNone> ();
						{
							// ko can
						}
						this.data.state.v = none;
					} else {
						if (this.data.state.v.getType () == RequestChangeUseRule.State.Type.Ask) {
							// needAccept?
							bool needAccept = true;
							{
								Room room = this.data.findDataInParent<Room> ();
								if (room != null) {
									Rights.ChangeRights changeRights = room.changeRights.v;
									if (changeRights != null) {
										ChangeUseRuleRight changeUseRuleRight = changeRights.changeUseRuleRight.v;
										if (changeUseRuleRight != null) {
											needAccept = changeUseRuleRight.needAccept.v;
										} else {
											Debug.LogError ("changeUseRuleRight null: " + this);
										}
									} else {
										Debug.LogError ("changeRights null: " + this);
									}
								} else {
									Debug.LogError ("room null: " + this);
								}
							}
							// Process
							if (!needAccept) {
								// change use rule
								{
									GameData gameData = this.data.findDataInParent<GameData> ();
									if (gameData != null) {
										gameData.useRule.v = !gameData.useRule.v;
									} else {
										Debug.LogError ("gameData null: " + this);
									}
								}
								// change to none
								RequestChangeUseRuleStateNone none = this.data.state.newOrOld<RequestChangeUseRuleStateNone> ();
								{

								}
								this.data.state.v = none;
							}
						}
					}
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

	#region implement callBacks

	private RoomCheckChangeAdminChange<RequestChangeUseRule> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestChangeUseRule> ();
	private GameCheckPlayerChange<RequestChangeUseRule> gameCheckPlayerChange = new GameCheckPlayerChange<RequestChangeUseRule> ();

	private Room room = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is RequestChangeUseRule) {
			RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
			// CheckChange
			{
				// roomAdmin
				{
					roomCheckAdminChange.addCallBack (this);
					roomCheckAdminChange.setData (requestChangeUseRule);
				}
				// gamePlayer
				{
					gameCheckPlayerChange.addCallBack (this);
					gameCheckPlayerChange.setData (requestChangeUseRule);
				}
			}
			// Parent
			{
				DataUtils.addParentCallBack (requestChangeUseRule, this, ref this.room);
			}
			// Child
			{
				requestChangeUseRule.state.allAddCallBack (this);
				requestChangeUseRule.whoCanAsks.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// CheckChange
		{
			if (data is RoomCheckChangeAdminChange<RequestChangeUseRule>) {
				dirty = true;
				return;
			}
			if (data is GameCheckPlayerChange<RequestChangeUseRule>) {
				dirty = true;
				return;
			}
		}
		// Parent
		{
			if (data is Room) {
				Room room = data as Room;
				// Child
				{
					room.changeRights.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Rights.ChangeRights) {
					Rights.ChangeRights changeRights = data as Rights.ChangeRights;
					// Child
					{
						changeRights.changeUseRuleRight.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is ChangeUseRuleRight) {
					dirty = true;
					return;
				}
			}
		}
		// Child
		{
			if (data is RequestChangeUseRule.State) {
				RequestChangeUseRule.State state = data as RequestChangeUseRule.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestChangeUseRule.State.Type.None:
						{
							RequestChangeUseRuleStateNone none = state as RequestChangeUseRuleStateNone;
							UpdateUtils.makeUpdate<RequestChangeUseRuleStateNoneUpdate, RequestChangeUseRuleStateNone> (none, this.transform);
						}
						break;
					case RequestChangeUseRule.State.Type.Ask:
						{
							RequestChangeUseRuleStateAsk ask = state as RequestChangeUseRuleStateAsk;
							UpdateUtils.makeUpdate<RequestChangeUseRuleStateAskUpdate, RequestChangeUseRuleStateAsk> (ask, this.transform);
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
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RequestChangeUseRule) {
			RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
			// CheckChange
			{
				// roomAdmin
				{
					roomCheckAdminChange.removeCallBack (this);
					roomCheckAdminChange.setData (null);
				}
				// gamePlayer
				{
					gameCheckPlayerChange.removeCallBack (this);
					gameCheckPlayerChange.setData (null);
				}
			}
			// Parent
			{
				DataUtils.removeParentCallBack (requestChangeUseRule, this, ref this.room);
			}
			// Child
			{
				requestChangeUseRule.state.allRemoveCallBack (this);
				requestChangeUseRule.whoCanAsks.allRemoveCallBack (this);
			}
			this.setDataNull (requestChangeUseRule);
			return;
		}
		// CheckChange
		{
			if (data is RoomCheckChangeAdminChange<RequestChangeUseRule>) {
				return;
			}
			if (data is GameCheckPlayerChange<RequestChangeUseRule>) {
				return;
			}
		}
		// Parent
		{
			if (data is Room) {
				Room room = data as Room;
				// Child
				{
					room.changeRights.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is Rights.ChangeRights) {
					Rights.ChangeRights changeRights = data as Rights.ChangeRights;
					// Child
					{
						changeRights.changeUseRuleRight.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is ChangeUseRuleRight) {
					return;
				}
			}
		}
		// Child
		{
			if (data is RequestChangeUseRule.State) {
				RequestChangeUseRule.State state = data as RequestChangeUseRule.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestChangeUseRule.State.Type.None:
						{
							RequestChangeUseRuleStateNone none = state as RequestChangeUseRuleStateNone;
							none.removeCallBackAndDestroy (typeof(RequestChangeUseRuleStateNoneUpdate));
						}
						break;
					case RequestChangeUseRule.State.Type.Ask:
						{
							RequestChangeUseRuleStateAsk ask = state as RequestChangeUseRuleStateAsk;
							ask.removeCallBackAndDestroy (typeof(RequestChangeUseRuleStateAskUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					human.removeCallBackAndDestroy (typeof(HumanUpdate));
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
		if (wrapProperty.p is RequestChangeUseRule) {
			switch ((RequestChangeUseRule.Property)wrapProperty.n) {
			case RequestChangeUseRule.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case RequestChangeUseRule.Property.whoCanAsks:
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
		// CheckChange
		{
			if (wrapProperty.p is RoomCheckChangeAdminChange<RequestChangeUseRule>) {
				dirty = true;
				return;
			}
			if (wrapProperty.p is GameCheckPlayerChange<RequestChangeUseRule>) {
				dirty = true;
				return;
			}
		}
		// Parent
		{
			if (wrapProperty.p is Room) {
				switch ((Room.Property)wrapProperty.n) {
				case Room.Property.roomInform:
					break;
				case Room.Property.changeRights:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Room.Property.name:
					break;
				case Room.Property.password:
					break;
				case Room.Property.users:
					break;
				case Room.Property.state:
					break;
				case Room.Property.requestNewContestManager:
					break;
				case Room.Property.contestManagers:
					break;
				case Room.Property.timeCreated:
					break;
				case Room.Property.chatRoom:
					break;
				case Room.Property.allowHint:
					break;
				case Room.Property.allowLoadHistory:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is Rights.ChangeRights) {
					switch ((Rights.ChangeRights.Property)wrapProperty.n) {
					case Rights.ChangeRights.Property.undoRedoRight:
						break;
					case Rights.ChangeRights.Property.changeGamePlayerRight:
						break;
					case Rights.ChangeRights.Property.changeUseRuleRight:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is ChangeUseRuleRight) {
					switch ((ChangeUseRuleRight.Property)wrapProperty.n) {
					case ChangeUseRuleRight.Property.canChange:
						dirty = true;
						break;
					case ChangeUseRuleRight.Property.onlyAdmin:
						dirty = true;
						break;
					case ChangeUseRuleRight.Property.needAdmin:
						dirty = true;
						break;
					case ChangeUseRuleRight.Property.needAccept:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
		}
		// Child
		{
			if (wrapProperty.p is RequestChangeUseRule.State) {
				return;
			}
			if (wrapProperty.p is Human) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}