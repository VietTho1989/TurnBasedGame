#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.X509.TbsCertificateList
struct TbsCertificateList_t741385336;
// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct AlgorithmIdentifier_t2670781410;
// Org.BouncyCastle.Asn1.DerBitString
struct DerBitString_t2717907355;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.CertificateList
struct  CertificateList_t2288802675  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.TbsCertificateList Org.BouncyCastle.Asn1.X509.CertificateList::tbsCertList
	TbsCertificateList_t741385336 * ___tbsCertList_2;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.X509.CertificateList::sigAlgID
	AlgorithmIdentifier_t2670781410 * ___sigAlgID_3;
	// Org.BouncyCastle.Asn1.DerBitString Org.BouncyCastle.Asn1.X509.CertificateList::sig
	DerBitString_t2717907355 * ___sig_4;

public:
	inline static int32_t get_offset_of_tbsCertList_2() { return static_cast<int32_t>(offsetof(CertificateList_t2288802675, ___tbsCertList_2)); }
	inline TbsCertificateList_t741385336 * get_tbsCertList_2() const { return ___tbsCertList_2; }
	inline TbsCertificateList_t741385336 ** get_address_of_tbsCertList_2() { return &___tbsCertList_2; }
	inline void set_tbsCertList_2(TbsCertificateList_t741385336 * value)
	{
		___tbsCertList_2 = value;
		Il2CppCodeGenWriteBarrier(&___tbsCertList_2, value);
	}

	inline static int32_t get_offset_of_sigAlgID_3() { return static_cast<int32_t>(offsetof(CertificateList_t2288802675, ___sigAlgID_3)); }
	inline AlgorithmIdentifier_t2670781410 * get_sigAlgID_3() const { return ___sigAlgID_3; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_sigAlgID_3() { return &___sigAlgID_3; }
	inline void set_sigAlgID_3(AlgorithmIdentifier_t2670781410 * value)
	{
		___sigAlgID_3 = value;
		Il2CppCodeGenWriteBarrier(&___sigAlgID_3, value);
	}

	inline static int32_t get_offset_of_sig_4() { return static_cast<int32_t>(offsetof(CertificateList_t2288802675, ___sig_4)); }
	inline DerBitString_t2717907355 * get_sig_4() const { return ___sig_4; }
	inline DerBitString_t2717907355 ** get_address_of_sig_4() { return &___sig_4; }
	inline void set_sig_4(DerBitString_t2717907355 * value)
	{
		___sig_4 = value;
		Il2CppCodeGenWriteBarrier(&___sig_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
