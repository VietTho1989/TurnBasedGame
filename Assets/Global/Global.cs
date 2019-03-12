using UnityEngine;
using System;
using System.Collections;

public class Global : Data
{

	public const int VersionCode = 1;

	public const float WaitSendTime = 30f;

	public const int ThreadSize = 1048576;

    #region time

    public static long getRealTimeInMiliSeconds()
	{
		DateTime epoch = new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		long ms = (long) (DateTime.UtcNow - epoch).TotalMilliseconds;
		return ms;
	}

    public static string getStrTime(long miliseconds)
    {
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(miliseconds);
        DateTime localDateTime = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local);
        return localDateTime.ToShortTimeString();// + ", " + dateTime.ToLongDateString();
    }

    #endregion

    public static string DataPath = "";

	#region Get

	private static Global instance;

	static Global()
	{
		instance = new Global ();
	}

	public static Global get()
	{
		return instance;
	}

    #endregion

    #region mainUI

    public Transform mainUI;

    #endregion

    public VP<NetworkReachability> networkReachability;

    public VP<DeviceOrientation> deviceOrientation;

    public VP<ScreenOrientation> screenOrientation;

    public VP<float> width;

    public VP<float> height;

    public VP<int> screenWidth;

    public VP<int> screenHeight;

	#region Constructor

	public enum Property
	{
		networkReachability,
        deviceOrientation,
        screenOrientation,
        width,
        height,
        screenWidth,
        screenHeight
    }

    public Global() : base()
    {
        this.networkReachability = new VP<NetworkReachability>(this, (byte)Property.networkReachability, NetworkReachability.ReachableViaLocalAreaNetwork);
        this.deviceOrientation = new VP<DeviceOrientation>(this, (byte)Property.deviceOrientation, DeviceOrientation.Portrait);
        this.screenOrientation = new VP<ScreenOrientation>(this, (byte)Property.screenOrientation, ScreenOrientation.AutoRotation);
        this.width = new VP<float>(this, (byte)Property.width, 480);
        this.height = new VP<float>(this, (byte)Property.height, 640);
        this.screenWidth = new VP<int>(this, (byte)Property.screenWidth, 480);
        this.screenHeight = new VP<int>(this, (byte)Property.screenHeight, 640);
    }

	#endregion

	public static readonly Color NormalColor = new Color (16/256f, 78/256f, 163/256f, 256/256f);
	public static readonly Color HintColor = Color.green;// new Color (0 / 256f, 1, 0, 256 / 256f);
	public static readonly Color TransparentColor = new Color(1f, 1f, 1f, 0f);

    public static void OnValueTransformChange(WrapProperty wrapProperty, DirtyInterface dirtyInterface)
    {
        Debug.LogError("global transform change");
        switch ((Global.Property)wrapProperty.n)
        {
            case Property.networkReachability:
                break;
            case Property.deviceOrientation:
                dirtyInterface.makeDirty();
                break;
            case Property.screenOrientation:
                dirtyInterface.makeDirty();
                break;
            case Property.width:
                dirtyInterface.makeDirty();
                break;
            case Property.height:
                dirtyInterface.makeDirty();
                break;
            case Property.screenWidth:
                dirtyInterface.makeDirty();
                break;
            case Property.screenHeight:
                dirtyInterface.makeDirty();
                break;
            default:
                Debug.LogError("Don't process: " + wrapProperty + "; " + dirtyInterface);
                break;
        }
    }

}