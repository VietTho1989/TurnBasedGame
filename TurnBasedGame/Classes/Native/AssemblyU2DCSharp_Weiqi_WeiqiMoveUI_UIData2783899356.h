﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LastMoveSub4144089413.h"

// VP`1<ReferenceData`1<Weiqi.WeiqiMove>>
struct VP_1_t3793940449;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiMoveUI/UIData
struct  UIData_t2783899356  : public LastMoveSub_t4144089413
{
public:
	// VP`1<ReferenceData`1<Weiqi.WeiqiMove>> Weiqi.WeiqiMoveUI/UIData::weiqiMove
	VP_1_t3793940449 * ___weiqiMove_5;
	// VP`1<System.Boolean> Weiqi.WeiqiMoveUI/UIData::isHint
	VP_1_t4203851724 * ___isHint_6;

public:
	inline static int32_t get_offset_of_weiqiMove_5() { return static_cast<int32_t>(offsetof(UIData_t2783899356, ___weiqiMove_5)); }
	inline VP_1_t3793940449 * get_weiqiMove_5() const { return ___weiqiMove_5; }
	inline VP_1_t3793940449 ** get_address_of_weiqiMove_5() { return &___weiqiMove_5; }
	inline void set_weiqiMove_5(VP_1_t3793940449 * value)
	{
		___weiqiMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___weiqiMove_5, value);
	}

	inline static int32_t get_offset_of_isHint_6() { return static_cast<int32_t>(offsetof(UIData_t2783899356, ___isHint_6)); }
	inline VP_1_t4203851724 * get_isHint_6() const { return ___isHint_6; }
	inline VP_1_t4203851724 ** get_address_of_isHint_6() { return &___isHint_6; }
	inline void set_isHint_6(VP_1_t4203851724 * value)
	{
		___isHint_6 = value;
		Il2CppCodeGenWriteBarrier(&___isHint_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
