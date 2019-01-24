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

// Org.BouncyCastle.Asn1.X509.DsaParameter
struct  DsaParameter_t274855281  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.DsaParameter::p
	DerInteger_t967720487 * ___p_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.DsaParameter::q
	DerInteger_t967720487 * ___q_3;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X509.DsaParameter::g
	DerInteger_t967720487 * ___g_4;

public:
	inline static int32_t get_offset_of_p_2() { return static_cast<int32_t>(offsetof(DsaParameter_t274855281, ___p_2)); }
	inline DerInteger_t967720487 * get_p_2() const { return ___p_2; }
	inline DerInteger_t967720487 ** get_address_of_p_2() { return &___p_2; }
	inline void set_p_2(DerInteger_t967720487 * value)
	{
		___p_2 = value;
		Il2CppCodeGenWriteBarrier(&___p_2, value);
	}

	inline static int32_t get_offset_of_q_3() { return static_cast<int32_t>(offsetof(DsaParameter_t274855281, ___q_3)); }
	inline DerInteger_t967720487 * get_q_3() const { return ___q_3; }
	inline DerInteger_t967720487 ** get_address_of_q_3() { return &___q_3; }
	inline void set_q_3(DerInteger_t967720487 * value)
	{
		___q_3 = value;
		Il2CppCodeGenWriteBarrier(&___q_3, value);
	}

	inline static int32_t get_offset_of_g_4() { return static_cast<int32_t>(offsetof(DsaParameter_t274855281, ___g_4)); }
	inline DerInteger_t967720487 * get_g_4() const { return ___g_4; }
	inline DerInteger_t967720487 ** get_address_of_g_4() { return &___g_4; }
	inline void set_g_4(DerInteger_t967720487 * value)
	{
		___g_4 = value;
		Il2CppCodeGenWriteBarrier(&___g_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
