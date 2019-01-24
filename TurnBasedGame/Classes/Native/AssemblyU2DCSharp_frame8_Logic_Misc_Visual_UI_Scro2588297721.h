#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.Scrollbar
struct Scrollbar_t3248359358;
// System.Action
struct Action_t3226471752;
// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ISRIA
struct ISRIA_t3237148766;
// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8
struct  Snapper8_t2588297721  : public MonoBehaviour_t1158329972
{
public:
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::snapWhenSpeedFallsBelow
	float ___snapWhenSpeedFallsBelow_2;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::viewportSnapPivot01
	float ___viewportSnapPivot01_3;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::itemSnapPivot01
	float ___itemSnapPivot01_4;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::snapDuration
	float ___snapDuration_5;
	// System.Single frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::snapAllowedError
	float ___snapAllowedError_6;
	// UnityEngine.UI.Scrollbar frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::scrollbar
	Scrollbar_t3248359358 * ___scrollbar_7;
	// System.Action frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::SnappingStarted
	Action_t3226471752 * ___SnappingStarted_8;
	// System.Action frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::SnappingEndedOrCancelled
	Action_t3226471752 * ___SnappingEndedOrCancelled_9;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::<SnappingInProgress>k__BackingField
	bool ___U3CSnappingInProgressU3Ek__BackingField_10;
	// frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.ISRIA frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::_Adapter
	Il2CppObject * ____Adapter_11;
	// UnityEngine.UI.ScrollRect frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::_ScrollRect
	ScrollRect_t1199013257 * ____ScrollRect_12;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::_SnappingDoneAndEndSnappingEventPending
	bool ____SnappingDoneAndEndSnappingEventPending_13;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::_SnapNeeded
	bool ____SnapNeeded_14;
	// System.Boolean frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter.Snapper8::_SnappingCancelled
	bool ____SnappingCancelled_15;

public:
	inline static int32_t get_offset_of_snapWhenSpeedFallsBelow_2() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___snapWhenSpeedFallsBelow_2)); }
	inline float get_snapWhenSpeedFallsBelow_2() const { return ___snapWhenSpeedFallsBelow_2; }
	inline float* get_address_of_snapWhenSpeedFallsBelow_2() { return &___snapWhenSpeedFallsBelow_2; }
	inline void set_snapWhenSpeedFallsBelow_2(float value)
	{
		___snapWhenSpeedFallsBelow_2 = value;
	}

	inline static int32_t get_offset_of_viewportSnapPivot01_3() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___viewportSnapPivot01_3)); }
	inline float get_viewportSnapPivot01_3() const { return ___viewportSnapPivot01_3; }
	inline float* get_address_of_viewportSnapPivot01_3() { return &___viewportSnapPivot01_3; }
	inline void set_viewportSnapPivot01_3(float value)
	{
		___viewportSnapPivot01_3 = value;
	}

	inline static int32_t get_offset_of_itemSnapPivot01_4() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___itemSnapPivot01_4)); }
	inline float get_itemSnapPivot01_4() const { return ___itemSnapPivot01_4; }
	inline float* get_address_of_itemSnapPivot01_4() { return &___itemSnapPivot01_4; }
	inline void set_itemSnapPivot01_4(float value)
	{
		___itemSnapPivot01_4 = value;
	}

	inline static int32_t get_offset_of_snapDuration_5() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___snapDuration_5)); }
	inline float get_snapDuration_5() const { return ___snapDuration_5; }
	inline float* get_address_of_snapDuration_5() { return &___snapDuration_5; }
	inline void set_snapDuration_5(float value)
	{
		___snapDuration_5 = value;
	}

	inline static int32_t get_offset_of_snapAllowedError_6() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___snapAllowedError_6)); }
	inline float get_snapAllowedError_6() const { return ___snapAllowedError_6; }
	inline float* get_address_of_snapAllowedError_6() { return &___snapAllowedError_6; }
	inline void set_snapAllowedError_6(float value)
	{
		___snapAllowedError_6 = value;
	}

	inline static int32_t get_offset_of_scrollbar_7() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___scrollbar_7)); }
	inline Scrollbar_t3248359358 * get_scrollbar_7() const { return ___scrollbar_7; }
	inline Scrollbar_t3248359358 ** get_address_of_scrollbar_7() { return &___scrollbar_7; }
	inline void set_scrollbar_7(Scrollbar_t3248359358 * value)
	{
		___scrollbar_7 = value;
		Il2CppCodeGenWriteBarrier(&___scrollbar_7, value);
	}

	inline static int32_t get_offset_of_SnappingStarted_8() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___SnappingStarted_8)); }
	inline Action_t3226471752 * get_SnappingStarted_8() const { return ___SnappingStarted_8; }
	inline Action_t3226471752 ** get_address_of_SnappingStarted_8() { return &___SnappingStarted_8; }
	inline void set_SnappingStarted_8(Action_t3226471752 * value)
	{
		___SnappingStarted_8 = value;
		Il2CppCodeGenWriteBarrier(&___SnappingStarted_8, value);
	}

	inline static int32_t get_offset_of_SnappingEndedOrCancelled_9() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___SnappingEndedOrCancelled_9)); }
	inline Action_t3226471752 * get_SnappingEndedOrCancelled_9() const { return ___SnappingEndedOrCancelled_9; }
	inline Action_t3226471752 ** get_address_of_SnappingEndedOrCancelled_9() { return &___SnappingEndedOrCancelled_9; }
	inline void set_SnappingEndedOrCancelled_9(Action_t3226471752 * value)
	{
		___SnappingEndedOrCancelled_9 = value;
		Il2CppCodeGenWriteBarrier(&___SnappingEndedOrCancelled_9, value);
	}

	inline static int32_t get_offset_of_U3CSnappingInProgressU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ___U3CSnappingInProgressU3Ek__BackingField_10)); }
	inline bool get_U3CSnappingInProgressU3Ek__BackingField_10() const { return ___U3CSnappingInProgressU3Ek__BackingField_10; }
	inline bool* get_address_of_U3CSnappingInProgressU3Ek__BackingField_10() { return &___U3CSnappingInProgressU3Ek__BackingField_10; }
	inline void set_U3CSnappingInProgressU3Ek__BackingField_10(bool value)
	{
		___U3CSnappingInProgressU3Ek__BackingField_10 = value;
	}

	inline static int32_t get_offset_of__Adapter_11() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ____Adapter_11)); }
	inline Il2CppObject * get__Adapter_11() const { return ____Adapter_11; }
	inline Il2CppObject ** get_address_of__Adapter_11() { return &____Adapter_11; }
	inline void set__Adapter_11(Il2CppObject * value)
	{
		____Adapter_11 = value;
		Il2CppCodeGenWriteBarrier(&____Adapter_11, value);
	}

	inline static int32_t get_offset_of__ScrollRect_12() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ____ScrollRect_12)); }
	inline ScrollRect_t1199013257 * get__ScrollRect_12() const { return ____ScrollRect_12; }
	inline ScrollRect_t1199013257 ** get_address_of__ScrollRect_12() { return &____ScrollRect_12; }
	inline void set__ScrollRect_12(ScrollRect_t1199013257 * value)
	{
		____ScrollRect_12 = value;
		Il2CppCodeGenWriteBarrier(&____ScrollRect_12, value);
	}

	inline static int32_t get_offset_of__SnappingDoneAndEndSnappingEventPending_13() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ____SnappingDoneAndEndSnappingEventPending_13)); }
	inline bool get__SnappingDoneAndEndSnappingEventPending_13() const { return ____SnappingDoneAndEndSnappingEventPending_13; }
	inline bool* get_address_of__SnappingDoneAndEndSnappingEventPending_13() { return &____SnappingDoneAndEndSnappingEventPending_13; }
	inline void set__SnappingDoneAndEndSnappingEventPending_13(bool value)
	{
		____SnappingDoneAndEndSnappingEventPending_13 = value;
	}

	inline static int32_t get_offset_of__SnapNeeded_14() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ____SnapNeeded_14)); }
	inline bool get__SnapNeeded_14() const { return ____SnapNeeded_14; }
	inline bool* get_address_of__SnapNeeded_14() { return &____SnapNeeded_14; }
	inline void set__SnapNeeded_14(bool value)
	{
		____SnapNeeded_14 = value;
	}

	inline static int32_t get_offset_of__SnappingCancelled_15() { return static_cast<int32_t>(offsetof(Snapper8_t2588297721, ____SnappingCancelled_15)); }
	inline bool get__SnappingCancelled_15() const { return ____SnappingCancelled_15; }
	inline bool* get_address_of__SnappingCancelled_15() { return &____SnappingCancelled_15; }
	inline void set__SnappingCancelled_15(bool value)
	{
		____SnappingCancelled_15 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
