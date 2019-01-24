using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match.Elimination
{
	public class ChooseBracketContestAdapter : SRIA<ChooseBracketContestAdapter.UIData, ChooseBracketContestHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<Bracket>> bracket;

			public LP<ChooseBracketContestHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				bracket,
				holders
			}

			public UIData() : base()
			{
				this.bracket = new VP<ReferenceData<Bracket>>(this, (byte)Property.bracket, new ReferenceData<Bracket>(null));
				this.holders = new LP<ChooseBracketContestHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<BracketContest> bracketContests = new List<BracketContest>();

			public void reset()
			{
				this.bracketContests.Clear ();
			}

		}

		#endregion

		#region Adapter

		public ChooseBracketContestHolder holderPrefab;

		protected override ChooseBracketContestHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChooseBracketContestHolder.UIData uiData = new ChooseBracketContestHolder.UIData ();
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

		protected override void UpdateViewsHolder (ChooseBracketContestHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoBracketContests;
		public static readonly TxtLanguage txtNoBracketContests = new TxtLanguage();

		static ChooseBracketContestAdapter()
		{
			txtNoBracketContests.add (Language.Type.vi, "Không có trận đấu nhánh nào cả");
		}

		#endregion

		public GameObject noBracketContests;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						Bracket bracket = this.data.bracket.v.data;
						if (bracket != null) {
							// check isLoadFull
							bool isLoadFull = true;
							{
								// dataIdentity
								if (isLoadFull) {
									DataIdentity dataIdentity = null;
									if (DataIdentity.clientMap.TryGetValue (bracket, out dataIdentity)) {
										if (dataIdentity is BracketIdentity) {
											BracketIdentity bracketIdentity = dataIdentity as  BracketIdentity;
											if (bracketIdentity.bracketContests != bracket.bracketContests.vs.Count) {
												Debug.LogError ("bracket bracketContest count error");
												isLoadFull = false;
											}
										} else {
											Debug.LogError ("why not bracketIdentity");
										}
									}
								}
							}
							// process
							if (isLoadFull) {
								List<BracketContest> bracketContests = new List<BracketContest> ();
								// get
								{
									foreach (BracketContest bracketContest in bracket.bracketContests.vs) {
										if (bracketContest.isActive.v) {
											bracketContests.Add (bracketContest);
										}
									}
								}
								// Make list
								{
									int min = Mathf.Min (bracketContests.Count, _Params.bracketContests.Count);
									// Update
									{
										for (int i = 0; i < min; i++) {
											if (bracketContests [i] != _Params.bracketContests [i]) {
												// change param
												_Params.bracketContests [i] = bracketContests [i];
												// Update holder
												foreach (ChooseBracketContestHolder.UIData holder in this.data.holders.vs) {
													if (holder.ItemIndex == i) {
														holder.bracketContest.v = new ReferenceData<BracketContest> (bracketContests [i]);
														break;
													}
												}
											}
										}
									}
									// Add or Remove
									{
										if (bracketContests.Count > min) {
											// Add
											int insertCount = bracketContests.Count - min;
											List<BracketContest> addItems = bracketContests.GetRange (min, insertCount);
											_Params.bracketContests.AddRange (addItems);
											InsertItems (min, insertCount, false, false);
										} else {
											// Remove
											int deleteCount = _Params.bracketContests.Count - min;
											if (deleteCount > 0) {
												RemoveItems (min, deleteCount, false, false);
												_Params.bracketContests.RemoveRange (min, deleteCount);
											}
										}
									}
								}
								// NoBracketContests
								{
									if (noBracketContests != null) {
										bool haveAny = false;
										{
											foreach (ChooseBracketContestHolder.UIData holder in this.data.holders.vs) {
												if (holder.bracketContest.v.data != null) {
													ChooseBracketContestHolder holderUI = holder.findCallBack<ChooseBracketContestHolder> ();
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
										noBracketContests.SetActive (!haveAny);
									} else {
										Debug.LogError ("noBracketContests null: " + this);
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
							if (tvNoBracketContests != null) {
								tvNoBracketContests.text = txtNoBracketContests.get ("Don't have any bracket matchs");
							} else {
								Debug.LogError ("tvNoBracketContests null: " + this);
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
					uiData.bracket.allAddCallBack (this);
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
				if (data is Bracket) {
					Bracket bracket = data as Bracket;
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					// Child
					{
						bracket.bracketContests.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is BracketContest) {
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
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.bracket.allRemoveCallBack (this);
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
				if (data is Bracket) {
					Bracket bracket = data as Bracket;
					// Child
					{
						bracket.bracketContests.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is BracketContest) {
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
				case UIData.Property.bracket:
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
			{
				if (wrapProperty.p is Bracket) {
					switch ((Bracket.Property)wrapProperty.n) {
					case Bracket.Property.isActive:
						dirty = true;
						break;
					case Bracket.Property.state:
						break;
					case Bracket.Property.index:
						break;
					case Bracket.Property.bracketContests:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case Bracket.Property.byeTeamIndexs:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is BracketContest) {
					switch ((BracketContest.Property)wrapProperty.n) {
					case BracketContest.Property.isActive:
						dirty = true;
						break;
					case BracketContest.Property.index:
						break;
					case BracketContest.Property.teamIndexs:
						break;
					case BracketContest.Property.contest:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}