using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRound : Data
	{

		public VP<bool> isActive;

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Load,
				Start,
				Play,
				End
			}

			public abstract Type getType();

		}

		public VP<State> state;

		#endregion

		public VP<int> index;

		public LP<Bracket> brackets;

		#region Constructor

		public enum Property
		{
			isActive,
			state,
			index,
			brackets
		}

		public EliminationRound() : base()
		{
			this.isActive = new VP<bool> (this, (byte)Property.isActive, true);
			this.state = new VP<State> (this, (byte)Property.state, new EliminationRoundStateLoad ());
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.brackets = new LP<Bracket> (this, (byte)Property.brackets);
		}

		#endregion

		public bool isLastRound()
		{
			if (this.isActive.v) {
				// get active brackets
				List<Bracket> activeBrackets = new List<Bracket>();
				{
					foreach (Bracket bracket in this.brackets.vs) {
						if (bracket.isActive.v) {
							activeBrackets.Add (bracket);
						} else {
							Debug.LogError ("bracket not active: " + this);
						}
					}
				}
				if (activeBrackets.Count == 1) {
					Bracket bracket = activeBrackets [0];
					if (bracket.state.v.getType () == Bracket.State.Type.End) {
						BracketStateEnd bracketStateEnd = bracket.state.v as BracketStateEnd;
						// get team count per contest
						int teamCountPerContest = 2;
						{
							EliminationContent eliminationContent = this.findDataInParent<EliminationContent> ();
							if (eliminationContent != null) {
								SingleContestFactory singleContestFactory = eliminationContent.singleContestFactory.v;
								if (singleContestFactory != null) {
									int playerPerTeam = 1;
									GameType.Type gameTypeType = GameType.Type.CHESS;
									singleContestFactory.getTeamCountAndPlayerPerTeamGameType (out teamCountPerContest, out playerPerTeam, out gameTypeType);
								} else {
									Debug.LogError ("singleContestFactory null: " + this);
								}
							} else {
								Debug.LogError ("eliminationContent null: " + this);
							}
						}
						if (teamCountPerContest <= 2) {
							if (bracketStateEnd.winTeamIndexs.vs.Count == 1) {
								return true;
							}
						} else {
							Debug.LogError ("why teamCountPerContest too large: " + teamCountPerContest);
							if (bracketStateEnd.winTeamIndexs.vs.Count < teamCountPerContest) {
								return true;
							}
						}
					} else {
						// not all bracket end
					}
				}
			} else {
				Debug.LogError ("this round not active: " + this);
			}
			return false;
		}

	}
}