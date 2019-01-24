using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformChange : ValueChangeCallBack
{

	public UpdateTransform.UpdateData updateTransform = new UpdateTransform.UpdateData ();

	public bool dirty = true;

	public TransformChange() : base()
	{
		this.updateTransform.addCallBack(this);
	}

	#region implement callBacks

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is UpdateTransform.UpdateData) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is UpdateTransform.UpdateData) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UpdateTransform.UpdateData) {
			switch ((UpdateTransform.UpdateData.Property)wrapProperty.n) {
			case UpdateTransform.UpdateData.Property.position:
				dirty = true;
				break;
			case UpdateTransform.UpdateData.Property.rotation:
				dirty = true;
				break;
			case UpdateTransform.UpdateData.Property.scale:
				dirty = true;
				break;
			case UpdateTransform.UpdateData.Property.size:
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