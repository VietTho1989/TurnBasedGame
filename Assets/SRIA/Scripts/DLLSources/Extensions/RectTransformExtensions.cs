using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace frame8.Logic.Misc.Other.Extensions
{
    public static class RectTransformExtensions
	{
		static Dictionary<RectTransform.Edge, Func<RectTransform, RectTransform, float>> _GetInsetFromParentEdge_MappedActions =
			new Dictionary<RectTransform.Edge, Func<RectTransform, RectTransform, float>>()
		{
			{ RectTransform.Edge.Bottom, GetInsetFromParentBottomEdge },
			{ RectTransform.Edge.Top, GetInsetFromParentTopEdge },
			{ RectTransform.Edge.Left, GetInsetFromParentLeftEdge },
			{ RectTransform.Edge.Right, GetInsetFromParentRightEdge }
		};

		static Dictionary<RectTransform.Edge, Action<RectTransform, RectTransform, float, float>> _SetInsetAndSizeFromParentEdgeWithCurrentAnchors_MappedActions =
			new Dictionary<RectTransform.Edge, Action<RectTransform, RectTransform, float, float>>()
		{
			{
				RectTransform.Edge.Bottom,
				(child, parentHint, newInset, newSize) => {
					var offsetChange = newInset - child.GetInsetFromParentBottomEdge(parentHint);
					var offsetMin = new Vector2(child.offsetMin.x, child.offsetMin.y + offsetChange); // need to store it before modifying anything, because the offsetmax will change the offsetmin and vice-versa
					child.offsetMax = new Vector2(child.offsetMax.x, child.offsetMax.y + (newSize - child.rect.height + offsetChange));
					child.offsetMin = offsetMin;
				}
			},
			{
				RectTransform.Edge.Top,
				(child, parentHint, newInset, newSize) => {
					var offsetChange = newInset - child.GetInsetFromParentTopEdge(parentHint);
					var offsetMax = new Vector2(child.offsetMax.x, child.offsetMax.y - offsetChange);
					child.offsetMin = new Vector2(child.offsetMin.x, child.offsetMin.y - (newSize - child.rect.height + offsetChange));
					child.offsetMax = offsetMax;
				}
			},
			{
				RectTransform.Edge.Left,
				(child, parentHint, newInset, newSize) => {
					var offsetChange = newInset - child.GetInsetFromParentLeftEdge(parentHint);
					var offsetMin = new Vector2(child.offsetMin.x + offsetChange, child.offsetMin.y);
					child.offsetMax = new Vector2(child.offsetMax.x + (newSize - child.rect.width + offsetChange), child.offsetMax.y);
					child.offsetMin = offsetMin;
				}
			},
			{
				RectTransform.Edge.Right,
				(child, parentHint, newInset, newSize) => {
					var offsetChange = newInset - child.GetInsetFromParentRightEdge(parentHint);
					var offsetMax = new Vector2(child.offsetMax.x - offsetChange, child.offsetMax.y);
					child.offsetMin = new Vector2(child.offsetMin.x - (newSize - child.rect.width + offsetChange), child.offsetMin.y);
					child.offsetMax = offsetMax;
				}
			}
		};


		/// <summary> GetTop(), GetRight() etc. only work if there's no canvas scaling</summary>
		public static float GetWorldTop(this RectTransform rt)
        { return rt.position.y + (1f - rt.pivot.y) * rt.rect.height; }

        public static float GetWorldBottom(this RectTransform rt)
        { return rt.position.y - rt.pivot.y * rt.rect.height; }

        public static float GetWorldLeft(this RectTransform rt)
        { return rt.position.x - rt.pivot.x * rt.rect.width; }

        public static float GetWorldRight(this RectTransform rt)
        { return rt.position.x + (1f - rt.pivot.x) * rt.rect.width; }

		//// Vertically (y), 0=bottom, 1=top
		//// Horizontally (x), 0=left, 1=right
		//public static Vector2 GetWorldSignedDistanceBetweenCustomPivots(
		//	this RectTransform rt, 
		//	float customPivotOnThisRect01, 
		//	RectTransform other, 
		//	float customPivotOnOtherRect01
		//){
		//	var result = new Vector2();
		//	var thisRect = rt.rect;
		//	var otherRect = other.rect;

		//	// Horizontal distance
		//	float pointOnThisRect_WorldSpace = rt.GetWorldRight() - (1f - customPivotOnThisRect01) * thisRect.width;
		//	float pointOnOtherRect_WorldSpace = other.GetWorldRight() - (1f - customPivotOnOtherRect01) * otherRect.width;
		//	result.x = pointOnOtherRect_WorldSpace - pointOnThisRect_WorldSpace;

		//	// Vertical distance
		//	pointOnThisRect_WorldSpace = rt.GetWorldTop() - (1f - customPivotOnThisRect01) * thisRect.height;
		//	pointOnOtherRect_WorldSpace = other.GetWorldTop() - (1f - customPivotOnOtherRect01) * otherRect.height;
		//	result.y = pointOnOtherRect_WorldSpace - pointOnThisRect_WorldSpace;

		//	return result;
		//}

		public static float GetWorldSignedHorDistanceBetweenCustomPivots(
			this RectTransform rt,
			float customPivotOnThisRect01,
			RectTransform other,
			float customPivotOnOtherRect01
		){
			// Horizontal distance
			float pointOnThisRect_WorldSpace = rt.GetWorldRight() - (1f - customPivotOnThisRect01) * rt.rect.width;
			float pointOnOtherRect_WorldSpace = other.GetWorldRight() - (1f - customPivotOnOtherRect01) * other.rect.width;
			return pointOnOtherRect_WorldSpace - pointOnThisRect_WorldSpace;
		}

		public static float GetWorldSignedVertDistanceBetweenCustomPivots(
			this RectTransform rt,
			float customPivotOnThisRect01,
			RectTransform other,
			float customPivotOnOtherRect01
		){
			// Vertical distance
			float pointOnThisRect_WorldSpace = rt.GetWorldTop() - (1f - customPivotOnThisRect01) * rt.rect.height;
			float pointOnOtherRect_WorldSpace = other.GetWorldTop() - (1f - customPivotOnOtherRect01) * other.rect.height;
			return pointOnOtherRect_WorldSpace - pointOnThisRect_WorldSpace;
		}

		/// <summary>
		/// It assumes the transform has a parent
		/// </summary>
		/// <param name="child"></param>
		/// <param name="parentHint"> the parent of child. used in order to prevent casting, in case the caller already has the parent stored in a variable</param>
		/// <returns></returns>
		public static float GetInsetFromParentTopEdge(this RectTransform child, RectTransform parentHint)
        {
            float parentPivotYDistToParentTop = (1f - parentHint.pivot.y) * parentHint.rect.height;
            float childLocPosY = child.localPosition.y;

            return parentPivotYDistToParentTop - child.rect.yMax - childLocPosY;
        }

        public static float GetInsetFromParentBottomEdge(this RectTransform child, RectTransform parentHint)
        {
            float parentPivotYDistToParentBottom = parentHint.pivot.y * parentHint.rect.height;
            float childLocPosY = child.localPosition.y;

            return parentPivotYDistToParentBottom + child.rect.yMin + childLocPosY;
        }

        public static float GetInsetFromParentLeftEdge(this RectTransform child, RectTransform parentHint)
        {
            float parentPivotXDistToParentLeft = parentHint.pivot.x * parentHint.rect.width;
            float childLocPosX = child.localPosition.x;

            return parentPivotXDistToParentLeft + child.rect.xMin + childLocPosX;
        }

        public static float GetInsetFromParentRightEdge(this RectTransform child, RectTransform parentHint)
        {
            float parentPivotXDistToParentRight = (1f - parentHint.pivot.x) * parentHint.rect.width;
            float childLocPosX = child.localPosition.x;

            return parentPivotXDistToParentRight - child.rect.xMax - childLocPosX;
        }


        public static float GetInsetFromParentEdge(this RectTransform child, RectTransform parentHint, RectTransform.Edge parentEdge)
		{ return _GetInsetFromParentEdge_MappedActions[parentEdge](child, parentHint); }

        // Assumes the child has a parent
        //public static void SetSizeWithCurrentAnchorsAndFixedEdge(this RectTransform child, RectTransform.Edge fixedEdge, float newSize)
        //{
        //    child.SetInsetAndSizeWithCurrentAnchorsAndFixedEdge(fixedEdge, child.GetInsetFromParentEdge(child.parent as RectTransform, fixedEdge), newSize);
        //}

        //public static void SetInsetAndSizeFromParentEdgeWithCurrentAnchors(this RectTransform child, RectTransform.Edge fixedEdge, float inset, float newSize)
        //{
        //    Vector2 anchorMin = child.anchorMin;
        //    Vector2 anchorMax = child.anchorMax;
        //    child.SetInsetAndSizeFromParentEdge(fixedEdge, inset, newSize);
        //    child.anchorMin = anchorMin;
        //    child.anchorMax = anchorMax;
        //}

        /// <summary> NOTE: Use the optimized version if parent is known </summary>
        public static void SetSizeFromParentEdgeWithCurrentAnchors(this RectTransform child, RectTransform.Edge fixedEdge, float newSize)
        {
            var par = child.parent as RectTransform;
            child.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(par, fixedEdge, child.GetInsetFromParentEdge(par, fixedEdge), newSize);
        }

        /// <summary> Optimized version of SetSizeFromParentEdgeWithCurrentAnchors(RectTransform.Edge fixedEdge, float newSize) when parent is known </summary>
        /// <param name="parentHint"></param>
        /// <param name="fixedEdge"></param>
        /// <param name="newSize"></param>
        public static void SetSizeFromParentEdgeWithCurrentAnchors(this RectTransform child, RectTransform parentHint, RectTransform.Edge fixedEdge, float newSize)
        {
            child.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(parentHint, fixedEdge, child.GetInsetFromParentEdge(parentHint, fixedEdge), newSize);
        }

        /// <summary> NOTE: Use the optimized version if parent is known </summary>
        /// <param name="fixedEdge"></param>
        /// <param name="newInset"></param>
        /// <param name="newSize"></param>
        public static void SetInsetAndSizeFromParentEdgeWithCurrentAnchors(this RectTransform child, RectTransform.Edge fixedEdge, float newInset, float newSize)
        {
            child.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(child.parent as RectTransform, fixedEdge, newInset, newSize);
        }

		/// <summary> Optimized version of SetInsetAndSizeFromParentEdgeWithCurrentAnchors(RectTransform.Edge fixedEdge, float newInset, float newSize) when parent is known </summary>
		/// <param name="parentHint"></param>
		/// <param name="fixedEdge"></param>
		/// <param name="newInset"></param>
		/// <param name="newSize"></param>
		public static void SetInsetAndSizeFromParentEdgeWithCurrentAnchors(this RectTransform child, RectTransform parentHint, RectTransform.Edge fixedEdge, float newInset, float newSize)
        { _SetInsetAndSizeFromParentEdgeWithCurrentAnchors_MappedActions[fixedEdge](child, parentHint, newInset, newSize); }



		public static void MatchParentSize(this RectTransform rt)
		{
			rt.anchorMin = Vector2.zero;
			rt.anchorMax = Vector2.one;
			rt.sizeDelta = Vector3.zero; // same size as anchors
			rt.pivot = Vector2.one * .5f; // center pivot
			rt.anchoredPosition = Vector3.zero; // centered at the anchors' center
		}
	}
}
