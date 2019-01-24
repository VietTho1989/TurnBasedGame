using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace FileSystem
{
	public class ActionEditProcessUpdate : UpdateBehavior<ActionEditProcess>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ActionEdit actionEdit = this.data.findDataInParent<ActionEdit> ();
					if (actionEdit != null) {
						switch (this.data.state.v) {
						case ActionEditProcess.State.Process:
							{
								startRoutine (ref this.processRoutine, TaskProcess ());
							}
							break;
						case ActionEditProcess.State.Success:
							{
								destroyRoutine (this.processRoutine);
								// refresh
								{
									FileSystemBrowser fileSystemBrowser = this.data.findDataInParent<FileSystemBrowser> ();
									if (fileSystemBrowser != null) {
										fileSystemBrowser.refresh ();
									} else {
										Debug.LogError ("fileSystemBrowser null: " + this);
									}
								}
								// change state
								{
									ActionEditSuccess actionEditSuccess = new ActionEditSuccess ();
									{
										actionEditSuccess.uid = actionEdit.state.makeId ();
										actionEditSuccess.successFiles.vs.AddRange (this.data.successFiles.vs);
									}
									actionEdit.state.v = actionEditSuccess;
								}
							}
							break;
						case ActionEditProcess.State.Fail:
							{
								destroyRoutine (this.processRoutine);
								// refresh
								{
									FileSystemBrowser fileSystemBrowser = this.data.findDataInParent<FileSystemBrowser> ();
									if (fileSystemBrowser != null) {
										fileSystemBrowser.refresh ();
									} else {
										Debug.LogError ("fileSystemBrowser null: " + this);
									}
								}
								// change state
								{
									ActionEditFail actionEditFail = new ActionEditFail ();
									{
										actionEditFail.uid = actionEdit.state.makeId ();
										// failFile
										{
											FileSystemInfo failFile = null;
											{
												if (this.data.files.vs.Count > 0) {
													failFile = this.data.files.vs [0];
												} else {
													Debug.LogError ("why don't have any file: " + this);
												}
											}
											actionEditFail.failFile.v = failFile;
										}
										actionEditFail.successFiles.vs.AddRange (this.data.successFiles.vs);
									}
									actionEdit.state.v = actionEditFail;
								}
							}
							break;
						default:
							Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("actionEdit null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		public class Work 
		{

			public FileSystemInfo file = null;

			public DirectoryInfo destDir = null;

			public ActionEdit.Action action = ActionEdit.Action.Delete;

			#region State

			public enum State
			{
				None,
				Success,
				Fail
			}

			public State state = State.None;

			#endregion

			public void DoWork()
			{
				State result = State.Fail;
				{
					if (file != null && destDir != null && destDir.Exists) {
						// action
						try {
							switch (action) {
							case ActionEdit.Action.Copy:
								{
									if (file is FileInfo) {
										string newPath = Path.Combine (destDir.FullName, file.Name);
										File.Copy (file.FullName, newPath);
									} else {
										// TODO Can hoan thien
									}
								}
								break;
							case ActionEdit.Action.Cut:
								{
									string newPath = Path.Combine (destDir.FullName, file.Name);
									if (file is FileInfo) {
										File.Move (file.FullName, newPath);
									} else if (file is DirectoryInfo) {
										Directory.Move (file.FullName, newPath);
									}
								}
								break;
							case ActionEdit.Action.Delete:
								{
									Debug.LogError ("delete file: " + file.FullName);
									if (file is DirectoryInfo) {
										DirectoryInfo directoryInfo = file as DirectoryInfo;
										Directory.Delete (directoryInfo.FullName);
									} else if (file is FileInfo) {
										FileInfo fileInfo = file as FileInfo;
										File.Delete (fileInfo.FullName);
									}
								}
								break;
							default:
								Debug.LogError ("unknown action: " + action);
								break;
							}
							result = State.Success;
						} catch (System.Exception e) {
							Debug.LogError ("FileExcept Error: " + e);
						}
					} else {
						Debug.LogError ("destDir nul");
					}
				}
				this.state = result;
			}
		}

		#region Task find hint

		public bool stop = false;

		private Routine processRoutine;

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (processRoutine);
			}
			return ret;
		}

		public IEnumerator TaskProcess()
		{
			if (this.data != null) {
				while (!stop && this.data.state.v == ActionEditProcess.State.Process) {
					if (this.data.files.vs.Count == 0) {
						this.data.state.v = ActionEditProcess.State.Success;
						break;
					} else {
						FileSystemInfo file = this.data.files.vs [0];
						{
							if (file != null && file.Exists) {
								ActionEdit actionEdit = this.data.findDataInParent<ActionEdit> ();
								if (actionEdit != null) {
									DirectoryInfo destDir = actionEdit.destDir.v;
									if (destDir != null && destDir.Exists) {
										// make work
										Work work = new Work();
										{
											work.file = file;
											work.destDir = destDir;
											work.action = actionEdit.action.v;
											work.state = Work.State.None;
										}
										// start thread
										{
											ThreadStart threadDelegate = new ThreadStart (work.DoWork);
											Thread newThread = new Thread (threadDelegate, Global.ThreadSize);
											newThread.Start ();
										}
										// Wait
										{
											while (work.state == Work.State.None) {
												yield return new Wait (0.1f);
											}
										}
										// Process
										{
											switch (work.state) {
											case Work.State.Success:
												{
													this.data.files.remove (file);
													// successFiles
													{
														switch (actionEdit.action.v) {
														case ActionEdit.Action.Cut:
														case ActionEdit.Action.Copy:
															{
																if (file is FileInfo) {
																	this.data.successFiles.add (new FileInfo (Path.Combine (destDir.FullName, file.Name)));
																} else if (file is DirectoryInfo) {
																	this.data.successFiles.add (new DirectoryInfo (Path.Combine (destDir.FullName, file.Name)));
																}
															}
															break;
														case ActionEdit.Action.Delete:
															break;
														default:
															Debug.LogError ("unknown action: " + actionEdit.action.v + "; " + this);
															break;
														}
													}
												}
												break;
											case Work.State.Fail:
												{
													this.data.state.v = ActionEditProcess.State.Fail;
												}
												break;
											default:
												this.data.state.v = ActionEditProcess.State.Fail;
												Debug.LogError ("unknown state: " + work.state + "; " + this);
												break;
											}
										}
									} else {
										Debug.LogError ("destDir nul");
										this.data.state.v = ActionEditProcess.State.Fail;
									}
								} else {
									Debug.LogError ("actionEdit null");
									this.data.state.v = ActionEditProcess.State.Fail;
									break;
								}
							} else {
								Debug.LogError ("file null");
								this.data.state.v = ActionEditProcess.State.Fail;
							}
						}
					}
				}
				if (this.data.state.v == ActionEditProcess.State.Process) {
					Debug.LogError ("why still processing");
					this.data.state.v = ActionEditProcess.State.Fail;
				}
			} else {
				Debug.LogError ("actionEditProcess null");
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is ActionEditProcess) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ActionEditProcess) {
				ActionEditProcess actionEditProcess = data as ActionEditProcess;
				// Child
				{

				}
				this.setDataNull (actionEditProcess);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ActionEditProcess) {
				switch ((ActionEditProcess.Property)wrapProperty.n) {
				case ActionEditProcess.Property.state:
					dirty = true;
					break;
				case ActionEditProcess.Property.files:
					break;
				case ActionEditProcess.Property.successFiles:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}