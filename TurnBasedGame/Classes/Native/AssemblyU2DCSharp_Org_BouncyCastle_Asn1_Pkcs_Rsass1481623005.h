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
// Org.BouncyCastle.Asn1.DerInteger
struct DerInteger_t967720487;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters
struct  RsassaPssParameters_t1481623005  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::hashAlgorithm
	AlgorithmIdentifier_t2670781410 * ___hashAlgorithm_2;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::maskGenAlgorithm
	AlgorithmIdentifier_t2670781410 * ___maskGenAlgorithm_3;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::saltLength
	DerInteger_t967720487 * ___saltLength_4;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::trailerField
	DerInteger_t967720487 * ___trailerField_5;

public:
	inline static int32_t get_offset_of_hashAlgorithm_2() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005, ___hashAlgorithm_2)); }
	inline AlgorithmIdentifier_t2670781410 * get_hashAlgorithm_2() const { return ___hashAlgorithm_2; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_hashAlgorithm_2() { return &___hashAlgorithm_2; }
	inline void set_hashAlgorithm_2(AlgorithmIdentifier_t2670781410 * value)
	{
		___hashAlgorithm_2 = value;
		Il2CppCodeGenWriteBarrier(&___hashAlgorithm_2, value);
	}

	inline static int32_t get_offset_of_maskGenAlgorithm_3() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005, ___maskGenAlgorithm_3)); }
	inline AlgorithmIdentifier_t2670781410 * get_maskGenAlgorithm_3() const { return ___maskGenAlgorithm_3; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_maskGenAlgorithm_3() { return &___maskGenAlgorithm_3; }
	inline void set_maskGenAlgorithm_3(AlgorithmIdentifier_t2670781410 * value)
	{
		___maskGenAlgorithm_3 = value;
		Il2CppCodeGenWriteBarrier(&___maskGenAlgorithm_3, value);
	}

	inline static int32_t get_offset_of_saltLength_4() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005, ___saltLength_4)); }
	inline DerInteger_t967720487 * get_saltLength_4() const { return ___saltLength_4; }
	inline DerInteger_t967720487 ** get_address_of_saltLength_4() { return &___saltLength_4; }
	inline void set_saltLength_4(DerInteger_t967720487 * value)
	{
		___saltLength_4 = value;
		Il2CppCodeGenWriteBarrier(&___saltLength_4, value);
	}

	inline static int32_t get_offset_of_trailerField_5() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005, ___trailerField_5)); }
	inline DerInteger_t967720487 * get_trailerField_5() const { return ___trailerField_5; }
	inline DerInteger_t967720487 ** get_address_of_trailerField_5() { return &___trailerField_5; }
	inline void set_trailerField_5(DerInteger_t967720487 * value)
	{
		___trailerField_5 = value;
		Il2CppCodeGenWriteBarrier(&___trailerField_5, value);
	}
};

struct RsassaPssParameters_t1481623005_StaticFields
{
public:
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::DefaultHashAlgorithm
	AlgorithmIdentifier_t2670781410 * ___DefaultHashAlgorithm_6;
	// Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::DefaultMaskGenFunction
	AlgorithmIdentifier_t2670781410 * ___DefaultMaskGenFunction_7;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::DefaultSaltLength
	DerInteger_t967720487 * ___DefaultSaltLength_8;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.RsassaPssParameters::DefaultTrailerField
	DerInteger_t967720487 * ___DefaultTrailerField_9;

public:
	inline static int32_t get_offset_of_DefaultHashAlgorithm_6() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005_StaticFields, ___DefaultHashAlgorithm_6)); }
	inline AlgorithmIdentifier_t2670781410 * get_DefaultHashAlgorithm_6() const { return ___DefaultHashAlgorithm_6; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_DefaultHashAlgorithm_6() { return &___DefaultHashAlgorithm_6; }
	inline void set_DefaultHashAlgorithm_6(AlgorithmIdentifier_t2670781410 * value)
	{
		___DefaultHashAlgorithm_6 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultHashAlgorithm_6, value);
	}

	inline static int32_t get_offset_of_DefaultMaskGenFunction_7() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005_StaticFields, ___DefaultMaskGenFunction_7)); }
	inline AlgorithmIdentifier_t2670781410 * get_DefaultMaskGenFunction_7() const { return ___DefaultMaskGenFunction_7; }
	inline AlgorithmIdentifier_t2670781410 ** get_address_of_DefaultMaskGenFunction_7() { return &___DefaultMaskGenFunction_7; }
	inline void set_DefaultMaskGenFunction_7(AlgorithmIdentifier_t2670781410 * value)
	{
		___DefaultMaskGenFunction_7 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultMaskGenFunction_7, value);
	}

	inline static int32_t get_offset_of_DefaultSaltLength_8() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005_StaticFields, ___DefaultSaltLength_8)); }
	inline DerInteger_t967720487 * get_DefaultSaltLength_8() const { return ___DefaultSaltLength_8; }
	inline DerInteger_t967720487 ** get_address_of_DefaultSaltLength_8() { return &___DefaultSaltLength_8; }
	inline void set_DefaultSaltLength_8(DerInteger_t967720487 * value)
	{
		___DefaultSaltLength_8 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultSaltLength_8, value);
	}

	inline static int32_t get_offset_of_DefaultTrailerField_9() { return static_cast<int32_t>(offsetof(RsassaPssParameters_t1481623005_StaticFields, ___DefaultTrailerField_9)); }
	inline DerInteger_t967720487 * get_DefaultTrailerField_9() const { return ___DefaultTrailerField_9; }
	inline DerInteger_t967720487 ** get_address_of_DefaultTrailerField_9() { return &___DefaultTrailerField_9; }
	inline void set_DefaultTrailerField_9(DerInteger_t967720487 * value)
	{
		___DefaultTrailerField_9 = value;
		Il2CppCodeGenWriteBarrier(&___DefaultTrailerField_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
