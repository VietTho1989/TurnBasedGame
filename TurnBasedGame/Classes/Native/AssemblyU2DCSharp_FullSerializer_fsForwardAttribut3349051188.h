#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Attribute542643598.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsForwardAttribute
struct  fsForwardAttribute_t3349051188  : public Attribute_t542643598
{
public:
	// System.String FullSerializer.fsForwardAttribute::MemberName
	String_t* ___MemberName_0;

public:
	inline static int32_t get_offset_of_MemberName_0() { return static_cast<int32_t>(offsetof(fsForwardAttribute_t3349051188, ___MemberName_0)); }
	inline String_t* get_MemberName_0() const { return ___MemberName_0; }
	inline String_t** get_address_of_MemberName_0() { return &___MemberName_0; }
	inline void set_MemberName_0(String_t* value)
	{
		___MemberName_0 = value;
		Il2CppCodeGenWriteBarrier(&___MemberName_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
