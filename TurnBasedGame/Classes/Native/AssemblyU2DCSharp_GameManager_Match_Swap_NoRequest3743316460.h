#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Swap_SwapPlayer626118672.h"

// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>>
struct VP_1_t3658899499;
// VP`1<GameManager.Match.Swap.NoRequestSwapPlayerUI/UIData/Sub>
struct VP_1_t1853396043;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Swap.NoRequestSwapPlayerUI/UIData
struct  UIData_t3743316460  : public Sub_t626118672
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.TeamPlayer>> GameManager.Match.Swap.NoRequestSwapPlayerUI/UIData::teamPlayer
	VP_1_t3658899499 * ___teamPlayer_5;
	// VP`1<GameManager.Match.Swap.NoRequestSwapPlayerUI/UIData/Sub> GameManager.Match.Swap.NoRequestSwapPlayerUI/UIData::sub
	VP_1_t1853396043 * ___sub_6;

public:
	inline static int32_t get_offset_of_teamPlayer_5() { return static_cast<int32_t>(offsetof(UIData_t3743316460, ___teamPlayer_5)); }
	inline VP_1_t3658899499 * get_teamPlayer_5() const { return ___teamPlayer_5; }
	inline VP_1_t3658899499 ** get_address_of_teamPlayer_5() { return &___teamPlayer_5; }
	inline void set_teamPlayer_5(VP_1_t3658899499 * value)
	{
		___teamPlayer_5 = value;
		Il2CppCodeGenWriteBarrier(&___teamPlayer_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t3743316460, ___sub_6)); }
	inline VP_1_t1853396043 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t1853396043 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t1853396043 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
