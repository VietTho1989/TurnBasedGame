using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShowSettingUI : UIBehavior<ShowSettingUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<SettingUI.UIData> settingUIData;

		public VP<ShowSettingFooterUI.UIData> footer;

		#region Constructor

		public enum Property
		{
			settingUIData,
			footer
		}

		public UIData() : base()
		{
			this.settingUIData = new VP<SettingUI.UIData>(this, (byte)Property.settingUIData, new SettingUI.UIData());
			this.footer = new VP<ShowSettingFooterUI.UIData>(this, (byte)Property.footer, new ShowSettingFooterUI.UIData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			Debug.LogError ("processEvent: " + e);
			bool isProcess = false;
			{
				// child
				if (!isProcess) {
					// TODO Can hoan thien
				}
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						ShowSettingUI showSettingUI = this.findCallBack<ShowSettingUI> ();
						if (showSettingUI != null) {
							showSettingUI.onClickBtnBack ();
						} else {
							Debug.LogError ("showSettingUI null: " + this);
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

	public Text tvSetting;
	public static readonly TxtLanguage txtSetting = new TxtLanguage ();

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage ();

	static ShowSettingUI()
	{
		txtSetting.add (Language.Type.vi, "Thiết Lập");
		txtBack.add (Language.Type.vi, "Quay Lại");
	}

	private void updateTxt()
	{
		if (tvSetting != null) {
			tvSetting.text = txtSetting.get ("Setting");
		} else {
			Debug.LogError ("tvSetting null: " + this);
		}
		if (tvBack != null) {
			tvBack.text = txtBack.get ("Back");
		} else {
			Debug.LogError ("tvBack null: " + this);
		}
	}

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// settingUIData
				{
					SettingUI.UIData settingUIData = this.data.settingUIData.v;
					if (settingUIData != null) {
						EditData<Setting> editSetting = settingUIData.editSetting.v;
						if (editSetting != null) {
							editSetting.origin.v = new ReferenceData<Setting> (Setting.get ());
							editSetting.canEdit.v = true;
						} else {
							Debug.LogError ("editSetting null: " + this);
						}
					} else {
						Debug.LogError ("settingUIData null: " + this);
					}
				}
				updateTxt ();
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

	public SettingUI settingUIPrefab;
	public Transform settingUIContainer;

	public ShowSettingFooterUI footerPrefab;
	public Transform footerContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.settingUIData.allAddCallBack (this);
				uiData.footer.allAddCallBack (this);
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
			if (data is SettingUI.UIData) {
				SettingUI.UIData settingUIData = data as SettingUI.UIData;
				// UI
				{
					UIUtils.Instantiate (settingUIData, settingUIPrefab, settingUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is ShowSettingFooterUI.UIData) {
				ShowSettingFooterUI.UIData footer = data as ShowSettingFooterUI.UIData;
				// UI
				{
					UIUtils.Instantiate (footer, footerPrefab, footerContainer);
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
				uiData.settingUIData.allRemoveCallBack (this);
				uiData.footer.allRemoveCallBack (this);
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
			if (data is SettingUI.UIData) {
				SettingUI.UIData settingUIData = data as SettingUI.UIData;
				// UI
				{
					settingUIData.removeCallBackAndDestroy (typeof(SettingUI));
				}
				return;
			}
			if (data is ShowSettingFooterUI.UIData) {
				ShowSettingFooterUI.UIData footer = data as ShowSettingFooterUI.UIData;
				// UI
				{
					footer.removeCallBackAndDestroy (typeof(ShowSettingFooterUI));
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
			case UIData.Property.settingUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.footer:
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
			if (wrapProperty.p is SettingUI.UIData) {
				return;
			}
			if (wrapProperty.p is ShowSettingFooterUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData> ();
			if (mainUIData != null) {
				mainUIData.showSettingUIData.v = null;
			} else {
				Debug.LogError ("mainUIData null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}