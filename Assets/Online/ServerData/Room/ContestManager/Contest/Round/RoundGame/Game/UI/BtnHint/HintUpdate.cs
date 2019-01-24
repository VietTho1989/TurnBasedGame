using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace Hint
{
	public class HintUpdate : UpdateBehavior<HintUI.UIData>
	{

		#region Refresh

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					GameData gameData = this.data.gameData.v.data;
					if (gameData != null) {
						// have change board: chuyen ve state Normal
						if (haveChangeBoard) {
							haveChangeBoard = false;
							switch (this.data.state.v.getType ()) {
							case HintUI.UIData.State.Type.Not:
								break;
							case HintUI.UIData.State.Type.Normal:
								break;
							case HintUI.UIData.State.Type.Get:
							case HintUI.UIData.State.Type.Getting:
							case HintUI.UIData.State.Type.Show:
								{
									NormalUI.UIData normalUIData = this.data.state.newOrOld<NormalUI.UIData> ();
									{

									}
									this.data.state.v = normalUIData;
								}
								break;
							default:
								Debug.LogError ("unknown state: " + this.data.state.v.getType () + "; " + this);
								break;
							}
						}
						// Check can use hint
						bool canUseHint = false;
						{
							// if (gameData.useRule.v) 
							{
								if (gameData.state.v is GameDataStateNormal) {
									// Room admin allow use hint
									bool isRoomAllowHint = false;
									{
										Room room = gameData.findDataInParent<Room> ();
										if (room != null) {
											switch (room.allowHint.v) {
											case Room.AllowHint.Allow:
												isRoomAllowHint = true;
												break;
											case Room.AllowHint.No:
												isRoomAllowHint = false;
												break;
											case Room.AllowHint.OnlyWatcher:
												{
													// Check you are watcher
													bool isYouWatcher = true;
													{
														Game game = gameData.findDataInParent<Game> ();
														if (game != null) {
															uint yourUserId = Server.getProfileUserId (room);
															for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
																GamePlayer gamePlayer = game.gamePlayers.vs [i];
																if (gamePlayer.inform.v is Human) {
																	Human human = gamePlayer.inform.v as Human;
																	if (human.playerId.v == yourUserId) {
																		isYouWatcher = false;
																		break;
																	}
																}
															}
														} else {
															Debug.LogError ("duel null: " + this);
														}
													}
													if (isYouWatcher) {
														isRoomAllowHint = true;
													} else {
														Debug.Log ("you are not watcher, so not allow hint: " + this);
														isRoomAllowHint = false;
													}
												}
												break;
											default:
												Debug.LogError ("unknown allow hint: " + room.allowHint.v + "; " + this);
												break;
											}
										} else {
											// Debug.LogError ("room null: " + this);
											isRoomAllowHint = true;
										}
									}
									if (isRoomAllowHint) {
										bool isCorrectGameState = false;
										{
											Game game = gameData.findDataInParent<Game> ();
											if (game != null) {
												if (game.state.v is GameState.Play) {
													bool correctGameAction = false;
													{
														switch (game.gameAction.v.getType ()) {
														case GameAction.Type.WaitInput:
															{
																WaitInputAction waitInputAction = game.gameAction.v as WaitInputAction;
																if (waitInputAction.sub.v != null) {
																	if (waitInputAction.sub.v is WaitHumanInput) {
																		correctGameAction = true;
																	}
																}
															}
															break;
														case GameAction.Type.ProcessMove:
														case GameAction.Type.StartTurn:
														case GameAction.Type.EndTurn:
														case GameAction.Type.Non:
														case GameAction.Type.UndoRedo:
															break;
														default:
															Debug.LogError ("unknown gameAction type: " + game.gameAction.v.getType ());
															break;
														}
													}
													// Process
													if (correctGameAction) {
														isCorrectGameState = true;
													} else {
														// Debug.LogError ("not correct gameAction: " + duel.game.property.gameAction.property);		
													}
												}
											} else {
												Debug.LogError ("game null: " + this);
											}
										}
										if (isCorrectGameState) {
											// boi vi neu gameAction la waitAction thi tuc la dang la human turn
											canUseHint = true;
										}
									} else {
										// Debug.LogError ("room not allow hint: " + this);
									}
								} else {
									Debug.Log ("game already finish: " + this);
								}
							} 
							/*else {
								Debug.LogError ("not use rule, so cannot hint: " + this);
							}*/
						}
						if (canUseHint) {
							switch (this.data.state.v.getType ()) {
							case HintUI.UIData.State.Type.Not:
								{
									destroyRoutine (findHintRoutine);
									// Chuyen ve normal
									{
										NormalUI.UIData normalUIData = this.data.state.newOrOld<NormalUI.UIData> ();
										{

										}
										this.data.state.v = normalUIData;
									}
								}
								break;
							case HintUI.UIData.State.Type.Normal:
								{
									destroyRoutine (findHintRoutine);
									if (this.data.autoHint.v) {
										// chuyen ve get
										GetUI.UIData getUIData = this.data.state.newOrOld<GetUI.UIData>();
										{

										}
										this.data.state.v = getUIData;
									}
								}
								break;
							case HintUI.UIData.State.Type.Get:
								{
									destroyRoutine (findHintRoutine);
								}
								break;
							case HintUI.UIData.State.Type.Getting:
								{
									// Tao rountine o sau
								}
								break;
							case HintUI.UIData.State.Type.Show:
								{
									destroyRoutine (findHintRoutine);
								}
								break;
							default:
								Debug.LogError ("unknown state type: " + this.data.state.v.getType () + "; " + this);
								break;
							}
						} else {
							// Debug.LogError ("Cannot use hint");
							// Chuyen ve Not
							NotUI.UIData notUIData = this.data.state.newOrOld<NotUI.UIData>();
							{

							}
							this.data.state.v = notUIData;
						}
					} else {
						Debug.LogError ("gameData null: " + this);
						// Chuyen ve Not
						NotUI.UIData notUIData = this.data.state.newOrOld<NotUI.UIData>();
						{

						}
						this.data.state.v = notUIData;
					}
					// Task find hint
					{
						switch (this.data.state.v.getType()) {
						case HintUI.UIData.State.Type.Not:
							{
								destroyRoutine (findHintRoutine);
							}
							break;
						case HintUI.UIData.State.Type.Normal:
							{
								destroyRoutine (findHintRoutine);
							}
							break;
						case HintUI.UIData.State.Type.Get:
							{
								destroyRoutine (findHintRoutine);
								// Chuyen sang getting
								{
									GettingUI.UIData gettingUIData = this.data.state.newOrOld<GettingUI.UIData> ();
									{

									}
									this.data.state.v = gettingUIData;
								}
							}
							break;
						case HintUI.UIData.State.Type.Getting:
							{
								if (Routine.IsNull (findHintRoutine)) {
									findHintRoutine = CoroutineManager.StartCoroutine (TaskFindHint(), this.gameObject);
								} else {
									Debug.LogError ("Why routine != null: " + this);
								}
							}
							break;
						case HintUI.UIData.State.Type.Show:
							{
								destroyRoutine (findHintRoutine);
							}
							break;
						default:
							Debug.LogError ("unknown state : " + this.data.state.v.getType () + "; " + this);
							break;
						}
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

		class Work 
		{

			public HintUI.UIData data = null;

			public GameMove hintMove = new NonMove();

			public bool isDone = false;

			public void DoWork() 
			{
				if (this.data != null) {
					GameData gameData = this.data.gameData.v.data;
					if(gameData!=null){
						Computer.AI ai = this.data.ai.v;
						hintMove = gameData.gameType.v.getAIMove (ai, true);
						if (hintMove != null) {
							hintMove = hintMove.getForHintMove (gameData.gameType.v);
							// get inform
							hintMove.getInforBeforeProcess (gameData.gameType.v);
						} else {
							Debug.LogError ("hintMove null");
						}
					}else{
						Debug.LogError("gameData null: "+this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
				// Finish
				isDone = true;
			}
		}

		#region Task find hint

		private Routine findHintRoutine;

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (findHintRoutine);
			}
			return ret;
		}

		public IEnumerator TaskFindHint()
		{
			if (this.data != null) {
				Work w = new Work();
				{
					w.data = this.data;
					w.isDone = false;
					// startThread
					ThreadStart threadDelegate = new ThreadStart (w.DoWork);
					Thread newThread = new Thread (threadDelegate, Global.ThreadSize);
					newThread.Start ();
				}
				// Wait
				{
					while (!w.isDone) {
						yield return new Wait (1f);
					}
				}
				if (w.hintMove.getType () == GameMove.Type.None) {
					Debug.LogWarning ("why cannot find a game move: " + this);
				}
				if (this.data != null) {
					if (this.data.state.v is GettingUI.UIData) {
						// Chuyen ve show state
						ShowUI.UIData showUIData = this.data.state.newOrOld<ShowUI.UIData>();
						{
							// gameMove
							{
								w.hintMove.uid = showUIData.hintMove.makeId ();
								showUIData.hintMove.v = w.hintMove;
							}
						}
						this.data.state.v = showUIData;
					} else {
						Debug.LogError ("why not correct state: " + this.data.state.v);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		#endregion

		#region implement callBacks

		private bool haveChangeBoard = true;

		private Room room = null;
		private Game game = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is HintUI.UIData) {
				HintUI.UIData hintUIData = data as HintUI.UIData;
				{
					hintUIData.gameData.allAddCallBack (this);
					hintUIData.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// State
			if (data is HintUI.UIData.State) {
				dirty = true;
				return;
			}
			// GameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// Parent
					{
						DataUtils.addParentCallBack(gameData, this, ref this.room);
						DataUtils.addParentCallBack (gameData, this, ref this.game);
					}
					// Child
					{
						gameData.gameType.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Parent
				{
					// Room
					if(data is Room){
						// Room room = data as Room;
						dirty = true;
						return;
					}
					// Game
					{
						if (data is Game) {
							Game game = data as Game;
							// Child
							{
								game.gameAction.allAddCallBack (this);
								game.gamePlayers.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						// Child
						{
							// GameAction
							{
								if (data is GameAction) {
									GameAction gameAction = data as GameAction;
									{
										if (gameAction is WaitInputAction) {
											WaitInputAction waitInputAction = gameAction as WaitInputAction;
											// Child
											{
												waitInputAction.sub.allAddCallBack (this);
											}
										}
									}
									dirty = true;
									return;
								}
								if (data is WaitInputAction.Sub) {
									dirty = true;
									return;
								}
							}
							// gamePlayers
							{
								if (data is GamePlayer) {
									GamePlayer gamePlayer = data as GamePlayer;
									// Child
									{
										gamePlayer.inform.allAddCallBack (this);
									}
									dirty = true;
									return;
								}
								// Child
								if (data is GamePlayer.Inform) {
									dirty = true;
									return;
								}
							}
						}
					}
				}
				// Child
				{
					if (data is GameType) {
						GameType gameType = data as GameType;
						// all child
						{
							if (gameType is Weiqi.Weiqi) {
								Weiqi.Weiqi weiqi = gameType as Weiqi.Weiqi;
								{
									weiqi.b.allAddCallBack (this);
								}
							} else {
								gameType.addCallBackAllChildren (this);
							}
						}
						dirty = true;
						haveChangeBoard = true;
						return;
					}
					// Child
					// if (data.findDataInParent<GameType> () != null) 
					{
						// add all child
						{
							data.addCallBackAllChildren (this);
						}
						dirty = true;
						haveChangeBoard = true;
						return;
					} 
					/*else {
						Debug.LogError ("why not parent gameType: " + this);
					}*/
				}
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is HintUI.UIData) {
				HintUI.UIData hintUIData = data as HintUI.UIData;
				{
					hintUIData.gameData.allRemoveCallBack (this);
					hintUIData.state.allRemoveCallBack (this);
				}
				this.setDataNull (hintUIData);
				return;
			}
			// state
			if (data is HintUI.UIData.State) {
				return;
			}
			// GameData
			{
				if (data is GameData) {
					GameData gameData = data as GameData;
					// Parent
					{
						DataUtils.removeParentCallBack (gameData, this, ref this.room);
						DataUtils.removeParentCallBack (gameData, this, ref this.game);
					}
					// Child
					{
						gameData.gameType.allRemoveCallBack (this);
					}
					return;
				}
				// Parent
				{
					// Room
					if(data is Room){
						// Room room = data as Room;
						return;
					}
					// Game
					{
						if (data is Game) {
							Game game = data as Game;
							// Child
							{
								game.gameAction.allRemoveCallBack (this);
								game.gamePlayers.allRemoveCallBack (this);
							}
							return;
						}
						// Child
						{
							// GameAction
							{
								if (data is GameAction) {
									GameAction gameAction = data as GameAction;
									{
										if (gameAction is WaitInputAction) {
											WaitInputAction waitInputAction = gameAction as WaitInputAction;
											{
												waitInputAction.sub.allRemoveCallBack (this);
											}
										}
									}
									return;
								}
								if (data is WaitInputAction.Sub) {
									return;
								}
							}
							// gamePlayers
							{
								if (data is GamePlayer) {
									GamePlayer gamePlayer = data as GamePlayer;
									// Child
									{
										gamePlayer.inform.allRemoveCallBack (this);
									}
									return;
								}
								// Child
								if (data is GamePlayer.Inform) {
									return;
								}
							}
						}
					}
				}
				// Child
				{
					if (data is GameType) {
						GameType gameType = data as GameType;
						// all child
						{
							gameType.removeCallBackAllChildren (this);
						}
						return;
					}
					// remove all Child
					{
						data.removeCallBackAllChildren (this);
						return;
					}
				}
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is HintUI.UIData) {
				switch ((HintUI.UIData.Property)wrapProperty.n) {
				case HintUI.UIData.Property.gameData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case HintUI.UIData.Property.autoHint:
					{
						dirty = true;
					}
					break;
				case HintUI.UIData.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case HintUI.UIData.Property.ai:
					break;
				case HintUI.UIData.Property.editHintAIUIData:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// state
			if (wrapProperty.p is HintUI.UIData.State) {
				return;
			}
			// GameData
			{
				if (wrapProperty.p is GameData) {
					switch ((GameData.Property)wrapProperty.n) {
					case GameData.Property.gameType:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
							haveChangeBoard = true;
						}
						break;
					case GameData.Property.useRule:
						dirty = true;
						break;
					case GameData.Property.turn:
						break;
					case GameData.Property.timeControl:
						break;
					case GameData.Property.lastMove:
						break;
					case GameData.Property.state:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Parent
				{
					// Room
					if (wrapProperty.p is Room) {
						switch ((Room.Property)wrapProperty.n) {
						case Room.Property.name:
							break;
						case Room.Property.password:
							break;
						case Room.Property.users:
							break;
						case Room.Property.state:
							break;
						case Room.Property.contestManagers:
							break;
						case Room.Property.timeCreated:
							break;
						case Room.Property.chatRoom:
							break;
						case Room.Property.allowHint:
							dirty = true;
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Game
					{
						if (wrapProperty.p is Game) {
							switch ((Game.Property)wrapProperty.n) {
							case Game.Property.gamePlayers:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case Game.Property.requestDraw:
								break;
							case Game.Property.state:
								break;
							case Game.Property.gameData:
								break;
							case Game.Property.history:
								break;
							case Game.Property.gameAction:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case Game.Property.undoRedoRequest:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						// GameAction
						{
							if (wrapProperty.p is GameAction) {
								if (wrapProperty.p is WaitInputAction) {
									switch ((WaitInputAction.Property)wrapProperty.n) {
									case WaitInputAction.Property.serverTime:
										break;
									case WaitInputAction.Property.clientTime:
										break;
									case WaitInputAction.Property.sub:
										{
											ValueChangeUtils.replaceCallBack (this, syncs);
											dirty = true;
										}
										break;
									case WaitInputAction.Property.inputs:
										break;
									default:
										Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
										break;
									}
								}
								return;
							}
							if (wrapProperty.p is WaitInputAction.Sub) {
								return;
							}
						}
						// gamePlayers
						{
							if (wrapProperty.p is GamePlayer) {
								switch ((GamePlayer.Property)wrapProperty.n) {
								case GamePlayer.Property.playerIndex:
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
									Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
							// Child
							if (wrapProperty.p is GamePlayer.Inform) {
								if (wrapProperty.p is Human) {
									switch ((Human.Property)wrapProperty.n) {
									case Human.Property.playerId:
										dirty = true;
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
										Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
										break;
									}
									return;
								}
								return;
							}
						}
					}
				}
				// Child
				{
					if (wrapProperty.p is GameType) {
						// Weiqi have special case
						if (wrapProperty.p is Weiqi.Weiqi) {
							switch((Weiqi.Weiqi.Property)wrapProperty.n){
							case Weiqi.Weiqi.Property.b:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
									haveChangeBoard = true;
								}
								break;
							case Weiqi.Weiqi.Property.deadgroup:
								break;
							case Weiqi.Weiqi.Property.scoreOwnerMap:
								break;
							case Weiqi.Weiqi.Property.scoreOwnerMapSize:
								break;
							case Weiqi.Weiqi.Property.scoreBlack:
								break;
							case Weiqi.Weiqi.Property.scoreWhite:
								break;
							case Weiqi.Weiqi.Property.dame:
								break;
							case Weiqi.Weiqi.Property.score:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
						} else {
							if (Generic.IsAddCallBackInterface<T>()) {
								ValueChangeUtils.replaceCallBack (this, syncs);
							}
							dirty = true;
							haveChangeBoard = true;
						}
						return;
					}
					// Child
					// if (wrapProperty.p.findDataInParent<GameType> () != null) 
					{
						if (Generic.IsAddCallBackInterface<T>()) {
							ValueChangeUtils.replaceCallBack (this, syncs);
						}
						dirty = true;
						haveChangeBoard = true;
						return;
					} 
					/*else {
						Debug.LogError ("why not parent gameType: " + wrapProperty.p + "; " + this);
					}*/
				}
			}
			// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}