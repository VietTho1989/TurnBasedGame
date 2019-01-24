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
// LP`1<System.Int32>
struct LP_1_t809621404;
// VP`1<GameManager.Match.Contest>
struct VP_1_t2804486552;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundContest
struct  RoundContest_t2205478778  : public Data_t3569509720
{
public:
	// VP`1<System.Int32> GameManager.Match.RoundContest::index
	VP_1_t2450154454 * ___index_5;
	// LP`1<System.Int32> GameManager.Match.RoundContest::teamIndexs
	LP_1_t809621404 * ___teamIndexs_6;
	// VP`1<GameManager.Match.Contest> GameManager.Match.RoundContest::contest
	VP_1_t2804486552 * ___contest_7;

public:
	inline static int32_t get_offset_of_index_5() { return static_cast<int32_t>(offsetof(RoundContest_t2205478778, ___index_5)); }
	inline VP_1_t2450154454 * get_index_5() const { return ___index_5; }
	inline VP_1_t2450154454 ** get_address_of_index_5() { return &___index_5; }
	inline void set_index_5(VP_1_t2450154454 * value)
	{
		___index_5 = value;
		Il2CppCodeGenWriteBarrier(&___index_5, value);
	}

	inline static int32_t get_offset_of_teamIndexs_6() { return static_cast<int32_t>(offsetof(RoundContest_t2205478778, ___teamIndexs_6)); }
	inline LP_1_t809621404 * get_teamIndexs_6() const { return ___teamIndexs_6; }
	inline LP_1_t809621404 ** get_address_of_teamIndexs_6() { return &___teamIndexs_6; }
	inline void set_teamIndexs_6(LP_1_t809621404 * value)
	{
		___teamIndexs_6 = value;
		Il2CppCodeGenWriteBarrier(&___teamIndexs_6, value);
	}

	inline static int32_t get_offset_of_contest_7() { return static_cast<int32_t>(offsetof(RoundContest_t2205478778, ___contest_7)); }
	inline VP_1_t2804486552 * get_contest_7() const { return ___contest_7; }
	inline VP_1_t2804486552 ** get_address_of_contest_7() { return &___contest_7; }
	inline void set_contest_7(VP_1_t2804486552 * value)
	{
		___contest_7 = value;
		Il2CppCodeGenWriteBarrier(&___contest_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
