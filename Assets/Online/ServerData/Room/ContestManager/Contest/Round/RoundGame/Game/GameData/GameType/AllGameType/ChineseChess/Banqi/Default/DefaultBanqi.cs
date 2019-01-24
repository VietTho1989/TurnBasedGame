using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class DefaultBanqi : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultBanqi() : base()
		{

		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Banqi;
		}

		public override GameType makeDefaultGameType ()
		{
			Game game = new Game();
			AI ai = new AI(game, Token.Ecolor.RED);
			string state = game.getBoard().saveBoard();
			// make banqi
			Banqi banqi = new Banqi();
			{
				banqi.color.v = ai.color;
				banqi.state.v = state;
			}
			return banqi;
		}

	}
}