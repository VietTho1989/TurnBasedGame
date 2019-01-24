#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "System_Configuration_System_Configuration_Property1217826846.h"

// System.Object
struct Il2CppObject;
// System.Configuration.ConfigurationElement
struct ConfigurationElement_t1776195828;
// System.Configuration.ConfigurationProperty
struct ConfigurationProperty_t2048066811;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.PropertyInformation
struct  PropertyInformation_t2089433965  : public Il2CppObject
{
public:
	// System.Boolean System.Configuration.PropertyInformation::isModified
	bool ___isModified_0;
	// System.Object System.Configuration.PropertyInformation::val
	Il2CppObject * ___val_1;
	// System.Configuration.PropertyValueOrigin System.Configuration.PropertyInformation::origin
	int32_t ___origin_2;
	// System.Configuration.ConfigurationElement System.Configuration.PropertyInformation::owner
	ConfigurationElement_t1776195828 * ___owner_3;
	// System.Configuration.ConfigurationProperty System.Configuration.PropertyInformation::property
	ConfigurationProperty_t2048066811 * ___property_4;

public:
	inline static int32_t get_offset_of_isModified_0() { return static_cast<int32_t>(offsetof(PropertyInformation_t2089433965, ___isModified_0)); }
	inline bool get_isModified_0() const { return ___isModified_0; }
	inline bool* get_address_of_isModified_0() { return &___isModified_0; }
	inline void set_isModified_0(bool value)
	{
		___isModified_0 = value;
	}

	inline static int32_t get_offset_of_val_1() { return static_cast<int32_t>(offsetof(PropertyInformation_t2089433965, ___val_1)); }
	inline Il2CppObject * get_val_1() const { return ___val_1; }
	inline Il2CppObject ** get_address_of_val_1() { return &___val_1; }
	inline void set_val_1(Il2CppObject * value)
	{
		___val_1 = value;
		Il2CppCodeGenWriteBarrier(&___val_1, value);
	}

	inline static int32_t get_offset_of_origin_2() { return static_cast<int32_t>(offsetof(PropertyInformation_t2089433965, ___origin_2)); }
	inline int32_t get_origin_2() const { return ___origin_2; }
	inline int32_t* get_address_of_origin_2() { return &___origin_2; }
	inline void set_origin_2(int32_t value)
	{
		___origin_2 = value;
	}

	inline static int32_t get_offset_of_owner_3() { return static_cast<int32_t>(offsetof(PropertyInformation_t2089433965, ___owner_3)); }
	inline ConfigurationElement_t1776195828 * get_owner_3() const { return ___owner_3; }
	inline ConfigurationElement_t1776195828 ** get_address_of_owner_3() { return &___owner_3; }
	inline void set_owner_3(ConfigurationElement_t1776195828 * value)
	{
		___owner_3 = value;
		Il2CppCodeGenWriteBarrier(&___owner_3, value);
	}

	inline static int32_t get_offset_of_property_4() { return static_cast<int32_t>(offsetof(PropertyInformation_t2089433965, ___property_4)); }
	inline ConfigurationProperty_t2048066811 * get_property_4() const { return ___property_4; }
	inline ConfigurationProperty_t2048066811 ** get_address_of_property_4() { return &___property_4; }
	inline void set_property_4(ConfigurationProperty_t2048066811 * value)
	{
		___property_4 = value;
		Il2CppCodeGenWriteBarrier(&___property_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
