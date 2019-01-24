using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
	public abstract class Limit : Data
	{
		public enum Type
		{
			NoLimit,
			HaveLimit
		}

		public abstract Type getType();

		public abstract bool isOverLimit(int number);

		public abstract class UIData : Data
		{

			public abstract Type getType ();

		}

	}
}