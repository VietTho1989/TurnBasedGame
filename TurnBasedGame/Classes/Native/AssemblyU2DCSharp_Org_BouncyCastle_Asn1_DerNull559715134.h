#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Null813671072.h"

// Org.BouncyCastle.Asn1.DerNull
struct DerNull_t559715134;
// System.Byte[]
struct ByteU5BU5D_t3397334013;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.DerNull
struct  DerNull_t559715134  : public Asn1Null_t813671072
{
public:
	// System.Byte[] Org.BouncyCastle.Asn1.DerNull::zeroBytes
	ByteU5BU5D_t3397334013* ___zeroBytes_3;

public:
	inline static int32_t get_offset_of_zeroBytes_3() { return static_cast<int32_t>(offsetof(DerNull_t559715134, ___zeroBytes_3)); }
	inline ByteU5BU5D_t3397334013* get_zeroBytes_3() const { return ___zeroBytes_3; }
	inline ByteU5BU5D_t3397334013** get_address_of_zeroBytes_3() { return &___zeroBytes_3; }
	inline void set_zeroBytes_3(ByteU5BU5D_t3397334013* value)
	{
		___zeroBytes_3 = value;
		Il2CppCodeGenWriteBarrier(&___zeroBytes_3, value);
	}
};

struct DerNull_t559715134_StaticFields
{
public:
	// Org.BouncyCastle.Asn1.DerNull Org.BouncyCastle.Asn1.DerNull::Instance
	DerNull_t559715134 * ___Instance_2;

public:
	inline static int32_t get_offset_of_Instance_2() { return static_cast<int32_t>(offsetof(DerNull_t559715134_StaticFields, ___Instance_2)); }
	inline DerNull_t559715134 * get_Instance_2() const { return ___Instance_2; }
	inline DerNull_t559715134 ** get_address_of_Instance_2() { return &___Instance_2; }
	inline void set_Instance_2(DerNull_t559715134 * value)
	{
		___Instance_2 = value;
		Il2CppCodeGenWriteBarrier(&___Instance_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
