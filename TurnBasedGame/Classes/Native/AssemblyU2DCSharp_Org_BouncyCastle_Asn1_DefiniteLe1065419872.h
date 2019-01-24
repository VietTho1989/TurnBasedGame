#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_LimitedInpu781897436.h"

// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DefiniteLengthInputStream
struct  DefiniteLengthInputStream_t1065419872  : public LimitedInputStream_t781897436
{
public:
	// System.Int32 Org.BouncyCastle.Asn1.DefiniteLengthInputStream::_originalLength
	int32_t ____originalLength_6;
	// System.Int32 Org.BouncyCastle.Asn1.DefiniteLengthInputStream::_remaining
	int32_t ____remaining_7;

public:
	inline static int32_t get_offset_of__originalLength_6() { return static_cast<int32_t>(offsetof(DefiniteLengthInputStream_t1065419872, ____originalLength_6)); }
	inline int32_t get__originalLength_6() const { return ____originalLength_6; }
	inline int32_t* get_address_of__originalLength_6() { return &____originalLength_6; }
	inline void set__originalLength_6(int32_t value)
	{
		____originalLength_6 = value;
	}

	inline static int32_t get_offset_of__remaining_7() { return static_cast<int32_t>(offsetof(DefiniteLengthInputStream_t1065419872, ____remaining_7)); }
	inline int32_t get__remaining_7() const { return ____remaining_7; }
	inline int32_t* get_address_of__remaining_7() { return &____remaining_7; }
	inline void set__remaining_7(int32_t value)
	{
		____remaining_7 = value;
	}
};

struct DefiniteLengthInputStream_t1065419872_StaticFields
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.DefiniteLengthInputStream::EmptyBytes
	ByteU5BU5D_t3397334013* ___EmptyBytes_5;

public:
	inline static int32_t get_offset_of_EmptyBytes_5() { return static_cast<int32_t>(offsetof(DefiniteLengthInputStream_t1065419872_StaticFields, ___EmptyBytes_5)); }
	inline ByteU5BU5D_t3397334013* get_EmptyBytes_5() const { return ___EmptyBytes_5; }
	inline ByteU5BU5D_t3397334013** get_address_of_EmptyBytes_5() { return &___EmptyBytes_5; }
	inline void set_EmptyBytes_5(ByteU5BU5D_t3397334013* value)
	{
		___EmptyBytes_5 = value;
		Il2CppCodeGenWriteBarrier(&___EmptyBytes_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
