#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.ScrollRect
struct ScrollRect_t1199013257;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.UI.Extensions.ScrollConflictManager
struct  ScrollConflictManager_t4227891694  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollConflictManager::ParentScrollRect
	ScrollRect_t1199013257 * ___ParentScrollRect_2;
	// UnityEngine.UI.ScrollRect UnityEngine.UI.Extensions.ScrollConflictManager::_myScrollRect
	ScrollRect_t1199013257 * ____myScrollRect_3;
	// System.Boolean UnityEngine.UI.Extensions.ScrollConflictManager::scrollOther
	bool ___scrollOther_4;
	// System.Boolean UnityEngine.UI.Extensions.ScrollConflictManager::scrollOtherHorizontally
	bool ___scrollOtherHorizontally_5;

public:
	inline static int32_t get_offset_of_ParentScrollRect_2() { return static_cast<int32_t>(offsetof(ScrollConflictManager_t4227891694, ___ParentScrollRect_2)); }
	inline ScrollRect_t1199013257 * get_ParentScrollRect_2() const { return ___ParentScrollRect_2; }
	inline ScrollRect_t1199013257 ** get_address_of_ParentScrollRect_2() { return &___ParentScrollRect_2; }
	inline void set_ParentScrollRect_2(ScrollRect_t1199013257 * value)
	{
		___ParentScrollRect_2 = value;
		Il2CppCodeGenWriteBarrier(&___ParentScrollRect_2, value);
	}

	inline static int32_t get_offset_of__myScrollRect_3() { return static_cast<int32_t>(offsetof(ScrollConflictManager_t4227891694, ____myScrollRect_3)); }
	inline ScrollRect_t1199013257 * get__myScrollRect_3() const { return ____myScrollRect_3; }
	inline ScrollRect_t1199013257 ** get_address_of__myScrollRect_3() { return &____myScrollRect_3; }
	inline void set__myScrollRect_3(ScrollRect_t1199013257 * value)
	{
		____myScrollRect_3 = value;
		Il2CppCodeGenWriteBarrier(&____myScrollRect_3, value);
	}

	inline static int32_t get_offset_of_scrollOther_4() { return static_cast<int32_t>(offsetof(ScrollConflictManager_t4227891694, ___scrollOther_4)); }
	inline bool get_scrollOther_4() const { return ___scrollOther_4; }
	inline bool* get_address_of_scrollOther_4() { return &___scrollOther_4; }
	inline void set_scrollOther_4(bool value)
	{
		___scrollOther_4 = value;
	}

	inline static int32_t get_offset_of_scrollOtherHorizontally_5() { return static_cast<int32_t>(offsetof(ScrollConflictManager_t4227891694, ___scrollOtherHorizontally_5)); }
	inline bool get_scrollOtherHorizontally_5() const { return ___scrollOtherHorizontally_5; }
	inline bool* get_address_of_scrollOtherHorizontally_5() { return &___scrollOtherHorizontally_5; }
	inline void set_scrollOtherHorizontally_5(bool value)
	{
		___scrollOtherHorizontally_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
