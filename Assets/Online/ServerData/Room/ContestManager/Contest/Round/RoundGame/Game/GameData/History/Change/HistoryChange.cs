using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class HistoryChange : Data
{

	public enum Type 
	{
		Turn,
		Wrap
	};

	public abstract Type getType();

}