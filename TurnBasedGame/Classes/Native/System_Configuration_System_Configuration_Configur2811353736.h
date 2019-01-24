#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"
#include "System_Configuration_System_Configuration_Configur1806001494.h"

// System.String
struct String_t;
// System.Type
struct Type_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Configuration.ConfigurationCollectionAttribute
struct  ConfigurationCollectionAttribute_t2811353736  : public Attribute_t542643598
{
public:
	// System.String System.Configuration.ConfigurationCollectionAttribute::addItemName
	String_t* ___addItemName_0;
	// System.String System.Configuration.ConfigurationCollectionAttribute::clearItemsName
	String_t* ___clearItemsName_1;
	// System.String System.Configuration.ConfigurationCollectionAttribute::removeItemName
	String_t* ___removeItemName_2;
	// System.Configuration.ConfigurationElementCollectionType System.Configuration.ConfigurationCollectionAttribute::collectionType
	int32_t ___collectionType_3;
	// System.Type System.Configuration.ConfigurationCollectionAttribute::itemType
	Type_t * ___itemType_4;

public:
	inline static int32_t get_offset_of_addItemName_0() { return static_cast<int32_t>(offsetof(ConfigurationCollectionAttribute_t2811353736, ___addItemName_0)); }
	inline String_t* get_addItemName_0() const { return ___addItemName_0; }
	inline String_t** get_address_of_addItemName_0() { return &___addItemName_0; }
	inline void set_addItemName_0(String_t* value)
	{
		___addItemName_0 = value;
		Il2CppCodeGenWriteBarrier(&___addItemName_0, value);
	}

	inline static int32_t get_offset_of_clearItemsName_1() { return static_cast<int32_t>(offsetof(ConfigurationCollectionAttribute_t2811353736, ___clearItemsName_1)); }
	inline String_t* get_clearItemsName_1() const { return ___clearItemsName_1; }
	inline String_t** get_address_of_clearItemsName_1() { return &___clearItemsName_1; }
	inline void set_clearItemsName_1(String_t* value)
	{
		___clearItemsName_1 = value;
		Il2CppCodeGenWriteBarrier(&___clearItemsName_1, value);
	}

	inline static int32_t get_offset_of_removeItemName_2() { return static_cast<int32_t>(offsetof(ConfigurationCollectionAttribute_t2811353736, ___removeItemName_2)); }
	inline String_t* get_removeItemName_2() const { return ___removeItemName_2; }
	inline String_t** get_address_of_removeItemName_2() { return &___removeItemName_2; }
	inline void set_removeItemName_2(String_t* value)
	{
		___removeItemName_2 = value;
		Il2CppCodeGenWriteBarrier(&___removeItemName_2, value);
	}

	inline static int32_t get_offset_of_collectionType_3() { return static_cast<int32_t>(offsetof(ConfigurationCollectionAttribute_t2811353736, ___collectionType_3)); }
	inline int32_t get_collectionType_3() const { return ___collectionType_3; }
	inline int32_t* get_address_of_collectionType_3() { return &___collectionType_3; }
	inline void set_collectionType_3(int32_t value)
	{
		___collectionType_3 = value;
	}

	inline static int32_t get_offset_of_itemType_4() { return static_cast<int32_t>(offsetof(ConfigurationCollectionAttribute_t2811353736, ___itemType_4)); }
	inline Type_t * get_itemType_4() const { return ___itemType_4; }
	inline Type_t ** get_address_of_itemType_4() { return &___itemType_4; }
	inline void set_itemType_4(Type_t * value)
	{
		___itemType_4 = value;
		Il2CppCodeGenWriteBarrier(&___itemType_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
