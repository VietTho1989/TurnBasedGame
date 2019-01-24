#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_AIUI_UIData_Sub3237004242.h"

// VP`1<EditData`1<MineSweeper.MineSweeperAI>>
struct VP_1_t187825832;
// VP`1<RequestChangeEnumUI/UIData>
struct VP_1_t3850875635;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// MineSweeper.MineSweeperAIUI/UIData
struct  UIData_t2467025031  : public Sub_t3237004242
{
public:
	// VP`1<EditData`1<MineSweeper.MineSweeperAI>> MineSweeper.MineSweeperAIUI/UIData::editAI
	VP_1_t187825832 * ___editAI_5;
	// VP`1<RequestChangeEnumUI/UIData> MineSweeper.MineSweeperAIUI/UIData::firstMoveType
	VP_1_t3850875635 * ___firstMoveType_6;

public:
	inline static int32_t get_offset_of_editAI_5() { return static_cast<int32_t>(offsetof(UIData_t2467025031, ___editAI_5)); }
	inline VP_1_t187825832 * get_editAI_5() const { return ___editAI_5; }
	inline VP_1_t187825832 ** get_address_of_editAI_5() { return &___editAI_5; }
	inline void set_editAI_5(VP_1_t187825832 * value)
	{
		___editAI_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAI_5, value);
	}

	inline static int32_t get_offset_of_firstMoveType_6() { return static_cast<int32_t>(offsetof(UIData_t2467025031, ___firstMoveType_6)); }
	inline VP_1_t3850875635 * get_firstMoveType_6() const { return ___firstMoveType_6; }
	inline VP_1_t3850875635 ** get_address_of_firstMoveType_6() { return &___firstMoveType_6; }
	inline void set_firstMoveType_6(VP_1_t3850875635 * value)
	{
		___firstMoveType_6 = value;
		Il2CppCodeGenWriteBarrier(&___firstMoveType_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
