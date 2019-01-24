#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen4115260720.h"

// GameManager.Match.RoundRobin.RequestNewRoundRobinStateNoneUI
struct RequestNewRoundRobinStateNoneUI_t2050755932;
// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAskUI
struct RequestNewRoundRobinStateAskUI_t158078549;
// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAcceptUI
struct RequestNewRoundRobinStateAcceptUI_t190559218;
// UnityEngine.Transform
struct Transform_t3275118058;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RequestNewRoundRobinUI
struct  RequestNewRoundRobinUI_t3662073043  : public UIBehavior_1_t4115260720
{
public:
	// GameManager.Match.RoundRobin.RequestNewRoundRobinStateNoneUI GameManager.Match.RoundRobin.RequestNewRoundRobinUI::nonePrefab
	RequestNewRoundRobinStateNoneUI_t2050755932 * ___nonePrefab_6;
	// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAskUI GameManager.Match.RoundRobin.RequestNewRoundRobinUI::askPrefab
	RequestNewRoundRobinStateAskUI_t158078549 * ___askPrefab_7;
	// GameManager.Match.RoundRobin.RequestNewRoundRobinStateAcceptUI GameManager.Match.RoundRobin.RequestNewRoundRobinUI::acceptPrefab
	RequestNewRoundRobinStateAcceptUI_t190559218 * ___acceptPrefab_8;
	// UnityEngine.Transform GameManager.Match.RoundRobin.RequestNewRoundRobinUI::stateContainer
	Transform_t3275118058 * ___stateContainer_9;

public:
	inline static int32_t get_offset_of_nonePrefab_6() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinUI_t3662073043, ___nonePrefab_6)); }
	inline RequestNewRoundRobinStateNoneUI_t2050755932 * get_nonePrefab_6() const { return ___nonePrefab_6; }
	inline RequestNewRoundRobinStateNoneUI_t2050755932 ** get_address_of_nonePrefab_6() { return &___nonePrefab_6; }
	inline void set_nonePrefab_6(RequestNewRoundRobinStateNoneUI_t2050755932 * value)
	{
		___nonePrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___nonePrefab_6, value);
	}

	inline static int32_t get_offset_of_askPrefab_7() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinUI_t3662073043, ___askPrefab_7)); }
	inline RequestNewRoundRobinStateAskUI_t158078549 * get_askPrefab_7() const { return ___askPrefab_7; }
	inline RequestNewRoundRobinStateAskUI_t158078549 ** get_address_of_askPrefab_7() { return &___askPrefab_7; }
	inline void set_askPrefab_7(RequestNewRoundRobinStateAskUI_t158078549 * value)
	{
		___askPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___askPrefab_7, value);
	}

	inline static int32_t get_offset_of_acceptPrefab_8() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinUI_t3662073043, ___acceptPrefab_8)); }
	inline RequestNewRoundRobinStateAcceptUI_t190559218 * get_acceptPrefab_8() const { return ___acceptPrefab_8; }
	inline RequestNewRoundRobinStateAcceptUI_t190559218 ** get_address_of_acceptPrefab_8() { return &___acceptPrefab_8; }
	inline void set_acceptPrefab_8(RequestNewRoundRobinStateAcceptUI_t190559218 * value)
	{
		___acceptPrefab_8 = value;
		Il2CppCodeGenWriteBarrier(&___acceptPrefab_8, value);
	}

	inline static int32_t get_offset_of_stateContainer_9() { return static_cast<int32_t>(offsetof(RequestNewRoundRobinUI_t3662073043, ___stateContainer_9)); }
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
