#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_AIUI_UIData_Sub3237004242.h"

// VP`1<EditData`1<HEX.HexAI>>
struct VP_1_t2243252359;
// VP`1<RequestChangeIntUI/UIData>
struct VP_1_t1437137211;
// VP`1<RequestChangeBoolUI/UIData>
struct VP_1_t3802102788;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HEX.HexAIUI/UIData
struct  UIData_t4235388103  : public Sub_t3237004242
{
public:
	// VP`1<EditData`1<HEX.HexAI>> HEX.HexAIUI/UIData::editAI
	VP_1_t2243252359 * ___editAI_5;
	// VP`1<RequestChangeIntUI/UIData> HEX.HexAIUI/UIData::limitTime
	VP_1_t1437137211 * ___limitTime_6;
	// VP`1<RequestChangeBoolUI/UIData> HEX.HexAIUI/UIData::firstMoveCenter
	VP_1_t3802102788 * ___firstMoveCenter_7;

public:
	inline static int32_t get_offset_of_editAI_5() { return static_cast<int32_t>(offsetof(UIData_t4235388103, ___editAI_5)); }
	inline VP_1_t2243252359 * get_editAI_5() const { return ___editAI_5; }
	inline VP_1_t2243252359 ** get_address_of_editAI_5() { return &___editAI_5; }
	inline void set_editAI_5(VP_1_t2243252359 * value)
	{
		___editAI_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAI_5, value);
	}

	inline static int32_t get_offset_of_limitTime_6() { return static_cast<int32_t>(offsetof(UIData_t4235388103, ___limitTime_6)); }
	inline VP_1_t1437137211 * get_limitTime_6() const { return ___limitTime_6; }
	inline VP_1_t1437137211 ** get_address_of_limitTime_6() { return &___limitTime_6; }
	inline void set_limitTime_6(VP_1_t1437137211 * value)
	{
		___limitTime_6 = value;
		Il2CppCodeGenWriteBarrier(&___limitTime_6, value);
	}

	inline static int32_t get_offset_of_firstMoveCenter_7() { return static_cast<int32_t>(offsetof(UIData_t4235388103, ___firstMoveCenter_7)); }
	inline VP_1_t3802102788 * get_firstMoveCenter_7() const { return ___firstMoveCenter_7; }
	inline VP_1_t3802102788 ** get_address_of_firstMoveCenter_7() { return &___firstMoveCenter_7; }
	inline void set_firstMoveCenter_7(VP_1_t3802102788 * value)
	{
		___firstMoveCenter_7 = value;
		Il2CppCodeGenWriteBarrier(&___firstMoveCenter_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
