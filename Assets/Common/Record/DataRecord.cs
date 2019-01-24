using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class DataRecord
	{

		public const string Extension = ".rep";

		public int version = Global.VersionCode;

		public Data data;

		public long startTime;

		public float t;

		#region changes

		public List<Change> changes = new List<Change>();

		public void makeChange<T>(Data data, WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			// Make change
			Change newChange = new Change ();
			{
				// t
				newChange.t = this.t;
				// wrapChange
				{
					WrapChange wrapChange = new WrapChange ();
					{
						wrapChange.uid = (uint)this.changes.Count;
						// Search info
						{
							wrapChange.pi.v = wrapProperty.p.makeSearchInforms (data);
							wrapChange.vn.v = wrapProperty.n;
						}
						// Content
						wrapChange.setSyncsObject(syncs);
					}
					newChange.change = wrapChange;
				}
			}
			changes.Add (newChange);
			// Debug.LogError ("recordChange: " + this.changes.Count);
		}

		#endregion

		#region pos

		public int pos = -1;

		public float getCurrentTime()
		{
			float currentTime = 0;
			{
				if (pos >= 0 && pos < this.changes.Count) {
					Change change = this.changes [pos];
					if (change != null) {
						currentTime = change.t;
					} else {
						Debug.LogError ("change null: " + this);
					}
				} else {
					if (pos < 0) {
						currentTime = 0;
					} else if (pos >= this.changes.Count) {
						currentTime = this.t;
					}
				}
			}
			return currentTime;
		}

		#endregion

		public void reset()
		{
			this.data = null;
			this.startTime = 0;
			this.t = 0;
			this.pos = -1;
			this.changes.Clear ();
		}

		#region makeBinary

		public void makeBinary(BinaryWriter writer)
		{
			if (data != null) {
				writer.Write (this.version);
				this.data.makeBinary (writer);
				writer.Write (this.startTime);
				writer.Write (this.t);
				// changes
				{
					writer.Write (this.changes.Count);
					foreach (Change change in this.changes) {
						change.makeBinary (writer);
					}
				}
			} else {
				Debug.LogError ("why data null: " + this);
			}
		}

		public static DataRecord parse(BinaryReader reader)
		{
			DataRecord dataRecord = new DataRecord ();
			{
				dataRecord.version = reader.ReadInt32();
				dataRecord.data = Data.parseBinary (reader);
				dataRecord.startTime = reader.ReadInt64();
				dataRecord.t = reader.ReadSingle ();
				// changes
				{
					int count = reader.ReadInt32 ();
					for (int i = 0; i < count; i++) {
						dataRecord.changes.Add (Change.parse (reader));
					}
				}
			}
			return dataRecord;
		}

		#endregion

		#region change position

		public uint moveForward(float newTime, uint maxProcessCount = uint.MaxValue)
		{
			uint processCount = 0;
			if (data != null) {
				int startIndex = this.pos + 1;
				for (int i = startIndex; i < this.changes.Count; i++) {
					// check processCount
					{
						if (processCount >= maxProcessCount) {
							Debug.LogError ("maxProcessCount: " + processCount + "; " + maxProcessCount);
							break;
						}
					}
					// check i
					if (i >= 0 && i < this.changes.Count) {
						Change change = this.changes [i];
						if (change != null) {
							// Debug.LogError ("moveForward change: " + i + "; " + change.t + "; " + newTime + "; " + this.t);
							// check time
							if (change.t <= newTime) {
								WrapChange wrapChange = change.change;
								if (wrapChange != null) {
									WrapProperty wrapProperty = data.findProperty (wrapChange);
									if (wrapProperty != null) {
										try {
											wrapProperty.processRedo (wrapChange);
										} catch (System.Exception e) {
											Debug.LogError ("processRedo error: " + e);
										}
									} else {
										Debug.LogError ("wrapProperty null: " + this);
									}
								} else {
									Debug.LogError ("wrapChange null: " + this);
								}
								this.pos = i;
								processCount++;
							} else {
								break;
							}
						} else {
							Debug.LogError ("change null: " + this);
							break;
						}
					} else {
						Debug.LogError ("i error: " + i);
						break;
					}
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
			return processCount;
		}

		public uint moveBackWard(float newTime, uint maxProcessCount = uint.MaxValue)
		{
			uint processCount = 0;
			if (data != null) {
				int startIndex = this.pos;
				for (int i = startIndex; i >= 0; i--) {
					// check processCount
					{
						if (processCount >= maxProcessCount) {
							Debug.LogError ("maxProcessCount: " + processCount + "; " + maxProcessCount);
							break;
						}
					}
					// check i
					if (i >= 0 && i < this.changes.Count) {
						Change change = this.changes [i];
						if (change != null) {
							// Debug.LogError ("moveForward change: " + i + "; " + change.t + "; " + newTime + "; " + this.t);
							// check time
							if (change.t >= newTime) {
								WrapChange wrapChange = change.change;
								if (wrapChange != null) {
									WrapProperty wrapProperty = data.findProperty (wrapChange);
									if (wrapProperty != null) {
										try {
											wrapProperty.processUndo (wrapChange);
										} catch (System.Exception e) {
											Debug.LogError ("processUndo error: " + e);
										}
									} else {
										Debug.LogError ("wrapProperty null: " + this);
									}
								} else {
									Debug.LogError ("wrapChange null: " + this);
								}
								this.pos = i - 1;
								processCount++;
							} else {
								break;
							}
						} else {
							Debug.LogError ("change null: " + this);
							break;
						}
					} else {
						Debug.LogError ("i error: " + i);
						break;
					}
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
			return processCount;
		}

		#endregion

	}
}