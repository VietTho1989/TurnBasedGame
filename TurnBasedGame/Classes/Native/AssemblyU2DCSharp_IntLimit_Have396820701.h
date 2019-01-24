#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_IntLimit318449432.h"

// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// IntLimit/Have
struct  Have_t396820701  : public IntLimit_t318449432
{
public:
	// VP`1<System.Int32> IntLimit/Have::min
	VP_1_t2450154454 * ___min_5;
	// VP`1<System.Int32> IntLimit/Have::max
	VP_1_t2450154454 * ___max_6;

public:
	inline static int32_t get_offset_of_min_5() { return static_cast<int32_t>(offsetof(Have_t396820701, ___min_5)); }
	inline VP_1_t2450154454 * get_min_5() const { return ___min_5; }
	inline VP_1_t2450154454 ** get_address_of_min_5() { return &___min_5; }
	inline void set_min_5(VP_1_t2450154454 * value)
	{
		___min_5 = value;
		Il2CppCodeGenWriteBarrier(&___min_5, value);
	}

	inline static int32_t get_offset_of_max_6() { return static_cast<int32_t>(offsetof(Have_t396820701, ___max_6)); }
	inline VP_1_t2450154454 * get_max_6() const { return ___max_6; }
	inline VP_1_t2450154454 ** get_address_of_max_6() { return &___max_6; }
	inline void set_max_6(VP_1_t2450154454 * value)
	{
		___max_6 = value;
		Il2CppCodeGenWriteBarrier(&___max_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
