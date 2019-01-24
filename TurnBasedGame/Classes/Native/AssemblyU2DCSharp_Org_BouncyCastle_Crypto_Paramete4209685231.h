#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_KeyGenera650995725.h"

// Org.BouncyCastle.Crypto.Parameters.DsaParameters
struct DsaParameters_t2550649858;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DsaKeyGenerationParameters
struct  DsaKeyGenerationParameters_t4209685231  : public KeyGenerationParameters_t650995725
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DsaParameters Org.BouncyCastle.Crypto.Parameters.DsaKeyGenerationParameters::parameters
	DsaParameters_t2550649858 * ___parameters_2;

public:
	inline static int32_t get_offset_of_parameters_2() { return static_cast<int32_t>(offsetof(DsaKeyGenerationParameters_t4209685231, ___parameters_2)); }
	inline DsaParameters_t2550649858 * get_parameters_2() const { return ___parameters_2; }
	inline DsaParameters_t2550649858 ** get_address_of_parameters_2() { return &___parameters_2; }
	inline void set_parameters_2(DsaParameters_t2550649858 * value)
	{
		___parameters_2 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
