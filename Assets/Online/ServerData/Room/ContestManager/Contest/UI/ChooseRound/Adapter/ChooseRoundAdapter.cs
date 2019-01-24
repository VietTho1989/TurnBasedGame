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
	public class ChooseRoundAdapter : SRIA<ChooseRoundAdapter.UIData, ChooseRoundHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<Contest>> contest;

			public LP<ChooseRoundHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				contest,
				holders
			}

			public UIData() : base()
			{
				this.contest = new VP<ReferenceData<Contest>>(this, (byte)Property.contest, new ReferenceData<Contest>(null));
				this.holders = new LP<ChooseRoundHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<Round> rounds = new List<Round>();

			public void reset()
			{
				this.rounds.Clear();
			}

		}

		#endregion

		#region Adapter

		public ChooseRoundHolder holderPrefab;

		protected override ChooseRoundHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChooseRoundHolder.UIData uiData = new ChooseRoundHolder.UIData();
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

		protected override void UpdateViewsHolder (ChooseRoundHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoRounds;
		public static readonly TxtLanguage txtNoRounds = new TxtLanguage();

		static ChooseRoundAdapter()
		{
			txtNoRounds.add (Language.Type.vi, "Không có set nào cả");
		}

		#endregion

		public GameObject noRounds;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						Contest contest = this.data.contest.v.data;
						if (contest != null) {
							// check isLoadFull
							bool isLoadFull = true;
							{
								// dataIdentity
								if (isLoadFull) {
									DataIdentity dataIdentity = null;
									if (DataIdentity.clientMap.TryGetValue (contest, out dataIdentity)) {
										if (dataIdentity is ContestIdentity) {
											ContestIdentity contestIdentity = dataIdentity as ContestIdentity;
											if (contestIdentity.rounds != contest.rounds.vs.Count) {
												Debug.LogError ("contestManagers count error");
												isLoadFull = false;
											}
										} else {
											Debug.LogError ("why not contestIdentity");
										}
									}
								}
							}
							// process
							if (isLoadFull) {
								List<Round> rounds = new List<Round> ();
								// get
								{
									rounds.AddRange (contest.rounds.vs);
								}
								// Make list
								{
									int min = Mathf.Min (rounds.Count, _Params.rounds.Count);
									// Update
									{
										for (int i = 0; i < min; i++) {
											if (rounds [i] != _Params.rounds [i]) {
												// change param
												_Params.rounds [i] = rounds [i];
												// Update holder
												foreach (ChooseRoundHolder.UIData holder in this.data.holders.vs) {
													if (holder.ItemIndex == i) {
														holder.round.v = new ReferenceData<Round> (rounds [i]);
														break;
													}
												}
											}
										}
									}
									// Add or Remove
									{
										if (rounds.Count > min) {
											// Add
											int insertCount = rounds.Count - min;
											List<Round> addItems = rounds.GetRange (min, insertCount);
											_Params.rounds.AddRange (addItems);
											InsertItems (min, insertCount, false, false);
										} else {
											// Remove
											int deleteCount = _Params.rounds.Count - min;
											if (deleteCount > 0) {
												RemoveItems (min, deleteCount, false, false);
												_Params.rounds.RemoveRange (min, deleteCount);
											}
										}
									}
								}
								// NoRounds
								{
									if (noRounds != null) {
										bool haveAny = false;
										{
											foreach (ChooseRoundHolder.UIData holder in this.data.holders.vs) {
												if (holder.round.v.data != null) {
													ChooseRoundHolder holderUI = holder.findCallBack<ChooseRoundHolder> ();
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
										noRounds.SetActive (!haveAny);
									} else {
										Debug.LogError ("noRounds null: " + this);
									}
								}
							} else {
								Debug.LogError ("not load full");
								dirty = true;
							}
						} else {
							Debug.LogError ("server null: " + this);
						}
						// txt
						{
							if (tvNoRounds != null) {
								tvNoRounds.text = txtNoRounds.get ("Don't have any sets in match");
							} else {
								Debug.LogError ("tvNoRounds null: " + this);
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
					uiData.contest.allAddCallBack (this);
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
			if (data is Contest) {
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
					uiData.contest.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is Contest) {
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
				case UIData.Property.contest:
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
			if (wrapProperty.p is Contest) {
				switch ((Contest.Property)wrapProperty.n) {
				case Contest.Property.state:
					break;
				case Contest.Property.playerPerTeam:
					break;
				case Contest.Property.teams:
					break;
				case Contest.Property.roundFactory:
					break;
				case Contest.Property.rounds:
					dirty = true;
					break;
				case Contest.Property.requestNewRound:
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