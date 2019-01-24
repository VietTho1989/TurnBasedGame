using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Xiangqi
{
	public class ZobristStruct : Data
	{

		/** uint32_t dwKey;*/
		public VP<System.UInt32> dwKey;

		/** uint32_t dwLock0;*/
		public VP<System.UInt32> dwLock0;

		/** uint32_t dwLock1;*/
		public VP<System.UInt32> dwLock1;

		#region Constructor

		public enum Property
		{
			/** uint32_t dwKey;*/
			dwKey,
			/** uint32_t dwLock0;*/
			dwLock0,
			/** uint32_t dwLock1;*/
			dwLock1
		}

		public ZobristStruct() : base()
		{
			this.dwKey = new VP<uint> (this, (byte)Property.dwKey, 0);
			this.dwLock0 = new VP<uint> (this, (byte)Property.dwLock0, 0);
			this.dwLock1 = new VP<uint> (this, (byte)Property.dwLock1, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(ZobristStruct zobr)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** uint32_t dwKey;*/
						writer.Write(zobr.dwKey.v);
						/** uint32_t dwLock0;*/
						writer.Write (zobr.dwLock0.v);
						/** uint32_t dwLock1;*/
						writer.Write (zobr.dwLock1.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(ZobristStruct zobr, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** uint32_t dwKey;*/
					{
						int size = sizeof(System.UInt32);
						if (count + size <= byteArray.Length) {
							zobr.dwKey.v = BitConverter.ToUInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** uint32_t dwLock0;*/
					{
						int size = sizeof(System.UInt32);
						if (count + size <= byteArray.Length) {
							zobr.dwLock0.v = BitConverter.ToUInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** uint32_t dwLock1;*/
					{
						int size = sizeof(System.UInt32);
						if (count + size <= byteArray.Length) {
							zobr.dwLock1.v = BitConverter.ToUInt32 (byteArray, count);
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
				Debug.LogError ("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}

}