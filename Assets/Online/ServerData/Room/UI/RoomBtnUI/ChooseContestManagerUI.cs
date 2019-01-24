using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ChooseContestManagerUI : UIBehavior<ChooseContestManagerUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Room>> room;

			public VP<ChooseContestManagerAdapter.UIData> chooseContestManagerAdapter;

			public VP<ContestManagerInformUI.UIData> currentContestManagerInform;

			#region Constructor

			public enum Property
			{
				room,
				chooseContestManagerAdapter,
				currentContestManagerInform
			}

			public UIData() : base()
			{
				this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
				this.chooseContestManagerAdapter = new VP<ChooseContestManagerAdapter.UIData>(this, (byte)Property.chooseContestManagerAdapter, new ChooseContestManagerAdapter.UIData());
				this.currentContestManagerInform = new VP<ContestManagerInformUI.UIData>(this, (byte)Property.currentContestManagerInform, new ContestManagerInformUI.UIData());
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							ChooseContestManagerUI chooseContestManagerUI = this.findCallBack<ChooseContestManagerUI> ();
							if (chooseContestManagerUI != null) {
								chooseContestManagerUI.onClickBtnBack ();
							} else {
								Debug.LogError ("chooseContestManagerUI null: " + this);
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
		public static readonly TxtLanguage txtBack = new TxtLanguage ();

		static ChooseContestManagerUI()
		{
			txtTitle.add (Language.Type.vi, "Chọn Giải Đấu");
			txtBack.add (Language.Type.vi, "Quay Lại");
		}

		#endregion

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Room room = this.data.room.v.data;
					if (room != null) {
						// chooseContestManagerAdapter
						{
							ChooseContestManagerAdapter.UIData chooseContestManagerAdapter = this.data.chooseContestManagerAdapter.v;
							if (chooseContestManagerAdapter != null) {
								chooseContestManagerAdapter.room.v = new ReferenceData<Room> (room);
							} else {
								Debug.LogError ("chooseContestManagerAdapter null: " + this);
							}
						}
						// currentContestManagerInform
						{
							ContestManagerInformUI.UIData currentContestManagerInform = this.data.currentContestManagerInform.v;
							if (currentContestManagerInform != null) {
								// Find current contestManager
								ContestManager currentContestManager = null;
								{
									RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData> ();
									if (roomUIData != null) {
										ContestManagerUI.UIData contestManagerUIData = roomUIData.contestManagerUIData.v;
										if (contestManagerUIData != null) {
											currentContestManager = contestManagerUIData.contestManager.v.data;
										} else {
											Debug.LogError ("contestManagerUIData null: " + this);
										}
									} else {
										Debug.LogError ("roomUIData null: " + this);
									}
								}
								currentContestManagerInform.contestManager.v = new ReferenceData<ContestManager> (currentContestManager);
							} else {
								Debug.LogError ("currentContestManagerInform null: " + this);
							}
						}
					} else {
						Debug.LogError ("room null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Choose Tournament");
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

		public ChooseContestManagerAdapter chooseContestManagerPrefab;
		public Transform chooseContestManagerContainer;

		public ContestManagerInformUI contestManagerInformPrefab;
		public Transform contestManagerInformContainer;
		private RoomUI.UIData roomUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.roomUIData);
				}
				// Child
				{
					uiData.room.allAddCallBack (this);
					uiData.chooseContestManagerAdapter.allAddCallBack (this);
					uiData.currentContestManagerInform.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Setting
			if (data is Setting) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is RoomUI.UIData) {
					RoomUI.UIData roomUIData = data as RoomUI.UIData;
					// Child
					{
						roomUIData.contestManagerUIData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is ContestManagerUI.UIData) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is Room) {
					dirty = true;
					return;
				}
				if (data is ChooseContestManagerAdapter.UIData) {
					ChooseContestManagerAdapter.UIData chooseContestManagerAdapterUIData = data as ChooseContestManagerAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (chooseContestManagerAdapterUIData, chooseContestManagerPrefab, chooseContestManagerContainer);
					}
					dirty = true;
					return;
				}
				if (data is ContestManagerInformUI.UIData) {
					ContestManagerInformUI.UIData contestManagerInformUIData = data as ContestManagerInformUI.UIData;
					// UI
					{
						UIUtils.Instantiate (contestManagerInformUIData, contestManagerInformPrefab, contestManagerInformContainer);
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
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.roomUIData);
				}
				// Child
				{
					uiData.room.allRemoveCallBack (this);
					uiData.chooseContestManagerAdapter.allRemoveCallBack (this);
					uiData.currentContestManagerInform.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Parent
			{
				if (data is RoomUI.UIData) {
					RoomUI.UIData roomUIData = data as RoomUI.UIData;
					// Child
					{
						roomUIData.contestManagerUIData.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is ContestManagerUI.UIData) {
					return;
				}
			}
			// Child
			{
				if (data is Room) {
					return;
				}
				if (data is ChooseContestManagerAdapter.UIData) {
					ChooseContestManagerAdapter.UIData chooseContestManagerAdapterUIData = data as ChooseContestManagerAdapter.UIData;
					// UI
					{
						chooseContestManagerAdapterUIData.removeCallBackAndDestroy (typeof(ChooseContestManagerAdapter));
					}
					return;
				}
				if (data is ContestManagerInformUI.UIData) {
					ContestManagerInformUI.UIData contestManagerInformUIData = data as ContestManagerInformUI.UIData;
					// UI
					{
						contestManagerInformUIData.removeCallBackAndDestroy (typeof(ContestManagerInformUI));
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
				case UIData.Property.room:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.chooseContestManagerAdapter:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.currentContestManagerInform:
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
			// Parent
			{
				if (wrapProperty.p is RoomUI.UIData) {
					switch ((RoomUI.UIData.Property)wrapProperty.n) {
					case RoomUI.UIData.Property.room:
						break;
					case RoomUI.UIData.Property.roomBtnUIData:
						break;
					case RoomUI.UIData.Property.contestManagerUIData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case RoomUI.UIData.Property.requestNewContestManagerUIData:
						break;
					case RoomUI.UIData.Property.chooseContestManagerUIData:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is ContestManagerUI.UIData) {
					switch ((ContestManagerUI.UIData.Property)wrapProperty.n) {
					case ContestManagerUI.UIData.Property.contestManager:
						dirty = true;
						break;
					case ContestManagerUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
				if (wrapProperty.p is Room) {
					return;
				}
				if (wrapProperty.p is ChooseContestManagerAdapter.UIData) {
					return;
				}
				if (wrapProperty.p is ContestManagerInformUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData> ();
				if (roomUIData != null) {
					roomUIData.chooseContestManagerUIData.v = null;
				} else {
					Debug.LogError ("roomUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}