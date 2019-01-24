#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ReferenceData`1<Server>
struct  ReferenceData_1_t1795103830  : public Il2CppObject
{
public:
	// T ReferenceData`1::data
	Server_t2724320767 * ___data_0;

public:
	inline static int32_t get_offset_of_data_0() { return static_cast<int32_t>(offsetof(ReferenceData_1_t1795103830, ___data_0)); }
	inline Server_t2724320767 * get_data_0() const { return ___data_0; }
	inline Server_t2724320767 ** get_address_of_data_0() { return &___data_0; }
	inline void set_data_0(Server_t2724320767 * value)
	{
		___data_0 = value;
		Il2CppCodeGenWriteBarrier(&___data_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
