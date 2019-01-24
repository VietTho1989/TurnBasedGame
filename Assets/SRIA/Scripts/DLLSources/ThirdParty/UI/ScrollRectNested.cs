using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

namespace frame8.ThirdParty.UI
{
	/// <summary>
	/// ScrollRect that supports being nested inside another ScrollRect.
	/// BASED ON: https://forum.unity3d.com/threads/nested-scrollrect.268551/#post-1906953
	/// </summary>
	public class ScrollRectNested : ScrollRect
	{
		ScrollRect _ParentScrollRect;
		bool _RouteToParent = false;

		protected override void Start()
		{
			base.Start();

			//if (!Application.isPlaying)
			//	return;

			var p = transform;
			while (!_ParentScrollRect && (p = p.parent))
				_ParentScrollRect = p.GetComponent<ScrollRect>();
		}


		public override void OnInitializePotentialDrag(PointerEventData eventData)
		{
			// Always route initialize potential drag event to parent
			if (_ParentScrollRect)
				((IInitializePotentialDragHandler)_ParentScrollRect).OnInitializePotentialDrag(eventData);
			base.OnInitializePotentialDrag(eventData);
		}

		public override void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
		{
			if (!horizontal && Math.Abs(eventData.delta.x) > Math.Abs(eventData.delta.y))
				_RouteToParent = true;
			else if (!vertical && Math.Abs(eventData.delta.x) < Math.Abs(eventData.delta.y))
				_RouteToParent = true;
			else
				_RouteToParent = false;

			if (_RouteToParent)
			{
				if (_ParentScrollRect)
					((IBeginDragHandler)_ParentScrollRect).OnBeginDrag(eventData);
			}
			else
				base.OnBeginDrag(eventData);
		}

		public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
		{
			if (_RouteToParent)
			{
				if (_ParentScrollRect)
					((IDragHandler)_ParentScrollRect).OnDrag(eventData);
			}
			else
				base.OnDrag(eventData);
		}

		public override void OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
		{
			if (_RouteToParent)
			{
				if (_ParentScrollRect)
					((IEndDragHandler)_ParentScrollRect).OnEndDrag(eventData);
			}
			else
				base.OnEndDrag(eventData);
			_RouteToParent = false;
		}
	}
}