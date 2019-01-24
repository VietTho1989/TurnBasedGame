using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;
using frame8.Logic.Misc.Other.Extensions;
using frame8.Logic.Misc.Visual.UI.MonoBehaviours;
using System.Linq;

namespace frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter
{
    /// Comments format: value if vertical scrolling/value if horizontal scrolling
    public class ItemsDescriptor
	{
        // Constant params (until the scrollview size changes)
        internal float itemsConstantTransversalSize; // widths/heights

		internal int itemsCount;
        internal double cumulatedSizesOfAllItemsPlusSpacing;
        internal int realIndexOfFirstItemInView;
        // Heuristic used to prevent destroying too much objects.
        // It's reset back to 0 when the NotifyScrollViewSizeChanged is called
        internal int maxVisibleItemsSeenSinceLastScrollViewSizeChange = 0;
        // Heuristic similar to the above one. The bigger this is, the more items will be held in the recycle bin, leading to fewer GC calls in the long run.
        // It's reset back to 0 when the NotifyScrollViewSizeChanged is called
        internal int destroyedItemsSinceLastScrollViewSizeChange = 0;

        //internal float DefaultSize { get; private set; }
        internal double CumulatedSizeOfAllItems { get { return itemsCount == 0 ? 0d : GetItemSizeCumulative(itemsCount - 1, false); } }

		internal float this[int itemIndexInView]
		{
			get
            {
                float val;
                if (_Sizes.TryGetValue(itemIndexInView, out val))
                    return val;

                return _DefaultSize;
            }
			set
			{
				if (_ChangingItemsSizesInProgress)
				{
					if (itemIndexInView != _IndexInViewOfLastItemThatChangedSizeDuringSizesChange + 1)
						throw new UnityException("Sizes can only be changed for items one by one, one after another(e.g. 3,4,5,6,7..), starting with the one passed to BeginChangingItemsSizes(int)!");


					//if (this[itemIndexInView] == value)
					//	return;

					//if (_IndexInViewOfLastItemThatChangedSize == -1 // the first size being set => add a new entry
					//		|| itemIndexInView > _IndexInViewOfLastItemThatChangedSize + 1) // the current index skips some intermediary indices => analogous
					//	_RangesOfIndicesInViewOfItemsWhichChangedSize.Add(itemIndexInView);
					//else // the current idx is immediately after
					//{
					//	if (itemIndexInView < _IndexInViewOfLastItemThatChangedSize + 1)
					//		throw new UnityException("Can only set sizes from smaller indices to bigger indices (3, 5, 8, 10.. not 5, 3, 6, 7, 1, 28)");

					//	_RangesOfIndicesInViewOfItemsWhichChangedSize[_RangesOfIndicesInViewOfItemsWhichChangedSize.Count - 1] = itemIndexInView;
					//}
					//_IndexInViewOfLastItemThatChangedSize = itemIndexInView;
					BinaryAddKeyToSortedListIfDoesntExist(itemIndexInView);
					_CumulatedSizesUntilNowDuringSizesChange += value;
					_Sizes[itemIndexInView] = value;
					_SizesCumulative[itemIndexInView] = _CumulatedSizesUntilNowDuringSizesChange;
					_IndexInViewOfLastItemThatChangedSizeDuringSizesChange = itemIndexInView;
				}
				else
					throw new UnityException("Call BeginChangingItemsSizes() before");
			}
		}

		// Important: if an item's index it's not here, it's assumed that its size is the default one, NOT that it's unknown
		/// <summary>indices in view of items of non-default sizes</summary>
		List<int> _Keys = new List<int>();
		Dictionary<int, float> _Sizes = new Dictionary<int, float>(); // heights/widths
		Dictionary<int, double> _SizesCumulative = new Dictionary<int, double>(); // heights/widths
		float _DefaultSize;
		bool _ChangingItemsSizesInProgress;
		int _IndexInViewOfFirstItemThatChangesSizeDuringSizesChange;
		int _IndexInViewOfLastItemThatChangedSizeDuringSizesChange = -1;
		double _CumulatedSizesUntilNowDuringSizesChange;
		//double _AverageSize;
		//bool _IgnoreItemsWithDefaultSizesWhenCalculatingAVGSize; 


		public ItemsDescriptor(float defaultSize)//, bool ignoreItemsWithDefaultSizesWhenCalculatingAVGSize)
		{
			//_IgnoreItemsWithDefaultSizesWhenCalculatingAVGSize = ignoreItemsWithDefaultSizesWhenCalculatingAVGSize;
			ReinitializeSizes(ItemCountChangeMode.RESET, 0, -1, defaultSize);
		}


