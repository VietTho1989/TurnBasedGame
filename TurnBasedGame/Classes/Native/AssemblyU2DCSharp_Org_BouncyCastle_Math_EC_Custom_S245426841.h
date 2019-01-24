#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Abstrac4137102866.h"

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R1Point
struct SecT163R1Point_t3656182376;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R1Curve
struct  SecT163R1Curve_t245426841  : public AbstractF2mCurve_t4137102866
{
public:
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R1Point Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R1Curve::m_infinity
	SecT163R1Point_t3656182376 * ___m_infinity_18;

public:
	inline static int32_t get_offset_of_m_infinity_18() { return static_cast<int32_t>(offsetof(SecT163R1Curve_t245426841, ___m_infinity_18)); }
	inline SecT163R1Point_t3656182376 * get_m_infinity_18() const { return ___m_infinity_18; }
	inline SecT163R1Point_t3656182376 ** get_address_of_m_infinity_18() { return &___m_infinity_18; }
	inline void set_m_infinity_18(SecT163R1Point_t3656182376 * value)
	{
		___m_infinity_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
