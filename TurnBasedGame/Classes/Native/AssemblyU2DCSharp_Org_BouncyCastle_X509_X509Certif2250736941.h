#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_X509_X509Extens1429324694.h"

// Org.BouncyCastle.Asn1.X509.X509CertificateStructure
struct X509CertificateStructure_t3705285294;
// Org.BouncyCastle.Asn1.X509.BasicConstraints
struct BasicConstraints_t3459049714;
// System.Boolean[]
struct BooleanU5BU5D_t3568034315;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.X509.X509Certificate
struct  X509Certificate_t2250736941  : public X509ExtensionBase_t1429324694
{
public:
	// Org.BouncyCastle.Asn1.X509.X509CertificateStructure Org.BouncyCastle.X509.X509Certificate::c
	X509CertificateStructure_t3705285294 * ___c_0;
	// Org.BouncyCastle.Asn1.X509.BasicConstraints Org.BouncyCastle.X509.X509Certificate::basicConstraints
	BasicConstraints_t3459049714 * ___basicConstraints_1;
	// System.Boolean[] Org.BouncyCastle.X509.X509Certificate::keyUsage
	BooleanU5BU5D_t3568034315* ___keyUsage_2;
	// System.Boolean Org.BouncyCastle.X509.X509Certificate::hashValueSet
	bool ___hashValueSet_3;
	// System.Int32 Org.BouncyCastle.X509.X509Certificate::hashValue
	int32_t ___hashValue_4;

public:
	inline static int32_t get_offset_of_c_0() { return static_cast<int32_t>(offsetof(X509Certificate_t2250736941, ___c_0)); }
	inline X509CertificateStructure_t3705285294 * get_c_0() const { return ___c_0; }
	inline X509CertificateStructure_t3705285294 ** get_address_of_c_0() { return &___c_0; }
	inline void set_c_0(X509CertificateStructure_t3705285294 * value)
	{
		___c_0 = value;
		Il2CppCodeGenWriteBarrier(&___c_0, value);
	}

	inline static int32_t get_offset_of_basicConstraints_1() { return static_cast<int32_t>(offsetof(X509Certificate_t2250736941, ___basicConstraints_1)); }
	inline BasicConstraints_t3459049714 * get_basicConstraints_1() const { return ___basicConstraints_1; }
	inline BasicConstraints_t3459049714 ** get_address_of_basicConstraints_1() { return &___basicConstraints_1; }
	inline void set_basicConstraints_1(BasicConstraints_t3459049714 * value)
	{
		___basicConstraints_1 = value;
		Il2CppCodeGenWriteBarrier(&___basicConstraints_1, value);
	}

	inline static int32_t get_offset_of_keyUsage_2() { return static_cast<int32_t>(offsetof(X509Certificate_t2250736941, ___keyUsage_2)); }
	inline BooleanU5BU5D_t3568034315* get_keyUsage_2() const { return ___keyUsage_2; }
	inline BooleanU5BU5D_t3568034315** get_address_of_keyUsage_2() { return &___keyUsage_2; }
	inline void set_keyUsage_2(BooleanU5BU5D_t3568034315* value)
	{
		___keyUsage_2 = value;
		Il2CppCodeGenWriteBarrier(&___keyUsage_2, value);
	}

	inline static int32_t get_offset_of_hashValueSet_3() { return static_cast<int32_t>(offsetof(X509Certificate_t2250736941, ___hashValueSet_3)); }
	inline bool get_hashValueSet_3() const { return ___hashValueSet_3; }
	inline bool* get_address_of_hashValueSet_3() { return &___hashValueSet_3; }
	inline void set_hashValueSet_3(bool value)
	{
		___hashValueSet_3 = value;
	}

	inline static int32_t get_offset_of_hashValue_4() { return static_cast<int32_t>(offsetof(X509Certificate_t2250736941, ___hashValue_4)); }
	inline int32_t get_hashValue_4() const { return ___hashValue_4; }
	inline int32_t* get_address_of_hashValue_4() { return &___hashValue_4; }
	inline void set_hashValue_4(int32_t value)
	{
		___hashValue_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
