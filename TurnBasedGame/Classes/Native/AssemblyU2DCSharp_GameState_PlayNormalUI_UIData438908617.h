#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_PlayUI_UIData_Sub47007089.h"

// VP`1<ReferenceData`1<GameState.PlayNormal>>
struct VP_1_t1002141388;
// VP`1<GameState.PlayNormalUI/UIData/State>
struct VP_1_t245754203;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayNormalUI/UIData
struct  UIData_t438908617  : public Sub_t47007089
{
public:
	// VP`1<ReferenceData`1<GameState.PlayNormal>> GameState.PlayNormalUI/UIData::playNormal
	VP_1_t1002141388 * ___playNormal_5;
	// VP`1<GameState.PlayNormalUI/UIData/State> GameState.PlayNormalUI/UIData::state
	VP_1_t245754203 * ___state_6;

public:
	inline static int32_t get_offset_of_playNormal_5() { return static_cast<int32_t>(offsetof(UIData_t438908617, ___playNormal_5)); }
	inline VP_1_t1002141388 * get_playNormal_5() const { return ___playNormal_5; }
	inline VP_1_t1002141388 ** get_address_of_playNormal_5() { return &___playNormal_5; }
	inline void set_playNormal_5(VP_1_t1002141388 * value)
	{
		___playNormal_5 = value;
		Il2CppCodeGenWriteBarrier(&___playNormal_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t438908617, ___state_6)); }
	inline VP_1_t245754203 * get_state_6() const { return ___state_6; }
	inline VP_1_t245754203 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t245754203 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
