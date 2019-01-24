using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NineMenMorrisMove : GameMove
	{

		public VP<int> moved;

		public VP<int> moved_to;

		public VP<Common.NMMAction> action;

		public VP<bool> mill;

		public VP<int> removed;

		#region Constructor

		public enum Property
		{
			moved,
			moved_to,
			action,
			mill,
			removed
		}

		public NineMenMorrisMove() : base()
		{
			this.moved = new VP<int> (this, (byte)Property.moved, -1);
			this.moved_to = new VP<int> (this, (byte)Property.moved_to, -1);
			this.action = new VP<Common.NMMAction> (this, (byte)Property.action, Common.NMMAction.Place);
			this.mill = new VP<bool> (this, (byte)Property.mill, false);
			this.removed = new VP<int> (this, (byte)Property.removed, -1);
		}

		#endregion

		public static int GetSize()
		{
			int ret = 0;
			{
				// public VP<int> moved
				ret += sizeof(int);
				// public VP<int> moved_to
				ret += sizeof(int);
				// public VP<Common.NMMAction> action
				ret += sizeof(int);
				// public VP<bool> mill
				ret += sizeof(bool);
				// public VP<int> removed
				ret += sizeof(int);
			}
			return ret;
		}

		#region implement base

		public override Type getType()
		{
			return Type.NineMenMorrisMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is NineMenMorris) {
				NineMenMorris nineMenMorris = gameType as NineMenMorris;
				// make animation
				NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = new NineMenMorrisMoveAnimation();
				{
					nineMenMorrisMoveAnimation.moved.v = this.moved.v;
					nineMenMorrisMoveAnimation.moved_to.v = this.moved_to.v;
					nineMenMorrisMoveAnimation.action.v = this.action.v;
					nineMenMorrisMoveAnimation.mill.v = this.mill.v;
					nineMenMorrisMoveAnimation.removed.v = this.removed.v;
					nineMenMorrisMoveAnimation.board.add (nineMenMorris.board.vs);
					nineMenMorrisMoveAnimation.turn.v = nineMenMorris.turn.v;
				}
				return nineMenMorrisMoveAnimation;
			} else {
				Debug.LogError ("why not nineMenMorris");
				return null;
			}
		}

		public override string print()
		{
			return string.Format ("NineMenMorris Move: {0}, {1}, {2}, {3}, {4}", this.moved.v, this.moved_to.v, this.action.v, this.mill.v, this.removed.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(NineMenMorrisMove nineMenMorrisMove)
		{
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** public VP<int> moved*/
						writer.Write (nineMenMorrisMove.moved.v);
						/** public VP<int> moved_to*/
						writer.Write (nineMenMorrisMove.moved_to.v);
						/** public VP<Common.NMMAction> action*/
						writer.Write ((int)nineMenMorrisMove.action.v);
						/** public VP<bool> mill*/
						writer.Write (nineMenMorrisMove.mill.v);
						/** public VP<int> removed;*/
						writer.Write (nineMenMorrisMove.removed.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(NineMenMorrisMove nineMenMorrisMove, byte[] byteArray, int start)
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
						/** public VP<int> moved*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							nineMenMorrisMove.moved.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: moved: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						/** public VP<int> moved_to*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							nineMenMorrisMove.moved_to.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: moved_to: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					{
						/** public VP<Common.NMMAction> action*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							nineMenMorrisMove.action.v = (Common.NMMAction)BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: moved: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					{
						/** public VP<bool> mill*/
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							nineMenMorrisMove.mill.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: moved: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					{
						/** public VP<int> removed;*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							nineMenMorrisMove.removed.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: removed: " + count + "; " + byteArray.Length);
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

	}
}