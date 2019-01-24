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

// Org.BouncyCastle.Asn1.Pkcs.DHParameter
struct  DHParameter_t310369835  : public Asn1Encodable_t3447851422
{
public:
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.DHParameter::p
	DerInteger_t967720487 * ___p_2;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.DHParameter::g
	DerInteger_t967720487 * ___g_3;
	// Org.BouncyCastle.Asn1.DerInteger Org.BouncyCastle.Asn1.Pkcs.DHParameter::l
	DerInteger_t967720487 * ___l_4;

public:
	inline static int32_t get_offset_of_p_2() { return static_cast<int32_t>(offsetof(DHParameter_t310369835, ___p_2)); }
	inline DerInteger_t967720487 * get_p_2() const { return ___p_2; }
	inline DerInteger_t967720487 ** get_address_of_p_2() { return &___p_2; }
	inline void set_p_2(DerInteger_t967720487 * value)
	{
		___p_2 = value;
		Il2CppCodeGenWriteBarrier(&___p_2, value);
	}

	inline static int32_t get_offset_of_g_3() { return static_cast<int32_t>(offsetof(DHParameter_t310369835, ___g_3)); }
	inline DerInteger_t967720487 * get_g_3() const { return ___g_3; }
	inline DerInteger_t967720487 ** get_address_of_g_3() { return &___g_3; }
	inline void set_g_3(DerInteger_t967720487 * value)
	{
		___g_3 = value;
		Il2CppCodeGenWriteBarrier(&___g_3, value);
	}

	inline static int32_t get_offset_of_l_4() { return static_cast<int32_t>(offsetof(DHParameter_t310369835, ___l_4)); }
	inline DerInteger_t967720487 * get_l_4() const { return ___l_4; }
	inline DerInteger_t967720487 ** get_address_of_l_4() { return &___l_4; }
	inline void set_l_4(DerInteger_t967720487 * value)
	{
		___l_4 = value;
		Il2CppCodeGenWriteBarrier(&___l_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
