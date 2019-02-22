using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class BtnBackWardUI : UIBehavior<BtnBackWardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<DirectoryHistory>> directoryHistory;

			#region Constructor

			public enum Property
			{
				directoryHistory
			}

			public UIData() : base()
			{
				this.directoryHistory = new VP<ReferenceData<DirectoryHistory>>(this, (byte)Property.directoryHistory, new ReferenceData<DirectoryHistory>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		#region txt

		public static readonly TxtLanguage txtCannotBackward = new TxtLanguage ();
		public static readonly TxtLanguage txtBackward = new TxtLanguage ();

		static BtnBackWardUI()
		{
			txtCannotBackward.add (Language.Type.vi, "Không thể lùi lại");
			txtBackward.add (Language.Type.vi, "Lùi Lại");
		}

		#endregion

		public Button btnBackWard;
		public Text tvBackWard;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					DirectoryHistory directoryHistory = this.data.directoryHistory.v.data;
					if (directoryHistory != null) {
						if (btnBackWard != null && tvBackWard != null) {
							if (directoryHistory.position.v < 0) {
								btnBackWard.interactable = false;
								tvBackWard.text = txtCannotBackward.get ("Cannot Backward");
							} else {
								btnBackWard.interactable = true;
								tvBackWard.text = txtBackward.get ("Backward");
							}
						} else {
							Debug.LogError ("btnBackWard, tvBackWard null: " + this);
						}
					} else {
						Debug.LogError ("directoryHistory null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.directoryHistory.allAddCallBack (this);
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
			if (data is DirectoryHistory) {
				dirty = true;
				return;
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
					uiData.directoryHistory.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is DirectoryHistory) {
				return;
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
				case UIData.Property.directoryHistory:
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
			if (wrapProperty.p is DirectoryHistory) {
				switch ((DirectoryHistory.Property)wrapProperty.n) {
				case DirectoryHistory.Property.isActive:
					break;
				case DirectoryHistory.Property.history:
					dirty = true;
					break;
				case DirectoryHistory.Property.position:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBackWard()
		{
			if (this.data != null) {
				DirectoryHistory directoryHistory = this.data.directoryHistory.v.data;
				if (directoryHistory != null) {
					directoryHistory.processUndoRedo (DirectoryHistory.Operation.Undo);
				} else {
					Debug.LogError ("directoryHistory null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}