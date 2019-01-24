#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct AlgorithmIdentifier_t2670781410;
// Org.BouncyCastle.Asn1.DerBitString
struct DerBitString_t2717907355;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo
struct  SubjectPublicKeyInfo_t3547422518  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo::algID
	AlgorithmIdentifier_t2670781410 * ___algID_2;
	// Org.BouncyCastle.Asn1.DerBitString Org.BouncyCastle.Asn1.X509.SubjectPublicKeyInfo::keyData
	DerBitString_t2717907355 * ___keyData_3;

public:
	inline static int32_t get_offset_of_algID_2() { return static_cast<int32_t>(offsetof(SubjectPublicKeyInfo_t3547422518, ___algID_2)); }
	inline AlgorithmIdentifier_t2670781410 * get_algID_2() const { return ___algID_2; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_algID_2() { return &___algID_2; }
	inline void set_algID_2(AlgorithmIdentifier_t2670781410 * value)
	{
		___algID_2 = value;
		Il2CppCodeGenWriteBarrier(&___algID_2, value);
	}

	inline static int32_t get_offset_of_keyData_3() { return static_cast<int32_t>(offsetof(SubjectPublicKeyInfo_t3547422518, ___keyData_3)); }
	inline DerBitString_t2717907355 * get_keyData_3() const { return ___keyData_3; }
	inline DerBitString_t2717907355 ** get_address_of_keyData_3() { return &___keyData_3; }
	inline void set_keyData_3(DerBitString_t2717907355 * value)
	{
		___keyData_3 = value;
		Il2CppCodeGenWriteBarrier(&___keyData_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
