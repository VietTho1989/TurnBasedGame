using UnityEngine;
using System.Collections;

public interface NetDataDelegate
{
	System.Type getDataType();

	#region ClientData

	void setClientData (Data newData);

	Data getClientData ();

	void initClientData();

	#endregion

	#region ServerData

	void setServerData (Data newData);

	Data getServerData();

	#endregion

	string getObjectName();
	
}

