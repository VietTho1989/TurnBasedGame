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
	public class ChooseBracketAdapter : SRIA<ChooseBracketAdapter.UIData, ChooseBracketHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<EliminationRound>> eliminationRound;

			public LP<ChooseBracketHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				eliminationRound,
				holders
			}

			public UIData() : base()
			{
				this.eliminationRound = new VP<ReferenceData<EliminationRound>>(this, (byte)Property.eliminationRound, new ReferenceData<EliminationRound>(null));
				this.holders = new LP<ChooseBracketHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<Bracket> brackets = new List<Bracket>();

			public void reset()
			{
				this.brackets.Clear();
			}

		}

		#endregion

		#region Adapter

		public ChooseBracketHolder holderPrefab;

		protected override ChooseBracketHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChooseBracketHolder.UIData uiData = new ChooseBracketHolder.UIData ();
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

		protected override void UpdateViewsHolder (ChooseBracketHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		#region txt

		public Text tvNoBrackets;
		public static readonly TxtLanguage txtNoBrackets = new TxtLanguage();

		static ChooseBracketAdapter()
		{
			txtNoBrackets.add (Language.Type.vi, "Không có nhánh nào cả");
		}

		#endregion

		public GameObject noBrackets;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						EliminationRound eliminationRound = this.data.eliminationRound.v.data;
						if (eliminationRound != null) {
							// check isLoadFull
							bool isLoadFull = true;
							{
								// dataIdentity
								if (isLoadFull) {
									DataIdentity dataIdentity = null;
									if (DataIdentity.clientMap.TryGetValue (eliminationRound, out dataIdentity)) {
										if (dataIdentity is EliminationRoundIdentity) {
											EliminationRoundIdentity eliminationRoundIdentity = dataIdentity as  EliminationRoundIdentity;
											if (eliminationRoundIdentity.brackets != eliminationRound.brackets.vs.Count) {
												Debug.LogError ("eliminationRound bracket count error");
												isLoadFull = false;
											}
										} else {
											Debug.LogError ("why not eliminationRoundIdentity");
										}
									}
								}
							}
							// process
							if (isLoadFull) {
								List<Bracket> brackets = new List<Bracket> ();
								// get
								{
									foreach (Bracket bracket in eliminationRound.brackets.vs) {
										if (bracket.isActive.v) {
											brackets.Add (bracket);
										}
									}
								}
								// Make list
								{
									int min = Mathf.Min (brackets.Count, _Params.brackets.Count);
									// Update
									{
										for (int i = 0; i < min; i++) {
											if (brackets [i] != _Params.brackets [i]) {
												// change param
												_Params.brackets [i] = brackets [i];
												// Update holder
												foreach (ChooseBracketHolder.UIData holder in this.data.holders.vs) {
													if (holder.ItemIndex == i) {
														holder.bracket.v = new ReferenceData<Bracket> (brackets [i]);
														break;
													}
												}
											}
										}
									}
									// Add or Remove
									{
										if (brackets.Count > min) {
											// Add
											int insertCount = brackets.Count - min;
											List<Bracket> addItems = brackets.GetRange (min, insertCount);
											_Params.brackets.AddRange (addItems);
											InsertItems (min, insertCount, false, false);
										} else {
											// Remove
											int deleteCount = _Params.brackets.Count - min;
											if (deleteCount > 0) {
												RemoveItems (min, deleteCount, false, false);
												_Params.brackets.RemoveRange (min, deleteCount);
											}
										}
									}
								}
								// NoBrackets
								{
									if (noBrackets != null) {
										bool haveAny = false;
										{
											foreach (ChooseBracketHolder.UIData holder in this.data.holders.vs) {
												if (holder.bracket.v.data != null) {
													ChooseBracketHolder holderUI = holder.findCallBack<ChooseBracketHolder> ();
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
										noBrackets.SetActive (!haveAny);
									} else {
										Debug.LogError ("noBrackets null: " + this);
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
							if (tvNoBrackets != null) {
								tvNoBrackets.text = txtNoBrackets.get ("Don't have any brackets");
							} else {
								Debug.LogError ("tvNoBrackets null: " + this);
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
					uiData.eliminationRound.allAddCallBack (this);
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
				if (data is EliminationRound) {
					EliminationRound eliminationRound = data as EliminationRound;
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
						eliminationRound.brackets.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Bracket) {
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
					uiData.eliminationRound.allRemoveCallBack (this);
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
				if (data is EliminationRound) {
					EliminationRound eliminationRound = data as EliminationRound;
					// Child
					{
						eliminationRound.brackets.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Bracket) {
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
				case UIData.Property.eliminationRound:
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
				if (wrapProperty.p is EliminationRound) {
					switch ((EliminationRound.Property)wrapProperty.n) {
					case EliminationRound.Property.isActive:
						break;
					case EliminationRound.Property.state:
						break;
					case EliminationRound.Property.index:
						break;
					case EliminationRound.Property.brackets:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
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
						break;
					case Bracket.Property.byeTeamIndexs:
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