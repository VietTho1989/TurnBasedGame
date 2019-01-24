using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChatGameMoveContentUI : UIBehavior<ChatGameMoveContentUI.UIData>
{

	#region UIData

	public class UIData : ChatMessageHolder.UIData.Sub
	{

		public VP<ReferenceData<ChatGameMoveContent>> chatGameMoveContent;

		#region Constructor

		public enum Property
		{
			chatGameMoveContent
		}

		public UIData() : base()
		{
			this.chatGameMoveContent = new VP<ReferenceData<ChatGameMoveContent>>(this, (byte)Property.chatGameMoveContent, new ReferenceData<ChatGameMoveContent>(null));
		}

		#endregion

		public override ChatMessage.Content.Type getType ()
		{
			return ChatMessage.Content.Type.GameMove;
		}

	}

	#endregion

	#region Refresh

	public Text tvTime;
	public Text tvContent;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatGameMoveContent chatGameMoveContent = this.data.chatGameMoveContent.v.data;
				if (chatGameMoveContent != null) {
					// content
					{
						if (tvContent != null) {
							Turn turn = chatGameMoveContent.turn.v;
							GameMove gameMove = chatGameMoveContent.gameMove.v;
							if (turn != null && gameMove != null) {
								string strMove = gameMove.getType () + ": " + gameMove.print ();
								tvContent.text = "GameMove: " + strMove + "; Turn: " + turn.turn.v + "; PlayerIndex: " + turn.playerIndex.v
									+ "; GameTurn: " + turn.gameTurn.v;
							} else {
								Debug.LogError ("turn, gameMove null: " + this);
							}
						} else {
							Debug.LogError ("tvContent null: " + this);
						}
					}
					// time
					{
						if (tvTime != null) {
							ChatMessage chatMessage = chatGameMoveContent.findDataInParent<ChatMessage> ();
							if (chatMessage != null) {
								tvTime.text = chatMessage.TimestampAsDateTime.ToString ("HH:mm");
							} else {
								Debug.LogError ("chatMessage null: " + this);
							}
						} else {
							Debug.LogError ("tvTime null: " + this);
						}
					}
				} else {
					// Debug.LogError ("chatGameMoveContent null: " + this);
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

	private ChatMessage chatMessage = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.chatGameMoveContent.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is ChatGameMoveContent) {
				ChatGameMoveContent chatGameMoveContent = data as ChatGameMoveContent;
				// Parent
				{
					DataUtils.addParentCallBack (chatGameMoveContent, this, ref this.chatMessage);
				}
				// Child
				{
					chatGameMoveContent.turn.allAddCallBack (this);
					chatGameMoveContent.gameMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is ChatMessage) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is Turn) {
					dirty = true;
					return;
				}
				if (data is GameMove) {
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
			// Child
			{
				uiData.chatGameMoveContent.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is ChatGameMoveContent) {
				ChatGameMoveContent chatGameMoveContent = data as ChatGameMoveContent;
				// Parent
				{
					DataUtils.removeParentCallBack (chatGameMoveContent, this, ref this.chatMessage);
				}
				// Child
				{
					chatGameMoveContent.turn.allRemoveCallBack (this);
					chatGameMoveContent.gameMove.allRemoveCallBack (this);
				}
				return;
			}
			// Parent
			{
				if (data is ChatMessage) {
					return;
				}
			}
			// Child
			{
				if (data is Turn) {
					return;
				}
				if (data is GameMove) {
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if(WrapProperty.checkError(wrapProperty)){
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.chatGameMoveContent:
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
			if (wrapProperty.p is ChatGameMoveContent) {
				switch ((ChatGameMoveContent.Property)wrapProperty.n) {
				case ChatGameMoveContent.Property.turn:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ChatGameMoveContent.Property.gameMove:
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
			// Parent
			{
				if (wrapProperty.p is ChatMessage) {
					switch ((ChatMessage.Property)wrapProperty.n) {
					case ChatMessage.Property.state:
						dirty = true;
						break;
					case ChatMessage.Property.time:
						dirty = true;
						break;
					case ChatMessage.Property.content:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
				if (wrapProperty.p is Turn) {
					switch ((Turn.Property)wrapProperty.n) {
					case Turn.Property.turn:
						dirty = true;
						break;
					case Turn.Property.playerIndex:
						dirty = true;
						break;
					case Turn.Property.gameTurn:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is GameMove) {
					dirty = true;
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}