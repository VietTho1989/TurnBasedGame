#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<RussianDraught.RussianDraughtMove>>
struct VP_1_t691572268;
// VP`1<RussianDraught.UseRule.BtnChosenMoveUI/OnClick>
struct VP_1_t2479797396;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RussianDraught.UseRule.BtnChosenMoveUI/UIData
struct  UIData_t37975733  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<RussianDraught.RussianDraughtMove>> RussianDraught.UseRule.BtnChosenMoveUI/UIData::russianDraughtMove
	VP_1_t691572268 * ___russianDraughtMove_5;
	// VP`1<RussianDraught.UseRule.BtnChosenMoveUI/OnClick> RussianDraught.UseRule.BtnChosenMoveUI/UIData::onClick
	VP_1_t2479797396 * ___onClick_6;

public:
	inline static int32_t get_offset_of_russianDraughtMove_5() { return static_cast<int32_t>(offsetof(UIData_t37975733, ___russianDraughtMove_5)); }
	inline VP_1_t691572268 * get_russianDraughtMove_5() const { return ___russianDraughtMove_5; }
	inline VP_1_t691572268 ** get_address_of_russianDraughtMove_5() { return &___russianDraughtMove_5; }
	inline void set_russianDraughtMove_5(VP_1_t691572268 * value)
	{
		___russianDraughtMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___russianDraughtMove_5, value);
	}

	inline static int32_t get_offset_of_onClick_6() { return static_cast<int32_t>(offsetof(UIData_t37975733, ___onClick_6)); }
	inline VP_1_t2479797396 * get_onClick_6() const { return ___onClick_6; }
	inline VP_1_t2479797396 ** get_address_of_onClick_6() { return &___onClick_6; }
	inline void set_onClick_6(VP_1_t2479797396 * value)
	{
		___onClick_6 = value;
		Il2CppCodeGenWriteBarrier(&___onClick_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
