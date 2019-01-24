using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shuffle
{
	
	static System.Random rnd = new System.Random();

	static void Fisher_Yates(int[] array)
	{
		int arraysize = array.Length;
		int random;
		int temp;

		for (int i = 0; i < arraysize; i++)
		{
			random = i + (int)(rnd.NextDouble() * (arraysize - i));

			temp = array[random];
			array[random] = array[i];
			array[i] = temp;
		}
	}

	public static string StringMixer(string s)
	{
		string output = "";
		int arraysize = s.Length;
		int[] randomArray = new int[arraysize];

		for (int i = 0; i < arraysize; i++)
		{
			randomArray[i] = i;
		}

		Fisher_Yates(randomArray);

		for (int i = 0; i < arraysize; i++)
		{
			output += s[randomArray[i]];
		}

		return output;
	}
}