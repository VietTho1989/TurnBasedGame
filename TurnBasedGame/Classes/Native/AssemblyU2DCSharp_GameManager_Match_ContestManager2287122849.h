#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<GameManager.Match.ContestManager>>
struct VP_1_t1139311102;
// VP`1<GameManager.Match.ContestManagerInformUI/UIData/StateUI>
struct VP_1_t3493460771;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.ContestManagerInformUI/UIData
struct  UIData_t2287122849  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<GameManager.Match.ContestManager>> GameManager.Match.ContestManagerInformUI/UIData::contestManager
	VP_1_t1139311102 * ___contestManager_5;
	// VP`1<GameManager.Match.ContestManagerInformUI/UIData/StateUI> GameManager.Match.ContestManagerInformUI/UIData::stateUI
	VP_1_t3493460771 * ___stateUI_6;

public:
	inline static int32_t get_offset_of_contestManager_5() { return static_cast<int32_t>(offsetof(UIData_t2287122849, ___contestManager_5)); }
	inline VP_1_t1139311102 * get_contestManager_5() const { return ___contestManager_5; }
	inline VP_1_t1139311102 ** get_address_of_contestManager_5() { return &___contestManager_5; }
	inline void set_contestManager_5(VP_1_t1139311102 * value)
	{
		___contestManager_5 = value;
		Il2CppCodeGenWriteBarrier(&___contestManager_5, value);
	}

	inline static int32_t get_offset_of_stateUI_6() { return static_cast<int32_t>(offsetof(UIData_t2287122849, ___stateUI_6)); }
	inline VP_1_t3493460771 * get_stateUI_6() const { return ___stateUI_6; }
	inline VP_1_t3493460771 ** get_address_of_stateUI_6() { return &___stateUI_6; }
	inline void set_stateUI_6(VP_1_t3493460771 * value)
	{
		___stateUI_6 = value;
		Il2CppCodeGenWriteBarrier(&___stateUI_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
