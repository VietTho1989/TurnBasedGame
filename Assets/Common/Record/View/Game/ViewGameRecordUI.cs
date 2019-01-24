using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewGameRecordUI : UIBehavior<ViewGameRecordUI.UIData>
	{

		#region UIData

		public class UIData : ViewRecordUI.UIData.Sub
		{

			public VP<ReferenceData<Game>> game;

			public VP<GameUI.UIData> gameUIData;

			#region Constructor

			public enum Property
			{
				game,
				gameUIData
			}

			public UIData() : base()
			{
				this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
				{
					this.gameUIData = new VP<GameUI.UIData>(this, (byte)Property.gameUIData, new GameUI.UIData());
					this.gameUIData.v.isReplay.v = true;
				}
			}

			#endregion

			public override Type getType ()
			{
				return Type.Game;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Game game = this.data.game.v.data;
					if (game != null) {
						// gameUIData
						{
							GameUI.UIData gameUIData = this.data.gameUIData.v;
							if (gameUIData != null) {
								gameUIData.game.v = new ReferenceData<Game> (game);
							} else {
								Debug.LogError ("gameUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("game null: " + this);
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

		public GameUI gameUIPrefab;
		public Transform gameUIContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.gameUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is GameUI.UIData) {
				GameUI.UIData gameUIData = data as GameUI.UIData;
				// UI
				{
					UIUtils.Instantiate (gameUIData, gameUIPrefab, gameUIContainer);
				}
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
					uiData.gameUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is GameUI.UIData) {
				GameUI.UIData gameUIData = data as GameUI.UIData;
				// UI
				{
					gameUIData.removeCallBackAndDestroy (typeof(GameUI));
				}
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
				case UIData.Property.game:
					dirty = true;
					break;
				case UIData.Property.gameUIData:
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
			if (wrapProperty.p is GameUI.UIData) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}