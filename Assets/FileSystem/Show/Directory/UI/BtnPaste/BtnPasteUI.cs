using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class BtnPasteUI : UIBehavior<BtnPasteUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<ShowDirectory>> showDirectory;

			#region Constructor

			public enum Property
			{
				showDirectory
			}

			public UIData() : base()
			{
				this.showDirectory = new VP<ReferenceData<ShowDirectory>>(this, (byte)Property.showDirectory, new ReferenceData<ShowDirectory>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtPaste = new TxtLanguage();
		public static readonly TxtLanguage txtCannotPaste = new TxtLanguage();

		static BtnPasteUI()
		{
			txtPaste.add (Language.Type.vi, "Dán");
			txtCannotPaste.add (Language.Type.vi, "Dán");
		}

		#endregion

		public Button btnPaste;
		public Text tvPaste;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ShowDirectory showDirectory = this.data.showDirectory.v.data;
					if (showDirectory != null) {
						if (btnPaste != null && tvPaste != null) {
							// find canPaste
							bool canPaste = false;
							{
								if (showDirectory.state.v != ShowDirectory.State.Fail) {
									// check dir
									DirectoryInfo dir = showDirectory.directory.v;
									if (dir != null) {
										if (dir.Exists) {
											// check correct action
											FileSystemBrowser fileSystemBrowser = showDirectory.findDataInParent<FileSystemBrowser>();
											if (fileSystemBrowser != null) {
												Action action = fileSystemBrowser.action.v;
												if (action != null) {
													if (action is ActionNone) {
														ActionNone actionNone = action as ActionNone;
														if (actionNone.state.v == ActionNone.State.Copy || actionNone.state.v == ActionNone.State.Cut) {
															canPaste = true;
														}
													}
												} else {
													Debug.LogError ("action null: " + this);
												}
											} else {
												Debug.LogError ("fileSystemBrowser null: " + this);
											}
										}
									} else {
										Debug.LogError ("dir null: " + this);
									}
								} else {
									Debug.LogError ("load fail: " + this);
								}
							}
							// Process
							{
								if (canPaste) {
									btnPaste.interactable = true;
									tvPaste.text = txtPaste.get ("Paste");
								} else {
									btnPaste.interactable = false;
									tvPaste.text = txtCannotPaste.get ("Paste");
								}
							}
						} else {
							Debug.LogError ("btnPaste, tvPaste null: " + this);
						}
					} else {
						Debug.LogError ("showDirectory null: " + this);
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

		private FileSystemBrowser fileSystemBrowser = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.showDirectory.allAddCallBack (this);
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
				if (data is ShowDirectory) {
					ShowDirectory showDirectory = data as ShowDirectory;
					// Parent
					{
						DataUtils.addParentCallBack (showDirectory, this, ref this.fileSystemBrowser);
					}
					dirty = true;
					return;
				}
				// Parent
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
					uiData.showDirectory.allRemoveCallBack (this);
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
				if (data is ShowDirectory) {
					ShowDirectory showDirectory = data as ShowDirectory;
					// Parent
					{
						DataUtils.removeParentCallBack (showDirectory, this, ref this.fileSystemBrowser);
					}
					return;
				}
				// Parent
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
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.showDirectory:
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
				if (wrapProperty.p is ShowDirectory) {
					switch ((ShowDirectory.Property)wrapProperty.n) {
					case ShowDirectory.Property.state:
						dirty = true;
						break;
					case ShowDirectory.Property.directory:
						dirty = true;
						break;
					case ShowDirectory.Property.directoryHistory:
						break;
					case ShowDirectory.Property.files:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
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
									dirty = true;
									break;
								case ActionNone.Property.selectFiles:
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnPaste()
		{
			if (this.data != null) {
				ShowDirectory showDirectory = this.data.showDirectory.v.data;
				if (showDirectory != null) {
					if (showDirectory.state.v != ShowDirectory.State.Fail) {
						// check dir
						DirectoryInfo dir = showDirectory.directory.v;
						if (dir != null) {
							if (dir.Exists) {
								// find action
								FileSystemBrowser fileSystemBrowser = showDirectory.findDataInParent<FileSystemBrowser>();
								if (fileSystemBrowser != null) {
									Action action = fileSystemBrowser.action.v;
									if (action != null) {
										switch (action.getType ()) {
										case Action.Type.None:
											{
												ActionNone actionNone = action as ActionNone;
												switch (actionNone.state.v) {
												case ActionNone.State.None:
													break;
												case ActionNone.State.Copy:
												case ActionNone.State.Cut:
													{
														ActionEdit actionEdit = new ActionEdit ();
														{
															actionEdit.uid = fileSystemBrowser.action.makeId ();
															actionEdit.action.v = (actionNone.state.v == ActionNone.State.Cut) ? ActionEdit.Action.Cut : ActionEdit.Action.Copy;
															// state: ko can
															actionEdit.files.vs.AddRange (actionNone.selectFiles.vs);
															actionEdit.destDir.v = dir;
														}
														fileSystemBrowser.action.v = actionEdit;
													}
													break;
												default:
													Debug.LogError ("unknown state: " + actionNone.state.v + "; " + this);
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
									} else {
										Debug.LogError ("action null: " + this);
									}
								} else {
									Debug.LogError ("fileSystemBrowser null: " + this);
								}
							} else {
								Debug.LogError ("dir not exist: " + this);
							}
						} else {
							Debug.LogError ("dir null: " + this);
						}
					} else {
						Debug.LogError ("load fail: " + this);
					}
				} else {
					Debug.LogError ("showDirectory null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}