using UnityEngine;
using System;
using System.IO;
using System.Collections;
using SQLite4Unity3d;
using Mono.Data.Sqlite;

public class TestSqlite : MonoBehaviour
{

	void Start () {
		string fileName = "Test1.sqlite";
		Mono.Data.Sqlite.SqliteConnection.CreateFile ("/Users/viettho/Desktop/NewProject/TurnbaseGame/Assets/StreamingAssets/"+fileName);
		DataService ds = new DataService(fileName);
		// sqliteObject
		{
			ds._connection.CreateTable<SqliteObject> ();
			// update
			for (uint i = 101; i < 120; i++) {
				SqliteObject sqliteObject = new SqliteObject ();
				{
					GamePlayer gamePlayer = new GamePlayer ();
					gamePlayer.uid = i;
					sqliteObject.updateIds (gamePlayer);
					sqliteObject.updateContent (gamePlayer);
				}
				ds._connection.Insert (sqliteObject);
				// ds._connection.Update (sqliteObject);
			}
			// get
			{
				TableQuery<SqliteObject> allSqliteObjects = ds._connection.Table<SqliteObject> ();
				Debug.LogError ("allSqliteObjectss: " + allSqliteObjects.Count ());
				foreach (SqliteObject sqliteObject in allSqliteObjects) {
					using(BinaryReader reader = new BinaryReader (new MemoryStream (sqliteObject.content))){
						Data data = Data.parseSqliteBinary (reader);
						Debug.LogError ("parse sqlite binary: " + data);
					}
				}
			}
		}

		// SqliteConnection connection;

		// connection.create
	}
}