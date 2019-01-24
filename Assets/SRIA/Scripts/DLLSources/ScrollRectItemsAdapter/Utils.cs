using frame8.Logic.Misc.Other.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
    public static class Utils
	{
		/// <summary>Returns the delta reported in the <see cref="PointerEventData"/></summary>
		public static Vector2? ForceSetPointerEventDistanceToZero(GameObject pointerDragGOToLookFor, bool throwExceptionIfNoModule)
		{
			var pointer = GetPointerEventDataWithPointerDragGO(pointerDragGOToLookFor, throwExceptionIfNoModule);
			if (pointer == null)
				return null;

			// Modify the original pointer to look like it was pressed at the current position and it didn't move
			//PointerEventData originalPED = null;
			Debug.Log("delta="+pointer.delta + ", scrollDelta=" + pointer.scrollDelta + ", dragging=" + pointer.dragging + ", pressPosition=" + pointer.pressPosition + ", position=" + pointer.position);
			//pointer.pointerPressRaycast = pointer.pointerCurrentRaycast;
			//pointer.pressPosition = pointer.position;
			var delta = pointer.delta;
			//pointer.delta = Vector2.zero;
			pointer.dragging = false;
			//pointer.scrollDelta = Vector2.zero;

			//// TODO test
			////pointer.Use();
			////originalPED = pointer;

			//break;
			return delta;
		}

		public static PointerEventData GetPointerEventDataWithPointerDragGO(GameObject pointerDragGOToLookFor, bool throwExceptionIfNoModule)
		{
			if (!(EventSystem.current.currentInputModule is PointerInputModule))
			{
				if (throwExceptionIfNoModule)
					throw new InvalidOperationException("currentInputModule is not a PointerInputModule");
				return null;
			}

			// Dig into reflection and get the original pointer data
			var eventSystemAsPointerInputModule = (EventSystem.current.currentInputModule as PointerInputModule);
			var pointerEvents = eventSystemAsPointerInputModule
				.GetType()
				.GetField("m_PointerData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
				.GetValue(eventSystemAsPointerInputModule)
				as Dictionary<int, PointerEventData>;

			foreach (var pointer in pointerEvents.Values)
				if (pointer.pointerDrag == pointerDragGOToLookFor)
					return pointer;

			return null;
		}

		public static Color GetRandomColor(bool fullAlpha = false)
		{ return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), fullAlpha ? 1f : UnityEngine.Random.Range(0f, 1f)); }
	}
}
