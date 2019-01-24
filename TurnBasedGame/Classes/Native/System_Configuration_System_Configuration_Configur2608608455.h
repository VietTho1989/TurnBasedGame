#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Configuration.InternalConfigurationFactory
struct InternalConfigurationFactory_t3846641927;
// System.Configuration.Internal.IInternalConfigSystem
struct IInternalConfigSystem_t344849519;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationManager
struct  ConfigurationManager_t2608608455  : public Il2CppObject
{
public:

public:
};

struct ConfigurationManager_t2608608455_StaticFields
{
public:
	// System.Configuration.InternalConfigurationFactory System.Configuration.ConfigurationManager::configFactory
	InternalConfigurationFactory_t3846641927 * ___configFactory_0;
	// System.Configuration.Internal.IInternalConfigSystem System.Configuration.ConfigurationManager::configSystem
	Il2CppObject * ___configSystem_1;
	// System.Object System.Configuration.ConfigurationManager::lockobj
	Il2CppObject * ___lockobj_2;

public:
	inline static int32_t get_offset_of_configFactory_0() { return static_cast<int32_t>(offsetof(ConfigurationManager_t2608608455_StaticFields, ___configFactory_0)); }
	inline InternalConfigurationFactory_t3846641927 * get_configFactory_0() const { return ___configFactory_0; }
	inline InternalConfigurationFactory_t3846641927 ** get_address_of_configFactory_0() { return &___configFactory_0; }
	inline void set_configFactory_0(InternalConfigurationFactory_t3846641927 * value)
	{
		___configFactory_0 = value;
		Il2CppCodeGenWriteBarrier(&___configFactory_0, value);
	}

	inline static int32_t get_offset_of_configSystem_1() { return static_cast<int32_t>(offsetof(ConfigurationManager_t2608608455_StaticFields, ___configSystem_1)); }
	inline Il2CppObject * get_configSystem_1() const { return ___configSystem_1; }
	inline Il2CppObject ** get_address_of_configSystem_1() { return &___configSystem_1; }
	inline void set_configSystem_1(Il2CppObject * value)
	{
		___configSystem_1 = value;
		Il2CppCodeGenWriteBarrier(&___configSystem_1, value);
	}

	inline static int32_t get_offset_of_lockobj_2() { return static_cast<int32_t>(offsetof(ConfigurationManager_t2608608455_StaticFields, ___lockobj_2)); }
	inline Il2CppObject * get_lockobj_2() const { return ___lockobj_2; }
	inline Il2CppObject ** get_address_of_lockobj_2() { return &___lockobj_2; }
	inline void set_lockobj_2(Il2CppObject * value)
	{
		___lockobj_2 = value;
		Il2CppCodeGenWriteBarrier(&___lockobj_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
