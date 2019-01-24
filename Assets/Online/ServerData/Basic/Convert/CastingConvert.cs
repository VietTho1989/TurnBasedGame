using UnityEngine;
using System.Collections;

public class CastingConvert<T, K> : ConvertDelegate<T, K>
{

	public override T convert (K value)
	{
		if (value is T) {
			return (T)(object)value;
		} else {
			Debug.LogError ("casting convert not correct");
			return default(T);
		}
	}

}

