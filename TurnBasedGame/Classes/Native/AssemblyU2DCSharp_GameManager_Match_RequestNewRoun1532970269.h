#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.RequestNewRound/State>
struct VP_1_t2477604317;
// VP`1<GameManager.Match.RequestNewRound/Limit>
struct VP_1_t1173900283;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RequestNewRound
struct  RequestNewRound_t1532970269  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.RequestNewRound/State> GameManager.Match.RequestNewRound::state
	VP_1_t2477604317 * ___state_5;
	// VP`1<GameManager.Match.RequestNewRound/Limit> GameManager.Match.RequestNewRound::limit
	VP_1_t1173900283 * ___limit_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(RequestNewRound_t1532970269, ___state_5)); }
	inline VP_1_t2477604317 * get_state_5() const { return ___state_5; }
	inline VP_1_t2477604317 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t2477604317 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_limit_6() { return static_cast<int32_t>(offsetof(RequestNewRound_t1532970269, ___limit_6)); }
	inline VP_1_t1173900283 * get_limit_6() const { return ___limit_6; }
	inline VP_1_t1173900283 ** get_address_of_limit_6() { return &___limit_6; }
	inline void set_limit_6(VP_1_t1173900283 * value)
	{
		___limit_6 = value;
		Il2CppCodeGenWriteBarrier(&___limit_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
