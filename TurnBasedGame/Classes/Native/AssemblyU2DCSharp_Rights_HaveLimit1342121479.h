#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Rights_Limit1725947585.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Rights.HaveLimit
struct  HaveLimit_t1342121479  : public Limit_t1725947585
{
public:
	// VP`1<System.Int32> Rights.HaveLimit::limit
	VP_1_t2450154454 * ___limit_5;

public:
	inline static int32_t get_offset_of_limit_5() { return static_cast<int32_t>(offsetof(HaveLimit_t1342121479, ___limit_5)); }
	inline VP_1_t2450154454 * get_limit_5() const { return ___limit_5; }
	inline VP_1_t2450154454 ** get_address_of_limit_5() { return &___limit_5; }
	inline void set_limit_5(VP_1_t2450154454 * value)
	{
		___limit_5 = value;
		Il2CppCodeGenWriteBarrier(&___limit_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
