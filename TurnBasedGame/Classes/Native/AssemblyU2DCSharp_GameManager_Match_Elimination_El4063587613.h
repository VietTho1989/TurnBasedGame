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
// LP`1<System.UInt32>
struct LP_1_t887425977;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationFactory
struct  EliminationFactory_t4063587613  : public ContestManagerContentFactory_t825758832
{
public:
	// VP`1<GameManager.Match.SingleContestFactory> GameManager.Match.Elimination.EliminationFactory::singleContestFactory
	VP_1_t1476376654 * ___singleContestFactory_5;
	// LP`1<System.UInt32> GameManager.Match.Elimination.EliminationFactory::initTeamCounts
	LP_1_t887425977 * ___initTeamCounts_6;

public:
	inline static int32_t get_offset_of_singleContestFactory_5() { return static_cast<int32_t>(offsetof(EliminationFactory_t4063587613, ___singleContestFactory_5)); }
	inline VP_1_t1476376654 * get_singleContestFactory_5() const { return ___singleContestFactory_5; }
	inline VP_1_t1476376654 ** get_address_of_singleContestFactory_5() { return &___singleContestFactory_5; }
	inline void set_singleContestFactory_5(VP_1_t1476376654 * value)
	{
		___singleContestFactory_5 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactory_5, value);
	}

	inline static int32_t get_offset_of_initTeamCounts_6() { return static_cast<int32_t>(offsetof(EliminationFactory_t4063587613, ___initTeamCounts_6)); }
	inline LP_1_t887425977 * get_initTeamCounts_6() const { return ___initTeamCounts_6; }
	inline LP_1_t887425977 ** get_address_of_initTeamCounts_6() { return &___initTeamCounts_6; }
	inline void set_initTeamCounts_6(LP_1_t887425977 * value)
	{
		___initTeamCounts_6 = value;
		Il2CppCodeGenWriteBarrier(&___initTeamCounts_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
