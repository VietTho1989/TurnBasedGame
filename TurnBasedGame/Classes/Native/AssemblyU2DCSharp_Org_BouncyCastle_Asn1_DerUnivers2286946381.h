#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_DerStringB1343648701.h"

// System.Char[]
struct CharU5BU5D_t1328083999;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerUniversalString
struct  DerUniversalString_t2286946381  : public DerStringBase_t1343648701
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.DerUniversalString::str
	ByteU5BU5D_t3397334013* ___str_3;

public:
	inline static int32_t get_offset_of_str_3() { return static_cast<int32_t>(offsetof(DerUniversalString_t2286946381, ___str_3)); }
	inline ByteU5BU5D_t3397334013* get_str_3() const { return ___str_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_str_3() { return &___str_3; }
	inline void set_str_3(ByteU5BU5D_t3397334013* value)
	{
		___str_3 = value;
		Il2CppCodeGenWriteBarrier(&___str_3, value);
	}
};

struct DerUniversalString_t2286946381_StaticFields
{
public:
	// System.Char[] Org.BouncyCastle.Asn1.DerUniversalString::table
	CharU5BU5D_t1328083999* ___table_2;

public:
	inline static int32_t get_offset_of_table_2() { return static_cast<int32_t>(offsetof(DerUniversalString_t2286946381_StaticFields, ___table_2)); }
	inline CharU5BU5D_t1328083999* get_table_2() const { return ___table_2; }
	inline CharU5BU5D_t1328083999** get_address_of_table_2() { return &___table_2; }
	inline void set_table_2(CharU5BU5D_t1328083999* value)
	{
		___table_2 = value;
		Il2CppCodeGenWriteBarrier(&___table_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
