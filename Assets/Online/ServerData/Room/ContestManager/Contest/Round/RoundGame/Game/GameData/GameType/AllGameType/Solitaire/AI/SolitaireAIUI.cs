using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireAIUI : UIBehavior<SolitaireAIUI.UIData>
	{

		#region UIData

		public class UIData : AIUI.UIData.Sub
		{

			public VP<EditData<SolitaireAI>> editAI;

			#region multiThreaded

			public VP<RequestChangeIntUI.UIData> multiThreaded;

			public void makeRequestChangeMultiThreaded (RequestChangeUpdate<int>.UpdateData update, int newMultiThreaded)
			{
				// Find
				SolitaireAI solitaireAI = null;
				{
					EditData<SolitaireAI> editSolitaireAI = this.editAI.v;
					if (editSolitaireAI != null) {
						solitaireAI = editSolitaireAI.show.v.data;
					} else {
						Debug.LogError ("editSolitaireAI null: " + this);
					}
				}
				// Process
				if (solitaireAI != null) {
					solitaireAI.requestChangeMultiThreaded (Server.getProfileUserId(solitaireAI), newMultiThreaded);
				} else {
					Debug.LogError ("solitaireAI null: " + this);
				}
			}

			#endregion

			#region maxClosedCount

			public VP<RequestChangeIntUI.UIData> maxClosedCount;

			public void makeRequestChangeMaxClosedCount (RequestChangeUpdate<int>.UpdateData update, int newMaxClosedCount)
			{
				// Find
				SolitaireAI solitaireAI = null;
				{
					EditData<SolitaireAI> editSolitaireAI = this.editAI.v;
					if (editSolitaireAI != null) {
						solitaireAI = editSolitaireAI.show.v.data;
					} else {
						Debug.LogError ("editSolitaireAI null: " + this);
					}
				}
				// Process
				if (solitaireAI != null) {
					solitaireAI.requestChangeMaxClosedCount (Server.getProfileUserId(solitaireAI), newMaxClosedCount);
				} else {
					Debug.LogError ("solitaireAI null: " + this);
				}
			}

			#endregion

			#region fastMode

			public VP<RequestChangeBoolUI.UIData> fastMode;

			public void makeRequestChangeFastMode (RequestChangeUpdate<bool>.UpdateData update, bool newFastMode)
			{
				// Find
				SolitaireAI solitaireAI = null;
				{
					EditData<SolitaireAI> editSolitaireAI = this.editAI.v;
					if (editSolitaireAI != null) {
						solitaireAI = editSolitaireAI.show.v.data;
					} else {
						Debug.LogError ("editSolitaireAI null: " + this);
					}
				}
				// Process
				if (solitaireAI != null) {
					solitaireAI.requestChangeFastMode (Server.getProfileUserId(solitaireAI), newFastMode);
				} else {
					Debug.LogError ("solitaireAI null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editAI,
				multiThreaded,
				maxClosedCount,
				fastMode
			}

			public UIData() : base()
			{
				this.editAI = new VP<EditData<SolitaireAI>>(this, (byte)Property.editAI, new EditData<SolitaireAI>());
				// multiThreaded
				{
					this.multiThreaded = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.multiThreaded, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.multiThreaded.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 5;
						}
						this.multiThreaded.v.limit.v = have;
					}
					// event
					this.multiThreaded.v.updateData.v.request.v = makeRequestChangeMultiThreaded;
				}
				// maxClosedCount
				{
					this.maxClosedCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxClosedCount, new RequestChangeIntUI.UIData());
					// event
					this.maxClosedCount.v.updateData.v.request.v = makeRequestChangeMaxClosedCount;
				}
				// fastMode
				{
					this.fastMode = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.fastMode, new RequestChangeBoolUI.UIData());
					// event
					this.fastMode.v.updateData.v.request.v = makeRequestChangeFastMode;
				}
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Solitaire;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbMultiThreaded;
		public static readonly TxtLanguage txtMultiThreaded = new TxtLanguage();

		public Text lbMaxClosedCount;
		public static readonly TxtLanguage txtMaxClosedCount = new TxtLanguage ();

		public Text lbFastMode;
		public static readonly TxtLanguage txtFastMode = new TxtLanguage ();

		static SolitaireAIUI()
		{
			txtTitle.add (Language.Type.vi, "AI Solitaire");
			txtMultiThreaded.add (Language.Type.vi, "Đa luồng");
			txtMaxClosedCount.add (Language.Type.vi, "Max closed count");
			txtFastMode.add (Language.Type.vi, "Kiểu nhanh");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<SolitaireAI> editSolitaireAI = this.data.editAI.v;
					if (editSolitaireAI != null) {
						editSolitaireAI.update ();
						// get show
						SolitaireAI show = editSolitaireAI.show.v.data;
						SolitaireAI compare = editSolitaireAI.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editSolitaireAI.compareOtherType.v.data != null) {
										if (editSolitaireAI.compareOtherType.v.data.GetType () != show.GetType ()) {
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
								// multiThreaded
								{
									RequestChangeIntUI.UIData multiThreaded = this.data.multiThreaded.v;
									if (multiThreaded != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = multiThreaded.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.multiThreaded.v;
											updateData.canRequestChange.v = editSolitaireAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												multiThreaded.showDifferent.v = true;
												multiThreaded.compare.v = compare.multiThreaded.v;
											} else {
												multiThreaded.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("multiThreaded null: " + this);
									}
								}
								// maxClosedCount
								{
									RequestChangeIntUI.UIData maxClosedCount = this.data.maxClosedCount.v;
									if (maxClosedCount != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = maxClosedCount.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.maxClosedCount.v;
											updateData.canRequestChange.v = editSolitaireAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												maxClosedCount.showDifferent.v = true;
												maxClosedCount.compare.v = compare.maxClosedCount.v;
											} else {
												maxClosedCount.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("maxClosedCount null: " + this);
									}
								}
								// fastMode
								{
									RequestChangeBoolUI.UIData fastMode = this.data.fastMode.v;
									if (fastMode != null) {
										// update
										RequestChangeUpdate<bool>.UpdateData updateData = fastMode.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.fastMode.v;
											updateData.canRequestChange.v = editSolitaireAI.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												fastMode.showDifferent.v = true;
												fastMode.compare.v = compare.fastMode.v;
											} else {
												fastMode.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("fastMode null: " + this);
									}
								}
							}
							// reset?
							if (needReset) {
								needReset = false;
								// multiThreaded
								{
									RequestChangeIntUI.UIData multiThreaded = this.data.multiThreaded.v;
									if (multiThreaded != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = multiThreaded.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.multiThreaded.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("multiThreaded null: " + this);
									}
								}
								// maxClosedCount
								{
									RequestChangeIntUI.UIData maxClosedCount = this.data.maxClosedCount.v;
									if (maxClosedCount != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = maxClosedCount.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.maxClosedCount.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("maxClosedCount null: " + this);
									}
								}
								// fastMode
								{
									RequestChangeBoolUI.UIData fastMode = this.data.fastMode.v;
									if (fastMode != null) {
										// update
										RequestChangeUpdate<bool>.UpdateData updateData = fastMode.updateData.v;
										if (updateData != null) {
											updateData.current.v = show.fastMode.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("fastMode null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("solitaireAI null: " + this);
						}
					} else {
						Debug.LogError ("editSolitaireAI null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Solitaire AI");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbMultiThreaded != null) {
							lbMultiThreaded.text = txtMultiThreaded.get ("MultiThreaded");
						} else {
							Debug.LogError ("lbMultiThreaded null: " + this);
						}
						if (lbMaxClosedCount != null) {
							lbMaxClosedCount.text = txtMaxClosedCount.get ("Max closed count");
						} else {
							Debug.LogError ("lbMaxClosedCount null: " + this);
						}
						if (lbFastMode != null) {
							lbFastMode.text = txtFastMode.get ("Fast mode");
						} else {
							Debug.LogError ("lbFastMode null: " + this);
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

		public Transform multiThreadedContainer;
		public Transform maxClosedCountContainer;
		public Transform fastModeContainer;

		public RequestChangeIntUI requestIntPrefab;
		public RequestChangeBoolUI requestBoolPrefab;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editAI.allAddCallBack (this);
					uiData.multiThreaded.allAddCallBack (this);
					uiData.maxClosedCount.allAddCallBack (this);
					uiData.fastMode.allAddCallBack (this);
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
					if (data is EditData<SolitaireAI>) {
						EditData<SolitaireAI> editAI = data as EditData<SolitaireAI>;
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
						if (data is SolitaireAI) {
							SolitaireAI solitaireAI = data as SolitaireAI;
							// Parent
							{
								DataUtils.addParentCallBack (solitaireAI, this, ref this.server);
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
							case UIData.Property.multiThreaded:
								UIUtils.Instantiate (requestChange, requestIntPrefab, multiThreadedContainer);
								break;
							case UIData.Property.maxClosedCount:
								UIUtils.Instantiate (requestChange, requestIntPrefab, maxClosedCountContainer);
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
							case UIData.Property.fastMode:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, fastModeContainer);
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
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.editAI.allRemoveCallBack (this);
					uiData.multiThreaded.allRemoveCallBack (this);
					uiData.maxClosedCount.allRemoveCallBack (this);
					uiData.fastMode.allRemoveCallBack (this);
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
					if (data is EditData<SolitaireAI>) {
						EditData<SolitaireAI> editAI = data as EditData<SolitaireAI>;
						// Child
						{
							editAI.show.allRemoveCallBack (this);
							editAI.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is SolitaireAI) {
							SolitaireAI solitaireAI = data as SolitaireAI;
							// Parent
							{
								DataUtils.removeParentCallBack (solitaireAI, this, ref this.server);
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
				case UIData.Property.multiThreaded:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.maxClosedCount:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.fastMode:
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
					if (wrapProperty.p is EditData<SolitaireAI>) {
						switch ((EditData<SolitaireAI>.Property)wrapProperty.n) {
						case EditData<SolitaireAI>.Property.origin:
							dirty = true;
							break;
						case EditData<SolitaireAI>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<SolitaireAI>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<SolitaireAI>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<SolitaireAI>.Property.canEdit:
							dirty = true;
							break;
						case EditData<SolitaireAI>.Property.editType:
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
						if (wrapProperty.p is SolitaireAI) {
							switch ((SolitaireAI.Property)wrapProperty.n) {
							case SolitaireAI.Property.multiThreaded:
								dirty = true;
								break;
							case SolitaireAI.Property.maxClosedCount:
								dirty = true;
								break;
							case SolitaireAI.Property.fastMode:
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
				if (wrapProperty.p is RequestChangeBoolUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}