#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3942136571.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// RequestChangeIntUI
struct RequestChangeIntUI_t2563984076;
// RequestChangeBoolUI
struct RequestChangeBoolUI_t2618169711;
// UnityEngine.Transform
struct Transform_t3275118058;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundHaveLimitUI
struct  RequestNewRoundHaveLimitUI_t632612280  : public UIBehavior_1_t3942136571
{
public:
	// System.Boolean GameManager.Match.RequestNewRoundHaveLimitUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject GameManager.Match.RequestNewRoundHaveLimitUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeIntUI GameManager.Match.RequestNewRoundHaveLimitUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_8;
	// RequestChangeBoolUI GameManager.Match.RequestNewRoundHaveLimitUI::requestBoolPrefab
	RequestChangeBoolUI_t2618169711 * ___requestBoolPrefab_9;
	// UnityEngine.Transform GameManager.Match.RequestNewRoundHaveLimitUI::maxRoundContainer
	Transform_t3275118058 * ___maxRoundContainer_10;
	// UnityEngine.Transform GameManager.Match.RequestNewRoundHaveLimitUI::enoughScoreStopContainer
	Transform_t3275118058 * ___enoughScoreStopContainer_11;
	// Server GameManager.Match.RequestNewRoundHaveLimitUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___requestIntPrefab_8)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_8() const { return ___requestIntPrefab_8; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_8() { return &___requestIntPrefab_8; }
	inline void set_requestIntPrefab_8(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_8, value);
	}

	inline static int32_t get_offset_of_requestBoolPrefab_9() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___requestBoolPrefab_9)); }
	inline RequestChangeBoolUI_t2618169711 * get_requestBoolPrefab_9() const { return ___requestBoolPrefab_9; }
	inline RequestChangeBoolUI_t2618169711 ** get_address_of_requestBoolPrefab_9() { return &___requestBoolPrefab_9; }
	inline void set_requestBoolPrefab_9(RequestChangeBoolUI_t2618169711 * value)
	{
		___requestBoolPrefab_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestBoolPrefab_9, value);
	}

	inline static int32_t get_offset_of_maxRoundContainer_10() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___maxRoundContainer_10)); }
	inline Transform_t3275118058 * get_maxRoundContainer_10() const { return ___maxRoundContainer_10; }
	inline Transform_t3275118058 ** get_address_of_maxRoundContainer_10() { return &___maxRoundContainer_10; }
	inline void set_maxRoundContainer_10(Transform_t3275118058 * value)
	{
		___maxRoundContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___maxRoundContainer_10, value);
	}

	inline static int32_t get_offset_of_enoughScoreStopContainer_11() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___enoughScoreStopContainer_11)); }
	inline Transform_t3275118058 * get_enoughScoreStopContainer_11() const { return ___enoughScoreStopContainer_11; }
	inline Transform_t3275118058 ** get_address_of_enoughScoreStopContainer_11() { return &___enoughScoreStopContainer_11; }
	inline void set_enoughScoreStopContainer_11(Transform_t3275118058 * value)
	{
		___enoughScoreStopContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___enoughScoreStopContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(RequestNewRoundHaveLimitUI_t632612280, ___server_12)); }
	inline Server_t2724320767 * get_server_12() const { return ___server_12; }
	inline Server_t2724320767 ** get_address_of_server_12() { return &___server_12; }
	inline void set_server_12(Server_t2724320767 * value)
	{
		___server_12 = value;
		Il2CppCodeGenWriteBarrier(&___server_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
