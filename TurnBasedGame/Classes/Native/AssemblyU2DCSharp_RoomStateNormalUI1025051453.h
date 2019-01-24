#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2099420424.h"

// RoomStateNormalNormalUI
struct RoomStateNormalNormalUI_t1295535850;
// RoomStateNormalFreezeUI
struct RoomStateNormalFreezeUI_t2176845042;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomStateNormalUI
struct  RoomStateNormalUI_t1025051453  : public UIBehavior_1_t2099420424
{
public:
	// RoomStateNormalNormalUI RoomStateNormalUI::normalPrefab
	RoomStateNormalNormalUI_t1295535850 * ___normalPrefab_6;
	// RoomStateNormalFreezeUI RoomStateNormalUI::freezePrefab
	RoomStateNormalFreezeUI_t2176845042 * ___freezePrefab_7;
	// UnityEngine.Transform RoomStateNormalUI::subContainer
	Transform_t3275118058 * ___subContainer_8;

public:
	inline static int32_t get_offset_of_normalPrefab_6() { return static_cast<int32_t>(offsetof(RoomStateNormalUI_t1025051453, ___normalPrefab_6)); }
	inline RoomStateNormalNormalUI_t1295535850 * get_normalPrefab_6() const { return ___normalPrefab_6; }
	inline RoomStateNormalNormalUI_t1295535850 ** get_address_of_normalPrefab_6() { return &___normalPrefab_6; }
	inline void set_normalPrefab_6(RoomStateNormalNormalUI_t1295535850 * value)
	{
		___normalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___normalPrefab_6, value);
	}

	inline static int32_t get_offset_of_freezePrefab_7() { return static_cast<int32_t>(offsetof(RoomStateNormalUI_t1025051453, ___freezePrefab_7)); }
	inline RoomStateNormalFreezeUI_t2176845042 * get_freezePrefab_7() const { return ___freezePrefab_7; }
	inline RoomStateNormalFreezeUI_t2176845042 ** get_address_of_freezePrefab_7() { return &___freezePrefab_7; }
	inline void set_freezePrefab_7(RoomStateNormalFreezeUI_t2176845042 * value)
	{
		___freezePrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___freezePrefab_7, value);
	}

	inline static int32_t get_offset_of_subContainer_8() { return static_cast<int32_t>(offsetof(RoomStateNormalUI_t1025051453, ___subContainer_8)); }
	inline Transform_t3275118058 * get_subContainer_8() const { return ___subContainer_8; }
	inline Transform_t3275118058 ** get_address_of_subContainer_8() { return &___subContainer_8; }
	inline void set_subContainer_8(Transform_t3275118058 * value)
	{
		___subContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
