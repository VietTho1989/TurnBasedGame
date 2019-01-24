using UnityEngine;
using System;
using System.Collections;
using System.IO;

namespace InternationalDraught
{
	public class Node : Data
	{

		/** Pos p_pos;*/
		public VP<Pos> p_pos;
		/** int p_ply;*/
		public VP<int> p_ply;

		#region Constructor

		public enum Property
		{
			p_pos,
			p_ply
		}

		public Node() : base()
		{
			this.p_pos = new VP<Pos> (this, (byte)Property.p_pos, new Pos ());
			this.p_ply = new VP<int> (this, (byte)Property.p_ply, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Node node)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** Pos p_pos;*/
						writer.Write (Pos.convertToBytes (node.p_pos.v));
						/** int p_ply;*/
						writer.Write(node.p_ply.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Node node, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** Pos p_pos;*/
					{
						Pos pos = new Pos();
						// parse
						{
							int byteLength = Pos.parse (pos, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							pos.uid = node.p_pos.makeId ();
							node.p_pos.v = pos;
						} else {
							Debug.LogError ("error, parse pos: " + node);
						}
					}
					break;
				case 1:
					/** int p_ply;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							node.p_ply.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: p_ply: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse node fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.Log ("parse node success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}