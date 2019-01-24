using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class CalculateScore : Data
{

	public enum Type
	{
		Sum,
		WinLoseDraw
	}

	public abstract Type getType();

	public abstract class UIData : Data
	{

		public abstract Type getType();

	}

}