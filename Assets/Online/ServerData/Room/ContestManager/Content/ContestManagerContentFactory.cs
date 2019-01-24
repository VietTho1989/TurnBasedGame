using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public abstract class ContestManagerContentFactory : Data
	{

		public abstract ContestManagerContent.Type getType();

		public abstract ContestManagerContent makeContent();

	}
}