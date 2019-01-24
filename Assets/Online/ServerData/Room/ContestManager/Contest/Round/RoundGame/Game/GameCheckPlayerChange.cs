using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCheckPlayerChange<K> : Data, ValueChangeCallBack where K : Data
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

	public GameCheckPlayerChange() : base()
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

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is Game) {
			Game game = data as Game;
			// Child
			{
				game.gamePlayers.allAddCallBack (this);
			}
			this.notifyChange ();
			return;
		}
		// Child
		{
			if (data is GamePlayer) {
				GamePlayer gamePlayer = data as GamePlayer;
				// Child
				{
					gamePlayer.inform.allAddCallBack (this);
				}
				notifyChange ();
				return;
			}
			// Child
			if (data is GamePlayer.Inform) {
				notifyChange ();
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is Game) {
			Game game = data as Game;
			// Child
			{
				game.gamePlayers.allRemoveCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is GamePlayer) {
				GamePlayer gamePlayer = data as GamePlayer;
				// Child
				{
					gamePlayer.inform.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is GamePlayer.Inform) {
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
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					this.notifyChange ();
				}
				break;
			case Game.Property.requestDraw:
				break;
			case Game.Property.state:
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
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is GamePlayer) {
				switch ((GamePlayer.Property)wrapProperty.n) {
				case GamePlayer.Property.playerIndex:
					this.notifyChange ();
					break;
				case GamePlayer.Property.inform:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						this.notifyChange ();
					}
					break;
				case GamePlayer.Property.state:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is GamePlayer.Inform) {
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						this.notifyChange ();
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
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}