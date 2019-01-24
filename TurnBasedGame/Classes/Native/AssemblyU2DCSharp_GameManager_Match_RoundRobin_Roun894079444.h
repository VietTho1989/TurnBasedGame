#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManagerC825758832.h"

// VP`1<GameManager.Match.SingleContestFactory>
struct VP_1_t1476376654;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinFactory
struct  RoundRobinFactory_t894079444  : public ContestManagerContentFactory_t825758832
{
public:
	// VP`1<GameManager.Match.SingleContestFactory> GameManager.Match.RoundRobin.RoundRobinFactory::singleContestFactory
	VP_1_t1476376654 * ___singleContestFactory_5;
	// VP`1<System.Int32> GameManager.Match.RoundRobin.RoundRobinFactory::teamCount
	VP_1_t2450154454 * ___teamCount_6;
	// VP`1<System.Boolean> GameManager.Match.RoundRobin.RoundRobinFactory::needReturnRound
	VP_1_t4203851724 * ___needReturnRound_7;

public:
	inline static int32_t get_offset_of_singleContestFactory_5() { return static_cast<int32_t>(offsetof(RoundRobinFactory_t894079444, ___singleContestFactory_5)); }
	inline VP_1_t1476376654 * get_singleContestFactory_5() const { return ___singleContestFactory_5; }
	inline VP_1_t1476376654 ** get_address_of_singleContestFactory_5() { return &___singleContestFactory_5; }
	inline void set_singleContestFactory_5(VP_1_t1476376654 * value)
	{
		___singleContestFactory_5 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactory_5, value);
	}

	inline static int32_t get_offset_of_teamCount_6() { return static_cast<int32_t>(offsetof(RoundRobinFactory_t894079444, ___teamCount_6)); }
	inline VP_1_t2450154454 * get_teamCount_6() const { return ___teamCount_6; }
	inline VP_1_t2450154454 ** get_address_of_teamCount_6() { return &___teamCount_6; }
	inline void set_teamCount_6(VP_1_t2450154454 * value)
	{
		___teamCount_6 = value;
		Il2CppCodeGenWriteBarrier(&___teamCount_6, value);
	}

	inline static int32_t get_offset_of_needReturnRound_7() { return static_cast<int32_t>(offsetof(RoundRobinFactory_t894079444, ___needReturnRound_7)); }
	inline VP_1_t4203851724 * get_needReturnRound_7() const { return ___needReturnRound_7; }
	inline VP_1_t4203851724 ** get_address_of_needReturnRound_7() { return &___needReturnRound_7; }
	inline void set_needReturnRound_7(VP_1_t4203851724 * value)
	{
		___needReturnRound_7 = value;
		Il2CppCodeGenWriteBarrier(&___needReturnRound_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
