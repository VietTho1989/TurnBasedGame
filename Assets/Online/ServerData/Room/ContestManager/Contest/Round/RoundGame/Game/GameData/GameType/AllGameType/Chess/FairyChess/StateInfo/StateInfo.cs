using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;
using System.Runtime.Serialization;

namespace FairyChess
{
	public class StateInfo : Data
	{

		/** Key    pawnKey*/
		public VP<ulong> pawnKey;
		/** Key    materialKey*/
		public VP<ulong> materialKey;
		/** Value  nonPawnMaterial[COLOR_NB];*/
		public LP<int> nonPawnMaterial;
		/** int    castlingRights;*/
		public VP<int> castlingRights;
		/** int    rule50;*/
		public VP<int> rule50;
		/** int    pliesFromNull;*/
		public VP<int> pliesFromNull;

		/** CheckCount checksGiven[COLOR_NB];*/
		public LP<int> checksGiven;

		/** Score  psq;*/
		public VP<int> psq;
		public VP<int> epSquare;

		// Not copied when making a move (will be recomputed anyhow)
		/** Key        key;*/
		public VP<ulong> key;
		/** Bitboard   checkersBB;*/
		public VP<ulong> checkersBB;
		/** Piece      capturedPiece;*/
		public VP<int> capturedPiece;
		/** Piece      unpromotedCapturedPiece;*/
		public VP<int> unpromotedCapturedPiece;

		/** Bitboard   blockersForKing[COLOR_NB];*/
		public LP<ulong> blockersForKing;
		/**  Bitboard   pinners[COLOR_NB];*/
		public LP<ulong> pinners;
		/** Bitboard   checkSquares[PIECE_TYPE_NB];*/
		public LP<ulong> checkSquares;

		/** bool       capturedpromoted;*/
		public VP<bool> capturedpromoted;

		#region Constructor

		public enum Property
		{
			pawnKey,
			materialKey,
			nonPawnMaterial,
			castlingRights,
			rule50,
			pliesFromNull,
			checksGiven,
			psq,
			epSquare,
			key,
			checkersBB,
			capturedPiece,
			unpromotedCapturedPiece,
			blockersForKing,
			pinners,
			checkSquares,
			capturedpromoted
		}

		public StateInfo() : base()
		{
			this.pawnKey = new VP<ulong> (this, (byte)Property.pawnKey, 0);
			this.materialKey = new VP<ulong> (this, (byte)Property.materialKey, 0);
			this.nonPawnMaterial = new LP<int> (this, (byte)Property.nonPawnMaterial);
			this.castlingRights = new VP<int> (this, (byte)Property.castlingRights, 0);
			this.rule50 = new VP<int> (this, (byte)Property.rule50, 0);
			this.pliesFromNull = new VP<int> (this, (byte)Property.pliesFromNull, 0);
			this.checksGiven = new LP<int> (this, (byte)Property.checksGiven);
			this.psq = new VP<int> (this, (byte)Property.psq, 0);
			this.epSquare = new VP<int> (this, (byte)Property.epSquare, 0);
			this.key = new VP<ulong> (this, (byte)Property.key, 0);
			this.checkersBB = new VP<ulong> (this, (byte)Property.checkersBB, 0);
			this.capturedPiece = new VP<int> (this, (byte)Property.capturedPiece, 0);
			this.unpromotedCapturedPiece = new VP<int> (this, (byte)Property.unpromotedCapturedPiece, 0);
			this.blockersForKing = new LP<ulong> (this, (byte)Property.blockersForKing);
			this.pinners = new LP<ulong> (this, (byte)Property.pinners);
			this.checkSquares = new LP<ulong> (this, (byte)Property.checkSquares);
			this.capturedpromoted = new VP<bool> (this, (byte)Property.capturedpromoted, false);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(StateInfo st)
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

					// public VP<int> castlingRights;
					writer.Write(st.castlingRights.v);
					// public VP<int> rule50;
					writer.Write(st.rule50.v);
					// public VP<int> pliesFromNull;
					writer.Write(st.pliesFromNull.v);
					// CheckCount checksGiven[COLOR_NB]
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < st.checksGiven.vs.Count) {
								value = st.checksGiven.vs [i];
							} else {
								Debug.LogError ("index error: " + st);
							}
						}
						writer.Write (value);
					}
					// public VP<int> psq;
					writer.Write(st.psq.v);
					// public VP<int> epSquare;
					writer.Write(st.epSquare.v);

					// Not copied when making a move (will be recomputed anyhow)
					// public VP<ulong> key;
					writer.Write(st.key.v);
					// public VP<ulong> checkersBB;
					writer.Write(st.checkersBB.v);
					// public VP<int> capturedPiece;
					writer.Write(st.capturedPiece.v);
					// Piece      unpromotedCapturedPiece;
					writer.Write(st.unpromotedCapturedPiece.v);
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
					// public LP<ulong> pinners; // [COLOR_NB]
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < st.pinners.vs.Count) {
								value = st.pinners.vs [i];
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
					// bool       capturedpromoted;
					writer.Write(st.capturedpromoted.v);
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		#endregion

		public static int parse(StateInfo st, byte[] byteArray, int start)
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
						// public VP<int> castlingRights;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.castlingRights.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: castlingRights: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
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
				case 5:
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
				case 6:
					{
						// CheckCount checksGiven[COLOR_NB];
						st.checksGiven.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								st.checksGiven.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: checksGiven: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 7:
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
				case 8:
					{
						// public VP<int> epSquare;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.epSquare.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: epSquare: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 9:
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
				case 10:
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
				case 11:
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
				case 12:
					{
						// Piece      unpromotedCapturedPiece;
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							st.unpromotedCapturedPiece.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: unpromotedCapturedPiece: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 13:
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
				case 14:
					{
						// public LP<ulong> pinners; // [COLOR_NB]
						st.pinners.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								st.pinners.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: pinnersForKing: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 15:
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
				case 16:
					{
						// bool       capturedpromoted;
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							st.capturedpromoted.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: capturedpromoted: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
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