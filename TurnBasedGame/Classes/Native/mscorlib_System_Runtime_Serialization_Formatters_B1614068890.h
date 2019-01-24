#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Runtime_Serialization_Formatters_B1398900059.h"

// System.Type[]
struct TypeU5BU5D_t1664964607;
// System.String[]
struct StringU5BU5D_t1642385972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.Formatters.Binary.SerializableTypeMetadata
struct  SerializableTypeMetadata_t1614068890  : public TypeMetadata_t1398900059
{
public:
	// System.Type[] System.Runtime.Serialization.Formatters.Binary.SerializableTypeMetadata::types
	TypeU5BU5D_t1664964607* ___types_2;
	// System.String[] System.Runtime.Serialization.Formatters.Binary.SerializableTypeMetadata::names
	StringU5BU5D_t1642385972* ___names_3;

public:
	inline static int32_t get_offset_of_types_2() { return static_cast<int32_t>(offsetof(SerializableTypeMetadata_t1614068890, ___types_2)); }
	inline TypeU5BU5D_t1664964607* get_types_2() const { return ___types_2; }
	inline TypeU5BU5D_t1664964607** get_address_of_types_2() { return &___types_2; }
	inline void set_types_2(TypeU5BU5D_t1664964607* value)
	{
		___types_2 = value;
		Il2CppCodeGenWriteBarrier(&___types_2, value);
	}

	inline static int32_t get_offset_of_names_3() { return static_cast<int32_t>(offsetof(SerializableTypeMetadata_t1614068890, ___names_3)); }
	inline StringU5BU5D_t1642385972* get_names_3() const { return ___names_3; }
	inline StringU5BU5D_t1642385972** get_address_of_names_3() { return &___names_3; }
	inline void set_names_3(StringU5BU5D_t1642385972* value)
	{
		___names_3 = value;
		Il2CppCodeGenWriteBarrier(&___names_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
