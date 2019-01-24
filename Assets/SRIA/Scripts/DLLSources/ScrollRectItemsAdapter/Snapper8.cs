using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using frame8.Logic.Misc.Other.Extensions;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using UnityEngine.EventSystems;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
	/// <summary>
	/// Script that enables snapping on a ScrollRect. It's used in conjuction with a <see cref="SRIA{TParams, TItemViewsHolder}"/>. Attach it to the ScrollRect game object.
	/// </summary>
	public class Snapper8 : MonoBehaviour
	{
		public float snapWhenSpeedFallsBelow = 50f;
		public float viewportSnapPivot01 = .5f;
		public float itemSnapPivot01 = .5f;
		//public float snapOnlyIfSpeedIsAbove = 20f;
		public float snapDuration = .3f;
		public float snapAllowedError = 1f;
		//[Tooltip("This will be disabled during snapping animation")]
		public Scrollbar scrollbar;

		public event Action SnappingStarted;
		public event Action SnappingEndedOrCancelled;

		/// <summary>This needs to be set externally</summary>
		public ISRIA Adapter
		{
			set
			{
				if (_Adapter == value)
					return;

				if (_Adapter != null)
					_Adapter.ScrollPositionChanged -= OnScrolled;
				_Adapter = value;
				if (_Adapter != null)
					_Adapter.ScrollPositionChanged += OnScrolled;
			}
		}
		public bool SnappingInProgress { get; private set; }

		bool IsPointerDraggingOnScrollRect { get { return _ScrollRect != null && Utils.GetPointerEventDataWithPointerDragGO(_ScrollRect.gameObject, false) != null; } }
		bool IsPointerDraggingOnScrollbar { get { return scrollbar != null && Utils.GetPointerEventDataWithPointerDragGO(scrollbar.gameObject, false) != null; } }

		ISRIA _Adapter;
		ScrollRect _ScrollRect;
		bool _SnappingDoneAndEndSnappingEventPending;
		bool _SnapNeeded; // a new snap will only start if after the las snap the scrollrect's scroll position has changed
		bool _SnappingCancelled;
		//bool _PointerDown;


		void Start()
		{
			_ScrollRect = GetComponent<ScrollRect>();
			//_ScrollRect.onValueChanged.AddListener(OnScrolled);

			if (scrollbar)
				scrollbar.onValueChanged.AddListener(OnScrollbarValueChanged);
		}

		void OnDisable() { CancelSnappingIfInProgress(); }

		void OnDestroy()
		{
			if (scrollbar)
				scrollbar.onValueChanged.RemoveListener(OnScrollbarValueChanged);
			//if (_ScrollRect)
			//	_ScrollRect.onValueChanged.RemoveListener(OnScrolled);

			if (_Adapter != null)
				_Adapter.ScrollPositionChanged -= OnScrolled;

			SnappingStarted = null;
			SnappingEndedOrCancelled = null;
		}

		internal void CancelSnappingIfInProgress()
		{
			_SnappingDoneAndEndSnappingEventPending = false;
			_SnapNeeded = false;

			//Debug.Log("cancel: inProg=" + SnappingInProgress);
			if (!SnappingInProgress)
				return;

			_SnappingCancelled = true;
			SnappingInProgress = false;
		}

		internal void StartSnappingIfNeeded()
		{
			// Disabling the script should make it unoperable
			if (!enabled)
				return;

			if (_SnappingDoneAndEndSnappingEventPending)
			{
				OnSnappingEndedOrCancelled();
				return;
			}

			if (_Adapter == null)
				return;

			//Debug.Log("SnappingInProgress=" + SnappingInProgress + ", _SnapNeeded=" + _SnapNeeded + ", magnitude=" + _ScrollRect.velocity.magnitude + ", IsPointerDraggingOnScrollRect=" + IsPointerDraggingOnScrollRect + ", IsPointerDraggingOnScrollbar=" + IsPointerDraggingOnScrollbar);
			if (SnappingInProgress || !_SnapNeeded || _ScrollRect.velocity.magnitude >= snapWhenSpeedFallsBelow || IsPointerDraggingOnScrollRect || IsPointerDraggingOnScrollbar)
				return;

			if (_Adapter.ContentVirtualInsetFromViewportStart >= 0d || _Adapter.ContentVirtualInsetFromViewportEnd >= 0d) // Content is at end => don't force any snapping
				return;

			float distanceToTarget;
			var middle = _Adapter.GetViewsHolderOfClosestItemToViewportPoint(viewportSnapPivot01, itemSnapPivot01, out distanceToTarget);
			//if (middle == null)
			//	Debug.Log("null");
			if (middle == null)
				return;

			int curIndex = middle.ItemIndex;
			//string s = "ci="+ curIndex + ", d="+ distanceToTarget;
			_SnapNeeded = false;
			if (distanceToTarget <= snapAllowedError)
				return;

			//Debug.Log("start: " + s);
			_SnappingCancelled = false;
			bool cancelledOrEnded = false; // used to check if the scroll was cancelled immediately after calling SmoothScrollTo (i.e. without first setting SnappingInProgress = true)
			_Adapter.SmoothScrollTo(
				curIndex,
				snapDuration,
				viewportSnapPivot01,
				itemSnapPivot01,
				progress =>
				{
					bool continuteAnimation = true;
					if (progress == 1f || _SnappingCancelled || IsPointerDraggingOnScrollRect || IsPointerDraggingOnScrollbar) // done. last iteration
					{
						cancelledOrEnded = true;
						continuteAnimation = false;

						//Debug.Log("received end callback: SnappingInProgress=" + SnappingInProgress);
						if (SnappingInProgress)
						{
							SnappingInProgress = false;
							_SnappingDoneAndEndSnappingEventPending = true;
						}
					}

					// If the items were refreshed while the snap animation was playing or if the user touched the scrollview, don't continue;
					return continuteAnimation;
				},
				true
			);

			// The scroll was cancelled immediately after calling SmoothScrollTo => cancel
			if (cancelledOrEnded)
				return;

			SnappingInProgress = true; //always true, because we're overriding the previous scroll

			if (SnappingInProgress)
				OnSnappingStarted();
		}

		//void OnScrolled(Vector2 _) { if (!SnappingInProgress) _SnapNeeded = true; }
		void OnScrolled(float _) { if (!SnappingInProgress) _SnapNeeded = true; } // from adapter
		void OnScrollbarValueChanged(float _) { if (IsPointerDraggingOnScrollbar) CancelSnappingIfInProgress(); } // from scrollbar

		void OnSnappingStarted()
		{
			//Debug.Log("start");
			//if (scrollbar)
			//	scrollbar.interactable = false;

			if (SnappingStarted != null)
				SnappingStarted();
		}

		void OnSnappingEndedOrCancelled()
		{
			//Debug.Log("end");
			//if (scrollbar)
			//	scrollbar.interactable = true;

			_SnappingDoneAndEndSnappingEventPending = false;

			if (SnappingEndedOrCancelled != null)
				SnappingEndedOrCancelled();
		}
	}
}
