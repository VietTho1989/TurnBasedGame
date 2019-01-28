﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class ChatRoomBtnLoadMoreUI : UIBehavior<ChatRoomBtnLoadMoreUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<ChatRoom>> chatRoom;

		#region state

		public enum State
		{
			None,
			Request,
			Wait
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			chatRoom,
			state
		}

		public UIData() : base()
		{
			this.chatRoom = new VP<ReferenceData<ChatRoom>>(this, (byte)Property.chatRoom, new ReferenceData<ChatRoom>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public void reset()
		{
			this.state.v = State.None;
		}

	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtLoadMore = new TxtLanguage();
	public static readonly TxtLanguage txtCancelLoadMore = new TxtLanguage();
	public static readonly TxtLanguage txtLoadingMore = new TxtLanguage ();

	static ChatRoomBtnLoadMoreUI()
	{
		txtLoadMore.add (Language.Type.vi, "Tải Thêm");
		txtCancelLoadMore.add (Language.Type.vi, "Huỷ tải thêm");
		txtLoadingMore.add (Language.Type.vi, "Đang tải thêm...");
	}

	#endregion

	public GameObject contentContainer = null;

	public Button btnLoadMore;
	public Text tvLoadMore;

	private bool needReset = false;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatRoom chatRoom = this.data.chatRoom.v.data;
				if (chatRoom != null) {
					// reset
					{
						if (needReset) {
							needReset = false;
							this.data.state.v = UIData.State.None;
						}
					}
					uint profileId = Server.getProfileUserId (chatRoom);
					// find can load more
					bool canLoadMore = false;
					{
						Server server = chatRoom.findDataInParent<Server> ();
						if (server != null && server.type.v == Server.Type.Client) {
							ChatViewer chatViewer = chatRoom.findChatViewer (profileId);
							if (chatViewer != null) {
								if (chatViewer.minViewId.v > 0) {
									canLoadMore = true;
								}
							} else {
								Debug.LogError ("chatViewer null: " + this);
								canLoadMore = true;
							}
						}
					}
					// process
					if (canLoadMore) {
						// Task
						{
							switch (this.data.state.v) {
							case UIData.State.None:
								{
									destroyRoutine (wait);
								}
								break;
							case UIData.State.Request:
								{
									destroyRoutine (wait);
									if (Server.IsServerOnline (chatRoom)) {
										chatRoom.requestLoadMore (profileId, ChatRoom.LoadMorePerRequest);
										this.data.state.v = UIData.State.Wait;
									} else {
										Debug.LogError ("server not online");
									}
								}
								break;
							case UIData.State.Wait:
								{
									if (Server.IsServerOnline (chatRoom)) {
										startRoutine (ref this.wait, TaskWait ());
									} else {
										destroyRoutine (wait);
										this.data.state.v = UIData.State.None;
									}
								}
								break;
							default:
								Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
								break;
							}
						}
						// UI
						{
							// contentContainer
							if (contentContainer != null) {
								contentContainer.SetActive (true);
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
							// btnLoadMore, tvLoadMore
							if (btnLoadMore != null && tvLoadMore != null) {
								switch (this.data.state.v) {
								case UIData.State.None:
									{
										btnLoadMore.enabled = true;
										tvLoadMore.text = txtLoadMore.get ("Load More");
									}
									break;
								case UIData.State.Request:
									{
										btnLoadMore.enabled = true;
										tvLoadMore.text = txtCancelLoadMore.get ("Cancel Load More");
									}
									break;
								case UIData.State.Wait:
									{
										btnLoadMore.enabled = false;
										tvLoadMore.text = txtLoadingMore.get ("Loading More...");
									}
									break;
								default:
									Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("btnLoadMore, tvLoadMore null: " + this);
							}
						}
					} else {
						// Task
						{
							this.data.state.v = UIData.State.None;
							destroyRoutine (wait);
						}
						// UI
						{
							if (contentContainer != null) {
								contentContainer.SetActive (false);
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("chatRoom null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region Task wait

	private Routine wait;

	public IEnumerator TaskWait()
	{
		if (this.data != null) {
			yield return new Wait (Global.WaitSendTime);
			this.data.state.v = UIData.State.None;
			Toast.showMessage ("request error");
			Debug.LogError ("request error: " + this);
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (wait);
		}
		return ret;
	}

	#endregion

	#region implement callBacks

	private Server server = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Update
			{
				UpdateUtils.makeUpdate<ChatRoomBtnLoadMoreAutoLoad, UIData> (uiData, this.transform);
			}
			// Child
			{
				uiData.chatRoom.allAddCallBack (this);
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
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Parent
				{
					DataUtils.addParentCallBack (chatRoom, this, ref this.server);
				}
				// Child
				{
					chatRoom.chatViewers.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is Server) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ChatViewer) {
					ChatViewer chatViewer = data as ChatViewer;
					// Child
					{
						chatViewer.subViews.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is ChatSubView) {
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
			// Setting
			Setting.get().removeCallBack(this);
			// Update
			{
				uiData.removeCallBackAndDestroy (typeof(ChatRoomBtnLoadMoreAutoLoad));
			}
			// Child
			{
				uiData.chatRoom.allRemoveCallBack (this);
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
			if (data is ChatRoom) {
				ChatRoom chatRoom = data as ChatRoom;
				// Parent
				{
					DataUtils.removeParentCallBack (chatRoom, this, ref this.server);
				}
				// Child
				{
					chatRoom.chatViewers.allRemoveCallBack (this);
				}
				return;
			}
			// Parent
			if (data is Server) {
				return;
			}
			// Child
			{
				if (data is ChatViewer) {
					ChatViewer chatViewer = data as ChatViewer;
					// Child
					{
						chatViewer.subViews.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is ChatSubView) {
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
			case UIData.Property.chatRoom:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
			if (wrapProperty.p is ChatRoom) {
				switch ((ChatRoom.Property)wrapProperty.n) {
				case ChatRoom.Property.topic:
					break;
				case ChatRoom.Property.isEnable:
					break;
				case ChatRoom.Property.players:
					break;
				case ChatRoom.Property.messages:
					{
						dirty = true;
						needReset = true;
					}
					break;
				case ChatRoom.Property.chatViewers:
					{
						ValueChangeUtils.replaceCallBack(this, syncs);
						dirty = true;
						needReset = true;
					}
					break;
				case ChatRoom.Property.typing:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is Server) {
				switch ((Server.Property)wrapProperty.n) {
				case Server.Property.serverConfig:
					break;
				case Server.Property.startState:
					break;
				case Server.Property.type:
					dirty = true;
					break;
				case Server.Property.profile:
					break;
				case Server.Property.state:
					dirty = true;
					break;
				case Server.Property.users:
					break;
				case Server.Property.disconnectTime:
					break;
				case Server.Property.globalChat:
					break;
				case Server.Property.friendWorld:
					break;
				case Server.Property.guilds:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is ChatViewer) {
					switch ((ChatViewer.Property)wrapProperty.n) {
					case ChatViewer.Property.userId:
						dirty = true;
						break;
					case ChatViewer.Property.minViewId:
						needReset = true;
						dirty = true;
						break;
					case ChatViewer.Property.subViews:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case ChatViewer.Property.connection:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is ChatSubView) {
					switch ((ChatSubView.Property)wrapProperty.n) {
					case ChatSubView.Property.min:
						dirty = true;
						break;
					case ChatSubView.Property.max:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnLoadMore()
	{
		if (this.data != null) {
			switch (this.data.state.v) {
			case UIData.State.None:
				this.data.state.v = UIData.State.Request;
				break;
			case UIData.State.Request:
				this.data.state.v = UIData.State.None;
				break;
			case UIData.State.Wait:
				Debug.LogError ("you are requesting: " + this);
				break;
			default:
				Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
				break;
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

}