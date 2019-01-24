using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpdateTransform : UpdateBehavior<UpdateTransform.UpdateData>
{

	#region UpdateData

	public class UpdateData : Data
	{
		public VP<Vector3> position;

		public VP<Quaternion> rotation;

		public VP<Vector3> scale;

		public VP<Vector2> size;

		#region Constructor

		public enum Property
		{
			position,
			rotation,
			scale,
			size
		}

		public UpdateData() : base()
		{
			this.position = new VP<Vector3>(this, (byte)Property.position, new Vector3());
			this.rotation = new VP<Quaternion>(this, (byte)Property.rotation, new Quaternion());
			this.scale = new VP<Vector3>(this, (byte)Property.scale, new Vector3());
			this.size = new VP<Vector2>(this, (byte)Property.size, new Vector2());
		}

		#endregion

		public void update(Transform transform)
		{
			this.position.v = transform.localPosition;
			this.rotation.v = transform.localRotation;
			this.scale.v = transform.localScale;
			// Size
			{
				if (transform is RectTransform) {
					RectTransform rectTransform = transform as RectTransform;
					this.size.v = new Vector2 (rectTransform.rect.width, rectTransform.rect.height);
				} else {
					Debug.LogError ("why not rectTransform: " + this);
					this.size.v = new Vector2 (0, 0);
				}
			}
		}

	}

	#endregion

	#region update

	public override void update ()
	{
		if (dirty || transform.hasChanged) {
			transform.hasChanged = false;
			dirty = false;
			if (this.data != null) {
				this.data.update (this.transform);
				// Debug.LogError ("updateTransform new position: " + this.data.position.v + "; " + this.data.size.v);
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

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is UpdateData) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UpdateData) {
			UpdateData updateData = data as UpdateData;
			{

			}
			this.setDataNull (updateData);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UpdateData) {
			// Debug.LogError ("have change: " + wrapProperty + "; " + syncs + "; " + this);
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}