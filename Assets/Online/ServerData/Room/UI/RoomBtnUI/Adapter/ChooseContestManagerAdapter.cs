using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match
{
	public class ChooseContestManagerAdapter : SRIA<ChooseContestManagerAdapter.UIData, ChooseContestManagerHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<Room>> room;

			public LP<ChooseContestManagerHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				room,
				holders
			}

			public UIData() : base()
			{
				this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
				this.holders = new LP<ChooseContestManagerHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<ContestManager> contestManagers = new List<ContestManager>();

			public void reset()
			{
				this.contestManagers.Clear ();
			}

		}

		#endregion

		#region Adapter

		public ChooseContestManagerHolder holderPrefab;

		protected override ChooseContestManagerHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChooseContestManagerHolder.UIData uiData = new ChooseContestManagerHolder.UIData();
			{
				// add
				{
					uiData.uid = this.data.holders.makeId ();
					this.data.holders.add (uiData);
				}
				// MakeUI
				if (holderPrefab != null) {
					uiData.Init (holderPrefab.gameObject, itemIndex);
				} else {
					Debug.LogError ("holderPrefab null: " + this);
				}
			}
			return uiData;
		}

		protected override void UpdateViewsHolder (ChooseContestManagerHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoContestManagers;
		public static readonly TxtLanguage txtNoContestManagers = new TxtLanguage ();

		static ChooseContestManagerAdapter()
		{
			txtNoContestManagers.add (Language.Type.vi, "Không có giải đấu nào");
		}

		#endregion

		public GameObject noContestManagers;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						Room room = this.data.room.v.data;
						if (room != null) {
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
								List<ContestManager> contestManagers = new List<ContestManager> ();
								// get
								{
									contestManagers.AddRange (room.contestManagers.vs);
								}
								// Make list
								{
									int min = Mathf.Min (contestManagers.Count, _Params.contestManagers.Count);
									// Update
									{
										for (int i = 0; i < min; i++) {
											if (contestManagers [i] != _Params.contestManagers [i]) {
												// change param
												_Params.contestManagers [i] = contestManagers [i];
												// Update holder
												foreach (ChooseContestManagerHolder.UIData holder in this.data.holders.vs) {
													if (holder.ItemIndex == i) {
														holder.contestManager.v = new ReferenceData<ContestManager> (contestManagers [i]);
														break;
													}
												}
											}
										}
									}
									// Add or Remove
									{
										if (contestManagers.Count > min) {
											// Add
											int insertCount = contestManagers.Count - min;
											List<ContestManager> addItems = contestManagers.GetRange (min, insertCount);
											_Params.contestManagers.AddRange (addItems);
											InsertItems (min, insertCount, false, false);
										} else {
											// Remove
											int deleteCount = _Params.contestManagers.Count - min;
											if (deleteCount > 0) {
												RemoveItems (min, deleteCount, false, false);
												_Params.contestManagers.RemoveRange (min, deleteCount);
											}
										}
									}
								}
								// NoContestManagers
								{
									if (noContestManagers != null) {
										bool haveAny = false;
										{
											foreach (ChooseContestManagerHolder.UIData holder in this.data.holders.vs) {
												if (holder.contestManager.v.data != null) {
													ChooseContestManagerHolder holderUI = holder.findCallBack<ChooseContestManagerHolder> ();
													if (holderUI != null) {
														if (holderUI.gameObject.activeSelf) {
															haveAny = true;
															break;
														}
													} else {
														Debug.LogError ("holderUI null: " + this);
													}
												}
											}
										}
										noContestManagers.SetActive (!haveAny);
									} else {
										Debug.LogError ("noContestManagers null: " + this);
									}
								}
							} else {
								Debug.LogError ("not load full");
								dirty = true;
							}
						} else {
							Debug.LogError ("room null: " + this);
						}
						// txt
						{
							if (tvNoContestManagers != null) {
								tvNoContestManagers.text = txtNoContestManagers.get ("Don't have any tournaments");
							} else {
								Debug.LogError ("tvNoContestManagers null: " + this);
							}
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					Debug.LogError ("not initalized: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.room.allAddCallBack (this);
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
			if (data is Room) {
				// reset
				{
					if (this.data != null) {
						this.data.reset ();
					} else {
						Debug.LogError ("data null: " + this);
					}
				}
				dirty = true;
				return;
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
					uiData.room.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is Room) {
				return;
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
				case UIData.Property.holders:
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
				case Room.Property.requestNewContestManager:
					break;
				case Room.Property.contestManagers:
					dirty = true;
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}