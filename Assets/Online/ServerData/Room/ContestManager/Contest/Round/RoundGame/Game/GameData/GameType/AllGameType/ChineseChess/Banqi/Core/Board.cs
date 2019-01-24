using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class Board
	{

		private List<Token> tokens;
		private List<Tile> tiles;
		private List<Token> graveyard;

		public Board() {
			tokens = new List<Token>();
			tiles = new List<Tile>();
			graveyard = new List<Token>();
			setBoard();
		}

		public Board(string String) {
			tokens = new List<Token>();
			tiles = new List<Tile>();
			graveyard = new List<Token>();
			loadBoard(String);
		}


		public List<Token> getGraveyard(){
			return graveyard;
		}

		public Token getToken(int x, int y) {
			for (int i = 0; i < tiles.Count; i++) {
				if (tiles [i].getPosition () [0] == x) {
					if (tiles [i].getPosition () [1] == y) {
						return tiles[i].getToken ();
					}
				}
			}
			Debug.LogError ("Token not on board");
			return null;
		}

		public Tile getTile(int x, int y) {
			for (int i = 0; i < tiles.Count; i++) {
				if (tiles [i].getPosition () [0] == x) {
					if (tiles [i].getPosition () [1] == y) {
						return tiles [i];
					}
				}
			}
			Debug.LogError ("Error finding tile");
			return null;
		}

		public void createToken(Token.Type type, Token.Ecolor color, int numOfTokens) {
			for (int i = 0; i < numOfTokens; i++) {
				tokens.Add (new Token (type, color));
			}
		}

		public void createTokenSet(Token.Ecolor _color) {
			Token.Ecolor color = _color;
			Token.Type type = Token.Type.GENERAL;
			createToken (type, color, 1);
			type = Token.Type.ADVISOR;
			createToken (type, color, 2);
			type = Token.Type.ELEPHANT;
			createToken (type, color, 2);
			type = Token.Type.CHARIOT;
			createToken (type, color, 2);
			type = Token.Type.HORSE;
			createToken (type, color, 2);
			type = Token.Type.CANNON;
			createToken (type, color, 2);
			type = Token.Type.SOLDIER;
			createToken (type, color, 5);
		}

		public void createAllTokens() {
			createTokenSet(Token.Ecolor.RED);
			createTokenSet(Token.Ecolor.BLACK);
		}

		public void createTiles() {

			for(int y=4; y>0; y--) {
				for(int x=1; x<9; x++) {
					tiles.Add(new Tile(x, y));
				}
			}
		}

		public void setBoard() {
			createAllTokens ();
			createTiles ();
			IListExtensions.Shuffle (tokens);
			for (int i = 0; i < tokens.Count; i++) {
				tiles [i].setToken (tokens [i]);
			}
		}

		public void resetBoard() {
			tokens.Clear ();
			tiles.Clear ();
			createAllTokens ();
			createTiles ();
			IListExtensions.Shuffle (tokens);
			for (int i = 0; i < tokens.Count; i++) {
				tiles [i].setToken (tokens [i]);
			}
		}

		public void presetBoard() {
			for (int i = 0; i < tokens.Count; i++) {
				tiles [i].setToken (tokens [i]);
			}
		}

		public void moveToGraveyard(Token token) {
			graveyard.Add (token);
			tokens.Remove (token);
			for (int i = 0; i < tiles.Count; i++) {
				if (tiles [i].getToken () == token) {
					tiles [i].setToken (null);
				}
			}
		}

		public string saveBoard() {
			string output = "";
			Token token;
			for (int i = 0; i < tiles.Count; i++) {
				if (tiles [i].getToken () == null) {
					output += "XXX ";
				} else {
					token = tiles [i].getToken ();
					output += token.abbreviate ();
					if (token.isFaceUp) {
						output += "U ";
					} else
						output += "D ";
				}
			}

			output += ". ";
			for (int i = 0; i < graveyard.Count; i++) {
				token = graveyard [i];
				output += token.abbreviate ();
				if (token.isFaceUp) {
					output += "U ";
				} else
					output += "D ";
			}

			return output;
		}

		public void loadBoard(string String)
		{
			string[] graveyardSplit = String.Split (new char[]{ '.' });
			// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
			string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
			Token.Ecolor color;
			Token.Type type;
			bool isFaceUp;
			Token token;

			tokens.Clear ();
			tiles.Clear ();
			createTiles ();

			for (int i = 0; i < split.Length; i++) {
				if (split [i].Equals ("XXX")) {
					continue;
				}
				if (string.IsNullOrEmpty (split [i])) {
					// Debug.LogError ("split i empty");
					continue;
				}

				if (split [i] [0] == 'B') {
					color = Token.Ecolor.BLACK;
				} else
					color = Token.Ecolor.RED;

				int temp = split [i] [1];
				switch (temp) {
				case '7':
					type = Token.Type.GENERAL;
					break;
				case '6':
					type = Token.Type.ADVISOR;
					break;
				case '5':
					type = Token.Type.ELEPHANT;
					break;
				case '4':
					type = Token.Type.CHARIOT;
					break;
				case '3':
					type = Token.Type.HORSE;
					break;
				case '2':
					type = Token.Type.CANNON;
					break;
				case '1':
					type = Token.Type.SOLDIER;
					break;
				default:
					Debug.LogError ("unknown type: " + temp);
					type = Token.Type.SOLDIER;
					break;
				}

				if (split [i] [2] == 'U') {
					isFaceUp = true;
				} else
					isFaceUp = false;

				token = new Token (type, color);
				if (isFaceUp) {
					token.flipToken ();
				}

				tokens.Add (token);
				tiles [i].setToken (token);
			}
		}

		public string printBoard() {
			StringBuilder builder = new StringBuilder ();
			int i = 0;

			for (int y = 4; y > 0; y--) {
				for (int x = 1; x < 9; x++) {
					if (tiles [i].getToken () == null) {
						builder.Append ("-- ");
					} else if (!tiles [i].getToken ().isFaceUp) {
						builder.Append ("[] ");
					} else {
						builder.Append (tiles [i].getToken ().abbreviate () + " ");
					}
					i++;
				}
				builder.AppendLine ();
			}
			builder.AppendLine ();
			return builder.ToString ();
		}

		public string printGraveyard() {
			StringBuilder builder = new StringBuilder ();
			{
				builder.Append ("Graveyard: ");
				for (int i = 0; i < graveyard.Count; i++) {
					builder.Append (graveyard [i].abbreviate () + " ");
				}
				builder.AppendLine ();
			}
			return builder.ToString ();
		}

	}
}