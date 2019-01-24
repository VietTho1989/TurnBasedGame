#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<GameManager.Match.LobbyBtnStart/UIData/State>
struct VP_1_t3464400143;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.LobbyBtnStart/UIData
struct  UIData_t2584802133  : public Data_t3569509720
{
public:
	// VP`1<GameManager.Match.LobbyBtnStart/UIData/State> GameManager.Match.LobbyBtnStart/UIData::state
	VP_1_t3464400143 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UIData_t2584802133, ___state_5)); }
	inline VP_1_t3464400143 * get_state_5() const { return ___state_5; }
	inline VP_1_t3464400143 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3464400143 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
