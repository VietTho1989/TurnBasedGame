using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
	public class DefaultGomokuUI : UIBehavior<DefaultGomokuUI.UIData>
	{

		#region UIData

		public class UIData : DefaultGameTypeUI
		{

			public VP<EditData<DefaultGomoku>> editDefaultGomoku;

			#region boardSize

			public VP<RequestChangeIntUI.UIData> boardSize;

			public void makeRequestChangeBoardSize (RequestChangeUpdate<int>.UpdateData update, int newBoardSize)
			{
				// Find
				DefaultGomoku defaultGomoku = null;
				{
					EditData<DefaultGomoku> editDefaultGomoku = this.editDefaultGomoku.v;
					if (editDefaultGomoku != null) {
						defaultGomoku = editDefaultGomoku.show.v.data;
					} else {
						Debug.LogError ("editDefaultGomoku null: " + this);
					}
				}
				// Process
				if (defaultGomoku != null) {
					defaultGomoku.requestChangeBoardSize (Server.getProfileUserId(defaultGomoku), newBoardSize);
				} else {
					Debug.LogError ("defaultGomoku null: " + this);
				}
			}

			#endregion

			public VP<MiniGameDataUI.UIData> miniGameDataUIData;

			#region Constructor

			public enum Property
			{
				editDefaultGomoku,
				boardSize,
				miniGameDataUIData
			}

			public UIData() : base()
			{
				this.editDefaultGomoku = new VP<EditData<DefaultGomoku>>(this, (byte)Property.editDefaultGomoku, new EditData<DefaultGomoku>());
				{
					this.boardSize = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.boardSize, new RequestChangeIntUI.UIData());
					// have limit
					{
						IntLimit.Have have = new IntLimit.Have();
						{
							have.uid = this.boardSize.v.limit.makeId();
							have.min.v = Gomoku.MinBoardSize;
							have.max.v = Gomoku.MaxBoardSize;
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
				return GameType.Type.Gomoku;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbBoardSize;
		public static readonly TxtLanguage txtBoardSize = new TxtLanguage ();

		static DefaultGomokuUI()
		{
			txtTitle.add (Language.Type.vi, "Mặc Định Cờ Caro");
			txtBoardSize.add (Language.Type.vi, "Kích thước bàn cờ");
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
					EditData<DefaultGomoku> editDefaultGomoku = this.data.editDefaultGomoku.v;
					if (editDefaultGomoku != null) {
						editDefaultGomoku.update ();
						// get show
						DefaultGomoku show = editDefaultGomoku.show.v.data;
						DefaultGomoku compare = editDefaultGomoku.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editDefaultGomoku.compareOtherType.v.data != null) {
										if (editDefaultGomoku.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// boardSize
									{
										RequestChangeIntUI.UIData boardSize = this.data.boardSize.v;
										if (boardSize != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = boardSize.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.boardSize.v;
												updateData.canRequestChange.v = editDefaultGomoku.canEdit.v;
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
								// Update Property
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
												// Find Gomoku
												Gomoku gomoku = gameData.gameType.newOrOld<Gomoku> ();
												{
													// find newGomoku
													Gomoku newGomoku = show.makeDefaultGameType () as Gomoku;
													// Copy
													DataUtils.copyData (gomoku, newGomoku);
												}
												gameData.gameType.v = gomoku;
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
						Debug.LogError ("editDefaultGomoku null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Default Gomoku");
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
		public Transform boardSizeContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get ().addCallBack (this);
				// Child
				{
					uiData.editDefaultGomoku.allAddCallBack (this);
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
				// editDefaultGomoku
				{
					if (data is EditData<DefaultGomoku>) {
						EditData<DefaultGomoku> editDefaultGomoku = data as EditData<DefaultGomoku>;
						// Child
						{
							editDefaultGomoku.show.allAddCallBack (this);
							editDefaultGomoku.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is DefaultGomoku) {
							DefaultGomoku defaultGomoku = data as DefaultGomoku;
							// Parent
							{
								DataUtils.addParentCallBack (defaultGomoku, this, ref this.server);
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
				if (data is RequestChangeIntUI.UIData) {
					RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.boardSize:
								{
									UIUtils.Instantiate (requestChange, requestIntPrefab, boardSizeContainer);
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
							{
								gameData.gameType.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// GameType
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
					uiData.editDefaultGomoku.allRemoveCallBack (this);
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
				// editDefaultGomoku
				{
					if (data is EditData<DefaultGomoku>) {
						EditData<DefaultGomoku> editDefaultGomoku = data as EditData<DefaultGomoku>;
						// Child
						{
							editDefaultGomoku.show.allRemoveCallBack (this);
							editDefaultGomoku.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is DefaultGomoku) {
							DefaultGomoku defaultGomoku = data as DefaultGomoku;
							// Parent
							{
								DataUtils.removeParentCallBack (defaultGomoku, this, ref this.server);
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
				case UIData.Property.editDefaultGomoku:
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
				// EditDefaultGomoku
				{
					if (wrapProperty.p is EditData<DefaultGomoku>) {
						switch ((EditData<DefaultGomoku>.Property)wrapProperty.n) {
						case EditData<DefaultGomoku>.Property.origin:
							dirty = true;
							break;
						case EditData<DefaultGomoku>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultGomoku>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultGomoku>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<DefaultGomoku>.Property.canEdit:
							dirty = true;
							break;
						case EditData<DefaultGomoku>.Property.editType:
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
						if (wrapProperty.p is DefaultGomoku) {
							switch ((DefaultGomoku.Property)wrapProperty.n) {
							case DefaultGomoku.Property.boardSize:
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
						if (wrapProperty.p is Server) {
							Server.State.OnUpdateSyncStateChange (wrapProperty, this);
							return;
						}
					}
				}
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
						// GameType
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