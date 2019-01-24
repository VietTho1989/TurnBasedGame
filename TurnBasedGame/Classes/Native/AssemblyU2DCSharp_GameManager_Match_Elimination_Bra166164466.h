#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Elimination_Bra283141357.h"

// LP`1<System.Int32>
struct LP_1_t809621404;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.BracketStateEnd
struct  BracketStateEnd_t166164466  : public State_t283141357
{
public:
	// LP`1<System.Int32> GameManager.Match.Elimination.BracketStateEnd::winTeamIndexs
	LP_1_t809621404 * ___winTeamIndexs_5;
	// LP`1<System.Int32> GameManager.Match.Elimination.BracketStateEnd::loseTeamIndexs
	LP_1_t809621404 * ___loseTeamIndexs_6;

public:
	inline static int32_t get_offset_of_winTeamIndexs_5() { return static_cast<int32_t>(offsetof(BracketStateEnd_t166164466, ___winTeamIndexs_5)); }
	inline LP_1_t809621404 * get_winTeamIndexs_5() const { return ___winTeamIndexs_5; }
	inline LP_1_t809621404 ** get_address_of_winTeamIndexs_5() { return &___winTeamIndexs_5; }
	inline void set_winTeamIndexs_5(LP_1_t809621404 * value)
	{
		___winTeamIndexs_5 = value;
		Il2CppCodeGenWriteBarrier(&___winTeamIndexs_5, value);
	}

	inline static int32_t get_offset_of_loseTeamIndexs_6() { return static_cast<int32_t>(offsetof(BracketStateEnd_t166164466, ___loseTeamIndexs_6)); }
	inline LP_1_t809621404 * get_loseTeamIndexs_6() const { return ___loseTeamIndexs_6; }
	inline LP_1_t809621404 ** get_address_of_loseTeamIndexs_6() { return &___loseTeamIndexs_6; }
	inline void set_loseTeamIndexs_6(LP_1_t809621404 * value)
	{
		___loseTeamIndexs_6 = value;
		Il2CppCodeGenWriteBarrier(&___loseTeamIndexs_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
