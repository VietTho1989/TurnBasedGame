using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	/**
	* quan ly cac contest: co the la single, round robin, loai truc tiep
	**/
	public class ContestManager : Data
	{

        public bool isFastStart = false;

		public VP<int> index;

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Lobby,
				Play
			}

			public abstract Type getType();

		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			index,
			state
		}

		public ContestManager() : base()
		{
			this.index = new VP<int> (this, (byte)Property.index, 0);
			this.state = new VP<State> (this, (byte)Property.state, new ContestManagerStateLobby ());
		}

		#endregion

	}
}