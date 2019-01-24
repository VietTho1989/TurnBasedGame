#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_KeyGenera650995725.h"

// Org.BouncyCastle.Crypto.Parameters.DHParameters
struct DHParameters_t431035336;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.DHKeyGenerationParameters
struct  DHKeyGenerationParameters_t1952252333  : public KeyGenerationParameters_t650995725
{
public:
	// Org.BouncyCastle.Crypto.Parameters.DHParameters Org.BouncyCastle.Crypto.Parameters.DHKeyGenerationParameters::parameters
	DHParameters_t431035336 * ___parameters_2;

public:
	inline static int32_t get_offset_of_parameters_2() { return static_cast<int32_t>(offsetof(DHKeyGenerationParameters_t1952252333, ___parameters_2)); }
	inline DHParameters_t431035336 * get_parameters_2() const { return ___parameters_2; }
	inline DHParameters_t431035336 ** get_address_of_parameters_2() { return &___parameters_2; }
	inline void set_parameters_2(DHParameters_t431035336 * value)
	{
		___parameters_2 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
