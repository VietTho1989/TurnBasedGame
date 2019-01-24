using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

using frame8.Logic.Misc.Other.Extensions;
using frame8.Logic.Misc.Visual.UI.MonoBehaviours;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
	public abstract partial class SRIA<TParams, TItemViewsHolder> : UIBehavior<TParams>, ISRIA where TParams : BaseParams where TItemViewsHolder : BaseItemViewsHolder
	{
		
		IEnumerator SmoothScrollProgressCoroutine(int itemIndex,  float duration, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f, Func<float, bool> onProgress = null)
		{
			//Debug.Log("Started routine");
			double minContentVirtualInsetFromVPAllowed = -_InternalState.VirtualScrollableArea;
			// Positive values indicate CT is smaller than VP, so no scrolling can be done
			if (minContentVirtualInsetFromVPAllowed >= 0d)
			{
				// This is dependent on the case. sometimes is needed, sometimes not
				//if (duration > 0f)
				//    yield return new WaitForSeconds(duration);

				_SmoothScrollCoroutine = null;

				if (onProgress != null)
					onProgress(1f);
				//Debug.Log("stop 1f");
				yield break;
			}

			// Ignoring OnScrollViewValueChanged during smooth scrolling
			var ignorOnScroll_lastValue = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			_Params.scrollRect.StopMovement();
			Canvas.ForceUpdateCanvases();

			Func<double> getTargetVrtInset = () =>
			{
				// This needs to be updated regularly (if looping/twin pass, but it doesn't add too much overhead, so it's ok to re-calculate it each time)
				minContentVirtualInsetFromVPAllowed = -_InternalState.VirtualScrollableArea;

				return ScrollToHelper_GetContentStartVirtualInsetFromViewportStart_Clamped(
							minContentVirtualInsetFromVPAllowed, 
							itemIndex, 
							normalizedOffsetFromViewportStart, 
							normalizedPositionOfItemPivotToUse
						);
			};

			double initialVrtInsetFromParent = -1d, targetVrtInsetFromParent = -1d; // setting a value because of compiler, but it's initialized at least once in the loop below
			bool needToCalculateInitialInset = true, needToCalculateTargetInset = true, notCanceledByCaller = true;
			float startTime = Time.time, elapsedTime;
			double progress, value;
			var endOfFrame = new WaitForEndOfFrame();
			do
			{
				yield return null;
				yield return endOfFrame;

				elapsedTime = Time.time - startTime;
				if (elapsedTime >= duration)
					progress = 1d;
				else
					// Normal in, sin slow out
					progress = Math.Sin((elapsedTime / duration) * Math.PI / 2);

				if (needToCalculateInitialInset)
				{
					initialVrtInsetFromParent = _InternalState.ContentPanelVirtualInsetFromViewportStart;
					needToCalculateInitialInset = _Params.loopItems;
				}

				if (needToCalculateTargetInset || _InternalState.lastComputeVisibilityHadATwinPass)
				{
					//initialVrtInsetFromParent = _InternalState.ContentPanelVirtualInsetFromViewportStart;
					targetVrtInsetFromParent = getTargetVrtInset();
					needToCalculateTargetInset = _Params.loopItems || _InternalState.lastComputeVisibilityHadATwinPass;
				}
				value = initialVrtInsetFromParent * (1d - progress) + targetVrtInsetFromParent * progress; // Lerp for double
				//Debug.Log(
				//	"t=" + progress.ToString("0.####") +
				//	", i=" + initialVrtInsetFromParent.ToString("0") +
				//	", t=" + targetVrtInsetFromParent.ToString("0") +
				//	", t-i=" + (targetVrtInsetFromParent - initialVrtInsetFromParent).ToString("0") +
				//	", toSet=" + value.ToString("0"));

				
				// If finished earlier => don't make additional unnecesary steps
				if (Math.Abs(targetVrtInsetFromParent - value) < 1f)
				{
					value = targetVrtInsetFromParent;
					progress = 1d;
				}

				// Values that that would cause the ctStart to be placed AFTER vpStart should indicate the scrolling has ended (can't go past it)
				if (value > 0d)
				{
					progress = 1d; // end; last loop
					value = 0d;
				}
				else
				{
					//Debug.Log("vrtinset="+_InternalState.ContentPanelVirtualInsetFromViewportStart + ", i="+ initialVirtualInsetFromParent + ", t="+ targetInsetFromParent + ", v="+value);
					ScrollToHelper_SetContentVirtualInsetFromViewportStart(value, false);
				}
			}
			while (progress < 1d && (onProgress == null || (notCanceledByCaller = onProgress((float)progress))));

			if (notCanceledByCaller)
			{
				// Assures the end result is the expected one
				ScrollToHelper_SetContentVirtualInsetFromViewportStart(getTargetVrtInset(), false);

				// This is a semi-hack-lazy hot-fix because when the duration is 0 (or near 0), sometimes the visibility isn't computed well
				// Same thing is done in ScrollTo method above
				ComputeVisibilityForCurrentPosition(false, true, false, -.1);
				ComputeVisibilityForCurrentPosition(true, true, false, +.1);
				//ScrollTo(itemIndex, normalizedOffsetFromViewportStart, normalizedPositionOfItemPivotToUse);

				_SmoothScrollCoroutine = null;

				if (onProgress != null)
					onProgress(1f);

				//Debug.Log("stop natural");

			}
			//else
			//	Debug.Log("routine cancelled");

			// This should be restored even if the scroll was cancelled by the caller. 
			// When the routine is stopped via StopCoroutine, this line won't be executed because the execution point won't pass the previous yield instruction.
			// It's assumed that _SkipComputeVisibilityInUpdateOrOnScroll is manually set to false whenever that happpens
			_SkipComputeVisibilityInUpdateOrOnScroll = ignorOnScroll_lastValue;
		}

		void CancelAnimationsIfAny()
		{
			if (_Params.snapper)
				_Params.snapper.CancelSnappingIfInProgress();
			if (_SmoothScrollCoroutine != null)
			{
				StopCoroutine(_SmoothScrollCoroutine);
				_SmoothScrollCoroutine = null;

				// Bugfix: if the routine is stopped, this is not restored back. Setting it to false is the best thing we can do
				_SkipComputeVisibilityInUpdateOrOnScroll = false;

				//Debug.Log("cancel - manual");
			}
		}

		void MarkViewsHoldersForRebuild(List<TItemViewsHolder> vhs)
		{
			if (vhs != null)
				foreach (var v in vhs)
					if (v != null && v.root != null)
						v.MarkForRebuild();
		}

		/// <summary> It assumes that the content is bigger than the viewport </summary>
		double ScrollToHelper_GetContentStartVirtualInsetFromViewportStart_Clamped(double minContentVirtualInsetFromVPAllowed, int itemIndex, float normalizedItemOffsetFromStart, float normalizedPositionOfItemPivotToUse)
		{
			float maxContentInsetFromVPAllowed = _Params.loopItems ? _InternalState.viewportSize/2 : 0f; // if looping, there's no need to clamp. in addition, clamping would cancel a scrollTo if the content is exactly at start or end
			minContentVirtualInsetFromVPAllowed -= maxContentInsetFromVPAllowed;
			int itemViewIdex = _ItemsDesc.GetItemViewIndexFromRealIndex(itemIndex);
			float itemSize = _ItemsDesc[itemViewIdex];
			float insetToAdd = _InternalState.viewportSize * normalizedItemOffsetFromStart - itemSize * normalizedPositionOfItemPivotToUse;

			double itemVrtInsetFromStart = _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(itemViewIdex);
			double ctInsetFromStart_Clamped = Math.Max(
						minContentVirtualInsetFromVPAllowed,
						Math.Min(maxContentInsetFromVPAllowed, -itemVrtInsetFromStart + insetToAdd)
					);

			//Debug.Log("siz=" + itemSize + ", -itemVrtInsetFromStart=" + (-itemVrtInsetFromStart) + ", insetToAdd=" + insetToAdd + ", ctInsetFromStart_Clamped=" + ctInsetFromStart_Clamped);

			return ctInsetFromStart_Clamped;
		}

		/// <summary><paramref name="offset"/> should be a valid value. See how it's clamped in <see cref="ScrollTo(int, float, float)"/></summary>
		void ScrollToHelper_SetContentVirtualInsetFromViewportStart(double virtualInset, bool cancelSnappingIfAny)
		{
			var ignoreOnScroll_valueBefore = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			if (cancelSnappingIfAny && _Params.snapper)
				_Params.snapper.CancelSnappingIfInProgress();

			//Canvas.ForceUpdateCanvases(); // commented: SetContentVirtualInsetFromViewportStart already calls this
			_Params.scrollRect.StopMovement();
			_InternalState.SetContentVirtualInsetFromViewportStart(virtualInset);

			// TODO see if removing the condition with loopItems has created any bugs
			ComputeVisibilityForCurrentPosition(true, true, false);// _Params.loopItems && (virtualInset > 0d || -virtualInset > _InternalState.VirtualScrollableArea));
			if (!_CorrectedPositionInCurrentComputeVisibilityPass)
				CorrectPositionsOfVisibleItems(false);// false);

			_SkipComputeVisibilityInUpdateOrOnScroll = ignoreOnScroll_valueBefore;
		}

		/// <summary> Make sure to only call this from <see cref="ChangeItemCountTo(int, bool, bool)"/>, because implementors may override it to catch the "pre-item-count-change" event</summary>
		void ChangeItemsCountInternal(ItemCountChangeMode changeMode, int count, int indexIfInsertingOrRemoving, bool contentPanelEndEdgeStationary, bool keepVelocity)
		{
			//OnItemsCountWillChange(itemsCount);
			CancelAnimationsIfAny();

			var ignoreOnScroll_valueBefore = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			int prevCount = _ItemsDesc.itemsCount;
			var velocity = _Params.scrollRect.velocity;
			if (!keepVelocity)
				_Params.scrollRect.StopMovement();

			double sizeOfAllItemsBefore = _ItemsDesc.CumulatedSizeOfAllItems;
			//double vo = 0d, ctVIVPE = 0d;
			//float inferredRO = 0f, actualRO = 0f;
			//double vsz = 0d, ctOff = 0d, ctSK = 0d;

			//if (_VisibleItemsCount > 0)
			//{
			//	vo = _InternalState.GetItemVirtualOffsetFromParentEndUsingItemIndexInView(_VisibleItems[_VisibleItemsCount - 1].itemIndexInView);
			//	ctVIVPE = _InternalState.ContentPanelVirtualInsetFromViewportEnd;
			//	inferredRO = _InternalState.GetItemInferredRealOffsetFromParentEnd(_VisibleItems[_VisibleItemsCount - 1].itemIndexInView);
			//	actualRO = _VisibleItems[_VisibleItemsCount - 1].root.GetInsetFromParentEdge(_Params.content, _InternalState.endEdge);
			//	Debug.Log("BEF:"
			//		+ " ctSz=" + (vsz=_InternalState.contentPanelVirtualSize)
			//		+ ", ctOffS=" + (ctOff=_InternalState.ContentPanelVirtualInsetFromViewportStart)
			//		+ ", ctSK=" + (ctSK=_InternalState.contentPanelSkippedInsetDueToVirtualization)
			//		+ ", vo=" + vo
			//		+ ", infRO=" + inferredRO
			//		+ ", actualRO=" + actualRO
			//		+ ", sizeAll=" + sizeOfAllItemsBefore
			//		+ ", ctVIVPE=" + ctVIVPE
			//	);
			//}

			//if (_InternalState.layoutRebuildPendingDueToScrollViewSizeChangeEvent)
			//	Canvas.ForceUpdateCanvases();

			_ItemsDesc.realIndexOfFirstItemInView = count > 0 ? 0 : -1;
			CollectItemsSizes(changeMode, count, indexIfInsertingOrRemoving, _ItemsDesc);

			double sizeOfAllItemsAfter = _ItemsDesc.CumulatedSizeOfAllItems;
			bool vrtContentPanelIsAtOrBeforeEnd = _InternalState.ContentPanelVirtualInsetFromViewportEnd >= 0d;
			if (sizeOfAllItemsAfter <= sizeOfAllItemsBefore) // content has shrunk
			{
				if (_InternalState.ContentPanelVirtualInsetFromViewportStart >= 0d)
					contentPanelEndEdgeStationary = false; // doesn't make sense to move the start edge if the content pos is at start (or after)
				else if (vrtContentPanelIsAtOrBeforeEnd)
					contentPanelEndEdgeStationary = true; // doesn't make sense to move the end edge if the content pos is at end (or before)
			}

			_InternalState.OnItemsCountChanged(prevCount, contentPanelEndEdgeStationary);

			//if (_VisibleItemsCount > 0)
			//{
			//	var vo2 = _InternalState.GetItemVirtualOffsetFromParentEndUsingItemIndexInView(_VisibleItems[_VisibleItemsCount - 1].itemIndexInView);
			//	var inferredRO2 = _InternalState.GetItemInferredRealOffsetFromParentEnd(_VisibleItems[_VisibleItemsCount - 1].itemIndexInView);
			//	var actualRO2 = _VisibleItems[_VisibleItemsCount - 1].root.GetInsetFromParentEdge(_Params.content, _InternalState.endEdge);
			//	Debug.Log("CHNG2:"
			//		+ " ctSz=" + (_InternalState.contentPanelVirtualSize - vsz)
			//		+ ", ctOffS=" + (_InternalState.ContentPanelVirtualInsetFromViewportStart - ctOff)
			//		+ ", ctSK=" + (_InternalState.contentPanelSkippedInsetDueToVirtualization - ctSK)
			//		+ ", vo=" + (vo2 - vo)
			//		+ ", infRO=" + (inferredRO2 - inferredRO)
			//		+ ", actualRO=" + (actualRO2 - actualRO)
			//		+ ", ctVIVPE_Ch=" + (ctVIVPE - _InternalState.ContentPanelVirtualInsetFromViewportEnd)
			//		+ ", sizeAll_Ch=" + (sizeOfAllItemsAfter - sizeOfAllItemsBefore)
			//		+ ", endStat=" + contentPanelEndEdgeStationary
			//	);
			//}

			// Re-build the content: mark all currentViews as recyclable
			// _RecyclableItems must be zero;
			if (GetNumExcessObjects() > 0)
				throw new UnityException("ChangeItemsCountInternal: GetNumExcessObjects() > 0 when calling ChangeItemsCountInternal(); this may be due ComputeVisibility not being finished executing yet");

            _RecyclableItems.AddRange(_VisibleItems);

			// If the itemsCount is 0, then it makes sense to destroy all the views, instead of marking them as recyclable. Maybe the ChangeItemCountTo(0) was called in order to clear the current contents
			if (count == 0)
				ClearCachedRecyclableItems();

			_VisibleItems.Clear();
			_VisibleItemsCount = 0;

			double reportedScrollDelta;
			if (contentPanelEndEdgeStationary)
				reportedScrollDelta = .1f;
			else
			{
				// If start edge is stationary, either if the content shrinks or expands the reportedDelta should be negative, 
				// indicating that a fake "slight scroll towards end" was done. This triggers a virtualization of the the content's position correctly to compensate for the new ctEnd 
				// and makes any item after it be visible again (in the shirnking case) if it was after viewport
				reportedScrollDelta = -.1f;

				// ..but if the ctEnd is fully visible, the content will act as it was shrinking with itemEndEdgeStationary=true, because the content's end can't go before vpEnd
				if (vrtContentPanelIsAtOrBeforeEnd)
					reportedScrollDelta = .1f;
			}

			ComputeVisibilityForCurrentPosition(true, true, true, reportedScrollDelta);
			if (!_CorrectedPositionInCurrentComputeVisibilityPass)
				CorrectPositionsOfVisibleItems(true);

			//// This solves some items not appearing when layout was just being rebuilt
			//if (/*_InternalState.lastComputeVisibilityHadATwinPass &&*/ _InternalState.layoutIsBeingRebuildDueToScrollViewSizeChangeEvent)
			//{
			//	ComputeVisibilityForCurrentPosition(true, true, true, -.1f);
			//	ComputeVisibilityForCurrentPosition(true, true, true, .1f);
			//}

			//if (_VisibleItemsCount > 0)
			//{
			//	var vo2 = _InternalState.GetItemVirtualOffsetFromParentEndUsingItemIndexInView(_VisibleItems[_VisibleItemsCount - 1].itemIndexInView);
			//	var inferredRO2 = _InternalState.GetItemInferredRealOffsetFromParentEnd(_VisibleItems[_VisibleItemsCount - 1].itemIndexInView);
			//	var actualRO2 = _VisibleItems[_VisibleItemsCount - 1].root.GetInsetFromParentEdge(_Params.content, _InternalState.endEdge);
			//	Debug.Log("CHNG3:"
			//		+ " ctSz=" + (_InternalState.contentPanelVirtualSize - vsz)
			//		+ ", ctOffS=" + (_InternalState.ContentPanelVirtualInsetFromViewportStart - ctOff)
			//		+ ", ctSK=" + (_InternalState.contentPanelSkippedInsetDueToVirtualization - ctSK)
			//		+ ", vo=" + (vo2 - vo)
			//		+ ", infRO=" + (inferredRO2 - inferredRO)
			//		+ ", actualRO=" + (actualRO2 - actualRO)
			//		+ ", ctVIVPE_Ch=" + (ctVIVPE - _InternalState.ContentPanelVirtualInsetFromViewportEnd)
			//	);
			//}

			if (keepVelocity)
				_Params.scrollRect.velocity = velocity;

			if (ItemsRefreshed != null)
				ItemsRefreshed(prevCount, count);

			_SkipComputeVisibilityInUpdateOrOnScroll = ignoreOnScroll_valueBefore;
		}

		/// <summary>Called by MonoBehaviour.Update</summary>
		void MyUpdate()
		{
			if (_InternalState.computeVisibilityTwinPassScheduled)
				throw new UnityException("ScheduleComputeVisibilityTwinPass() can only be called in UpdateViewsHolder() !!!");

			bool scrollviewSizeChanged = _InternalState.HasScrollViewSizeChanged;
			if (scrollviewSizeChanged)
			{
				//_InternalState.layoutIsBeingRebuildDueToScrollViewSizeChangeEvent = true;
				OnScrollViewSizeChanged(); 
				RebuildLayoutDueToScrollViewSizeChange(); // will call a refresh
				return;
				//_InternalState.updateRequestPending = true;
			}

			if (_InternalState.updateRequestPending)
			{
				// TODO See if need to skip modifying updateRequestPending if _SkipComputeVisibility is true

				// ON_SCROLL is the only case when we don't regularly update and are using only onScroll event to ComputeVisibility
				_InternalState.updateRequestPending = _Params.updateMode != BaseParams.UpdateMode.ON_SCROLL;
				if (!_SkipComputeVisibilityInUpdateOrOnScroll)
				{
					ComputeVisibilityForCurrentPosition(false, true, false);

					if (_Params.snapper)// && !scrollviewSizeChanged)
						_Params.snapper.StartSnappingIfNeeded();
				}
			}

			UpdateGalleryEffectIfNeeded();
		}

		/// <summary>Called by ScrollRect.onValueChanged event</summary>
		void OnScrollViewValueChanged(Vector2 _)
		{
			// Even though this is also checked in ComputeVisibilityForCurrentPosition, 
			// _InternalState.updateRequestPending might still be set to true (below), so we're checking it here
			if (_SkipComputeVisibilityInUpdateOrOnScroll)
				return; // also don't call ScrollPositionChanged

			if (_Params.updateMode != BaseParams.UpdateMode.MONOBEHAVIOUR_UPDATE)
			{
				ComputeVisibilityForCurrentPosition(
					false, // ScrollPositionChanged will be called below 
					true, 
					false
				);
			}

			if (_Params.updateMode != BaseParams.UpdateMode.ON_SCROLL) // ScrollPositionChanged will be called after the next ComputeVisibility
				_InternalState.updateRequestPending = true;

			if (ScrollPositionChanged != null)
				ScrollPositionChanged(GetNormalizedPosition());
		}

		void ComputeVisibilityForCurrentPosition(bool forceFireScrollViewPositionChangedEvent, bool virtualizeContentPositionIfNeeded, bool alsoCorrectTransversalPositions, double overrideScrollingDelta)
		{
			double curInset = _InternalState.ContentPanelVirtualInsetFromViewportStart;
			_InternalState.lastProcessedCTVirtualInsetFromParentStart = curInset - overrideScrollingDelta;
			ComputeVisibilityForCurrentPosition(forceFireScrollViewPositionChangedEvent, virtualizeContentPositionIfNeeded, alsoCorrectTransversalPositions);
		}

		//float lastSpeed = -1f;
		/// <summary>Called by <see cref="MyUpdate"/>, <see cref="OnScrollViewValueChanged(Vector2)"/> or both</summary>
		void ComputeVisibilityForCurrentPosition(bool forceFireScrollViewPositionChangedEvent, bool virtualizeContentPositionIfNeeded, bool alsoCorrectTransversalPositions)
		{
			_CorrectedPositionInCurrentComputeVisibilityPass = false;

			if (_InternalState.computeVisibilityTwinPassScheduled)
				throw new UnityException("ScheduleComputeVisibilityTwinPass() can only be called in UpdateViewsHolder() !!!");

			double curPos = _InternalState.ContentPanelVirtualInsetFromViewportStart;
			double delta = (curPos - _InternalState.lastProcessedCTVirtualInsetFromParentStart);
			var velocityToSet = _Params.scrollRect.velocity;
			PointerEventData pev = null;
			bool triedRetrievingPev = false;

			if (virtualizeContentPositionIfNeeded && _VisibleItemsCount > 0)
				triedRetrievingPev = VirtualizeContentPositionIfNeeded(ref pev, delta, pev == null, alsoCorrectTransversalPositions);

			ComputeVisibility(delta);

			if (_InternalState.computeVisibilityTwinPassScheduled)
				ComputeVisibilityTwinPass(ref pev, delta, !triedRetrievingPev);
			else
				_InternalState.lastComputeVisibilityHadATwinPass = false;

			if (pev != null)
			{
				pev.dragging = false;
				velocityToSet += pev.delta * Vector3.Distance(pev.pressPosition, pev.position) / 10;
				_Params.scrollRect.velocity = velocityToSet;
			}

			_InternalState.UpdateLastProcessedCTVirtualInsetFromParentStart();
			
			if ((forceFireScrollViewPositionChangedEvent || delta != 0d) && ScrollPositionChanged != null)
				ScrollPositionChanged(GetNormalizedPosition());
		}

		void ComputeVisibilityTwinPass(ref PointerEventData pev, double delta, bool returnPointerEventDataIfNeeded)
		{
			_InternalState.computeVisibilityTwinPassScheduled = false;

			if (_VisibleItemsCount == 0)
				throw new UnityException("computeVisibilityTwinPassScheduled, but there are no visible items. Only call ScheduleComputeVisibilityTwinPass() in UpdateViewsHolder() !!!");

			// Prevent onValueChanged callbacks from being processed when setting inset and size of content
			var ignoreOnScroll_valueBefore = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			Canvas.ForceUpdateCanvases();

			// 2 fors are more efficient
			if (_Params.scrollRect.horizontal)
			{
				for (int i = 0; i < _VisibleItemsCount; ++i)
					OnItemWidthChangedPreTwinPass(_VisibleItems[i]);
			}
			else
			{
				for (int i = 0; i < _VisibleItemsCount; ++i)
					OnItemHeightChangedPreTwinPass(_VisibleItems[i]);
			}

			//bool endEdgeStationary = delta > 0d;
			bool endEdgeStationary = delta == 0d ? _InternalState.preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass : delta > 0d;
			//Debug.Log("delta="+ delta + ", endStationary="+ endEdgeStationary);
			_InternalState.OnItemsSizesChangedExternally(_VisibleItems, endEdgeStationary);

			_SkipComputeVisibilityInUpdateOrOnScroll = ignoreOnScroll_valueBefore;

			// TODO see if this is needed; in most cases, the compute visibility will be called shortly anyway
			//ComputeVisibility(delta);

			if (returnPointerEventDataIfNeeded)
				pev = Utils.GetPointerEventDataWithPointerDragGO(_Params.scrollRect.gameObject, false);

			_InternalState.lastComputeVisibilityHadATwinPass = true;
		}

		// Should only be called once, in ComputeVisibilityForCurrentPosition()!
		// Assigns pev to the pointer event data, if a pointer was touching the scroll view before virtualizing. 
		// Will return false if it did not try to retrieve the pev
		bool VirtualizeContentPositionIfNeeded(ref PointerEventData pev, double delta, bool returnPointerEventDataIfNeeded, bool alsoCorrectTransversalPositions)
		{
			if (delta == 0d)
				return false;

			int potentialResetDir = delta > 0d /*positive scroll -> going to start*/ ? 2 : 1;
			float curRealAbstrNormPos = _Params.scrollRect.horizontal ? 1f - _Params.scrollRect.horizontalNormalizedPosition : _Params.scrollRect.verticalNormalizedPosition;
			int firstVisibleItem_IndexInView = _VisibleItems[0].itemIndexInView, lastVisibleItem_IndexInView = firstVisibleItem_IndexInView + _VisibleItemsCount - 1;
			bool firstVisibleIsFirstIndexInView = firstVisibleItem_IndexInView == 0;
			bool lastVisibleIsLastIndexInView = lastVisibleItem_IndexInView == _ItemsDesc.itemsCount - 1;
			float contentInsetFromVPStart_Prev = _Params.content.GetInsetFromParentEdge(_Params.viewport, _InternalState.startEdge);
			float contentInsetFromVPEnd_Prev = _Params.content.GetInsetFromParentEdge(_Params.viewport, _InternalState.endEdge);
			double sizeCummForLastVisibleItem = _ItemsDesc.GetItemSizeCumulative(lastVisibleItem_IndexInView);
			double sizeCummForFirstVisibleItem = _ItemsDesc.GetItemSizeCumulative(firstVisibleItem_IndexInView);

			// TODO test if adding padding end/start is needed
			// Sum of visible items sizes and the spaces between them
			// IF first visible is first in view, also add content start padding
			// // ELSE IF last visible is last in view, also add content end padding
			// Full name: visibleItemsTotalSizePlusSpacingBetweenThemPlusContentPaddingIfApplicable
			double sizVis = sizeCummForLastVisibleItem;
			if (!firstVisibleIsFirstIndexInView)
				sizVis -= (sizeCummForFirstVisibleItem - _ItemsDesc[firstVisibleItem_IndexInView]);
			sizVis += (lastVisibleItem_IndexInView - firstVisibleItem_IndexInView) * _InternalState.spacing;

			float firstVisibleItemAmountOutside = -contentInsetFromVPStart_Prev - _InternalState.GetItemInferredRealInsetFromParentStart(firstVisibleItem_IndexInView);
			float lastVisibleItemAmountOutside = -contentInsetFromVPEnd_Prev - _InternalState.GetItemInferredRealInsetFromParentEnd(lastVisibleItem_IndexInView);

			//Debug.Log("lastVisIdxInView="+ lastVisibleItem_IndexInView + ", lastIdxInView="+(_ItemsDesc.itemsCount-1));

			RectTransform.Edge edgeToInsetContentFrom;
			float contentNewInsetFromVPStartOrEnd;
			if (potentialResetDir == 1)
			{
				// Already done (this can sometimes mean there are too few items in list)
				if (firstVisibleIsFirstIndexInView)
					return false;

				//sizVis += _InternalState.paddingContentStart;

				// Full name: sizesOfItemsAfterLastVisiblePlusPreSpacingForEachPlusCTPadEndIfApplicable
				// if itemsAfter=0, sizAft will be the end padding only
				int itemsAfter = _ItemsDesc.itemsCount - lastVisibleItem_IndexInView - 1;
				double sizAft = _InternalState.spacing * itemsAfter
									+ (_ItemsDesc.GetItemSizeCumulative(_ItemsDesc.itemsCount - 1) - sizeCummForLastVisibleItem)
									+ _InternalState.paddingContentEnd;

				//Debug.Log("sizVis=" + sizVis + ", sizAft=" + sizAft);

				float contentNewInsetFromVPStart;
				// Do a smaller jump, because the content is near the end. the jump will be made so that the content's real end edge will be the same as the virtual one
				if (sizAft < sizVis
					// .. but in case of looping: the jump is partial only if the last visible is not the last in view 
					// (which would trigger a full jump, since there's no limit of how far we can scroll)
					 && (!_Params.loopItems || !lastVisibleIsLastIndexInView)  
				)
				{
					float sizAftPlusLastAmountOutside = (float)sizAft + lastVisibleItemAmountOutside;
					contentNewInsetFromVPStart = -(_InternalState.contentPanelSize - _InternalState.viewportSize - sizAftPlusLastAmountOutside);
				}
				else
				{
					// Update: In case of looping, the jump must be done if the there's no item in view after the last visible (otherwise there'd sometimes be empty space until the ct end)
					if ((!_Params.loopItems || !lastVisibleIsLastIndexInView) && curRealAbstrNormPos >= 1d - InternalState.proximityToLimitNeeded01ToResetPos)
						return false; // the content is not close enough to the end

					contentNewInsetFromVPStart = -(firstVisibleItemAmountOutside + _InternalState.paddingContentStart);
				}

				// Content is already approximately at that position => cancel
				if (Math.Abs(contentInsetFromVPStart_Prev - contentNewInsetFromVPStart) < 1f)// && !_Params.loopItems)
					return false;

				contentNewInsetFromVPStartOrEnd = contentNewInsetFromVPStart;
				edgeToInsetContentFrom = _InternalState.startEdge;
			}
			else
			{
				// Already done (this can sometimes mean there are too few items in list)
				if (lastVisibleIsLastIndexInView)
					return false;

				//sizVis += _InternalState.paddingContentEnd;

				// Full name: sizesOfItemsBeforeFirstVisiblePlusPreSpacingForEachPlusCTPadStartIfApplicable
				// if itemsAfter=0, sizAft will be the end padding only
				int itemsBefore = firstVisibleItem_IndexInView;
				double sizBef = _InternalState.spacing * itemsBefore
									+ sizeCummForFirstVisibleItem - _ItemsDesc[firstVisibleItem_IndexInView]
									+ _InternalState.paddingContentStart;

				//Debug.Log("sizVis=" + sizVis + ", sizBef=" + sizBef);

				float contentNewInsetFromVPEnd;
				// See analogous explanation in the previous case
				if (sizBef < sizVis
					// .. see above 
					&& (!_Params.loopItems || !firstVisibleIsFirstIndexInView) 
				)
				{
					float sizBefPlusFirstAmountOutside = (float)sizBef + firstVisibleItemAmountOutside;
					contentNewInsetFromVPEnd = -(_InternalState.contentPanelSize - _InternalState.viewportSize - sizBefPlusFirstAmountOutside);
				}
				else
				{
					// Update: In case of looping, the jump must be done if the there's no item in view before the first visible (otherwise there'd sometimes be empty space until the ct start)
					if ((!_Params.loopItems || !firstVisibleIsFirstIndexInView) && curRealAbstrNormPos <= InternalState.proximityToLimitNeeded01ToResetPos)
						return false; // the content is not close enough to the start

					contentNewInsetFromVPEnd = -(lastVisibleItemAmountOutside + _InternalState.paddingContentEnd);
				}

				// Content is already approximately at that position => cancel
				// Update: but in case of looping, the jump must be done if the there's no item in view before the first visible
				if (Math.Abs(contentInsetFromVPEnd_Prev - contentNewInsetFromVPEnd) < 1f)// && !_Params.loopItems)
					return false;

				contentNewInsetFromVPStartOrEnd = contentNewInsetFromVPEnd;
				edgeToInsetContentFrom = _InternalState.endEdge;
			}

			// Prevent onValueChanged callbacks from being processed when setting inset and size of content
			var ignoreOnScroll_valueBefore = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			//var velocityBeforeCTPosReset = _Params.scrollRect.velocity;
			if (returnPointerEventDataIfNeeded)
				pev = Utils.GetPointerEventDataWithPointerDragGO(_Params.scrollRect.gameObject, false);
			//if (pev != null)
			//{
			//	pev.dragging = false;
			//	velocityBeforeCTPosReset += pev.delta * Vector3.Distance(pev.pressPosition, pev.position) / 10;
			//}
			_Params.content.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(_Params.viewport, edgeToInsetContentFrom, contentNewInsetFromVPStartOrEnd, _InternalState.contentPanelSize);
			_Params.scrollRect.Rebuild(CanvasUpdate.PostLayout);
			Canvas.ForceUpdateCanvases(); // added after, because it makes sense, but it wasn't tested wether the lack of it would cause problems 

			// Restore to normal
			_SkipComputeVisibilityInUpdateOrOnScroll = ignoreOnScroll_valueBefore;

			bool looped = false;
			if (_Params.loopItems)
			{
				//Debug.Log("first=" + firstVisibleItem_IndexInView + ", " + _VisibleItems[0].itemIndexInView + "; last=" + lastVisibleItem_IndexInView + ", " + _VisibleItems[_VisibleItemsCount-1].itemIndexInView);
				int newRealIndexOfFirstItemInView = -1;
				if (potentialResetDir == 1) // going towards end
				{
					if (lastVisibleIsLastIndexInView)
					{
						// If going towards end, the panel's virtual and real start are now the same => 0 skipped inset
						_InternalState.contentPanelSkippedInsetDueToVirtualization = 0d;

						newRealIndexOfFirstItemInView = _VisibleItems[0].ItemIndex;
						//newRealIndexOfFirstItemInView = _InternalState.GetItemRealIndexFromViewIndex(0);

						// Adjust the itemIndexInView for the visible items. they'll be the last ones, so the last one of them will have, for example, viewIndex = itemsCount-1
						for (int i = 0; i < _VisibleItemsCount; ++i)
							_VisibleItems[i].itemIndexInView = i;
					}
				}
				else // going towards start
				{
					if (firstVisibleIsFirstIndexInView)
					{
						// If going towards start, the panel's virtual and real end are now the same => max skipped inset
						_InternalState.contentPanelSkippedInsetDueToVirtualization = -(_InternalState.contentPanelVirtualSize - _InternalState.contentPanelSize);

						// The next item after this will become the first one in view
						newRealIndexOfFirstItemInView = _ItemsDesc.GetItemRealIndexFromViewIndex(lastVisibleItem_IndexInView + 1);
						//newRealIndexOfFirstItemInView = _InternalState.GetItemRealIndexFromViewIndex(_ItemsDescriptor.itemsCount - 1);

						// Adjust the itemIndexInView for the visible items
						for (int i = 0; i < _VisibleItemsCount; ++i)
							_VisibleItems[i].itemIndexInView = _ItemsDesc.itemsCount - _VisibleItemsCount + i;
					}
				}

				looped = newRealIndexOfFirstItemInView != -1;
				if (looped)
					_ItemsDesc.RotateItemsSizesOnScrollViewLooped(newRealIndexOfFirstItemInView);
			}

			// Store the skipped inset amount, if no looping overrode it
			if (!looped)
				_InternalState.contentPanelSkippedInsetDueToVirtualization += contentInsetFromVPStart_Prev - _Params.content.GetInsetFromParentEdge(_Params.viewport, _InternalState.startEdge);

			// The visible items are displaced now, so correct their positions
			CorrectPositionsOfVisibleItems(alsoCorrectTransversalPositions);//delta > 0d);
			_CorrectedPositionInCurrentComputeVisibilityPass = true;

			//_Params.scrollRect.velocity = velocityBeforeCTPosReset;

			_InternalState.UpdateLastProcessedCTVirtualInsetFromParentStart();

			return true;
		}

		void CorrectPositionsOfVisibleItems(bool alsoCorrectTransversalPositioning)//bool itemEndEdgeStationary)
		{
			//_CorrectedPositionInCurrentComputeVisibilityPass = true;

			// Update the positions of the visible items so they'll retain their position relative to the viewport
			if (_VisibleItemsCount > 0)
				_InternalState.CorrectPositions(_VisibleItems, alsoCorrectTransversalPositioning);//, itemEndEdgeStationary);
		}

		/// <summary>The very core of <see cref="SRIA{TParams, TItemViewsHolder}"/>. You must be really brave if you think about trying to understand it :)</summary>
		void ComputeVisibility(double abstractDelta)
		{
			// ALIASES:
			// scroll down = the content goes down(the "view point" goes up); scroll up = analogue
			// the notation "x/y" means "x, if vertical scroll; y, if horizontal scroll"
			// positive scroll = down/right; negative scroll = up/left
			// [start] = usually refers to some point above/to-left-of [end], if negativeScroll; 
			//          else, [start] is below/to-right-of [end]; 
			//          for example: -in context of _VisibleItems, [start] is 0 for negativeScroll and <_VisibleItemsCount-1> for positiveScroll;
			//                       -in context of an item, [start] is its top for negativeScroll and bottom for positiveScroll;
			//                       - BUT for ct and vp, they have fixed meaning, regardless of the scroll sign. they only depend on scroll direction (if vert, start = top, end = bottom; if hor, start = left, end = right)
			// [end] = inferred from definition of [start]
			// LV = last visible (the last item that was closest to the negVPEnd_posVPStart in the prev call of this func - if applicable)
			// NLV = new last visible (the next one closer to the negVPEnd_posVPStart than LV)
			// neg = negative scroll (down or right)
			// pos =positive scroll (up or left)
			// ch = child (i.e. ctChS = content child start(first child) (= ct.top - ctPaddingTop, in case of vertical scroll))

			#region visualization
			// So, again, this is the items' start/end notions! Viewport's and Content's start/end are constant throughout the session
			// Assume the following scroll direction (hor) and sign (neg) (where the VIEWPORT+SCROLLBAR goes, opposed to where the CONTENT goes):
			// hor, negative:
			// O---------------->
			//      [vpStart]  [start]item[end] .. [start]item2[end] .. [start]LVItem[end] [vpEnd]
			// hor, positive:
			// <----------------O
			//      [vpStart]  [end]item[start] .. [end]item2[start] .. [end]LVItem[start] [vpEnd]
			#endregion

			bool negativeScroll = abstractDelta <= 0d;
			//bool verticalScroll = _Params.scrollRect.vertical;

			// Viewport constant values
			float vpSize = _InternalState.viewportSize;

			// Content panel constant values
			float ctSpacing = _InternalState.spacing,
				  ctPadTransvStart = _InternalState.transversalPaddingContentStart;

			// Items constant values
			float allItemsTransversalSizes = _ItemsDesc.itemsConstantTransversalSize;

			// Items variable values
			TItemViewsHolder nlvHolder = null;
			//int currentLVItemIndex;
			int currentLVItemIndexInView;

			double negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV;
			//RectTransform.Edge negStartEdge_posEndEdge;
			RectTransform.Edge transvStartEdge = _InternalState.transvStartEdge;

			//int negEndItemIndex_posStartItemIndex,
			//int endItemIndex, // TODO pending removal
			int endItemIndexInView,
				  neg1_posMinus1,
				  //negMinus1_pos1,
				  neg1_pos0,
				  neg0_pos1;

			//float neg0_posVPSize;

			if (negativeScroll)
			{
				neg1_posMinus1 = 1;
				//negStartEdge_posEndEdge = _InternalState.startEdge;
			}
			else
			{
				neg1_posMinus1 = -1;
				//negStartEdge_posEndEdge = _InternalState.endEdge;
			}
			//negMinus1_pos1 = -neg1_posMinus1;
			neg1_pos0 = (neg1_posMinus1 + 1) / 2;
			neg0_pos1 = 1 - neg1_pos0;
			//neg0_posVPSize = neg0_pos1 * vpSize;

			// IF _VisibleItemsCount == 0:
			//		-1, if negativeScroll
			//		_InternalParams.itemsCount, else
			// ELSE
			//		indexInView of last visible, if negativeScroll
			//		indexInView of first visible, else
			currentLVItemIndexInView = neg0_pos1 * (_ItemsDesc.itemsCount - 1) - neg1_posMinus1;
			bool thereWereVisibletems = _VisibleItemsCount > 0;
			//int indexInViewOfFirstVH, indexInViewOfLastVH;

			// _InternalParams.itemsCount - 1, if negativeScroll
			// 0, else
			endItemIndexInView = neg1_pos0 * (_ItemsDesc.itemsCount - 1);

			//float negCTVrtInsetFromVPS_posCTVrtInsetFromVPE = _Params.content.GetInsetFromParentEdge(_Params.viewport, negStartEdge_posEndEdge);
			double ctVrtInsetFromVPS = _InternalState.ContentPanelVirtualInsetFromViewportStart;
			double negCTVrtInsetFromVPS_posCTVrtInsetFromVPE = negativeScroll ? ctVrtInsetFromVPS : (-_InternalState.contentPanelVirtualSize + _InternalState.viewportSize - ctVrtInsetFromVPS);
			//float negCTInsetFromVPS_posCTInsetFromVPE = _Params.content.GetInsetFromParentEdge(_Params.viewport, negativeScroll ? _InternalState.startEdge : _InternalState.endEdge);

			// _VisibleItemsCount is always 0 in the first call of this func after the list is modified.

			// The item that was the last in the _VisibleItems (first, if pos scroll); We're inferring the positions of the other ones after(below/to the right, depending on hor/vert scroll) it this way, since the heights(widths for hor scroll) are known
			TItemViewsHolder startingLVHolder = null;

			// Get a list of items that are before(if neg)/after(if pos) viewport and move them from 
			// _VisibleItems to itemsOutsideViewport; they'll be candidates for recycling
			if (thereWereVisibletems)
			{
				// 
				// startingLV means the item in _VisibleItems that's the closest to the next one that'll spawn
				// 



				int startingLVHolderIndex;
				//RectTransform startingLVRT;

				//indexInViewOfFirstVH = _VisibleItems[0].itemIndexInView;
				//indexInViewOfLastVH = _VisibleItems[_VisibleItemsCount - 1].itemIndexInView;

				// startingLVHolderIndex will be:
				// _VisibleItemsCount - 1, if negativeScroll
				// 0, if upScroll
				startingLVHolderIndex = neg1_pos0 * (_VisibleItemsCount - 1);
				startingLVHolder = _VisibleItems[startingLVHolderIndex];
				//startingLVRT = startingLVHolder.root;

				// Approach name(will be referenced below): (%%%)
				// currentStartToUseForNLV will be:
				// NLV top (= LV bottom - spacing), if negativeScroll
				// NLV bottom (= LV top + spacing), else
				//---
				// More in depth: <down0up1 - startingLVRT.pivot.y> will be
				// -startingLVRT.pivot.y, if negativeScroll
				// 1 - startingLVRT.pivot.y, else
				//---
				// And: 
				// ctSpacing will be subtracted from the value, if negativeScroll
				// added, if upScroll

				// Commented: using a more efficient way of doing this by using cumulative sizes
				//if (verticalScroll)
				//{
				//    float sizePlusSpacing = startingLVRT.rect.height + ctSpacing;
				//    if (negativeScroll)
				//        negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = startingLVRT.GetInsetFromParentTopEdge(_Params.content) + sizePlusSpacing;
				//    else
				//        negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = startingLVRT.GetInsetFromParentBottomEdge(_Params.content) + sizePlusSpacing;
				//}
				//else
				//{
				//    float sizePlusSpacing = startingLVRT.rect.width + ctSpacing;
				//    if (negativeScroll)
				//        negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = startingLVRT.GetInsetFromParentLeftEdge(_Params.content) + sizePlusSpacing;
				//    else
				//        negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = startingLVRT.GetInsetFromParentRightEdge(_Params.content) + sizePlusSpacing;
				//}
				//float sizePlusSpacing = _InternalParams.itemsSizes[startingLVHolder.itemIndex] + ctSpacing;
				//if (negativeScroll)
				//    negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = _InternalParams.GetItemOffsetFromParentStart(startingLVHolder.itemIndex) + sizePlusSpacing;
				//else
				//    negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = _InternalParams.contentPanelSize - _InternalParams.GetItemOffsetFromParentStart(startingLVHolder.itemIndex);

				// Items variable values; initializing them to the current LV
				currentLVItemIndexInView = startingLVHolder.itemIndexInView;

				bool currentIsOutside;
				//RectTransform curRecCandidateRT;
				float curRecCandidateSizePlusSpacing;

				// vItemHolder is:
				// first in _VisibleItems, if negativeScroll
				// last in _VisibleItems, else
				int curRecCandidateVHIndex = neg0_pos1 * (_VisibleItemsCount - 1);
				TItemViewsHolder curRecCandidateVH = _VisibleItems[curRecCandidateVHIndex];
				double curInsetFromParentEdge = negativeScroll ? _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(curRecCandidateVH.itemIndexInView)
																: _InternalState.GetItemVirtualInsetFromParentEndUsingItemIndexInView(curRecCandidateVH.itemIndexInView);
				while (true)
				{
					//// vItemHolder is:
					//// first in _VisibleItems, if negativeScroll
					//// last in _VisibleItems, else
					//int curRecCandidateVHIndex = neg0_pos1 * (_VisibleItemsCount - 1);

					//curRecCandidateRT = curRecCandidateVH.root;
					//float lvSize = _InternalParams.itemsSizes[currentLVItemIndex];
					curRecCandidateSizePlusSpacing = _ItemsDesc[curRecCandidateVH.itemIndexInView] + ctSpacing; // major bugfix: 18.12.2016 1:20: must use vItemHolder.ItemIndex INSTEAD of currentLVItemIndex

					//s.Reset(); s.Start();
					//var cv = s.ElapsedMilliseconds;
					//Debug.Log("cv=" + cv);

					////// Commented the comment: this is actually better now, as GetItemVirtualInsetFromParentStartUsingItemIndexInView() is sometimes expensive
					////Commented: using a more efficient way of doing this by using cumulative sizes, even if we need to use an "if"
					////currentIsOutside = negCTInsetFromVPS_posCTInsetFromVPE + (curRecCandidateVH.root.GetInsetFromParentEdge(_Params.content, negStartEdge_posEndEdge) + curRecCandidateSizePlusSpacing) <= 0f;
					//if (negativeScroll)
					//	curInsetFromParentEdge = _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(curRecCandidateVH.itemIndexInView);
					//else
					//	curInsetFromParentEdge = _InternalState.GetItemVirtualOffsetFromParentEndUsingItemIndexInView(curRecCandidateVH.itemIndexInView);
					currentIsOutside = negCTVrtInsetFromVPS_posCTVrtInsetFromVPE + (curInsetFromParentEdge + curRecCandidateSizePlusSpacing) <= 0d;

					if (currentIsOutside)
					{
                        _RecyclableItems.Add(curRecCandidateVH);
						_VisibleItems.RemoveAt(curRecCandidateVHIndex);
						--_VisibleItemsCount;

						if (_VisibleItemsCount == 0) // all items that were considered visible are now outside viewport => will need to seek even more below 
							break;
					}
					else
						break; // the current item is outside(not necessarily completely) the viewport

					// if negative, VIs will be removed from start, so the index of the "next" stays constantly at 0; 
					// if positive, the index of the "next" is decremented by one, because it starts at end and the list is always shortened by 1
					curRecCandidateVHIndex -= neg0_pos1; 

					curInsetFromParentEdge += curRecCandidateSizePlusSpacing;
					curRecCandidateVH = _VisibleItems[curRecCandidateVHIndex];
				}
			}
			//else
			//    negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = neg1_pos0 * _InternalParams.paddingContentStart + neg0_pos1 * _InternalParams.paddingContentEnd;




			// Optimization: saving a lot of computations (especially visible when fast-scrolling using SmoothScrollTo or dragging the scrollbar) by skipping 
			// GetItemVirtualOffsetFromParent[Start/End]UsingItemIndexInView() calls and instead, inferring the offset along the way after calling that method only for the first item
			// Optimization2: trying to estimate the new FIRST visible item by the current scroll position when jumping large distances
			double currentItemVrtInset_negStart_posEnd = double.PositiveInfinity;
			int estimatedAVGVisibleItems = -1;
			if (Math.Abs(abstractDelta) > 10000d // huge jumps need optimization
				&& (estimatedAVGVisibleItems = (int)Math.Round(Math.Min(_InternalState.viewportSize / ((_Params.DefaultItemSize + _InternalState.spacing)), _AVGVisibleItemsCount)))
					< _ItemsDesc.itemsCount
			){
				int estimatedIndexInViewOfNewFirstVisible = (int)
					Math.Round(
						(1d - _InternalState.GetVirtualAbstractNormalizedScrollPosition()) * ((_ItemsDesc.itemsCount - 1) - neg1_pos0 * estimatedAVGVisibleItems)
					);

				double negCTVrtAmountBeforeVP_posCTVrtAmountAfterVP = Math.Max(-negCTVrtInsetFromVPS_posCTVrtInsetFromVPE, 0d);
				int initialEstimatedIndexInViewOfNewFirstVisible = estimatedIndexInViewOfNewFirstVisible;
				int index = initialEstimatedIndexInViewOfNewFirstVisible;
				float itemSize = _ItemsDesc[index];
				double negInsetStart_posInsetEnd =
						neg0_pos1 * (_InternalState.contentPanelVirtualSize - itemSize)
						+ neg1_posMinus1 * _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(index);

				while (negInsetStart_posInsetEnd <= /*minEstimatedItemInsetFrom_negStart_posEnd*/ negCTVrtAmountBeforeVP_posCTVrtAmountAfterVP - itemSize)
				{
					index += neg1_posMinus1;
					itemSize = _ItemsDesc[index];
					negInsetStart_posInsetEnd += itemSize + _InternalState.spacing;
				}

				// If the previous loop didnt' execute at all, it means there's a possibility that the searched item may be after the next item (next=to end if neg scrolling)
				if (index == initialEstimatedIndexInViewOfNewFirstVisible)
				{
					// Executes at least once
					while (negInsetStart_posInsetEnd > /*minEstimatedItemInsetFrom_negStart_posEnd*/ negCTVrtAmountBeforeVP_posCTVrtAmountAfterVP - itemSize)
					{
						index -= neg1_posMinus1;
						itemSize = _ItemsDesc[index];
						negInsetStart_posInsetEnd -= itemSize + _InternalState.spacing;
					}

					// At this point, index is right before (after, if pos scroll) the NLV, but negInsetStart_posInsetEnd needs to be set for the NLV itself
					negInsetStart_posInsetEnd += itemSize + _InternalState.spacing;
				}
				else // index bigger (lesser, if pos scroll) than initial
				{
					// Now index is the NLV's one, but the it needs to be 1 step before (after, if pos scroll)
					// negInsetStart_posInsetEnd is correctly left as NLV's inset
					index -= neg1_posMinus1;
				}

				if (!thereWereVisibletems ||
					negativeScroll && index > currentLVItemIndexInView || // the index should be bigger if going down/right. if the infered one is <=, then startingLV.itemIndexInview is reliable 
					!negativeScroll && index < currentLVItemIndexInView // analogous explanation for pos scroll
				){
					//Debug.Log("est=" + estimatedIndexInViewOfNewFirstVisible + ", def=" + currentLVItemIndexInView + ", actual=" + index);
					currentLVItemIndexInView = index;
					currentItemVrtInset_negStart_posEnd = negInsetStart_posInsetEnd;
				}
			}

			// Infinity means it was not set; if set, it means the position was inferred or this is not the 
			// first iteration (since this variable is updated to keep up with the progress)
			if (double.IsInfinity(currentItemVrtInset_negStart_posEnd) 
				&& currentLVItemIndexInView != endItemIndexInView) // this check is the same as in the loop below. there won't be no "next" item if the current LV is the last in view (first if positive scroll) 
			{
				int nextValueOf_NLVIndexInView = currentLVItemIndexInView + neg1_posMinus1; // next value in the loop below
				if (negativeScroll)
					currentItemVrtInset_negStart_posEnd = _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(nextValueOf_NLVIndexInView);
				else
					currentItemVrtInset_negStart_posEnd = _InternalState.GetItemVirtualInsetFromParentEndUsingItemIndexInView(nextValueOf_NLVIndexInView);
			}

			// Searching for next item(s) that might get visible in order to update them: towards vpEnd on negativeScroll OR towards vpStart else
			do
			{
				// negativeScroll vert/hor: there are no items below/to-the-right-of-the current LV that might need to be made visible
				// positive vert/hor: there are no items above/o-the-left-of-the current LV that might need to be made visible
				if (currentLVItemIndexInView == endItemIndexInView)
					break;

				//int nlvIndex = currentLVItemIndexInView; // TODO pending removal
				int nlvIndexInView = currentLVItemIndexInView;
				float nlvSize;
				bool breakBigLoop = false,
					 negNLVCandidateIsBeforeVP_posNLVCandidateIsAfterVP; // before vpStart, if negative scroll; after vpEnd, else

				do
				{
					nlvIndexInView += neg1_posMinus1;
					nlvSize = _ItemsDesc[nlvIndexInView];
					//if (negativeScroll)
					//	negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV = _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(nlvIndexInView);
					//else
					//	negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV = _InternalState.GetItemVirtualOffsetFromParentEndUsingItemIndexInView(nlvIndexInView);

					//if (negativeScroll)
					//	Debug.Log(currentVrtInset + ", " + _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(nlvIndexInView));
					negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV = currentItemVrtInset_negStart_posEnd;
					negNLVCandidateIsBeforeVP_posNLVCandidateIsAfterVP = negCTVrtInsetFromVPS_posCTVrtInsetFromVPE + (negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV + nlvSize) <= 0d;
					if (negNLVCandidateIsBeforeVP_posNLVCandidateIsAfterVP)
					{
						if (nlvIndexInView == endItemIndexInView) // all items are outside viewport => abort
						{
							breakBigLoop = true;
							break;
						}
					}
					else
					{
						// Next item is after vp(if neg) or before vp (if pos) => no more items will become visible 
						// (this happens usually in the first iteration of this loop inner loop, i.e. negNLVCandidateBeforeVP_posNLVCandidateAfterVP never being true)
						if (negCTVrtInsetFromVPS_posCTVrtInsetFromVPE + negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV > vpSize)
						{
							breakBigLoop = true;
							break;
						}

						// At this point, we've found the real nlv: nlvIndex, nlvH and currentTopToUseForNLV(if negativeScroll)/currentBottomToUseForNLV(if upScroll) were correctly assigned
						break;
					}
					currentItemVrtInset_negStart_posEnd += nlvSize + _InternalState.spacing;
				}
				while (true);

				if (breakBigLoop)
					break;

				int nlvRealIndex = _ItemsDesc.GetItemRealIndexFromViewIndex(nlvIndexInView);

				// Search for a recyclable holder for current NLV
				// This block remains the same regardless of <negativeScroll> variable, because the items in <itemsOutsideViewport> were already added in an order dependent on <negativeScroll>
				// (they are always from <closest to [start]> to <closest to [end]>)
				int i = 0;
				TItemViewsHolder potentiallyRecyclable;
				while (true)
				{
					if (i < _RecyclableItems.Count)
					{
						potentiallyRecyclable = _RecyclableItems[i];
						if (IsRecyclable(potentiallyRecyclable, nlvRealIndex, nlvSize))
						{
							OnBeforeRecycleOrDisableViewsHolder(potentiallyRecyclable, nlvRealIndex);

                            _RecyclableItems.RemoveAt(i);
							nlvHolder = potentiallyRecyclable;
							break;
						}
						++i;
					}
					else
					{
						// Found no recyclable view with the requested height
						nlvHolder = CreateViewsHolder(nlvRealIndex);
						break;
					}
				}

				// Add it in list at [end]
				_VisibleItems.Insert(neg1_pos0 * _VisibleItemsCount, nlvHolder);
				++_VisibleItemsCount;

				// Update its index
				nlvHolder.ItemIndex = nlvRealIndex;
				nlvHolder.itemIndexInView = nlvIndexInView;

				//// Cache its height
				//nlvHolder.cachedSize = _ItemsDescriptor.itemsSizes[nlvIndexInView];

				// Make sure it's parented to content panel
				RectTransform nlvRT = nlvHolder.root;
				nlvRT.SetParent(_Params.content, false);

				// Update its views
				UpdateViewsHolder(nlvHolder);

				// Make sure it's GO is activated
				nlvHolder.root.gameObject.SetActive(true);

				// Make sure it's left-top anchored (the need for this arose together with the feature for changind an item's size 
				// (an thus, the content's size) externally, using RequestChangeItemSizeAndUpdateLayout)
				nlvRT.anchorMin = nlvRT.anchorMax = _InternalState.constantAnchorPosForAllItems;

				//// Though visually not relevant, maybe it helps the UI system 
				//if (negativeScroll) nlvRT.SetAsLastSibling();
				//else nlvRT.SetAsFirstSibling();

				//if (negativeScroll)
				//	currentVirtualInsetFromCTSToUseForNLV = negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV;
				//else
				//	currentVirtualInsetFromCTSToUseForNLV = _InternalState.contentPanelVirtualSize - nlvSize - negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV;
				double currentVirtualInsetFromCTSToUseForNLV =
					neg0_pos1 * (_InternalState.contentPanelVirtualSize - nlvSize) + neg1_posMinus1 * negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV;

				//nlvRT.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(_Params.content, negStartEdge_posEndEdge, negCurrentVrtInsetFromCTSToUseForNLV_posCurrentVrtInsetFromCTEToUseForNLV, nlvSize);
				nlvRT.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(
					_Params.content, 
					_InternalState.startEdge, 
					_InternalState.ConvertItemInsetFromParentStart_FromVirtualToReal(currentVirtualInsetFromCTSToUseForNLV), 
					nlvSize
				);

				// Commented: using cumulative sizes
				//negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV += nlvSizePlusSpacing;


				//float itemSizesUntilNowPlusSpacing = _InternalParams.itemsSizesCumulative[nlvIndex] + nlvIndex * ctSpacing;
				//if (negativeScroll)
				//    negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = _InternalParams.paddingContentStart + itemSizesUntilNowPlusSpacing + ctSpacing;
				//else
				//    negCurrentInsetFromCTSToUseForNLV_posCurrentInsetFromCTEToUseForNLV = _InternalParams.paddingContentStart + itemSizesUntilNowPlusSpacing + ctSpacing;

				// Assure transversal size and transversal position based on parent's padding and width settings
				nlvRT.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(_Params.content, transvStartEdge, ctPadTransvStart, allItemsTransversalSizes);

				currentLVItemIndexInView = nlvIndexInView;
				currentItemVrtInset_negStart_posEnd += nlvSize + _InternalState.spacing;
			}
			while (true);

			// Keep track of the <maximum number of items that were visible since last scroll view size change>, so we can optimize the object pooling process
			// by destroying objects in recycle bin only if the aforementioned number is  less than <numVisibleItems + numItemsInRecycleBin>,
			// and of course, making sure at least 1 item is in the bin all the time
			if (_VisibleItemsCount > _ItemsDesc.maxVisibleItemsSeenSinceLastScrollViewSizeChange)
                _ItemsDesc.maxVisibleItemsSeenSinceLastScrollViewSizeChange = _VisibleItemsCount;

			// Disable all recyclable views
			// Destroy remaining unused views, BUT keep one, so there's always a reserve, instead of creating/destroying very frequently
			// + keep <numVisibleItems + numItemsInRecycleBin> abvove <_InternalParams.maxVisibleItemsSeenSinceLastScrollViewSizeChange>
			// See GetNumExcessObjects()
			GameObject go;
			TItemViewsHolder vh;
			for (int i = 0; i < _RecyclableItems.Count;)
			{
				vh = _RecyclableItems[i];
				go = vh.root.gameObject;
				if (go.activeSelf)
					OnBeforeRecycleOrDisableViewsHolder(vh, -1); // -1 means it'll be disabled, not re-used ATM

				go.SetActive(false);
				if (ShouldDestroyRecyclableItem(vh, GetNumExcessObjects() > 0))
				{
					GameObject.Destroy(go);
                    _RecyclableItems.RemoveAt(i);
					++_ItemsDesc.destroyedItemsSinceLastScrollViewSizeChange;
				}
				else
					++i;
			}

			// Last result weighs 9x more than the current result in calculating the AVG to prevent "outliers"
			_AVGVisibleItemsCount = _AVGVisibleItemsCount * .9d + _VisibleItemsCount * .1d;
		}

		int GetNumExcessObjects()
		{
			if (_RecyclableItems.Count > 1)
			{
				int excess = (_RecyclableItems.Count + _VisibleItemsCount) - GetMaxNumObjectsToKeepInMemory();
				if (excess > 0)
					return excess;
			}

			return 0;
		}

		int GetMaxNumObjectsToKeepInMemory()
		{
			return _Params.recycleBinCapacity > 0 ?
					  _Params.recycleBinCapacity + _VisibleItemsCount
					  : _ItemsDesc.maxVisibleItemsSeenSinceLastScrollViewSizeChange
						+ _ItemsDesc.destroyedItemsSinceLastScrollViewSizeChange + 1;
		}

		void UpdateGalleryEffectIfNeeded()
		{
			if (_Params.galleryEffectAmount == 0f)
			{
				if (_PrevGalleryEffectAmount == _Params.galleryEffectAmount)
					return;

				// Make sure the items in the recycle bin don't preserve the local scale from the gallery effect
				foreach (var recycled in _RecyclableItems)
					if (recycled != null && recycled.root)
						recycled.root.localScale = Vector3.one;
			}

			if (_VisibleItemsCount == 0)
				return;

			Func<RectTransform, float> getCornerFn;
			float viewportPivot_MinimumIsMinus1_MaximumIs1 = _Params.galleryEffectViewportPivot * 2 - 1f;
			float hor1_vertMinus1;
			if (_Params.scrollRect.horizontal)
			{
				hor1_vertMinus1 = 1;
				getCornerFn = RectTransformExtensions.GetWorldRight;
			}
			else
			{
				hor1_vertMinus1 = -1;
				getCornerFn = RectTransformExtensions.GetWorldTop;
			}

			float //midIndex = _VisibleItemsCount / 2, 
				 halfVPSize = _InternalState.viewportSize / 2, 
				 //vpCenter = (getCornerFn(_Params.viewport) - halfVPSize) + ();
				 vpPivot = (getCornerFn(_Params.viewport) - halfVPSize) + (halfVPSize * (viewportPivot_MinimumIsMinus1_MaximumIs1 * hor1_vertMinus1));
			for (int i = 0; i < _VisibleItemsCount; i++)
			{
				var vh = _VisibleItems[i];
				float center = getCornerFn(vh.root) - _ItemsDesc[vh.itemIndexInView] / 2;

				float t01 = 1f - Mathf.Clamp01(Mathf.Abs(center - vpPivot) / halfVPSize);
				vh.root.localScale = Vector3.Lerp(Vector3.one * (1f - _Params.galleryEffectAmount), Vector3.one, t01);
			}
			_PrevGalleryEffectAmount = _Params.galleryEffectAmount;
		}
		

		/// <inheritdoc/>
		class InternalState : InternalStateGeneric<TParams, TItemViewsHolder>
		{
			internal static InternalState CreateFromSourceParamsOrThrow(TParams sourceParams, ItemsDescriptor itemsDescriptor)
			{
				if (sourceParams.scrollRect.horizontal && sourceParams.scrollRect.vertical) {
					Debug.LogError ("Can't optimize a ScrollRect with both horizontal and vertical scrolling modes. Disable one of them");
					throw new UnityException ("Can't optimize a ScrollRect with both horizontal and vertical scrolling modes. Disable one of them");
				}

				return new InternalState(sourceParams, itemsDescriptor);
			}


			protected InternalState(TParams sourceParams, ItemsDescriptor itemsDescriptor) : base(sourceParams, itemsDescriptor) {}
		}
	}
}
