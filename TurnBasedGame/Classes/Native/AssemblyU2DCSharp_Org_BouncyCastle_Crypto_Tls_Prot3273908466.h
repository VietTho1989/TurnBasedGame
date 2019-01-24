#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Crypto.Tls.ProtocolVersion
struct ProtocolVersion_t3273908466;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Tls.ProtocolVersion
struct  ProtocolVersion_t3273908466  : public Il2CppObject
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Tls.ProtocolVersion::version
	int32_t ___version_6;
	// System.String Org.BouncyCastle.Crypto.Tls.ProtocolVersion::name
	String_t* ___name_7;

public:
	inline static int32_t get_offset_of_version_6() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466, ___version_6)); }
	inline int32_t get_version_6() const { return ___version_6; }
	inline int32_t* get_address_of_version_6() { return &___version_6; }
	inline void set_version_6(int32_t value)
	{
		___version_6 = value;
	}

	inline static int32_t get_offset_of_name_7() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466, ___name_7)); }
	inline String_t* get_name_7() const { return ___name_7; }
	inline String_t** get_address_of_name_7() { return &___name_7; }
	inline void set_name_7(String_t* value)
	{
		___name_7 = value;
		Il2CppCodeGenWriteBarrier(&___name_7, value);
	}
};

struct ProtocolVersion_t3273908466_StaticFields
{
public:
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.ProtocolVersion::SSLv3
	ProtocolVersion_t3273908466 * ___SSLv3_0;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.ProtocolVersion::TLSv10
	ProtocolVersion_t3273908466 * ___TLSv10_1;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.ProtocolVersion::TLSv11
	ProtocolVersion_t3273908466 * ___TLSv11_2;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.ProtocolVersion::TLSv12
	ProtocolVersion_t3273908466 * ___TLSv12_3;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.ProtocolVersion::DTLSv10
	ProtocolVersion_t3273908466 * ___DTLSv10_4;
	// Org.BouncyCastle.Crypto.Tls.ProtocolVersion Org.BouncyCastle.Crypto.Tls.ProtocolVersion::DTLSv12
	ProtocolVersion_t3273908466 * ___DTLSv12_5;

public:
	inline static int32_t get_offset_of_SSLv3_0() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466_StaticFields, ___SSLv3_0)); }
	inline ProtocolVersion_t3273908466 * get_SSLv3_0() const { return ___SSLv3_0; }
	inline ProtocolVersion_t3273908466 ** get_address_of_SSLv3_0() { return &___SSLv3_0; }
	inline void set_SSLv3_0(ProtocolVersion_t3273908466 * value)
	{
		___SSLv3_0 = value;
		Il2CppCodeGenWriteBarrier(&___SSLv3_0, value);
	}

	inline static int32_t get_offset_of_TLSv10_1() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466_StaticFields, ___TLSv10_1)); }
	inline ProtocolVersion_t3273908466 * get_TLSv10_1() const { return ___TLSv10_1; }
	inline ProtocolVersion_t3273908466 ** get_address_of_TLSv10_1() { return &___TLSv10_1; }
	inline void set_TLSv10_1(ProtocolVersion_t3273908466 * value)
	{
		___TLSv10_1 = value;
		Il2CppCodeGenWriteBarrier(&___TLSv10_1, value);
	}

	inline static int32_t get_offset_of_TLSv11_2() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466_StaticFields, ___TLSv11_2)); }
	inline ProtocolVersion_t3273908466 * get_TLSv11_2() const { return ___TLSv11_2; }
	inline ProtocolVersion_t3273908466 ** get_address_of_TLSv11_2() { return &___TLSv11_2; }
	inline void set_TLSv11_2(ProtocolVersion_t3273908466 * value)
	{
		___TLSv11_2 = value;
		Il2CppCodeGenWriteBarrier(&___TLSv11_2, value);
	}

	inline static int32_t get_offset_of_TLSv12_3() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466_StaticFields, ___TLSv12_3)); }
	inline ProtocolVersion_t3273908466 * get_TLSv12_3() const { return ___TLSv12_3; }
	inline ProtocolVersion_t3273908466 ** get_address_of_TLSv12_3() { return &___TLSv12_3; }
	inline void set_TLSv12_3(ProtocolVersion_t3273908466 * value)
	{
		___TLSv12_3 = value;
		Il2CppCodeGenWriteBarrier(&___TLSv12_3, value);
	}

	inline static int32_t get_offset_of_DTLSv10_4() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466_StaticFields, ___DTLSv10_4)); }
	inline ProtocolVersion_t3273908466 * get_DTLSv10_4() const { return ___DTLSv10_4; }
	inline ProtocolVersion_t3273908466 ** get_address_of_DTLSv10_4() { return &___DTLSv10_4; }
	inline void set_DTLSv10_4(ProtocolVersion_t3273908466 * value)
	{
		___DTLSv10_4 = value;
		Il2CppCodeGenWriteBarrier(&___DTLSv10_4, value);
	}

	inline static int32_t get_offset_of_DTLSv12_5() { return static_cast<int32_t>(offsetof(ProtocolVersion_t3273908466_StaticFields, ___DTLSv12_5)); }
	inline ProtocolVersion_t3273908466 * get_DTLSv12_5() const { return ___DTLSv12_5; }
	inline ProtocolVersion_t3273908466 ** get_address_of_DTLSv12_5() { return &___DTLSv12_5; }
	inline void set_DTLSv12_5(ProtocolVersion_t3273908466 * value)
	{
		___DTLSv12_5 = value;
		Il2CppCodeGenWriteBarrier(&___DTLSv12_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
