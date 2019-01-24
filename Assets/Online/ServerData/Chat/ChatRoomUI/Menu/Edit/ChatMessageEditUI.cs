using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class ChatMessageEditUI : UIBehavior<ChatMessageEditUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<ChatMessage>> chatMessage;

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
			chatMessage,
			state
		}

		public UIData() : base()
		{
			this.chatMessage = new VP<ReferenceData<ChatMessage>>(this, (byte)Property.chatMessage, new ReferenceData<ChatMessage>(null));
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

		public void reset()
		{
			this.state.v = State.None;
		}

		public bool processEvent(Event e)
		{
			Debug.LogError ("processEvent: " + e + "; " + this);
			bool isProcess = false;
			{
				// back
				if (!isProcess) {
					if (InputEvent.isBackEvent (e)) {
						ChatMessageEditUI chatMessageEditUI = this.findCallBack<ChatMessageEditUI> ();
						if (chatMessageEditUI != null) {
							chatMessageEditUI.onClickBtnBack ();
						} else {
							Debug.LogError ("chatMessageEditUI null: " + this);
						}
						isProcess = true;
					}
				}
			}
			return isProcess;
		}

	}
		
	#endregion

	#region Refresh

	public InputField inputField;

	public override void Awake ()
	{
		base.Awake ();
		// check input
		if (inputField != null) {
			inputField.onEndEdit.AddListener (delegate {
				dirty = true;
			});
		} else {
			Debug.LogError ("inputField null: " + this);
		}
	}

	#region txt

	public Text lbTitle;
	public static TxtLanguage txtTitle = new TxtLanguage();

	public Text tvBack;
	public static TxtLanguage txtBack = new TxtLanguage ();

	public Text tvMessagePlaceHolder;
	public static TxtLanguage txtMessagePlaceHolder = new TxtLanguage();

	public static readonly TxtLanguage txtEdit = new TxtLanguage ();
	public static readonly TxtLanguage txtCancelEdit = new TxtLanguage ();
	public static readonly TxtLanguage txtEditing = new TxtLanguage();
	public static readonly TxtLanguage txtCannotEdit = new TxtLanguage();

	static ChatMessageEditUI()
	{
		txtTitle.add (Language.Type.vi, "Chỉnh sửa thông điệp");
		txtBack.add (Language.Type.vi, "Quay Lại");
		txtMessagePlaceHolder.add (Language.Type.vi, "Xin hãy điền thông điệp mới vào");

		txtEdit.add (Language.Type.vi, "Chỉnh Sửa");
		txtCancelEdit.add (Language.Type.vi, "Huỷ chỉnh sửa");
		txtEditing.add (Language.Type.vi, "Đang chỉnh sửa");
		txtCannotEdit.add (Language.Type.vi, "Không thể chỉnh sửa");
	}

	#endregion

	private bool needReset = false;

	public Button btnEdit;
	public Text tvEdit;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				ChatMessage chatMessage = this.data.chatMessage.v.data;
				if (chatMessage != null) {
					// reset
					if (needReset) {
						this.data.state.v = UIData.State.None;
						needReset = false;
					}
					if (inputField != null) {
						string newMessage = inputField.text;
						// get chatNormalContent
						ChatNormalContent chatNormalContent = chatMessage.content.v as ChatNormalContent;
						if (chatNormalContent != null) {
							uint profileId = Server.getProfileUserId (chatMessage);
							if (chatNormalContent.isCanEdit (profileId, newMessage)) {
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
											// request
											{
												if (Server.IsServerOnline (chatMessage)) {
													chatNormalContent.requestEdit (profileId, newMessage);
													this.data.state.v = UIData.State.Wait;
												} else {
													Debug.LogError ("server not online: " + this);
												}
											}
										}
										break;
									case UIData.State.Wait:
										{
											if (Server.IsServerOnline (chatMessage)) {
												startRoutine (ref this.wait, TaskWait ());
											} else {
												this.data.state.v = UIData.State.None;
												destroyRoutine (wait);
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
									if (btnEdit != null && tvEdit != null) {
										switch (this.data.state.v) {
										case UIData.State.None:
											{
												btnEdit.enabled = true;
												tvEdit.text = txtEdit.get("Edit");
											}
											break;
										case UIData.State.Request:
											{
												btnEdit.enabled = true;
												tvEdit.text = txtCancelEdit.get ("Cancel Edit?");
											}
											break;
										case UIData.State.Wait:
											{
												btnEdit.enabled = false;
												tvEdit.text = txtEditing.get ("Editting");
											}
											break;
										default:
											Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
											break;
										}
									} else {
										Debug.LogError ("btnEdit, tvEdit null: " + this);
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
									if (btnEdit != null && tvEdit != null) {
										btnEdit.enabled = false;
										tvEdit.text = txtCannotEdit.get ("Cannot Edit");
									} else {
										Debug.LogError ("btnEdit, tvEdit null: " + this);
									}
								}
							}
						} else {
							Debug.LogError ("chatNormalContent null: " + this);
						}
					} else {
						Debug.LogError ("inputField null: " + this);
					}
				} else {
					Debug.LogError ("chatMessage null: " + this);
				}
				// txt
				{
					if (lbTitle != null) {
						lbTitle.text = txtTitle.get ("Edit Message");
					} else {
						Debug.LogError ("lbTitle null: " + this);
					}
					if (tvBack != null) {
						tvBack.text = txtBack.get ("Back");
					} else {
						Debug.LogError ("tvBack null: " + this);
					}
					if (tvMessagePlaceHolder != null) {
						tvMessagePlaceHolder.text = txtMessagePlaceHolder.get ("Please enter your new message");
					} else {
						Debug.LogError ("tvMessagePlaceHolder null: " + this);
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
			// Child
			{
				uiData.chatMessage.allAddCallBack (this);
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
			if (data is ChatMessage) {
				ChatMessage chatMessage = data as ChatMessage;
				// reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null: " + this);
					}
					// inputField
					if (inputField != null) {
						string strMessage = "";
						{
							ChatNormalContent chatNormalContent = chatMessage.content.v as ChatNormalContent;
							if (chatNormalContent != null) {
								if (chatNormalContent.messages.vs.Count > 0) {
									ChatNormalContent.Message lastMessage = chatNormalContent.messages.vs [chatNormalContent.messages.vs.Count - 1];
									strMessage = lastMessage.message;
								}
							} else {
								Debug.LogError ("chatNormalContent null: " + this);
							}
						}
						inputField.text = strMessage;
					} else {
						Debug.LogError ("inputField null: " + this);
					}
				}
				// Parent
				{
					DataUtils.addParentCallBack (chatMessage, this, ref this.server);
				}
				// Child
				{
					chatMessage.content.allAddCallBack (this);
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
			if (data is ChatMessage.Content) {
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
				uiData.chatMessage.allRemoveCallBack (this);
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
			if (data is ChatMessage) {
				ChatMessage chatMessage = data as ChatMessage;
				// Parent
				{
					DataUtils.removeParentCallBack (chatMessage, this, ref this.server);
				}
				// Child
				{
					chatMessage.content.allRemoveCallBack (this);
				}
				return;
			}
			// Parent
			if (data is Server) {
				return;
			}
			// Child
			if (data is ChatMessage.Content) {
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
			case UIData.Property.chatMessage:
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
			if (wrapProperty.p is ChatMessage) {
				switch ((ChatMessage.Property)wrapProperty.n) {
				case ChatMessage.Property.state:
					dirty = true;
					break;
				case ChatMessage.Property.time:
					break;
				case ChatMessage.Property.content:
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
			if (wrapProperty.p is Server) {
				Server.State.OnUpdateSyncStateChange (wrapProperty, this);
				return;
			}
			// Child
			if (wrapProperty.p is ChatMessage.Content) {
				ChatMessage.Content content = wrapProperty.p as ChatMessage.Content;
				switch (content.getType ()) {
				case ChatMessage.Content.Type.Normal:
					{
						switch ((ChatNormalContent.Property)wrapProperty.n) {
						case ChatNormalContent.Property.owner:
							dirty = true;
							break;
						case ChatNormalContent.Property.messages:
							dirty = true;
							break;
						case ChatNormalContent.Property.editMax:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
					}
					break;
				case ChatMessage.Content.Type.UserAction:
					break;
				case ChatMessage.Content.Type.RoomUserState:
					break;
				case ChatMessage.Content.Type.FriendStateChange:
					break;
				case ChatMessage.Content.Type.GameMove:
					break;
				default:
					Debug.LogError ("unknown type: " + content.getType () + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnBack()
	{
		if (this.data != null) {
			ChatMessageMenuUI.UIData chatMessageMenuUIData = this.data.findDataInParent<ChatMessageMenuUI.UIData> ();
			if (chatMessageMenuUIData != null) {
				chatMessageMenuUIData.edit.v = null;
			} else {
				Debug.LogError ("uiData null");
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	public void onClickBtnEdit()
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
				Debug.LogError ("You are editting: " + this);
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