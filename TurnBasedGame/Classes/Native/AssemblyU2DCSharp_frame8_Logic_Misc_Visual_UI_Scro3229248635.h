#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<System.Int32>
struct List_1_t1440998580;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Single>
struct Dictionary_2_t1084335567;
// System.Collections.Generic.Dictionary`2<System.Int32,System.Double>
struct Dictionary_2_t3085841316;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor
struct  ItemsDescriptor_t3229248635  : public Il2CppObject
{
public:
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::itemsConstantTransversalSize
	float ___itemsConstantTransversalSize_0;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::itemsCount
	int32_t ___itemsCount_1;
	// System.Double frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::cumulatedSizesOfAllItemsPlusSpacing
	double ___cumulatedSizesOfAllItemsPlusSpacing_2;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::realIndexOfFirstItemInView
	int32_t ___realIndexOfFirstItemInView_3;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::maxVisibleItemsSeenSinceLastScrollViewSizeChange
	int32_t ___maxVisibleItemsSeenSinceLastScrollViewSizeChange_4;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::destroyedItemsSinceLastScrollViewSizeChange
	int32_t ___destroyedItemsSinceLastScrollViewSizeChange_5;
	// System.Collections.Generic.List`1<System.Int32> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_Keys
	List_1_t1440998580 * ____Keys_6;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Single> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_Sizes
	Dictionary_2_t1084335567 * ____Sizes_7;
	// System.Collections.Generic.Dictionary`2<System.Int32,System.Double> frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_SizesCumulative
	Dictionary_2_t3085841316 * ____SizesCumulative_8;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_DefaultSize
	float ____DefaultSize_9;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_ChangingItemsSizesInProgress
	bool ____ChangingItemsSizesInProgress_10;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_IndexInViewOfFirstItemThatChangesSizeDuringSizesChange
	int32_t ____IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11;
	// System.Int32 frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_IndexInViewOfLastItemThatChangedSizeDuringSizesChange
	int32_t ____IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12;
	// System.Double frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ItemsDescriptor::_CumulatedSizesUntilNowDuringSizesChange
	double ____CumulatedSizesUntilNowDuringSizesChange_13;

public:
	inline static int32_t get_offset_of_itemsConstantTransversalSize_0() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ___itemsConstantTransversalSize_0)); }
	inline float get_itemsConstantTransversalSize_0() const { return ___itemsConstantTransversalSize_0; }
	inline float* get_address_of_itemsConstantTransversalSize_0() { return &___itemsConstantTransversalSize_0; }
	inline void set_itemsConstantTransversalSize_0(float value)
	{
		___itemsConstantTransversalSize_0 = value;
	}

	inline static int32_t get_offset_of_itemsCount_1() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ___itemsCount_1)); }
	inline int32_t get_itemsCount_1() const { return ___itemsCount_1; }
	inline int32_t* get_address_of_itemsCount_1() { return &___itemsCount_1; }
	inline void set_itemsCount_1(int32_t value)
	{
		___itemsCount_1 = value;
	}

	inline static int32_t get_offset_of_cumulatedSizesOfAllItemsPlusSpacing_2() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ___cumulatedSizesOfAllItemsPlusSpacing_2)); }
	inline double get_cumulatedSizesOfAllItemsPlusSpacing_2() const { return ___cumulatedSizesOfAllItemsPlusSpacing_2; }
	inline double* get_address_of_cumulatedSizesOfAllItemsPlusSpacing_2() { return &___cumulatedSizesOfAllItemsPlusSpacing_2; }
	inline void set_cumulatedSizesOfAllItemsPlusSpacing_2(double value)
	{
		___cumulatedSizesOfAllItemsPlusSpacing_2 = value;
	}

	inline static int32_t get_offset_of_realIndexOfFirstItemInView_3() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ___realIndexOfFirstItemInView_3)); }
	inline int32_t get_realIndexOfFirstItemInView_3() const { return ___realIndexOfFirstItemInView_3; }
	inline int32_t* get_address_of_realIndexOfFirstItemInView_3() { return &___realIndexOfFirstItemInView_3; }
	inline void set_realIndexOfFirstItemInView_3(int32_t value)
	{
		___realIndexOfFirstItemInView_3 = value;
	}

	inline static int32_t get_offset_of_maxVisibleItemsSeenSinceLastScrollViewSizeChange_4() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ___maxVisibleItemsSeenSinceLastScrollViewSizeChange_4)); }
	inline int32_t get_maxVisibleItemsSeenSinceLastScrollViewSizeChange_4() const { return ___maxVisibleItemsSeenSinceLastScrollViewSizeChange_4; }
	inline int32_t* get_address_of_maxVisibleItemsSeenSinceLastScrollViewSizeChange_4() { return &___maxVisibleItemsSeenSinceLastScrollViewSizeChange_4; }
	inline void set_maxVisibleItemsSeenSinceLastScrollViewSizeChange_4(int32_t value)
	{
		___maxVisibleItemsSeenSinceLastScrollViewSizeChange_4 = value;
	}

	inline static int32_t get_offset_of_destroyedItemsSinceLastScrollViewSizeChange_5() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ___destroyedItemsSinceLastScrollViewSizeChange_5)); }
	inline int32_t get_destroyedItemsSinceLastScrollViewSizeChange_5() const { return ___destroyedItemsSinceLastScrollViewSizeChange_5; }
	inline int32_t* get_address_of_destroyedItemsSinceLastScrollViewSizeChange_5() { return &___destroyedItemsSinceLastScrollViewSizeChange_5; }
	inline void set_destroyedItemsSinceLastScrollViewSizeChange_5(int32_t value)
	{
		___destroyedItemsSinceLastScrollViewSizeChange_5 = value;
	}

	inline static int32_t get_offset_of__Keys_6() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____Keys_6)); }
	inline List_1_t1440998580 * get__Keys_6() const { return ____Keys_6; }
	inline List_1_t1440998580 ** get_address_of__Keys_6() { return &____Keys_6; }
	inline void set__Keys_6(List_1_t1440998580 * value)
	{
		____Keys_6 = value;
		Il2CppCodeGenWriteBarrier(&____Keys_6, value);
	}

	inline static int32_t get_offset_of__Sizes_7() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____Sizes_7)); }
	inline Dictionary_2_t1084335567 * get__Sizes_7() const { return ____Sizes_7; }
	inline Dictionary_2_t1084335567 ** get_address_of__Sizes_7() { return &____Sizes_7; }
	inline void set__Sizes_7(Dictionary_2_t1084335567 * value)
	{
		____Sizes_7 = value;
		Il2CppCodeGenWriteBarrier(&____Sizes_7, value);
	}

	inline static int32_t get_offset_of__SizesCumulative_8() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____SizesCumulative_8)); }
	inline Dictionary_2_t3085841316 * get__SizesCumulative_8() const { return ____SizesCumulative_8; }
	inline Dictionary_2_t3085841316 ** get_address_of__SizesCumulative_8() { return &____SizesCumulative_8; }
	inline void set__SizesCumulative_8(Dictionary_2_t3085841316 * value)
	{
		____SizesCumulative_8 = value;
		Il2CppCodeGenWriteBarrier(&____SizesCumulative_8, value);
	}

	inline static int32_t get_offset_of__DefaultSize_9() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____DefaultSize_9)); }
	inline float get__DefaultSize_9() const { return ____DefaultSize_9; }
	inline float* get_address_of__DefaultSize_9() { return &____DefaultSize_9; }
	inline void set__DefaultSize_9(float value)
	{
		____DefaultSize_9 = value;
	}

	inline static int32_t get_offset_of__ChangingItemsSizesInProgress_10() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____ChangingItemsSizesInProgress_10)); }
	inline bool get__ChangingItemsSizesInProgress_10() const { return ____ChangingItemsSizesInProgress_10; }
	inline bool* get_address_of__ChangingItemsSizesInProgress_10() { return &____ChangingItemsSizesInProgress_10; }
	inline void set__ChangingItemsSizesInProgress_10(bool value)
	{
		____ChangingItemsSizesInProgress_10 = value;
	}

	inline static int32_t get_offset_of__IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11)); }
	inline int32_t get__IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11() const { return ____IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11; }
	inline int32_t* get_address_of__IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11() { return &____IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11; }
	inline void set__IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11(int32_t value)
	{
		____IndexInViewOfFirstItemThatChangesSizeDuringSizesChange_11 = value;
	}

	inline static int32_t get_offset_of__IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12)); }
	inline int32_t get__IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12() const { return ____IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12; }
	inline int32_t* get_address_of__IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12() { return &____IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12; }
	inline void set__IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12(int32_t value)
	{
		____IndexInViewOfLastItemThatChangedSizeDuringSizesChange_12 = value;
	}

	inline static int32_t get_offset_of__CumulatedSizesUntilNowDuringSizesChange_13() { return static_cast<int32_t>(offsetof(ItemsDescriptor_t3229248635, ____CumulatedSizesUntilNowDuringSizesChange_13)); }
	inline double get__CumulatedSizesUntilNowDuringSizesChange_13() const { return ____CumulatedSizesUntilNowDuringSizesChange_13; }
	inline double* get_address_of__CumulatedSizesUntilNowDuringSizesChange_13() { return &____CumulatedSizesUntilNowDuringSizesChange_13; }
	inline void set__CumulatedSizesUntilNowDuringSizesChange_13(double value)
	{
		____CumulatedSizesUntilNowDuringSizesChange_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
