#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Abstrac4137102866.h"

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT283K1Point
struct SecT283K1Point_t1967734354;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT283K1Curve
struct  SecT283K1Curve_t1564258929  : public AbstractF2mCurve_t4137102866
{
public:
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecT283K1Point Org.BouncyCastle.Math.EC.Custom.Sec.SecT283K1Curve::m_infinity
	SecT283K1Point_t1967734354 * ___m_infinity_18;

public:
	inline static int32_t get_offset_of_m_infinity_18() { return static_cast<int32_t>(offsetof(SecT283K1Curve_t1564258929, ___m_infinity_18)); }
	inline SecT283K1Point_t1967734354 * get_m_infinity_18() const { return ___m_infinity_18; }
	inline SecT283K1Point_t1967734354 ** get_address_of_m_infinity_18() { return &___m_infinity_18; }
	inline void set_m_infinity_18(SecT283K1Point_t1967734354 * value)
	{
		___m_infinity_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
