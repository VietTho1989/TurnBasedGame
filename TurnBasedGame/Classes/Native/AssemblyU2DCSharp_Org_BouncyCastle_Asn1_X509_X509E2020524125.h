#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Asn1.Asn1OctetString
struct Asn1OctetString_t1486532927;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.X509Extension
struct  X509Extension_t2020524125  : public Il2CppObject
{
public:
	// System.Boolean Org.BouncyCastle.Asn1.X509.X509Extension::critical
	bool ___critical_0;
	// Org.BouncyCastle.Asn1.Asn1OctetString Org.BouncyCastle.Asn1.X509.X509Extension::value
	Asn1OctetString_t1486532927 * ___value_1;

public:
	inline static int32_t get_offset_of_critical_0() { return static_cast<int32_t>(offsetof(X509Extension_t2020524125, ___critical_0)); }
	inline bool get_critical_0() const { return ___critical_0; }
	inline bool* get_address_of_critical_0() { return &___critical_0; }
	inline void set_critical_0(bool value)
	{
		___critical_0 = value;
	}

	inline static int32_t get_offset_of_value_1() { return static_cast<int32_t>(offsetof(X509Extension_t2020524125, ___value_1)); }
	inline Asn1OctetString_t1486532927 * get_value_1() const { return ___value_1; }
	inline Asn1OctetString_t1486532927 ** get_address_of_value_1() { return &___value_1; }
	inline void set_value_1(Asn1OctetString_t1486532927 * value)
	{
		___value_1 = value;
		Il2CppCodeGenWriteBarrier(&___value_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
