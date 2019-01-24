#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.RoundRobin.RoundRobin/State>
struct VP_1_t4204236162;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<GameManager.Match.RoundContest>
struct LP_1_t943222734;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundRobin.RoundRobin
struct  RoundRobin_t3891021718  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.RoundRobin.RoundRobin/State> GameManager.Match.RoundRobin.RoundRobin::state
	VP_1_t4204236162 * ___state_5;
	// VP`1<System.Int32> GameManager.Match.RoundRobin.RoundRobin::index
	VP_1_t2450154454 * ___index_6;
	// LP`1<GameManager.Match.RoundContest> GameManager.Match.RoundRobin.RoundRobin::roundContests
	LP_1_t943222734 * ___roundContests_7;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(RoundRobin_t3891021718, ___state_5)); }
	inline VP_1_t4204236162 * get_state_5() const { return ___state_5; }
	inline VP_1_t4204236162 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t4204236162 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_index_6() { return static_cast<int32_t>(offsetof(RoundRobin_t3891021718, ___index_6)); }
	inline VP_1_t2450154454 * get_index_6() const { return ___index_6; }
	inline VP_1_t2450154454 ** get_address_of_index_6() { return &___index_6; }
	inline void set_index_6(VP_1_t2450154454 * value)
	{
		___index_6 = value;
		Il2CppCodeGenWriteBarrier(&___index_6, value);
	}

	inline static int32_t get_offset_of_roundContests_7() { return static_cast<int32_t>(offsetof(RoundRobin_t3891021718, ___roundContests_7)); }
	inline LP_1_t943222734 * get_roundContests_7() const { return ___roundContests_7; }
	inline LP_1_t943222734 ** get_address_of_roundContests_7() { return &___roundContests_7; }
	inline void set_roundContests_7(LP_1_t943222734 * value)
	{
		___roundContests_7 = value;
		Il2CppCodeGenWriteBarrier(&___roundContests_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
