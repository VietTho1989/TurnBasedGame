using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GlobalUpdate : MonoBehaviour 
{
	
	void Update () {
		Global.get ().networkReachability.v = Application.internetReachability;
		// event click
		/*if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject ()) {
				Debug.LogError ("left-click over a GUI element!: " + EventSystem.current.currentSelectedGameObject);
			} else {
				Debug.Log ("just a left-click!");
			}
		}*/
	}

}