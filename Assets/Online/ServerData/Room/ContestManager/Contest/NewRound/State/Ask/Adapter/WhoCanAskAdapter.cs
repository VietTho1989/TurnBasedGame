using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match
{
	public class WhoCanAskAdapter : SRIA<WhoCanAskAdapter.UIData, WhoCanAskHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{

			public VP<ReferenceData<RequestNewRoundStateAsk>> requestNewRoundStateAsk;

			public LP<WhoCanAskHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				requestNewRoundStateAsk,
				holders
			}

			public UIData() : base()
			{
				this.requestNewRoundStateAsk = new VP<ReferenceData<RequestNewRoundStateAsk>>(this, (byte)Property.requestNewRoundStateAsk, new ReferenceData<RequestNewRoundStateAsk>(null));
				this.holders = new LP<WhoCanAskHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<Human> humans = new List<Human>();

			public void reset()
			{
				this.humans.Clear ();
			}

		}

		#endregion

		#region Adapter

		public WhoCanAskHolder holderPrefab;

		protected override WhoCanAskHolder.UIData CreateViewsHolder (int itemIndex)
		{
			// Debug.LogError ("create holder: " + itemIndex);
			WhoCanAskHolder.UIData uiData = new WhoCanAskHolder.UIData();
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

		protected override void UpdateViewsHolder (WhoCanAskHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		public GameObject noHumans;

		public override void refresh ()
		{
			if (dirty) {
				if (this.Initialized) {
					dirty = false;
					if (this.data != null) {
						RequestNewRoundStateAsk requestNewRoundStateAsk = this.data.requestNewRoundStateAsk.v.data;
						if (requestNewRoundStateAsk != null) {
							List<Human> humans = new List<Human> ();
							// get
							{
								humans.AddRange (requestNewRoundStateAsk.whoCanAsks.vs);
							}
							// Make list
							{
								int min = Mathf.Min (humans.Count, _Params.humans.Count);
								// Update
								{
									for (int i = 0; i < min; i++) {
										if (humans[i] != _Params.humans [i]) {
											// change param
											_Params.humans [i] = humans [i];
										}
										// Update holder
										foreach (WhoCanAskHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												Debug.LogError ("update human: " + humans [i]);
												holder.human.v = new ReferenceData<Human> (humans [i]);
												break;
											}
										}
									}
								}
								// Add or Remove
								{
									if (humans.Count > min) {
										// Add
										int insertCount = humans.Count - min;
										List<Human> addItems = humans.GetRange (min, insertCount);
										_Params.humans.AddRange (addItems);
										InsertItems (min, insertCount, false, false);
									} else {
										// Remove
										int deleteCount = _Params.humans.Count - min;
										if (deleteCount > 0) {
											RemoveItems (min, deleteCount, false, false);
											_Params.humans.RemoveRange (min, deleteCount);
										}
									}
								}
							}
							// NoHumans
							{
								if (noHumans != null) {
									bool haveAny = false;
									{
										foreach (WhoCanAskHolder.UIData holder in this.data.holders.vs) {
											if (holder.human.v.data != null) {
												WhoCanAskHolder holderUI = holder.findCallBack<WhoCanAskHolder> ();
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
									noHumans.SetActive (!haveAny);
								} else {
									Debug.LogError ("noHumans null: " + this);
								}
							}
						} else {
							Debug.LogError ("requestNewRoundStateAsk null: " + this);
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
				} else {
					// Debug.LogError ("not initalized: " + this);
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
					uiData.requestNewRoundStateAsk.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewRoundStateAsk) {
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
					uiData.requestNewRoundStateAsk.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RequestNewRoundStateAsk) {
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
				case UIData.Property.requestNewRoundStateAsk:
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
			if (wrapProperty.p is RequestNewRoundStateAsk) {
				switch ((RequestNewRoundStateAsk.Property)wrapProperty.n) {
				case RequestNewRoundStateAsk.Property.whoCanAsks:
					dirty = true;
					break;
				case RequestNewRoundStateAsk.Property.accepts:
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