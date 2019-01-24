using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class SwapRequestStateAsk : SwapRequest.State
	{

		public LP<Human> whoCanAsks;

		public LP<uint> accepts;

		#region Constructor

		public enum Property
		{
			whoCanAsks,
			accepts
		}

		public SwapRequestStateAsk() : base()
		{
			this.whoCanAsks = new LP<Human> (this, (byte)Property.whoCanAsks);
			this.accepts = new LP<uint> (this, (byte)Property.accepts);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Ask;
		}

		public static HashSet<uint> WhoCanAsk(Data data)
		{
			HashSet<uint> ret = new HashSet<uint> ();
			{
				if (data != null) {
					SwapRequestStateAsk swapRequestStateAsk = data.findDataInParent<SwapRequestStateAsk> ();
					if (swapRequestStateAsk != null) {
						// find change gamePlayerRight
						ChangeGamePlayerRight changeGamePlayerRight = null;
						{
							Room room = swapRequestStateAsk.findDataInParent<Room> ();
							if (room != null) {
								Rights.ChangeRights changeRights = room.changeRights.v;
								if (changeRights != null) {
									changeGamePlayerRight = changeRights.changeGamePlayerRight.v;
								} else {
									Debug.LogError ("changeRights null: " + data);
								}
							} else {
								Debug.LogError ("room null: " + data);
							}
						}
						// Process
						if (changeGamePlayerRight != null) {
							if (changeGamePlayerRight.onlyAdminNeed.v) {
								// add admin
								RoomUser admin = Room.findAdmin(swapRequestStateAsk);
								if (admin != null) {
									Human human = admin.inform.v;
									if (human != null) {
										ret.Add (human.playerId.v);
									} else {
										Debug.LogError ("human null: " + data);
									}
								} else {
									Debug.LogError ("admin null: " + data);
								}
							} else {
								// add swap player
								{
									SwapRequest swapRequest = swapRequestStateAsk.findDataInParent<SwapRequest> ();
									if (swapRequest != null) {
										if (swapRequest.inform.v is Human) {
											Human human = swapRequest.inform.v as Human;
											ret.Add (human.playerId.v);
										}
									} else {
										Debug.LogError ("swapRequest null: " + data);
									}
								}
								// add other player
								{
									ContestManagerStatePlay contestManagerStatePlay = swapRequestStateAsk.findDataInParent<ContestManagerStatePlay> ();
									if (contestManagerStatePlay != null) {
										foreach (MatchTeam matchTeam in contestManagerStatePlay.teams.vs) {
											foreach (TeamPlayer teamPlayer in matchTeam.players.vs) {
												if (teamPlayer.inform.v is Human) {
													Human human = teamPlayer.inform.v as Human;
													// check can add
													bool canAdd = true;
													{
														// remove, not ask player already left
														if (changeGamePlayerRight.canChangePlayerLeft.v) {
															// check inside room
															bool isInsideRoom = false;
															{
																RoomUser roomUser = Room.findUser (human.playerId.v, swapRequestStateAsk);
																if (roomUser != null) {
																	if (roomUser.isInsideRoom ()) {
																		isInsideRoom = true;
																	}
																} else {
																	Debug.LogError ("roomUser null: " + data);
																}
															}
															// Process
															if (!isInsideRoom) {
																canAdd = false;
															}
														}
													}
													// add
													if (canAdd) {
														ret.Add (human.playerId.v);
													}
												}
											}
										}
									} else {
										Debug.LogError ("contestManagerStatePlay null: " + data);
									}
								}
								// add admin
								{
									if (changeGamePlayerRight.needAdminAccept.v || ret.Count == 0) {
										RoomUser admin = Room.findAdmin (swapRequestStateAsk);
										if (admin != null) {
											Human human = admin.inform.v;
											if (human != null) {
												ret.Add (human.playerId.v);
											} else {
												Debug.LogError ("human null: " + data);
											}
										} else {
											Debug.LogError ("admin null: " + data);
										}
									}
								}
							}
						} else {
							Debug.LogError ("changeGamePlayerRight null: " + data);
						}
					} else {
						Debug.LogError ("swapRequestStateAsk null: " + data);
					}
				} else {
					Debug.LogError ("data null");
				}
			}
			return ret;
		}

		#region Accept

		public void requestAccept(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.accept (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SwapRequestStateAskIdentity) {
							SwapRequestStateAskIdentity swapRequestStateAskIdentity = dataIdentity as SwapRequestStateAskIdentity;
							swapRequestStateAskIdentity.requestAccept (userId);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request");
			}
		}

		public void accept(uint userId)
		{
			bool canAccept = true;
			{
				// check already accept
				if (canAccept) {
					if (this.accepts.vs.Contains (userId)) {
						Debug.LogError ("already accept: " + userId);
						canAccept = false;
					}
				}
				// check have right
				if(canAccept){
					bool canAsk = false;
					{
						foreach (Human human in this.whoCanAsks.vs) {
							if (human.playerId.v == userId) {
								canAsk = true;
								break;
							}
						}
					}
					if (!canAsk) {
						Debug.LogError ("Don't have right: " + this);
						canAccept = false;
					}
				}
			}
			if (canAccept) {
				this.accepts.add (userId);
			}
		}

		#endregion

		#region Refuse

		public void requestRefuse(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.accept (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SwapRequestStateAskIdentity) {
							SwapRequestStateAskIdentity swapRequestStateAskIdentity = dataIdentity as SwapRequestStateAskIdentity;
							swapRequestStateAskIdentity.requestRefuse (userId);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request");
			}
		}

		public void refuse(uint userId)
		{
			bool canRefuse = true;
			{
				// check have right
				if(canRefuse){
					bool canAsk = false;
					{
						foreach (Human human in this.whoCanAsks.vs) {
							if (human.playerId.v == userId) {
								canAsk = true;
								break;
							}
						}
					}
					if (!canAsk) {
						Debug.LogError ("Don't have right: " + this);
						canRefuse = false;
					}
				}
			}
			if (canRefuse) {
				SwapRequest swapRequest = this.findDataInParent<SwapRequest> ();
				if (swapRequest != null) {
					SwapRequestStateCancel swapRequestStateCancel = new SwapRequestStateCancel ();
					{
						swapRequestStateCancel.uid = swapRequest.state.makeId ();
						swapRequestStateCancel.whoCancel.v.playerId.v = userId;
					}
					swapRequest.state.v = swapRequestStateCancel;
				} else {
					Debug.LogError ("swapRequest null: " + this);
				}
			}
		}

		#endregion

	}
}