#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// Org.BouncyCastle.Math.EC.ECPoint[]
struct ECPointU5BU5D_t1061550629;
// Org.BouncyCastle.Math.EC.ECPoint
struct ECPoint_t626351532;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Org.BouncyCastle.Math.EC.Multiplier.WNafPreCompInfo
struct  WNafPreCompInfo_t485024160  : public Il2CppObject
{
public:
	// Org.BouncyCastle.Math.EC.ECPoint[] Org.BouncyCastle.Math.EC.Multiplier.WNafPreCompInfo::m_preComp
	ECPointU5BU5D_t1061550629* ___m_preComp_0;
	// Org.BouncyCastle.Math.EC.ECPoint[] Org.BouncyCastle.Math.EC.Multiplier.WNafPreCompInfo::m_preCompNeg
	ECPointU5BU5D_t1061550629* ___m_preCompNeg_1;
	// Org.BouncyCastle.Math.EC.ECPoint Org.BouncyCastle.Math.EC.Multiplier.WNafPreCompInfo::m_twice
	ECPoint_t626351532 * ___m_twice_2;

public:
	inline static int32_t get_offset_of_m_preComp_0() { return static_cast<int32_t>(offsetof(WNafPreCompInfo_t485024160, ___m_preComp_0)); }
	inline ECPointU5BU5D_t1061550629* get_m_preComp_0() const { return ___m_preComp_0; }
	inline ECPointU5BU5D_t1061550629** get_address_of_m_preComp_0() { return &___m_preComp_0; }
	inline void set_m_preComp_0(ECPointU5BU5D_t1061550629* value)
	{
		___m_preComp_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_preComp_0, value);
	}

	inline static int32_t get_offset_of_m_preCompNeg_1() { return static_cast<int32_t>(offsetof(WNafPreCompInfo_t485024160, ___m_preCompNeg_1)); }
	inline ECPointU5BU5D_t1061550629* get_m_preCompNeg_1() const { return ___m_preCompNeg_1; }
	inline ECPointU5BU5D_t1061550629** get_address_of_m_preCompNeg_1() { return &___m_preCompNeg_1; }
	inline void set_m_preCompNeg_1(ECPointU5BU5D_t1061550629* value)
	{
		___m_preCompNeg_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_preCompNeg_1, value);
	}

	inline static int32_t get_offset_of_m_twice_2() { return static_cast<int32_t>(offsetof(WNafPreCompInfo_t485024160, ___m_twice_2)); }
	inline ECPoint_t626351532 * get_m_twice_2() const { return ___m_twice_2; }
	inline ECPoint_t626351532 ** get_address_of_m_twice_2() { return &___m_twice_2; }
	inline void set_m_twice_2(ECPoint_t626351532 * value)
	{
		___m_twice_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_twice_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
