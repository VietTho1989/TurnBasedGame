using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WrapContentHorizontalLayoutGroup : WrapContent
{

	public override void refresh ()
	{
		if (transform.hasChanged) {
			transform.hasChanged = false;
			dirty = true;
		}
		if (dirty) {
			// Debug.LogError ("refresh layout: " + this);
			dirty = false;
			setHorizontalLayout ();
			SetLayoutHorizontal ();
			SetLayoutVertical ();
			// center in parent
			if (centerInParentHorizontal) {
				makeCenterInParentHorizontal ();
			}
			if (this.data != null) {
				Debug.LogError ("update transform wrapContent: " + this.transform + "; " + this);
				this.data.update (this.transform);
			} else {
				// Debug.LogError ("data null: " + this);
			}
			// make ancestor transform update
			SetAncestorDirty(this.transform);
		}
	}

	private void setHorizontalLayout()
	{
		this.horizontalFit = FitMode.PreferredSize;
		this.verticalFit = FitMode.Unconstrained;
		// Debug.LogError ("setVerticalLayout: " + this);
		float currentX = 0;
		for (int i = 0; i < rectTransform.childCount; i++) {
			Transform child = rectTransform.GetChild (i);
			if (child.gameObject.activeInHierarchy) {
				if (child is RectTransform) {
					RectTransform rectChild = (RectTransform)child;
					rectChild.localPosition = new Vector3 (currentX, rectChild.localPosition.y, rectChild.localPosition.z);
					// change current x
					{
						currentX += rectChild.rect.width;
					}
				} else {
					// Debug.LogError ("not rect transform: " + child);
				}
			} else {
				// Debug.LogError ("not active: " + this);
			}
		}
	}

	#region center in parent vertical

	public bool centerInParentHorizontal = false;

	public void makeCenterInParentHorizontal()
	{
		// Debug.LogError ("makeCenterInParentVertical: " + this);
		if (rectTransform != null) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x / 2, rectTransform.rect.height, rectTransform.localPosition.z);
		} else {
			Debug.LogError ("rectTransform null: " + this);
		}
	}

	#endregion

}