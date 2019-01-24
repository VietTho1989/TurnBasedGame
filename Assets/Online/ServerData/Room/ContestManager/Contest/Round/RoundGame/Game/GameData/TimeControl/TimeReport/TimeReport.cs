using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class TimeReport : Data
{

	public enum Type
	{
		None,
		Client
	}

	public abstract Type getType();

}