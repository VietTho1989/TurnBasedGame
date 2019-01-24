using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rule
{
	public class AbstractRuleList
	{
		/** origin of piece*/
		public const byte x = 0;

		/** dest position*/
		public const byte d = 1;

		/** expand this direction until meet piece*/
		public const byte r = 2;

		/** expand this direction like cannon*/
		public const byte c = 3;

		/** pin*/
		public const byte p = 4;

		/** xiangqi king vs king*/
		public const byte k = 5;

	}
}