		internal void ReinitializeSizes(ItemCountChangeMode changeMode, int count, int indexIfInsertingOrRemoving = -1, float? newDefaultSize = null)
		{
			if (newDefaultSize != null)
			{
				if (newDefaultSize != _DefaultSize)
				{
					if (changeMode != ItemCountChangeMode.RESET)
						throw new UnityException("Cannot preserve old sizes if the newDefaultSize is different!");

					_DefaultSize = newDefaultSize.Value;
					//_AverageSize = _DefaultSize = newDefaultSize.Value;
				}
			}

			if (changeMode == ItemCountChangeMode.RESET)
			{
				_Sizes.Clear();
				_SizesCumulative.Clear();
				_Keys.Clear();
				itemsCount = count;

				return;
			}

			if (indexIfInsertingOrRemoving < 0 || indexIfInsertingOrRemoving > itemsCount)
				throw new ArgumentOutOfRangeException("indexIfInsertingOrRemoving", indexIfInsertingOrRemoving, "Should be positive and less than itemsCount=" + itemsCount);

			int newCount;
			if (changeMode == ItemCountChangeMode.INSERT)
			{
				ShiftSizesKeys(indexIfInsertingOrRemoving, count);

				newCount = itemsCount + count;
				//if (newCount == 0)
				//	_AverageSize = 0d;
				//else if (!_IgnoreItemsWithDefaultSizesWhenCalculatingAVGSize)
				//{

				//	_AverageSize = ((double)itemsCount / newCount) * _AverageSize + ((double)count / newCount) * _DefaultSize;
				//}
			}
			else
			{
				if (count < 0)
					throw new ArgumentOutOfRangeException("count", count, "Cannot be negative!");

				if (indexIfInsertingOrRemoving + count > itemsCount)
					throw new ArgumentOutOfRangeException("RemoveItems: index + count", indexIfInsertingOrRemoving + count, "Should be positive and less than- or or equal to itemsCount=" + itemsCount);

				count = -count;
				ShiftSizesKeys(indexIfInsertingOrRemoving, count);
				newCount = itemsCount + count;
				//if (newCount == 0)
				//	_AverageSize = 0d;
				//else if (!_IgnoreItemsWithDefaultSizesWhenCalculatingAVGSize)
				//	_AverageSize = ((double)itemsCount / newCount) * _AverageSize + ((double)count / newCount) * _DefaultSize;
			}
			itemsCount = newCount;
		}

		void BinaryAddKeyToSortedListIfDoesntExist(int key)
		{
			int indexOfKey = _Keys.BinarySearch(key);
			if (indexOfKey < 0) // will be negative if it doesn't already exist
				_Keys.Insert(~indexOfKey, key);
		}

		void BinaryRemoveKeyFromSortedList(int key)
		{
			_Keys.RemoveAt(_Keys.BinarySearch(key));
		}

		//void Debug_ListSizesAndSizesCumulative()
		//{
		//	foreach (var k in _Keys)
		//		Debug.Log(k + ": " + _Sizes[k] + ", c=" + _SizesCumulative[k]);
		//}

		void ShiftSizesKeys(int startingKey, int amount)
		{
			if (_Sizes.Count != _SizesCumulative.Count || _Sizes.Count != _Keys.Count)
				throw new InvalidOperationException("The sizes state was corrupted");

			//Debug.Log("Bef, startingKey= " + startingKey + ", amount="+ amount + ", oldCount=" + itemsCount);
			//Debug_ListSizesAndSizesCumulative();
			
			var indexOfStartingKeyOrFirstKeyAfter = _Keys.BinarySearch(startingKey);
			if (indexOfStartingKeyOrFirstKeyAfter < 0) // doesn't exist => see if there's a key after
				indexOfStartingKeyOrFirstKeyAfter = ~indexOfStartingKeyOrFirstKeyAfter;

			//var itemsKV = _Sizes.ToList();
			//int i = -1;
			//KeyValuePair<int, float> kv;
			int i = indexOfStartingKeyOrFirstKeyAfter;
			//while (++i < itemsKV.Count && itemsKV[i].Key < startingKey) ; // skip until at- or after the startingKey

			double contentSizeChange = 0d; // the shifting amount

			//Debug.Log("Adjust after:");

			// Negative amount means the items are being removed => remove existing items from startingKey to <startingKey+amount-1>
			int key;
			float size;
			double sizeCumm;
			if (amount < 0)
			{
				int countBefore = _Keys.Count;
				int amountAbs = -amount;
				int lastItemIndexExclusive = startingKey + amountAbs;
				//--i;
				//while (++i < _Keys.Count && (key=_Keys[i]) < lastItemIndexExclusive)
				while (i < _Keys.Count && (key=_Keys[i]) < lastItemIndexExclusive)
				{
					contentSizeChange -= _Sizes[key];

					_Sizes.Remove(key);
					_SizesCumulative.Remove(key);
					_Keys.RemoveAt(i);
				}
				int itemsRemoved = countBefore - _Keys.Count;
				contentSizeChange -= (amountAbs - itemsRemoved) * _DefaultSize;

				// Shift the indices following after to the left, starting with the left-most index (to prevent overwriting existing keys). 
				// i = index of the first stored key after the last removed one
				for (; i < _Keys.Count; ++i)
				{
					key = _Keys[i];
					size = _Sizes[key];
					sizeCumm = _SizesCumulative[key];

					_Sizes.Remove(key);
					_SizesCumulative.Remove(key);

					var newKey = key + amount;
					if (newKey < 0) // the item will be removed from the head of the list => don't add it 
					{
						Debug.Log("here");
						_Keys.RemoveAt(i);
						continue;
					}
					_Keys[i] = newKey; // change the key to the new value
					_Sizes[newKey] = size;
					_SizesCumulative[newKey] = sizeCumm + contentSizeChange;
				}
			}
			else
			{
				contentSizeChange = amount * _DefaultSize; // new items are supposed to have default size

				// Shift the indices following after to the right, but start from the right-most (to prevent overwriting existing keys). 
				// i = index of startingKey or (if starting key is not stored) the first stored key after it
				int indexOfLeftMostKeyToBeShifted = i;
				for (i = _Keys.Count - 1; i >= indexOfLeftMostKeyToBeShifted; --i)
				{
					key = _Keys[i];
					size = _Sizes[key];
					sizeCumm = _SizesCumulative[key];

					_Sizes.Remove(key);
					_SizesCumulative.Remove(key);

					var newKey = key + amount;
					_Keys[i] = newKey; // change the key to the new value
					_Sizes[newKey] = size;
					_SizesCumulative[newKey] = sizeCumm + contentSizeChange;
				}
			}

			//Debug.Log("Aft");
			//Debug_ListSizesAndSizesCumulative();
		}

