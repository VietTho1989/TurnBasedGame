using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
	public class MakePlayerTimesUpdate : UpdateBehavior<TimeControlHourGlass>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					HashSet<int> playerIndexs = new HashSet<int> ();
					// Add
					{
						Game game = this.data.findDataInParent<Game> ();
						if (game != null) {
							foreach (GamePlayer gamePlayer in game.gamePlayers.vs) {
								playerIndexs.Add (gamePlayer.playerIndex.v);
							}
						} else {
							Debug.LogError ("duel null: " + this);
						}
					}
					// Process
					{
						// Remove player not in anymore
						{
							for (int i = this.data.playerTimes.vs.Count - 1; i >= 0; i--) {
								PlayerTime playerTime = this.data.playerTimes.vs [i];
								if (!playerIndexs.Contains (playerTime.playerIndex.v)) {
									Debug.LogError ("remove playerTime: " + playerTime);
									this.data.playerTimes.removeAt (i);
								}
							}
						}
						// Add
						foreach (int playerIndex in playerIndexs) {
							// Check already contain
							bool alreadyContain = false;
							{
								foreach (PlayerTime playerTime in this.data.playerTimes.vs) {
									if (playerTime.playerIndex.v == playerIndex) {
										alreadyContain = true;
										break;
									}
								}
							}
							// Process
							if (!alreadyContain) {
								// Make new
								PlayerTime playerTime = new PlayerTime();
								{
									playerTime.uid = this.data.playerTimes.makeId ();
									playerTime.playerIndex.v = playerIndex;
									playerTime.serverTime.v = this.data.initTime.v;
									playerTime.clientTime.v = this.data.initTime.v;
									playerTime.lagCompensation.v = this.data.lagCompensation.v;
								}
								this.data.playerTimes.add (playerTime);
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

		private GameCheckPlayerChange<TimeControlHourGlass> gameCheckPlayerChange = new GameCheckPlayerChange<TimeControlHourGlass>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// CheckChange
				{
					gameCheckPlayerChange.addCallBack (this);
					gameCheckPlayerChange.setData (timeControlHourGlass);
				}
				// Child
				{
					timeControlHourGlass.playerTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameCheckPlayerChange<TimeControlHourGlass>) {
				dirty = true;
				return;
			}
			// Child
			if (data is PlayerTime) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don' process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// CheckChange
				{
					gameCheckPlayerChange.removeCallBack (this);
					gameCheckPlayerChange.setData (null);
				}
				// Child
				{
					timeControlHourGlass.playerTimes.allRemoveCallBack (this);
				}
				this.setDataNull (timeControlHourGlass);
				return;
			}
			// CheckChange
			if (data is GameCheckPlayerChange<TimeControlHourGlass>) {
				return;
			}
			// Child
			if (data is PlayerTime) {
				return;
			}
			Debug.LogError ("Don' process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControlHourGlass) {
				switch ((TimeControlHourGlass.Property)wrapProperty.n) {
				case TimeControlHourGlass.Property.initTime:
					break;
				case TimeControlHourGlass.Property.lagCompensation:
					break;
				case TimeControlHourGlass.Property.playerTimes:
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
			if (wrapProperty.p is GameCheckPlayerChange<TimeControlHourGlass>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is PlayerTime) {
				switch ((PlayerTime.Property)wrapProperty.n) {
				case PlayerTime.Property.playerIndex:
					dirty = true;
					break;
				case PlayerTime.Property.serverTime:
					break;
				case PlayerTime.Property.clientTime:
					break;
				case PlayerTime.Property.lagCompensation:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}