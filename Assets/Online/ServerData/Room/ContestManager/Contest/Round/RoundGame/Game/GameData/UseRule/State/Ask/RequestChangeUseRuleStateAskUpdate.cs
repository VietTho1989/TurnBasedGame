using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleStateAskUpdate : UpdateBehavior<RequestChangeUseRuleStateAsk>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// get who canAsk
				HashSet<uint> whoCanAsks = new HashSet<uint>();
				{
					RequestChangeUseRule requestChangeUseRule = this.data.findDataInParent<RequestChangeUseRule>();
					if (requestChangeUseRule != null) {
						foreach (Human human in requestChangeUseRule.whoCanAsks.vs) {
							whoCanAsks.Add (human.playerId.v);
						}
					} else {
						Debug.LogError ("requestChangeUseRule null: " + this);
					}
				}
				// process
				if (whoCanAsks.Count > 0) {
					// remove who cannot ask
					for (int i = this.data.accepts.vs.Count - 1; i >= 0; i--) {
						if (!whoCanAsks.Contains (this.data.accepts.vs [i])) {
							Debug.LogError ("not contains: " + this.data.accepts.vs [i]);
							this.data.accepts.removeAt (i);
						}
					}
					if (this.data.accepts.vs.Count > 0) {
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
						// process
						if (allAccept) {
							// change useRule
							{
								GameData gameData = this.data.findDataInParent<GameData> ();
								if (gameData != null) {
									gameData.useRule.v = !gameData.useRule.v;
								} else {
									Debug.LogError ("gameData null: " + this);
								}
							}
							// change state
							{
								RequestChangeUseRule requestChangeUseRule = this.data.findDataInParent<RequestChangeUseRule>();
								if (requestChangeUseRule != null) {
									RequestChangeUseRuleStateNone none = new RequestChangeUseRuleStateNone ();
									{
										none.uid = requestChangeUseRule.state.makeId ();
									}
									requestChangeUseRule.state.v = none;
								} else {
									Debug.LogError ("requestChangeUseRule null: " + this);
								}
							}
						}
					} else {
						// nobody accept
						RequestChangeUseRule requestChangeUseRule = this.data.findDataInParent<RequestChangeUseRule>();
						if (requestChangeUseRule != null) {
							RequestChangeUseRuleStateNone none = new RequestChangeUseRuleStateNone ();
							{
								none.uid = requestChangeUseRule.state.makeId ();
							}
							requestChangeUseRule.state.v = none;
						} else {
							Debug.LogError ("requestChangeUseRule null: " + this);
						}
					}
				} else {
					// nobody can ask
					RequestChangeUseRule requestChangeUseRule = this.data.findDataInParent<RequestChangeUseRule>();
					if (requestChangeUseRule != null) {
						RequestChangeUseRuleStateNone none = new RequestChangeUseRuleStateNone ();
						{
							none.uid = requestChangeUseRule.state.makeId ();
						}
						requestChangeUseRule.state.v = none;
					} else {
						Debug.LogError ("requestChangeUseRule null: " + this);
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

	private RequestChangeUseRule requestChangeUseRule = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is RequestChangeUseRuleStateAsk) {
			RequestChangeUseRuleStateAsk ask = data as RequestChangeUseRuleStateAsk;
			// Parent
			{
				DataUtils.addParentCallBack (ask, this, ref this.requestChangeUseRule);
			}
			dirty = true;
			return;
		}
		// Parent
		{
			if (data is RequestChangeUseRule) {
				RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
				// Child
				{
					requestChangeUseRule.whoCanAsks.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Human) {
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RequestChangeUseRuleStateAsk) {
			RequestChangeUseRuleStateAsk ask = data as RequestChangeUseRuleStateAsk;
			// Parent
			{
				DataUtils.removeParentCallBack (ask, this, ref this.requestChangeUseRule);
			}
			this.setDataNull (ask);
			return;
		}
		// Parent
		{
			if (data is RequestChangeUseRule) {
				RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
				// Child
				{
					requestChangeUseRule.whoCanAsks.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is Human) {
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
		if (wrapProperty.p is RequestChangeUseRuleStateAsk) {
			switch ((RequestChangeUseRuleStateAsk.Property)wrapProperty.n) {
			case RequestChangeUseRuleStateAsk.Property.accepts:
				dirty = true;
				break;
			default:
				break;
			}
			return;
		}
		// Parent
		{
			if (wrapProperty.p is RequestChangeUseRule) {
				switch ((RequestChangeUseRule.Property)wrapProperty.n) {
				case RequestChangeUseRule.Property.state:
					break;
				case RequestChangeUseRule.Property.whoCanAsks:
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
			if (wrapProperty.p is Human) {
				Human.onUpdateSyncPlayerIdChange (wrapProperty, this);
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}