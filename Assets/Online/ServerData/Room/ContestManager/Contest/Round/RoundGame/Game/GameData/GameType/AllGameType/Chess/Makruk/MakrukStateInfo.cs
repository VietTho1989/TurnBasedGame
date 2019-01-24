using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace Makruk
{
	public class MakrukStateInfo : Data
	{

		/** Key    pawnKey*/
		public VP<ulong> pawnKey;
		/** Key    materialKey*/
		public VP<ulong> materialKey;
		/** Value  nonPawnMaterial[COLOR_NB];*/
		public LP<int> nonPawnMaterial;

		/** int    rule50;*/
		public VP<int> rule50;
		/** int    pliesFromNull;*/
		public VP<int> pliesFromNull;
		/** Score  psq;*/
		public VP<int> psq;

		// Not copied when making a move (will be recomputed anyhow)
		/** Key        key;*/
		public VP<ulong> key;
		/** Bitboard   checkersBB;*/
		public VP<ulong> checkersBB;
		/** Piece      capturedPiece;*/
		public VP<int> capturedPiece;
		/** Bitboard   blockersForKing[COLOR_NB];*/
		public LP<ulong> blockersForKing;
		/**  Bitboard   pinnersForKing[COLOR_NB];*/
		public LP<ulong> pinnersForKing;
		/** Bitboard   checkSquares[PIECE_TYPE_NB];*/
		public LP<ulong> checkSquares;

		#region Constructor

		public enum Property
		{
			/** VP<ulong>*/
			pawnKey,
			/** VP<ulong>*/
			materialKey,
			/** LP<int>*/
			nonPawnMaterial,

			/** VP<int>*/
			rule50,
			/** VP<int>*/
			pliesFromNull,
			/** VP<int>*/
			psq,

			/** VP<ulong>*/
			key,
			/** VP<ulong>*/
			checkersBB,
			/** VP<int>*/
			capturedPiece,
			/** LP<ulong>*/
			blockersForKing,
			/** LP<ulong>*/
			pinnersForKing,
			/** LP<ulong>*/
			checkSquares
		}

		public MakrukStateInfo() : base()
		{
			this.pawnKey = new VP<ulong> (this, (byte)Property.pawnKey, 0);
			this.materialKey = new VP<ulong> (this, (byte)Property.materialKey, 0);
			this.nonPawnMaterial = new LP<int> (this, (byte)Property.nonPawnMaterial);

			this.rule50 = new VP<int> (this, (byte)Property.rule50, 0);
			this.pliesFromNull = new VP<int> (this, (byte)Property.pliesFromNull, 0);
			this.psq = new VP<int> (this, (byte)Property.psq, 0);

			this.key = new VP<ulong> (this, (byte)Property.key, 0);
			this.checkersBB = new VP<ulong> (this, (byte)Property.checkersBB, 0);
			this.capturedPiece = new VP<int> (this, (byte)Property.capturedPiece, 0);
			this.blockersForKing = new LP<ulong> (this, (byte)Property.blockersForKing);
			this.pinnersForKing = new LP<ulong> (this, (byte)Property.pinnersForKing);
			this.checkSquares = new LP<ulong> (this, (byte)Property.checkSquares);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(MakrukStateInfo st)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// public VP<ulong> pawnKey;
					writer.Write(st.pawnKey.v);
					// public VP<ulong> materialKey;
					writer.Write(st.materialKey.v);
					// public LP<int> nonPawnMaterial; // [COLOR_NB]
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < st.nonPawnMaterial.vs.Count) {
								value = st.nonPawnMaterial.vs [i];
							} else {
								Debug.LogError ("index error: " + st);
							}
						}
						writer.Write (value);
					}

					// public VP<int> rule50;
					writer.Write(st.rule50.v);
					// public VP<int> pliesFromNull;
					writer.Write(st.pliesFromNull.v);
					// public VP<int> psq;
					writer.Write(st.psq.v);

					// Not copied when making a move (will be recomputed anyhow)
					// public VP<ulong> key;
					writer.Write(st.key.v);
					// public VP<ulong> checkersBB;
					writer.Write(st.checkersBB.v);
					// public VP<int> capturedPiece;
					writer.Write(st.capturedPiece.v);
					// public LP<ulong> blockersForKing;// [COLOR_NB]
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < st.blockersForKing.vs.Count) {
								value = st.blockersForKing.vs [i];
							} else {
								Debug.LogError ("index error: " + st);
							}
						}
						writer.Write (value);
					}
					// public LP<ulong> pinnersForKing; // [COLOR_NB]
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < st.pinnersForKing.vs.Count) {
								value = st.pinnersForKing.vs [i];
							} else {
								Debug.LogError ("index error: " + st);
							}
						}
						writer.Write (value);
					}
					// public LP<ulong> checkSquares;// [PIECE_TYPE_NB]
					for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < st.checkSquares.vs.Count) {
								value = st.checkSquares.vs [i];
							} else {
								Debug.LogError ("index error: " + st);
							}
						}
						writer.Write (value);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		#endregion

		public static int parse(MakrukStateInfo st, byte[] byteArray, int start)
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
						// public VP<ulong> pawnKey;
						int size = sizeof(ulong);
						if (count + size <= byteArray.Length) {
							st.pawnKey.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: pawnKey: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						// public VP<ulong> materialKey;
						int size = sizeof(ulong);
						if (count + size <= byteArray.Length) {
							st.materialKey.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: materialKey: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					{
						// public LP<int> nonPawnMaterial; // [COLOR_NB]
						st.nonPawnMaterial.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								st.nonPawnMaterial.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 3:
					{
						// public VP<int> rule50;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.rule50.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: rule50: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					{
						// public VP<int> pliesFromNull;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.pliesFromNull.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: pliesFromNull: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 5:
					{
						// public VP<int> psq;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.psq.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: psq: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 6:
					{
						// public VP<ulong> key;
						int size = sizeof(ulong);
						if (count + size <= byteArray.Length) {
							st.key.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 7:
					{
						// public VP<ulong> checkersBB;
						int size = sizeof(ulong);
						if (count + size <= byteArray.Length) {
							st.checkersBB.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: checkersBB: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 8:
					{
						// public VP<int> capturedPiece;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.capturedPiece.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: capturedPiece: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 9:
					{
						// public LP<ulong> blockersForKing;// [COLOR_NB]
						st.blockersForKing.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								st.blockersForKing.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: blockersForKing: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 10:
					{
						// public LP<ulong> pinnersForKing; // [COLOR_NB]
						st.pinnersForKing.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								st.pinnersForKing.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: pinnersForKing: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 11:
					{
						// public LP<ulong> checkSquares;// [PIECE_TYPE_NB]
						st.checkSquares.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++) {
							if (count + size <= byteArray.Length) {
								st.checkSquares.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: checkSquares: " + count + "; " + byteArray.Length + "; " + i);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				// Debug.LogError ("count: " + count + "; " + index);
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

	}
}