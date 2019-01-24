#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// frame8.ScrollRectItemsAdapter.Util.LongClickableItem/IItemLongClickListener
struct IItemLongClickListener_t2410271579;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.ScrollRectItemsAdapter.Util.LongClickableItem
struct  LongClickableItem_t2024321917  : public MonoBehaviour_t1158329972
{
public:
	// System.Single frame8.ScrollRectItemsAdapter.Util.LongClickableItem::longClickTime
	float ___longClickTime_2;
	// frame8.ScrollRectItemsAdapter.Util.LongClickableItem/IItemLongClickListener frame8.ScrollRectItemsAdapter.Util.LongClickableItem::longClickListener
	Il2CppObject * ___longClickListener_3;
	// System.Single frame8.ScrollRectItemsAdapter.Util.LongClickableItem::_PressedTime
	float ____PressedTime_4;
	// System.Boolean frame8.ScrollRectItemsAdapter.Util.LongClickableItem::_Pressing
	bool ____Pressing_5;

public:
	inline static int32_t get_offset_of_longClickTime_2() { return static_cast<int32_t>(offsetof(LongClickableItem_t2024321917, ___longClickTime_2)); }
	inline float get_longClickTime_2() const { return ___longClickTime_2; }
	inline float* get_address_of_longClickTime_2() { return &___longClickTime_2; }
	inline void set_longClickTime_2(float value)
	{
		___longClickTime_2 = value;
	}

	inline static int32_t get_offset_of_longClickListener_3() { return static_cast<int32_t>(offsetof(LongClickableItem_t2024321917, ___longClickListener_3)); }
	inline Il2CppObject * get_longClickListener_3() const { return ___longClickListener_3; }
	inline Il2CppObject ** get_address_of_longClickListener_3() { return &___longClickListener_3; }
	inline void set_longClickListener_3(Il2CppObject * value)
	{
		___longClickListener_3 = value;
		Il2CppCodeGenWriteBarrier(&___longClickListener_3, value);
	}

	inline static int32_t get_offset_of__PressedTime_4() { return static_cast<int32_t>(offsetof(LongClickableItem_t2024321917, ____PressedTime_4)); }
	inline float get__PressedTime_4() const { return ____PressedTime_4; }
	inline float* get_address_of__PressedTime_4() { return &____PressedTime_4; }
	inline void set__PressedTime_4(float value)
	{
		____PressedTime_4 = value;
	}

	inline static int32_t get_offset_of__Pressing_5() { return static_cast<int32_t>(offsetof(LongClickableItem_t2024321917, ____Pressing_5)); }
	inline bool get__Pressing_5() const { return ____Pressing_5; }
	inline bool* get_address_of__Pressing_5() { return &____Pressing_5; }
	inline void set__Pressing_5(bool value)
	{
		____Pressing_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
