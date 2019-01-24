using UnityEngine;
using System.Collections;

public class EnableDisableInform : MonoBehaviour
{

	void OnDisable()
	{
		WrapContent.SetAncestorDirty (this.transform);
	}

	private bool isFirstEnable = true;

	void OnEnable()
	{
		if (!isFirstEnable) {
			WrapContent.SetAncestorDirty (this.transform);
		} else {
			isFirstEnable = false;
		}
	}

}