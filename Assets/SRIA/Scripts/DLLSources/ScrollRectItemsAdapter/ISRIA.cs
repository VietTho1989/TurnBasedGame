using frame8.Logic.Misc.Other.Extensions;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
    /// <summary>
    /// Contains commonly used members so that an <see cref="SRIA{TParams, TItemViewsHolder}"/> instance 
    /// can be referenced abstractly (since instances of derived generic classes cannot be referenced by a variable of base type).
    /// </summary>
    /// <seealso cref="IScrollRectProxy"/>
    public interface ISRIA : IScrollRectProxy
    {

        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.ItemsRefreshed"/></summary>
        event Action<int, int> ItemsRefreshed;

        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.Initialized"/></summary>
        bool Initialized { get; }
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.BaseParameters"/></summary>
        BaseParams BaseParameters { get; }
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.AsMonoBehaviour"/></summary>
        MonoBehaviour AsMonoBehaviour { get; }
        double ContentVirtualSizeToViewportRatio { get; }
        double ContentVirtualInsetFromViewportStart { get; }
        double ContentVirtualInsetFromViewportEnd { get; }
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.VisibleItemsCount"/></summary>
        int VisibleItemsCount { get; }
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.RecyclableItemsCount"/></summary>
        int RecyclableItemsCount { get; }

        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.ChangeItemsCount(ItemCountChangeMode, int, int, bool, bool)"/></summary>
        void ChangeItemsCount(ItemCountChangeMode changeMode, int itemsCount, int indexIfAppendingOrRemoving = -1, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false);
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.SetVirtualAbstractNormalizedScrollPosition(double, bool)"/></summary>
        void SetVirtualAbstractNormalizedScrollPosition(double pos, bool computeVisibilityNow);
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.GetItemsCount"/></summary>
        int GetItemsCount();
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.ScrollTo(int, float, float)"/></summary>
        void ScrollTo(int itemIndex, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f);
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.SmoothScrollTo(int, float, float, float, Func{float, bool}, bool)"/></summary>
        bool SmoothScrollTo(int itemIndex, float duration, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f, Func<float, bool> onProgress = null, bool overrideCurrentScrollingAnimation = false);
        /// <summary>See <see cref="SRIA{TParams, TItemViewsHolder}.GetViewsHolderOfClosestItemToViewportPoint(float, float, out float)"/></summary>
        AbstractViewsHolder GetViewsHolderOfClosestItemToViewportPoint(float viewportPoint01, float itemPoint01, out float distance);

        // TODO Tu them vao
        float RequestChangeItemSizeAndUpdateLayout(int itemIndex, float requestedSize, bool itemEndEdgeStationary = false, bool computeVisibility = true);

    }
}