#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_LastMoveSub4144089413.h"

// VP`1<ReferenceData`1<Xiangqi.NoneRule.XiangqiCustomMove>>
struct VP_1_t2088808792;
// VP`1<System.Boolean>
struct VP_1_t4203851724;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Xiangqi.NoneRule.XiangqiCustomMoveUI/UIData
struct  UIData_t1116363023  : public LastMoveSub_t4144089413
{
public:
	// VP`1<ReferenceData`1<Xiangqi.NoneRule.XiangqiCustomMove>> Xiangqi.NoneRule.XiangqiCustomMoveUI/UIData::xiangqiCustomMove
	VP_1_t2088808792 * ___xiangqiCustomMove_5;
	// VP`1<System.Boolean> Xiangqi.NoneRule.XiangqiCustomMoveUI/UIData::isHint
	VP_1_t4203851724 * ___isHint_6;

public:
	inline static int32_t get_offset_of_xiangqiCustomMove_5() { return static_cast<int32_t>(offsetof(UIData_t1116363023, ___xiangqiCustomMove_5)); }
	inline VP_1_t2088808792 * get_xiangqiCustomMove_5() const { return ___xiangqiCustomMove_5; }
	inline VP_1_t2088808792 ** get_address_of_xiangqiCustomMove_5() { return &___xiangqiCustomMove_5; }
	inline void set_xiangqiCustomMove_5(VP_1_t2088808792 * value)
	{
		___xiangqiCustomMove_5 = value;
		Il2CppCodeGenWriteBarrier(&___xiangqiCustomMove_5, value);
	}

	inline static int32_t get_offset_of_isHint_6() { return static_cast<int32_t>(offsetof(UIData_t1116363023, ___isHint_6)); }
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
