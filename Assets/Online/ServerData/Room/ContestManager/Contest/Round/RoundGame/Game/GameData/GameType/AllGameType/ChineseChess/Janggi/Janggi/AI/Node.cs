using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi.Ai
{
	public class Node
	{

		//->노드 기본 정보
		//게임 스테이트
		public Board board;
		//현재 상태로 오게 만드는 무브
		public Common.Move prevMove;
		//부모 노드
		public Node parent;

		//-->서치 중 동적 생성, 이후 계속 유지
		//현재로부터 움직일 수 있는 모든 길
		public List<Common.Move> moves;

		public int visited = 0;
		public float win = 0;

		//각 길에 대한 다음 노드
		public Node[] children;

		//갈 길에 대한 policy network 확률
		//매 방문때마다 단 한 번만 계산되고,
		//계속 써먹게 되므로 저장해둔다.
		public float[] policyWeights;

		public Node(Node parent, Board board, Common.Move prevMove)
		{
			// lock (this)
			{
				this.parent = parent;
				this.board = board;
				this.prevMove = prevMove;
			}
		}

		public void PrepareMoves()
		{
			lock (this)
			{
				if (moves == null)
				{
					moves = board.GetAllPossibleMoves();

					//반복수 제거

					// my    yo    my   yo     my
					// p4 -> p3 -> p2-> p1 -> this -> next

					Node p2 = null;
					{
						if (parent != null) {
							p2 = parent.parent;
						}
					}
					Node p4 = null;
					{
						if (p2 != null) {
							if (p2.parent != null) {
								p4 = p2.parent.parent;
							}
						}
					}
					//둘 다 제자리로 온 경우
					if (p2 != null && board.Equals(p2.board))
					{
						moves.Remove(parent.prevMove);
					}

					//와리가리 한 경우
					if (p4 != null && board.Equals(p4.board))
					{
						moves.Remove(p2.parent.prevMove);
					}
				}
			}
		}

		public void PrepareChildren()
		{
			// lock (this)
			{
				if (children == null)
				{
					PrepareMoves();
					children = new Node[moves.Count];
				}
			}
		}

		internal void PreparePolicyWeights()
		{
			// lock (this)
			{
				if (policyWeights == null) {
					PrepareMoves ();
					policyWeights = new float[moves.Count];
				}
			}
		}

		public Node GetChild(int index)
		{
			// lock (this)
			{
				PrepareChildren();

				if (children[index] == null)
				{
					Common.Move move = moves[index];
					Board nextBoard = board.GetNext(move);
					Node nextNode = new Node(this, nextBoard, move);
					children[index] = nextNode;
				}
			}

			return children[index];
		}

		public void Clear()
		{
			// lock (this)
			{
				children = null;
				moves = null;
				policyWeights = null;
			}
		}

		public void ClearAll()
		{
			//lock (this) 
			{
				if (children != null) {
					foreach (Node node in children) {
						node.ClearAll ();
					}
				}

				Clear ();
			}
		}

	}
}