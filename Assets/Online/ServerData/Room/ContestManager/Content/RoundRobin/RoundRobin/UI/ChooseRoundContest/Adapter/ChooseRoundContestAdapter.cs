using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match.RoundRobin
{
	public class ChooseRoundContestAdapter : SRIA<ChooseRoundContestAdapter.UIData, ChooseRoundContestHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<RoundRobin>> roundRobin;

			public LP<ChooseRoundContestHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				roundRobin,
				holders
			}

			public UIData() : base()
			{
				this.roundRobin = new VP<ReferenceData<RoundRobin>>(this, (byte)Property.roundRobin, new ReferenceData<RoundRobin>(null));
				this.holders = new LP<ChooseRoundContestHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<RoundContest> roundContests = new List<RoundContest>();

			public void reset()
			{
				this.roundContests.Clear ();
			}

		}

		#endregion

		#region Adapter

		public ChooseRoundContestHolder holderPrefab;

		protected override ChooseRoundContestHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChooseRoundContestHolder.UIData uiData = new ChooseRoundContestHolder.UIData ();
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

		protected override void UpdateViewsHolder (ChooseRoundContestHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoRoundContests;
		public static readonly TxtLanguage txtNoRoundContests = new TxtLanguage();

		static ChooseRoundContestAdapter()
		{
			txtNoRoundContests.add (Language.Type.vi, "Không có trận đấu vòng tròn nào cả");
		}

		#endregion

		public GameObject noRoundContests;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						RoundRobin roundRobin = this.data.roundRobin.v.data;
						if (roundRobin != null) {
							// check isLoadFull
							bool isLoadFull = true;
							{
								// dataIdentity
								if (isLoadFull) {
									DataIdentity dataIdentity = null;
									if (DataIdentity.clientMap.TryGetValue (roundRobin, out dataIdentity)) {
										if (dataIdentity is RoundRobinIdentity) {
											RoundRobinIdentity roundRobinIdentity = dataIdentity as RoundRobinIdentity;
											if (roundRobinIdentity.roundContests != roundRobin.roundContests.vs.Count) {
												Debug.LogError ("roundRobin roundContest count error");
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
								List<RoundContest> roundContests = new List<RoundContest> ();
								// get
								{
									roundContests.AddRange (roundRobin.roundContests.vs);
								}
								// Make list
								{
									int min = Mathf.Min (roundContests.Count, _Params.roundContests.Count);
									// Update
									{
										for (int i = 0; i < min; i++) {
											if (roundContests [i] != _Params.roundContests [i]) {
												// change param
												_Params.roundContests [i] = roundContests [i];
												// Update holder
												foreach (ChooseRoundContestHolder.UIData holder in this.data.holders.vs) {
													if (holder.ItemIndex == i) {
														holder.roundContest.v = new ReferenceData<RoundContest> (roundContests [i]);
														break;
													}
												}
											}
										}
									}
									// Add or Remove
									{
										if (roundContests.Count > min) {
											// Add
											int insertCount = roundContests.Count - min;
											List<RoundContest> addItems = roundContests.GetRange (min, insertCount);
											_Params.roundContests.AddRange (addItems);
											InsertItems (min, insertCount, false, false);
										} else {
											// Remove
											int deleteCount = _Params.roundContests.Count - min;
											if (deleteCount > 0) {
												RemoveItems (min, deleteCount, false, false);
												_Params.roundContests.RemoveRange (min, deleteCount);
											}
										}
									}
								}
								// NoRoundContests
								{
									if (noRoundContests != null) {
										bool haveAny = false;
										{
											foreach (ChooseRoundContestHolder.UIData holder in this.data.holders.vs) {
												if (holder.roundContest.v.data != null) {
													ChooseRoundContestHolder holderUI = holder.findCallBack<ChooseRoundContestHolder> ();
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
										noRoundContests.SetActive (!haveAny);
									} else {
										Debug.LogError ("noRoundContests null: " + this);
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
							if (tvNoRoundContests != null) {
								tvNoRoundContests.text = txtNoRoundContests.get ("Don't have any roundrobin matchs");
							} else {
								Debug.LogError ("tvNoRoundContests null: " + this);
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
					uiData.roundRobin.allAddCallBack (this);
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
			if (data is RoundRobin) {
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
					uiData.roundRobin.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Setting
			if (data is Setting) {
				return;
			}
			// Child
			if (data is RoundRobin) {
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
				case UIData.Property.roundRobin:
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
			if (wrapProperty.p is RoundRobin) {
				switch ((RoundRobin.Property)wrapProperty.n) {
				case RoundRobin.Property.state:
					break;
				case RoundRobin.Property.index:
					break;
				case RoundRobin.Property.roundContests:
					dirty = true;
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