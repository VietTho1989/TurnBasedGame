#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Asymmetr1663727050.h"

// Org.BouncyCastle.Crypto.Parameters.DsaParameters
struct DsaParameters_t2550649858;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DsaKeyParameters
struct  DsaKeyParameters_t2298980877  : public AsymmetricKeyParameter_t1663727050
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DsaParameters Org.BouncyCastle.Crypto.Parameters.DsaKeyParameters::parameters
	DsaParameters_t2550649858 * ___parameters_1;

public:
	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(DsaKeyParameters_t2298980877, ___parameters_1)); }
	inline DsaParameters_t2550649858 * get_parameters_1() const { return ___parameters_1; }
	inline DsaParameters_t2550649858 ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(DsaParameters_t2550649858 * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
