using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace InternationalDraught
{
	public class Pos : Data
	{

		/** Bit p_piece[Piece_Size];*/
		public LP<System.UInt64> p_piece;
		/** Bit p_side[Side_Size];*/
		public LP<System.UInt64> p_side;
		/** Bit p_all;*/
		public VP<System.UInt64> p_all;
		/** Side p_turn;*/
		public VP<int> p_turn;

		#region Constructor

		public enum Property
		{
			p_piece,
			p_side,
			p_all,
			p_turn
		}

		public Pos() : base()
		{
			this.p_piece = new LP<ulong> (this, (byte)Property.p_piece);
			this.p_side = new LP<ulong> (this, (byte)Property.p_side);
			this.p_all = new VP<ulong> (this, (byte)Property.p_all, 0);
			this.p_turn = new VP<int> (this, (byte)Property.p_turn, 0);
		}

		#endregion

		const System.UInt64 Squares = 0x7DF3EF9F7CFBE7DF;

		static int bit(System.UInt64 b, int sq) { 
			return (int)((b >> sq) & 1); 
		}

		private System.UInt64 empty () { 
			return Squares ^ this.p_all.v; 
		}

		public System.UInt64 piece(int pc)
		{ 
			if (pc >= 0 && pc < this.p_piece.vs.Count) {
				return this.p_piece.vs [pc];
			} else {
				Debug.LogError ("pc error: " + pc);
				return 0;
			}
		}

		private System.UInt64 side(int sd)  
		{
			if (sd >= 0 && sd < this.p_side.vs.Count) {
				return this.p_side.vs [sd]; 
			} else {
				Debug.LogError ("sd error: " + sd);
				return 0;
			}
		}

		public int piece_side(int sq)
		{
			int ps = (bit(empty(), sq) << 2)
				| (bit(piece((int)Common.Piece.King), sq) << 1)
				| (bit(side((int)Common.Side.Black), sq) << 0);

			return ps; // can be Empty
		}

		public void setPieceSide(int sq, Common.Piece_Side pieceSide)
		{
			Debug.LogError ("setPieceSide: " + sq + ", " + pieceSide);
			// find
			ulong wm = side((int)Common.Side.White) & piece((int)Common.Piece.Man);
			ulong bm = side((int)Common.Side.Black) & piece((int)Common.Piece.Man);
			ulong wk = side((int)Common.Side.White) & piece((int)Common.Piece.King);
			ulong bk = side((int)Common.Side.Black) & piece((int)Common.Piece.King);
			{
				switch (pieceSide) {
				case Common.Piece_Side.White_Man:
					{
						wm |= 1UL << sq;
						bm &= ~(1UL << sq);
						wk &= ~(1UL << sq);
						bk &= ~(1UL << sq);
					}
					break;
				case Common.Piece_Side.Black_Man:
					{
						wm &= ~(1UL << sq);
						bm |= 1UL << sq;
						wk &= ~(1UL << sq);
						bk &= ~(1UL << sq);
					}
					break;
				case Common.Piece_Side.White_King:
					{
						wm &= ~(1UL << sq);
						bm &= ~(1UL << sq);
						wk |= (1UL << sq);
						bk &= ~(1UL << sq);
					}
					break;
				case Common.Piece_Side.Black_King:
					{
						wm &= ~(1UL << sq);
						bm &= ~(1UL << sq);
						wk &= ~(1UL << sq);
						bk |= 1UL << sq;
					}
					break;
				case Common.Piece_Side.Empty:
					{
						wm &= ~(1UL << sq);
						bm &= ~(1UL << sq);
						wk &= ~(1UL << sq);
						bk &= ~(1UL << sq);
					}
					break;
				default:
					Debug.LogError ("unknown pieceSide: " + pieceSide);
					break;
				}
			}
			// set
			{
				this.p_piece.set ((int)Common.Piece.Man, wm | bm);
				this.p_piece.set ((int)Common.Piece.King, wk | bk);
				this.p_side.set ((int)Common.Side.White, wm | wk);
				this.p_side.set ((int)Common.Side.Black, bm | bk);
				this.p_all.v = wm | bm | wk | bk;
			}
		}

		#region Convert

		public static byte[] convertToBytes(Pos pos)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/**Bit p_piece[Piece_Size];*/
						{
							for (int i = 0; i < Common.Piece_Size; i++) {
								// get value
								System.UInt64 value = 0;
								{
									if (i < pos.p_piece.vs.Count) {
										value = pos.p_piece.vs [i];
									} else {
										Debug.LogError ("error, index:  p_piece: " + pos);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/**Bit p_side[Side_Size];*/
						{
							for (int i = 0; i < Common.Side_Size; i++) {
								// get value
								System.UInt64 value = 0;
								{
									if (i < pos.p_side.vs.Count) {
										value = pos.p_side.vs [i];
									} else {
										Debug.LogError ("error, index:  p_side: " + pos);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/**Bit p_all;*/
						writer.Write (pos.p_all.v);
						/**Side p_turn;*/
						writer.Write (pos.p_turn.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Pos pos, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/**Bit p_piece[Piece_Size];*/
					{
						pos.p_piece.clear ();
						int size = sizeof(System.UInt64);
						for (int i = 0; i < Common.Piece_Size; i++) {
							if (count + size <= byteArray.Length) {
								pos.p_piece.add (BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: p_piece: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.Log ("parse p_piece: " + (count - start));
					}
					break;
				case 1:
					/**Bit p_side[Side_Size];*/
					{
						pos.p_side.clear ();
						int size = sizeof(System.UInt64);
						for (int i = 0; i < Common.Side_Size; i++) {
							if (count + size <= byteArray.Length) {
								pos.p_side.add (BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: p_side: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
						// Debug.Log ("parse p_side: " + (count - start));
					}
					break;
				case 2:
					/**Bit p_all;*/
					{
						int size = sizeof(System.UInt64);
						if (count + size <= byteArray.Length) {
							pos.p_all.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: p_all: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.Log ("parse p_all: " + (count - start));
					}
					break;
				case 3:
					/**Side p_turn;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							pos.p_turn.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: p_turn: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
						// Debug.Log ("parse p_turn: " + (count - start));
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
				Debug.LogError ("parse pos fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.Log ("parse pos success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}
}