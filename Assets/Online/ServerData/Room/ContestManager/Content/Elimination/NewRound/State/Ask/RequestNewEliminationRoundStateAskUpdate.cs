using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundStateAskUpdate : UpdateBehavior<RequestNewEliminationRoundStateAsk>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewEliminationRound.IsCanMakeNewRound (this.data)) {
						HashSet<uint> whoCanAsks = RequestNewEliminationRound.WhoCanAsk (this.data);
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
											this.data.whoCanAsks.add (human);
										} else {
											oldHumans.Remove (human);
										}
									}
									// Update
									{
										human.playerId.v = userId;
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
								RequestNewEliminationRound requestNewEliminationRound = this.data.findDataInParent<RequestNewEliminationRound> ();
								if (requestNewEliminationRound != null) {
									RequestNewEliminationRoundStateAccept requestNewEliminationRoundStateAccept = new RequestNewEliminationRoundStateAccept ();
									{
										requestNewEliminationRoundStateAccept.uid = requestNewEliminationRound.state.makeId ();
									}
									requestNewEliminationRound.state.v = requestNewEliminationRoundStateAccept;
								} else {
									Debug.LogError ("requestNewEliminationRound null: " + this);
								}
							}
						}
					} else {
						// Chuyen ve none
						RequestNewEliminationRound requestNewEliminationRound = this.data.findDataInParent<RequestNewEliminationRound>();
						if (requestNewEliminationRound != null) {
							RequestNewEliminationRoundStateNone requestNewEliminationRoundStateNone = new RequestNewEliminationRoundStateNone ();
							{
								requestNewEliminationRoundStateNone.uid = requestNewEliminationRound.state.makeId ();
							}
							requestNewEliminationRound.state.v = requestNewEliminationRoundStateNone;
						} else {
							Debug.LogError ("requestNewEliminationRound null: " + this);
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

		private EliminationRoundCheckChange<RequestNewEliminationRoundStateAsk> eliminationRoundCheckChange = new EliminationRoundCheckChange<RequestNewEliminationRoundStateAsk>();
		private ContestManagerStatePlayTeamCheckChange<RequestNewEliminationRoundStateAsk> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<RequestNewEliminationRoundStateAsk> ();
		private RoomCheckChangeAdminChange<RequestNewEliminationRoundStateAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestNewEliminationRoundStateAsk>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewEliminationRoundStateAsk) {
				RequestNewEliminationRoundStateAsk requestNewEliminationRoundStateAsk = data as RequestNewEliminationRoundStateAsk;
				// CheckChange
				{
					// eliminationRound
					{
						eliminationRoundCheckChange.addCallBack (this);
						eliminationRoundCheckChange.setData (requestNewEliminationRoundStateAsk);
					}
					// teamCheckChange
					{
						contestManagerStatePlayTeamCheckChange.addCallBack (this);
						contestManagerStatePlayTeamCheckChange.setData (requestNewEliminationRoundStateAsk);
					}
					// adminChange
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestNewEliminationRoundStateAsk);
					}
				}
				// Child
				{
					requestNewEliminationRoundStateAsk.whoCanAsks.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is EliminationRoundCheckChange<RequestNewEliminationRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (data is ContestManagerStatePlayTeamCheckChange<RequestNewEliminationRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewEliminationRoundStateAsk>) {
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
			if (data is RequestNewEliminationRoundStateAsk) {
				RequestNewEliminationRoundStateAsk requestNewEliminationRoundStateAsk = data as RequestNewEliminationRoundStateAsk;
				// CheckChange
				{
					// eliminationRound
					{
						eliminationRoundCheckChange.removeCallBack (this);
						eliminationRoundCheckChange.setData (null);
					}
					// teamCheckChange
					{
						contestManagerStatePlayTeamCheckChange.removeCallBack (this);
						contestManagerStatePlayTeamCheckChange.setData (null);
					}
					// adminChange
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
				}
				// Child
				{
					requestNewEliminationRoundStateAsk.whoCanAsks.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewEliminationRoundStateAsk);
				return;
			}
			// CheckChange
			{
				if (data is EliminationRoundCheckChange<RequestNewEliminationRoundStateAsk>) {
					return;
				}
				if (data is ContestManagerStatePlayTeamCheckChange<RequestNewEliminationRoundStateAsk>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewEliminationRoundStateAsk>) {
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
			if (wrapProperty.p is RequestNewEliminationRoundStateAsk) {
				switch ((RequestNewEliminationRoundStateAsk.Property)wrapProperty.n) {
				case RequestNewEliminationRoundStateAsk.Property.whoCanAsks:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RequestNewEliminationRoundStateAsk.Property.accepts:
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
				if (wrapProperty.p is EliminationRoundCheckChange<RequestNewEliminationRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<RequestNewEliminationRoundStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestNewEliminationRoundStateAsk>) {
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