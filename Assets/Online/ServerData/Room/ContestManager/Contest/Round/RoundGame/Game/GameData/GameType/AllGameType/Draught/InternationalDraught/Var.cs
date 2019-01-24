using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace InternationalDraught
{
	public class Var : Data
	{

		#region Property

		/** Variant_Type Variant = Normal;*/
		public VP<int> Variant;
		/** bool Book = true;*/
		public VP<bool> Book;
		/** int  Book_Ply = 4;*/
		public VP<int> Book_Ply;
		/** int  Book_Margin = 4;*/
		public VP<int> Book_Margin;
		/** bool Ponder = false;*/
		public VP<bool> Ponder;
		/** bool SMP = true;*/
		public VP<bool> SMP;
		/** int  SMP_Threads = 1;*/
		public VP<int> SMP_Threads;
		/** int  TT_Size = 1 << 22;*/
		public VP<int> TT_Size;
		/** bool BB = false;*/
		public VP<bool> BB;
		/** int  BB_Size = 5;*/
		public VP<int> BB_Size;
		/** int pickBestMove = 90;*/
		public VP<int> pickBestMove;

		#endregion

		#region Constructor

		public enum Property
		{
			/** Variant_Type Variant = Normal;*/
			Variant,
			/** bool Book = true;*/
			Book,
			/** int  Book_Ply = 4;*/
			Book_Ply,
			/** int  Book_Margin = 4;*/
			Book_Margin,
			/** bool Ponder = false;*/
			Ponder,
			/** bool SMP = true;*/
			SMP,
			/** int  SMP_Threads = 1;*/
			SMP_Threads,
			/** int  TT_Size = 1 << 22;*/
			TT_Size,
			/** bool BB = false;*/
			BB,
			/** int  BB_Size = 5;*/
			BB_Size,
			/** int pickBestMove = 90;*/
			pickBestMove
		}

		public Var() : base()
		{
			/** Variant_Type Variant = Normal;*/
			this.Variant = new VP<int> (this, (byte)Property.Variant, (int)Common.Variant_Type.Normal);
			/** bool Book = true;*/
			this.Book = new VP<bool> (this, (byte)Property.Book, true);
			/** int  Book_Ply = 4;*/
			this.Book_Ply = new VP<int> (this, (byte)Property.Book_Ply, 4);
			/** int  Book_Margin = 4;*/
			this.Book_Margin = new VP<int> (this, (byte)Property.Book_Margin, 4);
			/** bool Ponder = false;*/
			this.Ponder = new VP<bool> (this, (byte)Property.Ponder, false);
			/** bool SMP = true;*/
			this.SMP = new VP<bool> (this, (byte)Property.SMP, true);
			/** int  SMP_Threads = 1;*/
			this.SMP_Threads = new VP<int> (this, (byte)Property.SMP_Threads, 1);
			/** int  TT_Size = 1 << 22;*/
			this.TT_Size = new VP<int> (this, (byte)Property.TT_Size, 1 << 22);
			/** bool BB = false;*/
			this.BB = new VP<bool> (this, (byte)Property.BB, false);
			/** int  BB_Size = 5;*/
			this.BB_Size = new VP<int> (this, (byte)Property.BB_Size, 5);
			/** int pickBestMove = 90;*/
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 90);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Var var)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** Variant_Type Variant = Normal;*/
						writer.Write (var.Variant.v);
						/** bool Book = true;*/
						writer.Write (var.Book.v);
						/** int  Book_Ply = 4;*/
						writer.Write (var.Book_Ply.v);
						/** int  Book_Margin = 4;*/
						writer.Write (var.Book_Margin.v);
						/** bool Ponder = false;*/
						writer.Write (var.Ponder.v);
						/** bool SMP = true;*/
						writer.Write (var.SMP.v);
						/** int  SMP_Threads = 1;*/
						writer.Write (var.SMP_Threads.v);
						/** int  TT_Size = 1 << 22;*/
						writer.Write (var.TT_Size.v);
						/** bool BB = false;*/
						writer.Write (var.BB.v);
						/** int  BB_Size = 5;*/
						writer.Write (var.BB_Size.v);
						/** int pickBestMove = 90;*/
						writer.Write (var.pickBestMove.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Var var, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** Variant_Type Variant = Normal;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.Variant.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Variant: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** bool Book = true;*/
					{
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							var.Book.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Book: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** int  Book_Ply = 4;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.Book_Ply.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Book_Ply: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** int  Book_Margin = 4;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.Book_Margin.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Book_Margin: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** bool Ponder = false;*/
					{
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							var.Ponder.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: Ponder: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 5:
					/** bool SMP = true;*/
					{
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							var.SMP.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: SMP: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 6:
					/** int  SMP_Threads = 1;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.SMP_Threads.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: SMP_Threads: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 7:
					/** int  TT_Size = 1 << 22;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.TT_Size.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: TT_Size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 8:
					/** bool BB = false;*/
					{
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							var.BB.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: BB: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 9:
					/** int  BB_Size = 5;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.BB_Size.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: BB_Size: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 10:
					/** int pickBestMove = 90;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							var.pickBestMove.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: pickBestMove: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse var fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.Log ("parse var success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}