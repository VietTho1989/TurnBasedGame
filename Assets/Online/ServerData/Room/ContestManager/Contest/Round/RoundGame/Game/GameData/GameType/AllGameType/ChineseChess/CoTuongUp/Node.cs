using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
	public class Node : Data
	{
		
		public VP<int> ply;

		#region pieces

		public LP<byte> pieces;

		public byte getPieceByCoord(byte coord)
		{
			if (coord >= 0 && coord < this.pieces.vs.Count) {
				return this.pieces.vs [coord];
			} else {
				Debug.LogError ("coord error: " + coord + "; " + this);
				return Common.x;
			}
		}

		public byte getPieceByCoord(short coord)
		{
			if (coord >= 0 && coord < this.pieces.vs.Count) {
				return this.pieces.vs [coord];
			} else {
				Debug.LogError ("coord error: " + coord + "; " + this);
				return Common.x;
			}
		}

		public void setPieceByCoord(byte coord, byte piece)
		{
			if (coord >= 0 && coord < this.pieces.vs.Count) {
				this.pieces.set (coord, piece);
			} else {
				Debug.LogError ("coord error: " + coord + "; " + this);
			}
		}

		#endregion

		public LP<byte> captures;

		#region Property

		public enum Property
		{
			ply,
			pieces,
			captures
		}

		public Node() : base()
		{
			this.ply = new VP<int> (this, (byte)Property.ply, 0);
			this.pieces = new LP<byte> (this, (byte)Property.pieces);
			this.captures = new LP<byte> (this, (byte)Property.captures);
		}

		#endregion

	}
}