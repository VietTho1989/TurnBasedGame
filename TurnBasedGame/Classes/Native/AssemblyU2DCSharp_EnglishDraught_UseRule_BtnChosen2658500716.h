#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<EnglishDraught.EnglishDraughtMove>>
struct VP_1_t767105049;
// VP`1<EnglishDraught.UseRule.BtnChosenMoveUI/OnClick>
struct VP_1_t484532255;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// EnglishDraught.UseRule.BtnChosenMoveUI/UIData
struct  UIData_t2658500716  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<EnglishDraught.EnglishDraughtMove>> EnglishDraught.UseRule.BtnChosenMoveUI/UIData::englishDraughtMove
	VP_1_t767105049 * ___englishDraughtMove_5;
	// VP`1<EnglishDraught.UseRule.BtnChosenMoveUI/OnClick> EnglishDraught.UseRule.BtnChosenMoveUI/UIData::onClick
	VP_1_t484532255 * ___onClick_6;

public:
	inline static int32_t get_offset_of_englishDraughtMove_5() { return static_cast<int32_t>(offsetof(UIData_t2658500716, ___englishDraughtMove_5)); }
	inline VP_1_t767105049 * get_englishDraughtMove_5() const { return ___englishDraughtMove_5; }
	inline VP_1_t767105049 ** get_address_of_englishDraughtMove_5() { return &___englishDraughtMove_5; }
	inline void set_englishDraughtMove_5(VP_1_t767105049 * value)
	{
		___englishDraughtMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___englishDraughtMove_5, value);
	}

	inline static int32_t get_offset_of_onClick_6() { return static_cast<int32_t>(offsetof(UIData_t2658500716, ___onClick_6)); }
	inline VP_1_t484532255 * get_onClick_6() const { return ___onClick_6; }
	inline VP_1_t484532255 ** get_address_of_onClick_6() { return &___onClick_6; }
	inline void set_onClick_6(VP_1_t484532255 * value)
	{
		___onClick_6 = value;
		Il2CppCodeGenWriteBarrier(&___onClick_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
