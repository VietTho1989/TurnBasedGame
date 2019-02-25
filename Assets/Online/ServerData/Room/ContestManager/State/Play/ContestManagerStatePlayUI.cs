using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;

namespace GameManager.Match
{
	public class ContestManagerStatePlayUI : UIBehavior<ContestManagerStatePlayUI.UIData>
	{

		#region UIData

		public class UIData : ContestManagerUI.UIData.Sub
		{

			public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

			public VP<ContestManagerContent.UIData> contestManagerContentUIData;

			public VP<Swap.SwapUI.UIData> swapUIData;

			#region Constructor

			public enum Property
			{
				contestManagerStatePlay,
				contestManagerContentUIData,
				swapUIData
			}

			public UIData() : base()
			{
				this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
				this.contestManagerContentUIData = new VP<ContestManagerContent.UIData>(this, (byte)Property.contestManagerContentUIData, null);
				this.swapUIData = new VP<GameManager.Match.Swap.SwapUI.UIData>(this, (byte)Property.swapUIData, null);
			}

			#endregion

			public override ContestManager.State.Type getType ()
			{
				return ContestManager.State.Type.Play;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// swapUIData
					if (!isProcess) {
						GameManager.Match.Swap.SwapUI.UIData swapUIData = this.swapUIData.v;
						if (swapUIData != null) {
							isProcess = swapUIData.processEvent (e);
						} else {
							Debug.LogError ("swapUIData null: " + this);
						}
					}
					// contestManagerContentUIData
					if (!isProcess) {
						ContestManagerContent.UIData contestManagerContentUIData = this.contestManagerContentUIData.v;
						if (contestManagerContentUIData != null) {
							isProcess = contestManagerContentUIData.processEvent (e);
						} else {
							Debug.LogError ("contestManagerContentUIData null: " + this);
						}
					}
				}
				return isProcess;
			}

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
						// content
						{
							ContestManagerContent content = contestManagerStatePlay.content.v;
							if (content != null) {
								switch (content.getType ()) {
								case ContestManagerContent.Type.Single:
									{
										SingleContestContent singleContestContent = content as SingleContestContent;
										// UIData
										SingleContestContentUI.UIData singleContestContentUIData = this.data.contestManagerContentUIData.newOrOld<SingleContestContentUI.UIData>();
										{
											singleContestContentUIData.singleContestContent.v = new ReferenceData<SingleContestContent> (singleContestContent);
										}
										this.data.contestManagerContentUIData.v = singleContestContentUIData;
									}
									break;
								case ContestManagerContent.Type.RoundRobin:
									{
										RoundRobinContent roundRobinContent = content as RoundRobinContent;
										// UIData
										RoundRobinContentUI.UIData roundRobinContentUIData = this.data.contestManagerContentUIData.newOrOld<RoundRobinContentUI.UIData>();
										{
											roundRobinContentUIData.roundRobinContent.v = new ReferenceData<RoundRobinContent> (roundRobinContent);
										}
										this.data.contestManagerContentUIData.v = roundRobinContentUIData;
									}
									break;
								case ContestManagerContent.Type.Elimination:
									{
										EliminationContent eliminationContent = content as EliminationContent;
										// UIData
										EliminationContentUI.UIData eliminationContentUIData = this.data.contestManagerContentUIData.newOrOld<EliminationContentUI.UIData>();
										{
											eliminationContentUIData.eliminationContent.v = new ReferenceData<EliminationContent> (eliminationContent);
										}
										this.data.contestManagerContentUIData.v = eliminationContentUIData;
									}
									break;
								default:
									Debug.LogError ("unknown type: " + content.getType () + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("content null: " + this);
							}
						}
						// swapUIData
						{
							Swap.SwapUI.UIData swapUIData = this.data.swapUIData.v;
							if (swapUIData != null) {
								swapUIData.swap.v = new ReferenceData<GameManager.Match.Swap.Swap> (contestManagerStatePlay.swap.v);
							} else {
								// Debug.LogError ("swapUIData null: " + this);
							}
						}
                        // siblingIndex
                        {
                            UIRectTransform.SetSiblingIndex(this.data.contestManagerContentUIData.v, 0);
                            UIRectTransform.SetSiblingIndex(this.data.swapUIData.v, 1);
                        }
                    } else {
						Debug.LogError ("contestManagerStatePlay null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public SingleContestContentUI singleContestContentPrefab;
		public RoundRobinContentUI roundRobinContentPrefab;
		public EliminationContentUI eliminationContentPrefab;

		public Swap.SwapUI swapUIPrefab;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.contestManagerStatePlay.allAddCallBack (this);
					uiData.contestManagerContentUIData.allAddCallBack (this);
					uiData.swapUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is ContestManagerStatePlay) {
					dirty = true;
					return;
				}
				if (data is ContestManagerContent.UIData) {
					ContestManagerContent.UIData contestManagerContentUIData = data as ContestManagerContent.UIData;
					// UI
					{
						switch (contestManagerContentUIData.getType ()) {
						case ContestManagerContent.Type.Single:
							{
								SingleContestContentUI.UIData singleContestContentUIData = contestManagerContentUIData as SingleContestContentUI.UIData;
								UIUtils.Instantiate (singleContestContentUIData, singleContestContentPrefab, this.transform, UIConstants.FullParent);
							}
							break;
						case ContestManagerContent.Type.RoundRobin:
							{
								RoundRobinContentUI.UIData roundRobinContentUIData = contestManagerContentUIData as RoundRobinContentUI.UIData;
								UIUtils.Instantiate (roundRobinContentUIData, roundRobinContentPrefab, this.transform, UIConstants.FullParent);
							}
							break;
						case ContestManagerContent.Type.Elimination:
							{
								EliminationContentUI.UIData eliminationContentUIData = contestManagerContentUIData as EliminationContentUI.UIData;
								UIUtils.Instantiate (eliminationContentUIData, eliminationContentPrefab, this.transform, UIConstants.FullParent);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + contestManagerContentUIData.getType () + "; " + this);
							break;
						}
					}
					dirty = true;
					return;
				}
				if (data is Swap.SwapUI.UIData) {
					Swap.SwapUI.UIData swapUIData = data as Swap.SwapUI.UIData;
					// UI
					{
						UIUtils.Instantiate (swapUIData, swapUIPrefab, this.transform);
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
					uiData.contestManagerContentUIData.allRemoveCallBack (this);
					uiData.swapUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is ContestManagerStatePlay) {
					return;
				}
				if (data is ContestManagerContent.UIData) {
					ContestManagerContent.UIData contestManagerContentUIData = data as ContestManagerContent.UIData;
					// UI
					{
						switch (contestManagerContentUIData.getType ()) {
						case ContestManagerContent.Type.Single:
							{
								SingleContestContentUI.UIData singleContestContentUIData = contestManagerContentUIData as SingleContestContentUI.UIData;
								singleContestContentUIData.removeCallBackAndDestroy (typeof(SingleContestContentUI));
							}
							break;
						case ContestManagerContent.Type.RoundRobin:
							{
								RoundRobinContentUI.UIData roundRobinContentUIData = contestManagerContentUIData as RoundRobinContentUI.UIData;
								roundRobinContentUIData.removeCallBackAndDestroy (typeof(RoundRobinContentUI));
							}
							break;
						case ContestManagerContent.Type.Elimination:
							{
								EliminationContentUI.UIData eliminationContentUIData = contestManagerContentUIData as EliminationContentUI.UIData;
								eliminationContentUIData.removeCallBackAndDestroy (typeof(EliminationContentUI));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + contestManagerContentUIData.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is Swap.SwapUI.UIData) {
					Swap.SwapUI.UIData swapUIData = data as Swap.SwapUI.UIData;
					// UI
					{
						swapUIData.removeCallBackAndDestroy (typeof(Swap.SwapUI));
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
				case UIData.Property.contestManagerStatePlay:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.contestManagerContentUIData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.swapUIData:
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
				if (wrapProperty.p is ContestManagerStatePlay) {
					switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
					case ContestManagerStatePlay.Property.teams:
						break;
					case ContestManagerStatePlay.Property.content:
						dirty = true;
						break;
					case ContestManagerStatePlay.Property.swap:
						dirty = true;
						break;
					case ContestManagerStatePlay.Property.state:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ContestManagerContent.UIData) {
					return;
				}
				if (wrapProperty.p is Swap.SwapUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}