using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameHistoryUI : UIBehavior<GameHistoryUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<History>> history;

		public VP<ViewSaveDataUI.UIData> viewSaveDataUIData;

		public VP<BtnLoadHistoryUI.UIData> btnLoadHistoryUIData;

		#region Constructor

		public enum Property
		{
			history,
			viewSaveDataUIData,
			btnLoadHistoryUIData
		}

		public UIData() : base()
		{
			this.history = new VP<ReferenceData<History>>(this, (byte)Property.history, new ReferenceData<History>(null));
			this.viewSaveDataUIData = new VP<ViewSaveDataUI.UIData>(this, (byte)Property.viewSaveDataUIData, new ViewSaveDataUI.UIData());
			this.btnLoadHistoryUIData = new VP<BtnLoadHistoryUI.UIData>(this, (byte)Property.btnLoadHistoryUIData, new BtnLoadHistoryUI.UIData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// viewSaveDataUIData
				if (!isProcess) {
					ViewSaveDataUI.UIData viewSaveDataUIData = this.viewSaveDataUIData.v;
					if (viewSaveDataUIData != null) {
						isProcess = viewSaveDataUIData.processEvent (e);
					} else {
						Debug.LogError ("viewSaveDataUIData null: " + this);
					}
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtView = new TxtLanguage();
	public static readonly TxtLanguage txtCannotView = new TxtLanguage ();

	static GameHistoryUI()
	{
		txtView.add (Language.Type.vi, "Xem Lịch Sử");
		txtCannotView.add (Language.Type.vi, "Không Tải Lịch Sử, Không Thể Xem");
	}

	#endregion

	public Button btnView;
	public Text tvView;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				History history = this.data.history.v.data;
				if (history != null) {
					// btnView, tvView
					{
						if (btnView != null && tvView != null) {
							if (history.changes.vs.Count == history.changeCount.v) {
								btnView.interactable = true;
								tvView.text = txtView.get ("View History");
							} else {
								btnView.interactable = false;
								tvView.text = txtCannotView.get ("Not Load History, Cannot View");
							}
						} else {
							Debug.LogError ("btnView null, tvView null: " + this);
						}
					}
					// btnLoadHistoryUIData
					{
						BtnLoadHistoryUI.UIData btnLoadHistoryUIData = this.data.btnLoadHistoryUIData.v;
						if (btnLoadHistoryUIData != null) {
							btnLoadHistoryUIData.history.v = new ReferenceData<History> (history);
						} else {
							Debug.LogError ("btnLoadHistoryUIData null: " + this);
						}
					}
				} else {
					// Debug.LogError ("history null: " + this);
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public ViewSaveDataUI viewSaveDataPrefab;

	public BtnLoadHistoryUI btnLoadHistoryPrefab;
	public Transform btnLoadHistoryContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.history.allAddCallBack (this);
				uiData.viewSaveDataUIData.allAddCallBack (this);
				uiData.btnLoadHistoryUIData.allAddCallBack (this);
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
			if (data is History) {
				dirty = true;
				return;
			}
			if (data is ViewSaveDataUI.UIData) {
				ViewSaveDataUI.UIData viewSaveDataUIData = data as ViewSaveDataUI.UIData;
				// UI
				{
					Transform viewSaveDataUIContainer = null;
					{
						if (this.data != null) {
							GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData> ();
							if (gameUIData != null) {
								GameUI gameUI = gameUIData.findCallBack<GameUI> ();
								if (gameUI != null) {
									viewSaveDataUIContainer = gameUI.viewSaveDataUIContainer;
								} else {
									Debug.LogError ("gameUI null: " + this);
								}
							} else {
								Debug.LogError ("gameUIData null: " + this);
							}
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					UIUtils.Instantiate (viewSaveDataUIData, viewSaveDataPrefab, viewSaveDataUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is BtnLoadHistoryUI.UIData) {
				BtnLoadHistoryUI.UIData btnLoadHistoryUIData = data as BtnLoadHistoryUI.UIData;
				// UI
				{
					UIUtils.Instantiate (btnLoadHistoryUIData, btnLoadHistoryPrefab, btnLoadHistoryContainer);
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
				uiData.history.allRemoveCallBack (this);
				uiData.viewSaveDataUIData.allRemoveCallBack (this);
				uiData.btnLoadHistoryUIData.allRemoveCallBack (this);
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
			if (data is History) {
				return;
			}
			if (data is ViewSaveDataUI.UIData) {
				ViewSaveDataUI.UIData viewSaveDataUIData = data as ViewSaveDataUI.UIData;
				// UI
				{
					viewSaveDataUIData.removeCallBackAndDestroy (typeof(ViewSaveDataUI));
				}
				return;
			}
			if (data is BtnLoadHistoryUI.UIData) {
				BtnLoadHistoryUI.UIData btnLoadHistoryUIData = data as BtnLoadHistoryUI.UIData;
				// UI
				{
					btnLoadHistoryUIData.removeCallBackAndDestroy (typeof(BtnLoadHistoryUI));
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
			case UIData.Property.history:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.viewSaveDataUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.btnLoadHistoryUIData:
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
			if (wrapProperty.p is History) {
				switch ((History.Property)wrapProperty.n) {
				case History.Property.isActive:
					break;
				case History.Property.changes:
					dirty = true;
					break;
				case History.Property.position:
					break;
				case History.Property.changeCount:
					dirty = true;
					break;
				case History.Property.humanConnections:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is ViewSaveDataUI.UIData) {
				return;
			}
			if (wrapProperty.p is BtnLoadHistoryUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnView()
	{
		if (this.data != null) {
			History history = this.data.history.v.data;
			if (history != null) {
				Game game = history.findDataInParent<Game> ();
				if (game != null) {
					ViewSaveDataUI.UIData viewSaveDataUIData = this.data.viewSaveDataUIData.newOrOld<ViewSaveDataUI.UIData> ();
					{
						Save save = new Save ();
						{
							SaveData saveData = new SaveData ();
							{
								saveData.data = DataUtils.cloneData (game);
							}
							save.content = saveData;
						}
						viewSaveDataUIData.save.v = save;
					}
					this.data.viewSaveDataUIData.v = viewSaveDataUIData;
				} else {
					Debug.LogError ("game null: " + this);
				}
			} else {
				Debug.LogError ("history null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}