#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen442333985.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// TimeControl.Normal.TimeInfoUI
struct TimeInfoUI_t3022193567;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TimeControlNormalUI
struct  TimeControlNormalUI_t789601165  : public UIBehavior_1_t442333985
{
public:
	// System.Boolean TimeControl.Normal.TimeControlNormalUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject TimeControl.Normal.TimeControlNormalUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// TimeControl.Normal.TimeInfoUI TimeControl.Normal.TimeControlNormalUI::timeInfoPrefab
	TimeInfoUI_t3022193567 * ___timeInfoPrefab_8;
	// UnityEngine.Transform TimeControl.Normal.TimeControlNormalUI::generalInfoContainer
	Transform_t3275118058 * ___generalInfoContainer_9;
	// Server TimeControl.Normal.TimeControlNormalUI::server
	Server_t2724320767 * ___server_10;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(TimeControlNormalUI_t789601165, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(TimeControlNormalUI_t789601165, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_timeInfoPrefab_8() { return static_cast<int32_t>(offsetof(TimeControlNormalUI_t789601165, ___timeInfoPrefab_8)); }
	inline TimeInfoUI_t3022193567 * get_timeInfoPrefab_8() const { return ___timeInfoPrefab_8; }
	inline TimeInfoUI_t3022193567 ** get_address_of_timeInfoPrefab_8() { return &___timeInfoPrefab_8; }
	inline void set_timeInfoPrefab_8(TimeInfoUI_t3022193567 * value)
	{
		___timeInfoPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___timeInfoPrefab_8, value);
	}

	inline static int32_t get_offset_of_generalInfoContainer_9() { return static_cast<int32_t>(offsetof(TimeControlNormalUI_t789601165, ___generalInfoContainer_9)); }
	inline Transform_t3275118058 * get_generalInfoContainer_9() const { return ___generalInfoContainer_9; }
	inline Transform_t3275118058 ** get_address_of_generalInfoContainer_9() { return &___generalInfoContainer_9; }
	inline void set_generalInfoContainer_9(Transform_t3275118058 * value)
	{
		___generalInfoContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___generalInfoContainer_9, value);
	}

	inline static int32_t get_offset_of_server_10() { return static_cast<int32_t>(offsetof(TimeControlNormalUI_t789601165, ___server_10)); }
	inline Server_t2724320767 * get_server_10() const { return ___server_10; }
	inline Server_t2724320767 ** get_address_of_server_10() { return &___server_10; }
	inline void set_server_10(Server_t2724320767 * value)
	{
		___server_10 = value;
		Il2CppCodeGenWriteBarrier(&___server_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
