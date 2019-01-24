#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen126965956.h"

// GameManager.Match.RequestNewRoundStateNoneUI
struct RequestNewRoundStateNoneUI_t1646012582;
// GameManager.Match.RequestNewRoundStateAskUI
struct RequestNewRoundStateAskUI_t2354278443;
// GameManager.Match.RequestNewRoundStateAcceptUI
struct RequestNewRoundStateAcceptUI_t1792728192;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRoundUI
struct  RequestNewRoundUI_t1925056109  : public UIBehavior_1_t126965956
{
public:
	// GameManager.Match.RequestNewRoundStateNoneUI GameManager.Match.RequestNewRoundUI::nonePrefab
	RequestNewRoundStateNoneUI_t1646012582 * ___nonePrefab_6;
	// GameManager.Match.RequestNewRoundStateAskUI GameManager.Match.RequestNewRoundUI::askPrefab
	RequestNewRoundStateAskUI_t2354278443 * ___askPrefab_7;
	// GameManager.Match.RequestNewRoundStateAcceptUI GameManager.Match.RequestNewRoundUI::acceptPrefab
	RequestNewRoundStateAcceptUI_t1792728192 * ___acceptPrefab_8;
	// UnityEngine.Transform GameManager.Match.RequestNewRoundUI::stateContainer
	Transform_t3275118058 * ___stateContainer_9;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(RequestNewRoundUI_t1925056109, ___nonePrefab_6)); }
	inline RequestNewRoundStateNoneUI_t1646012582 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline RequestNewRoundStateNoneUI_t1646012582 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(RequestNewRoundStateNoneUI_t1646012582 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_askPrefab_7() { return static_cast<int32_t>(offsetof(RequestNewRoundUI_t1925056109, ___askPrefab_7)); }
	inline RequestNewRoundStateAskUI_t2354278443 * get_askPrefab_7() const { return ___askPrefab_7; }
	inline RequestNewRoundStateAskUI_t2354278443 ** get_address_of_askPrefab_7() { return &___askPrefab_7; }
	inline void set_askPrefab_7(RequestNewRoundStateAskUI_t2354278443 * value)
	{
		___askPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_7, value);
	}

	inline static int32_t get_offset_of_acceptPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewRoundUI_t1925056109, ___acceptPrefab_8)); }
	inline RequestNewRoundStateAcceptUI_t1792728192 * get_acceptPrefab_8() const { return ___acceptPrefab_8; }
	inline RequestNewRoundStateAcceptUI_t1792728192 ** get_address_of_acceptPrefab_8() { return &___acceptPrefab_8; }
	inline void set_acceptPrefab_8(RequestNewRoundStateAcceptUI_t1792728192 * value)
	{
		___acceptPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___acceptPrefab_8, value);
	}

	inline static int32_t get_offset_of_stateContainer_9() { return static_cast<int32_t>(offsetof(RequestNewRoundUI_t1925056109, ___stateContainer_9)); }
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
