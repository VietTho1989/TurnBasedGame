using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using FileSystem;

public class SaveUI : UIBehavior<SaveUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Data>> needSaveData;

		public VP<FileSystemBrowserUI.UIData> fileSystemBrowser;

		public VP<BtnSaveDataUI.UIData> btnSaveData;

		#region Constructor

		public enum Property
		{
			needSaveData,
			fileSystemBrowser,
			btnSaveData
		}

		public UIData() : base()
		{
			this.needSaveData = new VP<ReferenceData<Data>>(this, (byte)Property.needSaveData, new ReferenceData<Data>(null));
			{
				this.fileSystemBrowser = new VP<FileSystemBrowserUI.UIData>(this, (byte)Property.fileSystemBrowser, new FileSystemBrowserUI.UIData());
				this.fileSystemBrowser.v.fileSystemBrowser.v = new ReferenceData<FileSystemBrowser>(new FileSystemBrowser());
			}
			this.btnSaveData = new VP<BtnSaveDataUI.UIData>(this, (byte)Property.btnSaveData, new BtnSaveDataUI.UIData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// btnSaveData
				if (!isProcess) {
					BtnSaveDataUI.UIData btnSaveData = this.btnSaveData.v;
					if (btnSaveData != null) {
						isProcess = btnSaveData.processEvent (e);
					} else {
						Debug.LogError ("btnSaveData null: " + this);
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
						SaveUI saveUI = this.findCallBack<SaveUI> ();
						if (saveUI != null) {
							saveUI.onClickBtnBack ();
						} else {
							Debug.LogError ("saveUI null: " + this);
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

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage ();

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage ();

	public Text tvPlaceHolder;
	public static readonly TxtLanguage txtPlaceHolder = new TxtLanguage ();

	static SaveUI()
	{
		txtBack.add (Language.Type.vi, "Quay Lại");
		txtTitle.add (Language.Type.vi, "Lưu Trữ Dữ Liệu");
		txtPlaceHolder.add (Language.Type.vi, "Đặt tên file");
	}

	#endregion

	public InputField edtName;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Data needSaveData = this.data.needSaveData.v.data;
				if (needSaveData != null) {

				} else {
					Debug.LogError ("needSaveData null: " + this);
				}
				// txt
				{
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
					}
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Save Data");
					} else {
						Debug.LogError ("lbTitle null: " + this);
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

	public BtnSaveDataUI btnSaveDataPrefab;
	public Transform btnSaveDataContainer;
	public Transform confirmSaveContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.fileSystemBrowser.allAddCallBack(this);
				uiData.btnSaveData.allAddCallBack (this);
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
			if (data is BtnSaveDataUI.UIData) {
				BtnSaveDataUI.UIData btnSaveDataUIData = data as BtnSaveDataUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnSaveDataUIData, btnSaveDataPrefab, btnSaveDataContainer);
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
				uiData.fileSystemBrowser.allRemoveCallBack(this);
				uiData.btnSaveData.allRemoveCallBack (this);
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
			if (data is BtnSaveDataUI.UIData) {
				BtnSaveDataUI.UIData btnSaveDataUIData = data as BtnSaveDataUI.UIData;
				// UI
				{
					btnSaveDataUIData.removeCallBackAndDestroy (typeof(BtnSaveDataUI));
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
			case UIData.Property.needSaveData:
				break;
			case UIData.Property.fileSystemBrowser:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnSaveData:
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
			if (wrapProperty.p is BtnSaveDataUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			// gameUI
			{
				if (this.data.getDataParent () is GameUI.UIData) {
					GameUI.UIData gameUIData = this.data.getDataParent () as GameUI.UIData;
					gameUIData.saveUIData.v = null;
				}
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}