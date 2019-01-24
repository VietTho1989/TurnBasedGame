using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowSettingFooterUI : UIBehavior<ShowSettingFooterUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		#region Constructor

		public enum Property
		{

		}

		public UIData() : base()
		{

		}

		#endregion

	}

	#endregion

	#region drEditType

	public Dropdown drEditType;

	public override void Awake ()
	{
		base.Awake ();
		if (drEditType != null) {
			drEditType.onValueChanged.AddListener (delegate(int newValue) {
				if (drEditType.gameObject.activeInHierarchy) {
					if (this.data != null) {
						ShowSettingUI.UIData showSettingUIData = this.data.findDataInParent<ShowSettingUI.UIData>();
						if(showSettingUIData!=null){
							SettingUI.UIData settingUIData = showSettingUIData.settingUIData.v;
							if(settingUIData!=null){
								EditData<Setting> editSetting = settingUIData.editSetting.v;
								if(editSetting!=null){
									editSetting.editType.v = (Data.EditType)newValue;
								}else{
									Debug.LogError("editSetting null: "+this);
								}
							}else{
								Debug.LogError("settingUIData null: "+this);
							}
						}else{
							Debug.LogError("showSettingUIData null: "+this);
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					Debug.LogError ("drEditType not active: " + this);
				}
			});
		} else {
			Debug.LogError ("drValue null: " + this);
		}
	}

	#endregion

	#region Refresh

	public Button btnApply;
	public Text tvApply;

	public Button btnReset;
	public Text tvReset;

	public static readonly TxtLanguage txtApply = new TxtLanguage();
	public static readonly TxtLanguage txtCannotApply = new TxtLanguage ();
	public static readonly TxtLanguage txtReset = new TxtLanguage();
	public static readonly TxtLanguage txtCannotReset = new TxtLanguage ();
	public static readonly TxtLanguage txtImmediate = new TxtLanguage ();
	public static readonly TxtLanguage txtLater = new TxtLanguage();

	static ShowSettingFooterUI()
	{
		txtApply.add (Language.Type.vi, "Áp Dụng");
		txtCannotApply.add (Language.Type.vi, "Không thể áp dụng");
		txtReset.add (Language.Type.vi, "Đặt lại");
		txtCannotReset.add (Language.Type.vi, "Không cần đặt lại");
		txtImmediate.add (Language.Type.vi, "Ngay Lập Tức");
		txtLater.add (Language.Type.vi, "Sau này");
	}

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ShowSettingUI.UIData showSettingUIData = this.data.findDataInParent<ShowSettingUI.UIData> ();
				if (showSettingUIData != null) {
					SettingUI.UIData settingUIData = showSettingUIData.settingUIData.v;
					if (settingUIData != null) {
						EditData<Setting> editSetting = settingUIData.editSetting.v;
						if (editSetting != null) {
							// btn
							{
								if (btnApply != null && tvApply != null && btnReset != null && tvReset != null) {
									switch (editSetting.editType.v) {
									case EditData<Setting>.EditType.Immediate:
										{
											editSetting.compare.v = new ReferenceData<Setting> (null);
											btnApply.gameObject.SetActive (false);
											btnReset.gameObject.SetActive (false);
										}
										break;
									case EditData<Setting>.EditType.Later:
										{
											// compare
											{
												editSetting.compare.v = new ReferenceData<Setting> (editSetting.origin.v.data);
												/*editSetting.origin.allAddCallBack (this);
												editSetting.show.allAddCallBack (this);
												editSetting.compare.allAddCallBack (this);*/
											}
											btnApply.gameObject.SetActive (true);
											btnReset.gameObject.SetActive (true);
											// check is different
											bool isDifferent = false;
											{
												Setting origin = editSetting.origin.v.data;
												Setting show = editSetting.show.v.data; 
												if (origin != null && show != null) {
													if (origin != show) {
														if (DataUtils.IsDifferent (origin, show)) {
															isDifferent = true;
														}
														// Debug.LogError ("find different: " + isDifferent);
													} else {
														Debug.LogError ("the same: " + this);
													}
												} else {
													Debug.LogError ("origin, show null: " + this);
												}
											}
											// process
											if (isDifferent) {
												// apply
												{
													btnApply.enabled = true;
													tvApply.text = txtApply.get ("Apply");
												}
												// reset
												{
													btnReset.enabled = true;
													tvReset.text = txtReset.get ("Reset");
												}
											} else {
												// apply
												{
													btnApply.enabled = false;
													tvApply.text = txtCannotApply.get ("cannot apply");
												}
												// reset
												{
													btnReset.enabled = false;
													tvReset.text = txtCannotReset.get ("Don't need reset");
												}
											}
										}
										break;
									default:
										Debug.LogError ("unknown editType: " + editSetting.editType.v + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("btn null: " + this);
								}
							}
							// drEditType
							{
								if (drEditType != null) {
									// options
									{
										string[] options = new string[]{ txtImmediate.get ("Immediately"), txtLater.get ("Later") };
										// remove 
										{
											if (drEditType.options.Count > options.Length) {
												drEditType.options.RemoveRange (options.Length, drEditType.options.Count - options.Length);
											}
										}
										for (int i = 0; i < options.Length; i++) {
											if (i < drEditType.options.Count) {
												// Update
												drEditType.options [i].text = options [i];
											} else {
												// Add new
												Dropdown.OptionData optionData = new Dropdown.OptionData ();
												{
													optionData.text = options [i];
												}
												drEditType.options.Add (optionData);
											}
										}
									}
									// set value
									{
										drEditType.value = (int)editSetting.editType.v;
										drEditType.RefreshShownValue ();
									}
								} else {
									Debug.LogError ("drEditType null: " + this);
								}
							}
						} else {
							Debug.LogError ("editSetting null: " + this);
						}
					} else {
						Debug.LogError ("settingUIData null: " + this);
					}
				} else {
					Debug.LogError ("showSettingUIData null: " + this);
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

	private ShowSettingUI.UIData showSettingUIData = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Parent
			{
				DataUtils.addParentCallBack (uiData, this, ref this.showSettingUIData);
			}
			dirty = true;
			return;
		}
		// Parent
		{
			if (data is ShowSettingUI.UIData) {
				ShowSettingUI.UIData showSettingUIData = data as ShowSettingUI.UIData;
				// Child
				{
					showSettingUIData.settingUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is SettingUI.UIData) {
					SettingUI.UIData settingUIData = data as SettingUI.UIData;
					// Child
					{
						settingUIData.editSetting.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is EditData<Setting>) {
						EditData<Setting> editSetting = data as EditData<Setting>;
						// Child
						{
							editSetting.show.allAddCallBack (this);
							editSetting.compare.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					{
						if (data is Setting) {
							Setting setting = data as Setting;
							// Child
							{
								setting.addCallBackAllChildren (this);
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
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Parent
			{
				DataUtils.removeParentCallBack (uiData, this, ref this.showSettingUIData);
			}
			this.setDataNull (uiData);
			return;
		}
		// Parent
		{
			if (data is ShowSettingUI.UIData) {
				ShowSettingUI.UIData showSettingUIData = data as ShowSettingUI.UIData;
				// Child
				{
					showSettingUIData.settingUIData.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is SettingUI.UIData) {
					SettingUI.UIData settingUIData = data as SettingUI.UIData;
					// Child
					{
						settingUIData.editSetting.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is EditData<Setting>) {
						EditData<Setting> editSetting = data as EditData<Setting>;
						// Child
						{
							editSetting.show.allRemoveCallBack (this);
							editSetting.compare.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is Setting) {
							Setting setting = data as Setting;
							// Child
							{
								setting.removeCallBackAllChildren (this);
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
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Parent
		{
			if (wrapProperty.p is ShowSettingUI.UIData) {
				switch ((ShowSettingUI.UIData.Property)wrapProperty.n) {
				case ShowSettingUI.UIData.Property.settingUIData:
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
			// Child
			{
				if (wrapProperty.p is SettingUI.UIData) {
					switch ((SettingUI.UIData.Property)wrapProperty.n) {
					case SettingUI.UIData.Property.editSetting:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case SettingUI.UIData.Property.showLastMove:
						break;
					case SettingUI.UIData.Property.viewUrlImage:
						break;
					case SettingUI.UIData.Property.animationSetting:
						break;
					case SettingUI.UIData.Property.maxThinkCount:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is EditData<Setting>) {
						switch ((EditData<Setting>.Property)wrapProperty.n) {
						case EditData<Setting>.Property.origin:
							dirty = true;
							break;
						case EditData<Setting>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<Setting>.Property.compare:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<Setting>.Property.compareOtherType:
							dirty = true;
							break;
						case EditData<Setting>.Property.canEdit:
							dirty = true;
							break;
						case EditData<Setting>.Property.editType:
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
						if (wrapProperty.p is Setting) {
							if (Generic.IsAddCallBackInterface<T> ()) {
								ValueChangeUtils.replaceCallBack (this, syncs);
							}
							dirty = true;
							return;
						}
						// Child
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
		}
		// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnApply()
	{
		if (this.data != null) {
			// find editSetting
			EditData<Setting> editSetting = null;
			{
				ShowSettingUI.UIData showSettingUIData = this.data.findDataInParent<ShowSettingUI.UIData> ();
				if (showSettingUIData != null) {
					SettingUI.UIData settingUIData = showSettingUIData.settingUIData.v;
					if (settingUIData != null) {
						editSetting = settingUIData.editSetting.v;
					} else {
						Debug.LogError ("settingUIData null: " + this);
					}
				} else {
					Debug.LogError ("showSettingUIData null: " + this);
				}
			}
			// Process
			if (editSetting != null) {
				Setting origin = editSetting.origin.v.data;
				Setting show = editSetting.show.v.data;
				if (origin != null && show != null) {
					if (origin != show) {
						DataUtils.copyData (origin, show);
					} else {
						Debug.LogError ("the same: " + this);
					}
				} else {
					Debug.LogError ("origin, show null: " + this);
				}
			} else {
				Debug.LogError ("editSetting null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public void onClickBtnReset ()
	{
		if (this.data != null) {
			// find editSetting
			EditData<Setting> editSetting = null;
			{
				ShowSettingUI.UIData showSettingUIData = this.data.findDataInParent<ShowSettingUI.UIData> ();
				if (showSettingUIData != null) {
					SettingUI.UIData settingUIData = showSettingUIData.settingUIData.v;
					if (settingUIData != null) {
						editSetting = settingUIData.editSetting.v;
					} else {
						Debug.LogError ("settingUIData null: " + this);
					}
				} else {
					Debug.LogError ("showSettingUIData null: " + this);
				}
			}
			// Process
			if (editSetting != null) {
				Setting origin = editSetting.origin.v.data;
				Setting show = editSetting.show.v.data;
				if (origin != null && show != null) {
					if (origin != show) {
						editSetting.show.v = new ReferenceData<Setting> (null);
					} else {
						Debug.LogError ("the same: " + this);
					}
				} else {
					Debug.LogError ("origin, show null: " + this);
				}
			} else {
				Debug.LogError ("editSetting null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}