#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2881042900.h"

// GameManager.Match.ContestManagerStatePlay
struct ContestManagerStatePlay_t4088911568;
// GameManager.Match.SingleContestFactoryCheckChange`1<GameManager.Match.SingleContestFactory>
struct SingleContestFactoryCheckChange_1_t3298522882;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobinContentMakeNewRoundUpdate
struct  RoundRobinContentMakeNewRoundUpdate_t468351246  : public UpdateBehavior_1_t2881042900
{
public:
	// GameManager.Match.ContestManagerStatePlay GameManager.Match.RoundRobin.RoundRobinContentMakeNewRoundUpdate::contestManagerStatePlay
	ContestManagerStatePlay_t4088911568 * ___contestManagerStatePlay_4;
	// GameManager.Match.SingleContestFactoryCheckChange`1<GameManager.Match.SingleContestFactory> GameManager.Match.RoundRobin.RoundRobinContentMakeNewRoundUpdate::singleContestFactoryCheckChange
	SingleContestFactoryCheckChange_1_t3298522882 * ___singleContestFactoryCheckChange_5;

public:
	inline static int32_t get_offset_of_contestManagerStatePlay_4() { return static_cast<int32_t>(offsetof(RoundRobinContentMakeNewRoundUpdate_t468351246, ___contestManagerStatePlay_4)); }
	inline ContestManagerStatePlay_t4088911568 * get_contestManagerStatePlay_4() const { return ___contestManagerStatePlay_4; }
	inline ContestManagerStatePlay_t4088911568 ** get_address_of_contestManagerStatePlay_4() { return &___contestManagerStatePlay_4; }
	inline void set_contestManagerStatePlay_4(ContestManagerStatePlay_t4088911568 * value)
	{
		___contestManagerStatePlay_4 = value;
		Il2CppCodeGenWriteBarrier(&___contestManagerStatePlay_4, value);
	}

	inline static int32_t get_offset_of_singleContestFactoryCheckChange_5() { return static_cast<int32_t>(offsetof(RoundRobinContentMakeNewRoundUpdate_t468351246, ___singleContestFactoryCheckChange_5)); }
	inline SingleContestFactoryCheckChange_1_t3298522882 * get_singleContestFactoryCheckChange_5() const { return ___singleContestFactoryCheckChange_5; }
	inline SingleContestFactoryCheckChange_1_t3298522882 ** get_address_of_singleContestFactoryCheckChange_5() { return &___singleContestFactoryCheckChange_5; }
	inline void set_singleContestFactoryCheckChange_5(SingleContestFactoryCheckChange_1_t3298522882 * value)
	{
		___singleContestFactoryCheckChange_5 = value;
		Il2CppCodeGenWriteBarrier(&___singleContestFactoryCheckChange_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
