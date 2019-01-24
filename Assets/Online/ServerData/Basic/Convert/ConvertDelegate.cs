using UnityEngine;
using System.Collections;

public abstract class ConvertDelegate<T, K>
{

	public abstract T convert(K value);

}

