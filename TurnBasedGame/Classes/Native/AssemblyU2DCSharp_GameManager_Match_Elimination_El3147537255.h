#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.Boolean>
struct VP_1_t4203851724;
// VP`1<GameManager.Match.Elimination.EliminationRound/State>
struct VP_1_t4046447338;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<GameManager.Match.Elimination.Bracket>
struct LP_1_t3460718618;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.EliminationRound
struct  EliminationRound_t3147537255  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> GameManager.Match.Elimination.EliminationRound::isActive
	VP_1_t4203851724 * ___isActive_5;
	// VP`1<GameManager.Match.Elimination.EliminationRound/State> GameManager.Match.Elimination.EliminationRound::state
	VP_1_t4046447338 * ___state_6;
	// VP`1<System.Int32> GameManager.Match.Elimination.EliminationRound::index
	VP_1_t2450154454 * ___index_7;
	// LP`1<GameManager.Match.Elimination.Bracket> GameManager.Match.Elimination.EliminationRound::brackets
	LP_1_t3460718618 * ___brackets_8;

public:
	inline static int32_t get_offset_of_isActive_5() { return static_cast<int32_t>(offsetof(EliminationRound_t3147537255, ___isActive_5)); }
	inline VP_1_t4203851724 * get_isActive_5() const { return ___isActive_5; }
	inline VP_1_t4203851724 ** get_address_of_isActive_5() { return &___isActive_5; }
	inline void set_isActive_5(VP_1_t4203851724 * value)
	{
		___isActive_5 = value;
		Il2CppCodeGenWriteBarrier(&___isActive_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(EliminationRound_t3147537255, ___state_6)); }
	inline VP_1_t4046447338 * get_state_6() const { return ___state_6; }
	inline VP_1_t4046447338 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t4046447338 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_index_7() { return static_cast<int32_t>(offsetof(EliminationRound_t3147537255, ___index_7)); }
	inline VP_1_t2450154454 * get_index_7() const { return ___index_7; }
	inline VP_1_t2450154454 ** get_address_of_index_7() { return &___index_7; }
	inline void set_index_7(VP_1_t2450154454 * value)
	{
		___index_7 = value;
		Il2CppCodeGenWriteBarrier(&___index_7, value);
	}

	inline static int32_t get_offset_of_brackets_8() { return static_cast<int32_t>(offsetof(EliminationRound_t3147537255, ___brackets_8)); }
	inline LP_1_t3460718618 * get_brackets_8() const { return ___brackets_8; }
	inline LP_1_t3460718618 ** get_address_of_brackets_8() { return &___brackets_8; }
	inline void set_brackets_8(LP_1_t3460718618 * value)
	{
		___brackets_8 = value;
		Il2CppCodeGenWriteBarrier(&___brackets_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
