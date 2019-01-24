#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<Weiqi.WeiqiUpdate/UpdateData/State>
struct VP_1_t1956406925;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Weiqi.WeiqiUpdate/UpdateData
struct  UpdateData_t124194839  : public Data_t3569509720
{
public:
	// VP`1<Weiqi.WeiqiUpdate/UpdateData/State> Weiqi.WeiqiUpdate/UpdateData::state
	VP_1_t1956406925 * ___state_5;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(UpdateData_t124194839, ___state_5)); }
	inline VP_1_t1956406925 * get_state_5() const { return ___state_5; }
	inline VP_1_t1956406925 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t1956406925 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
