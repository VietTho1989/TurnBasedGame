using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Shogi
{
	public class StateInfo : Data
	{
		private static bool log = false;

		// Score material;
		public VP<int> material;

		// int pliesFromNull;
		public VP<int> pliesFromNull;

		// int continuousCheck[ColorNum];
		public LP<int> continuousCheck;

		// Key boardKey;
		public VP<System.UInt64> boardKey;

		// Key handKey;
		public VP<System.UInt64> handKey;

		// Bitboard checkersBB;
		public VP<Common.BitBoard> checkersBB;

		// Piece capturedPiece;
		public VP<Common.Piece> capturedPiece;

		// Hand hand;
		public VP<System.UInt32> hand;

		// ChangedLists cl;
		public VP<ChangedLists> cl;

		#region Constructor

		public enum Property
		{
			// Score material;
			material,
			// int pliesFromNull;
			pliesFromNull,
			// int continuousCheck[ColorNum];
			continuousCheck,
			// Key boardKey;
			boardKey,
			// Key handKey;
			handKey,
			// Bitboard checkersBB;
			checkersBB,
			// Piece capturedPiece;
			capturedPiece,
			// Hand hand;
			hand,
			// ChangedLists cl;
			cl
		}

		public StateInfo() : base()
		{
			// Score material;
			this.material = new VP<int>(this, (byte)Property.material, 0);
			// int pliesFromNull;
			this.pliesFromNull = new VP<int>(this, (byte)Property.pliesFromNull, 0);
			// int continuousCheck[ColorNum];
			this.continuousCheck = new LP<int>(this, (byte)Property.continuousCheck);
			// Key boardKey;
			this.boardKey = new VP<ulong>(this, (byte)Property.boardKey, 0);
			// Key handKey;
			this.handKey = new VP<ulong>(this, (byte)Property.handKey, 0);
			// Bitboard checkersBB;
			this.checkersBB = new VP<Common.BitBoard>(this, (byte)Property.checkersBB, new Common.BitBoard());
			// Piece capturedPiece;
			this.capturedPiece = new VP<Common.Piece>(this, (byte)Property.capturedPiece, 0);
			// Hand hand;
			this.hand = new VP<uint>(this, (byte)Property.hand, 0);
			// ChangedLists cl;
			this.cl = new VP<ChangedLists>(this, (byte)Property.cl, new ChangedLists());
		}

		#endregion

		public System.UInt64 key()
		{
			return boardKey.v + handKey.v;
		}

		#region Convert

		public static byte[] convertToBytes(StateInfo stateInfo)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// Score material;
						writer.Write(stateInfo.material.v);
						// int pliesFromNull;
						writer.Write(stateInfo.pliesFromNull.v);
						// int continuousCheck[ColorNum];
						{
							if (stateInfo.continuousCheck.vs.Count != (int)Common.Color.ColorNum) {
								Debug.LogError ("parse stateInfo continuousCheck count error");
							}
							for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
								// get value
								int value = 0;
								{
									if (i < stateInfo.continuousCheck.vs.Count) {
										value = stateInfo.continuousCheck.vs [i];
									} else {
										if (log)
											Debug.LogError ("index error:  continuousCheck: " + stateInfo);
									}
								}
								writer.Write (value);
							}
						}
						// Key boardKey;
						writer.Write(stateInfo.boardKey.v);
						// Key handKey;
						writer.Write(stateInfo.handKey.v);
						// Bitboard checkersBB;
						{
							writer.Write (stateInfo.checkersBB.v.p0);
							writer.Write (stateInfo.checkersBB.v.p1);
						}
						// Piece capturedPiece;
						writer.Write((int)stateInfo.capturedPiece.v);
						// Hand hand;
						writer.Write(stateInfo.hand.v);
						// ChangedLists cl;
						writer.Write(ChangedLists.convertToBytes(stateInfo.cl.v));
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(StateInfo stateInfo, byte[] byteArray, int start)
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
						if(Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: material: " + count);
						// Score material;
						if (count + sizeof(int) <= byteArray.Length) {
							stateInfo.material.v = BitConverter.ToInt32 (byteArray, count);
							count += sizeof(int);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: pliesFromNull: " + count);
						// int pliesFromNull;
						if (count + sizeof(int) <= byteArray.Length) {
							stateInfo.pliesFromNull.v = BitConverter.ToInt32 (byteArray, count);
							count += sizeof(int);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: continuousCheck: " + count);
						// int continuousCheck[ColorNum];
						stateInfo.continuousCheck.clear();
						for (int i = 0; i < (int)Common.Color.ColorNum; i++) {
							if (count + sizeof(int) <= byteArray.Length) {
								stateInfo.continuousCheck.add(BitConverter.ToInt32 (byteArray, count));
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
				case 3:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: boardKey: " + count);
						// Key boardKey;
						if (count + sizeof(ulong) <= byteArray.Length) {
							stateInfo.boardKey.v = BitConverter.ToUInt64 (byteArray, count);
							count += sizeof(ulong);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: handKey: " + count);
						// Key handKey;
						if (count + sizeof(ulong) <= byteArray.Length) {
							stateInfo.handKey.v = BitConverter.ToUInt64 (byteArray, count);
							count += sizeof(ulong);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 5:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: checkersBB: " + count);
						// Bitboard checkersBB;
						// p0
						System.UInt64 p0 = 0;
						if (isParseCorrect) {
							if (count + sizeof(ulong) <= byteArray.Length) {
								p0 = BitConverter.ToUInt64 (byteArray, count);
								count += sizeof(ulong);
							} else {
								if (log)
									Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// p1
						System.UInt64 p1 = 0;
						if (isParseCorrect) {
							if (count + sizeof(ulong) <= byteArray.Length) {
								p1 = BitConverter.ToUInt64 (byteArray, count);
								count += sizeof(ulong);
							} else {
								if (log)
									Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// set value
						if (isParseCorrect) {
							stateInfo.checkersBB.v = new Common.BitBoard (p0, p1);
						}
					}
					break;
				case 6:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: capturedPiece: " + count);
						// Piece capturedPiece;
						if (count + sizeof(int) <= byteArray.Length) {
							stateInfo.capturedPiece.v = (Common.Piece)BitConverter.ToInt32 (byteArray, count);
							count += sizeof(int);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 7:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: hand: " + count);
						// Hand hand;
						if (count + sizeof(uint) <= byteArray.Length) {
							stateInfo.hand.v = BitConverter.ToUInt32 (byteArray, count);
							count += sizeof(uint);
						} else {
							if(log)
								Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 8:
					{
						if (Shogi.parseLog)
							Debug.LogError ("parse shogi: stateInfo: changedLists: " + count);
						// ChangedLists cl;
						ChangedLists cl = new ChangedLists();
						// parse
						{
							int byteLength = ChangedLists.parse (cl, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								if (log)
									Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							cl.uid = stateInfo.cl.makeId ();
							stateInfo.cl.v = cl;
						} else {
							Debug.LogError ("parse ChangedLists error");
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