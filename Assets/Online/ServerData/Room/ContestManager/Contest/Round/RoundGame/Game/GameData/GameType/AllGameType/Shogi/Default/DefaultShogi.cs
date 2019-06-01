using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class DefaultShogi : DefaultGameType
	{

		#region Constructor

		public enum Property
		{

		}

		public DefaultShogi() : base()
		{

		}

        #endregion

        #region implement base

        public override GameType.Type getType ()
		{
			return GameType.Type.SHOGI;
		}

		public override GameType makeDefaultGameType ()
		{
			Shogi newShogi = Core.unityMakePositionByFen (Shogi.DefaultStartPositionSFEN);
			return newShogi;
		}

        #endregion

    }
}