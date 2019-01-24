#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen757773303.h"

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

// Gomoku.GomokuAIUI
struct  GomokuAIUI_t3837814644  : public UIBehavior_1_t757773303
{
public:
	// System.Boolean Gomoku.GomokuAIUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject Gomoku.GomokuAIUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// UnityEngine.Transform Gomoku.GomokuAIUI::searchDepthContainer
	Transform_t3275118058 * ___searchDepthContainer_8;
	// UnityEngine.Transform Gomoku.GomokuAIUI::timeLimitContainer
	Transform_t3275118058 * ___timeLimitContainer_9;
	// UnityEngine.Transform Gomoku.GomokuAIUI::levelContainer
	Transform_t3275118058 * ___levelContainer_10;
	// RequestChangeIntUI Gomoku.GomokuAIUI::requestIntPrefab
	RequestChangeIntUI_t2563984076 * ___requestIntPrefab_11;
	// Server Gomoku.GomokuAIUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_searchDepthContainer_8() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___searchDepthContainer_8)); }
	inline Transform_t3275118058 * get_searchDepthContainer_8() const { return ___searchDepthContainer_8; }
	inline Transform_t3275118058 ** get_address_of_searchDepthContainer_8() { return &___searchDepthContainer_8; }
	inline void set_searchDepthContainer_8(Transform_t3275118058 * value)
	{
		___searchDepthContainer_8 = value;
		Il2CppCodeGenWriteBarrier(&___searchDepthContainer_8, value);
	}

	inline static int32_t get_offset_of_timeLimitContainer_9() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___timeLimitContainer_9)); }
	inline Transform_t3275118058 * get_timeLimitContainer_9() const { return ___timeLimitContainer_9; }
	inline Transform_t3275118058 ** get_address_of_timeLimitContainer_9() { return &___timeLimitContainer_9; }
	inline void set_timeLimitContainer_9(Transform_t3275118058 * value)
	{
		___timeLimitContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___timeLimitContainer_9, value);
	}

	inline static int32_t get_offset_of_levelContainer_10() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___levelContainer_10)); }
	inline Transform_t3275118058 * get_levelContainer_10() const { return ___levelContainer_10; }
	inline Transform_t3275118058 ** get_address_of_levelContainer_10() { return &___levelContainer_10; }
	inline void set_levelContainer_10(Transform_t3275118058 * value)
	{
		___levelContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___levelContainer_10, value);
	}

	inline static int32_t get_offset_of_requestIntPrefab_11() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___requestIntPrefab_11)); }
	inline RequestChangeIntUI_t2563984076 * get_requestIntPrefab_11() const { return ___requestIntPrefab_11; }
	inline RequestChangeIntUI_t2563984076 ** get_address_of_requestIntPrefab_11() { return &___requestIntPrefab_11; }
	inline void set_requestIntPrefab_11(RequestChangeIntUI_t2563984076 * value)
	{
		___requestIntPrefab_11 = value;
		Il2CppCodeGenWriteBarrier(&___requestIntPrefab_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(GomokuAIUI_t3837814644, ___server_12)); }
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
