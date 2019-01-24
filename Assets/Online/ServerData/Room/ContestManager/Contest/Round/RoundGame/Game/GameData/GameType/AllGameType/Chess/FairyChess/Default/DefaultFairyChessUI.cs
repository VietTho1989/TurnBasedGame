using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class DefaultFairyChessUI : UIBehavior<DefaultFairyChessUI.UIData>
	{

		#region UIData

		public class UIData : DefaultGameTypeUI
		{

			public VP<EditData<DefaultFairyChess>> editDefaultFairyChess;

			#region variantType

			public VP<RequestChangeEnumUI.UIData> variantType;

			public void makeRequestChangeVariantType (RequestChangeUpdate<int>.UpdateData update, int newVariantType)
			{
				// Find
				DefaultFairyChess defaultFairyChess = null;
				{
					EditData<DefaultFairyChess> editDefaultFairyChess = this.editDefaultFairyChess.v;
					if (editDefaultFairyChess != null) {
						defaultFairyChess = editDefaultFairyChess.show.v.data;
					} else {
						Debug.LogError ("editDefaultFairyChess null: " + this);
					}
				}
				// Process
				if (defaultFairyChess != null) {
					// Find variantType
					Common.VariantType variantType = Common.VariantType.asean;
					{
						if (newVariantType >= 0 && newVariantType < VariantMap.EnableVariants.Length) {
							variantType = VariantMap.EnableVariants [newVariantType];
						}
					}
					defaultFairyChess.requestChangeVariantType (Server.getProfileUserId (defaultFairyChess), variantType);
				} else {
					Debug.LogError ("defaultFairyChess null: " + this);
				}
			}

			#endregion

			#region chess960

			public VP<RequestChangeBoolUI.UIData> chess960;

			public void makeRequestChangeChess960 (RequestChangeUpdate<bool>.UpdateData update, bool newChess960)
			{
				// Find
				DefaultFairyChess defaultFairyChess = null;
				{
					EditData<DefaultFairyChess> editDefaultFairyChess = this.editDefaultFairyChess.v;
					if (editDefaultFairyChess != null) {
						defaultFairyChess = editDefaultFairyChess.show.v.data;
					} else {
						Debug.LogError ("editDefaultFairyChess null: " + this);
					}
				}
				// Process
				if (defaultFairyChess != null) {
					defaultFairyChess.requestChangeChess960 (Server.getProfileUserId(defaultFairyChess), newChess960);
				} else {
					Debug.LogError ("defaultFairyChess null: " + this);
				}
			}

			#endregion

			public VP<MiniGameDataUI.UIData> miniGameDataUIData;

			#region Constructor

			public enum Property
			{
				editDefaultFairyChess,
				variantType,
				chess960,
				miniGameDataUIData
			}

			public UIData() : base()
			{
				this.editDefaultFairyChess = new VP<EditData<DefaultFairyChess>>(this, (byte)Property.editDefaultFairyChess, new EditData<DefaultFairyChess>());
				// variantType
				{
					this.variantType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.variantType, new RequestChangeEnumUI.UIData());
					// event
					this.variantType.v.updateData.v.request.v = makeRequestChangeVariantType;
					{
						for(int i=0; i<VariantMap.EnableVariants.Length; i++){
							this.variantType.v.options.add(VariantMap.EnableVariants[i].ToString());
						}
					}
				}
				// chess960
				{
					this.chess960 = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.chess960, new RequestChangeBoolUI.UIData());
					// event
					this.chess960.v.updateData.v.request.v = makeRequestChangeChess960;
				}
				this.miniGameDataUIData = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUIData, new MiniGameDataUI.UIData());
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.FairyChess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text lbVariantType;
		public static readonly TxtLanguage txtVariantType = new TxtLanguage ();

		public Text lbChess960;
		public static readonly TxtLanguage txtChess960 = new TxtLanguage ();

		static DefaultFairyChessUI()
		{
			txtTitle.add (Language.Type.vi, "Biến Thể Cờ Vua Mặc Định");
			txtVariantType.add (Language.Type.vi, "Thể loại");
			txtChess960.add (Language.Type.vi, "Chess960");
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
					EditData<DefaultFairyChess> editDefaultFairyChess = this.data.editDefaultFairyChess.v;
					if (editDefaultFairyChess != null) {
						editDefaultFairyChess.update ();
						// get show
						DefaultFairyChess show = editDefaultFairyChess.show.v.data;
						DefaultFairyChess compare = editDefaultFairyChess.compare.v.data;
						if (show != null) {
							// differentIndicator
							if (differentIndicator != null) {
								bool isDifferent = false;
								{
									if (editDefaultFairyChess.compareOtherType.v.data != null) {
										if (editDefaultFairyChess.compareOtherType.v.data.GetType () != show.GetType ()) {
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
									// variantType
									{
										RequestChangeEnumUI.UIData variantType = this.data.variantType.v;
										if (variantType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = variantType.updateData.v;
											if (updateData != null) {
												updateData.origin.v = VariantMap.getEnableVariantIndex (show.variantType.v);
												updateData.canRequestChange.v = editDefaultFairyChess.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													variantType.showDifferent.v = true;
													variantType.compare.v = VariantMap.getEnableVariantIndex (compare.variantType.v);
												} else {
													variantType.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("variantType null: " + this);
										}
									}
									// chess960
									{
										RequestChangeBoolUI.UIData chess960 = this.data.chess960.v;
										if (chess960 != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = chess960.updateData.v;
											if (updateData != null) {
												updateData.origin.v = show.chess960.v;
												updateData.canRequestChange.v = editDefaultFairyChess.canEdit.v;
												updateData.serverState.v = serverState;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
											// compare
											{
												if (compare != null) {
													chess960.showDifferent.v = true;
													chess960.compare.v = compare.chess960.v;
												} else {
													chess960.showDifferent.v = false;
												}
											}
										} else {
											Debug.LogError ("chess960 null: " + this);
										}
									}
								}
								// reset?
								if (needReset) {
									needReset = false;
									// variantType
									{
										RequestChangeEnumUI.UIData variantType = this.data.variantType.v;
										if (variantType != null) {
											// update
											RequestChangeUpdate<int>.UpdateData updateData = variantType.updateData.v;
											if (updateData != null) {
												updateData.current.v = VariantMap.getEnableVariantIndex (show.variantType.v);
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("variantType null: " + this);
										}
									}
									// chess960
									{
										RequestChangeBoolUI.UIData chess960 = this.data.chess960.v;
										if (chess960 != null) {
											// update
											RequestChangeUpdate<bool>.UpdateData updateData = chess960.updateData.v;
											if (updateData != null) {
												updateData.current.v = show.chess960.v;
												updateData.changeState.v = Data.ChangeState.None;
											} else {
												Debug.LogError ("updateData null: " + this);
											}
										} else {
											Debug.LogError ("chess960 null: " + this);
										}
									}
								}
							}
							// miniGameDataUIData
							if(miniGameDataDirty){
								miniGameDataDirty = false;
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
												// Find FairyChess
												FairyChess fairyChess = gameData.gameType.newOrOld<FairyChess>();
												{
													// Make new fairyChess
													FairyChess newFairyChess = (FairyChess)show.makeDefaultGameType ();;
													{
														if (newFairyChess.chess960.v) {
															for (Common.Rank y = Common.Rank.RANK_8; y >= Common.Rank.RANK_1; --y) {
																for (Common.File x = Common.File.FILE_A; x <= Common.File.FILE_H; ++x) {
																	// Common.Square square = Common.make_square (x, y);
																	// Common.Piece piece = newFairyChess.piece_on (square);
																	// TODO Can hoan thien
																	/*if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.W_PAWN && piece != Common.Piece.B_PAWN) {
																		newFairyChess.setPieceOn (square, Common.Piece.PIECE_NB);
																	}*/
																}
															}
														}
													}
													// Copy
													DataUtils.copyData(fairyChess, newFairyChess);
												}
												gameData.gameType.v = fairyChess;
											}
										}
									}
								}
								this.data.miniGameDataUIData.v = miniGameDataUIData;
							}
						} else {
							Debug.LogError ("defaultFairyChess null: " + this);
						}
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Default Fairy Chess");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (lbVariantType != null) {
							lbVariantType.text = txtVariantType.get ("Variant type");
						} else {
							Debug.LogError ("lbVariantType null: " + this);
						}
						if (lbChess960 != null) {
							lbChess960.text = txtChess960.get ("Chess960");
						} else {
							Debug.LogError ("lbChess960 null: " + this);
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
		public Transform variantTypeContainer;

		public RequestChangeBoolUI requestBoolPrefab;
		public Transform chess960Container;

		private Server server = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.editDefaultFairyChess.allAddCallBack (this);
					uiData.variantType.allAddCallBack (this);
					uiData.chess960.allAddCallBack (this);
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
				// editDefaultFairyChess
				{
					if (data is EditData<DefaultFairyChess>) {
						EditData<DefaultFairyChess> editDefaultFairyChess = data as EditData<DefaultFairyChess>;
						// Child
						{
							editDefaultFairyChess.show.allAddCallBack (this);
							editDefaultFairyChess.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is DefaultFairyChess) {
							DefaultFairyChess defaultFairyChess = data as DefaultFairyChess;
							// Parent
							{
								DataUtils.addParentCallBack (defaultFairyChess, this, ref this.server);
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
				// variantType
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.variantType:
								UIUtils.Instantiate (requestChange, requestEnumPrefab, variantTypeContainer);
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
				// chess960
				if (data is RequestChangeBoolUI.UIData) {
					RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
					// UI
					{
						WrapProperty wrapProperty = requestChange.p;
						if (wrapProperty != null) {
							switch ((UIData.Property)wrapProperty.n) {
							case UIData.Property.chess960:
								UIUtils.Instantiate (requestChange, requestBoolPrefab, chess960Container);
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
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.editDefaultFairyChess.allRemoveCallBack (this);
					uiData.variantType.allRemoveCallBack (this);
					uiData.chess960.allRemoveCallBack (this);
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
				// editDefaultFairyChess
				{
					if (data is EditData<DefaultFairyChess>) {
						EditData<DefaultFairyChess> editDefaultFairyChess = data as EditData<DefaultFairyChess>;
						// Child
						{
							editDefaultFairyChess.show.allRemoveCallBack (this);
							editDefaultFairyChess.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is DefaultFairyChess) {
							DefaultFairyChess defaultFairyChess = data as DefaultFairyChess;
							// Parent
							{
								DataUtils.removeParentCallBack (defaultFairyChess, this, ref this.server);
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
				// variantType
				if (data is RequestChangeEnumUI.UIData) {
					RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
					// UI
					{
						requestChange.removeCallBackAndDestroy (typeof(RequestChangeEnumUI));
					}
					return;
				}
				// chess960
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
				case UIData.Property.editDefaultFairyChess:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.variantType:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.chess960:
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
				// EditDefaultFairyChess
				{
					if (wrapProperty.p is EditData<DefaultFairyChess>) {
						switch ((EditData<DefaultFairyChess>.Property)wrapProperty.n) {
						case EditData<DefaultFairyChess>.Property.origin:
							dirty = true;
							break;
						case EditData<DefaultFairyChess>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultFairyChess>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<DefaultFairyChess>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<DefaultFairyChess>.Property.canEdit:
							dirty = true;
							break;
						case EditData<DefaultFairyChess>.Property.editType:
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
						if (wrapProperty.p is DefaultFairyChess) {
							switch ((DefaultFairyChess.Property)wrapProperty.n) {
							case DefaultFairyChess.Property.variantType:
								miniGameDataDirty = true;
								dirty = true;
								break;
							case DefaultFairyChess.Property.chess960:
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
				// variantType
				if (wrapProperty.p is RequestChangeEnumUI.UIData) {
					return;
				}
				// chess960
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