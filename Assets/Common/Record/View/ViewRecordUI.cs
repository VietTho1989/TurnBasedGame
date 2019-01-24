using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewRecordUI : UIBehavior<ViewRecordUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<DataRecord> dataRecord;

			#region Sub

			public abstract class Sub : Data
			{

				public enum Type
				{
					Game
				}

				public abstract Type getType();

			}

			public VP<Sub> sub;

			#endregion

			public VP<ViewRecordControllerUI.UIData> controller;

			#region Constructor

			public enum Property
			{
				dataRecord,
				sub,
				controller
			}

			public UIData() : base()
			{
				this.dataRecord = new VP<DataRecord>(this, (byte)Property.dataRecord, null);
				this.sub = new VP<Sub>(this, (byte)Property.sub, null);
				this.controller = new VP<ViewRecordControllerUI.UIData>(this, (byte)Property.controller, new ViewRecordControllerUI.UIData());
			}

			#endregion

			public bool processEvent(Event e)
			{
				Debug.LogError ("processEvent: " + e + "; " + this);
				bool isProcess = false;
				{
					// sub
					{

					}
					// controller
					{

					}
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							ViewRecordUI viewRecordUI = this.findCallBack<ViewRecordUI> ();
							if (viewRecordUI != null) {
								viewRecordUI.onClickBtnBack ();
							} else {
								Debug.LogError ("viewRecordUI null: " + this);
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

		static ViewRecordUI()
		{
			txtBack.add (Language.Type.vi, "Quay Lại");
		}

		#endregion

		public GameObject contentContainer;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					DataRecord dataRecord = this.data.dataRecord.v;
					if (dataRecord != null) {
						// contentContainer
						{
							if (contentContainer != null) {
								contentContainer.SetActive (true);
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
						}
						// sub
						{
							if (dataRecord.version == Global.VersionCode) {
								if (dataRecord.data != null) {
									if (dataRecord.data is Game) {
										Game game = dataRecord.data as Game;
										// find
										ViewGameRecordUI.UIData viewGameRecordUIData = this.data.sub.newOrOld<ViewGameRecordUI.UIData> ();
										{
											viewGameRecordUIData.game.v = new ReferenceData<Game> (game);
										}
										this.data.sub.v = viewGameRecordUIData;
									} else {
										this.data.sub.v = null;
										Debug.LogError ("unknown data");
									}
								} else {
									this.data.sub.v = null;
								}
							} else {
								Debug.LogError ("not correct version: " + this);
								this.data.sub.v = null;
							}
						}
						// controller
						{
							ViewRecordControllerUI.UIData viewRecordControllerUIData = this.data.controller.v;
							if (viewRecordControllerUIData != null) {
								viewRecordControllerUIData.dataRecord.v = dataRecord;
							} else {
								Debug.LogError ("viewRecordControllerUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("dataRecord null: " + this);
						// contentContainer
						{
							if (contentContainer != null) {
								contentContainer.SetActive (false);
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
						}
					}
					// txt
					{
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

		public ViewGameRecordUI viewGameRecordPrefab;
		public Transform subContainer;

		public ViewRecordControllerUI viewRecordControllerPrefab;
		public Transform viewRecordControllerContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.sub.allAddCallBack (this);
					uiData.controller.allAddCallBack (this);
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
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case UIData.Sub.Type.Game:
							{
								ViewGameRecordUI.UIData viewGameRecordUIData = sub as ViewGameRecordUI.UIData;
								UIUtils.Instantiate (viewGameRecordUIData, viewGameRecordPrefab, subContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is ViewRecordControllerUI.UIData) {
					ViewRecordControllerUI.UIData viewRecordControllerUIData = data as ViewRecordControllerUI.UIData;
					// UI
					{
						UIUtils.Instantiate (viewRecordControllerUIData, viewRecordControllerPrefab, viewRecordControllerContainer);
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
					uiData.sub.allRemoveCallBack (this);
					uiData.controller.allRemoveCallBack (this);
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
				if (data is UIData.Sub) {
					UIData.Sub sub = data as UIData.Sub;
					// UI
					{
						switch (sub.getType ()) {
						case UIData.Sub.Type.Game:
							{
								ViewGameRecordUI.UIData viewGameRecordUIData = sub as ViewGameRecordUI.UIData;
								viewGameRecordUIData.removeCallBackAndDestroy (typeof(ViewGameRecordUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is ViewRecordControllerUI.UIData) {
					ViewRecordControllerUI.UIData viewRecordControllerUIData = data as ViewRecordControllerUI.UIData;
					// UI
					{
						viewRecordControllerUIData.removeCallBackAndDestroy (typeof(ViewRecordControllerUI));
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
				case UIData.Property.dataRecord:
					dirty = true;
					break;
				case UIData.Property.sub:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.controller:
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
				if (wrapProperty.p is UIData.Sub) {
					return;
				}
				if (wrapProperty.p is ViewRecordControllerUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				this.data.dataRecord.v = null;
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}