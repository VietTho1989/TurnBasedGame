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
// VP`1<System.Int32>
struct VP_1_t2450154454;
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<GameManager.Match.Contest>
struct VP_1_t2804486552;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketContest
struct  BracketContest_t854378730  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> GameManager.Match.Elimination.BracketContest::isActive
	VP_1_t4203851724 * ___isActive_5;
	// VP`1<System.Int32> GameManager.Match.Elimination.BracketContest::index
	VP_1_t2450154454 * ___index_6;
	// LP`1<System.Int32> GameManager.Match.Elimination.BracketContest::teamIndexs
	LP_1_t809621404 * ___teamIndexs_7;
	// VP`1<GameManager.Match.Contest> GameManager.Match.Elimination.BracketContest::contest
	VP_1_t2804486552 * ___contest_8;

public:
	inline static int32_t get_offset_of_isActive_5() { return static_cast<int32_t>(offsetof(BracketContest_t854378730, ___isActive_5)); }
	inline VP_1_t4203851724 * get_isActive_5() const { return ___isActive_5; }
	inline VP_1_t4203851724 ** get_address_of_isActive_5() { return &___isActive_5; }
	inline void set_isActive_5(VP_1_t4203851724 * value)
	{
		___isActive_5 = value;
		Il2CppCodeGenWriteBarrier(&___isActive_5, value);
	}

	inline static int32_t get_offset_of_index_6() { return static_cast<int32_t>(offsetof(BracketContest_t854378730, ___index_6)); }
	inline VP_1_t2450154454 * get_index_6() const { return ___index_6; }
	inline VP_1_t2450154454 ** get_address_of_index_6() { return &___index_6; }
	inline void set_index_6(VP_1_t2450154454 * value)
	{
		___index_6 = value;
		Il2CppCodeGenWriteBarrier(&___index_6, value);
	}

	inline static int32_t get_offset_of_teamIndexs_7() { return static_cast<int32_t>(offsetof(BracketContest_t854378730, ___teamIndexs_7)); }
	inline LP_1_t809621404 * get_teamIndexs_7() const { return ___teamIndexs_7; }
	inline LP_1_t809621404 ** get_address_of_teamIndexs_7() { return &___teamIndexs_7; }
	inline void set_teamIndexs_7(LP_1_t809621404 * value)
	{
		___teamIndexs_7 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndexs_7, value);
	}

	inline static int32_t get_offset_of_contest_8() { return static_cast<int32_t>(offsetof(BracketContest_t854378730, ___contest_8)); }
	inline VP_1_t2804486552 * get_contest_8() const { return ___contest_8; }
	inline VP_1_t2804486552 ** get_address_of_contest_8() { return &___contest_8; }
	inline void set_contest_8(VP_1_t2804486552 * value)
	{
		___contest_8 = value;
		Il2CppCodeGenWriteBarrier(&___contest_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
