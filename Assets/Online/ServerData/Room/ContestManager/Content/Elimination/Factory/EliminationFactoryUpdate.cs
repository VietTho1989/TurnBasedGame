using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationFactoryUpdate : UpdateBehavior<EliminationFactory>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// correct init team count
					{
						if (this.data.initTeamCounts.vs.Count == 0) {
							this.data.initTeamCounts.add (4);
						} else {
							// check first team count
							if (this.data.initTeamCounts.vs [0] < 4) {
								Debug.LogError ("first team count too small: " + this.data.initTeamCounts.vs [0]);
								this.data.initTeamCounts.set (0, 4);
							}
						}
					}
					// update lobby
					ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby> ();
					if (lobby != null) {
						GameType.Type gameTypeType = GameType.Type.Xiangqi;
						int teamCount = 1;
						int playerPerTeam = 1;
						// Find
						{
							this.data.singleContestFactory.v.getTeamCountAndPlayerPerTeamGameType (out teamCount, out playerPerTeam, out gameTypeType);
						}
						// set
						{
							lobby.gameType.v = gameTypeType;
							{
								uint initTeamCounts = 0;
								{
									foreach (uint initTeamCount in this.data.initTeamCounts.vs) {
										initTeamCounts += initTeamCount;
									}
								}
								lobby.refreshTeam ((int)initTeamCounts, playerPerTeam);
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

		private SingleContestFactoryCheckChange<SingleContestFactory> singleContestFactoryCheckChange = new SingleContestFactoryCheckChange<SingleContestFactory> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationFactory) {
				EliminationFactory eliminationFactory = data as EliminationFactory;
				// Child
				{
					eliminationFactory.singleContestFactory.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is SingleContestFactory) {
					SingleContestFactory singleContestFactory = data as SingleContestFactory;
					// CheckChange
					{
						singleContestFactoryCheckChange.addCallBack (this);
						singleContestFactoryCheckChange.setData (singleContestFactory);
					}
					dirty = true;
					return;
				}
				// CheckChange
				if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationFactory) {
				EliminationFactory eliminationFactory = data as EliminationFactory;
				// Child
				{
					eliminationFactory.singleContestFactory.allRemoveCallBack (this);
				}
				this.setDataNull (eliminationFactory);
				return;
			}
			// Child
			{
				if (data is SingleContestFactory) {
					// SingleContestFactory singleContestFactory = data as SingleContestFactory;
					// CheckChange
					{
						singleContestFactoryCheckChange.removeCallBack (this);
						singleContestFactoryCheckChange.setData (null);
					}
					return;
				}
				// CheckChange
				if (data is SingleContestFactoryCheckChange<SingleContestFactory>) {
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
			if (wrapProperty.p is EliminationFactory) {
				switch ((EliminationFactory.Property)wrapProperty.n) {
				case EliminationFactory.Property.singleContestFactory:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case EliminationFactory.Property.initTeamCounts:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is SingleContestFactory) {
					return;
				}
				// CheckChange
				if (wrapProperty.p is SingleContestFactoryCheckChange<SingleContestFactory>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}