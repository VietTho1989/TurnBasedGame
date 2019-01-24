using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
	public class MakeTimeReportDeltaUpdate : UpdateBehavior<TimeControlHourGlass>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find TimeReportClient
					TimeReportClient timeReportClient = null;
					{
						TimeControl timeControl = this.data.findDataInParent<TimeControl> ();
						if (timeControl != null) {
							if (timeControl.timeReport.v != null && timeControl.timeReport.v is TimeReportClient) {
								timeReportClient = timeControl.timeReport.v as TimeReportClient;
							}
						} else {
							Debug.LogError ("timeControl null: " + this);
						}
					}
					// Process
					if (timeReportClient != null) {
						// Find PlayerIndex
						int playerIndex = 0;
						{
							GameData gameData = this.data.findDataInParent<GameData> ();
							if (gameData != null) {
								Turn turn = gameData.turn.v;
								if (turn != null) {
									playerIndex = turn.playerIndex.v;
								} else {
									Debug.LogError ("turn null: " + this);
								}
							} else {
								Debug.LogError ("gameData null: " + this);
							}
						}
						// Find reportTime
						float reportTime = 0;
						{
							foreach (PlayerTime playerTime in this.data.playerTimes.vs) {
								if (playerTime.playerIndex.v == playerIndex) {
									if (playerTime.clientTime.v > 0) {
										reportTime = playerTime.clientTime.v;
									}
								}
							}
						}
						// Set
						timeReportClient.delta.v = reportTime;
					} else {
						Debug.LogError ("timeReportClient null: " + this);
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

		private GameData gameData = null;
		private TimeControl timeControl = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// Parent
				{
					DataUtils.addParentCallBack (timeControlHourGlass, this, ref this.gameData);
					DataUtils.addParentCallBack (timeControlHourGlass, this, ref this.timeControl);
				}
				// Child
				{
					timeControlHourGlass.playerTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.turn.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Turn) {
						dirty = true;
						return;
					}
				}
				// TimeControl
				{
					if (data is TimeControl) {
						TimeControl timeControl = data as TimeControl;
						// Child
						{
							timeControl.timeReport.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is TimeReport) {
						dirty = true;
						return;
					}
				}
			}
			if (data is PlayerTime) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlHourGlass) {
				TimeControlHourGlass timeControlHourGlass = data as TimeControlHourGlass;
				// Parent
				{
					DataUtils.removeParentCallBack (timeControlHourGlass, this, ref this.gameData);
					DataUtils.removeParentCallBack (timeControlHourGlass, this, ref this.timeControl);
				}
				// Child
				{
					timeControlHourGlass.playerTimes.allRemoveCallBack (this);
				}
				this.setDataNull (timeControlHourGlass);
				return;
			}
			// Parent
			{
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.turn.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Turn) {
						return;
					}
				}
				// TimeControl
				{
					if (data is TimeControl) {
						TimeControl timeControl = data as TimeControl;
						// Child
						{
							timeControl.timeReport.allRemoveCallBack (this);
						}
						return;
					}
					if (data is TimeReport) {
						return;
					}
				}
			}
			if (data is PlayerTime) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
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
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// GameData
				{
					if (wrapProperty.p is GameData) {
						switch ((GameData.Property)wrapProperty.n) {
						case GameData.Property.gameType:
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GameData.Property.timeControl:
							break;
						case GameData.Property.lastMove:
							break;
						case GameData.Property.state:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Turn) {
						switch ((Turn.Property)wrapProperty.n) {
						case Turn.Property.turn:
							break;
						case Turn.Property.playerIndex:
							dirty = true;
							break;
						case Turn.Property.gameTurn:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				// TimeControl
				{
					if (wrapProperty.p is TimeControl) {
						switch ((TimeControl.Property)wrapProperty.n) {
						case TimeControl.Property.isEnable:
							break;
						case TimeControl.Property.aiCanTimeOut:
							break;
						case TimeControl.Property.timeOutPlayers:
							break;
						case TimeControl.Property.sub:
							break;
						case TimeControl.Property.use:
							break;
						case TimeControl.Property.timeReport:
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
					if (wrapProperty.p is TimeReport) {
						if (wrapProperty.p is TimeReportClient) {
							switch ((TimeReportClient.Property)wrapProperty.n) {
							case TimeReportClient.Property.userId:
								break;
							case TimeReportClient.Property.delta:
								dirty = true;
								break;
							case TimeReportClient.Property.reportTime:
								break;
							case TimeReportClient.Property.clientState:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
						}
						return;
					}
				}
			}
			if (wrapProperty.p is PlayerTime) {
				switch ((PlayerTime.Property)wrapProperty.n) {
				case PlayerTime.Property.playerIndex:
					dirty = true;
					break;
				case PlayerTime.Property.serverTime:
					break;
				case PlayerTime.Property.clientTime:
					dirty = true;
					break;
				case PlayerTime.Property.lagCompensation:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}