using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Xiangqi
{
	public class RollbackStruct : Data
	{

		/** ZobristStruct zobr;*/
		public VP<ZobristStruct> zobr;

		/** int vlWhite;*/
		public VP<int> vlWhite;

		/** int vlBlack;*/
		public VP<int> vlBlack;

		/** MoveStruct mvs; uint32_t dwmv;*/
		public VP<System.UInt32> mvs;

		#region Constructor

		public enum Property
		{
			/** ZobristStruct zobr;*/
			zobr,
			/** int vlWhite;*/
			vlWhite,
			/** int vlBlack;*/
			vlBlack,
			/** MoveStruct mvs; uint32_t dwmv;*/
			mvs
		}

		public RollbackStruct() : base()
		{
			this.zobr = new VP<ZobristStruct> (this, (byte)Property.zobr, new ZobristStruct ());
			this.vlWhite = new VP<int> (this, (byte)Property.vlWhite, 0);
			this.vlBlack = new VP<int> (this, (byte)Property.vlBlack, 0);
			this.mvs = new VP<uint> (this, (byte)Property.mvs, 0);
		}

		#endregion

		#region Convert 

		public static byte[] convertToBytes(RollbackStruct rbs)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** ZobristStruct zobr;*/
						writer.Write (ZobristStruct.convertToBytes (rbs.zobr.v));
						/** int vlWhite;*/
						writer.Write (rbs.vlWhite.v);
						/** int vlBlack;*/
						writer.Write (rbs.vlBlack.v);
						/** MoveStruct mvs; uint32_t dwmv;*/
						writer.Write (rbs.mvs.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(RollbackStruct rbs, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** ZobristStruct zobr;*/
					{
						ZobristStruct zobr = rbs.zobr.v;
						// parse
						{
							int byteLength = ZobristStruct.parse (zobr, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							// Debug.LogError ("RollBackStruct: zobr: parse correct: " + rbs);
						} else {
							Debug.LogError ("parse evalList error");
						}
					}
					break;
				case 1:
					/** int vlWhite;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							rbs.vlWhite.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** int vlBlack;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							rbs.vlBlack.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** MoveStruct mvs; uint32_t dwmv;*/
					{
						int size = sizeof(System.UInt32);
						if (count + size <= byteArray.Length) {
							rbs.mvs.v = BitConverter.ToUInt32 (byteArray, count);
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