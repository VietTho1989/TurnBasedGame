#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_AIUI_UIData_Sub3237004242.h"

// VP`1<EditData`1<RussianDraught.RussianDraughtAI>>
struct VP_1_t2228452232;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.RussianDraughtAIUI/UIData
struct  UIData_t2225938187  : public Sub_t3237004242
{
public:
	// VP`1<EditData`1<RussianDraught.RussianDraughtAI>> RussianDraught.RussianDraughtAIUI/UIData::editAI
	VP_1_t2228452232 * ___editAI_5;
	// VP`1<RequestChangeIntUI/UIData> RussianDraught.RussianDraughtAIUI/UIData::timeLimit
	VP_1_t1437137211 * ___timeLimit_6;
	// VP`1<RequestChangeIntUI/UIData> RussianDraught.RussianDraughtAIUI/UIData::pickBestMove
	VP_1_t1437137211 * ___pickBestMove_7;

public:
	inline static int32_t get_offset_of_editAI_5() { return static_cast<int32_t>(offsetof(UIData_t2225938187, ___editAI_5)); }
	inline VP_1_t2228452232 * get_editAI_5() const { return ___editAI_5; }
	inline VP_1_t2228452232 ** get_address_of_editAI_5() { return &___editAI_5; }
	inline void set_editAI_5(VP_1_t2228452232 * value)
	{
		___editAI_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAI_5, value);
	}

	inline static int32_t get_offset_of_timeLimit_6() { return static_cast<int32_t>(offsetof(UIData_t2225938187, ___timeLimit_6)); }
	inline VP_1_t1437137211 * get_timeLimit_6() const { return ___timeLimit_6; }
	inline VP_1_t1437137211 ** get_address_of_timeLimit_6() { return &___timeLimit_6; }
	inline void set_timeLimit_6(VP_1_t1437137211 * value)
	{
		___timeLimit_6 = value;
		Il2CppCodeGenWriteBarrier(&___timeLimit_6, value);
	}

	inline static int32_t get_offset_of_pickBestMove_7() { return static_cast<int32_t>(offsetof(UIData_t2225938187, ___pickBestMove_7)); }
	inline VP_1_t1437137211 * get_pickBestMove_7() const { return ___pickBestMove_7; }
	inline VP_1_t1437137211 ** get_address_of_pickBestMove_7() { return &___pickBestMove_7; }
	inline void set_pickBestMove_7(VP_1_t1437137211 * value)
	{
		___pickBestMove_7 = value;
		Il2CppCodeGenWriteBarrier(&___pickBestMove_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
