using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class Result : Data
	{

		public VP<int> playerIndex;

		public VP<float> score;

		#region Reason

		public enum Reason
		{
			None,
			RequestDraw,
			GameDraw,
			CheckMate,
			CheckMated,
			TimeOut,
			EnemyTimeOut,
			Surrender,
			EnemySurrender
		}

		public VP<Reason> reason;

		#endregion

		#region Constructor

		public enum Property
		{
			playerIndex,
			score,
			reason
		}

		public Result() : base()
		{
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.score = new VP<float> (this, (byte)Property.score, 0);
			this.reason = new VP<Reason> (this, (byte)Property.reason, Reason.None);
		}

		#endregion

	}
}