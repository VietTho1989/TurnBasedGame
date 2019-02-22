using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

namespace Posture
{
	public class LoadPostureUI : UIBehavior<LoadPostureUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<GameType.Type> gameType;

			public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

			public VP<LoadDataTask.TaskData> loadDataTask;

			#region Constructor

			public enum Property
			{
				gameType,
				fileSystemBrowser,
				loadDataTask
			}

			public UIData() : base()
			{
				this.gameType = new VP<GameType.Type>(this, (byte)Property.gameType, GameType.Type.CHESS);
				// fileSystemBrowser
				{
					this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
					this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
				}
				this.loadDataTask = new VP<LoadDataTask.TaskData>(this, (byte)Property.loadDataTask, new LoadDataTask.TaskData());
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// fileSystemBrowser
					if (!isProcess) {
						FileSystemBrowserUI.UIData fileSystemBrowser = this.fileSystemBrowser.v;
						if (fileSystemBrowser != null) {
							isProcess = fileSystemBrowser.processEvent (e);
						} else {
							Debug.LogError ("fileSystemBrowser null: " + this);
						}
					}
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							LoadPostureUI loadPostureUI = this.findCallBack<LoadPostureUI> ();
							if (loadPostureUI != null) {
								loadPostureUI.onClickBtnBack ();
							} else {
								Debug.LogError ("loadPostureUI null: " + this);
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text tvBack;
		public static readonly TxtLanguage txtBack = new TxtLanguage();

		public static readonly TxtLanguage txtLoad = new TxtLanguage();
		public static readonly TxtLanguage txtNotSelectFile = new TxtLanguage ();
		public static readonly TxtLanguage txtLoading = new TxtLanguage ();
		public static readonly TxtLanguage txtLoadSuccess = new TxtLanguage ();
		public static readonly TxtLanguage txtLoadFail = new TxtLanguage ();

		static LoadPostureUI()
		{
			txtTitle.add (Language.Type.vi, "Tải Thế Cờ");
			txtBack.add (Language.Type.vi, "Quay Lại");

			txtLoad.add (Language.Type.vi, "Tải");
			txtNotSelectFile.add (Language.Type.vi, "Không chọn file");
			txtLoading.add (Language.Type.vi, "Đang tải");
			txtLoadSuccess.add (Language.Type.vi, "Tải thành công");
			txtLoadFail.add (Language.Type.vi, "Tải thất bại");
		}

		#endregion

		public Button btnLoad;
		public Text tvLoad;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// loadData
					{
						// btnLoad, tvLoad
						{
							if (btnLoad != null && tvLoad != null) {
								LoadDataTask.TaskData loadDataTask = this.data.loadDataTask.v;
								if (loadDataTask != null) {
									switch (loadDataTask.state.v) {
									case LoadDataTask.TaskData.State.None:
										{
											// check have correct select file
											bool haveCorrectSelectFile = false;
											{
												FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
												if (fileSystemBrowserUIData != null) {
													FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
													if (fileSystemBrowser != null) {
														Action action = fileSystemBrowser.action.v;
														if (action != null) {
															if (action is ActionNone) {
																ActionNone actionNone = action as ActionNone;
																if (actionNone.selectFiles.vs.Count == 1) {
																	FileSystemInfo fileSystemInfo = actionNone.selectFiles.vs [0];
																	if (fileSystemInfo is FileInfo) {
																		FileInfo fileInfo = fileSystemInfo as FileInfo;
																		if (fileInfo.Extension == Save.SaveExtension || fileInfo.Extension == Save.FenExtension) {
																			haveCorrectSelectFile = true;
																		}
																	}
																}
															}
														} else {
															Debug.LogError ("action null: " + this);
														}
													} else {
														Debug.LogError ("fileSystemBrowser null: " + this);
													}
												} else {
													Debug.LogError ("fileSystemBrowserUIData null: " + this);
												}
											}
											// Process
											{
												if (haveCorrectSelectFile) {
													btnLoad.interactable = true;
													tvLoad.text = txtLoad.get("Load");
												} else {
													btnLoad.interactable = false;
													tvLoad.text = txtNotSelectFile.get ("Cannot Load, Not select file");
												}
											}
										}
										break;
									case LoadDataTask.TaskData.State.Load:
										{
											btnLoad.interactable = false;
											tvLoad.text = txtLoading.get("Loading");
										}
										break;
									case LoadDataTask.TaskData.State.Success:
										{
											btnLoad.interactable = false;
											tvLoad.text = txtLoadSuccess.get("Load Success");
										}
										break;
									case LoadDataTask.TaskData.State.Fail:
										{
											btnLoad.interactable = false;
											tvLoad.text = txtLoadFail.get("Load Fail");
										}
										break;
									default:
										Debug.LogError ("unknown state: " + loadDataTask.state.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("loadDataTask null: " + this);
								}
							} else {
								Debug.LogError ("btnLoad, tvLoad null: " + this);
							}
						}
						// UpdateTask
						{
							LoadDataTask.TaskData loadDataTask = this.data.loadDataTask.v;
							if (loadDataTask != null) {
								switch (loadDataTask.state.v) {
								case LoadDataTask.TaskData.State.None:
									{

									}
									break;
								case LoadDataTask.TaskData.State.Load:
									{

									}
									break;
								case LoadDataTask.TaskData.State.Success:
									{
										// set new Data 
										/*{
											GameData gameData = null;
											{
												if (loadDataTask.save != null) {
													if (loadDataTask.save.version == Global.VersionCode) {
														if (loadDataTask.save.content is SaveData) {
															SaveData saveData = loadDataTask.save.content as SaveData;
															// game
															if (saveData.data is Game) {
																Game game = saveData.data as Game;
																GameData checkGameData = game.gameData.v;
																if (checkGameData != null) {
																	GameType checkGameType = checkGameData.gameType.v;
																	if (checkGameType != null) {
																		if (checkGameType.getType () == this.data.gameType.v) {
																			gameData = checkGameData;
																		} else {
																			Debug.LogError ("different gameType: " + checkGameType.getType () + "; " + this.data.gameType.v);
																		}
																	} else {
																		Debug.LogError ("checkGameType null: " + this);
																	}
																} else {
																	Debug.LogError ("checkGameData null: " + this);
																}
															}
															// 
														}
													} else {
														Debug.LogError ("wrong version: " + loadDataTask.save.version);
													}
												}
											}
											if (gameData != null) {
												EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.findDataInParent<EditPostureGameDataUI.UIData> ();
												if (editPostureGameDataUIData != null) {
													// set gameData
													{
														EditPostureGameDataUI editPostureGameDataUI = editPostureGameDataUIData.findCallBack<EditPostureGameDataUI> ();
														if (editPostureGameDataUI != null) {
															editPostureGameDataUI.makeNewGame (gameData);
														} else {
															Debug.LogError ("editPostureGameDataUI null: " + this);
														}
													}
													editPostureGameDataUIData.loadPostureUIData.v = null;
												} else {
													Debug.LogError ("editPostureGameDataUIData null: " + this);
												}
											} else {
												Debug.LogError ("gameData null: " + this);
												Toast.showMessage (txtLoadFail.get ("load fail"));
											}
										}*/
										// set new game
										{
											Game game = null;
											{
												if (loadDataTask.save != null) {
													if (loadDataTask.save.version == Global.VersionCode) {
														if (loadDataTask.save.content is SaveData) {
															SaveData saveData = loadDataTask.save.content as SaveData;
															// game
															if (saveData.data is Game) {
																Game saveGame = saveData.data as Game;
																GameData checkGameData = saveGame.gameData.v;
																if (checkGameData != null) {
																	GameType checkGameType = checkGameData.gameType.v;
																	if (checkGameType != null) {
																		if (checkGameType.getType () == this.data.gameType.v) {
																			game = saveGame;
																		} else {
																			Debug.LogError ("different gameType: " + checkGameType.getType () + "; " + this.data.gameType.v);
																		}
																	} else {
																		Debug.LogError ("checkGameType null: " + this);
																	}
																} else {
																	Debug.LogError ("checkGameData null: " + this);
																}
															}
															// 
														}
													} else {
														Debug.LogError ("wrong version: " + loadDataTask.save.version);
													}
												}
											}
											if (game != null) {
												EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.findDataInParent<EditPostureGameDataUI.UIData> ();
												if (editPostureGameDataUIData != null) {
													// set gameData
													{
														EditPostureGameDataUI editPostureGameDataUI = editPostureGameDataUIData.findCallBack<EditPostureGameDataUI> ();
														if (editPostureGameDataUI != null) {
															editPostureGameDataUI.makeNewGame (game);
														} else {
															Debug.LogError ("editPostureGameDataUI null: " + this);
														}
													}
													editPostureGameDataUIData.loadPostureUIData.v = null;
												} else {
													Debug.LogError ("editPostureGameDataUIData null: " + this);
												}
											} else {
												Debug.LogError ("gameData null: " + this);
												Toast.showMessage (txtLoadFail.get ("load fail"));
											}
										}
										loadDataTask.state.v = LoadDataTask.TaskData.State.None;
									}
									break;
								case LoadDataTask.TaskData.State.Fail:
									{
										loadDataTask.state.v = LoadDataTask.TaskData.State.None;
									}
									break;
								default:
									Debug.LogError ("unknown state: " + loadDataTask.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("loadDataTask null: " + this);
							}
						}
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Load Posture");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (tvBack != null) {
							tvBack.text = txtBack.get ("Back");
						} else {
							Debug.LogError ("tvBack null: " + this);
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

		public FileSystemBrowserUI fileSystemBrowserPrefab;
		public Transform fileSystemBrowserContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.fileSystemBrowser.allAddCallBack (this);
					uiData.loadDataTask.allAddCallBack (this);
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
				// fileSystemBrowserUIData
				{
					if (data is FileSystemBrowserUI.UIData) {
						FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
						// UI
						{
							UIUtils.Instantiate (fileSystemBrowserUIData, fileSystemBrowserPrefab, fileSystemBrowserContainer);
						}
						// Child
						{
							fileSystemBrowserUIData.fileSystemBrowser.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is FileSystemBrowser) {
							FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
							// Child
							{
								fileSystemBrowser.action.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						if (data is Action) {
							dirty = true;
							return;
						}
					}
				}
				if (data is LoadDataTask.TaskData) {
					LoadDataTask.TaskData loadDataTask = data as LoadDataTask.TaskData;
					// Update
					{
						UpdateUtils.makeUpdate<LoadDataTask, LoadDataTask.TaskData> (loadDataTask, this.transform);
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
					uiData.fileSystemBrowser.allRemoveCallBack (this);
					uiData.loadDataTask.allRemoveCallBack (this);
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
				// fileSystemBrowserUIData
				{
					if (data is FileSystemBrowserUI.UIData) {
						FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
						// UI
						{
							fileSystemBrowserUIData.removeCallBackAndDestroy (typeof(FileSystemBrowserUI));
						}
						// Child
						{
							fileSystemBrowserUIData.fileSystemBrowser.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is FileSystemBrowser) {
							FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
							// Child
							{
								fileSystemBrowser.action.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						if (data is Action) {
							return;
						}
					}
				}
				if (data is LoadDataTask.TaskData) {
					LoadDataTask.TaskData loadDataTask = data as LoadDataTask.TaskData;
					// Update
					{
						loadDataTask.removeCallBackAndDestroy (typeof(LoadDataTask));
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
				case UIData.Property.gameType:
					break;
				case UIData.Property.fileSystemBrowser:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.loadDataTask:
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
				// fileSystemBrowserUIData
				{
					if (wrapProperty.p is FileSystemBrowserUI.UIData) {
						switch ((FileSystemBrowserUI.UIData.Property)wrapProperty.n) {
						case FileSystemBrowserUI.UIData.Property.fileSystemBrowser:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case FileSystemBrowserUI.UIData.Property.actionUIData:
							break;
						case FileSystemBrowserUI.UIData.Property.showUIData:
							break;
						case FileSystemBrowserUI.UIData.Property.btnDelete:
							break;
						case FileSystemBrowserUI.UIData.Property.btnCopy:
							break;
						case FileSystemBrowserUI.UIData.Property.btnCut:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is FileSystemBrowser) {
							switch ((FileSystemBrowser.Property)wrapProperty.n) {
							case FileSystemBrowser.Property.action:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case FileSystemBrowser.Property.show:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						if (wrapProperty.p is Action) {
							Action action = wrapProperty.p as Action;
							switch (action.getType ()) {
							case Action.Type.None:
								{
									switch ((ActionNone.Property)wrapProperty.n) {
									case ActionNone.Property.state:
										break;
									case ActionNone.Property.selectFiles:
										dirty = true;
										break;
									default:
										Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
										break;
									}
								}
								break;
							case Action.Type.Edit:
								break;
							default:
								Debug.LogError ("unknown type: " + action.getType () + "; " + this);
								break;
							}
							return;
						}
					}
				}
				if (wrapProperty.p is LoadDataTask.TaskData) {
					switch ((LoadDataTask.TaskData.Property)wrapProperty.n) {
					case LoadDataTask.TaskData.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this + "; " + syncs);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.findDataInParent<EditPostureGameDataUI.UIData> ();
				if (editPostureGameDataUIData != null) {
					editPostureGameDataUIData.loadPostureUIData.v = null;
				} else {
					Debug.LogError ("editPostureGameDataUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null");
			}
		}

		public void onClickBtnLoad()
		{
			if (this.data != null) {
				LoadDataTask.TaskData loadDataTask = this.data.loadDataTask.v;
				if (loadDataTask != null) {
					switch (loadDataTask.state.v) {
					case LoadDataTask.TaskData.State.None:
						{
							// find fileInfo
							FileInfo saveFileInfo = null;
							{
								FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
								if (fileSystemBrowserUIData != null) {
									FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
									if (fileSystemBrowser != null) {
										Action action = fileSystemBrowser.action.v;
										if (action != null) {
											if (action is ActionNone) {
												ActionNone actionNone = action as ActionNone;
												if (actionNone.selectFiles.vs.Count == 1) {
													FileSystemInfo fileSystemInfo = actionNone.selectFiles.vs [0];
													if (fileSystemInfo is FileInfo) {
														FileInfo fileInfo = fileSystemInfo as FileInfo;
														if (fileInfo.Extension == Save.SaveExtension || fileInfo.Extension == Save.FenExtension) {
															saveFileInfo = fileInfo;
														}
													}
												}
											}
										} else {
											Debug.LogError ("action null: " + this);
										}
									} else {
										Debug.LogError ("fileSystemBrowser null: " + this);
									}
								} else {
									Debug.LogError ("fileSystemBrowserUIData null: " + this);
								}
							}
							// Process
							if (saveFileInfo != null) {
								loadDataTask.save = null;
								loadDataTask.file = saveFileInfo;
								loadDataTask.state.v = LoadDataTask.TaskData.State.Load;
							} else {
								Debug.LogError ("saveFileInfo null: " + this);
							}
						}
						break;
					case LoadDataTask.TaskData.State.Load:
						break;
					case LoadDataTask.TaskData.State.Success:
						break;
					case LoadDataTask.TaskData.State.Fail:
						break;
					default:
						Debug.LogError ("unknown state: " + loadDataTask.state.v + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("loadDataTask null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}