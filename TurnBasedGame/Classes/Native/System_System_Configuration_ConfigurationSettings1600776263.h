#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Configuration.IConfigurationSystem
struct IConfigurationSystem_t3937028158;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationSettings
struct  ConfigurationSettings_t1600776263  : public Il2CppObject
{
public:

public:
};

struct ConfigurationSettings_t1600776263_StaticFields
{
public:
	// System.Configuration.IConfigurationSystem System.Configuration.ConfigurationSettings::config
	Il2CppObject * ___config_0;
	// System.Object System.Configuration.ConfigurationSettings::lockobj
	Il2CppObject * ___lockobj_1;

public:
	inline static int32_t get_offset_of_config_0() { return static_cast<int32_t>(offsetof(ConfigurationSettings_t1600776263_StaticFields, ___config_0)); }
	inline Il2CppObject * get_config_0() const { return ___config_0; }
	inline Il2CppObject ** get_address_of_config_0() { return &___config_0; }
	inline void set_config_0(Il2CppObject * value)
	{
		___config_0 = value;
		Il2CppCodeGenWriteBarrier(&___config_0, value);
	}

	inline static int32_t get_offset_of_lockobj_1() { return static_cast<int32_t>(offsetof(ConfigurationSettings_t1600776263_StaticFields, ___lockobj_1)); }
	inline Il2CppObject * get_lockobj_1() const { return ___lockobj_1; }
	inline Il2CppObject ** get_address_of_lockobj_1() { return &___lockobj_1; }
	inline void set_lockobj_1(Il2CppObject * value)
	{
		___lockobj_1 = value;
		Il2CppCodeGenWriteBarrier(&___lockobj_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
