#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen248988533.h"

// RoomStateNormalUI
struct RoomStateNormalUI_t1025051453;
// RoomStateEndUI
struct RoomStateEndUI_t1451594441;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RoomStateUI
struct  RoomStateUI_t1227043210  : public UIBehavior_1_t248988533
{
public:
	// RoomStateNormalUI RoomStateUI::normalPrefab
	RoomStateNormalUI_t1025051453 * ___normalPrefab_6;
	// RoomStateEndUI RoomStateUI::endPrefab
	RoomStateEndUI_t1451594441 * ___endPrefab_7;
	// UnityEngine.Transform RoomStateUI::subContainer
	Transform_t3275118058 * ___subContainer_8;

public:
	inline static int32_t get_offset_of_normalPrefab_6() { return static_cast<int32_t>(offsetof(RoomStateUI_t1227043210, ___normalPrefab_6)); }
	inline RoomStateNormalUI_t1025051453 * get_normalPrefab_6() const { return ___normalPrefab_6; }
	inline RoomStateNormalUI_t1025051453 ** get_address_of_normalPrefab_6() { return &___normalPrefab_6; }
	inline void set_normalPrefab_6(RoomStateNormalUI_t1025051453 * value)
	{
		___normalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___normalPrefab_6, value);
	}

	inline static int32_t get_offset_of_endPrefab_7() { return static_cast<int32_t>(offsetof(RoomStateUI_t1227043210, ___endPrefab_7)); }
	inline RoomStateEndUI_t1451594441 * get_endPrefab_7() const { return ___endPrefab_7; }
	inline RoomStateEndUI_t1451594441 ** get_address_of_endPrefab_7() { return &___endPrefab_7; }
	inline void set_endPrefab_7(RoomStateEndUI_t1451594441 * value)
	{
		___endPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___endPrefab_7, value);
	}

	inline static int32_t get_offset_of_subContainer_8() { return static_cast<int32_t>(offsetof(RoomStateUI_t1227043210, ___subContainer_8)); }
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
