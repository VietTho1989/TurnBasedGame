using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireSolved : GameMove
	{

		public enum SolveResult
		{
			CouldNotComplete = -2,
			SolvedMayNotBeMinimal = -1,
			Impossible = 0,
			SolvedMinimal = 1,
			NotSolved = 2
		}

		public VP<SolveResult> result;

		public LP<SolitaireMove> moves;

		#region Constructor

		public enum Property
		{
			result,
			moves
		}

		public SolitaireSolved() : base()
		{
			this.result = new VP<SolveResult> (this, (byte)Property.result, SolveResult.NotSolved);
			this.moves = new LP<SolitaireMove> (this, (byte)Property.moves);
		}

		#endregion

		#region implement gameMove

		public override Type getType()
		{
			return Type.SolitaireSolved;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return "SolitaireSolved: " + this.result.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

		public static int parse(SolitaireSolved solitaireSolved, byte[] byteArray, int start)
		{
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						// result
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							solitaireSolved.result.v = (SolveResult)BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: result: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						// moves
						// find move count
						int moveCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								moveCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: moveCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// correct moveCount
						if (moveCount < 0 || moveCount >= 512) {
							moveCount = 0;
							Debug.LogError ("moveCount error: " + moveCount);
						}
						// get moves
						List<SolitaireMove> moves = new List<SolitaireMove> ();
						{
							for (int i = 0; i < moveCount; i++) {
								SolitaireMove move = new SolitaireMove ();
								int moveByteLength = SolitaireMove.parse (move, byteArray, count);
								if (moveByteLength > 0) {
									moves.Add (move);
									count += moveByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
						}
						// add
						foreach (SolitaireMove move in moves) {
							move.uid = solitaireSolved.moves.makeId ();
							solitaireSolved.moves.add (move);
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

	}
}