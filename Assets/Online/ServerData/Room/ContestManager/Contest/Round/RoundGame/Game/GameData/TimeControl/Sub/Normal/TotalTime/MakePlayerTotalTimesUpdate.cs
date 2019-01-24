using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class MakePlayerTotalTimesUpdate : UpdateBehavior<TimeControlNormal>
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
							for (int i = this.data.playerTotalTimes.vs.Count - 1; i >= 0; i--) {
								PlayerTotalTime playerTotalTime = this.data.playerTotalTimes.vs [i];
								if (!playerIndexs.Contains (playerTotalTime.playerIndex.v)) {
									Debug.LogError ("remove playerTotalTime: " + playerTotalTime);
									this.data.playerTotalTimes.removeAt (i);
								}
							}
						}
						// Add
						foreach (int playerIndex in playerIndexs) {
							// Check already contain
							bool alreadyContain = false;
							{
								foreach (PlayerTotalTime playerTotalTime in this.data.playerTotalTimes.vs) {
									if (playerTotalTime.playerIndex.v == playerIndex) {
										alreadyContain = true;
										break;
									}
								}
							}
							// Process
							if (!alreadyContain) {
								// Make new
								PlayerTotalTime playerTotalTime = new PlayerTotalTime();
								{
									playerTotalTime.uid = this.data.playerTotalTimes.makeId ();
									playerTotalTime.playerIndex.v = playerIndex;
									playerTotalTime.serverTime.v = 0;
									playerTotalTime.clientTime.v = 0;
								}
								this.data.playerTotalTimes.add (playerTotalTime);
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

		private GameCheckPlayerChange<TimeControlNormal> gameCheckPlayerChange = new GameCheckPlayerChange<TimeControlNormal>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// CheckChange
				{
					gameCheckPlayerChange.addCallBack (this);
					gameCheckPlayerChange.setData (timeControlNormal);
				}
				// Child
				{
					timeControlNormal.playerTotalTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameCheckPlayerChange<TimeControlNormal>) {
				dirty = true;
				return;
			}
			// Child
			if (data is PlayerTotalTime) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// CheckChange
				{
					gameCheckPlayerChange.removeCallBack (this);
					gameCheckPlayerChange.setData (null);
				}
				// Child
				{
					timeControlNormal.playerTotalTimes.allRemoveCallBack (this);
				}
				this.setDataNull (timeControlNormal);
				return;
			}
			// CheckChange
			if (data is GameCheckPlayerChange<TimeControlNormal>) {
				return;
			}
			// Child
			if (data is PlayerTotalTime) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControlNormal) {
				switch ((TimeControlNormal.Property)wrapProperty.n) {
				case TimeControlNormal.Property.generalInfo:
					break;
				case TimeControlNormal.Property.playerTimeInfos:
					break;
				case TimeControlNormal.Property.playerTotalTimes:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameCheckPlayerChange<TimeControlNormal>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is PlayerTotalTime) {
				switch ((PlayerTotalTime.Property)wrapProperty.n) {
				case PlayerTotalTime.Property.playerIndex:
					dirty = true;
					break;
				case PlayerTotalTime.Property.serverTime:
					break;
				case PlayerTotalTime.Property.clientTime:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}