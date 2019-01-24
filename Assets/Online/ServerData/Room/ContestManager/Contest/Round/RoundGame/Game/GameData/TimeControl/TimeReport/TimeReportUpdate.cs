using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl
{
	public class TimeReportUpdate : UpdateBehavior<TimeControl>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.use.v == TimeControl.Use.ClientTime) {
						// find WaitInputAction
						WaitInputAction waitInputAction = null;
						{
							Game game = this.data.findDataInParent<Game> ();
							if (game != null) {
								if (game.gameAction.v != null) {
									if (game.gameAction.v is WaitInputAction) {
										waitInputAction = game.gameAction.v as WaitInputAction;
									}
								} else {
									Debug.LogError ("gameAction null: " + this);
								}
							} else {
								Debug.LogError ("time null: " + this);
							}
						}
						if (waitInputAction != null) {
							TimeReportClient timeReportClient = this.data.timeReport.newOrOld<TimeReportClient> ();
							{
								// userId
								{
									uint userId = 0;
									{
										if (waitInputAction.sub.v != null) {
											switch(waitInputAction.sub.v.getType()){
											case WaitInputAction.Sub.Type.Human:
												{
													WaitHumanInput waitHumanInput = waitInputAction.sub.v as WaitHumanInput;
													userId = waitHumanInput.userId.v;
												}
												break;
											case WaitInputAction.Sub.Type.AI:
												{
													WaitAIInput waitAIInput = waitInputAction.sub.v as WaitAIInput;
													userId = waitAIInput.userThink.v;
												}
												break;
											default:
												Debug.LogError ("unknown sub: " + waitInputAction.sub.getType () + "; " + this);
												break;
											}
										} else {
											Debug.LogError ("waitAIInputSub null: " + this);
										}
									}
									timeReportClient.userId.v = userId;
								}
								// delta
								{
									// Cai nay de cac timeControlSub tinh
								}
								// reportTime
								{
									// Cai nay thi ko nen reset lai
								}
							}
							this.data.timeReport.v = timeReportClient;
						} else {
							// Debug.LogError ("waitInputAction null: " + this);
							TimeReportNone timeReportNone = this.data.timeReport.newOrOld<TimeReportNone> ();
							{

							}
							this.data.timeReport.v = timeReportNone;
						}
					} else {
						TimeReportNone timeReportNone = this.data.timeReport.newOrOld<TimeReportNone> ();
						{

						}
						this.data.timeReport.v = timeReportNone;
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

		private Game game = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is TimeControl) {
				TimeControl timeControls = data as TimeControl;
				// Parent
				{
					DataUtils.addParentCallBack (timeControls, this, ref this.game);
				}
				// Child
				{
					timeControls.timeReport.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is Game) {
					Game game = data as Game;
					{
						game.gameAction.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is GameAction) {
						GameAction gameAction = data as GameAction;
						// Child
						{
							if (gameAction is WaitInputAction) {
								WaitInputAction waitInputAction = gameAction as WaitInputAction;
								// Child
								{
									waitInputAction.sub.allAddCallBack (this);
								}
							}
						}
						dirty = true;
						return;
					}
					// Child
					if (data is WaitInputAction.Sub) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is TimeReport) {
				TimeReport timeReport = data as TimeReport;
				{
					switch (timeReport.getType ()) {
					case TimeReport.Type.None:
						break;
					case TimeReport.Type.Client:
						{
							TimeReportClient timeReportClient = timeReport as TimeReportClient;
							UpdateUtils.makeUpdate<TimeReportClientUpdate, TimeReportClient> (timeReportClient, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + timeReport.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is TimeControl) {
				TimeControl timeControls = data as TimeControl;
				// Parent
				{
					DataUtils.removeParentCallBack (timeControls, this, ref this.game);
				}
				// Child
				{
					timeControls.timeReport.allRemoveCallBack (this);
				}
				this.setDataNull (timeControls);
				return;
			}
			// Parent
			{
				if (data is Game) {
					Game game = data as Game;
					{
						game.gameAction.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is GameAction) {
						GameAction gameAction = data as GameAction;
						// Child
						{
							if (gameAction is WaitInputAction) {
								WaitInputAction waitInputAction = gameAction as WaitInputAction;
								// Child
								{
									waitInputAction.sub.allRemoveCallBack (this);
								}
							}
						}
						return;
					}
					// Child
					if (data is WaitInputAction.Sub) {
						return;
					}
				}
			}
			// Child
			if (data is TimeReport) {
				TimeReport timeReport = data as TimeReport;
				{
					switch (timeReport.getType ()) {
					case TimeReport.Type.None:
						break;
					case TimeReport.Type.Client:
						{
							TimeReportClient timeReportClient = timeReport as TimeReportClient;
							timeReportClient.removeCallBackAndDestroy (typeof(TimeReportClientUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + timeReport.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is TimeControl) {
				switch ((TimeControl.Property)wrapProperty.n) {
				case TimeControl.Property.isEnable:
					break;
				case TimeControl.Property.timeOutPlayers:
					break;
				case TimeControl.Property.sub:
					break;
				case TimeControl.Property.use:
					dirty = true;
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
			// Parent
			{
				if (wrapProperty.p is Game) {
					switch ((Game.Property)wrapProperty.n) {
					case Game.Property.gamePlayers:
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
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Game.Property.undoRedoRequest:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is GameAction) {
						if (wrapProperty.p is WaitInputAction) {
							switch ((WaitInputAction.Property)wrapProperty.n) {
							case WaitInputAction.Property.serverTime:
								break;
							case WaitInputAction.Property.clientTime:
								break;
							case WaitInputAction.Property.sub:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case WaitInputAction.Property.inputs:
								break;
							case WaitInputAction.Property.clientInput:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						return;
					}
					// Child
					if (wrapProperty.p is WaitInputAction.Sub) {
						if (wrapProperty.p is WaitHumanInput) {
							switch ((WaitHumanInput.Property)wrapProperty.n) {
							case WaitHumanInput.Property.userId:
								dirty = true;
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						if (wrapProperty.p is WaitAIInput) {
							switch ((WaitAIInput.Property)wrapProperty.n) {
							case WaitAIInput.Property.userThink:
								dirty = true;
								break;
							case WaitAIInput.Property.reThink:
								break;
							case WaitAIInput.Property.sub:
								break;
							case WaitAIInput.Property.isGettingSolvedMove:
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
			}
			// Child
			if (wrapProperty.p is TimeReport) {
				if (wrapProperty.p is TimeReportNone) {
					return;
				}
				if (wrapProperty.p is TimeReportClient) {
					switch ((TimeReportClient.Property)wrapProperty.n) {
					case TimeReportClient.Property.userId:
						dirty = true;
						break;
					case TimeReportClient.Property.delta:
						break;
					case TimeReportClient.Property.reportTime:
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}