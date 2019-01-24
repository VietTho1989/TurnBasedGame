using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class End : State
	{

		#region result

		public LP<Result> results;

		public Result findResult(int playerIndex){
			return this.results.vs.Find (result => result.playerIndex.v == playerIndex);
		}

		#endregion

		#region Constructor

		public enum Property
		{
			results
		}

		public End() : base()
		{
			this.results = new LP<Result> (this, (byte)Property.results);
		}

		#endregion

		public override Type getType ()
		{
			return Type.End;
		}

	}
}