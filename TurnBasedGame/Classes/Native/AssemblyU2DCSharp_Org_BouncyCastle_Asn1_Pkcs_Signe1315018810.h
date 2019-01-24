#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;
// Org.BouncyCastle.Asn1.Asn1Set
struct Asn1Set_t2420705913;
// Org.BouncyCastle.Asn1.Pkcs.ContentInfo
struct ContentInfo_t1565361645;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Pkcs.SignedData
struct  SignedData_t1315018810  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.SignedData::version
	DerInteger_t967720487 * ___version_2;
	// Org.BouncyCastle.Asn1.Asn1Set Org.BouncyCastle.Asn1.Pkcs.SignedData::digestAlgorithms
	Asn1Set_t2420705913 * ___digestAlgorithms_3;
	// Org.BouncyCastle.Asn1.Pkcs.ContentInfo Org.BouncyCastle.Asn1.Pkcs.SignedData::contentInfo
	ContentInfo_t1565361645 * ___contentInfo_4;
	// Org.BouncyCastle.Asn1.Asn1Set Org.BouncyCastle.Asn1.Pkcs.SignedData::certificates
	Asn1Set_t2420705913 * ___certificates_5;
	// Org.BouncyCastle.Asn1.Asn1Set Org.BouncyCastle.Asn1.Pkcs.SignedData::crls
	Asn1Set_t2420705913 * ___crls_6;
	// Org.BouncyCastle.Asn1.Asn1Set Org.BouncyCastle.Asn1.Pkcs.SignedData::signerInfos
	Asn1Set_t2420705913 * ___signerInfos_7;

public:
	inline static int32_t get_offset_of_version_2() { return static_cast<int32_t>(offsetof(SignedData_t1315018810, ___version_2)); }
	inline DerInteger_t967720487 * get_version_2() const { return ___version_2; }
	inline DerInteger_t967720487 ** get_address_of_version_2() { return &___version_2; }
	inline void set_version_2(DerInteger_t967720487 * value)
	{
		___version_2 = value;
		Il2CppCodeGenWriteBarrier(&___version_2, value);
	}

	inline static int32_t get_offset_of_digestAlgorithms_3() { return static_cast<int32_t>(offsetof(SignedData_t1315018810, ___digestAlgorithms_3)); }
	inline Asn1Set_t2420705913 * get_digestAlgorithms_3() const { return ___digestAlgorithms_3; }
	inline Asn1Set_t2420705913 ** get_address_of_digestAlgorithms_3() { return &___digestAlgorithms_3; }
	inline void set_digestAlgorithms_3(Asn1Set_t2420705913 * value)
	{
		___digestAlgorithms_3 = value;
		Il2CppCodeGenWriteBarrier(&___digestAlgorithms_3, value);
	}

	inline static int32_t get_offset_of_contentInfo_4() { return static_cast<int32_t>(offsetof(SignedData_t1315018810, ___contentInfo_4)); }
	inline ContentInfo_t1565361645 * get_contentInfo_4() const { return ___contentInfo_4; }
	inline ContentInfo_t1565361645 ** get_address_of_contentInfo_4() { return &___contentInfo_4; }
	inline void set_contentInfo_4(ContentInfo_t1565361645 * value)
	{
		___contentInfo_4 = value;
		Il2CppCodeGenWriteBarrier(&___contentInfo_4, value);
	}

	inline static int32_t get_offset_of_certificates_5() { return static_cast<int32_t>(offsetof(SignedData_t1315018810, ___certificates_5)); }
	inline Asn1Set_t2420705913 * get_certificates_5() const { return ___certificates_5; }
	inline Asn1Set_t2420705913 ** get_address_of_certificates_5() { return &___certificates_5; }
	inline void set_certificates_5(Asn1Set_t2420705913 * value)
	{
		___certificates_5 = value;
		Il2CppCodeGenWriteBarrier(&___certificates_5, value);
	}

	inline static int32_t get_offset_of_crls_6() { return static_cast<int32_t>(offsetof(SignedData_t1315018810, ___crls_6)); }
	inline Asn1Set_t2420705913 * get_crls_6() const { return ___crls_6; }
	inline Asn1Set_t2420705913 ** get_address_of_crls_6() { return &___crls_6; }
	inline void set_crls_6(Asn1Set_t2420705913 * value)
	{
		___crls_6 = value;
		Il2CppCodeGenWriteBarrier(&___crls_6, value);
	}

	inline static int32_t get_offset_of_signerInfos_7() { return static_cast<int32_t>(offsetof(SignedData_t1315018810, ___signerInfos_7)); }
	inline Asn1Set_t2420705913 * get_signerInfos_7() const { return ___signerInfos_7; }
	inline Asn1Set_t2420705913 ** get_address_of_signerInfos_7() { return &___signerInfos_7; }
	inline void set_signerInfos_7(Asn1Set_t2420705913 * value)
	{
		___signerInfos_7 = value;
		Il2CppCodeGenWriteBarrier(&___signerInfos_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
