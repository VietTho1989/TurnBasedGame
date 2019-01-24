using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Makruk
{
	public class Chess960
	{

		public static string generateFirstRank(){
			string pieces = "RNSKMSNR";
			do{
				pieces = Shuffle.StringMixer(pieces);
			}while(!check(pieces));
			return pieces;
		}

		public static bool check(string rank){
			{
				Regex rgx = new Regex(@".*R.*K.*R.*");
				if (!rgx.IsMatch (rank)) {
					//king between rooks
					return false;
				}
			}
			{
				Regex rgx = new Regex(@".*S(..|....|......|)S.*");
				if (!rgx.IsMatch (rank)) {
					//all possible ways bishops can be placed
					return false;
				}
			}
			return true;
		}
	}
}