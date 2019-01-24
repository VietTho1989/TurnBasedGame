using UnityEngine;
using System.Collections;

public class AIController
{

	private static System.Object lockThis = new System.Object ();

	public const int MAX_THINK_COUNT = 30;
	public const int MIN_THINK_COUNT = 5;
	public static int thinkCount = 0;

	public static void startThink()
	{
		start:
		lock (lockThis) {
			if (thinkCount < Mathf.Clamp (Setting.get ().maxThinkCount.v, MIN_THINK_COUNT, MAX_THINK_COUNT)) {
				thinkCount++;
			} else {
				System.Threading.Thread.Sleep (1000);
				goto start;
			}
		}
	}

	public static void startEnd ()
	{
		if (thinkCount > 0) {
			thinkCount--;
		} else {
			Debug.LogError ("why think count not >0");
		}
	}

}