﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiAIUI : UIBehavior<XiangqiAIUI.UIData>
	{

		#region UIData

		public class UIData : AIUI.UIData.Sub
		{

			public VP<EditData<XiangqiAI>> editAI;

			#region Content

			#region depth

			public VP<RequestChangeIntUI.UIData> depth;

			public void makeRequestChangeDepth (RequestChangeUpdate<int>.UpdateData update, int newDepth)
			{
				// Find xiangqiAI
				XiangqiAI xiangqiAI = null;
				{
					EditData<XiangqiAI> editXiangqiAI = this.editAI.v;
					if (editXiangqiAI != null) {
						xiangqiAI = editXiangqiAI.show.v.data;
					} else {
						Debug.LogError ("editXiangqiAI null: " + this);
					}
				}
				// Process
				if (xiangqiAI != null) {
					xiangqiAI.requestChangeDepth (Server.getProfileUserId(xiangqiAI), newDepth);
				} else {
					Debug.LogError ("xiangqiAI null: " + this);
				}
			}

			#endregion

			#region thinkTime

			public VP<RequestChangeIntUI.UIData> thinkTime;

			public void makeRequestChangeThinkTime (RequestChangeUpdate<int>.UpdateData update, int newThinkTime)
			{
				// Find xiangqiAI
				XiangqiAI xiangqiAI = null;
				{
					EditData<XiangqiAI> editXiangqiAI = this.editAI.v;
					if (editXiangqiAI != null) {
						xiangqiAI = editXiangqiAI.show.v.data;
					} else {
						Debug.LogError ("editXiangqiAI null: " + this);
					}
				}
				// Process
				if (xiangqiAI != null) {
					xiangqiAI.requestChangeThinkTime (Server.getProfileUserId(xiangqiAI), newThinkTime);
				} else {
					Debug.LogError ("xiangqAI null: " + this);
				}
			}

			#endregion

			#region useBook

			public VP<RequestChangeBoolUI.UIData> useBook;

			public void makeRequestChangeUseBook (RequestChangeUpdate<bool>.UpdateData update, bool newUseBook)
			{
				// Find xiangqiAI
				XiangqiAI xiangqiAI = null;
				{
					EditData<XiangqiAI> editXiangqiAI = this.editAI.v;
					if (editXiangqiAI != null) {
						xiangqiAI = editXiangqiAI.show.v.data;
					} else {
						Debug.LogError ("editXiangqiAI null: " + this);
					}
				}
				// Process
				if (xiangqiAI != null) {
					xiangqiAI.requestChangeUseBook (Server.getProfileUserId(xiangqiAI), newUseBook);
				} else {
					Debug.LogError ("xiangqAI null: " + this);
				}
			}

			#endregion

			#region pickBestMove

			public VP<RequestChangeIntUI.UIData> pickBestMove;

			public void makeRequestChangePickBestMove (RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
			{
				// Find xiangqiAI
				XiangqiAI xiangqiAI = null;
				{
					EditData<XiangqiAI> editXiangqiAI = this.editAI.v;
					if (editXiangqiAI != null) {
						xiangqiAI = editXiangqiAI.show.v.data;
					} else {
						Debug.LogError ("editXiangqiAI null: " + this);
					}
				}
				// Process
				if (xiangqiAI != null) {
					xiangqiAI.requestChangePickBestMove (Server.getProfileUserId(xiangqiAI), newPickBestMove);
				} else {
					Debug.LogError ("xiangqAI null: " + this);
				}
			}

			#endregion

			#endregion

			#region Constructor

			public enum Property
			{
				editAI,
				// Content
				depth,
				thinkTime,
				useBook,
				pickBestMove
			}

			public UIData() : base()
			{
				this.editAI = new VP<EditData<XiangqiAI>>(this, (byte)Property.editAI, new EditData<XiangqiAI>());
				// Content
				{
					{
						this.depth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.depth, new RequestChangeIntUI.UIData());
						// have limit
						{
							IntLimit.Have have = new IntLimit.Have();
							{
								have.uid = this.depth.v.limit.makeId();
								have.min.v = 0;
								have.max.v = 30;
							}
							this.depth.v.limit.v = have;
						}
						// event
						this.depth.v.updateData.v.request.v = makeRequestChangeDepth;
					}
					{
						this.thinkTime = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.thinkTime, new RequestChangeIntUI.UIData());
						this.thinkTime.v.updateData.v.request.v = makeRequestChangeThinkTime;
					}
					{
						this.useBook = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useBook, new RequestChangeBoolUI.UIData());
						this.useBook.v.updateData.v.request.v = makeRequestChangeUseBook;
					}
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
						this.pickBestMove.v.updateData.v.request.v = makeRequestChangePickBestMove;
					}
				}
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Xiangqi;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbDepth;
		public static readonly TxtLanguage txtDepth = new TxtLanguage();

		public Text lbThinkTime;
		public static readonly TxtLanguage txtThinkTime = new TxtLanguage();

		public Text lbUseBook;
		public static readonly TxtLanguage txtUseBook = new TxtLanguage();

		public Text lbPickBestMove;
		public static readonly TxtLanguage txtPickBestMove = new TxtLanguage ();

		static XiangqiAIUI()
		{
			txtTitle.add (Language.Type.vi, "Cờ Tướng AI");
			txtDepth.add (Language.Type.vi, "Độ sâu");
			txtThinkTime.add (Language.Type.vi, "Thời gian nghĩ");
			txtUseBook.add (Language.Type.vi, "Dùng sách");
			txtPickBestMove.add (Language.Type.vi, "Chọn nước tốt nhất");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<XiangqiAI> editXiangqiAI = this.data.editAI.v;
					if (editXiangqiAI != null) {
						// update
						editXiangqiAI.update ();
						// get show
						XiangqiAI show = editXiangqiAI.show.v.data;
						XiangqiAI compare = editXiangqiAI.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editXiangqiAI.compareOtherType.v.data != null) {
										if (editXiangqiAI.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// Debug.LogError ("server null: " + this);
								}
							}
							// set origin
							{
								// depth
								{
									RequestChangeIntUI.UIData depth = this.data.depth.v;
									if (depth != null) {
										// updateData
										RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.depth.v;
											updateData.canRequestChange.v = editXiangqiAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												depth.showDifferent.v = true;
												depth.compare.v = compare.depth.v;
											} else {
												depth.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
								// thinkTime
								{
									RequestChangeIntUI.UIData thinkTime = this.data.thinkTime.v;
									if (thinkTime != null) {
										// updateData
										RequestChangeUpdate<int>.UpdateData updateData = thinkTime.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.thinkTime.v;
											updateData.canRequestChange.v = editXiangqiAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												thinkTime.showDifferent.v = true;
												thinkTime.compare.v = compare.thinkTime.v;
											} else {
												thinkTime.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("lngLimitTime null: " + this);
									}
								}
								// useBook
								{
									RequestChangeBoolUI.UIData useBook = this.data.useBook.v;
									if (useBook != null) {
										// updateData
										RequestChangeUpdate<bool>.UpdateData updateData = useBook.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.useBook.v;
											updateData.canRequestChange.v = editXiangqiAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												useBook.showDifferent.v = true;
												useBook.compare.v = compare.useBook.v;
											} else {
												useBook.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("useBook null: " + this);
									}
								}
								// pickBestMove
								{
									RequestChangeIntUI.UIData pickBestMove = this.data.pickBestMove.v;
									if (pickBestMove != null) {
										// updateData
										RequestChangeUpdate<int>.UpdateData updateData = pickBestMove.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.pickBestMove.v;
											updateData.canRequestChange.v = editXiangqiAI.canEdit.v;
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
								// depth
								{
									RequestChangeIntUI.UIData depth = this.data.depth.v;
									if (depth != null) {
										RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.depth.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("depth null: " + this);
									}
								}
								// thinkTime
								{
									RequestChangeIntUI.UIData thinkTime = this.data.thinkTime.v;
									if (thinkTime != null) {
										RequestChangeUpdate<int>.UpdateData updateData = thinkTime.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.thinkTime.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("lngLimitTime null: " + this);
									}
								}
								// useBook
								{
									RequestChangeBoolUI.UIData useBook = this.data.useBook.v;
									if (useBook != null) {
										RequestChangeUpdate<bool>.UpdateData updateData = useBook.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.useBook.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("useBook null: " + this);
									}
								}
								// pickBestMove
								{
									RequestChangeIntUI.UIData pickBestMove = this.data.pickBestMove.v;
									if (pickBestMove != null) {
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
							Debug.LogError ("xiangqiAI null: " + this);
						}
					} else {
						Debug.LogError ("editXiangqiAI null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Xiangqi AI");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbDepth != null) {
							lbDepth.text = txtDepth.get ("Depth");
						} else {
							Debug.LogError ("lbDepth null: " + this);
						}
						if (lbThinkTime != null) {
							lbThinkTime.text = txtThinkTime.get ("Think time");
						} else {
							Debug.LogError ("lbThinkTime null: " + this);
						}
						if (lbUseBook != null) {
							lbUseBook.text = txtUseBook.get ("Use book");
						} else {
							Debug.LogError ("lbUseBook null: " + this);
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

		public Transform depthContainer;
		public Transform thinkTimeContainer;
		public Transform useBookContainer;
		public Transform pickBestMoveContainer;

		public RequestChangeIntUI requestIntPrefab;
		public RequestChangeBoolUI requestBoolPrefab;

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
					uiData.depth.allAddCallBack (this);
					uiData.thinkTime.allAddCallBack (this);
					uiData.useBook.allAddCallBack (this);
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
					if (data is EditData<XiangqiAI>) {
						EditData<XiangqiAI> editAI = data as EditData<XiangqiAI>;
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
						if (data is XiangqiAI) {
							XiangqiAI xiangqiAI = data as XiangqiAI;
							// Parent
							{
								DataUtils.addParentCallBack (xiangqiAI, this, ref this.server);
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
							case UIData.Property.depth:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, depthContainer);
								}
								break;
							case UIData.Property.thinkTime:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, thinkTimeContainer);
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
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.useBook:
								{
									UIUtils.Instantiate (requestChange, requestBoolPrefab, useBookContainer);
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
					uiData.depth.allRemoveCallBack (this);
					uiData.thinkTime.allRemoveCallBack (this);
					uiData.useBook.allRemoveCallBack (this);
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
					if (data is EditData<XiangqiAI>) {
						EditData<XiangqiAI> editAI = data as EditData<XiangqiAI>;
						// Child
						{
							editAI.show.allRemoveCallBack (this);
							editAI.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is XiangqiAI) {
							XiangqiAI xiangqiAI = data as XiangqiAI;
							// Parent
							{
								DataUtils.removeParentCallBack (xiangqiAI, this, ref this.server);
							}
							return;
						}
						// Parent
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
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeBoolUI));
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
				case UIData.Property.depth:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.thinkTime:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.useBook:
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
					if (wrapProperty.p is EditData<XiangqiAI>) {
						switch ((EditData<XiangqiAI>.Property)wrapProperty.n) {
						case EditData<XiangqiAI>.Property.origin:
							dirty = true;
							break;
						case EditData<XiangqiAI>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<XiangqiAI>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<XiangqiAI>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<XiangqiAI>.Property.canEdit:
							dirty = true;
							break;
						case EditData<XiangqiAI>.Property.editType:
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
						if (wrapProperty.p is XiangqiAI) {
							switch ((XiangqiAI.Property)wrapProperty.n) {
							case XiangqiAI.Property.depth:
								dirty = true;
								break;
							case XiangqiAI.Property.thinkTime:
								dirty = true;
								break;
							case XiangqiAI.Property.useBook:
								dirty = true;
								break;
							case XiangqiAI.Property.pickBestMove:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Parent
						if (wrapProperty.p is Server) {
							Server.State.OnUpdateSyncStateChange (wrapProperty, this);
							return;
						}
					}
				}
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
					return;
				}
				if (wrapProperty.p is RequestChangeBoolUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}