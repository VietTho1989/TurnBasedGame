using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class TypingUI : UIBehavior<TypingUI.UIData>
{

	#region UIData

	public class UIData : Data
	{
		public VP<ReferenceData<Typing>> typing;

		#region Constructor

		public enum Property
		{
			typing
		}

		public UIData() : base()
		{
			this.typing = new VP<ReferenceData<Typing>>(this, (byte)Property.typing, new ReferenceData<Typing>(null));
		}

		#endregion
	}

	#endregion

	#region Refresh

	public Text tvContent;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Typing typing = this.data.typing.v.data;
				if (typing != null) {
					// tvContent
					if (tvContent != null) {
						if (typing.isEnable.v) {
							ChatRoom chatRoom = typing.findDataInParent<ChatRoom> ();
							if (chatRoom != null) {
								// Find who is typing
								List<Human> whoTypings = new List<Human> ();
								{
									uint yourUserId = Server.getProfileUserId (typing);
									for (int i = 0; i < typing.typingPlayers.vs.Count; i++) {
										TypingPlayer typingPlayer = typing.typingPlayers.vs [i];
										if (typingPlayer.playerId.v != yourUserId) {
											Human human = chatRoom.findHuman (typingPlayer.playerId.v);
											if (human != null) {
												whoTypings.Add (human);
											} else {
												Debug.LogError ("human null");
											}
										} else {
											// Debug.LogError ("the same userId: " + typingPlayer);
										}
									}
								}
								// Process
								if (whoTypings.Count > 0) {
									StringBuilder builder = new StringBuilder ();
									{
										for (int i = 0; i < whoTypings.Count; i++) {
											Human human = whoTypings [i];
											builder.Append (human.getPlayerName ());
											if (i < whoTypings.Count - 1) {
												builder.Append (", ");
											}
										}
										builder.Append (" typing...");
									}
									tvContent.text = builder.ToString ();
								} else {
									tvContent.text = "";
								}
							} else {
								Debug.LogError ("chatRoom null");
							}
						} else {
							tvContent.text = "";
						}
					} else {
						Debug.LogError ("tvContent null");
					}
				} else {
					Debug.LogError ("typing null");
				}
			} else {
				// Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public TypingSendUpdate typingSendUpdate;
	private ChatRoom chatRoom =  null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			{
				uiData.typing.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		if (data is Typing) {
			Typing typing = data as Typing;
			// Parent
			{
				DataUtils.addParentCallBack (typing, this, ref this.chatRoom);
			}
			// Child
			{
				typing.typingPlayers.allAddCallBack (this);
			}
			// TypingSendUpdate
			{
				if (typingSendUpdate != null) {
					TypingSendUpdate.TypingSendData typingSendData = new TypingSendUpdate.TypingSendData ();
					{
						typingSendData.typing.v = new ReferenceData<Typing> (typing);
					}
					typingSendUpdate.setData (typingSendData);
				} else {
					Debug.LogError ("typingSendUpdate null");
				}
			}
			dirty = true;
			return;
		}
		// ChatRoom
		{
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Child
				{
					chatRoom.players.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.account.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Account) {
					dirty = true;
					return;
				}
			}
		}
		if (data is TypingPlayer) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			{
				uiData.typing.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		if (data is Typing) {
			Typing typing = data as Typing;
			// Parent
			{
				DataUtils.removeParentCallBack (typing, this, ref this.chatRoom);
			}
			// Child
			{
				typing.typingPlayers.allRemoveCallBack (this);
			}
			// TypingSendUpdate
			{
				if (typingSendUpdate != null) {
					TypingSendUpdate.TypingSendData typingSendData = new TypingSendUpdate.TypingSendData ();
					{
						typingSendData.typing.v = new ReferenceData<Typing> (null);
					}
					typingSendUpdate.setData (typingSendData);
				} else {
					Debug.LogError ("typingSendUpdate null");
				}
			}
			return;
		}
		// ChatRoom
		{
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Child
				{
					chatRoom.players.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is Human) {
					Human human = data as Human;
					// Child
					{
						human.account.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Account) {
					return;
				}
			}
		}
		if (data is TypingPlayer) {
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
			case UIData.Property.typing:
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
		if (wrapProperty.p is Typing) {
			switch ((Typing.Property)wrapProperty.n) {
			case Typing.Property.isEnable:
				dirty = true;
				break;
			case Typing.Property.stopDuration:
				break;
			case Typing.Property.nextReceiveTime:
				break;
			case Typing.Property.typingPlayers:
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
		// ChatRoom
		{
			if (wrapProperty.p is ChatRoom) {
				switch ((ChatRoom.Property)wrapProperty.n) {
				case ChatRoom.Property.players:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case ChatRoom.Property.messages:
					break;
				case ChatRoom.Property.typing:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						dirty = true;
						break;
					case Human.Property.account:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Human.Property.state:
						break;
					case Human.Property.email:
						break;
					case Human.Property.phoneNumber:
						break;
					case Human.Property.status:
						break;
					case Human.Property.birthday:
						break;
					case Human.Property.sex:
						break;
					case Human.Property.connection:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is Account) {
					Account.OnUpdateSyncAccount (wrapProperty, this);
					return;
				}
			}
		}
		if (wrapProperty.p is TypingPlayer) {
			switch ((TypingPlayer.Property)wrapProperty.n) {
			case TypingPlayer.Property.playerId:
				dirty = true;
				break;
			case TypingPlayer.Property.state:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}