using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundGamePlayerUI : UIBehavior<RoundGamePlayerUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<GamePlayer>> gamePlayer;

			public VP<InformAvatarUI.UIData> avatar;

			#region Constructor

			public enum Property
			{
				gamePlayer,
				avatar
			}

			public UIData() : base()
			{
				this.gamePlayer = new VP<ReferenceData<GamePlayer>>(this, (byte)Property.gamePlayer, new ReferenceData<GamePlayer>(null));
				this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Text tvName;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					GamePlayer gamePlayer = this.data.gamePlayer.v.data;
					if (gamePlayer != null) {
						// avatar
						{
							InformAvatarUI.UIData avatar = this.data.avatar.v;
							if (avatar != null) {
								avatar.inform.v = new ReferenceData<GamePlayer.Inform> (gamePlayer.inform.v);
							} else {
								Debug.LogError ("avatar null: " + this);
							}
						}
						// tvName
						if (tvName != null) {
							float score = 0;
							bool isEndGame = false;
							{
								Game game = gamePlayer.findDataInParent<Game> ();
								if (game != null) {
									if (game.state.v is GameState.End) {
										GameState.End end = game.state.v as GameState.End;
										isEndGame = true;
										// get score
										{
											GameState.Result result = end.findResult (gamePlayer.playerIndex.v);
											if (result != null) {
												score = result.score.v;
											} else {
												Debug.LogError ("result null: " + this);
											}
										}
									}
								} else {
									Debug.LogError ("game null: " + this);
								}
							}
							tvName.text = gamePlayer.inform.v.getPlayerName () + ", " + gamePlayer.playerIndex.v + (isEndGame ? ": " + score
								: "");
						} else {
							Debug.LogError ("tvName null: " + this);
						}
					} else {
						Debug.LogError ("gamePlayer null: " + this);
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

		public InformAvatarUI informAvatarPrefab;
		public Transform informAvatarContainer;

		private Game game = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.gamePlayer.allAddCallBack (this);
					uiData.avatar.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// GamePlayer
				{
					if (data is GamePlayer) {
						GamePlayer gamePlayer = data as GamePlayer;
						// Parent
						{
							DataUtils.addParentCallBack (gamePlayer, this, ref this.game);
						}
						// Child
						{
							gamePlayer.inform.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Parent
					{
						if (data is Game) {
							Game game = data as Game;
							// Child
							{
								game.state.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						{
							if (data is GameState.State) {
								GameState.State state = data as GameState.State;
								// Child
								{
									if (state is GameState.End) {
										GameState.End end = state as GameState.End;
										end.results.allAddCallBack (this);
									}
								}
								dirty = true;
								return;
							}
							// Child
							if (data is GameState.Result) {
								dirty = true;
								return;
							}
						}
					}
					// Child
					{
						if (data is GamePlayer.Inform) {
							GamePlayer.Inform inform = data as GamePlayer.Inform;
							// Child
							{
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									break;
								case GamePlayer.Inform.Type.Computer:
									break;
								case GamePlayer.Inform.Type.Human:
									{
										Human human = inform as Human;
										human.account.allAddCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
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
				if (data is InformAvatarUI.UIData) {
					InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
					// UI
					{
						UIUtils.Instantiate (informAvatarUIData, informAvatarPrefab, informAvatarContainer);
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
					uiData.gamePlayer.allRemoveCallBack (this);
					uiData.avatar.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				// GamePlayer
				{
					if (data is GamePlayer) {
						GamePlayer gamePlayer = data as GamePlayer;
						// Parent
						{
							DataUtils.removeParentCallBack (gamePlayer, this, ref this.game);
						}
						// Child
						{
							gamePlayer.inform.allRemoveCallBack (this);
						}
						return;
					}
					// Parent
					{
						if (data is Game) {
							Game game = data as Game;
							// Child
							{
								game.state.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						{
							if (data is GameState.State) {
								GameState.State state = data as GameState.State;
								// Child
								{
									if (state is GameState.End) {
										GameState.End end = state as GameState.End;
										end.results.allRemoveCallBack (this);
									}
								}
								return;
							}
							// Child
							if (data is GameState.Result) {
								return;
							}
						}
					}
					// Child
					{
						if (data is GamePlayer.Inform) {
							GamePlayer.Inform inform = data as GamePlayer.Inform;
							// Child
							{
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									break;
								case GamePlayer.Inform.Type.Computer:
									break;
								case GamePlayer.Inform.Type.Human:
									{
										Human human = inform as Human;
										human.account.allRemoveCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
							}
							return;
						}
						// Child
						if (data is Account) {
							return;
						}
					}
				}
				if (data is InformAvatarUI.UIData) {
					InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
					// UI
					{
						informAvatarUIData.removeCallBackAndDestroy (typeof(InformAvatarUI));
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
				case UIData.Property.gamePlayer:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.avatar:
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
				// GamePlayer
				{
					if (wrapProperty.p is GamePlayer) {
						switch ((GamePlayer.Property)wrapProperty.n) {
						case GamePlayer.Property.playerIndex:
							dirty = true;
							break;
						case GamePlayer.Property.inform:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GamePlayer.Property.state:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Parent
					{
						if (wrapProperty.p is Game) {
							switch ((Game.Property)wrapProperty.n) {
							case Game.Property.gamePlayers:
								break;
							case Game.Property.requestDraw:
								break;
							case Game.Property.state:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case Game.Property.gameData:
								break;
							case Game.Property.history:
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
						// Child
						{
							if (wrapProperty.p is GameState.State) {
								if (wrapProperty.p is GameState.End) {
									switch ((GameState.End.Property)wrapProperty.n) {
									case GameState.End.Property.results:
										{
											ValueChangeUtils.replaceCallBack (this, syncs);
											dirty = true;
										}
										break;
									default:
										Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
										break;
									}
								}
								return;
							}
							// Child
							if (wrapProperty.p is GameState.Result) {
								switch ((GameState.Result.Property)wrapProperty.n) {
								case GameState.Result.Property.playerIndex:
									dirty = true;
									break;
								case GameState.Result.Property.score:
									dirty = true;
									break;
								case GameState.Result.Property.reason:
									break;
								default:
									Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
						}
					}
					// Child
					{
						if (wrapProperty.p is GamePlayer.Inform) {
							GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
							// Child
							{
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									break;
								case GamePlayer.Inform.Type.Computer:
									{
										switch ((Computer.Property)wrapProperty.n) {
										case Computer.Property.computerName:
											dirty = true;
											break;
										case Computer.Property.avatarUrl:
											break;
										case Computer.Property.ai:
											break;
										default:
											Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
											break;
										}
									}
									break;
								case GamePlayer.Inform.Type.Human:
									{
										switch ((Human.Property)wrapProperty.n) {
										case Human.Property.playerId:
											break;
										case Human.Property.account:
											{
												ValueChangeUtils.replaceCallBack(this, syncs);
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
										case Human.Property.ban:
											break;
										default:
											Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
											break;
										}
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
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
				if (wrapProperty.p is InformAvatarUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}