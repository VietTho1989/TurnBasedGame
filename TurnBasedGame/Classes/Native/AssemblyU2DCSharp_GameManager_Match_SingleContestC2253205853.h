#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ContestManager3360960190.h"

// VP`1<GameManager.Match.Contest>
struct VP_1_t2804486552;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.SingleContestContent
struct  SingleContestContent_t2253205853  : public ContestManagerContent_t3360960190
{
public:
	// VP`1<GameManager.Match.Contest> GameManager.Match.SingleContestContent::contest
	VP_1_t2804486552 * ___contest_5;

public:
	inline static int32_t get_offset_of_contest_5() { return static_cast<int32_t>(offsetof(SingleContestContent_t2253205853, ___contest_5)); }
	inline VP_1_t2804486552 * get_contest_5() const { return ___contest_5; }
	inline VP_1_t2804486552 ** get_address_of_contest_5() { return &___contest_5; }
	inline void set_contest_5(VP_1_t2804486552 * value)
	{
		___contest_5 = value;
		Il2CppCodeGenWriteBarrier(&___contest_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
