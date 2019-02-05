using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransformChange : ValueChangeCallBack
{

	public TransformData updateTransform = new TransformData ();

	public bool dirty = true;

	public TransformChange() : base()
	{
		this.updateTransform.addCallBack(this);
	}

	#region implement callBacks

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is TransformData) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is TransformData) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is TransformData) {
			switch ((TransformData.Property)wrapProperty.n) {
			case TransformData.Property.position:
				dirty = true;
				break;
			case TransformData.Property.rotation:
				dirty = true;
				break;
			case TransformData.Property.scale:
				dirty = true;
				break;
			case TransformData.Property.size:
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