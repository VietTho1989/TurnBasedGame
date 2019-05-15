using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenCaptureSetting : Data
{

    public VP<int> waitDuration;

    public const bool DefaultAutoCloseSetting = true;
    public VP<bool> autoCloseSetting;

    #region Constructor

    public enum Property
    {
        waitDuration,
        autoCloseSetting
    }

    public ScreenCaptureSetting() : base()
    {
        this.waitDuration = new VP<int>(this, (byte)Property.waitDuration, ScreenCaptureWaitUI.UIData.DefaultDuration);
        this.autoCloseSetting = new VP<bool>(this, (byte)Property.autoCloseSetting, DefaultAutoCloseSetting);
    }

    #endregion

}