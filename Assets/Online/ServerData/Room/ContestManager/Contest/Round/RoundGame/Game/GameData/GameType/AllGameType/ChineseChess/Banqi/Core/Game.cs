using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class Game
	{

		private Token.Status status;
		public Token.Ecolor winningColor;
		private string winningPlayer;
		private string losingPlayer;
		private string currentPlayer;
		private Token.Ecolor currentColor;
		private Token.Ecolor creatorColor;
		private List<string> players;
		private Board board;
		private string gameID;
		public bool isFirstMove;

		public Game() {
			status = Token.Status.ACTIVE;
			board = new Board();
			players = new List<string>();
			isFirstMove = true;
		}

		public Game(String _board) {
			status = Token.Status.ACTIVE;
			board = new Board(_board);
			players = new List<string>();
		}

		public String getCreatorColorAsString() {
			if(getCreatorColor() == Token.Ecolor.RED) {
				return "R";
			}else {
				return "B";
			}
		}

		public Token.Ecolor getCreatorColor() {
			return creatorColor;
		}

		public void setCreatorColor(Token.Ecolor color) {
			creatorColor = color;
		}

		public Token.Status getStatus() {
			return status;
		}

		public void setStatus(Token.Status _status) {
			status = _status;
		}

		public string getCurrentPlayer() {
			return currentPlayer;
		}

		public void setCurrentPlayer(string player) {
			currentPlayer = player;
		}

		public Token.Ecolor getCurrentColor() {
			return currentColor;
		}

		public void setCurrentColor(Token.Ecolor color) {
			currentColor = color;
		}

		public List<string> getPlayers(){
			return players;
		}

		public void setPlayers(string player1, string player2) {
			players.Clear();
			players.Add(player1);
			players.Add(player2);
		}

		public Board getBoard() {
			return board;
		}

		public void setBoard() {
			board.resetBoard();
		}

		public string getWinningPlayer() {
			return winningPlayer;
		}

		public string getLosingPlayer() {
			return losingPlayer;
		}    

		public Token.Ecolor getWinningColor() {
			return winningColor;
		}

		public String getGameID() {
			return gameID;
		}    

		public void setGameID(string gameID) {
			this.gameID = gameID;
		}


		//Game actions and logic starts here
		public void switchPlayer() {
			if (currentPlayer == players [0]) {
				currentPlayer = players [1];
			} else if (currentPlayer == players [1]) {
				currentPlayer = players [0];
			} else {
				Debug.LogError ("currentPlayer is not one of this game's players");
			}

			switchColor ();
		}

		public void switchColor() {
			if(currentColor == Token.Ecolor.RED) {
				currentColor = Token.Ecolor.BLACK;
			}else if(currentColor == Token.Ecolor.BLACK) {
				currentColor = Token.Ecolor.RED;
			}
		}

		public void flipToken(int x, int y) {
			if(!board.getToken(x,y).isFaceUp) {
				board.getToken(x,y).flipToken();
			}else {
				Debug.LogError("Token is already face-up!");
			}
		}


		public bool moveToken(string username, int startX, int startY, int endX, int endY) {
			Debug.LogError ("currentPlayer=<" + currentPlayer + ">  username=<" + username + ">");
			if (!username.Equals (currentPlayer)) {
				return false;
			}

			Token token = board.getToken (startX, startY);
			Token token2 = board.getToken (endX, endY);
			if (token.isFaceUp && (token2 == null || token2.isFaceUp)) {
				if (token.getColor () != currentColor) {
					return false;
				}

				if (isValidMove (startX, startY, endX, endY)) {
					if (token2 != null)
						board.moveToGraveyard (token2);
					board.getTile (endX, endY).setToken (token);
					board.getTile (startX, startY).setToken (null);
					switchPlayer ();
					return true;
				} else
					return false;
			} else if (!token.isFaceUp) {
				flipToken (startX, startY);
				switchPlayer ();
				return true;
			} else {
				return false;
			}
		}
			
		public bool isValidMove(int startX, int startY, int endX, int endY) {
			Token token = board.getToken (startX, startY);
			if (board.getToken (endX, endY) == null) {

				if ((Math.Abs (endX - startX) == 1 && Math.Abs (endY - startY) == 0) ||
				   (Math.Abs (endX - startX) == 0 && Math.Abs (endY - startY) == 1)) {
					return true;
				} else {
					return false;
				}

			} else {
				Token token2 = board.getToken (endX, endY);
				if (isValidAttack (token, token2)) {
					if (token.getType () == Token.Type.CANNON) {
						return cannonAttack (startX, startY, endX, endY);
					} else if ((Math.Abs (endX - startX) == 1 && Math.Abs (endY - startY) == 0) ||
					         (Math.Abs (endX - startX) == 0 && Math.Abs (endY - startY) == 1)) {
						return true;
					} else
						return false;
				} else
					return false;
			}
		}

		private bool cannonAttack(int startX, int startY, int endX, int endY){

			int jumped = 0;
			//check Y path
			if (startX == endX && Math.Abs (startY - endY) >= 2) {
				if (startY < endY) {
					for (int y = startY + 1; y < endY; y++) {//Y move down
						if (board.getToken (startX, y) != null) {
							jumped++;
						}
					}
				} else {
					for (int y = startY - 1; y > endY; y--) {//Y move up
						if (board.getToken (startX, y) != null) {
							jumped++;
						}
					}
				}

				//check X path
			} else if (startY == endY && Math.Abs (startX - endX) >= 2) {

				if (startX < endX) {
					for (int x = startX + 1; x < endX; x++) {//X move right
						if (board.getToken (x, startY) != null) {
							jumped++;
						}
					}
				} else {
					for (int x = startX - 1; x > endX; x--) {//X move left
						if (board.getToken (x, startY) != null) {
							jumped++;
						}
					}
				}

			} else
				return false;

			//System.out.println(jumped);
			if (jumped == 1) {
				return true;
			} else {
				return false;
			}
		}

		public bool isValidAttack(Token token, Token token2) {
			if (token.getColor ().Equals (token2.getColor ())) {
				return false;
			}
			if (token.getType () == Token.Type.GENERAL && token2.getType () == Token.Type.SOLDIER) {
				return false;
			}
			if (token.getType () == Token.Type.SOLDIER && token2.getType () == Token.Type.GENERAL) {
				return true;
			}
			if (token.getType () == Token.Type.CANNON) {
				return true;
			}
			if (token.value () >= token2.value ()) {
				return true;
			} else {
				return false;
			}
		}

		/**
	 * Returns True if the game is won, making sure to set winningPlayer, losingPlayer, & winningColor all appropriately.
	 * @return
	 */
		public bool isOver() {
			string state = this.board.saveBoard ();
			bool output = false;
			Token.Ecolor winningColor = Token.Ecolor.None;

			string[] split = state.Split (new char[]{ '.' });

			//System.out.println("split:" + Arrays.toString(split));

			string board = split [0];
			// string graveyard = split [1];

			if (!board.Contains ("R")) {
				//no red pieces, black wins
				winningColor = Token.Ecolor.RED;
				output = true;
			} else if (!board.Contains ("B")) {
				//no black pieces, red wins
				winningColor = Token.Ecolor.BLACK;
				output = true;
			} else {
				//there are both black and red pieces, game is not over
				return false;
			}

			String otherPlayer = "";

			foreach (string player in players) {
				if (!currentPlayer.Equals (player)) {
					otherPlayer = player;
				}
			}

			Token.Ecolor colorOfWinningMove = Token.Ecolor.BLACK;
			if (currentColor == Token.Ecolor.BLACK) {
				colorOfWinningMove = Token.Ecolor.RED;
			}

			//currentPlayer is winner if currentColor = winningColor
			if (colorOfWinningMove == winningColor) {
				this.winningPlayer = currentPlayer;
				this.losingPlayer = otherPlayer;
			} else {
				this.winningPlayer = otherPlayer;
				this.losingPlayer = currentPlayer;
			}

			return output;
		}

		public string getBoardWithColor() {
			String output = board.saveBoard();
			if(currentColor == Token.Ecolor.RED) {
				output += ". R";
			}
			else if(currentColor == Token.Ecolor.BLACK) {
				output += ". B";
			}else Debug.LogError("Problem getting currentColor!");

			return output;
		}

		public void setBoardWithColor(string String) {
			Debug.LogError (String);
			Debug.LogError (String.Substring (0, String.Length - 3));
			if (String [String.Length - 1] == 'R') {
				Debug.LogError ("SETTING CURRENT PLAYER AS RED");
				currentColor = Token.Ecolor.RED;
				board.loadBoard (String.Substring (0, String.Length - 3));
			} else if (String [String.Length - 1] == 'B') {
				Debug.LogError ("SETTING CURRENT PLAYER AS BLACK");
				currentColor = Token.Ecolor.BLACK;
				board.loadBoard (String.Substring (0, String.Length - 3));
			} else {
				Debug.LogError ("SHOULDN'T EVER BE HERE");
			}
		}

		public String toString(){
			return players [0] + " vs. " + players [1];
		}

		public Token.Ecolor getPlayerColor(String player)
		{
			if (player.Equals (currentPlayer)) {
				return currentColor;
			} else if (currentColor == Token.Ecolor.RED) {
				return Token.Ecolor.BLACK;
			} else {
				return Token.Ecolor.RED;
			}
		}

	}
}