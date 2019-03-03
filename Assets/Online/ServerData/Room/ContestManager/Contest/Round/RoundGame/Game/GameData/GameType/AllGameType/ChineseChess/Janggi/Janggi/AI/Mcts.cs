using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Janggi.Ai
{
	public class Mcts
	{

		public int pickBestMove = 90;

		//--각종 델리게이트
		public delegate float[] CalcScoresHandler(Node node);
		public delegate float CalcLeafEvaluationHandler(Node node);
		public delegate void CalcPolicyWeightsHandler(Node node);

		public abstract class Handlers
		{
			public abstract float[] CalcScores(Node node);
			public abstract float CalcLeafEvaluation(Node node);
			public abstract void CalcPolicyWeights(Node node);
		}

		public CalcScoresHandler CalcScores;
		public CalcLeafEvaluationHandler CalcLeafEvaluation;
		public CalcPolicyWeightsHandler CalcPolicyWeights;

		//--이벤트

		public delegate void ProgressUpdatedHandler(Mcts mcts, int visit, double rate);
		public event ProgressUpdatedHandler ProgressUpdated;

		//--------------------------------------------------------
		List<Node> history;

		Node start;
		public Node root;

		int currentLevel;

		public int myFirst;//나부터 시작했으면 0

		public const int DefaultMaxVisitCount = 50000;

		public Mcts(Handlers handlers)
		{
			CalcScores = handlers.CalcScores;
			CalcLeafEvaluation = handlers.CalcLeafEvaluation;
			CalcPolicyWeights = handlers.CalcPolicyWeights;

			maxVisitCount = DefaultMaxVisitCount;
		}

		public Mcts(Handlers handlers, int maxVisitCount)
		{
			CalcScores = handlers.CalcScores;
			CalcLeafEvaluation = handlers.CalcLeafEvaluation;
			CalcPolicyWeights = handlers.CalcPolicyWeights;

			this.maxVisitCount = maxVisitCount;
		}


		public void Init(Board board)
		{
			start = new Node(null, board, Common.Move.Empty);
			root = start;

			currentLevel = 0;
			myFirst = board.IsMyTurn ? 0 : 1;

			history = new List<Node>();
		}

		public int maxVisitCount;
		public int MaxVisitCount {
			set {
				maxVisitCount = value;
			}
			get {
				return maxVisitCount;
			}
		}

		//searchNext함수가 끝날때까지 기다린다.
		/*public void WaitSearching()
		{
			signalSearch.WaitOne();
		}*/

		/*public void PauseSearching()
		{
			signalPause.Reset();
		}*/

		/*public void WaitCycle()
		{
			signalCycle.WaitOne();
		}*/

		/*public void ResumeSearching()
		{
			signalPause.Set();
		}*/

		/*public bool IsSearching
		{
			//reset이면 누군가 들어있는(서치하고 있는) 상황
			get {
				return !signalSearch.WaitOne (0);
			}
		}*/

		/*public bool IsPaused
		{
			//reset이면 걸려서 멈춘 상황
			get {
				return !signalPause.WaitOne (0);
			}
		}*/

		// 두 번 이상 SearchNext를 수행하지 않도록 막는 시그널
		// System.Threading.ManualResetEvent signalSearch = new System.Threading.ManualResetEvent(true);
		//잠시멈춤 시그널
		// System.Threading.ManualResetEvent signalPause = new System.Threading.ManualResetEvent(true);
		//한 사이클 처리가 끝나기를 기다릴 수 있는 시그널
		// System.Threading.ManualResetEvent signalCycle = new System.Threading.ManualResetEvent(true);

		public Node SearchNextAsync()
		{
			/*if (IsSearching) {
				Debug.LogError ("why isSearching");
				return null;
			}*/

			// TODO Tam bo signalSearch.Reset ();

			//await Task.Run (() => 
			// Run
			{
				if (CalcScores == null) {
					throw new Exception ("CalcScore must not be null.");
				}

				if (CalcLeafEvaluation == null) {
					throw new Exception ("CalcValue must not be null.");
				}

				if (CalcPolicyWeights == null) {
					throw new Exception ("CalcPolicy must not be null.");
				}

				int maxDepth = 0;
				int depthSum = 0;

				bool isMyTurn = root.board.IsMyTurn;

				//ParallelOptions option = new ParallelOptions();
				//option.MaxDegreeOfParallelism = 10;

				// TODO tam bo signalPause.Set ();

				while (true) {
					//이미 셋으로 돌아섰다면 그냥 리턴
					/* TODO Tam bo if (signalSearch.WaitOne (0)) {
						break;
					}*/

					//조건을 만족한다면 셋으로 변경하고 리턴
					if (root.visited > maxVisitCount) {
						// TODO Tam bo signalSearch.Set ();
						break;
					}

					// TODO Tam bo signalCycle.Reset ();

					//500단위로 끊자.
					int parallelLoop = Math.Min (MaxVisitCount, 100);


					// Parallel.For(0, parallelLoop, turn =>
					for (int turn = 0; turn < parallelLoop; turn++) {
						// Debug.LogError ("parallel loop search: " + this.GetHashCode ());
						//랜덤으로 깊이 탐색
						List<Node> visitedNodes = new List<Node> ();
						Node next = root;

						float leafEvaluation = 0;
						bool finished = false;

						while (true) {
							//새로운 노드를 탐색하여 방문
							// Node parent = next;

							//하나의 노드에서 다음 노드로 가는 것은 한 번에 하나씩.
							//lock (parent) 
							{
								next = GetBestScoreChild (next);
								visitedNodes.Add (next);

								//겜이 끝났는지 확인 (익스펜드된 거라도 상관없음)
								if (next.board.IsMyWin) {
									finished = true;
									leafEvaluation = 1;
								} else if (next.board.IsYoWin) {
									finished = true;
									leafEvaluation = 0;
								}
								//첫 방문 노드라면 (익스펜드된 노드라면)
								else if (next.visited == 0) {
									//끝 노드를 평가한다.
									leafEvaluation = CalcLeafEvaluation (next);
									finished = true;
								}

								if (finished) {
									//visited, win 업데이트
									for (int i = visitedNodes.Count - 1; i >= 0; i--) {
										Node node = visitedNodes [i];
										// lock (node) 
										{
											//부모노드의 승리를 각 child에 나눠서 저장
											if (node.parent.board.IsMyTurn) {
												node.win += leafEvaluation;
											} else {
												//상대 차례일 때는 반대로 업데이트
												node.win += (1 - leafEvaluation);
											}

											node.visited++;
										}
									}

									root.visited++;

									break;
								} else {
									//안 끝났으면 다음 while로~
								}
							}
						}

						//얼마나 깊이 들어가는지 보기 위해 재미로 통계를 낸다. 
						int depth = visitedNodes.Count;
						depthSum += depth;
						if (depth > maxDepth) {
							maxDepth = depth;
						}
					}

					// TODO tam bo signalCycle.Set ();

					// ProgressUpdated?.Invoke (this, root.visited, root.visited / (double)MaxVisitCount);
					if (ProgressUpdated != null) {
						ProgressUpdated.Invoke (this, root.visited, root.visited / (double)MaxVisitCount);
					}
					// Debug.LogError ("ProgressUpdated: " + root.visited + ", " + root.visited / (double)MaxVisitCount);

					// TODO Tam bo signalPause.WaitOne ();
				}

				//Console.WriteLine($"Max depth : {maxDepth}");
				//Console.WriteLine($"Visited : {root.visited}");
			}
			//);

			//for (int i = 0; i < root.children.Length; i++)
			//{
			//	Node child = root.children[i];
			//	if (child != null)
			//	{
			//		Console.WriteLine($"{i} : {child.win} / {child.visited} ... {root.moves[i]}");
			//	}
			//	else
			//	{
			//		Console.WriteLine($"{i} : ... ");
			//	}
			//}



			//if (root.promNode == null)
			//{
			//	Console.WriteLine("== NO PROMISSING");
			//	root.promNode = root.GetRandomChild(promCalculator);
			//}

			//Console.WriteLine("Current Point : " + root.point);
			//Console.WriteLine("Expected Point : " + root.promNode.point);


			//Node temp = root.promNode;
			//while (temp.promNode != null)
			//{
			//	Console.WriteLine(temp.promNode.prevMove.ToString() + " : " + temp.promNode.point.ToString());
			//	temp = temp.promNode;
			//}


			return GetMostVisitedChild (root);
		}

		public void ForceStopSearch()
		{
			// signalPause.Set();
			// signalSearch.Set();
		}

		public void SetMove(Common.Move move)
		{
			root.PrepareMoves ();
			bool moved = false;
			for (int i = 0; i < root.moves.Count; i++) {
				if (move.Equals (root.moves [i])) {
					SetMove (root.GetChild (i));
					moved = true;
					break;
				}
			}

			if (!moved) {
				throw new Exception ("bad move");
			}
		}

		public void SetMove(Node node)
		{
			if (root.parent != null)
			{
				root.parent.Clear();
			}
			history.Add(root);
			root = node;
			currentLevel++;
		}

		public Node GetBestScoreChild(Node parent)
		{
			// lock (parent)
			{
				if (parent.policyWeights == null) {
					CalcPolicyWeights (parent);
				}

				parent.PrepareChildren();
				float[] scores = CalcScores(parent);
				// pickBestMove
				{
					if (pickBestMove >= 0 && pickBestMove < 100) {
						for (int i = 0; i < scores.Length; i++) {
							float score = scores [i];
							float newValue = score - GlobalJanggi.NextFloat (100 - pickBestMove) * score / 100;
							scores [i] = newValue;
						}
					} else {
						Debug.LogError ("pickBestMove error");
					}
				}
				float max = scores[0];

				List<int> maxIndexies = new List<int> { 0 };
				for (int i = 1; i < scores.Length; i++)
				{
					if (max < scores[i])
					{
						max = scores[i];
						maxIndexies.Clear();
						maxIndexies.Add(i);
					}
					else if (max == scores[i])
					{
						maxIndexies.Add(i);
					}
				}

				int index;
				if (maxIndexies.Count == 1)
				{
					index = maxIndexies[0];
				}
				else
				{
					int k = GlobalJanggi.Next(maxIndexies.Count);
					index = maxIndexies[k];
				}

				return parent.GetChild(index);
			}
		}

		public Node GetMostVisitedChild(Node parent)
		{
			// lock (parent)
			{
				Node[] children = parent.children;
				Node node = null;
				int max = int.MinValue;
				for (int i = 0; i < children.Length; i++) {
					if (children [i] == null) {
						continue;
					}

					if (max < children [i].visited) {
						max = children [i].visited;
						node = children [i];
					}
				}

				if (node == null) {
					// throw new Exception ("There is no visited child");
					Debug.LogError ("There is no visited child");
				}

				return node;
			}
		}
	}
}