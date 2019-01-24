using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateAskUpdate : UpdateBehavior<RequestNewRoundStateAsk>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewRound.IsCanMakeNewRound (this.data)) {
						HashSet<uint> whoCanAsks = RequestNewRound.WhoCanAsk (this.data);
						// update human
						{
							// get old
							List<Human> oldHumans = new List<Human> ();
							{
								oldHumans.AddRange (this.data.whoCanAsks.vs);
							}
							// Update
							{
								foreach (uint userId in whoCanAsks) {
									bool isNew = false;
									// find Human
									Human human = null;
									{
										// find old
										if (oldHumans.Count > 0) {
											human = oldHumans [0];
										}
										// make new
										if (human == null) {
											human = new Human ();
											{
												human.uid = this.data.whoCanAsks.makeId ();
											}
											isNew = true;
										} else {
											oldHumans.Remove (human);
										}
									}
									// Update
									{
										human.playerId.v = userId;
									}
									// Add
									if (isNew) {
										this.data.whoCanAsks.add (human);
									}
								}
							}
							// Remove old
							foreach (Human oldHuman in oldHumans) {
								this.data.whoCanAsks.remove (oldHuman);
							}
						}
						// accepts
						{
							// remove who cannot ask
							for (int i = this.data.accepts.vs.Count - 1; i >= 0; i--) {
								if (!whoCanAsks.Contains (this.data.accepts.vs [i])) {
									Debug.LogError ("not contains: " + this.data.accepts.vs [i]);
									this.data.accepts.removeAt (i);
								}
							}
							// check all accept
							bool allAccept = true;
							{
								foreach (uint userId in whoCanAsks) {
									if (!this.data.accepts.vs.Contains (userId)) {
										allAccept = false;
										break;
									}
								}
							}
							// Process
							if (allAccept) {
								// Chuyen sang state accept
								RequestNewRound requestNewRound = this.data.findDataInParent<RequestNewRound> ();
								if (requestNewRound != null) {
									RequestNewRoundStateAccept requestNewRoundStateAccept = new RequestNewRoundStateAccept ();
									{
										requestNewRoundStateAccept.uid = requestNewRound.state.makeId ();
									}
									requestNewRound.state.v = requestNewRoundStateAccept;
								} else {
									Debug.LogError ("requestNewRound null: " + this);
								}
							}
						}
					} else {
						// Chuyen ve none
						RequestNewRound requestNewRound = this.data.findDataInParent<RequestNewRound>();
						if (requestNewRound != null) {
							RequestNewRoundStateNone requestNewRoundStateNone = new RequestNewRoundStateNone ();
							{
								requestNewRoundStateNone.uid = requestNewRound.state.makeId ();
							}
							requestNewRound.state.v = requestNewRoundStateNone;
						} else {
							Debug.LogError ("requestNewRound null: " + this);
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private CheckCanMakeNewRoundChange<RequestNewRoundStateAsk> checkCanMakeNewRoundChange = new CheckCanMakeNewRoundChange<RequestNewRoundStateAsk>();
		private RoomCheckChangeAdminChange<RequestNewRoundStateAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestNewRoundStateAsk>();
		private CheckContestTeamChange<RequestNewRoundStateAsk> checkContestTeamChange = new CheckContestTeamChange<RequestNewRoundStateAsk>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundStateAsk) {
				RequestNewRoundStateAsk requestNewRoundStateAsk = data as RequestNewRoundStateAsk;
				// CheckChange
				{
					// canMake
					{
						checkCanMakeNewRoundChange.addCallBack (this);
						checkCanMakeNewRoundChange.setData (requestNewRoundStateAsk);
					}
					// adminChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestNewRoundStateAsk);
					}
					// teamChange
					{
						checkContestTeamChange.addCallBack (this);
						checkContestTeamChange.setData (requestNewRoundStateAsk);
					}
				}
				// Child
				{
					requestNewRoundStateAsk.whoCanAsks.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is CheckCanMakeNewRoundChange<RequestNewRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (data is CheckContestTeamChange<RequestNewRoundStateAsk>) {
					dirty = true;
					return;
				}
			}
			// Child
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewRoundStateAsk) {
				RequestNewRoundStateAsk requestNewRoundStateAsk = data as RequestNewRoundStateAsk;
				// CheckChange
				{
					// canMake
					{
						checkCanMakeNewRoundChange.removeCallBack (this);
						checkCanMakeNewRoundChange.setData (null);
					}
					// checAdminChange
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
					// teamChange
					{
						checkContestTeamChange.removeCallBack (this);
						checkContestTeamChange.setData (null);
					}
				}
				// Child
				{
					requestNewRoundStateAsk.whoCanAsks.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewRoundStateAsk);
				return;
			}
			// CheckChange
			{
				if (data is CheckCanMakeNewRoundChange<RequestNewRoundStateAsk>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewRoundStateAsk>) {
					return;
				}
				if (data is CheckContestTeamChange<RequestNewRoundStateAsk>) {
					return;
				}
			}
			// Child
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					human.removeCallBackAndDestroy (typeof(HumanUpdate));
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewRoundStateAsk) {
				switch ((RequestNewRoundStateAsk.Property)wrapProperty.n) {
				case RequestNewRoundStateAsk.Property.whoCanAsks:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RequestNewRoundStateAsk.Property.accepts:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			{
				if (wrapProperty.p is CheckCanMakeNewRoundChange<RequestNewRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestNewRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is CheckContestTeamChange<RequestNewRoundStateAsk>) {
					dirty = true;
					return;
				}
			}
			// Child
			if (wrapProperty.p is Human) {
				Human.onUpdateSyncPlayerIdChange (wrapProperty, this);
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}