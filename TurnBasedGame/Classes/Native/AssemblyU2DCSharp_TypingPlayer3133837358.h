#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.UInt32>
struct VP_1_t2527959027;
// VP`1<TypingPlayer/State>
struct VP_1_t1366653430;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TypingPlayer
struct  TypingPlayer_t3133837358  : public Data_t3569509720
{
public:
	// VP`1<System.UInt32> TypingPlayer::playerId
	VP_1_t2527959027 * ___playerId_5;
	// VP`1<TypingPlayer/State> TypingPlayer::state
	VP_1_t1366653430 * ___state_6;

public:
	inline static int32_t get_offset_of_playerId_5() { return static_cast<int32_t>(offsetof(TypingPlayer_t3133837358, ___playerId_5)); }
	inline VP_1_t2527959027 * get_playerId_5() const { return ___playerId_5; }
	inline VP_1_t2527959027 ** get_address_of_playerId_5() { return &___playerId_5; }
	inline void set_playerId_5(VP_1_t2527959027 * value)
	{
		___playerId_5 = value;
		Il2CppCodeGenWriteBarrier(&___playerId_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(TypingPlayer_t3133837358, ___state_6)); }
	inline VP_1_t1366653430 * get_state_6() const { return ___state_6; }
	inline VP_1_t1366653430 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t1366653430 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
