using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public abstract class Show : Data
	{

		public enum Type
		{
			Single
		}

		public abstract Type getType();

		public abstract class UIData : Data
		{

			public abstract Type getType();

			public abstract bool processEvent(Event e);

		}

	}
}