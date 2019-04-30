using System;
using UnityEngine;
// using FullSerializer;

public static class StringSerializationAPI 
{
	
    /*private static readonly fsSerializer _serializer = new fsSerializer();

	public static string Serialize(Type type, object value) {
		// serialize the data
		fsData data;
		_serializer.TrySerialize(type, value, out data).AssertSuccessWithoutWarnings();

		// emit the data via JSON
		string ret = fsJsonPrinter.CompressedJson(data);
		if (string.IsNullOrEmpty (ret)) {
			Debug.LogError ("why serialize null: " + type + "; " + value);
		}
		return ret;
	}

	public static object Deserialize(Type type, string serializedState) {
		// step 1: parse the JSON data
		fsData data = fsJsonParser.Parse(serializedState);

		// step 2: deserialize the data
		object deserialized = null;
		_serializer.TryDeserialize(data, type, ref deserialized).AssertSuccessWithoutWarnings();

		if (deserialized == null) {
			Debug.LogError ("why deserialize null: " + type + "; " + serializedState);
		}

		return deserialized;
	}*/

}