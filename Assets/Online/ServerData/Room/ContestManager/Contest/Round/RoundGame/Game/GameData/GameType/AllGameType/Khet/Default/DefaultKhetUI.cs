using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class DefaultKhetUI : UIBehavior<DefaultKhetUI.UIData>
	{

		#region UIData

		public class UIData : DefaultGameTypeUI
		{

			public VP<EditData<DefaultKhet>> editDefaultKhet;

			#region startPos

			public VP<RequestChangeEnumUI.UIData> startPos;

			public void makeRequestChangeStartPos (RequestChangeUpdate<int>.UpdateData update, int newStartPos)
			{
				// Find
				DefaultKhet defaultKhet = null;
				{
					EditData<DefaultKhet> editDefaultKhet = this.editDefaultKhet.v;
					if (editDefaultKhet != null) {
						defaultKhet = editDefaultKhet.show.v.data;
					} else {
						Debug.LogError ("editDefaultKhet null: " + this);
					}
				}
				// Process
				if (defaultKhet != null) {
					defaultKhet.requestChangeStartPos (Server.getProfileUserId (defaultKhet), (DefaultKhet.StartPos)newStartPos);
				} else {
					Debug.LogError ("defaultKhet null: " + this);
				}
			}

			#endregion

			public VP<MiniGameDataUI.UIData> miniGameDataUIData;

			#region Constructor

			public enum Property
			{
				editDefaultKhet,
				startPos,
				miniGameDataUIData
			}

			public UIData() : base()
			{
				this.editDefaultKhet = new VP<EditData<DefaultKhet>>(this, (byte)Property.editDefaultKhet, new EditData<DefaultKhet>());
				{
					this.startPos = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.startPos, new RequestChangeEnumUI.UIData());
					// event
					this.startPos.v.updateData.v.request.v = makeRequestChangeStartPos;
					// Options
					foreach (DefaultKhet.StartPos startPos in System.Enum.GetValues(typeof(DefaultKhet.StartPos))) {
						this.startPos.v.options.add(startPos.ToString());
					}
				}
				this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Khet;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbStartPos;
		public static readonly TxtLanguage txtStartPos = new TxtLanguage ();

		static DefaultKhetUI()
		{
			txtTitle.add (Language.Type.vi, "Khet Mặc Định");
			txtStartPos.add (Language.Type.vi, "Vị trí bắt đầu");
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
					EditData<DefaultKhet> editDefaultKhet = this.data.editDefaultKhet.v;
					if (editDefaultKhet != null) {
						editDefaultKhet.update ();
						// get show
						DefaultKhet show = editDefaultKhet.show.v.data;
						DefaultKhet compare = editDefaultKhet.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editDefaultKhet.compareOtherType.v.data != null) {
										if (editDefaultKhet.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// startPos
									{
										RequestChangeEnumUI.UIData startPos = this.data.startPos.v;
										if (startPos != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = startPos.updateData.v;
											if (updateData != null) {
												updateData.origin.v = (int)show.startPos.v;
												updateData.canRequestChange.v = editDefaultKhet.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													startPos.showDifferent.v = true;
													startPos.compare.v = (int)compare.startPos.v;
												} else {
													startPos.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("startPos null: " + this);
										}
									}
								}
								// reset?
								if (needReset) {
									needReset = false;
									// startPos
									{
										RequestChangeEnumUI.UIData startPos = this.data.startPos.v;
										if (startPos != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = startPos.updateData.v;
											if (updateData != null) {
												updateData.current.v = (int)show.startPos.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("startPos null: " + this);
										}
									}
								}
							}
							// miniGameDataUIData
							if(miniGameDataDirty){
								// find miniGameDataUIData
								MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUIData.newOrOld<MiniGameDataUI.UIData>();
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
												// Find Khet
												Khet khet = gameData.gameType.newOrOld<Khet>();
												{
													// Make new khet
													Khet newKhet = (Khet)show.makeDefaultGameType ();;
													// Copy
													DataUtils.copyData(khet, newKhet);
												}
												gameData.gameType.v = khet;
											}
										}
									}
								}
								this.data.miniGameDataUIData.v = miniGameDataUIData;
								miniGameDataDirty = false;
							}
						} else {
							Debug.LogError ("defaultKhet null: " + this);
						}
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Default Khet");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbStartPos != null) {
							lbStartPos.text = txtStartPos.get ("Start pos");
						} else {
							Debug.LogError ("lbStartPos null: " + this);
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

		public RequestChangeEnumUI requestEnumPrefab;
		public Transform startPosContainer;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editDefaultKhet.allAddCallBack (this);
					uiData.startPos.allAddCallBack (this);
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
				// editDefaultKhet
				{
					if (data is EditData<DefaultKhet>) {
						EditData<DefaultKhet> editDefaultKhet = data as EditData<DefaultKhet>;
						// Child
						{
							editDefaultKhet.show.allAddCallBack (this);
							editDefaultKhet.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is DefaultKhet) {
							DefaultKhet defaultKhet = data as DefaultKhet;
							// Parent
							{
								DataUtils.addParentCallBack (defaultKhet, this, ref this.server);
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
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.startPos:
								UIUtils.Instantiate (requestChange, requestEnumPrefab, startPosContainer);
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
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.editDefaultKhet.allRemoveCallBack (this);
					uiData.startPos.allRemoveCallBack (this);
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
				// editDefaultKhet
				{
					if (data is EditData<DefaultKhet>) {
						EditData<DefaultKhet> editDefaultKhet = data as EditData<DefaultKhet>;
						// Child
						{
							editDefaultKhet.show.allRemoveCallBack (this);
							editDefaultKhet.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is DefaultKhet) {
							DefaultKhet defaultKhet = data as DefaultKhet;
							// Parent
							{
								DataUtils.removeParentCallBack (defaultKhet, this, ref this.server);
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
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
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
				case UIData.Property.editDefaultKhet:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.startPos:
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
				// EditDefaultKhet
				{
					if (wrapProperty.p is EditData<DefaultKhet>) {
						switch ((EditData<DefaultKhet>.Property)wrapProperty.n) {
						case EditData<DefaultKhet>.Property.origin:
							dirty = true;
							break;
						case EditData<DefaultKhet>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultKhet>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultKhet>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<DefaultKhet>.Property.canEdit:
							dirty = true;
							break;
						case EditData<DefaultKhet>.Property.editType:
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
						if (wrapProperty.p is DefaultKhet) {
							switch ((DefaultKhet.Property)wrapProperty.n) {
							case DefaultKhet.Property.startPos:
								miniGameDataDirty = true;
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
				if (wrapProperty.p is RequestChangeEnumUI.UIData) {
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