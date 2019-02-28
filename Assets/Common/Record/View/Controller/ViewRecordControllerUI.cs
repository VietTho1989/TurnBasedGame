using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewRecordControllerUI : UIBehavior<ViewRecordControllerUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<DataRecord> dataRecord;

			#region speed

			public const float MaxSpeed = 10f;
			public const float MinSpeed = -10f;

			public VP<float> speed;

			public VP<RequestChangeFloatUI.UIData> requestSpeed;

			public void makeRequestChangeSpeed(RequestChangeUpdate<float>.UpdateData update, float newSpeed)
			{
				this.speed.v = Mathf.Clamp (newSpeed, MinSpeed, MaxSpeed);
			}

			#endregion

			#region State

			public abstract class State : Data
			{

				public enum Type
				{
					Play,
					Pick
				}

				public abstract Type getType();

				public abstract float getCurrentShowTime ();

			}

			public VP<State> state;

			#endregion

			#region stateUI

			public abstract class StateUI : Data
			{

				public abstract State.Type getType ();

			}

			public VP<StateUI> stateUI;

			#endregion

			#region time

			public VP<RequestChangeFloatUI.UIData> time;

			public void makeRequestChangeTime(RequestChangeUpdate<float>.UpdateData update, float newTime)
			{
				// find startTime
				float startTime = 0;
				ViewRecordControllerStatePlay.State playState = ViewRecordControllerStatePlay.State.Normal;
				{
					if (this.state.v is ViewRecordControllerStatePick) {
						ViewRecordControllerStatePick oldPick = this.state.v as ViewRecordControllerStatePick;
						startTime = oldPick.startTime.v;
						playState = oldPick.playState.v;
					} else if (this.state.v is ViewRecordControllerStatePlay) {
						ViewRecordControllerStatePlay oldPlay = this.state.v as ViewRecordControllerStatePlay;
						startTime = oldPlay.time.v;
						playState = oldPlay.state.v;
					}
				}
				Debug.LogError ("makeRequestChangeTime: " + startTime + "; " + newTime);
				// find pick
				ViewRecordControllerStatePick pick = null;
				{
					// find old
					if (this.state.v is ViewRecordControllerStatePick) {
						pick = this.state.v as ViewRecordControllerStatePick;
					}
					// make new
					if (pick == null) {
						pick = new ViewRecordControllerStatePick ();
						{
							pick.uid = this.state.makeId ();
						}
					}
				}
				// Update
				{
					pick.startTime.v = startTime;
					pick.pickTime.v = newTime;
					pick.playState.v = playState;
				}
				// set
				this.state.v = pick;
			}

			#endregion

			#region Constructor

			public enum Property
			{
				dataRecord,
				speed,
				requestSpeed,
				state,
				stateUI,
				time
			}

			public UIData()
			{
				this.dataRecord = new VP<DataRecord>(this, (byte)Property.dataRecord, null);
				// speed
				{
					this.speed = new VP<float>(this, (byte)Property.speed, 1f);
					// requestSpeed
					{
						this.requestSpeed = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.requestSpeed, new RequestChangeFloatUI.UIData());
						this.requestSpeed.v.updateData.v.canRequestChange.v = true;
						this.requestSpeed.v.updateData.v.request.v = makeRequestChangeSpeed;
						// limint
						{
							FloatLimit.Have haveLimit = new FloatLimit.Have();
							{
								haveLimit.min.v = MinSpeed;
								haveLimit.max.v = MaxSpeed;
							}
							this.requestSpeed.v.limit.v = haveLimit;
						}
					}
				}
				this.state = new VP<State>(this, (byte)Property.state, new ViewRecordControllerStatePlay());
				this.stateUI = new VP<StateUI>(this, (byte)Property.stateUI, null);
				// time
				{
					this.time = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.time, new RequestChangeFloatUI.UIData());
					this.time.v.updateData.v.canRequestChange.v = true;
					this.time.v.updateData.v.request.v = makeRequestChangeTime;
				}
			}

			#endregion

			public void reset()
			{
				// state
				{
					// find
					ViewRecordControllerStatePlay play = null;
					{
						// find old
						if (this.state.v is ViewRecordControllerStatePlay) {
							play = this.state.v as ViewRecordControllerStatePlay;
						}
						// make new
						if (play == null) {
							play = new ViewRecordControllerStatePlay ();
							{
								play.uid = this.state.makeId ();
							}
							this.state.v = play;
						}
					}
					// update
					{
						play.time.v = 0;
						play.state.v = ViewRecordControllerStatePlay.State.Normal;
					}
				}
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbSpeed;
		public static readonly TxtLanguage txtSpeed = new TxtLanguage();

		public Text lbTime;
		public static readonly TxtLanguage txtTime = new TxtLanguage();

		static ViewRecordControllerUI()
		{
            // txt
            {
                txtSpeed.add(Language.Type.vi, "Tốc Độ");
                txtTime.add(Language.Type.vi, "Thời Gian");
            }
            // rect
            {
                // requestSpeedRect
                {
                    // anchoredPosition: (-138.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.5);
                    // offsetMin: (60.0, 0.0); offsetMax: (-336.0, 0.0); sizeDelta: (-396.0, 0.0);
                    requestSpeedRect.anchoredPosition = new Vector3(-138.0f, 0.0f, 0.0f);
                    requestSpeedRect.anchorMin = new Vector2(0.0f, 0.0f);
                    requestSpeedRect.anchorMax = new Vector2(1.0f, 1.0f);
                    requestSpeedRect.pivot = new Vector2(0.5f, 0.5f);
                    requestSpeedRect.offsetMin = new Vector2(60.0f, 0.0f);
                    requestSpeedRect.offsetMax = new Vector2(-336.0f, 0.0f);
                    requestSpeedRect.sizeDelta = new Vector2(-396.0f, 0.0f);
                }
                // timeRect
                {
                    // anchoredPosition: (52.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.5);
                    // offsetMin: (204.0, 0.0); offsetMax: (-100.0, 0.0); sizeDelta: (-304.0, 0.0);
                    timeRect.anchoredPosition = new Vector3(52.0f, 0.0f);
                    timeRect.anchorMin = new Vector2(0.0f, 0.0f);
                    timeRect.anchorMax = new Vector2(1.0f, 1.0f);
                    timeRect.pivot = new Vector2(0.5f, 0.5f);
                    timeRect.offsetMin = new Vector2(204.0f, 0.0f);
                    timeRect.offsetMax = new Vector2(-100.0f, 0.0f);
                    timeRect.sizeDelta = new Vector2(-304.0f, 0.0f);
                }
                // stateUIRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 0.0); anchorMax: (1.0, 1.0); pivot: (1.0, 0.5);
                    // offsetMin: (-100.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (100.0, 0.0);
                    stateUIRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    stateUIRect.anchorMin = new Vector2(1.0f, 0.0f);
                    stateUIRect.anchorMax = new Vector2(1.0f, 1.0f);
                    stateUIRect.pivot = new Vector2(1.0f, 0.5f);
                    stateUIRect.offsetMin = new Vector2(-100.0f, 0.0f);
                    stateUIRect.offsetMax = new Vector2(0.0f, 0.0f);
                    stateUIRect.sizeDelta = new Vector2(100.0f, 0.0f);
                }
            }
        }

		#endregion

		private bool needReset = true;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					DataRecord dataRecord = this.data.dataRecord.v;
					if (dataRecord != null) {
						// request
						{
							// get server state
							Server.State.Type serverState = Server.State.Type.Connect;
							// set origin
							{
								// speed
								{
									RequestChangeFloatUI.UIData requestSpeed = this.data.requestSpeed.v;
									if (requestSpeed != null) {
										// update
										RequestChangeUpdate<float>.UpdateData updateData = requestSpeed.updateData.v;
										if (updateData != null) {
											updateData.origin.v = this.data.speed.v;
											updateData.canRequestChange.v = true;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("winScore null: " + this);
									}
								}
								// time
								{
									RequestChangeFloatUI.UIData time = this.data.time.v;
									if (time != null) {
										// limit
										{
											// find
											FloatLimit.Have haveLimit = null;
											{
												// find old
												if (time.limit.v is FloatLimit.Have) {
													haveLimit = time.limit.v as FloatLimit.Have;
												}
												// make new
												if (haveLimit == null) {
													haveLimit = new FloatLimit.Have ();
													{
														haveLimit.uid = time.limit.makeId ();
													}
													time.limit.v = haveLimit;
												}
											}
											// Update
											{
												haveLimit.min.v = 0;
												haveLimit.max.v = dataRecord.t;
											}
										}
										// update
										RequestChangeUpdate<float>.UpdateData updateData = time.updateData.v;
										if (updateData != null) {
											updateData.origin.v = this.data.state.v.getCurrentShowTime ();
											updateData.canRequestChange.v = true;
											updateData.serverState.v = serverState;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("winScore null: " + this);
									}
								}
							}
							// reset
							if (needReset) {
								needReset = false;
								// speed
								{
									RequestChangeFloatUI.UIData requestSpeed = this.data.requestSpeed.v;
									if (requestSpeed != null) {
										// update
										RequestChangeUpdate<float>.UpdateData updateData = requestSpeed.updateData.v;
										if (updateData != null) {
											updateData.current.v = this.data.speed.v;
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("requestSpeed null: " + this);
									}
								}
								// time
								{
									RequestChangeFloatUI.UIData time = this.data.time.v;
									if (time != null) {
										// update
										RequestChangeUpdate<float>.UpdateData updateData = time.updateData.v;
										if (updateData != null) {
											updateData.current.v = this.data.state.v.getCurrentShowTime ();
											updateData.changeState.v = Data.ChangeState.None;
										} else {
											Debug.LogError ("updateData null: " + this);
										}
									} else {
										Debug.LogError ("time null: " + this);
									}
								}
							}
						}
						// stateUI
						{
							UIData.State state = this.data.state.v;
							if (state != null) {
								switch (state.getType ()) {
								case UIData.State.Type.Play:
									{
										ViewRecordControllerStatePlay play = state as ViewRecordControllerStatePlay;
										// Find
										ViewRecordControllerStatePlayUI.UIData playUIData = this.data.stateUI.newOrOld<ViewRecordControllerStatePlayUI.UIData>();
										{
											playUIData.play.v = new ReferenceData<ViewRecordControllerStatePlay> (play);
										}
										this.data.stateUI.v = playUIData;
									}
									break;
								case UIData.State.Type.Pick:
									{
										ViewRecordControllerStatePick pick = state as ViewRecordControllerStatePick;
										// Find
										ViewRecordControllerStatePickUI.UIData pickUIData = this.data.stateUI.newOrOld<ViewRecordControllerStatePickUI.UIData>();
										{
											pickUIData.pick.v = new ReferenceData<ViewRecordControllerStatePick> (pick);
										}
										this.data.stateUI.v = pickUIData;
									}
									break;
								default:
									Debug.LogError ("unknown state: " + state.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("state null: " + this);
							}
						}
					} else {
						Debug.LogError ("dataRecord null: " + this);
					}
					// txt
					{
						if (lbSpeed != null) {
							lbSpeed.text = txtSpeed.get ("Speed");
						} else {
							Debug.LogError ("lbSpeed null: " + this);
						}
						if (lbTime != null) {
							lbTime.text = txtTime.get ("Time");
						} else {
							Debug.LogError ("lbTime null: " + this);
						}
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

        private static readonly UIRectTransform requestSpeedRect = new UIRectTransform();
        private static readonly UIRectTransform timeRect = new UIRectTransform();

		public ViewRecordControllerStatePlayUI playPrefab;
		public ViewRecordControllerStatePickUI pickPrefab;
        private static readonly UIRectTransform stateUIRect = new UIRectTransform();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.state.allAddCallBack (this);
					uiData.stateUI.allAddCallBack (this);
					uiData.requestSpeed.allAddCallBack (this);
					uiData.time.allAddCallBack (this);
				}
				dirty = true;
				needReset = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is UIData.State) {
					UIData.State state = data as UIData.State;
					// Update
					{
						switch (state.getType ()) {
						case UIData.State.Type.Play:
							{
								ViewRecordControllerStatePlay play = state as ViewRecordControllerStatePlay;
								UpdateUtils.makeUpdate<ViewRecordControllerStatePlayUpdate, ViewRecordControllerStatePlay> (play, this.transform);
							}
							break;
						case UIData.State.Type.Pick:
							{
								ViewRecordControllerStatePick pick = state as ViewRecordControllerStatePick;
								UpdateUtils.makeUpdate<ViewRecordControllerStatePickUpdate, ViewRecordControllerStatePick> (pick, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is UIData.StateUI) {
					UIData.StateUI stateUIData = data as UIData.StateUI;
					// UI
					{
						switch (stateUIData.getType ()) {
						case UIData.State.Type.Play:
							{
								ViewRecordControllerStatePlayUI.UIData playUIData = stateUIData as ViewRecordControllerStatePlayUI.UIData;
								UIUtils.Instantiate (playUIData, playPrefab, this.transform, stateUIRect);
							}
							break;
						case UIData.State.Type.Pick:
							{
								ViewRecordControllerStatePickUI.UIData pickUIData = stateUIData as ViewRecordControllerStatePickUI.UIData;
								UIUtils.Instantiate (pickUIData, pickPrefab, this.transform, stateUIRect);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + stateUIData.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				// requestSpeed, time
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.requestSpeed:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, this.transform, requestSpeedRect);
								break;
							case UIData.Property.time:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, this.transform, timeRect);
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
					uiData.state.allRemoveCallBack (this);
					uiData.stateUI.allRemoveCallBack (this);
					uiData.requestSpeed.allRemoveCallBack (this);
					uiData.time.allRemoveCallBack (this);
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
				if (data is UIData.State) {
					UIData.State state = data as UIData.State;
					// Update
					{
						switch (state.getType ()) {
						case UIData.State.Type.Play:
							{
								ViewRecordControllerStatePlay play = state as ViewRecordControllerStatePlay;
								play.removeCallBackAndDestroy (typeof(ViewRecordControllerStatePlayUpdate));
							}
							break;
						case UIData.State.Type.Pick:
							{
								ViewRecordControllerStatePick pick = state as ViewRecordControllerStatePick;
								pick.removeCallBackAndDestroy (typeof(ViewRecordControllerStatePickUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is UIData.StateUI) {
					UIData.StateUI stateUIData = data as UIData.StateUI;
					// UI
					{
						switch (stateUIData.getType ()) {
						case UIData.State.Type.Play:
							{
								ViewRecordControllerStatePlayUI.UIData playUIData = stateUIData as ViewRecordControllerStatePlayUI.UIData;
								playUIData.removeCallBackAndDestroy (typeof(ViewRecordControllerStatePlayUI));
							}
							break;
						case UIData.State.Type.Pick:
							{
								ViewRecordControllerStatePickUI.UIData pickUIData = stateUIData as ViewRecordControllerStatePickUI.UIData;
								pickUIData.removeCallBackAndDestroy (typeof(ViewRecordControllerStatePickUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + stateUIData.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				// requestSpeed, time
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
				case UIData.Property.dataRecord:
					{
						// reset
						{
							if (this.data != null) {
								this.data.reset ();
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						dirty = true;
					}
					break;
				case UIData.Property.speed:
					dirty = true;
					break;
				case UIData.Property.requestSpeed:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.state:
					{
						ValueChangeUtils.replaceCallBack(this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.stateUI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.time:
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
				if (wrapProperty.p is UIData.State) {
					UIData.State state = wrapProperty.p as UIData.State;
					switch (state.getType ()) {
					case UIData.State.Type.Play:
						{
							switch ((ViewRecordControllerStatePlay.Property)wrapProperty.n) {
							case ViewRecordControllerStatePlay.Property.state:
								break;
							case ViewRecordControllerStatePlay.Property.time:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						}
						break;
					case UIData.State.Type.Pick:
						{
							switch ((ViewRecordControllerStatePick.Property)wrapProperty.n) {
							case ViewRecordControllerStatePick.Property.pickTime:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is UIData.StateUI) {
					return;
				}
				// requestSpeed, time
				if (wrapProperty.p is RequestChangeFloatUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}