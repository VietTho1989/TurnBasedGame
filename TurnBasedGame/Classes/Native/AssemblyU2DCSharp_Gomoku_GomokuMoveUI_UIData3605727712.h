﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LastMoveSub4144089413.h"

// VP`1<ReferenceData`1<Gomoku.GomokuMove>>
struct VP_1_t4033093864;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Gomoku.GomokuMoveUI/UIData
struct  UIData_t3605727712  : public LastMoveSub_t4144089413
{
public:
	// VP`1<ReferenceData`1<Gomoku.GomokuMove>> Gomoku.GomokuMoveUI/UIData::gomokuMove
	VP_1_t4033093864 * ___gomokuMove_5;
	// VP`1<System.Boolean> Gomoku.GomokuMoveUI/UIData::isHint
	VP_1_t4203851724 * ___isHint_6;

public:
	inline static int32_t get_offset_of_gomokuMove_5() { return static_cast<int32_t>(offsetof(UIData_t3605727712, ___gomokuMove_5)); }
	inline VP_1_t4033093864 * get_gomokuMove_5() const { return ___gomokuMove_5; }
	inline VP_1_t4033093864 ** get_address_of_gomokuMove_5() { return &___gomokuMove_5; }
	inline void set_gomokuMove_5(VP_1_t4033093864 * value)
	{
		___gomokuMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___gomokuMove_5, value);
	}

	inline static int32_t get_offset_of_isHint_6() { return static_cast<int32_t>(offsetof(UIData_t3605727712, ___isHint_6)); }
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
