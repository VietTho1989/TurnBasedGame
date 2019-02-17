using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomUI : UIBehavior<RoomUI.UIData>
{

	#region UIData

	public class UIData : RoomContainerUI.UIData.Sub
	{
		
		public VP<ReferenceData<Room>> room;

		public VP<RoomStateUI.UIData> roomStateUIData;

		public VP<RoomBtnUI.UIData> roomBtnUIData;

		#region ContestManager

		public VP<ContestManagerUI.UIData> contestManagerUIData;

		public VP<RequestNewContestManagerUI.UIData> requestNewContestManagerUIData;

		#endregion

		public VP<ChooseContestManagerUI.UIData> chooseContestManagerUIData;

		public VP<RoomUserInformUI.UIData> roomUserInformUI;

		#region Constructor

		public enum Property
		{
			room,
			roomStateUIData,
			roomBtnUIData,

			contestManagerUIData,
			requestNewContestManagerUIData,

			chooseContestManagerUIData,
			roomUserInformUI
		}

		public UIData() : base()
		{
			this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
			this.roomStateUIData = new VP<RoomStateUI.UIData>(this, (byte)Property.roomStateUIData, new RoomStateUI.UIData());
			this.roomBtnUIData = new VP<RoomBtnUI.UIData>(this, (byte)Property.roomBtnUIData, new RoomBtnUI.UIData());

			this.contestManagerUIData = new VP<ContestManagerUI.UIData>(this, (byte)Property.contestManagerUIData, new ContestManagerUI.UIData());
			this.requestNewContestManagerUIData = new VP<RequestNewContestManagerUI.UIData>(this, (byte)Property.requestNewContestManagerUIData, new RequestNewContestManagerUI.UIData());
		
			this.chooseContestManagerUIData = new VP<ChooseContestManagerUI.UIData>(this, (byte)Property.chooseContestManagerUIData, null);
			this.roomUserInformUI = new VP<RoomUserInformUI.UIData>(this, (byte)Property.roomUserInformUI, null);
		}

		#endregion

		public override Type getType ()
		{
			return Type.RoomUI;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// roomUserInformUI
				if (!isProcess) {
					RoomUserInformUI.UIData roomUserInformUIData = this.roomUserInformUI.v;
					if (roomUserInformUIData != null) {
						isProcess = roomUserInformUIData.processEvent (e);
					} else {
						Debug.LogError ("roomUserInformUI null: " + this);
					}
				}
				// chooseContestManagerUIData
				if (!isProcess) {
					ChooseContestManagerUI.UIData chooseContestManagerUIData = this.chooseContestManagerUIData.v;
					if (chooseContestManagerUIData != null) {
						isProcess = chooseContestManagerUIData.processEvent (e);
					} else {
						Debug.LogError ("chooseContestManagerUIData null: " + this);
					}
				}
				// requestNewContestManagerUIData
				if (!isProcess) {
					RequestNewContestManagerUI.UIData requestNewContestManagerUIData = this.requestNewContestManagerUIData.v;
					if (requestNewContestManagerUIData != null) {
						isProcess = requestNewContestManagerUIData.processEvent (e);
					} else {
						Debug.LogError ("requestNewContestManagerUIData null: " + this);
					}
				}
				// contestManagerUIData
				if (!isProcess) {
					ContestManagerUI.UIData contestManagerUIData = this.contestManagerUIData.v;
					if (contestManagerUIData != null) {
						isProcess = contestManagerUIData.processEvent (e);
					} else {
						Debug.LogError ("contestManagerUIData null: " + this);
					}
				}
				// roomBtnUIData
				if (!isProcess) {
					RoomBtnUI.UIData roomBtnUIData = this.roomBtnUIData.v;
					if (roomBtnUIData != null) {
						isProcess = roomBtnUIData.processEvent (e);
					} else {
						Debug.LogError ("roomBtnUIData null: " + this);
					}
				}
			}
			return isProcess;
		}
	
	}

    #endregion

    #region txt, rect

    static RoomUI()
    {
        // rect
        {
            // roomBtnRect
            {
                // anchoredPosition: (-40.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -30.0); offsetMax: (-80.0, 0.0); sizeDelta: (-80.0, 30.0);
                roomBtnRect.anchoredPosition = new Vector3(-40.0f, 0.0f, 0.0f);
                roomBtnRect.anchorMin = new Vector2(0.0f, 1.0f);
                roomBtnRect.anchorMax = new Vector2(1.0f, 1.0f);
                roomBtnRect.pivot = new Vector2(0.5f, 1.0f);
                roomBtnRect.offsetMin = new Vector2(0.0f, -30.0f);
                roomBtnRect.offsetMax = new Vector2(-80.0f, 0.0f);
                roomBtnRect.sizeDelta = new Vector2(-80.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool haveNewContestManager = false;

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Room room = this.data.room.v.data;
				if (room != null) {
					// roomStateUIData
					{
						RoomStateUI.UIData roomStateUIData = this.data.roomStateUIData.v;
						if (roomStateUIData != null) {
							roomStateUIData.roomState.v = new ReferenceData<Room.State> (room.state.v);
						} else {
							Debug.LogError ("roomStateUIData null: " + this);
						}
					}
					// chon contestManager
					{
						// check isLoadFull
						bool isLoadFull = true;
						{
							// dataIdentity
							if (isLoadFull) {
								DataIdentity dataIdentity = null;
								if (DataIdentity.clientMap.TryGetValue (room, out dataIdentity)) {
									if (dataIdentity is RoomIdentity) {
										RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
										if (roomIdentity.contestManagers != room.contestManagers.vs.Count) {
											Debug.LogError ("contestManagers count error");
											isLoadFull = false;
										}
									} else {
										Debug.LogError ("why not roomIdentity");
									}
								}
							}
						}
						// process
						if (isLoadFull) {
							ContestManagerUI.UIData contestManagerUIData = this.data.contestManagerUIData.v;
							if (contestManagerUIData != null) {
								if (contestManagerUIData.contestManager.v.data == null ||
								    !room.contestManagers.vs.Contains (contestManagerUIData.contestManager.v.data)) {
									// Find contestManager
									ContestManager contestManager = null;
									{
										if (room.contestManagers.vs.Count > 0) {
											contestManager = room.contestManagers.vs [room.contestManagers.vs.Count - 1];
										}
									}
									// Set
									contestManagerUIData.contestManager.v = new ReferenceData<ContestManager> (contestManager);
								} else {
									if (haveNewContestManager) {
										ContestManager currentContestManager = contestManagerUIData.contestManager.v.data;
										if (currentContestManager != null) {
											if (currentContestManager.index.v == room.contestManagers.vs.Count - 2) {
												// set to new contestManager
												// Find contestManager
												ContestManager contestManager = null;
												{
													if (room.contestManagers.vs.Count > 0) {
														contestManager = room.contestManagers.vs [room.contestManagers.vs.Count - 1];
													}
												}
												// Set
												contestManagerUIData.contestManager.v = new ReferenceData<ContestManager> (contestManager);
											}
										} else {
											Debug.LogError ("currentContestManager null: " + this);
										}
									}
								}
							} else {
								Debug.LogError ("contestManagerUIData null: " + this);
							}
							haveNewContestManager = false;
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					}
					// requestNewContestManagerUIData
					{
						RequestNewContestManagerUI.UIData requestNewContestManagerUIData = this.data.requestNewContestManagerUIData.v;
						if (requestNewContestManagerUIData != null) {
							requestNewContestManagerUIData.requestNewContestManager.v = new ReferenceData<RequestNewContestManager> (room.requestNewContestManager.v);
						} else {
							Debug.LogError ("requestNewContestManagerUIData null: " + this);
						}
					}
					// chooseContestManagerUIData
					{
						ChooseContestManagerUI.UIData chooseContestManagerUIData = this.data.chooseContestManagerUIData.v;
						if (chooseContestManagerUIData != null) {
							chooseContestManagerUIData.room.v = new ReferenceData<Room> (room);
						} else {
							// Debug.LogError ("chooseContestManagerUIData null: " + this);
						}
					}
                    // siblingIndex
                    {
                        int siblingIndex = 0;
                        // contestManagerUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.contestManagerUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // roomBtnUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.roomBtnUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // requestNewContestManagerUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.requestNewContestManagerUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // chooseContestManagerUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.chooseContestManagerUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // roomUserInformUI
                        {
                            UIRectTransform.SetSiblingIndex(this.data.roomUserInformUI.v, siblingIndex);
                            siblingIndex++;
                        }
                        // roomStateUIData
                        if (roomStateUIContainer != null)
                        {
                            roomStateUIContainer.SetSiblingIndex(siblingIndex);
                            siblingIndex++;
                        }
                        else
                        {
                            Debug.LogError("roomStateUIContainer null");
                        }
                        // confirmBtnBackContainer
                        if (confirmBtnBackContainer != null)
                        {
                            confirmBtnBackContainer.SetSiblingIndex(siblingIndex);
                            siblingIndex++;
                        }
                        else
                        {
                            Debug.LogError("confirmBackContainer null");
                        }
                    }
                } else {
					Debug.LogError ("room null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBack

	public RoomStateUI roomStateUIPrefab;
	public Transform roomStateUIContainer;

	public RoomBtnUI roomBtnPrefab;
    private static readonly UIRectTransform roomBtnRect = new UIRectTransform();

	public ContestManagerUI contestManagerPrefab;
    private static readonly UIRectTransform contestManagerRect = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight, 0);

	public ChooseContestManagerUI chooseContestManagerPrefab;
    private static readonly UIRectTransform chooseContestManagerRect = UIConstants.FullParent;

	public RequestNewContestManagerUI requestNewContestManagerPrefab;
    private static readonly UIRectTransform requestNewContestManagerRect = UIConstants.FullParent;

	public RoomUserInformUI roomUserInformPrefab;
    private static readonly UIRectTransform roomUserInformRect = UIConstants.FullParent;

	public Transform confirmBtnBackContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.room.allAddCallBack (this);
				uiData.roomStateUIData.allAddCallBack (this);
				uiData.roomBtnUIData.allAddCallBack (this);
				uiData.contestManagerUIData.allAddCallBack (this);
				uiData.requestNewContestManagerUIData.allAddCallBack (this);
				uiData.chooseContestManagerUIData.allAddCallBack (this);
				uiData.roomUserInformUI.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// Room
			{
				if (data is Room) {
					Room room = data as Room;
					// Child
					{
						room.contestManagers.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is ContestManager) {
					haveNewContestManager = true;
					dirty = true;
					return;
				}
			}
			if (data is RoomStateUI.UIData) {
				RoomStateUI.UIData roomStateUIData = data as RoomStateUI.UIData;
				// UI
				{
					UIUtils.Instantiate (roomStateUIData, roomStateUIPrefab, roomStateUIContainer);
				}
				dirty = true;
				return;
			}
			if (data is RoomBtnUI.UIData) {
				RoomBtnUI.UIData roomBtnUIData = data as RoomBtnUI.UIData;
				// UI
				{
					UIUtils.Instantiate (roomBtnUIData, roomBtnPrefab, this.transform, roomBtnRect);
				}
				dirty = true;
				return;
			}
			if (data is ContestManagerUI.UIData) {
				ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (contestManagerUIData, contestManagerPrefab, this.transform, contestManagerRect);
				}
				dirty = true;
				return;
			}
			if (data is RequestNewContestManagerUI.UIData) {
				RequestNewContestManagerUI.UIData requestNewContestManagerUIData = data as RequestNewContestManagerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (requestNewContestManagerUIData, requestNewContestManagerPrefab, this.transform, requestNewContestManagerRect);
				}
				dirty = true;
				return;
			}
			if (data is ChooseContestManagerUI.UIData) {
				ChooseContestManagerUI.UIData chooseContestManagerUIData = data as ChooseContestManagerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (chooseContestManagerUIData, chooseContestManagerPrefab, this.transform, chooseContestManagerRect);
				}
				dirty = true;
				return;
			}
			if (data is RoomUserInformUI.UIData) {
				RoomUserInformUI.UIData roomUserInformUIData = data as RoomUserInformUI.UIData;
				// UI
				{
					UIUtils.Instantiate (roomUserInformUIData, roomUserInformPrefab, this.transform, roomUserInformRect);
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
				uiData.room.allRemoveCallBack (this);
				uiData.roomStateUIData.allRemoveCallBack (this);
				uiData.roomBtnUIData.allRemoveCallBack (this);
				uiData.contestManagerUIData.allRemoveCallBack (this);
				uiData.requestNewContestManagerUIData.allRemoveCallBack (this);
				uiData.chooseContestManagerUIData.allRemoveCallBack (this);
				uiData.roomUserInformUI.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// Room
			{
				if (data is Room) {
					Room room = data as Room;
					// Child
					{
						room.contestManagers.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is ContestManager) {
					return;
				}
			}
			if (data is RoomStateUI.UIData) {
				RoomStateUI.UIData roomStateUIData = data as RoomStateUI.UIData;
				// UI
				{
					roomStateUIData.removeCallBackAndDestroy (typeof(RoomStateUI));
				}
				return;
			}
			if (data is RoomBtnUI.UIData) {
				RoomBtnUI.UIData roomBtnUIData = data as RoomBtnUI.UIData;
				// UI
				{
					roomBtnUIData.removeCallBackAndDestroy (typeof(RoomBtnUI));
				}
				return;
			}
			if (data is ContestManagerUI.UIData) {
				ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
				// UI
				{
					contestManagerUIData.removeCallBackAndDestroy (typeof(ContestManagerUI));
				}
				return;
			}
			if (data is RequestNewContestManagerUI.UIData) {
				RequestNewContestManagerUI.UIData requestNewContestManagerUIData = data as RequestNewContestManagerUI.UIData;
				// UI
				{
					requestNewContestManagerUIData.removeCallBackAndDestroy (typeof(RequestNewContestManagerUI));
				}
				return;
			}
			if (data is ChooseContestManagerUI.UIData) {
				ChooseContestManagerUI.UIData chooseContestManagerUIData = data as ChooseContestManagerUI.UIData;
				// UI
				{
					chooseContestManagerUIData.removeCallBackAndDestroy (typeof(ChooseContestManagerUI));
				}
				return;
			}
			if (data is RoomUserInformUI.UIData) {
				RoomUserInformUI.UIData roomUserInformUIData = data as RoomUserInformUI.UIData;
				// UI
				{
					roomUserInformUIData.removeCallBackAndDestroy (typeof(RoomUserInformUI));
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
			case UIData.Property.room:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.roomStateUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.roomBtnUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.contestManagerUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.requestNewContestManagerUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.chooseContestManagerUIData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.roomUserInformUI:
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
			// Room
			{
				if (wrapProperty.p is Room) {
					switch ((Room.Property)wrapProperty.n) {
					case Room.Property.changeRights:
						break;
					case Room.Property.name:
						break;
					case Room.Property.password:
						break;
					case Room.Property.users:
						break;
					case Room.Property.state:
						break;
					case Room.Property.contestManagers:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Room.Property.timeCreated:
						break;
					case Room.Property.chatRoom:
						break;
					case Room.Property.allowHint:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is ContestManager) {
					return;
				}
			}
			if (wrapProperty.p is RoomStateUI.UIData) {
				return;
			}
			if (wrapProperty.p is RoomBtnUI.UIData) {
				return;
			}
			if (wrapProperty.p is ContestManagerUI.UIData) {
				return;
			}
			if (wrapProperty.p is RequestNewContestManagerUI.UIData) {
				return;
			}
			if (wrapProperty.p is ChooseContestManagerUI.UIData) {
				return;
			}
			if (wrapProperty.p is RoomUserInformUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}