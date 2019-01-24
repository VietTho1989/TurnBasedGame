using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace Weiqi
{
	public class WeiqiMove : GameMove
	{

		/** coord_t coord;*/
		public VP<int> coord;
		/** enum stone color;*/
		public VP<int> color;

		/** Tu them vao, ko co o ban goc*/
		public VP<int> boardSize;

		#region Constructor

		public enum Property
		{
			coord,
			color,
			boardSize
		}

		public WeiqiMove() : base()
		{
			this.coord = new VP<int> (this, (byte)Property.coord, -3);
			this.color = new VP<int> (this, (byte)Property.color, 0);
			this.boardSize = new VP<int> (this, (byte)Property.boardSize, 19);
		}

		#endregion

		public override Type getType ()
		{
			return Type.WeiqiMove;
		}

		public override string print ()
		{
			return Common.printMove (this);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Weiqi) {
				Weiqi weiqi = gameType as Weiqi;
				// Make animation
				WeiqiMoveAnimation weiqiMoveAnimation = new WeiqiMoveAnimation();
				{
					weiqiMoveAnimation.b.vs.AddRange (weiqi.b.v.b.vs);
					weiqiMoveAnimation.coord.v = this.coord.v;
					weiqiMoveAnimation.color.v = this.color.v;
					// captureCoords: Cai nay de sau
				}
				return weiqiMoveAnimation;
			} else {
				Debug.LogError ("error, why not weiqi: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			if (gameType is Weiqi) {
				Weiqi weiqi = gameType as Weiqi;
				// get Inform
				this.boardSize.v = weiqi.b.v.size.v;
			} else {
				Debug.LogError ("why gameType not Weiqi: " + gameType + "; " + this);
			}
		}

		#region Convert

		public static byte[] convertToBytes(WeiqiMove move)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** coord_t coord;*/
						writer.Write (move.coord.v);
						/** enum stone color;*/
						writer.Write (move.color.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(WeiqiMove move, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** coord_t coord;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							move.coord.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: coord: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** enum stone color;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							move.color.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: color: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse move fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.Log ("parse move success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}