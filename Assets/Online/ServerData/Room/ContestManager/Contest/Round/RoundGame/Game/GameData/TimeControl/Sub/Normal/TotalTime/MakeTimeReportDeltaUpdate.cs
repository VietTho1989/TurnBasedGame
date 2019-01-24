using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class MakeTimeReportDeltaUpdate : UpdateBehavior<TimeControlNormal>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					TimeControl timeControl = this.data.findDataInParent<TimeControl> ();
					if (timeControl != null) {
						// Find TimeReportClient
						TimeReportClient timeReportClient = null;
						{
							if (timeControl.timeReport.v != null) {
								if (timeControl.timeReport.v is TimeReportClient) {
									timeReportClient = timeControl.timeReport.v as TimeReportClient;
								}
							}
						}
						// Process
						if (timeReportClient != null) {
							float delta = 0;
							{
								// Get playerIndex
								int playerIndex = 0;
								{
									// Find Turn
									Turn turn = null;
									{
										GameData gameData = this.data.findDataInParent<GameData> ();
										if (gameData != null) {
											turn = gameData.turn.v;
										} else {
											Debug.LogError ("gameData null: " + this);
										}
									}
									if (turn != null) {
										playerIndex = turn.playerIndex.v;
									} else {
										Debug.LogError ("turn null: " + this);
									}
								}
								// Get PlayerTime
								PlayerTotalTime playerTotalTime = this.data.getPlayerTotalTime (playerIndex);
								TimeInfo playerTimeInfo = this.data.getTimeInfo (playerIndex);
								// Process
								if (playerTotalTime != null && playerTimeInfo != null) {
									if (playerTimeInfo.totalTime.v.isOverTime (playerTotalTime.clientTime.v)) {
										switch (playerTimeInfo.overTimePerTurn.v.getType ()) {
										case TimePerTurnInfo.Type.Limit:
											{
												TimePerTurnInfo.Limit limit = playerTimeInfo.overTimePerTurn.v as TimePerTurnInfo.Limit;
												delta = limit.perTurn.v;
											}
											break;
										case TimePerTurnInfo.Type.NoLimit:
											delta = 0;
											break;
										default:
											Debug.LogError ("unknown type: " + playerTimeInfo.overTimePerTurn.v.getType () + "; " + this);
											break;
										}
									} else {
										if (playerTimeInfo.timePerTurn.v is TimePerTurnInfo.Limit) {
											TimePerTurnInfo.Limit limit = playerTimeInfo.timePerTurn.v as TimePerTurnInfo.Limit;
											float turnDelta = limit.perTurn.v;
											// compare with total time
											if (playerTimeInfo.totalTime.v.getType () == TotalTimeInfo.Type.NoLimit) {
												delta = turnDelta;
											} else {
												TotalTimeInfo.Limit totalLimit = playerTimeInfo.totalTime.v as TotalTimeInfo.Limit;
												if (totalLimit.totalTime.v - playerTotalTime.clientTime.v > turnDelta) {
													delta = turnDelta;
												} else {
													if (playerTimeInfo.overTimePerTurn.v.getType () == TimePerTurnInfo.Type.NoLimit) {
														delta = turnDelta;
													} else {
														TimePerTurnInfo.Limit overTimeLimit = playerTimeInfo.overTimePerTurn.v as TimePerTurnInfo.Limit;
														delta = Mathf.Min (turnDelta, totalLimit.totalTime.v - playerTotalTime.clientTime.v + overTimeLimit.perTurn.v);
													}
												}
											}
										} else {
											Debug.LogError ("no limit, don't need delta");
										}
									}
								}
							}
							// Set
							// Debug.LogError ("makeTimeReportDelta: " + delta + "; " + this);
							timeReportClient.delta.v = delta;
						} else {
							// Debug.LogError ("timeReportClient null: " + this);
						}
					} else {
						Debug.LogError ("timeControls null: " + this);
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

		private TimeControl timeControls = null;
		private GameData gameData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// Parent
				{
					DataUtils.addParentCallBack (timeControlNormal, this, ref this.timeControls);
					DataUtils.addParentCallBack (timeControlNormal, this, ref this.gameData);
				}
				// Child
				{
					timeControlNormal.generalInfo.allAddCallBack (this);
					timeControlNormal.playerTimeInfos.allAddCallBack (this);
					timeControlNormal.playerTotalTimes.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// TimeControls
				{
					if (data is TimeControl) {
						TimeControl timeControls = data as TimeControl;
						// Child
						{
							timeControls.timeReport.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is TimeReport) {
						dirty = true;
						return;
					}
				}
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
			}
			// Child
			{
				// TimeInfo
				{
					if (data is TimeInfo) {
						TimeInfo timeInfo = data as TimeInfo;
						{
							timeInfo.timePerTurn.allAddCallBack (this);
							timeInfo.totalTime.allAddCallBack (this);
							timeInfo.overTimePerTurn.allAddCallBack (this);
							// lagCompensation
						}
						dirty = true;
						return;
					}
					if (data is TimePerTurnInfo) {
						dirty = true;
						return;
					}
					if (data is TotalTimeInfo) {
						dirty = true;
						return;
					}
				}
				if (data is PlayerTimeInfo) {
					PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
					{
						playerTimeInfo.timeInfo.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is PlayerTotalTime) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControlNormal) {
				TimeControlNormal timeControlNormal = data as TimeControlNormal;
				// Parent
				{
					DataUtils.removeParentCallBack (timeControlNormal, this, ref this.timeControls);
					DataUtils.removeParentCallBack (timeControlNormal, this, ref this.gameData);
				}
				// Child
				{
					timeControlNormal.generalInfo.allRemoveCallBack (this);
					timeControlNormal.playerTimeInfos.allRemoveCallBack (this);
					timeControlNormal.playerTotalTimes.allRemoveCallBack (this);
				}
				this.setDataNull (timeControlNormal);
				return;
			}
			// Parent
			{
				// TimeControls
				{
					if (data is TimeControl) {
						TimeControl timeControls = data as TimeControl;
						// Child
						{
							timeControls.timeReport.allRemoveCallBack (this);
						}
						return;
					}
					if (data is TimeReport) {
						return;
					}
				}
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
			}
			// Child
			{
				// TimeInfo
				{
					if (data is TimeInfo) {
						TimeInfo timeInfo = data as TimeInfo;
						{
							timeInfo.timePerTurn.allRemoveCallBack (this);
							timeInfo.totalTime.allRemoveCallBack (this);
							timeInfo.overTimePerTurn.allRemoveCallBack (this);
							// lagCompensation
						}
						return;
					}
					if (data is TimePerTurnInfo) {
						return;
					}
					if (data is TotalTimeInfo) {
						return;
					}
				}
				if (data is PlayerTimeInfo) {
					PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
					{
						playerTimeInfo.timeInfo.allRemoveCallBack (this);
					}
					return;
				}
				if (data is PlayerTotalTime) {
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
			if (wrapProperty.p is TimeControlNormal) {
				switch ((TimeControlNormal.Property)wrapProperty.n) {
				case TimeControlNormal.Property.generalInfo:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case TimeControlNormal.Property.playerTimeInfos:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
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
			// Parent
			{
				// TimeControls
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
						if (wrapProperty.p is TimeReportNone) {
							return;
						}
						if (wrapProperty.p is TimeReportClient) {
							switch ((TimeReportClient.Property)wrapProperty.n) {
							case TimeReportClient.Property.userId:
								break;
							case TimeReportClient.Property.delta:
								break;
							case TimeReportClient.Property.reportTime:
								dirty = true;
								break;
							case TimeReportClient.Property.clientState:
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
			}
			// Child
			{
				// TimeInfo
				{
					if (wrapProperty.p is TimeInfo) {
						switch ((TimeInfo.Property)wrapProperty.n) {
						case TimeInfo.Property.timePerTurn:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case TimeInfo.Property.totalTime:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case TimeInfo.Property.overTimePerTurn:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case TimeInfo.Property.lagCompensation:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					if (wrapProperty.p is TimePerTurnInfo) {
						if (wrapProperty.p is TimePerTurnInfo.Limit) {
							switch ((TimePerTurnInfo.Limit.Property)wrapProperty.n) {
							case TimePerTurnInfo.Limit.Property.perTurn:
								dirty = true;
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
						}
						if (wrapProperty.p is TimePerTurnInfo.NoLimit) {
							return;
						}
						return;
					}
					if (wrapProperty.p is TotalTimeInfo) {
						if (wrapProperty.p is TotalTimeInfo.Limit) {
							switch ((TotalTimeInfo.Limit.Property)wrapProperty.n) {
							case TotalTimeInfo.Limit.Property.totalTime:
								dirty = true;
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						if (wrapProperty.p is TotalTimeInfo.NoLimit) {
							return;
						}
						return;
					}
				}
				if (wrapProperty.p is PlayerTimeInfo) {
					switch ((PlayerTimeInfo.Property)wrapProperty.n) {
					case PlayerTimeInfo.Property.playerIndex:
						dirty = true;
						break;
					case PlayerTimeInfo.Property.timeInfo:
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
				if (wrapProperty.p is PlayerTotalTime) {
					switch ((PlayerTotalTime.Property)wrapProperty.n) {
					case PlayerTotalTime.Property.playerIndex:
						dirty = true;
						break;
					case PlayerTotalTime.Property.serverTime:
						break;
					case PlayerTotalTime.Property.clientTime:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknownw wrapProperty: " + wrapProperty + "; " + this);
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