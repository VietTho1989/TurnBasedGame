using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Janggi.Ai
{
	public class PrimaryUcb : Mcts.Handlers
	{

		
		public PrimaryUcb()
		{
			MaxRolloutDepth = 100;
			ExplorationRate = 0.7f;
		}

		public int MaxRolloutDepth
		{
			set;
			get;
		}

		public float ExplorationRate
		{
			set;
			get;
		}

		void moveRandomNext(Board board)
		{
			List<Common.Move> moves = board.GetAllPossibleMoves ();

			//int k = Global.Rand.Next(moves.Count);
			//MoveNext(moves[k]);
			//return;

			int[] proms = new int[moves.Count];

			Func<uint, uint, uint, uint, int> Judge;
			if (board.IsMyTurn) {
				Judge = (stoneFrom, stoneTo, targetTo, targetFrom) => {
					//일단 상대를 따먹으면 10점
					int takingPoint = StoneHelper.GetPoint (stoneTo);
					return takingPoint + ((StoneHelper.IsRed (targetTo) ? StoneHelper.GetPoint (stoneFrom) : 0) + (takingPoint != 0 ? 10 : 0));
				};
			} else {
				Judge = (stoneFrom, stoneTo, targetTo, targetFrom) => {
					int takingPoint = -StoneHelper.GetPoint (stoneTo);
					return takingPoint + ((StoneHelper.IsGreen (targetTo) ? -StoneHelper.GetPoint (stoneFrom) : 0) + (takingPoint != 0 ? 10 : 0));
				};
			}

			//최소 점수
			int min = int.MaxValue;
			int sum = 0;

			//마지막 rest빼고.
			for (int i = 0; i < moves.Count - 1; i++) {
				Common.Move move = moves [i];
				uint stoneFrom = board.stones [move.From.Y, move.From.X];
				uint stoneTo = board.stones [move.To.Y, move.To.X];
				uint targetTo = board.targets [move.To.Y, move.To.X];
				uint targetFrom = board.targets [move.From.Y, move.From.X];

				int judge = Judge (stoneFrom, stoneTo, targetTo, targetFrom);
				proms [i] = judge;

				if (judge < min) {
					min = judge;
				}

				sum += judge;
			}

			proms [proms.Length - 1] = min;
			sum += min;

			sum += (-min + 10) * proms.Length;

			int prob = GlobalJanggi.Next (sum);

			bool oldMyTurn = board.IsMyTurn;
			int cumm = 0;
			for (int i = 0; i < proms.Length; i++) {
				proms [i] = proms [i] - min + 10;
				cumm += proms [i];

				if (prob < cumm) {
					board.MoveNext (moves [i]);
					return;
				}
			}

			Debug.LogError ("have exception");
			//throw new Exception ("??");
		}


		public override void CalcPolicyWeights(Node node)
		{
			//기본 UCB에서는 pollicy가 없다.
		}

		public override float[] CalcScores(Node node)
		{
			Node[] children = node.children;
			float[] scores = new float[children.Length];
			if (node.visited == 0) {
				for (int i = 0; i < children.Length; i++) {
					scores [i] = float.MaxValue;
				}
			} else {
				for (int i = 0; i < children.Length; i++) {
					Node child = children [i];
					if (child == null) {
						//방문 안 한건 무조건 방문하도록 높게 책정
						scores [i] = float.MaxValue;
					} else {
						scores [i] = (float)child.win / child.visited +
						(float)(ExplorationRate * Math.Sqrt (2 * Math.Log (node.visited) / child.visited));
					}
				}
			}
			return scores;
		}

		public override float CalcLeafEvaluation(Node node)
		{
			//rollout
			Board rollout = new Board(node.board);

			//100수까지만 하자 혹시나.
			for (int i = 0; i < 10; i++)
			{
				moveRandomNext(rollout);

				if (rollout.IsMyWin)
				{
					return 1;
				}
				else if (rollout.IsYoWin)
				{
					return 0;
				}
			}

			return rollout.Point > 0 ? 1 : 0;
		}
	}
}