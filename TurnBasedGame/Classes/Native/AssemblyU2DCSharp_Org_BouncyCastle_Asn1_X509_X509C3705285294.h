#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Asn1_Asn1Encoda3447851422.h"

// Org.BouncyCastle.Asn1.X509.TbsCertificateStructure
struct TbsCertificateStructure_t1391133771;
// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier
struct AlgorithmIdentifier_t2670781410;
// Org.BouncyCastle.Asn1.DerBitString
struct DerBitString_t2717907355;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X509.X509CertificateStructure
struct  X509CertificateStructure_t3705285294  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.TbsCertificateStructure Org.BouncyCastle.Asn1.X509.X509CertificateStructure::tbsCert
	TbsCertificateStructure_t1391133771 * ___tbsCert_2;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.X509.X509CertificateStructure::sigAlgID
	AlgorithmIdentifier_t2670781410 * ___sigAlgID_3;
	// Org.BouncyCastle.Asn1.DerBitString Org.BouncyCastle.Asn1.X509.X509CertificateStructure::sig
	DerBitString_t2717907355 * ___sig_4;

public:
	inline static int32_t get_offset_of_tbsCert_2() { return static_cast<int32_t>(offsetof(X509CertificateStructure_t3705285294, ___tbsCert_2)); }
	inline TbsCertificateStructure_t1391133771 * get_tbsCert_2() const { return ___tbsCert_2; }
	inline TbsCertificateStructure_t1391133771 ** get_address_of_tbsCert_2() { return &___tbsCert_2; }
	inline void set_tbsCert_2(TbsCertificateStructure_t1391133771 * value)
	{
		___tbsCert_2 = value;
		Il2CppCodeGenWriteBarrier(&___tbsCert_2, value);
	}

	inline static int32_t get_offset_of_sigAlgID_3() { return static_cast<int32_t>(offsetof(X509CertificateStructure_t3705285294, ___sigAlgID_3)); }
	inline AlgorithmIdentifier_t2670781410 * get_sigAlgID_3() const { return ___sigAlgID_3; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_sigAlgID_3() { return &___sigAlgID_3; }
	inline void set_sigAlgID_3(AlgorithmIdentifier_t2670781410 * value)
	{
		___sigAlgID_3 = value;
		Il2CppCodeGenWriteBarrier(&___sigAlgID_3, value);
	}

	inline static int32_t get_offset_of_sig_4() { return static_cast<int32_t>(offsetof(X509CertificateStructure_t3705285294, ___sig_4)); }
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
