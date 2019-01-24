using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewSaveGameUI : UIBehavior<ViewSaveGameUI.UIData>
{

	#region UIData

	public class UIData : ViewSaveDataUI.UIData.Sub
	{

		public VP<ReferenceData<Game>> game;

		public VP<GamePlayerListUI.UIData> gamePlayerList;

		public VP<GameDataUI.UIData> gameDataUIData;

		public VP<ChatRoomUI.UIData> chatRoom;

		public VP<ViewSaveGameHistoryUI.UIData> history;

		#region Constructor

		public enum Property
		{
			game,
			gamePlayerList,
			gameDataUIData,
			chatRoom,
			history
		}

		public UIData() : base()
		{
			this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
			this.gamePlayerList = new VP<GamePlayerListUI.UIData>(this, (byte)Property.gamePlayerList, new GamePlayerListUI.UIData());
			// gameUIData
			{
				this.gameDataUIData = new VP<GameDataUI.UIData>(this, (byte)Property.gameDataUIData, new GameDataUI.UIData());
				// child
				{
					this.gameDataUIData.v.hintUI.v = null;
					this.gameDataUIData.v.allowInput.v = false;
				}
			}
			// chatRoom
			{
				this.chatRoom = new VP<ChatRoomUI.UIData>(this, (byte)Property.chatRoom, new ChatRoomUI.UIData());
				this.chatRoom.v.canSendMessage.v = false;
			}
			this.history = new VP<ViewSaveGameHistoryUI.UIData>(this, (byte)Property.history, new ViewSaveGameHistoryUI.UIData());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Game;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// history
				if (!isProcess) {
					ViewSaveGameHistoryUI.UIData history = this.history.v;
					if (history != null) {
						isProcess = history.processEvent (e);
					} else {
						Debug.LogError ("history null: " + this);
					}
				}
				// chatRoom
				if (!isProcess) {
					ChatRoomUI.UIData chatRoom = this.chatRoom.v;
					if (chatRoom != null) {
						isProcess = chatRoom.processEvent (e);
					} else {
						Debug.LogError ("chatRoom null: " + this);
					}
				}
				// gamePlayerList
				if (!isProcess) {
					GamePlayerListUI.UIData gamePlayerList = this.gamePlayerList.v;
					if (gamePlayerList != null) {
						isProcess = gamePlayerList.processEvent (e);
					} else {
						Debug.LogError ("gamePlayerList null: " + this);
					}
				}
				// gameDataUIData
				if (!isProcess) {
					GameDataUI.UIData gameDataUIData = this.gameDataUIData.v;
					if (gameDataUIData != null) {
						isProcess = gameDataUIData.processEvent (e);
					} else {
						Debug.LogError ("gameDataUIData null: " + this);
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
				Game game = this.data.game.v.data;
				if (game != null) {
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
						if (this.data.gameDataUIData.v != null) {
							this.data.gameDataUIData.v.gameData.v = new ReferenceData<GameData> (game.gameData.v);
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
					// history
					{
						ViewSaveGameHistoryUI.UIData viewSaveGameHistoryUIData = this.data.history.v;
						if (viewSaveGameHistoryUIData != null) {
							viewSaveGameHistoryUIData.history.v = new ReferenceData<History> (game.history.v);
						} else {
							Debug.LogError ("viewSaveGameHistoryUIData null: " + this);
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

	public GamePlayerListUI gamePlayerListPrefab;
	public Transform gamePlayerListContainer;

	public GameDataUI gameDataUIDataPrefab;
	public Transform gameDataUIDataContainer;

	public ChatRoomUI chatRoomPrefab;
	public Transform chatRoomContainer;

	public ViewSaveGameHistoryUI viewSaveGameHistoryPrefab;
	public Transform viewSaveGameHistoryContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.game.allAddCallBack (this);
				uiData.gamePlayerList.allAddCallBack (this);
				uiData.gameDataUIData.allAddCallBack (this);
				uiData.chatRoom.allAddCallBack (this);
				uiData.history.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Game) {
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
					UIUtils.Instantiate (gameDataUIData, gameDataUIDataPrefab, gameDataUIDataContainer);
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
			if (data is ViewSaveGameHistoryUI.UIData) {
				ViewSaveGameHistoryUI.UIData viewSaveGameHistoryUIData = data as ViewSaveGameHistoryUI.UIData;
				// UI
				{
					UIUtils.Instantiate (viewSaveGameHistoryUIData, viewSaveGameHistoryPrefab, viewSaveGameHistoryContainer);
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
				uiData.game.allRemoveCallBack (this);
				uiData.gamePlayerList.allRemoveCallBack (this);
				uiData.gameDataUIData.allRemoveCallBack (this);
				uiData.chatRoom.allRemoveCallBack (this);
				uiData.history.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Game) {
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
				GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
				// UI
				{
					gameDataUIData.removeCallBackAndDestroy (typeof(GameDataUI));
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
			if (data is ViewSaveGameHistoryUI.UIData) {
				ViewSaveGameHistoryUI.UIData viewSaveGameHistoryUIData = data as ViewSaveGameHistoryUI.UIData;
				// UI
				{
					viewSaveGameHistoryUIData.removeCallBackAndDestroy (typeof(ViewSaveGameHistoryUI));
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
			case UIData.Property.gamePlayerList:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.gameDataUIData:
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
			case UIData.Property.history:
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
			if (wrapProperty.p is Game) {
				switch ((Game.Property)wrapProperty.n) {
				case Game.Property.gamePlayers:
					break;
				case Game.Property.requestDraw:
					break;
				case Game.Property.state:
					break;
				case Game.Property.gameData:
					dirty = true;
					break;
				case Game.Property.history:
					dirty = true;
					break;
				case Game.Property.gameAction:
					break;
				case Game.Property.undoRedoRequest:
					break;
				case Game.Property.chatRoom:
					break;
				case Game.Property.animationData:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is GamePlayerListUI.UIData) {
				return;
			}
			if (wrapProperty.p is GameDataUI.UIData) {
				return;
			}
			if (wrapProperty.p is ChatRoomUI.UIData) {
				return;
			}
			if (wrapProperty.p is ViewSaveGameHistoryUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}