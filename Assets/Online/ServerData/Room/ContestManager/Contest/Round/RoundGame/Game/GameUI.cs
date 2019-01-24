using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameState;
using Record;

public class GameUI : UIBehavior<GameUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		
		public VP<ReferenceData<Game>> game;

		#region isReplay

		public VP<bool> isReplay;

		public static bool IsReplay(Data data)
		{
			if (data != null) {
				GameUI.UIData gameUIData = data.findDataInParent<GameUI.UIData> ();
				if (gameUIData != null) {
					return gameUIData.isReplay.v;
				} else {
					Debug.LogError ("gameUIData null: " + data);
				}
			} else {
				Debug.LogError ("data null: " + data);
			}
			return false;
		}

		#endregion

		public VP<StateUI.UIData> stateUI;

		public VP<GamePlayerListUI.UIData> gamePlayerList;

		public VP<GameDataUI.UIData> gameUIData;

		public VP<UndoRedoRequestUI.UIData> undoRedoRequestUIData;

		public VP<GameActionsUI.UIData> gameActionsUI;

		public VP<ChatRoomUI.UIData> chatRoom;

		public VP<RequestDrawUI.UIData> requestDraw;

		#region save

		public VP<SaveUI.UIData> saveUIData;

		public VP<GameHistoryUI.UIData> gameHistoryUIData;

		public VP<DataRecordTaskUI.UIData> dataRecordTaskUIData;

		#endregion

		#region Constructor

		public enum Property
		{
			game,
			isReplay,
			stateUI,
			gamePlayerList,
			gameDataUI,
			undoRedoRequestUIData,
			gameActionsUI,
			chatRoom,
			requestDraw,
			saveUIData,
			gameHistoryUIData,
			dataRecordTaskUIData
		}

		public UIData() : base()
		{
			this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
			this.isReplay = new VP<bool>(this, (byte)Property.isReplay, false);
			this.stateUI = new VP<StateUI.UIData>(this, (byte)Property.stateUI, new StateUI.UIData());
			this.gamePlayerList = new VP<GamePlayerListUI.UIData>(this, (byte)Property.gamePlayerList, new GamePlayerListUI.UIData());
			this.gameUIData =new VP<GameDataUI.UIData>(this, (byte)Property.gameDataUI, new GameDataUI.UIData());
			this.undoRedoRequestUIData = new VP<UndoRedoRequestUI.UIData>(this, (byte)Property.undoRedoRequestUIData, new UndoRedoRequestUI.UIData());
			this.gameActionsUI = new VP<GameActionsUI.UIData>(this, (byte)Property.gameActionsUI, new GameActionsUI.UIData());
			this.chatRoom = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoom, new ChatRoomUI.UIData());
			this.requestDraw = new VP<RequestDrawUI.UIData>(this, (byte)Property.requestDraw, new RequestDrawUI.UIData());
			this.saveUIData = new VP<SaveUI.UIData>(this, (byte)Property.saveUIData, null);
			this.gameHistoryUIData = new VP<GameHistoryUI.UIData>(this, (byte)Property.gameHistoryUIData, new GameHistoryUI.UIData());
			// dataRecordTaskUIData
			{
				this.dataRecordTaskUIData = new VP<DataRecordTaskUI.UIData>(this, (byte)Property.dataRecordTaskUIData, new DataRecordTaskUI.UIData());
				this.dataRecordTaskUIData.v.dataRecordTask.v = new ReferenceData<DataRecordTask>(new DataRecordTask());
			}
		}

		#endregion

		public void reset()
		{
			this.saveUIData.v = null;
		}

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// dataRecordTaskUIData
				if (!isProcess) {
					DataRecordTaskUI.UIData dataRecordTaskUIData = this.dataRecordTaskUIData.v;
					if (dataRecordTaskUIData != null) {
						isProcess = dataRecordTaskUIData.processEvent (e);
					} else {
						Debug.LogError ("dataRecordTaskUIData null: " + this);
					}
				}
				// gameHistoryUIData
				if (!isProcess) {
					GameHistoryUI.UIData gameHistoryUIData = this.gameHistoryUIData.v;
					if (gameHistoryUIData != null) {
						isProcess = gameHistoryUIData.processEvent (e);
					} else {
						Debug.LogError ("gameHistoryUIData: " + this);
					}
				}
				// saveUIData
				if (!isProcess) {
					SaveUI.UIData saveUIData = this.saveUIData.v;
					if (saveUIData != null) {
						isProcess = saveUIData.processEvent (e);
					} else {
						Debug.LogError ("saveUIData null: " + this);
					}
				}
				// gameUIData
				if (!isProcess) {
					GameDataUI.UIData gameUIData = this.gameUIData.v;
					if (gameUIData != null) {
						isProcess = gameUIData.processEvent (e);
					} else {
						Debug.LogError ("gameUIData null: " + this);
					}
				}
			}
			return isProcess;
		}

	}

	#endregion

	#region Update

	#region txt

	public Text tvSave;
	public static readonly TxtLanguage txtSave = new TxtLanguage();

	static GameUI()
	{
		txtSave.add (Language.Type.vi, "Lưu Lại");
	}

	#endregion

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Game game = this.data.game.v.data;
				if (game != null) {
					// stateUI
					{
						StateUI.UIData stateUIData = this.data.stateUI.v;
						if (stateUIData != null) {
							stateUIData.state.v = new ReferenceData<State> (game.state.v);
						} else {
							Debug.LogError ("stateUIData null: " + this);
						}
					}
					// gamePlayerList
					{
						if (this.data.gamePlayerList.v != null) {
							this.data.gamePlayerList.v.game.v = new ReferenceData<Game> (game);
						} else {
							Debug.LogError ("gamePlayerList null: " + this);
						}
					}
					// gameUIData
					{
						if (this.data.gameUIData.v != null) {
							this.data.gameUIData.v.gameData.v = new ReferenceData<GameData> (game.gameData.v);
						}
					}
					// UndoRedoRequest
					{
						if (this.data.undoRedoRequestUIData.v != null) {
							this.data.undoRedoRequestUIData.v.undoRedoRequest.v = new ReferenceData<UndoRedoRequest> (game.undoRedoRequest.v);
						}
					}
					// GameAction
					{
						if (this.data.gameActionsUI.v != null) {
							this.data.gameActionsUI.v.gameAction.v = new ReferenceData<GameAction> (game.gameAction.v);
						} else {
							Debug.LogError ("gameActionsUI null: " + this);
						}
					}
					// chatRoom
					{
						ChatRoomUI.UIData chatRoomUIData = this.data.chatRoom.v;
						if (chatRoomUIData != null) {
							chatRoomUIData.chatRoom.v = new ReferenceData<ChatRoom> (game.chatRoom.v);
						} else {
							Debug.LogError ("chatRoomUIData null: " + this);
						}
					}
					// requestDraw
					{
						RequestDrawUI.UIData requestDrawUIData = this.data.requestDraw.v;
						if (requestDrawUIData != null) {
							requestDrawUIData.requestDraw.v = new ReferenceData<RequestDraw> (game.requestDraw.v);
						} else {
							Debug.LogError ("requestDrawUIData null: " + this);
						}
					}
					// saveUIData
					{
						SaveUI.UIData saveUIData = this.data.saveUIData.v;
						if (saveUIData != null) {
							saveUIData.needSaveData.v = new ReferenceData<Data> (game);
						} else {
							// Debug.LogError ("saveUIData null: " + this);
						}
					}
					// gameHistoryUIData
					{
						GameHistoryUI.UIData gameHistoryUIData = this.data.gameHistoryUIData.v;
						if (gameHistoryUIData != null) {
							gameHistoryUIData.history.v = new ReferenceData<History>(game.history.v);
						} else {
							Debug.LogError ("gameHistoryUIData null: " + this);
						}
					}
					// dataRecordTaskUIData
					{
						DataRecordTaskUI.UIData dataRecordTaskUIData = this.data.dataRecordTaskUIData.v;
						if (dataRecordTaskUIData != null) {
							dataRecordTaskUIData.dataRecordTask.v.data.needRecordData.v = new ReferenceData<Data> (game);
							dataRecordTaskUIData.saveRecordContainer.v = this.dataRecordSaveContainer;
						} else {
							Debug.LogError ("dataRecordTaskUIData null: " + this);
						}
					}
				} else {
					Debug.LogError ("game null: " + this);
				}
				// txt
				{
					if (tvSave != null) {
						tvSave.text = txtSave.get ("Save");
					} else {
						Debug.LogError ("tvSave null: " + this);
					}
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public StateUI stateUIPrefab;
	public Transform stateUIContainer;

	public GamePlayerListUI gamePlayerListPrefab;
	public Transform gamePlayerListContainer;

	public GameDataUI gameDataUIPrefab;
	public Transform gameDataUIContainer;

	public UndoRedoRequestUI undoRedoRequestPrefab;
	public Transform undoRedoRequestContainer;

	public GameActionsUI gameActionsPrefab;
	public Transform gameActionsContainer;

	public ChatRoomUI chatRoomPrefab;
	public Transform chatRoomContainer;

	public RequestDrawUI requestDrawPrefab;
	public Transform requestDrawContainer;

	public SaveUI saveUIPrefab;
	public Transform saveUIContainer;

	public GameHistoryUI gameHistoryUIPrefab;
	public Transform gameHistoryUIContainer;
	public Transform viewSaveDataUIContainer;

	public DataRecordTaskUI dataRecordTaskUIPrefab;
	public Transform dataRecordTaskUIContainer;
	public Transform dataRecordSaveContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.game.allAddCallBack (this);
				uiData.stateUI.allAddCallBack (this);
				uiData.gamePlayerList.allAddCallBack (this);
				uiData.gameUIData.allAddCallBack (this);
				uiData.undoRedoRequestUIData.allAddCallBack (this);
				uiData.gameActionsUI.allAddCallBack (this);
				uiData.chatRoom.allAddCallBack (this);
				uiData.requestDraw.allAddCallBack (this);
				uiData.saveUIData.allAddCallBack (this);
				uiData.gameHistoryUIData.allAddCallBack (this);
				uiData.dataRecordTaskUIData.allAddCallBack (this);
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
			if (data is Game) {
				// reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				dirty = true;
				return;
			}
			if (data is StateUI.UIData) {
				StateUI.UIData stateUIData = data as StateUI.UIData;
				// UI
				{
					UIUtils.Instantiate (stateUIData, stateUIPrefab, stateUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is GamePlayerListUI.UIData) {
				GamePlayerListUI.UIData gamePlayerListUIData = data as GamePlayerListUI.UIData;
				// UI
				{
					UIUtils.Instantiate (gamePlayerListUIData, gamePlayerListPrefab, gamePlayerListContainer);
				}
				dirty = true;
				return;
			}
			if (data is GameDataUI.UIData) {
				GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
				// UI
				{
					UIUtils.Instantiate (gameDataUIData, gameDataUIPrefab, gameDataUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is UndoRedoRequestUI.UIData) {
				UndoRedoRequestUI.UIData subUIData = data as UndoRedoRequestUI.UIData;
				// UI
				{
					UIUtils.Instantiate (subUIData, undoRedoRequestPrefab, undoRedoRequestContainer);
				}
				return;
			}
			if (data is GameActionsUI.UIData) {
				GameActionsUI.UIData gameActionsUIData = data as GameActionsUI.UIData;
				// UI
				{
					UIUtils.Instantiate (gameActionsUIData, gameActionsPrefab, gameActionsContainer);
				}
				dirty = true;
				return;
			}
			if (data is ChatRoomUI.UIData) {
				ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
				// UI
				{
					UIUtils.Instantiate (chatRoomUIData, chatRoomPrefab, chatRoomContainer);
				}
				dirty = true;
				return;
			}
			if (data is RequestDrawUI.UIData) {
				RequestDrawUI.UIData requestDrawUIData = data as RequestDrawUI.UIData;
				// UI
				{
					UIUtils.Instantiate (requestDrawUIData, requestDrawPrefab, requestDrawContainer);
				}
				dirty = true;
				return;
			}
			if (data is SaveUI.UIData) {
				SaveUI.UIData saveUIData = data as SaveUI.UIData;
				// UI
				{
					UIUtils.Instantiate (saveUIData, saveUIPrefab, saveUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is GameHistoryUI.UIData) {
				GameHistoryUI.UIData gameHistoryUIData = data as GameHistoryUI.UIData;
				// UI
				{
					UIUtils.Instantiate (gameHistoryUIData, gameHistoryUIPrefab, gameHistoryUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is DataRecordTaskUI.UIData) {
				DataRecordTaskUI.UIData dataRecordTaskUIData = data as DataRecordTaskUI.UIData;
				// UI
				{
					UIUtils.Instantiate (dataRecordTaskUIData, dataRecordTaskUIPrefab, dataRecordTaskUIContainer);
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
				uiData.game.allRemoveCallBack (this);
				uiData.stateUI.allRemoveCallBack (this);
				uiData.gamePlayerList.allRemoveCallBack (this);
				uiData.gameUIData.allRemoveCallBack (this);
				uiData.undoRedoRequestUIData.allRemoveCallBack (this);
				uiData.gameActionsUI.allRemoveCallBack (this);
				uiData.chatRoom.allRemoveCallBack (this);
				uiData.requestDraw.allRemoveCallBack (this);
				uiData.saveUIData.allRemoveCallBack (this);
				uiData.gameHistoryUIData.allRemoveCallBack (this);
				uiData.dataRecordTaskUIData.allRemoveCallBack (this);
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
			if (data is Game) {
				return;
			}
			if (data is StateUI.UIData) {
				StateUI.UIData stateUIData = data as StateUI.UIData;
				// UI
				{
					stateUIData.removeCallBackAndDestroy (typeof(StateUI));
				}
				return;
			}
			if (data is GamePlayerListUI.UIData) {
				GamePlayerListUI.UIData gamePlayerListUIData = data as GamePlayerListUI.UIData;
				// UI
				{
					gamePlayerListUIData.removeCallBackAndDestroy (typeof(GamePlayerListUI));
				}
				return;
			}
			if (data is GameDataUI.UIData) {
				GameDataUI.UIData subUIData = data as GameDataUI.UIData;
				// UI
				{
					subUIData.removeCallBackAndDestroy (typeof(GameDataUI));
				}
				return;
			}
			if (data is UndoRedoRequestUI.UIData) {
				UndoRedoRequestUI.UIData subUIData = data as UndoRedoRequestUI.UIData;
				// UI
				{
					subUIData.removeCallBackAndDestroy (typeof(UndoRedoRequestUI));
				}
				return;
			}
			if (data is GameActionsUI.UIData) {
				GameActionsUI.UIData subUIData = data as GameActionsUI.UIData;
				// UI
				{
					subUIData.removeCallBackAndDestroy (typeof(GameActionsUI));
				}
				return;
			}
			if (data is ChatRoomUI.UIData) {
				ChatRoomUI.UIData chatRoomUIData = data as ChatRoomUI.UIData;
				// UI
				{
					chatRoomUIData.removeCallBackAndDestroy (typeof(ChatRoomUI));
				}
				return;
			}
			if (data is RequestDrawUI.UIData) {
				RequestDrawUI.UIData requestDrawUIData = data as RequestDrawUI.UIData;
				// UI
				{
					requestDrawUIData.removeCallBackAndDestroy (typeof(RequestDrawUI));
				}
				return;
			}
			if (data is SaveUI.UIData) {
				SaveUI.UIData saveUIData = data as SaveUI.UIData;
				// UI
				{
					saveUIData.removeCallBackAndDestroy (typeof(SaveUI));
				}
				return;
			}
			if (data is GameHistoryUI.UIData) {
				GameHistoryUI.UIData gameHistoryUIData = data as GameHistoryUI.UIData;
				// UI
				{
					gameHistoryUIData.removeCallBackAndDestroy (typeof(GameHistoryUI));
				}
				return;
			}
			if (data is DataRecordTaskUI.UIData) {
				DataRecordTaskUI.UIData dataRecordTaskUIData = data as DataRecordTaskUI.UIData;
				// UI
				{
					dataRecordTaskUIData.removeCallBackAndDestroy (typeof(DataRecordTaskUI));
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
			case UIData.Property.game:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.stateUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.gamePlayerList:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.gameDataUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.undoRedoRequestUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.gameActionsUI:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.chatRoom:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.requestDraw:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.saveUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.gameHistoryUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.dataRecordTaskUIData:
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
			if (wrapProperty.p is Game) {
				switch ((Game.Property)wrapProperty.n) {
				case Game.Property.gamePlayers:
					break;
				case Game.Property.requestDraw:
					dirty = true;
					break;
				case Game.Property.state:
					dirty = true;
					break;
				case Game.Property.gameData:
					dirty = true;
					break;
				case Game.Property.history:
					dirty = true;
					break;
				case Game.Property.gameAction:
					dirty = true;
					break;
				case Game.Property.undoRedoRequest:
					dirty = true;
					break;
				case Game.Property.chatRoom:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is StateUI.UIData) {
				return;
			}
			if (wrapProperty.p is GamePlayerListUI.UIData) {
				return;
			}
			if (wrapProperty.p is GameDataUI.UIData) {
				return;
			}
			if (wrapProperty.p is UndoRedoRequestUI.UIData) {
				return;
			}
			if (wrapProperty.p is GameActionsUI.UIData) {
				return;
			}
			if (wrapProperty.p is ChatRoomUI.UIData) {
				return;
			}
			if (wrapProperty.p is RequestDrawUI.UIData) {
				return;
			}
			if (wrapProperty.p is SaveUI.UIData) {
				return;
			}
			if (wrapProperty.p is GameHistoryUI.UIData) {
				return;
			}
			if (wrapProperty.p is DataRecordTaskUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnSave()
	{
		if (this.data != null) {
			Game game = this.data.game.v.data;
			if (game != null) {
				SaveUI.UIData saveUIData = this.data.saveUIData.newOrOld<SaveUI.UIData> ();
				{

				}
				this.data.saveUIData.v = saveUIData;
			} else {
				Debug.LogError ("game null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}