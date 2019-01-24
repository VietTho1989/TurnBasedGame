#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2868241365.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// TimeControl.Normal.TotalTimeInfoNoLimitUI
struct TotalTimeInfoNoLimitUI_t2195625349;
// TimeControl.Normal.TotalTimeInfoLimitUI
struct TotalTimeInfoLimitUI_t3344022774;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeControl.Normal.TotalTimeInfoUI
struct  TotalTimeInfoUI_t1026484747  : public UIBehavior_1_t2868241365
{
public:
	// System.Boolean TimeControl.Normal.TotalTimeInfoUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject TimeControl.Normal.TotalTimeInfoUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// TimeControl.Normal.TotalTimeInfoNoLimitUI TimeControl.Normal.TotalTimeInfoUI::noLimitPrefab
	TotalTimeInfoNoLimitUI_t2195625349 * ___noLimitPrefab_8;
	// TimeControl.Normal.TotalTimeInfoLimitUI TimeControl.Normal.TotalTimeInfoUI::limitPrefab
	TotalTimeInfoLimitUI_t3344022774 * ___limitPrefab_9;
	// UnityEngine.Transform TimeControl.Normal.TotalTimeInfoUI::subContainer
	Transform_t3275118058 * ___subContainer_10;
	// Server TimeControl.Normal.TotalTimeInfoUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(TotalTimeInfoUI_t1026484747, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(TotalTimeInfoUI_t1026484747, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_noLimitPrefab_8() { return static_cast<int32_t>(offsetof(TotalTimeInfoUI_t1026484747, ___noLimitPrefab_8)); }
	inline TotalTimeInfoNoLimitUI_t2195625349 * get_noLimitPrefab_8() const { return ___noLimitPrefab_8; }
	inline TotalTimeInfoNoLimitUI_t2195625349 ** get_address_of_noLimitPrefab_8() { return &___noLimitPrefab_8; }
	inline void set_noLimitPrefab_8(TotalTimeInfoNoLimitUI_t2195625349 * value)
	{
		___noLimitPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___noLimitPrefab_8, value);
	}

	inline static int32_t get_offset_of_limitPrefab_9() { return static_cast<int32_t>(offsetof(TotalTimeInfoUI_t1026484747, ___limitPrefab_9)); }
	inline TotalTimeInfoLimitUI_t3344022774 * get_limitPrefab_9() const { return ___limitPrefab_9; }
	inline TotalTimeInfoLimitUI_t3344022774 ** get_address_of_limitPrefab_9() { return &___limitPrefab_9; }
	inline void set_limitPrefab_9(TotalTimeInfoLimitUI_t3344022774 * value)
	{
		___limitPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___limitPrefab_9, value);
	}

	inline static int32_t get_offset_of_subContainer_10() { return static_cast<int32_t>(offsetof(TotalTimeInfoUI_t1026484747, ___subContainer_10)); }
	inline Transform_t3275118058 * get_subContainer_10() const { return ___subContainer_10; }
	inline Transform_t3275118058 ** get_address_of_subContainer_10() { return &___subContainer_10; }
	inline void set_subContainer_10(Transform_t3275118058 * value)
	{
		___subContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___subContainer_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(TotalTimeInfoUI_t1026484747, ___server_11)); }
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
