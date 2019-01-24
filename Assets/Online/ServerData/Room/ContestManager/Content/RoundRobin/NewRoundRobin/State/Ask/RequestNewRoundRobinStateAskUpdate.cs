using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateAskUpdate : UpdateBehavior<RequestNewRoundRobinStateAsk>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewRoundRobin.IsCanMakeNewRound (this.data)) {
						HashSet<uint> whoCanAsks = RequestNewRoundRobin.WhoCanAsk (this.data);
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
								RequestNewRoundRobin requestNewRoundRobin = this.data.findDataInParent<RequestNewRoundRobin> ();
								if (requestNewRoundRobin != null) {
									RequestNewRoundRobinStateAccept requestNewRoundRobinStateAccept = new RequestNewRoundRobinStateAccept ();
									{
										requestNewRoundRobinStateAccept.uid = requestNewRoundRobin.state.makeId ();
									}
									requestNewRoundRobin.state.v = requestNewRoundRobinStateAccept;
								} else {
									Debug.LogError ("requestNewRoundRobin null: " + this);
								}
							}
						}
					} else {
						// Chuyen ve none
						RequestNewRoundRobin requestNewRoundRobin = this.data.findDataInParent<RequestNewRoundRobin>();
						if (requestNewRoundRobin != null) {
							RequestNewRoundRobinStateNone requestNewRoundRobinStateNone = new RequestNewRoundRobinStateNone ();
							{
								requestNewRoundRobinStateNone.uid = requestNewRoundRobin.state.makeId ();
							}
							requestNewRoundRobin.state.v = requestNewRoundRobinStateNone;
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

		private RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAsk> requestNewRoundRobinCheckChange = new RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAsk> ();
		private RoomCheckChangeAdminChange<RequestNewRoundRobinStateAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestNewRoundRobinStateAsk>();
		private ContestManagerStatePlayTeamCheckChange<RequestNewRoundRobinStateAsk> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<RequestNewRoundRobinStateAsk>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundRobinStateAsk) {
				RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = data as RequestNewRoundRobinStateAsk;
				// CheckChange
				{
					// request
					{
						requestNewRoundRobinCheckChange.addCallBack (this);
						requestNewRoundRobinCheckChange.setData (requestNewRoundRobinStateAsk);
					}
					// admin
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestNewRoundRobinStateAsk);
					}
					// team
					{
						contestManagerStatePlayTeamCheckChange.addCallBack (this);
						contestManagerStatePlayTeamCheckChange.setData (requestNewRoundRobinStateAsk);
					}
				}
				// Child
				{
					requestNewRoundRobinStateAsk.whoCanAsks.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAsk>) {
					dirty = true;
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewRoundRobinStateAsk>) {
					dirty = true;
					return;
				}
				if (data is ContestManagerStatePlayTeamCheckChange<RequestNewRoundRobinStateAsk>) {
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
			if (data is RequestNewRoundRobinStateAsk) {
				RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = data as RequestNewRoundRobinStateAsk;
				// CheckChange
				{
					// request
					{
						requestNewRoundRobinCheckChange.removeCallBack (this);
						requestNewRoundRobinCheckChange.setData (null);
					}
					// admin
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
					// team
					{
						contestManagerStatePlayTeamCheckChange.removeCallBack (this);
						contestManagerStatePlayTeamCheckChange.setData (null);
					}
				}
				// Child
				{
					requestNewRoundRobinStateAsk.whoCanAsks.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewRoundRobinStateAsk);
				return;
			}
			// CheckChange
			{
				if (data is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAsk>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewRoundRobinStateAsk>) {
					return;
				}
				if (data is ContestManagerStatePlayTeamCheckChange<RequestNewRoundRobinStateAsk>) {
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
			if (wrapProperty.p is RequestNewRoundRobinStateAsk) {
				switch ((RequestNewRoundRobinStateAsk.Property)wrapProperty.n) {
				case RequestNewRoundRobinStateAsk.Property.whoCanAsks:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RequestNewRoundRobinStateAsk.Property.accepts:
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
				if (wrapProperty.p is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestNewRoundRobinStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<RequestNewRoundRobinStateAsk>) {
					dirty = true;
					return;
				}
			}
			// Child
			if (wrapProperty.p is Human) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}