using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultGameType : Data
{

	public abstract GameType.Type getType();

	public abstract GameType makeDefaultGameType();

}