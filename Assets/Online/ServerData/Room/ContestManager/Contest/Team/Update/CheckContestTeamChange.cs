using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class CheckContestTeamChange<K> : Data, ValueChangeCallBack where K : Data
	{

		public VP<int> change;

		private void notifyChange()
		{
			this.change.v = this.change.v + 1;
		}

		#region Constructor

		public enum Property
		{
			change
		}

		public CheckContestTeamChange() : base()
		{
			this.change = new VP<int> (this, (byte)Property.change, 0);
		}

		#endregion

		public K data;

		public void setData(K newData){
			if (this.data != newData) {
				// remove old
				{
					DataUtils.removeParentCallBack (this.data, this, ref this.contest);
				}
				// set new 
				{
					this.data = newData;
					DataUtils.addParentCallBack (this.data, this, ref this.contest);
				}
			} else {
				Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
			}
		}

		#region implement callBacks

		private Contest contest = null;

		public void onAddCallBack<T> (T data) where T:Data
		{
			if (data is Contest) {
				Contest contest = data as Contest;
				// Child
				{
					contest.teams.allAddCallBack (this);
				}
				this.notifyChange ();
				return;
			}
			// Child
			{
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Child
					{
						matchTeam.players.allAddCallBack (this);
					}
					this.notifyChange ();
					return;
				}
				// Child
				{
					if (data is TeamPlayer) {
						TeamPlayer teamPlayer = data as TeamPlayer;
						// Child
						{
							teamPlayer.inform.allAddCallBack (this);
						}
						this.notifyChange ();
						return;
					}
					// Child
					{
						if (data is GamePlayer.Inform) {
							GamePlayer.Inform inform = data as GamePlayer.Inform;
							// Child
							{
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									break;
								case GamePlayer.Inform.Type.Human:
									break;
								case GamePlayer.Inform.Type.Computer:
									{
										Computer computer = inform as Computer;
										computer.ai.allAddCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
							}
							this.notifyChange ();
							return;
						}
						// Child
						if (data is Computer.AI) {
							this.notifyChange ();
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
		{
			if (data is Contest) {
				Contest contest = data as Contest;
				// Child
				{
					contest.teams.allRemoveCallBack (this);
				}
				this.contest = null;
				return;
			}
			// Child
			{
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Child
					{
						matchTeam.players.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is TeamPlayer) {
						TeamPlayer teamPlayer = data as TeamPlayer;
						// Child
						{
							teamPlayer.inform.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					{
						if (data is GamePlayer.Inform) {
							GamePlayer.Inform inform = data as GamePlayer.Inform;
							// Child
							{
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									break;
								case GamePlayer.Inform.Type.Human:
									break;
								case GamePlayer.Inform.Type.Computer:
									{
										Computer computer = inform as Computer;
										computer.ai.allRemoveCallBack (this);
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
							}
							return;
						}
						// Child
						if (data is Computer.AI) {
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is Contest) {
				switch ((Contest.Property)wrapProperty.n) {
				case Contest.Property.state:
					break;
				case Contest.Property.playerPerTeam:
					break;
				case Contest.Property.teams:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						this.notifyChange ();
					}
					break;
				case Contest.Property.roundFactory:
					break;
				case Contest.Property.rounds:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is MatchTeam) {
					switch ((MatchTeam.Property)wrapProperty.n) {
					case MatchTeam.Property.teamIndex:
						break;
					case MatchTeam.Property.state:
						break;
					case MatchTeam.Property.players:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							this.notifyChange ();
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
					if (wrapProperty.p is TeamPlayer) {
						switch ((TeamPlayer.Property)wrapProperty.n) {
						case TeamPlayer.Property.playerIndex:
							break;
						case TeamPlayer.Property.inform:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								this.notifyChange ();
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
						if (wrapProperty.p is GamePlayer.Inform) {
							GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
							// Child
							{
								switch (inform.getType ()) {
								case GamePlayer.Inform.Type.None:
									break;
								case GamePlayer.Inform.Type.Human:
									{
										switch ((Human.Property)wrapProperty.n) {
										case Human.Property.playerId:
											this.notifyChange ();
											break;
										case Human.Property.account:
											break;
										case Human.Property.state:
											break;
										case Human.Property.email:
											break;
										case Human.Property.phoneNumber:
											break;
										case Human.Property.status:
											break;
										case Human.Property.birthday:
											break;
										case Human.Property.sex:
											break;
										case Human.Property.connection:
											break;
										case Human.Property.ban:
											break;
										default:
											Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
											break;
										}
									}
									break;
								case GamePlayer.Inform.Type.Computer:
									{
										switch ((Computer.Property)wrapProperty.n) {
										case Computer.Property.computerName:
											this.notifyChange ();
											break;
										case Computer.Property.avatarUrl:
											this.notifyChange ();
											break;
										case Computer.Property.ai:
											{
												ValueChangeUtils.replaceCallBack (this, syncs);
												this.notifyChange ();
											}
											break;
										default:
											Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
											break;
										}
									}
									break;
								default:
									Debug.LogError ("unknown type: " + inform.getType () + "; " + this);
									break;
								}
							}
							return;
						}
						// Child
						if (wrapProperty.p is Computer.AI) {
							this.notifyChange ();
							return;
						}
					}
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

	}
}