using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match.RoundRobin
{
	public class ChooseRoundRobinAdapter : SRIA<ChooseRoundRobinAdapter.UIData, ChooseRoundRobinHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<RoundRobinContent>> roundRobinContent;

			public LP<ChooseRoundRobinHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				roundRobinContent,
				holders
			}

			public UIData() : base()
			{
				this.roundRobinContent = new VP<ReferenceData<RoundRobinContent>>(this, (byte)Property.roundRobinContent, new ReferenceData<RoundRobinContent>(null));
				this.holders = new LP<ChooseRoundRobinHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<RoundRobin> roundRobins = new List<RoundRobin>();

			public void reset()
			{
				this.roundRobins.Clear ();
			}

		}

		#endregion

		#region Adapter

		public ChooseRoundRobinHolder holderPrefab;

		protected override ChooseRoundRobinHolder.UIData CreateViewsHolder (int itemIndex)
		{
			ChooseRoundRobinHolder.UIData uiData = new ChooseRoundRobinHolder.UIData ();
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

		protected override void UpdateViewsHolder (ChooseRoundRobinHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		public GameObject noRoundRobins;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						RoundRobinContent roundRobinContent = this.data.roundRobinContent.v.data;
						if (roundRobinContent != null) {
							List<RoundRobin> roundRobins = new List<RoundRobin> ();
							// get
							{
								roundRobins.AddRange (roundRobinContent.roundRobins.vs);
							}
							// Make list
							{
								int min = Mathf.Min (roundRobins.Count, _Params.roundRobins.Count);
								// Update
								{
									for (int i = 0; i < min; i++) {
										if (roundRobins[i] != _Params.roundRobins [i]) {
											// change param
											_Params.roundRobins [i] = roundRobins [i];
											// Update holder
											foreach (ChooseRoundRobinHolder.UIData holder in this.data.holders.vs) {
												if (holder.ItemIndex == i) {
													holder.roundRobin.v = new ReferenceData<RoundRobin> (roundRobins [i]);
													break;
												}
											}
										}
									}
								}
								// Add or Remove
								{
									if (roundRobins.Count > min) {
										// Add
										int insertCount = roundRobins.Count - min;
										List<RoundRobin> addItems = roundRobins.GetRange (min, insertCount);
										_Params.roundRobins.AddRange (addItems);
										InsertItems (min, insertCount, false, false);
									} else {
										// Remove
										int deleteCount = _Params.roundRobins.Count - min;
										if (deleteCount > 0) {
											RemoveItems (min, deleteCount, false, false);
											_Params.roundRobins.RemoveRange (min, deleteCount);
										}
									}
								}
							}
							// NoRoundRobins
							{
								if (noRoundRobins != null) {
									bool haveAny = false;
									{
										foreach (ChooseRoundRobinHolder.UIData holder in this.data.holders.vs) {
											if (holder.roundRobin.v.data != null) {
												ChooseRoundRobinHolder holderUI = holder.findCallBack<ChooseRoundRobinHolder> ();
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
									noRoundRobins.SetActive (!haveAny);
								} else {
									Debug.LogError ("noRoundRobins null: " + this);
								}
							}
						} else {
							Debug.LogError ("server null: " + this);
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
				// Child
				{
					uiData.roundRobinContent.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RoundRobinContent) {
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
				// Child
				{
					uiData.roundRobinContent.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RoundRobinContent) {
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
				case UIData.Property.roundRobinContent:
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
			// Child
			if (wrapProperty.p is RoundRobinContent) {
				switch ((RoundRobinContent.Property)wrapProperty.n) {
				case RoundRobinContent.Property.singleContestFactory:
					break;
				case RoundRobinContent.Property.roundRobins:
					dirty = true;
					break;
				case RoundRobinContent.Property.requestNewRoundRobin:
					break;
				case RoundRobinContent.Property.needReturnRound:
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