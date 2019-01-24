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

// Org.BouncyCastle.Asn1.DerBitString
struct  DerBitString_t2717907355  : public DerStringBase_t1343648701
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.DerBitString::data
	ByteU5BU5D_t3397334013* ___data_3;
	// System.Int32 Org.BouncyCastle.Asn1.DerBitString::padBits
	int32_t ___padBits_4;

public:
	inline static int32_t get_offset_of_data_3() { return static_cast<int32_t>(offsetof(DerBitString_t2717907355, ___data_3)); }
	inline ByteU5BU5D_t3397334013* get_data_3() const { return ___data_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_data_3() { return &___data_3; }
	inline void set_data_3(ByteU5BU5D_t3397334013* value)
	{
		___data_3 = value;
		Il2CppCodeGenWriteBarrier(&___data_3, value);
	}

	inline static int32_t get_offset_of_padBits_4() { return static_cast<int32_t>(offsetof(DerBitString_t2717907355, ___padBits_4)); }
	inline int32_t get_padBits_4() const { return ___padBits_4; }
	inline int32_t* get_address_of_padBits_4() { return &___padBits_4; }
	inline void set_padBits_4(int32_t value)
	{
		___padBits_4 = value;
	}
};

struct DerBitString_t2717907355_StaticFields
{
public:
	// System.Char[] Org.BouncyCastle.Asn1.DerBitString::table
	CharU5BU5D_t1328083999* ___table_2;

public:
	inline static int32_t get_offset_of_table_2() { return static_cast<int32_t>(offsetof(DerBitString_t2717907355_StaticFields, ___table_2)); }
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
