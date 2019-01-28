﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
	public class GomokuAIUI : UIBehavior<GomokuAIUI.UIData>
	{

		#region UIData

		public class UIData : AIUI.UIData.Sub
		{

			public VP<EditData<GomokuAI>> editAI;

			#region searchDepth

			public VP<RequestChangeIntUI.UIData> searchDepth;

			public void makeRequestChangeSearchDepth (RequestChangeUpdate<int>.UpdateData update, int newSearchDepth)
			{
				// Find gomokuAI
				GomokuAI gomokuAI = null;
				{
					EditData<GomokuAI> editGomokuAI = this.editAI.v;
					if (editGomokuAI != null) {
						gomokuAI = editGomokuAI.show.v.data;
					} else {
						Debug.LogError ("editGomokuAI null: " + this);
					}
				}
				// Process
				if (gomokuAI != null) {
					gomokuAI.requestChangeSearchDepth (Server.getProfileUserId(gomokuAI), newSearchDepth);
				} else {
					Debug.LogError ("gomokuAI null: " + this);
				}
			}

			#endregion

			#region timeLimit

			public VP<RequestChangeIntUI.UIData> timeLimit;

			public void makeRequestChangeTimeLimit (RequestChangeUpdate<int>.UpdateData update, int newTimeLimit)
			{
				// Find gomokuAI
				GomokuAI gomokuAI = null;
				{
					EditData<GomokuAI> editGomokuAI = this.editAI.v;
					if (editGomokuAI != null) {
						gomokuAI = editGomokuAI.show.v.data;
					} else {
						Debug.LogError ("editGomokuAI null: " + this);
					}
				}
				// Process
				if (gomokuAI != null) {
					gomokuAI.requestChangeTimeLimit (Server.getProfileUserId(gomokuAI), newTimeLimit);
				} else {
					Debug.LogError ("gomokuAI null: " + this);
				}
			}

			#endregion

			#region level

			public VP<RequestChangeIntUI.UIData> level;

			public void makeRequestChangeLevel (RequestChangeUpdate<int>.UpdateData update, int newLevel)
			{
				// Find gomokuAI
				GomokuAI gomokuAI = null;
				{
					EditData<GomokuAI> editGomokuAI = this.editAI.v;
					if (editGomokuAI != null) {
						gomokuAI = editGomokuAI.show.v.data;
					} else {
						Debug.LogError ("editGomokuAI null: " + this);
					}
				}
				// Process
				if (gomokuAI != null) {
					gomokuAI.requestChangeLevel (Server.getProfileUserId(gomokuAI), newLevel);
				} else {
					Debug.LogError ("gomokuAI null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editAI,
				searchDepth,
				timeLimit,
				level
			}

			public UIData() : base()
			{
				this.editAI = new VP<EditData<GomokuAI>>(this, (byte)Property.editAI, new EditData<GomokuAI>());
				// Content
				{
					// searchDepth
					{
						this.searchDepth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.searchDepth, new RequestChangeIntUI.UIData());
						// have limit
						{
							IntLimit.Have have = new IntLimit.Have();
							{
								have.uid = this.searchDepth.v.limit.makeId();
								have.min.v = 0;
								have.max.v = 30;
							}
							this.searchDepth.v.limit.v = have;
						}
						// event
						this.searchDepth.v.updateData.v.request.v = makeRequestChangeSearchDepth;
					}
					// timeLimit
					{
						this.timeLimit = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.timeLimit, new RequestChangeIntUI.UIData());
						// event
						this.timeLimit.v.updateData.v.request.v = makeRequestChangeTimeLimit;
					}
					// level
					{
						this.level = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.level, new RequestChangeIntUI.UIData());
						// have limit
						{
							IntLimit.Have have = new IntLimit.Have();
							{
								have.uid = this.level.v.limit.makeId();
								have.min.v = 0;
								have.max.v = 20;
							}
							this.level.v.limit.v = have;
						}
						// event
						this.level.v.updateData.v.request.v = makeRequestChangeLevel;
					}
				}
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Gomoku;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbSearchDepth;
		public static readonly TxtLanguage txtSearchDepth = new TxtLanguage();

		public Text lbTimeLimit;
		public static readonly TxtLanguage txtTimeLimit = new TxtLanguage();

		public Text lbLevel;
		public static readonly TxtLanguage txtLevel = new TxtLanguage ();

		static GomokuAIUI()
		{
			txtTitle.add (Language.Type.vi, "Cờ Caro AI");
			txtSearchDepth.add (Language.Type.vi, "Độ sâu tìm kiếm");
			txtTimeLimit.add (Language.Type.vi, "Thời gian giới hạn");
			txtLevel.add (Language.Type.vi, "Cấp độ");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<GomokuAI> editGomokuAI = this.data.editAI.v;
					if (editGomokuAI != null) {
						editGomokuAI.update ();
						// get show
						GomokuAI show = editGomokuAI.show.v.data;
						GomokuAI compare = editGomokuAI.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editGomokuAI.compareOtherType.v.data != null) {
										if (editGomokuAI.compareOtherType.v.data.GetType () != show.GetType ()) {
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
								// searchDepth
								{
									RequestChangeIntUI.UIData searchDepth = this.data.searchDepth.v;
									if (searchDepth != null) {
										// updateData
										RequestChangeUpdate<int>.UpdateData updateData = searchDepth.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.searchDepth.v;
											updateData.canRequestChange.v = editGomokuAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												searchDepth.showDifferent.v = true;
												searchDepth.compare.v = compare.searchDepth.v;
											} else {
												searchDepth.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
								// timeLimit
								{
									RequestChangeIntUI.UIData timeLimit = this.data.timeLimit.v;
									if (timeLimit != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = timeLimit.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.timeLimit.v;
											updateData.canRequestChange.v = editGomokuAI.canEdit.v;
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
										Debug.LogError ("depth null: " + this);
									}
								}
								// level
								{
									RequestChangeIntUI.UIData level = this.data.level.v;
									if (level != null) {
										// updateData
										RequestChangeUpdate<int>.UpdateData updateData = level.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.level.v;
											updateData.canRequestChange.v = editGomokuAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												level.showDifferent.v = true;
												level.compare.v = compare.level.v;
											} else {
												level.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
							}
							// reset?
							if (needReset) {
								needReset = false;
								// searchDepth
								{
									RequestChangeIntUI.UIData searchDepth = this.data.searchDepth.v;
									if (searchDepth != null) {
										RequestChangeUpdate<int>.UpdateData updateData = searchDepth.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.searchDepth.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
								// timeLimit
								{
									RequestChangeIntUI.UIData timeLimit = this.data.timeLimit.v;
									if (timeLimit != null) {
										RequestChangeUpdate<int>.UpdateData updateData = timeLimit.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.timeLimit.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
								// level
								{
									RequestChangeIntUI.UIData level = this.data.level.v;
									if (level != null) {
										RequestChangeUpdate<int>.UpdateData updateData = level.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.level.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("chessAI null: " + this);
						}
					} else {
						Debug.LogError ("editChessAI null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Gomoku AI");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbSearchDepth != null) {
							lbSearchDepth.text = txtSearchDepth.get ("Search depth");
						} else {
							Debug.LogError ("lbSearchDepth null: " + this);
						}
						if (lbTimeLimit != null) {
							lbTimeLimit.text = txtTimeLimit.get ("Time limit");
						} else {
							Debug.LogError ("lbTimeLimit null: " + this);
						}
						if (lbLevel != null) {
							lbLevel.text = txtLevel.get ("Level");
						} else {
							Debug.LogError ("lbLevel null: " + this);
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

		public Transform searchDepthContainer;
		public Transform timeLimitContainer;
		public Transform levelContainer;

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
					uiData.searchDepth.allAddCallBack (this);
					uiData.timeLimit.allAddCallBack (this);
					uiData.level.allAddCallBack (this);
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
					if (data is EditData<GomokuAI>) {
						EditData<GomokuAI> editAI = data as EditData<GomokuAI>;
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
						if (data is GomokuAI) {
							GomokuAI gomokuAI = data as GomokuAI;
							// Parent
							{
								DataUtils.addParentCallBack (gomokuAI, this, ref this.server);
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
							case UIData.Property.searchDepth:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, searchDepthContainer);
								}
								break;
							case UIData.Property.timeLimit:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, timeLimitContainer);
								}
								break;
							case UIData.Property.level:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, levelContainer);
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
					uiData.searchDepth.allRemoveCallBack (this);
					uiData.timeLimit.allRemoveCallBack (this);
					uiData.level.allRemoveCallBack (this);
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
					if (data is EditData<GomokuAI>) {
						EditData<GomokuAI> editAI = data as EditData<GomokuAI>;
						// Child
						{
							editAI.show.allRemoveCallBack (this);
							editAI.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is GomokuAI) {
							GomokuAI gomokuAI = data as GomokuAI;
							// Parent
							{
								DataUtils.removeParentCallBack (gomokuAI, this, ref this.server);
							}
							return;
						}
						if (data is Server) {
							return;
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
				case UIData.Property.searchDepth:
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
				case UIData.Property.level:
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
					if (wrapProperty.p is EditData<GomokuAI>) {
						switch ((EditData<GomokuAI>.Property)wrapProperty.n) {
						case EditData<GomokuAI>.Property.origin:
							dirty = true;
							break;
						case EditData<GomokuAI>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<GomokuAI>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<GomokuAI>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<GomokuAI>.Property.canEdit:
							dirty = true;
							break;
						case EditData<GomokuAI>.Property.editType:
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
						if (wrapProperty.p is GomokuAI) {
							switch ((GomokuAI.Property)wrapProperty.n) {
							case GomokuAI.Property.searchDepth:
								dirty = true;
								break;
							case GomokuAI.Property.timeLimit:
								dirty = true;
								break;
							case GomokuAI.Property.level:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						if (wrapProperty.p is Server) {
							Server.State.OnUpdateSyncStateChange (wrapProperty, this);
							return;
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