#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GameState_StateUI_UIData_Sub1882983268.h"

// VP`1<ReferenceData`1<GameState.Play>>
struct VP_1_t1886222719;
// VP`1<GameState.PlayUI/UIData/Sub>
struct VP_1_t425284095;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameState.PlayUI/UIData
struct  UIData_t2501541778  : public Sub_t1882983268
{
public:
	// VP`1<ReferenceData`1<GameState.Play>> GameState.PlayUI/UIData::play
	VP_1_t1886222719 * ___play_5;
	// VP`1<GameState.PlayUI/UIData/Sub> GameState.PlayUI/UIData::sub
	VP_1_t425284095 * ___sub_6;

public:
	inline static int32_t get_offset_of_play_5() { return static_cast<int32_t>(offsetof(UIData_t2501541778, ___play_5)); }
	inline VP_1_t1886222719 * get_play_5() const { return ___play_5; }
	inline VP_1_t1886222719 ** get_address_of_play_5() { return &___play_5; }
	inline void set_play_5(VP_1_t1886222719 * value)
	{
		___play_5 = value;
		Il2CppCodeGenWriteBarrier(&___play_5, value);
	}

	inline static int32_t get_offset_of_sub_6() { return static_cast<int32_t>(offsetof(UIData_t2501541778, ___sub_6)); }
	inline VP_1_t425284095 * get_sub_6() const { return ___sub_6; }
	inline VP_1_t425284095 ** get_address_of_sub_6() { return &___sub_6; }
	inline void set_sub_6(VP_1_t425284095 * value)
	{
		___sub_6 = value;
		Il2CppCodeGenWriteBarrier(&___sub_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
