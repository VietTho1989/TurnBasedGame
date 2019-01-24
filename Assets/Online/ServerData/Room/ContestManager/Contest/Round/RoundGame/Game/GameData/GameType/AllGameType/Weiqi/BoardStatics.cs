using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class BoardStatics : Data
	{
		private static readonly bool log = false;

		/** int size*/
		public VP<int> size;
		/** int nei8[8];*/
		public LP<int> nei8;
		/** int dnei[4];*/
		public LP<int> dnei;
		/** hash_t h[BOARD_MAX_COORDS][2]*/
		public LP<System.UInt64> h;
		/** uint8_t coord[BOARD_MAX_COORDS][2]*/
		public LP<byte> coord;

		#region Constructor

		public enum Property
		{
			/** int size*/
			size,
			/** int nei8[8];*/
			nei8,
			/** int dnei[4];*/
			dnei,
			/** hash_t h[BOARD_MAX_COORDS][2]*/
			h,
			/** uint8_t coord[BOARD_MAX_COORDS][2]*/
			coord
		}

		public BoardStatics() : base()
		{
			this.size = new VP<int> (this, (byte)Property.size, 0);
			this.nei8 = new LP<int> (this, (byte)Property.nei8);
			this.dnei = new LP<int> (this, (byte)Property.dnei);
			this.h = new LP<ulong> (this, (byte)Property.h);
			this.coord = new LP<byte> (this, (byte)Property.coord);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(BoardStatics boardStatics)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** int size*/
						writer.Write (boardStatics.size.v);
						/** int nei8[8];*/
						{
							for (int i = 0; i < 8; i++) {
								// get value
								int value = 0;
								{
									if (i < boardStatics.nei8.vs.Count) {
										value = boardStatics.nei8.vs [i];
									} else {
										Debug.LogError ("error, index:  nei8: " + boardStatics);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** int dnei[4];*/
						{
							for (int i = 0; i < 4; i++) {
								// get value
								int value = 0;
								{
									if (i < boardStatics.dnei.vs.Count) {
										value = boardStatics.dnei.vs [i];
									} else {
										Debug.LogError ("error, index:  dnei: " + boardStatics);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** hash_t h[BOARD_MAX_COORDS][2]*/
						{
							for (int y = 0; y < 2; y++) {
								for (int x = 0; x < Common.BOARD_MAX_COORDS; x++) {
									// get value
									ulong value = 0;
									{
										int i = x + Common.BOARD_MAX_COORDS * y;
										if (i < boardStatics.h.vs.Count) {
											value = boardStatics.h.vs [i];
										} else {
											Debug.LogError ("error, index:  h: " + boardStatics);
										}
									}
									// write
									writer.Write (value);
								}
							}
						}
						/** uint8_t coord[BOARD_MAX_COORDS][2]*/
						{
							for (int y = 0; y < 2; y++) {
								for (int x = 0; x < Common.BOARD_MAX_COORDS; x++) {
									// get value
									byte value = 0;
									{
										int i = x + Common.BOARD_MAX_COORDS * y;
										if (i < boardStatics.coord.vs.Count) {
											value = boardStatics.coord.vs [i];
										} else {
											Debug.LogError ("error, index:  h: " + boardStatics);
										}
									}
									// write
									writer.Write (value);
								}
							}
						}
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(BoardStatics boardStatics, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** int size*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardStatics.size.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** int nei8[8];*/
					{
						boardStatics.nei8.clear ();
						int size = sizeof(int);
						for (int i = 0; i < 8; i++) {
							if (count + size <= byteArray.Length) {
								boardStatics.nei8.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: nei8: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					/** int dnei[4];*/
					{
						boardStatics.dnei.clear ();
						int size = sizeof(int);
						for (int i = 0; i < 4; i++) {
							if (count + size <= byteArray.Length) {
								boardStatics.dnei.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: dnei: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 3:
					/** hash_t h[BOARD_MAX_COORDS][2]*/
					{
						boardStatics.h.clear ();
						int size = sizeof(ulong);
						for (int y = 0; y < 2; y++) {
							for (int x = 0; x < Common.BOARD_MAX_COORDS; x++) {
								if (count + size <= byteArray.Length) {
									boardStatics.h.add (BitConverter.ToUInt64 (byteArray, count));
									count += size;
								} else {
									if (log)
										Debug.LogError ("array not enough length: h: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
							}
						}
					}
					break;
				case 4:
					/** uint8_t coord[BOARD_MAX_COORDS][2]*/
					{
						boardStatics.coord.clear ();
						int size = sizeof(byte);
						for (int y = 0; y < 2; y++) {
							for (int x = 0; x < Common.BOARD_MAX_COORDS; x++) {
								if (count + size < byteArray.Length) {
									boardStatics.coord.add (byteArray [count]);
									count += size;
								} else {
									if (log)
										Debug.LogError ("array not enough length: coord: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
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
				Debug.LogError ("parse boardStatics fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse boardStatics success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}