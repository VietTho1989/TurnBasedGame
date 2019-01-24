using UnityEngine;
using System.IO;
using System.Collections;

namespace FileSystem
{
	public class FileSystemBrowser : Data
	{

		public const string SaveFolder = "SaveGame";

		public const string DatabaseFolder = "Database";

		#region select file

		public VP<Action> action;

		public void selectFile(FileSystemInfo file, bool isShift, bool allowRemove)
		{
			if (file != null) {
				if (this.action.v is ActionNone) {
					ActionNone actionNone = this.action.v as ActionNone;
					if (actionNone.state.v == ActionNone.State.None) {
						// find already contain file
						FileSystemInfo alreadyContainFile = null;
						{
							foreach (FileSystemInfo check in actionNone.selectFiles.vs) {
								if (check == file || check.FullName == file.FullName) {
									alreadyContainFile = check;
									break;
								}
							}
						}
						// process
						{
							if (!isShift) {
								if (alreadyContainFile == null) {
									actionNone.selectFiles.clear ();
									actionNone.selectFiles.add (file);
								} else {
									if (allowRemove) {
										actionNone.selectFiles.clear ();
									}
								}
							} else {
								if (alreadyContainFile == null) {
									actionNone.selectFiles.add (file);
								} else {
									if (allowRemove) {
										actionNone.selectFiles.remove (alreadyContainFile);
									}
								}
							}
						}
					}
				}
			} else {
				Debug.LogError ("file null: " + this);
			}
		}

		#endregion

		public VP<Show> show;

		public void refresh()
		{
			Show show = this.show.v;
			if (show != null) {
				switch (show.getType ()) {
				case Show.Type.Single:
					{
						SingleShow singleShow = show as SingleShow;
						ShowDirectory showDirectory = singleShow.showDirectory.v;
						if (showDirectory != null) {
							showDirectory.state.v = ShowDirectory.State.Load;
						} else {
							Debug.LogError ("showDirectory null: " + this);
						}
					}
					break;
				default:
					Debug.LogError ("unknown type: " + show.getType () + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("show null: " + this);
			}
		}

		public DirectoryInfo getCurrentDirectory()
		{
			DirectoryInfo ret = null;
			{
				Show show = this.show.v;
				if (show != null) {
					switch (show.getType ()) {
					case Show.Type.Single:
						{
							SingleShow singleShow = show as SingleShow;
							ShowDirectory showDirectory = singleShow.showDirectory.v;
							if (showDirectory != null) {
								ret = showDirectory.directory.v;
							} else {
								Debug.LogError ("showDirectory null: " + this);
							}
						}
						break;
					default:
						Debug.LogError ("unknown type: " + show.getType () + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("show null: " + this);
				}
			}
			return ret;
		}

		public void changeCurrentDirectory(DirectoryInfo directoryInfo)
		{
			Show show = this.show.v;
			if (show != null) {
				switch (show.getType ()) {
				case Show.Type.Single:
					{
						SingleShow singleShow = show as SingleShow;
						ShowDirectory showDirectory = singleShow.showDirectory.v;
						if (showDirectory != null) {
							showDirectory.directory.v = directoryInfo;
						} else {
							Debug.LogError ("showDirectory null: " + this);
						}
					}
					break;
				default:
					Debug.LogError ("unknown type: " + show.getType () + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("show null: " + this);
			}
		}

		#region Constructor

		public enum Property
		{
			action,
			show
		}

		public FileSystemBrowser() : base()
		{
			this.action = new VP<Action> (this, (byte)Property.action, new ActionNone ());
			this.show = new VP<Show> (this, (byte)Property.show, new SingleShow ());
		}

		#endregion

	}
}