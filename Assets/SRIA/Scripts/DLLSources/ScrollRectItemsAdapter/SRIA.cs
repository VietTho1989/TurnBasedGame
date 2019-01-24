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
	/// <para>Old name: ScrollRectItemsAdapter8 (renamed in v3.0 to SRIA)</para>
	/// <para>Base abstract component that you need to extend in order to provide an implementation for <see cref="CreateViewsHolder(int)"/> and <see cref="UpdateViewsHolder(TItemViewsHolder)"/>. 
	/// Should be attached to the GameObject containing the ScrollRect to be optimized.
	/// Any views holder should extend <see cref="BaseItemViewsHolder"/>, so you can provide it as the generic parameter <typeparamref name="TItemViewsHolder"/> when implementing SRIA.
	/// Extending <see cref="BaseParams"/> is optional. Based on your needs. Provide it as generic parameter <typeparamref name="TParams"/> when implementing SRIA</para>
	/// <para>How it works, in a nutshell (it's recommended to manually go through the example code in order to fully understand the mechanism):</para>
	/// <para>1. create your own implementation of <see cref="BaseItemViewsHolder"/>, let's name it MyItemViewsHolder</para>
	/// <para>2. create your own implementation of <see cref="BaseParams"/> (if needed), let's name it MyParams</para>
	/// <para>3. create your own implementation of SRIA&lt;MyParams, MyItemViewsHolder&gt;, let's name it MyScrollRectItemsAdapter</para>
	/// <para>4. instantiate MyScrollRectItemsAdapter</para>
	/// <para>5. call MyScrollRectItemsAdapter.ResetItemsCount(int) once (and any time your dataset is changed) and the following things will happen:</para>
	/// <para>    5.1. <see cref="CollectItemsSizes(ItemCountChangeMode, int, int, ItemsDescriptor)"/> will be called (which you can optionally implement to provide your own sizes, if known beforehand)</para>
	/// <para>    5.2. <see cref="CreateViewsHolder(int)"/> will be called for enough items to fill the viewport. Once a ViewsHolder is created, it'll be re-used when it goes off-viewport </para>
	/// <para>          - newOrRecycledViewsHolder.root will be null, so you need to instantiate your prefab, assign it and call newOrRecycledViewsHolder.CollectViews(). Alternatively, you can call its <see cref="AbstractViewsHolder.Init(GameObject, int, bool, bool)"/> method, which can do a lot of things for you, mainly instantiate the prefab and (if you want) call CollectViews() for you</para>
	/// <para>          - after creation, only <see cref="UpdateViewsHolder(TItemViewsHolder)"/> will be called for it when its represented item changes and becomes visible</para>
	/// <para>    5.3. <see cref="UpdateViewsHolder(TItemViewsHolder)"/> will be called when an item is to be displayed or simply needs updating:</para>
	/// <para>        - use <see cref="AbstractViewsHolder.ItemIndex"/> to get the item index, so you can retrieve its associated model from your data set (most common practice is to store the data list in your Params implementation)</para>
	/// <para>        - <see cref="AbstractViewsHolder.root"/> is not null here (given the views holder was properly created in CreateViewsHolder(..)). It's assigned a valid object whose UI elements only need their values changed (common practice is to implement helper methods in the views holder that take the model and update the views themselves)</para>
	/// <para> <see cref="ResetItems(int, bool, bool)"/> is also called when the viewport's size changes (like for orientation changes on mobile or window resizing on sandalone platforms)</para>
	/// <para></para>
	/// <para> *NOTE: No LayoutGroup (vertical/horizontal/grid) on content panel are allowed, since all the layouting is delegated to this adapter</para>
	/// </summary>
	/// <typeparam name="TParams">The params type to use</typeparam>
	/// <typeparam name="TItemViewsHolder"></typeparam>
	/// <seealso cref="ISRIA"/>
	/// <seealso cref="BaseParams"/>
	/// <seealso cref="BaseItemViewsHolder"/>
	public abstract partial class SRIA<TParams, TItemViewsHolder> : UIBehavior<TParams>, ISRIA where TParams : BaseParams where TItemViewsHolder : BaseItemViewsHolder
	{
		/// <summary>
		/// Custom
		/// </summary>

		public override void setData(TParams newData){
			// set
			if (this.data != newData) {
				// remove old
				if (this.data != null) {
					this.data.removeCallBack (this);
				}
				// set new 
				{
					this.data = newData;
					if (this.Initialized) {
						if (this.data != null) {
							this.data.addCallBack (this);
						}
					}
				}
			} else {
				// Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
			}
		}

		protected virtual void Start() { 
			Init();
			// set data
			if (this.data != null) {
				this.data.addCallBack (this);
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		/// <summary>
		/// Custom
		/// </summary>

		#region Configuration
		/// <summary>Parameters displayed in inspector, which can be tweaked based on your needs</summary>
		[SerializeField]
		protected TParams _Params;
		#endregion

		#region IScrollRectProxy events implementaion
		/// <inheritdoc/>
		public event Action<float> ScrollPositionChanged;
		#endregion

		#region ISRIA events & properties implementaion
		/// <summary> Fired when the item count changes or the views are refreshed (more exactly, after each <see cref="ChangeItemsCount(ItemCountChangeMode, int, int, bool, bool)"/> call)</summary>
		public event Action<int, int> ItemsRefreshed;
		/// <summary>Becomes true after <see cref="SRIA{TParams, TItemViewsHolder}.Init"/> and false in <see cref="SRIA{TParams, TItemViewsHolder}.Dispose"/></summary>
		public bool Initialized { get; private set; }
		/// <summary>The adapter's params that can be retrieved from anywhere through an <see cref="ISRIA"/> reference to this adapter</summary>
		public BaseParams BaseParameters { get { return Parameters; } }
		/// <summary>Simply casts the adapter to a MonoBehaviour and returns it. Guaranteed to be non-null, because <see cref="SRIA{TParams, TItemViewsHolder}"/> implements MonoBehaviour</summary>
		public MonoBehaviour AsMonoBehaviour { get { return this; } }
		/// <inheritdoc/>
		public double ContentVirtualSizeToViewportRatio { get { return _InternalState.contentPanelVirtualSize / _InternalState.viewportSize; } }
		/// <inheritdoc/>
		public double ContentVirtualInsetFromViewportStart { get { return _InternalState.ContentPanelVirtualInsetFromViewportStart; } }
		/// <inheritdoc/>
		public double ContentVirtualInsetFromViewportEnd { get { return _InternalState.ContentPanelVirtualInsetFromViewportEnd; } }
		/// <summary> The number of currently visible items (views holders). Can be used to iterate through all of them using <see cref="GetItemViewsHolder(int)"/></summary>
		public int VisibleItemsCount { get { return _VisibleItemsCount; } }
		/// <summary> The number of items that are cached and waiting to be recycled </summary>
		public int RecyclableItemsCount { get { return _RecyclableItems.Count; } }
		#endregion

		/// <summary>The adapter's parameters as seen in inspector</summary>
		public TParams Parameters { get { return _Params; } }

		protected List<TItemViewsHolder> _VisibleItems;
		protected int _VisibleItemsCount;
		protected List<TItemViewsHolder> _RecyclableItems = new List<TItemViewsHolder>();

		InternalState _InternalState;
        ItemsDescriptor _ItemsDesc;
		Coroutine _SmoothScrollCoroutine;
		bool _SkipComputeVisibilityInUpdateOrOnScroll;
		bool _CorrectedPositionInCurrentComputeVisibilityPass;
		float _PrevGalleryEffectAmount;
		double _AVGVisibleItemsCount; // never reset


		#region Unity methods

		public override void Awake()
		{
			base.Awake();
		}

		protected virtual void Update() { MyUpdate(); }

		public override void OnDestroy() {
			base.OnDestroy ();
			Dispose(); 
		}

		#endregion

		#region IScrollRectProxy methods implementaion
		/// <summary>Floating point rounding errors occur the bigger the content size, but generally it's accurrate enough</summary>
		/// <seealso cref="IScrollRectProxy.SetNormalizedPosition"/>
		public void SetNormalizedPosition(float normalizedPosition)
		{
			float abstractNormPos = _Params.scrollRect.horizontal ? 1f - normalizedPosition : normalizedPosition;
			SetVirtualAbstractNormalizedScrollPosition(abstractNormPos, true);
		}

		/// <summary>Floating point rounding errors occur the bigger the content size, but generally it's accurrate enough</summary>
		/// <seealso cref="IScrollRectProxy.GetNormalizedPosition"/>
		public float GetNormalizedPosition()
		{
			float abstractVirtNormPos = (float)_InternalState.GetVirtualAbstractNormalizedScrollPosition();
			return _Params.scrollRect.horizontal ? 1f - abstractVirtNormPos : abstractVirtNormPos;
		}

		/// <summary>Floating point rounding errors occur the bigger the content size, but generally it's accurrate enough. Returns <see cref="float.MaxValue"/> if the (virtual) content size is bigger than <see cref="float.MaxValue"/></summary>
		/// <seealso cref="IScrollRectProxy.GetContentSize"/>
		public float GetContentSize() { return (float)Math.Min(_InternalState.contentPanelVirtualSize, float.MaxValue); }
		#endregion

		/// <summary>Initialize the adapter. Will call Params.InitIfNeeded(), will initialize the internal state and will change the items count to 0</summary>
		public void Init()
		{
			Canvas.ForceUpdateCanvases();

			_Params.InitIfNeeded(this);
			if (_Params.snapper)
				_Params.snapper.Adapter = this;

			if (_Params.scrollRect.horizontalScrollbar != null || _Params.scrollRect.verticalScrollbar != null)
				throw new UnityException("SRIA only works with a "+typeof(ScrollbarFixer8).Name + " component added to the Scrollbar and the ScrollRect shouldn't have any scrollbar set up in the inspector (it hooks up automatically)");

			//Func<int, float> getSizeFn; if (_Params.scrollRect.horizontal) getSizeFn = i => GetItemWidth(i); else getSizeFn = i => GetItemHeight(i);
			_ItemsDesc = new ItemsDescriptor(_Params.DefaultItemSize);//, _Params.DefaultItemSizeUsage == BaseParams.DefaultSizeUsage.PLACEHOLDER_SIZE);
            _InternalState = InternalState.CreateFromSourceParamsOrThrow(_Params, _ItemsDesc);

			_VisibleItems = new List<TItemViewsHolder>();
			_AVGVisibleItemsCount = 0;

			Refresh();
			_InternalState.UpdateLastProcessedCTVirtualInsetFromParentStart();
			SetVirtualAbstractNormalizedScrollPosition(1f, false); // scroll to start
			_Params.scrollRect.onValueChanged.AddListener(OnScrollViewValueChanged);
			
			if (ScrollPositionChanged != null)
				ScrollPositionChanged(GetNormalizedPosition());

			// Debug stuff
#if UNITY_EDITOR
			var debugger = GameObject.FindObjectOfType<SRIADebugger>();
			if (debugger)
				debugger.InitWithAdapter(this);
#endif

			Initialized = true;
		}

		/// <summary>Same as ResetItemsCount(&lt;currentCount&gt;)</summary>
		public virtual void Refresh() { ChangeItemsCount(ItemCountChangeMode.RESET, _ItemsDesc.itemsCount); }

		/// <summary>It clears any previously cached sizes</summary>
		public virtual void ResetItems(int itemsCount, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		{ ChangeItemsCount(ItemCountChangeMode.RESET, itemsCount, -1, contentPanelEndEdgeStationary, keepVelocity); }

		/// <summary>It preserves previously cached sizes</summary>
		public virtual void InsertItems(int index, int itemsCount, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		{ ChangeItemsCount(ItemCountChangeMode.INSERT, itemsCount, index, contentPanelEndEdgeStationary, keepVelocity); }

		/// <summary>It preserves previously cached sizes</summary>
		public virtual void RemoveItems(int index, int itemsCount, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		{ ChangeItemsCount(ItemCountChangeMode.REMOVE, itemsCount, index, contentPanelEndEdgeStationary, keepVelocity); }

		/// <summary>Self-explanatory. See <see cref="ItemCountChangeMode"/> in order to understand how change modes differ from each other.</summary>
		public virtual void ChangeItemsCount(ItemCountChangeMode changeMode, int itemsCount, int indexIfInsertingOrRemoving = -1, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		{ ChangeItemsCountInternal(changeMode, itemsCount, indexIfInsertingOrRemoving, contentPanelEndEdgeStationary, keepVelocity); }

		/// <summary>Returns the last value that was passed to <see cref="ChangeItemsCount(ItemCountChangeMode, int, int, bool, bool)"/></summary>
		public virtual int GetItemsCount() { return _ItemsDesc.itemsCount; }

		/// <summary>
		/// <para>Get the viewsHolder with a specific index in the "visible items" list.</para>
		/// <para>Example: if you pass 0, the first visible ViewsHolder will be returned (if there's any)</para>
		/// <para>Not to be mistaken to the other method 'GetItemViewsHolderIfVisible(int withItemIndex)', which uses the itemIndex, i.e. the index in the list of data models.</para>
		/// <para>Returns null if the supplied parameter is >= <see cref="VisibleItemsCount"/></para>
		/// </summary>
		/// <param name="vhIndex"> the index of the ViewsHolder in the visible items array</param>
		public TItemViewsHolder GetItemViewsHolder(int vhIndex)
		{
			if (vhIndex >= _VisibleItemsCount)
				return null;
			return _VisibleItems[vhIndex];
		}

		/// <summary>Gets the views holder representing the <paramref name="withItemIndex"/>'th item in the list of data models, if it's visible.</summary>
		/// <returns>null, if not visible</returns>
		public TItemViewsHolder GetItemViewsHolderIfVisible(int withItemIndex)
		{
			int curVisibleIndex = 0;
			int curIndexInList;
			TItemViewsHolder curItemViewsHolder;
			for (curVisibleIndex = 0; curVisibleIndex < _VisibleItemsCount; ++curVisibleIndex)
			{
				curItemViewsHolder = _VisibleItems[curVisibleIndex];
				curIndexInList = curItemViewsHolder.ItemIndex;
				// Commented: with introduction of itemIndexInView, this check is no longer useful
				//if (curIndexInList > withItemIndex) // the requested item is before the visible ones, so no viewsHolder for it
				//    break;
				if (curIndexInList == withItemIndex)
					return curItemViewsHolder;
			}

			return null;
		}

		/// <summary>Same as GetItemViewsHolderIfVisible(int withItemIndex), but searches by the root RectTransform reference, rather than the item index</summary>
		/// <param name="withRoot">RectTransform reference to the searched viw holder's root</param>
		public TItemViewsHolder GetItemViewsHolderIfVisible(RectTransform withRoot)
		{
			TItemViewsHolder curItemViewsHolder;
			for (int i = 0; i < _VisibleItemsCount; ++i)
			{
				curItemViewsHolder = _VisibleItems[i];
				if (curItemViewsHolder.root == withRoot)
					return curItemViewsHolder;
			}

			return null;
		}

		/// <summary><paramref name="distance"/> will be set to <see cref="float.MaxValue"/> if no ViewsHolder is found. The point's format is in range [0=startEdge .. 1=endEdge]</summary>
		public virtual AbstractViewsHolder GetViewsHolderOfClosestItemToViewportPoint(float viewportPoint01, float itemPoint01, out float distance)
		{
			Func<RectTransform, float, RectTransform, float, float> getDistanceFn;
			if (_Params.scrollRect.horizontal)
				getDistanceFn = RectTransformExtensions.GetWorldSignedHorDistanceBetweenCustomPivots;
			else
				getDistanceFn = RectTransformExtensions.GetWorldSignedVertDistanceBetweenCustomPivots;

			return GetViewsHolderOfClosestItemToViewportPoint(_VisibleItems, getDistanceFn, viewportPoint01, itemPoint01, out distance);
		}

		/// <summary> 
		/// <para>By default, it aligns the ScrollRect's content so that the item with <paramref name="itemIndex"/> will be at the top.</para>
		/// <para>But the two optional parameters can be used for more fine-tuning. One common use-case is to set them both at 0.5 so the item will be end up exactly in the middle of the viewport</para>
		/// </summary>
		/// <param name="itemIndex">The item with this index will be considered</param>
		/// <param name="normalizedOffsetFromViewportStart">0f=no effect; 0.5f= the item's start edge (top or left) will be at the viewport's center; 1f=the item's start edge will be exactly at the viewport's end (thus, the item will be completely invisible)</param>
		/// <param name="normalizedPositionOfItemPivotToUse">For even more fine-adjustment, you can also specify what point on the item will be used to bring it to <paramref name="normalizedOffsetFromViewportStart"/>. The same principle applies as to the <paramref name="normalizedOffsetFromViewportStart"/> parameter: 0f=start(top/left), 1f=end(bottom/right)</param>
		public virtual void ScrollTo(int itemIndex, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f)
		{
			//if (_Params.loopItems)
			//	throw new UnityException("If looping is enabled, ScrollTo is not yet available, only SmoothScrollTo, preferably with a duration bigger than 0.5 seconds");

			CancelAnimationsIfAny();

			double minContentVirtualInsetFromVPAllowed = -_InternalState.VirtualScrollableArea;
			if (minContentVirtualInsetFromVPAllowed >= 0d)
				return; // can't, because content is not bigger than viewport

			ScrollToHelper_SetContentVirtualInsetFromViewportStart(
				ScrollToHelper_GetContentStartVirtualInsetFromViewportStart_Clamped(
					minContentVirtualInsetFromVPAllowed, 
					itemIndex, 
					normalizedOffsetFromViewportStart, 
					normalizedPositionOfItemPivotToUse
				),
				false
			);

			// This is a semi-hack-lazy hot-fix because when the scroll is immediate, sometimes the visibility isn't computed well
			// Same thing is done in SmoothScrollTo if duration is 0 or close to 0
			ComputeVisibilityForCurrentPosition(false, true, false, -.1);
			ComputeVisibilityForCurrentPosition(true, true, false, +.1);
		}

		/// <summary> Utility to smooth scroll. Identical to <see cref="ScrollTo(int, float, float)"/> in functionality, but the scroll is animated (scroll is done gradually, throughout multiple frames) </summary>
		/// <param name="onProgress">gets the progress (0f..1f) and returns if the scrolling should continue</param>
		/// <returns>if no smooth scroll animation was already playing and <paramref name="overrideCurrentScrollingAnimation"/> is false. if it was, then no new animation will begin, except if <paramref name="overrideCurrentScrollingAnimation"/> is true</returns>
		public virtual bool SmoothScrollTo(int itemIndex, float duration, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f, Func<float, bool> onProgress = null, bool overrideCurrentScrollingAnimation = false)
		{
			//if (_Params.loopItems && duration < .5f)
			//	throw new UnityException("If looping is enabled, SmoothScrollTo best works with a duration bigger than 0.5 seconds");

			if (_SmoothScrollCoroutine != null)
			{
				if (overrideCurrentScrollingAnimation)
				{
					if (_Params.snapper)
						_Params.snapper.CancelSnappingIfInProgress();

					StopCoroutine(_SmoothScrollCoroutine);
					_SmoothScrollCoroutine = null;

					// Bugfix: if the routine is stopped, this is not restored back. Setting it to false is the best thing we can do
					_SkipComputeVisibilityInUpdateOrOnScroll = false;

					//Debug.Log("cancel - other started");
				}
				else
					return false;
			}

			_SmoothScrollCoroutine = StartCoroutine(SmoothScrollProgressCoroutine(itemIndex, duration, normalizedOffsetFromViewportStart, normalizedPositionOfItemPivotToUse, onProgress));

			return true;
		}

		/// <summary> See <see cref="RequestChangeItemSizeAndUpdateLayout(int, float, bool, bool)"/> for additional info or if you want to resize an item which isn't visible</summary>
		/// <param name="withVH">the views holder. A common usage for an "expand on click" behavior is to have a button on a view whose onClick fires a method in the adapter where it retrieves the views holder via <see cref="GetItemViewsHolderIfVisible(RectTransform)"/> </param>
		public float RequestChangeItemSizeAndUpdateLayout(TItemViewsHolder withVH, float requestedSize, bool itemEndEdgeStationary = false, bool computeVisibility = true)
		{ return RequestChangeItemSizeAndUpdateLayout(withVH.ItemIndex, requestedSize, itemEndEdgeStationary, computeVisibility); }

		/// <summary>
		/// <para>An item width/height can be changed with this method. </para>
		/// <para>Should NOT be called during <see cref="ComputeVisibilityForCurrentPosition(bool, bool, bool)"/>, <see cref="UpdateViewsHolder(TItemViewsHolder)"/>, <see cref="CreateViewsHolder(int)"/> or from any critical view-recycling code. Suggestion: call it from MonBehaviour.Update()</para>
		/// <para>Will change the size of the item's RectTransform to <paramref name="requestedSize"/> and will shift the other items accordingly, if needed.</para>
		/// </summary>
		/// <param name="itemIndex">the index of the item to be resized. It doesn't need to be visible(case in which only the cached size will be updated and, obviously, the visible items will shift accordingly) </param>
		/// <param name="requestedSize">the height or width (depending on scrollview's orientation)</param>
		/// <param name="itemEndEdgeStationary">if to grow to the top/left (less common) instead of down/right (more common)</param>
		/// <returns>the resolved size. This can be slightly different than <paramref name="requestedSize"/> if the number of items is huge (>100k))</returns>
		public float RequestChangeItemSizeAndUpdateLayout(int itemIndex, float requestedSize, bool itemEndEdgeStationary = false, bool computeVisibility = true)
		{
			CancelAnimationsIfAny();

			var skipCompute_oldValue = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			_Params.scrollRect.StopMovement(); // we don't want a ComputeVisibility() during changing an item's size, so we cut off any inertia 

			int itemIndexInView = _ItemsDesc.GetItemViewIndexFromRealIndex(itemIndex);
			var viewsHolderIfVisible = GetItemViewsHolderIfVisible(itemIndex);
			float oldSize = _ItemsDesc[itemIndexInView];
			bool vrtContentPanelIsAtOrBeforeEnd = _InternalState.ContentPanelVirtualInsetFromViewportEnd >= 0d;
			if (requestedSize <= oldSize) // collapsing
			{
				if (_InternalState.ContentPanelVirtualInsetFromViewportStart >= 0d)
					itemEndEdgeStationary = false; // doesn't make sense to move the start edge if the content pos is at start (or after)

				else if (vrtContentPanelIsAtOrBeforeEnd)
					itemEndEdgeStationary = true; // doesn't make sense to move the end edge if the content pos is at end (or before)
			}

			float resolvedSize = 
				_InternalState.ChangeItemSizeAndUpdateContentSizeAccordingly(
					viewsHolderIfVisible,
					itemIndexInView, 
					requestedSize, 
					itemEndEdgeStationary
				);

			float reportedScrollDelta;
			if (itemEndEdgeStationary)
				reportedScrollDelta = .1f;
			else
			{
				// If start edge is stationary, either if the item shrinks or expands the reportedDelta should be negative, 
				// indicating that a fake "slight scroll towards end" was done. This triggers a virtualization of the the content's position correctly to compensate for the new ctEnd 
				// and makes any item after it be visible again (in the shirnking case) if it was after viewport
				reportedScrollDelta = -.1f;

				// ..but if the ctEnd is fully visible, the items will act as if they're shrinking with itemEndEdgeStationary=true, because the content's end can't exceed the vpEnd
				if (vrtContentPanelIsAtOrBeforeEnd)
					reportedScrollDelta = .1f;
			}

			if (computeVisibility)
				ComputeVisibilityForCurrentPosition(true, true, false, reportedScrollDelta);
			if (!_CorrectedPositionInCurrentComputeVisibilityPass)
				CorrectPositionsOfVisibleItems(false);// itemEndEdgeStationary);

			_SkipComputeVisibilityInUpdateOrOnScroll = skipCompute_oldValue;

			return resolvedSize;
		}

		/// <summary>
		/// <para>returns the VIRTUAL distance of the item's left (if scroll view is Horizontal) or top (if scroll view is Vertical) edge </para>
		/// <para>from the parent's left (respectively, top) edge</para>
		/// </summary>
		public double GetItemVirtualInsetFromParentStart(int itemIndex)
		{ return _InternalState.GetItemVirtualInsetFromParentStartUsingItemIndexInView(_ItemsDesc.GetItemViewIndexFromRealIndex(itemIndex)); }
		/// <summary>
		/// <para>Used internally. Returns values in [0f, 1f] interval, 1 meaning the scrollrect is at start, and 0 meaning end.</para>
		/// <para>It different approach when content size is smaller than viewport's size, so it can yield consistent results for <see cref="SRIA{TParams, TItemViewsHolder}.ComputeVisibility(double)"/></para>
		/// </summary>
		/// <returns>1 Meaning Start And 0 Meaning End</returns> 
		public double GetVirtualAbstractNormalizedScrollPosition() { return _InternalState.GetVirtualAbstractNormalizedScrollPosition(); }

		/// <summary>Same thing as <see cref="ScrollRect.normalizedPosition"/>, just that the position is 1 for start and 0 for end, regardless if using a horizontal or vertical ScrollRect</summary>
		/// <param name="pos">1=start, 0=end</param>
		public void SetVirtualAbstractNormalizedScrollPosition(double pos, bool computeVisibilityNow)
		{
			CancelAnimationsIfAny();

			var ignoreOnScroll_valueBefore = _SkipComputeVisibilityInUpdateOrOnScroll;
			_SkipComputeVisibilityInUpdateOrOnScroll = true;

			bool executed = _InternalState.SetVirtualAbstractNormalizedScrollPosition(pos);
			if (computeVisibilityNow && executed)
			{
				ComputeVisibilityForCurrentPosition(true, false, false); // ScrollPositionChanged will be called from here
				if (!_CorrectedPositionInCurrentComputeVisibilityPass)
					CorrectPositionsOfVisibleItems(false);
			}
			else if (ScrollPositionChanged != null)
				ScrollPositionChanged(GetNormalizedPosition());
				
			_SkipComputeVisibilityInUpdateOrOnScroll = ignoreOnScroll_valueBefore;
		}

		/// <summary>
		/// This is called during changing the items count. 
		/// The base implementation reinitializes the items descriptor so that all items will have the same size, specified in <see cref="BaseParams.DefaultItemSize"/>
		/// If overriding the method and the item default size should remain the same as <see cref="BaseParams.DefaultItemSize"/>, 
		/// don't forget to call the base implementation! Otherwise, call <see cref="ItemsDescriptor.ReinitializeSizes(ItemCountChangeMode, int, int, float?)"/> with the new default size as parameter.
		/// Use <see cref="ItemsDescriptor.BeginChangingItemsSizes(int)"/> before and <see cref="ItemsDescriptor.EndChangingItemsSizes()"/> after
		/// setting sizes. The indices of items for which you set custom sizes must be one after another (4,5,6,7.. etc). Gaps are not allowed.
		/// Use "itemsDesc[itemIndexInView] = size" syntax for setting custom sizes. In this call, <see cref="AbstractViewsHolder.ItemIndex"/> will be the same as <see cref="BaseItemViewsHolder.itemIndexInView"/>, even if looping is enabled.
		/// </summary>
		/// <param name="itemsDesc">The container for all the info related to items' sizes</param>
		protected virtual void CollectItemsSizes(ItemCountChangeMode changeMode, int count, int indexIfInsertingOrRemoving, ItemsDescriptor itemsDesc)
		{ itemsDesc.ReinitializeSizes(changeMode, count, indexIfInsertingOrRemoving, _Params.DefaultItemSize); }

		/// <summary> 
		/// <para>Called when there are no recyclable views for itemIndex. Provide a new viewsholder instance for itemIndex. This is the place where you must initialize the viewsholder </para>
		/// <para>via <see cref="AbstractViewsHolder.Init(GameObject, int, bool, bool)"/> shortcut or manually set its itemIndex, instantiate the prefab and call its <see cref="AbstractViewsHolder.CollectViews"/></para>
		/// </summary>
		/// <param name="itemIndex">the index of the model that'll be presented by this views holder</param>
		protected abstract TItemViewsHolder CreateViewsHolder(int itemIndex);

		/// <summary>
		/// <para>Here the data in your model should be bound to the views. Use newOrRecycled.ItemIndex (<see cref="AbstractViewsHolder.ItemIndex"/>) to retrieve its associated model</para>
		/// <para>Note that views holders are re-used (this is the main purpose of this adapter), so a views holder's views will contain data from its previously associated model and if, </para>
		/// <para>for example, you're downloading an image to be set as an icon, it makes sense to first clear the previous one (and probably temporarily replace it with a generic "Loading" image)</para>
		/// </summary>
		/// <param name="newOrRecycled"></param>
		protected abstract void UpdateViewsHolder(TItemViewsHolder newOrRecycled);

		/// <summary> Self-explanatory. The default implementation returns true each time</summary>
		/// <returns>If the provided views holder is compatible with the item with index <paramref name="indexOfItemThatWillBecomeVisible"/></returns>
		protected virtual bool IsRecyclable(TItemViewsHolder potentiallyRecyclable, int indexOfItemThatWillBecomeVisible, float heightOfItemThatWillBecomeVisible)
		{ return true; }

		/// <summary> Self-explanatory. The default implementation returns true if <paramref name="isInExcess"/> is true </summary>
		/// <param name="inRecycleBin">an item in the recycle bin (not visible, disabled)</param>
		/// <param name="isInExcess">this will be true if the current number of items exceeded the allowed one (as inferred from the parameters given at initialization)</param>
		protected virtual bool ShouldDestroyRecyclableItem(TItemViewsHolder inRecycleBin, bool isInExcess)
		{ return isInExcess; }

		/// <summary>
		/// Perfect place to clean the views in order to prepare them to be potentially recycled this frame or soon. <paramref name="newItemIndex"/> will be -1 if the item will be disabled/destroyed instead of being recycled.
		/// </summary>
		/// <param name="inRecycleBinOrVisible"></param>
		/// <param name="newItemIndex">-1 means it'll only be disabled and/or destroyed, not recycled ATM</param>
		protected virtual void OnBeforeRecycleOrDisableViewsHolder(TItemViewsHolder inRecycleBinOrVisible, int newItemIndex)
		{ }

		/// <summary>Destroying any remaining game objects in the <see cref="_RecyclableItems"/> list and clearing it</summary>
		protected virtual void ClearCachedRecyclableItems()
		{
            if (_RecyclableItems != null)
			{
				foreach (var recyclable in _RecyclableItems)
				{
					if (recyclable != null && recyclable.root != null)
						try { GameObject.Destroy(recyclable.root.gameObject); } catch (Exception e) { Debug.LogException(e); }
				}
				_RecyclableItems.Clear();
			}
		}

		/// <summary>Destroying any remaining game objects in the <see cref="_VisibleItems"/> list, clearing it and setting <see cref="VisibleItemsCount"/> to 0</summary>
		protected virtual void ClearVisibleItems()
		{
			if (_VisibleItems != null)
			{
				foreach (var item in _VisibleItems)
				{
					if (item != null && item.root != null)
						try { GameObject.Destroy(item.root.gameObject); } catch (Exception e) { Debug.LogException(e); }
				}
				_VisibleItems.Clear();
				_VisibleItemsCount = 0;
			}
		}

		/// <summary>This is called automatically when the size of the scrollview itself (the game object which has the ScrollRect component attached) changes</summary>
		protected virtual void OnScrollViewSizeChanged()
		{
			// Commented: refresh already does that
			//CancelAnimationsIfAny();

			//Debug.Log("TODO test virtualization when scroll view size changes");
			//_InternalState.layoutRebuildPendingDueToScrollViewSizeChangeEvent = true;

			//// Commented: is now called in 
			//Refresh();

			//CollectItemsSizes(ItemCountChangeMode.INSERT, 0, 0, _ItemsDesc);
		}

		/// <summary>
		/// <para>Called mainly when it's detected that the scroll view's size has changed. Marks everything for a layout rebuild and then calls Canvas.ForceUpdateCanvases(). </para>
		/// <para>IMPORTANT: Make sure to override <see cref="AbstractViewsHolder.MarkForRebuild"/> in your views holder implementation if you have child layout groups and call LayoutRebuilder.MarkForRebuild() on them</para> 
		/// </summary>
		protected virtual void RebuildLayoutDueToScrollViewSizeChange()
		{
			//float viewportSizeBefore = _InternalState.viewportSize;

			MarkViewsHoldersForRebuild(_VisibleItems);
			//MarkViewsHoldersForRebuild(_RecyclableItems);
			ClearCachedRecyclableItems();

			Canvas.ForceUpdateCanvases();

			_Params.InitIfNeeded(this);
			if (_Params.snapper)
				_Params.snapper.Adapter = this;

			_InternalState.CacheScrollViewInfo(); // update vp size etc.
            _ItemsDesc.maxVisibleItemsSeenSinceLastScrollViewSizeChange = 0;
            _ItemsDesc.destroyedItemsSinceLastScrollViewSizeChange = 0;
			//_InternalState.layoutRebuildPendingDueToScrollViewSizeChangeEvent = false;

			//float viewportSizeChange = _InternalState.viewportSize - viewportSizeBefore;

			Refresh();

			//if (_InternalState.lastComputeVisibilityHadATwinPass)
			//{
			//	// This fixes some items not appearing after rotation to portrait (in the chat demo)
			//	ComputeVisibilityForCurrentPosition(false, true, true, -.1f);
			//	ComputeVisibilityForCurrentPosition(true, true, true, .1f);
			//}

			//_InternalState.layoutIsBeingRebuildDueToScrollViewSizeChangeEvent = false;

			//_InternalState.OnItemsCountChanged(_ItemsDesc.itemsCount, false);
			//ComputeVisibilityForCurrentPosition(true, true, true);
			//if (!_CorrectedPositionInCurrentComputeVisibilityPass)
			//	CorrectPositionsOfVisibleItems(true);

			//Refresh();
		}

		/// <summary> 
		/// Only called for vertical ScrollRects. Called just before a "Twin" ComputeVisibility will execute. 
		/// This can be used, for example, to disable a ContentSizeFitter on the item which was used to externally calculate the item's size in the current Twin ComputeVisibility pass</summary>
		/// <seealso cref="ScheduleComputeVisibilityTwinPass(bool)"/>
		protected virtual void OnItemHeightChangedPreTwinPass(TItemViewsHolder viewsHolder) { }

		/// <summary> Same as <see cref="OnItemHeightChangedPreTwinPass(TItemViewsHolder)"/>, but for horizontal ScrollRects</summary>
		/// <seealso cref="ScheduleComputeVisibilityTwinPass(bool)"/>
		protected virtual void OnItemWidthChangedPreTwinPass(TItemViewsHolder viewsHolder) { }

		/// <summary>
		/// <para>This can be called in order to schedule a "Twin" ComputeVisibility() call after exactly 1 frame.</para> 
		/// <para>A use case is to enable a ContentSizeFitter on your item, call this, </para> 
		/// <para>and then disable the ContentSizeFitter in <see cref="OnItemHeightChangedPreTwinPass(TItemViewsHolder)"/> (or <see cref="OnItemWidthChangedPreTwinPass(TItemViewsHolder)"/> if horizontal ScrollRect)</para> 
		/// </summary>
		/// <param name="preferContentEndEdgeStationaryIfSizeChanges">this will only be considered if the scroll position didn't change since the last visibility computation</param>
		protected void ScheduleComputeVisibilityTwinPass(bool preferContentEndEdgeStationaryIfSizeChanges = false)
		{
			// Commented: since now the twin pass is done immediately after the usual pass, the update mode is not restricted anymore
			//if (_Params.updateMode != BaseParams.UpdateMode.MONOBEHAVIOUR_UPDATE)
			//	throw new UnityException("Twin pass is only possible if updateMode is " + BaseParams.UpdateMode.MONOBEHAVIOUR_UPDATE);

			_InternalState.computeVisibilityTwinPassScheduled = true;
			_InternalState.preferKeepingContentEndEdgeStationaryInNextComputeVisibilityTwinPass = preferContentEndEdgeStationaryIfSizeChanges;
		}

		/// <summary>See <see cref="GetViewsHolderOfClosestItemToViewportPoint(float, float, out float)"/></summary>
		protected AbstractViewsHolder GetViewsHolderOfClosestItemToViewportPoint(
			ICollection<TItemViewsHolder> viewsHolders,
			Func<RectTransform, float, RectTransform, float, float> getDistanceFn,
			float viewportPoint01,
			float itemPoint01,
			out float distance
		){
			TItemViewsHolder result = null;
			float minDistance = float.MaxValue;
			float curDistance;

			foreach (var vh in viewsHolders)
			{
				curDistance = Mathf.Abs(getDistanceFn(vh.root, itemPoint01, _Params.viewport, viewportPoint01));
				if (curDistance < minDistance)
				{
					result = vh;
					minDistance = curDistance;
				}
			}

			distance = minDistance;
			return result;
		}

		/// <summary>Called automatically in <see cref="OnDestroy"/></summary>
		protected virtual void Dispose()
		{
			Initialized = false;

			if (_Params != null && _Params.scrollRect)
				_Params.scrollRect.onValueChanged.RemoveListener(OnScrollViewValueChanged);

			if (_SmoothScrollCoroutine != null)
			{
				try { StopCoroutine(_SmoothScrollCoroutine); } catch { }

				_SmoothScrollCoroutine = null;
			}

			ClearCachedRecyclableItems();
			_RecyclableItems = null;

			ClearVisibleItems();
			_VisibleItems = null;

			_Params = null;
			_InternalState = null;

			if (ItemsRefreshed != null)
				ItemsRefreshed = null;
		}
	}
}
