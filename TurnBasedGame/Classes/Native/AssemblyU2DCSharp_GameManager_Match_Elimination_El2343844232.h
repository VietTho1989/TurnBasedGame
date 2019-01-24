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
// LP`1<System.UInt32>
struct LP_1_t887425977;
// VP`1<GameManager.Match.Elimination.RequestNewEliminationRound>
struct VP_1_t1325739080;
// LP`1<GameManager.Match.Elimination.EliminationRound>
struct LP_1_t1885281211;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationContent
struct  EliminationContent_t2343844232  : public ContestManagerContent_t3360960190
{
public:
	// VP`1<GameManager.Match.SingleContestFactory> GameManager.Match.Elimination.EliminationContent::singleContestFactory
	VP_1_t1476376654 * ___singleContestFactory_5;
	// LP`1<System.UInt32> GameManager.Match.Elimination.EliminationContent::initTeamCounts
	LP_1_t887425977 * ___initTeamCounts_8;
	// VP`1<GameManager.Match.Elimination.RequestNewEliminationRound> GameManager.Match.Elimination.EliminationContent::requestNewRound
	VP_1_t1325739080 * ___requestNewRound_9;
	// LP`1<GameManager.Match.Elimination.EliminationRound> GameManager.Match.Elimination.EliminationContent::rounds
	LP_1_t1885281211 * ___rounds_10;

public:
	inline static int32_t get_offset_of_singleContestFactory_5() { return static_cast<int32_t>(offsetof(EliminationContent_t2343844232, ___singleContestFactory_5)); }
	inline VP_1_t1476376654 * get_singleContestFactory_5() const { return ___singleContestFactory_5; }
	inline VP_1_t1476376654 ** get_address_of_singleContestFactory_5() { return &___singleContestFactory_5; }
	inline void set_singleContestFactory_5(VP_1_t1476376654 * value)
	{
		___singleContestFactory_5 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactory_5, value);
	}

	inline static int32_t get_offset_of_initTeamCounts_8() { return static_cast<int32_t>(offsetof(EliminationContent_t2343844232, ___initTeamCounts_8)); }
	inline LP_1_t887425977 * get_initTeamCounts_8() const { return ___initTeamCounts_8; }
	inline LP_1_t887425977 ** get_address_of_initTeamCounts_8() { return &___initTeamCounts_8; }
	inline void set_initTeamCounts_8(LP_1_t887425977 * value)
	{
		___initTeamCounts_8 = value;
		Il2CppCodeGenWriteBarrier(&___initTeamCounts_8, value);
	}

	inline static int32_t get_offset_of_requestNewRound_9() { return static_cast<int32_t>(offsetof(EliminationContent_t2343844232, ___requestNewRound_9)); }
	inline VP_1_t1325739080 * get_requestNewRound_9() const { return ___requestNewRound_9; }
	inline VP_1_t1325739080 ** get_address_of_requestNewRound_9() { return &___requestNewRound_9; }
	inline void set_requestNewRound_9(VP_1_t1325739080 * value)
	{
		___requestNewRound_9 = value;
		Il2CppCodeGenWriteBarrier(&___requestNewRound_9, value);
	}

	inline static int32_t get_offset_of_rounds_10() { return static_cast<int32_t>(offsetof(EliminationContent_t2343844232, ___rounds_10)); }
	inline LP_1_t1885281211 * get_rounds_10() const { return ___rounds_10; }
	inline LP_1_t1885281211 ** get_address_of_rounds_10() { return &___rounds_10; }
	inline void set_rounds_10(LP_1_t1885281211 * value)
	{
		___rounds_10 = value;
		Il2CppCodeGenWriteBarrier(&___rounds_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
