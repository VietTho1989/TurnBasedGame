#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Runtime_Serialization_Formatters_B3815195830.h"

// System.Reflection.MemberInfo[]
struct MemberInfoU5BU5D_t4238939941;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Runtime.Serialization.Formatters.Binary.MemberTypeMetadata
struct  MemberTypeMetadata_t887587901  : public ClrTypeMetadata_t3815195830
{
public:
	// System.Reflection.MemberInfo[] System.Runtime.Serialization.Formatters.Binary.MemberTypeMetadata::members
	MemberInfoU5BU5D_t4238939941* ___members_3;

public:
	inline static int32_t get_offset_of_members_3() { return static_cast<int32_t>(offsetof(MemberTypeMetadata_t887587901, ___members_3)); }
	inline MemberInfoU5BU5D_t4238939941* get_members_3() const { return ___members_3; }
	inline MemberInfoU5BU5D_t4238939941** get_address_of_members_3() { return &___members_3; }
	inline void set_members_3(MemberInfoU5BU5D_t4238939941* value)
	{
		___members_3 = value;
		Il2CppCodeGenWriteBarrier(&___members_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
