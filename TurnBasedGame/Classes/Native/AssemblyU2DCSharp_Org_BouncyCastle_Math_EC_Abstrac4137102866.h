#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_ECCurve140895757.h"

// Org.BouncyCastle.Math.BigInteger[]
struct BigIntegerU5BU5D_t431507903;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.AbstractF2mCurve
struct  AbstractF2mCurve_t4137102866  : public ECCurve_t140895757
{
public:
	// Org.BouncyCastle.Math.BigInteger[] Org.BouncyCastle.Math.EC.AbstractF2mCurve::si
	BigIntegerU5BU5D_t431507903* ___si_16;

public:
	inline static int32_t get_offset_of_si_16() { return static_cast<int32_t>(offsetof(AbstractF2mCurve_t4137102866, ___si_16)); }
	inline BigIntegerU5BU5D_t431507903* get_si_16() const { return ___si_16; }
	inline BigIntegerU5BU5D_t431507903** get_address_of_si_16() { return &___si_16; }
	inline void set_si_16(BigIntegerU5BU5D_t431507903* value)
	{
		___si_16 = value;
		Il2CppCodeGenWriteBarrier(&___si_16, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
