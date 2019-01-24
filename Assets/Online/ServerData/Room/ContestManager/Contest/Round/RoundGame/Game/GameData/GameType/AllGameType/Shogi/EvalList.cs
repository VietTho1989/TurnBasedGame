using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Shogi
{
	public class EvalList: Data
	{
		private static bool log = false;

		const int ListSize = 38;

		// EvalIndex list0[ListSize];
		public LP<int> list0;

		// EvalIndex list1[ListSize];
		public LP<int> list1;

		// Square listToSquareHand[ListSize];
		public LP<int> listToSquareHand;

		// int squareHandToList[SquareHandNum];
		public LP<int> squareHandToList;

		#region Constructor

		public enum Property
		{
			// EvalIndex list0[ListSize];
			list0,
			// EvalIndex list1[ListSize];
			list1,
			// Square listToSquareHand[ListSize];
			listToSquareHand,
			// int squareHandToList[SquareHandNum];
			squareHandToList
		}

		public EvalList() : base()
		{
			this.list0 = new LP<int> (this, (byte)Property.list0);
			this.list1 = new LP<int> (this, (byte)Property.list1);
			this.listToSquareHand = new LP<int> (this, (byte)Property.listToSquareHand);
			this.squareHandToList = new LP<int> (this, (byte)Property.squareHandToList);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(EvalList evalList)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// EvalIndex list0[ListSize];
						{
							if (evalList.list0.vs.Count != ListSize) {
								Debug.LogError ("parse evalList list0 count error");
							}
							for (int i = 0; i < ListSize; i++) {
								// get value
								int value = 0;
								{
									if (i < evalList.list0.vs.Count) {
										value = evalList.list0.vs [i];
									} else {
										if (log)
											Debug.LogError ("index error:  list0: " + evalList);
									}
								}
								writer.Write (value);
							}
						}
						// EvalIndex list1[ListSize];
						{
							if (evalList.list1.vs.Count != ListSize) {
								Debug.LogError ("parse evalList list1 count error");
							}
							for (int i = 0; i < ListSize; i++) {
								// get value
								int value = 0;
								{
									if (i < evalList.list1.vs.Count) {
										value = evalList.list1.vs [i];
									} else {
										if (log)
											Debug.LogError ("index error:  list1: " + evalList);
									}
								}
								writer.Write (value);
							}
						}
						// Square listToSquareHand[ListSize];
						{
							if (evalList.listToSquareHand.vs.Count != ListSize) {
								Debug.LogError ("parse evalList listToSquareHand count error");
							}
							for (int i = 0; i < ListSize; i++) {
								// get value
								int value = 0;
								{
									if (i < evalList.listToSquareHand.vs.Count) {
										value = evalList.listToSquareHand.vs [i];
									} else {
										if (log)
											Debug.LogError ("index error:  listToSquareHand: " + evalList);
									}
								}
								writer.Write (value);
							}
						}

						// int squareHandToList[SquareHandNum];
						{
							if (evalList.squareHandToList.vs.Count != (int)Common.Square.SquareHandNum) {
								Debug.LogError ("parse evalList squareHandToList count error");
							}
							for (int i = 0; i < (int)Common.Square.SquareHandNum; i++) {
								// get value
								int value = 0;
								{
									if (i < evalList.squareHandToList.vs.Count) {
										value = evalList.squareHandToList.vs [i];
									} else {
										if (log)
											Debug.LogError ("index error:  squareHandToList: " + evalList);
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

		public static int parse(EvalList evalList, byte[] byteArray, int start)
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
						// EvalIndex list0[ListSize];
						evalList.list0.clear();
						for (int i = 0; i < ListSize; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								evalList.list0.add (BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: list0: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 1:
					{
						// EvalIndex list1[ListSize];
						evalList.list1.clear();
						for (int i = 0; i < ListSize; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								evalList.list1.add (BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: list1: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					{
						// Square listToSquareHand[ListSize];
						evalList.listToSquareHand.clear();
						for (int i = 0; i < ListSize; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								evalList.listToSquareHand.add (BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: listToSquareHand: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 3:
					{
						// int squareHandToList[SquareHandNum];
						evalList.squareHandToList.clear();
						for (int i = 0; i < (int)Common.Square.SquareHandNum; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								evalList.squareHandToList.add (BitConverter.ToInt32 (byteArray, count));
								count += sizeof(int);
							} else {
								if(log)
									Debug.LogError ("array not enough length: squareHandToList: " + count + "; " + byteArray.Length);
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