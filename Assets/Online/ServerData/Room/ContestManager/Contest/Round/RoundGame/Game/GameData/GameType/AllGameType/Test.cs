using UnityEngine;
using System;
using System.Collections;

public class Test : MonoBehaviour
{

	public static bool stop = false;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			int matchCount = 5;

            // Chess.TestChess.startTestMatch (matchCount);
            // Makruk.TestMakruk.startTestMatch (matchCount);
            // Shatranj.TestShatranj.startTestMatch (matchCount);
            // Seirawan.TestSeirawan.startTestMatch (matchCount);
            // FairyChess.TestFairyChess.startTestMatch(matchCount);

            // Gomoku.TestGomoku.startTestMatch (matchCount);
            // Reversi.TestReversi.startTestMatch (matchCount);
            // Shogi.TestShogi.startTestMatch (matchCount);
            // Weiqi.TestWeiqi.startTestMatch (matchCount);
            // Xiangqi.TestXiangqi.startTestMatch (matchCount);

            // InternationalDraught.TestInternationalDraught.startTestMatch (matchCount);
            // EnglishDraught.TestEnglishDraught.startTestMatch (matchCount);
            // RussianDraught.TestRussianDraught.startTestMatch(matchCount);
            ChineseCheckers.TestChineseCheckers.startTestMatch(matchCount);

			// MineSweeper.TestMineSweeper.startTestMatch (matchCount);
			// HEX.TestHex.startTestMatch(matchCount);
			// Solitaire.TestSolitaire.startTestMatch(matchCount);
			// Sudoku.TestSudoku.startTestMatch (matchCount);
			// Khet.TestKhet.startTestMatch(matchCount);
			// Janggi.TestJanggi.startTestMatch(matchCount);
			// Banqi.TestBanqi.startTestMatch (matchCount);
			// NineMenMorris.TestNineMenMorris.startTestMatch(matchCount);
		}
		// Debug.LogWarning ("ThinkCount: " + AIController.thinkCount);
	}

	void OnDestroy() {
		stop = true;
	}
}