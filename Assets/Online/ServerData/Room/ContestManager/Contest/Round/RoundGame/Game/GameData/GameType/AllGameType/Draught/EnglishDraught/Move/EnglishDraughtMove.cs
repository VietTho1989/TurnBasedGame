using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace EnglishDraught
{
	public class EnglishDraughtMove : GameMove
	{

		/** uint64_t SrcDst*/
		public VP<System.UInt64> SrcDst;

		/** char cPath[12]*/
		public LP<byte> cPath;

		#region Constructor

		public enum Property
		{
			SrcDst,
			cPath
		}

		public EnglishDraughtMove() : base()
		{
			this.SrcDst = new VP<ulong> (this, (byte)Property.SrcDst, 0);
			this.cPath = new LP<byte> (this, (byte)Property.cPath);
		}

		#endregion

		public override Type getType ()
		{
			return Type.EnglishDraughtMove;
		}

		public override string print ()
		{
			return Common.printMove (this);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is EnglishDraught) {
				EnglishDraught englishDraught = gameType as EnglishDraught;
				// make animation
				EnglishDraughtMoveAnimation englishDraughtMoveAnimation = new EnglishDraughtMoveAnimation();
				{
					englishDraughtMoveAnimation.Sqs.vs.AddRange (englishDraught.Sqs.vs);
					// move
					{
						EnglishDraughtMove englishDraughtMove = DataUtils.cloneData (this) as EnglishDraughtMove;
						{
							englishDraughtMove.uid = englishDraughtMoveAnimation.move.makeId ();
						}
						englishDraughtMoveAnimation.move.v = englishDraughtMove;
					}
				}
				return englishDraughtMoveAnimation;
			} else {
				Debug.LogError ("why not englishDraught: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

		public List<int> getMoveSquareList()
		{
			List<int> ret = new List<int> ();
			{
				// from
				{
					int index = (int)(this.SrcDst.v & 63);
					if (index >= 0 && index < Common.BoardLocTo32.Length) {
						long from = Common.FlipX (Common.BoardLocTo32 [index]) + 1;
						int fromX = 0;
						int fromY = 0;
						Common.convertSquareToXY (from, out fromX, out fromY);
						ret.Add (fromX + 8 * fromY);
					} else {
						Debug.LogError ("index error: " + index + "; " + this);
					}
				}
				{
					int index = (int)((this.SrcDst.v >> 6) & 63);
					if (index >= 0 && index < Common.BoardLocTo32.Length) {
						long dest = Common.FlipX (Common.BoardLocTo32 [index]) + 1;
						int destX = 0;
						int destY = 0;
						Common.convertSquareToXY (dest, out destX, out destY);
						ret.Add (destX + 8 * destY);
					} else {
						Debug.LogError ("index error: " + index + "; " + this);
					}
				}
				// cPath
				{
					char cCap = ((this.SrcDst.v >> 12) != 0) ? 'x' : '-';
					if (cCap == 'x') {
						for (int i = 0; i < this.cPath.vs.Count; i++) {
							byte index = this.cPath.vs [i];
							if (index > 0) {
								if (index < Common.BoardLocTo32.Length) {
									long dest = Common.FlipX (Common.BoardLocTo32 [index]) + 1;
									int destX = 0;
									int destY = 0;
									Common.convertSquareToXY (dest, out destX, out destY);
									ret.Add (destX + 8 * destY);
								} else {
									Debug.LogError ("index error: " + index + "; " + this);
								}
							} else {
								break;
							}
						}
					}
				}
			}
			return ret;
		}

		public int from()
		{
			// get from
			long from = 0;
			{
				int locTo32 = (int)(this.SrcDst.v & 63);
				if (locTo32 >= 0 && locTo32 < Common.BoardLocTo32.Length) {
					from = Common.FlipX (Common.BoardLocTo32 [locTo32]) + 1;
				} else {
					Debug.LogError ("locTo32 error: " + locTo32);
				}
			}
			int fromX = 0;
			int fromY = 0;
			Common.convertSquareToXY (from, out fromX, out fromY);
			return fromX + 8 * fromY;
		}

		#region Convert

		public static byte[] convertToBytes(EnglishDraughtMove englishDraughtMove)
		{
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** uint64_t SrcDst*/
						writer.Write (englishDraughtMove.SrcDst.v);
						/** char cPath[12]*/
						for (int i = 0; i < 12; i++) {
							// get value
							byte value = 0;
							{
								if (i < englishDraughtMove.cPath.vs.Count) {
									value = englishDraughtMove.cPath.vs [i];
								} else {
									Debug.LogError ("error, index:  cPath: " + englishDraughtMove);
								}
							}
							// write
							writer.Write (value);
						}
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(EnglishDraughtMove englishDraughtMove, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** uint64_t SrcDst*/
					{
						// writer.Write (englishDraughtMove.SrcDst.v);
						int size = sizeof(System.UInt64);
						if (count + size <= byteArray.Length) {
							englishDraughtMove.SrcDst.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: SrcDst: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** char cPath[12]*/
					{
						englishDraughtMove.cPath.clear ();
						int size = 1;
						for (int i = 0; i < 12; i++) {
							if (count + size <= byteArray.Length) {
								englishDraughtMove.cPath.add (byteArray [count]);
								count += size;
							} else {
								Debug.LogError ("array not enough length: cPath: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
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

	}
}