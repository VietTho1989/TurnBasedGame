using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class DefaultHexUI : UIBehavior<DefaultHexUI.UIData>, HaveTransformData
	{

		#region UIData

		public class UIData : DefaultGameTypeUI
		{

			public VP<EditData<DefaultHex>> editDefaultHex;

			#region boardSize

			public VP<RequestChangeIntUI.UIData> boardSize;

			public void makeRequestChangeBoardSize (RequestChangeUpdate<int>.UpdateData update, int newBoardSize)
			{
				// Find
				DefaultHex defaultHex = null;
				{
					EditData<DefaultHex> editDefaultHex = this.editDefaultHex.v;
					if (editDefaultHex != null) {
						defaultHex = editDefaultHex.show.v.data;
					} else {
						Debug.LogError ("editDefaultHex null: " + this);
					}
				}
				// Process
				if (defaultHex != null) {
					defaultHex.requestChangeBoardSize (Server.getProfileUserId (defaultHex), (System.UInt16)newBoardSize);
				} else {
					Debug.LogError ("defaultHex null: " + this);
				}
			}

			#endregion

			public VP<MiniGameDataUI.UIData> miniGameDataUIData;

			#region Constructor

			public enum Property
			{
				editDefaultHex,
				boardSize,
				miniGameDataUIData
			}

			public UIData() : base()
			{
				this.editDefaultHex = new VP<EditData<DefaultHex>>(this, (byte)Property.editDefaultHex, new EditData<DefaultHex>());
				// boardSize
				{
					this.boardSize = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.boardSize, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.boardSize.v.limit.makeId();
							have.min.v = 4;
							have.max.v = Hex.MAX_BOARD_SIZE;
						}
						this.boardSize.v.limit.v = have;
					}
					// event
					this.boardSize.v.updateData.v.request.v = makeRequestChangeBoardSize;
				}
				this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Hex;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbBoardSize;
		public static readonly TxtLanguage txtBoardSize = new TxtLanguage();

		static DefaultHexUI()
		{
            // txt
            {
                txtTitle.add(Language.Type.vi, "Mặc Định Hex");
                txtBoardSize.add(Language.Type.vi, "Kích thước bàn cờ");
            }
            // rect
            {
                boardSizeRect.setPosY(UIConstants.HeaderHeight + UIConstants.DefaultMiniGameDataUISize + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            }
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            /*if (transform.hasChanged)
            {
                transform.hasChanged = false;
                this.transformData.update(this.transform);
            }*/
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        private bool needReset = true;
		private bool miniGameDataDirty = true;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					EditData<DefaultHex> editDefaultHex = this.data.editDefaultHex.v;
					if (editDefaultHex != null) {
						editDefaultHex.update ();
						// get show
						DefaultHex show = editDefaultHex.show.v.data;
						DefaultHex compare = editDefaultHex.compare.v.data;
						if (show != null) {
							// different
							if (lbTitle != null) {
								bool isDifferent = false;
								{
									if (editDefaultHex.compareOtherType.v.data != null) {
										if (editDefaultHex.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// boardSize
									{
										RequestChangeIntUI.UIData boardSize = this.data.boardSize.v;
										if (boardSize != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = boardSize.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.boardSize.v;
												updateData.canRequestChange.v = editDefaultHex.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													boardSize.showDifferent.v = true;
													boardSize.compare.v = compare.boardSize.v;
												} else {
													boardSize.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("boardSize null: " + this);
										}
									}
								}
								// reset?
								if (needReset) {
									needReset = false;
									// boardSize
									{
										RequestChangeIntUI.UIData boardSize = this.data.boardSize.v;
										if (boardSize != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = boardSize.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.boardSize.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("boardSize null: " + this);
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
												// Find Hex
												Hex hex = gameData.gameType.newOrOld<Hex> ();
												{
													// Make new hex
													Hex newHex = show.makeDefaultGameType () as Hex;
													// Copy
													DataUtils.copyData (hex, newHex);
												}
												gameData.gameType.v = hex;
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
						Debug.LogError ("editDefaultHex null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Default Hex");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbBoardSize != null) {
							lbBoardSize.text = txtBoardSize.get ("Board size");
						} else {
							Debug.LogError ("lbBoardSize null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
            updateTransformData();
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public MiniGameDataUI miniGameDataUIPrefab;

		public RequestChangeIntUI requestIntPrefab;

		public static readonly UIRectTransform boardSizeRect = new UIRectTransform(UIConstants.RequestRect);

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// Child
				{
					uiData.editDefaultHex.allAddCallBack (this);
					uiData.boardSize.allAddCallBack (this);
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
				// editDefaultHex
				{
					if (data is EditData<DefaultHex>) {
						EditData<DefaultHex> editDefaultHex = data as EditData<DefaultHex>;
						// Child
						{
							editDefaultHex.show.allAddCallBack (this);
							editDefaultHex.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is DefaultHex) {
							DefaultHex defaultHex = data as DefaultHex;
							// Parent
							{
								DataUtils.addParentCallBack (defaultHex, this, ref this.server);
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
				// boardSize
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.boardSize:
								UIUtils.Instantiate (requestChange, requestIntPrefab, this.transform, boardSizeRect);
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
							UIUtils.Instantiate (miniGameDataUIData, miniGameDataUIPrefab, this.transform, UIConstants.MiniGameDataUIRect);
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
					uiData.editDefaultHex.allRemoveCallBack (this);
					uiData.boardSize.allRemoveCallBack (this);
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
				// editDefaultHex
				{
					if (data is EditData<DefaultHex>) {
						EditData<DefaultHex> editDefaultHex = data as EditData<DefaultHex>;
						// Child
						{
							editDefaultHex.show.allRemoveCallBack (this);
							editDefaultHex.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is DefaultHex) {
							DefaultHex defaultHex = data as DefaultHex;
							// Parent
							{
								DataUtils.removeParentCallBack (defaultHex, this, ref this.server);
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
				// boardSize
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeIntUI));
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
						// Child
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
				case UIData.Property.editDefaultHex:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.boardSize:
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
				// editDefaultHex
				{
					if (wrapProperty.p is EditData<DefaultHex>) {
						switch ((EditData<DefaultHex>.Property)wrapProperty.n) {
						case EditData<DefaultHex>.Property.origin:
							dirty = true;
							break;
						case EditData<DefaultHex>.Property.show:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultHex>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultHex>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<DefaultHex>.Property.canEdit:
							dirty = true;
							break;
						case EditData<DefaultHex>.Property.editType:
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
						if (wrapProperty.p is DefaultHex) {
							switch ((DefaultHex.Property)wrapProperty.n) {
							case DefaultHex.Property.boardSize:
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
				// boardSize
				if (wrapProperty.p is RequestChangeIntUI.UIData) {
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