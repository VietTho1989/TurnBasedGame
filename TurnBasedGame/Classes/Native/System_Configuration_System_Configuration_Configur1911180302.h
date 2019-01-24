#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "System_Configuration_System_Configuration_Configur1776195828.h"

// System.Collections.ArrayList
struct ArrayList_t4252133567;
// System.Collections.IComparer
struct IComparer_t3952557350;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationElementCollection
struct  ConfigurationElementCollection_t1911180302  : public ConfigurationElement_t1776195828
{
public:
	// System.Collections.ArrayList System.Configuration.ConfigurationElementCollection::list
	ArrayList_t4252133567 * ___list_13;
	// System.Collections.ArrayList System.Configuration.ConfigurationElementCollection::removed
	ArrayList_t4252133567 * ___removed_14;
	// System.Collections.ArrayList System.Configuration.ConfigurationElementCollection::inherited
	ArrayList_t4252133567 * ___inherited_15;
	// System.Boolean System.Configuration.ConfigurationElementCollection::emitClear
	bool ___emitClear_16;
	// System.Boolean System.Configuration.ConfigurationElementCollection::modified
	bool ___modified_17;
	// System.Collections.IComparer System.Configuration.ConfigurationElementCollection::comparer
	Il2CppObject * ___comparer_18;
	// System.Int32 System.Configuration.ConfigurationElementCollection::inheritedLimitIndex
	int32_t ___inheritedLimitIndex_19;
	// System.String System.Configuration.ConfigurationElementCollection::addElementName
	String_t* ___addElementName_20;
	// System.String System.Configuration.ConfigurationElementCollection::clearElementName
	String_t* ___clearElementName_21;
	// System.String System.Configuration.ConfigurationElementCollection::removeElementName
	String_t* ___removeElementName_22;

public:
	inline static int32_t get_offset_of_list_13() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___list_13)); }
	inline ArrayList_t4252133567 * get_list_13() const { return ___list_13; }
	inline ArrayList_t4252133567 ** get_address_of_list_13() { return &___list_13; }
	inline void set_list_13(ArrayList_t4252133567 * value)
	{
		___list_13 = value;
		Il2CppCodeGenWriteBarrier(&___list_13, value);
	}

	inline static int32_t get_offset_of_removed_14() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___removed_14)); }
	inline ArrayList_t4252133567 * get_removed_14() const { return ___removed_14; }
	inline ArrayList_t4252133567 ** get_address_of_removed_14() { return &___removed_14; }
	inline void set_removed_14(ArrayList_t4252133567 * value)
	{
		___removed_14 = value;
		Il2CppCodeGenWriteBarrier(&___removed_14, value);
	}

	inline static int32_t get_offset_of_inherited_15() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___inherited_15)); }
	inline ArrayList_t4252133567 * get_inherited_15() const { return ___inherited_15; }
	inline ArrayList_t4252133567 ** get_address_of_inherited_15() { return &___inherited_15; }
	inline void set_inherited_15(ArrayList_t4252133567 * value)
	{
		___inherited_15 = value;
		Il2CppCodeGenWriteBarrier(&___inherited_15, value);
	}

	inline static int32_t get_offset_of_emitClear_16() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___emitClear_16)); }
	inline bool get_emitClear_16() const { return ___emitClear_16; }
	inline bool* get_address_of_emitClear_16() { return &___emitClear_16; }
	inline void set_emitClear_16(bool value)
	{
		___emitClear_16 = value;
	}

	inline static int32_t get_offset_of_modified_17() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___modified_17)); }
	inline bool get_modified_17() const { return ___modified_17; }
	inline bool* get_address_of_modified_17() { return &___modified_17; }
	inline void set_modified_17(bool value)
	{
		___modified_17 = value;
	}

	inline static int32_t get_offset_of_comparer_18() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___comparer_18)); }
	inline Il2CppObject * get_comparer_18() const { return ___comparer_18; }
	inline Il2CppObject ** get_address_of_comparer_18() { return &___comparer_18; }
	inline void set_comparer_18(Il2CppObject * value)
	{
		___comparer_18 = value;
		Il2CppCodeGenWriteBarrier(&___comparer_18, value);
	}

	inline static int32_t get_offset_of_inheritedLimitIndex_19() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___inheritedLimitIndex_19)); }
	inline int32_t get_inheritedLimitIndex_19() const { return ___inheritedLimitIndex_19; }
	inline int32_t* get_address_of_inheritedLimitIndex_19() { return &___inheritedLimitIndex_19; }
	inline void set_inheritedLimitIndex_19(int32_t value)
	{
		___inheritedLimitIndex_19 = value;
	}

	inline static int32_t get_offset_of_addElementName_20() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___addElementName_20)); }
	inline String_t* get_addElementName_20() const { return ___addElementName_20; }
	inline String_t** get_address_of_addElementName_20() { return &___addElementName_20; }
	inline void set_addElementName_20(String_t* value)
	{
		___addElementName_20 = value;
		Il2CppCodeGenWriteBarrier(&___addElementName_20, value);
	}

	inline static int32_t get_offset_of_clearElementName_21() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___clearElementName_21)); }
	inline String_t* get_clearElementName_21() const { return ___clearElementName_21; }
	inline String_t** get_address_of_clearElementName_21() { return &___clearElementName_21; }
	inline void set_clearElementName_21(String_t* value)
	{
		___clearElementName_21 = value;
		Il2CppCodeGenWriteBarrier(&___clearElementName_21, value);
	}

	inline static int32_t get_offset_of_removeElementName_22() { return static_cast<int32_t>(offsetof(ConfigurationElementCollection_t1911180302, ___removeElementName_22)); }
	inline String_t* get_removeElementName_22() const { return ___removeElementName_22; }
	inline String_t** get_address_of_removeElementName_22() { return &___removeElementName_22; }
	inline void set_removeElementName_22(String_t* value)
	{
		___removeElementName_22 = value;
		Il2CppCodeGenWriteBarrier(&___removeElementName_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
