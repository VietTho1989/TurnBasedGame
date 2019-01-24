#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_Elimination_Req863296875.h"

// VP`1<GameManager.Match.Elimination.RequestNewEliminationRoundAskBtnAcceptUI/UIData/State>
struct VP_1_t4178802857;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.RequestNewEliminationRoundAskBtnAcceptUI/UIData
struct  UIData_t732621179  : public Btn_t863296875
{
public:
	// VP`1<GameManager.Match.Elimination.RequestNewEliminationRoundAskBtnAcceptUI/UIData/State> GameManager.Match.Elimination.RequestNewEliminationRoundAskBtnAcceptUI/UIData::state
	VP_1_t4178802857 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UIData_t732621179, ___state_5)); }
	inline VP_1_t4178802857 * get_state_5() const { return ___state_5; }
	inline VP_1_t4178802857 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t4178802857 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
