using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match
{
	/**
	 * Cai nay chua dung
	 * */
	public class MatchTeamAdapter : SRIA<MatchTeamAdapter.UIData, MatchTeamHolder.UIData>
	{

		#region UIData

		[Serializable]
		public class UIData : BaseParams
		{
			public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

			public LP<MatchTeamHolder.UIData> holders;

			#region Constructor

			public enum Property
			{
				contestManagerStatePlay,
				holders
			}

			public UIData() : base()
			{
				this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
				this.holders = new LP<MatchTeamHolder.UIData>(this, (byte)Property.holders);
			}

			#endregion

			[NonSerialized]
			public List<MatchTeam> matchTeams = new List<MatchTeam> ();

			public void reset()
			{
				this.matchTeams.Clear();
			}

		}

		#endregion

		#region Adapter

		public MatchTeamHolder holderPrefab;

		protected override MatchTeamHolder.UIData CreateViewsHolder (int itemIndex)
		{
			MatchTeamHolder.UIData uiData = new MatchTeamHolder.UIData();
			{
				// add
				{
					uiData.uid = this.data.holders.makeId ();
					this.data.holders.add (uiData);
				}
				if (holderPrefab != null) {
					uiData.Init (holderPrefab.gameObject, itemIndex);
				} else {
					Debug.LogError ("holderPrefab null: " + this);
				}
			}
			return uiData;
		}

		protected override void UpdateViewsHolder (MatchTeamHolder.UIData newOrRecycled)
		{
			newOrRecycled.updateView (_Params);
		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ContestManagerStatePlay contestManagerStatePlay = this.data.contestManagerStatePlay.v.data;
					if (contestManagerStatePlay != null) {
						// get list of matchTeam
						List<MatchTeam> matchTeams = new List<MatchTeam>();
						{
							matchTeams.AddRange (contestManagerStatePlay.teams.vs);
						}
						// Add to adapter
						{
							int min = Mathf.Min (matchTeams.Count, _Params.matchTeams.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (matchTeams [i] != _Params.matchTeams [i]) {
										// change param
										_Params.matchTeams [i] = matchTeams [i];
										// Update holder
										foreach (MatchTeamHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.matchTeam.v = new ReferenceData<MatchTeam> (matchTeams [i]);
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (matchTeams.Count > min) {
									// Add
									int insertCount = matchTeams.Count - min;
									List<MatchTeam> addItems = matchTeams.GetRange (min, insertCount);
									_Params.matchTeams.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.matchTeams.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.matchTeams.RemoveRange (min, deleteCount);
									}
								}
							}
						}
					} else {
						Debug.LogError ("contestManagerStatePlay null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.contestManagerStatePlay.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ContestManagerStatePlay) {
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
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.contestManagerStatePlay.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is ContestManagerStatePlay) {
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
				case UIData.Property.contestManagerStatePlay:
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
			{
				if (wrapProperty.p is ContestManagerStatePlay) {
					switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
					case ContestManagerStatePlay.Property.teams:
						dirty = true;
						break;
					case ContestManagerStatePlay.Property.content:
						break;
					case ContestManagerStatePlay.Property.state:
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