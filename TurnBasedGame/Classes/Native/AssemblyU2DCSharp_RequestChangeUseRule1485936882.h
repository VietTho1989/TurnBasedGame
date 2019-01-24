#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<RequestChangeUseRule/State>
struct VP_1_t330490290;
// LP`1<Human>
struct LP_1_t4188799745;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// RequestChangeUseRule
struct  RequestChangeUseRule_t1485936882  : public Data_t3569509720
{
public:
	// VP`1<RequestChangeUseRule/State> RequestChangeUseRule::state
	VP_1_t330490290 * ___state_5;
	// LP`1<Human> RequestChangeUseRule::whoCanAsks
	LP_1_t4188799745 * ___whoCanAsks_6;

public:
	inline static int32_t get_offset_of_state_5() { return static_cast<int32_t>(offsetof(RequestChangeUseRule_t1485936882, ___state_5)); }
	inline VP_1_t330490290 * get_state_5() const { return ___state_5; }
	inline VP_1_t330490290 ** get_address_of_state_5() { return &___state_5; }
	inline void set_state_5(VP_1_t330490290 * value)
	{
		___state_5 = value;
		Il2CppCodeGenWriteBarrier(&___state_5, value);
	}

	inline static int32_t get_offset_of_whoCanAsks_6() { return static_cast<int32_t>(offsetof(RequestChangeUseRule_t1485936882, ___whoCanAsks_6)); }
	inline LP_1_t4188799745 * get_whoCanAsks_6() const { return ___whoCanAsks_6; }
	inline LP_1_t4188799745 ** get_address_of_whoCanAsks_6() { return &___whoCanAsks_6; }
	inline void set_whoCanAsks_6(LP_1_t4188799745 * value)
	{
		___whoCanAsks_6 = value;
		Il2CppCodeGenWriteBarrier(&___whoCanAsks_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
