using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;

/**
 * Ca client lan server deu co behavior nay
 * */
public class WaitAIInputUpdate : UpdateBehavior<WaitAIInput>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// find isClient
				bool isClient = false;
				{
					Server server = this.data.findDataInParent<Server> ();
					if (server != null) {
						if (server.type.v == Server.Type.Client) {
							isClient = true;
						}
					} else {
						Debug.LogError ("server null: " + this);
					}
				}
				bool isGettingSolvedMove = false;
				// Check null
				{
					if (this.data.sub.v == null) {
						WaitAIInputNone waitAIInputNone = this.data.sub.newOrOld<WaitAIInputNone> ();
						{

						}
						this.data.sub.v = waitAIInputNone;
					}
				}
				// Check can input
				bool canInput = false;
				{
					// Check already have input
					bool alreadyHaveInput = false;
					{
						WaitInputAction waitInputAction = this.data.findDataInParent<WaitInputAction> ();
						if (waitInputAction != null) {
							foreach (InputData inputData in waitInputAction.inputs.vs) {
								if (inputData.userSend.v == this.data.userThink.v) {
									alreadyHaveInput = true;
								}
							}
						} else {
							Debug.LogError ("waitInputAction null: " + this);
						}
					}
					// Check already send
					bool alreadySend = false;
					{
						WaitInputAction waitInputAction = this.data.findDataInParent<WaitInputAction> ();
						if (waitInputAction != null) {
							ClientInput clientInput = waitInputAction.clientInput.v;
							if (clientInput != null) {
								if (clientInput.sub.v != null) {
									if (clientInput.sub.v.getType () == ClientInput.Sub.Type.Send) {
										alreadySend = true;
									}
								} else {
									Debug.LogError ("sub null: " + this);
								}
							} else {
								Debug.LogError ("clientInput null: " + this);
							}
						} else {
							Debug.LogError ("waitInputAction null: " + this);
						}
					}
					// Process
					if (!alreadyHaveInput && !alreadySend) {
						canInput = true;
					} else {
						// Debug.LogError ("already have input: " + this);
					}
				}
				if (canInput) {
					// find have solvedMove
					bool isHaveSolvedMove = false;
					{
						// find GameType
						GameType gameType = null;
						{
							Game game = this.data.findDataInParent<Game> ();
							if (game != null) {
								GameData gameData = game.gameData.v;
								if (gameData != null) {
									gameType = gameData.gameType.v;
								} else {
									Debug.LogError ("gameData null: " + this);
								}
							} else {
								Debug.LogError ("game null: " + this);
							}
						}
						// process
						if (gameType != null) {
							isHaveSolvedMove = gameType.isHaveSolvedMove ();
						} else {
							Debug.LogError ("gameType null: " + this);
						}
					}
					// process
					if (isHaveSolvedMove) {
						Debug.LogError ("have solved move");
						Server.Type serverType = Server.Type.Offline;
						{
							Server server = this.data.findDataInParent<Server> ();
							if (server != null) {
								serverType = server.type.v;
							} else {
								Debug.LogError ("server null: " + this);
							}
						}
						if (serverType != Server.Type.Client) {
							// TODO hien gio get solved move van search o client
							// chuyen sang get solved move
							WaitAIInputSolved waitAIInputSolved = this.data.sub.newOrOld<WaitAIInputSolved> ();
							{

							}
							this.data.sub.v = waitAIInputSolved;
							isGettingSolvedMove = true;
						} else {
							// chuyen sang none
							WaitAIInputNone waitAIInputNone = this.data.sub.newOrOld<WaitAIInputNone> ();
							{

							}
							this.data.sub.v = waitAIInputNone;
						}
					} else {
						// find canSearch
						bool canSearch = false;
						{
							if (this.data.userThink.v == Server.getProfileUserId (this.data)) {
								if (!isClient) {
									canSearch = true;
								} else if (!this.data.isGettingSolvedMove.v) {
									canSearch = true;
								}
							}
						}
						// search
						if (canSearch) {
							// search
							WaitAIInputSearch search = this.data.sub.newOrOld<WaitAIInputSearch> ();
							{
								search.state.v = WaitAIInputSearch.State.Search;
							}
							this.data.sub.v = search;
						} else {
							Debug.LogError ("not correct user: " + this);
							// chuyen sang none
							WaitAIInputNone waitAIInputNone = this.data.sub.newOrOld<WaitAIInputNone> ();
							{

							}
							this.data.sub.v = waitAIInputNone;
						}
					}
				} else {
					// Chuyen ve none
					WaitAIInputNone waitAIInputNone = this.data.sub.newOrOld<WaitAIInputNone>();
					{

					}
					this.data.sub.v = waitAIInputNone;
				}
				// set isGettingSolvedMove
				if (!isClient) {
					this.data.isGettingSolvedMove.v = isGettingSolvedMove;
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

	#region implement callBacks

	private WaitInputAction waitInputAction = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is WaitAIInput) {
			WaitAIInput waitAIInput = data as WaitAIInput;
			// Parent
			{
				DataUtils.addParentCallBack (waitAIInput, this, ref this.waitInputAction);
			}
			// Child
			{
				waitAIInput.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Parent
		{
			if (data is WaitInputAction) {
				WaitInputAction waitInputAction = data as WaitInputAction;
				// Child
				{
					waitInputAction.clientInput.allAddCallBack (this);
					waitInputAction.inputs.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				// ClientInput
				{
					if (data is ClientInput) {
						ClientInput clientInput = data as ClientInput;
						{
							clientInput.sub.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is ClientInput.Sub) {
						dirty = true;
						return;
					}
				}
				// InputData
				if (data is InputData) {
					dirty = true;
					return;
				}
			}
		}
		// Child
		if (data is WaitAIInput.Sub) {
			WaitAIInput.Sub sub = data as WaitAIInput.Sub;
			{
				switch(sub.getType()){
				case WaitAIInput.Sub.Type.None:
					{
						WaitAIInputNone none = sub as WaitAIInputNone;
						UpdateUtils.makeUpdate<WaitAIInputNoneUpdate, WaitAIInputNone> (none, this.transform);
					}
					break;
				case WaitAIInput.Sub.Type.Search:
					{
						WaitAIInputSearch search = sub as WaitAIInputSearch;
						UpdateUtils.makeUpdate<WaitAIInputSearchUpdate, WaitAIInputSearch> (search, this.transform);
					}
					break;
				case WaitAIInput.Sub.Type.Solved:
					{
						WaitAIInputSolved solved = sub as WaitAIInputSolved;
						UpdateUtils.makeUpdate<WaitAIInputSolvedUpdate, WaitAIInputSolved> (solved, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown sub: " + sub.getType () + "; " + this);
					break;	
				};
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is WaitAIInput) {
			WaitAIInput waitAIInput = data as WaitAIInput;
			// Parent
			{
				DataUtils.removeParentCallBack (waitAIInput, this, ref this.waitInputAction);
			}
			// Child
			{
				waitAIInput.sub.allRemoveCallBack (this);
			}
			this.setDataNull (waitAIInput);
			return;
		}
		// Parent
		{
			if (data is WaitInputAction) {
				WaitInputAction waitInputAction = data as WaitInputAction;
				// Child
				{
					waitInputAction.clientInput.allRemoveCallBack (this);
					waitInputAction.inputs.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				// ClientInput
				{
					if (data is ClientInput) {
						ClientInput clientInput = data as ClientInput;
						{
							clientInput.sub.allRemoveCallBack (this);
						}
						return;
					}
					if (data is ClientInput.Sub) {
						return;
					}
				}
				// InputData
				if (data is InputData) {
					return;
				}
			}
		}
		// Child
		if (data is WaitAIInput.Sub) {
			WaitAIInput.Sub sub = data as WaitAIInput.Sub;
			{
				switch(sub.getType()){
				case WaitAIInput.Sub.Type.None:
					{
						WaitAIInputNone none = sub as WaitAIInputNone;
						none.removeCallBackAndDestroy (typeof(WaitAIInputNoneUpdate));
					}
					break;
				case WaitAIInput.Sub.Type.Search:
					{
						WaitAIInputSearch search = sub as WaitAIInputSearch;
						search.removeCallBackAndDestroy (typeof(WaitAIInputSearchUpdate));
					}
					break;
				case WaitAIInput.Sub.Type.Solved:
					{
						WaitAIInputSolved solved = sub as WaitAIInputSolved;
						solved.removeCallBackAndDestroy (typeof(WaitAIInputSolvedUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown sub: " + sub.getType () + "; " + this);
					break;	
				};
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is WaitAIInput) {
			switch ((WaitAIInput.Property)wrapProperty.n) {
			case WaitAIInput.Property.userThink:
				dirty = true;
				break;
			case WaitAIInput.Property.reThink:
				break;
			case WaitAIInput.Property.sub:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case WaitAIInput.Property.isGettingSolvedMove:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Parent
		{
			if (wrapProperty.p is WaitInputAction) {
				switch ((WaitInputAction.Property)wrapProperty.n) {
				case WaitInputAction.Property.serverTime:
					break;
				case WaitInputAction.Property.clientTime:
					break;
				case WaitInputAction.Property.sub:
					break;
				case WaitInputAction.Property.inputs:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case WaitInputAction.Property.clientInput:
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
				// ClientInput
				{
					if (wrapProperty.p is ClientInput) {
						switch ((ClientInput.Property)wrapProperty.n) {
						case ClientInput.Property.sub:
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
					if (wrapProperty.p is ClientInput.Sub) {
						return;
					}
				}
				// InputData
				if (wrapProperty.p is InputData) {
					switch ((InputData.Property)wrapProperty.n) {
					case InputData.Property.gameMove:
						break;
					case InputData.Property.userSend:
						dirty = true;
						break;
					case InputData.Property.clientTime:
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
		if (wrapProperty.p is WaitAIInput.Sub) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}