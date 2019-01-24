#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.RoundGame>>
struct VP_1_t2479123941;
// LP`1<GameManager.Match.RoundGamePlayerUI/UIData>
struct LP_1_t3971663028;
// VP`1<GameManager.Match.ChooseRoundGameHolder/UIData/StateUI>
struct VP_1_t203345916;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseRoundGameHolder/UIData
struct  UIData_t147812958  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.RoundGame>> GameManager.Match.ChooseRoundGameHolder/UIData::roundGame
	VP_1_t2479123941 * ___roundGame_8;
	// LP`1<GameManager.Match.RoundGamePlayerUI/UIData> GameManager.Match.ChooseRoundGameHolder/UIData::roundGamePlayers
	LP_1_t3971663028 * ___roundGamePlayers_9;
	// VP`1<GameManager.Match.ChooseRoundGameHolder/UIData/StateUI> GameManager.Match.ChooseRoundGameHolder/UIData::stateUI
	VP_1_t203345916 * ___stateUI_10;

public:
	inline static int32_t get_offset_of_roundGame_8() { return static_cast<int32_t>(offsetof(UIData_t147812958, ___roundGame_8)); }
	inline VP_1_t2479123941 * get_roundGame_8() const { return ___roundGame_8; }
	inline VP_1_t2479123941 ** get_address_of_roundGame_8() { return &___roundGame_8; }
	inline void set_roundGame_8(VP_1_t2479123941 * value)
	{
		___roundGame_8 = value;
		Il2CppCodeGenWriteBarrier(&___roundGame_8, value);
	}

	inline static int32_t get_offset_of_roundGamePlayers_9() { return static_cast<int32_t>(offsetof(UIData_t147812958, ___roundGamePlayers_9)); }
	inline LP_1_t3971663028 * get_roundGamePlayers_9() const { return ___roundGamePlayers_9; }
	inline LP_1_t3971663028 ** get_address_of_roundGamePlayers_9() { return &___roundGamePlayers_9; }
	inline void set_roundGamePlayers_9(LP_1_t3971663028 * value)
	{
		___roundGamePlayers_9 = value;
		Il2CppCodeGenWriteBarrier(&___roundGamePlayers_9, value);
	}

	inline static int32_t get_offset_of_stateUI_10() { return static_cast<int32_t>(offsetof(UIData_t147812958, ___stateUI_10)); }
	inline VP_1_t203345916 * get_stateUI_10() const { return ___stateUI_10; }
	inline VP_1_t203345916 ** get_address_of_stateUI_10() { return &___stateUI_10; }
	inline void set_stateUI_10(VP_1_t203345916 * value)
	{
		___stateUI_10 = value;
		Il2CppCodeGenWriteBarrier(&___stateUI_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
