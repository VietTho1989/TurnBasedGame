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
// VP`1<GameManager.Match.Elimination.Bracket/State>
struct VP_1_t661418363;
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<GameManager.Match.Elimination.BracketContest>
struct LP_1_t3887089982;
// LP`1<System.Int32>
struct LP_1_t809621404;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.Bracket
struct  Bracket_t428007366  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> GameManager.Match.Elimination.Bracket::isActive
	VP_1_t4203851724 * ___isActive_5;
	// VP`1<GameManager.Match.Elimination.Bracket/State> GameManager.Match.Elimination.Bracket::state
	VP_1_t661418363 * ___state_6;
	// VP`1<System.Int32> GameManager.Match.Elimination.Bracket::index
	VP_1_t2450154454 * ___index_7;
	// LP`1<GameManager.Match.Elimination.BracketContest> GameManager.Match.Elimination.Bracket::bracketContests
	LP_1_t3887089982 * ___bracketContests_8;
	// LP`1<System.Int32> GameManager.Match.Elimination.Bracket::byeTeamIndexs
	LP_1_t809621404 * ___byeTeamIndexs_9;

public:
	inline static int32_t get_offset_of_isActive_5() { return static_cast<int32_t>(offsetof(Bracket_t428007366, ___isActive_5)); }
	inline VP_1_t4203851724 * get_isActive_5() const { return ___isActive_5; }
	inline VP_1_t4203851724 ** get_address_of_isActive_5() { return &___isActive_5; }
	inline void set_isActive_5(VP_1_t4203851724 * value)
	{
		___isActive_5 = value;
		Il2CppCodeGenWriteBarrier(&___isActive_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(Bracket_t428007366, ___state_6)); }
	inline VP_1_t661418363 * get_state_6() const { return ___state_6; }
	inline VP_1_t661418363 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t661418363 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}

	inline static int32_t get_offset_of_index_7() { return static_cast<int32_t>(offsetof(Bracket_t428007366, ___index_7)); }
	inline VP_1_t2450154454 * get_index_7() const { return ___index_7; }
	inline VP_1_t2450154454 ** get_address_of_index_7() { return &___index_7; }
	inline void set_index_7(VP_1_t2450154454 * value)
	{
		___index_7 = value;
		Il2CppCodeGenWriteBarrier(&___index_7, value);
	}

	inline static int32_t get_offset_of_bracketContests_8() { return static_cast<int32_t>(offsetof(Bracket_t428007366, ___bracketContests_8)); }
	inline LP_1_t3887089982 * get_bracketContests_8() const { return ___bracketContests_8; }
	inline LP_1_t3887089982 ** get_address_of_bracketContests_8() { return &___bracketContests_8; }
	inline void set_bracketContests_8(LP_1_t3887089982 * value)
	{
		___bracketContests_8 = value;
		Il2CppCodeGenWriteBarrier(&___bracketContests_8, value);
	}

	inline static int32_t get_offset_of_byeTeamIndexs_9() { return static_cast<int32_t>(offsetof(Bracket_t428007366, ___byeTeamIndexs_9)); }
	inline LP_1_t809621404 * get_byeTeamIndexs_9() const { return ___byeTeamIndexs_9; }
	inline LP_1_t809621404 ** get_address_of_byeTeamIndexs_9() { return &___byeTeamIndexs_9; }
	inline void set_byeTeamIndexs_9(LP_1_t809621404 * value)
	{
		___byeTeamIndexs_9 = value;
		Il2CppCodeGenWriteBarrier(&___byeTeamIndexs_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
