using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class NormalRequestSwapPlayerUI : UIBehavior<NormalRequestSwapPlayerUI.UIData>
	{

		#region UIData

		public class UIData : NoRequestSwapPlayerUI.UIData.Sub
		{

			public VP<ReferenceData<TeamPlayer>> teamPlayer;

			#region Constructor

			public enum Property
			{
				teamPlayer
			}

			public UIData() : base()
			{
				this.teamPlayer = new VP<ReferenceData<TeamPlayer>>(this, (byte)Property.teamPlayer, new ReferenceData<TeamPlayer>(null));
			}

			#endregion

			public override RoomUser.Role getType ()
			{
				return RoomUser.Role.NORMAL;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
					if (teamPlayer != null) {

					} else {
						Debug.LogError ("teamPlayer null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.teamPlayer.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is TeamPlayer) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.teamPlayer.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is TeamPlayer) {
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
				case UIData.Property.teamPlayer:
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
			if (wrapProperty.p is TeamPlayer) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}