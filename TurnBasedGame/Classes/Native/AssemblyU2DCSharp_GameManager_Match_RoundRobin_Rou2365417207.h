#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManager3360960190.h"

// VP`1<GameManager.Match.SingleContestFactory>
struct VP_1_t1476376654;
// LP`1<GameManager.Match.RoundRobin.RoundRobin>
struct LP_1_t2628765674;
// VP`1<GameManager.Match.RoundRobin.RequestNewRoundRobin>
struct VP_1_t804478649;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinContent
struct  RoundRobinContent_t2365417207  : public ContestManagerContent_t3360960190
{
public:
	// VP`1<GameManager.Match.SingleContestFactory> GameManager.Match.RoundRobin.RoundRobinContent::singleContestFactory
	VP_1_t1476376654 * ___singleContestFactory_5;
	// LP`1<GameManager.Match.RoundRobin.RoundRobin> GameManager.Match.RoundRobin.RoundRobinContent::roundRobins
	LP_1_t2628765674 * ___roundRobins_6;
	// VP`1<GameManager.Match.RoundRobin.RequestNewRoundRobin> GameManager.Match.RoundRobin.RoundRobinContent::requestNewRoundRobin
	VP_1_t804478649 * ___requestNewRoundRobin_7;
	// VP`1<System.Boolean> GameManager.Match.RoundRobin.RoundRobinContent::needReturnRound
	VP_1_t4203851724 * ___needReturnRound_8;

public:
	inline static int32_t get_offset_of_singleContestFactory_5() { return static_cast<int32_t>(offsetof(RoundRobinContent_t2365417207, ___singleContestFactory_5)); }
	inline VP_1_t1476376654 * get_singleContestFactory_5() const { return ___singleContestFactory_5; }
	inline VP_1_t1476376654 ** get_address_of_singleContestFactory_5() { return &___singleContestFactory_5; }
	inline void set_singleContestFactory_5(VP_1_t1476376654 * value)
	{
		___singleContestFactory_5 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactory_5, value);
	}

	inline static int32_t get_offset_of_roundRobins_6() { return static_cast<int32_t>(offsetof(RoundRobinContent_t2365417207, ___roundRobins_6)); }
	inline LP_1_t2628765674 * get_roundRobins_6() const { return ___roundRobins_6; }
	inline LP_1_t2628765674 ** get_address_of_roundRobins_6() { return &___roundRobins_6; }
	inline void set_roundRobins_6(LP_1_t2628765674 * value)
	{
		___roundRobins_6 = value;
		Il2CppCodeGenWriteBarrier(&___roundRobins_6, value);
	}

	inline static int32_t get_offset_of_requestNewRoundRobin_7() { return static_cast<int32_t>(offsetof(RoundRobinContent_t2365417207, ___requestNewRoundRobin_7)); }
	inline VP_1_t804478649 * get_requestNewRoundRobin_7() const { return ___requestNewRoundRobin_7; }
	inline VP_1_t804478649 ** get_address_of_requestNewRoundRobin_7() { return &___requestNewRoundRobin_7; }
	inline void set_requestNewRoundRobin_7(VP_1_t804478649 * value)
	{
		___requestNewRoundRobin_7 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRoundRobin_7, value);
	}

	inline static int32_t get_offset_of_needReturnRound_8() { return static_cast<int32_t>(offsetof(RoundRobinContent_t2365417207, ___needReturnRound_8)); }
	inline VP_1_t4203851724 * get_needReturnRound_8() const { return ___needReturnRound_8; }
	inline VP_1_t4203851724 ** get_address_of_needReturnRound_8() { return &___needReturnRound_8; }
	inline void set_needReturnRound_8(VP_1_t4203851724 * value)
	{
		___needReturnRound_8 = value;
		Il2CppCodeGenWriteBarrier(&___needReturnRound_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
