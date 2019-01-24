using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class Pile : Data
	{

		public enum Piles {
			WASTE = 0,
			TABLEAU1,
			TABLEAU2,
			TABLEAU3,
			TABLEAU4,
			TABLEAU5,
			TABLEAU6,
			TABLEAU7,
			STOCK,
			FOUNDATION1C,
			FOUNDATION2D,
			FOUNDATION3S,
			FOUNDATION4H
		};

		/** int32_t size*/
		public VP<int> size;

		/** int32_t downSize*/
		public VP<int> downSize;
		/** Card down[24]*/
		public LP<Card> down;

		/** int32_t upSize*/
		public VP<int> upSize;
		/** Card up[24]*/
		public LP<Card> up;

		public Card Low() {
			int index = this.upSize.v - 1;
			if (index >= 0 && index < this.up.vs.Count) {
				return this.up.vs [index];
			} else {
				return null;
			}
		}

		#region Constructor

		public enum Property
		{
			size,
			downSize,
			down,
			upSize,
			up
		}

		public Pile() : base()
		{
			this.size = new VP<int> (this, (byte)Property.size, 0);

			this.downSize = new VP<int> (this, (byte)Property.downSize, 0);
			this.down = new LP<Card> (this, (byte)Property.down);

			this.upSize = new VP<int> (this, (byte)Property.upSize, 0);
			this.up = new LP<Card> (this, (byte)Property.up);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Pile pile)
		{
			// normal
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write
					{
						/** int32_t size*/
						writer.Write (pile.size.v);

						/** int32_t downSize*/
						writer.Write (pile.downSize.v);
						/** Card down[24]*/
						if (pile.downSize.v >= 0 && pile.downSize.v <= 24) {
							for (int i = 0; i < pile.downSize.v; i++) {
								// get value
								Card card = null;
								{
									if (i < pile.down.vs.Count) {
										card = pile.down.vs [i];
									} else {
										Debug.LogError ("index error: " + pile);
										card = new Card ();
									}
								}
								writer.Write (Card.convertToBytes (card));
							}
						} else {
							Debug.LogError ("pile downSize error: " + pile.downSize.v);
						}

						/** int32_t upSize*/
						writer.Write (pile.upSize.v);
						/** Card up[24]*/
						if (pile.upSize.v >= 0 && pile.upSize.v <= 24) {
							for (int i = 0; i < pile.upSize.v; i++) {
								// get value
								Card card = null;
								{
									if (i < pile.up.vs.Count) {
										card = pile.up.vs [i];
									} else {
										Debug.LogError ("index error: " + pile);
										card = new Card ();
									}
								}
								writer.Write (Card.convertToBytes (card));
							}
						} else {
							Debug.LogError ("pile upSize error: " + pile.upSize.v);
						}
					}
					// to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Pile pile, byte[] byteArray, int start)
		{
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** int32_t size*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							pile.size.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;

				case 1:
					/** int32_t downSize*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							pile.downSize.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: downSize: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** Card down[24]*/
					{
						pile.down.clear ();
						// get list of Card
						List<Card> cards = new List<Card> ();
						{
							if (pile.downSize.v >= 0 && pile.downSize.v <= 24) {
								for (int i = 0; i < pile.downSize.v; i++) {
									Card card = new Card ();
									int cardByteLength = Card.parse (card, byteArray, count);
									if (cardByteLength > 0) {
										cards.Add (card);
										count += cardByteLength;
									} else {
										Debug.LogError ("cannot parse");
										break;
									}
								}
							} else {
								Debug.LogError ("pile downSize error: " + pile.downSize.v);
							}
						}
						// add
						foreach (Card card in cards) {
							card.uid = pile.down.makeId ();
							pile.down.add (card);
						}
					}
					break;

				case 3:
					/** int32_t upSize*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							pile.upSize.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: upSize: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** Card up[24]*/
					{
						pile.up.clear ();
						// get list of Card
						List<Card> cards = new List<Card> ();
						{
							if (pile.upSize.v >= 0 && pile.upSize.v <= 24) {
								for (int i = 0; i < pile.upSize.v; i++) {
									Card card = new Card ();
									int cardByteLength = Card.parse (card, byteArray, count);
									if (cardByteLength > 0) {
										cards.Add (card);
										count += cardByteLength;
									} else {
										Debug.LogError ("cannot parse");
										break;
									}
								}
							} else {
								Debug.LogError ("pile upSize error: " + pile.upSize.v);
							}
						}
						// add
						foreach (Card card in cards) {
							card.uid = pile.up.makeId ();
							pile.up.add (card);
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
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
				// Debug.LogError ("parse success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}
}