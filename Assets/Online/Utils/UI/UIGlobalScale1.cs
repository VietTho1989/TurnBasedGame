using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIGlobalScale1 : MonoBehaviour
{

    private static readonly Vector3 NormalScale = new Vector3(1, 1, 1);

    void Update()
    {
        UIUtils.SetGlobalScale(this.transform, NormalScale);
    }

}