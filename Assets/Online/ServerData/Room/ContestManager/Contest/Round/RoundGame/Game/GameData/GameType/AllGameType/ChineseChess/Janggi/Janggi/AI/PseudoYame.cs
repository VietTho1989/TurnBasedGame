using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Janggi.Ai
{
	public class PseudoYame : Mcts.Handlers
	{

		public PseudoYame()
		{
			MaxRolloutDepth = 100;
			ExplorationRate = 1;
			Alpha = 0f;
		}

		public int MaxRolloutDepth
		{
			set;
			get;
		}

		public double ExplorationRate
		{
			set;
			get;
		}

		public float Alpha
		{
			set;
			get;
		}

		void moveRandomNext(Board board)
		{
			List<Common.Move> moves = board.GetAllPossibleMoves();

			//int k = Global.Rand.Next(moves.Count);
			//MoveNext(moves[k]);
			//return;

			int[] proms = new int[moves.Count];

			Func<uint, uint, uint, uint, int> Judge;
			if (board.IsMyTurn)
			{
				Judge = (stoneFrom, stoneTo, targetTo, targetFrom) =>
				{
					//일단 상대를 따먹으면 10점
					int takingPoint = StoneHelper.GetPoint(stoneTo);
					return takingPoint + ((StoneHelper.IsRed(targetTo) ? StoneHelper.GetPoint(stoneFrom) : 0) + (takingPoint != 0 ? 10 : 0));
				};
			}
			else
			{
				Judge = (stoneFrom, stoneTo, targetTo, targetFrom) =>
				{
					int takingPoint = -StoneHelper.GetPoint(stoneTo);
					return takingPoint + ((StoneHelper.IsGreen(targetTo) ? -StoneHelper.GetPoint(stoneFrom) : 0) + (takingPoint != 0 ? 10 : 0));
				};
			}

			//최소 점수
			int min = int.MaxValue;
			int sum = 0;

			//마지막 rest빼고.
			for (int i = 0; i < moves.Count - 1; i++)
			{
				Common.Move move = moves[i];
				uint stoneFrom = board.stones [move.From.Y, move.From.X];
				uint stoneTo = board.stones [move.To.Y, move.To.X];
				uint targetTo = board.targets[move.To.Y, move.To.X];
				uint targetFrom = board.targets[move.From.Y, move.From.X];

				int judge = Judge(stoneFrom, stoneTo, targetTo, targetFrom);
				proms[i] = judge;

				if (judge < min)
				{
					min = judge;
				}

				sum += judge;
			}

			proms[proms.Length - 1] = min;
			sum += min;

			sum += (-min + 10) * proms.Length;

			int prob = GlobalJanggi.Next(sum);

			bool oldMyTurn = board.IsMyTurn;
			int cumm = 0;
			for (int i = 0; i < proms.Length; i++)
			{
				proms[i] = proms[i] - min + 10;
				cumm += proms[i];

				if (prob < cumm)
				{
					board.MoveNext(moves[i]);
					return;
				}
			}

			Debug.LogError ("have exception");
			//throw new Exception("??");
		}
			
		public override void CalcPolicyWeights(Node node)
		{
			//기본 UCB에서는 pollicy가 없다.
			node.PreparePolicyWeights ();
			var moves = node.moves;
			Board board = node.board;
			float[] proms = node.policyWeights;

			Func<uint, uint, uint, int> Judge;
			if (board.IsMyTurn) {
				Judge = (stoneFrom, stoneTo, target) => {
					//일단 상대를 따먹으면 10점
					int takingPoint = StoneHelper.GetPoint (stoneTo);
					return takingPoint + ((StoneHelper.IsRed (target) ? StoneHelper.GetPoint (stoneFrom) : 0) + (takingPoint != 0 ? 10 : 0));
				};
			} else {
				Judge = (stoneFrom, stoneTo, target) => {
					int takingPoint = -StoneHelper.GetPoint (stoneTo);
					return takingPoint + ((StoneHelper.IsGreen (target) ? -StoneHelper.GetPoint (stoneFrom) : 0) + (takingPoint != 0 ? 10 : 0));
				};
			}

			//최소 점수
			int max = int.MinValue;
			int min = int.MaxValue;

			//마지막 rest빼고.
			for (int i = 0; i < moves.Count - 1; i++) {
				Common.Move move = moves [i];
				uint stoneFrom = board.stones [move.From.Y, move.From.X];
				uint stoneTo = board.stones [move.To.Y, move.To.X];
				uint target = board.targets [move.To.Y, move.To.X];

				int judge = Judge (stoneFrom, stoneTo, target);
				proms [i] = judge;

				if (judge > max) {
					max = judge;
				}

				if (judge < min) {
					min = judge;
				}
			}

			float sum = 0;
			int diff = Math.Min (max - min, 90);
			int diff0 = diff / 20;
			for (int i = 0; i < proms.Length - 1; i++) {
				proms [i] = proms [i] - max + diff;
				if (proms [i] < diff0)
					proms [i] = diff0;
				proms [i] += 2;
				sum += proms [i];
			}

			//rest에 대한 추가
			proms [proms.Length - 1] = diff0;
			sum += diff0;

			for (int i = 0; i < proms.Length; i++) {
				proms [i] = proms [i] / sum;
			}
		}

		public override float[] CalcScores(Node node)
		{
			Node[] children = node.children;
			float[] scores = new float[children.Length];
			float[] policyWeights = node.policyWeights;
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
						scores [i] = child.win / child.visited +
						(float)(ExplorationRate * policyWeights [i] * Math.Sqrt (node.visited / child.visited));
					}
				}
			}
			return scores;
		}

		public override float CalcLeafEvaluation(Node node)
		{
			//rollout
			Board rollout = new Board (node.board);

			bool finished = false;
			float rolloutResult = 0;

			if (Alpha != 0) {
				//100수까지만 하자 혹시나.
				for (int i = 0; i < 30; i++) {
					moveRandomNext (rollout);

					if (rollout.IsMyWin) {
						rolloutResult = 1;
						finished = true;
					} else if (rollout.IsYoWin) {
						rolloutResult = 0;
						finished = true;
					}
				}
			}

			if (!finished) {
				rolloutResult = rollout.Point > 0 ? 1 : 0;
			}

			float valueResult = node.board.Judge ();

			return rolloutResult * Alpha + (1 - Alpha) * valueResult;
		}

	}
}