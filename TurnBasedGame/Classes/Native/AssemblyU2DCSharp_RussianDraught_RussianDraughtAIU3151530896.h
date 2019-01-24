#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen1510013039.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Transform
struct Transform_t3275118058;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtAIUI
struct  RussianDraughtAIUI_t3151530896  : public UIBehavior_1_t1510013039
{
public:
	// System.Boolean RussianDraught.RussianDraughtAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject RussianDraught.RussianDraughtAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform RussianDraught.RussianDraughtAIUI::timeLimitContainer
	Transform_t3275118058 * ___timeLimitContainer_8;
	// UnityEngine.Transform RussianDraught.RussianDraughtAIUI::pickBestMoveContainer
	Transform_t3275118058 * ___pickBestMoveContainer_9;
	// RequestChangeIntUI RussianDraught.RussianDraughtAIUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_10;
	// Server RussianDraught.RussianDraughtAIUI::server
	Server_t2724320767 * ___server_11;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(RussianDraughtAIUI_t3151530896, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(RussianDraughtAIUI_t3151530896, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_timeLimitContainer_8() { return static_cast<int32_t>(offsetof(RussianDraughtAIUI_t3151530896, ___timeLimitContainer_8)); }
	inline Transform_t3275118058 * get_timeLimitContainer_8() const { return ___timeLimitContainer_8; }
	inline Transform_t3275118058 ** get_address_of_timeLimitContainer_8() { return &___timeLimitContainer_8; }
	inline void set_timeLimitContainer_8(Transform_t3275118058 * value)
	{
		___timeLimitContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___timeLimitContainer_8, value);
	}

	inline static int32_t get_offset_of_pickBestMoveContainer_9() { return static_cast<int32_t>(offsetof(RussianDraughtAIUI_t3151530896, ___pickBestMoveContainer_9)); }
	inline Transform_t3275118058 * get_pickBestMoveContainer_9() const { return ___pickBestMoveContainer_9; }
	inline Transform_t3275118058 ** get_address_of_pickBestMoveContainer_9() { return &___pickBestMoveContainer_9; }
	inline void set_pickBestMoveContainer_9(Transform_t3275118058 * value)
	{
		___pickBestMoveContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___pickBestMoveContainer_9, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_10() { return static_cast<int32_t>(offsetof(RussianDraughtAIUI_t3151530896, ___requestIntPrefab_10)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_10() const { return ___requestIntPrefab_10; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_10() { return &___requestIntPrefab_10; }
	inline void set_requestIntPrefab_10(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_10 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_10, value);
	}

	inline static int32_t get_offset_of_server_11() { return static_cast<int32_t>(offsetof(RussianDraughtAIUI_t3151530896, ___server_11)); }
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
