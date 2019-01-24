using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class GlobalRoomContainer : RoomContainer
{

	public LP<Room> rooms;

	#region Constructor

	public enum Property
	{
		rooms
	}

	public GlobalRoomContainer() : base()
	{
		this.rooms = new LP<Room> (this, (byte)Property.rooms);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Global;
	}

	public override List<GameType.Type> getGameTypes ()
	{
		return GameType.AllEnableGameTypes;
	}

	#region makeRoom

	public void requestMakeRoom(uint userId, CreateRoomMessage makeRoom)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.makeRoom (userId, makeRoom);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is GlobalRoomContainerIdentity) {
						GlobalRoomContainerIdentity globalRoomContainerIdentity = dataIdentity as GlobalRoomContainerIdentity;
						globalRoomContainerIdentity.requestMakeRoom (userId, makeRoom);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			// Debug.LogError ("You cannot request");
		}
	}

	public void makeRoom(uint userId, CreateRoomMessage makeRoom){
		bool check = true;
		// Check already in a room
		{
			foreach (Room room in this.rooms.vs) {
				if (room.state.v is RoomStateNormal) {
					RoomUser roomUser = room.findUser (userId);
					if (roomUser != null && roomUser.isInsideRoom ()) {
						// Debug.LogError ("already inside this room: " + roomUser + ", " + room);
						check = false;
					}
				}
			}
		}
		if (check) {
			Room room = new Room ();
			{
				room.uid = this.rooms.makeId ();
				// roomInform
				{
					room.roomInform.v.creator.v.playerId.v = userId;
				}
				room.name.v = makeRoom.roomName;
				room.password.v = makeRoom.password;
				// State
				{
					// TODO Can hoan thien
				}
				// Time
				room.timeCreated.v = Global.getRealTimeInMiliSeconds ();
				// Add RoomUser
				{
					RoomUser roomUser = new RoomUser ();
					{
						roomUser.uid = room.users.makeId ();
						roomUser.role.v = RoomUser.Role.ADMIN;
						// Information
						{
							Human human = new Human ();
							{
								human.playerId.v = userId;
							}
							roomUser.inform.v = human;
						}
					}
					room.users.add (roomUser);
				}
				// allowHint
				{
					Server server = this.findDataInParent<Server> ();
					if (server != null) {
						if (server.type.v == Server.Type.Offline) {
							room.allowHint.v = Room.AllowHint.Allow;
						} else {
							room.allowHint.v = Room.AllowHint.OnlyWatcher;
						}
					} else {
						Debug.LogError ("server null");
					}
				}
				// add create room message
				{
					// find roomTopic
					RoomTopic roomTopic = null;
					{
						ChatRoom chatRoom = room.chatRoom.v;
						if (chatRoom != null) {
							roomTopic = chatRoom.topic.v as RoomTopic;
						} else {
							Debug.LogError ("chatRoom null: " + this);
						}
					}
					// Add message
					roomTopic.addRoomUserState (userId, ChatRoomUserStateContent.Action.Create);
				}
				// contestManager
				{
					ContestManager contestManager = new ContestManager ();
					{
						contestManager.uid = room.contestManagers.makeId ();
						// Add admin to lobby
						{
							ContestManagerStateLobby lobby = contestManager.state.v as ContestManagerStateLobby;
							if (lobby != null) {
								// Make Team
								{
									LobbyTeam lobbyTeam = new LobbyTeam ();
									{
										lobbyTeam.uid = lobby.teams.makeId ();
										lobbyTeam.teamIndex.v = 0;
										// players
										{
											LobbyPlayer lobbyPlayer = new LobbyPlayer ();
											{
												lobbyPlayer.uid = lobbyTeam.players.makeId ();
												lobbyPlayer.playerIndex.v = 0;
												// inform
												{
													Human human = new Human ();
													{
														human.uid = lobbyPlayer.inform.makeId ();
														human.playerId.v = userId;
													}
													lobbyPlayer.inform.v = human;
												}
												lobbyPlayer.isReady.v = false;
											}
											lobbyTeam.players.add (lobbyPlayer);
										}
									}
									lobby.teams.add (lobbyTeam);
								}
								//gameType
								{
									// find defaultGameDataFactory
									DefaultGameDataFactory defaultGameDataFactory = null;
									{
										// get singleContestFactory
										ContestManagerContentFactory contentManagerFactory = lobby.contentFactory.v;
										if (contentManagerFactory is SingleContestFactory) {
											SingleContestFactory singleContestFactory = contentManagerFactory as SingleContestFactory;
											// get normal round factory
											if (singleContestFactory.roundFactory.v is NormalRoundFactory) {
												NormalRoundFactory normalRoundFactory = singleContestFactory.roundFactory.v as NormalRoundFactory;
												// get gameFactory
												GameFactory gameFactory = normalRoundFactory.gameFactory.v;
												if (gameFactory != null) {
													defaultGameDataFactory = gameFactory.gameDataFactory.v as DefaultGameDataFactory;
												} else {
													Debug.LogError ("gameFactory null: " + this);
												}
											}
										}
									}
									// Process
									if (defaultGameDataFactory != null) {
										defaultGameDataFactory.makeNewDefaultGameType (makeRoom.gameType);
									} else {
										Debug.LogError ("defaultGameDataFactory null: " + this);
									}
								}
							} else {
								Debug.LogError ("why lobby null: " + this);
							}
						}
					}
					room.contestManagers.add (contestManager);
				}
			}
			this.rooms.add (room);
		} else {
			// Debug.Log ("You cannot make room");
			// TODO Can hoan thien
			// string replyMessage = "You cannot make room, you have already been in a room";
			// TargetSendMessage(connectionToClient, replyMessage);
		}
	}

	#endregion

}