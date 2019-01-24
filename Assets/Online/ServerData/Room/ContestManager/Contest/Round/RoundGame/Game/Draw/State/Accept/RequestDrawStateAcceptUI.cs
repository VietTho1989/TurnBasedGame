using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateAcceptUI : UIBehavior<RequestDrawStateAcceptUI.UIData>
{

	#region UIData

	public class UIData : RequestDrawUI.UIData.Sub
	{
		public VP<ReferenceData<RequestDrawStateAccept>> requestDrawStateAccept;

		public override RequestDraw.State.Type getType ()
		{
			return RequestDraw.State.Type.Accept;
		}

		#region Constructor

		public enum Property
		{
			requestDrawStateAccept
		}

		public UIData() : base()
		{
			this.requestDrawStateAccept = new VP<ReferenceData<RequestDrawStateAccept>>(this, (byte)Property.requestDrawStateAccept, new ReferenceData<RequestDrawStateAccept>(null));
		}

		#endregion
	}

	#endregion

	#region Refresh

	#region txt

	public Text tvOK;
	public static readonly TxtLanguage txtOK = new TxtLanguage ();

	public Text tvCancel;
	public static readonly TxtLanguage txtCancel = new TxtLanguage ();

	public static readonly TxtLanguage txtRequestCancelDraw = new TxtLanguage ();
	public static readonly TxtLanguage txtPlayer = new TxtLanguage();
	public static readonly TxtLanguage txtAdmin = new TxtLanguage ();

	static RequestDrawStateAcceptUI()
	{
		txtOK.add (Language.Type.vi, "Đồng Ý");
		txtCancel.add (Language.Type.vi, "Huỷ Bỏ");

		txtRequestCancelDraw.add (Language.Type.vi, "yêu cầu huỷ bỏ hoà cờ");
		txtPlayer.add (Language.Type.vi, "Người chơi");
		txtAdmin.add (Language.Type.vi, "Admin");
	}

	#endregion

	public Text tvContent;
	public Image uiButton;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RequestDrawStateAccept requestDrawStateAccept = this.data.requestDrawStateAccept.v.data;
				if (requestDrawStateAccept != null) {
					// tvContent
					{
						if (tvContent != null) {
							// find
							int playerIndex = -1;
							{
								// Find accept userId
								if (requestDrawStateAccept.accepts.vs.Count > 0) {
									uint accept = requestDrawStateAccept.accepts.vs [0];
									// Find gamePlayer
									Game game = requestDrawStateAccept.findDataInParent<Game>();
									if (game != null) {
										for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
											GamePlayer gamePlayer = game.gamePlayers.vs [i];
											if (gamePlayer.inform.v is Human) {
												Human human = gamePlayer.inform.v as Human;
												if (human.playerId.v == accept) {
													playerIndex = gamePlayer.playerIndex.v;
													break;
												}
											}
										}
									} else {
										Debug.LogError ("duel null");
									}
								}
							}
							// process
							{
								if (playerIndex >= 0) {
									tvContent.text = txtPlayer.get ("Player") + " " + playerIndex + " " + txtRequestCancelDraw.get ("request cancel draw");
								} else {
									tvContent.text = txtAdmin.get ("Admin") + " " + txtRequestCancelDraw.get ("request cancel draw");
								}
							}
						} else {
							Debug.LogError ("tvContent null");
						}
					}
					// uiButton
					{
						if (uiButton != null) {
							uint userId = Server.getProfileUserId (requestDrawStateAccept);
							if (requestDrawStateAccept.isCanAnswer (userId)) {
								this.uiButton.gameObject.SetActive (true);
							} else {
								this.uiButton.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("uiButton null");
						}
					}
				} else {
					Debug.LogError ("requestDrawStateAccept null");
				}
				// txt
				{
					if (tvOK != null) {
						tvOK.text = txtOK.get ("OK");
					} else {
						Debug.LogError ("tvOK null: " + this);
					}
					if (tvCancel != null) {
						tvCancel.text = txtCancel.get ("Cancel");
					} else {
						Debug.LogError ("tvCancel null: " + this);
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

	private GameIsPlayingChange<RequestDrawStateAccept> gameIsPlayingChange = new GameIsPlayingChange<RequestDrawStateAccept>();
	private GameCheckPlayerChange<RequestDrawStateAccept> gameCheckPlayerChange = new GameCheckPlayerChange<RequestDrawStateAccept>();
	private RoomCheckChangeAdminChange<RequestDrawStateAccept> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestDrawStateAccept> ();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.requestDrawStateAccept.allAddCallBack (this);
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
			if (data is RequestDrawStateAccept) {
				RequestDrawStateAccept requestDrawStateAccept = data as RequestDrawStateAccept;
				// CheckChange
				{
					// isPlaying
					{
						gameIsPlayingChange.addCallBack (this);
						gameIsPlayingChange.setData (requestDrawStateAccept);
					}
					// gamePlayer
					{
						gameCheckPlayerChange.addCallBack (this);
						gameCheckPlayerChange.setData (requestDrawStateAccept);
					}
					// roomCheckAdminChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestDrawStateAccept);
					}
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
				uiData.requestDrawStateAccept.allRemoveCallBack (this);
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
			if (data is RequestDrawStateAccept) {
				// RequestDrawStateAccept requestDrawStateAccept = data as RequestDrawStateAccept;
				// CheckChange
				{
					// isPlaying
					{
						gameIsPlayingChange.removeCallBack (this);
						gameIsPlayingChange.setData (null);
					}
					// gamePlayer
					{
						gameCheckPlayerChange.removeCallBack (this);
						gameCheckPlayerChange.setData (null);
					}
					// roomCheckAdminChange
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
				}
				return;
			}
			// CheckChange
			{
				if (data is GameIsPlayingChange<RequestDrawStateAccept>) {
					return;
				}
				if (data is GameCheckPlayerChange<RequestDrawStateAccept>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestDrawStateAccept>) {
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
			case UIData.Property.requestDrawStateAccept:
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
			if (wrapProperty.p is RequestDrawStateAccept) {
				switch ((RequestDrawStateAccept.Property)wrapProperty.n) {
				case RequestDrawStateAccept.Property.accepts:
					dirty = true;
					break;
				case RequestDrawStateAccept.Property.refuses:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			{
				if (wrapProperty.p is GameIsPlayingChange<RequestDrawStateAccept>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is GameCheckPlayerChange<RequestDrawStateAccept>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestDrawStateAccept>) {
					dirty = true;
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	public void onClickBtnOK()
	{
		this.answer (RequestDrawStateAccept.Answer.Accept);	
	}

	public void onClickBtnCancel()
	{
		this.answer (RequestDrawStateAccept.Answer.Refuse);
	}

	private void answer(RequestDrawStateAccept.Answer answer)
	{
		if (this.data != null) {
			if (!GameUI.UIData.IsReplay (this.data)) {
				RequestDrawStateAccept requestDrawStateAccept = this.data.requestDrawStateAccept.v.data;
				if (requestDrawStateAccept != null) {
					uint userId = Server.getProfileUserId (requestDrawStateAccept);
					if (requestDrawStateAccept.isCanAnswer (userId)) {
						requestDrawStateAccept.requestAnswer (userId, answer);
					} else {
						Debug.LogError ("Cannot answer");
					}
				} else {
					Debug.LogError ("requestDrawStateAccept");
				}
			} else {
				Debug.LogError ("this is replay, cannot answer: " + this);
			}
		} else {
			Debug.LogError ("data null");
		}
	}
}