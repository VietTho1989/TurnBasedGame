using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WrapContent : UIBehavior<UpdateTransform.UpdateData>
{

	public static void SetAncestorDirty(Transform transform)
	{
		Transform current = transform;
		while (current != null) {
			current = current.parent;
			if (current != null) {
				// wrapContent
				{
					WrapContent wrapContent = current.GetComponent<WrapContent> ();
					if (wrapContent != null) {
						wrapContent.dirty = true;
					} else {
						// Debug.LogError ("wrapContent null: " + this);
					}
				}
				// holder
				{
					SriaHolderInterface holderInterface = current.GetComponent<SriaHolderInterface> ();
					if (holderInterface != null) {
						TransformChange transformChange = holderInterface.getTransformChange ();
						if (transformChange != null) {
							// transformChange.dirty = true;
							// transform
							{
								current.hasChanged = true;
							}
						} else {
							Debug.LogError ("transformChange null: " + transform);
						}
					} else {
						// Debug.LogError ("holderInterface null: " + transform);
					}
				}
			}
		}
	}

	#region Refresh

	public override void refresh ()
	{
		if (transform.hasChanged) {
			transform.hasChanged = false;
			dirty = true;
		}
		if (dirty) {
			// Debug.LogError ("refresh layout: " + this);
			dirty = false;
			SetLayoutHorizontal ();
			SetLayoutVertical ();
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

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	void OnTransformChildrenChanged()
	{
		// Debug.LogError ("OnTransformChildrenChanged: " + this);
		dirty = true;
	}

	void OnTransformParentChanged()
	{
		// Debug.LogError ("OnTransformParentChaned: " + this);
		dirty = true;
	}

	#endregion

	#if UNITY_EDITOR

	void OnValidate()
	{
		// Debug.LogError ("OnValidate called");
		dirty = true;
		this.refresh ();
	}

	#endif

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is UpdateTransform.UpdateData) {
			UpdateTransform.UpdateData updateTransform = data as UpdateTransform.UpdateData;
			{
				updateTransform.update (this.transform);
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UpdateTransform.UpdateData) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is UpdateTransform.UpdateData) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

	[SerializeField] protected float m_PaddingLeft = 0;
	public float paddingLeft {
		get { 
			return m_PaddingLeft; 
		} 
		set { 
			m_PaddingLeft = value;
			dirty = true;
		} 
	}

	[SerializeField] protected float m_PaddingRight = 0;
	public float paddingRight {
		get { 
			return m_PaddingRight; 
		} 
		set { 
			m_PaddingRight = value;
			dirty = true;
		} 
	}

	[SerializeField] protected float m_PaddingTop = 0;
	public float paddingTop {
		get { 
			return m_PaddingTop; 
		} 
		set { 
			m_PaddingTop = value;
			dirty = true;
		} 
	}

	[SerializeField] protected float m_PaddingBottom = 0;
	public float paddingBottom {
		get { 
			return m_PaddingBottom; 
		} 
		set { 
			m_PaddingBottom = value;
			dirty = true;
		} 
	}

	public enum FitMode
	{
		Unconstrained,
		MinSize,
		PreferredSize
	}

	[SerializeField] protected FitMode m_HorizontalFit = FitMode.Unconstrained;
	public FitMode horizontalFit {
		get { 
			return m_HorizontalFit; 
		} 
		set { 
			m_HorizontalFit = value;
			dirty = true;
		} 
	}

	[SerializeField] protected FitMode m_VerticalFit = FitMode.PreferredSize;
	public FitMode verticalFit { 
		get { 
			return m_VerticalFit; 
		}
		set { 
			m_VerticalFit = value;
			dirty = true;
		} 
	}

	[System.NonSerialized] private RectTransform m_Rect;
	protected RectTransform rectTransform
	{
		get
		{
			if (m_Rect == null)
				m_Rect = GetComponent<RectTransform> ();
			return m_Rect;
		}
	}

	public void SetLayoutHorizontal ()
	{
		if (horizontalFit == FitMode.PreferredSize) {
			float minX = float.MaxValue;
			float maxX = float.MinValue;
			for (int i = 0; i < rectTransform.childCount; i++) {
				Transform child = rectTransform.GetChild (i);
				if (child.gameObject.activeInHierarchy) {
					if (child is RectTransform) {
						RectTransform rectChild = (RectTransform)child;
						// min
						{
							float childMinX = -rectChild.anchoredPosition.x;
							if (childMinX < minX) {
								minX = childMinX;
								// Debug.LogError ("minX: " + minX + "; " + rectChild);
							}
						}
						// max
						{
							float childMaxX = rectChild.sizeDelta.x - rectChild.anchoredPosition.x;
							if (childMaxX > maxX) {
								maxX = childMaxX;
								// Debug.LogError ("maxX: " + maxX + "; " + rectChild);
							}
						}
					} else {
						// Debug.LogError ("not rect transform: " + child);
					}
				} else {
					// Debug.LogError ("not active: " + this);
				}
			}
			// Set new size
			if (minX != float.MaxValue && maxX != float.MinValue) {
				// Debug.LogError ("wrapContentSize: horizontal: " + minX + ", " + maxX + ", " + this.gameObject);
				rectTransform.sizeDelta = new Vector2 (maxX - minX + paddingLeft + paddingRight, rectTransform.sizeDelta.y);
			} else {
				// Debug.LogError ("wrong size: " + minX + ", " + maxX + ", " + this.gameObject);
			}
		}
	}

	public void SetLayoutVertical ()
	{
		if (verticalFit == FitMode.PreferredSize) {
			float minY = float.MaxValue;
			float maxY = float.MinValue;
			for (int i = 0; i < rectTransform.childCount; i++) {
				Transform child = rectTransform.GetChild (i);
				if (child.gameObject.activeInHierarchy) {
					if (child is RectTransform) {
						RectTransform rectChild = (RectTransform)child;
						// min
						{
							float childMinY = -rectChild.anchoredPosition.y;
							if (childMinY < minY) {
								minY = childMinY;
								// Debug.LogError ("minY: " + minY + "; " + rectChild);
							}
						}
						// max
						{
							float childMaxY = rectChild.sizeDelta.y - rectChild.anchoredPosition.y;
							if (childMaxY > maxY) {
								maxY = childMaxY;
								// Debug.LogError ("maxY: " + maxY + "; " + rectChild);
							}
						}
					} else {
						// Debug.LogError ("not rect transform: " + child);
					}
				} else {
					// Debug.LogError ("not active: " + this);
				}
			}
			// Set new size
			if (minY != float.MaxValue && maxY != float.MinValue) {
				rectTransform.sizeDelta = new Vector2 (rectTransform.sizeDelta.x, maxY + paddingBottom + paddingTop);
				// Debug.LogError ("sizeDelta: " + rectTransform.sizeDelta);
			} else {
				// Debug.LogError ("wrong size: " + minY + ", " + maxY + ", " + this.gameObject);
			}
		}
	}
}