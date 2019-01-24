using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ComputerCheckCorrectAIUpdate : UpdateBehavior<Computer>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// get gameType
					GameType.Type gameType = GameType.Type.Xiangqi;
					{
						ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby> ();
						if (lobby != null) {
							gameType = lobby.gameType.v;
						} else {
							Debug.LogError ("lobby null: " + this);
						}
					}
					// Process
					{
						// Find
						bool needMakeNewAI = true;
						{
							if (this.data.ai.v != null) {
								if (this.data.ai.v.getType () == gameType) {
									needMakeNewAI = false;
								}
							}
						}
						// Process
						if (needMakeNewAI) {
							Computer.AI ai = Computer.AI.makeDefaultAI (gameType);
							{
								ai.uid = this.data.ai.makeId ();
							}
							this.data.ai.v = ai;
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

		private ContestManagerStateLobby contestManagerStateLobby = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is Computer) {
				Computer computer = data as Computer;
				// Parent
				{
					DataUtils.addParentCallBack (computer, this, ref this.contestManagerStateLobby);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is ContestManagerStateLobby) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is Computer) {
				Computer computer = data as Computer;
				// Parent
				{
					DataUtils.removeParentCallBack (computer, this, ref this.contestManagerStateLobby);
				}
				this.setDataNull (computer);
				return;
			}
			// Parent
			{
				if (data is ContestManagerStateLobby) {
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
			if (wrapProperty.p is Computer) {
				switch ((Computer.Property)wrapProperty.n) {
				case Computer.Property.computerName:
					break;
				case Computer.Property.avatarUrl:
					break;
				case Computer.Property.ai:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is ContestManagerStateLobby) {
					switch ((ContestManagerStateLobby.Property)wrapProperty.n) {
					case ContestManagerStateLobby.Property.state:
						break;
					case ContestManagerStateLobby.Property.teams:
						break;
					case ContestManagerStateLobby.Property.gameType:
						dirty = true;
						break;
					case ContestManagerStateLobby.Property.randomTeamIndex:
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