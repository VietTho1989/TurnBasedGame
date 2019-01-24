#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_AIUI_UIData_Sub3237004242.h"

// VP`1<EditData`1<Gomoku.GomokuAI>>
struct VP_1_t2793438132;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuAIUI/UIData
struct  UIData_t1473698451  : public Sub_t3237004242
{
public:
	// VP`1<EditData`1<Gomoku.GomokuAI>> Gomoku.GomokuAIUI/UIData::editAI
	VP_1_t2793438132 * ___editAI_5;
	// VP`1<RequestChangeIntUI/UIData> Gomoku.GomokuAIUI/UIData::searchDepth
	VP_1_t1437137211 * ___searchDepth_6;
	// VP`1<RequestChangeIntUI/UIData> Gomoku.GomokuAIUI/UIData::timeLimit
	VP_1_t1437137211 * ___timeLimit_7;
	// VP`1<RequestChangeIntUI/UIData> Gomoku.GomokuAIUI/UIData::level
	VP_1_t1437137211 * ___level_8;

public:
	inline static int32_t get_offset_of_editAI_5() { return static_cast<int32_t>(offsetof(UIData_t1473698451, ___editAI_5)); }
	inline VP_1_t2793438132 * get_editAI_5() const { return ___editAI_5; }
	inline VP_1_t2793438132 ** get_address_of_editAI_5() { return &___editAI_5; }
	inline void set_editAI_5(VP_1_t2793438132 * value)
	{
		___editAI_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAI_5, value);
	}

	inline static int32_t get_offset_of_searchDepth_6() { return static_cast<int32_t>(offsetof(UIData_t1473698451, ___searchDepth_6)); }
	inline VP_1_t1437137211 * get_searchDepth_6() const { return ___searchDepth_6; }
	inline VP_1_t1437137211 ** get_address_of_searchDepth_6() { return &___searchDepth_6; }
	inline void set_searchDepth_6(VP_1_t1437137211 * value)
	{
		___searchDepth_6 = value;
		Il2CppCodeGenWriteBarrier(&___searchDepth_6, value);
	}

	inline static int32_t get_offset_of_timeLimit_7() { return static_cast<int32_t>(offsetof(UIData_t1473698451, ___timeLimit_7)); }
	inline VP_1_t1437137211 * get_timeLimit_7() const { return ___timeLimit_7; }
	inline VP_1_t1437137211 ** get_address_of_timeLimit_7() { return &___timeLimit_7; }
	inline void set_timeLimit_7(VP_1_t1437137211 * value)
	{
		___timeLimit_7 = value;
		Il2CppCodeGenWriteBarrier(&___timeLimit_7, value);
	}

	inline static int32_t get_offset_of_level_8() { return static_cast<int32_t>(offsetof(UIData_t1473698451, ___level_8)); }
	inline VP_1_t1437137211 * get_level_8() const { return ___level_8; }
	inline VP_1_t1437137211 ** get_address_of_level_8() { return &___level_8; }
	inline void set_level_8(VP_1_t1437137211 * value)
	{
		___level_8 = value;
		Il2CppCodeGenWriteBarrier(&___level_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
