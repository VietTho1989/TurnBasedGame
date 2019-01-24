using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStatePlayInformUI : UIBehavior<ContestManagerStatePlayInformUI.UIData>
	{

		#region UIData

		public class UIData : ContestManagerInformUI.UIData.StateUI
		{

			public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

			public VP<ContestManagerPlayBtnForceEndUI.UIData> btnForceEnd;

			#region Constructor

			public enum Property
			{
				contestManagerStatePlay,
				btnForceEnd
			}

			public UIData() : base()
			{
				this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
				this.btnForceEnd = new VP<ContestManagerPlayBtnForceEndUI.UIData>(this, (byte)Property.btnForceEnd, new ContestManagerPlayBtnForceEndUI.UIData());
			}

			#endregion

			public override ContestManager.State.Type getType ()
			{
				return ContestManager.State.Type.Play;
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text lbTitle;
		public static readonly TxtLanguage txtTitle = new TxtLanguage();

		static ContestManagerStatePlayInformUI()
		{
			txtTitle.add (Language.Type.vi, "Giải đấu trạng thái chơi");
		}

		#endregion

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManagerStatePlay contestManagerStatePlay = this.data.contestManagerStatePlay.v.data;
					if (contestManagerStatePlay != null) {
						// btnForceEnd
						{
							ContestManagerPlayBtnForceEndUI.UIData btnForceEnd = this.data.btnForceEnd.v;
							if (btnForceEnd != null) {
								btnForceEnd.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay> (contestManagerStatePlay);
							} else {
								Debug.LogError ("btnForceEnd null: " + this);
							}
						}
					} else {
						Debug.LogError ("contestManagerStatePlay null: " + this);
					}
					// txt
					{
						if (lbTitle != null) {
							lbTitle.text = txtTitle.get ("Tournament state play");
						} else {
							Debug.LogError ("lbTitle null: " + this);
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

		public ContestManagerPlayBtnForceEndUI btnForceEndPrefab;
		public Transform btnForceEndContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.contestManagerStatePlay.allAddCallBack (this);
					uiData.btnForceEnd.allAddCallBack (this);
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
				if (data is ContestManagerStatePlay) {
					dirty = true;
					return;
				}
				if (data is ContestManagerPlayBtnForceEndUI.UIData) {
					ContestManagerPlayBtnForceEndUI.UIData btnForceEnd = data as ContestManagerPlayBtnForceEndUI.UIData;
					// UI
					{
						UIUtils.Instantiate (btnForceEnd, btnForceEndPrefab, btnForceEndContainer);
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
					uiData.contestManagerStatePlay.allRemoveCallBack (this);
					uiData.btnForceEnd.allRemoveCallBack (this);
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
				if (data is ContestManagerStatePlay) {
					return;
				}
				if (data is ContestManagerPlayBtnForceEndUI.UIData) {
					ContestManagerPlayBtnForceEndUI.UIData btnForceEnd = data as ContestManagerPlayBtnForceEndUI.UIData;
					// UI
					{
						btnForceEnd.removeCallBackAndDestroy (typeof(ContestManagerPlayBtnForceEndUI));
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
				case UIData.Property.contestManagerStatePlay:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.btnForceEnd:
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
					Debug.LogError ("Don't proccess: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is ContestManagerStatePlay) {
					return;
				}
				if (wrapProperty.p is ContestManagerPlayBtnForceEndUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}