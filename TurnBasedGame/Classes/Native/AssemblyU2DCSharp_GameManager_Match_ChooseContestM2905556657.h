#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1196055060.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManager>>
struct VP_1_t1139311102;
// VP`1<GameManager.Match.ChooseContestManagerHolder/UIData/StateUI>
struct VP_1_t94173435;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ChooseContestManagerHolder/UIData
struct  UIData_t2905556657  : public BaseItemViewsHolder_t1196055060
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManager>> GameManager.Match.ChooseContestManagerHolder/UIData::contestManager
	VP_1_t1139311102 * ___contestManager_8;
	// VP`1<GameManager.Match.ChooseContestManagerHolder/UIData/StateUI> GameManager.Match.ChooseContestManagerHolder/UIData::stateUI
	VP_1_t94173435 * ___stateUI_9;

public:
	inline static int32_t get_offset_of_contestManager_8() { return static_cast<int32_t>(offsetof(UIData_t2905556657, ___contestManager_8)); }
	inline VP_1_t1139311102 * get_contestManager_8() const { return ___contestManager_8; }
	inline VP_1_t1139311102 ** get_address_of_contestManager_8() { return &___contestManager_8; }
	inline void set_contestManager_8(VP_1_t1139311102 * value)
	{
		___contestManager_8 = value;
		Il2CppCodeGenWriteBarrier(&___contestManager_8, value);
	}

	inline static int32_t get_offset_of_stateUI_9() { return static_cast<int32_t>(offsetof(UIData_t2905556657, ___stateUI_9)); }
	inline VP_1_t94173435 * get_stateUI_9() const { return ___stateUI_9; }
	inline VP_1_t94173435 ** get_address_of_stateUI_9() { return &___stateUI_9; }
	inline void set_stateUI_9(VP_1_t94173435 * value)
	{
		___stateUI_9 = value;
		Il2CppCodeGenWriteBarrier(&___stateUI_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
