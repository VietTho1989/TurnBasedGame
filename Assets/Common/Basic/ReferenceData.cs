using UnityEngine;
using System.Collections;

/**
 * ReferenceData chi nen danh cho data hoan toan ko co moi lien he gi ca: ko the co cung ancestor
 * */
public class ReferenceData<T> : AddCallBackInterface
{

	public T data;

	public ReferenceData(T data)
	{
		this.data = data;
	}

	#region implement addCallBackInterface

	public void addCallBack (ValueChangeCallBack callBack)
	{
		if (Generic.IsAddCallBackInterface<T>()) {
			if (this.data != null) {
				((AddCallBackInterface)this.data).addCallBack (callBack);
			} else {
				// Debug.LogError ("data null: " + this);
			}
		} else {
			Debug.LogError ("why not data: " + this);
		}
	}

	public void removeCallBack (ValueChangeCallBack callBack, bool isHide = false)
	{
		if (Generic.IsAddCallBackInterface<T>()) {
			if (this.data != null) {
				((AddCallBackInterface)this.data).removeCallBack (callBack);
			} else {
				// Debug.LogError ("data null: " + this);
			}
		} else {
			Debug.LogError ("why not data: " + this);
		}
	}

	#endregion

	public override bool Equals (object obj)
	{
		if (obj!=null && obj is ReferenceData<T>) {
			ReferenceData<T> other = obj as ReferenceData<T>;
			return object.Equals (this.data, other.data);
		} else {
			return false;
		}
	}

	public override int GetHashCode ()
	{
		if (this.data != null) {
			return this.data.GetHashCode ();
		} else {
			return 0;
		}
	}

}