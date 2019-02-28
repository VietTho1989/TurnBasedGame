using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class BtnCopyUI : UIBehavior<BtnCopyUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<FileSystemBrowser>> fileSystemBrowser;

			#region Constructor

			public enum Property
			{
				fileSystemBrowser
			}

			public UIData() : base()
			{
				this.fileSystemBrowser = new VP<ReferenceData<FileSystemBrowser>>(this, (byte)Property.fileSystemBrowser, new ReferenceData<FileSystemBrowser>(null));
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{

				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtCannotCopyNotSelect = new TxtLanguage ();
		public static readonly TxtLanguage txtCopy = new TxtLanguage ();
		public static readonly TxtLanguage txtAlreadySelectCopyCancel = new TxtLanguage ();
		public static readonly TxtLanguage txtCopying = new TxtLanguage();
		public static readonly TxtLanguage txtCancelCopy = new TxtLanguage ();

		public static readonly TxtLanguage txtCopyingFile = new TxtLanguage ();
		public static readonly TxtLanguage txtCancel = new TxtLanguage();

		public static readonly TxtLanguage txtCopySuccess = new TxtLanguage ();
		public static readonly TxtLanguage txtCopyFail = new TxtLanguage ();

		public static readonly TxtLanguage txtCopyFile = new TxtLanguage();
		public static readonly TxtLanguage txtFail = new TxtLanguage();

		public static readonly TxtLanguage txtCannotCopyOtherAction = new TxtLanguage ();

		static BtnCopyUI()
		{
			txtCannotCopyNotSelect.add (Language.Type.vi, "Sao Chép");
			txtCopy.add (Language.Type.vi, "Sao Chép");
			txtAlreadySelectCopyCancel.add (Language.Type.vi, "Huỷ chọn chép");
			txtCopying.add (Language.Type.vi, "Đang chép");
			txtCancelCopy.add (Language.Type.vi, "Huỷ chép?");

			txtCopyingFile.add (Language.Type.vi, "Đang chép");
			txtCancel.add (Language.Type.vi, "huỷ");

			txtCopySuccess.add (Language.Type.vi, "Chép thành công");
			txtCopyFail.add (Language.Type.vi, "Chép thất bại");

			txtCopyFile.add (Language.Type.vi, "Sao chép");
			txtFail.add (Language.Type.vi, "thất bại");

			txtCannotCopyOtherAction.add (Language.Type.vi, "Không thể chép");
		}

		#endregion

		public Button btnCopy;
		public Text tvCopy;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					FileSystemBrowser fileSystemBrowser = this.data.fileSystemBrowser.v.data;
					if (fileSystemBrowser != null) {
						if (btnCopy != null && tvCopy != null) {
							Action action = fileSystemBrowser.action.v;
							if (action != null) {
								switch (action.getType ()) {
								case Action.Type.None:
									{
										ActionNone actionNone = action as ActionNone;
										if (actionNone.selectFiles.vs.Count == 0) {
											btnCopy.interactable = false;
											tvCopy.text = txtCannotCopyNotSelect.get ("Copy");
										} else {
											switch (actionNone.state.v) {
											case ActionNone.State.None:
												{
													btnCopy.interactable = true;
													tvCopy.text = txtCopy.get("Copy");
												}
												break;
											case ActionNone.State.Cut:
												{
													btnCopy.interactable = true;
													tvCopy.text = txtCopy.get("Copy");
												}
												break;
											case ActionNone.State.Copy:
												{
													btnCopy.interactable = true;
													tvCopy.text = txtAlreadySelectCopyCancel.get ("Cancel copy");
												}
												break;
											default:
												Debug.LogError ("unknown state: " + actionNone.state.v + "; " + this);
												break;
											}
										}
									}
									break;
								case Action.Type.Edit:
									{
										ActionEdit actionEdit = action as ActionEdit;
										if (actionEdit.action.v == ActionEdit.Action.Copy) {
											ActionEdit.State state = actionEdit.state.v;
											if (state != null) {
												switch (state.getType ()) {
												case ActionEdit.State.Type.Start:
													{
														btnCopy.interactable = false;
														tvCopy.text = txtCopying.get ("Copying");
													}
													break;
												case ActionEdit.State.Type.Process:
													{
														ActionEditProcess actionEditProcess = state as ActionEditProcess;
														// set
														{
															btnCopy.interactable = true;
															// txt
															{
																FileSystemInfo file = null;
																{
																	if (actionEditProcess.files.vs.Count > 0) {
																		file = actionEditProcess.files.vs [0];
																	} else {
																		Debug.LogError ("Why don't have any file: " + this);
																	}
																}
																if (file != null) {
																	float percent = 0;
																	{
																		if (actionEdit.files.vs.Count > 0) {
																			percent = actionEditProcess.files.vs.Count / actionEdit.files.vs.Count;
																		} else {
																			Debug.LogError ("why actionEdit don't have any files: " + this);
																		}
																	}
																	tvCopy.text = txtCopyingFile.get ("Copying") + " " + file.Name + " (" + percent + ")," + txtCancel.get (" Cancel") + "?";
																} else {
																	tvCopy.text = txtCancelCopy.get ("Copying, Cancel?");
																}
															}
														}
													}
													break;
												case ActionEdit.State.Type.Success:
													{
														btnCopy.interactable = false;
														tvCopy.text = txtCopySuccess.get ("Copy success");
													}
													break;
												case ActionEdit.State.Type.Fail:
													{
														ActionEditFail actionEditFail = state as ActionEditFail;
														// Set
														{
															btnCopy.interactable = false;
															// txt
															{
																// find fail file
																FileSystemInfo failFile = actionEditFail.failFile.v;
																// Process
																if (failFile != null) {
																	tvCopy.text = txtCopyFile.get ("Copy") + " " + failFile.Name + " " + txtFail.get ("fail");
																} else {
																	Debug.LogError ("failFile null: " + this);
																	tvCopy.text = txtCopyFail.get ("Copy fail");
																}
															}
														}
													}
													break;
												default:
													Debug.LogError ("unknown type: " + state.getType () + "; " + this);
													break;
												}
											} else {
												Debug.LogError ("state null: " + this);
											}
										} else {
											btnCopy.interactable = false;
											tvCopy.text = txtCannotCopyOtherAction.get ("Can't copy");
										}
									}
									break;
								default:
									Debug.LogError ("unknown type: " + action.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("action null: " + this);
							}
						} else {
							Debug.LogError ("btnCopy, tvCopy null: " + this);
						}
					} else {
						Debug.LogError ("fileSystemBrowser null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.fileSystemBrowser.allAddCallBack (this);
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
				{
					if (data is Action) {
						Action action = data as Action;
						// Child
						{
							switch (action.getType ()) {
							case Action.Type.None:
								break;
							case Action.Type.Edit:
								{
									ActionEdit actionEdit = action as ActionEdit;
									actionEdit.state.allAddCallBack (this);
								}
								break;
							default:
								Debug.LogError ("unknown type: " + action.getType () + "; " + this);
								break;
							}
						}
						dirty = true;
						return;
					}
					// Child
					if (data is ActionEdit.State) {
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
					uiData.fileSystemBrowser.allRemoveCallBack (this);
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
				if (data is FileSystemBrowser) {
					FileSystemBrowser fileSystemBrowser = data as FileSystemBrowser;
					// Child
					{
						fileSystemBrowser.action.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is Action) {
						Action action = data as Action;
						// Child
						{
							switch (action.getType ()) {
							case Action.Type.None:
								break;
							case Action.Type.Edit:
								{
									ActionEdit actionEdit = action as ActionEdit;
									actionEdit.state.allRemoveCallBack (this);
								}
								break;
							default:
								Debug.LogError ("unknown type: " + action.getType () + "; " + this);
								break;
							}
						}
						return;
					}
					// Child
					if (data is ActionEdit.State) {
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
				case UIData.Property.fileSystemBrowser:
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
				{
					if (wrapProperty.p is Action) {
						Action action = wrapProperty.p as Action;
						// Child
						{
							switch (action.getType ()) {
							case Action.Type.None:
								{
									switch ((ActionNone.Property)wrapProperty.n) {
									case ActionNone.Property.state:
										dirty = true;
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
								{
									switch ((ActionEdit.Property)wrapProperty.n) {
									case ActionEdit.Property.action:
										dirty = true;
										break;
									case ActionEdit.Property.state:
										{
											ValueChangeUtils.replaceCallBack (this, syncs);
											dirty = true;
										}
										break;
									case ActionEdit.Property.files:
										break;
									case ActionEdit.Property.destDir:
										break;
									default:
										Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
										break;
									}
								}
								break;
							default:
								Debug.LogError ("unknown type: " + action.getType () + "; " + this);
								break;
							}
						}
						return;
					}
					// Child
					if (wrapProperty.p is ActionEdit.State) {
						ActionEdit.State state = wrapProperty.p as ActionEdit.State;
						switch (state.getType ()) {
						case ActionEdit.State.Type.Start:
							{
								switch ((ActionEditStart.Property)wrapProperty.n) {
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
							}
							break;
						case ActionEdit.State.Type.Process:
							{
								switch ((ActionEditProcess.Property)wrapProperty.n) {
								case ActionEditProcess.Property.state:
									dirty = true;
									break;
								case ActionEditProcess.Property.files:
									dirty = true;
									break;
								case ActionEditProcess.Property.successFiles:
									dirty = true;
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
							}
							break;
						case ActionEdit.State.Type.Success:
							{
								switch ((ActionEditSuccess.Property)wrapProperty.n) {
								case ActionEditSuccess.Property.time:
									dirty = true;
									break;
								case ActionEditSuccess.Property.duration:
									dirty = true;
									break;
								case ActionEditSuccess.Property.successFiles:
									dirty = true;
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
							}
							break;
						case ActionEdit.State.Type.Fail:
							{
								switch ((ActionEditFail.Property)wrapProperty.n) {
								case ActionEditFail.Property.failFile:
									dirty = true;
									break;
								case ActionEditFail.Property.successFiles:
									dirty = true;
									break;
								case ActionEditFail.Property.time:
									dirty = true;
									break;
								case ActionEditFail.Property.duration:
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
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnCopy()
		{
			if (this.data != null) {
				FileSystemBrowser fileSystemBrowser = this.data.fileSystemBrowser.v.data;
				if (fileSystemBrowser != null) {
					Action action = fileSystemBrowser.action.v;
					if (action != null) {
						switch (action.getType ()) {
						case Action.Type.None:
							{
								ActionNone actionNone = action as ActionNone;
								if (actionNone.selectFiles.vs.Count == 0) {
									// Don't select any file
								} else {
									switch (actionNone.state.v) {
									case ActionNone.State.None:
										{
											actionNone.state.v = ActionNone.State.Copy;
										}
										break;
									case ActionNone.State.Cut:
										{
											actionNone.state.v = ActionNone.State.Copy;
										}
										break;
									case ActionNone.State.Copy:
										{
											actionNone.state.v = ActionNone.State.None;
										}
										break;
									default:
										Debug.LogError ("unknown state: " + actionNone.state.v + "; " + this);
										break;
									}
								}
							}
							break;
						case Action.Type.Edit:
							{
								ActionEdit actionEdit = action as ActionEdit;
								if (actionEdit.action.v == ActionEdit.Action.Copy) {
									ActionEdit.State state = actionEdit.state.v;
									if (state != null) {
										switch (state.getType ()) {
										case ActionEdit.State.Type.Start:
											{

											}
											break;
										case ActionEdit.State.Type.Process:
											{
												ActionEditProcess actionEditProcess = state as ActionEditProcess;
												// cancel
												{
													ActionEditProcessUpdate actionEditProcessUpdate = actionEditProcess.findCallBack<ActionEditProcessUpdate> ();
													if (actionEditProcessUpdate != null) {
														actionEditProcessUpdate.stop = true;
													} else {
														Debug.LogError ("actionEditProcessUpdate null");
													}
												}
											}
											break;
										case ActionEdit.State.Type.Success:
											{
												
											}
											break;
										case ActionEdit.State.Type.Fail:
											{
												
											}
											break;
										default:
											Debug.LogError ("unknown type: " + state.getType () + "; " + this);
											break;
										}
									} else {
										Debug.LogError ("staate null: " + this);
									}
								} else {
									// other action
								}
							}
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
				Debug.LogError ("data null: " + this);
			}
		}

	}
}