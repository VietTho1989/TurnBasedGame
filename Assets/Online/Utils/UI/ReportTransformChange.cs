using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReportTransformChange : MonoBehaviour
{



	void Update()
	{
		if (this.transform.hasChanged) {
			this.transform.hasChanged = false;
			WrapContent.SetAncestorDirty (this.transform);
		}
	}

}