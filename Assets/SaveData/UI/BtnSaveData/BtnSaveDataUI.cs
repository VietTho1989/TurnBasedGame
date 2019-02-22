using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

public class BtnSaveDataUI : UIBehavior<BtnSaveDataUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<SaveTask.TaskData> saveData;

		public VP<ConfirmSaveDataUI.UIData> confirmSave;

		#region Constructor

		public enum Property
		{
			saveData,
			confirmSave
		}

		public UIData() : base()
		{
			this.saveData = new VP<SaveTask.TaskData>(this, (byte)Property.saveData, new SaveTask.TaskData());
			this.confirmSave = new VP<ConfirmSaveDataUI.UIData>(this, (byte)Property.confirmSave, null);
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// confirmSave
				if (!isProcess) {
					ConfirmSaveDataUI.UIData confirmSave = this.confirmSave.v;
					if (confirmSave != null) {
						isProcess = confirmSave.processEvent (e);
					} else {
						Debug.LogError ("confirmSave null: " + this);
					}
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtSave = new TxtLanguage();
	public static readonly TxtLanguage txtSaving = new TxtLanguage();

	static BtnSaveDataUI()
	{
		txtSave.add (Language.Type.vi, "Lưu Dữ Liệu");
		txtSaving.add (Language.Type.vi, "Đang lưu dữ liệu...");
	}

	#endregion

	public Button btnSaveData;
	public Text tvSaveData;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// btnSaveData, tvSaveData
				if (btnSaveData != null && tvSaveData != null) {
					SaveTask.TaskData saveData = this.data.saveData.v;
					if (saveData != null) {
						switch (saveData.state.v) {
						case SaveTask.TaskData.State.None:
							{
								btnSaveData.interactable = true;
								tvSaveData.text = txtSave.get ("Save Data");
							}
							break;
						case SaveTask.TaskData.State.Save:
							{
								this.data.confirmSave.v = null;
								btnSaveData.interactable = false;
								tvSaveData.text = txtSaving.get ("Saving data...");
							}
							break;
						case SaveTask.TaskData.State.Success:
							{
								this.data.confirmSave.v = null;
								saveData.state.v = SaveTask.TaskData.State.None;
								// refresh
								{
									SaveUI.UIData saveUIData = this.data.findDataInParent<SaveUI.UIData> ();
									if (saveUIData != null) {
										FileSystemBrowserUI.UIData fileSystemBrowserUIData = saveUIData.fileSystemBrowser.v;
										if (fileSystemBrowserUIData != null) {
											FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
											if (fileSystemBrowser != null) {
												fileSystemBrowser.refresh ();
												fileSystemBrowser.selectFile (saveData.file, false, false);
											} else {
												Debug.LogError ("fileSystemBrowser null: " + this);
											}
										} else {
											Debug.LogError ("fileSystemBrowserUIData null: " + this);
										}
									} else {
										Debug.LogError ("savevUIData null: " + this);
									}
								}
							}
							break;
						case SaveTask.TaskData.State.Fail:
							{
								this.data.confirmSave.v = null;
								saveData.state.v = SaveTask.TaskData.State.None;
							}
							break;
						default:
							Debug.LogError ("unknown state: " + saveData.state.v + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("saveData null: " + this);
					}
				} else {
					Debug.LogError ("btnSaveData, tvSaveData null: " + this);
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

	public ConfirmSaveDataUI confirmSaveDataPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.saveData.allAddCallBack (this);
				uiData.confirmSave.allAddCallBack (this);
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
			if (data is SaveTask.TaskData) {
				SaveTask.TaskData saveTask = data as SaveTask.TaskData;
				// Update
				{
					UpdateUtils.makeUpdate<SaveTask, SaveTask.TaskData> (saveTask, this.transform);
				}
				dirty = true;
				return;
			}
			if (data is ConfirmSaveDataUI.UIData) {
				ConfirmSaveDataUI.UIData confirmSaveDataUIData = data as ConfirmSaveDataUI.UIData;
				// UI
				{
					// find
					Transform confirmSaveContainer = null;
					{
						if (this.data != null) {
							SaveUI.UIData saveUIData = this.data.findDataInParent<SaveUI.UIData> ();
							if (saveUIData != null) {
								SaveUI saveUI = saveUIData.findCallBack<SaveUI> ();
								if (saveUI != null) {
									confirmSaveContainer = saveUI.confirmSaveContainer;
								} else {
									Debug.LogError ("saveUI null: " + this);
								}
							} else {
								Debug.LogError ("saveUIData null: " + this);
							}
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					Debug.LogError ("find confirmSaveContainer: " + confirmSaveContainer);
					// process
					UIUtils.Instantiate(confirmSaveDataUIData, confirmSaveDataPrefab, confirmSaveContainer);
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
				uiData.saveData.allRemoveCallBack (this);
				uiData.confirmSave.allRemoveCallBack (this);
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
			if (data is SaveTask.TaskData) {
				SaveTask.TaskData saveTask = data as SaveTask.TaskData;
				// Update
				{
					saveTask.removeCallBackAndDestroy (typeof(SaveTask));
				}
				return;
			}
			if (data is ConfirmSaveDataUI.UIData) {
				ConfirmSaveDataUI.UIData confirmSaveDataUIData = data as ConfirmSaveDataUI.UIData;
				// UI
				{
					confirmSaveDataUIData.removeCallBackAndDestroy (typeof(ConfirmSaveDataUI));
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
			case UIData.Property.saveData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.confirmSave:
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
			if (wrapProperty.p is SaveTask.TaskData) {
				switch ((SaveTask.TaskData.Property)wrapProperty.n) {
				case SaveTask.TaskData.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is ConfirmSaveDataUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnSaveData()
	{
		if (this.data != null) {
			SaveUI.UIData saveUIData = this.data.findDataInParent<SaveUI.UIData> ();
			if (saveUIData != null) {
				Data needSaveData = saveUIData.needSaveData.v.data;
				if (needSaveData != null) {
					SaveTask.TaskData saveData = this.data.saveData.v;
					if (saveData != null) {
						if (saveData.state.v == SaveTask.TaskData.State.None) {
							// get file
							FileInfo file = null;
							{
								SaveUI saveUI = saveUIData.findCallBack<SaveUI> ();
								if (saveUI != null) {
									if (saveUI.edtName != null) {
										string fileName = saveUI.edtName.text;
										if (!string.IsNullOrEmpty (fileName)) {
											// find folder
											DirectoryInfo dir = null;
											{
												FileSystemBrowserUI.UIData fileSystemBrowserUIData = saveUIData.fileSystemBrowser.v;
												if (fileSystemBrowserUIData != null) {
													FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
													if (fileSystemBrowser != null) {
														DirectoryInfo currentDir = fileSystemBrowser.getCurrentDirectory ();
														if (currentDir != null && currentDir.Exists) {
															dir = currentDir;
														}
													} else {
														Debug.LogError ("fileSystemBrowser null: " + this);
													}
												} else {
													Debug.LogError ("fileSystemBrowserUIData null: " + this);
												}
											}
											// Process
											if (dir != null) {
												file = new FileInfo (Path.Combine (dir.FullName, fileName) + Save.SaveExtension);
											} else {
												Debug.LogError ("dir null: " + this);
											}
										} else {
											Debug.LogError ("fileName null: " + this);
										}
									} else {
										Debug.LogError ("edtName null: " + this);
									}
								} else {
									Debug.LogError ("saveUI null: " + this);
								}
							}
							// process
							if (file != null) {
								if (!file.Exists) {
									saveData.file = file;
									// content
									{
										SaveData newSaveData = new SaveData ();
										{
											newSaveData.data = DataUtils.cloneData (needSaveData);
										}
										saveData.save.content = newSaveData;
									}
									saveData.state.v = SaveTask.TaskData.State.Save;
								} else {
									ConfirmSaveDataUI.UIData confirmSaveUIData = this.data.confirmSave.newOrOld<ConfirmSaveDataUI.UIData> ();
									{
										confirmSaveUIData.fileInfo.v = file;
									}
									this.data.confirmSave.v = confirmSaveUIData;
								}
							} else {
								Debug.LogError ("file null: " + this);
							}
						} else {
							Debug.LogError ("you are saving: " + this);
						}
					} else {
						Debug.LogError ("saveData null: " + this);
					}
				} else {
					Debug.LogError ("needSaveData null: " + this);
				}
			} else {
				Debug.LogError ("saveUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}