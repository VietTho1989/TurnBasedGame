using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class Tile
	{

		private int[] position;
		private Token token;

		public Tile(int x, int y) {
			position = new int[2];
			position[0] = x;
			position[1] = y;

			token = null;
		}

		public int[] getPosition(){
			return position;
		}

		public Token getToken(){
			return token;
		}

		public void setToken(Token _token) {
			token = _token;
		}

	}
}