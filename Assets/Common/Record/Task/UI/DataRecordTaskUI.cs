using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class DataRecordTaskUI : UIBehavior<DataRecordTaskUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<DataRecordTask>> dataRecordTask;

			#region saveRecord

			public VP<SaveRecordUI.UIData> saveRecordUIData;

			public VP<Transform> saveRecordContainer;

			#endregion

			#region Constructor

			public enum Property
			{
				dataRecordTask,
				saveRecordUIData,
				saveRecordContainer
			}

			public UIData() : base()
			{
				this.dataRecordTask = new VP<ReferenceData<DataRecordTask>>(this, (byte)Property.dataRecordTask, new ReferenceData<DataRecordTask>(null));
				this.saveRecordUIData = new VP<SaveRecordUI.UIData>(this, (byte)Property.saveRecordUIData, null);
				this.saveRecordContainer = new VP<Transform>(this, (byte)Property.saveRecordContainer, null);
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// saveRecordUIData
					if (!isProcess) {
						SaveRecordUI.UIData saveRecordUIData = this.saveRecordUIData.v;
						if (saveRecordUIData != null) {
							isProcess = saveRecordUIData.processEvent (e);
						} else {
							Debug.LogError ("saveRecordUIData null: " + this);
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtNone = new TxtLanguage();
		public static readonly TxtLanguage txtStart = new TxtLanguage();
		public static readonly TxtLanguage txtRecord = new TxtLanguage();
		public static readonly TxtLanguage txtFinish = new TxtLanguage ();

		static DataRecordTaskUI()
		{
			txtNone.add (Language.Type.vi, "Ghi");
			txtStart.add (Language.Type.vi, "Đang bắt đầu...");
			txtRecord.add (Language.Type.vi, "Đang ghi, dừng?");
			txtFinish.add (Language.Type.vi, "Kết thúc, lưu trữ?");
		}

		#endregion

		public Button btnRecord;
		public Text tvRecord;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					DataRecordTask dataRecordTask = this.data.dataRecordTask.v.data;
					if (dataRecordTask != null) {
						// btnRecord, tvRecord
						{
							if (btnRecord != null && tvRecord != null) {
								switch (dataRecordTask.state.v) {
								case DataRecordTask.State.None:
									{
										btnRecord.enabled = true;
										tvRecord.text = txtNone.get ("Record");
									}
									break;
								case DataRecordTask.State.Start:
									{
										btnRecord.enabled = true;
										tvRecord.text = txtStart.get ("Starting...");
									}
									break;
								case DataRecordTask.State.Record:
									{
										btnRecord.enabled = true;
										tvRecord.text = txtRecord.get("Recording, stop?");
									}
									break;
								case DataRecordTask.State.Finish:
									{
										btnRecord.enabled = true;
										tvRecord.text = txtFinish.get ("Finish, save?");
									}
									break;
								default:
									Debug.LogError ("unknown state: " + dataRecordTask.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("btnRecord, tvRecord null: " + this);
							}
						}
						// saveUI
						{
							if (this.data.saveRecordContainer.v != null) {
								switch (dataRecordTask.state.v) {
								case DataRecordTask.State.None:
									break;
								case DataRecordTask.State.Start:
									break;
								case DataRecordTask.State.Record:
									break;
								case DataRecordTask.State.Finish:
									{
										SaveRecordUI.UIData saveRecordUIData = this.data.saveRecordUIData.newOrOld<SaveRecordUI.UIData> ();
										{
											UIUtils.Instantiate (saveRecordUIData, saveRecordUIPrefab, this.data.saveRecordContainer.v);
										}
										this.data.saveRecordUIData.v = saveRecordUIData;
									}
									break;
								default:
									Debug.LogError ("unknown state: " + dataRecordTask.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("saveRecordContainer null: " + this);
								this.data.saveRecordUIData.v = null;
							}
						}
					} else {
						Debug.LogError ("dataRecordTask null: " + this);
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

		public SaveRecordUI saveRecordUIPrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.dataRecordTask.allAddCallBack (this);
					uiData.saveRecordUIData.allAddCallBack (this);
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
				if (data is DataRecordTask) {
					DataRecordTask dataRecordTask = data as DataRecordTask;
					// Update
					{
						UpdateUtils.makeUpdate<DataRecordTaskUpdate, DataRecordTask> (dataRecordTask, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is SaveRecordUI.UIData) {
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
					uiData.dataRecordTask.allRemoveCallBack (this);
					uiData.saveRecordUIData.allRemoveCallBack (this);
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
				if (data is DataRecordTask) {
					DataRecordTask dataRecordTask = data as DataRecordTask;
					// Update
					{
						dataRecordTask.removeCallBackAndDestroy (typeof(DataRecordTaskUpdate));
					}
					return;
				}
				if (data is SaveRecordUI.UIData) {
					SaveRecordUI.UIData saveRecordUIData = data as SaveRecordUI.UIData;
					// UI
					{
						saveRecordUIData.removeCallBackAndDestroy (typeof(SaveRecordUI));
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
				case UIData.Property.dataRecordTask:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.saveRecordUIData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.saveRecordContainer:
					dirty = true;
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
				if (wrapProperty.p is DataRecordTask) {
					switch ((DataRecordTask.Property)wrapProperty.n) {
					case DataRecordTask.Property.needRecordData:
						break;
					case DataRecordTask.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is SaveRecordUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnRecord()
		{
			if (this.data != null) {
				DataRecordTask dataRecordTask = this.data.dataRecordTask.v.data;
				if (dataRecordTask != null) {
					switch (dataRecordTask.state.v) {
					case DataRecordTask.State.None:
						{
							dataRecordTask.state.v = DataRecordTask.State.Start;
						}
						break;
					case DataRecordTask.State.Start:
						{
							dataRecordTask.state.v = DataRecordTask.State.Finish;
						}
						break;
					case DataRecordTask.State.Record:
						{
							dataRecordTask.state.v = DataRecordTask.State.Finish;
						}
						break;
					case DataRecordTask.State.Finish:
						{
							Debug.LogError ("why can click: " + this);
						}
						break;
					default:
						Debug.LogError ("unknown state: " + dataRecordTask.state.v + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("dataRecordTask null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}