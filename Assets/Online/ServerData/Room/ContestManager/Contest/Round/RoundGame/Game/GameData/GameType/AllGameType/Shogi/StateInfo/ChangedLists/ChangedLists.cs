using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Shogi
{
	public class ChangedLists : Data
	{
		private static bool log = false;

		// ChangedListPair clistpair[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
		public LP<ChangedListPair> clistpair;

		// int listindex[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
		public LP<int> listindex;

		// size_t size;
		public VP<ulong> size;

		#region Constructor

		public enum Property
		{
			// ChangedListPair clistpair[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
			clistpair,
			// int listindex[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
			listindex,
			// size_t size;
			size
		}

		public ChangedLists() : base()
		{
			// ChangedListPair clistpair[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
			this.clistpair = new LP<ChangedListPair>(this, (byte)Property.clistpair);
			// int listindex[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
			this.listindex = new LP<int>(this, (byte)Property.listindex);
			// size_t size;
			this.size = new VP<ulong>(this, (byte)Property.size, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(ChangedLists changedLists)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// ChangedListPair clistpair[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
						{
							if (changedLists.clistpair.vs.Count != 2) {
								Debug.LogError ("parse changedLists clistpair count error");
							}
							for (int i = 0; i < 2; i++) {
								// get value
								ChangedListPair value = null;
								{
									if (i < changedLists.clistpair.vs.Count) {
										value = changedLists.clistpair.vs [i];
									} else {
										Debug.LogError ("index error: " + changedLists);
									}
									if (value == null) {
										value = new ChangedListPair ();
									}
								}
								writer.Write (ChangedListPair.convertToBytes (value));
							}
						}
						// int listindex[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
						{
							if (changedLists.listindex.vs.Count != 2) {
								Debug.LogError ("parse changedLists listindex count error");
							}
							for (int i = 0; i < 2; i++) {
								// get value
								int value = 0;
								{
									if (i < changedLists.listindex.vs.Count) {
										value = changedLists.listindex.vs [i];
									} else {
										if (log)
											Debug.LogError ("index error: " + changedLists);
									}
								}
								writer.Write (value);
							}
						}
						// size_t size;
						writer.Write(changedLists.size.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(ChangedLists changedLists, byte[] byteArray, int start)
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
						// ChangedListPair clistpair[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
						changedLists.clistpair.clear ();
						// parse
						{
							// get list of stateInfo
							List<ChangedListPair> clistpair = new List<ChangedListPair> ();
							for (int i = 0; i < 2; i++) {
								ChangedListPair changedListPair = new ChangedListPair ();
								int changedListPairByteLength = ChangedListPair.parse (changedListPair, byteArray, count);
								if (changedListPairByteLength > 0) {
									// add to list
									clistpair.Add (changedListPair);
									// increase pointer index
									count += changedListPairByteLength;
								} else {
									if (log)
										Debug.LogError ("cannot parse");
									isParseCorrect = false;
									break;
								}
							}
							if(log)
								Debug.LogError ("parse changeListPair count: " + clistpair.Count);
							// add to chess data
							for (int i = 0; i < clistpair.Count; i++) {
								ChangedListPair changedListPair = clistpair [i];
								{
									changedListPair.uid = changedLists.clistpair.makeId ();
								}
								changedLists.clistpair.add (changedListPair);
							}
						}
					}
					break;
				case 1:
					{
						// int listindex[2]; // 一手で動く駒は最大2つ。(動く駒、取られる駒)
						changedLists.listindex.clear();
						for (int i = 0; i < 2; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								changedLists.listindex.add(BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: listindex: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					{
						// size_t size;
						if (count + sizeof(ulong) <= byteArray.Length) {
							changedLists.size.v = BitConverter.ToUInt64 (byteArray, count);
							count += sizeof(ulong);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
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