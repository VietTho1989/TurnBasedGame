using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class SqliteData
{

	public List<Data.SI> search = new List<Data.SI> ();

	public Data data = null;

	public SqliteData(SqliteObject sqliteObject)
	{
		if (sqliteObject != null) {
			// search
			{
				List<uint> searchInfo = new List<uint> ();
				{
					if (sqliteObject.ids != null) {
						try {
							using (BinaryReader reader = new BinaryReader (new MemoryStream (sqliteObject.ids))) {
								int count = sqliteObject.ids.Length/sizeof(uint);
								for(int i=0; i<count; i++){
									searchInfo.Add(reader.ReadUInt32());
								}
							}
						} catch (System.Exception e) {
							Debug.LogError (e);
						}
					} else {
						Debug.LogError ("ids null");
					}
				}
				this.search = DataIdentity.deserialize (searchInfo);
			}
			// data
			{
				if (sqliteObject.content != null) {
					try {
						using (BinaryReader reader = new BinaryReader (new MemoryStream (sqliteObject.content))) {
							this.data = Data.parseSqliteBinary (reader);
							// Debug.LogError ("parse sqlite binary: " + data);
							// TODO Test HistoryChange
							/*{
								if (this.data is HistoryChange) {
									Debug.LogError ("load historyChange: " + this.data + "; " + this.search.Count);
								}
							}*/
						}
					} catch (System.Exception e) {
						Debug.LogError (e);
					}
				} else {
					Debug.LogError ("content null");
				}
			}
		} else {
			Debug.LogError ("sqliteObject null");
		}
	}

	public static bool AddToServer(Server server, SqliteData sqliteData)
	{
		bool ret = false;
		if (server != null) {
			if (sqliteData != null) {
				if (sqliteData.search != null && sqliteData.data != null) {
					// uid
					// sqliteData.data.uid = sqliteData.search [0].i;
					// add
					{
						WrapProperty searchProperty = server.findPropertyForData (sqliteData.search);
						if (searchProperty != null) {
							searchProperty.addValue (sqliteData.data, true);
							ret = true;
						} else {
							Debug.LogError ("seachProperty null");
						}
					}
				} else {
					Debug.LogError ("search, data null");
				}
			} else {
				Debug.LogError ("sqliteData null");
			}
		} else {
			Debug.LogError ("server null");
		}
		return ret;
	}

}