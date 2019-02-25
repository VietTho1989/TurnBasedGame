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
			this.requestChangeUseRule = new VP<RequestChangeUseRuleUI.UIData>(this, (byte)Property.requestChangeUseRule, null);
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
						// Debug.LogError ("gameDataUIData null: " + data);
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

    #region txt, rect

    static GameDataUI()
    {
        // rect
        {
            // boardRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.2, 0.2); anchorMax: (0.8, 0.8); pivot: (0.5, 0.5);
                // offsetMin: (0.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (0.0, 0.0);
                boardRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                boardRect.anchorMin = new Vector2(0.2f, 0.2f);
                boardRect.anchorMax = new Vector2(0.8f, 0.8f);
                boardRect.pivot = new Vector2(0.5f, 0.5f);
                boardRect.offsetMin = new Vector2(0.0f, 0.0f);
                boardRect.offsetMax = new Vector2(0.0f, 0.0f);
                boardRect.sizeDelta = new Vector2(0.0f, 0.0f);
            }
            // turnRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (-45.0, -40.0); offsetMax: (45.0, 0.0); sizeDelta: (90.0, 40.0);
                turnRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                turnRect.anchorMin = new Vector2(0.5f, 1.0f);
                turnRect.anchorMax = new Vector2(0.5f, 1.0f);
                turnRect.pivot = new Vector2(0.5f, 1.0f);
                turnRect.offsetMin = new Vector2(-45.0f, -40.0f);
                turnRect.offsetMax = new Vector2(45.0f, 0.0f);
                turnRect.sizeDelta = new Vector2(90.0f, 40.0f);
            }
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
                    // input
                    {
                        GameDataBoardUI.UIData board = this.data.board.v;
                        if (board != null)
                        {
                            board.gameData.v = new ReferenceData<GameData>(gameData);
                        }
                        else
                        {
                            Debug.LogError("board null: " + this);
                        }
                    }
                    // HintData
                    {
                        HintUI.UIData hintUI = this.data.hintUI.v;
                        if (hintUI != null)
                        {
                            hintUI.gameData.v = new ReferenceData<GameData>(gameData);
                        }
                        else
                        {
                            Debug.LogError("hintUI null: " + this);
                        }
                    }
                    // Turn
                    {
                        TurnUI.UIData turnUIData = this.data.turn.v;
                        if (turnUIData != null)
                        {
                            turnUIData.turn.v = new ReferenceData<Turn>(gameData.turn.v);
                        }
                        else
                        {
                            Debug.LogError("turnUIData null: " + this);
                        }
                    }
                    // requestChangeUseRule
                    {
                        RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = this.data.requestChangeUseRule.v;
                        if (requestChangeUseRuleUIData != null)
                        {
                            requestChangeUseRuleUIData.requestChangeUseRule.v = new ReferenceData<RequestChangeUseRule>(gameData.requestChangeUseRule.v);
                        }
                        else
                        {
                            Debug.LogError("requestChangeUseRuleUIData null: " + this);
                        }
                    }
                    // UI
                    {
                        UIRectTransform.SetSiblingIndex(this.data.turn.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.board.v, 1);
                        UIRectTransform.SetSiblingIndex(this.data.hintUI.v, 2);
                        UIRectTransform.SetSiblingIndex(this.data.requestChangeUseRule.v, 3);
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
    private static readonly UIRectTransform boardRect = new UIRectTransform();

	public TurnUI turnPrefab;
    private static readonly UIRectTransform turnRect = new UIRectTransform();

	public HintUI hintPrefab;
    private readonly UIRectTransform hintRect = UIConstants.FullParent;

	public RequestChangeUseRuleUI requestChangeUseRulePrefab;

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
					UIUtils.Instantiate (boardData, boardPrefab, this.transform, boardRect);
				}
				dirty = true;
				return;
			}
			if (data is HintUI.UIData) {
				HintUI.UIData hintData = data as HintUI.UIData;
				// UI
				{
					UIUtils.Instantiate (hintData, hintPrefab, this.transform, hintRect);
				}
				dirty = true;
				return;
			}
			if (data is TurnUI.UIData) {
				TurnUI.UIData turnUIData = data as TurnUI.UIData;
				// UI
				{
                    UIUtils.Instantiate(turnUIData, turnPrefab, this.transform, turnRect);
				}
				dirty = true;
				return;
			}
			if (data is RequestChangeUseRuleUI.UIData) {
				RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = data as RequestChangeUseRuleUI.UIData;
				// UI
				{
					UIUtils.Instantiate (requestChangeUseRuleUIData, requestChangeUseRulePrefab, this.transform);
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
				TurnUI.UIData turnUIData = data as TurnUI.UIData;
				// UI
				{
                    turnUIData.removeCallBackAndDestroy(typeof(TurnUI));
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
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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