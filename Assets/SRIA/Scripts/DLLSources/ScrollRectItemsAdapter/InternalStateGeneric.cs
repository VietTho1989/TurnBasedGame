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
    /// <summary>
	/// Contains cached variables, helper methods and generally things that are not exposed to inheritors. Note: the LayoutGroup component on content, if any, will be disabled.
    /// <para>Comments format: value if vertical scrolling/value if horizontal scrolling</para>
	/// </summary>
    abstract class InternalStateGeneric<TParams, TItemViewsHolder> 
		where TParams : BaseParams 
		where TItemViewsHolder : BaseItemViewsHolder 
	{ 
        #region Fields & Props
        // Constant params (until the scrollview size changes)
        //internal readonly double proximityToLimitNeeded01ToResetPos = .95d;
        internal const double proximityToLimitNeeded01ToResetPos = 1d; // todo replace this with the avtual value if everything works fine
		internal readonly Vector2 constantAnchorPosForAllItems = new Vector2(0f, 1f); // top-left
		internal float viewportSize;
		internal float paddingContentStart; // top/left
		internal float transversalPaddingContentStart; // left/top
		internal float paddingContentEnd; // bottom/right
		internal float paddingStartPlusEnd;
		internal float spacing;
		internal RectTransform.Edge startEdge; // RectTransform.Edge.Top/RectTransform.Edge.Left
		internal RectTransform.Edge endEdge; // RectTransform.Edge.Bottom/RectTransform.Edge.Right
		internal RectTransform.Edge transvStartEdge; // RectTransform.Edge.Left/RectTransform.Edge.Top

		// Cache params
		internal double lastProcessedCTVirtualInsetFromParentStart; // normY / 1-normX
		//internal int realIndexOfFirstItemInView;
		// 0, if contentSize < MaxContentSize; else, it's the number of times the content panel's position was reset to reserve space after it for the new items which become visible
		internal double contentPanelSkippedInsetDueToVirtualization;
		internal Vector2 scrollViewSize;
		//internal float[] itemsSizes; // heights/widths
		//internal double[] itemsSizesCumulative; // heights/widths
		//internal double cumulatedSizesOfAllItemsPlusSpacing;
		internal float contentPanelSize; // height/width
		internal double contentPanelVirtualSize; // height/width
		//internal bool onScrollPositionChangedFiredAndVisibilityComputedForCurrentItems;
		internal bool updateRequestPending;
		//internal bool layoutRebuildPendingDueToScrollViewSizeChangeEvent;
		//internal bool layoutIsBeingRebuildDueToScrollViewSizeChangeEvent;
		internal bool computeVisibilityTwinPassScheduled;
		internal bool preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass;
		internal bool lastComputeVisibilityHadATwinPass;

		internal bool HasScrollViewSizeChanged { get { return scrollViewSize != _SourceParams.ScrollViewRT.rect.size; } }
		// (Update: setting it to 10 solved some issues. It's better this way. Maybe 100 is the upper-bound)
		// it should stay this should be at least 3. But it's HIGHLY RECOMMENDED to be 4 (this fixed ScrollTo in horizontal scroll views)
		// Even if "skipping" is on (the content virtual size is >= MaxContentPanelRealSize), the content's real size may slightly differ from this, 
		// even if this very value is passed to SetInsetAndSize as size (the biggest observer error was ~.001). 
		// This should be taken into consideration when checking wether the skipping is on or off (ex. ctRealSize < MaxContentPanelRealSize DOES NOT imply skipping is on)
		internal float MaxContentPanelRealSize { get { return viewportSize * 10; } } 
		internal double ContentPanelVirtualInsetFromViewportStart { get { return contentPanelSkippedInsetDueToVirtualization + _SourceParams.content.GetInsetFromParentEdge(_SourceParams.viewport, startEdge); } }
		internal double ContentPanelVirtualInsetFromViewportEnd { get { return -contentPanelVirtualSize + viewportSize - ContentPanelVirtualInsetFromViewportStart; } }
		internal double VirtualScrollableArea { get { return contentPanelVirtualSize - viewportSize; } }
		internal float RealScrollableArea { get { return contentPanelSize - viewportSize; } }

		ItemsDescriptor _ItemsDesc;
		TParams _SourceParams;
		Func<RectTransform, float> _GetRTCurrentSizeFn;
        #endregion


		protected InternalStateGeneric(TParams sourceParams, ItemsDescriptor itemsDescriptor)
		{
			_SourceParams = sourceParams;
            _ItemsDesc = itemsDescriptor;

			var lg = sourceParams.content.GetComponent<LayoutGroup>();
			if (lg && lg.enabled)
			{
				lg.enabled = false;
				Debug.Log("LayoutGroup on GameObject " + lg.name + " has beed disabled in order to use ScrollRectItemsAdapter8");
			}

			var contentSizeFitter = sourceParams.content.GetComponent<ContentSizeFitter>();
			if (contentSizeFitter && contentSizeFitter.enabled)
			{
				contentSizeFitter.enabled = false;
				Debug.Log("ContentSizeFitter on GameObject " + contentSizeFitter.name + " has beed disabled in order to use ScrollRectItemsAdapter8");
			}

			var layoutElement = sourceParams.content.GetComponent<LayoutElement>();
			if (layoutElement)
			{
				GameObject.Destroy(layoutElement);
				Debug.Log("LayoutElement on GameObject " + contentSizeFitter.name + " has beed DESTROYED in order to use ScrollRectItemsAdapter8");
			}

			if (sourceParams.scrollRect.horizontal)
			{
				startEdge = RectTransform.Edge.Left;
				endEdge = RectTransform.Edge.Right;
				transvStartEdge = RectTransform.Edge.Top;
				_GetRTCurrentSizeFn = root => root.rect.width;
			}
			else
			{
				startEdge = RectTransform.Edge.Top;
				endEdge = RectTransform.Edge.Bottom;
				transvStartEdge = RectTransform.Edge.Left;
				_GetRTCurrentSizeFn = root => root.rect.height;
			}


			_SourceParams.UpdateContentPivotFromGravityType();

			CacheScrollViewInfo();
		}


		internal void CacheScrollViewInfo()
		{
			scrollViewSize = _SourceParams.ScrollViewRT.rect.size;
			RectTransform vpRT = _SourceParams.viewport;
			Rect vpRect = vpRT.rect;
			if (_SourceParams.scrollRect.horizontal)
			{
				viewportSize = vpRect.width;
				paddingContentStart = _SourceParams.contentPadding.left;
				paddingContentEnd = _SourceParams.contentPadding.right;
				transversalPaddingContentStart = _SourceParams.contentPadding.top;
				_ItemsDesc.itemsConstantTransversalSize = _SourceParams.content.rect.height - (transversalPaddingContentStart + _SourceParams.contentPadding.bottom);
			}
			else
			{
				viewportSize = vpRect.height;
				paddingContentStart = _SourceParams.contentPadding.top;
				paddingContentEnd = _SourceParams.contentPadding.bottom;
				transversalPaddingContentStart = _SourceParams.contentPadding.left;
                _ItemsDesc.itemsConstantTransversalSize = _SourceParams.content.rect.width - (transversalPaddingContentStart + _SourceParams.contentPadding.right);
			}

			spacing = _SourceParams.contentSpacing;

			// There's no concept of content start/end padding. instead, the spacing amount is appended before+after the first+last item
			if (_SourceParams.loopItems)
				paddingContentStart = paddingContentEnd = spacing;

			paddingStartPlusEnd = paddingContentStart + paddingContentEnd;
		}

		internal void OnItemsCountChanged(int itemsPrevCount, bool contentPanelEndEdgeStationary)
		{
			OnCumulatedSizesOfAllItemsChanged(contentPanelEndEdgeStationary, true);

			//// Schedule a new ComputeVisibility iteration
			//onScrollPositionChangedFiredAndVisibilityComputedForCurrentItems = false;

			computeVisibilityTwinPassScheduled = false;
			lastComputeVisibilityHadATwinPass = false;
		}

		/// <summary><paramref name="viewsHolder"/> will be null if the item is not visible</summary>
		/// <returns>the resolved size, as this may be a bit different than the passed <paramref name="requestedSize"/> for huge data sets (>100k items)</returns>
		internal float ChangeItemSizeAndUpdateContentSizeAccordingly(TItemViewsHolder viewsHolder, int itemIndexInView, float requestedSize, bool itemEndEdgeStationary, bool rebuild = true)
		{
			//LiveDebugger8.logR("ChangeItemCountInternal");
			//if (itemsSizes == null)
			//	throw new UnityException("Wait for initialization first");

			float resolvedSize;
			if (viewsHolder == null)
				resolvedSize = requestedSize;
			else
			{
				if (viewsHolder.root == null)
					throw new UnityException("God bless: shouldn't happen if implemented according to documentation/examples"); // shouldn't happen if implemented according to documentation/examples

				RectTransform.Edge edge;
				float realInsetToSet;
				if (itemEndEdgeStationary)
				{
					edge = endEdge;
					realInsetToSet = GetItemInferredRealInsetFromParentEnd(itemIndexInView);
				}
				else
				{
					edge = startEdge;
					realInsetToSet = GetItemInferredRealInsetFromParentStart(itemIndexInView);
				}
				viewsHolder.root.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(_SourceParams.content, edge, realInsetToSet, requestedSize);

				// Even though we know the desired size, the one actually set by the UI system may be different, so we cache that one
				resolvedSize = _GetRTCurrentSizeFn(viewsHolder.root);
				//viewsHolder.cachedSize = resolvedSize;
			}

            _ItemsDesc.BeginChangingItemsSizes(itemIndexInView);
			//var bef = _ItemsDesc.GetItemSizeCumulative(itemIndexInView+1);
            _ItemsDesc[itemIndexInView] = resolvedSize;
            _ItemsDesc.EndChangingItemsSizes();
			//var aft = _ItemsDesc.GetItemSizeCumulative(itemIndexInView+1);

			//Debug.Log(bef + "; aft=" + aft);


			OnCumulatedSizesOfAllItemsChanged(itemEndEdgeStationary, rebuild);

			return resolvedSize;
		}

        /// <summary>
        /// Assuming there vhs.Count is > 0. IMPORTANT: vhs should be in order (their itemIndexInView 
        /// should be in ascending order - not necesarily consecutive)
        /// </summary>
        internal void OnItemsSizesChangedExternally(List<TItemViewsHolder> vhs, bool itemEndEdgeStationary)
		{
			if (_ItemsDesc.itemsCount == 0)
				throw new UnityException("Cannot change item sizes externally if the items count is 0!");

			int vhsCount = vhs.Count;
			int viewIndex;
			TItemViewsHolder vh;
			//var insetEdge = itemEndEdgeStationary ? endEdge : startEdge;
			float currentSize;

            _ItemsDesc.BeginChangingItemsSizes(vhs[0].itemIndexInView);
            for (int i = 0; i < vhsCount; ++i)
			{
				vh = vhs[i];
				viewIndex = vh.itemIndexInView;
				currentSize = _GetRTCurrentSizeFn(vh.root);

                _ItemsDesc[viewIndex] = currentSize;
                //_ItemsDesc.UpdateCumulatedSomehow();
            }
            _ItemsDesc.EndChangingItemsSizes();

            // Update the remaining cumulative values until end
            //for (int i = num; i < itemsCount; ++i)
            //	itemsSizesCumulative[i] = itemsSizesCumulative[i - 1] + itemsSizes[i];
            //_ItemsDesc.UpdateCumulatedSomehow();

            OnCumulatedSizesOfAllItemsChanged(itemEndEdgeStationary, true);

			if (vhsCount > 0)
				// Bugfix: updating their positions after the content's, because the content's size would shift the items without OUR consent :)
				CorrectPositions(vhs, true);//, itemEndEdgeStationary);
		}

		internal void CorrectPositions(List<TItemViewsHolder> vhs, bool alsoCorrectTransversalPositioning)//, bool itemEndEdgeStationary)
		{
			// Update the positions of the provided vhs so they'll retain their position relative to the viewport
			TItemViewsHolder vh;
			int count = vhs.Count;
			//var edge = itemEndEdgeStationary ? endEdge : startEdge;
			//Func<int, float> getInferredRealOffsetFromParentStartOrEndFn;
			//if (itemEndEdgeStationary)
			//	getInferredRealOffsetFromParentStartOrEndFn = GetItemInferredRealOffsetFromParentEnd;
			//else
			//	getInferredRealOffsetFromParentStartOrEndFn = GetItemInferredRealOffsetFromParentStart;

			double insetStartOfCurItem = GetItemVirtualInsetFromParentStartUsingItemIndexInView(vhs[0].itemIndexInView);
			float curSize;
			for (int i = 0; i < count; ++i)
			{
				vh = vhs[i];
				curSize = _ItemsDesc[vh.itemIndexInView];
				vh.root.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(
					_SourceParams.content,
					//edge,
					startEdge,
					//getInferredRealOffsetFromParentStartOrEndFn(vh.itemIndexInView),
					//GetItemInferredRealInsetFromParentStart(vh.itemIndexInView),
					ConvertItemInsetFromParentStart_FromVirtualToReal(insetStartOfCurItem),
					curSize
				);
				insetStartOfCurItem += curSize + spacing;

				if (alsoCorrectTransversalPositioning)
					vh.root.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(transvStartEdge, transversalPaddingContentStart, _ItemsDesc.itemsConstantTransversalSize);
			}
		}

		internal void UpdateLastProcessedCTVirtualInsetFromParentStart() { lastProcessedCTVirtualInsetFromParentStart = ContentPanelVirtualInsetFromViewportStart; }

		/// <summary> See the <see cref="SRIA{TParams, TItemViewsHolder}.GetVirtualAbstractNormalizedScrollPosition"/> for documentation</summary>
		internal double GetVirtualAbstractNormalizedScrollPosition()
		{
			float vpSize = viewportSize;
			double ctVrtSize = contentPanelVirtualSize;
			if (vpSize > ctVrtSize)
				return _SourceParams.content.GetInsetFromParentEdge(_SourceParams.viewport, startEdge) / vpSize;

			double ctVrtInsetWhenScrolledToMaxEnd = -ctVrtSize + vpSize;
			return 1d - ContentPanelVirtualInsetFromViewportStart / ctVrtInsetWhenScrolledToMaxEnd;
		}

		internal bool SetVirtualAbstractNormalizedScrollPosition(double pos)
		{
			if (viewportSize > contentPanelVirtualSize)
				return false; // N/A

			// The new real inset for the content is not set as accuratly as possible (needs too much thinking :) ), but in practice the small error is not visible
			double virtualScrollArea = contentPanelVirtualSize - viewportSize;
			double newVirtualInsetIfRealOffsetIsZero = (1d - pos) * virtualScrollArea;

			float realScrollArea = contentPanelSize - viewportSize;
			float newRealInset;
			if (pos < .000001d) // manual clamp
				newRealInset = -realScrollArea;
			else if (pos > .999999d) // manual clamp
				newRealInset = 0f;
			else
				newRealInset = -(float)Math.Min(float.MaxValue, Math.Max(float.MinValue, newVirtualInsetIfRealOffsetIsZero % realScrollArea));
			_SourceParams.content.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(startEdge, newRealInset, contentPanelSize);
			contentPanelSkippedInsetDueToVirtualization = -newVirtualInsetIfRealOffsetIsZero - newRealInset;

			return true;
		}

		//public double ttt;
		internal void SetContentVirtualInsetFromViewportStart(double virtualInset)
		{
			double vsa = VirtualScrollableArea;
			if (!_SourceParams.loopItems)
			{
				if (virtualInset > 0d)
				{
					virtualInset = 0d;
					Debug.Log("virtualInset>0: " + virtualInset + ". Clamping...");
				}
				else if (-virtualInset > vsa)
				{
					Debug.Log("-virtualInset("+(-virtualInset)+") > virtualScrollableArea("+vsa+ "). Clamping...");
					virtualInset = -vsa;
				}
			}

			double newRealCTInsetFromVPS;
			//double h = -12345d;
			//int iu = 0;
			float rsa = 12345f;
			double insetDistance = 12345f;
			//double cpsBef = contentPanelSize;
			//double cpsMaxBef = MaxContentPanelRealSize;

			// TODO use "contentPanelSize < MaxContentPanelRealSize" again when resolved the bug where max size slightly differs from the real one, even though the skip mode is "on")
			// TODO use "contentPanelSize < MaxContentPanelRealSize" again when resolved the bug where max size slightly differs from the real one, even though the skip mode is "on")
			// TODO use "contentPanelSize < MaxContentPanelRealSize" again when resolved the bug where max size slightly differs from the real one, even though the skip mode is "on")
			// TODO use "contentPanelSize < MaxContentPanelRealSize" again when resolved the bug where max size slightly differs from the real one, even though the skip mode is "on")
			// TODO use "contentPanelSize < MaxContentPanelRealSize" again when resolved the bug where max size slightly differs from the real one, even though the skip mode is "on")
			// TODO use "contentPanelSize < MaxContentPanelRealSize" again when resolved the bug where max size slightly differs from the real one, even though the skip mode is "on")

			//if (contentPanelSize < MaxContentPanelRealSize) // the easy case
			//	newRealCTInsetFromVPS = virtualInset;
			//else
			//{
			//	iu = 1;
				rsa = RealScrollableArea; // real scrollable area
				insetDistance = Math.Abs(virtualInset);
				//h = insetDistance % rsa;
				newRealCTInsetFromVPS = Math.Sign(virtualInset) * (insetDistance % rsa);
				if (insetDistance < rsa) // the content panel can handle it without the need to skip inset
					contentPanelSkippedInsetDueToVirtualization = 0;
				else
					contentPanelSkippedInsetDueToVirtualization = virtualInset - newRealCTInsetFromVPS;

				//Debug.Log("insetDistance="+ insetDistance + ", rsa=" + rsa + ", newRealCTInsetFromVPS=" + newRealCTInsetFromVPS + ", sk=" + contentPanelSkippedInsetDueToVirtualization);
			//}
			_SourceParams.content.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(startEdge, (float)newRealCTInsetFromVPS, contentPanelSize);

			Canvas.ForceUpdateCanvases();

			//if (ttt > ContentPanelVirtualInsetFromViewportStart)
			//{
			//	int x = 0;
			//	int xww = 0;

			//}
		}

		internal double GetItemVirtualInsetFromParentStartUsingItemIndexInView(int itemIndexInView)
		{
			double cumulativeSizeOfAllItemsBeforePlusSpacing = 0d;
			if (itemIndexInView > 0)
				cumulativeSizeOfAllItemsBeforePlusSpacing = _ItemsDesc.GetItemSizeCumulative(itemIndexInView - 1) + itemIndexInView * (double)spacing;

			return paddingContentStart + cumulativeSizeOfAllItemsBeforePlusSpacing;
		}
		internal double GetItemVirtualInsetFromParentEndUsingItemIndexInView(int itemIndexInView)
		{ return contentPanelVirtualSize - GetItemVirtualInsetFromParentStartUsingItemIndexInView(itemIndexInView) - _ItemsDesc[itemIndexInView]; }
		internal float GetItemInferredRealInsetFromParentStart(int itemIndexInView)
		{ return ConvertItemInsetFromParentStart_FromVirtualToReal(GetItemVirtualInsetFromParentStartUsingItemIndexInView(itemIndexInView)); }
		internal float GetItemInferredRealInsetFromParentEnd(int itemIndexInView)
		{ return contentPanelSize - GetItemInferredRealInsetFromParentStart(itemIndexInView) - _ItemsDesc[itemIndexInView]; }

		//internal double ConvertItemOffsetFromParentStart_FromRealToVirtual(float realOffsetFromParrentStart)
		//{ return -contentPanelSkippedInsetDueToVirtualization + realOffsetFromParrentStart; }
		internal float ConvertItemInsetFromParentStart_FromVirtualToReal(double virtualInsetFromParrentStart)
		{ return (float)(virtualInsetFromParrentStart + contentPanelSkippedInsetDueToVirtualization); }

		void OnCumulatedSizesOfAllItemsChanged(bool contentPanelEndEdgeStationary, bool rebuild = true)
		{
			_ItemsDesc.cumulatedSizesOfAllItemsPlusSpacing = _ItemsDesc.CumulatedSizeOfAllItems + Math.Max(0d, _ItemsDesc.itemsCount - 1) * spacing;
			OnCumulatedSizesOfAllItemsPlusSpacingChanged(contentPanelEndEdgeStationary, rebuild);
		}

		//public float maxStored;
		void OnCumulatedSizesOfAllItemsPlusSpacingChanged(bool contentPanelEndEdgeStationary, bool rebuild = true)
		{
			double contentPrevVrtInsetFromVPEnd = ContentPanelVirtualInsetFromViewportEnd;
			double contentPrevVrtInsetFromVPStart = ContentPanelVirtualInsetFromViewportStart;
			double contentPanelPrevVirtualSize = contentPanelVirtualSize;

			contentPanelVirtualSize = _ItemsDesc.cumulatedSizesOfAllItemsPlusSpacing + paddingStartPlusEnd;
			float newContentPanelSize;
			bool contentPanelNewVirtualSizeIsSmallerThanMaxRealSize = contentPanelVirtualSize < MaxContentPanelRealSize;
			if (contentPanelNewVirtualSizeIsSmallerThanMaxRealSize) // the virtual size will be the same as the real size, because the data set is too small
			{
				newContentPanelSize = (float)contentPanelVirtualSize;
				contentPanelSkippedInsetDueToVirtualization = 0;
			}
			else
				newContentPanelSize = MaxContentPanelRealSize;
			//maxStored = MaxContentPanelRealSize;

			//Debug.Log("MaxContentPanelRealSize="+MaxContentPanelRealSize 
			//	+ ", newContentPanelSize=" + newContentPanelSize
			//	+ ", contentPanelSize=" + contentPanelSize
			//	+ ", contentPanelVirtualSize=" + contentPanelVirtualSize
			//	+ ", contentPanelPrevVirtualSize=" + contentPanelPrevVirtualSize
			//	);


			//Debug.Log("(befvp)"+_SourceParams.viewport.rect.width + ", h=" + _SourceParams.viewport.rect.height);
			float prevContentPanelSize = contentPanelSize;
			contentPanelSize = newContentPanelSize;
			float ctRealSizeChange = contentPanelSize - prevContentPanelSize;
			var edgeToUse = contentPanelEndEdgeStationary ? endEdge : startEdge;
			float insetToUse = _SourceParams.content.GetInsetFromParentEdge(_SourceParams.viewport, edgeToUse);
			_SourceParams.content.SetInsetAndSizeFromParentEdgeWithCurrentAnchors(_SourceParams.viewport, edgeToUse, insetToUse, contentPanelSize);

			//Debug.Log("(bef)"+contentPanelSize.ToString("#.######") + ", rs=" + _SourceParams.content.rect.width.ToString("#.######") + ", max=" + MaxContentPanelRealSize.ToString("#.######"));

			if (rebuild)
			{
				_SourceParams.scrollRect.Rebuild(CanvasUpdate.PostLayout);
				Canvas.ForceUpdateCanvases();
			}

			if (contentPanelNewVirtualSizeIsSmallerThanMaxRealSize)
				return;

			//Debug.Log("(aftvp)"+_SourceParams.viewport.rect.width + ", h=" + _SourceParams.viewport.rect.height);

			//Debug.Log(contentPanelSize.ToString("#.######") + ", rs=" + _SourceParams.content.rect.width.ToString("#.######") + ", max=" + MaxContentPanelRealSize.ToString("#.######"));

			// IMPORTANT: it's assumed that when the scrollview's size changes, this method is called with contentPanelEndEdgeStationary=false, 
			// so that if the ct size and ct vrt size both should change, this will be done by fixing the start edge, in order to preserve the skip amount (easier implementation. works for now)

			// TODO only do this if the virtual size didn't change + if it did, include code that also takes the real size change needed into account 
			double ctVirtualSizeChange = contentPanelVirtualSize - contentPanelPrevVirtualSize;
			//Debug.Log("ctVirtualSizeChange=" + ctVirtualSizeChange);
			float cutRealAmountFoundBeforeVPE_IfEndStat_RealSizeHasShrunk = 0f;
			//if (ctRealSizeChange != 0f)
			//{
			//	// Commented: changing content real size due to scrollview size change is assumed will always call this method with contentPanelEndEdgeStationary=false;
			//	//if (contentPanelEndEdgeStationary)
			//	//	contentPanelSkippedInsetDueToVirtualization += ctRealSizeChange;

			//	if (!contentPanelEndEdgeStationary)
			//	{
			//		if (ctRealSizeChange < 0d) // smaller real content
			//		{
			//			float prevCTEDistanceFromVPE = Math.Abs(viewportSize - insetToUse /*inset from start*/ - prevContentPanelSize);
			//			// The content prev dist from vpe is smaller than the cut in its size => it needs to be shifted DOWN/RIGHT
			//			var cutInRealSize = -ctRealSizeChange;
			//			if (prevCTEDistanceFromVPE < cutInRealSize)
			//			{
			//				cutRealAmountFoundBeforeVPE_IfEndStat_RealSizeHasShrunk = cutInRealSize - prevCTEDistanceFromVPE;
			//				contentPanelSkippedInsetDueToVirtualization += cutRealAmountFoundBeforeVPE_IfEndStat_RealSizeHasShrunk;

			//				//if (ctVirtualSizeChange != 0d)
			//				//{
			//				//	// Set it back because the next call should also have ctVirtualSizeChange != 0 in order to continue as if the content's real size was already correct
			//				//	contentPanelVirtualSize = contentPanelPrevVirtualSize; 
			//				//	OnCumulatedSizesOfAllItemsPlusSpacingChanged(contentPanelEndEdgeStationary, true);
			//				//}
			//				//return;
			//			}
			//		}
			//	}

			//	//if (ctVirtualSizeChange != 0d)
			//	//	throw new UnityException("Both the content size and the content virtual size had changed. This is not allowed");
			//}
			//Debug.Log("willdo " + (ctVirtualSizeChange != 0d));

			if (ctVirtualSizeChange != 0d || ctRealSizeChange != 0f)
			{
				//Debug.LogError("Here3");
				var cutInVirtualSize = -ctVirtualSizeChange;

				// TODO also test this case when the vp shrinks and the virtual size also shrinks
				// TODO also test this case when the vp shrinks and the virtual size also shrinks
				// TODO also test this case when the vp shrinks and the virtual size also shrinks
				// TODO also test this case when the vp shrinks and the virtual size also shrinks
				// TODO also test this case when the vp shrinks and the virtual size also shrinks
				if (contentPanelEndEdgeStationary)
				{
					contentPanelSkippedInsetDueToVirtualization -= ctVirtualSizeChange;

					if (ctVirtualSizeChange < 0d) // smaller content
					{
						double prevCTSVrtDistanceFromVPS = Math.Abs(contentPrevVrtInsetFromVPStart);
						// The content prev amount before vp is smaller than the cut in its size => it needs to be shifted UP/LEFT
						if (prevCTSVrtDistanceFromVPS < cutInVirtualSize)
						{
							var cutAmountFoundAfterVPE = cutInVirtualSize - prevCTSVrtDistanceFromVPS;
							contentPanelSkippedInsetDueToVirtualization -= cutAmountFoundAfterVPE;
						}
					}
					else
					{
						if (contentPanelSize > prevContentPanelSize)
							// If the content panel's real size increased, take that difference out from the skipped inset
							contentPanelSkippedInsetDueToVirtualization += ctRealSizeChange;
					}
				}
				else
				{
					if (ctVirtualSizeChange < 0d) // smaller content
					{
						double prevCTEVrtDistanceFromVPE = Math.Abs(contentPrevVrtInsetFromVPEnd);
						double cutInVrtAndRealSize = cutInVirtualSize;
						if (ctRealSizeChange < 0f)
							cutInVrtAndRealSize -= ctRealSizeChange;

						// The content prev vrt dist from vpe is smaller than the cut in its size => it needs to be shifted DOWN/RIGHT
						if (prevCTEVrtDistanceFromVPE < cutInVrtAndRealSize) 
						{
							var cutVrtAmountFoundBeforeVPE = cutInVrtAndRealSize - prevCTEVrtDistanceFromVPE;
							contentPanelSkippedInsetDueToVirtualization +=
								(cutVrtAmountFoundBeforeVPE); 
								//- cutRealAmountFoundBeforeVPE_IfEndStat_RealSizeHasShrunk); // this was already added above, don't add it again
						}
					}
					else if (ctRealSizeChange < 0d) // smaller real content
					{
						float prevCTEDistanceFromVPE = Math.Abs(viewportSize - insetToUse /*inset from start*/ - prevContentPanelSize);
						// The content prev dist from vpe is smaller than the cut in its size => it needs to be shifted DOWN/RIGHT
						var cutInRealSize = -ctRealSizeChange;
						if (prevCTEDistanceFromVPE < cutInRealSize)
						{
							cutRealAmountFoundBeforeVPE_IfEndStat_RealSizeHasShrunk = cutInRealSize - prevCTEDistanceFromVPE;
							contentPanelSkippedInsetDueToVirtualization += cutRealAmountFoundBeforeVPE_IfEndStat_RealSizeHasShrunk;

							//if (ctVirtualSizeChange != 0d)
							//{
							//	// Set it back because the next call should also have ctVirtualSizeChange != 0 in order to continue as if the content's real size was already correct
							//	contentPanelVirtualSize = contentPanelPrevVirtualSize; 
							//	OnCumulatedSizesOfAllItemsPlusSpacingChanged(contentPanelEndEdgeStationary, true);
							//}
							//return;
						}
					}
				}
			}
		}
	}
}
