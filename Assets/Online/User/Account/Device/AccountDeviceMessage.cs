using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class AccountDeviceMessage : MessageBase, AccountMessage
{

	public string imei = "";
	public string deviceName = "";
	public int deviceType = (int)DeviceType.Console;
	public string customName = "";

	public override void Deserialize(NetworkReader reader)
	{
		imei = reader.ReadString ();
		deviceName = reader.ReadString ();
		deviceType = reader.ReadInt32 ();
		customName = reader.ReadString ();
	}

	public override void Serialize(NetworkWriter writer)
	{
		writer.Write (imei);
		writer.Write (deviceName);
		writer.Write (deviceType);
		writer.Write (customName);
	}

	#region implement base

	public Account.Type getType()
	{
		return Account.Type.DEVICE;
	}

	public Account makeAccount()
	{
		AccountDevice accountDevice = new AccountDevice ();
		{
			accountDevice.imei.v = this.imei;
			accountDevice.deviceName.v = this.deviceName;
			accountDevice.customName.v = this.customName;
			accountDevice.deviceType.v = this.deviceType;
		}
		return accountDevice;
	}

	#endregion

	public override string ToString ()
	{
		return string.Format ("[AccountDeviceMessage: {0}, {1}, {2}, {3}]", imei, deviceName, customName, deviceType);
	}

}