#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.ExporterLabel
struct  ExporterLabel_t839268261  : public Il2CppObject
{
public:

public:
};

struct ExporterLabel_t839268261_StaticFields
{
public:
	// System.String Org.BouncyCastle.Crypto.Tls.ExporterLabel::extended_master_secret
	String_t* ___extended_master_secret_8;

public:
	inline static int32_t get_offset_of_extended_master_secret_8() { return static_cast<int32_t>(offsetof(ExporterLabel_t839268261_StaticFields, ___extended_master_secret_8)); }
	inline String_t* get_extended_master_secret_8() const { return ___extended_master_secret_8; }
	inline String_t** get_address_of_extended_master_secret_8() { return &___extended_master_secret_8; }
	inline void set_extended_master_secret_8(String_t* value)
	{
		___extended_master_secret_8 = value;
		Il2CppCodeGenWriteBarrier(&___extended_master_secret_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
