using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;

public class HaveSqliteServerUpdateUI : UIBehavior<HaveSqliteServerUpdateUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<SQLiteConnection> connection;

		public VP<ReferenceData<Server>> server;

		#region Constructor

		public enum Property
		{
			connection,
			server
		}

		public UIData() : base()
		{
			this.connection = new VP<SQLiteConnection>(this, (byte)Property.connection, null);
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
		}

		#endregion

	}

	#endregion

	#region Sqlite

	private bool canUpdate = true;

	public class UpdateData
	{

		public bool alreadyAdd = true;

		public enum Type
		{
			Add,
			Remove,
			Update
		}

		public Type type = Type.Update;

		public Data data = null;

	}

	private Dictionary<Data, UpdateData> dictUpdate = new Dictionary<Data, UpdateData> ();

	private void updateSqlite(Data data, UpdateData.Type type)
	{
		if (canUpdate) {
			if (data != null) {
				// find UpdateData
				UpdateData updateData = null;
				{
					if (!dictUpdate.TryGetValue (data, out updateData)) {
						updateData = new UpdateData ();
						{
							if (type == UpdateData.Type.Add) {
								updateData.alreadyAdd = false;
							}
						}
						dictUpdate.Add (data, updateData);
					}
				}
				// Set
				{
					updateData.data = data;
					updateData.type = type;
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	#endregion

	#region Refresh

	private Dictionary<Data, byte[]> idsDict = new Dictionary<Data, byte[]> ();

	public override void refresh ()
	{
		if (this.data != null) {
			SQLiteConnection connection = this.data.connection.v;
			if (connection != null) {
				if (dictUpdate.Count > 0) {
					List<SqliteObject> addDatas = new List<SqliteObject> ();
					List<SqliteObject> removeDatas = new List<SqliteObject> ();
					List<SqliteObject> updateDatas = new List<SqliteObject> ();
					{
						// Debug.LogError ("need update: " + dictUpdate.Count);
						foreach (UpdateData updateData in dictUpdate.Values) {
							switch (updateData.type) {
							case UpdateData.Type.Add:
								{
									byte[] ids = null;
									if (idsDict.TryGetValue (updateData.data, out ids)) {
										SqliteObject sqliteObject = new SqliteObject ();
										{
											sqliteObject.ids = ids;
											sqliteObject.updateContent (updateData.data);
											// TODO Co nen them vao?
											sqliteObject.data = updateData.data;
										}
										addDatas.Add (sqliteObject);
										// history change
										/*{
											if (updateData.data is HistoryChange) {
												Debug.LogError ("add history change: " + updateData.data);
											}
										}*/
									} else {
										Debug.LogError ("Cannot find ids: " + updateData.data);
									}
								}
								break;
							case UpdateData.Type.Remove:
								{
									if (updateData.alreadyAdd) {
										byte[] ids = null;
										if (idsDict.TryGetValue (updateData.data, out ids)) {
											SqliteObject sqliteObject = new SqliteObject ();
											{
												sqliteObject.ids = ids;
												sqliteObject.updateContent (updateData.data);
												// TODO Co nen them vao?
												sqliteObject.data = updateData.data;
											}
											removeDatas.Add (sqliteObject);
											// remove in ds dict
											idsDict.Remove(updateData.data);
										}
									} else {
										// Debug.LogError ("why not already add: " + updateData.data + ", " + this);
									}
								}
								break;
							case UpdateData.Type.Update:
								{
									byte[] ids = null;
									if (idsDict.TryGetValue (updateData.data, out ids)) {
										SqliteObject sqliteObject = new SqliteObject ();
										{
											sqliteObject.ids = ids;
											sqliteObject.updateContent (updateData.data);
											// TODO Co nen them vao?
											sqliteObject.data = updateData.data;
										}
										if (updateData.alreadyAdd) {
											updateDatas.Add (sqliteObject);
										} else {
											addDatas.Add (sqliteObject);
										}
									}
								}
								break;
							default:
								Debug.LogError ("unknown type: " + updateData.type + "; " + this);
								break;
							}
						}
						dictUpdate.Clear ();
					}
					// Update sqlite
					{
						// add
						if (addDatas.Count > 0) {
							/*try {
								connection.InsertAll (addDatas);
							} catch (Exception e) {
								Debug.LogError ("insert all error: " + e);
							}*/
							foreach (SqliteObject addData in addDatas) {
								try{
									connection.InsertOrReplace(addData);
								}catch(Exception e){
									Debug.LogError ("insert error: " + e + "; " + addData.data);
								}
							}
						}
						// remove
						if (removeDatas.Count > 0) {
							foreach (SqliteObject removeData in removeDatas) {
								try {
									connection.Delete (removeData);
								} catch (Exception e) {
									Debug.LogError ("delete error: " + e);
								}
							}
						}
						// update
						if (updateDatas.Count > 0) {
							try {
								connection.UpdateAll (updateDatas);
							} catch (Exception e) {
								Debug.LogError ("updateAll error: " + e);
							}
						}
					}
				}
			} else {
				// Debug.LogError ("connection null: " + this);
				// dictUpdate.Clear ();
			}
		} else {
			// Debug.LogError ("data null: " + this);
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.server.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is Server) {
			Server server = data as Server;
			// reset
			this.dictUpdate.Clear();
			// idsDict
			idsDict.Add(server, SqliteObject.GetIdsBytes(server));
			// Child
			{
				canUpdate = false;
				server.addCallBackAllChildren (this);
				canUpdate = true;
			}
			dirty = true;
			return;
		}
		// Child
		{
			// idsDict
			idsDict.Add(data, SqliteObject.GetIdsBytes(data));
			// add
			this.updateSqlite (data, UpdateData.Type.Add);
			// child
			data.addCallBackAllChildren (this);
			dirty = true;
			return;
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.server.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				canUpdate = false;
				server.removeCallBackAllChildren (this);
				canUpdate = true;
			}
			return;
		}
		// Child
		{
			this.updateSqlite (data, UpdateData.Type.Remove);
			data.removeCallBackAllChildren (this);
			return;
		}
		// Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UIData) {
			switch ((UIData.Property)wrapProperty.n) {
			case UIData.Property.connection:
				{
					// reset
					this.dictUpdate.Clear();
				}
				break;
			case UIData.Property.server:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is Server) {
			// update
			this.updateSqlite (wrapProperty.p, UpdateData.Type.Update);
			// Child
			if (Generic.IsAddCallBackInterface<T>()) {
				ValueChangeUtils.replaceCallBack (this, syncs);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// update
			this.updateSqlite (wrapProperty.p, UpdateData.Type.Update);
			// Child
			if (Generic.IsAddCallBackInterface<T>()) {
				ValueChangeUtils.replaceCallBack (this, syncs);
			}
			dirty = true;
			return;
		}
		// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}