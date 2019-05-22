using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalPrefab : MonoBehaviour
{

    public RequestChangeBoolUI requestBool;
    public RequestChangeEnumUI requestEnum;
    public RequestChangeFloatUI requestFloat;
    public RequestChangeIntUI requestInt;
    public RequestChangeLongUI requestLong;
    public RequestChangeStringUI requestString;

    #region instance

    public static GlobalPrefab instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

}