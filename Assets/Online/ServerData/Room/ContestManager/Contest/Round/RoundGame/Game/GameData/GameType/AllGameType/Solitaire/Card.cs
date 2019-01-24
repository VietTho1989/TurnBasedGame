using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class Card : Data
	{

		public enum Cards 
		{
			EMPTY = 0,
			ACE,
			TWO,
			THREE,
			FOUR,
			FIVE,
			SIX,
			SEVEN,
			EIGHT,
			NINE,
			TEN,
			JACK,
			QUEEN,
			KING
		}

		public enum Suits
		{
			CLUBS = 0,
			DIAMONDS,
			SPADES,
			HEARTS,
			NONE = 255
		}

		/** unsigned char Suit*/
		public VP<byte> Suit;

		/** unsigned char Rank*/
		public VP<byte> Rank;

		/** unsigned char IsOdd*/
		public VP<byte> IsOdd;

		/** unsigned char IsRed*/
		public VP<byte> IsRed;

		/** unsigned char Foundation*/
		public VP<byte> Foundation;

		/** unsigned char Value*/
		public VP<byte> Value;

		#region Constructor

		public enum Property
		{
			Suit,
			Rank,
			IsOdd,
			IsRed,
			Foundation,
			Value
		}

		public Card() : base()
		{
			this.Suit = new VP<byte> (this, (byte)Property.Suit, 0);
			this.Rank = new VP<byte> (this, (byte)Property.Rank, 0);
			this.IsOdd = new VP<byte> (this, (byte)Property.IsOdd, 0);
			this.IsRed = new VP<byte> (this, (byte)Property.IsRed, 0);
			this.Foundation = new VP<byte> (this, (byte)Property.Foundation, 0);
			this.Value = new VP<byte> (this, (byte)Property.Value, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Card card)
		{
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** unsigned char Suit*/
						writer.Write (card.Suit.v);
						/** unsigned char Rank*/
						writer.Write (card.Rank.v);
						/** unsigned char IsOdd*/
						writer.Write (card.IsOdd.v);
						/** unsigned char IsRed*/
						writer.Write (card.IsRed.v);
						/** unsigned char Foundation*/
						writer.Write (card.Foundation.v);
						/** unsigned char Value*/
						writer.Write (card.Value.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Card card, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** unsigned char Suit*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							card.Suit.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Suit: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** unsigned char Rank*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							card.Rank.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Rank: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** unsigned char IsOdd*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							card.IsOdd.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: IsOdd: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** unsigned char IsRed*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							card.IsRed.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: IsRed: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** unsigned char Foundation*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							card.Foundation.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Foundation: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 5:
					/** unsigned char Value*/
					{
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							card.Value.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Value: " + count + "; " + byteArray.Length);
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