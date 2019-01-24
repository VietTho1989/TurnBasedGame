#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Configuration_System_Configuration_Configur2600766927.h"

// System.Configuration.ConfigurationPropertyCollection
struct ConfigurationPropertyCollection_t3473514151;
// System.Configuration.ConfigurationProperty
struct ConfigurationProperty_t2048066811;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Net.Configuration.AuthenticationModulesSection
struct  AuthenticationModulesSection_t1750570770  : public ConfigurationSection_t2600766927
{
public:

public:
};

struct AuthenticationModulesSection_t1750570770_StaticFields
{
public:
	// System.Configuration.ConfigurationPropertyCollection System.Net.Configuration.AuthenticationModulesSection::properties
	ConfigurationPropertyCollection_t3473514151 * ___properties_17;
	// System.Configuration.ConfigurationProperty System.Net.Configuration.AuthenticationModulesSection::authenticationModulesProp
	ConfigurationProperty_t2048066811 * ___authenticationModulesProp_18;

public:
	inline static int32_t get_offset_of_properties_17() { return static_cast<int32_t>(offsetof(AuthenticationModulesSection_t1750570770_StaticFields, ___properties_17)); }
	inline ConfigurationPropertyCollection_t3473514151 * get_properties_17() const { return ___properties_17; }
	inline ConfigurationPropertyCollection_t3473514151 ** get_address_of_properties_17() { return &___properties_17; }
	inline void set_properties_17(ConfigurationPropertyCollection_t3473514151 * value)
	{
		___properties_17 = value;
		Il2CppCodeGenWriteBarrier(&___properties_17, value);
	}

	inline static int32_t get_offset_of_authenticationModulesProp_18() { return static_cast<int32_t>(offsetof(AuthenticationModulesSection_t1750570770_StaticFields, ___authenticationModulesProp_18)); }
	inline ConfigurationProperty_t2048066811 * get_authenticationModulesProp_18() const { return ___authenticationModulesProp_18; }
	inline ConfigurationProperty_t2048066811 ** get_address_of_authenticationModulesProp_18() { return &___authenticationModulesProp_18; }
	inline void set_authenticationModulesProp_18(ConfigurationProperty_t2048066811 * value)
	{
		___authenticationModulesProp_18 = value;
		Il2CppCodeGenWriteBarrier(&___authenticationModulesProp_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
