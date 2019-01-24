using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AnimationSettingUI : UIBehavior<AnimationSettingUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<EditData<AnimationSetting>> editAnimationSetting;

		#region scale

		public VP<RequestChangeFloatUI.UIData> scale;

		public void makeRequestChangeScale (RequestChangeUpdate<float>.UpdateData update, float newScale)
		{
			// Find
			AnimationSetting animationSetting = null;
			{
				EditData<AnimationSetting> editAnimationSetting = this.editAnimationSetting.v;
				if (editAnimationSetting != null) {
					animationSetting = editAnimationSetting.show.v.data;
				} else {
					Debug.LogError ("editAnimationSetting null: " + this);
				}
			}
			// Process
			if (animationSetting != null) {
				animationSetting.scale.v = newScale;
			} else {
				Debug.LogError ("animationSetting null: " + this);
			}
		}

		#endregion

		#region fastForward

		public VP<RequestChangeBoolUI.UIData> fastForward;

		public void makeRequestChangeFastForward (RequestChangeUpdate<bool>.UpdateData update, bool newFastForward)
		{
			// Find
			AnimationSetting animationSetting = null;
			{
				EditData<AnimationSetting> editAnimationSetting = this.editAnimationSetting.v;
				if (editAnimationSetting != null) {
					animationSetting = editAnimationSetting.show.v.data;
				} else {
					Debug.LogError ("editAnimationSetting null: " + this);
				}
			}
			// Process
			if (animationSetting != null) {
				animationSetting.fastForward.v = newFastForward;
			} else {
				Debug.LogError ("animationSetting null: " + this);
			}
		}

		#endregion

		#region maxWaitAnimationCount

		public VP<RequestChangeIntUI.UIData> maxWaitAnimationCount;

		public void makeRequestChangeMaxWaitAnimationCount (RequestChangeUpdate<int>.UpdateData update, int newMaxWaitAnimationCount)
		{
			// Find
			AnimationSetting animationSetting = null;
			{
				EditData<AnimationSetting> editAnimationSetting = this.editAnimationSetting.v;
				if (editAnimationSetting != null) {
					animationSetting = editAnimationSetting.show.v.data;
				} else {
					Debug.LogError ("editAnimationSetting null: " + this);
				}
			}
			// Process
			if (animationSetting != null) {
				animationSetting.maxWaitAnimationCount.v = newMaxWaitAnimationCount;
			} else {
				Debug.LogError ("animationSetting null: " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			editAnimationSetting,
			scale,
			fastForward,
			maxWaitAnimationCount
		}

		public UIData() : base()
		{
			{
				this.editAnimationSetting = new VP<EditData<AnimationSetting>>(this, (byte)Property.editAnimationSetting, new EditData<AnimationSetting>());
				this.editAnimationSetting.v.canEdit.v = true;
			}
			// scale
			{
				this.scale = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.scale, new RequestChangeFloatUI.UIData());
				// have limit
				{
					FloatLimit.Have have = new FloatLimit.Have();
					{
						have.uid = this.scale.v.limit.makeId();
						have.min.v = 0;
						have.max.v = 10;
					}
					this.scale.v.limit.v = have;
				}
				// event
				this.scale.v.updateData.v.request.v = makeRequestChangeScale;
			}
			// fastForward
			{
				this.fastForward = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.fastForward, new RequestChangeBoolUI.UIData());
				this.fastForward.v.updateData.v.request.v = makeRequestChangeFastForward;
			}
			// maxWaitAnimationCount
			{
				this.maxWaitAnimationCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxWaitAnimationCount, new RequestChangeIntUI.UIData());
				// have limit
				{
					IntLimit.Have have = new IntLimit.Have();
					{
						have.uid = this.maxWaitAnimationCount.v.limit.makeId();
						have.min.v = 0;
						have.max.v = 100;
					}
					this.maxWaitAnimationCount.v.limit.v = have;
				}
				// event
				this.maxWaitAnimationCount.v.updateData.v.request.v = makeRequestChangeMaxWaitAnimationCount;
			}
		}

		#endregion

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
				EditData<AnimationSetting> editAnimationSetting = this.data.editAnimationSetting.v;
				if (editAnimationSetting != null) {
					editAnimationSetting.update ();
					// get show
					AnimationSetting show = editAnimationSetting.show.v.data;
					AnimationSetting compare = editAnimationSetting.compare.v.data;
					if (show != null) {
						// differentIndicator
						if (differentIndicator != null) {
							bool isDifferent = false;
							{
								if (editAnimationSetting.compareOtherType.v.data != null) {
									if (editAnimationSetting.compareOtherType.v.data.GetType () != show.GetType ()) {
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
								/*Server server = show.findDataInParent<Server> ();
								if (server != null) {
									if (server.state.v != null) {
										serverState = server.state.v.getType ();
									} else {
										Debug.LogError ("server state null: " + this);
									}
								} else {
									Debug.LogError ("server null: " + this);
								}*/
							}
							// set origin
							{
								// scale
								{
									RequestChangeFloatUI.UIData scale = this.data.scale.v;
									if (scale != null) {
										// update
										RequestChangeUpdate<float>.UpdateData updateData = scale.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.scale.v;
											updateData.canRequestChange.v = editAnimationSetting.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												scale.showDifferent.v = true;
												scale.compare.v = compare.scale.v;
											} else {
												scale.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("scale null: " + this);
									}
								}
								// fastForward
								{
									RequestChangeBoolUI.UIData fastForward = this.data.fastForward.v;
									if (fastForward != null) {
										// update
										RequestChangeUpdate<bool>.UpdateData updateData = fastForward.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.fastForward.v;
											updateData.canRequestChange.v = editAnimationSetting.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												fastForward.showDifferent.v = true;
												fastForward.compare.v = compare.fastForward.v;
											} else {
												fastForward.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("fastForward null: " + this);
									}
								}
								// maxWaitAnimationCount
								{
									RequestChangeIntUI.UIData maxWaitAnimationCount = this.data.maxWaitAnimationCount.v;
									if (maxWaitAnimationCount != null) {
										// update
										RequestChangeUpdate<int>.UpdateData updateData = maxWaitAnimationCount.updateData.v;
										if (updateData != null) {
											updateData.origin.v = show.maxWaitAnimationCount.v;
											updateData.canRequestChange.v = editAnimationSetting.canEdit.v;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
										// compare
										{
											if (compare != null) {
												maxWaitAnimationCount.showDifferent.v = true;
												maxWaitAnimationCount.compare.v = compare.maxWaitAnimationCount.v;
											} else {
												maxWaitAnimationCount.showDifferent.v = false;
											}
										}
									} else {
										Debug.LogError ("maxWaitAnimationCount null: " + this);
									}
								}
							}
						}
						// reset
						if (needReset) {
							needReset = false;
							// scale
							{
								RequestChangeFloatUI.UIData scale = this.data.scale.v;
								if (scale != null) {
									// update
									RequestChangeUpdate<float>.UpdateData updateData = scale.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.scale.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("scale null: " + this);
								}
							}
							// fastForward
							{
								RequestChangeBoolUI.UIData fastForward = this.data.fastForward.v;
								if (fastForward != null) {
									// update
									RequestChangeUpdate<bool>.UpdateData updateData = fastForward.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.fastForward.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("fastForward null: " + this);
								}
							}
							// maxWaitAnimationCount
							{
								RequestChangeIntUI.UIData maxWaitAnimationCount = this.data.maxWaitAnimationCount.v;
								if (maxWaitAnimationCount != null) {
									// update
									RequestChangeUpdate<int>.UpdateData updateData = maxWaitAnimationCount.updateData.v;
									if (updateData != null) {
										updateData.current.v = show.maxWaitAnimationCount.v;
										updateData.changeState.v = Data.ChangeState.None;
									} else {
										Debug.LogError ("updateData null: " + this);
									}
								} else {
									Debug.LogError ("maxWaitAnimationCount null: " + this);
								}
							}
						}
					} else {
						Debug.LogError ("show null: " + this);
					}
				} else {
					Debug.LogError ("editAnimationSetting null: " + this);
				}
				// update Text
				this.updateTxt();
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

	#region update text

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	public Text tvScale;
	public static readonly TxtLanguage txtScale = new TxtLanguage ();

	public Text tvFastForward;
	public static readonly TxtLanguage txtFastForward = new TxtLanguage ();

	public Text tvMaxWaitAnimationCount;
	public static readonly TxtLanguage txtMaxWaitAnimationCount = new TxtLanguage ();

	static AnimationSettingUI()
	{
		txtTitle.add (Language.Type.vi, "Thiết Lập Animation");
		txtScale.add (Language.Type.vi, "Tỷ Lệ");
		txtFastForward.add (Language.Type.vi, "Tua Nhanh");
		txtMaxWaitAnimationCount.add (Language.Type.vi, "Số animation chờ tối đa");
	}

	private void updateTxt()
	{
		if (lbTitle != null) {
			lbTitle.text = txtTitle.get ("Animation Setting");
		} else {
			Debug.LogError ("lbTitle null: " + this);
		}
		if (tvScale != null) {
			tvScale.text = txtScale.get ("Scale");
		} else {
			Debug.LogError ("tvScale null: " + this);
		}
		if (tvFastForward != null) {
			tvFastForward.text = txtFastForward.get ("Fast Forward");
		} else {
			Debug.LogError ("tvFastForward null: " + this);
		}
		if (tvMaxWaitAnimationCount != null) {
			tvMaxWaitAnimationCount.text = txtMaxWaitAnimationCount.get ("Max Wait Animation Count");
		} else {
			Debug.LogError ("tvMaxWaitAnimationCount null: " + this);
		}
	}

	#endregion

	#region implement callBacks

	public RequestChangeFloatUI requestFloatPrefab;
	public RequestChangeBoolUI requestBoolPrefab;
	public RequestChangeIntUI requestIntPrefab;

	public Transform scaleContainer;
	public Transform fastForwardContainer;
	public Transform maxWaitAnimationCountContainer;

	// private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.editAnimationSetting.allAddCallBack (this);
				uiData.scale.allAddCallBack (this);
				uiData.fastForward.allAddCallBack (this);
				uiData.maxWaitAnimationCount.allAddCallBack (this);
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
			// editAnimationSetting
			{
				if (data is EditData<AnimationSetting>) {
					EditData<AnimationSetting> editAnimationSetting = data as EditData<AnimationSetting>;
					// Child
					{
						editAnimationSetting.show.allAddCallBack (this);
						editAnimationSetting.compare.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is AnimationSetting) {
						/*AnimationSetting animationSetting = data as AnimationSetting;
						// Parent
						{
							DataUtils.addParentCallBack (animationSetting, this, ref this.server);
						}*/
						needReset = true;
						dirty = true;
						return;
					}
					// Parent
					{
						/*if (data is Server) {
							dirty = true;
							return;
						}*/
					}
				}
			}
			// scale
			if (data is RequestChangeFloatUI.UIData) {
				RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.scale:
							UIUtils.Instantiate (requestChange, requestFloatPrefab, scaleContainer);
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
			// fastForward
			if (data is RequestChangeBoolUI.UIData) {
				RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.fastForward:
							UIUtils.Instantiate (requestChange, requestBoolPrefab, fastForwardContainer);
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
			// maxWaitAnimationCount
			if (data is RequestChangeIntUI.UIData) {
				RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
				// UI
				{
					WrapProperty wrapProperty = requestChange.p;
					if (wrapProperty != null) {
						switch ((UIData.Property)wrapProperty.n) {
						case UIData.Property.maxWaitAnimationCount:
							UIUtils.Instantiate (requestChange, requestIntPrefab, maxWaitAnimationCountContainer);
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
				uiData.editAnimationSetting.allRemoveCallBack (this);
				uiData.scale.allRemoveCallBack (this);
				uiData.fastForward.allRemoveCallBack (this);
				uiData.maxWaitAnimationCount.allRemoveCallBack (this);
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
			// editAnimationSetting
			{
				if (data is EditData<AnimationSetting>) {
					EditData<AnimationSetting> editAnimationSetting = data as EditData<AnimationSetting>;
					// Child
					{
						editAnimationSetting.show.allRemoveCallBack (this);
						editAnimationSetting.compare.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is AnimationSetting) {
						/*AnimationSetting animationSetting = data as AnimationSetting;
						// Parent
						{
							DataUtils.removeParentCallBack (animationSetting, this, ref this.server);
						}*/
						return;
					}
					// Parent
					{
						/*if (data is Server) {
							return;
						}*/
					}
				}
			}
			// scale
			if (data is RequestChangeFloatUI.UIData) {
				RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeFloatUI));
				}
				return;
			}
			// fastForward
			if (data is RequestChangeBoolUI.UIData) {
				RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
				// UI
				{
					requestChange.removeCallBackAndDestroy (typeof(RequestChangeBoolUI));
				}
				return;
			}
			// maxWaitAnimationCount
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
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.editAnimationSetting:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.scale:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.fastForward:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.maxWaitAnimationCount:
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
			// editAnimationSetting
			{
				if (wrapProperty.p is EditData<AnimationSetting>) {
					switch ((EditData<AnimationSetting>.Property)wrapProperty.n) {
					case EditData<AnimationSetting>.Property.origin:
						dirty = true;
						break;
					case EditData<AnimationSetting>.Property.show:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case EditData<AnimationSetting>.Property.compare:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case EditData<AnimationSetting>.Property.compareOtherType:
						dirty = true;
						break;
					case EditData<AnimationSetting>.Property.canEdit:
						dirty = true;
						break;
					case EditData<AnimationSetting>.Property.editType:
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
					if (wrapProperty.p is AnimationSetting) {
						switch ((AnimationSetting.Property)wrapProperty.n) {
						case AnimationSetting.Property.scale:
							dirty = true;
							break;
						case AnimationSetting.Property.fastForward:
							dirty = true;
							break;
						case AnimationSetting.Property.maxWaitAnimationCount:
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
						/*if (wrapProperty.p is Server) {
							Server.State.OnUpdateSyncStateChange (wrapProperty, this);
							return;
						}*/
					}
				}
			}
			// scale
			if (wrapProperty.p is RequestChangeFloatUI.UIData) {
				return;
			}
			// fastForward
			if (wrapProperty.p is RequestChangeBoolUI.UIData) {
				return;
			}
			// maxWaitAnimationCount
			if (wrapProperty.p is RequestChangeIntUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}