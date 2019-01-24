#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManagerC825758832.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<GameManager.Match.RoundFactory>
struct VP_1_t2213350254;
// VP`1<GameManager.Match.RequestNewRound/Limit>
struct VP_1_t1173900283;
// VP`1<CalculateScore>
struct VP_1_t3414263936;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.SingleContestFactory
struct  SingleContestFactory_t1098099648  : public ContestManagerContentFactory_t825758832
{
public:
	// VP`1<System.Int32> GameManager.Match.SingleContestFactory::playerPerTeam
	VP_1_t2450154454 * ___playerPerTeam_5;
	// VP`1<GameManager.Match.RoundFactory> GameManager.Match.SingleContestFactory::roundFactory
	VP_1_t2213350254 * ___roundFactory_6;
	// VP`1<GameManager.Match.RequestNewRound/Limit> GameManager.Match.SingleContestFactory::newRoundLimit
	VP_1_t1173900283 * ___newRoundLimit_7;
	// VP`1<CalculateScore> GameManager.Match.SingleContestFactory::calculateScore
	VP_1_t3414263936 * ___calculateScore_8;

public:
	inline static int32_t get_offset_of_playerPerTeam_5() { return static_cast<int32_t>(offsetof(SingleContestFactory_t1098099648, ___playerPerTeam_5)); }
	inline VP_1_t2450154454 * get_playerPerTeam_5() const { return ___playerPerTeam_5; }
	inline VP_1_t2450154454 ** get_address_of_playerPerTeam_5() { return &___playerPerTeam_5; }
	inline void set_playerPerTeam_5(VP_1_t2450154454 * value)
	{
		___playerPerTeam_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerPerTeam_5, value);
	}

	inline static int32_t get_offset_of_roundFactory_6() { return static_cast<int32_t>(offsetof(SingleContestFactory_t1098099648, ___roundFactory_6)); }
	inline VP_1_t2213350254 * get_roundFactory_6() const { return ___roundFactory_6; }
	inline VP_1_t2213350254 ** get_address_of_roundFactory_6() { return &___roundFactory_6; }
	inline void set_roundFactory_6(VP_1_t2213350254 * value)
	{
		___roundFactory_6 = value;
		Il2CppCodeGenWriteBarrier(&___roundFactory_6, value);
	}

	inline static int32_t get_offset_of_newRoundLimit_7() { return static_cast<int32_t>(offsetof(SingleContestFactory_t1098099648, ___newRoundLimit_7)); }
	inline VP_1_t1173900283 * get_newRoundLimit_7() const { return ___newRoundLimit_7; }
	inline VP_1_t1173900283 ** get_address_of_newRoundLimit_7() { return &___newRoundLimit_7; }
	inline void set_newRoundLimit_7(VP_1_t1173900283 * value)
	{
		___newRoundLimit_7 = value;
		Il2CppCodeGenWriteBarrier(&___newRoundLimit_7, value);
	}

	inline static int32_t get_offset_of_calculateScore_8() { return static_cast<int32_t>(offsetof(SingleContestFactory_t1098099648, ___calculateScore_8)); }
	inline VP_1_t3414263936 * get_calculateScore_8() const { return ___calculateScore_8; }
	inline VP_1_t3414263936 ** get_address_of_calculateScore_8() { return &___calculateScore_8; }
	inline void set_calculateScore_8(VP_1_t3414263936 * value)
	{
		___calculateScore_8 = value;
		Il2CppCodeGenWriteBarrier(&___calculateScore_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
