using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class MoveQueue : Data
	{
		private static readonly bool log = false;

		/* XXX: On larger board this might not be enough. */
		public const int MQL = 512; 

		/** unsigned int moves;*/
		public VP<uint> moves;
	
		/** coord_t move[MQL];*/
		public LP<int> move;

		public int getMove(int index)
		{
			if (index >= 0 && index < this.move.vs.Count) {
				return this.move.vs [index];
			} else {
				// Debug.LogError ("error, getMove: index error: " + index);
				return -3;
			}
		}

		/* Each move can have an optional tag or set of tags.
         * The usage of these is user-dependent. */
		/** unsigned char tag[MQL];*/
		public LP<byte> tag;

		#region Constructor

		public enum Property
		{
			/** unsigned int moves;*/
			moves,
			/** coord_t move[MQL];*/
			move,
			/** unsigned char tag[MQL];*/
			tag
		}

		public MoveQueue() : base()
		{
			/** unsigned int moves;*/
			this.moves = new VP<uint> (this, (byte)Property.moves, 0);
			/** coord_t move[MQL];*/
			this.move = new LP<int> (this, (byte)Property.move);
			/** unsigned char tag[MQL];*/
			this.tag = new LP<byte> (this, (byte)Property.tag);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(MoveQueue moveQueue)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** unsigned int moves;*/
						writer.Write (moveQueue.moves.v);
						/** coord_t move[MQL];*/
						{
							for (int i = 0; i < MQL; i++) {
								// get value
								int value = 0;
								{
									if (i < moveQueue.move.vs.Count) {
										value = moveQueue.move.vs [i];
									} else {
										Debug.LogError ("error, index:  move: " + moveQueue);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** unsigned char tag[MQL];*/
						{
							for (int i = 0; i < MQL; i++) {
								// get value
								byte value = 0;
								{
									if (i < moveQueue.tag.vs.Count) {
										value = moveQueue.tag.vs [i];
									} else {
										Debug.LogError ("error, index:  tag: " + moveQueue);
									}
								}
								// write
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

		public static int parse(MoveQueue moveQueue, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** unsigned int moves;*/
					{
						int size = sizeof(uint);
						if (count + size <= byteArray.Length) {
							moveQueue.moves.v = BitConverter.ToUInt32 (byteArray, count);
							count += size;
						} else {
							if(log)
								Debug.LogError ("error, array not enough length: moves: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** coord_t move[MQL];*/
					{
						moveQueue.move.clear ();
						int size = sizeof(int);
						for (int i = 0; i < MQL; i++) {
							if (count + size <= byteArray.Length) {
								moveQueue.move.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: move: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					/** unsigned char tag[MQL];*/
					{
						moveQueue.tag.clear ();
						int size = sizeof(byte);
						for (int i = 0; i < MQL; i++) {
							if (count + size < byteArray.Length) {
								moveQueue.tag.add (byteArray[count]);
								count += size;
							} else {
								if (log)
									Debug.LogError ("array not enough length: move: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse moveQueue fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				if(log)
					Debug.Log ("parse moveQueue success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}