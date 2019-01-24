using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;

public abstract class SriaHolderBehavior<K> : UIBehavior<K>, SriaHolderInterface where K : BaseItemViewsHolder
{

	public void setHolder(BaseItemViewsHolder holder)
	{
		if (holder is K) {
			this.setData (holder as K);
			refreshSize = true;
		}
	}

	#region Refresh

	public TransformChange transformChange = new TransformChange ();

	public TransformChange getTransformChange()
	{
		return this.transformChange;
	}

	private int oldIndex = 0;
	private bool refreshSize = true;

	public override void refresh ()
	{
		// Check index
		{
			// find index
			int index = 0;
			{
				if (this.data != null) {
					index = this.data.ItemIndex;
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
			if (oldIndex != index) {
				oldIndex = index;
				return;
			}
		}
		// Transform change?
		if (transform.hasChanged) {
			transform.hasChanged = false;
			refreshSize = true;
		}
		// resize
		if (refreshSize) {
			refreshSize = false;
			// wrap
			{
				SetLayoutHorizontal ();
				SetLayoutVertical ();
			}
			// update
			transformChange.updateTransform.update (this.transform);
		}
		// set holder size
		if (transformChange.dirty) {
			transformChange.dirty = false;
			// Find adapter
			if (this.data != null) {
				// Find adapter
				ISRIA adapter = null;
				{
					BaseParams baseParams = this.data.findDataInParent<BaseParams> ();
					if (baseParams != null) {
						// Debug.LogError ("find base params: " + baseParams + "; " + this);
						// find adapter in callBack
						adapter = baseParams.findCallBack<ISRIA> ();
					} else {
						Debug.LogError ("baseParams null: " + this);
					}
				}
				// Process
				if (adapter != null) {
					// Debug.LogError ("adapter not null: " + this);
					if (this.verticalFit == Fit.PreferredSize) {
						float holderSize = transformChange.updateTransform.size.v.y;
						// Debug.LogError ("refreshHolderSize: " + holderSize);
						if (holderSize > 0) {
							adapter.RequestChangeItemSizeAndUpdateLayout (this.data.ItemIndex, holderSize);
						} else {
							Debug.LogError ("holderSize = 0: " + this);
						}
					}
					if (this.horizontalFit == Fit.PreferredSize) {
						float holderSize = transformChange.updateTransform.size.v.x;
						// Debug.LogError ("refreshHolderSize: horizontal" + holderSize);
						if (holderSize > 0) {
							adapter.RequestChangeItemSizeAndUpdateLayout (this.data.ItemIndex, holderSize);
						} else {
							Debug.LogError ("holderSize = 0: " + this);
						}
					}
				} else {
					// Debug.LogError ("adapter null: " + this);
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#if UNITY_EDITOR

	void OnValidate()
	{
		// Debug.LogError ("OnValidate called");
		refreshSize = true;
		this.refresh ();
	}

	#endif

	[SerializeField] protected float m_PaddingLeft = 0;
	public float paddingLeft {
		get { 
			return m_PaddingLeft; 
		} 
		set { 
			m_PaddingLeft = value;
			refreshSize = true;
		} 
	}

	[SerializeField] protected float m_PaddingRight = 0;
	public float paddingRight {
		get { 
			return m_PaddingRight; 
		} 
		set { 
			m_PaddingRight = value;
			refreshSize = true;
		} 
	}

	[SerializeField] protected float m_PaddingTop = 0;
	public float paddingTop {
		get { 
			return m_PaddingTop; 
		} 
		set { 
			m_PaddingTop = value;
			refreshSize = true;
		} 
	}

	[SerializeField] protected float m_PaddingBottom = 0;
	public float paddingBottom {
		get { 
			return m_PaddingBottom; 
		} 
		set { 
			m_PaddingBottom = value;
			refreshSize = true;
		} 
	}

	public enum Fit
	{
		Unconstrained,
		MinSize,
		PreferredSize
	}

	[SerializeField] protected Fit m_HorizontalFit = Fit.Unconstrained;
	public Fit horizontalFit {
		get { 
			return m_HorizontalFit; 
		} 
		set { 
			m_HorizontalFit = value;
			refreshSize = true;
		} 
	}

	[SerializeField] protected Fit m_VerticalFit = Fit.PreferredSize;
	public Fit verticalFit { 
		get { 
			return m_VerticalFit; 
		}
		set { 
			m_VerticalFit = value;
			refreshSize = true;
		} 
	}

	[System.NonSerialized] private RectTransform m_Rect;
	private RectTransform rectTransform
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
		// Debug.LogError ("setLayoutHorizontal");
		// horizontal fit
		if (horizontalFit == Fit.PreferredSize) {
			float minX = float.MaxValue;
			float maxX = float.MinValue;
			for (int i = 0; i < rectTransform.childCount; i++) {
				Transform child = rectTransform.GetChild (i);
				// Debug.LogError ("check child: " + child.gameObject);
				if (child.gameObject.activeInHierarchy && child is RectTransform) {
					RectTransform rectChild = (RectTransform)child;
					// Debug.LogError ("horizontal fit: rectChild: " + rectChild.anchoredPosition + ", " + rectChild.sizeDelta);
					// min
					{
						float childMinX = -rectChild.anchoredPosition.x;
						if (childMinX < minX) {
							minX = childMinX;
						}
					}
					// max
					{
						float childMaxX = rectChild.sizeDelta.x - rectChild.anchoredPosition.x;
						if (childMaxX > maxX) {
							maxX = childMaxX;
						}
					}
				} else {
					// Debug.LogError ("not rect transform: " + child);
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
		// Debug.LogError ("wrapContentSize: " + this.gameObject + ", " + rectTransform.sizeDelta);
	}

	public void SetLayoutVertical ()
	{
		// Debug.LogError ("setLayoutVertical");
		// vertical fit
		if (verticalFit == Fit.PreferredSize) {
			float minY = float.MaxValue;
			float maxY = float.MinValue;
			for (int i = 0; i < rectTransform.childCount; i++) {
				Transform child = rectTransform.GetChild (i);
				// Debug.LogError ("check child: " + child.gameObject);
				if (child.gameObject.activeInHierarchy && child is RectTransform) {
					RectTransform rectChild = (RectTransform)child;
					// Debug.LogError ("vertical fit: rectChild: " + rectChild.gameObject + ", " + rectChild.anchoredPosition + ", " + rectChild.sizeDelta);
					// min
					{
						float childMinY = -rectChild.anchoredPosition.y;
						if (childMinY < minY) {
							minY = childMinY;
							// Debug.LogError ("childMin: " + rectChild.gameObject + ", " + minY);
						}
					}
					// max
					{
						float childMaxY = rectChild.sizeDelta.y - rectChild.anchoredPosition.y;
						if (childMaxY > maxY) {
							maxY = childMaxY;
							// Debug.LogError ("childMax: " + rectChild.gameObject + ", " + maxY);
						}
					}
				} else {
					// Debug.LogError ("not rect transform: " + child);
				}
			}
			// Set new size
			if (minY != float.MaxValue && maxY != float.MinValue) {
				// Debug.LogError ("wrapContentSize: vertical : " + minY + ", " + maxY + ", " + this.gameObject);
				// rectTransform.sizeDelta = new Vector2 (rectTransform.sizeDelta.x, maxY - minY + paddingBottom + paddingTop);
				rectTransform.sizeDelta = new Vector2 (rectTransform.sizeDelta.x, maxY + paddingBottom + paddingTop);
			} else {
				// Debug.LogError ("wrong size: " + minY + ", " + maxY + ", " + this.gameObject);
			}
		}
		// Debug.LogError ("wrapContentSize: " + this.gameObject + ", " + rectTransform.sizeDelta);
	}

	#region WrapContent

	#endregion

}