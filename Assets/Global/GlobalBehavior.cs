using UnityEngine;
using Mirror;
using System.Collections;

public class GlobalBehavior : MonoBehaviour
{

	public static int MaxCheckLegalCount = 25;
	public static int CheckLegalCount = 0;

	public static int MaxCheckFinishCount = 20;
	public static int CheckFinishCount = 0;

	void FixedUpdate ()
	{
		CheckLegalCount = 0;
		CheckFinishCount = 0;

        // TODO Test ping
        /*{
            double ping = NetworkTime.rtt;
            Debug.LogError("ping: " + ping);
        }*/
    }

}