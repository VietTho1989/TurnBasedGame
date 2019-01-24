#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_KeyGenera650995725.h"

// Org.BouncyCastle.Crypto.Parameters.ElGamalParameters
struct ElGamalParameters_t1215309569;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ElGamalKeyGenerationParameters
struct  ElGamalKeyGenerationParameters_t303785198  : public KeyGenerationParameters_t650995725
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ElGamalParameters Org.BouncyCastle.Crypto.Parameters.ElGamalKeyGenerationParameters::parameters
	ElGamalParameters_t1215309569 * ___parameters_2;

public:
	inline static int32_t get_offset_of_parameters_2() { return static_cast<int32_t>(offsetof(ElGamalKeyGenerationParameters_t303785198, ___parameters_2)); }
	inline ElGamalParameters_t1215309569 * get_parameters_2() const { return ___parameters_2; }
	inline ElGamalParameters_t1215309569 ** get_address_of_parameters_2() { return &___parameters_2; }
	inline void set_parameters_2(ElGamalParameters_t1215309569 * value)
	{
		___parameters_2 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
