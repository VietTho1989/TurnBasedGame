using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawStateAskUI : UIBehavior<RequestDrawStateAskUI.UIData>
{

	#region UIData

	public class UIData : RequestDrawUI.UIData.Sub
	{
		public VP<ReferenceData<RequestDrawStateAsk>> requestDrawStateAsk;

		public override RequestDraw.State.Type getType ()
		{
			return RequestDraw.State.Type.Ask;
		}

		#region Constructor

		public enum Property
		{
			requestDrawStateAsk
		}

		public UIData() : base()
		{
			this.requestDrawStateAsk = new VP<ReferenceData<RequestDrawStateAsk>>(this, (byte)Property.requestDrawStateAsk, new ReferenceData<RequestDrawStateAsk>(null));
		}

		#endregion
	}

	#endregion

	#region Refresh

	#region txt

	public static readonly TxtLanguage txtPlayer = new TxtLanguage ();
	public static readonly TxtLanguage txtRequestDraw = new TxtLanguage();
	public static readonly TxtLanguage txtAdmin = new TxtLanguage();

	public Text tvOK;
	public static readonly TxtLanguage txtOK = new TxtLanguage();

	public Text tvCancel;
	public static readonly TxtLanguage txtCancel = new TxtLanguage ();

	static RequestDrawStateAskUI()
	{
		txtPlayer.add (Language.Type.vi, "Người chơi");
		txtRequestDraw.add (Language.Type.vi, "yêu cầu hoà");
		txtAdmin.add (Language.Type.vi, "Admin");

		txtOK.add (Language.Type.vi, "Đồng Ý");
		txtCancel.add (Language.Type.vi, "Huỷ Bỏ");
	}

	#endregion

	public Text tvContent;
	public Image uiButton;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				RequestDrawStateAsk requestDrawStateAsk = this.data.requestDrawStateAsk.v.data;
				if (requestDrawStateAsk != null) {
					// tvContent
					{
						if (this.tvContent != null) {
							int playerAskIndex = -1;
							{
								if (requestDrawStateAsk.accepts.vs.Count > 0) {
									uint playerAskId = requestDrawStateAsk.accepts.vs [0];
									Game game = requestDrawStateAsk.findDataInParent<Game> ();
									if (game != null) {
										for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
											GamePlayer gamePlayer = game.gamePlayers.vs [i];
											if (gamePlayer.inform.v is Human) {
												Human human = gamePlayer.inform.v as Human;
												if (human.playerId.v == playerAskId) {
													playerAskIndex = gamePlayer.playerIndex.v;
													break;
												}
											}
										}
									} else {
										Debug.LogError ("duel null");
									}
								}
							}
							// Process
							{
								if (playerAskIndex >= 0) {
									tvContent.text = txtPlayer.get ("Player ") + " " + playerAskIndex + " " + txtRequestDraw.get ("request draw");
								} else {
									tvContent.text = txtAdmin.get ("Admin") + " " + txtRequestDraw.get ("request draw");
								}
							}
						} else {
							Debug.LogError ("tvContent null");
						}
					}
					// uiButton
					{
						if (this.uiButton != null) {
							uint userId = Server.getProfileUserId (requestDrawStateAsk);
							if (requestDrawStateAsk.isCanAnswer (userId)) {
								this.uiButton.gameObject.SetActive (true);
							} else {
								this.uiButton.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("uiButton null");
						}
					}
				} else {
					Debug.LogError ("requestDrawStateAsk null");
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

	private GameIsPlayingChange<RequestDrawStateAsk> gameIsPlayingChange = new GameIsPlayingChange<RequestDrawStateAsk>();
	private GameCheckPlayerChange<RequestDrawStateAsk> gameCheckPlayerChange = new GameCheckPlayerChange<RequestDrawStateAsk>();
	private RoomCheckChangeAdminChange<RequestDrawStateAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestDrawStateAsk> ();

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.requestDrawStateAsk.allAddCallBack (this);
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
			if (data is RequestDrawStateAsk) {
				RequestDrawStateAsk requestDrawStateAsk = data as RequestDrawStateAsk;
				// CheckChange
				{
					// isPlaying
					{
						gameIsPlayingChange.addCallBack (this);
						gameIsPlayingChange.setData (requestDrawStateAsk);
					}
					// gamePlayer
					{
						gameCheckPlayerChange.addCallBack (this);
						gameCheckPlayerChange.setData (requestDrawStateAsk);
					}
					// roomCheckAdminChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestDrawStateAsk);
					}
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is GameIsPlayingChange<RequestDrawStateAsk>) {
					dirty = true;
					return;
				}
				if (data is GameCheckPlayerChange<RequestDrawStateAsk>) {
					dirty = true;
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestDrawStateAsk>) {
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
			// Child
			{
				uiData.requestDrawStateAsk.allRemoveCallBack (this);
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
			if (data is RequestDrawStateAsk) {
				// RequestDrawStateAsk requestDrawStateAsk = data as RequestDrawStateAsk;
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
				if (data is GameIsPlayingChange<RequestDrawStateAsk>) {
					return;
				}
				if (data is GameCheckPlayerChange<RequestDrawStateAsk>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestDrawStateAsk>) {
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
			case UIData.Property.requestDrawStateAsk:
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
			if (wrapProperty.p is RequestDrawStateAsk) {
				switch ((RequestDrawStateAsk.Property)wrapProperty.n) {
				case RequestDrawStateAsk.Property.accepts:
					dirty = true;
					break;
				case RequestDrawStateAsk.Property.refuses:
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
				if (wrapProperty.p is GameIsPlayingChange<RequestDrawStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is GameCheckPlayerChange<RequestDrawStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestDrawStateAsk>) {
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
		this.answer (RequestDrawStateAsk.Answer.Accept);
	}

	public void onClickBtnCancel()
	{
		this.answer (RequestDrawStateAsk.Answer.Refuse);
	}

	public void answer(RequestDrawStateAsk.Answer answer){
		if (this.data != null) {
			if (!GameUI.UIData.IsReplay (this.data)) {
				RequestDrawStateAsk requestDrawStateAsk = this.data.requestDrawStateAsk.v.data;
				if (requestDrawStateAsk != null) {
					uint userId = Server.getProfileUserId (requestDrawStateAsk);
					if (requestDrawStateAsk.isCanAnswer (userId)) {
						requestDrawStateAsk.requestAnswer (userId, answer);
					} else {
						Debug.LogError ("Cannot answer: " + userId + ", " + answer);
					}
				} else {
					Debug.LogError ("requestDrawStateAsk null");
				}
			} else {
				Debug.LogError ("this is replay, cannot answer: " + this);
			}
		} else {
			Debug.LogError ("data null");
		}
	}

}