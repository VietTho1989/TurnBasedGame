using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtAIUI : UIBehavior<RussianDraughtAIUI.UIData>
	{

		#region UIData

		public class UIData : AIUI.UIData.Sub
		{

			public VP<EditData<RussianDraughtAI>> editAI;

			#region timeLimit

			public VP<RequestChangeIntUI.UIData> timeLimit;

			public void makeRequestChangeTimeLimit (RequestChangeUpdate<int>.UpdateData update, int newTimeLimit)
			{
				// Find russianDraughtAI
				RussianDraughtAI russianDraughtAI = null;
				{
					EditData<RussianDraughtAI> editRussianDraughtAI = this.editAI.v;
					if (editRussianDraughtAI != null) {
						russianDraughtAI = editRussianDraughtAI.show.v.data;
					} else {
						Debug.LogError ("editRussianDraughtAI null: " + this);
					}
				}
				// Process
				if (russianDraughtAI != null) {
					russianDraughtAI.requestChangeTimeLimit (Server.getProfileUserId (russianDraughtAI), newTimeLimit);
				} else {
					Debug.LogError ("russianDraughtAI null: " + this);
				}
			}

			#endregion

			#region pickBestMove

			public VP<RequestChangeIntUI.UIData> pickBestMove;

			public void makeRequestChangePickBestMove (RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
			{
				// Find russianDraughtAI
				RussianDraughtAI russianDraughtAI = null;
				{
					EditData<RussianDraughtAI> editRussianDraughtAI = this.editAI.v;
					if (editRussianDraughtAI != null) {
						russianDraughtAI = editRussianDraughtAI.show.v.data;
					} else {
						Debug.LogError ("editRussianDraughtAI null: " + this);
					}
				}
				// Process
				if (russianDraughtAI != null) {
					russianDraughtAI.requestChangePickBestMove (Server.getProfileUserId (russianDraughtAI), newPickBestMove);
				} else {
					Debug.LogError ("russianDraughtAI null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editAI,
				timeLimit,
				pickBestMove
			}

			public UIData() : base()
			{
				this.editAI = new VP<EditData<RussianDraughtAI>>(this, (byte)Property.editAI, new EditData<RussianDraughtAI>());
				// timeLimit
				{
					this.timeLimit = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.timeLimit, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.timeLimit.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 3*60*1000;
						}
						this.timeLimit.v.limit.v = have;
					}
					// event
					this.timeLimit.v.updateData.v.request.v = makeRequestChangeTimeLimit;
				}
				// pickBestMove
				{
					this.pickBestMove = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.pickBestMove, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.pickBestMove.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 100;
						}
						this.pickBestMove.v.limit.v = have;
					}
					// event
					this.pickBestMove.v.updateData.v.request.v = makeRequestChangePickBestMove;
				}
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.RussianDraught;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbTimeLimit;
		public static readonly TxtLanguage txtTimeLimit = new TxtLanguage();

		public Text lbPickBestMove;
		public static readonly TxtLanguage txtPickBestMove = new TxtLanguage();

		static RussianDraughtAIUI()
		{
			txtTitle.add (Language.Type.vi, "Cờ Đam Kiểu Nga AI");
			txtTimeLimit.add (Language.Type.vi, "Giới hạn thời gian");
			txtPickBestMove.add (Language.Type.vi, "Chọn nước đi tốt nhất");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<RussianDraughtAI> editRussianDraughtAI = this.data.editAI.v;
					if (editRussianDraughtAI != null) {
						editRussianDraughtAI.update ();
						// get show
						RussianDraughtAI show = editRussianDraughtAI.show.v.data;
						RussianDraughtAI compare = editRussianDraughtAI.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editRussianDraughtAI.compareOtherType.v.data != null) {
										if (editRussianDraughtAI.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
								differentIndicator.SetActive (isDifferent);
							} else {
								Debug.LogError ("differentIndicator null: " + this);
							}
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
								// timeLimit
								{
									RequestChangeIntUI.UIData timeLimit = this.data.timeLimit.v;
									if (timeLimit != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = timeLimit.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.timeLimit.v;
											updateData.canRequestChange.v = editRussianDraughtAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												timeLimit.showDifferent.v = true;
												timeLimit.compare.v = compare.timeLimit.v;
											} else {
												timeLimit.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("timeLimit null: " + this);
									}
								}
								// pickBestMove
								{
									RequestChangeIntUI.UIData pickBestMove = this.data.pickBestMove.v;
									if (pickBestMove != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = pickBestMove.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.pickBestMove.v;
											updateData.canRequestChange.v = editRussianDraughtAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												pickBestMove.showDifferent.v = true;
												pickBestMove.compare.v = compare.pickBestMove.v;
											} else {
												pickBestMove.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("pickBestMove null: " + this);
									}
								}
							}
							// reset?
							if (needReset) {
								needReset = false;
								// timeLimit
								{
									RequestChangeIntUI.UIData timeLimit = this.data.timeLimit.v;
									if (timeLimit != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = timeLimit.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.timeLimit.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("timeLimit null: " + this);
									}
								}
								// pickBestMove
								{
									RequestChangeIntUI.UIData pickBestMove = this.data.pickBestMove.v;
									if (pickBestMove != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = pickBestMove.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.pickBestMove.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("pickBestMove null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editRussianDraughtAI null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Russian Draughts AI");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbTimeLimit != null) {
							lbTimeLimit.text = txtTimeLimit.get ("Time limit");
						} else {
							Debug.LogError ("lbTimeLimit null: " + this);
						}
						if (lbPickBestMove != null) {
							lbPickBestMove.text = txtPickBestMove.get ("Pick best move");
						} else {
							Debug.LogError ("lbPickBestMove null: " + this);
						}
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

		public Transform timeLimitContainer;
		public Transform pickBestMoveContainer;

		public RequestChangeIntUI requestIntPrefab;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// Child
				{
					uiData.editAI.allAddCallBack (this);
					uiData.timeLimit.allAddCallBack (this);
					uiData.pickBestMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Child
			{
				// editAI
				{
					if (data is EditData<RussianDraughtAI>) {
						EditData<RussianDraughtAI> editAI = data as EditData<RussianDraughtAI>;
						// Child
						{
							editAI.show.allAddCallBack (this);
							editAI.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is RussianDraughtAI) {
							RussianDraughtAI russianDraughtAI = data as RussianDraughtAI;
							// Parent
							{
								DataUtils.addParentCallBack (russianDraughtAI, this, ref this.server);
							}
							dirty = true;
							needReset = true;
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
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.timeLimit:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, timeLimitContainer);
								}
								break;
							case UIData.Property.pickBestMove:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, pickBestMoveContainer);
								}
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
				// Setting
				Setting.get ().removeCallBack (this);
				// Child
				{
					uiData.editAI.allRemoveCallBack (this);
					uiData.timeLimit.allRemoveCallBack (this);
					uiData.pickBestMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			{
				// editAI
				{
					if (data is EditData<RussianDraughtAI>) {
						EditData<RussianDraughtAI> editAI = data as EditData<RussianDraughtAI>;
						// Child
						{
							editAI.show.allRemoveCallBack (this);
							editAI.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is RussianDraughtAI) {
							RussianDraughtAI russianDraughtAI = data as RussianDraughtAI;
							// Parent
							{
								DataUtils.removeParentCallBack (russianDraughtAI, this, ref this.server);
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
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.editAI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.timeLimit:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pickBestMove:
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
			// Setting
			if (wrapProperty.p is Setting) {
				switch ((Setting.Property)wrapProperty.n) {
				case Setting.Property.language:
					dirty = true;
					break;
				case Setting.Property.showLastMove:
					break;
				case Setting.Property.viewUrlImage:
					break;
				case Setting.Property.animationSetting:
					break;
				case Setting.Property.maxThinkCount:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				// editAI
				{
					if (wrapProperty.p is EditData<RussianDraughtAI>) {
						switch ((EditData<RussianDraughtAI>.Property)wrapProperty.n) {
						case EditData<RussianDraughtAI>.Property.origin:
							dirty = true;
							break;
						case EditData<RussianDraughtAI>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<RussianDraughtAI>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<RussianDraughtAI>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<RussianDraughtAI>.Property.canEdit:
							dirty = true;
							break;
						case EditData<RussianDraughtAI>.Property.editType:
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
						if (wrapProperty.p is RussianDraughtAI) {
							switch ((RussianDraughtAI.Property)wrapProperty.n) {
							case RussianDraughtAI.Property.timeLimit:
								dirty = true;
								break;
							case RussianDraughtAI.Property.pickBestMove:
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
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}