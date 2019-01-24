using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using UnityEngine.EventSystems;

namespace frame8.ScrollRectItemsAdapter.Util
{
	public class RectTransformEdgeDragger : MonoBehaviour, IDragHandler, IPointerDownHandler
	{
		public event Action TargetDragged;

		public RectTransform draggedRectTransform;
		public RectTransform.Edge draggedEdge;
		public float maxDistance = 100;

		RectTransform rt;
		Vector2 startDragPos;
		Vector2 initialPos;
		float startInset;
		float startSize;


		void Awake()
		{
			rt = (transform as RectTransform);
		}

		void Start()
		{
			initialPos = rt.position;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			startDragPos = transform.position;
			startInset = draggedRectTransform.GetInsetFromParentEdge(draggedRectTransform.parent as RectTransform, draggedEdge);

			if (draggedEdge == RectTransform.Edge.Left || draggedEdge == RectTransform.Edge.Right)
				startSize = draggedRectTransform.rect.width;
			else
				startSize = draggedRectTransform.rect.height;
		}

		public void OnDrag(PointerEventData ped)
		{
			var dragVector = ped.position - ped.pressPosition;

			var rtNewPos = startDragPos;
			float amount;
			float rectMoveAmount;
			if (draggedEdge == RectTransform.Edge.Left || draggedEdge == RectTransform.Edge.Right)
			{
				amount = dragVector.x;
				rtNewPos.x += amount;

				rectMoveAmount = rtNewPos.x - initialPos.x;
				if (Mathf.Abs(rectMoveAmount) > maxDistance)
					return;
			}
			else
			{
				amount = dragVector.y;
				rtNewPos.y += amount;

				rectMoveAmount = rtNewPos.y - initialPos.y;
				if (Mathf.Abs(rectMoveAmount) > maxDistance)
					return;
			}

			rt.position = rtNewPos;

			draggedRectTransform.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(draggedEdge, startInset + amount, startSize - amount);

			if (TargetDragged != null)
				TargetDragged();
		}
	}
}
