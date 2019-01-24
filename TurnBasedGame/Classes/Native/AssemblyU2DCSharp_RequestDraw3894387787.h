#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<RequestDraw/State>
struct VP_1_t3732211129;
// VP`1<System.Int64>
struct VP_1_t1287355043;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestDraw
struct  RequestDraw_t3894387787  : public Data_t3569509720
{
public:
	// VP`1<RequestDraw/State> RequestDraw::state
	VP_1_t3732211129 * ___state_5;
	// VP`1<System.Int64> RequestDraw::time
	VP_1_t1287355043 * ___time_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(RequestDraw_t3894387787, ___state_5)); }
	inline VP_1_t3732211129 * get_state_5() const { return ___state_5; }
	inline VP_1_t3732211129 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t3732211129 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_time_6() { return static_cast<int32_t>(offsetof(RequestDraw_t3894387787, ___time_6)); }
	inline VP_1_t1287355043 * get_time_6() const { return ___time_6; }
	inline VP_1_t1287355043 ** get_address_of_time_6() { return &___time_6; }
	inline void set_time_6(VP_1_t1287355043 * value)
	{
		___time_6 = value;
		Il2CppCodeGenWriteBarrier(&___time_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
