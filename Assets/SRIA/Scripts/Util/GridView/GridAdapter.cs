using frame8.Logic.Misc.Other.Extensions;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace frame8.ScrollRectItemsAdapter.Util.GridView
{
    /// <summary>
    /// <para>An optimized adapter for a GridView </para>
    /// <para>Implements <see cref="SRIA{TParams, TItemViewsHolder}"/> to simulate a grid by using</para>
    /// <para>a runtime-generated "row" prefab (or "colum" prefab, if horizontal ScrollRect), having a Horizontal (or Vertical, respectively) LayoutGroup component, inside which its corresponding cells will lie.</para>
    /// <para>This prefab is represented by a <see cref="CellGroupViewsHolder{TCellVH}"/>, which nicely abstractizes the mechanism to using cell prefabs. This views holder is managed internally and is no concern for most users.</para> 
    /// <para>The cell prefab is used the same way as the "item prefab", for those already familiarized with the ListView examples. It is represented</para>
    /// <para>by a <see cref="CellViewsHolder"/>, which are the actual views holders you need to create/update and nothing else. </para>
    /// </summary>
    /// <typeparam name="TParams">Must inherit from GridParams. See also <see cref="SRIA{TParams, TItemViewsHolder}.Parameters"/></typeparam>
    /// <typeparam name="TCellVH">The views holder type to use for the cell. Must inherit from CellViewsHolder</typeparam>
	public abstract class GridAdapter<TParams, TCellVH> : SRIA<TParams, CellGroupViewsHolder<TCellVH>> 
        where TParams : GridParams
        where TCellVH : CellViewsHolder, new()
	{
		/// <summary>The "items count". Same value is returned in <see cref="GetItemsCount"/></summary>
		public int CellsCount { get { return _CellsCount; } }

		protected int _CellsCount;

//#pragma warning disable 809 // Obsolete member 'memberA' overrides non-obsolete member 'memberB'

		//public sealed override void ResetItemsCount(int cellsCount /*param name changed from itemsCount*/, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		//{ base.ResetItemsCount(cellsCount, contentPanelEndEdgeStationary, keepVelocity); }

		/// <summary>Not currently implemented fir GridAdapters</summary>
		public sealed override void InsertItems(int index, int itemsCount, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		{ throw new InvalidOperationException("Cannot use InsertItems() with a GridAdapter yet. Use ResetItemsCount() instead."); }

		/// <summary>Not currently implemented fir GridAdapters</summary>
		public sealed override void RemoveItems(int index, int itemsCount, bool contentPanelEndEdgeStationary = false, bool keepVelocity = false)
		{ throw new InvalidOperationException("Cannot use RemoveItems() with a GridAdapter yet. Use ResetItemsCount() instead."); }

		/// <summary> Overridden in order to convert the cellsCount to groupsCount before passing it to the base's implementation</summary>
		/// <seealso cref="SRIA{TParams, TItemViewsHolder}.ChangeItemsCount(ItemCountChangeMode, int, int, bool, bool)"/>
		public override void ChangeItemsCount(
			ItemCountChangeMode changeMode, 
			int cellsCount /*param name changed from itemsCount*/, 
			int indexIfAppendingOrRemoving = -1, 
			bool contentPanelEndEdgeStationary = false, 
			bool keepVelocity = false
		)
		{
			if (changeMode != ItemCountChangeMode.RESET)
				throw new InvalidOperationException("Only ItemCountChangeMode.RESET is supported with a GridAdapter for now");

			_CellsCount = cellsCount;

			// The number of groups is passed to the base's implementation
			int groupsCount = _Params.GetNumberOfRequiredGroups(_CellsCount);

			base.ChangeItemsCount(changeMode, groupsCount, indexIfAppendingOrRemoving, contentPanelEndEdgeStationary, keepVelocity);
		}

		/// <summary>
		/// Tha base implementation finds the group. Here, we're narrowing the search in the group iself in order to return the CellViewsHolder
		/// </summary>
		public sealed override AbstractViewsHolder GetViewsHolderOfClosestItemToViewportPoint(float viewportPoint01, float itemPoint01, out float distance)
		{
			var groupVH = base.GetViewsHolderOfClosestItemToViewportPoint(viewportPoint01, itemPoint01, out distance) as CellGroupViewsHolder<TCellVH>;

			if (groupVH == null 
				|| groupVH.NumActiveCells == 0) // 0 active cells is highly unlikely, but it's worth taking it into account
				return null;

			// Returning the cell closest to the middle
			return groupVH.ContainingCellViewsHolders[groupVH.NumActiveCells / 2];
		}

		/// <summary> Scrolls to the specified cell. Use <see cref="ScrollToGroup(int, float, float)"/> if that was intended instead</summary>
		public sealed override void ScrollTo(int cellIndex, float normalizedOffsetFromViewportStart = 0, float normalizedPositionOfItemPivotToUse = 0)
		{ ScrollToGroup(_Params.GetGroupIndex(cellIndex), normalizedOffsetFromViewportStart, normalizedPositionOfItemPivotToUse); }

		/// <summary> Scrolls to the specified cell. Use <see cref="SmoothScrollToGroup(int, float, float, float, Func{float, bool})"/> if that was intended instead</summary>
		public sealed override bool SmoothScrollTo(int cellIndex, float duration, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f, Func<float, bool> onProgress = null, bool overrideAnyCurrentScrollingAnimation = false)
		{ return SmoothScrollToGroup(_Params.GetGroupIndex(cellIndex), duration, normalizedOffsetFromViewportStart, normalizedPositionOfItemPivotToUse, onProgress, overrideAnyCurrentScrollingAnimation); }
//#pragma warning restore 809

		/// <summary>Overriding base's implementation so that we pass the cells count to our own implementation which converts them to group count before further passing it to the base impl.</summary>
		public sealed override void Refresh() { Refresh(false); }

		/// <summary>See <see cref="Refresh"/></summary>
		public virtual void Refresh(bool contentPanelEndEdgeStationary, bool keepVelocity = false) { ChangeItemsCount(ItemCountChangeMode.RESET, _CellsCount, -1, contentPanelEndEdgeStationary, keepVelocity); }

		/// <summary>Overriding base's implementation to return the cells count, instead of the groups count</summary>
		/// <seealso cref="SRIA{TParams, TItemViewsHolder}.GetItemsCount"/>
		public sealed override int GetItemsCount() { return _CellsCount; }

		#region Cell views holders helpers
		public virtual int GetCellGroupsCount() { return base.GetItemsCount(); }

		/// <summary>The number of visible cells</summary>
		public virtual int GetNumVisibleCells()
		{
			if (_VisibleItemsCount == 0)
				return 0;
			return (_VisibleItemsCount - 1) * _Params.numCellsPerGroup + _VisibleItems[_VisibleItemsCount - 1].NumActiveCells;
		}

		/// <summary>
		/// <para>Retrieve the views holder of a cell with speciffic index in view. For example, one can iterate from 0 to <see cref="GetNumVisibleCells"/> </para>
		/// <para>in order to do something with each visible cell. Not to be mistaken for <see cref="GetCellViewsHolderIfVisible(int)"/>,</para>
		/// <para>which retrieves a cell by the index of its corresponding model in your data list (<see cref="AbstractViewsHolder.ItemIndex"/>)</para>
		/// </summary>
		public virtual TCellVH GetCellViewsHolder(int cellViewsHolderIndex)
		{
			if (_VisibleItemsCount == 0)
				return null;

			if (cellViewsHolderIndex > GetNumVisibleCells() - 1)
				return null;

			return _VisibleItems[_Params.GetGroupIndex(cellViewsHolderIndex)]
					.ContainingCellViewsHolders[cellViewsHolderIndex % _Params.numCellsPerGroup];
		}

		/// <summary>
		/// <para>Retrieve the views holder of a cell whose associated model's index in your data list is <paramref name="withCellItemIndex"/>.</para>
		/// <para>Not to be mistaken for <see cref="GetCellViewsHolder(int)"/> which retrieves a cell by its index <see cref="SRIA{TParams, TItemViewsHolder}._VisibleItems"/></para>
		/// </summary>
		/// <returns>null, if the item is outside the viewport (and thus no view is associated with it)</returns>
		public virtual TCellVH GetCellViewsHolderIfVisible(int withCellItemIndex)
		{
			var groupVH = GetItemViewsHolderIfVisible(_Params.GetGroupIndex(withCellItemIndex));
			if (groupVH == null)
				return null;

			int indexOfFirstCellInGroup = groupVH.ItemIndex * _Params.numCellsPerGroup;

			if (withCellItemIndex < indexOfFirstCellInGroup + groupVH.NumActiveCells)
				return groupVH.ContainingCellViewsHolders[withCellItemIndex - indexOfFirstCellInGroup];

			return null;
		}

		/// <summary>Scroll to the specified GROUP. Use <see cref="ScrollTo(int, float, float)"/> if scrolling to a CELL was intended instead</summary>
		/// <seealso cref="SRIA{TParams, TItemViewsHolder}.ScrollTo(int, float, float)"/>
		public virtual void ScrollToGroup(int groupIndex, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f)
		{ base.ScrollTo(groupIndex, normalizedOffsetFromViewportStart, normalizedPositionOfItemPivotToUse); }

		/// <summary>See <see cref="ScrollToGroup(int, float, float)"/></summary>
		public virtual bool SmoothScrollToGroup(int groupIndex, float duration, float normalizedOffsetFromViewportStart = 0f, float normalizedPositionOfItemPivotToUse = 0f, Func<float, bool> onProgress = null, bool overrideAnyCurrentScrollingAnimation = false)
		{ return base.SmoothScrollTo(groupIndex, duration, normalizedOffsetFromViewportStart, normalizedPositionOfItemPivotToUse, onProgress, overrideAnyCurrentScrollingAnimation); }
		#endregion
		
        /// <summary> Creates the Group viewsholder which instantiates the group prefab using the provided params in <see cref="ScrollRectItemsAdapter8{TParams, TItemViewsHolder}.Init(TParams)"/></summary>
        /// <seealso cref="ScrollRectItemsAdapter8{TParams, TItemViewsHolder}.CreateViewsHolder(int)"/>
        /// <param name="itemIndex">the index of the GROUP (attention, not the CELL) that needs creation</param>
        /// <returns>The created group views holder </returns>
        protected override CellGroupViewsHolder<TCellVH> CreateViewsHolder(int itemIndex)
        {
            var instance = new CellGroupViewsHolder<TCellVH>();
            instance.Init(_Params.GetGroupPrefab(itemIndex).gameObject, itemIndex, _Params.cellPrefab, _Params.numCellsPerGroup);

            return instance;
        }

        /// <summary>Here the grid adapter checks if new groups need to be created or if old ones need to be disabled or destroyed, after which it calls <see cref="UpdateCellViewsHolder(TCellVH)"/> for each remaining cells</summary>
        /// <seealso cref="SRIA{TParams, TItemViewsHolder}.UpdateViewsHolder(TItemViewsHolder)"/>
        /// <param name="newOrRecycled">The viewsholder of the group that needs updated</param>
        protected sealed override void UpdateViewsHolder(CellGroupViewsHolder<TCellVH> newOrRecycled)
        {
            // At this point there is for sure enough groups, but there may not be enough enabled cells, or there may be too much enabled cells

            int activeCellsForThisGroup;
            // If it's the last one
            if (newOrRecycled.ItemIndex + 1 == GetCellGroupsCount())
            {
                int totalCellsBeforeThisGroup = 0;
                if (newOrRecycled.ItemIndex > 0)
                {
                    totalCellsBeforeThisGroup = newOrRecycled.ItemIndex * _Params.numCellsPerGroup;
                }
                activeCellsForThisGroup = _CellsCount - totalCellsBeforeThisGroup;
            }
            else
            {
                activeCellsForThisGroup = _Params.numCellsPerGroup;
            }
            newOrRecycled.NumActiveCells = activeCellsForThisGroup;

            for (int i = 0; i < activeCellsForThisGroup; ++i)
                UpdateCellViewsHolder(newOrRecycled.ContainingCellViewsHolders[i]);
        }

		/// <summary>The only important callback for inheritors. It provides cell's views holder which has just become visible and whose views should be updated from its corresponding data model. viewsHolder.ItemIndex(<see cref="AbstractViewsHolder.ItemIndex"/>) can be used to know what data model is associated with. </summary>
		/// <param name="viewsHolder">The cell's views holder</param>
		protected abstract void UpdateCellViewsHolder(TCellVH viewsHolder);

		/// <summary>
		/// Overridden in order to call <see cref="OnBeforeRecycleOrDisableCellViewsHolder(TCellVH, int)"/> for each active cell in the group
		/// </summary>
		/// <seealso cref="SRIA{TParams, TItemViewsHolder}.OnBeforeRecycleOrDisableViewsHolder(TItemViewsHolder, int)"/>
		protected sealed override void OnBeforeRecycleOrDisableViewsHolder(CellGroupViewsHolder<TCellVH> inRecycleBinOrVisible, int newItemIndex)
		{
			base.OnBeforeRecycleOrDisableViewsHolder(inRecycleBinOrVisible, newItemIndex);

			// 2 fors are more efficient
			if (newItemIndex == -1)
				for (int i = 0; i < inRecycleBinOrVisible.NumActiveCells; ++i)
					OnBeforeRecycleOrDisableCellViewsHolder(inRecycleBinOrVisible.ContainingCellViewsHolders[i], -1);
			else
				for (int i = 0; i < inRecycleBinOrVisible.NumActiveCells; ++i)
					OnBeforeRecycleOrDisableCellViewsHolder(inRecycleBinOrVisible.ContainingCellViewsHolders[i], newItemIndex * _Params.numCellsPerGroup + i);
		}

		/// <summary>The only important callback for inheritors. It provides cell's views holder which has just become visible and whose views should be updated from its corresponding data model. viewsHolder.ItemIndex(<see cref="AbstractViewsHolder.ItemIndex"/>) can be used to know what data model is associated with. </summary>
		/// <param name="viewsHolder">The cell's views holder</param>
		protected virtual void OnBeforeRecycleOrDisableCellViewsHolder(TCellVH viewsHolder, int newItemIndex) { }
	}
}
