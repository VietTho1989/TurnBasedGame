using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class DefaultMineSweeperUI : UIBehavior<DefaultMineSweeperUI.UIData>
	{

		#region UIData

		public class UIData : DefaultGameTypeUI
		{

			public VP<EditData<DefaultMineSweeper>> editDefaultMineSweeper;

			#region N

			public VP<RequestChangeIntUI.UIData> N;

			public void makeRequestChangeN (RequestChangeUpdate<int>.UpdateData update, int newN)
			{
				// Find
				DefaultMineSweeper defaultMineSweeper = null;
				{
					EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
					if (editDefaultMineSweeper != null) {
						defaultMineSweeper = editDefaultMineSweeper.show.v.data;
					} else {
						Debug.LogError ("editDefaultMineSweeper null: " + this);
					}
				}
				// Process
				if (defaultMineSweeper != null) {
					defaultMineSweeper.requestChangeN (Server.getProfileUserId(defaultMineSweeper), newN);
				} else {
					Debug.LogError ("defaultMineSweeper null: " + this);
				}
			}

			#endregion

			#region M

			public VP<RequestChangeIntUI.UIData> M;

			public void makeRequestChangeM (RequestChangeUpdate<int>.UpdateData update, int newM)
			{
				// Find
				DefaultMineSweeper defaultMineSweeper = null;
				{
					EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
					if (editDefaultMineSweeper != null) {
						defaultMineSweeper = editDefaultMineSweeper.show.v.data;
					} else {
						Debug.LogError ("editDefaultMineSweeper null: " + this);
					}
				}
				// Process
				if (defaultMineSweeper != null) {
					defaultMineSweeper.requestChangeM (Server.getProfileUserId(defaultMineSweeper), newM);
				} else {
					Debug.LogError ("defaultMineSweeper null: " + this);
				}
			}

			#endregion

			#region minK

			public VP<RequestChangeFloatUI.UIData> minK;

			public void makeRequestChangeMinK (RequestChangeUpdate<float>.UpdateData update, float newMinK)
			{
				// Find
				DefaultMineSweeper defaultMineSweeper = null;
				{
					EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
					if (editDefaultMineSweeper != null) {
						defaultMineSweeper = editDefaultMineSweeper.show.v.data;
					} else {
						Debug.LogError ("editDefaultMineSweeper null: " + this);
					}
				}
				// Process
				if (defaultMineSweeper != null) {
					defaultMineSweeper.requestChangeMinK (Server.getProfileUserId(defaultMineSweeper), newMinK);
				} else {
					Debug.LogError ("defaultMineSweeper null: " + this);
				}
			}

			#endregion

			#region maxK

			public VP<RequestChangeFloatUI.UIData> maxK;

			public void makeRequestChangeMaxK (RequestChangeUpdate<float>.UpdateData update, float newMaxK)
			{
				// Find
				DefaultMineSweeper defaultMineSweeper = null;
				{
					EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
					if (editDefaultMineSweeper != null) {
						defaultMineSweeper = editDefaultMineSweeper.show.v.data;
					} else {
						Debug.LogError ("editDefaultMineSweeper null: " + this);
					}
				}
				// Process
				if (defaultMineSweeper != null) {
					defaultMineSweeper.requestChangeMaxK (Server.getProfileUserId (defaultMineSweeper), newMaxK);
				} else {
					Debug.LogError ("defaultMineSweeper null: " + this);
				}
			}

			#endregion

			#region allowWatchBomb

			public VP<RequestChangeBoolUI.UIData> allowWatchBomb;

			public void makeRequestChangeAllowWatchBomb (RequestChangeUpdate<bool>.UpdateData update, bool newAllowWatchBomb)
			{
				// Find
				DefaultMineSweeper defaultMineSweeper = null;
				{
					EditData<DefaultMineSweeper> editDefaultMineSweeper = this.editDefaultMineSweeper.v;
					if (editDefaultMineSweeper != null) {
						defaultMineSweeper = editDefaultMineSweeper.show.v.data;
					} else {
						Debug.LogError ("editDefaultMineSweeper null: " + this);
					}
				}
				// Process
				if (defaultMineSweeper != null) {
					defaultMineSweeper.requestChangeAllowWatchBomb (Server.getProfileUserId (defaultMineSweeper), newAllowWatchBomb);
				} else {
					Debug.LogError ("defaultMineSweeper null: " + this);
				}
			}

			#endregion

			public VP<MiniGameDataUI.UIData> miniGameDataUIData;

			#region Constructor

			public enum Property
			{
				editDefaultMineSweeper,
				N,
				M,
				minK,
				maxK,
				allowWatchBomb,
				miniGameDataUIData
			}

			public UIData() : base()
			{
				this.editDefaultMineSweeper = new VP<EditData<DefaultMineSweeper>>(this, (byte)Property.editDefaultMineSweeper, new EditData<DefaultMineSweeper>());
				// N
				{
					this.N = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.N, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.N.v.limit.makeId();
							have.min.v = MineSweeper.MIN_DIMENSION_SIZE;
							have.max.v = MineSweeper.MAX_DIMENSION_SIZE;
						}
						this.N.v.limit.v = have;
					}
					// event
					this.N.v.updateData.v.request.v = makeRequestChangeN;
				}
				// M
				{
					this.M = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.M, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.M.v.limit.makeId();
							have.min.v = MineSweeper.MIN_DIMENSION_SIZE;
							have.max.v = MineSweeper.MAX_DIMENSION_SIZE;
						}
						this.M.v.limit.v = have;
					}
					// event
					this.M.v.updateData.v.request.v = makeRequestChangeM;
				}
				// minK
				{
					this.minK = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.minK, new RequestChangeFloatUI.UIData());
					// have limit
					{
						FloatLimit.Have have = new FloatLimit.Have();
						{
							have.uid = this.minK.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 1;
						}
						this.minK.v.limit.v = have;
					}
					// event
					this.minK.v.updateData.v.request.v = makeRequestChangeMinK;
				}
				// maxK
				{
					this.maxK = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.maxK, new RequestChangeFloatUI.UIData());
					// have limit
					{
						FloatLimit.Have have = new FloatLimit.Have();
						{
							have.uid = this.maxK.v.limit.makeId();
							have.min.v = 0;
							have.max.v = 1;
						}
						this.maxK.v.limit.v = have;
					}
					// event
					this.maxK.v.updateData.v.request.v = makeRequestChangeMaxK;
				}
				// allowWatchBomb
				{
					this.allowWatchBomb = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.allowWatchBomb, new RequestChangeBoolUI.UIData());
					this.allowWatchBomb.v.updateData.v.request.v = makeRequestChangeAllowWatchBomb;
				}
				this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.MineSweeper;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbN;
		public static readonly TxtLanguage txtN = new TxtLanguage ();

		public Text lbM;
		public static readonly TxtLanguage txtM = new TxtLanguage();

		public Text lbMinK;
		public static readonly TxtLanguage txtMinK = new TxtLanguage();

		public Text lbMaxK;
		public static readonly TxtLanguage txtMaxK = new TxtLanguage();

		public Text lbAllowWatchBomb;
		public static readonly TxtLanguage txtAllowWatchBomb = new TxtLanguage ();

		static DefaultMineSweeperUI()
		{
			txtTitle.add (Language.Type.vi, "Mặc Định Dò Mìn");
			txtN.add (Language.Type.vi, "Chiều dài");
			txtM.add (Language.Type.vi, "Chiều rộng");
			txtMinK.add (Language.Type.vi, "Mật độ mìn tối thiểu");
			txtMaxK.add (Language.Type.vi, "Mật độ mìn tối đa");
			txtAllowWatchBomb.add (Language.Type.vi, "Cho phép người xem thấy bom");
		}

		#endregion

		private bool needReset = true;
		private bool miniGameDataDirty = true;

		public GameObject differentIndicator;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<DefaultMineSweeper> editDefaultMineSweeper = this.data.editDefaultMineSweeper.v;
					if (editDefaultMineSweeper != null) {
						editDefaultMineSweeper.update ();
						// get show
						DefaultMineSweeper show = editDefaultMineSweeper.show.v.data;
						DefaultMineSweeper compare = editDefaultMineSweeper.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editDefaultMineSweeper.compareOtherType.v.data != null) {
										if (editDefaultMineSweeper.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// N
									{
										RequestChangeIntUI.UIData N = this.data.N.v;
										if (N != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = N.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.N.v;
												updateData.canRequestChange.v = editDefaultMineSweeper.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													N.showDifferent.v = true;
													N.compare.v = compare.N.v;
												} else {
													N.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("N null: " + this);
										}
									}
									// M
									{
										RequestChangeIntUI.UIData M = this.data.M.v;
										if (M != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = M.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.M.v;
												updateData.canRequestChange.v = editDefaultMineSweeper.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													M.showDifferent.v = true;
													M.compare.v = compare.M.v;
												} else {
													M.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("M null: " + this);
										}
									}
									// minK
									{
										RequestChangeFloatUI.UIData minK = this.data.minK.v;
										if (minK != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = minK.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.minK.v;
												updateData.canRequestChange.v = editDefaultMineSweeper.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													minK.showDifferent.v = true;
													minK.compare.v = compare.minK.v;
												} else {
													minK.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("minK null: " + this);
										}
									}
									// maxK
									{
										RequestChangeFloatUI.UIData maxK = this.data.maxK.v;
										if (maxK != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = maxK.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.maxK.v;
												updateData.canRequestChange.v = editDefaultMineSweeper.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													maxK.showDifferent.v = true;
													maxK.compare.v = compare.maxK.v;
												} else {
													maxK.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("maxK null: " + this);
										}
									}
									// allowWatchBomb
									{
										RequestChangeBoolUI.UIData allowWatchBomb = this.data.allowWatchBomb.v;
										if (allowWatchBomb != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = allowWatchBomb.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.allowWatchBomb.v;
												updateData.canRequestChange.v = editDefaultMineSweeper.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													allowWatchBomb.showDifferent.v = true;
													allowWatchBomb.compare.v = compare.allowWatchBomb.v;
												} else {
													allowWatchBomb.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("allowWatchBomb null: " + this);
										}
									}
								}
								// reset?
								if (needReset) {
									needReset = false;
									// N
									{
										RequestChangeIntUI.UIData N = this.data.N.v;
										if (N != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = N.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.N.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("N null: " + this);
										}
									}
									// M
									{
										RequestChangeIntUI.UIData M = this.data.M.v;
										if (M != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = M.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.M.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("M null: " + this);
										}
									}
									// minK
									{
										RequestChangeFloatUI.UIData minK = this.data.minK.v;
										if (minK != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = minK.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.minK.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("minK null: " + this);
										}
									}
									// maxK
									{
										RequestChangeFloatUI.UIData maxK = this.data.maxK.v;
										if (maxK != null) {
											// update
											RequestChangeUpdate<float>.UpdateData updateData = maxK.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.maxK.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("maxK null: " + this);
										}
									}
									// allowWatchBomb
									{
										RequestChangeBoolUI.UIData allowWatchBomb = this.data.allowWatchBomb.v;
										if (allowWatchBomb != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = allowWatchBomb.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.allowWatchBomb.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("allowWatchBomb null: " + this);
										}
									}
								}
							}
							// miniGameDataUIData
							if (miniGameDataDirty) {
								miniGameDataDirty = false;
								// find miniGameDataUIData
								MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUIData.newOrOld<MiniGameDataUI.UIData> ();
								{
									// gameData
									{
										// Find GameData
										GameData gameData = null;
										{
											// Find old
											if (miniGameDataUIData.gameData.v.data != null) {
												gameData = miniGameDataUIData.gameData.v.data;
											}
											// Make new
											if (gameData == null) {
												gameData = new GameData ();
												miniGameDataUIData.gameData.v = new ReferenceData<GameData> (gameData);
											}
										}
										// Update Property
										{
											// GameType
											{
												// Find MineSweeper
												MineSweeper mineSweeper = gameData.gameType.newOrOld<MineSweeper> ();
												{
													// Make new mineSweeper
													MineSweeper newMineSweeper = show.makeDefaultGameType () as MineSweeper;
													// Copy
													DataUtils.copyData (mineSweeper, newMineSweeper);
												}
												gameData.gameType.v = mineSweeper;
											}
										}
									}
								}
								this.data.miniGameDataUIData.v = miniGameDataUIData;
							}
						} else {
							Debug.LogError ("show null: " + this);
						}
					} else {
						Debug.LogError ("editDefaultMineSweeper null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Default Mine Sweeper");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbN != null) {
							lbN.text = txtN.get ("N");
						} else {
							Debug.LogError ("lbN null: " + this);
						}
						if (lbM != null) {
							lbM.text = txtM.get ("M");
						} else {
							Debug.LogError ("lbM null: " + this);
						}
						if (lbMinK != null) {
							lbMinK.text = txtMinK.get ("MinK");
						} else {
							Debug.LogError ("lbMinK null: " + this);
						}
						if (lbMaxK != null) {
							lbMaxK.text = txtMaxK.get ("MaxK");
						} else {
							Debug.LogError ("lbMaxK null: " + this);
						}
						if (lbAllowWatchBomb != null) {
							lbAllowWatchBomb.text = txtAllowWatchBomb.get ("Allow watch bomb");
						} else {
							Debug.LogError ("lbAllowWatchBomb null: " + this);
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

		public MiniGameDataUI miniGameDataUIPrefab;
		public Transform miniGameDataUIContainer;

		public RequestChangeIntUI requestIntPrefab;
		public RequestChangeFloatUI requestFloatPrefab;
		public RequestChangeBoolUI requestBoolPrefab;

		public Transform NContainer;
		public Transform MContainer;
		public Transform minKContainer;
		public Transform maxKContainer;
		public Transform allowWatchBombContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// Child
				{
					uiData.editDefaultMineSweeper.allAddCallBack (this);
					uiData.N.allAddCallBack (this);
					uiData.M.allAddCallBack (this);
					uiData.minK.allAddCallBack (this);
					uiData.maxK.allAddCallBack (this);
					uiData.allowWatchBomb.allAddCallBack (this);
					uiData.miniGameDataUIData.allAddCallBack (this);
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
				// editDefaultMineSweeper
				{
					if (data is EditData<DefaultMineSweeper>) {
						EditData<DefaultMineSweeper> editDefaultMineSweeper = data as EditData<DefaultMineSweeper>;
						// Child
						{
							editDefaultMineSweeper.show.allAddCallBack (this);
							editDefaultMineSweeper.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is DefaultMineSweeper) {
							DefaultMineSweeper defaultMineSweeper = data as DefaultMineSweeper;
							// Parent
							{
								DataUtils.addParentCallBack (defaultMineSweeper, this, ref this.server);
							}
							needReset = true;
							miniGameDataDirty = true;
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
				// N, M
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.N:
								UIUtils.Instantiate (requestChange, requestIntPrefab, NContainer);
								break;
							case UIData.Property.M:
								UIUtils.Instantiate (requestChange, requestIntPrefab, MContainer);
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
				// minK, maxK
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.minK:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, minKContainer);
								break;
							case UIData.Property.maxK:
								UIUtils.Instantiate (requestChange, requestFloatPrefab, maxKContainer);
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
				// allowWatchBomb
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.allowWatchBomb:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, allowWatchBombContainer);
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
				// MiniGameDataUIData
				{
					if (data is MiniGameDataUI.UIData) {
						MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
						// UI
						{
							UIUtils.Instantiate (miniGameDataUIData, miniGameDataUIPrefab, miniGameDataUIContainer);
						}
						// Child
						{
							miniGameDataUIData.gameData.allAddCallBack (this);
						}
						miniGameDataDirty = true;
						dirty = true;
						return;
					}
					// GameData
					{
						if (data is GameData) {
							GameData gameData = data as GameData;
							// Child
							{
								gameData.gameType.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						{
							data.addCallBackAllChildren (this);
							dirty = true;
							return;
						}
					}
				}
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().removeCallBack (this);
				// Child
				{
					uiData.editDefaultMineSweeper.allRemoveCallBack (this);
					uiData.N.allRemoveCallBack (this);
					uiData.M.allRemoveCallBack (this);
					uiData.minK.allRemoveCallBack (this);
					uiData.maxK.allRemoveCallBack (this);
					uiData.allowWatchBomb.allRemoveCallBack (this);
					uiData.miniGameDataUIData.allRemoveCallBack (this);
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
				// editDefaultMineSweeper
				{
					if (data is EditData<DefaultMineSweeper>) {
						EditData<DefaultMineSweeper> editDefaultMineSweeper = data as EditData<DefaultMineSweeper>;
						// Child
						{
							editDefaultMineSweeper.show.allRemoveCallBack (this);
							editDefaultMineSweeper.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is DefaultMineSweeper) {
							DefaultMineSweeper defaultMineSweeper = data as DefaultMineSweeper;
							// Parent
							{
								DataUtils.removeParentCallBack (defaultMineSweeper, this, ref this.server);
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
				// N, M
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
					}
					return;
				}
				// minK, maxK
				if (data is RequestChangeFloatUI.UIData) {
					RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeFloatUI));
					}
					return;
				}
				// alowWatchBomb
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeBoolUI));
					}
					return;
				}
				// MiniGameDataUIData
				{
					if (data is MiniGameDataUI.UIData) {
						MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
						// UI
						{
							miniGameDataUIData.removeCallBackAndDestroy (typeof(MiniGameDataUI));
						}
						// Child
						{
							miniGameDataUIData.gameData.allRemoveCallBack (this);
						}
						return;
					}
					// GameData
					{
						if (data is GameData) {
							GameData gameData = data as GameData;
							// Child
							{
								gameData.gameType.allRemoveCallBack (this);
							}
							return;
						}
						// GameType
						{
							data.removeCallBackAllChildren (this);
							return;
						}
					}
				}
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.editDefaultMineSweeper:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.N:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.M:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.minK:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.maxK:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.allowWatchBomb:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.miniGameDataUIData:
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
				// editDefaultMineSweeper
				{
					if (wrapProperty.p is EditData<DefaultMineSweeper>) {
						switch ((EditData<DefaultMineSweeper>.Property)wrapProperty.n) {
						case EditData<DefaultMineSweeper>.Property.origin:
							dirty = true;
							break;
						case EditData<DefaultMineSweeper>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultMineSweeper>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultMineSweeper>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<DefaultMineSweeper>.Property.canEdit:
							dirty = true;
							break;
						case EditData<DefaultMineSweeper>.Property.editType:
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
						if (wrapProperty.p is DefaultMineSweeper) {
							switch ((DefaultMineSweeper.Property)wrapProperty.n) {
							case DefaultMineSweeper.Property.N:
								miniGameDataDirty = true;
								dirty = true;
								break;
							case DefaultMineSweeper.Property.M:
								miniGameDataDirty = true;
								dirty = true;
								break;
							case DefaultMineSweeper.Property.minK:
								miniGameDataDirty = true;
								dirty = true;
								break;
							case DefaultMineSweeper.Property.maxK:
								miniGameDataDirty = true;
								dirty = true;
								break;
							case DefaultMineSweeper.Property.allowWatchBomb:
								miniGameDataDirty = true;
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
				// N, M
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
					return;
				}
				// minK, maxK
				if (wrapProperty.p is RequestChangeFloatUI.UIData) {
					return;
				}
				// allowWatchBomb
				if (wrapProperty.p is RequestChangeBoolUI.UIData) {
					return;
				}
				// MiniGameDataUIData
				{
					if (wrapProperty.p is MiniGameDataUI.UIData) {
						switch ((MiniGameDataUI.UIData.Property)wrapProperty.n) {
						case MiniGameDataUI.UIData.Property.gameData:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case MiniGameDataUI.UIData.Property.board:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// GameData
					{
						if (wrapProperty.p is GameData) {
							switch ((GameData.Property)wrapProperty.n) {
							case GameData.Property.gameType:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case GameData.Property.useRule:
								break;
							case GameData.Property.turn:
								break;
							case GameData.Property.timeControl:
								break;
							case GameData.Property.lastMove:
								break;
							case GameData.Property.state:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						{
							if (Generic.IsAddCallBackInterface<T> ()) {
								ValueChangeUtils.replaceCallBack (this, syncs);
							}
							dirty = true;
							return;
						}
					}
				}
			}
			// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}