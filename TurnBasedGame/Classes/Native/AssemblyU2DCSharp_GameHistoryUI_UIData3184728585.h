#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<History>>
struct VP_1_t3287900393;
// VP`1<ViewSaveDataUI/UIData>
struct VP_1_t3660286215;
// VP`1<BtnLoadHistoryUI/UIData>
struct VP_1_t1270006887;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameHistoryUI/UIData
struct  UIData_t3184728585  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<History>> GameHistoryUI/UIData::history
	VP_1_t3287900393 * ___history_5;
	// VP`1<ViewSaveDataUI/UIData> GameHistoryUI/UIData::viewSaveDataUIData
	VP_1_t3660286215 * ___viewSaveDataUIData_6;
	// VP`1<BtnLoadHistoryUI/UIData> GameHistoryUI/UIData::btnLoadHistoryUIData
	VP_1_t1270006887 * ___btnLoadHistoryUIData_7;

public:
	inline static int32_t get_offset_of_history_5() { return static_cast<int32_t>(offsetof(UIData_t3184728585, ___history_5)); }
	inline VP_1_t3287900393 * get_history_5() const { return ___history_5; }
	inline VP_1_t3287900393 ** get_address_of_history_5() { return &___history_5; }
	inline void set_history_5(VP_1_t3287900393 * value)
	{
		___history_5 = value;
		Il2CppCodeGenWriteBarrier(&___history_5, value);
	}

	inline static int32_t get_offset_of_viewSaveDataUIData_6() { return static_cast<int32_t>(offsetof(UIData_t3184728585, ___viewSaveDataUIData_6)); }
	inline VP_1_t3660286215 * get_viewSaveDataUIData_6() const { return ___viewSaveDataUIData_6; }
	inline VP_1_t3660286215 ** get_address_of_viewSaveDataUIData_6() { return &___viewSaveDataUIData_6; }
	inline void set_viewSaveDataUIData_6(VP_1_t3660286215 * value)
	{
		___viewSaveDataUIData_6 = value;
		Il2CppCodeGenWriteBarrier(&___viewSaveDataUIData_6, value);
	}

	inline static int32_t get_offset_of_btnLoadHistoryUIData_7() { return static_cast<int32_t>(offsetof(UIData_t3184728585, ___btnLoadHistoryUIData_7)); }
	inline VP_1_t1270006887 * get_btnLoadHistoryUIData_7() const { return ___btnLoadHistoryUIData_7; }
	inline VP_1_t1270006887 ** get_address_of_btnLoadHistoryUIData_7() { return &___btnLoadHistoryUIData_7; }
	inline void set_btnLoadHistoryUIData_7(VP_1_t1270006887 * value)
	{
		___btnLoadHistoryUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___btnLoadHistoryUIData_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
