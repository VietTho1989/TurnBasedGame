using UnityEngine;
using System.Collections;

public class GlobalObserverUpdate : MonoBehaviour
{

	void Update ()
	{
		GameObserver.Controller.resetPerFrame ();
	}
}

