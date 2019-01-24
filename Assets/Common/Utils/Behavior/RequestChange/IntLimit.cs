using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class IntLimit : Data
{

	public enum Type
	{
		No,
		Have
	}

	public abstract Type getType();


	#region No

	public class No : IntLimit
	{

		#region Constructor

		public enum Property
		{

		}

		public No() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.No;
		}

	}

	#endregion

	#region Have

	public class Have : IntLimit
	{

		public VP<int> min;

		public VP<int> max;

		#region Constructor

		public enum Property
		{
			min,
			max
		}

		public Have() : base()
		{
			this.min = new VP<int>(this, (byte)Property.min, 0);
			this.max = new VP<int>(this, (byte)Property.max, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Have;
		}

	}

	#endregion

}