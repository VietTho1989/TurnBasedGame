using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ChooseRoundHolder : SriaHolderBehavior<ChooseRoundHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<Round>> round;

			public VP<RoundState.UIData> roundStateUIData;

			#region Constructor

			public enum Property
			{
				round,
				roundStateUIData
			}

			public UIData() : base()
			{
				this.round = new VP<ReferenceData<Round>>(this, (byte)Property.round, new ReferenceData<Round>(null));
				this.roundStateUIData = new VP<RoundState.UIData>(this, (byte)Property.roundStateUIData, null);
			}

			#endregion

			public void updateView(ChooseRoundAdapter.UIData myParams)
			{
				// Find
				Round round = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.rounds.Count) {
						round = myParams.rounds [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.round.v = new ReferenceData<Round> (round);
			}

		}

		#endregion

		#region Refresh

		#region txt

		public Text tvShow;
		public static readonly TxtLanguage txtShow = new TxtLanguage();

		public static readonly TxtLanguage txtIndex = new TxtLanguage();

		static ChooseRoundHolder()
		{
			txtShow.add (Language.Type.vi, "Hiện");
			txtIndex.add (Language.Type.vi, "");
		}

		#endregion

		public Text tvIndex;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Round round = this.data.round.v.data;
					if (round != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = txtIndex.get ("") + "" + round.index.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
						// roundStateUIData
						{
							RoundState roundState = round.state.v;
							if (roundState != null) {
								switch (roundState.getType ()) {
								case RoundState.Type.Load:
									{
										RoundStateLoad roundStateLoad = roundState as RoundStateLoad;
										// UIData
										RoundStateLoadUI.UIData roundStateLoadUIData = this.data.roundStateUIData.newOrOld<RoundStateLoadUI.UIData>();
										{
											roundStateLoadUIData.roundStateLoad.v = new ReferenceData<RoundStateLoad> (roundStateLoad);
										}
										this.data.roundStateUIData.v = roundStateLoadUIData;
									}
									break;
								case RoundState.Type.Start:
									{
										RoundStateStart roundStateStart = roundState as RoundStateStart;
										// UIData
										RoundStateStartUI.UIData roundStateStartUIData = this.data.roundStateUIData.newOrOld<RoundStateStartUI.UIData>();
										{
											roundStateStartUIData.roundStateStart.v = new ReferenceData<RoundStateStart> (roundStateStart);
										}
										this.data.roundStateUIData.v = roundStateStartUIData;
									}
									break;
								case RoundState.Type.Play:
									{
										RoundStatePlay roundStatePlay = roundState as RoundStatePlay;
										// UIData
										RoundStatePlayUI.UIData roundStatePlayUIData = this.data.roundStateUIData.newOrOld<RoundStatePlayUI.UIData>();
										{
											roundStatePlayUIData.roundStatePlay.v = new ReferenceData<RoundStatePlay> (roundStatePlay);
										}
										this.data.roundStateUIData.v = roundStatePlayUIData;
									}
									break;
								case RoundState.Type.End:
									{
										RoundStateEnd roundStateEnd = roundState as RoundStateEnd;
										// UIData
										RoundStateEndUI.UIData roundStateEndUIData = this.data.roundStateUIData.newOrOld<RoundStateEndUI.UIData>();
										{
											roundStateEndUIData.roundStateEnd.v = new ReferenceData<RoundStateEnd> (roundStateEnd);
										}
										this.data.roundStateUIData.v = roundStateEndUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + roundState.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("roundState null: " + this);
							}
						}
					} else {
						Debug.LogError ("round null: " + this);
					}
					// txt
					{
						if (tvShow != null) {
							tvShow.text = txtShow.get ("Show");
						} else {
							Debug.LogError ("tvShow null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public RoundStateLoadUI loadPrefab;
		public RoundStateStartUI startPrefab;
		public RoundStatePlayUI playPrefab;
		public RoundStateEndUI endPrefab;
		public Transform roundStateContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Setting
				Setting.get().addCallBack(this);
				// Child
				{
					uiData.round.allAddCallBack (this);
					uiData.roundStateUIData.allAddCallBack (this);
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
				if (data is Round) {
					dirty = true;
					return;
				}
				if (data is RoundState.UIData) {
					RoundState.UIData roundStateUIData = data as RoundState.UIData;
					// UI
					{
						switch (roundStateUIData.getType ()) {
						case RoundState.Type.Load:
							{
								RoundStateLoadUI.UIData roundStateLoadUIData = roundStateUIData as RoundStateLoadUI.UIData;
								UIUtils.Instantiate (roundStateLoadUIData, loadPrefab, roundStateContainer);
							}
							break;
						case RoundState.Type.Start:
							{
								RoundStateStartUI.UIData roundStateStartUIData = roundStateUIData as RoundStateStartUI.UIData;
								UIUtils.Instantiate (roundStateStartUIData, startPrefab, roundStateContainer);
							}
							break;
						case RoundState.Type.Play:
							{
								RoundStatePlayUI.UIData roundStatePlayUIData = roundStateUIData as RoundStatePlayUI.UIData;
								UIUtils.Instantiate (roundStatePlayUIData, playPrefab, roundStateContainer);
							}
							break;
						case RoundState.Type.End:
							{
								RoundStateEndUI.UIData roundStateEndUIData = roundStateUIData as RoundStateEndUI.UIData;
								UIUtils.Instantiate (roundStateEndUIData, endPrefab, roundStateContainer);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + roundStateUIData.getType () + "; " + this);
							break;
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
				// Setting
				Setting.get().removeCallBack(this);
				// Child
				{
					uiData.round.allRemoveCallBack (this);
					uiData.roundStateUIData.allRemoveCallBack (this);
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
				if (data is Round) {
					return;
				}
				if (data is RoundState.UIData) {
					RoundState.UIData roundStateUIData = data as RoundState.UIData;
					// UI
					{
						switch (roundStateUIData.getType ()) {
						case RoundState.Type.Load:
							{
								RoundStateLoadUI.UIData roundStateLoadUIData = roundStateUIData as RoundStateLoadUI.UIData;
								roundStateLoadUIData.removeCallBackAndDestroy (typeof(RoundStateLoadUI));
							}
							break;
						case RoundState.Type.Start:
							{
								RoundStateStartUI.UIData roundStateStartUIData = roundStateUIData as RoundStateStartUI.UIData;
								roundStateStartUIData.removeCallBackAndDestroy (typeof(RoundStateStartUI));
							}
							break;
						case RoundState.Type.Play:
							{
								RoundStatePlayUI.UIData roundStatePlayUIData = roundStateUIData as RoundStatePlayUI.UIData;
								roundStatePlayUIData.removeCallBackAndDestroy (typeof(RoundStatePlayUI));
							}
							break;
						case RoundState.Type.End:
							{
								RoundStateEndUI.UIData roundStateEndUIData = roundStateUIData as RoundStateEndUI.UIData;
								roundStateEndUIData.removeCallBackAndDestroy (typeof(RoundStateEndUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + roundStateUIData.getType () + "; " + this);
							break;
						}
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
				case UIData.Property.round:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.roundStateUIData:
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
				if (wrapProperty.p is Round) {
					switch ((Round.Property)wrapProperty.n) {
					case Round.Property.state:
						dirty = true;
						break;
					case Round.Property.index:
						dirty = true;
						break;
					case Round.Property.roundGames:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is RoundState.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnShow()
		{
			if (this.data != null) {
				Round round = this.data.round.v.data;
				if (round != null) {
					ContestUI.UIData contestUIData = this.data.findDataInParent<ContestUI.UIData> ();
					if (contestUIData != null) {
						RoundUI.UIData roundUIData = contestUIData.roundUIData.v;
						if (roundUIData != null) {
							roundUIData.round.v = new ReferenceData<Round> (round);
						} else {
							Debug.LogError ("roundUIData null: " + this);
						}
					} else {
						Debug.LogError ("contestUIData null: " + this);
					}
				} else {
					Debug.LogError ("round null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}