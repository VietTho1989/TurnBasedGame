using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class BoardOwnerMap : Data
	{
		private static readonly bool log = false;

		/* Map of final owners of all intersections on the board. */
		/* This may be shared between multiple threads! */
		/* XXX: We assume sig_atomic_t is thread-atomic. This may not
         * be true in pathological cases. */
		/** sig_atomic_t playouts;*/
		public VP<int> playouts;
		/* At the final board position, for each coordinate increase the
         * counter of appropriate color. */
		/** sig_atomic_t map[BOARD_MAX_COORDS][S_MAX];*/
		public LP<int> map;

		#region Constructor

		public enum Property
		{
			/** sig_atomic_t playouts;*/
			playouts,
			/** sig_atomic_t map[BOARD_MAX_COORDS][S_MAX];*/
			map
		}

		public BoardOwnerMap() : base()
		{
			/** sig_atomic_t playouts;*/
			this.playouts = new VP<int> (this, (byte)Property.playouts, 0);
			/** sig_atomic_t map[BOARD_MAX_COORDS][S_MAX];*/
			this.map = new LP<int> (this, (byte)Property.map);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(BoardOwnerMap boardOwnerMap)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** sig_atomic_t playouts;*/
						writer.Write (boardOwnerMap.playouts.v);
						/** sig_atomic_t map[BOARD_MAX_COORDS][S_MAX];*/
						{
							for (int y = 0; y < (int)Common.stone.S_MAX; y++) {
								for (int x = 0; x < Common.BOARD_MAX_COORDS; x++) {
									// get value
									int value = 0;
									{
										int i = x + Common.BOARD_MAX_COORDS * y;
										if (i < boardOwnerMap.map.vs.Count) {
											value = boardOwnerMap.map.vs [i];
										} else {
											Debug.LogError ("error, index:  map: " + boardOwnerMap);
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

		public static int parse(BoardOwnerMap boardOwnerMap, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** sig_atomic_t playouts;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							boardOwnerMap.playouts.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: playouts: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** sig_atomic_t map[BOARD_MAX_COORDS][S_MAX];*/
					{
						boardOwnerMap.map.clear ();
						int size = sizeof(int);
						for (int y = 0; y < (int)Common.stone.S_MAX; y++) {
							for (int x = 0; x < Common.BOARD_MAX_COORDS; x++) {
								if (count + size <= byteArray.Length) {
									boardOwnerMap.map.add (BitConverter.ToInt32 (byteArray, count));
									count += size;
								} else {
									if (log)
										Debug.LogError ("array not enough length: map: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse boardOwnerMap fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse boardOwnerMap success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}