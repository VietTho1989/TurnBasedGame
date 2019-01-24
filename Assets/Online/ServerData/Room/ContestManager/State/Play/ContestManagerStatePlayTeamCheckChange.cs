using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStatePlayTeamCheckChange<K> : Data, ValueChangeCallBack where K : Data
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

		public ContestManagerStatePlayTeamCheckChange() : base()
		{
			this.change = new VP<int> (this, (byte)Property.change, 0);
		}

		#endregion

		public K data;

		public void setData(K newData){
			if (this.data != newData) {
				// remove old
				{
					DataUtils.removeParentCallBack (this.data, this, ref this.contestManagerStatePlay);
				}
				// set new 
				{
					this.data = newData;
					DataUtils.addParentCallBack (this.data, this, ref this.contestManagerStatePlay);
				}
			} else {
				Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
			}
		}

		#region implement callBacks

		private ContestManagerStatePlay contestManagerStatePlay = null;

		public void onAddCallBack<T> (T data) where T:Data
		{
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Child
				{
					contestManagerStatePlay.teams.allAddCallBack (this);
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
						matchTeam.state.allAddCallBack (this);
						matchTeam.players.allAddCallBack (this);
					}
					this.notifyChange ();
					return;
				}
				// Child
				{
					// state
					if (data is TeamState) {
						this.notifyChange ();
						return;
					}
					// teamPlayer
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
						// Inform
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
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
		{
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Child
				{
					contestManagerStatePlay.teams.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is MatchTeam) {
					MatchTeam matchTeam = data as MatchTeam;
					// Child
					{
						matchTeam.state.allRemoveCallBack (this);
						matchTeam.players.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					// state
					if (data is TeamState) {
						return;
					}
					// teamPlayer
					{
						if (data is TeamPlayer) {
							TeamPlayer teamPlayer = data as TeamPlayer;
							// Child
							{
								teamPlayer.inform.allRemoveCallBack (this);
							}
							return;
						}
						// Inform
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
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ContestManagerStatePlay) {
				switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
				case ContestManagerStatePlay.Property.state:
					break;
				case ContestManagerStatePlay.Property.isForceEnd:
					break;
				case ContestManagerStatePlay.Property.teams:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						this.notifyChange ();
					}
					break;
				case ContestManagerStatePlay.Property.swap:
					break;
				case ContestManagerStatePlay.Property.content:
					break;
				case ContestManagerStatePlay.Property.contentTeamResult:
					break;
				case ContestManagerStatePlay.Property.gameTypeType:
					break;
				case ContestManagerStatePlay.Property.randomTeamIndex:
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
						this.notifyChange ();
						break;
					case MatchTeam.Property.state:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							this.notifyChange ();
						}
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
					// state
					if (wrapProperty.p is TeamState) {
						this.notifyChange ();
						return;
					}
					// teamPlayer
					{
						if (wrapProperty.p is TeamPlayer) {
							switch ((TeamPlayer.Property)wrapProperty.n) {
							case TeamPlayer.Property.playerIndex:
								this.notifyChange ();
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
						// Inform
						{
							if (wrapProperty.p is GamePlayer.Inform) {
								GamePlayer.Inform inform = wrapProperty.p as GamePlayer.Inform;
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
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		#endregion

	}
}