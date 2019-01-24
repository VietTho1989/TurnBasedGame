#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Configuration_System_Configuration_Configur2600766927.h"

// System.Configuration.ConfigurationProperty
struct ConfigurationProperty_t2048066811;
// System.Configuration.ConfigurationPropertyCollection
struct ConfigurationPropertyCollection_t3473514151;
// System.Configuration.ProtectedConfigurationProviderCollection
struct ProtectedConfigurationProviderCollection_t388338823;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ProtectedConfigurationSection
struct  ProtectedConfigurationSection_t3541826375  : public ConfigurationSection_t2600766927
{
public:
	// System.Configuration.ProtectedConfigurationProviderCollection System.Configuration.ProtectedConfigurationSection::providers
	ProtectedConfigurationProviderCollection_t388338823 * ___providers_20;

public:
	inline static int32_t get_offset_of_providers_20() { return static_cast<int32_t>(offsetof(ProtectedConfigurationSection_t3541826375, ___providers_20)); }
	inline ProtectedConfigurationProviderCollection_t388338823 * get_providers_20() const { return ___providers_20; }
	inline ProtectedConfigurationProviderCollection_t388338823 ** get_address_of_providers_20() { return &___providers_20; }
	inline void set_providers_20(ProtectedConfigurationProviderCollection_t388338823 * value)
	{
		___providers_20 = value;
		Il2CppCodeGenWriteBarrier(&___providers_20, value);
	}
};

struct ProtectedConfigurationSection_t3541826375_StaticFields
{
public:
	// System.Configuration.ConfigurationProperty System.Configuration.ProtectedConfigurationSection::defaultProviderProp
	ConfigurationProperty_t2048066811 * ___defaultProviderProp_17;
	// System.Configuration.ConfigurationProperty System.Configuration.ProtectedConfigurationSection::providersProp
	ConfigurationProperty_t2048066811 * ___providersProp_18;
	// System.Configuration.ConfigurationPropertyCollection System.Configuration.ProtectedConfigurationSection::properties
	ConfigurationPropertyCollection_t3473514151 * ___properties_19;

public:
	inline static int32_t get_offset_of_defaultProviderProp_17() { return static_cast<int32_t>(offsetof(ProtectedConfigurationSection_t3541826375_StaticFields, ___defaultProviderProp_17)); }
	inline ConfigurationProperty_t2048066811 * get_defaultProviderProp_17() const { return ___defaultProviderProp_17; }
	inline ConfigurationProperty_t2048066811 ** get_address_of_defaultProviderProp_17() { return &___defaultProviderProp_17; }
	inline void set_defaultProviderProp_17(ConfigurationProperty_t2048066811 * value)
	{
		___defaultProviderProp_17 = value;
		Il2CppCodeGenWriteBarrier(&___defaultProviderProp_17, value);
	}

	inline static int32_t get_offset_of_providersProp_18() { return static_cast<int32_t>(offsetof(ProtectedConfigurationSection_t3541826375_StaticFields, ___providersProp_18)); }
	inline ConfigurationProperty_t2048066811 * get_providersProp_18() const { return ___providersProp_18; }
	inline ConfigurationProperty_t2048066811 ** get_address_of_providersProp_18() { return &___providersProp_18; }
	inline void set_providersProp_18(ConfigurationProperty_t2048066811 * value)
	{
		___providersProp_18 = value;
		Il2CppCodeGenWriteBarrier(&___providersProp_18, value);
	}

	inline static int32_t get_offset_of_properties_19() { return static_cast<int32_t>(offsetof(ProtectedConfigurationSection_t3541826375_StaticFields, ___properties_19)); }
	inline ConfigurationPropertyCollection_t3473514151 * get_properties_19() const { return ___properties_19; }
	inline ConfigurationPropertyCollection_t3473514151 ** get_address_of_properties_19() { return &___properties_19; }
	inline void set_properties_19(ConfigurationPropertyCollection_t3473514151 * value)
	{
		___properties_19 = value;
		Il2CppCodeGenWriteBarrier(&___properties_19, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
