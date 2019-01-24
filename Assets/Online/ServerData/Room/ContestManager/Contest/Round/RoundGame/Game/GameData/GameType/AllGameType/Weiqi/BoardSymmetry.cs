using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class BoardSymmetry : Data
	{
		private static readonly bool log = false;

		/** int x1;*/
		public VP<int> x1;
		/** int x2;*/
		public VP<int> x2;
		/** int y1;*/
		public VP<int> y1;
		/** int y2;*/
		public VP<int> y2;
		/** int d;*/
		public VP<int> d;
		/** enum e_sym type;*/
		public VP<int> type;

		#region Constructor

		public enum Property
		{
			/** int x1;*/
			x1,
			/** int x2;*/
			x2,
			/** int y1;*/
			y1,
			/** int y2;*/
			y2,
			/** int d;*/
			d,
			/** enum e_sym type;*/
			type
		}

		public BoardSymmetry() : base()
		{
			this.x1 = new VP<int> (this, (byte)Property.x1, 0);
			this.x2 = new VP<int> (this, (byte)Property.x2, 0);
			this.y1 = new VP<int> (this, (byte)Property.y1, 0);
			this.y2 = new VP<int> (this, (byte)Property.y2, 0);
			this.d = new VP<int> (this, (byte)Property.d, 0);
			this.type = new VP<int> (this, (byte)Property.type, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(BoardSymmetry boardSymmetry)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** int x1;*/
						writer.Write (boardSymmetry.x1.v);
						/** int x2;*/
						writer.Write (boardSymmetry.x2.v);
						/** int y1;*/
						writer.Write (boardSymmetry.y1.v);
						/** int y2;*/
						writer.Write (boardSymmetry.y2.v);
						/** int d;*/
						writer.Write (boardSymmetry.d.v);
						/** enum e_sym type;*/
						writer.Write (boardSymmetry.type.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(BoardSymmetry boardSymmetry, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** int x1;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardSymmetry.x1.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: x1: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** int x2;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardSymmetry.x2.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: x2: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** int y1;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardSymmetry.y1.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: y1: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** int y2;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardSymmetry.y2.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: y2: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** int d;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardSymmetry.d.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: d: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 5:
					/** enum e_sym type;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardSymmetry.type.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: type: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
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
				Debug.LogError ("parse boardSymmetry fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse boardSymmetry success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}