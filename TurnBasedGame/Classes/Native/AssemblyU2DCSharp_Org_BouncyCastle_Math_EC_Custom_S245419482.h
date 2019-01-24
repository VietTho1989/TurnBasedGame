#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Org_BouncyCastle_Math_EC_Abstrac4137102866.h"

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R2Point
struct SecT163R2Point_t3656174885;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R2Curve
struct  SecT163R2Curve_t245419482  : public AbstractF2mCurve_t4137102866
{
public:
	// Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R2Point Org.BouncyCastle.Math.EC.Custom.Sec.SecT163R2Curve::m_infinity
	SecT163R2Point_t3656174885 * ___m_infinity_18;

public:
	inline static int32_t get_offset_of_m_infinity_18() { return static_cast<int32_t>(offsetof(SecT163R2Curve_t245419482, ___m_infinity_18)); }
	inline SecT163R2Point_t3656174885 * get_m_infinity_18() const { return ___m_infinity_18; }
	inline SecT163R2Point_t3656174885 ** get_address_of_m_infinity_18() { return &___m_infinity_18; }
	inline void set_m_infinity_18(SecT163R2Point_t3656174885 * value)
	{
		___m_infinity_18 = value;
		Il2CppCodeGenWriteBarrier(&___m_infinity_18, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
