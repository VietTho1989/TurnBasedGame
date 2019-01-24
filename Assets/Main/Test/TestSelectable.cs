using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestSelectable : Selectable
{

	void Update()
	{
		this.gameObject.transform.GetSiblingIndex ();
	}

}