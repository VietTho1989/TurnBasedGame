using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace HEX.NoneRule
{
	public class HexCustomSetUI : UIBehavior<HexCustomSetUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<HexCustomSet>> hexCustomSet;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				hexCustomSet,
				isHint
			}

			public UIData() : base()
			{
				this.hexCustomSet = new VP<ReferenceData<HexCustomSet>>(this, (byte)Property.hexCustomSet, new ReferenceData<HexCustomSet>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.HexCustomSet;
			}

		}

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Hex ? 1 : 0;
        }

        #region Refresh

        public UILineRenderer lineRenderer;

		public Image imgHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					HexCustomSet hexCustomSet = this.data.hexCustomSet.v.data;
					if (hexCustomSet != null) {
						// lineRenderer
						if (lineRenderer != null) {
							Vector2[] points = new Vector2[5];
							{
								Vector3 localPos = Common.GetLocalPosition (hexCustomSet.square.v, this.data);
								points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
								points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
								points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
								points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
							}
							lineRenderer.Points = points;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (imgHint != null) {
							if (this.data.isHint.v) {
								// sprite
								{
									float alpha = 0.5f;
									switch (hexCustomSet.piece.v) {
									case Common.Color.Empty:
										imgHint.color = Global.TransparentColor;
										break;
									case Common.Color.Red:
										imgHint.color = new Color (1, 0, 0, alpha);
										break;
									case Common.Color.Blue:
										imgHint.color = new Color (0, 0, 1, alpha);
										break;
									default:
										Debug.LogError ("unknown color: " + hexCustomSet.piece.v + "; " + this);
										imgHint.color = Global.TransparentColor;
										break;
									}
								}
								// position
								{
									imgHint.transform.localPosition = Common.GetLocalPosition (hexCustomSet.square.v, this.data);
								}
								// scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
								}
							} else {
								imgHint.color = Global.TransparentColor;
							}
						} else {
							Debug.LogError ("imgHint null: " + this);
						}
					} else {
						Debug.LogError ("hexCustomSet null: " + this);
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

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		private HexGameDataUI.UIData hexGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.hexGameDataUIData);
				}
				// Child
				{
					uiData.hexCustomSet.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is HexGameDataUI.UIData) {
					HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
					// Child
					{
						hexGameDataUIData.board.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.hex.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Hex) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is HexCustomSet) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.hexGameDataUIData);
				}
				// Child
				{
					uiData.hexCustomSet.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is HexGameDataUI.UIData) {
					HexGameDataUI.UIData hexGameDataUIData = data as HexGameDataUI.UIData;
					// Child
					{
						hexGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.hex.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Hex) {
						return;
					}
				}
			}
			// Child
			if (data is HexCustomSet) {
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
				case UIData.Property.hexCustomSet:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (wrapProperty.p is HexGameDataUI.UIData) {
					switch ((HexGameDataUI.UIData.Property)wrapProperty.n) {
					case HexGameDataUI.UIData.Property.gameData:
						break;
					case HexGameDataUI.UIData.Property.transformOrganizer:
						break;
					case HexGameDataUI.UIData.Property.isOnAnimation:
						break;
					case HexGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case HexGameDataUI.UIData.Property.lastMove:
						break;
					case HexGameDataUI.UIData.Property.showHint:
						break;
					case HexGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is BoardUI.UIData) {
						switch ((BoardUI.UIData.Property)wrapProperty.n) {
						case BoardUI.UIData.Property.hex:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case BoardUI.UIData.Property.boardSize:
							break;
						case BoardUI.UIData.Property.pieces:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Hex) {
						switch ((Hex.Property)wrapProperty.n) {
						case Hex.Property.boardSize:
							dirty = true;
							break;
						case Hex.Property.board:
							dirty = true;
							break;
						case Hex.Property.isSwitch:
							break;
						case Hex.Property.isCustom:
							break;
						case Hex.Property.playerIndex:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			// Child
			if (wrapProperty.p is HexCustomSet) {
				switch ((HexCustomSet.Property)wrapProperty.n) {
				case HexCustomSet.Property.square:
					dirty = true;
					break;
				case HexCustomSet.Property.piece:
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

	}
}