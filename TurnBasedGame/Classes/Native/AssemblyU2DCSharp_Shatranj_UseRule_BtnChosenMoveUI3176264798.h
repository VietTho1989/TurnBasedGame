#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<ReferenceData`1<Shatranj.ShatranjMove>>
struct VP_1_t32393703;
// VP`1<Shatranj.UseRule.BtnChosenMoveUI/OnClick>
struct VP_1_t2071727249;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Shatranj.UseRule.BtnChosenMoveUI/UIData
struct  UIData_t3176264798  : public Data_t3569509720
{
public:
	// VP`1<ReferenceData`1<Shatranj.ShatranjMove>> Shatranj.UseRule.BtnChosenMoveUI/UIData::shatranjMove
	VP_1_t32393703 * ___shatranjMove_5;
	// VP`1<Shatranj.UseRule.BtnChosenMoveUI/OnClick> Shatranj.UseRule.BtnChosenMoveUI/UIData::onClick
	VP_1_t2071727249 * ___onClick_6;

public:
	inline static int32_t get_offset_of_shatranjMove_5() { return static_cast<int32_t>(offsetof(UIData_t3176264798, ___shatranjMove_5)); }
	inline VP_1_t32393703 * get_shatranjMove_5() const { return ___shatranjMove_5; }
	inline VP_1_t32393703 ** get_address_of_shatranjMove_5() { return &___shatranjMove_5; }
	inline void set_shatranjMove_5(VP_1_t32393703 * value)
	{
		___shatranjMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___shatranjMove_5, value);
	}

	inline static int32_t get_offset_of_onClick_6() { return static_cast<int32_t>(offsetof(UIData_t3176264798, ___onClick_6)); }
	inline VP_1_t2071727249 * get_onClick_6() const { return ___onClick_6; }
	inline VP_1_t2071727249 ** get_address_of_onClick_6() { return &___onClick_6; }
	inline void set_onClick_6(VP_1_t2071727249 * value)
	{
		___onClick_6 = value;
		Il2CppCodeGenWriteBarrier(&___onClick_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
