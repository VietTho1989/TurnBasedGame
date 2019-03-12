using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIGlobalScale1 : MonoBehaviour
{

    private static readonly Vector3 desiredGlobalScale = new Vector3(1.0f, 1.0f, 1.0f);

    void Update()
    {
        /*if (Global.get().mainUI != null)
        {
            this.transform.localScale = Global.get().mainUI.Inv;
        }
        else
        {
            Debug.LogError("mainUI null");
        }*/

        Vector3 scaleFactor = GetGlobalToLocalScaleFactor(this.transform); //Determine the factor

        // Debug.LogError("scaleFactor: " + scaleFactor);
        //Determine what the new scale local scale should be
        Vector3 newLocalScale = new Vector3
          (desiredGlobalScale.x / scaleFactor.x,
           desiredGlobalScale.y / scaleFactor.y,
           desiredGlobalScale.z / scaleFactor.z);

        //Set the new local scale, Now the gameObject has the requested global scale
        this.transform.localScale = newLocalScale;
    }

    public static Vector3 GetGlobalToLocalScaleFactor(Transform t)
    {
        Vector3 factor = Vector3.one;

        while (true)
        {
            Transform tParent = t.parent;

            if (tParent != null && tParent != Global.get().mainUI)
            {
                // Debug.LogError("localScale: " + tParent.localScale);
                factor.x *= tParent.localScale.x;
                factor.y *= tParent.localScale.y;
                factor.z *= tParent.localScale.z;

                t = tParent;
            }
            else
            {
                return factor;
            }
        }
    }

}