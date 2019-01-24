using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class TotalTimeInfoLimitUI : UIBehavior<TotalTimeInfoLimitUI.UIData>
	{

		#region UIData

		public class UIData : TotalTimeInfoUI.UIData.Sub
		{

			public VP<EditData<TotalTimeInfo.Limit>> editLimit;

			#region perTurn

			public VP<RequestChangeFloatUI.UIData> totalTime;

			public void makeRequestChangeTotalTime (RequestChangeUpdate<float>.UpdateData update, float newTotalTime)
			{
				// Find
				TotalTimeInfo.Limit limit = null;
				{
					EditData<TotalTimeInfo.Limit> editLimit = this.editLimit.v;
					if (editLimit != null) {
						limit = editLimit.show.v.data;
					} else {
						Debug.LogError ("editLimit null: " + this);
					}
				}
				// Process
				if (limit != null) {
					limit.requestChangeTotalTime (Server.getProfileUserId(limit), newTotalTime);
				} else {
					Debug.LogError ("limit null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editLimit,
				totalTime
			}

			public UIData() : base()
			{
				this.editLimit = new VP<EditData<TotalTimeInfo.Limit>>(this, (byte)Property.editLimit, new EditData<TotalTimeInfo.Limit>());
				// totalTime
				{
					this.totalTime = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.totalTime, new RequestChangeFloatUI.UIData());
					// event
					this.totalTime.v.updateData.v.request.v = makeRequestChangeTotalTime;
				}
			}

			#endregion

			public override TotalTimeInfo.Type getType ()
			{
				return TotalTimeInfo.Type.Limit;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbTotalTime;
		public static readonly TxtLanguage txtTotalTime = new TxtLanguage();

		static TotalTimeInfoLimitUI()
		{
			txtTitle.add (Language.Type.vi, "Tổng Thời Gian Giới Hạn");
			txtTotalTime.add (Language.Type.vi, "Tổng thời gian");
		}

		#endregion

		private bool needReset = true;
		public GameObject differentIndicator;

		public override void refresh ()
		{
			if(dirty){
				dirty = false;
				if (this.data != null) {
					EditData<TotalTimeInfo.Limit> editLimit = this.data.editLimit.v;
					if (editLimit != null) {
						editLimit.update ();
						// get show
						TotalTimeInfo.Limit show = editLimit.show.v.data;
						TotalTimeInfo.Limit compare = editLimit.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editLimit.compareOtherType.v.data != null) {
										if (editLimit.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// perTurn
									{
										RequestChangeFloatUI.UIData perTurn = this.data.totalTime.v;
										if (perTurn != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = perTurn.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.totalTime.v;
												updateData.canRequestChange.v = editLimit.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													perTurn.showDifferent.v = true;
													perTurn.compare.v = compare.totalTime.v;
												} else {
													perTurn.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("perTurn null: " + this);
										}
									}
								}
								// reset
								if (needReset) {
									needReset = false;
									// perTurn
									{
										RequestChangeFloatUI.UIData perTurn = this.data.totalTime.v;
										if (perTurn != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = perTurn.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.totalTime.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("perTurn null: " + this);
										}
									}
								}
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editLimit null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Total Time Limit");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbTotalTime != null) {
							lbTotalTime.text = txtTotalTime.get ("Total time");
						} else {
							Debug.LogError ("lbTotalTime null: " + this);
						}
						txtTotalTime.add (Language.Type.vi, "Tổng thời gian");
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

		public RequestChangeFloatUI requestFloatPrefab;
		public Transform totalTimeContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editLimit.allAddCallBack (this);
					uiData.totalTime.allAddCallBack (this);
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
				// editLimit
				{
					if (data is EditData<TotalTimeInfo.Limit>) {
						EditData<TotalTimeInfo.Limit> editLimit = data as EditData<TotalTimeInfo.Limit>;
						// Child
						{
							editLimit.show.allAddCallBack (this);
							editLimit.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is TotalTimeInfo.Limit) {
							TotalTimeInfo.Limit limit = data as TotalTimeInfo.Limit;
							// Parent
							{
								DataUtils.addParentCallBack (limit, this, ref this.server);
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
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.totalTime:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, totalTimeContainer);
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
					uiData.editLimit.allRemoveCallBack (this);
					uiData.totalTime.allRemoveCallBack (this);
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
				// editLimit
				{
					if (data is EditData<TotalTimeInfo.Limit>) {
						EditData<TotalTimeInfo.Limit> editLimit = data as EditData<TotalTimeInfo.Limit>;
						// Child
						{
							editLimit.show.allRemoveCallBack (this);
							editLimit.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is TotalTimeInfo.Limit) {
							TotalTimeInfo.Limit limit = data as TotalTimeInfo.Limit;
							// Parent
							{
								DataUtils.removeParentCallBack (limit, this, ref this.server);
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
				case UIData.Property.editLimit:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.totalTime:
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
				// editLimit
				{
					if (wrapProperty.p is EditData<TotalTimeInfo.Limit>) {
						switch ((EditData<TotalTimeInfo.Limit>.Property)wrapProperty.n) {
						case EditData<TotalTimeInfo.Limit>.Property.origin:
							dirty = true;
							break;
						case EditData<TotalTimeInfo.Limit>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TotalTimeInfo.Limit>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TotalTimeInfo.Limit>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<TotalTimeInfo.Limit>.Property.canEdit:
							dirty = true;
							break;
						case EditData<TotalTimeInfo.Limit>.Property.editType:
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
						if (wrapProperty.p is TotalTimeInfo.Limit) {
							switch ((TotalTimeInfo.Limit.Property)wrapProperty.n) {
							case TotalTimeInfo.Limit.Property.totalTime:
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
				if (wrapProperty.p is RequestChangeFloatUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}