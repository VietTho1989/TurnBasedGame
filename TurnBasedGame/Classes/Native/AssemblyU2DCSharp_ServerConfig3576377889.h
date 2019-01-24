#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Data3569509720.h"

// VP`1<System.String>
struct VP_1_t2407497239;
// VP`1<System.Int32>
struct VP_1_t2450154454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ServerConfig
struct  ServerConfig_t3576377889  : public Data_t3569509720
{
public:
	// VP`1<System.String> ServerConfig::address
	VP_1_t2407497239 * ___address_5;
	// VP`1<System.Int32> ServerConfig::port
	VP_1_t2450154454 * ___port_6;

public:
	inline static int32_t get_offset_of_address_5() { return static_cast<int32_t>(offsetof(ServerConfig_t3576377889, ___address_5)); }
	inline VP_1_t2407497239 * get_address_5() const { return ___address_5; }
	inline VP_1_t2407497239 ** get_address_of_address_5() { return &___address_5; }
	inline void set_address_5(VP_1_t2407497239 * value)
	{
		___address_5 = value;
		Il2CppCodeGenWriteBarrier(&___address_5, value);
	}

	inline static int32_t get_offset_of_port_6() { return static_cast<int32_t>(offsetof(ServerConfig_t3576377889, ___port_6)); }
	inline VP_1_t2450154454 * get_port_6() const { return ___port_6; }
	inline VP_1_t2450154454 ** get_address_of_port_6() { return &___port_6; }
	inline void set_port_6(VP_1_t2450154454 * value)
	{
		___port_6 = value;
		Il2CppCodeGenWriteBarrier(&___port_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
