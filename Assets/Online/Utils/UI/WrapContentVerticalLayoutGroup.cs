using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WrapContentVerticalLayoutGroup : WrapContent
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
			setVerticalLayout ();
			SetLayoutHorizontal ();
			SetLayoutVertical ();
			// center in parent
			if (centerInParentVertical) {
				makeCenterInParentVertical ();
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

	private void setVerticalLayout()
	{
		// Debug.LogError ("setVerticalLayout: " + this);
		float currentY = 0;
		for (int i = 0; i < rectTransform.childCount; i++) {
			Transform child = rectTransform.GetChild (i);
			if (child.gameObject.activeInHierarchy) {
				if (child is RectTransform) {
					RectTransform rectChild = (RectTransform)child;
					rectChild.localPosition = new Vector3 (rectChild.localPosition.x, currentY, rectChild.localPosition.z);
					// change current y
					{
						currentY -= rectChild.rect.height;
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

	public bool centerInParentVertical = false;

	public void makeCenterInParentVertical()
	{
		// Debug.LogError ("makeCenterInParentVertical: " + this);
		if (rectTransform != null) {
			rectTransform.localPosition = new Vector3 (rectTransform.localPosition.x, rectTransform.rect.height/2, rectTransform.localPosition.z);
		} else {
			Debug.LogError ("rectTransform null: " + this);
		}
	}

	#endregion

}