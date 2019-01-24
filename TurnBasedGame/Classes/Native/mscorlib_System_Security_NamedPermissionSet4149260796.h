#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Security_PermissionSet1941658161.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.NamedPermissionSet
struct  NamedPermissionSet_t4149260796  : public PermissionSet_t1941658161
{
public:
	// System.String System.Security.NamedPermissionSet::name
	String_t* ___name_12;
	// System.String System.Security.NamedPermissionSet::description
	String_t* ___description_13;

public:
	inline static int32_t get_offset_of_name_12() { return static_cast<int32_t>(offsetof(NamedPermissionSet_t4149260796, ___name_12)); }
	inline String_t* get_name_12() const { return ___name_12; }
	inline String_t** get_address_of_name_12() { return &___name_12; }
	inline void set_name_12(String_t* value)
	{
		___name_12 = value;
		Il2CppCodeGenWriteBarrier(&___name_12, value);
	}

	inline static int32_t get_offset_of_description_13() { return static_cast<int32_t>(offsetof(NamedPermissionSet_t4149260796, ___description_13)); }
	inline String_t* get_description_13() const { return ___description_13; }
	inline String_t** get_address_of_description_13() { return &___description_13; }
	inline void set_description_13(String_t* value)
	{
		___description_13 = value;
		Il2CppCodeGenWriteBarrier(&___description_13, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
