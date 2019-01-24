using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Shogi
{
	public class ChangedListPair : Data
	{
		private static bool log = false;

		// EvalIndex newlist[2];
		public LP<int> newList;

		// EvalIndex oldlist[2];
		public LP<int> oldlist;

		#region Constructor

		public enum Property
		{
			// EvalIndex newlist[2];
			newList,
			// EvalIndex oldlist[2];
			oldlist
		}

		public ChangedListPair() : base()
		{
			// EvalIndex newlist[2];
			this.newList = new LP<int>(this, (byte)Property.newList);
			// EvalIndex oldlist[2];
			this.oldlist = new LP<int>(this, (byte)Property.oldlist);
		}

		#endregion

		#region convert

		public static byte[] convertToBytes(ChangedListPair changedListPair)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// EvalIndex newlist[2];
						{
							if (changedListPair.newList.vs.Count != 2) {
								Debug.LogError ("parse changedListPair newList count error");
							}
							for (int i = 0; i < 2; i++) {
								// get value
								int value = 0;
								{
									if (i < changedListPair.newList.vs.Count) {
										value = changedListPair.newList.vs [i];
									} else {
										Debug.LogError ("index error: " + changedListPair);
									}
								}
								writer.Write (value);
							}
						}
						// EvalIndex oldlist[2];
						{
							if (changedListPair.newList.vs.Count != 2) {
								Debug.LogError ("parse changedListPair oldlist count error");
							}
							for (int i = 0; i < 2; i++) {
								// get value
								int value = 0;
								{
									if (i < changedListPair.oldlist.vs.Count) {
										value = changedListPair.oldlist.vs [i];
									} else {
										Debug.LogError ("index error: " + changedListPair);
									}
								}
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

		public static int parse(ChangedListPair changeListPair, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						// EvalIndex newlist[2];
						changeListPair.newList.clear();
						for (int i = 0; i < 2; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								changeListPair.newList.add(BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: newlist: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 1:
					{
						// EvalIndex oldlist[2];
						changeListPair.oldlist.clear();
						for (int i = 0; i < 2; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								changeListPair.oldlist.add(BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: newlist: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				default:
					if(log)
						Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				if(log)
					Debug.LogError ("count: " + count + "; " + index);
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
				if(log)
					Debug.LogError ("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}