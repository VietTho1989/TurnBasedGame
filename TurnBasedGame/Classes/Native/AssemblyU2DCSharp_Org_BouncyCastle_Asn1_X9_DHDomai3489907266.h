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
// Org.BouncyCastle.Asn1.X9.DHValidationParms
struct DHValidationParms_t4010119324;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Asn1.X9.DHDomainParameters
struct  DHDomainParameters_t3489907266  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X9.DHDomainParameters::p
	DerInteger_t967720487 * ___p_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X9.DHDomainParameters::g
	DerInteger_t967720487 * ___g_3;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X9.DHDomainParameters::q
	DerInteger_t967720487 * ___q_4;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.X9.DHDomainParameters::j
	DerInteger_t967720487 * ___j_5;
	// Org.BouncyCastle.Asn1.X9.DHValidationParms Org.BouncyCastle.Asn1.X9.DHDomainParameters::validationParms
	DHValidationParms_t4010119324 * ___validationParms_6;

public:
	inline static int32_t get_offset_of_p_2() { return static_cast<int32_t>(offsetof(DHDomainParameters_t3489907266, ___p_2)); }
	inline DerInteger_t967720487 * get_p_2() const { return ___p_2; }
	inline DerInteger_t967720487 ** get_address_of_p_2() { return &___p_2; }
	inline void set_p_2(DerInteger_t967720487 * value)
	{
		___p_2 = value;
		Il2CppCodeGenWriteBarrier(&___p_2, value);
	}

	inline static int32_t get_offset_of_g_3() { return static_cast<int32_t>(offsetof(DHDomainParameters_t3489907266, ___g_3)); }
	inline DerInteger_t967720487 * get_g_3() const { return ___g_3; }
	inline DerInteger_t967720487 ** get_address_of_g_3() { return &___g_3; }
	inline void set_g_3(DerInteger_t967720487 * value)
	{
		___g_3 = value;
		Il2CppCodeGenWriteBarrier(&___g_3, value);
	}

	inline static int32_t get_offset_of_q_4() { return static_cast<int32_t>(offsetof(DHDomainParameters_t3489907266, ___q_4)); }
	inline DerInteger_t967720487 * get_q_4() const { return ___q_4; }
	inline DerInteger_t967720487 ** get_address_of_q_4() { return &___q_4; }
	inline void set_q_4(DerInteger_t967720487 * value)
	{
		___q_4 = value;
		Il2CppCodeGenWriteBarrier(&___q_4, value);
	}

	inline static int32_t get_offset_of_j_5() { return static_cast<int32_t>(offsetof(DHDomainParameters_t3489907266, ___j_5)); }
	inline DerInteger_t967720487 * get_j_5() const { return ___j_5; }
	inline DerInteger_t967720487 ** get_address_of_j_5() { return &___j_5; }
	inline void set_j_5(DerInteger_t967720487 * value)
	{
		___j_5 = value;
		Il2CppCodeGenWriteBarrier(&___j_5, value);
	}

	inline static int32_t get_offset_of_validationParms_6() { return static_cast<int32_t>(offsetof(DHDomainParameters_t3489907266, ___validationParms_6)); }
	inline DHValidationParms_t4010119324 * get_validationParms_6() const { return ___validationParms_6; }
	inline DHValidationParms_t4010119324 ** get_address_of_validationParms_6() { return &___validationParms_6; }
	inline void set_validationParms_6(DHValidationParms_t4010119324 * value)
	{
		___validationParms_6 = value;
		Il2CppCodeGenWriteBarrier(&___validationParms_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
