#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Crypto_Parameter215653120.h"





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Crypto.Parameters.RC2Parameters
struct  RC2Parameters_t852146563  : public KeyParameter_t215653120
{
public:
	// System.Int32 Org.BouncyCastle.Crypto.Parameters.RC2Parameters::bits
	int32_t ___bits_1;

public:
	inline static int32_t get_offset_of_bits_1() { return static_cast<int32_t>(offsetof(RC2Parameters_t852146563, ___bits_1)); }
	inline int32_t get_bits_1() const { return ___bits_1; }
	inline int32_t* get_address_of_bits_1() { return &___bits_1; }
	inline void set_bits_1(int32_t value)
	{
		___bits_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
