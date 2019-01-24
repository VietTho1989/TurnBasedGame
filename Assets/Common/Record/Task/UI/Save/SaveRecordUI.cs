using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

namespace Record
{
	public class SaveRecordUI : UIBehavior<SaveRecordUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

			public VP<SaveRecordTask.TaskData> saveTask;

			public VP<ConfirmSaveRecordUI.UIData> confirmSave;

			#region Constructor

			public enum Property
			{
				fileSystemBrowser,
				saveTask,
				confirmSave
			}

			public UIData() : base()
			{
				{
					this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
					this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
				}
				this.saveTask = new VP<SaveRecordTask.TaskData>(this, (byte)Property.saveTask, new SaveRecordTask.TaskData());
				this.confirmSave = new VP<ConfirmSaveRecordUI.UIData>(this, (byte)Property.confirmSave, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// confirmSave
					if (!isProcess) {
						ConfirmSaveRecordUI.UIData confirmSave = this.confirmSave.v;
						if (confirmSave != null) {
							isProcess = confirmSave.processEvent (e);
						} else {
							Debug.LogError ("confirmSave null: " + this);
						}
					}
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
							SaveRecordUI saveRecordUI = this.findCallBack<SaveRecordUI> ();
							if (saveRecordUI != null) {
								saveRecordUI.onClickBtnBack ();
							} else {
								Debug.LogError ("saveRecordUI null: " + this);
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

		public static readonly TxtLanguage txtSave = new TxtLanguage();
		public static readonly TxtLanguage txtSaving = new TxtLanguage ();

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		public Text tvBack;
		public static readonly TxtLanguage txtBack = new TxtLanguage ();

		public Text tvPlaceHolder;
		public static readonly TxtLanguage txtPlaceHolder = new TxtLanguage();

		static SaveRecordUI()
		{
			txtSave.add (Language.Type.vi, "Lưu");
			txtSaving.add (Language.Type.vi, "Đang lưu...");
			txtTitle.add (Language.Type.vi, "Lưu Trữ Bản Ghi");
			txtBack.add (Language.Type.vi, "Quay Lại");
			txtPlaceHolder.add (Language.Type.vi, "Điền tên file");
		}

		#endregion

		public InputField edtName;

		public Button btnSave;
		public Text tvSave;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// btnSave, tvSave
					if (btnSave != null && tvSave != null) {
						SaveRecordTask.TaskData saveTask = this.data.saveTask.v;
						if (saveTask != null) {
							switch (saveTask.state.v) {
							case SaveRecordTask.TaskData.State.None:
								{
									btnSave.enabled = true;
									tvSave.text = txtSave.get("Save");
								}
								break;
							case SaveRecordTask.TaskData.State.Save:
								{
									this.data.confirmSave.v = null;
									btnSave.enabled = false;
									tvSave.text = txtSaving.get("Saving...");
								}
								break;
							case SaveRecordTask.TaskData.State.Success:
								{
									this.data.confirmSave.v = null;
									saveTask.state.v = SaveRecordTask.TaskData.State.None;
									// refresh
									{
										SaveRecordUI.UIData saveRecordUIData = this.data.findDataInParent<SaveRecordUI.UIData> ();
										if (saveRecordUIData != null) {
											FileSystemBrowserUI.UIData fileSystemBrowserUIData = saveRecordUIData.fileSystemBrowser.v;
											if (fileSystemBrowserUIData != null) {
												FileSystemBrowser fileSystemBrowser = fileSystemBrowserUIData.fileSystemBrowser.v.data;
												if (fileSystemBrowser != null) {
													fileSystemBrowser.refresh ();
													fileSystemBrowser.selectFile (saveTask.file, false, false);
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
							case SaveRecordTask.TaskData.State.Fail:
								{
									this.data.confirmSave.v = null;
									saveTask.state.v = SaveRecordTask.TaskData.State.None;
								}
								break;
							default:
								Debug.LogError ("unknown state: " + saveTask.state.v + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("saveData null: " + this);
						}
					} else {
						Debug.LogError ("btnSaveData, tvSaveData null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Save Record");
						} else {
							Debug.LogError ("lbTitle null: " + this);
						}
						if (tvBack != null) {
							tvBack.text = txtBack.get ("Back");
						} else {
							Debug.LogError ("tvBack null: " + this);
						}
						if (tvPlaceHolder != null) {
							tvPlaceHolder.text = txtPlaceHolder.get ("Enter file name");
						} else {
							Debug.LogError ("tvPlaceHolder null: " + this);
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

		public ConfirmSaveRecordUI confirmSaveRecordPrefab;
		public Transform confirmSaveRecordContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.fileSystemBrowser.allAddCallBack (this);
					uiData.saveTask.allAddCallBack (this);
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
				if (data is FileSystemBrowserUI.UIData) {
					FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
					// UI
					{
						UIUtils.Instantiate (fileSystemBrowserUIData, fileSystemBrowserPrefab, fileSystemBrowserContainer);
					}
					dirty = true;
					return;
				}
				if (data is SaveRecordTask.TaskData) {
					SaveRecordTask.TaskData saveRecordTask = data as SaveRecordTask.TaskData;
					// Update
					{
						UpdateUtils.makeUpdate<SaveRecordTask, SaveRecordTask.TaskData> (saveRecordTask, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is ConfirmSaveRecordUI.UIData) {
					ConfirmSaveRecordUI.UIData confirmSaveRecordUIData = data as ConfirmSaveRecordUI.UIData;
					// UI
					{
						UIUtils.Instantiate (confirmSaveRecordUIData, confirmSaveRecordPrefab, confirmSaveRecordContainer);
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
					uiData.saveTask.allRemoveCallBack (this);
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
				if (data is FileSystemBrowserUI.UIData) {
					FileSystemBrowserUI.UIData fileSystemBrowserUIData = data as FileSystemBrowserUI.UIData;
					// UI
					{
						fileSystemBrowserUIData.removeCallBackAndDestroy (typeof(FileSystemBrowserUI));
					}
					return;
				}
				if (data is SaveRecordTask.TaskData) {
					SaveRecordTask.TaskData saveRecordTask = data as SaveRecordTask.TaskData;
					// Update
					{
						saveRecordTask.removeCallBackAndDestroy (typeof(SaveRecordTask));
					}
					return;
				}
				if (data is ConfirmSaveRecordUI.UIData) {
					ConfirmSaveRecordUI.UIData confirmSaveRecordUIData = data as ConfirmSaveRecordUI.UIData;
					// UI
					{
						confirmSaveRecordUIData.removeCallBackAndDestroy (typeof(ConfirmSaveRecordUI));
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
				case UIData.Property.fileSystemBrowser:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.saveTask:
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
				if (wrapProperty.p is FileSystemBrowserUI.UIData) {
					return;
				}
				if (wrapProperty.p is SaveRecordTask.TaskData) {
					switch ((SaveRecordTask.TaskData.Property)wrapProperty.n) {
					case SaveRecordTask.TaskData.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ConfirmSaveRecordUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				DataRecordTaskUI.UIData dataRecordTaskUIData = this.data.findDataInParent<DataRecordTaskUI.UIData> ();
				if (dataRecordTaskUIData != null) {
					DataRecordTask dataRecordTask = dataRecordTaskUIData.dataRecordTask.v.data;
					if (dataRecordTask != null) {
						dataRecordTask.state.v = DataRecordTask.State.None;
						dataRecordTaskUIData.saveRecordUIData.v = null;
					} else {
						Debug.LogError ("dataRecordTask null: " + this);
					}
				} else {
					Debug.LogError ("dataRecordTaskUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnSaveRecord()
		{
			if (this.data != null) {
				// find dataRecord
				DataRecord dataRecord = null;
				{
					DataRecordTaskUI.UIData dataRecordTaskUIData = this.data.findDataInParent<DataRecordTaskUI.UIData> ();
					if (dataRecordTaskUIData != null) {
						DataRecordTask dataRecordTask = dataRecordTaskUIData.dataRecordTask.v.data;
						if (dataRecordTask != null) {
							dataRecord = dataRecordTask.record;
						} else {
							Debug.LogError ("dataRecordTask null: " + this);
						}
					} else {
						Debug.LogError ("dataRecordTaskUIData null: " + this);
					}
				}
				// Process
				if (dataRecord != null) {
					SaveRecordTask.TaskData saveTask = this.data.saveTask.v;
					if (saveTask != null) {
						if (saveTask.state.v == SaveRecordTask.TaskData.State.None) {
							// get file
							FileInfo file = null;
							{
								if (this.edtName != null) {
									string fileName = this.edtName.text;
									if (!string.IsNullOrEmpty (fileName)) {
										// find folder
										DirectoryInfo dir = null;
										{
											FileSystemBrowserUI.UIData fileSystemBrowserUIData = this.data.fileSystemBrowser.v;
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
											file = new FileInfo (Path.Combine (dir.FullName, fileName) + DataRecord.Extension);
										} else {
											Debug.LogError ("dir null: " + this);
										}
									} else {
										Debug.LogError ("fileName null: " + this);
									}
								} else {
									Debug.LogError ("edtName null: " + this);
								}
							}
							// process
							if (file != null) {
								if (!file.Exists) {
									saveTask.file = file;
									saveTask.dataRecord = dataRecord;
									saveTask.state.v = SaveRecordTask.TaskData.State.Save;
								} else {
									ConfirmSaveRecordUI.UIData confirmSaveUIData = this.data.confirmSave.newOrOld<ConfirmSaveRecordUI.UIData> ();
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
					Debug.LogError ("dataRecord null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}