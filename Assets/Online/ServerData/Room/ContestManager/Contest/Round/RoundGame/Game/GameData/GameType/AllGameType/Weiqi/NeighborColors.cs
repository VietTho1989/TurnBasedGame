using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class NeighborColors : Data
	{
		private static readonly bool log = false;

		/** char colors[S_MAX];*/ 
		// TODO size of char o C# la 2, o C++ la 1
		public LP<byte> colors;

		#region Constructor

		public enum Property
		{
			/** char colors[S_MAX];*/
			colors
		}

		public NeighborColors() : base()
		{
			this.colors = new LP<byte>(this, (byte)Property.colors);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(NeighborColors neighborColors)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** char colors[S_MAX];*/
						{
							for (int i = 0; i < (int)Common.stone.S_MAX; i++) {
								// get value
								byte value = 0;
								{
									if (i < neighborColors.colors.vs.Count) {
										value = neighborColors.colors.vs [i];
									} else {
										Debug.LogError ("error, index: colors: " + neighborColors);
									}
								}
								// write
								writer.Write (value);
							}
						}
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(NeighborColors neighborColors, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** char colors[S_MAX];*/
					{
						neighborColors.colors.clear ();
						int size = sizeof(byte);
						for (int i = 0; i < (int)Common.stone.S_MAX; i++) {
							if (count + size < byteArray.Length) {
								neighborColors.colors.add (byteArray[count]);
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: colors: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				default:
					alreadyPassAll = true;
					break;
				}
				index++;
				if (!isParseCorrect) {
					if(log)
						Debug.LogError ("not parse correct");
					break;
				}
				if (alreadyPassAll) {
					break;
				}
			}
			// return
			if (!isParseCorrect) {
				Debug.LogError ("parse neighborColors fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse neighborColors success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}