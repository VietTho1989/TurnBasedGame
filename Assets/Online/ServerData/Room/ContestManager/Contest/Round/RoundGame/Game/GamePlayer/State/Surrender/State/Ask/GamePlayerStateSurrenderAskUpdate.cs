using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderAskUpdate : UpdateBehavior<GamePlayerStateSurrenderAsk>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				HashSet<uint> whoCanAsks = this.data.getWhoCanAsks();
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
						// Chuyen sang state normal
						GamePlayer gamePlayer = this.data.findDataInParent<GamePlayer>();
						if (gamePlayer != null) {
							GamePlayerStateNormal normal = new GamePlayerStateNormal ();
							{
								normal.uid = gamePlayer.state.makeId ();
							}
							gamePlayer.state.v = normal;
						} else {
							Debug.LogError ("gamePlayer null: " + this);
						}
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

	private RoomCheckChangeAdminChange<GamePlayerStateSurrenderAsk> roomCheckAdminChange = new RoomCheckChangeAdminChange<GamePlayerStateSurrenderAsk> ();
	private GameCheckPlayerChange<GamePlayerStateSurrenderAsk> checkPlayerChange = new GameCheckPlayerChange<GamePlayerStateSurrenderAsk>();

	public override void onAddCallBack<T> (T data)
	{
		if (data is GamePlayerStateSurrenderAsk) {
			GamePlayerStateSurrenderAsk ask = data as GamePlayerStateSurrenderAsk;
			// CheckChange
			{
				// room admin
				{
					roomCheckAdminChange.addCallBack (this);
					roomCheckAdminChange.setData (ask);
				}
				// player
				{
					checkPlayerChange.addCallBack (this);
					checkPlayerChange.setData (ask);
				}
			}
			// Child
			{
				ask.whoCanAsks.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// CheckChange
		{
			// admin
			if (data is RoomCheckChangeAdminChange<GamePlayerStateSurrenderAsk>) {
				dirty = true;
				return;
			}
			// player
			if (data is GameCheckPlayerChange<GamePlayerStateSurrenderAsk>) {
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
		if (data is GamePlayerStateSurrenderAsk) {
			GamePlayerStateSurrenderAsk ask = data as GamePlayerStateSurrenderAsk;
			// CheckChange
			{
				// room admin
				{
					roomCheckAdminChange.removeCallBack (this);
					roomCheckAdminChange.setData (null);
				}
				// player
				{
					checkPlayerChange.removeCallBack (this);
					checkPlayerChange.setData (null);
				}
			}
			// Child
			{
				ask.whoCanAsks.allRemoveCallBack (this);
			}
			this.setDataNull(ask);
			return;
		}
		// CheckChange
		{
			// admin
			if (data is RoomCheckChangeAdminChange<GamePlayerStateSurrenderAsk>) {
				return;
			}
			// player
			if (data is GameCheckPlayerChange<GamePlayerStateSurrenderAsk>) {
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
		if (wrapProperty.p is GamePlayerStateSurrenderAsk) {
			switch ((GamePlayerStateSurrenderAsk.Property)wrapProperty.n) {
			case GamePlayerStateSurrenderAsk.Property.whoCanAsks:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case GamePlayerStateSurrenderAsk.Property.accepts:
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
			// admin
			if (wrapProperty.p is RoomCheckChangeAdminChange<GamePlayerStateSurrenderAsk>) {
				dirty = true;
				return;
			}
			// player
			if (wrapProperty.p is GameCheckPlayerChange<GamePlayerStateSurrenderAsk>) {
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