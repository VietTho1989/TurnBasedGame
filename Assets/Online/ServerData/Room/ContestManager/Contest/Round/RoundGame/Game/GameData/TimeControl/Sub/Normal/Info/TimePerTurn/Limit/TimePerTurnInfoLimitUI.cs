using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class TimePerTurnInfoLimitUI : UIBehavior<TimePerTurnInfoLimitUI.UIData>
	{

		#region UIData

		public class UIData : TimePerTurnInfoUI.UIData.Sub
		{

			public VP<EditData<TimePerTurnInfo.Limit>> editLimit;

			#region perTurn

			public VP<RequestChangeFloatUI.UIData> perTurn;

			public void makeRequestChangePerTurn (RequestChangeUpdate<float>.UpdateData update, float newPerTurn)
			{
				// Find
				TimePerTurnInfo.Limit limit = null;
				{
					EditData<TimePerTurnInfo.Limit> editLimit = this.editLimit.v;
					if (editLimit != null) {
						limit = editLimit.show.v.data;
					} else {
						Debug.LogError ("editLimit null: " + this);
					}
				}
				// Process
				if (limit != null) {
					limit.requestChangePerTurn (Server.getProfileUserId(limit), newPerTurn);
				} else {
					Debug.LogError ("limit null: " + this);
				}
			}

			#endregion

			#region Constructor

			public enum Property
			{
				editLimit,
				perTurn
			}

			public UIData() : base()
			{
				this.editLimit = new VP<EditData<TimePerTurnInfo.Limit>>(this, (byte)Property.editLimit, new EditData<TimePerTurnInfo.Limit>());
				// perTurn
				{
					this.perTurn = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.perTurn, new RequestChangeFloatUI.UIData());
					// event
					this.perTurn.v.updateData.v.request.v = makeRequestChangePerTurn;
				}
			}

			#endregion

			public override TimePerTurnInfo.Type getType ()
			{
				return TimePerTurnInfo.Type.Limit;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage ();

		public Text lbPerTurn;
		public static readonly TxtLanguage txtPerTurn = new TxtLanguage();

		static TimePerTurnInfoLimitUI()
		{
            // txt
            {
                txtTitle.add(Language.Type.vi, "Giới Hạn Thời Gian Mỗi Lượt");
                txtPerTurn.add(Language.Type.vi, "Mỗi lượt");
            }
            // rect
            {
                // perTurnRect
                perTurnRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            }
        }

		#endregion

		private bool needReset = true;

		public override void refresh ()
		{
			if(dirty){
				dirty = false;
				if (this.data != null) {
					EditData<TimePerTurnInfo.Limit> editLimit = this.data.editLimit.v;
					if (editLimit != null) {
						editLimit.update ();
						// get show
						TimePerTurnInfo.Limit show = editLimit.show.v.data;
						TimePerTurnInfo.Limit compare = editLimit.compare.v.data;
						if (show != null) {
							// different
							if (lbTitle != null) {
								bool isDifferent = false;
								{
									if (editLimit.compareOtherType.v.data != null) {
										if (editLimit.compareOtherType.v.data.GetType () != show.GetType ()) {
											isDifferent = true;
										}
									}
								}
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
							} else {
								Debug.LogError ("lbTitle null: " + this);
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
										RequestChangeFloatUI.UIData perTurn = this.data.perTurn.v;
										if (perTurn != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = perTurn.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.perTurn.v;
												updateData.canRequestChange.v = editLimit.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													perTurn.showDifferent.v = true;
													perTurn.compare.v = compare.perTurn.v;
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
										RequestChangeFloatUI.UIData perTurn = this.data.perTurn.v;
										if (perTurn != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = perTurn.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.perTurn.v;
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
							lbTitle.text = txtTitle.get ("Time Per Turn Limit");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbPerTurn != null) {
							lbPerTurn.text = txtPerTurn.get ("Per turn");
						} else {
							Debug.LogError ("lbPerTurn null: " + this);
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

		public RequestChangeFloatUI requestFloatPrefab;
        private static readonly UIRectTransform perTurnRect = new UIRectTransform(UIConstants.RequestRect); 

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
					uiData.perTurn.allAddCallBack (this);
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
					if (data is EditData<TimePerTurnInfo.Limit>) {
						EditData<TimePerTurnInfo.Limit> editLimit = data as EditData<TimePerTurnInfo.Limit>;
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
						if (data is TimePerTurnInfo.Limit) {
							TimePerTurnInfo.Limit limit = data as TimePerTurnInfo.Limit;
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
							case UIData.Property.perTurn:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, this.transform, perTurnRect);
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
					uiData.perTurn.allRemoveCallBack (this);
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
					if (data is EditData<TimePerTurnInfo.Limit>) {
						EditData<TimePerTurnInfo.Limit> editLimit = data as EditData<TimePerTurnInfo.Limit>;
						// Child
						{
							editLimit.show.allRemoveCallBack (this);
							editLimit.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is TimePerTurnInfo.Limit) {
							TimePerTurnInfo.Limit limit = data as TimePerTurnInfo.Limit;
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
				case UIData.Property.perTurn:
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
					if (wrapProperty.p is EditData<TimePerTurnInfo.Limit>) {
						switch ((EditData<TimePerTurnInfo.Limit>.Property)wrapProperty.n) {
						case EditData<TimePerTurnInfo.Limit>.Property.origin:
							dirty = true;
							break;
						case EditData<TimePerTurnInfo.Limit>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TimePerTurnInfo.Limit>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<TimePerTurnInfo.Limit>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<TimePerTurnInfo.Limit>.Property.canEdit:
							dirty = true;
							break;
						case EditData<TimePerTurnInfo.Limit>.Property.editType:
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
						if (wrapProperty.p is TimePerTurnInfo.Limit) {
							switch ((TimePerTurnInfo.Limit.Property)wrapProperty.n) {
							case TimePerTurnInfo.Limit.Property.perTurn:
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