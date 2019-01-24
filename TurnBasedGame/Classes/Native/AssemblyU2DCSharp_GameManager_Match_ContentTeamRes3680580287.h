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
// LP`1<GameManager.Match.TeamResult>
struct LP_1_t2167682310;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContentTeamResult
struct  ContentTeamResult_t3680580287  : public Data_t3569509720
{
public:
	// VP`1<System.Boolean> GameManager.Match.ContentTeamResult::isEnd
	VP_1_t4203851724 * ___isEnd_5;
	// LP`1<GameManager.Match.TeamResult> GameManager.Match.ContentTeamResult::teamResults
	LP_1_t2167682310 * ___teamResults_6;

public:
	inline static int32_t get_offset_of_isEnd_5() { return static_cast<int32_t>(offsetof(ContentTeamResult_t3680580287, ___isEnd_5)); }
	inline VP_1_t4203851724 * get_isEnd_5() const { return ___isEnd_5; }
	inline VP_1_t4203851724 ** get_address_of_isEnd_5() { return &___isEnd_5; }
	inline void set_isEnd_5(VP_1_t4203851724 * value)
	{
		___isEnd_5 = value;
		Il2CppCodeGenWriteBarrier(&___isEnd_5, value);
	}

	inline static int32_t get_offset_of_teamResults_6() { return static_cast<int32_t>(offsetof(ContentTeamResult_t3680580287, ___teamResults_6)); }
	inline LP_1_t2167682310 * get_teamResults_6() const { return ___teamResults_6; }
	inline LP_1_t2167682310 ** get_address_of_teamResults_6() { return &___teamResults_6; }
	inline void set_teamResults_6(LP_1_t2167682310 * value)
	{
		___teamResults_6 = value;
		Il2CppCodeGenWriteBarrier(&___teamResults_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
