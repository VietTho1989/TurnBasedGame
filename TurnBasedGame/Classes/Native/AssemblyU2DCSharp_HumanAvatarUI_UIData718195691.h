﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_InformAvatarUI_UIData_Sub1252068624.h"

// VP`1<ReferenceData`1<Human>>
struct VP_1_t605148562;
// VP`1<AccountAvatarUI/UIData>
struct VP_1_t3547432187;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HumanAvatarUI/UIData
struct  UIData_t718195691  : public Sub_t1252068624
{
public:
	// VP`1<ReferenceData`1<Human>> HumanAvatarUI/UIData::human
	VP_1_t605148562 * ___human_5;
	// VP`1<AccountAvatarUI/UIData> HumanAvatarUI/UIData::avatar
	VP_1_t3547432187 * ___avatar_6;

public:
	inline static int32_t get_offset_of_human_5() { return static_cast<int32_t>(offsetof(UIData_t718195691, ___human_5)); }
	inline VP_1_t605148562 * get_human_5() const { return ___human_5; }
	inline VP_1_t605148562 ** get_address_of_human_5() { return &___human_5; }
	inline void set_human_5(VP_1_t605148562 * value)
	{
		___human_5 = value;
		Il2CppCodeGenWriteBarrier(&___human_5, value);
	}

	inline static int32_t get_offset_of_avatar_6() { return static_cast<int32_t>(offsetof(UIData_t718195691, ___avatar_6)); }
	inline VP_1_t3547432187 * get_avatar_6() const { return ___avatar_6; }
	inline VP_1_t3547432187 ** get_address_of_avatar_6() { return &___avatar_6; }
	inline void set_avatar_6(VP_1_t3547432187 * value)
	{
		___avatar_6 = value;
		Il2CppCodeGenWriteBarrier(&___avatar_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif