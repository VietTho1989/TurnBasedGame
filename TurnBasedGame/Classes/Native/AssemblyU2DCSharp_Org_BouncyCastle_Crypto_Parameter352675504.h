#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Asymmetr1663727050.h"

// Org.BouncyCastle.Crypto.Parameters.ElGamalParameters
struct ElGamalParameters_t1215309569;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.ElGamalKeyParameters
struct  ElGamalKeyParameters_t352675504  : public AsymmetricKeyParameter_t1663727050
{
public:
	// Org.BouncyCastle.Crypto.Parameters.ElGamalParameters Org.BouncyCastle.Crypto.Parameters.ElGamalKeyParameters::parameters
	ElGamalParameters_t1215309569 * ___parameters_1;

public:
	inline static int32_t get_offset_of_parameters_1() { return static_cast<int32_t>(offsetof(ElGamalKeyParameters_t352675504, ___parameters_1)); }
	inline ElGamalParameters_t1215309569 * get_parameters_1() const { return ___parameters_1; }
	inline ElGamalParameters_t1215309569 ** get_address_of_parameters_1() { return &___parameters_1; }
	inline void set_parameters_1(ElGamalParameters_t1215309569 * value)
	{
		___parameters_1 = value;
		Il2CppCodeGenWriteBarrier(&___parameters_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
