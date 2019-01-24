using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class CheckEndResultChange<K> : Data, ValueChangeCallBack where K : Data
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

		public CheckEndResultChange() : base()
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
					game.state.allAddCallBack (this);
				}
				this.notifyChange ();
				return;
			}
			// Child
			{
				if (data is State) {
					State state = data as State;
					// Child
					{
						if (state is End) {
							End end = state as End;
							end.results.allAddCallBack (this);
						}
					}
					this.notifyChange ();
					return;
				}
				// Child
				if (data is Result) {
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
				// Child
				{
					game.state.allRemoveCallBack (this);
				}
				this.game = null;
				return;
			}
			// Child
			{
				if (data is State) {
					State state = data as State;
					// Child
					{
						if (state is End) {
							End end = state as End;
							end.results.allRemoveCallBack (this);
						}
					}
					return;
				}
				// Child
				if (data is Result) {
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
			// Child
			{
				if (wrapProperty.p is State) {
					if (wrapProperty.p is End) {
						switch ((End.Property)wrapProperty.n) {
						case End.Property.results:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								this.notifyChange ();
							}
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
					return;
				}
				// Child
				if (wrapProperty.p is Result) {
					switch ((Result.Property)wrapProperty.n) {
					case Result.Property.playerIndex:
						this.notifyChange ();
						break;
					case Result.Property.score:
						this.notifyChange ();
						break;
					case Result.Property.reason:
						this.notifyChange ();
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}