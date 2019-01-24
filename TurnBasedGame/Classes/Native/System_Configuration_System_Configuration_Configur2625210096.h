#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationFileMap
struct  ConfigurationFileMap_t2625210096  : public Il2CppObject
{
public:
	// System.String System.Configuration.ConfigurationFileMap::machineConfigFilename
	String_t* ___machineConfigFilename_0;

public:
	inline static int32_t get_offset_of_machineConfigFilename_0() { return static_cast<int32_t>(offsetof(ConfigurationFileMap_t2625210096, ___machineConfigFilename_0)); }
	inline String_t* get_machineConfigFilename_0() const { return ___machineConfigFilename_0; }
	inline String_t** get_address_of_machineConfigFilename_0() { return &___machineConfigFilename_0; }
	inline void set_machineConfigFilename_0(String_t* value)
	{
		___machineConfigFilename_0 = value;
		Il2CppCodeGenWriteBarrier(&___machineConfigFilename_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