		/// <summary>
		/// UPDATE: Only consecutive indices are allowed now! 
		/// // Deprecated comment: Only changing sizes of items starting from smaller indic towards bigger indices, e.g. from 'left' to 'right' in the array
		/// </summary>
        internal void BeginChangingItemsSizes(int indexInViewOfFirstItemThatWillChangeSize)
		{
			if (_ChangingItemsSizesInProgress)
				throw new UnityException("Call EndChangingItemsSizes() when done doing it");

			_ChangingItemsSizesInProgress = true;
            _IndexInViewOfFirstItemThatChangesSizeDuringSizesChange = indexInViewOfFirstItemThatWillChangeSize;
			_IndexInViewOfLastItemThatChangedSizeDuringSizesChange = _IndexInViewOfFirstItemThatChangesSizeDuringSizesChange - 1;
			_CumulatedSizesUntilNowDuringSizesChange = _IndexInViewOfFirstItemThatChangesSizeDuringSizesChange == 0 ? 0d : GetItemSizeCumulative(_IndexInViewOfFirstItemThatChangesSizeDuringSizesChange - 1);
			//_IndexInViewOfLastItemThatChangedSize = -1;
			//_RangesOfIndicesInViewOfItemsWhichChangedSize.Clear();
		}

        internal void EndChangingItemsSizes()
		{
			_ChangingItemsSizesInProgress = false;

			if (_IndexInViewOfLastItemThatChangedSizeDuringSizesChange == _IndexInViewOfFirstItemThatChangesSizeDuringSizesChange - 1)
				return; // this[int] wasn't assigned between BeginChangingItemsSizes() and EndChangingItemsSizes(), i.e. nothing has changed

			var indexOfLastKeyThatChanged = _Keys.BinarySearch(_IndexInViewOfLastItemThatChangedSizeDuringSizesChange);
			if (indexOfLastKeyThatChanged < 0) // doesn't exist
				throw new InvalidOperationException("The sizes state was corrupted");

			double cumulatedSizesUntilNow = _CumulatedSizesUntilNowDuringSizesChange;
			int prevKey = _IndexInViewOfLastItemThatChangedSizeDuringSizesChange;
			int curKey;
			for (int i = indexOfLastKeyThatChanged + 1; i < _Keys.Count; ++i)
			{
				curKey = _Keys[i];
				cumulatedSizesUntilNow += (curKey - prevKey - 1) * _DefaultSize + _Sizes[curKey];
				_SizesCumulative[curKey] = cumulatedSizesUntilNow;
				prevKey = curKey;
			}
		}

        internal int GetItemRealIndexFromViewIndex(int indexInView) 
		{ 
			if (itemsCount == 0) {
				Debug.LogError ("why divide by zero");
				return 0;
			}
			return (realIndexOfFirstItemInView + indexInView) % itemsCount; 
		}

		internal int GetItemViewIndexFromRealIndex(int realIndex) 
		{ 
			if (itemsCount == 0) {
				Debug.LogError ("why divide by zero");
				return 0;
			}
			return (realIndex - realIndexOfFirstItemInView + itemsCount) % itemsCount;
		}

