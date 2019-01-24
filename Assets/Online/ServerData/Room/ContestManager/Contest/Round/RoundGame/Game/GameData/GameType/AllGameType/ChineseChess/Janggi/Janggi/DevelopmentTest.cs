using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Janggi;
using Janggi.Ai;

public class DevelopmentTest
{
	
	public DevelopmentTest()
	{
		for (int i = 0; i < 32; i++)
		{
			uint stone = (uint)1 << i;
			Console.WriteLine(((StoneHelper.Stones)stone).ToString() + ", " + StoneHelper.GetPoint(stone));
		}

		Board board = new Board(Board.Tables.Outer, Board.Tables.Left, true);

		PrimaryUcb primaryUcb = new PrimaryUcb();
		Mcts mcts = new Mcts(primaryUcb);

		mcts.Init(board);

		int turn = 0;
		while (!board.IsMyWin && !board.IsYoWin) {
			Debug.LogError ("Turn: " + turn);
			turn++;
			Node node = mcts.SearchNextAsync ();
			board.MoveNext (node.prevMove);
			mcts.SetMove (node.prevMove);
			Debug.LogError (board.PrintStones ());
		}
	}

}