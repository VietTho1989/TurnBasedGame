using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

using Hint;

public class GameDataUI : UIBehavior<GameDataUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		
		public VP<ReferenceData<GameData>> gameData;

		public VP<GameDataBoardUI.UIData> board;

		public VP<Com.MyBool> allowLastMove;

		public VP<HintUI.UIData> hintUI;

		public VP<bool> allowInput;

		public VP<TurnUI.UIData> turn;

		public VP<RequestChangeUseRuleUI.UIData> requestChangeUseRule;

		#region Constructor

		public enum Property
		{
			gameData,
			board,
			allowLastMove,
			hintUI,
			allowInput,
			turn,
			requestChangeUseRule
		}

		public UIData() : base()
		{
			this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
			this.board = new VP<GameDataBoardUI.UIData>(this, (byte)Property.board, new GameDataBoardUI.UIData());
			this.allowLastMove = new VP<Com.MyBool>(this, (byte)Property.allowLastMove, Com.MyBool.None);
			this.hintUI = new VP<HintUI.UIData>(this, (byte)Property.hintUI, new HintUI.UIData());
			this.allowInput = new VP<bool>(this, (byte)Property.allowInput, false);
			this.turn = new VP<TurnUI.UIData>(this, (byte)Property.turn, new TurnUI.UIData());
			this.requestChangeUseRule = new VP<RequestChangeUseRuleUI.UIData>(this, (byte)Property.requestChangeUseRule, new RequestChangeUseRuleUI.UIData());
		}

		#endregion

		public static bool IsAllowInput(Data data)
		{
			bool gameDataUIDataAllowInput = false;
			{
				if (data != null) {
					GameDataUI.UIData gameDataUIData = data.findDataInParent<GameDataUI.UIData> ();
					if (gameDataUIData != null) {
						gameDataUIDataAllowInput = gameDataUIData.allowInput.v;
					} else {
						Debug.LogError ("gameDataUIData null: " + data);
					}
				} else {
					Debug.LogError ("data null: " + data);
				}
			}
			return gameDataUIDataAllowInput;
		}

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// hintUI
				if (!isProcess) {
					HintUI.UIData hintUI = this.hintUI.v;
					if (hintUI != null) {
						isProcess = hintUI.processEvent (e);
					} else {
						Debug.LogError ("hintUI null: " + this);
					}
				}
				// requestChangeUseRule
				if (!isProcess) {
					RequestChangeUseRuleUI.UIData requestChangeUseRule = this.requestChangeUseRule.v;
					if (requestChangeUseRule != null) {
						isProcess = requestChangeUseRule.processEvent (e);
					} else {
						Debug.LogError ("requestChangeUseRule null: " + this);
					}
				}
				// board
				if (!isProcess) {
					GameDataBoardUI.UIData board = this.board.v;
					if (board != null) {
						isProcess = board.processEvent (e);
					} else {
						Debug.LogError ("board null: " + this);
					}
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region Update

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				GameData gameData = this.data.gameData.v.data;
				if (gameData != null) {
					if (this.data != null) {
						// input
						{
							GameDataBoardUI.UIData board = this.data.board.v;
							if (board != null) {
								board.gameData.v = new ReferenceData<GameData> (gameData);
							} else {
								Debug.LogError ("board null: " + this);
							}
						}
						// HintData
						{
							HintUI.UIData hintUI = this.data.hintUI.v;
							if (hintUI != null) {
								hintUI.gameData.v = new ReferenceData<GameData> (gameData);
							} else {
								Debug.LogError ("hintUI null: " + this);
							}
						}
						// Turn
						{
							TurnUI.UIData turnUIData = this.data.turn.v;
							if (turnUIData != null) {
								turnUIData.turn.v = new ReferenceData<Turn> (gameData.turn.v);
							} else {
								Debug.LogError ("turnUIData null: " + this);
							}
						}
						// requestChangeUseRule
						{
							RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = this.data.requestChangeUseRule.v;
							if (requestChangeUseRuleUIData != null) {
								requestChangeUseRuleUIData.requestChangeUseRule.v = new ReferenceData<RequestChangeUseRule> (gameData.requestChangeUseRule.v);
							} else {
								Debug.LogError ("requestChangeUseRuleUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					Debug.LogError ("gameData null: " + this);
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

	public GameDataBoardUI boardPrefab;

	public Transform content;

	public TurnUI turnUI;

	public Transform hintContainer;
	public HintUI hintPrefab;

	public RequestChangeUseRuleUI requestChangeUseRulePrefab;
	public Transform requestChangeUseRuleContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.gameData.allAddCallBack (this);
				uiData.board.allAddCallBack (this);
				uiData.hintUI.allAddCallBack (this);
				uiData.turn.allAddCallBack (this);
				uiData.requestChangeUseRule.allAddCallBack (this);
			}
			// Update
			{
				UpdateUtils.makeUpdate<GameDataUIAllowInputUpdate, UIData> (uiData, this.transform);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is GameData) {
				dirty = true;
				return;
			}
			if (data is GameDataBoardUI.UIData) {
				GameDataBoardUI.UIData boardData = data as GameDataBoardUI.UIData;
				// UI
				{
					UIUtils.Instantiate (boardData, boardPrefab, content);
				}
				dirty = true;
				return;
			}
			if (data is HintUI.UIData) {
				HintUI.UIData hintData = data as HintUI.UIData;
				// UI
				{
					UIUtils.Instantiate (hintData, hintPrefab, hintContainer);
				}
				dirty = true;
				return;
			}
			if (data is TurnUI.UIData) {
				TurnUI.UIData subUIData = data as TurnUI.UIData;
				// UI
				{
					if (turnUI != null) {
						turnUI.setData (subUIData);
					} else {
						Debug.LogError ("turnUI null: " + this);
					}
				}
				dirty = true;
				return;
			}
			if (data is RequestChangeUseRuleUI.UIData) {
				RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = data as RequestChangeUseRuleUI.UIData;
				// UI
				{
					UIUtils.Instantiate (requestChangeUseRuleUIData, requestChangeUseRulePrefab, requestChangeUseRuleContainer);
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
			// Child
			{
				uiData.gameData.allRemoveCallBack (this);
				uiData.board.allRemoveCallBack (this);
				uiData.hintUI.allRemoveCallBack (this);
				uiData.turn.allRemoveCallBack (this);
				uiData.requestChangeUseRule.allRemoveCallBack (this);
			}
			// Update
			{
				uiData.removeCallBackAndDestroy (typeof(GameDataUIAllowInputUpdate));
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is GameData) {
				return;
			}
			if (data is GameDataBoardUI.UIData) {
				GameDataBoardUI.UIData boardData = data as GameDataBoardUI.UIData;
				// UI
				{
					boardData.removeCallBackAndDestroy (typeof(GameDataBoardUI));
				}
				return;
			}
			if (data is HintUI.UIData) {
				HintUI.UIData hintData = data as HintUI.UIData;
				// UI
				{
					hintData.removeCallBackAndDestroy (typeof(HintUI));
				}
				return;
			}
			if (data is TurnUI.UIData) {
				TurnUI.UIData subUIData = data as TurnUI.UIData;
				// UI
				{
					if (this.turnUI != null) {
						if (this.turnUI.data == subUIData) {
							this.turnUI.setData (null);
						} else {
							Debug.LogError ("why different: " + this);
						}
					} else {
						Debug.LogError ("turnUI null: " + this);
					}
				}
				return;
			}
			if (data is RequestChangeUseRuleUI.UIData) {
				RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = data as RequestChangeUseRuleUI.UIData;
				// UI
				{
					requestChangeUseRuleUIData.removeCallBackAndDestroy (typeof(RequestChangeUseRuleUI));
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
			case UIData.Property.gameData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.board:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.allowLastMove:
				break;
			case UIData.Property.hintUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.allowInput:
				break;
			case UIData.Property.turn:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.requestChangeUseRule:
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
		// Child
		{
			if (wrapProperty.p is GameData) {
				switch ((GameData.Property)wrapProperty.n) {
				case GameData.Property.gameType:
					break;
				case GameData.Property.useRule:
					break;
				case GameData.Property.requestChangeUseRule:
					dirty = true;
					break;
				case GameData.Property.turn:
					dirty = true;
					break;
				case GameData.Property.timeControl:
					break;
				case GameData.Property.lastMove:
					break;
				case GameData.Property.state:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is GameDataBoardUI.UIData) {
				return;
			}
			if (wrapProperty.p is HintUI.UIData) {
				return;
			}
			if (wrapProperty.p is TurnUI.UIData) {
				return;
			}
			if (wrapProperty.p is RequestChangeUseRuleUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}