#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro1775368447.h"

// VP`1<ReferenceData`1<Posture.ChoosePostureUI/UIData>>
struct VP_1_t23755559;
// LP`1<Posture.ChoosePostureHolder/UIData>
struct LP_1_t3463016938;
// System.Collections.Generic.List`1<Posture.PostureGameData>
struct List_1_t181307880;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Posture.ChoosePostureAdapter/UIData
struct  UIData_t275358825  : public BaseParams_t1775368447
{
public:
	// VP`1<ReferenceData`1<Posture.ChoosePostureUI/UIData>> Posture.ChoosePostureAdapter/UIData::loadPostureData
	VP_1_t23755559 * ___loadPostureData_20;
	// LP`1<Posture.ChoosePostureHolder/UIData> Posture.ChoosePostureAdapter/UIData::holders
	LP_1_t3463016938 * ___holders_21;
	// System.Collections.Generic.List`1<Posture.PostureGameData> Posture.ChoosePostureAdapter/UIData::postureGameDatas
	List_1_t181307880 * ___postureGameDatas_22;

public:
	inline static int32_t get_offset_of_loadPostureData_20() { return static_cast<int32_t>(offsetof(UIData_t275358825, ___loadPostureData_20)); }
	inline VP_1_t23755559 * get_loadPostureData_20() const { return ___loadPostureData_20; }
	inline VP_1_t23755559 ** get_address_of_loadPostureData_20() { return &___loadPostureData_20; }
	inline void set_loadPostureData_20(VP_1_t23755559 * value)
	{
		___loadPostureData_20 = value;
		Il2CppCodeGenWriteBarrier(&___loadPostureData_20, value);
	}

	inline static int32_t get_offset_of_holders_21() { return static_cast<int32_t>(offsetof(UIData_t275358825, ___holders_21)); }
	inline LP_1_t3463016938 * get_holders_21() const { return ___holders_21; }
	inline LP_1_t3463016938 ** get_address_of_holders_21() { return &___holders_21; }
	inline void set_holders_21(LP_1_t3463016938 * value)
	{
		___holders_21 = value;
		Il2CppCodeGenWriteBarrier(&___holders_21, value);
	}

	inline static int32_t get_offset_of_postureGameDatas_22() { return static_cast<int32_t>(offsetof(UIData_t275358825, ___postureGameDatas_22)); }
	inline List_1_t181307880 * get_postureGameDatas_22() const { return ___postureGameDatas_22; }
	inline List_1_t181307880 ** get_address_of_postureGameDatas_22() { return &___postureGameDatas_22; }
	inline void set_postureGameDatas_22(List_1_t181307880 * value)
	{
		___postureGameDatas_22 = value;
		Il2CppCodeGenWriteBarrier(&___postureGameDatas_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
