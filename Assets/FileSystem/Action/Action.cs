using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public abstract class Action : Data
	{

		public enum Type
		{
			None,
			Edit
		}

		public abstract Type getType();

		public abstract class UIData : Data
		{

			public abstract Type getType ();

		}

	}
}