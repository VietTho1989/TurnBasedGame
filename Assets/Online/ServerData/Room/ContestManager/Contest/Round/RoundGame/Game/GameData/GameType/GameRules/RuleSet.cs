using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rule
{
	public class RuleSet
	{

		public byte[,] matrix;

		public byte x = 0;

		public byte y = 0;

		#region Other

        /** chinese chess: general vs general*/
		public byte otherKing = 0;

		#endregion

	}
}