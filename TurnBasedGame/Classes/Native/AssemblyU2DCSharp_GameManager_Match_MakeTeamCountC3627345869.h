#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2941835239.h"

// GameManager.Match.CheckContestTeamChange`1<GameManager.Match.Contest>
struct CheckContestTeamChange_1_t3760336211;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.MakeTeamCountCorrectUpdate
struct  MakeTeamCountCorrectUpdate_t3627345869  : public UpdateBehavior_1_t2941835239
{
public:
	// GameManager.Match.CheckContestTeamChange`1<GameManager.Match.Contest> GameManager.Match.MakeTeamCountCorrectUpdate::checkContestTeamChange
	CheckContestTeamChange_1_t3760336211 * ___checkContestTeamChange_4;

public:
	inline static int32_t get_offset_of_checkContestTeamChange_4() { return static_cast<int32_t>(offsetof(MakeTeamCountCorrectUpdate_t3627345869, ___checkContestTeamChange_4)); }
	inline CheckContestTeamChange_1_t3760336211 * get_checkContestTeamChange_4() const { return ___checkContestTeamChange_4; }
	inline CheckContestTeamChange_1_t3760336211 ** get_address_of_checkContestTeamChange_4() { return &___checkContestTeamChange_4; }
	inline void set_checkContestTeamChange_4(CheckContestTeamChange_1_t3760336211 * value)
	{
		___checkContestTeamChange_4 = value;
		Il2CppCodeGenWriteBarrier(&___checkContestTeamChange_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
