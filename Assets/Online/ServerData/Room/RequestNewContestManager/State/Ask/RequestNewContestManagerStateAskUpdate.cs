using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewContestManagerStateAskUpdate : UpdateBehavior<RequestNewContestManagerStateAsk>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewContestManager.IsCanMakeNewContestManagerWithoutRequestState (this.data)) {
						HashSet<uint> whoCanAsks = RequestNewContestManager.WhoCanAsk (this.data);
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
								RequestNewContestManager requestNewContestManager = this.data.findDataInParent<RequestNewContestManager> ();
								if (requestNewContestManager != null) {
									RequestNewContestManagerStateAccept requestNewContestManagerStateAccept = new RequestNewContestManagerStateAccept ();
									{
										requestNewContestManagerStateAccept.uid = requestNewContestManager.state.makeId ();
									}
									requestNewContestManager.state.v = requestNewContestManagerStateAccept;
								} else {
									Debug.LogError ("requestNewContestManager null: " + this);
								}
							}
						}
					} else {
						// Chuyen ve none
						RequestNewContestManager requestNewContestManager = this.data.findDataInParent<RequestNewContestManager>();
						if (requestNewContestManager != null) {
							RequestNewContestManagerStateNone requestNewContestManagerStateNone = new RequestNewContestManagerStateNone ();
							{
								requestNewContestManagerStateNone.uid = requestNewContestManager.state.makeId ();
							}
							requestNewContestManager.state.v = requestNewContestManagerStateNone;
						} else {
							Debug.LogError ("requestNewContestManager null: " + this);
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

		private CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAsk> checkCanMakeNewContestManagerChange = new CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAsk>();
		private RoomCheckChangeAdminChange<RequestNewContestManagerStateAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestNewContestManagerStateAsk> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewContestManagerStateAsk) {
				RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = data as RequestNewContestManagerStateAsk;
				// CheckChange
				{
					// canMake
					{
						checkCanMakeNewContestManagerChange.addCallBack (this);
						checkCanMakeNewContestManagerChange.setData (requestNewContestManagerStateAsk);
					}
					// admin
					{
						roomCheckAdminChange.addCallBack (this);
						roomCheckAdminChange.setData (requestNewContestManagerStateAsk);
					}
				}
				// Child
				{
					requestNewContestManagerStateAsk.whoCanAsks.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAsk>) {
					dirty = true;
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewContestManagerStateAsk>) {
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
			if (data is RequestNewContestManagerStateAsk) {
				RequestNewContestManagerStateAsk requestNewContestManagerStateAsk = data as RequestNewContestManagerStateAsk;
				// CheckChange
				{
					// canMake
					{
						checkCanMakeNewContestManagerChange.removeCallBack (this);
						checkCanMakeNewContestManagerChange.setData (null);
					}
					// admin
					{
						roomCheckAdminChange.removeCallBack (this);
						roomCheckAdminChange.setData (null);
					}
				}
				// Child
				{
					requestNewContestManagerStateAsk.whoCanAsks.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewContestManagerStateAsk);
				return;
			}
			// CheckChange
			{
				if (data is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAsk>) {
					return;
				}
				if (data is RoomCheckChangeAdminChange<RequestNewContestManagerStateAsk>) {
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
			if (wrapProperty.p is RequestNewContestManagerStateAsk) {
				switch ((RequestNewContestManagerStateAsk.Property)wrapProperty.n) {
				case RequestNewContestManagerStateAsk.Property.whoCanAsks:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RequestNewContestManagerStateAsk.Property.accepts:
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
				if (wrapProperty.p is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAsk>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is RoomCheckChangeAdminChange<RequestNewContestManagerStateAsk>) {
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