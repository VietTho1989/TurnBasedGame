using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MineSweeper
{
	public class Point : Data
	{

		public VP<sbyte> x;

		public VP<sbyte> y;

		#region Constructor

		public enum Property
		{
			x,
			y
		}

		public Point() : base()
		{
			this.x = new VP<sbyte> (this, (byte)Property.x, 0);
			this.y = new VP<sbyte> (this, (byte)Property.y, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Point point)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// int x
						writer.Write(point.x.v);
						// int y
						writer.Write(point.y.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Point point, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					// sbyte x
					{
						int size = sizeof(sbyte);
						if (count + size <= byteArray.Length) {
							point.x.v = (sbyte)byteArray [count];
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					// sbyte y
					{
						int size = sizeof(sbyte);
						if (count + size <= byteArray.Length) {
							point.y.v = (sbyte)byteArray [count];
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				index++;
				if (!isParseCorrect) {
					Debug.LogError ("not parse correct");
					break;
				}
				if (alreadyPassAll) {
					break;
				}
			}
			// return
			if (!isParseCorrect) {
				Debug.LogError ("parse fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}
}