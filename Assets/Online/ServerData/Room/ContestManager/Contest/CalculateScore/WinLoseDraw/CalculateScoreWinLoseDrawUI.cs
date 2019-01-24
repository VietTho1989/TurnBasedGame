using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class CalculateScoreWinLoseDrawUI : UIBehavior<CalculateScoreWinLoseDrawUI.UIData>
	{

		#region UIData

		public class UIData : CalculateScore.UIData
		{

			public VP<EditData<CalculateScoreWinLoseDraw>> editCalculateScoreWinLoseDraw;

			#region winScore

			public VP<RequestChangeFloatUI.UIData> winScore;

			public void makeRequestChangeWinScore (RequestChangeUpdate<float>.UpdateData update, float newWinScore)
			{
				// Find
				CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = null;
				{
					EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = this.editCalculateScoreWinLoseDraw.v;
					if (editCalculateScoreWinLoseDraw != null) {
						calculateScoreWinLoseDraw = editCalculateScoreWinLoseDraw.show.v.data;
					} else {
						Debug.LogError ("editCalculateScoreWinLoseDraw null: " + this);
					}
				}
				// Process
				if (calculateScoreWinLoseDraw != null) {
					calculateScoreWinLoseDraw.requestChangeWinScore (Server.getProfileUserId (calculateScoreWinLoseDraw), newWinScore);
				} else {
					Debug.LogError ("haveLimit null: " + this);
				}
			}

			#endregion

			#region loseScore

			public VP<RequestChangeFloatUI.UIData> loseScore;

			public void makeRequestChangeLoseScore (RequestChangeUpdate<float>.UpdateData update, float newLoseScore)
			{
				// Find
				CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = null;
				{
					EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = this.editCalculateScoreWinLoseDraw.v;
					if (editCalculateScoreWinLoseDraw != null) {
						calculateScoreWinLoseDraw = editCalculateScoreWinLoseDraw.show.v.data;
					} else {
						Debug.LogError ("editCalculateScoreWinLoseDraw null: " + this);
					}
				}
				// Process
				if (calculateScoreWinLoseDraw != null) {
					calculateScoreWinLoseDraw.requestChangeLoseScore (Server.getProfileUserId (calculateScoreWinLoseDraw), newLoseScore);
				} else {
					Debug.LogError ("haveLimit null: " + this);
				}
			}

			#endregion

			#region drawScore

			public VP<RequestChangeFloatUI.UIData> drawScore;

			public void makeRequestChangeDrawScore (RequestChangeUpdate<float>.UpdateData update, float newDrawScore)
			{
				// Find
				CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = null;
				{
					EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = this.editCalculateScoreWinLoseDraw.v;
					if (editCalculateScoreWinLoseDraw != null) {
						calculateScoreWinLoseDraw = editCalculateScoreWinLoseDraw.show.v.data;
					} else {
						Debug.LogError ("editCalculateScoreWinLoseDraw null: " + this);
					}
				}
				// Process
				if (calculateScoreWinLoseDraw != null) {
					calculateScoreWinLoseDraw.requestChangeDrawScore (Server.getProfileUserId (calculateScoreWinLoseDraw), newDrawScore);
				} else {
					Debug.LogError ("haveLimit null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editCalculateScoreWinLoseDraw,
				winScore,
				loseScore,
				drawScore
			}

			public UIData() : base()
			{
				this.editCalculateScoreWinLoseDraw = new VP<EditData<CalculateScoreWinLoseDraw>>(this, (byte)Property.editCalculateScoreWinLoseDraw, new EditData<CalculateScoreWinLoseDraw>());
				// winScore
				{
					this.winScore = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.winScore, new RequestChangeFloatUI.UIData());
					this.winScore.v.updateData.v.request.v = makeRequestChangeWinScore;
				}
				// loseScore
				{
					this.loseScore = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.loseScore, new RequestChangeFloatUI.UIData());
					this.loseScore.v.updateData.v.request.v = makeRequestChangeLoseScore;
				}
				// drawScore
				{
					this.drawScore = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.drawScore, new RequestChangeFloatUI.UIData());
					this.drawScore.v.updateData.v.request.v = makeRequestChangeDrawScore;
				}
			}

			#endregion

			public override CalculateScore.Type getType ()
			{
				return CalculateScore.Type.WinLoseDraw;
			}

		}

		#endregion

		#region Refresh

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = this.data.editCalculateScoreWinLoseDraw.v;
					if (editCalculateScoreWinLoseDraw != null) {
						editCalculateScoreWinLoseDraw.update ();
						// get show
						CalculateScoreWinLoseDraw show = editCalculateScoreWinLoseDraw.show.v.data;
						CalculateScoreWinLoseDraw compare = editCalculateScoreWinLoseDraw.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editCalculateScoreWinLoseDraw.compareOtherType.v.data != null) {
										if (editCalculateScoreWinLoseDraw.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
								differentIndicator.SetActive (isDifferent);
							} else {
								Debug.LogError ("differentIndicator null: " + this);
							}
							// request
							{
								// get server state
								Server.State.Type serverState = Server.State.Type.Connect;
								{
									Server server = show.findDataInParent<Server> ();
									if (server != null) {
										if (server.state.v != null) {
											serverState = server.state.v.getType ();
										} else {
											Debug.LogError ("server state null: " + this);
										}
									} else {
										Debug.LogError ("server null: " + this);
									}
								}
								// set origin
								{
									// winScore
									{
										RequestChangeFloatUI.UIData winScore = this.data.winScore.v;
										if (winScore != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = winScore.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.winScore.v;
												updateData.canRequestChange.v = editCalculateScoreWinLoseDraw.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													winScore.showDifferent.v = true;
													winScore.compare.v = compare.winScore.v;
												} else {
													winScore.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("winScore null: " + this);
										}
									}
									// loseScore
									{
										RequestChangeFloatUI.UIData loseScore = this.data.loseScore.v;
										if (loseScore != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = loseScore.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.loseScore.v;
												updateData.canRequestChange.v = editCalculateScoreWinLoseDraw.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													loseScore.showDifferent.v = true;
													loseScore.compare.v = compare.loseScore.v;
												} else {
													loseScore.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("loseScore null: " + this);
										}
									}
									// drawScore
									{
										RequestChangeFloatUI.UIData drawScore = this.data.drawScore.v;
										if (drawScore != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = drawScore.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.drawScore.v;
												updateData.canRequestChange.v = editCalculateScoreWinLoseDraw.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													drawScore.showDifferent.v = true;
													drawScore.compare.v = compare.drawScore.v;
												} else {
													drawScore.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("drawScore null: " + this);
										}
									}
								}
								// reset
								if (needReset) {
									needReset = false;
									// winScore
									{
										RequestChangeFloatUI.UIData winScore = this.data.winScore.v;
										if (winScore != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = winScore.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.winScore.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("winScore null: " + this);
										}
									}
									// loseScore
									{
										RequestChangeFloatUI.UIData loseScore = this.data.loseScore.v;
										if (loseScore != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = loseScore.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.loseScore.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("loseScore null: " + this);
										}
									}
									// drawScore
									{
										RequestChangeFloatUI.UIData drawScore = this.data.drawScore.v;
										if (drawScore != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = drawScore.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.drawScore.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("drawScore null: " + this);
										}
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editCalculateScoreWinLoseScore null: " + this);
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

		public RequestChangeFloatUI requestFloatPrefab;

		public Transform winScoreContainer;
		public Transform loseScoreContainer;
		public Transform drawScoreContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.editCalculateScoreWinLoseDraw.allAddCallBack (this);
					uiData.winScore.allAddCallBack (this);
					uiData.loseScore.allAddCallBack (this);
					uiData.drawScore.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// editCalculateScoreWinLoseDraw
				{
					if (data is EditData<CalculateScoreWinLoseDraw>) {
						EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = data as EditData<CalculateScoreWinLoseDraw>;
						// Child
						{
							editCalculateScoreWinLoseDraw.show.allAddCallBack (this);
							editCalculateScoreWinLoseDraw.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is CalculateScoreWinLoseDraw) {
							CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = data as CalculateScoreWinLoseDraw;
							// Parent
							{
								DataUtils.addParentCallBack (calculateScoreWinLoseDraw, this, ref this.server);
							}
							needReset = true;
							dirty = true;
							return;
						}
						// Parent
						{
							if (data is Server) {
								dirty = true;
								return;
							}
						}
					}
				}
				// winScore, loseScore, drawScore
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.winScore:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, winScoreContainer);
								break;
							case UIData.Property.loseScore:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, loseScoreContainer);
								break;
							case UIData.Property.drawScore:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, drawScoreContainer);
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("wrapProperty null: " + this);
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
					uiData.editCalculateScoreWinLoseDraw.allRemoveCallBack (this);
					uiData.winScore.allRemoveCallBack (this);
					uiData.loseScore.allRemoveCallBack (this);
					uiData.drawScore.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				// editCalculateScoreWinLoseDraw
				{
					if (data is EditData<CalculateScoreWinLoseDraw>) {
						EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = data as EditData<CalculateScoreWinLoseDraw>;
						// Child
						{
							editCalculateScoreWinLoseDraw.show.allRemoveCallBack (this);
							editCalculateScoreWinLoseDraw.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is CalculateScoreWinLoseDraw) {
							CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = data as CalculateScoreWinLoseDraw;
							// Parent
							{
								DataUtils.removeParentCallBack (calculateScoreWinLoseDraw, this, ref this.server);
							}
							return;
						}
						// Parent
						{
							if (data is Server) {
								return;
							}
						}
					}
				}
				// winScore, loseScore, drawScore
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeFloatUI));
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
				case UIData.Property.editCalculateScoreWinLoseDraw:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.winScore:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.loseScore:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.drawScore:
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
				// editCalculateScoreWinLoseDraw
				{
					if (wrapProperty.p is EditData<CalculateScoreWinLoseDraw>) {
						switch ((EditData<CalculateScoreWinLoseDraw>.Property)wrapProperty.n) {
						case EditData<CalculateScoreWinLoseDraw>.Property.origin:
							dirty = true;
							break;
						case EditData<CalculateScoreWinLoseDraw>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<CalculateScoreWinLoseDraw>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<CalculateScoreWinLoseDraw>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<CalculateScoreWinLoseDraw>.Property.canEdit:
							dirty = true;
							break;
						case EditData<CalculateScoreWinLoseDraw>.Property.editType:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is CalculateScoreWinLoseDraw) {
							switch ((CalculateScoreWinLoseDraw.Property)wrapProperty.n) {
							case CalculateScoreWinLoseDraw.Property.winScore:
								dirty = true;
								break;
							case CalculateScoreWinLoseDraw.Property.loseScore:
								dirty = true;
								break;
							case CalculateScoreWinLoseDraw.Property.drawScore:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Parent
						{
							if (wrapProperty.p is Server) {
								Server.State.OnUpdateSyncStateChange (wrapProperty, this);
								return;
							}
						}
					}
				}
				// winScore, loseScore, drawScore
				if (wrapProperty.p is RequestChangeFloatUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}