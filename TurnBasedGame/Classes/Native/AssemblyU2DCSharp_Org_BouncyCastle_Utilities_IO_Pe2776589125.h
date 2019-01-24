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

// Org.BouncyCastle.Utilities.IO.Pem.PemHeader
struct  PemHeader_t2776589125  : public Il2CppObject
{
public:
	// System.String Org.BouncyCastle.Utilities.IO.Pem.PemHeader::name
	String_t* ___name_0;
	// System.String Org.BouncyCastle.Utilities.IO.Pem.PemHeader::val
	String_t* ___val_1;

public:
	inline static int32_t get_offset_of_name_0() { return static_cast<int32_t>(offsetof(PemHeader_t2776589125, ___name_0)); }
	inline String_t* get_name_0() const { return ___name_0; }
	inline String_t** get_address_of_name_0() { return &___name_0; }
	inline void set_name_0(String_t* value)
	{
		___name_0 = value;
		Il2CppCodeGenWriteBarrier(&___name_0, value);
	}

	inline static int32_t get_offset_of_val_1() { return static_cast<int32_t>(offsetof(PemHeader_t2776589125, ___val_1)); }
	inline String_t* get_val_1() const { return ___val_1; }
	inline String_t** get_address_of_val_1() { return &___val_1; }
	inline void set_val_1(String_t* value)
	{
		___val_1 = value;
		Il2CppCodeGenWriteBarrier(&___val_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
