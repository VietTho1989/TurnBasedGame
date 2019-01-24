#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen2117309732.h"

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

// GameManager.Match.CalculateScoreWinLoseDrawUI
struct  CalculateScoreWinLoseDrawUI_t4022670967  : public UIBehavior_1_t2117309732
{
public:
	// System.Boolean GameManager.Match.CalculateScoreWinLoseDrawUI::needReset
	bool ___needReset_6;
	// UnityEngine.GameObject GameManager.Match.CalculateScoreWinLoseDrawUI::differentIndicator
	GameObject_t1756533147 * ___differentIndicator_7;
	// RequestChangeFloatUI GameManager.Match.CalculateScoreWinLoseDrawUI::requestFloatPrefab
	RequestChangeFloatUI_t3993257673 * ___requestFloatPrefab_8;
	// UnityEngine.Transform GameManager.Match.CalculateScoreWinLoseDrawUI::winScoreContainer
	Transform_t3275118058 * ___winScoreContainer_9;
	// UnityEngine.Transform GameManager.Match.CalculateScoreWinLoseDrawUI::loseScoreContainer
	Transform_t3275118058 * ___loseScoreContainer_10;
	// UnityEngine.Transform GameManager.Match.CalculateScoreWinLoseDrawUI::drawScoreContainer
	Transform_t3275118058 * ___drawScoreContainer_11;
	// Server GameManager.Match.CalculateScoreWinLoseDrawUI::server
	Server_t2724320767 * ___server_12;

public:
	inline static int32_t get_offset_of_needReset_6() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___needReset_6)); }
	inline bool get_needReset_6() const { return ___needReset_6; }
	inline bool* get_address_of_needReset_6() { return &___needReset_6; }
	inline void set_needReset_6(bool value)
	{
		___needReset_6 = value;
	}

	inline static int32_t get_offset_of_differentIndicator_7() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___differentIndicator_7)); }
	inline GameObject_t1756533147 * get_differentIndicator_7() const { return ___differentIndicator_7; }
	inline GameObject_t1756533147 ** get_address_of_differentIndicator_7() { return &___differentIndicator_7; }
	inline void set_differentIndicator_7(GameObject_t1756533147 * value)
	{
		___differentIndicator_7 = value;
		Il2CppCodeGenWriteBarrier(&___differentIndicator_7, value);
	}

	inline static int32_t get_offset_of_requestFloatPrefab_8() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___requestFloatPrefab_8)); }
	inline RequestChangeFloatUI_t3993257673 * get_requestFloatPrefab_8() const { return ___requestFloatPrefab_8; }
	inline RequestChangeFloatUI_t3993257673 ** get_address_of_requestFloatPrefab_8() { return &___requestFloatPrefab_8; }
	inline void set_requestFloatPrefab_8(RequestChangeFloatUI_t3993257673 * value)
	{
		___requestFloatPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___requestFloatPrefab_8, value);
	}

	inline static int32_t get_offset_of_winScoreContainer_9() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___winScoreContainer_9)); }
	inline Transform_t3275118058 * get_winScoreContainer_9() const { return ___winScoreContainer_9; }
	inline Transform_t3275118058 ** get_address_of_winScoreContainer_9() { return &___winScoreContainer_9; }
	inline void set_winScoreContainer_9(Transform_t3275118058 * value)
	{
		___winScoreContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___winScoreContainer_9, value);
	}

	inline static int32_t get_offset_of_loseScoreContainer_10() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___loseScoreContainer_10)); }
	inline Transform_t3275118058 * get_loseScoreContainer_10() const { return ___loseScoreContainer_10; }
	inline Transform_t3275118058 ** get_address_of_loseScoreContainer_10() { return &___loseScoreContainer_10; }
	inline void set_loseScoreContainer_10(Transform_t3275118058 * value)
	{
		___loseScoreContainer_10 = value;
		Il2CppCodeGenWriteBarrier(&___loseScoreContainer_10, value);
	}

	inline static int32_t get_offset_of_drawScoreContainer_11() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___drawScoreContainer_11)); }
	inline Transform_t3275118058 * get_drawScoreContainer_11() const { return ___drawScoreContainer_11; }
	inline Transform_t3275118058 ** get_address_of_drawScoreContainer_11() { return &___drawScoreContainer_11; }
	inline void set_drawScoreContainer_11(Transform_t3275118058 * value)
	{
		___drawScoreContainer_11 = value;
		Il2CppCodeGenWriteBarrier(&___drawScoreContainer_11, value);
	}

	inline static int32_t get_offset_of_server_12() { return static_cast<int32_t>(offsetof(CalculateScoreWinLoseDrawUI_t4022670967, ___server_12)); }
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
