using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
{
	public class MakrukGameDataUI : UIBehavior<MakrukGameDataUI.UIData>
	{

		#region UIData

		public class UIData : GameDataBoardUI.UIData.Sub
		{
			
			public VP<ReferenceData<GameData>> gameData;

			#region Transform

			public VP<UpdateTransform.UpdateData> updateTransform;

			public VP<UITransformOrganizer.UpdateData> transformOrganizer;

			#endregion

			public VP<bool> isOnAnimation;

			public VP<BoardUI.UIData> board;

			public VP<LastMoveUI.UIData> lastMove;

			public VP<ShowHintUI.UIData> showHint;

			public VP<InputUI.UIData> inputUI;

			#region Constructor

			public enum Property
			{
				gameData,

				updateTransform,
				transformOrganizer,

				isOnAnimation,
				board,
				lastMove,
				showHint,
				inputUI
			}

			public UIData() : base()
			{
				this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));

				this.updateTransform = new VP<UpdateTransform.UpdateData>(this, (byte)Property.updateTransform, new UpdateTransform.UpdateData());
				this.transformOrganizer = new VP<UITransformOrganizer.UpdateData>(this, (byte)Property.transformOrganizer, new UITransformOrganizer.UpdateData());

				this.isOnAnimation = new VP<bool>(this, (byte)Property.isOnAnimation, false);
				this.board = new VP<BoardUI.UIData>(this, (byte)Property.board, new BoardUI.UIData());
				this.lastMove = new VP<LastMoveUI.UIData>(this, (byte)Property.lastMove, new LastMoveUI.UIData());
				this.showHint = new VP<ShowHintUI.UIData>(this, (byte)Property.showHint, new ShowHintUI.UIData());
				this.inputUI = new VP<InputUI.UIData>(this, (byte)Property.inputUI, new InputUI.UIData());
			}

			#endregion

			public override GameType.Type getType ()
			{
				return GameType.Type.Makruk;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// inputUI
					if (!isProcess) {
						InputUI.UIData inputUI = this.inputUI.v;
						if (inputUI != null) {
							isProcess = inputUI.processEvent (e);
						} else {
							Debug.LogError ("inputUI null: " + this);
						}
					}
				}
				return isProcess;
			}

		}
			
		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// isOnAnimation
					this.data.isOnAnimation.v = GameDataBoardUI.UIData.isOnAnimation (this.data);
					// Find Makruk
					Makruk makruk = null;
					{
						GameData gameData = this.data.gameData.v.data;
						if (gameData != null) {
							GameType gameType = gameData.gameType.v;
							if (gameType != null) {
								if (gameType is Makruk) {
									makruk = (Makruk)gameType;
								} else {
									Debug.LogError ("why not makruk");
								}
							} else {
								Debug.LogError ("gameType null: " + this);
							}
						}
					}
					// process
					{
						// board
						{
							if (this.data.board.v != null) {
								this.data.board.v.makruk.v = new ReferenceData<Makruk> (makruk);
							} else {
								Debug.LogError ("board null: " + this);
							}
						}
						// input
						{
							if (this.data.inputUI.v != null) {
								this.data.inputUI.v.makruk.v = new ReferenceData<Makruk> (makruk);
							} else {
								Debug.LogError ("inputUI null: " + this);
							}
						}
						// LastMove
						{
							LastMoveUI.UIData lastMoveUIData = this.data.lastMove.v;
							if (lastMoveUIData != null) {
								lastMoveUIData.gameData.v = new ReferenceData<GameData> (this.data.gameData.v.data);
							} else {
								Debug.LogError ("lastMoveUIData null: " + this);
							}
						}
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

		public BoardUI boardPrefab;
		public LastMoveUI lastMovePrefab;
		public ShowHintUI showHintPrefab;
		public InputUI inputPrefab;

		private CheckHaveAnimation<UIData> checkHaveAnimation = new CheckHaveAnimation<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					checkHaveAnimation.addCallBack (this);
					checkHaveAnimation.setData (uiData);
				}
				// Child
				{
					uiData.gameData.allAddCallBack (this);
					uiData.board.allAddCallBack (this);
					uiData.lastMove.allAddCallBack (this);
					uiData.showHint.allAddCallBack (this);
					uiData.inputUI.allAddCallBack (this);
					// transform
					{
						uiData.updateTransform.allAddCallBack (this);
						uiData.transformOrganizer.allAddCallBack (this);
					}
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is CheckHaveAnimation<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				// GameData
				if (data is GameData) {
					dirty = true;
					return;
				}
				// Board
				if (data is BoardUI.UIData) {
					BoardUI.UIData boardUIData = data as BoardUI.UIData;
					// UI
					{
						UIUtils.Instantiate (boardUIData, boardPrefab, this.transform);
					}
					dirty = true;
					return;
				}
				// LastMove
				if (data is LastMoveUI.UIData) {
					LastMoveUI.UIData lastMoveUIData = data as LastMoveUI.UIData;
					// UI
					{
						UIUtils.Instantiate (lastMoveUIData, lastMovePrefab, this.transform);
					}
					dirty = true;
					return;
				}
				// ShowHint
				if (data is ShowHintUI.UIData) {
					ShowHintUI.UIData showHintUIData = data as ShowHintUI.UIData;
					// UI
					{
						UIUtils.Instantiate (showHintUIData, showHintPrefab, this.transform);
					}
					dirty = true;
					return;
				}
				// Input
				if (data is InputUI.UIData) {
					InputUI.UIData inputUIData = data as InputUI.UIData;
					// UI
					{
						InputUI inputUI = (InputUI)UIUtils.Instantiate (inputUIData, inputPrefab, this.transform);
						if (inputUI != null) {
							inputUI.transform.SetAsLastSibling ();
						} else {
							Debug.LogError ("inputUI null: " + this);
						}
					}
					dirty = true;
					return;
				}
				// Transform
				{
					if (data is UpdateTransform.UpdateData) {
						UpdateTransform.UpdateData updateTransformData = data as UpdateTransform.UpdateData;
						{
							UpdateUtils.makeComponentUpdate<UpdateTransform, UpdateTransform.UpdateData> (updateTransformData, this.transform);
						}
						dirty = true;
						return;
					}
					if (data is UITransformOrganizer.UpdateData) {
						UITransformOrganizer.UpdateData transformOrganizer = data as UITransformOrganizer.UpdateData;
						{
							UpdateUtils.makeComponentUpdate<UITransformOrganizer, UITransformOrganizer.UpdateData> (transformOrganizer, this.transform);
						}
						dirty = true;
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					checkHaveAnimation.removeCallBack (this);
					checkHaveAnimation.setData (null);
				}
				// Child
				{
					uiData.gameData.allRemoveCallBack (this);
					uiData.board.allRemoveCallBack (this);
					uiData.lastMove.allRemoveCallBack (this);
					uiData.showHint.allRemoveCallBack (this);
					uiData.inputUI.allRemoveCallBack (this);
					// Transform
					{
						uiData.updateTransform.allRemoveCallBack (this);
						uiData.transformOrganizer.allRemoveCallBack (this);
					}
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is CheckHaveAnimation<UIData>) {
				return;
			}
			// Child
			{
				// GameData
				if (data is GameData) {
					return;
				}
				// Board
				if (data is BoardUI.UIData) {
					BoardUI.UIData boardUIData = data as BoardUI.UIData;
					// UI
					{
						boardUIData.removeCallBackAndDestroy (typeof(BoardUI));
					}
					return;
				}
				// LastMove
				if (data is LastMoveUI.UIData) {
					LastMoveUI.UIData lastMoveUIData = data as LastMoveUI.UIData;
					// UI
					{
						lastMoveUIData.removeCallBackAndDestroy (typeof(LastMoveUI));
					}
					return;
				}
				// ShowHint
				if (data is ShowHintUI.UIData) {
					ShowHintUI.UIData showHintUIData = data as ShowHintUI.UIData;
					// UI
					{
						showHintUIData.removeCallBackAndDestroy (typeof(ShowHintUI));
					}
					return;
				}
				// InputUI
				if (data is InputUI.UIData) {
					InputUI.UIData inputUIData = data as InputUI.UIData;
					// UI
					{
						inputUIData.removeCallBackAndDestroy (typeof(InputUI));
					}
					return;
				}
				// Transform
				{
					if (data is UpdateTransform.UpdateData) {
						UpdateTransform.UpdateData updateTransformData = data as UpdateTransform.UpdateData;
						{
							updateTransformData.removeCallBackAndRemoveComponent (typeof(UpdateTransform));
						}
						return;
					}
					if (data is UITransformOrganizer.UpdateData) {
						UITransformOrganizer.UpdateData transformOrganizer = data as UITransformOrganizer.UpdateData;
						{
							transformOrganizer.removeCallBackAndRemoveComponent (typeof(UITransformOrganizer));
						}
						return;
					}
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
				case UIData.Property.gameData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.updateTransform:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.transformOrganizer:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isOnAnimation:
					break;
				case UIData.Property.board:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.lastMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.showHint:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.inputUI:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is CheckHaveAnimation<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				// GameData
				if (wrapProperty.p is GameData) {
					switch ((GameData.Property)wrapProperty.n) {
					case GameData.Property.gameType:
						dirty = true;
						break;
					case GameData.Property.useRule:
						break;
					case GameData.Property.turn:
						break;
					case GameData.Property.timeControl:
						break;
					case GameData.Property.lastMove:
						break;
					case GameData.Property.state:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Board
				if (wrapProperty.p is BoardUI.UIData) {
					return;
				}
				// LastMove
				if (wrapProperty.p is LastMoveUI.UIData) {
					return;
				}
				// ShowHint
				if (wrapProperty.p is ShowHintUI.UIData) {
					return;
				}
				// InputUI
				if (wrapProperty.p is InputUI.UIData) {
					return;
				}
				// Transform
				{
					if (wrapProperty.p is UpdateTransform.UpdateData) {
						return;
					}
					if (wrapProperty.p is UITransformOrganizer.UpdateData) {
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}