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
    /// <para>A views holder representing a group of cells (row or column). It instantiates the maximum number of cells it can contain,</para>
    /// <para>but only those of them that should be displayed will have their <see cref="CellViewsHolder.views"/> enabled</para>
    /// </summary>
    /// <typeparam name="TCellVH">The views holder type used for the cells in this group</typeparam>
    public class CellGroupViewsHolder<TCellVH> : BaseItemViewsHolder where TCellVH : CellViewsHolder, new()
    {
        /// <summary>Uses base's implementation, but also updates the indices of all containing cells each time the setter is called</summary>
        public override int ItemIndex
        {
            get { return base.ItemIndex; }
            set
            {
                base.ItemIndex = value;
                if (_Capacity > 0)
                    OnGroupIndexChanged();
            }
        }

        /// <summary>The number of visible cells, i.e. that are used to display real data. The other ones are disabled and are either empty or hold obsolete data</summary>
        public int NumActiveCells
        {
            get { return _NumActiveCells; }
            set
            {
                if (_NumActiveCells != value)
                {
                    _NumActiveCells = value;
                    for (int i = 0; i < _Capacity; ++i)
                        ContainingCellViewsHolders[i].views.gameObject.SetActive(i < _NumActiveCells);
                }
            }
        }

        /// <summary>The views holders of all containing cells, active or not</summary>
        public TCellVH[] ContainingCellViewsHolders { get; private set; }

        protected HorizontalOrVerticalLayoutGroup _LayoutGroup;
        protected int _Capacity = -1;
        protected int _NumActiveCells = 0;


        /// <summary>
        /// <para>Called by <see cref="Init(GameObject, int, RectTransform, int)"/>, after the GameObjects for the group and all containing cells are instantiated</para>
        /// <para>Creates the cells' views holders and initializes them, also setting their itemIndex based on this group's <see cref="ItemIndex"/></para>
        /// </summary>
        public override void CollectViews()
        {
            base.CollectViews();

            //if (capacity == -1) // not initialized
            //    throw new InvalidOperationException("ItemAsLayoutGroupViewsHolder.CollectViews(): call InitGroup(...) before!");

            _LayoutGroup = root.GetComponent<HorizontalOrVerticalLayoutGroup>();

            ContainingCellViewsHolders = new TCellVH[_Capacity];
            for (int i = 0; i < _Capacity; ++i)
            {
                ContainingCellViewsHolders[i] = new TCellVH();
                ContainingCellViewsHolders[i].InitWithExistingRootPrefab(root.GetChild(i) as RectTransform);
                ContainingCellViewsHolders[i].views.gameObject.SetActive(false); // not visible, initially
            }

            if (ItemIndex != -1 && _Capacity > 0)
                UpdateIndicesOfContainingCells();
        }

        /// <summary>The only way to instantiate the group views holder. It's used internally, since the group managing is not done by the API user</summary>
        /// <param name="itemIndex">the group's index</param>
        internal void Init(GameObject groupPrefab, int itemIndex, RectTransform cellPrefab, int numCellsPerGroup)
        {
            base.Init(
                groupPrefab, 
                itemIndex, 
                true,
                false // not calling CollectViews, because we'll call it below
            );

            _Capacity = numCellsPerGroup;

            // Instantiate all the cells in the group
            for (int i = 0; i < _Capacity; ++i)
            {
                var cellInstance = (GameObject.Instantiate(cellPrefab.gameObject) as GameObject).transform as RectTransform;
                cellInstance.gameObject.SetActive(true); // just in case the prefab was disabled
                cellInstance.SetParent(root);
            }
            CollectViews();
        }

		/// <summary>This happens when the views holder is recycled or first created</summary>
        protected virtual void OnGroupIndexChanged()
        {
            if (_Capacity > 0)
                UpdateIndicesOfContainingCells();
        }

        protected virtual void UpdateIndicesOfContainingCells()
        {
            for (int i = 0; i < _Capacity; ++i)
                ContainingCellViewsHolders[i].ItemIndex = ItemIndex * _Capacity + i; 
        }
    }

}
