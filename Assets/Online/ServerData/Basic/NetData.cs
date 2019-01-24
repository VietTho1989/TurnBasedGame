using UnityEngine;
using System;
using System.Collections;

public class NetData<T> : NetDataDelegate where T : Data
{
	public System.Type getDataType()
	{
		return typeof(T);
	}

	#region ClientData

	public T clientData = null;

	public void setClientData (Data newData)
	{
		if (newData is T) {
			this.clientData = (T)newData;
		} else {
			Debug.LogError ("newData not T");
		}
	}

	public Data getClientData ()
	{
		return this.clientData;
	}

	public void initClientData()
	{
		// Debug.LogError ("initClientData: " + this + ", " + this.clientData);
		this.clientData = Activator.CreateInstance<T>();
	}

	#endregion

	#region ServerData

	public T serverData = null;

	public Data getServerData()
	{
		return this.serverData;
	}

	public void setServerData (Data newData)
	{
		if (newData is T) {
			this.serverData = (T)newData;
		} else {
			Debug.LogError ("newData not T");
		}
	}

	#endregion

	#region Constructor

	public NetData() 
	{

	}

	#endregion

	#region implement delegate

	public string getObjectName()
	{
		if (this.serverData != null) {
			return "" + typeof(T) + " " + this.serverData.uid;
		}
		if (this.clientData != null) {
			return "" + typeof(T) + " " + this.clientData.uid;
		}
		return "" + typeof(T);
	}

	#endregion

}

