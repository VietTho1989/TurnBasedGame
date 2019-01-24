using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class NoRequestSwapPlayerUI : UIBehavior<NoRequestSwapPlayerUI.UIData>
	{

		#region UIData

		public class UIData : SwapPlayerInformUI.UIData.Sub
		{

			public VP<ReferenceData<TeamPlayer>> teamPlayer;

			#region Sub

			public abstract class Sub : Data
			{

				public abstract RoomUser.Role getType();

			}

			public VP<Sub> sub;

			#endregion

			#region Constructor

			public enum Property
			{
				teamPlayer,
				sub
			}

			public UIData() : base()
			{
				this.teamPlayer = new VP<ReferenceData<TeamPlayer>>(this, (byte)Property.teamPlayer, new ReferenceData<TeamPlayer>(null));
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
			}

			#endregion

			public override Type getType ()
			{
				return Type.NoRequest;
			}

		}

		#endregion

		#region Refresh

		public GameObject notAllowSwap;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
					if (teamPlayer != null) {
						// room allow to swap?
						{
							if (notAllowSwap != null) {
								// find
								bool roomAllowSwap = true;
								{
									Room room = teamPlayer.findDataInParent<Room> ();
									if (room != null) {
										Rights.ChangeRights changeRights = room.changeRights.v;
										if (changeRights != null) {
											ChangeGamePlayerRight changeGamePlayerRight = changeRights.changeGamePlayerRight.v;
											if (changeGamePlayerRight != null) {
												roomAllowSwap = changeGamePlayerRight.canChange.v;
											} else {
												Debug.LogError ("changeGamePlayerRight null: " + this);
											}
										} else {
											Debug.LogError ("changeRights null: " + this);
										}
									} else {
										Debug.LogError ("room null: " + this);
									}
								}
								// process
								notAllowSwap.SetActive(!roomAllowSwap);
							} else {
								Debug.LogError ("not allow swap: " + this);
							}
						}
						// sub
						{
							if (Room.isYouAdmin (teamPlayer)) {
								// admin
								AdminRequestSwapPlayerUI.UIData adminRequestSwapPlayerUIData = this.data.sub.newOrOld<AdminRequestSwapPlayerUI.UIData>();
								{
									adminRequestSwapPlayerUIData.teamPlayer.v = new ReferenceData<TeamPlayer> (teamPlayer);
								}
								this.data.sub.v = adminRequestSwapPlayerUIData;
							} else {
								// normal
								NormalRequestSwapPlayerUI.UIData normalRequestSwapPlayerUIData = this.data.sub.newOrOld<NormalRequestSwapPlayerUI.UIData>();
								{
									normalRequestSwapPlayerUIData.teamPlayer.v = new ReferenceData<TeamPlayer> (teamPlayer);
								}
								this.data.sub.v = normalRequestSwapPlayerUIData;
							}
						}
					} else {
						Debug.LogError ("teamPlayer null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public AdminRequestSwapPlayerUI adminRequestSwapPlayerPrefab;
		public NormalRequestSwapPlayerUI normalRequestSwapPlayerPrefab;
		public Transform subContainer;

		private RoomCheckChangeAdminChange<TeamPlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<TeamPlayer> ();
		private Room room = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.teamPlayer.allAddCallBack (this);
					uiData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// teamPlayer
				{
					if (data is TeamPlayer) {
						TeamPlayer teamPlayer = data as TeamPlayer;
						// CheckChange
						{
							roomCheckAdminChange.addCallBack (this);
							roomCheckAdminChange.setData (teamPlayer);
						}
						// Parent
						{
							DataUtils.addParentCallBack (teamPlayer, this, ref this.room);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is RoomCheckChangeAdminChange<TeamPlayer>) {
						dirty = true;
						return;
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
									changeRights.changeGamePlayerRight.allAddCallBack (this);
								}
								dirty = true;
								return;
							}
							// Child
							if (data is ChangeGamePlayerRight) {
								dirty = true;
								return;
							}
						}
					}
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RoomUser.Role.ADMIN:
							{
								AdminRequestSwapPlayerUI.UIData adminRequestSwapPlayerUIData = sub as AdminRequestSwapPlayerUI.UIData;
								UIUtils.Instantiate (adminRequestSwapPlayerUIData, adminRequestSwapPlayerPrefab, subContainer);
							}
							break;
						case RoomUser.Role.NORMAL:
							{
								NormalRequestSwapPlayerUI.UIData normalRequestSwapPlayerUIData = sub as NormalRequestSwapPlayerUI.UIData;
								UIUtils.Instantiate (normalRequestSwapPlayerUIData, normalRequestSwapPlayerPrefab, subContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
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
				// Child
				{
					uiData.teamPlayer.allRemoveCallBack (this);
					uiData.sub.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				// teamPlayer
				{
					if (data is TeamPlayer) {
						TeamPlayer teamPlayer = data as TeamPlayer;
						// CheckChange
						{
							roomCheckAdminChange.removeCallBack (this);
							roomCheckAdminChange.setData (null);
						}
						// Parent
						{
							DataUtils.removeParentCallBack (teamPlayer, this, ref this.room);
						}
						return;
					}
					// CheckChange
					if (data is RoomCheckChangeAdminChange<TeamPlayer>) {
						return;
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
									changeRights.changeGamePlayerRight.allRemoveCallBack (this);
								}
								return;
							}
							// Child
							if (data is ChangeGamePlayerRight) {
								return;
							}
						}
					}
				}
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case RoomUser.Role.ADMIN:
							{
								AdminRequestSwapPlayerUI.UIData adminRequestSwapPlayerUIData = sub as AdminRequestSwapPlayerUI.UIData;
								adminRequestSwapPlayerUIData.removeCallBackAndDestroy (typeof(AdminRequestSwapPlayerUI));
							}
							break;
						case RoomUser.Role.NORMAL:
							{
								NormalRequestSwapPlayerUI.UIData normalRequestSwapPlayerUIData = sub as NormalRequestSwapPlayerUI.UIData;
								normalRequestSwapPlayerUIData.removeCallBackAndDestroy (typeof(NormalRequestSwapPlayerUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
						}
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
				case UIData.Property.teamPlayer:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.sub:
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
			// Child
			{
				// teamPlayer
				{
					if (wrapProperty.p is TeamPlayer) {
						return;
					}
					// CheckChange
					if (wrapProperty.p is RoomCheckChangeAdminChange<TeamPlayer>) {
						dirty = true;
						return;
					}
					// Parent
					{
						if (wrapProperty.p is Room) {
							switch ((Room.Property)wrapProperty.n) {
							case Room.Property.changeRights:
								{
									ValueChangeUtils.replaceCallBack(this, syncs);
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
							if (wrapProperty.p is ChangeGamePlayerRight) {
								switch ((ChangeGamePlayerRight.Property)wrapProperty.n) {
								case ChangeGamePlayerRight.Property.canChange:
									dirty = true;
									break;
								case ChangeGamePlayerRight.Property.canChangePlayerLeft:
									break;
								case ChangeGamePlayerRight.Property.needAdminAccept:
									break;
								case ChangeGamePlayerRight.Property.onlyAdminNeed:
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
						}
					}
				}
				if (wrapProperty.p is UIData.Sub) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}