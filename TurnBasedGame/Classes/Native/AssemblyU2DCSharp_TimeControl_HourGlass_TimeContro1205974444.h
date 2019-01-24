#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4119333497.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeFloatUI
struct RequestChangeFloatUI_t3993257673;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.HourGlass.TimeControlHourGlassUI
struct  TimeControlHourGlassUI_t1205974444  : public UIBehavior_1_t4119333497
{
public:
	// System.Boolean TimeControl.HourGlass.TimeControlHourGlassUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject TimeControl.HourGlass.TimeControlHourGlassUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeFloatUI TimeControl.HourGlass.TimeControlHourGlassUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_8;
	// UnityEngine.Transform TimeControl.HourGlass.TimeControlHourGlassUI::initTimeContainer
	Transform_t3275118058 * ___initTimeContainer_9;
	// UnityEngine.Transform TimeControl.HourGlass.TimeControlHourGlassUI::lagCompensationContainer
	Transform_t3275118058 * ___lagCompensationContainer_10;
	// Server TimeControl.HourGlass.TimeControlHourGlassUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(TimeControlHourGlassUI_t1205974444, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(TimeControlHourGlassUI_t1205974444, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestFloatPrefab_8() { return static_cast<int32_t>(offsetof(TimeControlHourGlassUI_t1205974444, ___requestFloatPrefab_8)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_8() const { return ___requestFloatPrefab_8; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_8() { return &___requestFloatPrefab_8; }
	inline void set_requestFloatPrefab_8(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_8, value);
	}

	inline static int32_t get_offset_of_initTimeContainer_9() { return static_cast<int32_t>(offsetof(TimeControlHourGlassUI_t1205974444, ___initTimeContainer_9)); }
	inline Transform_t3275118058 * get_initTimeContainer_9() const { return ___initTimeContainer_9; }
	inline Transform_t3275118058 ** get_address_of_initTimeContainer_9() { return &___initTimeContainer_9; }
	inline void set_initTimeContainer_9(Transform_t3275118058 * value)
	{
		___initTimeContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___initTimeContainer_9, value);
	}

	inline static int32_t get_offset_of_lagCompensationContainer_10() { return static_cast<int32_t>(offsetof(TimeControlHourGlassUI_t1205974444, ___lagCompensationContainer_10)); }
	inline Transform_t3275118058 * get_lagCompensationContainer_10() const { return ___lagCompensationContainer_10; }
	inline Transform_t3275118058 ** get_address_of_lagCompensationContainer_10() { return &___lagCompensationContainer_10; }
	inline void set_lagCompensationContainer_10(Transform_t3275118058 * value)
	{
		___lagCompensationContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___lagCompensationContainer_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(TimeControlHourGlassUI_t1205974444, ___server_11)); }
	inline Server_t2724320767 * get_server_11() const { return ___server_11; }
	inline Server_t2724320767 ** get_address_of_server_11() { return &___server_11; }
	inline void set_server_11(Server_t2724320767 * value)
	{
		___server_11 = value;
		Il2CppCodeGenWriteBarrier(&___server_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
