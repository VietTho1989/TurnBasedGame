using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
	public class CoTuongUpMove : GameMove
	{

		public VP<int> move;

		#region Constructor

		public enum Property
		{
			move
		}

		public CoTuongUpMove() : base()
		{
			this.move = new VP<int> (this, (byte)Property.move, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.CoTuongUpMove;
		}

		public override string print ()
		{
			// TODO Can hoan thien
			return "";
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is CoTuongUp) {
				CoTuongUp coTuongUp = gameType as CoTuongUp;
				// Make animation
				CoTuongUpMoveAnimation coTuongUpMoveAnimation = new CoTuongUpMoveAnimation();
				{
					coTuongUpMoveAnimation.move.v = this.move.v;
					if (coTuongUp.nodes.vs.Count > 0) {
						Node currentNode = coTuongUp.nodes.vs [coTuongUp.nodes.vs.Count - 1];
						coTuongUpMoveAnimation.node.v = DataUtils.cloneData (currentNode) as Node;
					}
				}
				return coTuongUpMoveAnimation;
			} else {
				Debug.LogError ("error, unknown gameType: " + gameType + "; " + this);
				return null;
			}
		}

		public static Rules.Move getMove(int mv)
		{
			Rules.Move move = new Rules.Move ();
			{
				byte[] byteArray = BitConverter.GetBytes (mv);
				move.from.x = byteArray [0];
				move.from.y = byteArray [1];
				move.dest.x = byteArray [2];
				move.dest.y = byteArray [3];
			}
			return move;
		}

		public static CoTuongUpMove makeMove(Rules.Move move)
		{
			CoTuongUpMove coTuongUpMove = new CoTuongUpMove();
			{
				byte[] byteArray = new byte[]{ move.from.x, move.from.y, move.dest.x, move.dest.y };
				coTuongUpMove.move.v = BitConverter.ToInt32 (byteArray, 0);
			}
			return coTuongUpMove;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

	}
}