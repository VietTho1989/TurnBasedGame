using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class Laser : Data
	{

		/** int32_t _targetIndex*/
		public VP<int> _targetIndex;

		/** Square _targetSquare*/
		public VP<byte> _targetSquare;

		/** int32_t _targetPiece*/
		public VP<int> _targetPiece;

		#region Constructor

		public enum Property
		{
			_targetIndex,
			_targetSquare,
			_targetPiece
		}

		public Laser() : base()
		{
			this._targetIndex = new VP<int> (this, (byte)Property._targetIndex, 0);
			this._targetSquare = new VP<byte> (this, (byte)Property._targetSquare, 0);
			this._targetPiece = new VP<int> (this, (byte)Property._targetPiece, 0);
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Laser laser)
		{
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					/** int32_t _targetIndex*/
					writer.Write (laser._targetIndex.v);
					/** Square _targetSquare*/
					writer.Write (laser._targetSquare.v);
					/** int32_t _targetPiece*/
					writer.Write (laser._targetPiece.v);
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Laser laser, byte[] byteArray, int start)
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
						/** int32_t _targetIndex*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							laser._targetIndex.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: _targetIndex: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						/** Square _targetSquare*/
						int size = sizeof(byte);
						if (count + size <= byteArray.Length) {
							laser._targetSquare.v = byteArray [count];
							count += size;
						} else {
							Debug.LogError ("array not enough length: _targetSquare: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					{
						/** int32_t _targetPiece*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							laser._targetPiece.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: _targetPiece: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				// Debug.LogError ("count: " + count + "; " + index);
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
				Debug.LogError ("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}
}