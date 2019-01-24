#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;
// VP`1<System.Single>
struct VP_1_t2454786938;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.TeamResult
struct  TeamResult_t3429938354  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.TeamResult::teamIndex
	VP_1_t2450154454 * ___teamIndex_5;
	// VP`1<System.Single> GameManager.Match.TeamResult::score
	VP_1_t2454786938 * ___score_6;

public:
	inline static int32_t get_offset_of_teamIndex_5() { return static_cast<int32_t>(offsetof(TeamResult_t3429938354, ___teamIndex_5)); }
	inline VP_1_t2450154454 * get_teamIndex_5() const { return ___teamIndex_5; }
	inline VP_1_t2450154454 ** get_address_of_teamIndex_5() { return &___teamIndex_5; }
	inline void set_teamIndex_5(VP_1_t2450154454 * value)
	{
		___teamIndex_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndex_5, value);
	}

	inline static int32_t get_offset_of_score_6() { return static_cast<int32_t>(offsetof(TeamResult_t3429938354, ___score_6)); }
	inline VP_1_t2454786938 * get_score_6() const { return ___score_6; }
	inline VP_1_t2454786938 ** get_address_of_score_6() { return &___score_6; }
	inline void set_score_6(VP_1_t2454786938 * value)
	{
		___score_6 = value;
		Il2CppCodeGenWriteBarrier(&___score_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
