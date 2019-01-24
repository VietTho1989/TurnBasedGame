using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class Group : Data
	{
		private static readonly bool log = false;

		/* We keep track of only up to GROUP_KEEP_LIBS; over that, we
         * don't care. */
		/* _Combination_ of these two values can make some difference
		* in performance - fine-tune. */
		public const int GROUP_KEEP_LIBS = 10;
		// refill lib[] only when we hit this; this must be at least 2!
		// Moggy requires at least 3 - see below for semantic impact.
		public const int GROUP_REFILL_LIBS = 5;
		/** coord_t lib[GROUP_KEEP_LIBS];*/
		public LP<int> lib;
		/* libs is only LOWER BOUND for the number of real liberties!!!
         * It denotes only number of items in lib[], thus you can rely
         * on it to store real liberties only up to <= GROUP_REFILL_LIBS. */
		public VP<int> libs;

		#region Constructor

		public enum Property
		{
			/** coord_t lib[GROUP_KEEP_LIBS];*/
			lib,
			/** int libs*/
			libs
		}

		public Group() : base()
		{
			this.lib = new LP<int> (this, (byte)Property.lib);
			this.libs = new VP<int> (this, (byte)Property.libs, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Group group)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** coord_t lib[GROUP_KEEP_LIBS];*/
						{
							for (int i = 0; i < GROUP_KEEP_LIBS; i++) {
								// get value
								int value = 0;
								{
									if (i < group.lib.vs.Count) {
										value = group.lib.vs [i];
									} else {
										Debug.LogError ("error, index:  lib: " + group);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** int libs*/
						writer.Write(group.libs.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Group group, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** coord_t lib[GROUP_KEEP_LIBS];*/
					{
						group.lib.clear ();
						int size = sizeof(int);
						for (int i = 0; i < GROUP_KEEP_LIBS; i++) {
							if (count + size <= byteArray.Length) {
								group.lib.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: lib: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 1:
					/** int libs*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							group.libs.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: libs: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse group fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse group success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}