using frame8.Logic.Misc.Other.Extensions;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
	/// <summary>
	/// <para>Input params to be passed to <see cref="SRIA{TParams, TItemViewsHolder}.Init()"/></para>
	/// <para>This can be used Monobehaviour's field and exposed via inspector (most common case)</para>
	/// <para>Or can be manually constructed, depending on what's easier in your context</para>
	/// </summary>
	[System.Serializable]
	public class BaseParams : Data
	{
		#region Configuration
		/// <summary>
		/// <para>How much objects besides the visible ones to keep in memory at max, besides the visible ones</para>
		/// <para>By default, no more than the heuristically found "ideal" number of items will be held in memory</para>
		/// <para>Set to a positive integer to limit it - Not recommended, unless you're OK with more GC calls (i.e. occasional FPS hiccups) in favor of using less RAM</para>
		/// </summary>
		[Tooltip("How much objects besides the visible ones to keep in memory at max. \n" +
			"By default, no more than the heuristically found \"ideal\" number of items will be held in memory.\n" +
			"Set to a positive integer to limit it - Not recommended, unless you're OK with more GC calls (i.e. occasional FPS hiccups) in favor of using less RAM")]
		[Header("Optimizing process")]
		public int recycleBinCapacity = -1;

		// Not implemented yet
		///// <summary>
		///// <para>The bigger, the more items will be active past the minimum needed to fill the viewport - with a performance cost, of course</para>
		///// <para>1f = generally, the number of visible items + 1 will always be active</para>
		///// <para>2f = twice the number of visible items + 1 will be always active</para>
		///// <para>2.5f = 2.5 * (the number of visible items) + 1 will be always active</para>
		///// </summary>
		//[Range(1f, 5f)]
		//public float recyclingToleranceFactor = 1f;

		/// <summary>See <see cref="UpdateMode"/> enum for full description. The default is <see cref="UpdateMode.ON_SCROLL_THEN_MONOBEHAVIOUR_UPDATE"/> and if the framerate is acceptable, it should be leaved this way</summary>
		[Tooltip("See BaseParams.UpdateMode enum for full description. The default is ON_SCROLL_THEN_MONOBEHAVIOUR_UPDATE and if the framerate is acceptable, it should be leaved this way")]
		public UpdateMode updateMode = UpdateMode.ON_SCROLL_THEN_MONOBEHAVIOUR_UPDATE;

		/// <summary>
		/// <para>If true: When the last item is reached, the first one appears after it, basically allowing you to scroll infinitely.</para>
		/// <para>Initially intended for things like spinners, but it can be used for anything alike. It may interfere with other functionalities in some very obscure/complex contexts/setups, so be sure to test the hell out of it.</para>
		/// <para>Also please note that sometimes during dragging the content, the actual looping changes the Unity's internal PointerEventData for the current click/touch pointer id, </para>
		/// <para>so if you're also externally tracking the current click/touch, in this case only 'PointerEventData.pointerCurrentRaycast' and 'PointerEventData.position'(current position) are </para>
		/// <para>preserved, the other ones are reset to defaults to assure a smooth loop transition</para>
		/// </summary>
		[Tooltip("If true: When the last item is reached, the first one appears after it, basically allowing you to scroll infinitely.\n" +
			" Initially intended for things like spinners, but it can be used for anything alike.\n" +
			" It may interfere with other functionalities in some very obscure/complex contexts/setups, so be sure to test the hell out of it.\n" +
			" Also please note that sometimes during dragging the content, the actual looping changes the Unity's internal PointerEventData for the current click/touch pointer id, so if you're also externally tracking the current click/touch, in this case only 'PointerEventData.pointerCurrentRaycast' and 'PointerEventData.position'(current position) are preserved, the other ones are reset to defaults to assure a smooth loop transition. Sorry for the long decription. Here's an ASCII potato: (@)")]
		public bool loopItems;

		/// <summary>If null, <see cref="scrollRect"/> is considered to be the viewport</summary>
		[Tooltip("If null, the scrollRect is considered to be the viewport")]
		public RectTransform viewport;

		/// <summary>Padding for the 4 edges of the content panel</summary>
		[Tooltip("This is used instead of the old way of putting a disabled LayoutGroup component on the content")]
		public RectOffset contentPadding = new RectOffset();

		/// <summary>
		/// The effect of this property can only be seen when the content size is smaller than the viewport, case in which there are 3 possibilities: 
		/// place the content at the start, middle or end. <see cref="ContentGravity.NONE"/> doesn't change the content's position (it'll be preserved from the way you aligned it in edit-mode)
		/// </summary>
		public ContentGravity contentGravity = ContentGravity.START;

		/// <summary>Spacing between items (horizontal if the ScrollRect is horizontal. else, vertical)</summary>
		[Tooltip("This is used instead of the old way of putting a disabled LayoutGroup component on the content")]
		public float contentSpacing;

		/// <summary>Applies 1 scale for the item in the middle and gradually lowers the scale of the side items. 0=no effect, 1=the most sideways items will have 0 scale. <see cref="galleryEffectViewportPivot"/> can be used to apply scaling weight in other place than the middle</summary>
		[Range(0f, 1f)]
		public float galleryEffectAmount;

		/// <summary>0=start, 1=end</summary>
		[Range(0f, 1f)]
		public float galleryEffectViewportPivot = .5f;

		/// <summary>The size of all items for which the size is not specified</summary>
		[Tooltip("The size of all items for which the size is not specified in CollectItemSizes()")]
		[SerializeField]
		protected float _DefaultItemSize = 60f;

		///// <summary>
		///// <para>This can be set to <see cref="DefaultSizeUsage.PLACEHOLDER_SIZE"/> when the items will use a ContentSizeFitter (or similar), thus enabling the adapter to optimize some calculations</para>
		///// <para>(for the curious one, it's about computing the AVG size of all items: when the default size means UNKNOWN (<see cref="DefaultSizeUsage.PLACEHOLDER_SIZE"/>), the items whose sizes weren't yet calculated shouldn't be included in the averaging)</para>
		///// </summary>
		//[Tooltip("This can be set to PLACEHOLDER_SIZE when the items will use a ContentSizeFitter (or similar), thus enabling the adapter to optimize some calculations")]
		//[SerializeField]
		//protected DefaultSizeUsage _DefaultItemSizeUsage = DefaultSizeUsage.ACTUAL_SIZE;
		#endregion

		[NonSerialized]
		[System.Obsolete("This was actually renamed to maxNumberOfObjectsToKeepInMemory. If however there's the need to keep more objects active than the viewport allows, " +
			"consider slightly increasing recyclingToleranceFactor", true)]
		public int minNumberOfObjectsToKeepInMemory = -1;

		/// <summary>The ScrollRect that'll be optimized. It's set in <see cref="InitIfNeeded(ISRIA)"/></summary>
		[NonSerialized]
		public ScrollRect scrollRect;

		///// <summary>If null, will be the same as <see cref="ScrollRect.content"/></summary>
		//[Tooltip("If null, will be the same as scrollRect.content")]
		[NonSerialized]
		public RectTransform content;

		internal float DefaultItemSize { get { return _DefaultItemSize; } }
		//internal DefaultSizeUsage DefaultItemSizeUsage { get { return _DefaultItemSizeUsage; } }
		internal RectTransform ScrollViewRT { get { if (!_ScrollViewRT) _ScrollViewRT = scrollRect.transform as RectTransform; return _ScrollViewRT; } }
		internal Snapper8 snapper { get; private set; }

		RectTransform _ScrollViewRT;


		/// <summary>Don't use it. It's here just so the class can be serialized by Unity when used as a MonoBehaviour's field. Use <see cref="BaseParams.BaseParams(ScrollRect)"/> or <see cref="BaseParams.BaseParams(ScrollRect, RectTransform, RectTransform)"/> instead</summary>
		public BaseParams() { }

   //     public BaseParams(BaseParams other)
   //     {
   //         this.recycleBinCapacity = other.recycleBinCapacity;
   //         //this.recyclingToleranceFactor = other.recyclingToleranceFactor;
			//this.updateMode = other.updateMode;
   //         this.scrollRect = other.scrollRect;
   //         this.viewport = other.viewport;
   //         this.content = other.content;
   //         this.contentPadding = other.contentPadding == null ? new RectOffset() : new RectOffset(contentPadding.left, contentPadding.right, contentPadding.top, contentPadding.bottom);
   //         this.contentGravity = other.contentGravity;
   //         this.contentSpacing = other.contentSpacing;
   //     }

        public BaseParams(ScrollRect scrollRect)
            :this(scrollRect, scrollRect.transform as RectTransform, scrollRect.content)
        {}

        public BaseParams(ScrollRect scrollRect, RectTransform viewport, RectTransform content)
        {
            this.scrollRect = scrollRect;
            this.viewport = viewport == null ? scrollRect.transform as RectTransform : viewport;
            this.content = content == null ? scrollRect.content : content;
        }


        /// <summary>
		/// Called internally in <see cref="SRIA{TParams, TItemViewsHolder}.Init()"/> and every time the scrollview's size changes. 
		/// This makes sure the content and viewport have valid values. It can also be overridden to initialize custom data
		/// </summary>
        internal virtual void InitIfNeeded(ISRIA sria)
        {
			// Commented: null-coalescing operator doesn't work with unity's Object
			//content = content ?? scrollRect.content;
			if (!scrollRect)
				scrollRect = sria.AsMonoBehaviour.GetComponent<ScrollRect>();
			if (!scrollRect)
				throw new UnityException("Can't find ScrollRect component!");
            if (!viewport)
                viewport = scrollRect.transform as RectTransform;
            if (!content)
                content = scrollRect.content;
			if (!snapper)
				snapper = scrollRect.GetComponent<Snapper8>();
		}

		[System.Obsolete("This method was moved to the ScrollRectItemsAdapter8 class", true)]
        internal float GetAbstractNormalizedScrollPosition() { return 0f; }

		/// <summary>
		/// See <see cref="ContentGravity"/>
		/// </summary>
		internal void UpdateContentPivotFromGravityType()
		{
			if (contentGravity != ContentGravity.NONE)
			{
				int v1_h0 = scrollRect.horizontal ? 0 : 1;

				var piv = content.pivot;

				// The transfersal position is at the center
				piv[1 - v1_h0] = .5f;

				int contentGravityAsInt = ((int)contentGravity);
				float pivotInScrollingDirection_IfVerticalScrollView;
				if (contentGravityAsInt < 3)
					// 1 = TOP := 1f;
					// 2 = CENTER := .5f;
					pivotInScrollingDirection_IfVerticalScrollView = 1f / contentGravityAsInt;
				else
					// 3 = BOTTOM := 0f;
					pivotInScrollingDirection_IfVerticalScrollView = 0f;

				piv[v1_h0] = pivotInScrollingDirection_IfVerticalScrollView;
				if (v1_h0 == 0) // i.e. if horizontal
					piv[v1_h0] = 1f - piv[v1_h0];

				content.pivot = piv;
			}
		}


		/// <summary> Represents how often or when the optimizer does his core loop: checking for any items that need to be created, destroyed, disabled, displayed, recycled</summary>
		public enum UpdateMode
		{
			/// <summary>
			/// <para>Updates are triggered by a MonoBehaviour.Update() (i.e. each frame the ScrollView is active) and at each OnScroll event</para>
			/// <para>Moderate performance when scrolling, but works in all cases</para>
			/// </summary>
			ON_SCROLL_THEN_MONOBEHAVIOUR_UPDATE,

			/// <summary>
			/// <para>Updates ar triggered by each OnScroll event</para>
			/// <para>Experimental. However, if you use it and see no issues, it's recommended over ON_SCROLL_THEN_MONOBEHAVIOUR_UPDATE.</para>
			/// <para>This is also useful if you don't want the optimizer to use CPU when idle.</para>
			/// <para>A bit better performance when scrolling</para>
			/// </summary>
			ON_SCROLL,

			/// <summary>
			/// <para>Update is triggered by a MonoBehaviour.Update() (i.e. each frame the ScrollView is active)</para>
			/// <para>In this mode, some temporary gaps appear when fast-scrolling. If this is not acceptable, use other modes.</para>
			/// <para>Best performance when scrolling, items appear a bit delayed when fast-scrolling</para>
			/// </summary>
			MONOBEHAVIOUR_UPDATE
		}


		/// <summary> Represents how often or when the optimizer does his core loop: checking for any items that need to be created, destroyed, disabled, displayed, recycled</summary>
		public enum ContentGravity
		{
			/// <summary>you set it up manually</summary>
			NONE,

			/// <summary>top if vertical scrollview, else left</summary>
			START,

			/// <summary>top if vertical scrollview, else left</summary>
			CENTER,

			/// <summary>bottom if vertical scrollview, else right</summary>
			END

		}


		///// <summary> 
		///// 2 possible meanings: the default size will be set to items for which: 
		///// <para>a. <see cref="ACTUAL_SIZE"/>: the size was not explicitly set in <see cref="SRIA{TParams, TItemViewsHolder}.CollectItemsSizes(ItemCountChangeMode, int, int, ItemsDescriptor)"/> or <see cref="SRIA{TParams, TItemViewsHolder}.RequestChangeItemSizeAndUpdateLayout(int, float, bool, bool)"/></para>
		///// <para>b. <see cref="PLACEHOLDER_SIZE"/>: the size is unknown</para>
		///// </summary>
		//public enum DefaultSizeUsage
		//{
		//	/// <summary>All items will have the default size, until otherwise specified</summary>
		//	ACTUAL_SIZE,

		//	/// <summary>This works in conjunction with <see cref="SRIA{TParams, TItemViewsHolder}.ScheduleComputeVisibilityTwinPass(bool)"/>. Mostly used when a ContentSizeFitter is needed on each item</summary>
		//	PLACEHOLDER_SIZE
		//}
	}
}
