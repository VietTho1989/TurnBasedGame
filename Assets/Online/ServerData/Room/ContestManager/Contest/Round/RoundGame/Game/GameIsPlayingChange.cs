using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameState;

public class GameIsPlayingChange<K> : Data, ValueChangeCallBack where K : Data
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

	public GameIsPlayingChange() : base()
	{
		this.change = new VP<int> (this, (byte)Property.change, 0);
	}

	#endregion

	public K data;

	public void setData(K newData){
		if (this.data != newData) {
			// remove old
			{
				DataUtils.removeParentCallBack (this.data, this, ref this.game);
			}
			// set new 
			{
				this.data = newData;
				DataUtils.addParentCallBack (this.data, this, ref this.game);
			}
		} else {
			Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
	}

	#region implement callBacks

	private Game game = null;
	private Room room = null;

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is Game) {
			Game game = data as Game;
			// Parent
			{
				DataUtils.addParentCallBack (game, this, ref this.room);
			}
			// Child
			{
				game.state.allAddCallBack (this);
			}
			this.notifyChange ();
			return;
		}
		// Parent
		{
			if (data is Room) {
				this.notifyChange ();
				return;
			}
		}
		// Child
		{
			if (data is State) {
				this.notifyChange ();
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is Game) {
			Game game = data as Game;
			// Parent
			{
				DataUtils.removeParentCallBack (game, this, ref this.room);
			}
			// Child
			{
				game.state.allRemoveCallBack (this);
			}
			this.game = null;
			return;
		}
		// Parent
		{
			if (data is Room) {
				return;
			}
		}
		// Child
		{
			if (data is State) {
				return;
			}
		}	
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Game) {
			switch ((Game.Property)wrapProperty.n) {
			case Game.Property.gamePlayers:
				break;
			case Game.Property.requestDraw:
				break;
			case Game.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					this.notifyChange ();
				}
				break;
			case Game.Property.gameData:
				break;
			case Game.Property.history:
				break;
			case Game.Property.gameAction:
				break;
			case Game.Property.undoRedoRequest:
				break;
			case Game.Property.chatRoom:
				break;
			case Game.Property.animationData:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Parent
		{
			if (wrapProperty.p is Room) {
				switch ((Room.Property)wrapProperty.n) {
				case Room.Property.changeRights:
					break;
				case Room.Property.name:
					break;
				case Room.Property.password:
					break;
				case Room.Property.users:
					break;
				case Room.Property.state:
					this.notifyChange ();
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
		}
		// Child
		{
			if (wrapProperty.p is State) {
				State state = wrapProperty.p as State;
				switch (state.getType ()) {
				case State.Type.Load:
					break;
				case State.Type.Start:
					break;
				case State.Type.Play:
					{
						switch ((Play.Property)wrapProperty.n) {
						case Play.Property.sub:
							this.notifyChange ();
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
					break;
				case State.Type.End:
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}