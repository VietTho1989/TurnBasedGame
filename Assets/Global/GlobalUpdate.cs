using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GlobalUpdate : MonoBehaviour
{

    public RectTransform mainUI;

    void FixedUpdate()
    {
        Global.get().mainUI = mainUI;
        Global.get().networkReachability.v = Application.internetReachability;
        Global.get().deviceOrientation.v = Input.deviceOrientation;
        Global.get().screenOrientation.v = Screen.orientation;
        if (mainUI != null)
        {
            Global.get().width.v = mainUI.rect.size.x;
            Global.get().height.v = mainUI.rect.size.y;
        }
        else
        {
            Debug.LogError("mainUI null");
        }
        Global.get().screenWidth.v = Screen.width;
        Global.get().screenHeight.v = Screen.height;
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