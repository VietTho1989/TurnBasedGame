using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LanHostUI : UIBehavior<LanHostUI.UIData>
{

	#region UIData

	public class UIData : LanUI.UIData.Sub, ServerManager.UIData.OnClick
	{
		
		public VP<SqliteServerUI.UIData> sqliteServerUIData;

		#region Constructor

		public enum Property
		{
			sqliteServerUIData
		}

		public UIData() : base()
		{
			// sqliteServerUIData
			{
				this.sqliteServerUIData = new VP<SqliteServerUI.UIData>(this, (byte)Property.sqliteServerUIData, new SqliteServerUI.UIData());
				this.sqliteServerUIData.v.serverType = Server.Type.Host;
			}
		}

		#endregion

		public override LanUI.UIData.Sub.Type getType()
		{
			return LanUI.UIData.Sub.Type.Host;
		}

		#region implement ServerManager.UIData.OnClick

		public void onClickReturn()
		{
			LanUI.UIData lanUIData = this.findDataInParent<LanUI.UIData> ();
			if (lanUIData != null) {
				LanMenuUI.UIData lanMenuUIData = lanUIData.sub.newOrOld<LanMenuUI.UIData> ();
				{

				}
				lanUIData.sub.v = lanMenuUIData;
			} else {
				Debug.LogError ("lanUIData null: " + this);
			}
		}

		#endregion

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// sqliteServerUIData
				if (!isProcess) {
					SqliteServerUI.UIData sqliteServerUIData = this.sqliteServerUIData.v;
					if (sqliteServerUIData != null) {
						isProcess = sqliteServerUIData.processEvent (e);
					} else {
						Debug.LogError ("sqliteServerUIData null: " + this);
					}
				}
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						LanHostUI lanHostUI = this.findCallBack<LanHostUI> ();
						if (lanHostUI != null) {
							lanHostUI.onClickBtnBack ();
						} else {
							Debug.LogError ("lanHostUI null: " + this);
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

	public Text lbTitle;
	public static readonly TxtLanguage txtTitle = new TxtLanguage();

	public Text tvBack;
	public static readonly TxtLanguage txtBack = new TxtLanguage();

	static LanHostUI()
	{
		txtTitle.add (Language.Type.vi, "Máy chủ mạng LAN");
		txtBack.add (Language.Type.vi, "Quay Lại");
	}

	#endregion

	public GameObject contentContainer;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// contentContainer
				{
					if (contentContainer != null) {
						bool show = false;
						{
							SqliteServerUI.UIData sqliteServerUIData = this.data.sqliteServerUIData.v;
							if (sqliteServerUIData != null) {
								show = sqliteServerUIData.isShowOther ();
							} else {
								Debug.LogError ("sqliteServerUIData null: " + this);
							}
						}
						contentContainer.SetActive (show);
					} else {
						Debug.LogError ("contentContainer null: " + this);
					}
				}
                // siblingIndex
                {
                    UIRectTransform.SetSiblingIndex(this.data.sqliteServerUIData.v, 0);
                }
                // txt
                {
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Lan Host");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
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

	public SqliteServerUI sqliteServerPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.sqliteServerUIData.allAddCallBack (this);
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
			if (data is SqliteServerUI.UIData) {
				SqliteServerUI.UIData sqliteServerUIData = data as SqliteServerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (sqliteServerUIData, sqliteServerPrefab, this.transform, UIConstants.FullParent);
				}
				// Child
				{
					sqliteServerUIData.sub.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is SqliteServerUI.UIData.Sub) {
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
				uiData.sqliteServerUIData.allRemoveCallBack (this);
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
			if (data is SqliteServerUI.UIData) {
				SqliteServerUI.UIData sqliteServerUIData = data as SqliteServerUI.UIData;
				// UI
				{
					sqliteServerUIData.removeCallBackAndDestroy (typeof(SqliteServerUI));
				}
				// Child
				{
					sqliteServerUIData.sub.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is SqliteServerUI.UIData.Sub) {
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
			case UIData.Property.sqliteServerUIData:
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
			if (wrapProperty.p is SqliteServerUI.UIData) {
				switch ((SqliteServerUI.UIData.Property)wrapProperty.n) {
				case SqliteServerUI.UIData.Property.sub:
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
			if (wrapProperty.p is SqliteServerUI.UIData.Sub) {
				SqliteServerUI.UIData.Sub sub = wrapProperty.p as  SqliteServerUI.UIData.Sub;
				switch (sub.getType ()) {
				case SqliteServerUI.UIData.Sub.Type.NoDatabase:
					{
						switch ((NoDatabaseServerUI.UIData.Property)wrapProperty.n) {
						case NoDatabaseServerUI.UIData.Property.sub:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
					break;
				case SqliteServerUI.UIData.Sub.Type.HaveDatabase:
					{
						switch ((HaveDatabaseServerUI.UIData.Property)wrapProperty.n) {
						case HaveDatabaseServerUI.UIData.Property.sub:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
					break;
				default:
					Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		Debug.LogError ("onClickBtnBack: " + this);
		if (this.data != null) {
			this.data.onClickReturn ();
		} else {
			Debug.LogError ("uiData null: " + this);
		}
	}

}