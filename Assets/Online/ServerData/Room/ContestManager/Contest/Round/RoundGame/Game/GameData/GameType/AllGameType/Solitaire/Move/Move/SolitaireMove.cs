using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireMove : GameMove
	{

		/** unsigned char From*/
		public VP<byte> From;

		/** unsigned char To*/
		public VP<byte> To;

		/** unsigned char Count*/
		public VP<byte> Count;

		/** unsigned char Extra*/
		public VP<byte> Extra;

		#region Constructor

		public enum Property
		{
			From,
			To,
			Count,
			Extra
		}

		public SolitaireMove() : base()
		{
			this.From = new VP<byte>(this, (byte)Property.From, 0);
			this.To = new VP<byte> (this, (byte)Property.To, 0);
			this.Count = new VP<byte> (this, (byte)Property.Count, 0);
			this.Extra = new VP<byte> (this, (byte)Property.Extra, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.SolitaireMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Solitaire) {
				Solitaire solitaire = gameType as Solitaire;
				// make animation
				SolitaireMoveAnimation solitaireMoveAnimation = new SolitaireMoveAnimation ();
				{
					solitaireMoveAnimation.From.v = this.From.v;
					solitaireMoveAnimation.To.v = this.To.v;
					solitaireMoveAnimation.Count.v = this.Count.v;
					solitaireMoveAnimation.Extra.v = this.Extra.v;

					// piles
					foreach (Pile pile in solitaire.piles.vs) {
						Pile animationPile = DataUtils.cloneData (pile) as Pile;
						{
							animationPile.uid = solitaireMoveAnimation.piles.makeId ();
						}
						solitaireMoveAnimation.piles.add (animationPile);
					}
					solitaireMoveAnimation.drawCount.v = solitaire.drawCount.v;
				}
				return solitaireMoveAnimation;
			} else {
				Debug.LogError ("why gameType not solitaire: "+gameType+"; "+this);
				return null;
			}
		}

		public override string print()
		{
			return "Solitaire Move: " + (Pile.Piles)this.From.v + ", " + (Pile.Piles)this.To.v + ", " + this.Count.v + ", " + this.Extra.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#region Convert

		public static byte[] convertToBytes(SolitaireMove solitaireMove)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** unsigned char From*/
						writer.Write (solitaireMove.From.v);
						/** unsigned char To*/
						writer.Write (solitaireMove.To.v);
						/** unsigned char Count*/
						writer.Write (solitaireMove.Count.v);
						/** unsigned char Extra*/
						writer.Write (solitaireMove.Extra.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(SolitaireMove solitaireMove, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** unsigned char From*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							solitaireMove.From.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: From: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** unsigned char To*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							solitaireMove.To.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: To: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** unsigned char Count*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							solitaireMove.Count.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Count: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** unsigned char Extra*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							solitaireMove.Extra.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Extra: " + count + "; " + byteArray.Length);
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