using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class Change
	{

		/**
		 * time when change happen
		 * */
		public float t;

		public WrapChange change = new WrapChange();

		#region makeBinary

		public void makeBinary(BinaryWriter writer)
		{
			writer.Write (this.t);
			this.change.makeBinary (writer);
		}

		public static Change parse(BinaryReader reader)
		{
			Change change = new Change ();
			{
				change.t = reader.ReadSingle ();
				// wrapChange
				{
					Data outData = Data.parseBinary (reader);
					if (outData is WrapChange) {
						change.change = outData as WrapChange;
					} else {
						Debug.LogError ("why outData not wrapChange: " + outData);
					}
				}
			}
			return change;
		}

		#endregion

	}
}