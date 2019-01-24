using UnityEngine;
using Mirror;
using System;
using System.Collections.Generic;

public class IdentityUtils 
{

	#region initSync

	public static void InitSync<T>(SyncList<T> syncList, IList<T> listProperty)
	{
		syncList.Clear ();
		for (int i = 0; i < listProperty.Count; i++) {
			syncList.Add (listProperty [i]);
		}
	}

	public static void InitSync<T, K>(SyncList<T> syncList, LP<K> listProperty, ConvertDelegate<T, K> convert)
	{
		syncList.Clear ();
		for (int i = 0; i < listProperty.vs.Count; i++) {
			syncList.Add (convert.convert (listProperty.vs [i]));
		}
	}

	#endregion

	#region Update Sync

	public static void UpdateSyncList<T, K>(SyncList<K> syncList, List<Sync<T>> syncs, ConvertDelegate<K, T> convert)
	{
		for (int syncCount = 0; syncCount < syncs.Count; syncCount++) {
			Sync<T> sync = syncs [syncCount];
			switch (sync.getType ()) {
			case Sync<T>.Type.Set:
				{
					SyncSet<T> syncSet = (SyncSet<T>)sync;
					// replace
					if (syncSet.olds.Count == syncSet.news.Count) {
						if (syncSet.index >= 0 && syncSet.index + (syncSet.olds.Count - 1) < syncList.Count) {
							if (typeof(T) == typeof(K)) {
								for (int i = 0; i < syncSet.olds.Count; i++) {
									syncList [syncSet.index + i] = (K)(object)syncSet.news [i];
								}
							} else {
								// Debug.Log ("different type: " + typeof(T) + "; " + typeof(K));
								for (int i = 0; i < syncSet.olds.Count; i++) {
									syncList [syncSet.index + i] = convert.convert (syncSet.news [i]);
								}
							}
						} else {
							Debug.LogError ("UpdateSync: Set: index error: " + syncSet.index + ", " + syncList.Count);
						}
					} else {
						Debug.LogError ("not the same count");
					}
				}
				break;
			case Sync<T>.Type.Add:
				{
					// TODO add tung cai the nay co the anh huong den toc do o client
					SyncAdd<T> syncAdd = (SyncAdd<T>)sync;
					for (int i = 0; i < syncAdd.values.Count; i++) {
						T value = syncAdd.values [i];
						if (syncAdd.index + i >= 0 && syncAdd.index + i <= syncList.Count) {
							if (typeof(T) == typeof(K)) {
								syncList.Insert (syncAdd.index + i, (K)(object)value);
							} else {
								// Debug.LogError ("different type: " + typeof(T) + "; " + typeof(K));
								syncList.Insert (syncAdd.index + i, convert.convert (value));
							}
						} else {
							Debug.LogError ("UpdateSync: Add: index error: " + syncAdd.index + ", " + syncList.Count);
						}
					}
				}
				break;
			case Sync<T>.Type.Remove:
				{
					SyncRemove<T> syncRemove = (SyncRemove<T>)sync;
					for (int i = 0; i < syncRemove.values.Count; i++) {
						T value = syncRemove.values [i];
						if (syncRemove.index >= 0 && syncRemove.index < syncList.Count) {
							syncList.RemoveAt (syncRemove.index);
						} else {
							Debug.LogError ("UpdateSync: Remove: index error: " + syncRemove.index + ", " + syncList.Count);
						}
					}
				}
				break;
			default:
				Debug.LogError ("unknown type: " + sync.getType ());
				break;
			}
		}
	}

	#endregion

	#region Refresh
	
	public static void refresh<T>(LP<T> listProperty, IList<T> syncList)
	{
		if (listProperty == null || syncList == null) {
			Debug.LogError ("IdentityUtils null error");
			return;
		}
		// find listChange
		List<Change<T>> changes = new List<Change<T>> ();
		{
			// make the same count
			{
				// remove excess value
				if (listProperty.getValueCount () > syncList.Count) {
					ChangeRemove<T> changeRemove = new ChangeRemove<T> ();
					{
						changeRemove.index = syncList.Count;
						changeRemove.number = listProperty.getValueCount () - syncList.Count;
					}
					changes.Add (changeRemove);
				}
				// need insert
				else if (listProperty.getValueCount () < syncList.Count) {
					ChangeAdd<T> changeAdd = new ChangeAdd<T> ();
					{
						changeAdd.index = listProperty.getValueCount ();
						for (int i = listProperty.getValueCount (); i < syncList.Count; i++) {
							changeAdd.values.Add (syncList [i]);
						}
					}
					changes.Add (changeAdd);
				}
			}
			// Copy each value
			{
				// oldChangeSet
				ChangeSet<T> oldChangeSet = null;
				// minCount
				int minCount = Math.Min (listProperty.getValueCount (), syncList.Count);
				// get changes
				for (int i = 0; i < minCount; i++) {
					T oldValue = (T)listProperty.getValue (i);
					T newValue = syncList [i];
					if (!object.Equals (newValue, oldValue)) {
						// get changeSet
						ChangeSet<T> changeSet = null;
						{
							// setIdex: set position in list
							int setIndex = i;
							// check old
							if (oldChangeSet != null) {
								if (oldChangeSet.index + oldChangeSet.values.Count == setIndex) {
									changeSet = oldChangeSet;
								}
							}
							// make new
							if (changeSet == null) {
								changeSet = new ChangeSet<T> ();
								{
									changeSet.index = setIndex;
								}
								changes.Add (changeSet);
								// set new old
								oldChangeSet = changeSet;
							}
						}
						// add value
						changeSet.values.Add (newValue);
					}
				}
			}
		}
		// Change
		if (changes.Count > 0) {
			listProperty.processChange (changes);
		}
	}

