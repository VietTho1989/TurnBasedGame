using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtMove : GameMove
	{

		/** uint16_t m[12];*/
		public LP<System.UInt16> m;

		/** char path[11];*/
		public LP<byte> path;

		/** unsigned char l;*/
		public VP<byte> l;

		#region Constructor

		public enum Property
		{
			m,
			path,
			l
		}

		public RussianDraughtMove() : base()
		{
			this.m = new LP<ushort> (this, (byte)Property.m);
			this.path = new LP<byte> (this, (byte)Property.path);
			this.l = new VP<byte> (this, (byte)Property.l, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.RussianDraughtMove;
		}

		public override string print ()
		{
			return Core.unityGetStrMove (this, Core.CanCorrect);
		}

		#region Convert

		public static byte[] convertToBytes(RussianDraughtMove russianDraughtMove)
		{
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** uint16_t m[12];*/
						for (int i = 0; i < 12; i++) {
							// get value
							System.UInt16 value = 0;
							{
								if (i < russianDraughtMove.m.vs.Count) {
									value = russianDraughtMove.m.vs [i];
								} else {
									Debug.LogError ("error, index:  m: " + russianDraughtMove);
								}
							}
							// write
							writer.Write (value);
						}
						/** char path[11];*/
						for (int i = 0; i < 11; i++) {
							// get value
							byte value = 0;
							{
								if (i < russianDraughtMove.path.vs.Count) {
									value = russianDraughtMove.path.vs [i];
								} else {
									Debug.LogError ("error, index:  path: " + russianDraughtMove);
								}
							}
							// write
							writer.Write (value);
						}
						/** unsigned char l;*/
						writer.Write (russianDraughtMove.l.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(RussianDraughtMove russianDraughtMove, byte[] byteArray, int start)
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
						/** uint16_t m[12];*/
						russianDraughtMove.m.clear ();
						int size = sizeof(System.UInt16);
						for (int i = 0; i < 12; i++) {
							if (count + size <= byteArray.Length) {
								russianDraughtMove.m.add (BitConverter.ToUInt16 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: m: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 1:
					{
						/** char path[11];*/
						russianDraughtMove.path.clear ();
						int size = 1;
						for (int i = 0; i < 11; i++) {
							if (count + size <= byteArray.Length) {
								russianDraughtMove.path.add (byteArray [count]);
								count += size;
							} else {
								Debug.LogError ("array not enough length: path: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					{
						/** unsigned char l;*/
						int size = 1;
						if (count + size <= byteArray.Length) {
							russianDraughtMove.l.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: l: " + count + "; " + byteArray.Length);
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
				// Debug.Log ("parse node success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is RussianDraught) {
				RussianDraught russianDraught = gameType as RussianDraught;
				// make animation
				RussianDraughtMoveAnimation russianDraughtMoveAnimation = new RussianDraughtMoveAnimation();
				{
					russianDraughtMoveAnimation.Board.vs.AddRange (russianDraught.Board.vs);
					// move
					{
						RussianDraughtMove russianDraughtMove = DataUtils.cloneData (this) as RussianDraughtMove;
						{
							russianDraughtMove.uid = russianDraughtMoveAnimation.move.makeId ();
						}
						russianDraughtMoveAnimation.move.v = russianDraughtMove;
					}
				}
				return russianDraughtMoveAnimation;
			} else {
				Debug.LogError ("why not russianDraught: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

		#region Utils

		public static readonly int[] Square64 = new int[]{
			0,  0,  0,  0,  0,
			7,  5,  3,  1,  0,
			14, 12, 10,  8,
			23, 21, 19, 17,  0,
			30, 28, 26, 24,
			39, 37, 35, 33,  0,
			46, 44, 42, 40,
			55, 53, 51, 49,  0,
			62, 60, 58, 56
		};

		public static int convertMtoSq(int sq)
		{
			sq = sq & 63;
			if (sq >= 0 && sq < Square64.Length) {
				sq = Square64 [sq];
				sq = (7 - sq % 8) + 8 * (sq / 8);
				return sq;
			}
			return -1;
		}

		public List<int> getMoveSquareList()
		{
			List<int> ret = new List<int> ();
			{
				if (this.l.v >= 2 && this.l.v < this.m.vs.Count && this.m.vs.Count == 12) {
					// from
					{
						int sq = convertMtoSq (this.m.vs [0]);
						if (sq >= 0) {
							ret.Add (sq);
						} else {
							Debug.LogError ("why sq so small: " + sq + "; " + this);
						}
					}
					// Jump
					{
						for (int i = 2; i < this.l.v; i++) {
							int sq = convertMtoSq (this.m.vs [i]);
							if (sq >= 0) {
								int squareX = sq % 8;
								int squareY = sq / 8;
								if (ret.Count > 0) {
									// lastSquare
									int lastSquare = ret [ret.Count - 1];
									int lastSquareX = lastSquare % 8;
									int lastSquareY = lastSquare / 8;
									// make correct square
									int correctSquare = (squareX + 1 * (squareX > lastSquareX ? 1 : -1)) 
										+ 8 * (squareY + 1 * (squareY > lastSquareY ? 1 : -1));
									ret.Add (correctSquare);
								} else {
									Debug.LogError ("why don't have last square: " + this);
								}
							} else {
								Debug.LogError ("why sq so small: " + sq + "; " + this);
							}
						}
					}
					// Dest
					{
						int sq = convertMtoSq (this.m.vs [1]);
						if (sq >= 0) {
							ret.Add (sq);
						} else {
							Debug.LogError ("why sq so small: " + sq + "; " + this);
						}
					}
				} else {
					Debug.LogError ("why l so low: " + this.l.v + "; " + this);
				}
			}
			return ret;
		}

		public int from()
		{
			if (this.l.v >= 2 && this.l.v < this.m.vs.Count && this.m.vs.Count == 12) {
				return convertMtoSq (this.m.vs [0]);
			} else {
				Debug.LogError ("why l so low: " + this.l.v + "; " + this);
				return -1;
			}
		}

		#endregion

	}
}