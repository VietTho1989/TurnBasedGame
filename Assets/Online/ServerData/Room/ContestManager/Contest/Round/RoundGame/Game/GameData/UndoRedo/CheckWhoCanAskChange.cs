using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rights;

namespace UndoRedo
{
	public class CheckWhoCanAskChange<K> : Data, ValueChangeCallBack where K : Data
	{

		public VP<int> change;

		private void notifyChange()
		{
			this.change.v = this.change.v + 1;
		}

		#region Constructor

		public enum Property
		{
			change
		}

		public CheckWhoCanAskChange() : base()
		{
			this.change = new VP<int> (this, (byte)Property.change, 0);
		}

		#endregion

		public K data;

		public void setData(K newData){
			if (this.data != newData) {
				// remove old
				{
					DataUtils.removeParentCallBack (this.data, this, ref this.undoRedoRequest);
				}
				// set new 
				{
					this.data = newData;
					DataUtils.addParentCallBack (this.data, this, ref this.undoRedoRequest);
				}
			} else {
				Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
			}
		}

		#region implement callBacks

		private UndoRedoRequest undoRedoRequest = null;

		private RoomCheckChangeAdminChange<UndoRedoRequest> roomCheckAdminChange = new RoomCheckChangeAdminChange<UndoRedoRequest>();
		private GameCheckPlayerChange<UndoRedoRequest> gameCheckPlayerChange = new GameCheckPlayerChange<UndoRedoRequest>();

		private Room room = null;

		public void onAddCallBack<T> (T data) where T:Data
		{
			if (data is UndoRedoRequest) {
				UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
				// CheckChange
				{
					// room admin
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (undoRedoRequest);
					}
					// gamePlayer
					{
						gameCheckPlayerChange.addCallBack (this);
						gameCheckPlayerChange.setData (undoRedoRequest);
					}
				}
				// Parent
				{
					DataUtils.addParentCallBack (undoRedoRequest, this, ref this.room);
				}
				this.notifyChange ();
				return;
			}
			// CheckChange
			{
				if (data is RoomCheckChangeAdminChange<UndoRedoRequest>) {
					this.notifyChange ();
					return;
				}
				if (data is GameCheckPlayerChange<UndoRedoRequest>) {
					this.notifyChange ();
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
					this.notifyChange ();
					return;
				}
				// Child
				{
					if (data is ChangeRights) {
						ChangeRights changeRights = data as ChangeRights;
						// Child
						{
							changeRights.undoRedoRight.allAddCallBack (this);
						}
						this.notifyChange ();
						return;
					}
					// Child
					if (data is UndoRedoRight) {
						this.notifyChange ();
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
		{
			if (data is UndoRedoRequest) {
				UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
				// CheckChange
				{
					// room admin
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
					DataUtils.removeParentCallBack (undoRedoRequest, this, ref this.room);
				}
				this.undoRedoRequest = null;
				return;
			}
			// CheckChange
			{
				if (data is RoomCheckChangeAdminChange<UndoRedoRequest>) {
					return;
				}
				if (data is GameCheckPlayerChange<UndoRedoRequest>) {
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
					if (data is ChangeRights) {
						ChangeRights changeRights = data as ChangeRights;
						// Child
						{
							changeRights.undoRedoRight.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is UndoRedoRight) {
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UndoRedoRequest) {
				return;
			}
			// CheckChange
			{
				if (wrapProperty.p is RoomCheckChangeAdminChange<UndoRedoRequest>) {
					this.notifyChange ();
					return;
				}
				if (wrapProperty.p is GameCheckPlayerChange<UndoRedoRequest>) {
					this.notifyChange ();
					return;
				}
			}
			// Parent
			{
				if (wrapProperty.p is Room) {
					switch ((Room.Property)wrapProperty.n) {
					case Room.Property.changeRights:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							this.notifyChange ();
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
					if (wrapProperty.p is ChangeRights) {
						switch ((ChangeRights.Property)wrapProperty.n) {
						case ChangeRights.Property.undoRedoRight:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								this.notifyChange ();
							}
							break;
						case ChangeRights.Property.changeGamePlayerRight:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is UndoRedoRight) {
						switch ((UndoRedoRight.Property)wrapProperty.n) {
						case UndoRedoRight.Property.needAccept:
							this.notifyChange ();
							break;
						case UndoRedoRight.Property.needAdmin:
							this.notifyChange ();
							break;
						case UndoRedoRight.Property.limit:
							this.notifyChange ();
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

	}
}