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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.CryptoPro.Gost3410ParamSetParameters
struct  Gost3410ParamSetParameters_t2624318576  : public Asn1Encodable_t3447851422
{
public:
	// System.Int32 Org.BouncyCastle.Asn1.CryptoPro.Gost3410ParamSetParameters::keySize
	int32_t ___keySize_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.CryptoPro.Gost3410ParamSetParameters::p
	DerInteger_t967720487 * ___p_3;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.CryptoPro.Gost3410ParamSetParameters::q
	DerInteger_t967720487 * ___q_4;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.CryptoPro.Gost3410ParamSetParameters::a
	DerInteger_t967720487 * ___a_5;

public:
	inline static int32_t get_offset_of_keySize_2() { return static_cast<int32_t>(offsetof(Gost3410ParamSetParameters_t2624318576, ___keySize_2)); }
	inline int32_t get_keySize_2() const { return ___keySize_2; }
	inline int32_t* get_address_of_keySize_2() { return &___keySize_2; }
	inline void set_keySize_2(int32_t value)
	{
		___keySize_2 = value;
	}

	inline static int32_t get_offset_of_p_3() { return static_cast<int32_t>(offsetof(Gost3410ParamSetParameters_t2624318576, ___p_3)); }
	inline DerInteger_t967720487 * get_p_3() const { return ___p_3; }
	inline DerInteger_t967720487 ** get_address_of_p_3() { return &___p_3; }
	inline void set_p_3(DerInteger_t967720487 * value)
	{
		___p_3 = value;
		Il2CppCodeGenWriteBarrier(&___p_3, value);
	}

	inline static int32_t get_offset_of_q_4() { return static_cast<int32_t>(offsetof(Gost3410ParamSetParameters_t2624318576, ___q_4)); }
	inline DerInteger_t967720487 * get_q_4() const { return ___q_4; }
	inline DerInteger_t967720487 ** get_address_of_q_4() { return &___q_4; }
	inline void set_q_4(DerInteger_t967720487 * value)
	{
		___q_4 = value;
		Il2CppCodeGenWriteBarrier(&___q_4, value);
	}

	inline static int32_t get_offset_of_a_5() { return static_cast<int32_t>(offsetof(Gost3410ParamSetParameters_t2624318576, ___a_5)); }
	inline DerInteger_t967720487 * get_a_5() const { return ___a_5; }
	inline DerInteger_t967720487 ** get_address_of_a_5() { return &___a_5; }
	inline void set_a_5(DerInteger_t967720487 * value)
	{
		___a_5 = value;
		Il2CppCodeGenWriteBarrier(&___a_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
