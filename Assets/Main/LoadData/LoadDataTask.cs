using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class LoadDataTask : UpdateBehavior<LoadDataTask.TaskData>
{

	#region TaskData

	public class TaskData : Data
	{

		public Save save = null;

		public FileInfo file = null;

		#region State

		public enum State
		{
			None,
			Load,
			Success,
			Fail
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			state
		}

		public TaskData() : base()
		{
			this.state = new VP<State>(this, (byte)Property.state, State.None);
		}

		#endregion

	}

	#endregion

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case TaskData.State.None:
					{
						destroyRoutine (loadRoutine);
					}
					break;
				case TaskData.State.Load:
					{
						startRoutine (ref this.loadRoutine, TaskLoad ());
					}
					break;
				case TaskData.State.Success:
					{
						destroyRoutine (loadRoutine);
					}
					break;
				case TaskData.State.Fail:
					{
						destroyRoutine (loadRoutine);
					}
					break;
				default:
					Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region Routine Load

	private Routine loadRoutine;

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (loadRoutine);
		}
		return ret;
	}

	public IEnumerator TaskLoad()
	{
		if (this.data != null) {
			bool success = false;
			// Task
			{
				var mtask = UnityTask.Run (() => { 
					{
						try{
							if(this.data!=null){
								if (this.data.file != null && this.data.file.Exists) {
									// Get bytes
									byte[] bytes = File.ReadAllBytes (this.data.file.FullName);
									byte[] outBytes = null;
									// Decompress
									if (lbz2.bz2DecompressBuffer (bytes, ref outBytes, true) == 0) {
										Debug.LogError ("decompress sucess: " + bytes.Length + ", " + outBytes.Length);
										// make save
										{
											using(BinaryReader reader = new BinaryReader(new MemoryStream(outBytes))){
												this.data.save = Save.parse(reader);
											}
										}
										// finish
										if(this.data.save!=null){
											success = true;
										}else{
											Debug.LogError("save null: "+this);
										}
									} else {
										Debug.LogError ("decompress fail");
									}
								} else {
									Debug.LogError ("file null");
								}
							}else{
								Debug.LogError("data null: "+this);
							}
						}catch(Exception e){
							Debug.LogError ("Error: " + e);
						}
					}
				});
				// Wait
				{
					while (!mtask.IsCompleted) {
						yield return new Wait ();
					}
					// yield return mtask;
					if (mtask.IsFaulted) {
						Debug.LogException (mtask.Exception);
					}
				}
			}
			// Process
			if (success) {
				Debug.LogError ("load success");
				this.data.state.v = TaskData.State.Success;
			} else {
				Debug.LogError ("load fail");
				this.data.state.v = TaskData.State.Fail;
			}
		} else {
			Debug.LogError ("inputData null");
		}
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is TaskData) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is TaskData) {
			TaskData taskData = data as TaskData;
			// Child
			{

			}
			this.setDataNull (taskData);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is TaskData) {
			switch ((TaskData.Property)wrapProperty.n) {
			case TaskData.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}