        internal double GetItemSizeCumulative(int itemIndexInView, bool allowInferringFromNeighborAfter = true)
		{
			// No key in the dictionary. This also means that there's no size in 
			// _Sizes either (assuming the things are done correctly - when a size is set, the cumm size is also set)
			if (_Keys.Count > 0)
			{
				double result;
				if (_SizesCumulative.TryGetValue(itemIndexInView, out result))
					return result;

				int indexOfNextKey = _Keys.BinarySearch(itemIndexInView);
				if (indexOfNextKey >= 0)
					throw new InvalidOperationException("The sizes state was corrupted. key not in _SizesCumulative, but present in _Keys");

				indexOfNextKey = ~indexOfNextKey;
				int indexOfPrevKey = indexOfNextKey - 1;
				//int itemsCountDeltaLeft;

				// Case where there's a key after (bigger) AND "can use next neighbor to infer size"
				if (indexOfNextKey < _Keys.Count && allowInferringFromNeighborAfter)
				{
					int indexInViewOfNextItemWithKnownSize = _Keys[indexOfNextKey];
					int itemsCountDeltaRight = indexInViewOfNextItemWithKnownSize - itemIndexInView;

					// .. and: (size for none of prev items was set OR the next one is closer)  => searched item's cumm. size is 
					// the current item's cumm. size minus <currentItemSize + numItemsBetween * defaultSize>
					if ((indexOfPrevKey < 0 || itemsCountDeltaRight < (/*itemsCountDeltaLeft =*/ itemIndexInView - _Keys[indexOfPrevKey])))
						return _SizesCumulative[indexInViewOfNextItemWithKnownSize] - (this[indexInViewOfNextItemWithKnownSize] + (itemsCountDeltaRight - 1) * _DefaultSize);
				}
				// Case where there's no key after or can't use it, but there may be some before

				if (indexOfPrevKey >= 0)
				{
					int indexInViewOfPrevItemWithKnownSize = _Keys[indexOfPrevKey];
					// Found an item before it that provides a starting point in calculating the searched cumm. size:
					// It's biggestPrevCummSize + itemsCountDelta * defaultSize; 3 possible reasons for this:
					// a. inferring from next keys are not allowed (allowInferringFromNeighborAfter=false)
					// b. there's no next key
					// c. there's a prev key that's closer than the next key
					// .. in all cases, => the prev item's data is generally more reliable
					return _SizesCumulative[indexInViewOfPrevItemWithKnownSize] + (itemIndexInView - indexInViewOfPrevItemWithKnownSize) * _DefaultSize;
				}
			}

			// At this point, there are no keys stored OR the inferring can't or shouldn't be done using the next key => return based on the default size

			return (itemIndexInView + 1) * _DefaultSize; // same as if there were no keys
		}

        internal void RotateItemsSizesOnScrollViewLooped(int newValueOf_RealIndexOfFirstItemInView)
        {
            int oldValueOf_realIndexOfFirstItemInView = realIndexOfFirstItemInView;
            realIndexOfFirstItemInView = newValueOf_RealIndexOfFirstItemInView;

            int rotateAmount = oldValueOf_realIndexOfFirstItemInView - realIndexOfFirstItemInView;
			int keysCount = _Keys.Count;
			if (rotateAmount == 0 && keysCount == 0)
				return;
			if (rotateAmount < 0)
				rotateAmount += itemsCount;

			var keysOld = _Keys.ToArray();
			var sizesOld = _Sizes;
			_Keys.Clear();
			_Sizes = new Dictionary<int, float>(keysCount);
			_SizesCumulative.Clear();
			_SizesCumulative = new Dictionary<int, double>(keysCount);

			int oldKeyWithCurSize, newKeyWithCurSize;
			double cumulatedSizesOfAllItemsUntilNow = 0d;
			int prevKey = -1;
			int numGapsSinceLastKey;
			float size;
			for (int i = 0; i < keysCount; ++i)
			{
				oldKeyWithCurSize = keysOld[i];
				newKeyWithCurSize = (oldKeyWithCurSize + rotateAmount) % itemsCount;
				BinaryAddKeyToSortedListIfDoesntExist(newKeyWithCurSize);
				size = sizesOld[oldKeyWithCurSize];
				_Sizes[newKeyWithCurSize] = size;

				numGapsSinceLastKey = newKeyWithCurSize - prevKey - 1;
				cumulatedSizesOfAllItemsUntilNow += numGapsSinceLastKey * _DefaultSize;
				cumulatedSizesOfAllItemsUntilNow += size;
				_SizesCumulative[newKeyWithCurSize] = cumulatedSizesOfAllItemsUntilNow;

				prevKey = newKeyWithCurSize;
			}
        }
    }
}
