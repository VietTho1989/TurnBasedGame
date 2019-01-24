using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace FileSystem
{
	public class FileAdapter : SRIA<FileAdapter.UIData, FileHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{
			
			public VP<ReferenceData<ShowDirectory>> showDirectory;

			public VP<SortDataUI.UIData> sortData;

			public LP<FileHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				showDirectory,
				sortData,
				holders
			}

			public UIData() : base()
			{
				this.showDirectory = new VP<ReferenceData<ShowDirectory>>(this, (byte)Property.showDirectory, new ReferenceData<ShowDirectory>(null));
				// sortData
				{
					this.sortData = new VP<SortDataUI.UIData>(this, (byte)Property.sortData, new SortDataUI.UIData());
					{
						EditData<SortData> editSortData = this.sortData.v.editSortData.v;
						if(editSortData!=null){
							editSortData.origin.v = new ReferenceData<SortData>(new SortData());
							editSortData.canEdit.v = true;
							editSortData.editType.v = EditType.Immediate;
						}else{
							Debug.LogError("editSortData null: "+this);
						}
					}
				}
				this.holders = new LP<FileHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<FileSystemInfo> files = new List<FileSystemInfo>();

			public void reset()
			{
				this.files.Clear();
			}

		}

		#endregion

		#region Adapter

		public FileHolder holderPrefab;

		protected override FileHolder.UIData CreateViewsHolder (int itemIndex)
		{
			FileHolder.UIData uiData = new FileHolder.UIData();
			{
				// add
				{
					uiData.uid = this.data.holders.makeId ();
					this.data.holders.add (uiData);
				}
				// MakeUI
				if (holderPrefab != null) {
					uiData.Init (holderPrefab.gameObject, itemIndex);
				} else {
					Debug.LogError ("holderPrefab null: " + this);
				}
			}
			return uiData;
		}

		protected override void UpdateViewsHolder (FileHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoFiles;
		public static readonly TxtLanguage txtNoFiles = new TxtLanguage();

		static FileAdapter()
		{
			txtNoFiles.add (Language.Type.vi, "Không có file nào cả");
		}

		#endregion

		public GameObject noFiles;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						ShowDirectory showDirectory = this.data.showDirectory.v.data;
						if (showDirectory != null) {
							List<FileSystemInfo> files = new List<FileSystemInfo> ();
							// filter
							{
								files.AddRange (showDirectory.files.vs);
								// find sort
								SortData sortData = null;
								{
									SortDataUI.UIData sortDataUIData = this.data.sortData.v;
									if (sortDataUIData != null) {
										EditData<SortData> editSortData = sortDataUIData.editSortData.v;
										if (editSortData != null) {
											sortData = editSortData.show.v.data;
										} else {
											Debug.LogError ("editSortData null: " + this);
										}
									} else {
										Debug.LogError ("sortDataUIData null: " + this);
									}
								}
								// Process
								if (sortData != null) {
									// filter string
									{
										if (!string.IsNullOrEmpty (sortData.filter.v)) {
											for (int i = files.Count - 1; i >= 0; i--) {
												FileSystemInfo file = files [i];
												if (!file.Name.Contains (sortData.filter.v)) {
													files.RemoveAt (i);
												}
											}
										}
									}
									// sort
									{
										switch (sortData.sortType.v) {
										case SortData.SortType.None:
											break;
										case SortData.SortType.Name:
											{
												files.Sort (delegate(FileSystemInfo p1, FileSystemInfo p2) {
													if(p1==null){
														return 1;
													}
													if(p2==null){
														return -1;
													}
													return  p1.Name.CompareTo (p2.Name);
												});
											}
											break;
										case SortData.SortType.Kind:
											{
												files.Sort (delegate(FileSystemInfo p1, FileSystemInfo p2) {
													if(p1==null){
														return 1;
													}
													if(p2==null){
														return -1;
													}
													return  p1.Extension.CompareTo (p2.Extension);
												});
											}
											break;
										case SortData.SortType.Date:
											{
												files.Sort (delegate(FileSystemInfo p1, FileSystemInfo p2) {
													if(p1==null){
														return 1;
													}
													if(p2==null){
														return -1;
													}
													return  p1.CreationTime.CompareTo (p2.CreationTime);
												});
											}
											break;
										default:
											Debug.LogError ("Unknown type: " + sortData.sortType.v + "; " + this);
											break;
										}
									}
								} else {
									Debug.LogError ("sortData null: " + this);
								}
							}
							// Make list
							{
								int min = Mathf.Min (files.Count, _Params.files.Count);
								// Update
								{
									for (int i = 0; i < min; i++) {
										if (files[i] != _Params.files [i]) {
											// change param
											_Params.files [i] = files [i];
											// Update holder
											foreach (FileHolder.UIData holder in this.data.holders.vs) {
												if (holder.ItemIndex == i) {
													holder.file.v = files [i];
													break;
												}
											}
										}
									}
								}
								// Add or Remove
								{
									if (files.Count > min) {
										// Add
										int insertCount = files.Count - min;
										List<FileSystemInfo> addItems = files.GetRange (min, insertCount);
										_Params.files.AddRange (addItems);
										InsertItems (min, insertCount, false, false);
									} else {
										// Remove
										int deleteCount = _Params.files.Count - min;
										if (deleteCount > 0) {
											RemoveItems (min, deleteCount, false, false);
											_Params.files.RemoveRange (min, deleteCount);
										}
									}
								}
							}
							// NoFiles
							{
								if (noFiles != null) {
									bool haveAny = false;
									{
										foreach (FileHolder.UIData holder in this.data.holders.vs) {
											if (holder.file.v != null) {
												FileHolder holderUI = holder.findCallBack<FileHolder> ();
												if (holderUI != null) {
													if (holderUI.gameObject.activeSelf) {
														haveAny = true;
														break;
													}
												} else {
													Debug.LogError ("holderUI null: " + this);
												}
											}
										}
									}
									noFiles.SetActive (!haveAny);
								} else {
									Debug.LogError ("noFiles null: " + this);
								}
							}
						} else {
							Debug.LogError ("server null: " + this);
						}
						// txt
						{
							if (tvNoFiles != null) {
								tvNoFiles.text = txtNoFiles.get ("Don't have any files");
							} else {
								Debug.LogError ("tvNoFiles null: " + this);
							}
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					Debug.LogError ("not initalized: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public SortDataUI sortDataPrefab;
		public Transform sortDataContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.showDirectory.allAddCallBack (this);
					uiData.sortData.allAddCallBack (this);
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
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					dirty = true;
					return;
				}
				// SortData
				{
					if (data is SortDataUI.UIData) {
						SortDataUI.UIData sortDataUIData = data as SortDataUI.UIData;
						// UI
						{
							UIUtils.Instantiate (sortDataUIData, sortDataPrefab, sortDataContainer);
						}
						// Child
						{
							sortDataUIData.editSortData.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is EditData<SortData>) {
							EditData<SortData> editSortData = data as EditData<SortData>;
							// Child
							{
								editSortData.show.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						if (data is SortData) {
							dirty = true;
							return;
						}
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
					uiData.sortData.allRemoveCallBack (this);
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
					return;
				}
				// SortData
				{
					if (data is SortDataUI.UIData) {
						SortDataUI.UIData sortDataUIData = data as SortDataUI.UIData;
						// UI
						{
							sortDataUIData.removeCallBackAndDestroy (typeof(SortDataUI));
						}
						// Child
						{
							sortDataUIData.editSortData.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is EditData<SortData>) {
							EditData<SortData> editSortData = data as EditData<SortData>;
							// Child
							{
								editSortData.show.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						if (data is SortData) {
							return;
						}
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
				case UIData.Property.sortData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.holders:
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
						break;
					case ShowDirectory.Property.directory:
						break;
					case ShowDirectory.Property.directoryHistory:
						break;
					case ShowDirectory.Property.files:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// SortData
				{
					if (wrapProperty.p is SortDataUI.UIData) {
						switch ((SortDataUI.UIData.Property)wrapProperty.n) {
						case SortDataUI.UIData.Property.editSortData:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case SortDataUI.UIData.Property.filter:
							break;
						case SortDataUI.UIData.Property.sortType:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					{
						if (wrapProperty.p is EditData<SortData>) {
							switch ((EditData<SortData>.Property)wrapProperty.n) {
							case EditData<SortData>.Property.origin:
								break;
							case EditData<SortData>.Property.show:
								{
									ValueChangeUtils.replaceCallBack(this, syncs);
									dirty = true;
								}
								break;
							case EditData<SortData>.Property.compare:
								break;
							case EditData<SortData>.Property.compareOtherType:
								break;
							case EditData<SortData>.Property.canEdit:
								break;
							case EditData<SortData>.Property.editType:
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// Child
						if (wrapProperty.p is SortData) {
							switch ((SortData.Property)wrapProperty.n) {
							case SortData.Property.filter:
								dirty = true;
								break;
							case SortData.Property.sortType:
								dirty = true;
								break;
							default:
								Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}