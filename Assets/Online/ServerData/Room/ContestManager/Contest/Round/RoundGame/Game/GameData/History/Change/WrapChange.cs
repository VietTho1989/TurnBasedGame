using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class WrapChange : HistoryChange
{
	/** ParentInfo*/
	public VP<List<Data.SI>> pi;
	/** variableName*/
	public VP<byte> vn;

	#region Content

	public object syncsObject = null;

	public void setSyncsObject<T>(List<Sync<T>> syncs)
	{
		this.syncsObject = syncs;
		// make strSyncs
		{
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					writer.Write (syncs.Count);
					foreach (Sync<T> sync in syncs) {
						writer.Write ((int)sync.getType ());
						sync.makeBinary (writer);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			this.syncs.v = byteArray;
			// Debug.LogError ("setSyncs: " + byteArray.Length + "; " + this + "; " + GameUtils.Utils.FormatBytes (byteArray));
		}
	}

	public VP<byte[]> syncs;

	public List<Sync<T>> getSyncs<T>()
	{
		if (this.syncsObject != null && this.syncsObject is List<Sync<T>>) {
			return (List<Sync<T>>)this.syncsObject;
		} else {
			List<Sync<T>> syncs = new List<Sync<T>> ();
			{
				byte[] byteArray = this.syncs.v;
				// Debug.LogError ("getSyncs: " + byteArray.Length + "; " + GameUtils.Utils.FormatBytes (byteArray));
				// make reader
				Stream stream = new MemoryStream(byteArray);
				using (BinaryReader reader = new BinaryReader (stream)) {
					int count = reader.ReadInt32();
					for (int i = 0; i < count; i++) {
						int type = reader.ReadInt32();
						switch ((Sync<T>.Type)type) {
						case Sync<T>.Type.Set:
							{
								SyncSet<T> syncSet = new SyncSet<T> ();
								{
									syncSet.parse (reader);
								}
								syncs.Add (syncSet);
							}
							break;
						case Sync<T>.Type.Add:
							{
								SyncAdd<T> syncAdd = new SyncAdd<T> ();
								{
									syncAdd.parse (reader);
								}
								syncs.Add (syncAdd);
							}
							break;
						case Sync<T>.Type.Remove:
							{
								SyncRemove<T> syncRemove = new SyncRemove<T> ();
								{
									syncRemove.parse (reader);
								}
								syncs.Add (syncRemove);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + type + "; " + this);
							break;
						}
					}
				}
			}
			syncsObject = syncs;
			return syncs;
		}
	}

	#endregion

	#region Constructor

	public enum Property
	{
		pi,
		vn,
		syncs
	}

	public WrapChange() : base()
	{
		this.pi = new VP<List<SI>> (this, (byte)Property.pi, new List<Data.SI> ());
		this.vn = new VP<byte> (this, (byte)Property.vn, 0);
		this.syncs = new VP<byte[]> (this, (byte)Property.syncs, new byte[0]);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Wrap;
	}

}