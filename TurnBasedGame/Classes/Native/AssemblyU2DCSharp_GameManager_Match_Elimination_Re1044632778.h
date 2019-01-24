#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen3483749100.h"

// GameManager.Match.Elimination.RequestNewEliminationRoundStateNoneUI
struct RequestNewEliminationRoundStateNoneUI_t3110872101;
// GameManager.Match.Elimination.RequestNewEliminationRoundStateAskUI
struct RequestNewEliminationRoundStateAskUI_t2811809168;
// GameManager.Match.Elimination.RequestNewEliminationRoundStateAcceptUI
struct RequestNewEliminationRoundStateAcceptUI_t3888817191;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.RequestNewEliminationRoundUI
struct  RequestNewEliminationRoundUI_t1044632778  : public UIBehavior_1_t3483749100
{
public:
	// GameManager.Match.Elimination.RequestNewEliminationRoundStateNoneUI GameManager.Match.Elimination.RequestNewEliminationRoundUI::nonePrefab
	RequestNewEliminationRoundStateNoneUI_t3110872101 * ___nonePrefab_6;
	// GameManager.Match.Elimination.RequestNewEliminationRoundStateAskUI GameManager.Match.Elimination.RequestNewEliminationRoundUI::askPrefab
	RequestNewEliminationRoundStateAskUI_t2811809168 * ___askPrefab_7;
	// GameManager.Match.Elimination.RequestNewEliminationRoundStateAcceptUI GameManager.Match.Elimination.RequestNewEliminationRoundUI::acceptPrefab
	RequestNewEliminationRoundStateAcceptUI_t3888817191 * ___acceptPrefab_8;
	// UnityEngine.Transform GameManager.Match.Elimination.RequestNewEliminationRoundUI::stateContainer
	Transform_t3275118058 * ___stateContainer_9;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundUI_t1044632778, ___nonePrefab_6)); }
	inline RequestNewEliminationRoundStateNoneUI_t3110872101 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline RequestNewEliminationRoundStateNoneUI_t3110872101 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(RequestNewEliminationRoundStateNoneUI_t3110872101 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_askPrefab_7() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundUI_t1044632778, ___askPrefab_7)); }
	inline RequestNewEliminationRoundStateAskUI_t2811809168 * get_askPrefab_7() const { return ___askPrefab_7; }
	inline RequestNewEliminationRoundStateAskUI_t2811809168 ** get_address_of_askPrefab_7() { return &___askPrefab_7; }
	inline void set_askPrefab_7(RequestNewEliminationRoundStateAskUI_t2811809168 * value)
	{
		___askPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_7, value);
	}

	inline static int32_t get_offset_of_acceptPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundUI_t1044632778, ___acceptPrefab_8)); }
	inline RequestNewEliminationRoundStateAcceptUI_t3888817191 * get_acceptPrefab_8() const { return ___acceptPrefab_8; }
	inline RequestNewEliminationRoundStateAcceptUI_t3888817191 ** get_address_of_acceptPrefab_8() { return &___acceptPrefab_8; }
	inline void set_acceptPrefab_8(RequestNewEliminationRoundStateAcceptUI_t3888817191 * value)
	{
		___acceptPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___acceptPrefab_8, value);
	}

	inline static int32_t get_offset_of_stateContainer_9() { return static_cast<int32_t>(offsetof(RequestNewEliminationRoundUI_t1044632778, ___stateContainer_9)); }
	inline Transform_t3275118058 * get_stateContainer_9() const { return ___stateContainer_9; }
	inline Transform_t3275118058 ** get_address_of_stateContainer_9() { return &___stateContainer_9; }
	inline void set_stateContainer_9(Transform_t3275118058 * value)
	{
		___stateContainer_9 = value;
		Il2CppCodeGenWriteBarrier(&___stateContainer_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
