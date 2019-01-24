#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameManager_Match_ChooseRoundGam4120036206.h"

// VP`1<ReferenceData`1<GameState.Play>>
struct VP_1_t1886222719;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.RoundGameStatePlayUI/UIData
struct  UIData_t3666966214  : public StateUI_t4120036206
{
public:
	// VP`1<ReferenceData`1<GameState.Play>> GameManager.Match.RoundGameStatePlayUI/UIData::play
	VP_1_t1886222719 * ___play_5;

public:
	inline static int32_t get_offset_of_play_5() { return static_cast<int32_t>(offsetof(UIData_t3666966214, ___play_5)); }
	inline VP_1_t1886222719 * get_play_5() const { return ___play_5; }
	inline VP_1_t1886222719 ** get_address_of_play_5() { return &___play_5; }
	inline void set_play_5(VP_1_t1886222719 * value)
	{
		___play_5 = value;
		Il2CppCodeGenWriteBarrier(&___play_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