	public static void refresh<T, K>(LP<T> listProperty, IList<K> syncList, ConvertDelegate<T, K> convert)
	{
		if (syncList != null) {
			// Convert IList<K> to List<T> 
			List<T> list = new List<T> ();
			{
				for (int i = 0; i < syncList.Count; i++) {
					list.Add (convert.convert (syncList [i]));
				}
			}
			// Refresh
			IdentityUtils.refresh(listProperty, list);
		} else {
			Debug.LogError ("syncList null: " + listProperty + "; " + syncList);
		}
	}

	#endregion

	#region onSyncListChange

	public static void onSyncListChange<T>(LP<T> listProperty, IList<T> syncList, SyncList<T>.Operation op, int index)
	{
		switch (op) {
		case SyncList<T>.Operation.OP_ADD:
			{
				if (index >= 0 && index < syncList.Count) {
					T value = syncList [index];
					listProperty.add (value);
				} else {
					Debug.LogError ("onSyncListChange<T>: index error: " + op + "; " + index + "; " + listProperty);
				}
			}
			break;
		case SyncList<T>.Operation.OP_CLEAR:
			{
				Debug.LogError ("clear");
				listProperty.clear ();
			}
			break;
		case SyncList<T>.Operation.OP_INSERT:
			{
				if (index >= 0 && index <= syncList.Count) {
					T value = syncList [index];
					listProperty.insert (index, value);
				} else {
					Debug.LogError ("onSyncListChange<T>: index error: " + op + "; " + index + "; " + listProperty);
				}
			}
			break;
		case SyncList<T>.Operation.OP_REMOVE:
			{
				if (index >= 0 && index < listProperty.vs.Count) {
					listProperty.removeAt (index);
				} else {
					Debug.LogError ("onSyncListChange<T>: remove error: " + op + "; " + index + "; " + listProperty);
				}
			}
			break;
		case SyncList<T>.Operation.OP_REMOVEAT:
			{
				listProperty.removeAt (index);
			}
			break;
		case SyncList<T>.Operation.OP_SET:
			{
				if (index >= 0 && index < syncList.Count) {
					listProperty.set (index, syncList [index]);
				} else {
					Debug.LogError ("index error: OP_SET: " + index + ", " + syncList.Count);
				}
			}
			break;
		case SyncList<T>.Operation.OP_DIRTY:
			break;
		default:
			Debug.LogError ("unknown operation: " + op + "; " + listProperty);
			break;
		}
	}

	public static void onSyncListChange<T, K>(LP<T> listProperty, IList<K> syncList, SyncList<K>.Operation op, int index, ConvertDelegate<T, K> convert)
	{
		// Convert IList<K> to List<T> 
		List<T> list = new List<T> ();
		{
			for (int i = 0; i < syncList.Count; i++) {
				list.Add (convert.convert (syncList [i]));
			}
		}
		// Operation
		SyncList<T>.Operation newOp = SyncList<T>.Operation.OP_ADD;
		{
			switch (op) {
			case SyncList<K>.Operation.OP_ADD:
				newOp = SyncList<T>.Operation.OP_ADD;
				break;
			case SyncList<K>.Operation.OP_CLEAR:
				newOp = SyncList<T>.Operation.OP_CLEAR;
				break;
			case SyncList<K>.Operation.OP_INSERT:
				newOp = SyncList<T>.Operation.OP_INSERT;
				break;
			case SyncList<K>.Operation.OP_REMOVE:
				newOp = SyncList<T>.Operation.OP_REMOVE;
				break;
			case SyncList<K>.Operation.OP_REMOVEAT:
				newOp = SyncList<T>.Operation.OP_REMOVEAT;
				break;
			case SyncList<K>.Operation.OP_SET:
				newOp = SyncList<T>.Operation.OP_SET;
				break;
			case SyncList<K>.Operation.OP_DIRTY:
				newOp = SyncList<T>.Operation.OP_DIRTY;
				break;
			default:
				Debug.LogError ("unknown operation: " + op + "; " + listProperty);
				break;
			}
		}
		// onSyncListChange
		IdentityUtils.onSyncListChange(listProperty, list, newOp, index);
	}

	#endregion

}